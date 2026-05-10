using System;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Other;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace #f7
{
	// Token: 0x020003BF RID: 959
	internal sealed class #z7 : NotifyPropertyChangedObjectBase
	{
		// Token: 0x17000B5A RID: 2906
		// (get) Token: 0x060020BA RID: 8378 RVA: 0x0001FEB2 File Offset: 0x0001E0B2
		// (set) Token: 0x060020BB RID: 8379 RVA: 0x0001FEBE File Offset: 0x0001E0BE
		public double SnapSpacingX
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.#d != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107398098));
					this.#d = value;
					base.RaisePropertyChanged(#Phc.#3hc(107398098));
				}
			}
		}

		// Token: 0x17000B5B RID: 2907
		// (get) Token: 0x060020BC RID: 8380 RVA: 0x0001FEFC File Offset: 0x0001E0FC
		// (set) Token: 0x060020BD RID: 8381 RVA: 0x0001FF08 File Offset: 0x0001E108
		public double SnapSpacingY
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (this.#e != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107398049));
					this.#e = value;
					base.RaisePropertyChanged(#Phc.#3hc(107398049));
				}
			}
		}

		// Token: 0x17000B5C RID: 2908
		// (get) Token: 0x060020BE RID: 8382 RVA: 0x0001FF46 File Offset: 0x0001E146
		// (set) Token: 0x060020BF RID: 8383 RVA: 0x0001FF52 File Offset: 0x0001E152
		public bool EqualXAndYSpacing
		{
			get
			{
				return this.#f;
			}
			set
			{
				if (this.#f != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107380921));
					this.#f = value;
					base.RaisePropertyChanged(#Phc.#3hc(107380921));
				}
			}
		}

		// Token: 0x17000B5D RID: 2909
		// (get) Token: 0x060020C0 RID: 8384 RVA: 0x0001FF90 File Offset: 0x0001E190
		// (set) Token: 0x060020C1 RID: 8385 RVA: 0x0001FF9C File Offset: 0x0001E19C
		public bool SnapStructuralGrid
		{
			get
			{
				return this.#g;
			}
			set
			{
				if (this.#g != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107380761));
					this.#g = value;
					base.RaisePropertyChanged(#Phc.#3hc(107380761));
				}
			}
		}

		// Token: 0x17000B5E RID: 2910
		// (get) Token: 0x060020C2 RID: 8386 RVA: 0x0001FFDA File Offset: 0x0001E1DA
		// (set) Token: 0x060020C3 RID: 8387 RVA: 0x0001FFE6 File Offset: 0x0001E1E6
		public bool SnapDrawingGrid
		{
			get
			{
				return this.#h;
			}
			set
			{
				if (this.#h != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107380750));
					this.#h = value;
					base.RaisePropertyChanged(#Phc.#3hc(107380750));
				}
			}
		}

		// Token: 0x17000B5F RID: 2911
		// (get) Token: 0x060020C4 RID: 8388 RVA: 0x00020024 File Offset: 0x0001E224
		// (set) Token: 0x060020C5 RID: 8389 RVA: 0x00020030 File Offset: 0x0001E230
		public bool SnapObjectsCentroid
		{
			get
			{
				return this.#i;
			}
			set
			{
				if (this.#i != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107380779));
					this.#i = value;
					base.RaisePropertyChanged(#Phc.#3hc(107380779));
				}
			}
		}

		// Token: 0x17000B60 RID: 2912
		// (get) Token: 0x060020C6 RID: 8390 RVA: 0x0002006E File Offset: 0x0001E26E
		// (set) Token: 0x060020C7 RID: 8391 RVA: 0x0002007A File Offset: 0x0001E27A
		public bool SnapIntersection
		{
			get
			{
				return this.#j;
			}
			set
			{
				if (this.#j != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107380804));
					this.#j = value;
					base.RaisePropertyChanged(#Phc.#3hc(107380804));
				}
			}
		}

		// Token: 0x17000B61 RID: 2913
		// (get) Token: 0x060020C8 RID: 8392 RVA: 0x000200B8 File Offset: 0x0001E2B8
		// (set) Token: 0x060020C9 RID: 8393 RVA: 0x000200C4 File Offset: 0x0001E2C4
		public bool SnappingGridEnabled
		{
			get
			{
				return this.#k;
			}
			set
			{
				if (this.#k != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107398064));
					this.#k = value;
					base.RaisePropertyChanged(#Phc.#3hc(107398064));
				}
			}
		}

		// Token: 0x17000B62 RID: 2914
		// (get) Token: 0x060020CA RID: 8394 RVA: 0x00020102 File Offset: 0x0001E302
		// (set) Token: 0x060020CB RID: 8395 RVA: 0x0002010E File Offset: 0x0001E30E
		public bool ObjectSnappingEnabled
		{
			get
			{
				return this.#l;
			}
			set
			{
				if (this.#l != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107398035));
					this.#l = value;
					base.RaisePropertyChanged(#Phc.#3hc(107398035));
				}
			}
		}

		// Token: 0x17000B63 RID: 2915
		// (get) Token: 0x060020CC RID: 8396 RVA: 0x0002014C File Offset: 0x0001E34C
		// (set) Token: 0x060020CD RID: 8397 RVA: 0x00020158 File Offset: 0x0001E358
		public bool SnapToCover
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107398006));
					this.#a = value;
					base.RaisePropertyChanged(#Phc.#3hc(107398006));
				}
			}
		}

		// Token: 0x17000B64 RID: 2916
		// (get) Token: 0x060020CE RID: 8398 RVA: 0x00020196 File Offset: 0x0001E396
		// (set) Token: 0x060020CF RID: 8399 RVA: 0x000201A2 File Offset: 0x0001E3A2
		public bool SnapReinforcement
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107381216));
					this.#b = value;
					base.RaisePropertyChanged(#Phc.#3hc(107381216));
				}
			}
		}

		// Token: 0x17000B65 RID: 2917
		// (get) Token: 0x060020D0 RID: 8400 RVA: 0x000201E0 File Offset: 0x0001E3E0
		// (set) Token: 0x060020D1 RID: 8401 RVA: 0x000201EC File Offset: 0x0001E3EC
		public bool SnapShapes
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107381191));
					this.#c = value;
					base.RaisePropertyChanged(#Phc.#3hc(107381191));
				}
			}
		}

		// Token: 0x060020D2 RID: 8402 RVA: 0x000C6C18 File Offset: 0x000C4E18
		public SnappingSettings #CY()
		{
			return new SnappingSettings
			{
				SnapSpacingX = this.SnapSpacingX,
				SnapSpacingY = this.SnapSpacingY,
				EqualXAndYSpacing = this.EqualXAndYSpacing,
				SnapStructuralGrid = this.SnapStructuralGrid,
				SnapDrawingGrid = this.SnapDrawingGrid,
				SnapObjectsCentroid = this.SnapObjectsCentroid,
				SnapIntersection = this.SnapIntersection,
				SnappingGridEnabled = this.SnappingGridEnabled,
				ObjectSnappingEnabled = this.ObjectSnappingEnabled,
				SnapToCover = this.SnapToCover,
				SnapReinforcement = this.SnapReinforcement,
				SnapShapes = this.SnapShapes
			};
		}

		// Token: 0x060020D3 RID: 8403 RVA: 0x000C6CD8 File Offset: 0x000C4ED8
		public static #z7 #c7(SnappingSettings #y7)
		{
			return new #z7
			{
				SnapSpacingX = #y7.SnapSpacingX,
				SnapSpacingY = #y7.SnapSpacingY,
				EqualXAndYSpacing = #y7.EqualXAndYSpacing,
				SnapStructuralGrid = #y7.SnapStructuralGrid,
				SnapDrawingGrid = #y7.SnapDrawingGrid,
				SnapObjectsCentroid = #y7.SnapObjectsCentroid,
				SnapIntersection = #y7.SnapIntersection,
				SnappingGridEnabled = #y7.SnappingGridEnabled,
				ObjectSnappingEnabled = #y7.ObjectSnappingEnabled,
				SnapToCover = #y7.SnapToCover,
				SnapShapes = #y7.SnapShapes,
				SnapReinforcement = #y7.SnapReinforcement
			};
		}

		// Token: 0x04000D39 RID: 3385
		private bool #a;

		// Token: 0x04000D3A RID: 3386
		private bool #b;

		// Token: 0x04000D3B RID: 3387
		private bool #c;

		// Token: 0x04000D3C RID: 3388
		private double #d;

		// Token: 0x04000D3D RID: 3389
		private double #e;

		// Token: 0x04000D3E RID: 3390
		private bool #f;

		// Token: 0x04000D3F RID: 3391
		private bool #g;

		// Token: 0x04000D40 RID: 3392
		private bool #h;

		// Token: 0x04000D41 RID: 3393
		private bool #i;

		// Token: 0x04000D42 RID: 3394
		private bool #j;

		// Token: 0x04000D43 RID: 3395
		private bool #k;

		// Token: 0x04000D44 RID: 3396
		private bool #l;
	}
}
