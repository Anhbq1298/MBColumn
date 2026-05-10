using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using #7hc;
using #cme;
using #npe;
using #wje;
using #xKe;
using StructurePoint.CoreAssets.AppManager.Column.Helpers;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Other;
using StructurePoint.CoreAssets.Units;

namespace StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy.CTI
{
	// Token: 0x020010D5 RID: 4309
	internal sealed class LegacyCtiFormatReader : #bme
	{
		// Token: 0x0600928A RID: 37514 RVA: 0x00075B94 File Offset: 0x00073D94
		public LegacyCtiFormatReader(Stream stream) : base(stream)
		{
			stream.Position = 0L;
		}

		// Token: 0x0600928B RID: 37515 RVA: 0x001F0F08 File Offset: 0x001EF108
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
			columnStorageModel.MaterialProperties = this.#rme(#Phc.#3hc(107290558), columnStorageModel);
			columnStorageModel.ReductionFactors = this.#sme(#Phc.#3hc(107290497), columnStorageModel.ProjectInfo.FileVersion);
			float[] array = this.#ume(#Phc.#3hc(107290468), columnStorageModel.ProjectInfo.FileVersion);
			columnStorageModel.ReinforcementRatios = new ReinforcementRatios(array[0], array[1]);
			columnStorageModel.MinRebarClearSpacing = array[2];
			columnStorageModel.DesignToRequiredRatio = array[3];
			columnStorageModel.Polygons = new List<SectionPolygon>();
			List<Point> source = this.#vme(#Phc.#3hc(107290443));
			if (this.#d > 0 && source.Any<Point>())
			{
				columnStorageModel.Polygons.Add(new SectionPolygon
				{
					Application = PolygonApplication.Solid,
					FigureType = PolygonFigureType.Irregural
				});
				IEnumerable<Point> collection = source.Take(this.#d);
				columnStorageModel.Polygons.Last<SectionPolygon>().Points.AddRange(collection);
			}
			List<Point> source2 = this.#wme(#Phc.#3hc(107290450));
			if (this.#e > 0 && source2.Any<Point>())
			{
				columnStorageModel.Polygons.Add(new SectionPolygon
				{
					Application = PolygonApplication.Opening,
					FigureType = PolygonFigureType.Irregural
				});
				IEnumerable<Point> collection2 = source2.Take(this.#e);
				columnStorageModel.Polygons.Last<SectionPolygon>().Points.AddRange(collection2);
			}
			columnStorageModel.ReinforcementBars = this.#xme(#Phc.#3hc(107290425));
			columnStorageModel.FactoredLoads = new List<FactoredLoad>();
			columnStorageModel.AxialLoads = new List<AxialLoad>();
			if (columnStorageModel.Options.ActiveLoad == LoadType.Axial)
			{
				columnStorageModel.AxialLoads = this.#yme(#Phc.#3hc(107290396)).Select(new Func<FactoredLoad, AxialLoad>(LegacyCtiFormatReader.<>c.<>9.#Jme)).ToList<AxialLoad>();
			}
			else
			{
				columnStorageModel.FactoredLoads = this.#yme(#Phc.#3hc(107290396));
			}
			SlendernessOfDesignedColumn[] array2 = this.#zme(#Phc.#3hc(107289827), columnStorageModel.ProjectInfo.FileVersion);
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
			columnStorageModel.ServiceLoads = this.#Eme(#Phc.#3hc(107290917), columnStorageModel.ProjectInfo.FileVersion);
			columnStorageModel.LoadFactors = this.#Fme(#Phc.#3hc(107289673), columnStorageModel.ProjectInfo.FileVersion);
			columnStorageModel.BarGroupType = #yhe.#Pb<BarGroupType>(base.#2le(base.#Vle(#Phc.#3hc(107289644))));
			this.#Gme(#Phc.#3hc(107289655), columnStorageModel);
			columnStorageModel.SustainedLoadFactors = this.#P7(#Phc.#3hc(107289626), columnStorageModel.ProjectInfo.FileVersion);
			columnStorageModel.DraftingSettings = DraftingSettings.Default(columnStorageModel.Options.Unit);
			return columnStorageModel;
		}

		// Token: 0x0600928C RID: 37516 RVA: 0x001F13E8 File Offset: 0x001EF5E8
		private Options #jme(string #kme)
		{
			string #Ztc = base.#Vle(#kme);
			string[] array = base.#Xle(#Ztc, #kme);
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
			this.#a = base.#0le(array[16]);
			this.#b = base.#0le(array[17]);
			this.#c = base.#0le(array[18]);
			this.#d = (int)base.#0le(array[19]);
			this.#e = (int)base.#0le(array[20]);
			options.InvestigationClearCover = #yhe.#Pb<ClearCoverType>((int)base.#0le(array[23]));
			options.DesignClearCover = #yhe.#Pb<ClearCoverType>((int)base.#0le(array[24]));
			this.#f = base.#0le(array[25]);
			if (array.Length >= 27)
			{
				options.SectionCapacityMethod = #yhe.#Pb<SectionCapacityMethodType>((int)base.#0le(array[26]));
			}
			return options;
		}

		// Token: 0x0600928D RID: 37517 RVA: 0x001F15EC File Offset: 0x001EF7EC
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
				DrawMax = new Point(base.#3le(array[5]), base.#3le(array[6])),
				DrawMin = new Point(base.#3le(array[7]), base.#3le(array[8])),
				GridSpc = new Point(base.#3le(array[9]), base.#3le(array[10])),
				Snap = new Point(base.#3le(array[11]), base.#3le(array[12]))
			};
		}

		// Token: 0x0600928E RID: 37518 RVA: 0x001F16DC File Offset: 0x001EF8DC
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

		// Token: 0x0600928F RID: 37519 RVA: 0x001F1728 File Offset: 0x001EF928
		private InvestigationReinforcement #nme(string #kme, ColumnStorageModel #Od)
		{
			ReinforcementType investigationReinforcement = #Od.Options.InvestigationReinforcement;
			string[] array = #YKe.#WKe(base.#Vle(#kme));
			InvestigationReinforcementEqual allEqual = new InvestigationReinforcementEqual
			{
				NumberOfBars = #YKe.#2le(array[0]),
				BarSize = #YKe.#2le(array[4]),
				ClearCover = #YKe.#3le(array[8])
			};
			InvestigationReinforcementSidesDifferent different = new InvestigationReinforcementSidesDifferent
			{
				TopNumberOfBars = #YKe.#2le((investigationReinforcement == ReinforcementType.AllEqual || investigationReinforcement == ReinforcementType.EqualSpace) ? array[1] : array[0]),
				BottomNumberOfBars = #YKe.#2le(array[1]),
				LeftNumberOfBars = #YKe.#2le(array[2]),
				RightNumberOfBars = #YKe.#2le(array[3]),
				TopBarSize = #YKe.#2le(array[4]),
				BottomBarSize = #YKe.#2le(array[5]),
				LeftBarSize = #YKe.#2le(array[6]),
				RightBarSize = #YKe.#2le(array[7]),
				TopClearCover = #YKe.#3le(array[8]),
				BottomClearCover = #YKe.#3le(array[9]),
				LeftClearCover = #YKe.#3le(array[10]),
				RightClearCover = #YKe.#3le(array[11])
			};
			return new InvestigationReinforcement
			{
				AllEqual = allEqual,
				Different = different
			};
		}

		// Token: 0x06009290 RID: 37520 RVA: 0x001F1850 File Offset: 0x001EFA50
		private DesignReinforcement #ome(string #kme, ColumnStorageModel #Od)
		{
			ReinforcementType designReinforcement = #Od.Options.DesignReinforcement;
			string[] array = #YKe.#WKe(base.#Vle(#kme));
			DesignReinforcementEqual designReinforcementEqual = new DesignReinforcementEqual();
			DesignReinforcementSidesDifferent designReinforcementSidesDifferent = new DesignReinforcementSidesDifferent();
			if (designReinforcement == ReinforcementType.AllEqual || designReinforcement == ReinforcementType.EqualSpace)
			{
				designReinforcementEqual.MinNumberOfBars = #YKe.#2le(array[0]);
				designReinforcementEqual.MaxNumberOfBars = #YKe.#2le(array[1]);
				designReinforcementEqual.MinBarSize = #YKe.#2le(array[4]);
				designReinforcementEqual.MaxBarSize = #YKe.#2le(array[5]);
				designReinforcementEqual.ClearCover = #YKe.#3le(array[8]);
			}
			if (designReinforcement == ReinforcementType.Different)
			{
				designReinforcementSidesDifferent.MinTopBottomNumberOfBars = #YKe.#2le(array[0]);
				designReinforcementSidesDifferent.MaxTopBottomNumberOfBars = #YKe.#2le(array[1]);
				designReinforcementSidesDifferent.MinLeftRightNumberOfBars = #YKe.#2le(array[2]);
				designReinforcementSidesDifferent.MaxLeftRightNumberOfBars = #YKe.#2le(array[3]);
				designReinforcementSidesDifferent.MinTopBottomBarSize = #YKe.#2le(array[4]);
				designReinforcementSidesDifferent.MaxTopBottomBarSize = #YKe.#2le(array[5]);
				designReinforcementSidesDifferent.MinLeftRightBarSize = #YKe.#2le(array[6]);
				designReinforcementSidesDifferent.MaxLeftRightBarSize = #YKe.#2le(array[7]);
				designReinforcementSidesDifferent.TopBottomClearCover = #YKe.#3le(array[8]);
				bool flag = designReinforcement == ReinforcementType.Different;
				designReinforcementSidesDifferent.LeftRightClearCover = (flag ? #YKe.#3le(array[10]) : #YKe.#3le(array[8]));
			}
			return new DesignReinforcement
			{
				AllEqual = designReinforcementEqual,
				Different = designReinforcementSidesDifferent
			};
		}

		// Token: 0x06009291 RID: 37521 RVA: 0x001F198C File Offset: 0x001EFB8C
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

		// Token: 0x06009292 RID: 37522 RVA: 0x001F19C8 File Offset: 0x001EFBC8
		private DesignDimensions #qme(string #kme)
		{
			int #dTc = 6;
			return new DesignDimensions(base.#Zle(#dTc, #kme).Select(new Func<string, float>(base.#3le)).ToArray<float>());
		}

		// Token: 0x06009293 RID: 37523 RVA: 0x001F19FC File Offset: 0x001EFBFC
		private MaterialProperties #rme(string #kme, ColumnStorageModel #Od)
		{
			int #dTc = (#Od.ProjectInfo.FileVersion >= 5f) ? 11 : 8;
			string[] array = base.#Zle(#dTc, #kme);
			MaterialProperties materialProperties = new MaterialProperties();
			materialProperties.Fcp = base.#3le(array[0]);
			materialProperties.Ec = base.#3le(array[1]);
			materialProperties.Fc = base.#3le(array[2]);
			materialProperties.Beta1 = base.#3le(array[3]);
			materialProperties.Eps = base.#3le(array[4]);
			materialProperties.Fy = base.#3le(array[5]);
			materialProperties.Es = base.#3le(array[6]);
			materialProperties.Precast = (base.#2le(array[7]) != 0);
			if (#Od.ProjectInfo.FileVersion >= 5f)
			{
				materialProperties.IsConcreteStandard = (base.#2le(array[8]) != 0);
				materialProperties.IsSteelStandard = (base.#2le(array[9]) != 0);
				materialProperties.Eyt = base.#3le(array[10]);
			}
			else
			{
				Options options = #Od.Options;
				materialProperties.Eyt = #5je.#Lje(materialProperties.Fy, materialProperties.Es, options.IsACI());
				materialProperties.IsConcreteStandard = #5je.#Pje(materialProperties.Fc, materialProperties.Ec, materialProperties.Beta1, materialProperties.Eps, materialProperties.Fcp, (int)options.Code, (short)options.Unit);
				materialProperties.IsSteelStandard = #5je.#1je(materialProperties.Es, materialProperties.Eyt, materialProperties.Fy, (int)options.Code, (short)options.Unit);
			}
			return materialProperties;
		}

		// Token: 0x06009294 RID: 37524 RVA: 0x001F1B7C File Offset: 0x001EFD7C
		private ReductionFactors #sme(string #kme, float #tme)
		{
			int #dTc = (#tme >= 5.1f) ? 5 : 4;
			string[] array = base.#Zle(#dTc, #kme);
			ReductionFactors reductionFactors = new ReductionFactors();
			reductionFactors.A = base.#3le(array[0]);
			reductionFactors.B = base.#3le(array[1]);
			reductionFactors.C = base.#3le(array[2]);
			reductionFactors.Trans = base.#3le(array[3]);
			if (#tme >= 5.1f)
			{
				reductionFactors.MinDimension = base.#3le(array[4]);
			}
			return reductionFactors;
		}

		// Token: 0x06009295 RID: 37525 RVA: 0x001F1BFC File Offset: 0x001EFDFC
		private float[] #ume(string #kme, float #tme)
		{
			int num = 4;
			string[] array = base.#Zle(num, #kme);
			float[] array2 = new float[num];
			for (int i = 0; i < num; i++)
			{
				array2[i] = base.#3le(array[i]);
			}
			if (#tme <= 6f)
			{
				float num2 = array2[3];
				if ((double)Math.Abs(num2) < 0.001)
				{
					num2 = 1f;
				}
				array2[3] = 1f / num2;
			}
			return array2;
		}

		// Token: 0x06009296 RID: 37526 RVA: 0x001F1C68 File Offset: 0x001EFE68
		private List<Point> #vme(string #kme)
		{
			int #5le = 2;
			int num;
			float[,] array = base.#4le(#5le, out num, #kme);
			List<Point> list = new List<Point>();
			for (int i = 0; i < num; i++)
			{
				Point item = new Point(array[i, 0], array[i, 1]);
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06009297 RID: 37527 RVA: 0x001F1C68 File Offset: 0x001EFE68
		private List<Point> #wme(string #kme)
		{
			int #5le = 2;
			int num;
			float[,] array = base.#4le(#5le, out num, #kme);
			List<Point> list = new List<Point>();
			for (int i = 0; i < num; i++)
			{
				Point item = new Point(array[i, 0], array[i, 1]);
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06009298 RID: 37528 RVA: 0x001F1CBC File Offset: 0x001EFEBC
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
			return list.Take((int)this.#a).ToList<ReinforcementBar>();
		}

		// Token: 0x06009299 RID: 37529 RVA: 0x001F1D38 File Offset: 0x001EFF38
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
			return list.Take((int)this.#b).ToList<FactoredLoad>();
		}

		// Token: 0x0600929A RID: 37530 RVA: 0x001F1DB0 File Offset: 0x001EFFB0
		private SlendernessOfDesignedColumn[] #zme(string #kme, float #tme)
		{
			int num = 2;
			int #dTc = (#tme > 4.5f) ? 8 : 7;
			SlendernessOfDesignedColumn[] array = new SlendernessOfDesignedColumn[num];
			for (int i = 0; i < num; i++)
			{
				string[] array2 = base.#Zle(#dTc, #kme);
				array[i] = new SlendernessOfDesignedColumn
				{
					Height = base.#3le(array2[0]),
					Kbraced = base.#3le(array2[1]),
					Ksway = base.#3le(array2[2]),
					IsBraced = ((byte)base.#2le(array2[3]) == 1),
					Kmode = (Kmode)((byte)base.#2le(array2[4])),
					SumPc = base.#3le(array2[5]),
					SumPu = base.#3le(array2[6]),
					CheckSwayAtEndsOnly = (((#tme > 4.5f) ? ((byte)base.#2le(array2[7])) : 0) == 1)
				};
			}
			return array;
		}

		// Token: 0x0600929B RID: 37531 RVA: 0x001F1E8C File Offset: 0x001F008C
		private SlendernessOfColumn[] #Ame(ColumnStorageModel #Od, string #kme)
		{
			BeamsCalculatorCore beamsCalculatorCore = new BeamsCalculatorCore(#Od.Options.Unit, #Od.Options.Code);
			int #dTc = 6;
			int num = 2;
			SlendernessOfColumn[] array = new SlendernessOfColumn[num];
			for (int i = 0; i < num; i++)
			{
				string[] array2 = base.#Zle(#dTc, #kme);
				short nocol = base.#0le(array2[0]);
				float height = base.#3le(array2[1]);
				float width = base.#3le(array2[2]);
				float depth = base.#3le(array2[3]);
				float fcp = base.#3le(array2[4]);
				float ec = base.#3le(array2[5]);
				SlendernessOfColumn slendernessOfColumn = new SlendernessOfColumn(nocol, height, width, depth, fcp, ec);
				slendernessOfColumn.IsConcreteStandard = beamsCalculatorCore.#qKe(slendernessOfColumn.Fcp, slendernessOfColumn.Ec);
				array[i] = slendernessOfColumn;
			}
			return array;
		}

		// Token: 0x0600929C RID: 37532 RVA: 0x001F1F5C File Offset: 0x001F015C
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

		// Token: 0x0600929D RID: 37533 RVA: 0x00075BA5 File Offset: 0x00073DA5
		private float[] #Cme(string #kme)
		{
			float[] array = new float[2];
			array[0] = base.#9le(#kme);
			return array;
		}

		// Token: 0x0600929E RID: 37534 RVA: 0x001F1FC8 File Offset: 0x001F01C8
		private float[] #Dme(string #kme)
		{
			string[] array = base.#Zle(2, #kme);
			return new float[]
			{
				base.#3le(array[0]),
				base.#3le(array[1])
			};
		}

		// Token: 0x0600929F RID: 37535 RVA: 0x001F1FFC File Offset: 0x001F01FC
		private List<ServiceLoad> #Eme(string #kme, float #tme)
		{
			int num = (#tme > 4f) ? 25 : 20;
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
			return list.Take((int)this.#c).ToList<ServiceLoad>();
		}

		// Token: 0x060092A0 RID: 37536 RVA: 0x001F2080 File Offset: 0x001F0280
		private List<LoadFactor> #Fme(string #kme, float #tme)
		{
			int num = (#tme > 4f) ? 5 : 4;
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
			return list.Take((int)this.#f).ToList<LoadFactor>();
		}

		// Token: 0x060092A1 RID: 37537 RVA: 0x001F2100 File Offset: 0x001F0300
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

		// Token: 0x060092A2 RID: 37538 RVA: 0x001F21C8 File Offset: 0x001F03C8
		private SustainedLoadFactors #P7(string #kme, float #tme)
		{
			float[] array = new float[5];
			if (#tme <= 4.2f)
			{
				array[0] = 100f;
				array[1] = 0f;
				array[2] = 0f;
				array[3] = 0f;
				array[4] = 0f;
			}
			else
			{
				List<string> list = base.#Zle(5, #kme).ToList<string>();
				for (int i = 0; i < 5; i++)
				{
					array[i] = base.#3le(list[i]);
				}
			}
			return new SustainedLoadFactors(array);
		}

		// Token: 0x060092A3 RID: 37539 RVA: 0x001F2240 File Offset: 0x001F0440
		private Beam #Hme(ColumnStorageModel #Od, int #dTc, string #kme)
		{
			string[] array = base.#Zle(#dTc, #kme);
			Beam beam = new Beam
			{
				BeamType = ((base.#0le(array[0]) == 1) ? BeamType.None : BeamType.Rectangular),
				Length = base.#3le(array[1]),
				Width = base.#3le(array[2]),
				Depth = base.#3le(array[3]),
				MofI = base.#3le(array[4]),
				Fcp = base.#3le(array[5]),
				Ec = base.#3le(array[6])
			};
			BeamsCalculatorCore beamsCalculatorCore = new BeamsCalculatorCore(#Od.Options.Unit, #Od.Options.Code);
			beam.IsInertiaStandard = beamsCalculatorCore.#sKe(beam.Depth, beam.Width, beam.MofI);
			beam.IsConcreteStandard = beamsCalculatorCore.#qKe(beam.Fcp, beam.Ec);
			return beam;
		}

		// Token: 0x04003E50 RID: 15952
		private short #a;

		// Token: 0x04003E51 RID: 15953
		private short #b;

		// Token: 0x04003E52 RID: 15954
		private short #c;

		// Token: 0x04003E53 RID: 15955
		private int #d;

		// Token: 0x04003E54 RID: 15956
		private int #e;

		// Token: 0x04003E55 RID: 15957
		private short #f;
	}
}
