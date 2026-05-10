using System;
using #7hc;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.Products.Column.Model;

namespace #5Z
{
	// Token: 0x020003A1 RID: 929
	internal sealed class #E2 : #20
	{
		// Token: 0x06001E61 RID: 7777 RVA: 0x0001CC2D File Offset: 0x0001AE2D
		public #E2()
		{
		}

		// Token: 0x06001E62 RID: 7778 RVA: 0x000C2784 File Offset: 0x000C0984
		public #E2(IrregularOptions #Rf)
		{
			this.ViewFlag = #Rf.ViewFlag;
			this.SectionFlag = #Rf.SectionFlag;
			this.ReinforcementFlag = #Rf.ReinforcementFlag;
			this.BarsToPlace = #Rf.BarsToPlace;
			this.BarArea = #Rf.BarArea;
			this.DrawMax = #Rf.DrawMax.#TW();
			this.DrawMin = #Rf.DrawMin.#TW();
			this.GridSpc = #Rf.GridSpc.#TW();
			this.Snap = #Rf.Snap.#TW();
		}

		// Token: 0x17000A97 RID: 2711
		// (get) Token: 0x06001E63 RID: 7779 RVA: 0x0001D569 File Offset: 0x0001B769
		// (set) Token: 0x06001E64 RID: 7780 RVA: 0x0001D575 File Offset: 0x0001B775
		public ViewFlag ViewFlag
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.SetProperty<ViewFlag>(ref this.#a, value, #Phc.#3hc(107398990));
			}
		}

		// Token: 0x17000A98 RID: 2712
		// (get) Token: 0x06001E65 RID: 7781 RVA: 0x0001D59B File Offset: 0x0001B79B
		// (set) Token: 0x06001E66 RID: 7782 RVA: 0x0001D5A7 File Offset: 0x0001B7A7
		public SectionFlag SectionFlag
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<SectionFlag>(ref this.#b, value, #Phc.#3hc(107398977));
			}
		}

		// Token: 0x17000A99 RID: 2713
		// (get) Token: 0x06001E67 RID: 7783 RVA: 0x0001D5CD File Offset: 0x0001B7CD
		// (set) Token: 0x06001E68 RID: 7784 RVA: 0x0001D5D9 File Offset: 0x0001B7D9
		public ReinforcementFlag ReinforcementFlag
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.SetProperty<ReinforcementFlag>(ref this.#c, value, #Phc.#3hc(107398992));
			}
		}

		// Token: 0x17000A9A RID: 2714
		// (get) Token: 0x06001E69 RID: 7785 RVA: 0x0001D5FF File Offset: 0x0001B7FF
		// (set) Token: 0x06001E6A RID: 7786 RVA: 0x0001D60B File Offset: 0x0001B80B
		public short BarsToPlace
		{
			get
			{
				return this.#d;
			}
			set
			{
				this.SetProperty<short>(ref this.#d, value, #Phc.#3hc(107398967));
			}
		}

		// Token: 0x17000A9B RID: 2715
		// (get) Token: 0x06001E6B RID: 7787 RVA: 0x0001D631 File Offset: 0x0001B831
		// (set) Token: 0x06001E6C RID: 7788 RVA: 0x0001D63D File Offset: 0x0001B83D
		public float BarArea
		{
			get
			{
				return this.#e;
			}
			set
			{
				this.SetProperty<float>(ref this.#e, value, #Phc.#3hc(107398918));
			}
		}

		// Token: 0x17000A9C RID: 2716
		// (get) Token: 0x06001E6D RID: 7789 RVA: 0x0001D663 File Offset: 0x0001B863
		// (set) Token: 0x06001E6E RID: 7790 RVA: 0x0001D66F File Offset: 0x0001B86F
		public Point3D DrawMax
		{
			get
			{
				return this.#f;
			}
			set
			{
				this.SetProperty<Point3D>(ref this.#f, value, #Phc.#3hc(107398937));
			}
		}

		// Token: 0x17000A9D RID: 2717
		// (get) Token: 0x06001E6F RID: 7791 RVA: 0x0001D695 File Offset: 0x0001B895
		// (set) Token: 0x06001E70 RID: 7792 RVA: 0x0001D6A1 File Offset: 0x0001B8A1
		public Point3D DrawMin
		{
			get
			{
				return this.#g;
			}
			set
			{
				this.SetProperty<Point3D>(ref this.#g, value, #Phc.#3hc(107398380));
			}
		}

		// Token: 0x17000A9E RID: 2718
		// (get) Token: 0x06001E71 RID: 7793 RVA: 0x0001D6C7 File Offset: 0x0001B8C7
		// (set) Token: 0x06001E72 RID: 7794 RVA: 0x0001D6D3 File Offset: 0x0001B8D3
		public Point3D GridSpc
		{
			get
			{
				return this.#h;
			}
			set
			{
				this.SetProperty<Point3D>(ref this.#h, value, #Phc.#3hc(107398399));
			}
		}

		// Token: 0x17000A9F RID: 2719
		// (get) Token: 0x06001E73 RID: 7795 RVA: 0x0001D6F9 File Offset: 0x0001B8F9
		// (set) Token: 0x06001E74 RID: 7796 RVA: 0x0001D705 File Offset: 0x0001B905
		public Point3D Snap
		{
			get
			{
				return this.#i;
			}
			set
			{
				this.SetProperty<Point3D>(ref this.#i, value, #Phc.#3hc(107398386));
			}
		}

		// Token: 0x06001E75 RID: 7797 RVA: 0x000C2818 File Offset: 0x000C0A18
		public IrregularOptions #CY()
		{
			IrregularOptions irregularOptions = new IrregularOptions();
			Point3D point3D = this.DrawMax;
			Point drawMax;
			if ((drawMax = ((point3D != null) ? point3D.#SW() : null)) == null)
			{
				drawMax = new Point();
			}
			irregularOptions.DrawMax = drawMax;
			Point3D point3D2 = this.Snap;
			Point snap;
			if ((snap = ((point3D2 != null) ? point3D2.#SW() : null)) == null)
			{
				snap = new Point();
			}
			irregularOptions.Snap = snap;
			Point3D point3D3 = this.GridSpc;
			Point gridSpc;
			if ((gridSpc = ((point3D3 != null) ? point3D3.#SW() : null)) == null)
			{
				gridSpc = new Point();
			}
			irregularOptions.GridSpc = gridSpc;
			Point3D point3D4 = this.DrawMin;
			irregularOptions.DrawMin = (((point3D4 != null) ? point3D4.#SW() : null) ?? new Point());
			irregularOptions.SectionFlag = this.SectionFlag;
			irregularOptions.ReinforcementFlag = this.ReinforcementFlag;
			irregularOptions.BarsToPlace = this.BarsToPlace;
			irregularOptions.ViewFlag = this.ViewFlag;
			irregularOptions.BarArea = this.BarArea;
			return irregularOptions;
		}

		// Token: 0x04000C18 RID: 3096
		private ViewFlag #a;

		// Token: 0x04000C19 RID: 3097
		private SectionFlag #b;

		// Token: 0x04000C1A RID: 3098
		private ReinforcementFlag #c;

		// Token: 0x04000C1B RID: 3099
		private short #d;

		// Token: 0x04000C1C RID: 3100
		private float #e;

		// Token: 0x04000C1D RID: 3101
		private Point3D #f;

		// Token: 0x04000C1E RID: 3102
		private Point3D #g;

		// Token: 0x04000C1F RID: 3103
		private Point3D #h;

		// Token: 0x04000C20 RID: 3104
		private Point3D #i;
	}
}
