using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using #7hc;

namespace #NBe
{
	// Token: 0x02001220 RID: 4640
	internal sealed class #cCe
	{
		// Token: 0x06009B58 RID: 39768 RVA: 0x002100FC File Offset: 0x0020E2FC
		public void #npb(Stream #gp, #2Be #5Be)
		{
			byte[] array = Encoding.ASCII.GetBytes(#Phc.#3hc(107283381));
			#gp.Write(array, 0, array.Length);
			array = BitConverter.GetBytes(#5Be.FileFormatVersion);
			#gp.Write(array, 0, array.Length);
			array = BitConverter.GetBytes(#5Be.ActiveAxis);
			#gp.Write(array, 0, array.Length);
			array = this.#aCe(#5Be.Data);
			#gp.Write(array, 0, array.Length);
		}

		// Token: 0x06009B59 RID: 39769 RVA: 0x00210170 File Offset: 0x0020E370
		private byte[] #aCe(#SBe #bCe)
		{
			int num = Marshal.SizeOf<#SBe>(#bCe);
			byte[] array = new byte[num];
			IntPtr intPtr = Marshal.AllocHGlobal(num);
			Marshal.StructureToPtr<#SBe>(#bCe, intPtr, true);
			Marshal.Copy(intPtr, array, 0, num);
			Marshal.FreeHGlobal(intPtr);
			return array;
		}
	}
}
