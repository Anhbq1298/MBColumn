using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #cYd;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.Geometry.Helpers
{
	// Token: 0x020007E4 RID: 2020
	public static class PolygonOperationsHelper
	{
		// Token: 0x060040EB RID: 16619 RVA: 0x0012FFF8 File Offset: 0x0012E1F8
		public static void #Esc(PolygonData #JP, SegmentData #PP, IList<Point> #BP)
		{
			PolygonOperationsHelper.#GTb #GTb = new PolygonOperationsHelper.#GTb();
			PolygonOperationsHelper.#GTb #GTb2;
			if (3 != 0)
			{
				#GTb2 = #GTb;
			}
			#GTb2.#a = #PP;
			#X0d.#V0d(#JP, #Phc.#3hc(107399958), Component.Geometry, #Phc.#3hc(107461319));
			#X0d.#V0d(#GTb2.#a, #Phc.#3hc(107368915), Component.Geometry, #Phc.#3hc(107461298));
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.Geometry, #Phc.#3hc(107461245));
			if (#BP.Count <= 0)
			{
				return;
			}
			#GTb2.#d = #JP.Segments.IndexOf(#GTb2.#a);
			if (#GTb2.#d < 0)
			{
				#GTb2.#a = #JP.Segments.FirstOrDefault(new Func<SegmentData, bool>(#GTb2.#cyc));
				#GTb2.#d = #JP.Segments.IndexOf(#GTb2.#a);
				if (#GTb2.#d < 0)
				{
					throw new #jYd(#Phc.#3hc(107368915), #Phc.#3hc(107461160), Component.Geometry);
				}
			}
			#GTb2.#c = #JP.Points2D.ToList<Point>();
			#GTb2.#b = #GTb2.#c[#GTb2.#d];
			#BP.Select(new Func<Point, <>f__AnonymousType0<double, Point>>(#GTb2.#dyc)).OrderBy(new Func<<>f__AnonymousType0<double, Point>, double>(PolygonOperationsHelper.<>c.<>9.#fyc)).ToList().ForEach(new Action<<>f__AnonymousType0<double, Point>>(#GTb2.#eyc));
			#JP.#dwc(#GTb2.#c);
		}

		// Token: 0x020007E6 RID: 2022
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x060040F0 RID: 16624 RVA: 0x001301C8 File Offset: 0x0012E3C8
			internal bool #cyc(SegmentData #Rf)
			{
				bool flag;
				int num = (flag = Point.#E3d(#Rf.StartPoint, this.#a.StartPoint)) ? 1 : 0;
				bool result;
				bool flag2;
				for (;;)
				{
					if (!false)
					{
						if (flag)
						{
							break;
						}
						num = 0;
					}
					flag2 = (result = (num != 0));
					if (flag2)
					{
						return result;
					}
					num = (flag2 ? 1 : 0);
					flag = flag2;
					if (!flag2)
					{
						goto Block_4;
					}
				}
				result = Point.#E3d(#Rf.EndPoint, this.#a.EndPoint);
				return result;
				Block_4:
				result = flag2;
				if (!flag2)
				{
					return flag2;
				}
				return result;
			}

			// Token: 0x060040F1 RID: 16625 RVA: 0x000369BF File Offset: 0x00034BBF
			internal <>f__AnonymousType0<double, Point> #dyc(Point #Rf)
			{
				return new
				{
					Distance = GeometryHelper.#lcb(#Rf, this.#b),
					Point = #Rf
				};
			}

			// Token: 0x060040F2 RID: 16626 RVA: 0x00130238 File Offset: 0x0012E438
			internal void #eyc(<>f__AnonymousType0<double, Point> #Rf)
			{
				List<Point> list = this.#c;
				int index = this.#d + 1;
				this.#d = index;
				list.Insert(index, #Rf.Point);
			}

			// Token: 0x04001D3A RID: 7482
			public SegmentData #a;

			// Token: 0x04001D3B RID: 7483
			public Point #b;

			// Token: 0x04001D3C RID: 7484
			public List<Point> #c;

			// Token: 0x04001D3D RID: 7485
			public int #d;
		}
	}
}
