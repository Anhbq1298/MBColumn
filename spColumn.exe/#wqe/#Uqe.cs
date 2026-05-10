using System;
using System.Collections.Generic;
using System.Linq;
using #12e;
using #3ve;
using #6re;
using #7hc;
using #owe;
using #P6e;
using #Wse;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.GraphicalReport;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Geometry.Data;

namespace #wqe
{
	// Token: 0x0200115E RID: 4446
	internal sealed class #Uqe
	{
		// Token: 0x06009681 RID: 38529 RVA: 0x00077ED2 File Offset: 0x000760D2
		public #Uqe(#yse #tA, GeneralInformation #Vqe)
		{
			if (#tA == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107409344));
			}
			this.#a = #tA;
			this.#b = #Vqe;
		}

		// Token: 0x06009682 RID: 38530 RVA: 0x001FB950 File Offset: 0x001F9B50
		public #lte #ul(#Hqe #Pc)
		{
			#Pc.Configuration = (#Pc.Configuration ?? new #O6e());
			DesignEngine designEngine = #Pc.DesignEngine;
			ColumnStorageModel columnStorageModel = #Pc.Model;
			#lte #lte = new #lte
			{
				Input = columnStorageModel,
				IsReportSourceValid = true,
				Output = ((designEngine != null) ? designEngine.OutputModel : null),
				GeneralInfo = this.#b
			};
			#lte.TestOptions.TestMode = #Pc.TestMode;
			#lte.TestOptions.OriginalLoadType = #Pc.OriginalLoadType;
			#lte.Images.AddRange(#Pc.UserImages);
			#Vse #Vse = #lte.BasicProperties;
			if (designEngine != null && #lte.Output != null && #lte.Output.SolveCompleted)
			{
				#lte.FailureSurface = #2ve.#ul(columnStorageModel, designEngine);
				#Vse.GeomProperties = designEngine.GeometryProperties;
				#Vse.Bars = designEngine.OutputModel.ReinforcementBars.ToList<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>();
				if (columnStorageModel.Options.SectionType == SectionType.Rectangle || columnStorageModel.Options.SectionType == SectionType.Circle)
				{
					#Vse.DimensionA = designEngine.OutputModel.InvestigationDimensions[0];
					#Vse.DimensionB = designEngine.OutputModel.InvestigationDimensions[1];
				}
				else if (columnStorageModel.Options.SectionType == SectionType.Irregular)
				{
					#lte.BasicProperties.Polygons.AddRange(columnStorageModel.Polygons);
					BoundingBoxData boundingBoxData = SectionPreviewGenerator.#Gue(#lte, false);
					if (boundingBoxData != null)
					{
						#Vse.DimensionA = (float)boundingBoxData.Width;
						#Vse.DimensionB = (float)boundingBoxData.Height;
					}
					#lte.BasicProperties.Polygons.Clear();
				}
				#i5e #i5e = #lte.Output.Variables;
				#Vse.ReductionFactorA = #i5e.RedFactPhiA;
				#Vse.ReductionFactorB = #i5e.RedFactPhiB;
				#Vse.ReductionFactorC = #i5e.RedFactPhiC;
				#Vse.MinSectionDimension = #i5e.MinSectionDimension.GetValueOrDefault();
				#Vse.SlendernessProperties = designEngine.OutputModel.Slenderness;
				if (#Pc.ForcePlaceReinforcement && #Vse.Bars.Count <= 0)
				{
					#Pc.DesignEngine = new DesignEngine(columnStorageModel, #Pc.Configuration);
					designEngine.#tOe();
					designEngine.ReinforcementProperties.#YSe();
					#Vse.Bars = designEngine.RuntimeModel.ReinforcementBars.Bars.Take(designEngine.RuntimeModel.ReinforcementBars.NumberOfBars).ToList<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>();
				}
			}
			else
			{
				try
				{
					#Pc.DesignEngine = new DesignEngine(columnStorageModel, #Pc.Configuration);
					designEngine = #Pc.DesignEngine;
					designEngine.#tOe();
					designEngine.#uOe();
					designEngine.ReinforcementProperties.#YSe();
					#Vse.Bars = designEngine.RuntimeModel.ReinforcementBars.Bars.Take(designEngine.RuntimeModel.ReinforcementBars.NumberOfBars).ToList<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar>();
					#Vse.GeomProperties = designEngine.GeometryProperties;
					if (columnStorageModel.Options.ProblemType == ProblemType.Design)
					{
						#Vse.DimensionA = columnStorageModel.DesignDimensions.MinWidth;
						#Vse.DimensionB = columnStorageModel.DesignDimensions.MinHeight;
					}
					else
					{
						#Vse.DimensionA = columnStorageModel.InvestigationDimensions.DimensionA;
						#Vse.DimensionB = columnStorageModel.InvestigationDimensions.DimensionB;
					}
					#Vse.ReductionFactorA = designEngine.RuntimeModel.ReductionFactors.#E1e(designEngine.InputModel, designEngine.RuntimeModel, designEngine.CodeExpert);
					#Vse.ReductionFactorB = designEngine.RuntimeModel.ReductionFactors.B;
					#Vse.ReductionFactorC = designEngine.RuntimeModel.ReductionFactors.C;
					#Vse.MinSectionDimension = designEngine.RuntimeModel.ReductionFactors.MinDimension;
					#Vse.SlendernessProperties = new #K3e();
					#Vse.SlendernessProperties.SlendernessX.#mg(designEngine.RuntimeModel.SlendernessX);
					#Vse.SlendernessProperties.SlendernessY.#mg(designEngine.RuntimeModel.SlendernessY);
				}
				catch (Exception)
				{
					if (!#Pc.ModelHasValidationErrors)
					{
						throw;
					}
				}
			}
			List<Point3D> list;
			List<SectionPolygon> collection;
			SectionGeometryHelper.#BT(#lte.Input, #Vse.DimensionA, #Vse.DimensionB, out list, out collection, true);
			#Vse.Polygons.AddRange(collection);
			#zwe.#ywe(columnStorageModel.Options.Unit, #lte.GeneralInfo);
			if (#Pc.CreateDiagrams)
			{
				new ReportDiagramsHandler().#sAe(#Pc.Options, #lte, this.#a, designEngine);
			}
			return #lte;
		}

		// Token: 0x06009683 RID: 38531 RVA: 0x001FBDA4 File Offset: 0x001F9FA4
		public static bool #Tqe(ColumnStorageModel #X)
		{
			Options options = #X.Options;
			ReinforcementType reinforcementType = (options.ProblemType == ProblemType.Design) ? options.DesignReinforcement : options.InvestigationReinforcement;
			if (options.SectionType != SectionType.Rectangle || reinforcementType != ReinforcementType.Different)
			{
				return false;
			}
			if (options.ProblemType == ProblemType.Design)
			{
				return #X.DesignReinforcement.Different.MinLeftRightNumberOfBars >= 0;
			}
			return #X.InvestigationReinforcement.Different.LeftNumberOfBars >= 0 || #X.InvestigationReinforcement.Different.RightNumberOfBars >= 0;
		}

		// Token: 0x0400407F RID: 16511
		private readonly #yse #a;

		// Token: 0x04004080 RID: 16512
		private readonly GeneralInformation #b;
	}
}
