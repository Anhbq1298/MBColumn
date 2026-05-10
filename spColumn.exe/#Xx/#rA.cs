using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using #5Kd;
using #6re;
using #7hc;
using #eU;
using #ezc;
using #kB;
using #LQc;
using #qPd;
using #sUd;
using #v1c;
using #Wse;
using StructurePoint.CoreAssets.GUI.Framework;
using StructurePoint.CoreAssets.GUI.Framework.Services;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.ViewModels;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.ViewModels.Reporting;

namespace #Xx
{
	// Token: 0x020001C7 RID: 455
	internal sealed class #rA : ResultsMainViewModelCore<ColumnResultsExplorerViewModel>, INotifyPropertyChanged, #RBc<#9Kd>, IViewModel, #rPd, #oB
	{
		// Token: 0x06000FE3 RID: 4067 RVA: 0x000A5954 File Offset: 0x000A3B54
		public #rA(#GBc #2x, #9Kd #Ee, ILogger #3x, #v2c #my, #wPd #sA, #tUd #5x, #rW #Hj, #yse #tA, #uUd #qy, #8Sc #ls, #jB #yq, #iW #ss) : base(#2x, #Ee, #3x, #my, #sA, #5x, #tA, #qy)
		{
			this.#a = #Hj;
			this.#b = #ls;
			this.#c = #yq;
			this.#d = #ss;
			this.#c.ReportSourceBecameInvalid += this.#ky;
			base.WindowIconUri = new Uri(#Phc.#3hc(107409058), UriKind.RelativeOrAbsolute);
			base.OutdatedModelDisplayMode = OutdatedModelDisplayMode.MessageWithButton;
		}

		// Token: 0x1700060D RID: 1549
		// (get) Token: 0x06000FE4 RID: 4068 RVA: 0x000A59D4 File Offset: 0x000A3BD4
		public override ColumnResultsExplorerViewModel Explorer
		{
			get
			{
				ColumnResultsExplorerViewModel result;
				if ((result = this.#e) == null)
				{
					result = (this.#e = new ColumnResultsExplorerViewModel((#yse)base.ReporterSettings, base.FeaturesDescriptor, base.FileSystemService, base.ExceptionHandler));
				}
				return result;
			}
		}

		// Token: 0x1700060E RID: 1550
		// (get) Token: 0x06000FE5 RID: 4069 RVA: 0x000124F0 File Offset: 0x000106F0
		public override string ResultsAreUnavailableOrOutdatedMessaage
		{
			get
			{
				return Strings.StringTablesAreUnavailableOrOutdated;
			}
		}

		// Token: 0x1700060F RID: 1551
		// (get) Token: 0x06000FE6 RID: 4070 RVA: 0x000124FB File Offset: 0x000106FB
		public override string RegenerateResultsMessage { get; }

		// Token: 0x06000FE7 RID: 4071 RVA: 0x00012507 File Offset: 0x00010707
		public override void #od(IGenericLoaderWindow #by)
		{
			this.#c.#DA();
			this.#c.IsEnabled = true;
			base.#od(#by);
		}

		// Token: 0x06000FE8 RID: 4072 RVA: 0x000A5A24 File Offset: 0x000A3C24
		protected override bool #pA()
		{
			#UA #UA = this.#a.ResultsParameters;
			return #UA != null && (!#UA.UpdateOnly || base.View.Visibility != Visibility.Collapsed);
		}

		// Token: 0x06000FE9 RID: 4073 RVA: 0x000A5A6C File Offset: 0x000A3C6C
		protected override void #hz()
		{
			if (this.Explorer.IsRefreshing)
			{
				base.View.BringToFront();
				this.#b.#od(this.#d.#6(), StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringSpResultsIsRefreshingTheView.#z2d(true) + Strings.StringPleaseWaitUntilItFinishes.#z2d(), StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringSpResults, MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK, MessageBoxOptions.None);
				return;
			}
			try
			{
				#lte #lte = this.#a.Model;
				this.#c.#DA();
				this.Explorer.#YOd(base.View.MainContentGridSize.Width);
				this.Explorer.#hz(#lte);
				base.Title = Strings.StringTables + (string.IsNullOrWhiteSpace(#lte.GeneralInfo.FileName) ? string.Empty : (#Phc.#3hc(107382888) + Path.GetFileName(#lte.GeneralInfo.FileName)));
			}
			finally
			{
				base.ShowPleaseWaitProgramIsSolving = false;
			}
		}

		// Token: 0x06000FEA RID: 4074 RVA: 0x00012533 File Offset: 0x00010733
		protected override void #qA()
		{
			base.ShowPleaseWaitProgramIsSolving = true;
			base.#qA();
		}

		// Token: 0x06000FEB RID: 4075 RVA: 0x0001254E File Offset: 0x0001074E
		public void #jy()
		{
			this.#qA();
		}

		// Token: 0x06000FEC RID: 4076 RVA: 0x0001254E File Offset: 0x0001074E
		private void #ky(object #Ge, EventArgs #He)
		{
			this.#qA();
		}

		// Token: 0x04000636 RID: 1590
		private readonly #rW #a;

		// Token: 0x04000637 RID: 1591
		private readonly #8Sc #b;

		// Token: 0x04000638 RID: 1592
		private readonly #jB #c;

		// Token: 0x04000639 RID: 1593
		private readonly #iW #d;

		// Token: 0x0400063A RID: 1594
		private ColumnResultsExplorerViewModel #e;

		// Token: 0x0400063B RID: 1595
		[CompilerGenerated]
		private readonly string #f = Strings.StringRegenerateTheTables;
	}
}
