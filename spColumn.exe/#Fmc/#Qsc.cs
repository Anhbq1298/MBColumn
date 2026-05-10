using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #Fmc
{
	// Token: 0x020007EA RID: 2026
	internal static class #Qsc
	{
		// Token: 0x060040FD RID: 16637 RVA: 0x00130618 File Offset: 0x0012E818
		public static bool #Nsc(ShapeData #rP, SegmentData #Osc)
		{
			#Qsc.#GTb #GTb = new #Qsc.#GTb();
			#GTb.#a = #Osc;
			#X0d.#V0d(#rP, #Phc.#3hc(107371527), Component.Geometry, #Phc.#3hc(107461513));
			#X0d.#V0d(#GTb.#a, #Phc.#3hc(107461492), Component.Geometry, #Phc.#3hc(107461451));
			return #rP.Polygons.Any(new Func<PolygonData, bool>(#GTb.#jyc));
		}

		// Token: 0x060040FE RID: 16638 RVA: 0x001306A8 File Offset: 0x0012E8A8
		public static bool #Psc(SegmentData #Urc, SegmentData #Vrc)
		{
			int num;
			int num2;
			if (#Urc != #Vrc)
			{
				if (5 == 0)
				{
					return false;
				}
				if (#Urc == null)
				{
					if (false)
					{
						goto IL_93;
					}
					if (#Vrc == null)
					{
						goto IL_26;
					}
				}
				if (#Urc != null && #Vrc != null)
				{
					if (PointsConverter.#uC(#Urc.StartPoint, #Vrc.StartPoint))
					{
						bool flag = (num = (PointsConverter.#uC(#Urc.EndPoint, #Vrc.EndPoint) ? 1 : 0)) != 0;
						if (false)
						{
							goto IL_27;
						}
						if (flag)
						{
							goto IL_93;
						}
					}
					num2 = (PointsConverter.#uC(#Urc.StartPoint, #Vrc.EndPoint) ? 1 : 0);
					goto IL_7D;
				}
				return false;
				IL_93:
				if (!false)
				{
					return true;
				}
				return false;
			}
			IL_26:
			num = 1;
			IL_27:
			int num3 = num2 = num;
			if (num3 != 0)
			{
				return num3 != 0;
			}
			IL_7D:
			if (num2 != 0)
			{
				return PointsConverter.#uC(#Urc.EndPoint, #Vrc.StartPoint);
			}
			return false;
		}

		// Token: 0x020007EB RID: 2027
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06004100 RID: 16640 RVA: 0x00130788 File Offset: 0x0012E988
			internal bool #jyc(PolygonData #JP)
			{
				IEnumerable<SegmentData> source = #JP.Segments;
				Func<SegmentData, bool> predicate;
				if ((predicate = this.#b) == null)
				{
					predicate = (this.#b = new Func<SegmentData, bool>(this.#kyc));
				}
				return source.Any(predicate);
			}

			// Token: 0x06004101 RID: 16641 RVA: 0x00036A3F File Offset: 0x00034C3F
			internal bool #kyc(SegmentData #PP)
			{
				return #Qsc.#Psc(#PP, this.#a);
			}

			// Token: 0x04001D42 RID: 7490
			public SegmentData #a;

			// Token: 0x04001D43 RID: 7491
			public Func<SegmentData, bool> #b;
		}
	}
}
