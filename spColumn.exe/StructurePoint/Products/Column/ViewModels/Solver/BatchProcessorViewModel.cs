using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using #7hc;
using #AUi;
using #cYd;
using #lH;
using #Mb;
using #Mn;
using #o1d;
using #pXd;
using Alphaleonis.Win32.Filesystem;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.BatchExecution;
using StructurePoint.Products.Column.BatchExecution.Execution;
using StructurePoint.Products.Column.Core.Application.Misc;
using StructurePoint.Products.Column.Services.API;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.ViewModels.Solver
{
	// Token: 0x02000116 RID: 278
	internal sealed class BatchProcessorViewModel : #HH<#Lb>, INotifyPropertyChanged, IViewModel<#Lb>, IViewModel, #Ln
	{
		// Token: 0x060008FA RID: 2298 RVA: 0x000941C8 File Offset: 0x000923C8
		public BatchProcessorViewModel(Lazy<#Lb> view, ICoreServices services, #0Ui projectExecutorFactory) : base(view, services)
		{
			this.#a = projectExecutorFactory;
			this.#B = new DelegateCommand(new Action<object>(this.#Jo), new Predicate<object>(this.#Ko));
			this.#C = new DelegateCommand(new Action<object>(this.#Vo), new Predicate<object>(this.#Wo));
			this.#D = new DelegateCommand(new Action<object>(this.#Xo), new Predicate<object>(this.#Yo));
			this.#E = new DelegateCommand(new Action<object>(this.#Ug), new Predicate<object>(this.#Zo));
			this.#A = new DelegateCommand(new Action<object>(this.#Do), new Predicate<object>(this.#Eo));
			this.IsBusy = false;
		}

		// Token: 0x170003D9 RID: 985
		// (get) Token: 0x060008FB RID: 2299 RVA: 0x0000CE39 File Offset: 0x0000B039
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x170003DA RID: 986
		// (get) Token: 0x060008FC RID: 2300 RVA: 0x0000CE49 File Offset: 0x0000B049
		// (set) Token: 0x060008FD RID: 2301 RVA: 0x000942B0 File Offset: 0x000924B0
		public string DataFolder
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107381206));
					this.#yl();
					this.#b = (value ?? string.Empty);
					this.#vh();
					base.RaisePropertyChanged(#Phc.#3hc(107381206));
				}
				if (base.FileSystem.#X1c(this.#b))
				{
					this.#6o(new Action(this.#Lo), Strings.StringLoadingFiles);
				}
			}
		}

		// Token: 0x170003DB RID: 987
		// (get) Token: 0x060008FE RID: 2302 RVA: 0x0000CE55 File Offset: 0x0000B055
		// (set) Token: 0x060008FF RID: 2303 RVA: 0x00094348 File Offset: 0x00092548
		public string BusyMessage
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.#d != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107381157));
					this.#d = value;
					this.#vh();
					base.RaisePropertyChanged(#Phc.#3hc(107381157));
				}
			}
		}

		// Token: 0x170003DC RID: 988
		// (get) Token: 0x06000900 RID: 2304 RVA: 0x0000CE61 File Offset: 0x0000B061
		// (set) Token: 0x06000901 RID: 2305 RVA: 0x0000CE6D File Offset: 0x0000B06D
		public string OutputFolder { get; set; }

		// Token: 0x170003DD RID: 989
		// (get) Token: 0x06000902 RID: 2306 RVA: 0x0000CE7E File Offset: 0x0000B07E
		// (set) Token: 0x06000903 RID: 2307 RVA: 0x0000CE8A File Offset: 0x0000B08A
		public string AcceptedDataFilesFolder { get; set; }

		// Token: 0x170003DE RID: 990
		// (get) Token: 0x06000904 RID: 2308 RVA: 0x0000CE9B File Offset: 0x0000B09B
		// (set) Token: 0x06000905 RID: 2309 RVA: 0x0000CEA7 File Offset: 0x0000B0A7
		public string AcceptedOutputsFolder { get; set; }

		// Token: 0x170003DF RID: 991
		// (get) Token: 0x06000906 RID: 2310 RVA: 0x0000CEB8 File Offset: 0x0000B0B8
		// (set) Token: 0x06000907 RID: 2311 RVA: 0x0000CEC4 File Offset: 0x0000B0C4
		public string SummaryFileName { get; set; }

		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x06000908 RID: 2312 RVA: 0x0000CED5 File Offset: 0x0000B0D5
		public RadObservableCollection<BatchItemViewModel> BatchItems { get; }

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x06000909 RID: 2313 RVA: 0x0000CEE1 File Offset: 0x0000B0E1
		public DelegateCommand BrowseDataFolderCommand { get; }

		// Token: 0x170003E2 RID: 994
		// (get) Token: 0x0600090A RID: 2314 RVA: 0x0000CEED File Offset: 0x0000B0ED
		// (set) Token: 0x0600090B RID: 2315 RVA: 0x0009439C File Offset: 0x0009259C
		public bool ReportTxt
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (this.#e != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107381172));
					this.#e = value;
					this.#Mo();
					base.RaisePropertyChanged(#Phc.#3hc(107381172));
				}
			}
		}

		// Token: 0x170003E3 RID: 995
		// (get) Token: 0x0600090C RID: 2316 RVA: 0x0000CEF9 File Offset: 0x0000B0F9
		// (set) Token: 0x0600090D RID: 2317 RVA: 0x000943EC File Offset: 0x000925EC
		public bool ReportPdf
		{
			get
			{
				return this.#f;
			}
			set
			{
				if (this.#f != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107381127));
					this.#f = value;
					this.#Mo();
					base.RaisePropertyChanged(#Phc.#3hc(107381127));
				}
			}
		}

		// Token: 0x170003E4 RID: 996
		// (get) Token: 0x0600090E RID: 2318 RVA: 0x0000CF05 File Offset: 0x0000B105
		// (set) Token: 0x0600090F RID: 2319 RVA: 0x0009443C File Offset: 0x0009263C
		public bool ReportWord
		{
			get
			{
				return this.#g;
			}
			set
			{
				if (this.#g != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107381146));
					this.#g = value;
					this.#Mo();
					base.RaisePropertyChanged(#Phc.#3hc(107381146));
				}
			}
		}

		// Token: 0x170003E5 RID: 997
		// (get) Token: 0x06000910 RID: 2320 RVA: 0x0000CF11 File Offset: 0x0000B111
		// (set) Token: 0x06000911 RID: 2321 RVA: 0x0009448C File Offset: 0x0009268C
		public bool ReportExcel
		{
			get
			{
				return this.#h;
			}
			set
			{
				if (this.#h != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107381097));
					this.#h = value;
					this.#Mo();
					base.RaisePropertyChanged(#Phc.#3hc(107381097));
				}
			}
		}

		// Token: 0x170003E6 RID: 998
		// (get) Token: 0x06000912 RID: 2322 RVA: 0x0000CF1D File Offset: 0x0000B11D
		// (set) Token: 0x06000913 RID: 2323 RVA: 0x000944DC File Offset: 0x000926DC
		public bool ReportCsv
		{
			get
			{
				return this.#i;
			}
			set
			{
				if (this.#i != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107381112));
					this.#i = value;
					this.#Mo();
					base.RaisePropertyChanged(#Phc.#3hc(107381112));
				}
			}
		}

		// Token: 0x170003E7 RID: 999
		// (get) Token: 0x06000914 RID: 2324 RVA: 0x0000CF29 File Offset: 0x0000B129
		// (set) Token: 0x06000915 RID: 2325 RVA: 0x0009452C File Offset: 0x0009272C
		public bool SectionToDXF
		{
			get
			{
				return this.#j;
			}
			set
			{
				if (this.#j != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107381067));
					this.#j = value;
					this.#Mo();
					base.RaisePropertyChanged(#Phc.#3hc(107381067));
				}
			}
		}

		// Token: 0x170003E8 RID: 1000
		// (get) Token: 0x06000916 RID: 2326 RVA: 0x0000CF35 File Offset: 0x0000B135
		// (set) Token: 0x06000917 RID: 2327 RVA: 0x0009457C File Offset: 0x0009277C
		public bool EquivalentCTI
		{
			get
			{
				return this.#k;
			}
			set
			{
				if (this.#k != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107381082));
					this.#k = value;
					this.#Mo();
					base.RaisePropertyChanged(#Phc.#3hc(107381082));
				}
			}
		}

		// Token: 0x170003E9 RID: 1001
		// (get) Token: 0x06000918 RID: 2328 RVA: 0x0000CF41 File Offset: 0x0000B141
		// (set) Token: 0x06000919 RID: 2329 RVA: 0x000945CC File Offset: 0x000927CC
		public bool ContinueWhenRhoGreater8
		{
			get
			{
				return this.#m;
			}
			set
			{
				if (this.#m != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107381029));
					this.#m = value;
					this.#Mo();
					base.RaisePropertyChanged(#Phc.#3hc(107381029));
				}
			}
		}

		// Token: 0x170003EA RID: 1002
		// (get) Token: 0x0600091A RID: 2330 RVA: 0x0000CF4D File Offset: 0x0000B14D
		// (set) Token: 0x0600091B RID: 2331 RVA: 0x0009461C File Offset: 0x0009281C
		public bool ConsiderColumnAsArchitectural
		{
			get
			{
				return this.#l;
			}
			set
			{
				if (this.#l != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107380996));
					this.#l = value;
					this.#Mo();
					base.RaisePropertyChanged(#Phc.#3hc(107380996));
				}
			}
		}

		// Token: 0x170003EB RID: 1003
		// (get) Token: 0x0600091C RID: 2332 RVA: 0x0000CF59 File Offset: 0x0000B159
		// (set) Token: 0x0600091D RID: 2333 RVA: 0x0009466C File Offset: 0x0009286C
		public string ProcessingMessage
		{
			get
			{
				return this.#n;
			}
			set
			{
				if (this.#n != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107413243));
					this.#n = value;
					base.RaisePropertyChanged(#Phc.#3hc(107413243));
				}
			}
		}

		// Token: 0x170003EC RID: 1004
		// (get) Token: 0x0600091E RID: 2334 RVA: 0x0000CF65 File Offset: 0x0000B165
		// (set) Token: 0x0600091F RID: 2335 RVA: 0x000946BC File Offset: 0x000928BC
		public string RunButtonContent
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107413186));
					this.#c = value;
					base.RaisePropertyChanged(#Phc.#3hc(107413186));
				}
			}
		}

		// Token: 0x170003ED RID: 1005
		// (get) Token: 0x06000920 RID: 2336 RVA: 0x0000CF71 File Offset: 0x0000B171
		public DelegateCommand RunButtonCommand { get; }

		// Token: 0x170003EE RID: 1006
		// (get) Token: 0x06000921 RID: 2337 RVA: 0x0000CF7D File Offset: 0x0000B17D
		public DelegateCommand StopCommand { get; }

		// Token: 0x170003EF RID: 1007
		// (get) Token: 0x06000922 RID: 2338 RVA: 0x0000CF89 File Offset: 0x0000B189
		public DelegateCommand OrganizeCommand { get; }

		// Token: 0x170003F0 RID: 1008
		// (get) Token: 0x06000923 RID: 2339 RVA: 0x0000CF95 File Offset: 0x0000B195
		public DelegateCommand CloseCommand { get; }

		// Token: 0x170003F1 RID: 1009
		// (get) Token: 0x06000924 RID: 2340 RVA: 0x0009470C File Offset: 0x0009290C
		public bool IsFinished
		{
			get
			{
				if (this.BatchItems.Any<BatchItemViewModel>())
				{
					return this.BatchItems.Count == this.BatchItems.Count(new Func<BatchItemViewModel, bool>(BatchProcessorViewModel.<>c.<>9.#1wf));
				}
				return false;
			}
		}

		// Token: 0x170003F2 RID: 1010
		// (get) Token: 0x06000925 RID: 2341 RVA: 0x0000CFA1 File Offset: 0x0000B1A1
		// (set) Token: 0x06000926 RID: 2342 RVA: 0x0000CFAD File Offset: 0x0000B1AD
		public bool IsBusy
		{
			get
			{
				return this.#t;
			}
			set
			{
				base.RaisePropertyChanging(#Phc.#3hc(107413161));
				this.#t = value;
				base.RaisePropertyChanged(#Phc.#3hc(107413161));
			}
		}

		// Token: 0x170003F3 RID: 1011
		// (get) Token: 0x06000927 RID: 2343 RVA: 0x0000CFE2 File Offset: 0x0000B1E2
		// (set) Token: 0x06000928 RID: 2344 RVA: 0x0009476C File Offset: 0x0009296C
		public BatchProcessorViewModel.#oVb CurrentState
		{
			get
			{
				return this.#r;
			}
			private set
			{
				if (this.#r != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107413152));
					this.#r = value;
					base.RaisePropertyChanged(#Phc.#3hc(107413152));
					base.RaisePropertyChanged(#Phc.#3hc(107413135));
				}
			}
		}

		// Token: 0x170003F4 RID: 1012
		// (get) Token: 0x06000929 RID: 2345 RVA: 0x0000CFEE File Offset: 0x0000B1EE
		public bool AreOptionsEnabled
		{
			get
			{
				return this.CurrentState == BatchProcessorViewModel.#oVb.#a || this.CurrentState == BatchProcessorViewModel.#oVb.#d;
			}
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x0000D00F File Offset: 0x0000B20F
		protected override void #uh(#Lb #Ee)
		{
			this.CurrentState = BatchProcessorViewModel.#oVb.#a;
			base.#uh(#Ee);
			#Ee.Closing += this.#Dh;
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x000947C8 File Offset: 0x000929C8
		protected override void #vh()
		{
			this.RunButtonCommand.InvalidateCanExecute();
			this.StopCommand.InvalidateCanExecute();
			this.OrganizeCommand.InvalidateCanExecute();
			this.CloseCommand.InvalidateCanExecute();
			this.BrowseDataFolderCommand.InvalidateCanExecute();
			base.#vh();
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x00094820 File Offset: 0x00092A20
		public void #Kn()
		{
			BatchProcessorViewModel.#dxf #dxf;
			#dxf.#b = AsyncVoidMethodBuilder.Create();
			#dxf.#c = this;
			#dxf.#a = -1;
			if (!false)
			{
				#dxf.#b.Start<BatchProcessorViewModel.#dxf>(ref #dxf);
			}
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x00094868 File Offset: 0x00092A68
		private void #Dh(object #Ge, CancelEventArgs #He)
		{
			this.#lm();
			if (this.CurrentState == BatchProcessorViewModel.#oVb.#b)
			{
				if (!this.#o.IsCancellationRequested)
				{
					MessageBoxResult messageBoxResult = base.Services.DialogService.#3Sc(base.ActiveWindow, Strings.StringBatchProcessingInProgress.#z2d() + Environment.NewLine + Strings.StringWouldYouLikeToToStopIt.#J2d(), MessageBoxButton.YesNo, MessageBoxResult.Yes);
					if (messageBoxResult == MessageBoxResult.Yes)
					{
						this.#q = true;
						this.#Qo();
						this.#wo();
					}
				}
				#He.Cancel = true;
			}
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x0000D03D File Offset: 0x0000B23D
		private void #RTi(object #Ge, #TUi #He)
		{
			Interlocked.Exchange(ref this.#p, #He.Current);
			this.#wo();
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x00094900 File Offset: 0x00092B00
		private void #yl()
		{
			this.#q = false;
			this.BatchItems.Clear();
			this.CurrentState = BatchProcessorViewModel.#oVb.#a;
			this.#p = 0;
			this.#o = new CancellationTokenSource();
			this.#vh();
			this.#wo();
			this.#0o();
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x00094958 File Offset: 0x00092B58
		private void #wo()
		{
			string str = string.Empty;
			if (this.#o.IsCancellationRequested)
			{
				str = ((this.CurrentState == BatchProcessorViewModel.#oVb.#b) ? (#Phc.#3hc(107413142) + Strings.StringStopping + #Phc.#3hc(107382694)) : (#Phc.#3hc(107413142) + Strings.StringStopped + #Phc.#3hc(107382694)));
			}
			this.ProcessingMessage = Strings.StringProcessing0Of1.#D2d(new object[]
			{
				this.#p,
				this.BatchItems.Count
			}).#O2d() + str;
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x00094A20 File Offset: 0x00092C20
		private #SUi #Jn(BatchProcessorSettings #ng)
		{
			string outputFolder = #ng.OutputFolder;
			ProjectExecutionParameters projectExecutionParameters = new ProjectExecutionParameters
			{
				ExcelReportPath = (#ng.GenerateExcelReport ? outputFolder : null),
				TextReportPath = (#ng.GenerateTxtReport ? outputFolder : null),
				CsvReportPath = (#ng.GenerateCsvReport ? outputFolder : null),
				WordReportPath = (#ng.GenerateWordReport ? outputFolder : null),
				PdfReportPath = (#ng.GeneratePdfReport ? outputFolder : null),
				CtiPath = (#ng.EquivalentCTI ? outputFolder : null),
				DxfPath = (#ng.SectionToDXF ? outputFolder : null),
				ContinueProcessingWhenBarsAreOutsideOfSection = true,
				ContinueProcessingWhenRhoIsGreaterThanEight = #ng.ContinueWhenRhoGreater8,
				IsColumnArchitectural = #ng.ConsiderArchitecturalColumn
			};
			return new #SUi
			{
				CancellationTokenSource = this.#o,
				SummaryPath = this.#Go(),
				ExecutionParameters = projectExecutionParameters,
				NumberOfThreads = Math.Max(Environment.ProcessorCount / 2, 1)
			};
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x00094B2C File Offset: 0x00092D2C
		private BatchProcessorSettings #xo()
		{
			return new BatchProcessorSettings
			{
				ConsiderArchitecturalColumn = this.ConsiderColumnAsArchitectural,
				DataFolder = this.DataFolder,
				GenerateCsvReport = this.ReportCsv,
				GenerateExcelReport = this.ReportExcel,
				GeneratePdfReport = this.ReportPdf,
				GenerateTxtReport = this.ReportTxt,
				GenerateWordReport = this.ReportWord,
				SectionToDXF = this.SectionToDXF,
				EquivalentCTI = this.EquivalentCTI,
				OutputFolder = this.OutputFolder,
				ContinueWhenRhoGreater8 = this.ContinueWhenRhoGreater8,
				AcceptedDataFilesFolder = this.AcceptedDataFilesFolder,
				AcceptedOutputsFolder = this.AcceptedOutputsFolder,
				SummaryFileName = this.SummaryFileName
			};
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x00094C04 File Offset: 0x00092E04
		private void #lm()
		{
			BatchProcessorSettings other = this.#xo();
			BatchProcessorSettings batchProcessorSettings = base.Services.Settings.BatchProcessorSettings;
			batchProcessorSettings.CopyMutableSettings(other);
			base.Services.Settings.BatchProcessorSettings = batchProcessorSettings;
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x00094C50 File Offset: 0x00092E50
		private void #yo()
		{
			BatchProcessorSettings batchProcessorSettings = base.Services.Settings.BatchProcessorSettings;
			this.ConsiderColumnAsArchitectural = batchProcessorSettings.ConsiderArchitecturalColumn;
			this.#b = batchProcessorSettings.DataFolder;
			this.ReportCsv = batchProcessorSettings.GenerateCsvReport;
			this.ReportExcel = batchProcessorSettings.GenerateExcelReport;
			this.ReportPdf = batchProcessorSettings.GeneratePdfReport;
			this.ReportTxt = batchProcessorSettings.GenerateTxtReport;
			this.ReportWord = batchProcessorSettings.GenerateWordReport;
			this.SectionToDXF = batchProcessorSettings.SectionToDXF;
			this.EquivalentCTI = batchProcessorSettings.EquivalentCTI;
			this.ContinueWhenRhoGreater8 = batchProcessorSettings.ContinueWhenRhoGreater8;
			this.OutputFolder = batchProcessorSettings.OutputFolder;
			this.AcceptedDataFilesFolder = batchProcessorSettings.AcceptedDataFilesFolder;
			this.AcceptedOutputsFolder = batchProcessorSettings.AcceptedOutputsFolder;
			this.SummaryFileName = batchProcessorSettings.SummaryFileName;
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x00094D34 File Offset: 0x00092F34
		private string #zo(string #Ao)
		{
			#Ao = ((string.IsNullOrWhiteSpace(#Ao) || !base.FileSystem.#X1c(#Ao)) ? Environment.GetFolderPath(Environment.SpecialFolder.MyComputer) : #Ao);
			return base.FileSystem.#Y1c(base.DialogService.ActiveWindow, Environment.SpecialFolder.MyComputer, #Ao);
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x00094D88 File Offset: 0x00092F88
		private bool #Bo()
		{
			try
			{
				string #So = this.#Fo();
				if (!base.FileSystem.#X1c(#So))
				{
					base.FileSystem.#k2c(#So);
				}
			}
			catch (Exception exception)
			{
				base.DialogService.#qn(base.ActiveWindow, Strings.StringCoundNotCreateOutputDirectory.#z2d());
				base.Services.Logger.Log(LoggingLevel.Warning, new Func<string>(BatchProcessorViewModel.<>c.<>9.#kVi), exception);
				return false;
			}
			try
			{
				if (this.BatchItems.Count != this.BatchItems.Select(new Func<BatchItemViewModel, string>(BatchProcessorViewModel.<>c.<>9.#lVi)).Distinct<string>().Count<string>() && !this.#5o())
				{
					return false;
				}
				string #So2 = this.#Fo();
				if (base.FileSystem.#X1c(#So2))
				{
					base.FileSystem.#Ro(#So2, #Phc.#3hc(107413137), SearchOption.TopDirectoryOnly).#I1d(new Action<string>(this.#STi));
				}
			}
			catch (Exception #ob)
			{
				base.Services.ExceptionHandler.#3Ab(Strings.StringFailedToPrepareOutputDirectory.#z2d() + Environment.NewLine + #sYd.#oYd(#ob), #ob);
				return false;
			}
			return true;
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x00094EF8 File Offset: 0x000930F8
		private void #Co()
		{
			BatchProcessorViewModel.#rVi #rVi;
			#rVi.#b = AsyncVoidMethodBuilder.Create();
			#rVi.#c = this;
			#rVi.#a = -1;
			if (!false)
			{
				#rVi.#b.Start<BatchProcessorViewModel.#rVi>(ref #rVi);
			}
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x00094F40 File Offset: 0x00093140
		private void #Do(object #Sb)
		{
			string value = this.#zo(this.DataFolder);
			if (!string.IsNullOrWhiteSpace(value))
			{
				this.DataFolder = value;
			}
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x0000CFEE File Offset: 0x0000B1EE
		private bool #Eo(object #Sb)
		{
			return this.CurrentState == BatchProcessorViewModel.#oVb.#a || this.CurrentState == BatchProcessorViewModel.#oVb.#d;
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x0000D063 File Offset: 0x0000B263
		private string #Fo()
		{
			return Alphaleonis.Win32.Filesystem.Path.Combine(new string[]
			{
				this.DataFolder,
				this.OutputFolder
			});
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x0000D08E File Offset: 0x0000B28E
		private string #Go()
		{
			return Alphaleonis.Win32.Filesystem.Path.Combine(new string[]
			{
				this.DataFolder,
				this.SummaryFileName
			});
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x00094F78 File Offset: 0x00093178
		private void #Jo(object #Sb)
		{
			switch (this.CurrentState)
			{
			case BatchProcessorViewModel.#oVb.#a:
				this.#No();
				return;
			case BatchProcessorViewModel.#oVb.#b:
				this.#Uo();
				return;
			case BatchProcessorViewModel.#oVb.#c:
				this.#To();
				return;
			case BatchProcessorViewModel.#oVb.#d:
				this.#No();
				return;
			default:
				return;
			}
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x0000D0B9 File Offset: 0x0000B2B9
		private bool #Ko(object #Sb)
		{
			return this.CurrentState != BatchProcessorViewModel.#oVb.#b || this.#o == null || !this.#o.IsCancellationRequested;
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x00094FCC File Offset: 0x000931CC
		private void #Lo()
		{
			this.BatchItems.Clear();
			if (!base.FileSystem.#X1c(this.DataFolder))
			{
				return;
			}
			IList<string> source = BatchExecutorHelper.#GUi(base.FileSystem, this.DataFolder);
			this.BatchItems.AddRange(source.Select(new Func<string, BatchItemViewModel>(this.#zvf)));
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x00095034 File Offset: 0x00093234
		private void #Mo()
		{
			if (this.BatchItems.Any<BatchItemViewModel>())
			{
				this.BatchItems.#I1d(new Action<BatchItemViewModel>(BatchProcessorViewModel.<>c.<>9.#5wf));
			}
			this.#o = new CancellationTokenSource();
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x00095090 File Offset: 0x00093290
		private void #No()
		{
			BatchProcessorViewModel.#fxf #fxf;
			#fxf.#b = AsyncVoidMethodBuilder.Create();
			#fxf.#c = this;
			#fxf.#a = -1;
			if (!false)
			{
				#fxf.#b.Start<BatchProcessorViewModel.#fxf>(ref #fxf);
			}
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x000950D8 File Offset: 0x000932D8
		private bool #Oo(bool #Po)
		{
			if (base.FileSystem.#X1c(this.DataFolder))
			{
				return true;
			}
			if (#Po && string.IsNullOrWhiteSpace(this.DataFolder))
			{
				return false;
			}
			string #SSc = base.DialogService.#5Sc(Strings.StringInvalidDataSpecified.#z2d(), Strings.StringInvalidDataFolder.#z2d());
			base.DialogService.#qn(base.ActiveWindow, #SSc);
			return false;
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x0000D0E8 File Offset: 0x0000B2E8
		private void #Qo()
		{
			this.#o.Cancel();
			this.#wo();
			this.#vh();
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x0009514C File Offset: 0x0009334C
		private void #To()
		{
			if (!base.FileSystem.#X1c(this.DataFolder))
			{
				base.DialogService.#qn(base.ActiveWindow, Strings.StringInvalidDataFolder.#z2d());
				this.CurrentState = BatchProcessorViewModel.#oVb.#a;
				return;
			}
			if (!base.FileSystem.#X1c(this.#Fo()))
			{
				base.DialogService.#qn(base.ActiveWindow, Strings.StringInvalidOutputFolder.#z2d());
				return;
			}
			this.#o = new CancellationTokenSource();
			foreach (BatchItemViewModel batchItemViewModel in this.BatchItems)
			{
				if (!batchItemViewModel.IsProcessed)
				{
					batchItemViewModel.CancellationToken = new #OXd(this.#o.Token);
				}
			}
			this.#Co();
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x0000D10D File Offset: 0x0000B30D
		private void #Uo()
		{
			this.#s = true;
			this.#Qo();
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x0000D128 File Offset: 0x0000B328
		private void #Vo(object #Sb)
		{
			this.#s = false;
			this.#Qo();
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x0000D143 File Offset: 0x0000B343
		private bool #Wo(object #Sb)
		{
			return this.CurrentState == BatchProcessorViewModel.#oVb.#b && this.#o != null && !this.#o.IsCancellationRequested;
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x00095244 File Offset: 0x00093444
		private void #Xo(object #Sb)
		{
			BatchProcessorViewModel.#qVi #qVi;
			#qVi.#b = AsyncVoidMethodBuilder.Create();
			#qVi.#c = this;
			#qVi.#a = -1;
			if (!false)
			{
				#qVi.#b.Start<BatchProcessorViewModel.#qVi>(ref #qVi);
			}
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x0009528C File Offset: 0x0009348C
		private bool #Yo(object #Sb)
		{
			if (this.CurrentState == BatchProcessorViewModel.#oVb.#d)
			{
				return this.BatchItems.Any(new Func<BatchItemViewModel, bool>(BatchProcessorViewModel.<>c.<>9.#oVi));
			}
			return false;
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x0000D172 File Offset: 0x0000B372
		private void #Ug(object #Sb)
		{
			base.View.Close();
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x00003375 File Offset: 0x00001575
		private bool #Zo(object #Sb)
		{
			return true;
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x000952DC File Offset: 0x000934DC
		private void #0o()
		{
			switch (this.#r)
			{
			case BatchProcessorViewModel.#oVb.#a:
				this.RunButtonContent = Strings.StringRun;
				return;
			case BatchProcessorViewModel.#oVb.#b:
				this.RunButtonContent = Strings.StringPause;
				return;
			case BatchProcessorViewModel.#oVb.#c:
				this.RunButtonContent = Strings.StringResume;
				return;
			case BatchProcessorViewModel.#oVb.#d:
				this.RunButtonContent = Strings.StringRun;
				return;
			default:
				return;
			}
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x00095344 File Offset: 0x00093544
		private void #1o(string #2o)
		{
			base.FileSystem.#Ro(this.#Fo(), #2o + #Phc.#3hc(107413100), SearchOption.AllDirectories).#I1d(new Action<string>(this.#TTi));
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x00095390 File Offset: 0x00093590
		private void #3o()
		{
			string #SSc = BatchExecutorHelper.#HUi(this.BatchItems, this.DataFolder, this.OutputFolder, this.SummaryFileName);
			base.DialogService.#od(base.ActiveWindow, #SSc, ColumnGlobalInfo.DefaultMessageBoxTitle, MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK, MessageBoxOptions.None);
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x000953E4 File Offset: 0x000935E4
		private bool #4o()
		{
			TextColumnsAligner textColumnsAligner = TextColumnsAligner.MessageBoxAligner(#Phc.#3hc(107383615));
			textColumnsAligner.Add(Strings.StringAllFilesWithNoErrorsOrWarningsWillBeMoved.#z2d());
			textColumnsAligner.AddEmptyLine();
			textColumnsAligner.Add(Strings.StringDataFiles, string.Format(Strings.StringTo0Folder, this.AcceptedDataFilesFolder));
			textColumnsAligner.Add(Strings.StringOutputs, string.Format(Strings.StringTo0Folder, this.AcceptedOutputsFolder));
			return base.DialogService.#od(base.ActiveWindow, textColumnsAligner.GetFinalMessage(), ColumnGlobalInfo.DefaultMessageBoxTitle, MessageBoxButton.OKCancel, MessageBoxImage.Asterisk, MessageBoxResult.OK, MessageBoxOptions.None) == MessageBoxResult.OK;
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x0009548C File Offset: 0x0009368C
		private bool #5o()
		{
			string #SSc = Strings.StringFilesWithTheSameNameButDifferentExtensionsDetected.#z2d() + #Phc.#3hc(107413095) + Strings.StringOutputFilesWillBeOverwritten.#z2d();
			return base.DialogService.#od(base.ActiveWindow, #SSc, ColumnGlobalInfo.DefaultMessageBoxTitle, MessageBoxButton.OKCancel, MessageBoxImage.Exclamation, MessageBoxResult.OK, MessageBoxOptions.None) == MessageBoxResult.OK;
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x000954E8 File Offset: 0x000936E8
		private Task<bool> #6o(Action #nd, string #5)
		{
			BatchProcessorViewModel.#sVi #sVi;
			#sVi.#b = AsyncTaskMethodBuilder<bool>.Create();
			#sVi.#c = this;
			#sVi.#e = #nd;
			#sVi.#d = #5;
			#sVi.#a = -1;
			#sVi.#b.Start<BatchProcessorViewModel.#sVi>(ref #sVi);
			return #sVi.#b.Task;
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x00095548 File Offset: 0x00093748
		[CompilerGenerated]
		private void #xvf()
		{
			try
			{
				base.View.ShowDialog();
			}
			finally
			{
				this.#u.#ZXd();
			}
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x0000D18B File Offset: 0x0000B38B
		[CompilerGenerated]
		private void #STi(string #9o)
		{
			base.FileSystem.#W1c(#9o);
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x0000D1A6 File Offset: 0x0000B3A6
		[CompilerGenerated]
		private BatchItemViewModel #zvf(string #bp)
		{
			return new BatchItemViewModel(#bp, this.#a, base.Logger, new #OXd(this.#o.Token), base.Services.Settings);
		}

		// Token: 0x06000954 RID: 2388 RVA: 0x0000D1E1 File Offset: 0x0000B3E1
		[CompilerGenerated]
		private void #Avf(BatchItemViewModel #9o)
		{
			#9o.#nn();
			#9o.CancellationToken = new #OXd(this.#o.Token);
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x0000D18B File Offset: 0x0000B38B
		[CompilerGenerated]
		private void #TTi(string #9o)
		{
			base.FileSystem.#W1c(#9o);
		}

		// Token: 0x040002EE RID: 750
		private readonly #0Ui #a;

		// Token: 0x040002EF RID: 751
		private string #b;

		// Token: 0x040002F0 RID: 752
		private string #c;

		// Token: 0x040002F1 RID: 753
		private string #d;

		// Token: 0x040002F2 RID: 754
		private bool #e;

		// Token: 0x040002F3 RID: 755
		private bool #f;

		// Token: 0x040002F4 RID: 756
		private bool #g;

		// Token: 0x040002F5 RID: 757
		private bool #h;

		// Token: 0x040002F6 RID: 758
		private bool #i;

		// Token: 0x040002F7 RID: 759
		private bool #j;

		// Token: 0x040002F8 RID: 760
		private bool #k;

		// Token: 0x040002F9 RID: 761
		private bool #l;

		// Token: 0x040002FA RID: 762
		private bool #m;

		// Token: 0x040002FB RID: 763
		private string #n;

		// Token: 0x040002FC RID: 764
		private CancellationTokenSource #o;

		// Token: 0x040002FD RID: 765
		private int #p;

		// Token: 0x040002FE RID: 766
		private bool #q;

		// Token: 0x040002FF RID: 767
		private BatchProcessorViewModel.#oVb #r;

		// Token: 0x04000300 RID: 768
		private bool #s;

		// Token: 0x04000301 RID: 769
		private bool #t;

		// Token: 0x04000302 RID: 770
		private readonly NonBlockingLock #u = new NonBlockingLock();

		// Token: 0x04000303 RID: 771
		[CompilerGenerated]
		private string #v;

		// Token: 0x04000304 RID: 772
		[CompilerGenerated]
		private string #w;

		// Token: 0x04000305 RID: 773
		[CompilerGenerated]
		private string #x;

		// Token: 0x04000306 RID: 774
		[CompilerGenerated]
		private string #y;

		// Token: 0x04000307 RID: 775
		[CompilerGenerated]
		private readonly RadObservableCollection<BatchItemViewModel> #z = new RadObservableCollection<BatchItemViewModel>();

		// Token: 0x04000308 RID: 776
		[CompilerGenerated]
		private readonly DelegateCommand #A;

		// Token: 0x04000309 RID: 777
		[CompilerGenerated]
		private readonly DelegateCommand #B;

		// Token: 0x0400030A RID: 778
		[CompilerGenerated]
		private readonly DelegateCommand #C;

		// Token: 0x0400030B RID: 779
		[CompilerGenerated]
		private readonly DelegateCommand #D;

		// Token: 0x0400030C RID: 780
		[CompilerGenerated]
		private readonly DelegateCommand #E;

		// Token: 0x02000117 RID: 279
		public enum #oVb
		{
			// Token: 0x0400030E RID: 782
			#a,
			// Token: 0x0400030F RID: 783
			#b,
			// Token: 0x04000310 RID: 784
			#c,
			// Token: 0x04000311 RID: 785
			#d
		}

		// Token: 0x02000119 RID: 281
		[CompilerGenerated]
		private sealed class #PVd
		{
			// Token: 0x06000960 RID: 2400 RVA: 0x0009558C File Offset: 0x0009378C
			internal Task #FVb()
			{
				BatchProcessorViewModel.#PVd.#ydc #ydc;
				#ydc.#b = AsyncTaskMethodBuilder.Create();
				#ydc.#c = this;
				#ydc.#a = -1;
				#ydc.#b.Start<BatchProcessorViewModel.#PVd.#ydc>(ref #ydc);
				return #ydc.#b.Task;
			}

			// Token: 0x06000961 RID: 2401 RVA: 0x0000D2AF File Offset: 0x0000B4AF
			internal void #HVb(BatchItemViewModel #9o)
			{
				this.#a.#1o(Alphaleonis.Win32.Filesystem.Path.GetFileNameWithoutExtension(#9o.FileName));
			}

			// Token: 0x0400031A RID: 794
			public BatchProcessorViewModel #a;

			// Token: 0x0400031B RID: 795
			public BatchProcessorSettings #b;

			// Token: 0x0200011A RID: 282
			[StructLayout(LayoutKind.Auto)]
			private struct #ydc : IAsyncStateMachine
			{
				// Token: 0x06000962 RID: 2402 RVA: 0x000955DC File Offset: 0x000937DC
				void IAsyncStateMachine.#BVb()
				{
					int num = this.#a;
					int num2;
					if (4 != 0)
					{
						num2 = num;
					}
					BatchProcessorViewModel.#PVd #PVd = this.#c;
					try
					{
						if (num2 != 0)
						{
							this.#d = new #FUi(#PVd.#a.FileSystem);
							this.#d.Progress += #PVd.#a.#RTi;
						}
						try
						{
							TaskAwaiter awaiter;
							if (num2 != 0)
							{
								#SUi #Pc = #PVd.#a.#Jn(#PVd.#b);
								awaiter = this.#d.#0(#PVd.#a.BatchItems, #Pc).GetAwaiter();
								if (!awaiter.IsCompleted)
								{
									num2 = (this.#a = 0);
									this.#e = awaiter;
									this.#b.AwaitUnsafeOnCompleted<TaskAwaiter, BatchProcessorViewModel.#PVd.#ydc>(ref awaiter, ref this);
									return;
								}
							}
							else
							{
								awaiter = this.#e;
								this.#e = default(TaskAwaiter);
								num2 = (this.#a = -1);
							}
							awaiter.GetResult();
						}
						finally
						{
							if (num2 < 0)
							{
								this.#d.Progress -= #PVd.#a.#RTi;
							}
						}
					}
					catch (Exception exception)
					{
						this.#a = -2;
						this.#d = null;
						this.#b.SetException(exception);
						return;
					}
					this.#a = -2;
					this.#d = null;
					this.#b.SetResult();
				}

				// Token: 0x06000963 RID: 2403 RVA: 0x0000D2D3 File Offset: 0x0000B4D3
				[DebuggerHidden]
				void IAsyncStateMachine.#CVb(IAsyncStateMachine #DVb)
				{
					this.#b.SetStateMachine(#DVb);
				}

				// Token: 0x0400031C RID: 796
				public int #a;

				// Token: 0x0400031D RID: 797
				public AsyncTaskMethodBuilder #b;

				// Token: 0x0400031E RID: 798
				public BatchProcessorViewModel.#PVd #c;

				// Token: 0x0400031F RID: 799
				private #FUi #d;

				// Token: 0x04000320 RID: 800
				private TaskAwaiter #e;
			}
		}

		// Token: 0x0200011B RID: 283
		[CompilerGenerated]
		private sealed class #t5b
		{
			// Token: 0x06000965 RID: 2405 RVA: 0x0000D2ED File Offset: 0x0000B4ED
			internal void #pVi()
			{
				this.#a.#uUi(this.#b, this.#c.DataFolder, new List<string>
				{
					this.#d
				});
			}

			// Token: 0x04000321 RID: 801
			public BatchOrganizer #a;

			// Token: 0x04000322 RID: 802
			public List<BatchItemViewModel> #b;

			// Token: 0x04000323 RID: 803
			public BatchProcessorViewModel #c;

			// Token: 0x04000324 RID: 804
			public string #d;
		}
	}
}
