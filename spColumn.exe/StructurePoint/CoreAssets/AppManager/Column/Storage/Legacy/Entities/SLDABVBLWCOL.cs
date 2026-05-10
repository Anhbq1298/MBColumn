using System;
using System.Runtime.InteropServices;

namespace StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy.Entities
{
	// Token: 0x020010CD RID: 4301
	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	internal struct SLDABVBLWCOL
	{
		// Token: 0x04003E09 RID: 15881
		public short #a;

		// Token: 0x04003E0A RID: 15882
		public float #b;

		// Token: 0x04003E0B RID: 15883
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public float[] #c;

		// Token: 0x04003E0C RID: 15884
		public float #d;

		// Token: 0x04003E0D RID: 15885
		public float #e;
	}
}
