using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using #o1d;
using #pXd;
using NetTopologySuite.Geometries;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.AppManager.Column.Helpers
{
	// Token: 0x02001292 RID: 4754
	public sealed class ShapesMergeHelper
	{
		// Token: 0x06009F4B RID: 40779 RVA: 0x0007D2DC File Offset: 0x0007B4DC
		public ShapesMergeHelper(IList<SectionPolygon> polygons, Action<string> feedbackProvider = null)
		{
			this.#a = polygons;
			this.#b = feedbackProvider;
		}

		// Token: 0x06009F4C RID: 40780 RVA: 0x0021CE68 File Offset: 0x0021B068
		public bool #2Le(out List<SectionPolygon> #kmc)
		{
			this.#FAb();
			#kmc = new List<SectionPolygon>();
			IList<SectionPolygon> list = null;
			List<SectionPolygon> #DAb = new List<SectionPolygon>();
			List<Geometry> list2;
			List<Geometry> list3;
			try
			{
				list2 = GeometryConverter.#Uxb(this.#c);
				list3 = GeometryConverter.#Uxb(this.#d);
				if (!this.#zAb(list2.Union(list3).ToList<Geometry>(), list2, list3, #DAb))
				{
					return false;
				}
				if (list2.Any<Geometry>())
				{
					Geometry geometry = ColumnGeometryHelper.#Tlc(list2);
					if (list3.Any<Geometry>())
					{
						geometry = ColumnGeometryHelper.#5lc(new #OXd(CancellationToken.None), list3, geometry);
					}
					if (geometry != null)
					{
						geometry = GeometrySimplifier.#aLe(geometry);
						list = GeometryConverter.#Wxb(geometry);
					}
				}
				else if (list3.Any<Geometry>())
				{
					IList<SectionPolygon> list4 = GeometryConverter.#Wxb(GeometrySimplifier.#aLe(ColumnGeometryHelper.#Tlc(list3)));
					if (!list4.All(new Func<SectionPolygon, bool>(ShapesMergeHelper.<>c.<>9.#Igf)))
					{
						return false;
					}
					list = list4;
					list.#I1d(new Action<SectionPolygon>(ShapesMergeHelper.<>c.<>9.#Jgf));
				}
			}
			catch (Exception)
			{
				return false;
			}
			if (list == null)
			{
				return false;
			}
			this.#a.#F7c(list2.Union(list3).Select(new Func<Geometry, SectionPolygon>(ShapesMergeHelper.<>c.<>9.#Kgf)).Where(new Func<SectionPolygon, bool>(ShapesMergeHelper.<>c.<>9.#Lgf)));
			this.#a.#pR(new ICollection<SectionPolygon>[]
			{
				list
			});
			#kmc = this.#a.ToList<SectionPolygon>();
			ColumnStorageModel.ReAssignShapeId(this.#a);
			return true;
		}

		// Token: 0x06009F4D RID: 40781 RVA: 0x0021D02C File Offset: 0x0021B22C
		private void #FAb()
		{
			this.#c = this.#a.Where(new Func<SectionPolygon, bool>(ShapesMergeHelper.<>c.<>9.#Mgf)).ToList<SectionPolygon>();
			this.#d = this.#a.Where(new Func<SectionPolygon, bool>(ShapesMergeHelper.<>c.<>9.#Ngf)).ToList<SectionPolygon>();
		}

		// Token: 0x06009F4E RID: 40782 RVA: 0x0021D0A4 File Offset: 0x0021B2A4
		private bool #zAb(IList<Geometry> #AAb, IList<Geometry> #BAb, IList<Geometry> #CAb, List<SectionPolygon> #DAb)
		{
			HashSet<Geometry> hashSet = new HashSet<Geometry>();
			for (int i = 0; i < #AAb.Count; i++)
			{
				Geometry geometry = #AAb[i];
				Geometry geometry2 = geometry;
				bool? flag = null;
				for (int j = i + 1; j < #AAb.Count; j++)
				{
					Geometry geometry3 = #AAb[j];
					Geometry geometry4 = geometry3;
					flag = new bool?(flag.GetValueOrDefault());
					ColumnGeometryHelper.#DKe(ref geometry, ref geometry3);
					#AAb.#27c(geometry2, geometry, false);
					#AAb.#27c(geometry4, geometry3, true);
					#BAb.#27c(geometry2, geometry, false);
					#BAb.#27c(geometry4, geometry3, true);
					#CAb.#27c(geometry2, geometry, false);
					#CAb.#27c(geometry4, geometry3, true);
					if (geometry.Intersects(geometry3) || geometry.Touches(geometry3) || geometry.Distance(geometry3) <= ColumnGeometryHelper.#b)
					{
						hashSet.Remove(geometry2);
						hashSet.Remove(geometry4);
						hashSet.Add(geometry);
						hashSet.Add(geometry3);
					}
					geometry2 = geometry;
				}
			}
			List<Geometry> list = #BAb.Intersect(hashSet).ToList<Geometry>();
			List<Geometry> list2 = #CAb.Intersect(hashSet).ToList<Geometry>();
			#BAb.Clear();
			#BAb.#pR(new ICollection<Geometry>[]
			{
				list
			});
			#CAb.Clear();
			#CAb.#pR(new ICollection<Geometry>[]
			{
				list2
			});
			#DAb.AddRange(#AAb.Except(list2).Except(list).Select(new Func<Geometry, SectionPolygon>(ShapesMergeHelper.<>c.<>9.#Ogf)).Where(new Func<SectionPolygon, bool>(ShapesMergeHelper.<>c.<>9.#Pgf)));
			return hashSet.Any<Geometry>();
		}

		// Token: 0x0400457D RID: 17789
		private readonly IList<SectionPolygon> #a;

		// Token: 0x0400457E RID: 17790
		private readonly Action<string> #b;

		// Token: 0x0400457F RID: 17791
		private List<SectionPolygon> #c;

		// Token: 0x04004580 RID: 17792
		private List<SectionPolygon> #d;
	}
}
