using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using #5Kd;
using #6re;
using #7hc;
using #BTd;
using #ERd;
using #eU;
using #ezc;
using #FTd;
using #hId;
using #kB;
using #LPd;
using #LQc;
using #qPd;
using #sUd;
using #v1c;
using #wqe;
using #Wse;
using StructurePoint.CoreAssets.GUI.Framework;
using StructurePoint.CoreAssets.GUI.Framework.Services;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Application.API;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.ViewModels;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Printing;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.ViewModels.Reporting;

namespace #Xx
{
	// Token: 0x020001A1 RID: 417
	internal sealed class #ly : ReporterMainViewModelCore<ColumnReportExplorerViewModel>, INotifyPropertyChanged, #RBc<#4Kd>, IViewModel, #pPd, #mB
	{
		// Token: 0x06000D9E RID: 3486 RVA: 0x0009F0A4 File Offset: 0x0009D2A4
		public #ly(#GBc #2x, ILogger #3x, #8Sc #ls, #v2c #my, #tUd #5x, #rUd #Hj, #vUd #ny, #yse #iw, #4Kd #Ee, #xPd #oy, #uPd #py, #uUd #qy, #ATd #ry, #jB #yq, #qW #1c) : base(#2x, #Ee, #3x, #my, #qy, #ls, #iw, #py, #ny, #Hj, #oy, #5x, #ry, true)
		{
			base.View.SetViewModel(this);
			base.WindowIconUri = new Uri(#Phc.#3hc(107409058), UriKind.RelativeOrAbsolute);
			base.OutdatedModelDisplayMode = OutdatedModelDisplayMode.MessageWithButton;
			this.#c = new #Kqe();
			this.#a = #yq;
			this.#b = #1c;
			this.#a.ReportAvailabilityChecked += this.#ky;
		}

		// Token: 0x1700055E RID: 1374
		// (get) Token: 0x06000D9F RID: 3487 RVA: 0x00010800 File Offset: 0x0000EA00
		public override DocumentContentOptionsCore OptionsCore
		{
			get
			{
				return this.Explorer.Options;
			}
		}

		// Token: 0x1700055F RID: 1375
		// (get) Token: 0x06000DA0 RID: 3488 RVA: 0x0009F13C File Offset: 0x0009D33C
		public override ColumnReportExplorerViewModel Explorer
		{
			get
			{
				if (this.#e == null)
				{
					this.#e = new ColumnReportExplorerViewModel(base.FeaturesDescriptor, base.ExceptionHandler, base.ApplicationContext, (#yse)base.SettingsManager, this.#b);
					this.#e.NavigationRequested += this.#YLd;
				}
				this.#e.DesignEngineService = this.#b;
				return this.#e;
			}
		}

		// Token: 0x17000560 RID: 1376
		// (get) Token: 0x06000DA1 RID: 3489 RVA: 0x00010819 File Offset: 0x0000EA19
		protected override #JRd Reports
		{
			get
			{
				return this.#c;
			}
		}

		// Token: 0x17000561 RID: 1377
		// (get) Token: 0x06000DA2 RID: 3490 RVA: 0x00010825 File Offset: 0x0000EA25
		public override string ReportIsUnavailableOrOutdatedMessaage { get; }

		// Token: 0x06000DA3 RID: 3491 RVA: 0x0009F1BC File Offset: 0x0009D3BC
		public override void #od(IGenericLoaderWindow #by)
		{
			this.#a.#DA();
			this.#a.IsEnabled = true;
			this.#a.#BA(TimeSpan.FromSeconds(2.0));
			this.#d = null;
			base.#od(#by);
		}

		// Token: 0x06000DA4 RID: 3492 RVA: 0x0009F214 File Offset: 0x0009D414
		protected override string #cy()
		{
			#lte #lte = this.#d;
			string result = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			if (#lte != null)
			{
				string directoryName = Path.GetDirectoryName(#lte.GeneralInfo.FileName);
				if (base.FileSystemService.#X1c(directoryName))
				{
					result = directoryName;
				}
			}
			return result;
		}

		// Token: 0x06000DA5 RID: 3493 RVA: 0x00010831 File Offset: 0x0000EA31
		protected override string #dy()
		{
			if (!string.IsNullOrWhiteSpace(this.#d.GeneralInfo.FileName))
			{
				return Path.GetFileNameWithoutExtension(this.#d.GeneralInfo.FileName);
			}
			return null;
		}

		// Token: 0x06000DA6 RID: 3494 RVA: 0x0009F260 File Offset: 0x0009D460
		protected override #jJd #ey()
		{
			#jJd #jJd = base.#jMd();
			if (#jJd.PrinterStatus == #GId.#a)
			{
				base.SettingsManager.#iUd(#jJd.Margins, (ReporterUnitsSystem)this.#d.Input.Options.Unit, #NTd.#a);
			}
			PageMarginsSpecification #wId = #jJd.Margins.#xId(this.#d.Input.Options.Unit == UnitSystem.USCustomary || #jJd.PrinterStatus > #GId.#a);
			#jJd.Margins.#mg(#wId);
			return #jJd;
		}

		// Token: 0x06000DA7 RID: 3495 RVA: 0x0009F2FC File Offset: 0x0009D4FC
		protected override void #fy()
		{
			this.#c.#uP(this.#d);
			this.#c.#uP(((#rW)base.ApplicationContext).DocumentOptions);
			this.#c.#uP(this.#ey());
		}

		// Token: 0x06000DA8 RID: 3496 RVA: 0x0009F354 File Offset: 0x0009D554
		protected override void #gy()
		{
			#ly.#XWb #XWb = new #ly.#XWb();
			#XWb.#a = this;
			#rW #rW = (#rW)base.ApplicationContext;
			#XWb.#b = #rW.Model;
			#UA #UA = #rW.ResultsParameters;
			this.#d = #XWb.#b;
			base.ApplicationContext.IsCurrentlyReadingData = true;
			try
			{
				base.Title = Strings.StringReporter + (string.IsNullOrWhiteSpace(#XWb.#b.GeneralInfo.FileName) ? string.Empty : (#Phc.#3hc(107382888) + Path.GetFileName(#XWb.#b.GeneralInfo.FileName)));
				this.#c.#uP(this.#d);
				base.ApplicationContext.ShowPleaseWaitProgramIsSolving = false;
				base.ApplicationContext.IsDirty = #UA.UpdateOnly;
				if (this.#f)
				{
					UnitSystem unit = #XWb.#b.Input.Options.Unit;
					UnitSystem? unitSystem = this.#g;
					if (unit == unitSystem.GetValueOrDefault() & unitSystem != null)
					{
						goto IL_1C1;
					}
				}
				#gId #gId = base.SettingsManager.#ey((ReporterUnitsSystem)#XWb.#b.Input.Options.Unit, #NTd.#a);
				#gId.UnitString = ((#XWb.#b.Input.Options.Unit == UnitSystem.SIMetric) ? Localization.StringMillimeters : Localization.StringInches);
				#gId.Settings = base.SettingsManager;
				#gId.Logger = base.Logger;
				#gId.FontSizeInfoProvider = base.ReportFontSizeInfoProvider;
				#gId.DialogService = base.DialogService;
				base.OptionsPanelViewModel.View.InitializePrintOptions(#gId);
				this.#g = new UnitSystem?(#XWb.#b.Input.Options.Unit);
				this.#f = true;
				IL_1C1:
				base.#AMd(new Action(#XWb.#WWb));
			}
			finally
			{
				base.ApplicationContext.IsCurrentlyReadingData = false;
			}
		}

		// Token: 0x06000DA9 RID: 3497 RVA: 0x0001086D File Offset: 0x0000EA6D
		protected override bool #hy()
		{
			return this.#d != null;
		}

		// Token: 0x06000DAA RID: 3498 RVA: 0x0009F578 File Offset: 0x0009D778
		protected override bool #iy()
		{
			#rW #rW = (#rW)base.ApplicationContext;
			#UA #UA = #rW.ReporterParameters;
			return !#UA.UpdateOnly;
		}

		// Token: 0x06000DAB RID: 3499 RVA: 0x0009F5B0 File Offset: 0x0009D7B0
		public void #jy()
		{
			base.ApplicationContext.ShowPleaseWaitProgramIsSolving = true;
			base.ApplicationContext.IsDirty = false;
			this.#MMd();
			if (this.#d != null)
			{
				this.#d.IsReportSourceValid = false;
			}
			this.#d = null;
			this.Explorer.#7Nd();
			base.ApplicationContext.Options.IsReportFileFormatChangeAllowed = false;
			this.#vh(true);
		}

		// Token: 0x06000DAC RID: 3500 RVA: 0x0001087C File Offset: 0x0000EA7C
		private void #ky(object #Ge, #OPd #He)
		{
			if (#He.IsSourceValid)
			{
				return;
			}
			this.#jy();
		}

		// Token: 0x04000526 RID: 1318
		private readonly #jB #a;

		// Token: 0x04000527 RID: 1319
		private readonly #qW #b;

		// Token: 0x04000528 RID: 1320
		private readonly #Kqe #c;

		// Token: 0x04000529 RID: 1321
		private #lte #d;

		// Token: 0x0400052A RID: 1322
		private ColumnReportExplorerViewModel #e;

		// Token: 0x0400052B RID: 1323
		private bool #f;

		// Token: 0x0400052C RID: 1324
		private UnitSystem? #g;

		// Token: 0x0400052D RID: 1325
		[CompilerGenerated]
		private readonly string #h = Strings.StringReportIsUnavailableOrOutdated.#z2d();

		// Token: 0x020001A2 RID: 418
		[CompilerGenerated]
		private sealed class #XWb
		{
			// Token: 0x06000DAE RID: 3502 RVA: 0x00010899 File Offset: 0x0000EA99
			internal void #WWb()
			{
				this.#a.Explorer.#hz(this.#b);
			}

			// Token: 0x0400052E RID: 1326
			public #ly #a;

			// Token: 0x0400052F RID: 1327
			public #lte #b;
		}
	}
}
