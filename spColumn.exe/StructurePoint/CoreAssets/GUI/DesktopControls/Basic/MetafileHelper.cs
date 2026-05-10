using System;
using System.Drawing.Imaging;
using Vanara.PInvoke;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AA1 RID: 2721
	public static class MetafileHelper
	{
		// Token: 0x060058CE RID: 22734 RVA: 0x0016AEBC File Offset: 0x001690BC
		public static bool PutEnhMetafileOnClipboard(IntPtr handle, Metafile metafile)
		{
			bool result = false;
			IntPtr henhmetafile = metafile.GetHenhmetafile();
			if (!henhmetafile.Equals(IntPtr.Zero))
			{
				Gdi32.SafeHENHMETAFILE safeHENHMETAFILE = Gdi32.CopyEnhMetaFile(henhmetafile, null);
				if (!safeHENHMETAFILE.IsInvalid && !safeHENHMETAFILE.IsNull && User32.OpenClipboard(handle) && User32.EmptyClipboard())
				{
					result = User32.SetClipboardData(14U, safeHENHMETAFILE.DangerousGetHandle()).Equals(safeHENHMETAFILE.DangerousGetHandle());
					User32.CloseClipboard();
				}
				Gdi32.DeleteEnhMetaFile(henhmetafile);
			}
			return result;
		}
	}
}
