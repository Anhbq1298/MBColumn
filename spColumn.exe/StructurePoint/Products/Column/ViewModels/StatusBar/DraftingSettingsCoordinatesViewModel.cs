using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #f7;
using #Gb;
using #kB;
using #lH;
using #qJ;
using #Wl;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Other;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Services.API;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.ViewModels.StatusBar
{
	// Token: 0x02000100 RID: 256
	internal sealed class DraftingSettingsCoordinatesViewModel : #rH<#Fb>, INotifyPropertyChanged, #kH<#Fb>, IViewModel<#Fb>, IViewModel, #Gm
	{
		// Token: 0x0600086D RID: 2157 RVA: 0x0000C5C1 File Offset: 0x0000A7C1
		public DraftingSettingsCoordinatesViewModel(Lazy<#Fb> view, IExtendedServices services, #jB reportAvailabilityChecker, IEditorService editorService, #zJ designEngineAvailabilityChecker) : base(view, services, Strings.StringCoordinates)
		{
			this.#a = reportAvailabilityChecker;
			this.#b = editorService;
			this.#c = designEngineAvailabilityChecker;
		}

		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x0600086E RID: 2158 RVA: 0x0000C5F2 File Offset: 0x0000A7F2
		public RadObservableCollection<ComboItem<int>> Precisions { get; }

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x0600086F RID: 2159 RVA: 0x0000C5FE File Offset: 0x0000A7FE
		// (set) Token: 0x06000870 RID: 2160 RVA: 0x0000C60A File Offset: 0x0000A80A
		public ComboItem<int> Precision
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.#d != value)
				{
					this.#d = value;
					base.RaisePropertyChanged(#Phc.#3hc(107380928));
				}
			}
		}

		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x06000871 RID: 2161 RVA: 0x0000C638 File Offset: 0x0000A838
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x00092F84 File Offset: 0x00091184
		protected override void #0l()
		{
			base.#0l();
			this.Precisions.Clear();
			this.Precisions.AddRange(Enumerable.Range(0, 6).Select(new Func<int, ComboItem<int>>(DraftingSettingsCoordinatesViewModel.<>c.<>9.#0wf)));
			this.#4l(base.Services.Project.Model.DraftingSettings.StatusBarSettings);
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x00093004 File Offset: 0x00091204
		protected override void #1l()
		{
			base.#1l();
			base.Services.Settings.StatusBar.ShowCoordinates = true;
			this.#2l();
			base.Services.GuiController.EditorStatusBar.Section.#Dnb();
			base.#mH();
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x00093060 File Offset: 0x00091260
		private void #2l()
		{
			DraftingSettingsCoordinatesViewModel.#8Ub #8Ub = new DraftingSettingsCoordinatesViewModel.#8Ub();
			#8Ub.#a = this;
			#8Ub.#b = base.Services.Project.Model.DraftingSettings.StatusBarSettings;
			int num = this.#3l() ? #8Ub.#b.FootInchPrecision : #8Ub.#b.FloatingPointPrecision;
			if (num == this.Precision.Value)
			{
				return;
			}
			using (this.#c.#AA())
			{
				using (this.#a.#AA())
				{
					this.#b.#0Pb(new Action(#8Ub.#5Ub));
					this.#a.#DA();
				}
			}
			base.Services.Settings.StatusBar = #8Ub.#b;
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x0000C648 File Offset: 0x0000A848
		private bool #3l()
		{
			return base.Services.Project.Model.Units.Section.Width.UnitType == LengthUnit.Inch;
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x00093178 File Offset: 0x00091378
		private void #4l(#H7 #ng)
		{
			DraftingSettingsCoordinatesViewModel.#DUb #DUb = new DraftingSettingsCoordinatesViewModel.#DUb();
			#H7 #H = #H7.#c7(StatusBarSettings.Default(base.Services.Project.Model.Options.Unit));
			#DUb.#a = (this.#3l() ? #ng.FootInchPrecision : #ng.FloatingPointPrecision);
			#DUb.#b = (this.#3l() ? #H.FootInchPrecision : #H.FloatingPointPrecision);
			this.Precision = (this.Precisions.FirstOrDefault(new Func<ComboItem<int>, bool>(#DUb.#6Ub)) ?? this.Precisions.First(new Func<ComboItem<int>, bool>(#DUb.#7Ub)));
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x0000C67D File Offset: 0x0000A87D
		bool #kH<#Fb>.#5l()
		{
			return base.IsValid;
		}

		// Token: 0x040002B1 RID: 689
		private readonly #jB #a;

		// Token: 0x040002B2 RID: 690
		private readonly IEditorService #b;

		// Token: 0x040002B3 RID: 691
		private readonly #zJ #c;

		// Token: 0x040002B4 RID: 692
		private ComboItem<int> #d;

		// Token: 0x040002B5 RID: 693
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<int>> #e = new RadObservableCollection<ComboItem<int>>();

		// Token: 0x02000102 RID: 258
		[CompilerGenerated]
		private sealed class #8Ub
		{
			// Token: 0x0600087C RID: 2172 RVA: 0x00093240 File Offset: 0x00091440
			internal void #5Ub()
			{
				if (this.#a.#3l())
				{
					this.#b.FootInchPrecision = this.#a.Precision.Value;
					return;
				}
				this.#b.FloatingPointPrecision = this.#a.Precision.Value;
			}

			// Token: 0x040002B8 RID: 696
			public DraftingSettingsCoordinatesViewModel #a;

			// Token: 0x040002B9 RID: 697
			public #H7 #b;
		}

		// Token: 0x02000103 RID: 259
		[CompilerGenerated]
		private sealed class #DUb
		{
			// Token: 0x0600087E RID: 2174 RVA: 0x0000C6BD File Offset: 0x0000A8BD
			internal bool #6Ub(ComboItem<int> #Rf)
			{
				return #Rf.Value == this.#a;
			}

			// Token: 0x0600087F RID: 2175 RVA: 0x0000C6D9 File Offset: 0x0000A8D9
			internal bool #7Ub(ComboItem<int> #Rf)
			{
				return #Rf.Value == this.#b;
			}

			// Token: 0x040002BA RID: 698
			public int #a;

			// Token: 0x040002BB RID: 699
			public int #b;
		}
	}
}
