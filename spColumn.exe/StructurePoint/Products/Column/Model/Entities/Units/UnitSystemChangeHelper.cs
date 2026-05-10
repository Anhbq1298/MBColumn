using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #3wb;
using #5Z;
using #7hc;
using #eU;
using #f7;
using #tFb;
using #Xc;
using #xKe;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Units;
using StructurePoint.CoreAssets.Units.UnitSets;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Viewports.API;

namespace StructurePoint.Products.Column.Model.Entities.Units
{
	// Token: 0x020003B6 RID: 950
	internal sealed class UnitSystemChangeHelper
	{
		// Token: 0x06002017 RID: 8215 RVA: 0x000C484C File Offset: 0x000C2A4C
		public UnitSystemChangeHelper(#oW projectContext, #vd dockingManager, #JFb barsParametersContext, ISettingsManager settings, #2wb templateService, #0V snappingCache)
		{
			if (projectContext == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107383985));
			}
			this.#a = projectContext;
			this.#b = dockingManager;
			this.#c = barsParametersContext;
			this.#d = settings;
			this.#e = templateService;
			this.#f = snappingCache;
		}

		// Token: 0x06002018 RID: 8216 RVA: 0x000C48A0 File Offset: 0x000C2AA0
		public void #z6(IUnit #A6, IUnit #B6)
		{
			if (#A6.UnitSymbol.Name == #B6.UnitSymbol.Name)
			{
				return;
			}
			foreach (IViewport viewport in this.#b.EditorViewports.Viewports)
			{
				IModelEditorViewport modelEditorViewport = viewport as IModelEditorViewport;
				if (modelEditorViewport != null)
				{
					modelEditorViewport.Editor.#WJb(#B6, #A6);
					modelEditorViewport.Renderer.#cg();
				}
			}
		}

		// Token: 0x06002019 RID: 8217 RVA: 0x000C494C File Offset: 0x000C2B4C
		public void #DY(UnitSystem #C6)
		{
			ColumnModel columnModel = this.#a.Model;
			ColumnModel columnModel2;
			if (4 != 0)
			{
				columnModel2 = columnModel;
			}
			UnitSystem unitSystem = columnModel2.Options.Unit;
			if (#C6 == unitSystem)
			{
				return;
			}
			IUnit unit = columnModel2.Units.Section.Width.Unit;
			UnitValueGroups #3r = (unitSystem == UnitSystem.SIMetric) ? columnModel2.MetricUnits : columnModel2.EnglishUnits;
			UnitValueGroups #4r = (#C6 == UnitSystem.SIMetric) ? columnModel2.MetricUnits : columnModel2.EnglishUnits;
			columnModel2.#DY(#C6);
			this.#H6(#3r, #4r);
			this.#I6(#3r, #4r);
			this.#J6(#3r, #4r);
			this.#M6(#3r, #4r);
			this.#E6(#3r, #4r, unitSystem, #C6);
			this.#D6(#3r, #4r);
			this.#16();
			#rLe #rLe = new #rLe();
			#rLe.#NQ(columnModel2.MaterialProperties, #C6, columnModel2.Options.Code);
			this.#e.#DY(unitSystem, #C6);
			this.#c.#eb(false);
			this.#c.#gFb(this.#a.Model.Options.Unit);
			this.#d.RuntimeSettings.Cover = this.#c.Cover;
			IUnit unit2 = this.#a.Model.Units.Section.Width.Unit;
			if (unit.UnitSymbol.Name != unit2.UnitSymbol.Name)
			{
				this.#z6(unit, unit2);
			}
			this.#f.#uP(this.#a);
		}

		// Token: 0x0600201A RID: 8218 RVA: 0x000C4AE8 File Offset: 0x000C2CE8
		private void #D6(UnitValueGroups #3r, UnitValueGroups #4r)
		{
			#j7 #j = this.#a.Model.DraftingSettings.DrawingGridSettings;
			#z7 #z = this.#a.Model.DraftingSettings.SnappingSettings;
			#j.SpacingX = (double)this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#Q5i), #j.SpacingX);
			#j.SpacingY = (double)this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#R5i), #j.SpacingY);
			#z.SnapSpacingX = (double)this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#S5i), #z.SnapSpacingX);
			#z.SnapSpacingY = (double)this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#T5i), #z.SnapSpacingY);
		}

		// Token: 0x0600201B RID: 8219 RVA: 0x000C4C10 File Offset: 0x000C2E10
		private void #E6(UnitValueGroups #3r, UnitValueGroups #4r, UnitSystem #F6, UnitSystem #G6)
		{
			foreach (SectionTypeDependentValuesCacheItem sectionTypeDependentValuesCacheItem in this.#a.Model.SectionTypeCacheItems)
			{
				#T1 #T = new #T1(sectionTypeDependentValuesCacheItem.InvestigationReinforcement);
				#Q1 #Q = new #Q1(sectionTypeDependentValuesCacheItem.InvestigationDimensions);
				this.#O6(#3r, #4r, #T, #Q);
				sectionTypeDependentValuesCacheItem.InvestigationReinforcement = #T.#CY();
				sectionTypeDependentValuesCacheItem.InvestigationDimensions = #Q.#CY();
				#k1 #k = new #k1(sectionTypeDependentValuesCacheItem.DesignReinforcement);
				#f1 #f = new #f1(sectionTypeDependentValuesCacheItem.DesignDimensions);
				this.#R6(#3r, #4r, #k, #f);
				sectionTypeDependentValuesCacheItem.DesignDimensions = #f.#CY();
				sectionTypeDependentValuesCacheItem.DesignReinforcement = #k.#CY();
				foreach (ReinforcementBar reinforcementBar in sectionTypeDependentValuesCacheItem.Bars)
				{
					reinforcementBar.Area = this.#Pb<AreaUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<AreaUnit>>(UnitSystemChangeHelper.<>c.<>9.#U5i), (double)reinforcementBar.Area);
					reinforcementBar.X = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#V5i), (double)reinforcementBar.X);
					reinforcementBar.Y = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#W5i), (double)reinforcementBar.Y);
					reinforcementBar.Z = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#X5i), (double)reinforcementBar.Z);
				}
				for (int i = 0; i < sectionTypeDependentValuesCacheItem.Polygons.Count; i++)
				{
					SectionPolygon sectionPolygon = sectionTypeDependentValuesCacheItem.Polygons[i];
					ShapeModel shapeModel = new ShapeModel(sectionPolygon);
					this.#N6(#3r, #4r, shapeModel);
					sectionPolygon = shapeModel.#CY();
					sectionTypeDependentValuesCacheItem.Polygons[i] = sectionPolygon;
				}
				TemplateData templateData = sectionTypeDependentValuesCacheItem.TemplateData;
				if (templateData != null && templateData.ParameterValues.Any<TemplateParameterValue>())
				{
					foreach (TemplateParameterValue #Zwb in sectionTypeDependentValuesCacheItem.TemplateData.ParameterValues)
					{
						this.#e.#Ywb(#F6, #G6, sectionTypeDependentValuesCacheItem.TemplateData.Definition, #Zwb);
					}
				}
			}
		}

		// Token: 0x0600201C RID: 8220 RVA: 0x000C4F10 File Offset: 0x000C3110
		private void #H6(UnitValueGroups #3r, UnitValueGroups #4r)
		{
			ColumnModel columnModel = this.#a.Model;
			bool flag = columnModel.Options.#h3();
			columnModel.MaterialProperties.Fcp = this.#Pb<ForcePerAreaUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<ForcePerAreaUnit>>(UnitSystemChangeHelper.<>c.<>9.#Y5i), (double)columnModel.MaterialProperties.Fcp);
			columnModel.MaterialProperties.Ec = this.#Pb<ForcePerAreaUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<ForcePerAreaUnit>>(UnitSystemChangeHelper.<>c.<>9.#Z5i), (double)columnModel.MaterialProperties.Ec);
			columnModel.MaterialProperties.Fc = this.#Pb<ForcePerAreaUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<ForcePerAreaUnit>>(UnitSystemChangeHelper.<>c.<>9.#05i), (double)columnModel.MaterialProperties.Fc);
			columnModel.MaterialProperties.Beta1 = this.#Pb<DimensionlessUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#15i), (double)columnModel.MaterialProperties.Beta1);
			columnModel.MaterialProperties.Eps = this.#Pb<DimensionlessUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#25i), (double)columnModel.MaterialProperties.Eps);
			columnModel.MaterialProperties.Fy = this.#Pb<ForcePerAreaUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<ForcePerAreaUnit>>(UnitSystemChangeHelper.<>c.<>9.#35i), (double)columnModel.MaterialProperties.Fy);
			columnModel.MaterialProperties.Es = this.#Pb<ForcePerAreaUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<ForcePerAreaUnit>>(UnitSystemChangeHelper.<>c.<>9.#45i), (double)columnModel.MaterialProperties.Es);
			columnModel.MaterialProperties.Eyt = this.#Pb<DimensionlessUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#55i), (double)columnModel.MaterialProperties.Eyt);
			if (!flag)
			{
				columnModel.ReductionFactors.A = this.#Pb<DimensionlessUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#65i), (double)columnModel.ReductionFactors.A);
				columnModel.ReductionFactors.B = this.#Pb<DimensionlessUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#75i), (double)columnModel.ReductionFactors.B);
				columnModel.ReductionFactors.C = this.#Pb<DimensionlessUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#85i), (double)columnModel.ReductionFactors.C);
			}
			else
			{
				columnModel.ReductionFactors.A = this.#Pb<DimensionlessUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#95i), (double)columnModel.ReductionFactors.A);
				columnModel.ReductionFactors.B = this.#Pb<DimensionlessUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#a6i), (double)columnModel.ReductionFactors.B);
				columnModel.ReductionFactors.C = this.#Pb<DimensionlessUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#b6i), (double)columnModel.ReductionFactors.C);
			}
			columnModel.ReductionFactors.MinDimension = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#c6i), (double)columnModel.ReductionFactors.MinDimension);
			columnModel.MinRebarClearSpacing = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#d6i), (double)columnModel.MinRebarClearSpacing);
			foreach (StandardBar standardBar in columnModel.Bars)
			{
				using (standardBar.#Y0())
				{
					standardBar.Diameter = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#e6i), (double)standardBar.Diameter);
					standardBar.Area = this.#Pb<AreaUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<AreaUnit>>(UnitSystemChangeHelper.<>c.<>9.#f6i), (double)standardBar.Area);
					standardBar.Weight = this.#Pb<MassPerLengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<MassPerLengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#g6i), (double)standardBar.Weight);
				}
			}
		}

		// Token: 0x0600201D RID: 8221 RVA: 0x000C5434 File Offset: 0x000C3634
		private void #I6(UnitValueGroups #3r, UnitValueGroups #4r)
		{
			ColumnModel columnModel = this.#a.Model;
			this.#T6(#3r, #4r, columnModel.DesignedColumnX);
			this.#T6(#3r, #4r, columnModel.DesignedColumnY);
			this.#V6(#3r, #4r, columnModel.ColumnAbove);
			this.#V6(#3r, #4r, columnModel.ColumnBelow);
			this.#X6(#3r, #4r, columnModel.BeamX.AboveLeft);
			this.#X6(#3r, #4r, columnModel.BeamX.AboveRight);
			this.#X6(#3r, #4r, columnModel.BeamX.BelowLeft);
			this.#X6(#3r, #4r, columnModel.BeamX.BelowRight);
			this.#X6(#3r, #4r, columnModel.BeamY.AboveLeft);
			this.#X6(#3r, #4r, columnModel.BeamY.AboveRight);
			this.#X6(#3r, #4r, columnModel.BeamY.BelowLeft);
			this.#X6(#3r, #4r, columnModel.BeamY.BelowRight);
			columnModel.StiffnessReductionFactorPhi = this.#Pb<DimensionlessUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#h6i), (double)columnModel.StiffnessReductionFactorPhi);
			columnModel.CrackedIBeams = this.#Pb<DimensionlessUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#i6i), (double)columnModel.CrackedIBeams);
			columnModel.CrackedIColumn = this.#Pb<DimensionlessUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#j6i), (double)columnModel.CrackedIColumn);
		}

		// Token: 0x0600201E RID: 8222 RVA: 0x000C55D8 File Offset: 0x000C37D8
		private void #J6(UnitValueGroups #3r, UnitValueGroups #4r)
		{
			UnitSystemChangeHelper.#BUb #BUb = new UnitSystemChangeHelper.#BUb();
			UnitSystemChangeHelper.#BUb #BUb2;
			if (!false)
			{
				#BUb2 = #BUb;
			}
			#BUb2.#a = this;
			#BUb2.#b = #3r;
			#BUb2.#c = #4r;
			ColumnModel columnModel = this.#a.Model;
			this.#L6(#BUb2.#b, #BUb2.#c);
			this.#K6(#BUb2.#b, #BUb2.#c);
			columnModel.ServiceLoads.ForEach(new Action<ServiceLoad>(#BUb2.#D4b));
			columnModel.SustainedLoadFactors.Dead = this.#Pb<DimensionlessUnit>(#BUb2.#b, #BUb2.#c, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#k6i), (double)columnModel.SustainedLoadFactors.Dead);
			columnModel.SustainedLoadFactors.Live = this.#Pb<DimensionlessUnit>(#BUb2.#b, #BUb2.#c, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#l6i), (double)columnModel.SustainedLoadFactors.Live);
			columnModel.SustainedLoadFactors.Wind = this.#Pb<DimensionlessUnit>(#BUb2.#b, #BUb2.#c, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#m6i), (double)columnModel.SustainedLoadFactors.Wind);
			columnModel.SustainedLoadFactors.Earthquake = this.#Pb<DimensionlessUnit>(#BUb2.#b, #BUb2.#c, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#n6i), (double)columnModel.SustainedLoadFactors.Earthquake);
			columnModel.SustainedLoadFactors.Snow = this.#Pb<DimensionlessUnit>(#BUb2.#b, #BUb2.#c, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#o6i), (double)columnModel.SustainedLoadFactors.Snow);
			columnModel.LoadFactors.ForEach(new Action<LoadFactor>(#BUb2.#E4b));
		}

		// Token: 0x0600201F RID: 8223 RVA: 0x000C57E8 File Offset: 0x000C39E8
		private void #K6(UnitValueGroups #3r, UnitValueGroups #4r)
		{
			UnitSystemChangeHelper.#61b #61b = new UnitSystemChangeHelper.#61b();
			#61b.#a = this;
			#61b.#b = #3r;
			#61b.#c = #4r;
			ColumnModel columnModel = this.#a.Model;
			columnModel.AxialLoads.ForEach(new Action<AxialLoad>(#61b.#F4b));
		}

		// Token: 0x06002020 RID: 8224 RVA: 0x000C5840 File Offset: 0x000C3A40
		private void #L6(UnitValueGroups #3r, UnitValueGroups #4r)
		{
			UnitSystemChangeHelper.#8Ub #8Ub = new UnitSystemChangeHelper.#8Ub();
			#8Ub.#a = this;
			#8Ub.#b = #3r;
			#8Ub.#c = #4r;
			ColumnModel columnModel = this.#a.Model;
			columnModel.FactoredLoads.ForEach(new Action<FactoredLoad>(#8Ub.#G4b));
		}

		// Token: 0x06002021 RID: 8225 RVA: 0x000C5898 File Offset: 0x000C3A98
		private void #M6(UnitValueGroups #3r, UnitValueGroups #4r)
		{
			ColumnModel columnModel = this.#a.Model;
			this.#O6(#3r, #4r);
			this.#R6(#3r, #4r);
			foreach (ReinforcementBar reinforcementBar in columnModel.ReinforcementBars)
			{
				reinforcementBar.Area = this.#Pb<AreaUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<AreaUnit>>(UnitSystemChangeHelper.<>c.<>9.#A6i), (double)reinforcementBar.Area);
				reinforcementBar.X = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#B6i), (double)reinforcementBar.X);
				reinforcementBar.Y = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#C6i), (double)reinforcementBar.Y);
				reinforcementBar.Z = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#D6i), (double)reinforcementBar.Z);
			}
			foreach (ShapeModel #JP in this.#a.Model.Shapes)
			{
				this.#N6(#3r, #4r, #JP);
			}
		}

		// Token: 0x06002022 RID: 8226 RVA: 0x000C5A44 File Offset: 0x000C3C44
		private void #N6(UnitValueGroups #3r, UnitValueGroups #4r, ShapeModel #JP)
		{
			foreach (PolygonData polygonData in #JP.Polygons)
			{
				List<Point3D> list = new List<Point3D>();
				for (int i = 0; i < polygonData.Points2DCount; i++)
				{
					Point3D item = polygonData.Points3D[i];
					item.X = (double)this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#E6i), item.X);
					item.Y = (double)this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#F6i), item.Y);
					list.Add(item);
				}
				polygonData.#dwc(list);
			}
		}

		// Token: 0x06002023 RID: 8227 RVA: 0x000C5B54 File Offset: 0x000C3D54
		private void #O6(UnitValueGroups #3r, UnitValueGroups #4r, #T1 #P6, #Q1 #Q6)
		{
			InvestigationReinforcementEqual investigationReinforcementEqual = #P6.AllEqual;
			#m2 #m = #P6.Different;
			#Q6.DimensionA = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#G6i), (double)#Q6.DimensionA);
			#Q6.DimensionB = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#H6i), (double)#Q6.DimensionB);
			investigationReinforcementEqual.ClearCover = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#I6i), (double)investigationReinforcementEqual.ClearCover);
			#m.TopClearCover = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#J6i), (double)#m.TopClearCover);
			#m.BottomClearCover = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#K6i), (double)#m.BottomClearCover);
			#m.LeftClearCover = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#L6i), (double)#m.LeftClearCover);
			#m.RightClearCover = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#M6i), (double)#m.RightClearCover);
		}

		// Token: 0x06002024 RID: 8228 RVA: 0x000C5D00 File Offset: 0x000C3F00
		private void #O6(UnitValueGroups #3r, UnitValueGroups #4r)
		{
			ColumnModel columnModel = this.#a.Model;
			this.#O6(#3r, #4r, columnModel.InvestigationReinforcement, columnModel.InvestigationDimensions);
		}

		// Token: 0x06002025 RID: 8229 RVA: 0x000C5D3C File Offset: 0x000C3F3C
		private void #R6(UnitValueGroups #3r, UnitValueGroups #4r, #k1 #P6, #f1 #Q6)
		{
			DesignReinforcementEqual designReinforcementEqual = #P6.AllEqual;
			DesignReinforcementEqual designReinforcementEqual2;
			if (8 != 0)
			{
				designReinforcementEqual2 = designReinforcementEqual;
			}
			#P1 #P7 = #P6.Different;
			#Q6.MinWidth = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#N6i), (double)#Q6.MinWidth);
			#Q6.MaxWidth = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#O6i), (double)#Q6.MaxWidth);
			#Q6.WidthIncrement = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#P6i), (double)#Q6.WidthIncrement);
			#Q6.MinHeight = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#Q6i), (double)#Q6.MinHeight);
			#Q6.MaxHeight = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#R6i), (double)#Q6.MaxHeight);
			#Q6.HeightIncrement = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#S6i), (double)#Q6.HeightIncrement);
			designReinforcementEqual2.ClearCover = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#T6i), (double)designReinforcementEqual2.ClearCover);
			#P7.LeftRightClearCover = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#U6i), (double)#P7.LeftRightClearCover);
			#P7.TopBottomClearCover = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#V6i), (double)#P7.TopBottomClearCover);
		}

		// Token: 0x06002026 RID: 8230 RVA: 0x000C5F58 File Offset: 0x000C4158
		private void #R6(UnitValueGroups #3r, UnitValueGroups #4r)
		{
			ColumnModel columnModel = this.#a.Model;
			this.#R6(#3r, #4r, columnModel.DesignReinforcement, columnModel.DesignDimensions);
		}

		// Token: 0x06002027 RID: 8231 RVA: 0x000C5F94 File Offset: 0x000C4194
		private void #S6(UnitValueGroups #3r, UnitValueGroups #4r, #V3 #rD)
		{
			#rD.AxialLoad = this.#Pb<ForceUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<ForceUnit>>(UnitSystemChangeHelper.<>c.<>9.#W6i), (double)#rD.AxialLoad);
			#rD.MomentXTop = this.#Pb<MomentUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<MomentUnit>>(UnitSystemChangeHelper.<>c.<>9.#X6i), (double)#rD.MomentXTop);
			#rD.MomentYTop = this.#Pb<MomentUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<MomentUnit>>(UnitSystemChangeHelper.<>c.<>9.#Y6i), (double)#rD.MomentYTop);
			#rD.MomentXBottom = this.#Pb<MomentUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<MomentUnit>>(UnitSystemChangeHelper.<>c.<>9.#Z6i), (double)#rD.MomentXBottom);
			#rD.MomentYBottom = this.#Pb<MomentUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<MomentUnit>>(UnitSystemChangeHelper.<>c.<>9.#06i), (double)#rD.MomentYBottom);
		}

		// Token: 0x06002028 RID: 8232 RVA: 0x000C60C4 File Offset: 0x000C42C4
		private void #T6(UnitValueGroups #3r, UnitValueGroups #4r, #X3 #U6)
		{
			#U6.Height = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#16i), (double)#U6.Height);
			#U6.SumPc = this.#Pb<DimensionlessUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#26i), (double)#U6.SumPc);
			#U6.SumPu = this.#Pb<DimensionlessUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#36i), (double)#U6.SumPu);
			#U6.SumPu = this.#Pb<DimensionlessUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#46i), (double)#U6.SumPu);
			#U6.Kbraced = this.#Pb<DimensionlessUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#56i), (double)#U6.Kbraced);
			#U6.Ksway = this.#Pb<DimensionlessUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#66i), (double)#U6.Ksway);
		}

		// Token: 0x06002029 RID: 8233 RVA: 0x000C6228 File Offset: 0x000C4428
		private void #V6(UnitValueGroups #3r, UnitValueGroups #4r, SlendernessOfColumn #W6)
		{
			#W6.Height = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#76i), (double)#W6.Height);
			#W6.Width = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#86i), (double)#W6.Width);
			#W6.Depth = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#96i), (double)#W6.Depth);
			#W6.Fcp = this.#Pb<ForcePerAreaUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<ForcePerAreaUnit>>(UnitSystemChangeHelper.<>c.<>9.#a7i), (double)#W6.Fcp);
			#W6.Ec = this.#Pb<ForcePerAreaUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<ForcePerAreaUnit>>(UnitSystemChangeHelper.<>c.<>9.#b7i), (double)#W6.Ec);
		}

		// Token: 0x0600202A RID: 8234 RVA: 0x000C6358 File Offset: 0x000C4558
		private void #X6(UnitValueGroups #3r, UnitValueGroups #4r, Beam #Y6)
		{
			#Y6.Length = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#c7i), (double)#Y6.Length);
			#Y6.Width = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#d7i), (double)#Y6.Width);
			#Y6.Depth = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(UnitSystemChangeHelper.<>c.<>9.#e7i), (double)#Y6.Depth);
			#Y6.Fcp = this.#Pb<ForcePerAreaUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<ForcePerAreaUnit>>(UnitSystemChangeHelper.<>c.<>9.#f7i), (double)#Y6.Fcp);
			#Y6.Ec = this.#Pb<ForcePerAreaUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<ForcePerAreaUnit>>(UnitSystemChangeHelper.<>c.<>9.#g7i), (double)#Y6.Ec);
			#Y6.MofI = this.#Pb<AreaMomentOfInertiaUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<AreaMomentOfInertiaUnit>>(UnitSystemChangeHelper.<>c.<>9.#h7i), (double)#Y6.MofI);
		}

		// Token: 0x0600202B RID: 8235 RVA: 0x000C64BC File Offset: 0x000C46BC
		private float #Pb<#06>(UnitValueGroups #3r, UnitValueGroups #4r, Func<UnitValueGroups, ColumnUnit<#06>> #Z6, double #c4) where #06 : struct, IComparable
		{
			ColumnUnit<#06> columnUnit = #Z6(#3r);
			ColumnUnit<#06> #b = #Z6(#4r);
			return (float)columnUnit.#a4(#b, #c4);
		}

		// Token: 0x0600202C RID: 8236 RVA: 0x000C64F0 File Offset: 0x000C46F0
		private void #16()
		{
			foreach (IModelEditorViewport modelEditorViewport in this.#b.EditorViewports.Viewports.OfType<IModelEditorViewport>())
			{
				modelEditorViewport.Editor.DynamicInput.Config.XValue.Unit = this.#a.Model.Units.Section.Width.Unit.UnitSymbol.Symbol;
				modelEditorViewport.Editor.DynamicInput.Config.YValue.Unit = this.#a.Model.Units.Section.Width.Unit.UnitSymbol.Symbol;
			}
		}

		// Token: 0x04000CBF RID: 3263
		private readonly #oW #a;

		// Token: 0x04000CC0 RID: 3264
		private readonly #vd #b;

		// Token: 0x04000CC1 RID: 3265
		private readonly #JFb #c;

		// Token: 0x04000CC2 RID: 3266
		private readonly ISettingsManager #d;

		// Token: 0x04000CC3 RID: 3267
		private readonly #2wb #e;

		// Token: 0x04000CC4 RID: 3268
		private readonly #0V #f;

		// Token: 0x020003B8 RID: 952
		[CompilerGenerated]
		private sealed class #BUb
		{
			// Token: 0x0600208A RID: 8330 RVA: 0x000C65F0 File Offset: 0x000C47F0
			internal void #D4b(ServiceLoad #ivb)
			{
				this.#a.#S6(this.#b, this.#c, #ivb.Dead);
				this.#a.#S6(this.#b, this.#c, #ivb.Live);
				this.#a.#S6(this.#b, this.#c, #ivb.Wind);
				this.#a.#S6(this.#b, this.#c, #ivb.Earthquake);
				this.#a.#S6(this.#b, this.#c, #ivb.Snow);
			}

			// Token: 0x0600208B RID: 8331 RVA: 0x000C66AC File Offset: 0x000C48AC
			internal void #E4b(LoadFactor #ivb)
			{
				#ivb.Dead = this.#a.#Pb<DimensionlessUnit>(this.#b, this.#c, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#p6i), (double)#ivb.Dead);
				#ivb.Live = this.#a.#Pb<DimensionlessUnit>(this.#b, this.#c, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#q6i), (double)#ivb.Live);
				#ivb.Wind = this.#a.#Pb<DimensionlessUnit>(this.#b, this.#c, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#r6i), (double)#ivb.Wind);
				#ivb.Earthquake = this.#a.#Pb<DimensionlessUnit>(this.#b, this.#c, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#s6i), (double)#ivb.Earthquake);
				#ivb.Snow = this.#a.#Pb<DimensionlessUnit>(this.#b, this.#c, new Func<UnitValueGroups, ColumnUnit<DimensionlessUnit>>(UnitSystemChangeHelper.<>c.<>9.#t6i), (double)#ivb.Snow);
			}

			// Token: 0x04000D20 RID: 3360
			public UnitSystemChangeHelper #a;

			// Token: 0x04000D21 RID: 3361
			public UnitValueGroups #b;

			// Token: 0x04000D22 RID: 3362
			public UnitValueGroups #c;
		}

		// Token: 0x020003B9 RID: 953
		[CompilerGenerated]
		private sealed class #61b
		{
			// Token: 0x0600208D RID: 8333 RVA: 0x000C6828 File Offset: 0x000C4A28
			internal void #F4b(AxialLoad #ivb)
			{
				#ivb.InitialLoad = this.#a.#Pb<ForceUnit>(this.#b, this.#c, new Func<UnitValueGroups, ColumnUnit<ForceUnit>>(UnitSystemChangeHelper.<>c.<>9.#u6i), (double)#ivb.InitialLoad);
				#ivb.FinalLoad = this.#a.#Pb<ForceUnit>(this.#b, this.#c, new Func<UnitValueGroups, ColumnUnit<ForceUnit>>(UnitSystemChangeHelper.<>c.<>9.#v6i), (double)#ivb.FinalLoad);
				#ivb.Increment = this.#a.#Pb<ForceUnit>(this.#b, this.#c, new Func<UnitValueGroups, ColumnUnit<ForceUnit>>(UnitSystemChangeHelper.<>c.<>9.#w6i), (double)#ivb.Increment);
			}

			// Token: 0x04000D23 RID: 3363
			public UnitSystemChangeHelper #a;

			// Token: 0x04000D24 RID: 3364
			public UnitValueGroups #b;

			// Token: 0x04000D25 RID: 3365
			public UnitValueGroups #c;
		}

		// Token: 0x020003BA RID: 954
		[CompilerGenerated]
		private sealed class #8Ub
		{
			// Token: 0x0600208F RID: 8335 RVA: 0x000C691C File Offset: 0x000C4B1C
			internal void #G4b(FactoredLoad #ivb)
			{
				#ivb.AxialLoad = this.#a.#Pb<ForceUnit>(this.#b, this.#c, new Func<UnitValueGroups, ColumnUnit<ForceUnit>>(UnitSystemChangeHelper.<>c.<>9.#x6i), (double)#ivb.AxialLoad);
				#ivb.MomentX = this.#a.#Pb<MomentUnit>(this.#b, this.#c, new Func<UnitValueGroups, ColumnUnit<MomentUnit>>(UnitSystemChangeHelper.<>c.<>9.#y6i), (double)#ivb.MomentX);
				#ivb.MomentY = this.#a.#Pb<MomentUnit>(this.#b, this.#c, new Func<UnitValueGroups, ColumnUnit<MomentUnit>>(UnitSystemChangeHelper.<>c.<>9.#z6i), (double)#ivb.MomentY);
			}

			// Token: 0x04000D26 RID: 3366
			public UnitSystemChangeHelper #a;

			// Token: 0x04000D27 RID: 3367
			public UnitValueGroups #b;

			// Token: 0x04000D28 RID: 3368
			public UnitValueGroups #c;
		}
	}
}
