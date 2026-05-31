using MBColumn.Application.DTOs;
using MBColumn.Application.DTOs.Persistence;
using MBColumn.Application.Reports.Builders;
using MBColumn.Application.Reports.Models;
using MBColumn.Application.Services;
using MBColumn.Domain.Enums;
using MBColumn.Domain.Interfaces;
using MBColumn.Infrastructure.Reports.Pdf;
using MBColumn.Infrastructure.DesignCodes;
using MBColumn.Infrastructure.Math;
using MBColumn.Presentation.Wpf.Commands;
using MBColumn.Presentation.Wpf.Services;
using MBColumn.Presentation.Wpf.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MBColumn.Presentation.Wpf.ViewModels;

public sealed class BatchPrintWindowViewModel : ViewModelBase
{
    private readonly IProjectService _projectService;
    private readonly ProjectSession _projectSession;
    private readonly ColumnCalculationService _calculationService;
    private readonly IMessageService _messageService;
    private readonly ProjectExplorerViewModel _explorer;
    private readonly Func<InputViewModel> _inputFactory;

    private string _outputPath = "";
    private bool _keepProjectStructure = true;
    private bool _flatFiles = false;
    private bool _compiledReport = false;
    private bool _isCalculating;

    public event EventHandler? RequestClose;

    public ObservableCollection<ExplorerNodeViewModel> Nodes { get; }

    public BatchPrintWindowViewModel(
        IProjectService projectService,
        ProjectSession projectSession,
        ColumnCalculationService calculationService,
        IMessageService messageService,
        ProjectExplorerViewModel explorer,
        Func<InputViewModel> inputFactory)
    {
        _projectService = projectService;
        _projectSession = projectSession;
        _calculationService = calculationService;
        _messageService = messageService;
        _explorer = explorer;
        _inputFactory = inputFactory;

        Nodes = new ObservableCollection<ExplorerNodeViewModel>(_explorer.Nodes);

        BrowseFolderCommand = new RelayCommand(BrowseFolder);
        SelectAllCommand = new RelayCommand(SelectAll);
        ClearAllCommand = new RelayCommand(ClearAll);
        PrintSelectedCommand = new AsyncRelayCommand(async () => await PrintSelectedAsync(), () => !IsCalculating && !string.IsNullOrWhiteSpace(OutputPath));
        PrintAllCommand = new AsyncRelayCommand(async () => await PrintAllAsync(), () => !IsCalculating && !string.IsNullOrWhiteSpace(OutputPath));

        OutputPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MBColumn Reports");
    }

    public string OutputPath
    {
        get => _outputPath;
        set
        {
            if (Set(ref _outputPath, value))
            {
                RaisePrintCanExecute();
            }
        }
    }

    public bool KeepProjectStructure
    {
        get => _keepProjectStructure;
        set => Set(ref _keepProjectStructure, value);
    }

    public bool FlatFiles
    {
        get => _flatFiles;
        set => Set(ref _flatFiles, value);
    }

    public bool CompiledReport
    {
        get => _compiledReport;
        set => Set(ref _compiledReport, value);
    }

    public bool IsCalculating
    {
        get => _isCalculating;
        set
        {
            if (Set(ref _isCalculating, value))
            {
                RaisePrintCanExecute();
            }
        }
    }

    public ICommand BrowseFolderCommand { get; }
    public ICommand SelectAllCommand { get; }
    public ICommand ClearAllCommand { get; }
    public ICommand PrintSelectedCommand { get; }
    public ICommand PrintAllCommand { get; }

    private void RaisePrintCanExecute()
    {
        (PrintSelectedCommand as AsyncRelayCommand)?.RaiseCanExecuteChanged();
        (PrintAllCommand as AsyncRelayCommand)?.RaiseCanExecuteChanged();
    }

