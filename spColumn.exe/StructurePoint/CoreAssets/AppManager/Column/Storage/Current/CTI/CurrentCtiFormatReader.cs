using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using #7hc;
using #coe;
using #Ine;
using #npe;
using #o1d;
using StructurePoint.CoreAssets.AppManager.Column.Helpers;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Other;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Units;

namespace StructurePoint.CoreAssets.AppManager.Column.Storage.Current.CTI
{
	// Token: 0x020010FA RID: 4346
	internal sealed class CurrentCtiFormatReader : #Hne
	{
		// Token: 0x06009355 RID: 37717 RVA: 0x00076124 File Offset: 0x00074324
		public CurrentCtiFormatReader(Stream stream) : base(stream)
		{
			stream.#i2d();
		}

		// Token: 0x06009356 RID: 37718 RVA: 0x001F497C File Offset: 0x001F2B7C
		public ColumnStorageModel #Cjc()
		{
			ColumnStorageModel columnStorageModel = new ColumnStorageModel();
			columnStorageModel.ProjectInfo = new ProjectInfo();
			columnStorageModel.ProjectInfo.FileVersion = base.#9le(#Phc.#3hc(107290874));
			columnStorageModel.ProjectInfo.Project = base.#Vle(#Phc.#3hc(107290907));
			columnStorageModel.ProjectInfo.ColumnId = base.#Vle(#Phc.#3hc(107290350));
			columnStorageModel.ProjectInfo.Engineer = base.#Vle(#Phc.#3hc(107290365));
			columnStorageModel.InvestigateInputFlag = (int)base.#7le(#Phc.#3hc(107290316));
			columnStorageModel.DesignInputFlag = (int)base.#7le(#Phc.#3hc(107290283));
			columnStorageModel.SlendernessInputFlag = (int)base.#7le(#Phc.#3hc(107290290));
			columnStorageModel.Options = this.#jme(#Phc.#3hc(107290265));
			columnStorageModel.IrregularOptions = this.#lme(#Phc.#3hc(107290212));
			columnStorageModel.Ties = this.#mme(#Phc.#3hc(107290183));
			columnStorageModel.InvestigationReinforcement = this.#nme(#Phc.#3hc(107290206), columnStorageModel);
			columnStorageModel.DesignReinforcement = this.#ome(#Phc.#3hc(107290165), columnStorageModel);
			columnStorageModel.InvestigationDimensions = this.#pme(#Phc.#3hc(107290132));
			columnStorageModel.DesignDimensions = this.#qme(#Phc.#3hc(107290563));
			columnStorageModel.MaterialProperties = this.#rme(#Phc.#3hc(107290558));
			columnStorageModel.ReductionFactors = this.#sme(#Phc.#3hc(107290497));
			float[] array = this.#ume(#Phc.#3hc(107290468));
			columnStorageModel.ReinforcementRatios = new ReinforcementRatios(array[0], array[1]);
			columnStorageModel.MinRebarClearSpacing = array[2];
			columnStorageModel.DesignToRequiredRatio = array[3];
			columnStorageModel.Polygons = new List<SectionPolygon>();
			this.#Yme(columnStorageModel.Polygons, #Phc.#3hc(107290443), PolygonApplication.Solid);
			this.#Yme(columnStorageModel.Polygons, #Phc.#3hc(107290450), PolygonApplication.Opening);
			columnStorageModel.ReinforcementBars = this.#xme(#Phc.#3hc(107290425));
			List<FactoredLoad> list = this.#yme(#Phc.#3hc(107290396));
			columnStorageModel.FactoredLoads = new List<FactoredLoad>();
			columnStorageModel.AxialLoads = new List<AxialLoad>();
			if (columnStorageModel.Options.ActiveLoad == LoadType.Factored || columnStorageModel.Options.ActiveLoad != LoadType.Axial)
			{
				columnStorageModel.FactoredLoads = list;
			}
			if (columnStorageModel.Options.ActiveLoad == LoadType.Axial)
			{
				columnStorageModel.AxialLoads = list.Select(new Func<FactoredLoad, AxialLoad>(CurrentCtiFormatReader.<>c.<>9.#jbf)).ToList<AxialLoad>();
			}
			SlendernessOfDesignedColumn[] array2 = this.#zme(#Phc.#3hc(107289827));
			columnStorageModel.DesignedColumnX = array2[0];
			columnStorageModel.DesignedColumnY = array2[1];
			SlendernessOfColumn[] array3 = this.#Ame(columnStorageModel, #Phc.#3hc(107289798));
			columnStorageModel.ColumnAbove = array3[0];
			columnStorageModel.ColumnBelow = array3[1];
			SlendernessOfBeams[] array4 = this.#Bme(columnStorageModel, #Phc.#3hc(107289777));
			columnStorageModel.BeamX = array4[0];
			columnStorageModel.BeamY = array4[1];
			float[] array5 = this.#Cme(#Phc.#3hc(107289748));
			columnStorageModel.StiffnessX = array5[0];
			columnStorageModel.SlendernessOptFactor = base.#7le(#Phc.#3hc(107289707));
			columnStorageModel.StiffnessReductionFactorPhi = base.#9le(#Phc.#3hc(107289722));
			float[] array6 = this.#Dme(#Phc.#3hc(107290951));
			columnStorageModel.CrackedIBeams = array6[0];
			columnStorageModel.CrackedIColumn = array6[1];
			columnStorageModel.ServiceLoads = this.#Eme(#Phc.#3hc(107290917));
			columnStorageModel.LoadFactors = this.#Fme(#Phc.#3hc(107289673));
			columnStorageModel.BarGroupType = #yhe.#Pb<BarGroupType>(base.#2le(base.#Vle(#Phc.#3hc(107289644))));
			this.#Gme(#Phc.#3hc(107289655), columnStorageModel);
			columnStorageModel.SustainedLoadFactors = this.#P7(#Phc.#3hc(107289626));
			columnStorageModel.DraftingSettings = DraftingSettings.Default(columnStorageModel.Options.Unit);
			this.#Kne(columnStorageModel);
			return columnStorageModel;
		}

		// Token: 0x06009357 RID: 37719 RVA: 0x001F4D8C File Offset: 0x001F2F8C
		private void #Kne(ColumnStorageModel #Od)
		{
			if (#Od.Options.ProblemType == ProblemType.Investigation && (#Od.Options.SectionType == SectionType.Circle || #Od.Options.SectionType == SectionType.Rectangle) && (#Od.Polygons.Any<SectionPolygon>() || #Od.ReinforcementBars.Any<ReinforcementBar>()))
			{
				SectionTypeDependentValuesCacheItem item = new SectionTypeDependentValuesCacheItem
				{
					ProblemType = ProblemType.Investigation,
					SectionOnly = true,
					Polygons = #Od.Polygons.ToList<SectionPolygon>(),
					Bars = #Od.ReinforcementBars.ToList<ReinforcementBar>(),
					SectionType = SectionType.Irregular,
					InvestigationReinforcementType = ReinforcementType.Irregular
				};
				#Od.SectionTypeCacheItems.Add(item);
				#Od.Polygons.Clear();
				#Od.ReinforcementBars.Clear();
			}
		}

		// Token: 0x06009358 RID: 37720 RVA: 0x001F4E48 File Offset: 0x001F3048
		private void #Yme(List<SectionPolygon> #yP, string #Wle, PolygonApplication #Wme)
		{
			int num = base.#8le(#Wle);
			for (int i = 0; i < num; i++)
			{
				SectionPolygon sectionPolygon = new SectionPolygon();
				sectionPolygon.Application = #Wme;
				sectionPolygon.FigureType = PolygonFigureType.Irregural;
				#yP.Add(sectionPolygon);
				int num2 = base.#8le(#Wle);
				for (int j = 0; j < num2; j++)
				{
					float[] array = base.#Yle(#Wle);
					if (array.Length != 2)
					{
						throw new #goe(string.Format(#Phc.#3hc(107289272), base.LineCounter) + #Phc.#3hc(107289223).#z2d());
					}
					sectionPolygon.Points.Add(new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point(array[0], array[1]));
				}
				bool flag;
				try
				{
					flag = ColumnGeometryHelper.#1lc(sectionPolygon.Points.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, Point3D>(CurrentCtiFormatReader.<>c.<>9.#kbf)).ToList<Point3D>());
				}
				catch (Exception)
				{
					flag = false;
				}
				if (!flag)
				{
					throw new #goe(string.Format(#Phc.#3hc(107289166), i + 1));
				}
			}
		}

		// Token: 0x06009359 RID: 37721 RVA: 0x001F4F70 File Offset: 0x001F3170
		private Options #jme(string #kme)
		{
			string #Ztc = base.#Vle(#kme);
			string[] array = base.#Xle(#Ztc, new int?(27), #kme, null);
			Options options = new Options();
			options.ProblemType = #yhe.#Pb<ProblemType>((int)base.#0le(array[0]));
			options.Unit = #yhe.#Pb<UnitSystem>((int)base.#0le(array[1]));
			options.Code = #yhe.#Pb<DesignCodes>((int)base.#0le(array[2]));
			options.ConsideredAxis = #yhe.#Pb<ConsideredAxis>((int)base.#0le(array[3]));
			options.RedType = base.#0le(array[4]);
			options.ConsiderSlenderness = (base.#0le(array[5]) == 1);
			options.DesignTarget = #yhe.#Pb<DesignTarget>((int)Math.Min(base.#0le(array[6]), 1));
			options.SectionType = #yhe.#Pb<SectionType>((int)base.#0le(array[8]));
			options.ReinforcementLayout = #yhe.#Pb<ReinforcementLayout>((int)base.#0le(array[9]));
			options.ColumnType = #yhe.#Pb<ColumnType>((int)Math.Min(base.#0le(array[10]), 2));
			options.ConfinementType = #yhe.#Pb<ConfinementType>((int)base.#0le(array[11]));
			options.InvestigationLoad = #yhe.#Pb<LoadType>((int)base.#0le(array[12]));
			options.DesignLoad = #yhe.#Pb<LoadType>((int)base.#0le(array[13]));
			options.InvestigationReinforcement = #yhe.#Pb<ReinforcementType>((int)base.#0le(array[14]));
			options.DesignReinforcement = #yhe.#Pb<ReinforcementType>((int)base.#0le(array[15]));
			this.#b = base.#0le(array[16]);
			this.#c = base.#0le(array[17]);
			this.#d = base.#0le(array[18]);
			options.InvestigationClearCover = #yhe.#Pb<ClearCoverType>((int)base.#0le(array[23]));
			options.DesignClearCover = #yhe.#Pb<ClearCoverType>((int)base.#0le(array[24]));
			this.#e = base.#0le(array[25]);
			if (array.Length >= 27)
			{
				options.SectionCapacityMethod = #yhe.#Pb<SectionCapacityMethodType>((int)base.#0le(array[26]));
			}
			return options;
		}

		// Token: 0x0600935A RID: 37722 RVA: 0x001F5164 File Offset: 0x001F3364
		private IrregularOptions #lme(string #kme)
		{
			string[] array = base.#Zle(13, #kme);
			return new IrregularOptions
			{
				ViewFlag = #yhe.#Pb<ViewFlag>((int)base.#0le(array[0])),
				SectionFlag = #yhe.#Pb<SectionFlag>((int)base.#0le(array[1])),
				ReinforcementFlag = #yhe.#Pb<ReinforcementFlag>((int)base.#0le(array[2])),
				BarsToPlace = base.#0le(array[3]),
				BarArea = base.#3le(array[4]),
				DrawMax = new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point(base.#3le(array[5]), base.#3le(array[6])),
				DrawMin = new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point(base.#3le(array[7]), base.#3le(array[8])),
				GridSpc = new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point(base.#3le(array[9]), base.#3le(array[10])),
				Snap = new StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point(base.#3le(array[11]), base.#3le(array[12]))
			};
		}

		// Token: 0x0600935B RID: 37723 RVA: 0x001F5254 File Offset: 0x001F3454
		private Ties #mme(string #kme)
		{
			int #dTc = 3;
			string[] array = base.#Zle(#dTc, #kme);
			return new Ties
			{
				SmallTie = (int)base.#0le(array[0]),
				LargeTie = (int)base.#0le(array[1]),
				LongitudinalBar = (int)base.#0le(array[2])
			};
		}

		// Token: 0x0600935C RID: 37724 RVA: 0x001F52A0 File Offset: 0x001F34A0
		private InvestigationReinforcement #nme(string #kme, ColumnStorageModel #Od)
		{
			ReinforcementType investigationReinforcement = #Od.Options.InvestigationReinforcement;
			string #Ztc = base.#Vle(#kme);
			string[] array = base.#Xle(#Ztc, new int?(12), #kme, null);
			InvestigationReinforcementEqual allEqual = new InvestigationReinforcementEqual
			{
				NumberOfBars = base.#2le(array[0]),
				BarSize = base.#2le(array[4]),
				ClearCover = base.#3le(array[8])
			};
			InvestigationReinforcementSidesDifferent different = new InvestigationReinforcementSidesDifferent
			{
				TopNumberOfBars = base.#2le((investigationReinforcement == ReinforcementType.AllEqual || investigationReinforcement == ReinforcementType.EqualSpace) ? array[1] : array[0]),
				BottomNumberOfBars = base.#2le(array[1]),
				LeftNumberOfBars = base.#2le(array[2]),
				RightNumberOfBars = base.#2le(array[3]),
				TopBarSize = base.#2le(array[4]),
				BottomBarSize = base.#2le(array[5]),
				LeftBarSize = base.#2le(array[6]),
				RightBarSize = base.#2le(array[7]),
				TopClearCover = base.#3le(array[8]),
				BottomClearCover = base.#3le(array[9]),
				LeftClearCover = base.#3le(array[10]),
				RightClearCover = base.#3le(array[11])
			};
			return new InvestigationReinforcement
			{
				AllEqual = allEqual,
				Different = different
			};
		}

		// Token: 0x0600935D RID: 37725 RVA: 0x001F53EC File Offset: 0x001F35EC
		private DesignReinforcement #ome(string #kme, ColumnStorageModel #Od)
		{
			ReinforcementType designReinforcement = #Od.Options.DesignReinforcement;
			string #Ztc = base.#Vle(#kme);
			string[] array = base.#Xle(#Ztc, new int?(12), #kme, null);
			DesignReinforcementEqual designReinforcementEqual = new DesignReinforcementEqual();
			DesignReinforcementSidesDifferent designReinforcementSidesDifferent = new DesignReinforcementSidesDifferent();
			if (designReinforcement == ReinforcementType.AllEqual || designReinforcement == ReinforcementType.EqualSpace)
			{
				designReinforcementEqual.MinNumberOfBars = base.#2le(array[0]);
				designReinforcementEqual.MaxNumberOfBars = base.#2le(array[1]);
				designReinforcementEqual.MinBarSize = base.#2le(array[4]);
				designReinforcementEqual.MaxBarSize = base.#2le(array[5]);
				designReinforcementEqual.ClearCover = base.#3le(array[8]);
			}
			if (designReinforcement == ReinforcementType.Different)
			{
				designReinforcementSidesDifferent.MinTopBottomNumberOfBars = base.#2le(array[0]);
				designReinforcementSidesDifferent.MaxTopBottomNumberOfBars = base.#2le(array[1]);
				designReinforcementSidesDifferent.MinLeftRightNumberOfBars = base.#2le(array[2]);
				designReinforcementSidesDifferent.MaxLeftRightNumberOfBars = base.#2le(array[3]);
				designReinforcementSidesDifferent.MinTopBottomBarSize = base.#2le(array[4]);
				designReinforcementSidesDifferent.MaxTopBottomBarSize = base.#2le(array[5]);
				designReinforcementSidesDifferent.MinLeftRightBarSize = base.#2le(array[6]);
				designReinforcementSidesDifferent.MaxLeftRightBarSize = base.#2le(array[7]);
				designReinforcementSidesDifferent.TopBottomClearCover = base.#3le(array[8]);
				bool flag = designReinforcement == ReinforcementType.Different;
				designReinforcementSidesDifferent.LeftRightClearCover = (flag ? base.#3le(array[10]) : base.#3le(array[8]));
			}
			return new DesignReinforcement
			{
				AllEqual = designReinforcementEqual,
				Different = designReinforcementSidesDifferent
			};
		}

		// Token: 0x0600935E RID: 37726 RVA: 0x001F5558 File Offset: 0x001F3758
		private InvestigationDimensions #pme(string #kme)
		{
			int #dTc = 2;
			string[] array = base.#Zle(#dTc, #kme);
			return new InvestigationDimensions(new float[]
			{
				base.#3le(array[0]),
				base.#3le(array[1])
			});
		}

		// Token: 0x0600935F RID: 37727 RVA: 0x001F5594 File Offset: 0x001F3794
		private DesignDimensions #qme(string #kme)
		{
			int #dTc = 6;
			return new DesignDimensions(base.#Zle(#dTc, #kme).Select(new Func<string, float>(base.#3le)).ToArray<float>());
		}

		// Token: 0x06009360 RID: 37728 RVA: 0x001F55C8 File Offset: 0x001F37C8
		private MaterialProperties #rme(string #kme)
		{
			int #dTc = 11;
			string[] array = base.#Zle(#dTc, #kme);
			return new MaterialProperties
			{
				Fcp = base.#3le(array[0]),
				Ec = base.#3le(array[1]),
				Fc = base.#3le(array[2]),
				Beta1 = base.#3le(array[3]),
				Eps = base.#3le(array[4]),
				Fy = base.#3le(array[5]),
				Es = base.#3le(array[6]),
				Precast = (base.#2le(array[7]) != 0),
				IsConcreteStandard = (base.#2le(array[8]) != 0),
				IsSteelStandard = (base.#2le(array[9]) != 0),
				Eyt = base.#3le(array[10])
			};
		}

		// Token: 0x06009361 RID: 37729 RVA: 0x001F5698 File Offset: 0x001F3898
		private ReductionFactors #sme(string #kme)
		{
			int #dTc = 5;
			string[] array = base.#Zle(#dTc, #kme);
			return new ReductionFactors
			{
				A = base.#3le(array[0]),
				B = base.#3le(array[1]),
				C = base.#3le(array[2]),
				Trans = base.#3le(array[3]),
				MinDimension = base.#3le(array[4])
			};
		}

		// Token: 0x06009362 RID: 37730 RVA: 0x001F5700 File Offset: 0x001F3900
		private float[] #ume(string #kme)
		{
			int num = 4;
			string[] array = base.#Zle(num, #kme);
			float[] array2 = new float[num];
			for (int i = 0; i < num; i++)
			{
				array2[i] = base.#3le(array[i]);
			}
			return array2;
		}

		// Token: 0x06009363 RID: 37731 RVA: 0x001F5738 File Offset: 0x001F3938
		private List<ReinforcementBar> #xme(string #kme)
		{
			int #5le = 3;
			int num;
			float[,] array = base.#4le(#5le, out num, #kme);
			List<ReinforcementBar> list = new List<ReinforcementBar>();
			for (int i = 0; i < num; i++)
			{
				float area = array[i, 0];
				float x = array[i, 1];
				float y = array[i, 2];
				ReinforcementBar item = new ReinforcementBar(area, x, y, 0f);
				list.Add(item);
			}
			return list.Take((int)this.#b).ToList<ReinforcementBar>();
		}

		// Token: 0x06009364 RID: 37732 RVA: 0x001F57B4 File Offset: 0x001F39B4
		private List<FactoredLoad> #yme(string #kme)
		{
			int #5le = 3;
			int num;
			float[,] array = base.#4le(#5le, out num, #kme);
			List<FactoredLoad> list = new List<FactoredLoad>();
			for (int i = 0; i < num; i++)
			{
				float axialLoad = array[i, 0];
				float momentX = array[i, 1];
				float momentY = array[i, 2];
				FactoredLoad item = new FactoredLoad(axialLoad, momentX, momentY);
				list.Add(item);
			}
			return list.Take((int)this.#c).ToList<FactoredLoad>();
		}

		// Token: 0x06009365 RID: 37733 RVA: 0x001F582C File Offset: 0x001F3A2C
		private SlendernessOfDesignedColumn[] #zme(string #kme)
		{
			int num = 2;
			SlendernessOfDesignedColumn[] array = new SlendernessOfDesignedColumn[num];
			for (int i = 0; i < num; i++)
			{
				string[] array2 = base.#Zle(9, #kme);
				array[i] = new SlendernessOfDesignedColumn
				{
					Height = base.#3le(array2[0]),
					Kbraced = base.#3le(array2[1]),
					Ksway = base.#3le(array2[2]),
					IsBraced = ((byte)base.#2le(array2[3]) == 1),
					Kmode = (Kmode)((byte)base.#2le(array2[4])),
					SumPc = base.#3le(array2[5]),
					SumPu = base.#3le(array2[6]),
					CheckSwayAtEndsOnly = ((byte)base.#2le(array2[7]) == 1),
					EndCondition = #yhe.#Pb<EndConditionType>(base.#2le(array2[8]))
				};
			}
			return array;
		}

		// Token: 0x06009366 RID: 37734 RVA: 0x001F58FC File Offset: 0x001F3AFC
		private SlendernessOfColumn[] #Ame(ColumnStorageModel #Od, string #kme)
		{
			int #dTc = 6;
			int num = 2;
			SlendernessOfColumn[] array = new SlendernessOfColumn[num];
			BeamsCalculatorCore beamsCalculatorCore = new BeamsCalculatorCore(#Od.Options.Unit, #Od.Options.Code);
			for (int i = 0; i < num; i++)
			{
				string[] array2 = base.#Zle(#dTc, #kme);
				SlendernessColumnType type = #yhe.#Pb<SlendernessColumnType>((int)base.#0le(array2[0]));
				float height = base.#3le(array2[1]);
				float width = base.#3le(array2[2]);
				float depth = base.#3le(array2[3]);
				float fcp = base.#3le(array2[4]);
				float ec = base.#3le(array2[5]);
				SlendernessOfColumn slendernessOfColumn = new SlendernessOfColumn(type, height, width, depth, fcp, ec);
				slendernessOfColumn.IsConcreteStandard = beamsCalculatorCore.#qKe(slendernessOfColumn.Fcp, slendernessOfColumn.Ec);
				array[i] = slendernessOfColumn;
			}
			return array;
		}

		// Token: 0x06009367 RID: 37735 RVA: 0x001F59D0 File Offset: 0x001F3BD0
		private SlendernessOfBeams[] #Bme(ColumnStorageModel #Od, string #kme)
		{
			int #dTc = 7;
			int num = 2;
			SlendernessOfBeams[] array = new SlendernessOfBeams[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = new SlendernessOfBeams
				{
					AboveLeft = this.#Hme(#Od, #dTc, #kme),
					AboveRight = this.#Hme(#Od, #dTc, #kme),
					BelowLeft = this.#Hme(#Od, #dTc, #kme),
					BelowRight = this.#Hme(#Od, #dTc, #kme)
				};
			}
			return array;
		}

		// Token: 0x06009368 RID: 37736 RVA: 0x00076134 File Offset: 0x00074334
		private float[] #Cme(string #kme)
		{
			float[] array = new float[2];
			array[0] = base.#9le(#kme);
			return array;
		}

		// Token: 0x06009369 RID: 37737 RVA: 0x001F5A3C File Offset: 0x001F3C3C
		private float[] #Dme(string #kme)
		{
			string[] array = base.#Zle(2, #kme);
			return new float[]
			{
				base.#3le(array[0]),
				base.#3le(array[1])
			};
		}

		// Token: 0x0600936A RID: 37738 RVA: 0x001F5A70 File Offset: 0x001F3C70
		private List<ServiceLoad> #Eme(string #kme)
		{
			int num = 25;
			int num2;
			float[,] array = base.#4le(num, out num2, #kme);
			List<ServiceLoad> list = new List<ServiceLoad>();
			for (int i = 0; i < num2; i++)
			{
				float[] array2 = new float[num];
				for (int j = 0; j < num; j++)
				{
					array2[j] = array[i, j];
				}
				list.Add(new ServiceLoad(array2));
			}
			return list.Take((int)this.#d).ToList<ServiceLoad>();
		}

		// Token: 0x0600936B RID: 37739 RVA: 0x001F5AE8 File Offset: 0x001F3CE8
		private List<LoadFactor> #Fme(string #kme)
		{
			int num = 5;
			int num2;
			float[,] array = base.#4le(num, out num2, #kme);
			List<LoadFactor> list = new List<LoadFactor>();
			for (int i = 0; i < num2; i++)
			{
				float[] array2 = new float[num];
				for (int j = 0; j < num; j++)
				{
					array2[j] = array[i, j];
				}
				list.Add(new LoadFactor(array2));
			}
			return list.Take((int)this.#e).ToList<LoadFactor>();
		}

		// Token: 0x0600936C RID: 37740 RVA: 0x001F5B60 File Offset: 0x001F3D60
		private void #Gme(string #kme, ColumnStorageModel #Od)
		{
			#Od.Bars.Clear();
			if (#Od.BarGroupType != BarGroupType.UserDefined)
			{
				List<StandardBar> collection = #mpe.#bpe(#Od.BarGroupType, #Od.Options.Unit);
				#Od.Bars.AddRange(collection);
				return;
			}
			int #5le = 4;
			List<StandardBar> list = new List<StandardBar>();
			int num;
			float[,] array = base.#4le(#5le, out num, #kme);
			for (int i = 0; i < num; i++)
			{
				list.Add(new StandardBar
				{
					Size = (int)array[i, 0],
					Diameter = array[i, 1],
					Area = array[i, 2],
					Weight = array[i, 3]
				});
			}
			#Od.Bars.AddRange(list);
		}

		// Token: 0x0600936D RID: 37741 RVA: 0x001F5C28 File Offset: 0x001F3E28
		private SustainedLoadFactors #P7(string #kme)
		{
			float[] array = new float[5];
			List<string> list = base.#Zle(5, #kme).ToList<string>();
			for (int i = 0; i < 5; i++)
			{
				array[i] = base.#3le(list[i]);
			}
			return new SustainedLoadFactors(array);
		}

		// Token: 0x0600936E RID: 37742 RVA: 0x001F5C6C File Offset: 0x001F3E6C
		private Beam #Hme(ColumnStorageModel #Od, int #dTc, string #kme)
		{
			string[] array = base.#Zle(#dTc, #kme);
			BeamType beamType = this.#Lne(base.#0le(array[0]));
			if (beamType == BeamType.Rigid)
			{
				return new Beam(#Tai.#Sai());
			}
			Beam beam = new Beam
			{
				BeamType = beamType,
				Length = base.#3le(array[1]),
				Width = base.#3le(array[2]),
				Depth = base.#3le(array[3]),
				MofI = base.#3le(array[4]),
				Fcp = base.#3le(array[5]),
				Ec = base.#3le(array[6])
			};
			BeamsCalculatorCore beamsCalculatorCore = new BeamsCalculatorCore(#Od.Options.Unit, #Od.Options.Code);
			beam.IsConcreteStandard = beamsCalculatorCore.#qKe(beam.Fcp, beam.Ec);
			beam.IsInertiaStandard = beamsCalculatorCore.#sKe(beam.Depth, beam.Width, beam.MofI);
			return beam;
		}

		// Token: 0x0600936F RID: 37743 RVA: 0x00076146 File Offset: 0x00074346
		private BeamType #Lne(short #Mne)
		{
			if (#Mne == 0)
			{
				return BeamType.Rectangular;
			}
			if (#Mne != 2)
			{
				return BeamType.None;
			}
			return BeamType.Rigid;
		}

		// Token: 0x04003ED2 RID: 16082
		private const int #a = 1;

		// Token: 0x04003ED3 RID: 16083
		private short #b;

		// Token: 0x04003ED4 RID: 16084
		private short #c;

		// Token: 0x04003ED5 RID: 16085
		private short #d;

		// Token: 0x04003ED6 RID: 16086
		private short #e;
	}
}
