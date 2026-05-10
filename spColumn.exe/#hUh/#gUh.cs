using System;
using System.Collections.Generic;
using System.Windows;
using #LQc;
using StructurePoint.CoreAssets.AppManager.Column.Storage.ImportExport;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;

namespace #hUh
{
	// Token: 0x0200020C RID: 524
	internal static class #gUh
	{
		// Token: 0x060011ED RID: 4589 RVA: 0x00013C16 File Offset: 0x00011E16
		public static bool #eUh(#8Sc #ls, IReadOnlyCollection<ServiceLoad> #xtf, Window #aR)
		{
			return #xtf.Count == 0 || #ls.#0Sc(#aR, Strings.StringExistingServiceLoadsWillBeDiscarded.#z2d()) == MessageBoxResult.OK;
		}

		// Token: 0x060011EE RID: 4590 RVA: 0x00013C42 File Offset: 0x00011E42
		public static bool #eUh(#8Sc #ls, IReadOnlyCollection<FactoredLoad> #fUh, Window #aR)
		{
			return #fUh.Count == 0 || #ls.#0Sc(#aR, Strings.StringExistingFactoredLoadsWillBeDiscarded.#z2d()) == MessageBoxResult.OK;
		}

		// Token: 0x060011EF RID: 4591 RVA: 0x00013C6E File Offset: 0x00011E6E
		public static bool #eUh(#8Sc #ls, ColumnModel #Od, LoadsImportType #8Q, Window #aR)
		{
			switch (#8Q)
			{
			case LoadsImportType.FactoredLoads:
			case LoadsImportType.ETABS:
				return #gUh.#eUh(#ls, #Od.FactoredLoads, #aR);
			case LoadsImportType.ServiceLoads:
				return #gUh.#eUh(#ls, #Od.ServiceLoads, #aR);
			default:
				return true;
			}
		}
	}
}
