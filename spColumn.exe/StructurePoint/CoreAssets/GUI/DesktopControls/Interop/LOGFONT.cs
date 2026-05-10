using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Interop
{
	// Token: 0x02000995 RID: 2453
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public sealed class LOGFONT
	{
		// Token: 0x06004FC1 RID: 20417 RVA: 0x0004291E File Offset: 0x00040B1E
		public Font ToFont()
		{
			return Font.FromLogFont(this);
		}

		// Token: 0x0400232A RID: 9002
		public int lfHeight;

		// Token: 0x0400232B RID: 9003
		public int lfWidth;

		// Token: 0x0400232C RID: 9004
		public int lfEscapement;

		// Token: 0x0400232D RID: 9005
		public int lfOrientation;

		// Token: 0x0400232E RID: 9006
		public FontWeight lfWeight;

		// Token: 0x0400232F RID: 9007
		[MarshalAs(UnmanagedType.U1)]
		public bool lfItalic;

		// Token: 0x04002330 RID: 9008
		[MarshalAs(UnmanagedType.U1)]
		public bool lfUnderline;

		// Token: 0x04002331 RID: 9009
		[MarshalAs(UnmanagedType.U1)]
		public bool lfStrikeOut;

		// Token: 0x04002332 RID: 9010
		public FontCharSet lfCharSet;

		// Token: 0x04002333 RID: 9011
		public FontPrecision lfOutPrecision;

		// Token: 0x04002334 RID: 9012
		public FontClipPrecision lfClipPrecision;

		// Token: 0x04002335 RID: 9013
		public FontQuality lfQuality;

		// Token: 0x04002336 RID: 9014
		public FontPitchAndFamily lfPitchAndFamily;

		// Token: 0x04002337 RID: 9015
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string lfFaceName;
	}
}
