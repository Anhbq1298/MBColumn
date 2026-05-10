using System;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #Fmc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #3Pc
{
	// Token: 0x02000C14 RID: 3092
	internal static class #2Pc
	{
		// Token: 0x06006499 RID: 25753 RVA: 0x0018AD4C File Offset: 0x00188F4C
		public static bool #WHb(PolygonData #1Pc, ShapeData #Rf, Point #oBb, Point #pBb)
		{
			string #R0d = #Phc.#3hc(107398878);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107443832);
			if (!false)
			{
				#X0d.#V0d(#Rf, #R0d, #x6c, #Qic);
			}
			if (!false)
			{
				bool flag2;
				bool flag = flag2 = BooleanOperationsHelper.#7lc(#Rf, #1Pc);
				if (!false)
				{
					if (!flag)
					{
						return false;
					}
					if (GeometryHelper.#WHb(#Rf, #oBb))
					{
						if (7 == 0)
						{
							goto IL_D1;
						}
						if (!#Rf.#cxc(0).Points2D.Contains(#oBb))
						{
							goto IL_7A;
						}
					}
					if (false)
					{
						return true;
					}
					if (!GeometryHelper.#WHb(#Rf, #pBb) || #Rf.#cxc(0).Points2D.Contains(#pBb))
					{
						return true;
					}
					IL_7A:
					if (!#2Pc.#UHb(#Rf.#cxc(0), #oBb))
					{
						goto IL_9A;
					}
					flag2 = #2Pc.#UHb(#Rf.#cxc(0), #pBb);
				}
				if (!flag2)
				{
					goto IL_9A;
				}
				return true;
				IL_9A:
				if (GeometryHelper.#WHb(#Rf, #oBb) && !#Rf.#cxc(0).Points2D.Contains(#oBb))
				{
					goto IL_C8;
				}
			}
			if (#2Pc.#UHb(#Rf.#cxc(0), #pBb))
			{
				return true;
			}
			IL_C8:
			if (!GeometryHelper.#WHb(#Rf, #pBb))
			{
				goto IL_E5;
			}
			IL_D1:
			if (!#Rf.#cxc(0).Points2D.Contains(#pBb))
			{
				return false;
			}
			IL_E5:
			if (#2Pc.#UHb(#Rf.#cxc(0), #oBb))
			{
				return true;
			}
			return false;
		}

		// Token: 0x0600649A RID: 25754 RVA: 0x0018AE5C File Offset: 0x0018905C
		private static bool #UHb(PolygonData #JP, Point #Ng)
		{
			#2Pc.#v0b #v0b = new #2Pc.#v0b();
			#2Pc.#v0b #v0b2;
			if (!false)
			{
				#v0b2 = #v0b;
			}
			#v0b2.#a = #Ng;
			return #JP.Segments.Any(new Func<SegmentData, bool>(#v0b2.#Bbc));
		}

		// Token: 0x02000C15 RID: 3093
		[CompilerGenerated]
		private sealed class #v0b
		{
			// Token: 0x0600649C RID: 25756 RVA: 0x0005169A File Offset: 0x0004F89A
			internal bool #Bbc(SegmentData #Rf)
			{
				return #jsc.#Src(#Rf, this.#a, true);
			}

			// Token: 0x0400293F RID: 10559
			public Point #a;
		}
	}
}
