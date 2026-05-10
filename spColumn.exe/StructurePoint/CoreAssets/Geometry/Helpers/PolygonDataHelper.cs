using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using Microsoft.SqlServer.Types;
using StructurePoint.CoreAssets.Geometry.Data;

namespace StructurePoint.CoreAssets.Geometry.Helpers
{
	// Token: 0x020007C1 RID: 1985
	public static class PolygonDataHelper
	{
		// Token: 0x06003FCB RID: 16331 RVA: 0x0012983C File Offset: 0x00127A3C
		public static string #Woc(PolygonData #JP)
		{
			if (3 == 0 || #JP == null)
			{
				return string.Empty;
			}
			SqlGeometry sqlGeometry = #JP.SqlGeometry;
			string text;
			if (sqlGeometry != null)
			{
				SqlChars sqlChars = sqlGeometry.STAsText();
				if (sqlChars == null)
				{
					text = null;
					goto IL_38;
				}
				SqlString sqlString = sqlChars.ToSqlString();
				if (2 != 0)
				{
					if (3 != 0)
					{
						text = sqlString.Value;
						goto IL_38;
					}
					goto IL_45;
				}
			}
			text = null;
			IL_38:
			string text2 = text;
			if (!\u0003.\u0004(text2))
			{
				return \u0010.\u0092(#Phc.#3hc(107367592), text2, #Phc.#3hc(107367575));
			}
			IL_45:
			return string.Empty;
		}

		// Token: 0x06003FCC RID: 16332 RVA: 0x001298E4 File Offset: 0x00127AE4
		public static string #Woc(IEnumerable<PolygonData> #yP)
		{
			if (#yP != null)
			{
				Func<PolygonData, string> selector;
				if ((selector = PolygonDataHelper.#2Ui.#a) == null)
				{
					selector = (PolygonDataHelper.#2Ui.#a = new Func<PolygonData, string>(PolygonDataHelper.#Woc));
				}
				List<string> list = #yP.Select(selector).Where(new Func<string, bool>(PolygonDataHelper.<>c.<>9.#Gxc)).ToList<string>();
				List<string> values;
				if (!false)
				{
					values = list;
				}
				if (!false && !false)
				{
					return string.Join(Environment.NewLine + #Phc.#3hc(107367530), values);
				}
			}
			return string.Empty;
		}

		// Token: 0x020007C2 RID: 1986
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x04001CE4 RID: 7396
			public static Func<PolygonData, string> #a;
		}
	}
}