    private void BrowseFolder()
    {
        var folderDialog = new Microsoft.Win32.OpenFolderDialog
        {
            Title = "Select Destination Folder for PDF Reports"
        };
        if (folderDialog.ShowDialog() == true)
        {
            OutputPath = folderDialog.FolderName;
        }
    }

    private void SelectAll()
    {
        foreach (var node in Nodes)
        {
            node.IsChecked = true;
        }
    }

    private void ClearAll()
    {
        foreach (var node in Nodes)
        {
            node.IsChecked = false;
        }
    }

    private async Task PrintAllAsync()
    {
        SelectAll();
        await PrintSelectedAsync();
    }

    private async Task PrintSelectedAsync()
    {
        var selectedIds = new List<int>();
        foreach (var node in Nodes)
        {
            if (node is GroupItemViewModel g)
            {
                foreach (var c in g.Columns)
                {
                    if (c.IsChecked == true)
                    {
                        selectedIds.Add(c.Id);
                    }
                }
            }
            else if (node is ColumnItemViewModel c && c.IsChecked == true)
            {
                selectedIds.Add(c.Id);
            }
        }

        if (selectedIds.Count == 0)
        {
            _messageService.ShowInformation("Please check one or more sections to print.", "Print Scope");
            return;
        }

        string outputDir = OutputPath;
        if (!Directory.Exists(outputDir))
        {
            try
            {
                Directory.CreateDirectory(outputDir);
            }
            catch (Exception ex)
            {
                _messageService.ShowError($"Could not create destination folder:\n{ex.Message}", "Print Error");
                return;
            }
        }

        var toCalculate = new List<(int Id, string Name, ColumnInputSnapshot Snapshot)>();
        foreach (var id in selectedIds)
        {
            var col = _projectService.GetColumns().FirstOrDefault(c => c.Id == id);
            if (col is null) continue;
            var result = _projectService.LoadColumnResult(id);
            var status = _explorer.Nodes.OfType<ColumnItemViewModel>().FirstOrDefault(c => c.Id == id)?.Status
                         ?? _explorer.Nodes.OfType<GroupItemViewModel>().SelectMany(g => g.Columns).FirstOrDefault(c => c.Id == id)?.Status;
            
            if (result is null || status != SectionStatus.Calculated)
            {
                var snapshot = _projectService.LoadColumnInput(id);
                if (snapshot is not null)
                {
                    toCalculate.Add((id, col.Name, snapshot));
                }
            }
        }

        if (toCalculate.Count > 0)
        {
            IsCalculating = true;
            CalculationProgressWindow? progressWindow = null;
            System.Windows.Application.Current?.Dispatcher.Invoke(() =>
            {
                progressWindow = new CalculationProgressWindow
                {
                    Owner = System.Windows.Application.Current.MainWindow,
                    ProgressMax = toCalculate.Count,
                    ProgressValue = 0,
                    StatusText = $"Calculating: [0/{toCalculate.Count}] calculated"
                };
                progressWindow.Show();
            });

            var backgroundResults = await Task.Run(() =>
            {
                var results = new List<(int ColumnId, string Name, CalculationResultDto? Result, string? Error)>();
                var localInput = _inputFactory();

                int calculatedCount = 0;
                foreach (var item in toCalculate)
                {
                    try
                    {
                        localInput.LoadFromSnapshot(item.Snapshot);
                        var result = _calculationService.Calculate(localInput.ToDto());
                        results.Add((item.Id, item.Name, result, null));
                    }
                    catch (Exception ex)
                    {
                        results.Add((item.Id, item.Name, null, ex.Message));
                    }
                    finally
                    {
                        calculatedCount++;
                        int currentCount = calculatedCount;
                        System.Windows.Application.Current?.Dispatcher.InvokeAsync(() =>
                        {
                            try
                            {
                                if (progressWindow is not null && progressWindow.IsLoaded)
                                {
                                    progressWindow.ProgressValue = currentCount;
                                    progressWindow.StatusText = $"Calculating: [{currentCount}/{toCalculate.Count}] calculated";
                                }
                            }
                            catch { }
                        });
                    }
                }
                return results;
            });

            System.Windows.Application.Current?.Dispatcher.Invoke(() =>
            {
                try
                {
                    if (progressWindow is not null && progressWindow.IsLoaded)
                        progressWindow.Close();
                }
                catch { }
            });

            var failedColumns = new List<string>();
            foreach (var item in backgroundResults)
            {
                var columnId = item.ColumnId;
                if (item.Result is not null)
                {
                    _projectSession.StoreColumnResult(columnId, item.Result);
                    _projectService.SaveColumnResult(columnId, item.Result);
                    _explorer.SetSectionStatus(columnId, SectionStatus.Calculated);
                }
                else if (item.Error is not null)
                {
                    _explorer.SetSectionStatus(columnId, SectionStatus.Error);
                    failedColumns.Add($"{item.Name}: {item.Error}");
                }
            }

            IsCalculating = false;

            if (failedColumns.Count > 0)
            {
                _messageService.ShowWarning($"Batch print aborted. The following sections failed calculation:\n\n{string.Join(Environment.NewLine, failedColumns)}", "Print Cancelled");
                return;
            }
        }

        CalculationProgressWindow? printProgressWindow = null;
        System.Windows.Application.Current?.Dispatcher.Invoke(() =>
        {
            printProgressWindow = new CalculationProgressWindow
            {
                Owner = System.Windows.Application.Current.MainWindow,
                ProgressMax = selectedIds.Count,
                ProgressValue = 0,
                StatusText = $"Generating reports: [0/{selectedIds.Count}] completed"
            };
            printProgressWindow.Show();
        });

        string? errorMsg = null;
        try
        {
            await Task.Run(() =>
            {
                var generatedReports = new List<(string TempPath, string ColumnName, ReportData Data)>();
                int printedCount = 0;

                foreach (var id in selectedIds)
                {
                    var result = _projectService.LoadColumnResult(id);
                    var col = _projectService.GetColumns().FirstOrDefault(c => c.Id == id);
                    if (result is null || col is null) continue;

                    string columnName = col.Name;
                    string groupName = _projectService.GetGroups().FirstOrDefault(g => g.Id == col.GroupId)?.Name ?? "Default";
                    string projectName = _projectService.ProjectName;

                    IDesignCodeService codeService = result.DesignCode == DesignCodeType.Aci318Style
                        ? new Aci318DesignCodeService()
                        : new Ec2DesignCodeService { AlphaCc = result.AlphaCc };
                    IUnitConversionService unitService = new UnitConversionService();

                    string? sectionSvg = null;
                    try
                    {
                        sectionSvg = MBColumn.Infrastructure.Reports.Graphics.SectionGeometryRenderer.RenderSection(
                            result.SectionShape,
                            result.SectionWidthMm, result.SectionHeightMm,
                            result.DiameterMm > 0 ? result.DiameterMm : result.SectionWidthMm,
                            result.CoverMm, result.RebarCoordinates);
                    }
                    catch { }

                    DiagramBlock? pmDiagramBlock = null, mmDiagramBlock = null;
                    try
                    {
                        var diag = new DiagramDataService();
                        double theta = result.GoverningThetaDegrees;
                        var pmData = diag.BuildPmAngleDiagramData(result.ControlPoints, result.UnitSystem, theta);
                        var pmAll = pmData.Points.Concat(diag.BuildPmAngleDemandPoints(result.LoadCaseResults, theta)).Concat(pmData.SpecialCapacityPoints).ToList();
                        pmDiagramBlock = new DiagramBlock(pmAll, pmData.ReferenceLines,
                            $"M ({pmData.MUnit})", $"P ({pmData.PUnit})", result.Ratio,
                            UseEqualAspect: false, WidthPct: 90,
                            Caption: $"Figure 8.1 – P-M interaction diagram at θ = {theta:F1}°");

                        var mmData = diag.BuildMxMyDiagramDataAtDisplayP(result.ControlPoints, result.UnitSystem, result.PuDisplay);
                        var mmAll = mmData.Points.Concat(diag.BuildMxMyDemandPoints(result.LoadCaseResults)).ToList();
                        mmDiagramBlock = new DiagramBlock(mmAll, [],
                            $"Mx ({mmData.MUnit})", $"My ({mmData.MUnit})", result.Ratio,
                            UseEqualAspect: true, WidthPct: 80,
                            Caption: "Figure 8.2 – Mx-My interaction diagram at governing axial load");
                    }
                    catch { }

                    var builder = new CalculationReportBuilder();
                    var reportData = builder.Build(projectName, groupName, columnName,
                                                   result, codeService, unitService, sectionSvg,
                                                   pmDiagram: pmDiagramBlock, mmDiagram: mmDiagramBlock);

                    string safeName = string.Join("_", columnName.Split(Path.GetInvalidFileNameChars()));
                    string safeGroupName = string.Join("_", groupName.Split(Path.GetInvalidFileNameChars()));

                    string tempPdfPath = Path.Combine(Path.GetTempPath(), $"MBColumn_Temp_{Guid.NewGuid():N}.pdf");
                    var pdfRenderer = new QuestPdfCalculationReportRenderer();
                    pdfRenderer.RenderToFile(reportData, tempPdfPath);

                    generatedReports.Add((tempPdfPath, $"{groupName} - {columnName}", reportData));

                    if (!CompiledReport)
                    {
                        string finalPath;
                        if (KeepProjectStructure)
                        {
                            string subDir = Path.Combine(outputDir, safeGroupName);
                            if (!Directory.Exists(subDir)) Directory.CreateDirectory(subDir);
                            finalPath = Path.Combine(subDir, $"{safeName}_Report.pdf");
                        }
                        else
                        {
                            finalPath = Path.Combine(outputDir, $"{safeGroupName}_{safeName}_Report.pdf");
                        }

                        if (File.Exists(finalPath)) File.Delete(finalPath);
                        File.Move(tempPdfPath, finalPath);
                    }

                    printedCount++;
                    int currentPrint = printedCount;
                    System.Windows.Application.Current?.Dispatcher.InvokeAsync(() =>
                    {
                        try
                        {
                            if (printProgressWindow is not null && printProgressWindow.IsLoaded)
                            {
                                printProgressWindow.ProgressValue = currentPrint;
                                printProgressWindow.StatusText = $"Generating reports: [{currentPrint}/{selectedIds.Count}] completed";
                            }
                        }
                        catch { }
                    });
                }

                if (CompiledReport && generatedReports.Count > 0)
                {
                    string safeProjectName = string.Join("_", _projectService.ProjectName.Split(Path.GetInvalidFileNameChars()));
                    if (string.IsNullOrWhiteSpace(safeProjectName)) safeProjectName = "MBColumn_Compiled_Report";
                    string finalPath = Path.Combine(outputDir, $"{safeProjectName}.pdf");

                    PdfMergeUtility.MergePdfDocuments(generatedReports, finalPath);

                    foreach (var report in generatedReports)
                    {
                        try
                        {
                            if (File.Exists(report.TempPath)) File.Delete(report.TempPath);
                        }
                        catch { }
                    }
                }
            });
        }
        catch (Exception ex)
        {
            errorMsg = ex.Message;
        }
        finally
        {
            System.Windows.Application.Current?.Dispatcher.Invoke(() =>
            {
                try
                {
                    if (printProgressWindow is not null && printProgressWindow.IsLoaded)
                        printProgressWindow.Close();
                }
                catch { }
            });
        }

        if (errorMsg is not null)
        {
            _messageService.ShowError($"Export failed:\n{errorMsg}", "Print Error");
        }
        else
        {
            _messageService.ShowInformation($"Successfully exported {selectedIds.Count} PDF report(s) to:\n{outputDir}", "Print Complete");
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
    }
}
