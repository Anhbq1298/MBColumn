using System;
using System.Collections.Generic;
using System.Text;
using #2be;
using #7hc;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #0be
{
	// Token: 0x02001035 RID: 4149
	internal static class #Zbe
	{
		// Token: 0x06008E3B RID: 36411 RVA: 0x001E5090 File Offset: 0x001E3290
		public static string #qp(ValidationFailure #Xbe, #ice #ib)
		{
			#xce #xce = #Xbe.CustomState as #xce;
			if (#xce == null)
			{
				return #Xbe.ErrorMessage;
			}
			string text = #Zbe.#Qhc(#xce.ItemType);
			string text2 = #Zbe.#Qhc(#xce.Property, #ib);
			string text3 = Environment.NewLine + #Xbe.ErrorMessage.#32d().#22d().#A2d();
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text2 = #Phc.#3hc(107382888) + text2;
			}
			string result;
			if (#xce.ItemIndex != null)
			{
				result = string.Format(#Phc.#3hc(107246137), new object[]
				{
					text,
					text2,
					#xce.ItemIndex + 1,
					text3
				});
			}
			else
			{
				result = text + text2 + #Phc.#3hc(107383615) + text3;
			}
			return result;
		}

		// Token: 0x06008E3C RID: 36412 RVA: 0x001E5184 File Offset: 0x001E3384
		public static string #Ybe(IList<ValidationFailure> #YRb, #ice #ib)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (ValidationFailure #Xbe in #YRb)
			{
				stringBuilder.AppendLine(#Zbe.#qp(#Xbe, #ib));
				stringBuilder.AppendLine();
			}
			return stringBuilder.ToString().Trim();
		}

		// Token: 0x06008E3D RID: 36413 RVA: 0x001E51EC File Offset: 0x001E33EC
		private static string #Qhc(#Nce #R0)
		{
			switch (#R0)
			{
			case #Nce.#a:
			case #Nce.#z:
				return Strings.StringProject;
			case #Nce.#b:
				return Strings.StringSectionTies;
			case #Nce.#c:
			case #Nce.#d:
				return Strings.StringSection_HYPHEN_Dimension;
			case #Nce.#e:
				return Strings.StringDefinitions_HYPHEN_Materials;
			case #Nce.#f:
				return Strings.StringDefinitionsDesign_HYPHEN_Criteria;
			case #Nce.#g:
				return Strings.StringSlenderness_HYPHEN_DesignColumnXAxis;
			case #Nce.#h:
				return Strings.StringSlenderness_HYPHEN_DesignColumnYAxis;
			case #Nce.#i:
			case #Nce.#j:
			case #Nce.#k:
			case #Nce.#l:
			case #Nce.#m:
				return Strings.StringSection_HYPHEN_Reinforcement;
			case #Nce.#n:
			case #Nce.#o:
			case #Nce.#p:
			case #Nce.#q:
			case #Nce.#r:
			case #Nce.#s:
				return Strings.StringLoads_HYPHEN_Service;
			case #Nce.#t:
			case #Nce.#u:
				return Strings.StringSlenderness_HYPHEN_ColumnsAboveBelow;
			case #Nce.#v:
			case #Nce.#w:
				return Strings.StringSection_HYPHEN_Irregular;
			case #Nce.#x:
				return Strings.StringLoads_HYPHEN_Factored;
			case #Nce.#y:
				return Strings.StringDefinitions_HYPHEN_ReductionFactors;
			case #Nce.#A:
				return Strings.StringDefinitionsDesign_HYPHEN_Criteria;
			case #Nce.#B:
				return Strings.StringDefinitions_HYPHEN_Reinforcement;
			case #Nce.#C:
				return Strings.StringLoads_HYPHEN_LoadFactors;
			case #Nce.#D:
				return Strings.StringSlenderness_HYPHEN_SlendernessFactors;
			case #Nce.#E:
				return Strings.StringSlenderness_HYPHEN_BeamXAboveLeft;
			case #Nce.#F:
				return Strings.StringSlenderness_HYPHEN_BeamXAboveRight;
			case #Nce.#G:
				return Strings.StringSlenderness_HYPHEN_BeamXBelowLeft;
			case #Nce.#H:
				return Strings.StringSlenderness_HYPHEN_BeamXBelowRight;
			case #Nce.#I:
				return Strings.StringSlenderness_HYPHEN_BeamYAboveLeft;
			case #Nce.#J:
				return Strings.StringSlenderness_HYPHEN_BeamYAboveRight;
			case #Nce.#K:
				return Strings.StringSlenderness_HYPHEN_BeamYBelowLeft;
			case #Nce.#L:
				return Strings.StringSlenderness_HYPHEN_BeamYBelowRight;
			case #Nce.#M:
				return Strings.StringIrregularSection;
			case #Nce.#N:
				return Strings.StringAxialLoads;
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107246108), #R0, null);
			}
		}

		// Token: 0x06008E3E RID: 36414 RVA: 0x001E535C File Offset: 0x001E355C
		public static string #Qhc(#Oce #z8c, #ice #ib)
		{
			bool flag = #ib.#Qbe();
			switch (#z8c)
			{
			case #Oce.#a:
				return Strings.StringStartDepthD;
			case #Oce.#b:
				if (!flag)
				{
					return Strings.StringStartDiameterB;
				}
				return Strings.StringStartWidthB;
			case #Oce.#c:
				return Strings.StringEndDepthD;
			case #Oce.#d:
				if (!flag)
				{
					return Strings.StringEndDiameterB;
				}
				return Strings.StringEndWidthB;
			case #Oce.#e:
				if (!flag)
				{
					return Strings.StringDiameterStepD;
				}
				return Strings.StringDepthStepD;
			case #Oce.#f:
				return Strings.StringWidthStepB;
			case #Oce.#g:
				if (!flag)
				{
					return Strings.StringDiameter;
				}
				return Strings.StringWidth;
			case #Oce.#h:
				return Strings.StringDepth;
			case #Oce.#i:
				return Strings.StringNoOfBars;
			case #Oce.#j:
				return Strings.StringClearCover;
			case #Oce.#k:
				return Strings.StringBarSize;
			case #Oce.#l:
				return Strings.StringTopNoOfBars;
			case #Oce.#m:
				return Strings.StringBottomNoOfBars;
			case #Oce.#n:
				return Strings.StringLeftNoOfBars;
			case #Oce.#o:
				return Strings.StringRightNoOfBars;
			case #Oce.#p:
				return Strings.StringTopBarSize;
			case #Oce.#q:
				return Strings.StringBottomBarSize;
			case #Oce.#r:
				return Strings.StringLeftBarSize;
			case #Oce.#s:
				return Strings.StringRightBarSize;
			case #Oce.#t:
				return Strings.StringTopClearCover;
			case #Oce.#u:
				return Strings.StringBottomClearCover;
			case #Oce.#v:
				return Strings.StringLeftClearCover;
			case #Oce.#w:
				return Strings.StringRightClearCover;
			case #Oce.#x:
				return Strings.StringMinNoOfBars;
			case #Oce.#y:
				return Strings.StringMinBarSize;
			case #Oce.#z:
				return Strings.StringMaxNoOfBars;
			case #Oce.#A:
				return Strings.StringMaxBarSize;
			case #Oce.#B:
				return Strings.StringMinTopBottomNoOfBars;
			case #Oce.#C:
				return Strings.StringMaxTopBottomNoOfBars;
			case #Oce.#D:
				return Strings.StringMinLeftRightNoOfBars;
			case #Oce.#E:
				return Strings.StringMaxLeftRightNoOfBars;
			case #Oce.#F:
				return Strings.StringMinTopBottomBarSize;
			case #Oce.#G:
				return Strings.StringMaxTopBottomBarSize;
			case #Oce.#H:
				return Strings.StringMinLeftRightBarSize;
			case #Oce.#I:
				return Strings.StringMaxLeftRightBarSize;
			case #Oce.#J:
				return Strings.StringTopBottomClearCover;
			case #Oce.#K:
				return Strings.StringLeftRightClearCover;
			case #Oce.#L:
				return Strings.StringArea;
			case #Oce.#M:
				return Strings.StringX;
			case #Oce.#N:
				return Strings.StringY;
			case #Oce.#O:
				return Strings.StringZ;
			case #Oce.#P:
				return Strings.StringElasticityEc;
			case #Oce.#Q:
				return Strings.StringMaxStressFc;
			case #Oce.#R:
				return Strings.StringBeta1;
			case #Oce.#S:
				return Strings.StringUltimateStrainEps;
			case #Oce.#T:
				return Strings.StringElasticityEs;
			case #Oce.#U:
				return Strings.StringEty;
			case #Oce.#V:
				return Strings.StringPrecast;
			case #Oce.#W:
				return Strings.StringStrengthFcp;
			case #Oce.#X:
				return Strings.StringStrengthFy;
			case #Oce.#Y:
				return Strings.StringAxialCompressionA;
			case #Oce.#Z:
				if (!#ib.IsCsa)
				{
					return Strings.StringTensionControlledB;
				}
				return Strings.StringSteelS;
			case #Oce.#0:
				if (!#ib.IsCsa)
				{
					return Strings.StringCompressionControlled;
				}
				return Strings.StringConcreteC;
			case #Oce.#1:
				return Strings.StringIrregularSectionMinDimensionH;
			case #Oce.#2:
				return Strings.StringMinimumReinforcementRatio;
			case #Oce.#3:
				return Strings.StringMaximumReinforcementRatio;
			case #Oce.#4:
				return Strings.StringAllowableCapacity_Ratio;
			case #Oce.#5:
				return Strings.StringMinClearSpacingBetweenBars;
			case #Oce.#6:
				return #Phc.#3hc(107246575);
			case #Oce.#7:
				return #Phc.#3hc(107246562);
			case #Oce.#8:
				return #Phc.#3hc(107246581);
			case #Oce.#9:
				return Strings.StringSize;
			case #Oce.#ab:
				return Strings.StringDiameter;
			case #Oce.#bb:
				return Strings.StringWeight;
			case #Oce.#cb:
				return Strings.StringHeight;
			case #Oce.#db:
				return Strings.StringMomentX;
			case #Oce.#eb:
				return Strings.StringMomentY;
			case #Oce.#fb:
				if (#ib.ActiveLoad != LoadType.Factored)
				{
					return Strings.StringP;
				}
				return Strings.StringPu;
			case #Oce.#gb:
				return Strings.StringMxTop;
			case #Oce.#hb:
				return Strings.StringMxBot;
			case #Oce.#ib:
				return Strings.StringMyTop;
			case #Oce.#jb:
				return Strings.StringMyBot;
			case #Oce.#kb:
				return Strings.StringDead;
			case #Oce.#lb:
				return Strings.StringLive;
			case #Oce.#mb:
				return Strings.StringWind;
			case #Oce.#nb:
				return Strings.StringEarthquake;
			case #Oce.#ob:
				return Strings.StringSnow;
			case #Oce.#pb:
				return Strings.StringStiffnessReductionFactor;
			case #Oce.#qb:
				return Strings.StringBeamsClb;
			case #Oce.#rb:
				return Strings.StringColumnsClc;
			case #Oce.#sb:
				return Strings.StringSumPuDividedByPu;
			case #Oce.#tb:
				return Strings.StringSumPcDividedByPc;
			case #Oce.#ub:
				return Strings.StringKBraced;
			case #Oce.#vb:
				return Strings.StringKSway;
			case #Oce.#wb:
				return Strings.StringDepth;
			case #Oce.#xb:
				return Strings.StringWidth;
			case #Oce.#yb:
				return Strings.StringLength;
			case #Oce.#zb:
				return Strings.StringInertia;
			case #Oce.#Ab:
				return Strings.StringLoadType;
			case #Oce.#Bb:
				return Strings.StringSectionType;
			case #Oce.#Cb:
				return #Phc.#3hc(107246556);
			case #Oce.#Db:
				return #Phc.#3hc(107246523);
			case #Oce.#Eb:
				return #Phc.#3hc(107246466);
			case #Oce.#Fb:
				return #Phc.#3hc(107348230);
			case #Oce.#Gb:
				return #Phc.#3hc(107348253);
			case #Oce.#Hb:
				return #Phc.#3hc(107246445);
			case #Oce.#Ib:
				return string.Empty;
			case #Oce.#Jb:
				return #Phc.#3hc(107246452);
			case #Oce.#Kb:
				return Strings.StringInitialLoad;
			case #Oce.#Lb:
				return Strings.StringFinalLoad;
			case #Oce.#Mb:
				return Strings.StringIncrement;
			case #Oce.#Nb:
				return #Phc.#3hc(107246403);
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107246346), #z8c, null);
			}
		}
	}
}
