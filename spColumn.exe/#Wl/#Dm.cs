using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using #7hc;
using #f7;
using #Gb;
using #kB;
using #lH;
using #qJ;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Services.API;

namespace #Wl
{
	// Token: 0x0200010E RID: 270
	internal sealed class #Dm : #rH<#Jb>, INotifyPropertyChanged, #kH<#Jb>, IViewModel<#Jb>, IViewModel, #Jm
	{
		// Token: 0x060008C4 RID: 2244 RVA: 0x0000CA98 File Offset: 0x0000AC98
		public #Dm(Lazy<#Jb> #Ee, IExtendedServices #0c, #jB #pl, IEditorService #wj, #zJ #pj) : base(#Ee, #0c, Strings.StringObjectSnap_CAMEL)
		{
			this.#a = #pl;
			this.#b = #wj;
			this.#c = #pj;
		}

		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x060008C5 RID: 2245 RVA: 0x0000CABE File Offset: 0x0000ACBE
		// (set) Token: 0x060008C6 RID: 2246 RVA: 0x0000CACA File Offset: 0x0000ACCA
		public bool SnapCover
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
					base.RaisePropertyChanged(#Phc.#3hc(107380849));
				}
			}
		}

		// Token: 0x170003CA RID: 970
		// (get) Token: 0x060008C7 RID: 2247 RVA: 0x0000CAF8 File Offset: 0x0000ACF8
		// (set) Token: 0x060008C8 RID: 2248 RVA: 0x0000CB04 File Offset: 0x0000AD04
		public bool SnapIntersection
		{
			get
			{
				return this.#g;
			}
			set
			{
				if (this.#g != value)
				{
					this.#g = value;
					base.RaisePropertyChanged(#Phc.#3hc(107380804));
				}
			}
		}

		// Token: 0x170003CB RID: 971
		// (get) Token: 0x060008C9 RID: 2249 RVA: 0x0000CB32 File Offset: 0x0000AD32
		// (set) Token: 0x060008CA RID: 2250 RVA: 0x0000CB3E File Offset: 0x0000AD3E
		public bool SnapObjectsCentroid
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
					base.RaisePropertyChanged(#Phc.#3hc(107380779));
				}
			}
		}

		// Token: 0x170003CC RID: 972
		// (get) Token: 0x060008CB RID: 2251 RVA: 0x0000CB6C File Offset: 0x0000AD6C
		// (set) Token: 0x060008CC RID: 2252 RVA: 0x0000CB78 File Offset: 0x0000AD78
		public bool SnapDrawingGrid
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
					base.RaisePropertyChanged(#Phc.#3hc(107380750));
				}
			}
		}

		// Token: 0x170003CD RID: 973
		// (get) Token: 0x060008CD RID: 2253 RVA: 0x0000CBA6 File Offset: 0x0000ADA6
		// (set) Token: 0x060008CE RID: 2254 RVA: 0x0000CBB2 File Offset: 0x0000ADB2
		public bool SnapStructuralGrid
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
					base.RaisePropertyChanged(#Phc.#3hc(107380761));
				}
			}
		}

		// Token: 0x170003CE RID: 974
		// (get) Token: 0x060008CF RID: 2255 RVA: 0x0000CBE0 File Offset: 0x0000ADE0
		// (set) Token: 0x060008D0 RID: 2256 RVA: 0x0000CBEC File Offset: 0x0000ADEC
		public bool SnapReinforcement
		{
			get
			{
				return this.#i;
			}
			set
			{
				if (this.#i != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107381216));
					this.#i = value;
					base.RaisePropertyChanged(#Phc.#3hc(107381216));
				}
			}
		}

		// Token: 0x170003CF RID: 975
		// (get) Token: 0x060008D1 RID: 2257 RVA: 0x0000CC2A File Offset: 0x0000AE2A
		// (set) Token: 0x060008D2 RID: 2258 RVA: 0x0000CC36 File Offset: 0x0000AE36
		public bool SnapShapes
		{
			get
			{
				return this.#j;
			}
			set
			{
				if (this.#j != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107381191));
					this.#j = value;
					base.RaisePropertyChanged(#Phc.#3hc(107381191));
				}
			}
		}

		// Token: 0x170003D0 RID: 976
		// (get) Token: 0x060008D3 RID: 2259 RVA: 0x0000CC74 File Offset: 0x0000AE74
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x0000CC84 File Offset: 0x0000AE84
		protected override void #0l()
		{
			base.#0l();
			this.#4l(base.Services.Project.Model.DraftingSettings.SnappingSettings);
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x0000CCB8 File Offset: 0x0000AEB8
		protected override void #1l()
		{
			base.#1l();
			this.#2l();
			base.#mH();
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x00093A80 File Offset: 0x00091C80
		private void #2l()
		{
			#Dm.#p6b #p6b = new #Dm.#p6b();
			#p6b.#b = this;
			#p6b.#a = base.Services.Project.Model.DraftingSettings.SnappingSettings;
			if (#p6b.#a.SnapObjectsCentroid == this.SnapObjectsCentroid && #p6b.#a.SnapDrawingGrid == this.SnapDrawingGrid && #p6b.#a.SnapIntersection == this.SnapIntersection && #p6b.#a.SnapToCover == this.SnapCover && #p6b.#a.SnapStructuralGrid == this.SnapStructuralGrid && #p6b.#a.SnapShapes == this.SnapShapes && #p6b.#a.SnapReinforcement == this.SnapReinforcement)
			{
				return;
			}
			using (this.#c.#AA())
			{
				using (this.#a.#AA())
				{
					this.#b.#0Pb(new Action(#p6b.#5Ub));
					this.#a.#DA();
				}
			}
			base.Services.Settings.SnappingSettings = #p6b.#a;
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x00093BEC File Offset: 0x00091DEC
		private void #4l(#z7 #ng)
		{
			this.SnapIntersection = #ng.SnapIntersection;
			this.SnapStructuralGrid = #ng.SnapStructuralGrid;
			this.SnapObjectsCentroid = #ng.SnapObjectsCentroid;
			this.SnapCover = #ng.SnapToCover;
			this.SnapDrawingGrid = #ng.SnapDrawingGrid;
			this.SnapReinforcement = #ng.SnapReinforcement;
			this.SnapShapes = #ng.SnapShapes;
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x0000C67D File Offset: 0x0000A87D
		bool #kH<#Jb>.#Cm()
		{
			return base.IsValid;
		}

		// Token: 0x040002D6 RID: 726
		private readonly #jB #a;

		// Token: 0x040002D7 RID: 727
		private readonly IEditorService #b;

		// Token: 0x040002D8 RID: 728
		private readonly #zJ #c;

		// Token: 0x040002D9 RID: 729
		private bool #d;

		// Token: 0x040002DA RID: 730
		private bool #e;

		// Token: 0x040002DB RID: 731
		private bool #f;

		// Token: 0x040002DC RID: 732
		private bool #g;

		// Token: 0x040002DD RID: 733
		private bool #h;

		// Token: 0x040002DE RID: 734
		private bool #i;

		// Token: 0x040002DF RID: 735
		private bool #j;

		// Token: 0x0200010F RID: 271
		[CompilerGenerated]
		private sealed class #p6b
		{
			// Token: 0x060008DA RID: 2266 RVA: 0x00093C5C File Offset: 0x00091E5C
			internal void #5Ub()
			{
				this.#a.SnapObjectsCentroid = this.#b.SnapObjectsCentroid;
				this.#a.SnapDrawingGrid = this.#b.SnapDrawingGrid;
				this.#a.SnapIntersection = this.#b.SnapIntersection;
				this.#a.SnapToCover = this.#b.SnapCover;
				this.#a.SnapStructuralGrid = this.#b.SnapStructuralGrid;
				this.#a.SnapReinforcement = this.#b.SnapReinforcement;
				this.#a.SnapShapes = this.#b.SnapShapes;
			}

			// Token: 0x040002E0 RID: 736
			public #z7 #a;

			// Token: 0x040002E1 RID: 737
			public #Dm #b;
		}
	}
}
