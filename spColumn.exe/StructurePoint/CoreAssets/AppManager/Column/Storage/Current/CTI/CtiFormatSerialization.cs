using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using #7hc;
using #xKe;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Storage.Current.CTI
{
	// Token: 0x020010FC RID: 4348
	internal sealed class CtiFormatSerialization
	{
		// Token: 0x06009374 RID: 37748 RVA: 0x00076162 File Offset: 0x00074362
		public CtiFormatSerialization(ColumnStorageModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399786));
			}
			this.#a = model;
		}

		// Token: 0x06009375 RID: 37749 RVA: 0x001F5D5C File Offset: 0x001F3F5C
		public string #y0d()
		{
			List<string> list = new List<string>();
			list.Add(#Phc.#3hc(107289145));
			list.Add(#Phc.#3hc(107290874));
			list.Add(this.#Fjc());
			list.Add(#Phc.#3hc(107290907));
			list.Add(this.#6ne(this.#a.ProjectInfo.Project, false));
			list.Add(#Phc.#3hc(107290350));
			list.Add(this.#6ne(this.#a.ProjectInfo.ColumnId, false));
			list.Add(#Phc.#3hc(107290365));
			list.Add(this.#6ne(this.#a.ProjectInfo.Engineer, false));
			list.Add(#Phc.#3hc(107290316));
			list.Add(this.#6ne(this.#a.InvestigateInputFlag, false));
			list.Add(#Phc.#3hc(107290283));
			list.Add(this.#6ne(this.#a.DesignInputFlag, false));
			list.Add(#Phc.#3hc(107290290));
			list.Add(this.#6ne(this.#a.SlendernessInputFlag, false));
			list.Add(#Phc.#3hc(107290265));
			list.Add(this.#2Jd(this.#a));
			list.Add(#Phc.#3hc(107290212));
			list.Add(this.#lme(this.#a.IrregularOptions));
			list.Add(#Phc.#3hc(107290183));
			list.Add(this.#mme(this.#a.Ties));
			list.Add(#Phc.#3hc(107290206));
			list.Add(this.#nme(this.#a));
			list.Add(#Phc.#3hc(107290165));
			list.Add(this.#ome(this.#a));
			list.Add(#Phc.#3hc(107290132));
			list.Add(this.#pme(this.#a.InvestigationDimensions));
			list.Add(#Phc.#3hc(107290563));
			list.Add(this.#qme(this.#a.DesignDimensions));
			list.Add(#Phc.#3hc(107290558));
			list.Add(this.#rme(this.#a.MaterialProperties));
			list.Add(#Phc.#3hc(107290497));
			list.Add(this.#sme(this.#a.ReductionFactors));
			list.Add(#Phc.#3hc(107290468));
			list.Add(this.#ume(this.#a));
			this.#Pne(list);
			this.#Nne(list);
			list.Add(#Phc.#3hc(107290396));
			if (this.#a.Options.ActiveLoad == LoadType.Axial)
			{
				this.#Yne(ref list, this.#a.AxialLoads);
			}
			else
			{
				this.#yme(ref list, this.#a.FactoredLoads);
			}
			list.Add(#Phc.#3hc(107289827));
			list.Add(this.#zme(this.#a));
			list.Add(#Phc.#3hc(107289798));
			list.Add(this.#Ame(this.#a));
			list.Add(#Phc.#3hc(107289777));
			list.Add(this.#Bme(this.#a));
			list.Add(#Phc.#3hc(107289748));
			list.Add(this.#6ne(this.#a.StiffnessX, true));
			list.Add(#Phc.#3hc(107289707));
			list.Add(this.#6ne((int)this.#a.SlendernessOptFactor, false));
			list.Add(#Phc.#3hc(107289722));
			list.Add(this.#6ne(this.#a.StiffnessReductionFactorPhi, true));
			list.Add(#Phc.#3hc(107290951));
			list.Add(this.#6ne(this.#a.CrackedIBeams, true) + #YKe.#a + this.#6ne(this.#a.CrackedIColumn, true));
			list.Add(#Phc.#3hc(107290917));
			this.#Eme(ref list, this.#a.ServiceLoads);
			list.Add(#Phc.#3hc(107289673));
			this.#Fme(ref list, this.#a.LoadFactors);
			list.Add(#Phc.#3hc(107289644));
			list.Add(this.#6ne(this.#a.BarGroupType, false));
			list.Add(#Phc.#3hc(107289655));
			this.#Gme(ref list, this.#a);
			list.Add(#Phc.#3hc(107289626));
			list.Add(this.#P7(this.#a.SustainedLoadFactors));
			return string.Join(Environment.NewLine, list);
		}

		// Token: 0x06009376 RID: 37750 RVA: 0x001F6274 File Offset: 0x001F4474
		private void #Nne(List<string> #One)
		{
			if (this.#a.Options.SectionType == SectionType.Irregular)
			{
				#One.Add(#Phc.#3hc(107290425));
				this.#xme(ref #One, this.#a.ReinforcementBars);
				return;
			}
			SectionTypeDependentValuesCacheItem sectionTypeDependentValuesCacheItem = this.#a.SectionTypeCacheItems.FirstOrDefault(new Func<SectionTypeDependentValuesCacheItem, bool>(CtiFormatSerialization.<>c.<>9.#lbf));
			if (sectionTypeDependentValuesCacheItem != null)
			{
				#One.Add(#Phc.#3hc(107290425));
				this.#xme(ref #One, sectionTypeDependentValuesCacheItem.Bars);
				return;
			}
			#One.Add(#Phc.#3hc(107290425));
			#One.Add(#Phc.#3hc(107426661));
		}

		// Token: 0x06009377 RID: 37751 RVA: 0x001F632C File Offset: 0x001F452C
		private void #Pne(List<string> #One)
		{
			if (this.#a.Options.SectionType == SectionType.Irregular)
			{
				#One.Add(#Phc.#3hc(107290443));
				this.#Ome(ref #One, this.#a.Polygons.Where(new Func<SectionPolygon, bool>(CtiFormatSerialization.<>c.<>9.#mbf)).ToList<SectionPolygon>());
				#One.Add(#Phc.#3hc(107290450));
				this.#Ome(ref #One, this.#a.Polygons.Where(new Func<SectionPolygon, bool>(CtiFormatSerialization.<>c.<>9.#nbf)).ToList<SectionPolygon>());
				return;
			}
			SectionTypeDependentValuesCacheItem sectionTypeDependentValuesCacheItem = this.#a.SectionTypeCacheItems.FirstOrDefault(new Func<SectionTypeDependentValuesCacheItem, bool>(CtiFormatSerialization.<>c.<>9.#obf));
			if (sectionTypeDependentValuesCacheItem != null)
			{
				#One.Add(#Phc.#3hc(107290443));
				this.#Ome(ref #One, sectionTypeDependentValuesCacheItem.Polygons.Where(new Func<SectionPolygon, bool>(CtiFormatSerialization.<>c.<>9.#pbf)).ToList<SectionPolygon>());
				#One.Add(#Phc.#3hc(107290450));
				this.#Ome(ref #One, sectionTypeDependentValuesCacheItem.Polygons.Where(new Func<SectionPolygon, bool>(CtiFormatSerialization.<>c.<>9.#qbf)).ToList<SectionPolygon>());
				return;
			}
			#One.Add(#Phc.#3hc(107290443));
			#One.Add(#Phc.#3hc(107426661));
			#One.Add(#Phc.#3hc(107290450));
			#One.Add(#Phc.#3hc(107426661));
		}

		// Token: 0x06009378 RID: 37752 RVA: 0x001F64F0 File Offset: 0x001F46F0
		private void #Ome(ref List<string> #Usb, IList<SectionPolygon> #yP)
		{
			#Usb.Add(this.#6ne(#yP.Count, false));
			foreach (SectionPolygon sectionPolygon in #yP)
			{
				this.#rHb(ref #Usb, sectionPolygon.Points);
			}
		}

		// Token: 0x06009379 RID: 37753 RVA: 0x001F6558 File Offset: 0x001F4758
		private string #Fjc()
		{
			double num = Convert.ToDouble(Convert.ToDouble(ColumnGlobalInfo.Version, CultureInfo.InvariantCulture));
			return this.#6ne((float)num, false);
		}

		// Token: 0x0600937A RID: 37754 RVA: 0x001F6588 File Offset: 0x001F4788
		private int #Qne(ColumnStorageModel #Od)
		{
			if (#Od.Options.SectionType == SectionType.Irregular)
			{
				return #Od.ReinforcementBars.Count;
			}
			SectionTypeDependentValuesCacheItem sectionTypeDependentValuesCacheItem = this.#a.SectionTypeCacheItems.FirstOrDefault(new Func<SectionTypeDependentValuesCacheItem, bool>(CtiFormatSerialization.<>c.<>9.#rbf));
			if (sectionTypeDependentValuesCacheItem == null)
			{
				return 0;
			}
			return sectionTypeDependentValuesCacheItem.Bars.Count;
		}

		// Token: 0x0600937B RID: 37755 RVA: 0x001F65F0 File Offset: 0x001F47F0
		private string #2Jd(ColumnStorageModel #Od)
		{
			return #YKe.#VKe(new List<string>
			{
				this.#6ne(#Od.Options.ProblemType, false),
				this.#6ne(#Od.Options.Unit, false),
				this.#6ne(#Od.Options.Code, false),
				this.#6ne(#Od.Options.ConsideredAxis, false),
				this.#6ne(#Od.Options.RedType, false),
				this.#6ne(#Od.Options.ConsiderSlenderness, false),
				this.#6ne(#Od.Options.DesignTarget, false),
				this.#6ne(0, false),
				this.#6ne(#Od.Options.SectionType, false),
				this.#6ne(#Od.Options.ReinforcementLayout, false),
				this.#6ne(#Od.Options.ColumnType, false),
				this.#6ne(#Od.Options.ConfinementType, false),
				this.#6ne((#Od.Options.InvestigationLoad == LoadType.NoLoads) ? LoadType.Controld : #Od.Options.InvestigationLoad, false),
				this.#6ne((#Od.Options.DesignLoad == LoadType.NoLoads) ? LoadType.Controld : #Od.Options.DesignLoad, false),
				this.#6ne(#Od.Options.InvestigationReinforcement, false),
				this.#6ne(#Od.Options.DesignReinforcement, false),
				this.#6ne(this.#Qne(#Od), false),
				this.#6ne((#Od.Options.ActiveLoad == LoadType.Axial) ? #Od.AxialLoads.Count : #Od.FactoredLoads.Count, false),
				this.#6ne(#Od.ServiceLoads.Count, false),
				this.#6ne(this.#Xne(PolygonApplication.Solid), false),
				this.#6ne(this.#Xne(PolygonApplication.Opening), false),
				this.#6ne(0, false),
				this.#6ne(0f, true),
				this.#6ne(#Od.Options.InvestigationClearCover, false),
				this.#6ne(#Od.Options.DesignClearCover, false),
				this.#6ne(#Od.LoadFactors.Count, false),
				this.#6ne(#Od.Options.SectionCapacityMethod, false)
			});
		}

		// Token: 0x0600937C RID: 37756 RVA: 0x001F6930 File Offset: 0x001F4B30
		private string #lme(IrregularOptions #Rne)
		{
			return #YKe.#VKe(new List<string>
			{
				this.#6ne(#Rne.ViewFlag, false),
				this.#6ne(#Rne.SectionFlag, false),
				this.#6ne(#Rne.ReinforcementFlag, false),
				this.#6ne(#Rne.BarsToPlace, false),
				this.#6ne(#Rne.BarArea, true),
				this.#6ne(#Rne.DrawMax.X, true),
				this.#6ne(#Rne.DrawMax.Y, true),
				this.#6ne(#Rne.DrawMin.X, true),
				this.#6ne(#Rne.DrawMin.Y, true),
				this.#6ne(#Rne.GridSpc.X, true),
				this.#6ne(#Rne.GridSpc.Y, true),
				this.#6ne(#Rne.Snap.X, true),
				this.#6ne(#Rne.Snap.Y, true)
			});
		}

		// Token: 0x0600937D RID: 37757 RVA: 0x001F6AA8 File Offset: 0x001F4CA8
		private string #mme(Ties #63)
		{
			return #YKe.#VKe(new List<string>
			{
				this.#6ne(#63.SmallTie, false),
				this.#6ne(#63.LargeTie, false),
				this.#6ne(#63.LongitudinalBar, false)
			});
		}

		// Token: 0x0600937E RID: 37758 RVA: 0x001F6B08 File Offset: 0x001F4D08
		private string #nme(ColumnStorageModel #Od)
		{
			List<string> list = #YKe.#XKe();
			ReinforcementType reinforcementType = #Od.Options.InvestigationReinforcement;
			SectionTypeDependentValuesCacheItem sectionTypeDependentValuesCacheItem = #Od.SectionTypeCacheItems.FirstOrDefault(new Func<SectionTypeDependentValuesCacheItem, bool>(CtiFormatSerialization.<>c.<>9.#Mbi));
			InvestigationReinforcementEqual investigationReinforcementEqual = (reinforcementType == ReinforcementType.AllEqual || reinforcementType == ReinforcementType.EqualSpace) ? #Od.InvestigationReinforcement.AllEqual : ((sectionTypeDependentValuesCacheItem != null) ? sectionTypeDependentValuesCacheItem.InvestigationReinforcement.AllEqual : null);
			SectionTypeDependentValuesCacheItem sectionTypeDependentValuesCacheItem2 = #Od.SectionTypeCacheItems.FirstOrDefault(new Func<SectionTypeDependentValuesCacheItem, bool>(CtiFormatSerialization.<>c.<>9.#Nbi));
			InvestigationReinforcementSidesDifferent investigationReinforcementSidesDifferent = (reinforcementType == ReinforcementType.Different) ? #Od.InvestigationReinforcement.Different : ((sectionTypeDependentValuesCacheItem2 != null) ? sectionTypeDependentValuesCacheItem2.InvestigationReinforcement.Different : null);
			if (investigationReinforcementEqual == null && investigationReinforcementSidesDifferent == null)
			{
				investigationReinforcementEqual = #Od.InvestigationReinforcement.AllEqual;
			}
			if (#Od.Options.SectionType == SectionType.Irregular)
			{
				reinforcementType = ((investigationReinforcementEqual != null) ? ReinforcementType.AllEqual : ReinforcementType.Different);
			}
			if (investigationReinforcementEqual != null && (reinforcementType == ReinforcementType.AllEqual || reinforcementType == ReinforcementType.EqualSpace))
			{
				list[0] = #YKe.#6ne(investigationReinforcementEqual.NumberOfBars, false);
				list[4] = #YKe.#6ne(investigationReinforcementEqual.BarSize, false);
				list[8] = #YKe.#6ne(investigationReinforcementEqual.ClearCover, true);
			}
			if (investigationReinforcementSidesDifferent != null && reinforcementType == ReinforcementType.Different)
			{
				list[0] = #YKe.#6ne(investigationReinforcementSidesDifferent.TopNumberOfBars, false);
				list[1] = #YKe.#6ne(investigationReinforcementSidesDifferent.BottomNumberOfBars, false);
				list[2] = #YKe.#6ne(investigationReinforcementSidesDifferent.LeftNumberOfBars, false);
				list[3] = #YKe.#6ne(investigationReinforcementSidesDifferent.RightNumberOfBars, false);
				list[4] = #YKe.#6ne(investigationReinforcementSidesDifferent.TopBarSize, false);
				list[5] = #YKe.#6ne(investigationReinforcementSidesDifferent.BottomBarSize, false);
				list[6] = #YKe.#6ne(investigationReinforcementSidesDifferent.LeftBarSize, false);
				list[7] = #YKe.#6ne(investigationReinforcementSidesDifferent.RightBarSize, false);
				list[8] = #YKe.#6ne(investigationReinforcementSidesDifferent.TopClearCover, true);
				list[9] = #YKe.#6ne(investigationReinforcementSidesDifferent.BottomClearCover, true);
				list[10] = #YKe.#6ne(investigationReinforcementSidesDifferent.LeftClearCover, true);
				list[11] = #YKe.#6ne(investigationReinforcementSidesDifferent.RightClearCover, true);
			}
			return #YKe.#VKe(list);
		}

		// Token: 0x0600937F RID: 37759 RVA: 0x001F6D88 File Offset: 0x001F4F88
		private string #ome(ColumnStorageModel #Od)
		{
			ReinforcementType reinforcementType = #Od.Options.DesignReinforcement;
			List<string> list = #YKe.#XKe();
			DesignReinforcementEqual designReinforcementEqual;
			if (reinforcementType != ReinforcementType.AllEqual && reinforcementType != ReinforcementType.EqualSpace)
			{
				SectionTypeDependentValuesCacheItem sectionTypeDependentValuesCacheItem = #Od.SectionTypeCacheItems.FirstOrDefault(new Func<SectionTypeDependentValuesCacheItem, bool>(CtiFormatSerialization.<>c.<>9.#Obi));
				designReinforcementEqual = ((sectionTypeDependentValuesCacheItem != null) ? sectionTypeDependentValuesCacheItem.DesignReinforcement.AllEqual : null);
			}
			else
			{
				designReinforcementEqual = #Od.DesignReinforcement.AllEqual;
			}
			DesignReinforcementEqual designReinforcementEqual2 = designReinforcementEqual;
			DesignReinforcementSidesDifferent designReinforcementSidesDifferent;
			if (reinforcementType != ReinforcementType.Different)
			{
				SectionTypeDependentValuesCacheItem sectionTypeDependentValuesCacheItem2 = #Od.SectionTypeCacheItems.FirstOrDefault(new Func<SectionTypeDependentValuesCacheItem, bool>(CtiFormatSerialization.<>c.<>9.#Pbi));
				designReinforcementSidesDifferent = ((sectionTypeDependentValuesCacheItem2 != null) ? sectionTypeDependentValuesCacheItem2.DesignReinforcement.Different : null);
			}
			else
			{
				designReinforcementSidesDifferent = #Od.DesignReinforcement.Different;
			}
			DesignReinforcementSidesDifferent designReinforcementSidesDifferent2 = designReinforcementSidesDifferent;
			if (designReinforcementEqual2 == null && designReinforcementSidesDifferent2 == null)
			{
				designReinforcementEqual2 = #Od.DesignReinforcement.AllEqual;
			}
			if (#Od.Options.SectionType == SectionType.Irregular)
			{
				reinforcementType = ((designReinforcementEqual2 != null) ? ReinforcementType.AllEqual : ReinforcementType.Different);
			}
			if (reinforcementType == ReinforcementType.AllEqual || reinforcementType == ReinforcementType.EqualSpace)
			{
				list[0] = #YKe.#6ne(designReinforcementEqual2.MinNumberOfBars, false);
				list[1] = #YKe.#6ne(designReinforcementEqual2.MaxNumberOfBars, false);
				list[4] = #YKe.#6ne(designReinforcementEqual2.MinBarSize, false);
				list[5] = #YKe.#6ne(designReinforcementEqual2.MaxBarSize, false);
				list[8] = #YKe.#6ne(designReinforcementEqual2.ClearCover, true);
			}
			if (reinforcementType == ReinforcementType.Different)
			{
				list[0] = #YKe.#6ne(designReinforcementSidesDifferent2.MinTopBottomNumberOfBars, false);
				list[1] = #YKe.#6ne(designReinforcementSidesDifferent2.MaxTopBottomNumberOfBars, false);
				list[2] = #YKe.#6ne(designReinforcementSidesDifferent2.MinLeftRightNumberOfBars, false);
				list[3] = #YKe.#6ne(designReinforcementSidesDifferent2.MaxLeftRightNumberOfBars, false);
				list[4] = #YKe.#6ne(designReinforcementSidesDifferent2.MinTopBottomBarSize, false);
				list[5] = #YKe.#6ne(designReinforcementSidesDifferent2.MaxTopBottomBarSize, false);
				list[6] = #YKe.#6ne(designReinforcementSidesDifferent2.MinLeftRightBarSize, false);
				list[7] = #YKe.#6ne(designReinforcementSidesDifferent2.MaxLeftRightBarSize, false);
				list[8] = #YKe.#6ne(designReinforcementSidesDifferent2.TopBottomClearCover, true);
				list[10] = #YKe.#6ne(designReinforcementSidesDifferent2.LeftRightClearCover, true);
			}
			return #YKe.#VKe(list);
		}

		// Token: 0x06009380 RID: 37760 RVA: 0x00076185 File Offset: 0x00074385
		private string #pme(InvestigationDimensions #Sne)
		{
			return #YKe.#VKe(new List<string>
			{
				this.#6ne(#Sne.DimensionA, true),
				this.#6ne(#Sne.DimensionB, true)
			});
		}

		// Token: 0x06009381 RID: 37761 RVA: 0x001F6FEC File Offset: 0x001F51EC
		private string #qme(DesignDimensions #Tne)
		{
			return #YKe.#VKe(new List<string>
			{
				this.#6ne(#Tne.MinWidth, true),
				this.#6ne(#Tne.MinHeight, true),
				this.#6ne(#Tne.MaxWidth, true),
				this.#6ne(#Tne.MaxHeight, true),
				this.#6ne(#Tne.WidthIncrement, true),
				this.#6ne(#Tne.HeightIncrement, true)
			});
		}

		// Token: 0x06009382 RID: 37762 RVA: 0x001F7094 File Offset: 0x001F5294
		private string #rme(MaterialProperties #Une)
		{
			return #YKe.#VKe(new List<string>
			{
				this.#6ne(#Une.Fcp, true),
				this.#6ne(#Une.Ec, true),
				this.#6ne(#Une.Fc, true),
				this.#6ne(#Une.Beta1, true),
				this.#6ne(#Une.Eps, true),
				this.#6ne(#Une.Fy, true),
				this.#6ne(#Une.Es, true),
				this.#6ne(#Une.Precast, false),
				this.#6ne(#Une.IsConcreteStandard, false),
				this.#6ne(#Une.IsSteelStandard, false),
				this.#6ne(#Une.Eyt, true)
			});
		}

		// Token: 0x06009383 RID: 37763 RVA: 0x001F71B4 File Offset: 0x001F53B4
		private string #sme(ReductionFactors #Vne)
		{
			return #YKe.#VKe(new List<string>
			{
				this.#6ne(#Vne.A, true),
				this.#6ne(#Vne.B, true),
				this.#6ne(#Vne.C, true),
				this.#6ne(#Vne.Trans, true),
				this.#6ne(#Vne.MinDimension, true)
			});
		}

		// Token: 0x06009384 RID: 37764 RVA: 0x001F7244 File Offset: 0x001F5444
		private string #ume(ColumnStorageModel #Od)
		{
			return #YKe.#VKe(new List<string>
			{
				this.#6ne(#Od.ReinforcementRatios.MinReinforcementRatio, true),
				this.#6ne(#Od.ReinforcementRatios.MaxReinforcementRatio, true),
				this.#6ne(#Od.MinRebarClearSpacing, true),
				this.#6ne(#Od.DesignToRequiredRatio, true)
			});
		}

		// Token: 0x06009385 RID: 37765 RVA: 0x001F72C8 File Offset: 0x001F54C8
		private void #rHb(ref List<string> #Wne, List<Point> #BP)
		{
			#Wne.Add(this.#6ne(#BP.Count, false));
			foreach (Point point in #BP)
			{
				string item = this.#6ne(point.X, true) + #YKe.#a + this.#6ne(point.Y, true);
				#Wne.Add(item);
			}
		}

		// Token: 0x06009386 RID: 37766 RVA: 0x001F7360 File Offset: 0x001F5560
		private int #Xne(PolygonApplication #Wme)
		{
			CtiFormatSerialization.#HUb #HUb = new CtiFormatSerialization.#HUb();
			#HUb.#a = #Wme;
			IList<SectionPolygon> list;
			if (this.#a.Options.SectionType == SectionType.Irregular)
			{
				list = this.#a.Polygons;
			}
			else
			{
				SectionTypeDependentValuesCacheItem sectionTypeDependentValuesCacheItem = this.#a.SectionTypeCacheItems.FirstOrDefault(new Func<SectionTypeDependentValuesCacheItem, bool>(CtiFormatSerialization.<>c.<>9.#sbf));
				list = ((sectionTypeDependentValuesCacheItem != null) ? sectionTypeDependentValuesCacheItem.Polygons : null);
			}
			list = ((list != null) ? list.Where(new Func<SectionPolygon, bool>(#HUb.#tbf)).ToList<SectionPolygon>() : null);
			if (list == null || list.Count != 1)
			{
				return 0;
			}
			return list[0].Points.Count;
		}

		// Token: 0x06009387 RID: 37767 RVA: 0x001F7414 File Offset: 0x001F5614
		private void #xme(ref List<string> #Wne, List<ReinforcementBar> #KJ)
		{
			#Wne.Add(this.#6ne(#KJ.Count, false));
			foreach (ReinforcementBar reinforcementBar in #KJ)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(this.#6ne(reinforcementBar.Area, true));
				stringBuilder.Append(#YKe.#a);
				stringBuilder.Append(this.#6ne(reinforcementBar.X, true));
				stringBuilder.Append(#YKe.#a);
				stringBuilder.Append(this.#6ne(reinforcementBar.Y, true));
				#Wne.Add(stringBuilder.ToString());
			}
		}

		// Token: 0x06009388 RID: 37768 RVA: 0x001F74F0 File Offset: 0x001F56F0
		private void #Yne(ref List<string> #Wne, List<AxialLoad> #tk)
		{
			#Wne.Add(this.#6ne(#tk.Count, false));
			foreach (AxialLoad axialLoad in #tk)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(this.#6ne(axialLoad.InitialLoad, true));
				stringBuilder.Append(#YKe.#a);
				stringBuilder.Append(this.#6ne(axialLoad.FinalLoad, true));
				stringBuilder.Append(#YKe.#a);
				stringBuilder.Append(this.#6ne(axialLoad.Increment, true));
				#Wne.Add(stringBuilder.ToString());
			}
		}

		// Token: 0x06009389 RID: 37769 RVA: 0x001F75CC File Offset: 0x001F57CC
		private void #yme(ref List<string> #Wne, List<FactoredLoad> #tk)
		{
			#Wne.Add(this.#6ne(#tk.Count, false));
			foreach (FactoredLoad factoredLoad in #tk)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(this.#6ne(factoredLoad.AxialLoad, true));
				stringBuilder.Append(#YKe.#a);
				stringBuilder.Append(this.#6ne(factoredLoad.MomentX, true));
				stringBuilder.Append(#YKe.#a);
				stringBuilder.Append(this.#6ne(factoredLoad.MomentY, true));
				#Wne.Add(stringBuilder.ToString());
			}
		}

		// Token: 0x0600938A RID: 37770 RVA: 0x000761C1 File Offset: 0x000743C1
		private string #zme(ColumnStorageModel #Od)
		{
			return this.#Zne(#Od.DesignedColumnX) + Environment.NewLine + this.#Zne(#Od.DesignedColumnY);
		}

		// Token: 0x0600938B RID: 37771 RVA: 0x001F76A8 File Offset: 0x001F58A8
		private string #Zne(SlendernessOfDesignedColumn #0ne)
		{
			return #YKe.#VKe(new List<string>
			{
				this.#6ne(#0ne.Height, true),
				this.#6ne(#0ne.Kbraced, true),
				this.#6ne(#0ne.Ksway, true),
				this.#6ne(#0ne.IsBraced, false),
				this.#6ne(#0ne.Kmode, false),
				this.#6ne(#0ne.SumPc, true),
				this.#6ne(#0ne.SumPu, true),
				this.#6ne(#0ne.CheckSwayAtEndsOnly, false),
				this.#6ne((int)#0ne.EndCondition, false)
			});
		}

		// Token: 0x0600938C RID: 37772 RVA: 0x000761E5 File Offset: 0x000743E5
		private string #Ame(ColumnStorageModel #Od)
		{
			return this.#1ne(#Od.ColumnAbove) + Environment.NewLine + this.#1ne(#Od.ColumnBelow);
		}

		// Token: 0x0600938D RID: 37773 RVA: 0x001F7798 File Offset: 0x001F5998
		private string #1ne(SlendernessOfColumn #2ne)
		{
			return #YKe.#VKe(new List<string>
			{
				this.#6ne((int)#2ne.SlendernessColumnType, false),
				this.#6ne(#2ne.Height, true),
				this.#6ne(#2ne.Width, true),
				this.#6ne(#2ne.Depth, true),
				this.#6ne(#2ne.Fcp, true),
				this.#6ne(#2ne.Ec, true)
			});
		}

		// Token: 0x0600938E RID: 37774 RVA: 0x001F7840 File Offset: 0x001F5A40
		private string #Bme(ColumnStorageModel #Od)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(this.#3ne(#Od.BeamX.AboveLeft) + Environment.NewLine);
			stringBuilder.Append(this.#3ne(#Od.BeamX.AboveRight) + Environment.NewLine);
			stringBuilder.Append(this.#3ne(#Od.BeamX.BelowLeft) + Environment.NewLine);
			stringBuilder.Append(this.#3ne(#Od.BeamX.BelowRight) + Environment.NewLine);
			stringBuilder.Append(this.#3ne(#Od.BeamY.AboveLeft) + Environment.NewLine);
			stringBuilder.Append(this.#3ne(#Od.BeamY.AboveRight) + Environment.NewLine);
			stringBuilder.Append(this.#3ne(#Od.BeamY.BelowLeft) + Environment.NewLine);
			stringBuilder.Append(this.#3ne(#Od.BeamY.BelowRight));
			return stringBuilder.ToString();
		}

		// Token: 0x0600938F RID: 37775 RVA: 0x001F7960 File Offset: 0x001F5B60
		private string #3ne(Beam #Y6)
		{
			List<string> list = new List<string>();
			int num = this.#4ne(#Y6.BeamType);
			list.Add(this.#6ne(num, false));
			if (#Y6.BeamType != BeamType.Rigid)
			{
				list.Add(this.#6ne(#Y6.Length, true));
				list.Add(this.#6ne(#Y6.Width, true));
				list.Add(this.#6ne(#Y6.Depth, true));
				list.Add(this.#6ne(#Y6.MofI, true));
				list.Add(this.#6ne(#Y6.Fcp, true));
				list.Add(this.#6ne(#Y6.Ec, true));
			}
			else
			{
				list.Add(this.#6ne(0f, true));
				list.Add(this.#6ne(0f, true));
				list.Add(this.#6ne(0f, true));
				list.Add(this.#6ne(0f, true));
				list.Add(this.#6ne(0f, true));
				list.Add(this.#6ne(0f, true));
			}
			return #YKe.#VKe(list);
		}

		// Token: 0x06009390 RID: 37776 RVA: 0x00076209 File Offset: 0x00074409
		private int #4ne(BeamType #5ne)
		{
			if (#5ne == BeamType.Rectangular)
			{
				return 0;
			}
			if (#5ne != BeamType.Rigid)
			{
				return 1;
			}
			return 2;
		}

		// Token: 0x06009391 RID: 37777 RVA: 0x001F7AC4 File Offset: 0x001F5CC4
		private void #Eme(ref List<string> #Wne, List<ServiceLoad> #tk)
		{
			#Wne.Add(this.#6ne(#tk.Count, false));
			foreach (ServiceLoad serviceLoad in #tk)
			{
				List<string> #7me = serviceLoad.ToArray().Select(new Func<float, string>(this.#8ne)).ToList<string>();
				#Wne.Add(#YKe.#VKe(#7me));
			}
		}

		// Token: 0x06009392 RID: 37778 RVA: 0x001F7B4C File Offset: 0x001F5D4C
		private void #Fme(ref List<string> #Wne, List<LoadFactor> #tk)
		{
			#Wne.Add(this.#6ne(#tk.Count, false));
			foreach (LoadFactor loadFactor in #tk)
			{
				List<string> #7me = loadFactor.ToArray().Select(new Func<float, string>(this.#9ne)).ToList<string>();
				#Wne.Add(#YKe.#VKe(#7me));
			}
		}

		// Token: 0x06009393 RID: 37779 RVA: 0x001F7BD4 File Offset: 0x001F5DD4
		private void #Gme(ref List<string> #Wne, ColumnStorageModel #Od)
		{
			if (#Od.BarGroupType != BarGroupType.UserDefined)
			{
				return;
			}
			#Wne.Add(this.#6ne(#Od.Bars.Count, false));
			foreach (StandardBar standardBar in #Od.Bars)
			{
				string item = #YKe.#VKe(new List<string>
				{
					this.#6ne(standardBar.Size, false),
					this.#6ne(standardBar.Diameter, true),
					this.#6ne(standardBar.Area, true),
					this.#6ne(standardBar.Weight, true)
				});
				#Wne.Add(item);
			}
		}

		// Token: 0x06009394 RID: 37780 RVA: 0x001F7CC0 File Offset: 0x001F5EC0
		private string #P7(SustainedLoadFactors #ivb)
		{
			return #YKe.#VKe(new List<string>
			{
				this.#6ne(#ivb.Dead, true),
				this.#6ne(#ivb.Live, true),
				this.#6ne(#ivb.Wind, true),
				this.#6ne(#ivb.Earthquake, true),
				this.#6ne(#ivb.Snow, true)
			});
		}

		// Token: 0x06009395 RID: 37781 RVA: 0x0007621A File Offset: 0x0007441A
		private string #6ne(object #Vg, bool #7ne = false)
		{
			return #YKe.#6ne(#Vg, #7ne);
		}

		// Token: 0x06009396 RID: 37782 RVA: 0x00076223 File Offset: 0x00074423
		[CompilerGenerated]
		private string #8ne(float #9o)
		{
			return this.#6ne(#9o, true);
		}

		// Token: 0x06009397 RID: 37783 RVA: 0x00076223 File Offset: 0x00074423
		[CompilerGenerated]
		private string #9ne(float #9o)
		{
			return this.#6ne(#9o, true);
		}

		// Token: 0x04003EDA RID: 16090
		private readonly ColumnStorageModel #a;

		// Token: 0x020010FE RID: 4350
		[CompilerGenerated]
		private sealed class #HUb
		{
			// Token: 0x060093A7 RID: 37799 RVA: 0x000762A9 File Offset: 0x000744A9
			internal bool #tbf(SectionPolygon #9o)
			{
				return #9o.Application == this.#a;
			}

			// Token: 0x04003EE8 RID: 16104
			public PolygonApplication #a;
		}
	}
}
