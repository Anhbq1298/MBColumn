using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #4vc;
using #7hc;
using #Fmc;
using #S9;
using #u3d;
using #UYd;
using #wsb;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.Products.Column.FailureSurface.Model;

namespace StructurePoint.Products.Column.FailureSurface.Core.Helpers
{
	// Token: 0x0200047C RID: 1148
	internal static class CrossSectionGeneratorsHelper
	{
		// Token: 0x06002A84 RID: 10884 RVA: 0x000E34D8 File Offset: 0x000E16D8
		public static IList<PolyLine3D> #Tsb(IList<#3wc> #Usb, FailureSurface #Jkb)
		{
			CrossSectionGeneratorsHelper.#GTb #GTb = new CrossSectionGeneratorsHelper.#GTb();
			#GTb.#a = #Usb;
			#X0d.#V0d(#Jkb, #Phc.#3hc(107358775), Component.GUI, #Phc.#3hc(107358432));
			#X0d.#V0d(#GTb.#a, #Phc.#3hc(107358379), Component.GUI, #Phc.#3hc(107358370));
			List<PolyLine3D> list = new List<PolyLine3D>();
			while (#GTb.#a.Count > 0)
			{
				CrossSectionGeneratorsHelper.#o7b #o7b = new CrossSectionGeneratorsHelper.#o7b();
				List<Point3D> list2 = new List<Point3D>();
				CrossSectionGeneratorsHelper.#o7b #o7b2 = #o7b;
				IEnumerable<#3wc> #a = #GTb.#a;
				Func<#3wc, bool> predicate;
				if ((predicate = #GTb.#b) == null)
				{
					predicate = (#GTb.#b = new Func<#3wc, bool>(#GTb.#l7b));
				}
				#o7b2.#a = #a.FirstOrDefault(predicate);
				if (#o7b.#a != null)
				{
					list2.Add(#o7b.#a.StartPoint);
					IEnumerable<#3wc> #a3;
					Func<#3wc, bool> predicate2;
					for (#3wc #a2 = #GTb.#a.FirstOrDefault(new Func<#3wc, bool>(#o7b.#m7b)); #a2 != null; #a2 = #a3.FirstOrDefault(predicate2))
					{
						#GTb.#a.Remove(#o7b.#a);
						list2.Add(#o7b.#a.EndPoint);
						#o7b.#a = #a2;
						#a3 = #GTb.#a;
						if ((predicate2 = #o7b.#b) == null)
						{
							predicate2 = (#o7b.#b = new Func<#3wc, bool>(#o7b.#n7b));
						}
					}
					#GTb.#a.Remove(#o7b.#a);
					list2.Add(#o7b.#a.EndPoint);
					list.Add(new PolyLine3D(list2));
				}
				else
				{
					#o7b.#a = #GTb.#a.First<#3wc>();
					#GTb.#a.Remove(#o7b.#a);
					list2.Add(#o7b.#a.StartPoint);
					list2.Add(#o7b.#a.EndPoint);
					list.Add(new PolyLine3D(list2));
				}
			}
			return list;
		}

		// Token: 0x06002A85 RID: 10885 RVA: 0x000E36BC File Offset: 0x000E18BC
		public static void #Vsb(#Itb #5d, int #Wsb, bool #Xsb)
		{
			List<Point3D> #3sb = new List<Point3D>();
			List<int> #4sb = new List<int>();
			int num;
			CrossSectionGeneratorsHelper.#7sb(#5d, out num, #4sb, #3sb, #Wsb, #Xsb);
			if (num != 2)
			{
				return;
			}
			List<Point3D> list = new List<Point3D>();
			CrossSectionGeneratorsHelper.#btb(#5d, list, #4sb, #3sb, #Wsb, #Xsb);
			if (list.Count < 3)
			{
				return;
			}
			CrossSectionGeneratorsHelper.#otb(list, #5d.PointsConsistingFailureSurface, #5d.IndexesConsistingFailureSurface);
		}

		// Token: 0x06002A86 RID: 10886 RVA: 0x000E3720 File Offset: 0x000E1920
		public static void #Ysb(#Itb #5d, int #Wsb, bool #Xsb)
		{
			List<Point3D> list = new List<Point3D>();
			List<Point3D> #3sb;
			if (2 != 0)
			{
				#3sb = list;
			}
			List<int> #4sb = new List<int>();
			int num;
			CrossSectionGeneratorsHelper.#gtb(#5d, out num, #3sb, #4sb, #Wsb, #Xsb);
			if (num == 0)
			{
				return;
			}
			List<Point3D> list2 = new List<Point3D>();
			CrossSectionGeneratorsHelper.#ltb(#5d, list2, #3sb, #4sb, #Wsb, #Xsb);
			if (list2.Count < 3)
			{
				return;
			}
			CrossSectionGeneratorsHelper.#otb(list2, #5d.PointsConsistingFailureSurface, #5d.IndexesConsistingFailureSurface);
		}

		// Token: 0x06002A87 RID: 10887 RVA: 0x000E3784 File Offset: 0x000E1984
		private static void #Zsb(#c4d #0sb, #c4d #1sb, #c4d #2sb, List<Point3D> #3sb, List<int> #4sb, ref int #5sb, int #6sb)
		{
			double #43d;
			if (#Loc.#toc(#0sb, #1sb, new #c4d(0.0, 0.0, 1.0), #2sb, out #43d))
			{
				#c4d #c4d = #c4d.#G3d(#0sb, #c4d.#33d(#43d, #1sb));
				Point3D item = new Point3D(#c4d.X, #c4d.Y, #c4d.Z);
				#3sb.Add(item);
				#4sb.Add(#6sb);
				#5sb++;
			}
		}

		// Token: 0x06002A88 RID: 10888 RVA: 0x000E380C File Offset: 0x000E1A0C
		private static void #7sb(#Itb #5d, out int #5sb, List<int> #4sb, List<Point3D> #3sb, int #Wsb, bool #Xsb)
		{
			if (#Xsb)
			{
				#5sb = 0;
				CrossSectionGeneratorsHelper.#Zsb(new #c4d(#5d.PointsConsistingFailureSurface[#Wsb].X, #5d.PointsConsistingFailureSurface[#Wsb].Y, #5d.PointsConsistingFailureSurface[#Wsb].Z), new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + 1 - FailureSurface.RowLength].X - #5d.PointsConsistingFailureSurface[#Wsb].X, #5d.PointsConsistingFailureSurface[#Wsb + 1 - FailureSurface.RowLength].Y - #5d.PointsConsistingFailureSurface[#Wsb].Y, #5d.PointsConsistingFailureSurface[#Wsb + 1 - FailureSurface.RowLength].Z - #5d.PointsConsistingFailureSurface[#Wsb].Z), new #c4d(0.0, 0.0, #5d.CrossSectionHeight), #3sb, #4sb, ref #5sb, 1);
				CrossSectionGeneratorsHelper.#Zsb(new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + 1 - FailureSurface.RowLength].X, #5d.PointsConsistingFailureSurface[#Wsb + 1 - FailureSurface.RowLength].Y, #5d.PointsConsistingFailureSurface[#Wsb + 1 - FailureSurface.RowLength].Z), new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + 1].X - #5d.PointsConsistingFailureSurface[#Wsb + 1 - FailureSurface.RowLength].X, #5d.PointsConsistingFailureSurface[#Wsb + 1].Y - #5d.PointsConsistingFailureSurface[#Wsb + 1 - FailureSurface.RowLength].Y, #5d.PointsConsistingFailureSurface[#Wsb + 1].Z - #5d.PointsConsistingFailureSurface[#Wsb + 1 - FailureSurface.RowLength].Z), new #c4d(0.0, 0.0, #5d.CrossSectionHeight), #3sb, #4sb, ref #5sb, 2);
				CrossSectionGeneratorsHelper.#Zsb(new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + 1].X, #5d.PointsConsistingFailureSurface[#Wsb + 1].Y, #5d.PointsConsistingFailureSurface[#Wsb + 1].Z), new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].X - #5d.PointsConsistingFailureSurface[#Wsb + 1].X, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].Y - #5d.PointsConsistingFailureSurface[#Wsb + 1].Y, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].Z - #5d.PointsConsistingFailureSurface[#Wsb + 1].Z), new #c4d(0.0, 0.0, #5d.CrossSectionHeight), #3sb, #4sb, ref #5sb, 3);
				CrossSectionGeneratorsHelper.#Zsb(new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].X, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].Y, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].Z), new #c4d(#5d.PointsConsistingFailureSurface[#Wsb].X - #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].X, #5d.PointsConsistingFailureSurface[#Wsb].Y - #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].Y, #5d.PointsConsistingFailureSurface[#Wsb].Z - #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].Z), new #c4d(0.0, 0.0, #5d.CrossSectionHeight), #3sb, #4sb, ref #5sb, 4);
				return;
			}
			#5sb = 0;
			CrossSectionGeneratorsHelper.#Zsb(new #c4d(#5d.PointsConsistingFailureSurface[#Wsb].X, #5d.PointsConsistingFailureSurface[#Wsb].Y, #5d.PointsConsistingFailureSurface[#Wsb].Z), new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + 1].X - #5d.PointsConsistingFailureSurface[#Wsb].X, #5d.PointsConsistingFailureSurface[#Wsb + 1].Y - #5d.PointsConsistingFailureSurface[#Wsb].Y, #5d.PointsConsistingFailureSurface[#Wsb + 1].Z - #5d.PointsConsistingFailureSurface[#Wsb].Z), new #c4d(0.0, 0.0, #5d.CrossSectionHeight), #3sb, #4sb, ref #5sb, 1);
			CrossSectionGeneratorsHelper.#Zsb(new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + 1].X, #5d.PointsConsistingFailureSurface[#Wsb + 1].Y, #5d.PointsConsistingFailureSurface[#Wsb + 1].Z), new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength + 1].X - #5d.PointsConsistingFailureSurface[#Wsb + 1].X, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength + 1].Y - #5d.PointsConsistingFailureSurface[#Wsb + 1].Y, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength + 1].Z - #5d.PointsConsistingFailureSurface[#Wsb + 1].Z), new #c4d(0.0, 0.0, #5d.CrossSectionHeight), #3sb, #4sb, ref #5sb, 2);
			CrossSectionGeneratorsHelper.#Zsb(new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength + 1].X, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength + 1].Y, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength + 1].Z), new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].X - #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength + 1].X, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].Y - #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength + 1].Y, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].Z - #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength + 1].Z), new #c4d(0.0, 0.0, #5d.CrossSectionHeight), #3sb, #4sb, ref #5sb, 3);
			CrossSectionGeneratorsHelper.#Zsb(new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].X, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].Y, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].Z), new #c4d(#5d.PointsConsistingFailureSurface[#Wsb].X - #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].X, #5d.PointsConsistingFailureSurface[#Wsb].Y - #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].Y, #5d.PointsConsistingFailureSurface[#Wsb].Z - #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].Z), new #c4d(0.0, 0.0, #5d.CrossSectionHeight), #3sb, #4sb, ref #5sb, 4);
		}

		// Token: 0x06002A89 RID: 10889 RVA: 0x000E40E8 File Offset: 0x000E22E8
		private static void #8sb(#Itb #5d, Point3D #9sb, List<Point3D> #atb)
		{
			if (((#5d.WhichPartToCutHorizontal == #xbb.#a && #9sb.Z <= #5d.CrossSectionHeight) || (#5d.WhichPartToCutHorizontal == #xbb.#b && #9sb.Z >= #5d.CrossSectionHeight)) && !CrossSectionGeneratorsHelper.#mtb(#9sb, #atb))
			{
				#atb.Add(#9sb);
			}
		}

		// Token: 0x06002A8A RID: 10890 RVA: 0x000E4140 File Offset: 0x000E2340
		private static void #btb(#Itb #5d, List<Point3D> #atb, List<int> #4sb, List<Point3D> #3sb, int #Wsb, bool #Xsb)
		{
			if (#Xsb)
			{
				int num = 0;
				CrossSectionGeneratorsHelper.#8sb(#5d, #5d.PointsConsistingFailureSurface[#Wsb], #atb);
				CrossSectionGeneratorsHelper.#itb(ref num, 1, #atb, #3sb, #4sb);
				CrossSectionGeneratorsHelper.#8sb(#5d, #5d.PointsConsistingFailureSurface[#Wsb + 1 - FailureSurface.RowLength], #atb);
				CrossSectionGeneratorsHelper.#itb(ref num, 2, #atb, #3sb, #4sb);
				CrossSectionGeneratorsHelper.#8sb(#5d, #5d.PointsConsistingFailureSurface[#Wsb + 1], #atb);
				CrossSectionGeneratorsHelper.#itb(ref num, 3, #atb, #3sb, #4sb);
				CrossSectionGeneratorsHelper.#8sb(#5d, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength], #atb);
				CrossSectionGeneratorsHelper.#itb(ref num, 4, #atb, #3sb, #4sb);
				return;
			}
			int num2 = 0;
			CrossSectionGeneratorsHelper.#8sb(#5d, #5d.PointsConsistingFailureSurface[#Wsb], #atb);
			CrossSectionGeneratorsHelper.#itb(ref num2, 1, #atb, #3sb, #4sb);
			CrossSectionGeneratorsHelper.#8sb(#5d, #5d.PointsConsistingFailureSurface[#Wsb + 1], #atb);
			CrossSectionGeneratorsHelper.#itb(ref num2, 2, #atb, #3sb, #4sb);
			CrossSectionGeneratorsHelper.#8sb(#5d, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength + 1], #atb);
			CrossSectionGeneratorsHelper.#itb(ref num2, 3, #atb, #3sb, #4sb);
			CrossSectionGeneratorsHelper.#8sb(#5d, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength], #atb);
			CrossSectionGeneratorsHelper.#itb(ref num2, 4, #atb, #3sb, #4sb);
		}

		// Token: 0x06002A8B RID: 10891 RVA: 0x000E4290 File Offset: 0x000E2490
		private static void #ctb(#c4d #0sb, #c4d #1sb, #c4d #dtb, #c4d #etb, List<int> #4sb, List<Point3D> #3sb, ref int #5sb, int #ftb)
		{
			double #43d;
			if (#Loc.#toc(#0sb, #1sb, #dtb, #etb, out #43d))
			{
				#c4d #c4d = #c4d.#G3d(#0sb, #c4d.#33d(#43d, #1sb));
				Point3D point3D = new Point3D(#c4d.X, #c4d.Y, #c4d.Z);
				if (!CrossSectionGeneratorsHelper.#mtb(point3D, #3sb))
				{
					#3sb.Add(point3D);
					#4sb.Add(#ftb);
					#5sb++;
				}
			}
		}

		// Token: 0x06002A8C RID: 10892 RVA: 0x000E4304 File Offset: 0x000E2504
		private static void #gtb(#Itb #5d, out int #5sb, List<Point3D> #3sb, List<int> #4sb, int #Wsb, bool #Xsb)
		{
			#5sb = 0;
			#c4d #0sb = new #c4d(#5d.PointsConsistingFailureSurface[#Wsb].X, #5d.PointsConsistingFailureSurface[#Wsb].Y, #5d.PointsConsistingFailureSurface[#Wsb].Z);
			#c4d #1sb = #Xsb ? new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + 1 - FailureSurface.RowLength].X - #5d.PointsConsistingFailureSurface[#Wsb].X, #5d.PointsConsistingFailureSurface[#Wsb + 1 - FailureSurface.RowLength].Y - #5d.PointsConsistingFailureSurface[#Wsb].Y, #5d.PointsConsistingFailureSurface[#Wsb + 1 - FailureSurface.RowLength].Z - #5d.PointsConsistingFailureSurface[#Wsb].Z) : new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + 1].X - #5d.PointsConsistingFailureSurface[#Wsb].X, #5d.PointsConsistingFailureSurface[#Wsb + 1].Y - #5d.PointsConsistingFailureSurface[#Wsb].Y, #5d.PointsConsistingFailureSurface[#Wsb + 1].Z - #5d.PointsConsistingFailureSurface[#Wsb].Z);
			CrossSectionGeneratorsHelper.#ctb(#0sb, #1sb, #5d.Normal, new #c4d(#5d.CoordinateSystemOrigin.X, #5d.CoordinateSystemOrigin.Y, 0.0), #4sb, #3sb, ref #5sb, 1);
			#0sb = (#Xsb ? new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + 1 - FailureSurface.RowLength].X, #5d.PointsConsistingFailureSurface[#Wsb + 1 - FailureSurface.RowLength].Y, #5d.PointsConsistingFailureSurface[#Wsb + 1 - FailureSurface.RowLength].Z) : new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + 1].X, #5d.PointsConsistingFailureSurface[#Wsb + 1].Y, #5d.PointsConsistingFailureSurface[#Wsb + 1].Z));
			#1sb = (#Xsb ? new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + 1].X - #5d.PointsConsistingFailureSurface[#Wsb + 1 - FailureSurface.RowLength].X, #5d.PointsConsistingFailureSurface[#Wsb + 1].Y - #5d.PointsConsistingFailureSurface[#Wsb + 1 - FailureSurface.RowLength].Y, #5d.PointsConsistingFailureSurface[#Wsb + 1].Z - #5d.PointsConsistingFailureSurface[#Wsb + 1 - FailureSurface.RowLength].Z) : new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength + 1].X - #5d.PointsConsistingFailureSurface[#Wsb + 1].X, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength + 1].Y - #5d.PointsConsistingFailureSurface[#Wsb + 1].Y, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength + 1].Z - #5d.PointsConsistingFailureSurface[#Wsb + 1].Z));
			CrossSectionGeneratorsHelper.#ctb(#0sb, #1sb, #5d.Normal, new #c4d(#5d.CoordinateSystemOrigin.X, #5d.CoordinateSystemOrigin.Y, 0.0), #4sb, #3sb, ref #5sb, 2);
			#0sb = (#Xsb ? new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + 1].X, #5d.PointsConsistingFailureSurface[#Wsb + 1].Y, #5d.PointsConsistingFailureSurface[#Wsb + 1].Z) : new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength + 1].X, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength + 1].Y, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength + 1].Z));
			#1sb = (#Xsb ? new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].X - #5d.PointsConsistingFailureSurface[#Wsb + 1].X, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].Y - #5d.PointsConsistingFailureSurface[#Wsb + 1].Y, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].Z - #5d.PointsConsistingFailureSurface[#Wsb + 1].Z) : new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].X - #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength + 1].X, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].Y - #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength + 1].Y, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].Z - #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength + 1].Z));
			CrossSectionGeneratorsHelper.#ctb(#0sb, #1sb, #5d.Normal, new #c4d(#5d.CoordinateSystemOrigin.X, #5d.CoordinateSystemOrigin.Y, 0.0), #4sb, #3sb, ref #5sb, 3);
			#0sb = new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].X, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].Y, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].Z);
			#1sb = new #c4d(#5d.PointsConsistingFailureSurface[#Wsb].X - #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].X, #5d.PointsConsistingFailureSurface[#Wsb].Y - #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].Y, #5d.PointsConsistingFailureSurface[#Wsb].Z - #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].Z);
			CrossSectionGeneratorsHelper.#ctb(#0sb, #1sb, #5d.Normal, new #c4d(#5d.CoordinateSystemOrigin.X, #5d.CoordinateSystemOrigin.Y, 0.0), #4sb, #3sb, ref #5sb, 4);
		}

		// Token: 0x06002A8D RID: 10893 RVA: 0x000E4A98 File Offset: 0x000E2C98
		private static void #8sb(#Itb #5d, #c4d #htb, Point3D #9sb, List<Point3D> #atb)
		{
			if (((#5d.WhichPartToCutVertical == #ybb.#a && #Loc.#Gnc(#5d.Normal, #htb) <= 0.0) || (#5d.WhichPartToCutVertical == #ybb.#b && #Loc.#Gnc(#5d.Normal, #htb) >= 0.0)) && !CrossSectionGeneratorsHelper.#mtb(#9sb, #atb))
			{
				#atb.Add(#9sb);
			}
		}

		// Token: 0x06002A8E RID: 10894 RVA: 0x000E4B00 File Offset: 0x000E2D00
		private static void #itb(ref int #jtb, int #ktb, List<Point3D> #atb, List<Point3D> #3sb, List<int> #4sb)
		{
			for (int i = 0; i < #4sb.Count; i++)
			{
				if (#4sb[i] == #ktb && !CrossSectionGeneratorsHelper.#mtb(#3sb[i], #atb))
				{
					#atb.Add(#3sb[i]);
					#jtb++;
				}
			}
		}

		// Token: 0x06002A8F RID: 10895 RVA: 0x000E4B58 File Offset: 0x000E2D58
		private static void #ltb(#Itb #5d, List<Point3D> #atb, List<Point3D> #3sb, List<int> #4sb, int #Wsb, bool #Xsb)
		{
			int num = 0;
			#c4d #htb = new #c4d(#5d.PointsConsistingFailureSurface[#Wsb].X - #5d.CoordinateSystemOrigin.X, #5d.PointsConsistingFailureSurface[#Wsb].Y - #5d.CoordinateSystemOrigin.Y, #5d.PointsConsistingFailureSurface[#Wsb].Z);
			Point3D #9sb = #5d.PointsConsistingFailureSurface[#Wsb];
			CrossSectionGeneratorsHelper.#8sb(#5d, #htb, #9sb, #atb);
			CrossSectionGeneratorsHelper.#itb(ref num, 1, #atb, #3sb, #4sb);
			#htb = (#Xsb ? new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + 1 - FailureSurface.RowLength].X - #5d.CoordinateSystemOrigin.X, #5d.PointsConsistingFailureSurface[#Wsb + 1 - FailureSurface.RowLength].Y - #5d.CoordinateSystemOrigin.Y, #5d.PointsConsistingFailureSurface[#Wsb + 1 - FailureSurface.RowLength].Z) : new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + 1].X - #5d.CoordinateSystemOrigin.X, #5d.PointsConsistingFailureSurface[#Wsb + 1].Y - #5d.CoordinateSystemOrigin.Y, #5d.PointsConsistingFailureSurface[#Wsb + 1].Z));
			#9sb = (#Xsb ? #5d.PointsConsistingFailureSurface[#Wsb + 1 - FailureSurface.RowLength] : #5d.PointsConsistingFailureSurface[#Wsb + 1]);
			CrossSectionGeneratorsHelper.#8sb(#5d, #htb, #9sb, #atb);
			CrossSectionGeneratorsHelper.#itb(ref num, 2, #atb, #3sb, #4sb);
			#htb = (#Xsb ? new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + 1].X - #5d.CoordinateSystemOrigin.X, #5d.PointsConsistingFailureSurface[#Wsb + 1].Y - #5d.CoordinateSystemOrigin.Y, #5d.PointsConsistingFailureSurface[#Wsb + 1].Z) : new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength + 1].X - #5d.CoordinateSystemOrigin.X, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength + 1].Y - #5d.CoordinateSystemOrigin.Y, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength + 1].Z));
			#9sb = (#Xsb ? #5d.PointsConsistingFailureSurface[#Wsb + 1] : #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength + 1]);
			CrossSectionGeneratorsHelper.#8sb(#5d, #htb, #9sb, #atb);
			CrossSectionGeneratorsHelper.#itb(ref num, 3, #atb, #3sb, #4sb);
			#htb = new #c4d(#5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].X - #5d.CoordinateSystemOrigin.X, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].Y - #5d.CoordinateSystemOrigin.Y, #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength].Z);
			#9sb = #5d.PointsConsistingFailureSurface[#Wsb + FailureSurface.RowLength];
			CrossSectionGeneratorsHelper.#8sb(#5d, #htb, #9sb, #atb);
			CrossSectionGeneratorsHelper.#itb(ref num, 4, #atb, #3sb, #4sb);
			List<Point3D> list = new List<Point3D>();
			foreach (Point3D item in #atb)
			{
				list.Add(item);
			}
			list.Add(#atb[0]);
			#5d.Wireframe.Add(new PolyLine3D(list));
		}

		// Token: 0x06002A90 RID: 10896 RVA: 0x000E4F84 File Offset: 0x000E3184
		private static bool #mtb(Point3D #9sb, List<Point3D> #7p)
		{
			bool result = false;
			foreach (Point3D #mcb in #7p)
			{
				if (CrossSectionGeneratorsHelper.#ntb(#mcb, #9sb))
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06002A91 RID: 10897 RVA: 0x000E4FE8 File Offset: 0x000E31E8
		private static bool #ntb(Point3D #mcb, Point3D #ncb)
		{
			double num = 0.0001;
			return Math.Abs(#mcb.X - #ncb.X) < num && Math.Abs(#mcb.Y - #ncb.Y) < num && Math.Abs(#mcb.Z - #ncb.Z) < num;
		}

		// Token: 0x06002A92 RID: 10898 RVA: 0x000E5054 File Offset: 0x000E3254
		private static void #otb(List<Point3D> #atb, IList<Point3D> #BP, IList<int> #Dob)
		{
			#atb = CrossSectionGeneratorsHelper.#ptb(#atb);
			if (#atb.Count == 3)
			{
				foreach (Point3D item in #atb)
				{
					#BP.Add(item);
				}
				#Dob.Add(#BP.Count - 3);
				#Dob.Add(#BP.Count - 2);
				#Dob.Add(#BP.Count - 1);
				return;
			}
			if (#atb.Count == 4)
			{
				foreach (Point3D item2 in #atb)
				{
					#BP.Add(item2);
				}
				#Dob.Add(#BP.Count - 4);
				#Dob.Add(#BP.Count - 3);
				#Dob.Add(#BP.Count - 2);
				#Dob.Add(#BP.Count - 4);
				#Dob.Add(#BP.Count - 2);
				#Dob.Add(#BP.Count - 1);
				return;
			}
			if (#atb.Count == 5)
			{
				foreach (Point3D item3 in #atb)
				{
					#BP.Add(item3);
				}
				#Dob.Add(#BP.Count - 5);
				#Dob.Add(#BP.Count - 4);
				#Dob.Add(#BP.Count - 3);
				#Dob.Add(#BP.Count - 5);
				#Dob.Add(#BP.Count - 3);
				#Dob.Add(#BP.Count - 2);
				#Dob.Add(#BP.Count - 5);
				#Dob.Add(#BP.Count - 2);
				#Dob.Add(#BP.Count - 1);
			}
		}

		// Token: 0x06002A93 RID: 10899 RVA: 0x000E5264 File Offset: 0x000E3464
		private static List<Point3D> #ptb(List<Point3D> #atb)
		{
			if (#atb.Count < 3)
			{
				return null;
			}
			Point3D point3D = new Point3D(#atb.Average(new Func<Point3D, double>(CrossSectionGeneratorsHelper.<>c.<>9.#r7b)), #atb.Average(new Func<Point3D, double>(CrossSectionGeneratorsHelper.<>c.<>9.#s7b)), #atb.Average(new Func<Point3D, double>(CrossSectionGeneratorsHelper.<>c.<>9.#t7b)));
			#c4d #Doc = #Loc.#Dnc(new #c4d(#atb[0].X - point3D.X, #atb[0].Y - point3D.Y, #atb[0].Z - point3D.Z), new #c4d(#atb[1].X - point3D.X, #atb[1].Y - point3D.Y, #atb[1].Z - point3D.Z));
			#Doc.#wlc();
			bool flag = false;
			while (!flag)
			{
				flag = true;
				for (int i = 0; i < #atb.Count; i++)
				{
					int num = i;
					int num2 = (i + 1 == #atb.Count) ? 0 : (i + 1);
					if (#Loc.#Gnc(#Doc, #Loc.#Dnc(new #c4d(#atb[num].X - point3D.X, #atb[num].Y - point3D.Y, #atb[num].Z - point3D.Z), new #c4d(#atb[num2].X - point3D.X, #atb[num2].Y - point3D.Y, #atb[num2].Z - point3D.Z))) < 0.0)
					{
						CrossSectionGeneratorsHelper.#qtb<Point3D>(num, num2, #atb);
						flag = false;
					}
				}
			}
			return #atb;
		}

		// Token: 0x06002A94 RID: 10900 RVA: 0x000E54B4 File Offset: 0x000E36B4
		private static void #qtb<#Fu>(int #rtb, int #stb, List<#Fu> #7p)
		{
			#Fu value = #7p[#rtb];
			#7p[#rtb] = #7p[#stb];
			#7p[#stb] = value;
		}

		// Token: 0x0200047E RID: 1150
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06002A9B RID: 10907 RVA: 0x000E54EC File Offset: 0x000E36EC
			internal bool #l7b(#3wc #5Gb)
			{
				CrossSectionGeneratorsHelper.#q7b #q7b = new CrossSectionGeneratorsHelper.#q7b();
				CrossSectionGeneratorsHelper.#q7b #q7b2;
				if (!false)
				{
					#q7b2 = #q7b;
				}
				#q7b2.#a = #5Gb;
				return this.#a.FirstOrDefault(new Func<#3wc, bool>(#q7b2.#p7b)) != null;
			}

			// Token: 0x04001103 RID: 4355
			public IList<#3wc> #a;

			// Token: 0x04001104 RID: 4356
			public Func<#3wc, bool> #b;
		}

		// Token: 0x0200047F RID: 1151
		[CompilerGenerated]
		private sealed class #o7b
		{
			// Token: 0x06002A9D RID: 10909 RVA: 0x00026882 File Offset: 0x00024A82
			internal bool #m7b(#3wc #Rf)
			{
				return Point3D.#E3d(#Rf.StartPoint, this.#a.EndPoint);
			}

			// Token: 0x06002A9E RID: 10910 RVA: 0x00026882 File Offset: 0x00024A82
			internal bool #n7b(#3wc #Rf)
			{
				return Point3D.#E3d(#Rf.StartPoint, this.#a.EndPoint);
			}

			// Token: 0x04001105 RID: 4357
			public #3wc #a;

			// Token: 0x04001106 RID: 4358
			public Func<#3wc, bool> #b;
		}

		// Token: 0x02000480 RID: 1152
		[CompilerGenerated]
		private sealed class #q7b
		{
			// Token: 0x06002AA0 RID: 10912 RVA: 0x000268A6 File Offset: 0x00024AA6
			internal bool #p7b(#3wc #6Gb)
			{
				return Point3D.#E3d(#6Gb.StartPoint, this.#a.EndPoint);
			}

			// Token: 0x04001107 RID: 4359
			public #3wc #a;
		}
	}
}
