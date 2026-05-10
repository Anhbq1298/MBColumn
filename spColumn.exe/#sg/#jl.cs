using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using #1b;
using #7hc;
using #eU;
using #f7;
using #HI;
using #kB;
using #lH;
using #qJ;
using #RJb;
using #Wl;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.StatusBar;
using StructurePoint.Products.Column.Viewports.API;
using Telerik.Windows.Controls;

namespace #sg
{
	// Token: 0x020000F0 RID: 240
	internal sealed class #jl : #HH<#ac>, IViewModel<#ac>, INotifyPropertyChanged, IViewModel, #MI
	{
		// Token: 0x060007B0 RID: 1968 RVA: 0x00091A68 File Offset: 0x0008FC68
		public #jl(Lazy<#ac> #Ee, IExtendedServices #0c, #Gm #kl, #Jm #ll, #Im #ml, #Km #nl, #Hm #ol, #jB #pl, IEditorService #wj, #zJ #pj, #BLb #ql) : base(#Ee, #0c)
		{
			this.#a = #0c;
			this.#b = #pl;
			this.#c = #wj;
			this.#d = #pj;
			this.#e = #ql;
			this.#g = #kl;
			this.#h = #ll;
			this.#i = #ml;
			this.#j = #nl;
			this.#k = #ol;
			this.#n = new DelegateCommand(new Action<object>(this.#fl), new Predicate<object>(this.#gl));
			this.#l = new DelegateCommand(new Action<object>(this.#dl), new Predicate<object>(this.#el));
			base.Project.ModelChanged += this.#cl;
			this.#a.UndoManager.PropertyChanged += this.#7j;
			#ql.ActiveScopeChanged += this.#bl;
		}

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x060007B1 RID: 1969 RVA: 0x0000BDB0 File Offset: 0x00009FB0
		public #Gm Coordinates { get; }

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x060007B2 RID: 1970 RVA: 0x0000BDBC File Offset: 0x00009FBC
		public #Jm ObjectSnap { get; }

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x060007B3 RID: 1971 RVA: 0x0000BDC8 File Offset: 0x00009FC8
		public #Im DynamicInput { get; }

		// Token: 0x17000341 RID: 833
		// (get) Token: 0x060007B4 RID: 1972 RVA: 0x0000BDD4 File Offset: 0x00009FD4
		public #Km Snap { get; }

		// Token: 0x17000342 RID: 834
		// (get) Token: 0x060007B5 RID: 1973 RVA: 0x0000BDE0 File Offset: 0x00009FE0
		public #Hm DrawingGrid { get; }

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x060007B6 RID: 1974 RVA: 0x0000BDEC File Offset: 0x00009FEC
		public DelegateCommand ShowDraftingSettingsCommand { get; }

		// Token: 0x17000344 RID: 836
		// (get) Token: 0x060007B7 RID: 1975 RVA: 0x0000BDF8 File Offset: 0x00009FF8
		public #Vl DraftingFeatures { get; }

