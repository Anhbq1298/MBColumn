using System;
using System.Collections.Generic;
using System.Drawing;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core
{
	// Token: 0x02000B1A RID: 2842
	public static class FontsCache
	{
		// Token: 0x06005D17 RID: 23831 RVA: 0x00175518 File Offset: 0x00173718
		public static Font GetOrCreate(string font, float size)
		{
			string key = string.Format(#Phc.#3hc(107420723), font, size);
			Font font2;
			if (!FontsCache.Cache.TryGetValue(key, out font2))
			{
				font2 = new Font(new FontFamily(font), size, FontStyle.Regular, GraphicsUnit.Point);
				FontsCache.Cache[key] = font2;
			}
			return font2;
		}

		// Token: 0x040026C9 RID: 9929
		private static readonly Dictionary<string, Font> Cache = new Dictionary<string, Font>();
	}
}
