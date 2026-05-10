using System;
using System.Drawing;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A9A RID: 2714
	public static class FastBitmapExtensions
	{
		// Token: 0x06005899 RID: 22681 RVA: 0x0004940C File Offset: 0x0004760C
		[CLSCompliant(false)]
		public static FastBitmap FastLock(this Bitmap bitmap)
		{
			FastBitmap fastBitmap = new FastBitmap(bitmap);
			fastBitmap.Lock();
			return fastBitmap;
		}

		// Token: 0x0600589A RID: 22682 RVA: 0x0004941F File Offset: 0x0004761F
		public static Bitmap DeepClone(this Bitmap bitmap)
		{
			return bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), bitmap.PixelFormat);
		}
	}
}
