using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using #4vc;
using #7hc;
using #Fmc;
using #S9;
using #u3d;
using #UYd;
using #wsb;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.Products.Column.FailureSurface.Model;

namespace StructurePoint.Products.Column.FailureSurface.Core.Helpers
{
	// Token: 0x02000484 RID: 1156
	internal static class VerticalFailureSurfaceCrossSectionGenerator
	{
		// Token: 0x06002AC2 RID: 10946 RVA: 0x00026AB8 File Offset: 0x00024CB8
		public static IList<Point3D> #Jtb(FailureSurface #Jkb)
		{
			#X0d.#V0d(#Jkb, #Phc.#3hc(107358775), Component.GUI, #Phc.#3hc(107357744));
			return new List<Point3D>(#Jkb.NominalPositions);
		}

		// Token: 0x06002AC3 RID: 10947 RVA: 0x00026AEC File Offset: 0x00024CEC
		public static IList<Point3D> #Ktb(FailureSurface #Jkb)
		{
			#X0d.#V0d(#Jkb, #Phc.#3hc(107358775), Component.GUI, #Phc.#3hc(107357744));
			return new List<Point3D>(#Jkb.NominalTransformedPositions);
		}

		// Token: 0x06002AC4 RID: 10948 RVA: 0x00026B20 File Offset: 0x00024D20
		public static IList<Point3D> #Ltb(FailureSurface #Jkb)
		{
			#X0d.#V0d(#Jkb, #Phc.#3hc(107358775), Component.GUI, #Phc.#3hc(107358203));
			return new List<Point3D>(#Jkb.FactoredPositions);
		}

		// Token: 0x06002AC5 RID: 10949 RVA: 0x000E6708 File Offset: 0x000E4908
		public static IList<Point3D> #Mtb(FailureSurface #Jkb, List<Point3D> #0tb)
		{
			#X0d.#V0d(#Jkb, #Phc.#3hc(107358775), Component.GUI, #Phc.#3hc(107358203));
			for (int i = 0; i < #Jkb.VertexCount; i += FailureSurface.RowLength)
			{
				List<Point3D> list = new List<Point3D>();
				for (int j = 0; j < FailureSurface.RowLength; j++)
				{
					list.Add(#Jkb.FactoredTransformedPositions[i + j]);
				}
				#0tb.Add(new Point3D(list.Average(new Func<Point3D, double>(VerticalFailureSurfaceCrossSectionGenerator.<>c.<>9.#v7b)), list.Average(new Func<Point3D, double>(VerticalFailureSurfaceCrossSectionGenerator.<>c.<>9.#w7b)), list.Average(new Func<Point3D, double>(VerticalFailureSurfaceCrossSectionGenerator.<>c.<>9.#x7b))));
			}
			return new List<Point3D>(#Jkb.FactoredTransformedPositions);
		}

		// Token: 0x06002AC6 RID: 10950 RVA: 0x000E6818 File Offset: 0x000E4A18
		public static IList<int> #Ntb(FailureSurface #Jkb, #ybb #Qkb, #c4d #dtb, IList<Point3D> #BP, Point3D #Clb, List<PolyLine3D> #Glb)
		{
			#X0d.#V0d(#Jkb, #Phc.#3hc(107358775), Component.GUI, #Phc.#3hc(107358118));
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.GUI, #Phc.#3hc(107358097));
			List<int> list = new List<int>();
			int num = #BP.Count - FailureSurface.RowLength;
			#Itb #5d = new #Itb
			{
				FailureSurface = #Jkb,
				WhichPartToCutVertical = #Qkb,
				Normal = #dtb,
				PointsConsistingFailureSurface = #BP,
				IndexesConsistingFailureSurface = list,
				CoordinateSystemOrigin = #Clb,
				Wireframe = #Glb
			};
			for (int i = 0; i < num; i++)
			{
				bool flag = (i + 1) % FailureSurface.RowLength == 0;
				if (flag)
				{
					if ((#Qkb == #ybb.#a && #Loc.#Gnc(#dtb, new #c4d(#BP[i].X - #Clb.X, #BP[i].Y - #Clb.Y, #BP[i].Z)) <= 0.0 && #Loc.#Gnc(#dtb, new #c4d(#BP[i + 1 - FailureSurface.RowLength].X - #Clb.X, #BP[i + 1 - FailureSurface.RowLength].Y - #Clb.Y, #BP[i + 1 - FailureSurface.RowLength].Z)) <= 0.0 && #Loc.#Gnc(#dtb, new #c4d(#BP[i + FailureSurface.RowLength].X - #Clb.X, #BP[i + FailureSurface.RowLength].Y - #Clb.Y, #BP[i + FailureSurface.RowLength].Z)) <= 0.0 && #Loc.#Gnc(#dtb, new #c4d(#BP[i + 1].X - #Clb.X, #BP[i + 1].Y - #Clb.Y, #BP[i + 1].Z)) <= 0.0) || (#Qkb == #ybb.#b && #Loc.#Gnc(#dtb, new #c4d(#BP[i].X - #Clb.X, #BP[i].Y - #Clb.Y, #BP[i].Z)) >= 0.0 && #Loc.#Gnc(#dtb, new #c4d(#BP[i + 1 - FailureSurface.RowLength].X - #Clb.X, #BP[i + 1 - FailureSurface.RowLength].Y - #Clb.Y, #BP[i + 1 - FailureSurface.RowLength].Z)) >= 0.0 && #Loc.#Gnc(#dtb, new #c4d(#BP[i + FailureSurface.RowLength].X - #Clb.X, #BP[i + FailureSurface.RowLength].Y - #Clb.Y, #BP[i + FailureSurface.RowLength].Z)) >= 0.0 && #Loc.#Gnc(#dtb, new #c4d(#BP[i + 1].X - #Clb.X, #BP[i + 1].Y - #Clb.Y, #BP[i + 1].Z)) >= 0.0))
					{
						VerticalFailureSurfaceCrossSectionGenerator.#Stb(list, i, flag, FailureSurface.RowLength);
					}
					else
					{
						CrossSectionGeneratorsHelper.#Ysb(#5d, i, flag);
					}
				}
				else if ((#Qkb == #ybb.#a && #Loc.#Gnc(#dtb, new #c4d(#BP[i].X - #Clb.X, #BP[i].Y - #Clb.Y, #BP[i].Z)) <= 0.0 && #Loc.#Gnc(#dtb, new #c4d(#BP[i + 1].X - #Clb.X, #BP[i + 1].Y - #Clb.Y, #BP[i + 1].Z)) <= 0.0 && #Loc.#Gnc(#dtb, new #c4d(#BP[i + FailureSurface.RowLength].X - #Clb.X, #BP[i + FailureSurface.RowLength].Y - #Clb.Y, #BP[i + FailureSurface.RowLength].Z)) <= 0.0 && #Loc.#Gnc(#dtb, new #c4d(#BP[i + FailureSurface.RowLength + 1].X - #Clb.X, #BP[i + FailureSurface.RowLength + 1].Y - #Clb.Y, #BP[i + FailureSurface.RowLength + 1].Z)) <= 0.0) || (#Qkb == #ybb.#b && #Loc.#Gnc(#dtb, new #c4d(#BP[i].X - #Clb.X, #BP[i].Y - #Clb.Y, #BP[i].Z)) >= 0.0 && #Loc.#Gnc(#dtb, new #c4d(#BP[i + 1].X - #Clb.X, #BP[i + 1].Y - #Clb.Y, #BP[i + 1].Z)) >= 0.0 && #Loc.#Gnc(#dtb, new #c4d(#BP[i + FailureSurface.RowLength].X - #Clb.X, #BP[i + FailureSurface.RowLength].Y - #Clb.Y, #BP[i + FailureSurface.RowLength].Z)) >= 0.0 && #Loc.#Gnc(#dtb, new #c4d(#BP[i + FailureSurface.RowLength + 1].X - #Clb.X, #BP[i + FailureSurface.RowLength + 1].Y - #Clb.Y, #BP[i + FailureSurface.RowLength + 1].Z)) >= 0.0))
				{
					VerticalFailureSurfaceCrossSectionGenerator.#Stb(list, i, flag, FailureSurface.RowLength);
				}
				else
				{
					CrossSectionGeneratorsHelper.#Ysb(#5d, i, flag);
				}
			}
			return list;
		}

		// Token: 0x06002AC7 RID: 10951 RVA: 0x000E6F80 File Offset: 0x000E5180
		public static IMeshDrawingResult #Otb(FailureSurface #Jkb, IList<Point3D> #BP, IList<int> #Ptb, Color #BR)
		{
			#X0d.#V0d(#Jkb, #Phc.#3hc(107358775), Component.GUI, #Phc.#3hc(107358044));
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.GUI, #Phc.#3hc(107357959));
			#X0d.#V0d(#Ptb, #Phc.#3hc(107358502), Component.GUI, #Phc.#3hc(107357426));
			IMeshDrawingResult meshDrawingResult = #Jkb.DrawingResultsFactory.CreateMeshDrawingResult();
			meshDrawingResult.SetContent(#BP, #Ptb);
			meshDrawingResult.SetColor(#BR, null);
			meshDrawingResult.Freeze();
			return meshDrawingResult;
		}

		// Token: 0x06002AC8 RID: 10952 RVA: 0x000E7020 File Offset: 0x000E5220
		public static IEnumerable<PolyLine3D> #Qtb(FailureSurface #Jkb, #ybb #Qkb, #c4d #dtb, IList<Point3D> #BP, Point3D #Clb)
		{
			#X0d.#V0d(#Jkb, #Phc.#3hc(107358775), Component.GUI, #Phc.#3hc(107357373));
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.GUI, #Phc.#3hc(107357288));
			List<#3wc> list = new List<#3wc>();
			for (int i = 0; i < #Jkb.RowCount; i++)
			{
				for (int j = 0; j < FailureSurface.RowLength; j++)
				{
					int num = i * FailureSurface.RowLength + j;
					int num2 = (j < FailureSurface.RowLength - 1) ? (num + 1) : (i * FailureSurface.RowLength);
					if (num2 <= #Jkb.VertexCount - 1)
					{
						if ((#Qkb == #ybb.#a && #Loc.#Gnc(#dtb, new #c4d(#BP[num].X - #Clb.X, #BP[num].Y - #Clb.Y, #BP[num].Z)) <= 0.0 && #Loc.#Gnc(#dtb, new #c4d(#BP[num2].X - #Clb.X, #BP[num2].Y - #Clb.Y, #BP[num2].Z)) <= 0.0) || (#Qkb == #ybb.#b && #Loc.#Gnc(#dtb, new #c4d(#BP[num].X - #Clb.X, #BP[num].Y - #Clb.Y, #BP[num].Z)) >= 0.0 && #Loc.#Gnc(#dtb, new #c4d(#BP[num2].X - #Clb.X, #BP[num2].Y - #Clb.Y, #BP[num2].Z)) >= 0.0))
						{
							list.Add(new #3wc(#BP[num], #BP[num2]));
						}
						if ((#Qkb == #ybb.#a && #Loc.#Gnc(#dtb, new #c4d(#BP[num].X - #Clb.X, #BP[num].Y - #Clb.Y, #BP[num].Z)) > 0.0 && #Loc.#Gnc(#dtb, new #c4d(#BP[num2].X - #Clb.X, #BP[num2].Y - #Clb.Y, #BP[num2].Z)) <= 0.0) || (#Qkb == #ybb.#b && #Loc.#Gnc(#dtb, new #c4d(#BP[num].X - #Clb.X, #BP[num].Y - #Clb.Y, #BP[num].Z)) < 0.0 && #Loc.#Gnc(#dtb, new #c4d(#BP[num2].X - #Clb.X, #BP[num2].Y - #Clb.Y, #BP[num2].Z)) >= 0.0))
						{
							double #43d;
							#Loc.#toc(new #c4d(#BP[num].X, #BP[num].Y, #BP[num].Z), new #c4d(#BP[num2].X - #BP[num].X, #BP[num2].Y - #BP[num].Y, #BP[num2].Z - #BP[num].Z), #dtb, new #c4d(#Clb.X, #Clb.Y, 0.0), out #43d);
							#c4d #4Bb = new #c4d(#BP[num2].X - #BP[num].X, #BP[num2].Y - #BP[num].Y, #BP[num2].Z - #BP[num].Z);
							Point3D #Xrb = Point3D.#G3d(#BP[num], #c4d.#33d(#43d, #4Bb));
							list.Add(new #3wc(#Xrb, #BP[num2]));
						}
						if ((#Qkb == #ybb.#a && #Loc.#Gnc(#dtb, new #c4d(#BP[num].X - #Clb.X, #BP[num].Y - #Clb.Y, #BP[num].Z)) <= 0.0 && #Loc.#Gnc(#dtb, new #c4d(#BP[num2].X - #Clb.X, #BP[num2].Y - #Clb.Y, #BP[num2].Z)) > 0.0) || (#Qkb == #ybb.#b && #Loc.#Gnc(#dtb, new #c4d(#BP[num].X - #Clb.X, #BP[num].Y - #Clb.Y, #BP[num].Z)) >= 0.0 && #Loc.#Gnc(#dtb, new #c4d(#BP[num2].X - #Clb.X, #BP[num2].Y - #Clb.Y, #BP[num2].Z)) < 0.0))
						{
							double #43d2;
							#Loc.#toc(new #c4d(#BP[num].X, #BP[num].Y, #BP[num].Z), new #c4d(#BP[num2].X - #BP[num].X, #BP[num2].Y - #BP[num].Y, #BP[num2].Z - #BP[num].Z), #dtb, new #c4d(#Clb.X, #Clb.Y, 0.0), out #43d2);
							#c4d #4Bb2 = new #c4d(#BP[num2].X - #BP[num].X, #BP[num2].Y - #BP[num].Y, #BP[num2].Z - #BP[num].Z);
							Point3D #Yrb = Point3D.#G3d(#BP[num], #c4d.#33d(#43d2, #4Bb2));
							list.Add(new #3wc(#BP[num], #Yrb));
						}
					}
				}
			}
			return CrossSectionGeneratorsHelper.#Tsb(list, #Jkb);
		}

		// Token: 0x06002AC9 RID: 10953 RVA: 0x000E7844 File Offset: 0x000E5A44
		public static IEnumerable<PolyLine3D> #Rtb(FailureSurface #Jkb, #ybb #Qkb, #c4d #dtb, IList<Point3D> #BP, Point3D #Clb)
		{
			#X0d.#V0d(#Jkb, #Phc.#3hc(107358775), Component.GUI, #Phc.#3hc(107357267));
			#X0d.#V0d(#BP, #Phc.#3hc(107358670), Component.GUI, #Phc.#3hc(107357214));
			List<#3wc> list = new List<#3wc>();
			for (int i = 0; i < FailureSurface.RowLength; i++)
			{
				for (int j = 0; j < #Jkb.RowCount - 1; j++)
				{
					int num = i + j * FailureSurface.RowLength;
					int index = num + FailureSurface.RowLength;
					if ((#Qkb == #ybb.#a && #Loc.#Gnc(#dtb, new #c4d(#BP[num].X - #Clb.X, #BP[num].Y - #Clb.Y, #BP[num].Z)) <= 0.0 && #Loc.#Gnc(#dtb, new #c4d(#BP[index].X - #Clb.X, #BP[index].Y - #Clb.Y, #BP[index].Z)) <= 0.0) || (#Qkb == #ybb.#b && #Loc.#Gnc(#dtb, new #c4d(#BP[num].X - #Clb.X, #BP[num].Y - #Clb.Y, #BP[num].Z)) >= 0.0 && #Loc.#Gnc(#dtb, new #c4d(#BP[index].X - #Clb.X, #BP[index].Y - #Clb.Y, #BP[index].Z)) >= 0.0))
					{
						list.Add(new #3wc(#BP[num], #BP[index]));
					}
					if ((#Qkb == #ybb.#a && #Loc.#Gnc(#dtb, new #c4d(#BP[num].X - #Clb.X, #BP[num].Y - #Clb.Y, #BP[num].Z)) > 0.0 && #Loc.#Gnc(#dtb, new #c4d(#BP[index].X - #Clb.X, #BP[index].Y - #Clb.Y, #BP[index].Z)) <= 0.0) || (#Qkb == #ybb.#b && #Loc.#Gnc(#dtb, new #c4d(#BP[num].X - #Clb.X, #BP[num].Y - #Clb.Y, #BP[num].Z)) < 0.0 && #Loc.#Gnc(#dtb, new #c4d(#BP[index].X - #Clb.X, #BP[index].Y - #Clb.Y, #BP[index].Z)) >= 0.0))
					{
						double #43d;
						#Loc.#toc(new #c4d(#BP[num].X, #BP[num].Y, #BP[num].Z), new #c4d(#BP[index].X - #BP[num].X, #BP[index].Y - #BP[num].Y, #BP[index].Z - #BP[num].Z), #dtb, new #c4d(#Clb.X, #Clb.Y, 0.0), out #43d);
						#c4d #4Bb = new #c4d(#BP[index].X - #BP[num].X, #BP[index].Y - #BP[num].Y, #BP[index].Z - #BP[num].Z);
						Point3D #Xrb = Point3D.#G3d(#BP[num], #c4d.#33d(#43d, #4Bb));
						list.Add(new #3wc(#Xrb, #BP[index]));
					}
					if ((#Qkb == #ybb.#a && #Loc.#Gnc(#dtb, new #c4d(#BP[num].X - #Clb.X, #BP[num].Y - #Clb.Y, #BP[num].Z)) <= 0.0 && #Loc.#Gnc(#dtb, new #c4d(#BP[index].X - #Clb.X, #BP[index].Y - #Clb.Y, #BP[index].Z)) > 0.0) || (#Qkb == #ybb.#b && #Loc.#Gnc(#dtb, new #c4d(#BP[num].X - #Clb.X, #BP[num].Y - #Clb.Y, #BP[num].Z)) >= 0.0 && #Loc.#Gnc(#dtb, new #c4d(#BP[index].X - #Clb.X, #BP[index].Y - #Clb.Y, #BP[index].Z)) < 0.0))
					{
						double #43d2;
						#Loc.#toc(new #c4d(#BP[num].X, #BP[num].Y, #BP[num].Z), new #c4d(#BP[index].X - #BP[num].X, #BP[index].Y - #BP[num].Y, #BP[index].Z - #BP[num].Z), #dtb, new #c4d(#Clb.X, #Clb.Y, 0.0), out #43d2);
						#c4d #4Bb2 = new #c4d(#BP[index].X - #BP[num].X, #BP[index].Y - #BP[num].Y, #BP[index].Z - #BP[num].Z);
						Point3D #Yrb = Point3D.#G3d(#BP[num], #c4d.#33d(#43d2, #4Bb2));
						list.Add(new #3wc(#BP[num], #Yrb));
					}
				}
			}
			return CrossSectionGeneratorsHelper.#Tsb(list, #Jkb);
		}

		// Token: 0x06002ACA RID: 10954 RVA: 0x000E6148 File Offset: 0x000E4348
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
	}
}
