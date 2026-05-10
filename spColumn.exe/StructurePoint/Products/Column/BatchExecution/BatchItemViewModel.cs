using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using #12e;
using #58e;
using #7hc;
using #AUi;
using #coe;
using #Mn;
using #pXd;
using #qJ;
using #Rwe;
using #Wse;
using Alphaleonis.Win32.Filesystem;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Communication;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.BatchExecution.Execution;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.Solver;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.BatchExecution
{
	// Token: 0x020006D7 RID: 1751
	internal sealed class BatchItemViewModel : NotifyPropertyChangedObjectBase, #XWi
	{
		// Token: 0x06003A4F RID: 14927 RVA: 0x001146D8 File Offset: 0x001128D8
		public BatchItemViewModel(string filePath, #0Ui projectExecutorFactory, ILogger logger, #KXd cancellationToken, ISettingsManager settingsManager)
		{
			this.#a = projectExecutorFactory;
			this.#b = logger;
			this.#c = settingsManager;
			this.CancellationToken = cancellationToken;
			this.#k = filePath;
			this.FileName = Path.GetFileName(filePath);
			this.#on();
		}

		// Token: 0x170011E9 RID: 4585
		// (get) Token: 0x06003A50 RID: 14928 RVA: 0x000329DD File Offset: 0x00030BDD
		// (set) Token: 0x06003A51 RID: 14929 RVA: 0x000329E9 File Offset: 0x00030BE9
		public ItemState ItemState
		{
			get
			{
				return this.#j;
			}
			private set
			{
				if (this.#j != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107347997));
					this.#j = value;
					base.RaisePropertyChanged(#Phc.#3hc(107347997));
				}
			}
		}

		// Token: 0x170011EA RID: 4586
		// (get) Token: 0x06003A52 RID: 14930 RVA: 0x00032A27 File Offset: 0x00030C27
		public string FilePath { get; }

		// Token: 0x170011EB RID: 4587
		// (get) Token: 0x06003A53 RID: 14931 RVA: 0x00032A33 File Offset: 0x00030C33
		// (set) Token: 0x06003A54 RID: 14932 RVA: 0x00032A3F File Offset: 0x00030C3F
		public string FileName { get; set; }

		// Token: 0x170011EC RID: 4588
		// (get) Token: 0x06003A55 RID: 14933 RVA: 0x00032A50 File Offset: 0x00030C50
		// (set) Token: 0x06003A56 RID: 14934 RVA: 0x00114730 File Offset: 0x00112930
		public string Section
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.#d != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107347984));
					this.#d = value;
					base.RaisePropertyChanged(#Phc.#3hc(107347984));
				}
			}
		}

		// Token: 0x170011ED RID: 4589
		// (get) Token: 0x06003A57 RID: 14935 RVA: 0x00032A5C File Offset: 0x00030C5C
		// (set) Token: 0x06003A58 RID: 14936 RVA: 0x00114780 File Offset: 0x00112980
		public string Size
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (this.#e != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107397811));
					this.#e = value;
					base.RaisePropertyChanged(#Phc.#3hc(107397811));
				}
			}
		}

		// Token: 0x170011EE RID: 4590
		// (get) Token: 0x06003A59 RID: 14937 RVA: 0x00032A68 File Offset: 0x00030C68
		// (set) Token: 0x06003A5A RID: 14938 RVA: 0x001147D0 File Offset: 0x001129D0
		public string CapacityRatio
		{
			get
			{
				return this.#f;
			}
			set
			{
				if (this.#f != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107407951));
					this.#f = value;
					base.RaisePropertyChanged(#Phc.#3hc(107407951));
				}
			}
		}

		// Token: 0x170011EF RID: 4591
		// (get) Token: 0x06003A5B RID: 14939 RVA: 0x00032A74 File Offset: 0x00030C74
		// (set) Token: 0x06003A5C RID: 14940 RVA: 0x00114820 File Offset: 0x00112A20
		public string Rho
		{
			get
			{
				return this.#g;
			}
			set
			{
				if (this.#g != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107352619));
					this.#g = value;
					base.RaisePropertyChanged(#Phc.#3hc(107352619));
				}
			}
		}

		// Token: 0x170011F0 RID: 4592
		// (get) Token: 0x06003A5D RID: 14941 RVA: 0x00032A80 File Offset: 0x00030C80
		// (set) Token: 0x06003A5E RID: 14942 RVA: 0x00114870 File Offset: 0x00112A70
		public string StateText
		{
			get
			{
				return this.#h;
			}
			set
			{
				if (this.#h != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107348451));
					this.#h = value;
					base.RaisePropertyChanged(#Phc.#3hc(107348451));
				}
			}
		}

		// Token: 0x170011F1 RID: 4593
		// (get) Token: 0x06003A5F RID: 14943 RVA: 0x00032A8C File Offset: 0x00030C8C
		// (set) Token: 0x06003A60 RID: 14944 RVA: 0x00032A98 File Offset: 0x00030C98
		public bool ShowFullMessageTooltip
		{
			get
			{
				return this.#i;
			}
			private set
			{
				if (this.#i != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107348470));
					this.#i = value;
					base.RaisePropertyChanged(#Phc.#3hc(107348470));
				}
			}
		}

		// Token: 0x170011F2 RID: 4594
		// (get) Token: 0x06003A61 RID: 14945 RVA: 0x00032AD6 File Offset: 0x00030CD6
		public bool IsProcessed
		{
			get
			{
				return this.ItemState == ItemState.Success || this.ItemState == ItemState.Warning || this.ItemState == ItemState.Error;
			}
		}

		// Token: 0x170011F3 RID: 4595
		// (get) Token: 0x06003A62 RID: 14946 RVA: 0x00032B01 File Offset: 0x00030D01
		// (set) Token: 0x06003A63 RID: 14947 RVA: 0x00032B0D File Offset: 0x00030D0D
		public #KXd CancellationToken { get; set; }

		// Token: 0x170011F4 RID: 4596
		// (get) Token: 0x06003A64 RID: 14948 RVA: 0x00032B1E File Offset: 0x00030D1E
		public RadObservableCollection<BatchItemFeedbackData> FeedbackItems { get; }

		// Token: 0x170011F5 RID: 4597
		// (get) Token: 0x06003A65 RID: 14949 RVA: 0x00032B2A File Offset: 0x00030D2A
		// (set) Token: 0x06003A66 RID: 14950 RVA: 0x00032B36 File Offset: 0x00030D36
		public #lte ReportingModel { get; private set; }

		// Token: 0x170011F6 RID: 4598
		// (get) Token: 0x06003A67 RID: 14951 RVA: 0x00032B47 File Offset: 0x00030D47
		// (set) Token: 0x06003A68 RID: 14952 RVA: 0x00032B53 File Offset: 0x00030D53
		public bool HasSectionProperties { get; private set; }

		// Token: 0x170011F7 RID: 4599
		// (get) Token: 0x06003A69 RID: 14953 RVA: 0x00032B64 File Offset: 0x00030D64
		private static bool IsCommandline
		{
			get
			{
				Application application = Application.Current;
				return ((application != null) ? application.Dispatcher : null) == null;
			}
		}

		// Token: 0x06003A6A RID: 14954 RVA: 0x00032B7E File Offset: 0x00030D7E
		public void #nn()
		{
			this.ItemState = ItemState.Queued;
			this.StateText = Strings.StringQueued;
		}

		// Token: 0x06003A6B RID: 14955 RVA: 0x001148C0 File Offset: 0x00112AC0
		public void #on()
		{
			this.ItemState = ItemState.None;
			this.StateText = string.Empty;
			this.ShowFullMessageTooltip = false;
			this.#d = #Phc.#3hc(107399922);
			this.#e = #Phc.#3hc(107348437);
			this.#g = #Phc.#3hc(107348432);
			this.#f = #Phc.#3hc(107348395);
		}

		// Token: 0x06003A6C RID: 14956 RVA: 0x00114934 File Offset: 0x00112B34
		public void #0(ProjectExecutionParameters #ng)
		{
			BatchItemViewModel.#1Vb #1Vb = new BatchItemViewModel.#1Vb();
			#1Vb.#a = this;
			try
			{
				this.ItemState = ItemState.Processing;
				ProjectExecutionParameters #Pc = this.#Jn(#ng);
				#UUi #UUi = this.#a.#ul(this);
				this.ReportingModel = #UUi.#0(#Pc, this.CancellationToken, new #EJ(true, false, true, false, this.#c.DiagramInterpolationConvergenceEpsilonPercentage), #ng.CreateErrorLogFiles);
				if (this.ReportingModel == null)
				{
					this.StateText = Strings.StringError_S;
					this.ItemState = ItemState.Error;
				}
				else
				{
					#aP #aP = new #aP(new #RP());
					#aP.#6O(this.ReportingModel.Input, true);
					#yp #Cn = new #yp(#aP);
					this.#wn(#aP);
					this.#Bn(this.ReportingModel, #Cn, #ng);
				}
			}
			catch (OperationCanceledException)
			{
				this.StateText = Strings.StringCancelled;
				this.ItemState = ItemState.Cancelled;
				throw;
			}
			catch (Exception ex)
			{
				#1Vb.#b = ex;
				this.StateText = Strings.StringError_S;
				this.#Fn();
				this.ItemState = ItemState.Error;
				this.ShowFullMessageTooltip = true;
				BatchItemViewModel.#c6c(new Action(#1Vb.#bVb));
				if (!(#1Vb.#b is #EXi) && !(#1Vb.#b is #goe))
				{
					this.#b.Log(LoggingLevel.Error, #1Vb.#b);
				}
			}
		}

		// Token: 0x06003A6D RID: 14957 RVA: 0x00009E6A File Offset: 0x0000806A
		public void #pn(string #5)
		{
		}

		// Token: 0x06003A6E RID: 14958 RVA: 0x00009E6A File Offset: 0x0000806A
		public void #qn(string #5)
		{
		}

		// Token: 0x06003A6F RID: 14959 RVA: 0x00032B9E File Offset: 0x00030D9E
		public void #rn(string #sn)
		{
			this.StateText = #sn;
		}

		// Token: 0x06003A70 RID: 14960 RVA: 0x00009E6A File Offset: 0x0000806A
		public void #tn(string #5)
		{
		}

		// Token: 0x06003A71 RID: 14961 RVA: 0x00032BB3 File Offset: 0x00030DB3
		private static void #c6c(Action #nd)
		{
			if (BatchItemViewModel.IsCommandline)
			{
				#nd();
				return;
			}
			LayoutHelper.BeginInvokeOnApplicationThread(#nd);
		}

		// Token: 0x06003A72 RID: 14962 RVA: 0x00032BD6 File Offset: 0x00030DD6
		private IReadOnlyList<Message> #un()
		{
			return this.ReportingModel.Output.Messages;
		}

		// Token: 0x06003A73 RID: 14963 RVA: 0x00114AAC File Offset: 0x00112CAC
		private void #vn()
		{
			string text = #Phc.#3hc(107408434);
			if (string.IsNullOrWhiteSpace(this.CapacityRatio))
			{
				this.CapacityRatio = text;
			}
			if (string.IsNullOrWhiteSpace(this.Section))
			{
				this.Section = text;
			}
			if (string.IsNullOrWhiteSpace(this.Rho))
			{
				this.Rho = text;
			}
			if (string.IsNullOrWhiteSpace(this.Size))
			{
				this.Size = text;
			}
		}

		// Token: 0x06003A74 RID: 14964 RVA: 0x00114B20 File Offset: 0x00112D20
		private void #wn(#aP #xn)
		{
			#l4e #l4e = this.ReportingModel.Output;
			if (#l4e != null && #l4e.SolveCompleted)
			{
				this.CapacityRatio = this.ReportingModel.Output.CapacityData.OverallCapacity + (this.#un().Any(new Func<Message, bool>(BatchItemViewModel.<>c.<>9.#QVi)) ? #Phc.#3hc(107348386) : string.Empty);
				if (this.ReportingModel.Input.Options.ActiveLoad == LoadType.NoLoads || this.ReportingModel.Input.Options.ActiveLoad == LoadType.Axial)
				{
					this.CapacityRatio = #Phc.#3hc(107408434);
				}
				this.#zn(#xn);
			}
			else if (this.ReportingModel.Output != null)
			{
				this.#zn(#xn);
			}
			else if (this.ReportingModel.ModelValidationErrors.Any<string>())
			{
				this.#Fn();
			}
			this.#vn();
		}

		// Token: 0x06003A75 RID: 14965 RVA: 0x00114C44 File Offset: 0x00112E44
		private string #yn(double #f)
		{
			string format = (this.ReportingModel.Input.Options.Unit == UnitSystem.SIMetric) ? #Phc.#3hc(107383605) : #Phc.#3hc(107408811);
			return #f.ToString(format, CultureInfo.CurrentCulture);
		}

		// Token: 0x06003A76 RID: 14966 RVA: 0x00114C9C File Offset: 0x00112E9C
		private void #zn(#aP #xn)
		{
			this.HasSectionProperties = true;
			string text = string.Empty.#O2d() + #xn.Model.Units.Section.Width.Symbol;
			this.Section = #yhe.#Qwe(this.ReportingModel.Input.Options.SectionType);
			#Vse #Vse = this.ReportingModel.BasicProperties;
			string str = ((double)#Vse.GeomProperties.Rho < 1.0 || (double)#Vse.GeomProperties.Rho > 8.0) ? #Phc.#3hc(107348386) : string.Empty;
			this.Rho = #Vse.GeomProperties.Rho.ToString(#Phc.#3hc(107408811)) + str;
			if (this.ReportingModel.Input.Options.SectionType == SectionType.Circle)
			{
				this.Size = this.#yn((double)#Vse.DimensionA) + text;
				return;
			}
			if (this.ReportingModel.Input.Options.SectionType != SectionType.Undefined)
			{
				this.Size = this.#yn((double)#Vse.DimensionA) + #Phc.#3hc(107348413) + this.#yn((double)#Vse.DimensionB) + text;
			}
		}

		// Token: 0x06003A77 RID: 14967 RVA: 0x00114E08 File Offset: 0x00113008
		private void #An(IList<BatchItemFeedbackData> #8f)
		{
			BatchItemViewModel.#lbc #lbc = new BatchItemViewModel.#lbc();
			#lbc.#a = this;
			#lbc.#b = #8f;
			this.StateText = (#lbc.#b.Any(new Func<BatchItemFeedbackData, bool>(BatchItemViewModel.<>c.<>9.#RVi)) ? Strings.StringError_S : Strings.StringWarning_S);
			this.ItemState = (#lbc.#b.Any(new Func<BatchItemFeedbackData, bool>(BatchItemViewModel.<>c.<>9.#SVi)) ? ItemState.Error : ItemState.Warning);
			BatchItemViewModel.#c6c(new Action(#lbc.#jVb));
		}

		// Token: 0x06003A78 RID: 14968 RVA: 0x00114ECC File Offset: 0x001130CC
		private void #Bn(#lte #Od, #yp #Cn, ProjectExecutionParameters #ng)
		{
			BatchItemViewModel.#86b #86b = new BatchItemViewModel.#86b();
			#86b.#b = #Cn;
			List<BatchItemFeedbackData> list = new List<BatchItemFeedbackData>();
			if (this.#Dn(#Od, list))
			{
				this.#An(list);
				return;
			}
			#86b.#a = #ng.ContinueProcessingWhenRhoIsGreaterThanEight;
			List<BatchItemFeedbackData> collection = this.#un().Where(new Func<Message, bool>(#86b.#lVb)).Select(new Func<Message, BatchItemFeedbackData>(#86b.#mVb)).Where(new Func<BatchItemFeedbackData, bool>(BatchItemViewModel.<>c.<>9.#TVi)).ToList<BatchItemFeedbackData>();
			list.AddRange(collection);
			if (#Od.Output.BarsOutsideSectionPresent)
			{
				list.Add(new BatchItemFeedbackData(Strings.StringWarning, Message.EnumType.Warning, Strings.StringBarsOutsideSectionPresent.#z2d()));
			}
			if (list.Any<BatchItemFeedbackData>())
			{
				this.#An(list);
				return;
			}
			this.StateText = Strings.StringOk_PASCAL;
			this.ItemState = ItemState.Success;
		}

		// Token: 0x06003A79 RID: 14969 RVA: 0x00114FCC File Offset: 0x001131CC
		private bool #Dn(#lte #Od, List<BatchItemFeedbackData> #En)
		{
			#En.AddRange(#Od.ModelValidationErrors.Select(new Func<string, BatchItemFeedbackData>(BatchItemViewModel.<>c.<>9.#UVi)));
			#En.AddRange(#Od.ModelValidationWarnings.Select(new Func<string, BatchItemFeedbackData>(BatchItemViewModel.<>c.<>9.#VVi)));
			return #Od.ModelValidationErrors.Any<string>();
		}

		// Token: 0x06003A7A RID: 14970 RVA: 0x00115054 File Offset: 0x00113254
		private void #Fn()
		{
			this.Section = (this.Size = (this.Rho = (this.CapacityRatio = #Phc.#3hc(107408434))));
		}

		// Token: 0x06003A7B RID: 14971 RVA: 0x00115098 File Offset: 0x00113298
		private string #Gn(string #Hn, string #In)
		{
			if (string.IsNullOrWhiteSpace(#Hn))
			{
				return #Hn;
			}
			string path = Path.Combine(new string[]
			{
				#Hn,
				Path.GetFileName(this.FilePath)
			});
			return Path.ChangeExtension(path, #In);
		}

		// Token: 0x06003A7C RID: 14972 RVA: 0x001150E0 File Offset: 0x001132E0
		private ProjectExecutionParameters #Jn(ProjectExecutionParameters #ng)
		{
			return new ProjectExecutionParameters
			{
				IsColumnArchitectural = #ng.IsColumnArchitectural,
				InputPath = this.FilePath,
				ContinueProcessingWhenRhoIsGreaterThanEight = #ng.ContinueProcessingWhenRhoIsGreaterThanEight,
				ContinueProcessingWhenBarsAreOutsideOfSection = true,
				WordReportPath = this.#Gn(#ng.WordReportPath, #Phc.#3hc(107350801)),
				PdfReportPath = this.#Gn(#ng.PdfReportPath, #Phc.#3hc(107350806)),
				TextReportPath = this.#Gn(#ng.TextReportPath, #Phc.#3hc(107413479)),
				ExcelReportPath = this.#Gn(#ng.ExcelReportPath, #Phc.#3hc(107350248)),
				CsvReportPath = this.#Gn(#ng.CsvReportPath, #Phc.#3hc(107408483)),
				CsvDiagramPath = this.#Gn(#ng.CsvDiagramPath, #Phc.#3hc(107408483)),
				TxtDiagramPath = this.#Gn(#ng.TxtDiagramPath, #Phc.#3hc(107413479)),
				DxfPath = this.#Gn(#ng.DxfPath, #Phc.#3hc(107350266)),
				CtiPath = this.#Gn(#ng.CtiPath, #Phc.#3hc(107350271)),
				RemoveDuplicateLoads = #ng.RemoveDuplicateLoads,
				DiagramInterpolationConvergenceEpsilon = new float?(#ng.DiagramInterpolationConvergenceEpsilon ?? 1f),
				TestMode = #ng.TestMode,
				CreateErrorLogFiles = #ng.CreateErrorLogFiles,
				IncludeNominalDiagram = #ng.IncludeNominalDiagram,
				LateralLoadsCompatibilityMode = #ng.LateralLoadsCompatibilityMode
			};
		}

		// Token: 0x040018D9 RID: 6361
		private readonly #0Ui #a;

		// Token: 0x040018DA RID: 6362
		private readonly ILogger #b;

		// Token: 0x040018DB RID: 6363
		private readonly ISettingsManager #c;

		// Token: 0x040018DC RID: 6364
		private string #d;

		// Token: 0x040018DD RID: 6365
		private string #e;

		// Token: 0x040018DE RID: 6366
		private string #f;

		// Token: 0x040018DF RID: 6367
		private string #g;

		// Token: 0x040018E0 RID: 6368
		private string #h;

		// Token: 0x040018E1 RID: 6369
		private bool #i;

		// Token: 0x040018E2 RID: 6370
		private ItemState #j;

		// Token: 0x040018E3 RID: 6371
		[CompilerGenerated]
		private readonly string #k;

		// Token: 0x040018E4 RID: 6372
		[CompilerGenerated]
		private string #l;

		// Token: 0x040018E5 RID: 6373
		[CompilerGenerated]
		private #KXd #m;

		// Token: 0x040018E6 RID: 6374
		[CompilerGenerated]
		private readonly RadObservableCollection<BatchItemFeedbackData> #n = new RadObservableCollection<BatchItemFeedbackData>();

		// Token: 0x040018E7 RID: 6375
		[CompilerGenerated]
		private #lte #o;

		// Token: 0x040018E8 RID: 6376
		[CompilerGenerated]
		private bool #p;

		// Token: 0x020006D9 RID: 1753
		[CompilerGenerated]
		private sealed class #1Vb
		{
			// Token: 0x06003A86 RID: 14982 RVA: 0x00032C7B File Offset: 0x00030E7B
			internal void #bVb()
			{
				this.#a.FeedbackItems.Add(new BatchItemFeedbackData(Strings.StringError, Message.EnumType.Error, this.#b.Message));
			}

			// Token: 0x040018F0 RID: 6384
			public BatchItemViewModel #a;

			// Token: 0x040018F1 RID: 6385
			public Exception #b;
		}

		// Token: 0x020006DA RID: 1754
		[CompilerGenerated]
		private sealed class #lbc
		{
			// Token: 0x06003A88 RID: 14984 RVA: 0x00032CAF File Offset: 0x00030EAF
			internal void #jVb()
			{
				this.#a.FeedbackItems.AddRange(this.#b);
				this.#a.ShowFullMessageTooltip = this.#a.FeedbackItems.Any<BatchItemFeedbackData>();
			}

			// Token: 0x040018F2 RID: 6386
			public BatchItemViewModel #a;

			// Token: 0x040018F3 RID: 6387
			public IList<BatchItemFeedbackData> #b;
		}

		// Token: 0x020006DB RID: 1755
		[CompilerGenerated]
		private sealed class #86b
		{
			// Token: 0x06003A8A RID: 14986 RVA: 0x00032CEE File Offset: 0x00030EEE
			internal bool #lVb(Message #Rf)
			{
				return SolverWindowViewModel.#0p(#Rf, this.#a) == Message.EnumType.Warning || SolverWindowViewModel.#0p(#Rf, this.#a) == Message.EnumType.Error;
			}

			// Token: 0x06003A8B RID: 14987 RVA: 0x0011529C File Offset: 0x0011349C
			internal BatchItemFeedbackData #mVb(Message #Rf)
			{
				return new BatchItemFeedbackData
				{
					Type = ((SolverWindowViewModel.#0p(#Rf, this.#a) == Message.EnumType.Warning) ? Strings.StringWarning : Strings.StringError),
					TypeRaw = SolverWindowViewModel.#0p(#Rf, this.#a),
					Message = ProjectExecutor.#JRb(this.#b, #Rf).#32d()
				};
			}

			// Token: 0x040018F4 RID: 6388
			public bool #a;

			// Token: 0x040018F5 RID: 6389
			public #yp #b;
		}
	}
}
