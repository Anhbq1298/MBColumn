using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using #5Z;
using #npe;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Templates;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Storage;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;

namespace StructurePoint.Products.Column.ViewModels.Definitions.Modules
{
	// Token: 0x0200025C RID: 604
	internal static class BarGroupChangeHelper
	{
		// Token: 0x060013FB RID: 5115 RVA: 0x000AF49C File Offset: 0x000AD69C
		public static bool #UF(ColumnModel #VF, BarGroupType #WF)
		{
			bool #ZF = #WF != #VF.BarGroupType;
			List<StructurePoint.Products.Column.Model.Entities.StandardBar> #YF = #VF.Bars.Select(new Func<StructurePoint.Products.Column.Model.Entities.StandardBar, StructurePoint.Products.Column.Model.Entities.StandardBar>(BarGroupChangeHelper.<>c.<>9.#9Yb)).ToList<StructurePoint.Products.Column.Model.Entities.StandardBar>();
			if (#WF == BarGroupType.UserDefined)
			{
				#VF.BarGroupType = BarGroupType.UserDefined;
				return BarGroupChangeHelper.#XF(#VF, #YF, #ZF);
			}
			UnitSystem #Qg = #VF.Options.Unit;
			List<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.StandardBar> source = #mpe.#bpe(#WF, #Qg);
			#VF.BarGroupType = #WF;
			#VF.Bars.Clear();
			#VF.Bars.#pR(source.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.StandardBar, StructurePoint.Products.Column.Model.Entities.StandardBar>(BarGroupChangeHelper.<>c.<>9.#aZb)));
			return BarGroupChangeHelper.#XF(#VF, #YF, #ZF);
		}

		// Token: 0x060013FC RID: 5116 RVA: 0x000AF578 File Offset: 0x000AD778
		public static bool #XF(ColumnModel #VF, List<StructurePoint.Products.Column.Model.Entities.StandardBar> #YF, bool #ZF)
		{
			bool flag = BarGroupChangeHelper.#dG(#VF, #YF);
			#T1 #9F = #VF.InvestigationReinforcement;
			#k1 #7F = #VF.DesignReinforcement;
			#53 #5F = #VF.Ties;
			bool flag2 = false;
			BarGroupChangeHelper.#8F(#VF, #YF, #ZF, #9F, ref flag2);
			BarGroupChangeHelper.#6F(#VF, #YF, #ZF, #7F, ref flag2);
			BarGroupChangeHelper.#4F(#VF, #YF, #ZF, #5F, ref flag2);
			flag2 = BarGroupChangeHelper.#0F(#VF, #YF, #ZF, flag2);
			foreach (SectionTypeDependentValuesCacheItem sectionTypeDependentValuesCacheItem in #VF.SectionTypeCacheItems)
			{
				BarGroupChangeHelper.#8F(#VF, #YF, #ZF, sectionTypeDependentValuesCacheItem.InvestigationReinforcement, ref flag2);
				BarGroupChangeHelper.#6F(#VF, #YF, #ZF, sectionTypeDependentValuesCacheItem.DesignReinforcement, ref flag2);
				BarGroupChangeHelper.#4F(#VF, #YF, #ZF, sectionTypeDependentValuesCacheItem.Ties, ref flag2);
				if (sectionTypeDependentValuesCacheItem.SectionType == SectionType.IrregularTemplate)
				{
					flag2 = BarGroupChangeHelper.#2F(#VF, #YF, #ZF, sectionTypeDependentValuesCacheItem.TemplateData, flag2);
				}
			}
			return flag2 || flag;
		}

		// Token: 0x060013FD RID: 5117 RVA: 0x000154D2 File Offset: 0x000136D2
		public static bool #0F(ColumnModel #VF, List<StructurePoint.Products.Column.Model.Entities.StandardBar> #YF, bool #ZF, bool #1F)
		{
			if (#VF.Options.SectionType == SectionType.IrregularTemplate)
			{
				#1F = BarGroupChangeHelper.#2F(#VF, #YF, #ZF, #1F);
			}
			return #1F;
		}

		// Token: 0x060013FE RID: 5118 RVA: 0x000AF688 File Offset: 0x000AD888
		internal static bool #2F(ColumnModel #VF, List<StructurePoint.Products.Column.Model.Entities.StandardBar> #YF, bool #ZF, TemplateDataEntity #3F, bool #1F)
		{
			IEnumerable<TemplateParameterGroupDefinition> enumerable = #3F.TemplateDefinition.ReinforcementParameters.Union(#3F.TemplateDefinition.SectionParameters);
			foreach (TemplateParameterGroupDefinition templateParameterGroupDefinition in enumerable)
			{
				using (List<TemplateParameterDefinition>.Enumerator enumerator2 = templateParameterGroupDefinition.Parameters.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						BarGroupChangeHelper.#dZb #dZb = new BarGroupChangeHelper.#dZb();
						#dZb.#a = enumerator2.Current;
						if (#dZb.#a.Type == TemplateParameterType.BarSize)
						{
							BarGroupChangeHelper.#fZb #fZb = new BarGroupChangeHelper.#fZb();
							TemplateParameterValueEntity templateParameterValueEntity = #VF.TemplateData.ParameterValues.FirstOrDefault(new Func<TemplateParameterValueEntity, bool>(#dZb.#cZb));
							if (templateParameterValueEntity != null && int.TryParse(templateParameterValueEntity.Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out #fZb.#a))
							{
								int #cG = #YF.FindIndex(new Predicate<StructurePoint.Products.Column.Model.Entities.StandardBar>(#fZb.#eZb));
								int index = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #cG, #ZF, ref #1F);
								StructurePoint.Products.Column.Model.Entities.StandardBar standardBar = #VF.Bars.ElementAtOrDefault(index);
								if (standardBar != null)
								{
									templateParameterValueEntity.Value = standardBar.Size.ToString(CultureInfo.InvariantCulture);
								}
							}
						}
					}
				}
			}
			return #1F;
		}

		// Token: 0x060013FF RID: 5119 RVA: 0x000AF820 File Offset: 0x000ADA20
		internal static bool #2F(ColumnModel #VF, List<StructurePoint.Products.Column.Model.Entities.StandardBar> #YF, bool #ZF, TemplateData #3F, bool #1F)
		{
			IEnumerable<TemplateParameterGroupDefinition> enumerable = #3F.Definition.ReinforcementParameters.Union(#3F.Definition.SectionParameters);
			foreach (TemplateParameterGroupDefinition templateParameterGroupDefinition in enumerable)
			{
				using (List<TemplateParameterDefinition>.Enumerator enumerator2 = templateParameterGroupDefinition.Parameters.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						BarGroupChangeHelper.#xTb #xTb = new BarGroupChangeHelper.#xTb();
						#xTb.#a = enumerator2.Current;
						if (#xTb.#a.Type == TemplateParameterType.BarSize)
						{
							BarGroupChangeHelper.#zTb #zTb = new BarGroupChangeHelper.#zTb();
							TemplateParameterValue templateParameterValue = #3F.ParameterValues.FirstOrDefault(new Func<TemplateParameterValue, bool>(#xTb.#cZb));
							if (templateParameterValue != null && int.TryParse(templateParameterValue.Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out #zTb.#a))
							{
								int #cG = #YF.FindIndex(new Predicate<StructurePoint.Products.Column.Model.Entities.StandardBar>(#zTb.#eZb));
								int index = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #cG, #ZF, ref #1F);
								StructurePoint.Products.Column.Model.Entities.StandardBar standardBar = #VF.Bars.ElementAtOrDefault(index);
								if (standardBar != null)
								{
									templateParameterValue.Value = standardBar.Size.ToString(CultureInfo.InvariantCulture);
								}
							}
						}
					}
				}
			}
			return #1F;
		}

		// Token: 0x06001400 RID: 5120 RVA: 0x000154FA File Offset: 0x000136FA
		internal static bool #2F(ColumnModel #VF, List<StructurePoint.Products.Column.Model.Entities.StandardBar> #YF, bool #ZF, bool #1F)
		{
			return BarGroupChangeHelper.#2F(#VF, #YF, #ZF, #VF.TemplateData, #1F);
		}

		// Token: 0x06001401 RID: 5121 RVA: 0x000AF9B4 File Offset: 0x000ADBB4
		private static void #4F(ColumnModel #VF, List<StructurePoint.Products.Column.Model.Entities.StandardBar> #YF, bool #ZF, Ties #5F, ref bool #1F)
		{
			#5F.SmallTie = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #5F.SmallTie, #ZF, ref #1F);
			#5F.LargeTie = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #5F.LargeTie, #ZF, ref #1F);
			#5F.LongitudinalBar = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #5F.LongitudinalBar, #ZF, ref #1F);
		}

		// Token: 0x06001402 RID: 5122 RVA: 0x000AFA20 File Offset: 0x000ADC20
		private static void #4F(ColumnModel #VF, List<StructurePoint.Products.Column.Model.Entities.StandardBar> #YF, bool #ZF, #53 #5F, ref bool #1F)
		{
			#5F.SmallTie = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #5F.SmallTie, #ZF, ref #1F);
			#5F.LargeTie = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #5F.LargeTie, #ZF, ref #1F);
			#5F.LongitudinalBar = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #5F.LongitudinalBar, #ZF, ref #1F);
		}

		// Token: 0x06001403 RID: 5123 RVA: 0x000AFA8C File Offset: 0x000ADC8C
		private static void #6F(ColumnModel #VF, List<StructurePoint.Products.Column.Model.Entities.StandardBar> #YF, bool #ZF, #k1 #7F, ref bool #1F)
		{
			#7F.AllEqual.MinBarSize = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #7F.AllEqual.MinBarSize, #ZF, ref #1F);
			#7F.AllEqual.MaxBarSize = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #7F.AllEqual.MaxBarSize, #ZF, ref #1F);
			#7F.Different.MinLeftRightBarSize = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #7F.Different.MinLeftRightBarSize, #ZF, ref #1F);
			#7F.Different.MaxLeftRightBarSize = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #7F.Different.MaxLeftRightBarSize, #ZF, ref #1F);
			#7F.Different.MinTopBottomBarSize = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #7F.Different.MinTopBottomBarSize, #ZF, ref #1F);
			#7F.Different.MaxTopBottomBarSize = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #7F.Different.MaxLeftRightBarSize, #ZF, ref #1F);
		}

		// Token: 0x06001404 RID: 5124 RVA: 0x000AFB98 File Offset: 0x000ADD98
		private static void #6F(ColumnModel #VF, List<StructurePoint.Products.Column.Model.Entities.StandardBar> #YF, bool #ZF, DesignReinforcement #7F, ref bool #1F)
		{
			#7F.AllEqual.MinBarSize = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #7F.AllEqual.MinBarSize, #ZF, ref #1F);
			#7F.AllEqual.MaxBarSize = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #7F.AllEqual.MaxBarSize, #ZF, ref #1F);
			#7F.Different.MinLeftRightBarSize = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #7F.Different.MinLeftRightBarSize, #ZF, ref #1F);
			#7F.Different.MaxLeftRightBarSize = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #7F.Different.MaxLeftRightBarSize, #ZF, ref #1F);
			#7F.Different.MinTopBottomBarSize = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #7F.Different.MinTopBottomBarSize, #ZF, ref #1F);
			#7F.Different.MaxTopBottomBarSize = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #7F.Different.MaxLeftRightBarSize, #ZF, ref #1F);
		}

		// Token: 0x06001405 RID: 5125 RVA: 0x000AFCA4 File Offset: 0x000ADEA4
		private static void #8F(ColumnModel #VF, List<StructurePoint.Products.Column.Model.Entities.StandardBar> #YF, bool #ZF, InvestigationReinforcement #9F, ref bool #1F)
		{
			#9F.AllEqual.BarSize = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #9F.AllEqual.BarSize, #ZF, ref #1F);
			#9F.Different.TopBarSize = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #9F.Different.TopBarSize, #ZF, ref #1F);
			#9F.Different.BottomBarSize = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #9F.Different.BottomBarSize, #ZF, ref #1F);
			#9F.Different.LeftBarSize = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #9F.Different.LeftBarSize, #ZF, ref #1F);
			#9F.Different.RightBarSize = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #9F.Different.RightBarSize, #ZF, ref #1F);
		}

		// Token: 0x06001406 RID: 5126 RVA: 0x000AFD88 File Offset: 0x000ADF88
		private static void #8F(ColumnModel #VF, List<StructurePoint.Products.Column.Model.Entities.StandardBar> #YF, bool #ZF, #T1 #9F, ref bool #1F)
		{
			#9F.AllEqual.BarSize = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #9F.AllEqual.BarSize, #ZF, ref #1F);
			#9F.Different.TopBarSize = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #9F.Different.TopBarSize, #ZF, ref #1F);
			#9F.Different.BottomBarSize = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #9F.Different.BottomBarSize, #ZF, ref #1F);
			#9F.Different.LeftBarSize = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #9F.Different.LeftBarSize, #ZF, ref #1F);
			#9F.Different.RightBarSize = BarGroupChangeHelper.#aG(#YF, #VF.Bars, #9F.Different.RightBarSize, #ZF, ref #1F);
		}

		// Token: 0x06001407 RID: 5127 RVA: 0x000AFE6C File Offset: 0x000AE06C
		private static int #aG(IList<StructurePoint.Products.Column.Model.Entities.StandardBar> #YF, IList<StructurePoint.Products.Column.Model.Entities.StandardBar> #bG, int #cG, bool #ZF, ref bool #1F)
		{
			if (#ZF)
			{
				if (#YF.ElementAtOrDefault(#cG) == null)
				{
					return 0;
				}
				StructurePoint.Products.Column.Model.Entities.StandardBar standardBar = #bG.ElementAtOrDefault(#cG);
				if (standardBar != null)
				{
					return #cG;
				}
				int num = Math.Max(0, #cG);
				num = Math.Min(num, #bG.Count - 1);
				#1F = (num != #cG);
				return num;
			}
			else
			{
				BarGroupChangeHelper.#iZb #iZb = new BarGroupChangeHelper.#iZb();
				#iZb.#a = #YF.ElementAtOrDefault(#cG);
				if (#iZb.#a == null)
				{
					return 0;
				}
				StructurePoint.Products.Column.Model.Entities.StandardBar standardBar2 = #bG.FirstOrDefault(new Func<StructurePoint.Products.Column.Model.Entities.StandardBar, bool>(#iZb.#gZb));
				if (standardBar2 != null)
				{
					return #bG.IndexOf(standardBar2);
				}
				var <>f__AnonymousType = #bG.Select(new Func<StructurePoint.Products.Column.Model.Entities.StandardBar, <>f__AnonymousType11<float, StructurePoint.Products.Column.Model.Entities.StandardBar>>(#iZb.#hZb)).OrderBy(new Func<<>f__AnonymousType11<float, StructurePoint.Products.Column.Model.Entities.StandardBar>, float>(BarGroupChangeHelper.<>c.<>9.#bZb)).FirstOrDefault();
				if (<>f__AnonymousType != null)
				{
					#1F = true;
					return #bG.IndexOf(<>f__AnonymousType.Bar);
				}
				return -1;
			}
		}

		// Token: 0x06001408 RID: 5128 RVA: 0x000AFF6C File Offset: 0x000AE16C
		private static bool #dG(ColumnModel #VF, IList<StructurePoint.Products.Column.Model.Entities.StandardBar> #YF)
		{
			#T1 #T = #VF.InvestigationReinforcement;
			#k1 #k = #VF.DesignReinforcement;
			#53 # = #VF.Ties;
			int[] array = new int[]
			{
				#T.AllEqual.BarSize,
				#T.Different.TopBarSize,
				#T.Different.BottomBarSize,
				#T.Different.LeftBarSize,
				#T.Different.RightBarSize,
				#k.AllEqual.MinBarSize,
				#k.AllEqual.MaxBarSize,
				#k.Different.MinLeftRightBarSize,
				#k.Different.MaxLeftRightBarSize,
				#k.Different.MinTopBottomBarSize,
				#k.Different.MaxTopBottomBarSize,
				#.SmallTie,
				#.LargeTie,
				#.LongitudinalBar
			};
			foreach (int index in array)
			{
				BarGroupChangeHelper.#BUb #BUb = new BarGroupChangeHelper.#BUb();
				#BUb.#a = #YF.ElementAtOrDefault(index);
				if (#BUb.#a != null && #VF.Bars.FirstOrDefault(new Func<StructurePoint.Products.Column.Model.Entities.StandardBar, bool>(#BUb.#jZb)) == null)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0200025E RID: 606
		[CompilerGenerated]
		private sealed class #iZb
		{
			// Token: 0x0600140F RID: 5135 RVA: 0x00015537 File Offset: 0x00013737
			internal bool #gZb(StructurePoint.Products.Column.Model.Entities.StandardBar #Rf)
			{
				return #Rf.Size == this.#a.Size;
			}

			// Token: 0x06001410 RID: 5136 RVA: 0x00015558 File Offset: 0x00013758
			internal <>f__AnonymousType11<float, StructurePoint.Products.Column.Model.Entities.StandardBar> #hZb(StructurePoint.Products.Column.Model.Entities.StandardBar #rG)
			{
				return new
				{
					Diff = Math.Abs(#rG.Area - this.#a.Area),
					Bar = #rG
				};
			}

			// Token: 0x0400082C RID: 2092
			public StructurePoint.Products.Column.Model.Entities.StandardBar #a;
		}

		// Token: 0x0200025F RID: 607
		[CompilerGenerated]
		private sealed class #BUb
		{
			// Token: 0x06001412 RID: 5138 RVA: 0x00015583 File Offset: 0x00013783
			internal bool #jZb(StructurePoint.Products.Column.Model.Entities.StandardBar #Rf)
			{
				return #Rf.Size == this.#a.Size;
			}

			// Token: 0x0400082D RID: 2093
			public StructurePoint.Products.Column.Model.Entities.StandardBar #a;
		}

		// Token: 0x02000260 RID: 608
		[CompilerGenerated]
		private sealed class #dZb
		{
			// Token: 0x06001414 RID: 5140 RVA: 0x000155A4 File Offset: 0x000137A4
			internal bool #cZb(TemplateParameterValueEntity #Rf)
			{
				return string.Equals(#Rf.Key, this.#a.Key);
			}

			// Token: 0x0400082E RID: 2094
			public TemplateParameterDefinition #a;
		}

		// Token: 0x02000261 RID: 609
		[CompilerGenerated]
		private sealed class #fZb
		{
			// Token: 0x06001416 RID: 5142 RVA: 0x000155C8 File Offset: 0x000137C8
			internal bool #eZb(StructurePoint.Products.Column.Model.Entities.StandardBar #Rf)
			{
				return #Rf.Size == this.#a;
			}

			// Token: 0x0400082F RID: 2095
			public int #a;
		}

		// Token: 0x02000262 RID: 610
		[CompilerGenerated]
		private sealed class #xTb
		{
			// Token: 0x06001418 RID: 5144 RVA: 0x000155E4 File Offset: 0x000137E4
			internal bool #cZb(TemplateParameterValue #Rf)
			{
				return string.Equals(#Rf.Key, this.#a.Key);
			}

			// Token: 0x04000830 RID: 2096
			public TemplateParameterDefinition #a;
		}

		// Token: 0x02000263 RID: 611
		[CompilerGenerated]
		private sealed class #zTb
		{
			// Token: 0x0600141A RID: 5146 RVA: 0x00015608 File Offset: 0x00013808
			internal bool #eZb(StructurePoint.Products.Column.Model.Entities.StandardBar #Rf)
			{
				return #Rf.Size == this.#a;
			}

			// Token: 0x04000831 RID: 2097
			public int #a;
		}
	}
}
