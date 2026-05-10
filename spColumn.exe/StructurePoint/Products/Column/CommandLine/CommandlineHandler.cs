using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using #58e;
using #7hc;
using #AUi;
using #P6e;
using #pXd;
using #UYd;
using #v1c;
using #wRb;
using Alphaleonis.Win32.Filesystem;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.BatchExecution;
using StructurePoint.Products.Column.BatchExecution.Execution;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.CommandLine
{
	// Token: 0x020006C9 RID: 1737
	internal sealed class CommandlineHandler : #bUi
	{
		// Token: 0x060039CB RID: 14795 RVA: 0x00032353 File Offset: 0x00030553
		public CommandlineHandler(#XWi feedback, #0Ui executorFactory, #v2c fileSystem, ILogger logger, ISettingsManager settingsManager)
		{
			this.#a = feedback;
			this.#b = executorFactory;
			this.#c = fileSystem;
			this.#d = logger;
			this.#e = settingsManager;
		}

		// Token: 0x060039CC RID: 14796 RVA: 0x00032380 File Offset: 0x00030580
		public void #3Ab(CommandLineParameters #Pc)
		{
			if (#Pc.Batch)
			{
				this.#eUi(#Pc);
				return;
			}
			this.#fUi(#Pc);
		}

		// Token: 0x060039CD RID: 14797 RVA: 0x00112B50 File Offset: 0x00110D50
		private void #RTi(object #Ge, #TUi #He)
		{
			#TYd.#npb(#TYd.InfoColor, Strings.StringBatchProcessor0Of1FilesProcessed.#D2d(new object[]
			{
				#He.Current,
				#He.Total
			}).#z2d(), true);
		}

		// Token: 0x060039CE RID: 14798 RVA: 0x00112BA8 File Offset: 0x00110DA8
		private static string #0Rb(string #cUi, string #c4, bool #1Rb, string #In)
		{
			if (!string.IsNullOrWhiteSpace(#c4))
			{
				if (#c4.StartsWith(#Phc.#3hc(107350811)))
				{
					#c4 = #c4.Substring(1);
				}
				if (#c4.EndsWith(#Phc.#3hc(107350811)))
				{
					#c4 = #c4.Substring(0, #c4.Length - 1);
				}
				return #c4;
			}
			if (#1Rb)
			{
				return Path.GetFullPath(Path.ChangeExtension(#cUi, #In));
			}
			return null;
		}

		// Token: 0x060039CF RID: 14799 RVA: 0x00112C1C File Offset: 0x00110E1C
		private static string #dUi(string #cUi, string #c4, bool #1Rb)
		{
			if (!string.IsNullOrWhiteSpace(#c4))
			{
				if (#c4.StartsWith(#Phc.#3hc(107350811)))
				{
					#c4 = #c4.Substring(1);
				}
				if (#c4.EndsWith(#Phc.#3hc(107350811)))
				{
					#c4 = #c4.Substring(0, #c4.Length - 1);
				}
				return #c4;
			}
			if (#1Rb)
			{
				return #cUi;
			}
			return null;
		}

		// Token: 0x060039D0 RID: 14800 RVA: 0x00112C84 File Offset: 0x00110E84
		private void #eUi(CommandLineParameters #Pc)
		{
			this.#hUi(#Pc);
			if (!this.#c.#X1c(#Pc.OutputPath))
			{
				this.#c.#k2c(#Pc.OutputPath);
			}
			ProjectExecutionParameters projectExecutionParameters = this.#gUi(#Pc);
			IList<string> list = BatchExecutorHelper.#GUi(this.#c, projectExecutionParameters.InputPath);
			this.#a.#pn(Strings.StringBatchProcessorSearchingForInputFiles.#B2d());
			IEnumerable<string> source = list;
			Func<string, string> selector;
			if ((selector = CommandlineHandler.#2Ui.#a) == null)
			{
				selector = (CommandlineHandler.#2Ui.#a = new Func<string, string>(Path.GetFileNameWithoutExtension));
			}
			HashSet<string> hashSet = source.Select(selector).Select(new Func<string, string>(CommandlineHandler.<>c.<>9.#kUi)).ToHashSet<string>();
			if (hashSet.Count != list.Count)
			{
				this.#a.#tn(Strings.StringFilesWithTheSameNameButDifferentExtensionsDetected.#z2d(true) + Strings.StringOutputFilesWillBeOverwritten.#z2d());
			}
			List<BatchItemViewModel> #vUi = list.Select(new Func<string, BatchItemViewModel>(this.#BXi)).ToList<BatchItemViewModel>();
			this.#a.#pn(Strings.StringBatchProcessor0FileSFound.#D2d(new object[]
			{
				list.Count
			}).#z2d());
			#FUi #FUi = new #FUi(this.#c);
			#FUi.Progress += this.#RTi;
			Task task = #FUi.#0(#vUi, new #SUi
			{
				ExecutionParameters = projectExecutionParameters,
				CancellationTokenSource = new CancellationTokenSource(),
				SummaryPath = this.#iUi(#Pc),
				NumberOfThreads = this.#e.CmdBatchNumberOfThreads
			});
			task.Wait();
			Console.WriteLine();
			string # = BatchExecutorHelper.#HUi(#vUi, #Pc.InputPath, #Pc.OutputPath, this.#iUi(#Pc));
			this.#a.#pn(#);
		}

		// Token: 0x060039D1 RID: 14801 RVA: 0x00112E60 File Offset: 0x00111060
		private void #fUi(CommandLineParameters #Pc)
		{
			this.#jUi(#Pc);
			try
			{
				ProjectExecutionParameters #Pc2 = this.#gUi(#Pc);
				#UUi #UUi = this.#b.#ul(this.#a);
				#UUi.#0(#Pc2, #OXd.None, new #O6e(this.#e.DiagramInterpolationConvergenceEpsilonPercentage), true);
			}
			catch (#EXi)
			{
			}
		}

		// Token: 0x060039D2 RID: 14802 RVA: 0x00112ED0 File Offset: 0x001110D0
		private ProjectExecutionParameters #gUi(CommandLineParameters #xQb)
		{
			return new ProjectExecutionParameters
			{
				InputPath = #xQb.InputPath,
				TextReportPath = #xQb.OutputPath,
				PdfReportPath = #xQb.PdfReportPath,
				WordReportPath = #xQb.WordReportPath,
				CsvReportPath = #xQb.CsvReportPath,
				ExcelReportPath = #xQb.ExcelReportPath,
				CtiPath = #xQb.CtiPath,
				DxfPath = #xQb.DxfPath,
				CsvDiagramPath = #xQb.CsvDiagramPath,
				TxtDiagramPath = #xQb.TxtDiagramPath,
				TestMode = #xQb.TestMode,
				ContinueProcessingWhenBarsAreOutsideOfSection = #xQb.ContinueProcessingWhenBarsAreOutsideOfSection,
				IncludeNominalDiagram = #xQb.IncludeNominalDiagram,
				IsColumnArchitectural = #xQb.IsColumnArchitectural,
				RemoveDuplicateLoads = #xQb.RemoveDuplicateLoads,
				DiagramInterpolationConvergenceEpsilon = new float?(#xQb.DiagramInterpolationConvergenceEpsilon ?? this.#e.DiagramInterpolationConvergenceEpsilonPercentage),
				LateralLoadsCompatibilityMode = #xQb.LateralLoadsCompatibilityMode,
				ContinueProcessingWhenRhoIsGreaterThanEight = #xQb.ContinueProcessingWhenRhoIsGreaterThanEight,
				CreateErrorLogFiles = true
			};
		}

		// Token: 0x060039D3 RID: 14803 RVA: 0x00113004 File Offset: 0x00111204
		private void #hUi(CommandLineParameters #Pc)
		{
			this.#a.#pn(Strings.StringProcessingArguments.#B2d());
			#Pc.InputPath = Path.GetFullPath(#Pc.InputPath);
			string text = #Pc.OutputPath;
			#Pc.OutputPath = (string.IsNullOrWhiteSpace((text != null) ? text.Trim() : null) ? #Pc.InputPath : #Pc.OutputPath);
			#Pc.OutputPath = Path.GetFullPath(#Pc.OutputPath);
			#Pc.CsvReportPath = CommandlineHandler.#dUi(#Pc.OutputPath, #Pc.CsvReportPath, #Pc.CsvReportRequested);
			#Pc.PdfReportPath = CommandlineHandler.#dUi(#Pc.OutputPath, #Pc.PdfReportPath, #Pc.PdfReportRequested);
			#Pc.WordReportPath = CommandlineHandler.#dUi(#Pc.OutputPath, #Pc.WordReportPath, #Pc.WordReportRequested);
			#Pc.ExcelReportPath = CommandlineHandler.#dUi(#Pc.OutputPath, #Pc.ExcelReportPath, #Pc.ExcelReportRequested);
			#Pc.CtiPath = CommandlineHandler.#dUi(#Pc.OutputPath, #Pc.CtiPath, #Pc.CtiRequested);
			#Pc.CsvDiagramPath = CommandlineHandler.#dUi(#Pc.OutputPath, #Pc.CsvDiagramPath, #Pc.ExportCsvDiagram);
			#Pc.TxtDiagramPath = CommandlineHandler.#dUi(#Pc.OutputPath, #Pc.TxtDiagramPath, #Pc.ExportTxtDiagram);
			#Pc.DxfPath = CommandlineHandler.#dUi(#Pc.OutputPath, #Pc.DxfPath, #Pc.ExportDxf);
		}

		// Token: 0x060039D4 RID: 14804 RVA: 0x0011317C File Offset: 0x0011137C
		private string #iUi(CommandLineParameters #Pc)
		{
			string summaryFileName = this.#e.BatchProcessorSettings.SummaryFileName;
			string text = #Pc.InputPath;
			return Path.Combine(new string[]
			{
				text,
				summaryFileName
			});
		}

		// Token: 0x060039D5 RID: 14805 RVA: 0x001131C0 File Offset: 0x001113C0
		private void #jUi(CommandLineParameters #Pc)
		{
			this.#a.#pn(Strings.StringProcessingArguments.#B2d());
			#Pc.InputPath = Path.GetFullPath(#Pc.InputPath);
			#Pc.OutputPath = CommandlineHandler.#0Rb(#Pc.InputPath, #Pc.OutputPath, true, #Phc.#3hc(107413479));
			#Pc.CsvReportPath = CommandlineHandler.#0Rb(#Pc.OutputPath, #Pc.CsvReportPath, #Pc.CsvReportRequested, #Phc.#3hc(107408483));
			#Pc.PdfReportPath = CommandlineHandler.#0Rb(#Pc.OutputPath, #Pc.PdfReportPath, #Pc.PdfReportRequested, #Phc.#3hc(107350806));
			#Pc.WordReportPath = CommandlineHandler.#0Rb(#Pc.OutputPath, #Pc.WordReportPath, #Pc.WordReportRequested, #Phc.#3hc(107350801));
			#Pc.ExcelReportPath = CommandlineHandler.#0Rb(#Pc.OutputPath, #Pc.ExcelReportPath, #Pc.ExcelReportRequested, #Phc.#3hc(107350248));
			#Pc.CtiPath = CommandlineHandler.#0Rb(#Pc.OutputPath, #Pc.CtiPath, #Pc.CtiRequested, #Phc.#3hc(107350271));
			#Pc.CsvDiagramPath = CommandlineHandler.#0Rb(#Pc.OutputPath, #Pc.CsvDiagramPath, #Pc.ExportCsvDiagram, #Phc.#3hc(107408483));
			#Pc.TxtDiagramPath = CommandlineHandler.#0Rb(#Pc.OutputPath, #Pc.TxtDiagramPath, #Pc.ExportTxtDiagram, #Phc.#3hc(107413479));
			#Pc.DxfPath = CommandlineHandler.#0Rb(#Pc.OutputPath, #Pc.DxfPath, #Pc.ExportDxf, #Phc.#3hc(107350266));
		}

		// Token: 0x060039D6 RID: 14806 RVA: 0x000323A5 File Offset: 0x000305A5
		[CompilerGenerated]
		private BatchItemViewModel #BXi(string #bp)
		{
			return new BatchItemViewModel(#bp, this.#b, this.#d, #OXd.None, this.#e);
		}

		// Token: 0x04001885 RID: 6277
		private readonly #XWi #a;

		// Token: 0x04001886 RID: 6278
		private readonly #0Ui #b;

		// Token: 0x04001887 RID: 6279
		private readonly #v2c #c;

		// Token: 0x04001888 RID: 6280
		private readonly ILogger #d;

		// Token: 0x04001889 RID: 6281
		private readonly ISettingsManager #e;

		// Token: 0x020006CA RID: 1738
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x0400188A RID: 6282
			public static Func<string, string> #a;
		}
	}
}
