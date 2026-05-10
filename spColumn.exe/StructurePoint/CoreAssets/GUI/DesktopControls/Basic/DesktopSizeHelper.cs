using System;
using System.Drawing;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A94 RID: 2708
	public static class DesktopSizeHelper
	{
		// Token: 0x0600585A RID: 22618 RVA: 0x00169594 File Offset: 0x00167794
		public static StructurePoint.CoreAssets.Infrastructure.Data.Size Fit(StructurePoint.CoreAssets.Infrastructure.Data.Size availableSize, StructurePoint.CoreAssets.Infrastructure.Data.Size actualSize)
		{
			if (actualSize.Width > availableSize.Width || actualSize.Height > availableSize.Height)
			{
				double num = Math.Min(availableSize.Width / actualSize.Width, availableSize.Height / actualSize.Height);
				return new StructurePoint.CoreAssets.Infrastructure.Data.Size(actualSize.Width * num, actualSize.Height * num);
			}
			return actualSize;
		}

		// Token: 0x0600585B RID: 22619 RVA: 0x0016960C File Offset: 0x0016780C
		public static System.Drawing.Size Fit(System.Drawing.Size availableSize, System.Drawing.Size actualSize)
		{
			if (actualSize.Width > availableSize.Width || actualSize.Height > availableSize.Height || (actualSize.Height < availableSize.Height && actualSize.Width < availableSize.Width))
			{
				double num = Math.Min(1.0 * (double)availableSize.Width / (double)actualSize.Width, 1.0 * (double)availableSize.Height / (double)actualSize.Height);
				return new System.Drawing.Size((int)((double)actualSize.Width * num), (int)((double)actualSize.Height * num));
			}
			return actualSize;
		}
	}
}
