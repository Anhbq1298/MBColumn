using System;
using System.Runtime.CompilerServices;
using #bZg;
using ClipperLib;

namespace StructurePoint.CoreAssets.Geometry.Helpers
{
	// Token: 0x020007FA RID: 2042
	internal struct ClipperLine
	{
		// Token: 0x1700136C RID: 4972
		// (get) Token: 0x060041A1 RID: 16801 RVA: 0x00037186 File Offset: 0x00035386
		// (set) Token: 0x060041A2 RID: 16802 RVA: 0x00037192 File Offset: 0x00035392
		public IntPoint PointA { [#cWi] get; set; }

		// Token: 0x1700136D RID: 4973
		// (get) Token: 0x060041A3 RID: 16803 RVA: 0x000371A3 File Offset: 0x000353A3
		// (set) Token: 0x060041A4 RID: 16804 RVA: 0x000371AF File Offset: 0x000353AF
		public IntPoint PointB { [#cWi] get; set; }

		// Token: 0x060041A5 RID: 16805 RVA: 0x0013338C File Offset: 0x0013158C
		public bool #7tc(ClipperLine #Ztc, bool #8tc = false)
		{
			if (4 != 0)
			{
				bool flag = this.#7tc(#Ztc.PointA, #8tc);
				while (flag && !false)
				{
					bool result = flag = this.#7tc(#Ztc.PointB, #8tc);
					if (!false)
					{
						return result;
					}
				}
			}
			return false;
		}

		// Token: 0x060041A6 RID: 16806 RVA: 0x001333E4 File Offset: 0x001315E4
		public bool #7tc(IntPoint #Ng, bool #8tc = false)
		{
			if (false || (#8tc && (\u001C\u0002.\u0010\u0005(#Ng, this.PointA) || \u001C\u0002.\u0010\u0005(#Ng, this.PointB))))
			{
				return false;
			}
			if (ClipperHelper.#Gtc(this.PointA, this.PointB, #Ng) != 0L)
			{
				return false;
			}
			long num = \u001D\u0002.\u0011\u0005(this.PointA.X, this.PointB.X);
			long num2 = #Ng.X;
			while (num <= num2 && #Ng.X <= \u001D\u0002.\u0012\u0005(this.PointA.X, this.PointB.X))
			{
				long num3 = num = \u001D\u0002.\u0011\u0005(this.PointA.Y, this.PointB.Y);
				long num4 = num2 = #Ng.Y;
				if (!false)
				{
					if (num3 <= num4 && #Ng.Y <= \u001D\u0002.\u0012\u0005(this.PointA.Y, this.PointB.Y))
					{
						return true;
					}
					break;
				}
			}
			return false;
		}

		// Token: 0x060041A7 RID: 16807 RVA: 0x00133538 File Offset: 0x00131738
		public IntPoint? #9tc(ClipperLine #Ztc)
		{
			if (this.PointA == #Ztc.PointA)
			{
				return new IntPoint?(this.PointA);
			}
			if (this.PointB == #Ztc.PointA)
			{
				return new IntPoint?(this.PointB);
			}
			if (this.PointA == #Ztc.PointB)
			{
				return new IntPoint?(this.PointA);
			}
			if (this.PointB == #Ztc.PointB)
			{
				return new IntPoint?(this.PointB);
			}
			return null;
		}

		// Token: 0x060041A8 RID: 16808 RVA: 0x00133628 File Offset: 0x00131828
		public IntPoint? #auc(IntPoint? #Ng)
		{
			if (#Ng != null)
			{
				if (this.PointA == #Ng.Value)
				{
					if (!false)
					{
						return new IntPoint?(this.PointB);
					}
				}
				else
				{
					if (this.PointB == #Ng.Value)
					{
						return new IntPoint?(this.PointA);
					}
					return null;
				}
			}
			return null;
		}

		// Token: 0x04001D80 RID: 7552
		[CompilerGenerated]
		private IntPoint #a;

		// Token: 0x04001D81 RID: 7553
		[CompilerGenerated]
		private IntPoint #b;
	}
}
