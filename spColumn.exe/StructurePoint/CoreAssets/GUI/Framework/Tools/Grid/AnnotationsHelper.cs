using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #Fmc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.Framework.Tools.Grid
{
	// Token: 0x02000B9A RID: 2970
	public static class AnnotationsHelper
	{
		// Token: 0x06006185 RID: 24965 RVA: 0x0017CD60 File Offset: 0x0017AF60
		public static Tuple<Point3D, Point3D> #MJc(GridLineDefinitionModel #bsc, Point #NJc, double #OJc, double #PJc)
		{
			do
			{
				string #R0d = #Phc.#3hc(107364483);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107415498);
				if (7 != 0)
				{
					#X0d.#V0d(#bsc, #R0d, #x6c, #Qic);
				}
			}
			while (false);
			double #Udb = #bsc.Angle;
			Point #Ng;
			Point point3;
			double x;
			do
			{
				bool flag = #Emc.#Dmc(#Udb);
				bool flag2 = #Emc.#Cmc(#bsc.Angle);
				bool flag3;
				if (!false)
				{
					flag3 = flag2;
				}
				Point point = (flag || flag3) ? #bsc.GridLineData.LineSegment.StartPoint : #bsc.GridLineData.LineSegment.EndPoint;
				if (!false)
				{
					#Ng = point;
				}
				Point point2 = GeometryHelper.#Jnc(#NJc, #OJc, -#PJc);
				if (!false)
				{
					point3 = point2;
				}
				x = (#Udb = point3.X);
			}
			while (!true);
			return new Tuple<Point3D, Point3D>(new Point3D(x, point3.Y, 0.0), PointsConverter.#vsc(#Ng));
		}

		// Token: 0x06006186 RID: 24966 RVA: 0x0017CE24 File Offset: 0x0017B024
		public static Point #QJc(GridLineDefinitionModel #bsc, double #OJc, double #PJc, IReadOnlyList<Point3D> #RJc)
		{
			string #R0d = #Phc.#3hc(107364483);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107415477);
			if (!false)
			{
				#X0d.#V0d(#bsc, #R0d, #x6c, #Qic);
			}
			bool flag = #Emc.#Dmc(#bsc.Angle);
			bool flag2 = #Emc.#Cmc(#bsc.Angle);
			bool flag3;
			if (-1 != 0)
			{
				flag3 = flag2;
			}
			int num;
			bool flag4;
			if (!flag)
			{
				flag4 = ((num = ((!flag3) ? 1 : 0)) != 0);
				if (false)
				{
					goto IL_CC;
				}
			}
			else
			{
				flag4 = false;
			}
			bool flag5;
			if (5 != 0)
			{
				flag5 = flag4;
			}
			Point point = flag5 ? #bsc.GridLineData.LineSegment.EndPoint : #bsc.GridLineData.LineSegment.StartPoint;
			Point #Ng;
			if (5 != 0)
			{
				#Ng = point;
			}
			List<Point> list = PointsConverter.#vsc(#RJc);
			List<Point> #RJc2;
			if (!false)
			{
				#RJc2 = list;
			}
			IL_8D:
			double num2 = AnnotationsHelper.#5Jc(#bsc);
			double num3;
			if (!false)
			{
				num3 = num2;
			}
			double num4 = #PJc * 2.0;
			int num5 = 0;
			IL_AA:
			if (7 == 0)
			{
				goto IL_119;
			}
			double num6 = num3;
			IL_AF:
			double num7 = num6 + (double)num5 * num4;
			Point point2 = GeometryHelper.#Jnc(#Ng, #OJc, num7 + #PJc);
			if (false)
			{
				goto IL_8D;
			}
			num = num5 + 1;
			IL_CC:
			num5 = num;
			if (AnnotationsHelper.#6Jc(point2, #RJc2, #PJc - #PJc * 0.05))
			{
				goto IL_AA;
			}
			if (!flag5)
			{
				return point2;
			}
			num5 = 1;
			double num8 = num6 = 0.0;
			if (2 != 0)
			{
				double num9 = num8;
				goto IL_11F;
			}
			goto IL_AF;
			IL_119:
			num5++;
			IL_11F:
			if (!AnnotationsHelper.#8Jc(point2, #PJc, #bsc.GridLineData.EditorWorkspaceSize))
			{
				if (num5 <= 1)
				{
					return point2;
				}
				num5 = 1;
				double num9;
				num7 = num9;
			}
			else if (-1 != 0)
			{
				double num9 = num7 + (double)num5 * num4;
				point2 = GeometryHelper.#Jnc(#Ng, #OJc, num9 + #PJc);
				goto IL_119;
			}
			while (AnnotationsHelper.#6Jc(point2, #RJc2, #PJc - #PJc * 0.05))
			{
				double num9 = num7 + (double)num5 * num4;
				point2 = GeometryHelper.#Jnc(#Ng, #OJc, num9 + #PJc);
				num5++;
			}
			return point2;
		}

		// Token: 0x06006187 RID: 24967 RVA: 0x0017CFD4 File Offset: 0x0017B1D4
		public static double #SJc(GridLineDefinitionModel #bsc)
		{
			string #R0d = #Phc.#3hc(107364483);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107415392);
			if (5 != 0)
			{
				#X0d.#V0d(#bsc, #R0d, #x6c, #Qic);
			}
			bool flag = #Emc.#Dmc(#bsc.Angle);
			bool flag2 = #Emc.#Cmc(#bsc.Angle);
			Point point = (flag || flag2) ? #bsc.GridLineData.LineSegment.StartPoint : #bsc.GridLineData.LineSegment.EndPoint;
			Point #Xqc;
			if (!false)
			{
				#Xqc = point;
			}
			Func<double, double, bool> func;
			if ((func = AnnotationsHelper.#2Ui.#a) == null)
			{
				func = (AnnotationsHelper.#2Ui.#a = new Func<double, double, bool>(#Emc.#Amc));
			}
			BoundingBoxData boundingBoxData = #bsc.GridLineData.EditorWorkspaceSize;
			BoundingBoxData boundingBoxData2;
			if (!false)
			{
				boundingBoxData2 = boundingBoxData;
			}
			double #Udb = AnnotationsHelper.#0Jc(#bsc.GridLineData.LineSegment.StartPoint, #bsc.GridLineData.LineSegment.EndPoint, #Xqc);
			Func<double, double, bool> func2 = func;
			bool #sT = func2(#Xqc.X, boundingBoxData2.MinX);
			bool #3Jc = func2(#Xqc.X, boundingBoxData2.MaxX);
			bool flag3 = func2(#Xqc.Y, boundingBoxData2.MinY);
			bool #JLb;
			if (3 != 0)
			{
				#JLb = flag3;
			}
			bool flag4 = func2(#Xqc.Y, boundingBoxData2.MaxY);
			bool #4Jc;
			if (6 != 0)
			{
				#4Jc = flag4;
			}
			return AnnotationsHelper.#1Jc(flag, flag2, #sT, #3Jc, #JLb, #4Jc, #Udb);
		}

		// Token: 0x06006188 RID: 24968 RVA: 0x0017D120 File Offset: 0x0017B320
		public static double #TJc(double #UJc, double #VJc)
		{
			double num = #UJc;
			double num2 = #VJc;
			double num4;
			double num3;
			double num5;
			do
			{
				num3 = (num = (num4 = num + num2));
				if (7 == 0)
				{
					goto IL_41;
				}
				num5 = (num2 = 2.0);
			}
			while (4 == 0);
			double num6 = Math.Abs(num3 / num5 / 100.0);
			double num7;
			if (7 != 0)
			{
				num7 = num6;
			}
			num4 = ((false || num7 <= 0.0) ? 1.0 : num7);
			IL_41:
			if (!false)
			{
				num7 = num4;
			}
			return 2.55 * num7;
		}

		// Token: 0x06006189 RID: 24969 RVA: 0x0017D184 File Offset: 0x0017B384
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public static List<GridLineDefinitionModel> #WJc(IList<GridLineDefinitionModel> #ooc, IList<GridLineDefinitionModel> #XJc)
		{
			AnnotationsHelper.#ITb #ITb = new AnnotationsHelper.#ITb();
			AnnotationsHelper.#ITb #ITb2;
			if (!false)
			{
				#ITb2 = #ITb;
			}
			#ITb2.#a = #XJc;
			List<GridLineDefinitionModel> list = #ooc.Where(new Func<GridLineDefinitionModel, bool>(#ITb2.#b9c)).Reverse<GridLineDefinitionModel>().ToList<GridLineDefinitionModel>();
			List<GridLineDefinitionModel> source;
			if (5 != 0)
			{
				source = list;
			}
			#ITb2.#b = source.Where(new Func<GridLineDefinitionModel, bool>(AnnotationsHelper.<>c.<>9.#e9c)).ToList<GridLineDefinitionModel>();
			IEnumerable<GridLineDefinitionModel> enumerable = source.Where(new Func<GridLineDefinitionModel, bool>(#ITb2.#d9c));
			IEnumerable<GridLineDefinitionModel> enumerable2;
			if (!false)
			{
				enumerable2 = enumerable;
			}
			#ITb2.#b = #ITb2.#b.OrderBy(new Func<GridLineDefinitionModel, double>(AnnotationsHelper.<>c.<>9.#f9c)).ThenBy(new Func<GridLineDefinitionModel, double>(AnnotationsHelper.<>c.<>9.#g9c)).ToList<GridLineDefinitionModel>();
			IEnumerable<GridLineDefinitionModel> enumerable3 = enumerable2.OrderBy(new Func<GridLineDefinitionModel, double>(AnnotationsHelper.<>c.<>9.#h9c)).ThenBy(new Func<GridLineDefinitionModel, double>(AnnotationsHelper.<>c.<>9.#i9c)).ToList<GridLineDefinitionModel>();
			if (true)
			{
				enumerable2 = enumerable3;
			}
			List<GridLineDefinitionModel> list2 = #ITb2.#b.ToList<GridLineDefinitionModel>();
			IEnumerable<GridLineDefinitionModel> collection = enumerable2;
			if (2 != 0)
			{
				list2.AddRange(collection);
			}
			return list2;
		}

		// Token: 0x0600618A RID: 24970 RVA: 0x0017D2EC File Offset: 0x0017B4EC
		public static BoundingBoxData #YJc(HashSet<IAnnotationDrawingResult> #ZJc, BoundingBoxDataLight #smc, double #PJc)
		{
			string #R0d = #Phc.#3hc(107369578);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107415339);
			if (!false)
			{
				#X0d.#V0d(#smc, #R0d, #x6c, #Qic);
			}
			List<Point3D> source = #ZJc.Select(new Func<IAnnotationDrawingResult, Point3D>(AnnotationsHelper.<>c.<>9.#j9c)).ToList<Point3D>();
			double minX = Math.Min(source.Min(new Func<Point3D, double>(AnnotationsHelper.<>c.<>9.#k9c)) - #PJc, #smc.MinX);
			double maxX = Math.Max(source.Max(new Func<Point3D, double>(AnnotationsHelper.<>c.<>9.#l9c)) + #PJc, #smc.MaxX);
			double num = Math.Min(source.Min(new Func<Point3D, double>(AnnotationsHelper.<>c.<>9.#m9c)) - #PJc, #smc.MinY);
			double minY;
			if (5 != 0)
			{
				minY = num;
			}
			double num2 = Math.Max(source.Max(new Func<Point3D, double>(AnnotationsHelper.<>c.<>9.#n9c)) + #PJc, #smc.MaxY);
			double maxY;
			if (true)
			{
				maxY = num2;
			}
			return new BoundingBoxData(minX, maxX, minY, maxY);
		}

		// Token: 0x0600618B RID: 24971 RVA: 0x0017D430 File Offset: 0x0017B630
		private static double #0Jc(Point #Xrb, Point #Yrb, Point #Xqc)
		{
			Point point2;
			if (2 != 0)
			{
				Point point = (!Point.#E3d(#Xrb, #Xqc) || false) ? #Xrb : #Yrb;
				if (true)
				{
					point2 = point;
				}
			}
			double #8mc = point2.X;
			double result;
			do
			{
				result = (#8mc = GeometryHelper.#knc(#8mc, point2.Y, #Xqc.X, #Xqc.Y));
			}
			while (false);
			return result;
		}

		// Token: 0x0600618C RID: 24972 RVA: 0x0017D47C File Offset: 0x0017B67C
		private static double #1Jc(bool #lKb, bool #2Jc, bool #sT, bool #3Jc, bool #JLb, bool #4Jc, double #Udb)
		{
			if (!#lKb)
			{
				if (false)
				{
					goto IL_40;
				}
				if (!#2Jc)
				{
					double num;
					double result = num = #Udb;
					if (!false)
					{
						return result;
					}
					goto IL_8C;
				}
			}
			if (#sT && #JLb)
			{
				if (#lKb)
				{
					double num2 = -180.0;
					if (3 != 0)
					{
						#Udb = num2;
					}
					return #Udb;
				}
				if (!#2Jc)
				{
					return #Udb;
				}
			}
			else
			{
				if (#sT)
				{
					double num3 = 180.0;
					if (8 != 0)
					{
						#Udb = num3;
					}
					return #Udb;
				}
				if (#JLb)
				{
					double num4 = 270.0;
					if (!false)
					{
						#Udb = num4;
					}
					if (!false)
					{
						return #Udb;
					}
				}
				else if (#4Jc)
				{
					double num;
					double num5 = num = 90.0;
					if (5 != 0)
					{
						if (!false)
						{
							#Udb = num5;
						}
						return #Udb;
					}
					goto IL_8C;
				}
				else
				{
					if (#3Jc)
					{
						double num = 0.0;
						goto IL_8C;
					}
					return #Udb;
				}
			}
			double num6 = 270.0;
			if (!false)
			{
				#Udb = num6;
			}
			IL_40:
			return #Udb;
			IL_8C:
			if (-1 != 0)
			{
				double num;
				#Udb = num;
			}
			return #Udb;
		}

		// Token: 0x0600618D RID: 24973 RVA: 0x0017D53C File Offset: 0x0017B73C
		private static double #5Jc(GridLineDefinitionModel #bsc)
		{
			BoundingBoxData boundingBoxData = #bsc.GridLineData.EditorWorkspaceSize;
			BoundingBoxData boundingBoxData2;
			if (!false)
			{
				boundingBoxData2 = boundingBoxData;
			}
			double num2;
			double num = num2 = boundingBoxData2.Width;
			if (false)
			{
				goto IL_36;
			}
			double num3 = num2 = num + boundingBoxData2.Height;
			if (false)
			{
				goto IL_36;
			}
			double num4 = num3 / 2.0;
			IL_2C:
			num2 = num4 / 100.0;
			IL_36:
			double num5;
			if (true)
			{
				num5 = num2;
			}
			double result = num4 = 3.0 * num5;
			if (!false)
			{
				return result;
			}
			goto IL_2C;
		}

		// Token: 0x0600618E RID: 24974 RVA: 0x0017D598 File Offset: 0x0017B798
		private static bool #6Jc(Point #7Jc, IEnumerable<Point> #RJc, double #PJc)
		{
			if (!false && -1 != 0)
			{
				IEnumerator<Point> enumerator = #RJc.GetEnumerator();
				IEnumerator<Point> enumerator2;
				if (!false)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (enumerator2.MoveNext())
					{
						Point point = enumerator2.Current;
						Point point2;
						if (7 != 0)
						{
							point2 = point;
						}
						if (GeometryHelper.#snc(point2.X, point2.Y, #PJc, #7Jc.X, #7Jc.Y, #PJc))
						{
							bool flag = true;
							bool result;
							if (!false)
							{
								result = flag;
							}
							return result;
						}
					}
				}
				finally
				{
					if (enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x0600618F RID: 24975 RVA: 0x0017D620 File Offset: 0x0017B820
		private static bool #8Jc(Point #9Jc, double #aKc, BoundingBoxData #Prc)
		{
			double? num = #jsc.#lcb(#Prc.RightEdge, #9Jc);
			double? num2;
			if (!false)
			{
				num2 = num;
			}
			double? num3 = #jsc.#lcb(#Prc.TopEdge, #9Jc);
			double? num4;
			if (5 != 0)
			{
				num4 = num3;
			}
			while (num2 != null && num4 != null)
			{
				int num6;
				if (Math.Min(num2.Value, num4.Value) < #aKc)
				{
					if (false)
					{
						continue;
					}
					int num5 = num6 = 1;
					if (num5 != 0)
					{
						return num5 != 0;
					}
				}
				else
				{
					num6 = 0;
				}
				int result;
				int num7 = result = num6;
				if (num7 == 0)
				{
					return num7 != 0;
				}
				return result != 0;
			}
			return true;
		}

		// Token: 0x04002808 RID: 10248
		private const int #a = 3;

		// Token: 0x04002809 RID: 10249
		private const double #b = 0.05;

		// Token: 0x02000B9B RID: 2971
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x0400280A RID: 10250
			public static Func<double, double, bool> #a;
		}

		// Token: 0x02000B9D RID: 2973
		[CompilerGenerated]
		private sealed class #ITb
		{
			// Token: 0x0600619D RID: 24989 RVA: 0x0004FEC1 File Offset: 0x0004E0C1
			internal bool #b9c(GridLineDefinitionModel #c9c)
			{
				int result;
				if ((5 == 0 || string.IsNullOrWhiteSpace(#c9c.Label)) && 5 != 0)
				{
					result = 0;
				}
				else
				{
					bool flag = (result = (this.#a.Contains(#c9c) ? 1 : 0)) != 0;
					if (!false)
					{
						return !flag;
					}
				}
				return result != 0;
			}

			// Token: 0x0600619E RID: 24990 RVA: 0x0004FEEA File Offset: 0x0004E0EA
			internal bool #d9c(GridLineDefinitionModel #c9c)
			{
				return !this.#b.Contains(#c9c);
			}

			// Token: 0x04002816 RID: 10262
			public IList<GridLineDefinitionModel> #a;

			// Token: 0x04002817 RID: 10263
			public List<GridLineDefinitionModel> #b;
		}
	}
}
