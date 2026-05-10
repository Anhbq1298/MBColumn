using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using #0be;
using #58e;
using #6re;
using #7hc;
using #AUi;
using #coe;
using #cYd;
using #g7e;
using #Jie;
using #kB;
using #Mn;
using #owe;
using #P6e;
using #pXd;
using #qJ;
using #v1c;
using #WB;
using #wqe;
using #Wse;
using #y6e;
using Alphaleonis.Win32.Filesystem;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Communication;
using StructurePoint.CoreAssets.AppManager.Column.Reporting;
using StructurePoint.CoreAssets.AppManager.Column.Storage;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.Solver;

namespace StructurePoint.Products.Column.BatchExecution.Execution
{
	// Token: 0x020006F3 RID: 1779
	internal sealed class ProjectExecutor : #UUi
	{
		// Token: 0x06003AF3 RID: 15091 RVA: 0x00116540 File Offset: 0x00114740
		public ProjectExecutor(#Ioe storageProvider, ILogger logger, #yse reporterSettings, #lB reporterDataProvider, #XWi feedback, #LJ validationService, #v2c fileSystem, ISettingsManager settingsManager)
		{
			this.#a = storageProvider;
			this.#b = logger;
			this.#c = reporterSettings;
			this.#d = reporterDataProvider;
			this.#e = feedback;
			this.#f = validationService;
			this.#g = fileSystem;
			this.#h = settingsManager;
			this.#a.OnUnsupportedInputFileNoDataFound += this.#GXi;
			this.#a.OnUnsupportedInputProjectCreatedWithNewerApplication += this.#FXi;
		}

		// Token: 0x06003AF4 RID: 15092 RVA: 0x001165C0 File Offset: 0x001147C0
		public #lte #0(ProjectExecutionParameters #Pc, #KXd #GRb, #Q6e #HRb, bool #IRb)
		{
			ProjectExecutor.#oWb #oWb = new ProjectExecutor.#oWb();
			#oWb.#a = #Pc;
			ProjectExecutionParameters projectExecutionParameters = #oWb.#a;
			if (projectExecutionParameters == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107395311));
			}
			this.#i = projectExecutionParameters;
			CommandLineReportGeneratorSettings #ng = this.#SRb(#oWb.#a);
			this.#QRb(#oWb.#a, #ng);
			this.#a.OnLateralLoadsCompatibilityModeRequested -= #oWb.#adc;
			this.#a.OnLateralLoadsCompatibilityModeRequested += #oWb.#adc;
			this.#e.#rn(Strings.StringPreparing.#B2d());
			#GRb.#GEd();
			this.#e.#pn(Strings.StringLoadingProject.#B2d());
			#9oe #9oe = this.#a.#Cjc(#oWb.#a.InputPath, new #ape());
			if (!#9oe.IsValid)
			{
				return null;
			}
			ColumnStorageModel columnStorageModel = #9oe.Model;
			if (this.#h.CurrentGeneralOptions.ReorderSolidAndOpeningLabelsBeforeSolve || !columnStorageModel.HasValidShapeIds())
			{
				columnStorageModel.ReAssignShapeIdIfNeeded();
			}
			#HRb.DiagramInterpolationConvergenceEpsilonPercentage = (#oWb.#a.DiagramInterpolationConvergenceEpsilon ?? #HRb.DiagramInterpolationConvergenceEpsilonPercentage);
			this.#e.#rn(Strings.StringValidatingInputFile.#B2d());
			this.#e.#pn(Strings.StringValidatingInputFile.#B2d());
			#oWb.#b = new ColumnModel(columnStorageModel);
			#lte result;
			#SJ #SJ;
			if (!this.#NRb(#oWb.#a, #HRb, #IRb, #oWb.#b, columnStorageModel, out result, out #SJ))
			{
				return result;
			}
			if (#oWb.#a.RemoveDuplicateLoads && (columnStorageModel.Options.ActiveLoad == LoadType.Factored || columnStorageModel.Options.ActiveLoad == LoadType.Axial || columnStorageModel.Options.ActiveLoad == LoadType.Service))
			{
				this.#UTi(columnStorageModel);
			}
			this.#e.#rn(Strings.StringSolving.#B2d());
			#GRb.#GEd();
			this.#e.#pn(Strings.StringRunningSolver.#B2d());
			DesignEngine designEngine = new DesignEngine(columnStorageModel, #HRb);
			designEngine.MessageBus.DialogRequested += #oWb.#bdc;
			designEngine.#0();
			designEngine.MessageBus.DialogRequested -= #oWb.#bdc;
			IList<FormattedMessage> source;
			bool flag = this.#VRb(#oWb.#a, designEngine, columnStorageModel, #IRb, out source);
			#GRb.#GEd();
			this.#e.#rn(Strings.StringProcessing.#B2d());
			#Uqe #Uqe = new #Uqe(this.#c, this.#d.#OA());
			#lte #lte = #Uqe.#ul(new #Hqe(columnStorageModel, designEngine, null)
			{
				CreateDiagrams = false,
				ForcePlaceReinforcement = flag,
				Configuration = #HRb,
				TestMode = #oWb.#a.TestMode,
				OriginalLoadType = ((#9oe.OriginalLoadType == LoadType.Controld) ? LoadType.NoLoads : #9oe.OriginalLoadType)
			});
			this.#h.CurrentColorSettings.#oRb(#lte.ColorSettings);
			#lte.DesignEngineWarningsAndErrors.AddRange(source.Select(new Func<FormattedMessage, string>(ProjectExecutor.<>c.<>9.#ddc)));
			#lte.ModelValidationWarnings.AddRange(#SJ.Warnings.Select(new Func<ValidationFailure, string>(#oWb.#cdc)));
			#zwe.#ywe(columnStorageModel.Options.Unit, #lte.GeneralInfo);
			#GRb.#GEd();
			#lte.GeneralInfo.FileName = #oWb.#a.InputPath;
			#vqe #vqe = new #vqe(this.#b, this.#c, null, this.#e);
			#vqe.#fp(#lte, designEngine, #ng);
			#GRb.#GEd();
			this.#PRb(#oWb.#a, columnStorageModel);
			if (!source.Any(new Func<FormattedMessage, bool>(ProjectExecutor.<>c.<>9.#edc)))
			{
				this.#MRb(#lte, #oWb.#a);
			}
			this.#LRb(#lte, #oWb.#a, designEngine);
			this.#e.#rn(Strings.StringFinished);
			string # = source.Any(new Func<FormattedMessage, bool>(ProjectExecutor.<>c.<>9.#fdc)) ? Strings.StringSolverInterrupted_PASCAL.#B2d() : Strings.StringSolutionCompleted.#B2d();
			this.#e.#pn(#);
			return #lte;
		}

		// Token: 0x06003AF5 RID: 15093 RVA: 0x00116A24 File Offset: 0x00114C24
		public static string #JRb(#yp #Cn, Message #5)
		{
			#M6e #M6e = #5.Code;
			if (#M6e == #M6e.#e)
			{
				return Strings.StringReinforcementRationExceeds8.#z2d();
			}
			if (#M6e != #M6e.#q)
			{
				return #Cn.#pp(#5);
			}
			return Strings.StringCannotSolveTheColumnModel.#z2d();
		}

		// Token: 0x06003AF6 RID: 15094 RVA: 0x00116A6C File Offset: 0x00114C6C
		public IList<FormattedMessage> #KRb(DesignEngine #rj, ColumnStorageModel #Od, ProjectExecutionParameters #Pc)
		{
			List<FormattedMessage> list = new List<FormattedMessage>();
			if (this.#XRb(#rj))
			{
				#aP #aP = new #aP(new #RP());
				#aP.#6O(#Od, false);
				#yp #Cn = new #yp(#aP);
				bool #1p = #Pc.ContinueProcessingWhenRhoIsGreaterThanEight;
				foreach (Message # in #rj.OutputModel.Messages)
				{
					string text = ProjectExecutor.#JRb(#Cn, #);
					Message.EnumType enumType = SolverWindowViewModel.#0p(#, #1p);
					list.Add(new FormattedMessage
					{
						IsError = (enumType == Message.EnumType.Error),
						IsWarning = (enumType == Message.EnumType.Warning),
						IsNote = (enumType == Message.EnumType.Note),
						Message = #,
						Text = text
					});
				}
				if (#rj.OutputModel.BarsOutsideSectionPresent)
				{
					list.Add(new FormattedMessage(Strings.StringBarsOutsideSectionPresent.#z2d(), false, true, false, null));
				}
			}
			return list;
		}

		// Token: 0x06003AF7 RID: 15095 RVA: 0x00116B88 File Offset: 0x00114D88
		private void #FXi(object #Ge, EventArgs #He)
		{
			string text = Strings.StringTheInputProjectNotSupported.#z2d(true) + Environment.NewLine;
			text += Strings.StringTheInputProjectHasBeenCreatedWithANewerVersionOfSpColumnWithDisabledBackwardAndForwardCompatibilityMode.#z2d();
			if (this.#i.CreateErrorLogFiles)
			{
				this.#VRb(this.#i, new List<FormattedMessage>
				{
					new FormattedMessage(text, true, false, false, null)
				}, true);
			}
			else
			{
				this.#e.#qn(text);
			}
			throw new #EXi(text);
		}

		// Token: 0x06003AF8 RID: 15096 RVA: 0x00116C0C File Offset: 0x00114E0C
		private void #GXi(object #Ge, EventArgs #He)
		{
			string text = Strings.StringTheInputProjectNotSupported.#z2d(true) + Environment.NewLine;
			text += Strings.StringNoValidInputDataFound.#z2d();
			if (this.#i.CreateErrorLogFiles)
			{
				this.#VRb(this.#i, new List<FormattedMessage>
				{
					new FormattedMessage(text, true, false, false, null)
				}, true);
			}
			else
			{
				this.#e.#qn(text);
			}
			throw new #EXi(text);
		}

		// Token: 0x06003AF9 RID: 15097 RVA: 0x00116C90 File Offset: 0x00114E90
		private void #UTi(ColumnStorageModel #Od)
		{
			this.#e.#pn(Strings.StringRemovingDuplicateLoads.#B2d());
			int num = #DC.#UTi(#Od);
			this.#e.#pn(Strings.StringRemoved0DuplicateLoads.#D2d(new object[]
			{
				num
			}).#z2d());
		}

		// Token: 0x06003AFA RID: 15098 RVA: 0x00116CF0 File Offset: 0x00114EF0
		private void #LRb(#lte #Od, ProjectExecutionParameters #Pc, DesignEngine #rj)
		{
			if (!string.IsNullOrWhiteSpace(#Pc.DxfPath))
			{
				this.#e.#pn(Strings.StringWritingDXFFile.#B2d());
				using (Stream stream = this.#g.#T1c(#Pc.DxfPath))
				{
					SectionGeometryHelper.#2W(#Od.Input, true);
					ColumnStorageModel #Od2 = ExportModelHelper.#bJ(#Od.Input, #rj);
					this.#a.#5ie(#Od2, stream);
				}
			}
		}

		// Token: 0x06003AFB RID: 15099 RVA: 0x00116D80 File Offset: 0x00114F80
		private void #MRb(#lte #Od, ProjectExecutionParameters #Pc)
		{
			if (!string.IsNullOrWhiteSpace(#Pc.CsvDiagramPath) || !string.IsNullOrWhiteSpace(#Pc.TxtDiagramPath))
			{
				this.#e.#pn(Strings.StringWritingDiagramFiles.#B2d());
				#zUi #zUi = new #zUi(#Pc);
				#zUi.#xRb(#Od);
			}
		}

		// Token: 0x06003AFC RID: 15100 RVA: 0x00116DD8 File Offset: 0x00114FD8
		private bool #NRb(ProjectExecutionParameters #Pc, #Q6e #HRb, bool #IRb, ColumnModel #YK, ColumnStorageModel #Od, out #lte #Wdb, out #SJ #ORb)
		{
			ProjectExecutor.#i9b #i9b = new ProjectExecutor.#i9b();
			#i9b.#a = #YK;
			#ORb = this.#f.#IH(#i9b.#a);
			#Wdb = null;
			if (!#ORb.IsValid)
			{
				#Uqe #Uqe = new #Uqe(this.#c, this.#d.#OA());
				#Wdb = #Uqe.#ul(new #Hqe(#Od, null, null)
				{
					CreateDiagrams = false,
					ForcePlaceReinforcement = true,
					Configuration = #HRb,
					ModelHasValidationErrors = true
				});
				this.#h.CurrentColorSettings.#oRb(#Wdb.ColorSettings);
				#Wdb.ModelValidationErrors.AddRange(#ORb.Errors.Select(new Func<ValidationFailure, string>(#i9b.#hdc)));
				IEnumerable<string> source = #Wdb.ModelValidationErrors.Union(#Wdb.ModelValidationWarnings);
				Func<string, FormattedMessage> selector;
				if ((selector = ProjectExecutor.#2Ui.#a) == null)
				{
					selector = (ProjectExecutor.#2Ui.#a = new Func<string, FormattedMessage>(FormattedMessage.#qn));
				}
				this.#VRb(#Pc, source.Select(selector).ToList<FormattedMessage>(), #IRb);
				return false;
			}
			return true;
		}

		// Token: 0x06003AFD RID: 15101 RVA: 0x00116F00 File Offset: 0x00115100
		private void #PRb(ProjectExecutionParameters #Pc, ColumnStorageModel #Od)
		{
			if (!string.IsNullOrWhiteSpace(#Pc.CtiPath))
			{
				this.#e.#pn(Strings.StringWritingCtiFile.#B2d());
				using (FileStream fileStream = Alphaleonis.Win32.Filesystem.File.Open(#Pc.CtiPath, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
				{
					StorageProvider storageProvider = new StorageProvider();
					storageProvider.#zl(#Od, fileStream, new #3oe(), #Hoe.#c);
				}
			}
		}

		// Token: 0x06003AFE RID: 15102 RVA: 0x00116F7C File Offset: 0x0011517C
		private void #QRb(ProjectExecutionParameters #Pc, CommandLineReportGeneratorSettings #ng)
		{
			this.#RRb(#ng.PdfReportPath);
			this.#RRb(#ng.DocReportPath);
			this.#RRb(#ng.XlsReportPath);
			this.#RRb(#ng.TxtReportPath);
			this.#RRb(#ng.CsvReportPath);
			#zUi #zUi = new #zUi(#Pc);
			this.#RRb(#zUi.#BRb());
			this.#RRb(#zUi.#CRb());
			this.#RRb(#zUi.#DRb());
			this.#RRb(#zUi.#ERb());
			this.#RRb(#Pc.DxfPath);
			string text = #Pc.InputPath;
			string a = (text != null) ? text.Trim() : null;
			string text2 = #Pc.CtiPath;
			if (!string.Equals(a, (text2 != null) ? text2.Trim() : null, StringComparison.OrdinalIgnoreCase))
			{
				this.#RRb(#Pc.CtiPath);
			}
			this.#RRb(this.#TRb(#Pc.InputPath));
		}

		// Token: 0x06003AFF RID: 15103 RVA: 0x00117070 File Offset: 0x00115270
		private void #RRb(string #So)
		{
			if (string.IsNullOrWhiteSpace(#So))
			{
				return;
			}
			try
			{
				if (Alphaleonis.Win32.Filesystem.File.Exists(#So))
				{
					Alphaleonis.Win32.Filesystem.File.Delete(#So);
				}
			}
			catch (Exception #ob)
			{
				this.#e.#qn((#Phc.#3hc(107348350) + #So + #Phc.#3hc(107348305)).#z2d() + #sYd.#oYd(#ob));
			}
		}

		// Token: 0x06003B00 RID: 15104 RVA: 0x001170EC File Offset: 0x001152EC
		private CommandLineReportGeneratorSettings #SRb(ProjectExecutionParameters #Pc)
		{
			return new CommandLineReportGeneratorSettings
			{
				TxtReportPath = #Pc.TextReportPath,
				CsvReportPath = #Pc.CsvReportPath,
				PdfReportPath = #Pc.PdfReportPath,
				DocReportPath = #Pc.WordReportPath,
				XlsReportPath = #Pc.ExcelReportPath,
				UseSimpleExcelSheetName = false
			};
		}

		// Token: 0x06003B01 RID: 15105 RVA: 0x00117150 File Offset: 0x00115350
		private string #TRb(string #URb)
		{
			string text = Alphaleonis.Win32.Filesystem.Path.GetFileNameWithoutExtension(#URb) + #Phc.#3hc(107348268);
			string directoryName = Alphaleonis.Win32.Filesystem.Path.GetDirectoryName(#URb);
			return Alphaleonis.Win32.Filesystem.Path.Combine(new string[]
			{
				directoryName,
				text
			});
		}

		// Token: 0x06003B02 RID: 15106 RVA: 0x0011719C File Offset: 0x0011539C
		private bool #VRb(ProjectExecutionParameters #Pc, IList<FormattedMessage> #Lp, bool #WRb)
		{
			string text = this.#TRb((!string.IsNullOrWhiteSpace(#Pc.TextReportPath)) ? #Pc.TextReportPath : #Pc.InputPath);
			this.#RRb(text);
			if (!#Lp.Any<FormattedMessage>())
			{
				return false;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < #Lp.Count; i++)
			{
				FormattedMessage formattedMessage = #Lp[i];
				string # = (formattedMessage.IsError ? Strings.StringError.#u2d(true) : Strings.StringWarning.#u2d(true)) + formattedMessage.Text;
				if (formattedMessage.IsError)
				{
					this.#e.#qn(#);
				}
				else if (formattedMessage.IsWarning)
				{
					this.#e.#tn(#);
				}
				stringBuilder.AppendLine(string.Format(#Phc.#3hc(107348275), i + 1, formattedMessage.Text));
			}
			if (#WRb)
			{
				Alphaleonis.Win32.Filesystem.File.WriteAllText(text, stringBuilder.ToString().Trim());
			}
			return true;
		}

		// Token: 0x06003B03 RID: 15107 RVA: 0x001172B4 File Offset: 0x001154B4
		private bool #XRb(DesignEngine #rj)
		{
			if (((#rj != null) ? #rj.OutputModel : null) != null)
			{
				return #rj.OutputModel.Messages.Any(new Func<Message, bool>(ProjectExecutor.<>c.<>9.#IXi)) || #rj.OutputModel.BarsOutsideSectionPresent;
			}
			return false;
		}

		// Token: 0x06003B04 RID: 15108 RVA: 0x0011731C File Offset: 0x0011551C
		private bool #VRb(ProjectExecutionParameters #Pc, DesignEngine #rj, ColumnStorageModel #Od, bool #WRb, out IList<FormattedMessage> #YRb)
		{
			string #So = this.#TRb(#Pc.InputPath);
			this.#RRb(#So);
			#YRb = new List<FormattedMessage>();
			if (this.#XRb(#rj))
			{
				#YRb = this.#KRb(#rj, #Od, #Pc);
				return this.#VRb(#Pc, #YRb, #WRb);
			}
			return false;
		}

		// Token: 0x04001922 RID: 6434
		private readonly #Ioe #a;

		// Token: 0x04001923 RID: 6435
		private readonly ILogger #b;

		// Token: 0x04001924 RID: 6436
		private readonly #yse #c;

		// Token: 0x04001925 RID: 6437
		private readonly #lB #d;

		// Token: 0x04001926 RID: 6438
		private readonly #XWi #e;

		// Token: 0x04001927 RID: 6439
		private readonly #LJ #f;

		// Token: 0x04001928 RID: 6440
		private readonly #v2c #g;

		// Token: 0x04001929 RID: 6441
		private readonly ISettingsManager #h;

		// Token: 0x0400192A RID: 6442
		private ProjectExecutionParameters #i;

		// Token: 0x020006F4 RID: 1780
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x0400192B RID: 6443
			public static Func<string, FormattedMessage> #a;
		}

		// Token: 0x020006F6 RID: 1782
		[CompilerGenerated]
		private sealed class #oWb
		{
			// Token: 0x06003B0C RID: 15116 RVA: 0x0003320C File Offset: 0x0003140C
			internal void #adc(object #Ge, #Mie #He)
			{
				#He.CompatibilityMode = this.#a.LateralLoadsCompatibilityMode;
			}

			// Token: 0x06003B0D RID: 15117 RVA: 0x00117374 File Offset: 0x00115574
			internal void #bdc(object #Ge, #w7e #He)
			{
				switch (#He.Question)
				{
				case #w7e.#Nif.#a:
					#He.Response = this.#a.IsColumnArchitectural;
					return;
				case #w7e.#Nif.#b:
					#He.Response = this.#a.ContinueProcessingWhenBarsAreOutsideOfSection;
					return;
				case #w7e.#Nif.#c:
					#He.Response = this.#a.ContinueProcessingWhenRhoIsGreaterThanEight;
					return;
				default:
					return;
				}
			}

			// Token: 0x06003B0E RID: 15118 RVA: 0x0003322B File Offset: 0x0003142B
			internal string #cdc(ValidationFailure #Rf)
			{
				return #Zbe.#qp(#Rf, this.#b.#BY());
			}

			// Token: 0x04001931 RID: 6449
			public ProjectExecutionParameters #a;

			// Token: 0x04001932 RID: 6450
			public ColumnModel #b;
		}

		// Token: 0x020006F7 RID: 1783
		[CompilerGenerated]
		private sealed class #i9b
		{
			// Token: 0x06003B10 RID: 15120 RVA: 0x0003324A File Offset: 0x0003144A
			internal string #hdc(ValidationFailure #Nr)
			{
				return #Zbe.#qp(#Nr, this.#a.#BY()).#32d();
			}

			// Token: 0x04001933 RID: 6451
			public ColumnModel #a;
		}
	}
}
