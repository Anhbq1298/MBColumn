using System;
using System.Collections.Generic;
using #qpb;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;
using StructurePoint.Products.Column.FailureSurface.ViewModels.Filtering;

namespace #Djb
{
	// Token: 0x02000420 RID: 1056
	internal static class #Gjb
	{
		// Token: 0x0600265A RID: 9818 RVA: 0x000D6470 File Offset: 0x000D4670
		public static List<NavigationComboItem> #Ejb(#Qpb #Fjb, #lte #Od, IEnumerable<GridDataRowCore> #Zgb)
		{
			List<NavigationComboItem> list = new List<NavigationComboItem>();
			if (#Od.Input.Options.ConsideredAxis != ConsideredAxis.Both)
			{
				return list;
			}
			foreach (GridDataRowCore row in #Zgb)
			{
				list.Add(new NavigationComboItem(#Fjb, row));
			}
			return list;
		}
	}
}
