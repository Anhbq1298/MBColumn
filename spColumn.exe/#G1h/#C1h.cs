using System;
using netDxf.Units;
using StructurePoint.CoreAssets.DataExchange.ExternFormat;

namespace #G1h
{
	// Token: 0x02000791 RID: 1937
	internal static class #C1h
	{
		// Token: 0x06003E3D RID: 15933 RVA: 0x001201E0 File Offset: 0x0011E3E0
		public static ExternDrawingUnit #A1h(DrawingUnits #B1h)
		{
			ExternDrawingUnit result;
			if (true && !false && !Enum.TryParse<ExternDrawingUnit>(#B1h.ToString(), true, out result) && !false)
			{
				return ExternDrawingUnit.UnitLess;
			}
			return result;
		}
	}
}
