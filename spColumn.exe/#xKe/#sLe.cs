using System;
using NetTopologySuite;
using NetTopologySuite.Geometries.Implementation;
using StructurePoint.CoreAssets.AppManager.Column.Helpers;

namespace #xKe
{
	// Token: 0x0200127C RID: 4732
	internal static class #sLe
	{
		// Token: 0x06009EB0 RID: 40624 RVA: 0x0021A6BC File Offset: 0x002188BC
		public static void #eb()
		{
			if (!#sLe.#b)
			{
				object obj = #sLe.#a;
				lock (obj)
				{
					if (!#sLe.#b)
					{
						NtsGeometryServices.Instance = new NtsGeometryServices(new PackedCoordinateSequenceFactory(PackedCoordinateSequenceFactory.PackedType.Double), ColumnGeometryHelper.#e, 0);
						#sLe.#b = true;
					}
				}
			}
		}

		// Token: 0x040044A5 RID: 17573
		private static readonly object #a = new object();

		// Token: 0x040044A6 RID: 17574
		private static bool #b;
	}
}
