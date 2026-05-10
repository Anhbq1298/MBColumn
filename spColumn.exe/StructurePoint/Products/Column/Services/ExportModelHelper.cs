using System;
using System.Collections.Generic;
using System.Linq;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.Products.Column.Services
{
	// Token: 0x0200028D RID: 653
	internal static class ExportModelHelper
	{
		// Token: 0x06001506 RID: 5382 RVA: 0x000B0EF8 File Offset: 0x000AF0F8
		public static ColumnStorageModel #bJ(ColumnStorageModel #Od, DesignEngine #rj)
		{
			if (#Od.Options.ProblemType == ProblemType.Investigation)
			{
				return #Od;
			}
			if (((#rj != null) ? #rj.OutputModel : null) == null || !#rj.OutputModel.SolveCompleted)
			{
				return #Od;
			}
			float num = #rj.OutputModel.InvestigationDimensions[0];
			float num2 = #rj.OutputModel.InvestigationDimensions[1];
			if (num <= 0f && num2 <= 0f)
			{
				return #Od;
			}
			List<Point3D> list;
			List<SectionPolygon> collection;
			SectionGeometryHelper.#BT(#Od, num, num2, out list, out collection, true);
			#Od.Polygons.Clear();
			#Od.Polygons.AddRange(collection);
			#Od.ReinforcementBars.Clear();
			#Od.ReinforcementBars.AddRange(#rj.OutputModel.ReinforcementBars.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.ReinforcementBar, StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.ReinforcementBar>(ExportModelHelper.<>c.<>9.#2Zb)));
			return #Od;
		}
	}
}
