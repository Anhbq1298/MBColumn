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
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Viewports.API;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.ViewModels.StatusBar
{
	// Token: 0x0200010A RID: 266
	internal sealed class DraftingSettingsDynamicInputViewModel : #rH<#Ib>, INotifyPropertyChanged, #kH<#Ib>, IViewModel<#Ib>, IViewModel, #Im
	{
		// Token: 0x060008AF RID: 2223 RVA: 0x000937AC File Offset: 0x000919AC
		public DraftingSettingsDynamicInputViewModel(Lazy<#Ib> view, IExtendedServices services, #jB reportAvailabilityChecker, IEditorService editorService, #zJ designEngineAvailabilityChecker) : base(view, services, Strings.StringDynamicInput_CAMEL)
		{
			this.#a = services;
			this.#b = reportAvailabilityChecker;
			this.#c = editorService;
			this.#d = designEngineAvailabilityChecker;
			this.#i = new RadObservableCollection<ComboItem<int>>(Enumerable.Range(0, 5).Select(new Func<int, ComboItem<int>>(DraftingSettingsDynamicInputViewModel.<>c.<>9.#9Ub)));
		}

		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x060008B0 RID: 2224 RVA: 0x0000C8E1 File Offset: 0x0000AAE1
		// (set) Token: 0x060008B1 RID: 2225 RVA: 0x0000C8ED File Offset: 0x0000AAED
		public bool ShowInputBoxes
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (this.#e != value)
				{
					this.#e = value;
					if (!this.#g)
					{
						this.#lm(true);
					}
					base.RaisePropertyChanged(#Phc.#3hc(107380887));
				}
			}
		}

		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x060008B2 RID: 2226 RVA: 0x0000C92A File Offset: 0x0000AB2A
		// (set) Token: 0x060008B3 RID: 2227 RVA: 0x0000C936 File Offset: 0x0000AB36
		public bool ShowPrompt
		{
			get
			{
				return this.#f;
			}
			set
			{
				if (this.#f != value)
				{
					this.#f = value;
					if (!this.#g)
					{
						this.#lm(true);
					}
					base.RaisePropertyChanged(#Phc.#3hc(107380834));
				}
			}
		}

		// Token: 0x170003C6 RID: 966
		// (get) Token: 0x060008B4 RID: 2228 RVA: 0x0000C973 File Offset: 0x0000AB73
		// (set) Token: 0x060008B5 RID: 2229 RVA: 0x0000C97F File Offset: 0x0000AB7F
		public int Precision
		{
			get
			{
				return this.#h;
			}
			set
			{
				if (this.#h != value)
				{
					this.#h = value;
					if (!this.#g)
					{
						this.#lm(true);
					}
					base.RaisePropertyChanged(#Phc.#3hc(107380928));
				}
			}
		}

		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x060008B6 RID: 2230 RVA: 0x0000C9BC File Offset: 0x0000ABBC
		public RadObservableCollection<ComboItem<int>> Precisions { get; }

		// Token: 0x170003C8 RID: 968
		// (get) Token: 0x060008B7 RID: 2231 RVA: 0x0000C9C8 File Offset: 0x0000ABC8
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x0000C9D8 File Offset: 0x0000ABD8
		protected override void #1l()
		{
			base.#1l();
			this.#lm(false);
			base.#mH();
		}

		// Token: 0x060008B9 RID: 2233 RVA: 0x0000C9F9 File Offset: 0x0000ABF9
		protected override void #0l()
		{
			base.#0l();
			this.#4l(base.Services.Project.Model.DraftingSettings.DynamicInputSettings);
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x0000CA2D File Offset: 0x0000AC2D
		private void #lm(bool #4f = true)
		{
			this.#2l();
			this.#mm(#4f);
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x0009381C File Offset: 0x00091A1C
		private void #2l()
		{
			DraftingSettingsDynamicInputViewModel.#ZXb #ZXb = new DraftingSettingsDynamicInputViewModel.#ZXb();
			#ZXb.#b = this;
			#ZXb.#a = base.Services.Project.Model.DraftingSettings.DynamicInputSettings;
			if (#ZXb.#a.ShowPrompt == this.ShowPrompt && #ZXb.#a.ShowInputBoxes == this.ShowInputBoxes && #ZXb.#a.Precision == this.Precision)
			{
				return;
			}
			using (this.#d.#AA())
			{
				using (this.#b.#AA())
				{
					this.#c.#0Pb(new Action(#ZXb.#5Ub));
					this.#b.#DA();
				}
			}
			base.Services.Settings.DynamicInput = #ZXb.#a;
		}

		// Token: 0x060008BC RID: 2236 RVA: 0x0009393C File Offset: 0x00091B3C
		private void #mm(bool #4f = true)
		{
			foreach (IModelEditorViewport modelEditorViewport in this.#a.ViewportsManager.Viewports.OfType<IModelEditorViewport>())
			{
				modelEditorViewport.Editor.DynamicInput.Config.ShowPrompt = this.ShowPrompt;
				modelEditorViewport.Editor.DynamicInput.Config.ShowInputBoxes = this.ShowInputBoxes;
				modelEditorViewport.Editor.DynamicInput.Config.Precision = this.Precision;
				if (#4f && modelEditorViewport == this.#a.ViewportsManager.ActiveViewport)
				{
					modelEditorViewport.Renderer.#cg();
				}
			}
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x0000CA48 File Offset: 0x0000AC48
		private void #4l(#n7 #ng)
		{
			this.#g = true;
			this.ShowInputBoxes = #ng.ShowInputBoxes;
			this.ShowPrompt = #ng.ShowPrompt;
			this.Precision = #ng.Precision;
			this.#g = false;
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x0000C67D File Offset: 0x0000A87D
		bool #kH<#Ib>.#nm()
		{
			return base.IsValid;
		}

		// Token: 0x040002C9 RID: 713
		private readonly IExtendedServices #a;

		// Token: 0x040002CA RID: 714
		private readonly #jB #b;

		// Token: 0x040002CB RID: 715
		private readonly IEditorService #c;

		// Token: 0x040002CC RID: 716
		private readonly #zJ #d;

		// Token: 0x040002CD RID: 717
		private bool #e;

		// Token: 0x040002CE RID: 718
		private bool #f;

		// Token: 0x040002CF RID: 719
		private bool #g;

		// Token: 0x040002D0 RID: 720
		private int #h;

		// Token: 0x040002D1 RID: 721
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<int>> #i;

		// Token: 0x0200010C RID: 268
		[CompilerGenerated]
		private sealed class #ZXb
		{
			// Token: 0x060008C3 RID: 2243 RVA: 0x00093A24 File Offset: 0x00091C24
			internal void #5Ub()
			{
				this.#a.ShowPrompt = this.#b.ShowPrompt;
				this.#a.ShowInputBoxes = this.#b.ShowInputBoxes;
				this.#a.Precision = this.#b.Precision;
			}

			// Token: 0x040002D4 RID: 724
			public #n7 #a;

			// Token: 0x040002D5 RID: 725
			public DraftingSettingsDynamicInputViewModel #b;
		}
	}
}
