using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace #Zjb
{
	// Token: 0x02000425 RID: 1061
	internal sealed class #5jb : NotifyPropertyChangedObjectBase
	{
		// Token: 0x060026A2 RID: 9890 RVA: 0x000244B7 File Offset: 0x000226B7
		public #5jb(string #oT, string #f, string #6jb)
		{
			this.Label = #oT;
			this.Value = #f;
			this.Unit = #6jb;
		}

		// Token: 0x17000D0D RID: 3341
		// (get) Token: 0x060026A3 RID: 9891 RVA: 0x000244D4 File Offset: 0x000226D4
		// (set) Token: 0x060026A4 RID: 9892 RVA: 0x000244E0 File Offset: 0x000226E0
		public string Label { get; set; }

		// Token: 0x17000D0E RID: 3342
		// (get) Token: 0x060026A5 RID: 9893 RVA: 0x000244F1 File Offset: 0x000226F1
		// (set) Token: 0x060026A6 RID: 9894 RVA: 0x000244FD File Offset: 0x000226FD
		public string Unit { get; set; }

		// Token: 0x17000D0F RID: 3343
		// (get) Token: 0x060026A7 RID: 9895 RVA: 0x0002450E File Offset: 0x0002270E
		// (set) Token: 0x060026A8 RID: 9896 RVA: 0x0002451A File Offset: 0x0002271A
		public string Value { get; set; }

		// Token: 0x04000F4B RID: 3915
		[CompilerGenerated]
		private string #a;

		// Token: 0x04000F4C RID: 3916
		[CompilerGenerated]
		private string #b;

		// Token: 0x04000F4D RID: 3917
		[CompilerGenerated]
		private string #c;
	}
}
