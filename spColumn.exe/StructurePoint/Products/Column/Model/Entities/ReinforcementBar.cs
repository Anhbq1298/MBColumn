using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using #5Z;
using #7hc;
using #9pe;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.Products.Column.Model.Entities
{
	// Token: 0x020003A6 RID: 934
	[DebuggerDisplay("X={X}, Y={Y}, Z={Z}")]
	internal sealed class ReinforcementBar : #20, #mqe
	{
		// Token: 0x06001EE4 RID: 7908 RVA: 0x000C2FDC File Offset: 0x000C11DC
		public ReinforcementBar(#nqe other)
		{
			this.Area = other.Area;
			this.X = other.X;
			this.Y = other.Y;
			this.Z = other.Z;
		}

		// Token: 0x06001EE5 RID: 7909 RVA: 0x000C302C File Offset: 0x000C122C
		public ReinforcementBar(ReinforcementBar oldBar)
		{
			this.X = oldBar.X;
			this.Y = oldBar.Y;
			this.Z = oldBar.Z;
			this.Area = oldBar.Area;
		}

		// Token: 0x06001EE6 RID: 7910 RVA: 0x0001E0AE File Offset: 0x0001C2AE
		public ReinforcementBar(float area, float x, float y, float z)
		{
			this.Area = area;
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		// Token: 0x06001EE7 RID: 7911 RVA: 0x000C307C File Offset: 0x000C127C
		public ReinforcementBar(ReinforcementBar item)
		{
			this.Area = item.Area;
			this.X = item.X;
			this.Y = item.Y;
			this.Z = item.Z;
		}

		// Token: 0x17000ACA RID: 2762
		// (get) Token: 0x06001EE8 RID: 7912 RVA: 0x0001E0DE File Offset: 0x0001C2DE
		// (set) Token: 0x06001EE9 RID: 7913 RVA: 0x0001E0EA File Offset: 0x0001C2EA
		public StructurePoint.CoreAssets.Infrastructure.Data.Point Location
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (StructurePoint.CoreAssets.Infrastructure.Data.Point.#F3d(this.#c, value))
				{
					this.#c = value;
					this.Point = new devDept.Geometry.Point3D(value.X, value.Y);
				}
			}
		}

		// Token: 0x17000ACB RID: 2763
		// (get) Token: 0x06001EEA RID: 7914 RVA: 0x0001E126 File Offset: 0x0001C326
		// (set) Token: 0x06001EEB RID: 7915 RVA: 0x0001E132 File Offset: 0x0001C332
		public devDept.Geometry.Point3D Point { get; private set; }

		// Token: 0x17000ACC RID: 2764
		// (get) Token: 0x06001EEC RID: 7916 RVA: 0x0001E143 File Offset: 0x0001C343
		// (set) Token: 0x06001EED RID: 7917 RVA: 0x0001E14F File Offset: 0x0001C34F
		public float Area
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.SetProperty<float>(ref this.#a, value, #Phc.#3hc(107397869));
			}
		}

		// Token: 0x17000ACD RID: 2765
		// (get) Token: 0x06001EEE RID: 7918 RVA: 0x000C30CC File Offset: 0x000C12CC
		// (set) Token: 0x06001EEF RID: 7919 RVA: 0x000C30F4 File Offset: 0x000C12F4
		public float X
		{
			get
			{
				return (float)this.Location.X;
			}
			set
			{
				this.Location = new StructurePoint.CoreAssets.Infrastructure.Data.Point((double)value, this.Location.Y);
			}
		}

		// Token: 0x17000ACE RID: 2766
		// (get) Token: 0x06001EF0 RID: 7920 RVA: 0x000C3128 File Offset: 0x000C1328
		// (set) Token: 0x06001EF1 RID: 7921 RVA: 0x0001E175 File Offset: 0x0001C375
		public float Y
		{
			get
			{
				return (float)this.Location.Y;
			}
			set
			{
				this.Location = new StructurePoint.CoreAssets.Infrastructure.Data.Point((double)this.X, (double)value);
			}
		}

		// Token: 0x17000ACF RID: 2767
		// (get) Token: 0x06001EF2 RID: 7922 RVA: 0x0001E197 File Offset: 0x0001C397
		// (set) Token: 0x06001EF3 RID: 7923 RVA: 0x0001E1A3 File Offset: 0x0001C3A3
		public float Z
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<float>(ref this.#b, value, #Phc.#3hc(107397860));
			}
		}

		// Token: 0x06001EF4 RID: 7924 RVA: 0x0001E1C9 File Offset: 0x0001C3C9
		public ReinforcementBar #EA()
		{
			return new ReinforcementBar(this.#CY());
		}

		// Token: 0x06001EF5 RID: 7925 RVA: 0x000C3150 File Offset: 0x000C1350
		public ReinforcementBar #CY()
		{
			return new ReinforcementBar
			{
				Y = this.Y,
				X = this.X,
				Z = this.Z,
				Area = this.Area
			};
		}

		// Token: 0x04000C49 RID: 3145
		private float #a;

		// Token: 0x04000C4A RID: 3146
		private float #b;

		// Token: 0x04000C4B RID: 3147
		private StructurePoint.CoreAssets.Infrastructure.Data.Point #c;

		// Token: 0x04000C4C RID: 3148
		[CompilerGenerated]
		private devDept.Geometry.Point3D #d = new devDept.Geometry.Point3D();
	}
}
