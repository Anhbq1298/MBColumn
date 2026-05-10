using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #4vc;
using #7hc;
using #Fmc;
using #S9;
using #u3d;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.Products.Column.FailureSurface.Core.Helpers;
using StructurePoint.Products.Column.FailureSurface.Model;

namespace #wsb
{
	// Token: 0x02000482 RID: 1154
	internal static class #Ztb
	{
		// Token: 0x06002AB4 RID: 10932 RVA: 0x000269CF File Offset: 0x00024BCF
		public static IList<Point3D> #Jtb(FailureSurface #Jkb)
		{
			#X0d.#V0d(#Jkb, #Phc.#3hc(107358775), Component.GUI, #Phc.#3hc(107358317));
			return new List<Point3D>(#Jkb.NominalPositions);
		}

		// Token: 0x06002AB5 RID: 10933 RVA: 0x00026A03 File Offset: 0x00024C03
		public static IList<Point3D> #Ktb(FailureSurface #Jkb)
		{
			#X0d.#V0d(#Jkb, #Phc.#3hc(107358775), Component.GUI, #Phc.#3hc(107358317));
			return new List<Point3D>(#Jkb.NominalTransformedPositions);
		}

		// Token: 0x06002AB6 RID: 10934 RVA: 0x00026A37 File Offset: 0x00024C37
		public static IList<Point3D> #Ltb(FailureSurface #Jkb)
		{
			#X0d.#V0d(#Jkb, #Phc.#3hc(107358775), Component.GUI, #Phc.#3hc(107358296));
			return new List<Point3D>(#Jkb.FactoredPositions);
		}

		// Token: 0x06002AB7 RID: 10935 RVA: 0x00026A6B File Offset: 0x00024C6B
		public static IList<Point3D> #Mtb(FailureSurface #Jkb)
		{
			#X0d.#V0d(#Jkb, #Phc.#3hc(107358775), Component.GUI, #Phc.#3hc(107358296));
			return new List<Point3D>(#Jkb.FactoredTransformedPositions);
		}

		// Token: 0x06002AB8 RID: 10936 RVA: 0x000E5530 File Offset: 0x000E3730
		public static IList<int> #Ntb(FailureSurface #Jkb, #xbb #Qkb, double #Lkb, IList<Point3D> #BP)
		{
			#Ztb.#xTb #xTb = new #Ztb.#xTb();
			#xTb.#a = #Lkb;
			#X0d.#V0d(#Jkb, #Phc.#3hc(107358775), Component.GUI, #Phc.#3hc(107358211));
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.GUI, #Phc.#3hc(107358661));
			List<int> list = new List<int>();
			int #Xtb = #BP.Count - FailureSurface.RowLength - 1;
			if (!#BP.Any(new Func<Point3D, bool>(#xTb.#u7b)))
			{
				return #Ztb.#Vtb(#Jkb, #Qkb, #xTb.#a, #BP);
			}
			if (#Qkb == #xbb.#a)
			{
				return #Ztb.#Ytb(#Jkb, #Qkb, #xTb.#a, #BP, #Xtb, list);
			}
			#Ztb.#Wtb(#Jkb, #Qkb, #xTb.#a, #BP, #Xtb, list);
			return list;
		}

		// Token: 0x06002AB9 RID: 10937 RVA: 0x000E5600 File Offset: 0x000E3800
		public static IMeshDrawingResult #Otb(FailureSurface #Jkb, IList<Point3D> #BP, IList<int> #Ptb, Color #BR)
		{
			#X0d.#V0d(#Jkb, #Phc.#3hc(107358775), Component.GUI, #Phc.#3hc(107358640));
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.GUI, #Phc.#3hc(107358587));
			#X0d.#V0d(#Ptb, #Phc.#3hc(107358502), Component.GUI, #Phc.#3hc(107358521));
			if (#Ptb.Count == 0)
			{
				return null;
			}
			IMeshDrawingResult meshDrawingResult = #Jkb.DrawingResultsFactory.CreateMeshDrawingResult();
			meshDrawingResult.SetContent(#BP, #Ptb);
			meshDrawingResult.SetColor(#BR, null);
			meshDrawingResult.Freeze();
			return meshDrawingResult;
		}

		// Token: 0x06002ABA RID: 10938 RVA: 0x000E56B4 File Offset: 0x000E38B4
		public static IList<PolyLine3D> #Qtb(FailureSurface #Jkb, #xbb #Qkb, double #Lkb, IList<Point3D> #BP)
		{
			#X0d.#V0d(#Jkb, #Phc.#3hc(107358775), Component.GUI, #Phc.#3hc(107357924));
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.GUI, #Phc.#3hc(107357871));
			List<#3wc> list = new List<#3wc>();
			for (int i = 0; i < #Jkb.RowCount; i++)
			{
				for (int j = 0; j < FailureSurface.RowLength; j++)
				{
					int num = i * FailureSurface.RowLength + j;
					int num2 = (j < FailureSurface.RowLength - 1) ? (num + 1) : (i * FailureSurface.RowLength);
					if (num2 <= #Jkb.VertexCount - 1)
					{
						if ((#Qkb == #xbb.#a && #BP[num].Z <= #Lkb && #BP[num2].Z <= #Lkb) || (#Qkb == #xbb.#b && #BP[num].Z >= #Lkb && #BP[num2].Z >= #Lkb))
						{
							list.Add(new #3wc(#BP[num], #BP[num2]));
						}
						else if ((#Qkb == #xbb.#a && #BP[num].Z > #Lkb && #BP[num2].Z <= #Lkb) || (#Qkb == #xbb.#b && #BP[num].Z < #Lkb && #BP[num2].Z >= #Lkb))
						{
							double #43d;
							#Loc.#toc(new #c4d(#BP[num].X, #BP[num].Y, #BP[num].Z), new #c4d(#BP[num2].X - #BP[num].X, #BP[num2].Y - #BP[num].Y, #BP[num2].Z - #BP[num].Z), new #c4d(0.0, 0.0, 1.0), new #c4d(0.0, 0.0, #Lkb), out #43d);
							#c4d #4Bb = new #c4d(#BP[num2].X - #BP[num].X, #BP[num2].Y - #BP[num].Y, #BP[num2].Z - #BP[num].Z);
							Point3D #Xrb = Point3D.#G3d(#BP[num], #c4d.#33d(#43d, #4Bb));
							list.Add(new #3wc(#Xrb, #BP[num2]));
						}
						else if ((#Qkb == #xbb.#a && #BP[num].Z <= #Lkb && #BP[num2].Z > #Lkb) || (#Qkb == #xbb.#b && #BP[num].Z >= #Lkb && #BP[num2].Z < #Lkb))
						{
							double #43d2;
							#Loc.#toc(new #c4d(#BP[num].X, #BP[num].Y, #BP[num].Z), new #c4d(#BP[num2].X - #BP[num].X, #BP[num2].Y - #BP[num].Y, #BP[num2].Z - #BP[num].Z), new #c4d(0.0, 0.0, 1.0), new #c4d(0.0, 0.0, #Lkb), out #43d2);
							#c4d #4Bb2 = new #c4d(#BP[num2].X - #BP[num].X, #BP[num2].Y - #BP[num].Y, #BP[num2].Z - #BP[num].Z);
							Point3D #Yrb = Point3D.#G3d(#BP[num], #c4d.#33d(#43d2, #4Bb2));
							list.Add(new #3wc(#BP[num], #Yrb));
						}
					}
				}
			}
			return CrossSectionGeneratorsHelper.#Tsb(list, #Jkb);
		}

		// Token: 0x06002ABB RID: 10939 RVA: 0x000E5BC8 File Offset: 0x000E3DC8
		public static IList<PolyLine3D> #Rtb(FailureSurface #Jkb, #xbb #Qkb, double #Lkb, IList<Point3D> #BP)
		{
			#X0d.#V0d(#Jkb, #Phc.#3hc(107358775), Component.GUI, #Phc.#3hc(107357850));
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.GUI, #Phc.#3hc(107357765));
			List<#3wc> list = new List<#3wc>();
			List<Point3D> list2 = new List<Point3D>();
			for (int i = 0; i < FailureSurface.RowLength; i++)
			{
				for (int j = 0; j < #Jkb.RowCount - 1; j++)
				{
					int num = i + j * FailureSurface.RowLength;
					int num2 = num + FailureSurface.RowLength;
					if (num2 <= #Jkb.VertexCount - 1)
					{
						if ((#Qkb == #xbb.#a && #BP[num].Z <= #Lkb && #BP[num2].Z <= #Lkb) || (#Qkb == #xbb.#b && #BP[num].Z >= #Lkb && #BP[num2].Z >= #Lkb))
						{
							list.Add(new #3wc(#BP[num], #BP[num2]));
						}
						else if ((#Qkb == #xbb.#a && #BP[num].Z > #Lkb && #BP[num2].Z <= #Lkb) || (#Qkb == #xbb.#b && #BP[num].Z < #Lkb && #BP[num2].Z >= #Lkb))
						{
							double #43d;
							#Loc.#toc(new #c4d(#BP[num].X, #BP[num].Y, #BP[num].Z), new #c4d(#BP[num2].X - #BP[num].X, #BP[num2].Y - #BP[num].Y, #BP[num2].Z - #BP[num].Z), new #c4d(0.0, 0.0, 1.0), new #c4d(0.0, 0.0, #Lkb), out #43d);
							#c4d #4Bb = new #c4d(#BP[num2].X - #BP[num].X, #BP[num2].Y - #BP[num].Y, #BP[num2].Z - #BP[num].Z);
							Point3D point3D = Point3D.#G3d(#BP[num], #c4d.#33d(#43d, #4Bb));
							list2.Add(point3D);
							list.Add(new #3wc(point3D, #BP[num2]));
						}
						else if ((#Qkb == #xbb.#a && #BP[num].Z <= #Lkb && #BP[num2].Z > #Lkb) || (#Qkb == #xbb.#b && #BP[num].Z >= #Lkb && #BP[num2].Z < #Lkb))
						{
							double #43d2;
							#Loc.#toc(new #c4d(#BP[num].X, #BP[num].Y, #BP[num].Z), new #c4d(#BP[num2].X - #BP[num].X, #BP[num2].Y - #BP[num].Y, #BP[num2].Z - #BP[num].Z), new #c4d(0.0, 0.0, 1.0), new #c4d(0.0, 0.0, #Lkb), out #43d2);
							#c4d #4Bb2 = new #c4d(#BP[num2].X - #BP[num].X, #BP[num2].Y - #BP[num].Y, #BP[num2].Z - #BP[num].Z);
							Point3D point3D2 = Point3D.#G3d(#BP[num], #c4d.#33d(#43d2, #4Bb2));
							list2.Add(point3D2);
							list.Add(new #3wc(#BP[num], point3D2));
						}
					}
				}
			}
			if (list2.Count > 0)
			{
				for (int k = 0; k < list2.Count - 1; k++)
				{
					list.Add(new #3wc(list2[k], list2[k + 1]));
				}
				list.Add(new #3wc(list2[list2.Count - 1], list2[0]));
			}
			return CrossSectionGeneratorsHelper.#Tsb(list, #Jkb);
		}

		// Token: 0x06002ABC RID: 10940 RVA: 0x000E6148 File Offset: 0x000E4348
		private static void #Stb(List<int> #Dob, int #Ttb, bool #Xsb, int #Utb)
		{
			#Dob.Add(#Ttb);
			#Dob.Add(#Xsb ? (#Ttb + 1 - #Utb) : (1 + #Ttb));
			#Dob.Add(#Utb + #Ttb);
			if (#Xsb)
			{
				#Dob.Add(#Ttb + 1 - #Utb);
				#Dob.Add(1 + #Ttb);
				#Dob.Add(#Utb + #Ttb);
				return;
			}
			#Dob.Add(1 + #Ttb);
			#Dob.Add(#Utb + 1 + #Ttb);
			#Dob.Add(#Utb + #Ttb);
		}

		// Token: 0x06002ABD RID: 10941 RVA: 0x000E61C4 File Offset: 0x000E43C4
		private static IList<int> #Vtb(FailureSurface #Jkb, #xbb #Qkb, double #Lkb, IList<Point3D> #BP)
		{
			#X0d.#V0d(#Jkb, #Phc.#3hc(107358775), Component.GUI, #Phc.#3hc(107358211));
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.GUI, #Phc.#3hc(107358661));
			List<int> list = new List<int>();
			int num = #BP.Count - FailureSurface.RowLength;
			#Itb #5d = new #Itb
			{
				FailureSurface = #Jkb,
				WhichPartToCutHorizontal = #Qkb,
				CrossSectionHeight = #Lkb,
				PointsConsistingFailureSurface = #BP,
				IndexesConsistingFailureSurface = list
			};
			for (int i = 0; i < num; i++)
			{
				bool flag = (i + 1) % FailureSurface.RowLength == 0;
				if (flag)
				{
					if ((#Qkb == #xbb.#a && #BP[i].Z <= #Lkb && #BP[i + 1 - FailureSurface.RowLength].Z <= #Lkb && #BP[i + FailureSurface.RowLength].Z <= #Lkb && #BP[i + 1].Z <= #Lkb) || (#Qkb == #xbb.#b && #BP[i].Z >= #Lkb && #BP[i + 1 - FailureSurface.RowLength].Z >= #Lkb && #BP[i + FailureSurface.RowLength].Z >= #Lkb && #BP[i + 1].Z >= #Lkb))
					{
						#Ztb.#Stb(list, i, flag, FailureSurface.RowLength);
					}
					else
					{
						CrossSectionGeneratorsHelper.#Vsb(#5d, i, flag);
					}
				}
				else if ((#Qkb == #xbb.#a && #BP[i].Z <= #Lkb && #BP[i + 1].Z <= #Lkb && #BP[i + FailureSurface.RowLength].Z <= #Lkb && #BP[i + FailureSurface.RowLength + 1].Z <= #Lkb) || (#Qkb == #xbb.#b && #BP[i].Z >= #Lkb && #BP[i + 1].Z >= #Lkb && #BP[i + FailureSurface.RowLength].Z >= #Lkb && #BP[i + FailureSurface.RowLength + 1].Z >= #Lkb))
				{
					#Ztb.#Stb(list, i, flag, FailureSurface.RowLength);
				}
				else
				{
					CrossSectionGeneratorsHelper.#Vsb(#5d, i, flag);
				}
			}
			return list;
		}

		// Token: 0x06002ABE RID: 10942 RVA: 0x000E6444 File Offset: 0x000E4644
		private static void #Wtb(FailureSurface #Jkb, #xbb #Qkb, double #Lkb, IList<Point3D> #BP, int #Xtb, List<int> #Ptb)
		{
			for (int i = 0; i < #Xtb; i++)
			{
				bool flag = (i + 1) % FailureSurface.RowLength == 0;
				bool flag2 = !flag && #BP[i].Z >= #Lkb && #BP[i + 1].Z >= #Lkb && #BP[i + FailureSurface.RowLength].Z >= #Lkb && #BP[i + FailureSurface.RowLength + 1].Z >= #Lkb;
				bool flag3 = flag && #BP[i].Z >= #Lkb && #BP[i + 1 - FailureSurface.RowLength].Z >= #Lkb && #BP[i + 1].Z >= #Lkb && #BP[i + FailureSurface.RowLength].Z >= #Lkb;
				if (flag3 || flag2)
				{
					#Ztb.#Stb(#Ptb, i, flag, FailureSurface.RowLength);
				}
				else
				{
					#Itb #5d = new #Itb
					{
						FailureSurface = #Jkb,
						WhichPartToCutHorizontal = #Qkb,
						CrossSectionHeight = #Lkb,
						PointsConsistingFailureSurface = #BP,
						IndexesConsistingFailureSurface = #Ptb
					};
					CrossSectionGeneratorsHelper.#Vsb(#5d, i, flag);
				}
			}
		}

		// Token: 0x06002ABF RID: 10943 RVA: 0x000E65A4 File Offset: 0x000E47A4
		private static IList<int> #Ytb(FailureSurface #Jkb, #xbb #Qkb, double #Lkb, IList<Point3D> #BP, int #Xtb, List<int> #Ptb)
		{
			for (int i = 0; i < #Xtb + 1; i++)
			{
				bool flag = (i + 1) % FailureSurface.RowLength == 0;
				bool flag2 = !flag && #BP[i].Z <= #Lkb && #BP[i + 1].Z <= #Lkb && #BP[i + FailureSurface.RowLength].Z <= #Lkb && #BP[i + FailureSurface.RowLength + 1].Z <= #Lkb;
				bool flag3 = flag && #BP[i].Z <= #Lkb && #BP[i + 1 - FailureSurface.RowLength].Z <= #Lkb && #BP[i + 1].Z <= #Lkb && #BP[i + FailureSurface.RowLength].Z <= #Lkb;
				if (flag3 || flag2)
				{
					#Ztb.#Stb(#Ptb, i, flag, FailureSurface.RowLength);
				}
				else
				{
					#Itb #5d = new #Itb
					{
						FailureSurface = #Jkb,
						WhichPartToCutHorizontal = #Qkb,
						CrossSectionHeight = #Lkb,
						PointsConsistingFailureSurface = #BP,
						IndexesConsistingFailureSurface = #Ptb
					};
					CrossSectionGeneratorsHelper.#Vsb(#5d, i, flag);
				}
			}
			return #Ptb;
		}

		// Token: 0x02000483 RID: 1155
		[CompilerGenerated]
		private sealed class #xTb
		{
			// Token: 0x06002AC1 RID: 10945 RVA: 0x00026A9F File Offset: 0x00024C9F
			internal bool #u7b(Point3D #Rf)
			{
				return #Rf.Z == this.#a;
			}

			// Token: 0x04001111 RID: 4369
			public double #a;
		}
	}
}