		// Token: 0x17000345 RID: 837
		// (get) Token: 0x060007B8 RID: 1976 RVA: 0x0000BE04 File Offset: 0x0000A004
		public DelegateCommand DisableEnableDraftingSettingCommand { get; }

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x060007B9 RID: 1977 RVA: 0x0000BE10 File Offset: 0x0000A010
		// (set) Token: 0x060007BA RID: 1978 RVA: 0x0000BE1C File Offset: 0x0000A01C
		public bool CanChangeDraftingSettings
		{
			get
			{
				return this.#f;
			}
			private set
			{
				if (this.#f != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107381299));
					this.#f = value;
					base.RaisePropertyChanged(#Phc.#3hc(107381299));
				}
			}
		}

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x060007BB RID: 1979 RVA: 0x0000BE5A File Offset: 0x0000A05A
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x0000BE6A File Offset: 0x0000A06A
		protected override void #uh(#ac #Ee)
		{
			base.#uh(#Ee);
			this.#hl();
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x00091B64 File Offset: 0x0008FD64
		protected override void #vh()
		{
			this.CanChangeDraftingSettings = (base.Project.Model.Options.SectionType == SectionType.Irregular && this.#e.ActiveScope == this.#e.Section);
			this.ShowDraftingSettingsCommand.InvalidateCanExecute();
			this.DisableEnableDraftingSettingCommand.InvalidateCanExecute();
			base.#vh();
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x0000BE85 File Offset: 0x0000A085
		private void #bl(object #Ge, #QJb #He)
		{
			this.#vh();
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x0000BE85 File Offset: 0x0000A085
		private void #7j(object #Ge, PropertyChangedEventArgs #He)
		{
			this.#vh();
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x0000BE95 File Offset: 0x0000A095
		private void #cl(object #Ge, #7V #He)
		{
			this.#hl();
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x00009E6A File Offset: 0x0000806A
		private void #dl(object #Sb)
		{
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x0000BEA5 File Offset: 0x0000A0A5
		private bool #el(object #Sb)
		{
			return base.Project.Model.Options.SectionType == SectionType.Irregular && this.#e.ActiveScope == this.#e.Section;
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x00091BD4 File Offset: 0x0008FDD4
		private void #fl(object #Sb)
		{
			#jl.#SUb #SUb = new #jl.#SUb();
			#SUb.#a = #Sb;
			#SUb.#b = this;
			using (this.#d.#AA())
			{
				using (this.#b.#AA())
				{
					this.#c.#0Pb(new Action(#SUb.#ZUb));
					this.#b.#DA();
				}
			}
			this.#a.ViewportsManager.Renderer.#cg();
			IModelEditorViewport modelEditorViewport = this.#a.ViewportsManager.ActiveViewport as IModelEditorViewport;
			if (modelEditorViewport != null)
			{
				modelEditorViewport.Editor.SetFocus(null);
			}
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x0000BEE5 File Offset: 0x0000A0E5
		private bool #gl(object #Sb)
		{
			return this.CanChangeDraftingSettings;
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x00091CBC File Offset: 0x0008FEBC
		private void #hl()
		{
			if (base.Project.Model.DraftingSettings == null)
			{
				return;
			}
			#z7 #z = base.Project.Model.DraftingSettings.SnappingSettings;
			this.DraftingFeatures.IsSnapChecked = #z.SnappingGridEnabled;
			this.DraftingFeatures.IsObjectSnapChecked = #z.ObjectSnappingEnabled;
			#j7 #j = base.Project.Model.DraftingSettings.DrawingGridSettings;
			this.DraftingFeatures.IsDrawingGridChecked = #j.GridEnabled;
			this.DraftingFeatures.IsDynamicInputChecked = base.Project.Model.DraftingSettings.DynamicInputSettings.Enabled;
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x00091D80 File Offset: 0x0008FF80
		private void #il(ColumnModel #Od)
		{
			#e7 #e = #Od.DraftingSettings;
			base.Services.Settings.DrawingGrid = #e.DrawingGridSettings;
			base.Services.Settings.DynamicInput = #e.DynamicInputSettings;
			base.Services.Settings.SnappingSettings = #e.SnappingSettings;
			base.Services.Settings.StatusBar = #e.StatusBarSettings;
		}

		// Token: 0x0400021D RID: 541
		private readonly IExtendedServices #a;

		// Token: 0x0400021E RID: 542
		private readonly #jB #b;

		// Token: 0x0400021F RID: 543
		private readonly IEditorService #c;

		// Token: 0x04000220 RID: 544
		private readonly #zJ #d;

		// Token: 0x04000221 RID: 545
		private readonly #BLb #e;

		// Token: 0x04000222 RID: 546
		private bool #f;

		// Token: 0x04000223 RID: 547
		[CompilerGenerated]
		private readonly #Gm #g;

		// Token: 0x04000224 RID: 548
		[CompilerGenerated]
		private readonly #Jm #h;

		// Token: 0x04000225 RID: 549
		[CompilerGenerated]
		private readonly #Im #i;

		// Token: 0x04000226 RID: 550
		[CompilerGenerated]
		private readonly #Km #j;

		// Token: 0x04000227 RID: 551
		[CompilerGenerated]
		private readonly #Hm #k;

		// Token: 0x04000228 RID: 552
		[CompilerGenerated]
		private readonly DelegateCommand #l;

		// Token: 0x04000229 RID: 553
		[CompilerGenerated]
		private readonly #Vl #m = new #Vl();

		// Token: 0x0400022A RID: 554
		[CompilerGenerated]
		private readonly DelegateCommand #n;

		// Token: 0x020000F1 RID: 241
		[CompilerGenerated]
		private sealed class #SUb
		{
			// Token: 0x060007C8 RID: 1992 RVA: 0x00091DF8 File Offset: 0x0008FFF8
			internal void #ZUb()
			{
				DraftingFeature draftingFeature = (DraftingFeature)this.#a;
				#e7 #e = this.#b.Services.Project.Model.DraftingSettings;
				switch (draftingFeature)
				{
				case DraftingFeature.DrawingGrid:
					#e.DrawingGridSettings.GridEnabled = this.#b.DraftingFeatures.IsDrawingGridChecked;
					break;
				case DraftingFeature.DynamicInput:
					#e.DynamicInputSettings.Enabled = this.#b.DraftingFeatures.IsDynamicInputChecked;
					break;
				case DraftingFeature.ObjectSnap:
					#e.SnappingSettings.ObjectSnappingEnabled = this.#b.DraftingFeatures.IsObjectSnapChecked;
					break;
				case DraftingFeature.Snap:
					#e.SnappingSettings.SnappingGridEnabled = this.#b.DraftingFeatures.IsSnapChecked;
					break;
				case DraftingFeature.Ortho:
					this.#b.Services.Settings.OrthoEnabled = this.#b.DraftingFeatures.IsOrthoChecked;
					break;
				}
				this.#b.#il(this.#b.Services.Project.Model);
				foreach (IModelEditorViewport modelEditorViewport in this.#b.#a.ViewportsManager.Viewports.OfType<IModelEditorViewport>())
				{
					modelEditorViewport.Editor.DynamicInput.Config.Enabled = #e.DynamicInputSettings.Enabled;
				}
			}

			// Token: 0x0400022B RID: 555
			public object #a;

			// Token: 0x0400022C RID: 556
			public #jl #b;
		}
	}
}
