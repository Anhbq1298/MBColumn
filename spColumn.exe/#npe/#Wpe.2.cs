using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Validation;
using StructurePoint.CoreAssets.Units;

namespace #npe
{
	// Token: 0x02001113 RID: 4371
	internal static class #Wpe
	{
		// Token: 0x06009406 RID: 37894 RVA: 0x000765BC File Offset: 0x000747BC
		public static void #sai(ColumnStorageModel #Od)
		{
			#Od.ReductionFactors.MinDimension = 0f;
		}

		// Token: 0x06009407 RID: 37895 RVA: 0x001F85D0 File Offset: 0x001F67D0
		public static void #xkb(ColumnStorageModel #X)
		{
			#X.Options.SectionType = SectionType.Rectangle;
			#X.Options.InvestigationReinforcement = ReinforcementType.AllEqual;
			#X.Options.DesignReinforcement = ReinforcementType.AllEqual;
			#X.Options.ReinforcementLayout = ReinforcementLayout.Rectangle;
			#Wpe.#Gpe(#X);
			#Wpe.#Hpe(#X);
			#Wpe.#Ipe(#X);
			#Wpe.#Jpe(#X, true, null);
			#Wpe.#Lpe(#X, true, null);
			#Wpe.#Mpe(#X);
		}

		// Token: 0x06009408 RID: 37896 RVA: 0x001F8648 File Offset: 0x001F6848
		public static void #tpe(ColumnStorageModel #X)
		{
			#Wpe.#Fpe(#X);
			Options options = #X.Options;
			bool flag = options.SectionType == SectionType.Irregular;
			bool flag2 = !flag && options.ProblemType == ProblemType.Investigation && options.InvestigationReinforcement == ReinforcementType.Irregular;
			#Wpe.#Gpe(#X);
			#ope #ope = (#ope)((options.ProblemType == ProblemType.Design) ? #X.DesignInputFlag : #X.InvestigateInputFlag);
			bool flag3 = #ope.HasFlag(#ope.#c);
			if (flag)
			{
				#Wpe.#Hpe(#X);
				#Wpe.#Ipe(#X);
			}
			else
			{
				if (options.ProblemType == ProblemType.Design)
				{
					#Wpe.#Hpe(#X);
					#Wpe.#Epe(#X);
				}
				else
				{
					#Wpe.#Ipe(#X);
				}
				if (!flag3)
				{
					#Wpe.#Ipe(#X);
					#Wpe.#Hpe(#X);
				}
			}
			if (flag || flag2)
			{
				#Wpe.#Jpe(#X, true, null);
				#Wpe.#Lpe(#X, true, null);
				#Wpe.#Mpe(#X);
			}
			if (options.ProblemType == ProblemType.Investigation)
			{
				#Wpe.#Lpe(#X, true, null);
				#Wpe.#Jpe(#X, false, new ReinforcementType?(#X.Options.InvestigationReinforcement));
			}
			else
			{
				#Wpe.#Jpe(#X, true, null);
				#Wpe.#Lpe(#X, false, new ReinforcementType?(#X.Options.DesignReinforcement));
			}
			if (!#ope.HasFlag(#ope.#d))
			{
				bool #Kpe = !flag3;
				#Wpe.#Lpe(#X, #Kpe, null);
				#Wpe.#Jpe(#X, #Kpe, null);
			}
		}

		// Token: 0x06009409 RID: 37897 RVA: 0x001F87B4 File Offset: 0x001F69B4
		private static void #Epe(ColumnStorageModel #Od)
		{
			if (#Od.Options.SectionType == SectionType.Circle && (#Od.DesignDimensions.MaxHeight <= 0f || #Od.DesignDimensions.MinHeight <= 0f))
			{
				#Od.DesignDimensions.MaxHeight = #Od.DesignDimensions.MaxWidth;
				#Od.DesignDimensions.MinHeight = #Od.DesignDimensions.MinWidth;
			}
		}

		// Token: 0x0600940A RID: 37898 RVA: 0x001F8820 File Offset: 0x001F6A20
		private static void #Fpe(ColumnStorageModel #X)
		{
			if (#X.Options.ProblemType == ProblemType.Investigation && #X.Options.ActiveReinforcement == ReinforcementType.Irregular && (#X.Options.SectionType == SectionType.Circle || #X.Options.SectionType == SectionType.Rectangle))
			{
				float dimensionA = #X.InvestigationDimensions.DimensionA;
				float dimensionB = #X.InvestigationDimensions.DimensionB;
				List<Point3D> list;
				List<SectionPolygon> collection;
				SectionGeometryHelper.#BT(#X, dimensionA, dimensionB, out list, out collection, true);
				#X.Polygons.Clear();
				#X.Polygons.AddRange(collection);
				#X.Options.SectionType = SectionType.Irregular;
			}
		}

		// Token: 0x0600940B RID: 37899 RVA: 0x001F88AC File Offset: 0x001F6AAC
		private static void #Gpe(ColumnStorageModel #X)
		{
			BarGroupType barGroupType = #X.BarGroupType;
			if (barGroupType == BarGroupType.UserDefined)
			{
				return;
			}
			if (barGroupType - BarGroupType.ASTM615 <= 3)
			{
				#X.Bars.Clear();
				#X.Bars.AddRange(#mpe.#bpe(#X.BarGroupType, #X.Options.Unit));
				return;
			}
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x0600940C RID: 37900 RVA: 0x001F88FC File Offset: 0x001F6AFC
		private static void #Hpe(ColumnStorageModel #X)
		{
			float dimensionA = #Wpe.#Ope(#X) ? 16f : 400f;
			float dimensionB = #Wpe.#Ope(#X) ? 16f : 400f;
			if (!new InvestigationDimensionsValidator(#X.CreateContext()).Validate(#X.InvestigationDimensions).IsValid)
			{
				#X.InvestigationDimensions.DimensionA = dimensionA;
				#X.InvestigationDimensions.DimensionB = dimensionB;
			}
			#X.InvestigateInputFlag |= 2;
		}

		// Token: 0x0600940D RID: 37901 RVA: 0x001F8978 File Offset: 0x001F6B78
		private static void #Ipe(ColumnStorageModel #X)
		{
			if (!new DesignDimensionsValidator(#X.CreateContext()).Validate(#X.DesignDimensions).IsValid)
			{
				float minWidth = #Wpe.#Ope(#X) ? 16f : 400f;
				float minHeight = #Wpe.#Ope(#X) ? 16f : 400f;
				float maxWidth = #Wpe.#Ope(#X) ? 36f : 900f;
				float maxHeight = #Wpe.#Ope(#X) ? 36f : 900f;
				float num = #Wpe.#Ope(#X) ? 2f : 50f;
				#X.DesignDimensions.MinWidth = minWidth;
				#X.DesignDimensions.MaxWidth = maxWidth;
				#X.DesignDimensions.WidthIncrement = num;
				#X.DesignDimensions.MinHeight = minHeight;
				#X.DesignDimensions.MaxHeight = maxHeight;
				#X.DesignDimensions.HeightIncrement = num;
			}
			#X.DesignInputFlag |= 2;
		}

		// Token: 0x0600940E RID: 37902 RVA: 0x001F8A68 File Offset: 0x001F6C68
		private static void #Jpe(ColumnStorageModel #X, bool #Kpe, ReinforcementType? #C = null)
		{
			float num = #Wpe.#Ope(#X) ? 1.5f : 40f;
			int barSize = #Wpe.#Ppe(#X, 8, 25, 25, 25);
			int num2 = #Wpe.#Ppe(#X, 6, 16, 20, 20);
			if (#C != null)
			{
				ReinforcementType? reinforcementType = #C;
				ReinforcementType reinforcementType2 = ReinforcementType.AllEqual;
				if (reinforcementType.GetValueOrDefault() == reinforcementType2 & reinforcementType != null)
				{
					goto IL_F6;
				}
				reinforcementType = #C;
				reinforcementType2 = ReinforcementType.EqualSpace;
				if (reinforcementType.GetValueOrDefault() == reinforcementType2 & reinforcementType != null)
				{
					goto IL_F6;
				}
			}
			if (#X.InvestigationReinforcement.AllEqual == null)
			{
				#X.InvestigationReinforcement.AllEqual = new InvestigationReinforcementEqual();
			}
			if (!new InvestigationReinforcementEqualValidator(#X.CreateContext()).Validate(#X.InvestigationReinforcement.AllEqual).IsValid)
			{
				#X.InvestigationReinforcement.AllEqual.NumberOfBars = (#Kpe ? 4 : 0);
				#X.InvestigationReinforcement.AllEqual.ClearCover = (#Kpe ? num : 0f);
				#X.InvestigationReinforcement.AllEqual.BarSize = barSize;
			}
			IL_F6:
			if (#C != null)
			{
				ReinforcementType? reinforcementType = #C;
				ReinforcementType reinforcementType2 = ReinforcementType.Different;
				if (reinforcementType.GetValueOrDefault() == reinforcementType2 & reinforcementType != null)
				{
					goto IL_26A;
				}
			}
			if (#X.InvestigationReinforcement.Different == null)
			{
				#X.InvestigationReinforcement.Different = new InvestigationReinforcementSidesDifferent();
			}
			if (!new InvestigationReinforcementDifferentValidator(#X.CreateContext()).Validate(#X.InvestigationReinforcement.Different).IsValid)
			{
				#X.InvestigationReinforcement.Different.TopNumberOfBars = (#Kpe ? 3 : 0);
				#X.InvestigationReinforcement.Different.BottomNumberOfBars = (#Kpe ? 3 : 0);
				#X.InvestigationReinforcement.Different.LeftNumberOfBars = (#Kpe ? 1 : 0);
				#X.InvestigationReinforcement.Different.RightNumberOfBars = (#Kpe ? 1 : 0);
				#X.InvestigationReinforcement.Different.TopClearCover = (#Kpe ? num : 0f);
				#X.InvestigationReinforcement.Different.BottomClearCover = (#Kpe ? num : 0f);
				#X.InvestigationReinforcement.Different.LeftClearCover = (#Kpe ? num : 0f);
				#X.InvestigationReinforcement.Different.RightClearCover = (#Kpe ? num : 0f);
				#X.InvestigationReinforcement.Different.TopBarSize = num2;
				#X.InvestigationReinforcement.Different.BottomBarSize = num2;
				#X.InvestigationReinforcement.Different.LeftBarSize = num2;
				#X.InvestigationReinforcement.Different.RightBarSize = num2;
			}
			IL_26A:
			if (#Kpe)
			{
				#X.InvestigateInputFlag |= 4;
			}
			if (#X.Options.InvestigationReinforcement == ReinforcementType.Undefined)
			{
				#X.Options.InvestigationReinforcement = ReinforcementType.AllEqual;
			}
		}

		// Token: 0x0600940F RID: 37903 RVA: 0x001F8D0C File Offset: 0x001F6F0C
		private static void #Lpe(ColumnStorageModel #X, bool #Kpe, ReinforcementType? #C = null)
		{
			float num = #Wpe.#Ope(#X) ? 1.5f : 40f;
			if (#C != null)
			{
				ReinforcementType? reinforcementType = #C;
				ReinforcementType reinforcementType2 = ReinforcementType.AllEqual;
				if (reinforcementType.GetValueOrDefault() == reinforcementType2 & reinforcementType != null)
				{
					goto IL_11B;
				}
				reinforcementType = #C;
				reinforcementType2 = ReinforcementType.EqualSpace;
				if (reinforcementType.GetValueOrDefault() == reinforcementType2 & reinforcementType != null)
				{
					goto IL_11B;
				}
			}
			if (#X.DesignReinforcement.AllEqual == null)
			{
				#X.DesignReinforcement.AllEqual = new DesignReinforcementEqual();
			}
			if (!new DesignReinforcementEqualValidator(#X.CreateContext()).Validate(#X.DesignReinforcement.AllEqual).IsValid)
			{
				#X.DesignReinforcement.AllEqual.MinNumberOfBars = (#Kpe ? 4 : 0);
				#X.DesignReinforcement.AllEqual.MaxNumberOfBars = (#Kpe ? 24 : 0);
				#X.DesignReinforcement.AllEqual.ClearCover = (#Kpe ? num : 0f);
				#X.DesignReinforcement.AllEqual.MinBarSize = #Wpe.#Ppe(#X, 6, 19, 20, 20);
				#X.DesignReinforcement.AllEqual.MaxBarSize = #Wpe.#Ppe(#X, 11, 36, 35, 32);
			}
			IL_11B:
			if (#C != null)
			{
				ReinforcementType? reinforcementType = #C;
				ReinforcementType reinforcementType2 = ReinforcementType.Different;
				if (reinforcementType.GetValueOrDefault() == reinforcementType2 & reinforcementType != null)
				{
					goto IL_285;
				}
			}
			if (#X.DesignReinforcement.Different == null)
			{
				#X.DesignReinforcement.Different = new DesignReinforcementSidesDifferent();
			}
			if (!new DesignReinforcementDifferentValidator(#X.CreateContext()).Validate(#X.DesignReinforcement.Different).IsValid)
			{
				#X.DesignReinforcement.Different.MinTopBottomNumberOfBars = (#Kpe ? 4 : 0);
				#X.DesignReinforcement.Different.MaxTopBottomNumberOfBars = (#Kpe ? 14 : 0);
				#X.DesignReinforcement.Different.MinLeftRightNumberOfBars = 0;
				#X.DesignReinforcement.Different.MaxLeftRightNumberOfBars = (#Kpe ? 10 : 0);
				#X.DesignReinforcement.Different.TopBottomClearCover = (#Kpe ? num : 0f);
				#X.DesignReinforcement.Different.LeftRightClearCover = (#Kpe ? num : 0f);
				#X.DesignReinforcement.Different.MinTopBottomBarSize = #Wpe.#Ppe(#X, 6, 19, 20, 20);
				#X.DesignReinforcement.Different.MaxTopBottomBarSize = #Wpe.#Ppe(#X, 11, 36, 35, 32);
				#X.DesignReinforcement.Different.MinLeftRightBarSize = #Wpe.#Ppe(#X, 6, 19, 20, 20);
				#X.DesignReinforcement.Different.MaxLeftRightBarSize = #Wpe.#Ppe(#X, 11, 36, 35, 32);
			}
			IL_285:
			if (#X.Options.DesignReinforcement == ReinforcementType.Undefined)
			{
				#X.Options.DesignReinforcement = ReinforcementType.AllEqual;
			}
			if (#Kpe)
			{
				#X.DesignInputFlag |= 4;
			}
		}

		// Token: 0x06009410 RID: 37904 RVA: 0x000765CE File Offset: 0x000747CE
		public static void #tai(ColumnStorageModel #X)
		{
			if (#X.Options.Unit == UnitSystem.SIMetric)
			{
				#X.Ties.LargeTie = #Wpe.#Ppe(#X, 4, 13, 15, 8);
			}
		}

		// Token: 0x06009411 RID: 37905 RVA: 0x001F8FCC File Offset: 0x001F71CC
		private static void #Mpe(ColumnStorageModel #X)
		{
			Ties ties = #X.Ties;
			if (!new TiesValidator(#X.CreateContext()).Validate(#X.Ties).IsValid)
			{
				ties.SmallTie = (#Wpe.#Upe(#X, ties.SmallTie) ? ties.SmallTie : #Wpe.#Ppe(#X, 3, 10, 10, 8));
				ties.LongitudinalBar = (#Wpe.#Upe(#X, ties.LongitudinalBar) ? ties.LongitudinalBar : #Wpe.#Ppe(#X, 10, 32, 55, 32));
				if (#X.Options.Unit == UnitSystem.USCustomary)
				{
					ties.LargeTie = (#Wpe.#Upe(#X, ties.LargeTie) ? ties.LargeTie : #Wpe.#Ppe(#X, 4, 13, 15, 12));
					return;
				}
				ties.LargeTie = (#Wpe.#Upe(#X, ties.LargeTie) ? ties.LargeTie : #Wpe.#Ppe(#X, 4, 13, 15, 8));
			}
		}

		// Token: 0x06009412 RID: 37906 RVA: 0x000765F5 File Offset: 0x000747F5
		private static bool #Ope(ColumnStorageModel #X)
		{
			return #X.Options.Unit == UnitSystem.USCustomary;
		}

		// Token: 0x06009413 RID: 37907 RVA: 0x001F90B4 File Offset: 0x001F72B4
		private static int #Ppe(ColumnStorageModel #X, int #Qpe, int #Rpe, int #Spe, int #Tpe)
		{
			switch (#X.BarGroupType)
			{
			case BarGroupType.ASTM615:
				return #Wpe.#Vpe(#X, #Qpe);
			case BarGroupType.CSA:
				return #Wpe.#Vpe(#X, #Spe);
			case BarGroupType.PREN10080:
				return #Wpe.#Vpe(#X, #Tpe);
			case BarGroupType.ASTM615M:
				return #Wpe.#Vpe(#X, #Rpe);
			default:
				return 0;
			}
		}

		// Token: 0x06009414 RID: 37908 RVA: 0x00076605 File Offset: 0x00074805
		private static bool #Upe(ColumnStorageModel #Od, int #4jb)
		{
			return #4jb >= 0 && #4jb < #Od.Bars.Count;
		}

		// Token: 0x06009415 RID: 37909 RVA: 0x001F9104 File Offset: 0x001F7304
		private static int #Vpe(ColumnStorageModel #X, int #Wge)
		{
			#Wpe.#8Ub #8Ub = new #Wpe.#8Ub();
			#8Ub.#a = #Wge;
			int num = #X.Bars.FindIndex(new Predicate<StandardBar>(#8Ub.#xbf));
			if (num < 0)
			{
				return 0;
			}
			return num;
		}

		// Token: 0x02001114 RID: 4372
		[CompilerGenerated]
		private sealed class #8Ub
		{
			// Token: 0x06009417 RID: 37911 RVA: 0x0007661B File Offset: 0x0007481B
			internal bool #xbf(StandardBar #Rf)
			{
				return #Rf.Size == this.#a;
			}

			// Token: 0x04003F1F RID: 16159
			public int #a;
		}
	}
}
