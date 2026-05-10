using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace #Zjb
{
	// Token: 0x02000424 RID: 1060
	internal sealed class #Yjb : EventArgs
	{
		// Token: 0x06002697 RID: 9879 RVA: 0x000243F9 File Offset: 0x000225F9
		public #Yjb(double #0jb, double #1jb, double #2jb, MouseButton #3jb, int? #4jb)
		{
			this.MomentX = #0jb;
			this.MomentY = #1jb;
			this.AxialForce = #2jb;
			this.MouseButton = #3jb;
			this.Index = #4jb;
		}

		// Token: 0x17000D08 RID: 3336
		// (get) Token: 0x06002698 RID: 9880 RVA: 0x00024426 File Offset: 0x00022626
		// (set) Token: 0x06002699 RID: 9881 RVA: 0x00024432 File Offset: 0x00022632
		public double MomentX { get; set; }

		// Token: 0x17000D09 RID: 3337
		// (get) Token: 0x0600269A RID: 9882 RVA: 0x00024443 File Offset: 0x00022643
		// (set) Token: 0x0600269B RID: 9883 RVA: 0x0002444F File Offset: 0x0002264F
		public double MomentY { get; set; }

		// Token: 0x17000D0A RID: 3338
		// (get) Token: 0x0600269C RID: 9884 RVA: 0x00024460 File Offset: 0x00022660
		// (set) Token: 0x0600269D RID: 9885 RVA: 0x0002446C File Offset: 0x0002266C
		public double AxialForce { get; set; }

		// Token: 0x17000D0B RID: 3339
		// (get) Token: 0x0600269E RID: 9886 RVA: 0x0002447D File Offset: 0x0002267D
		// (set) Token: 0x0600269F RID: 9887 RVA: 0x00024489 File Offset: 0x00022689
		public MouseButton MouseButton { get; private set; }

		// Token: 0x17000D0C RID: 3340
		// (get) Token: 0x060026A0 RID: 9888 RVA: 0x0002449A File Offset: 0x0002269A
		// (set) Token: 0x060026A1 RID: 9889 RVA: 0x000244A6 File Offset: 0x000226A6
		public int? Index { get; private set; }

		// Token: 0x04000F46 RID: 3910
		[CompilerGenerated]
		private double #a;

		// Token: 0x04000F47 RID: 3911
		[CompilerGenerated]
		private double #b;

		// Token: 0x04000F48 RID: 3912
		[CompilerGenerated]
		private double #c;

		// Token: 0x04000F49 RID: 3913
		[CompilerGenerated]
		private MouseButton #d;

		// Token: 0x04000F4A RID: 3914
		[CompilerGenerated]
		private int? #e;
	}
}
