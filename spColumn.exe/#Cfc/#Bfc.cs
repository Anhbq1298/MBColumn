using System;
using System.Runtime.InteropServices;

namespace #Cfc
{
	// Token: 0x02000715 RID: 1813
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct #Bfc
	{
		// Token: 0x04001AAF RID: 6831
		public uint #a;

		// Token: 0x04001AB0 RID: 6832
		public uint #b;

		// Token: 0x04001AB1 RID: 6833
		public uint #c;

		// Token: 0x04001AB2 RID: 6834
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
		public byte[] #d;
	}
}
