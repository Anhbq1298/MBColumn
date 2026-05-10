using System;
using System.Runtime.CompilerServices;

namespace #wdd
{
	// Token: 0x02000D10 RID: 3344
	internal sealed class #Hdd
	{
		// Token: 0x06006E2F RID: 28207 RVA: 0x00058B4B File Offset: 0x00056D4B
		public #Hdd(int #Idd, int #Jdd, int #Kdd, int #Ldd)
		{
			this.AbsoluteStart = #Idd;
			this.AbsoluteEnd = #Jdd;
			this.RelativeStart = #Kdd;
			this.RelativeEnd = #Ldd;
		}

		// Token: 0x17001EEE RID: 7918
		// (get) Token: 0x06006E30 RID: 28208 RVA: 0x00058B70 File Offset: 0x00056D70
		// (set) Token: 0x06006E31 RID: 28209 RVA: 0x00058B7C File Offset: 0x00056D7C
		public int AbsoluteStart { get; private set; }

		// Token: 0x17001EEF RID: 7919
		// (get) Token: 0x06006E32 RID: 28210 RVA: 0x00058B8D File Offset: 0x00056D8D
		// (set) Token: 0x06006E33 RID: 28211 RVA: 0x00058B99 File Offset: 0x00056D99
		public int AbsoluteEnd { get; private set; }

		// Token: 0x17001EF0 RID: 7920
		// (get) Token: 0x06006E34 RID: 28212 RVA: 0x00058BAA File Offset: 0x00056DAA
		// (set) Token: 0x06006E35 RID: 28213 RVA: 0x00058BB6 File Offset: 0x00056DB6
		public int RelativeStart { get; private set; }

		// Token: 0x17001EF1 RID: 7921
		// (get) Token: 0x06006E36 RID: 28214 RVA: 0x00058BC7 File Offset: 0x00056DC7
		// (set) Token: 0x06006E37 RID: 28215 RVA: 0x00058BD3 File Offset: 0x00056DD3
		public int RelativeEnd { get; private set; }

		// Token: 0x17001EF2 RID: 7922
		// (get) Token: 0x06006E38 RID: 28216 RVA: 0x00058BE4 File Offset: 0x00056DE4
		public int Count
		{
			get
			{
				return this.AbsoluteEnd - this.AbsoluteStart + 1;
			}
		}

		// Token: 0x04002C4E RID: 11342
		[CompilerGenerated]
		private int #a;

		// Token: 0x04002C4F RID: 11343
		[CompilerGenerated]
		private int #b;

		// Token: 0x04002C50 RID: 11344
		[CompilerGenerated]
		private int #c;

		// Token: 0x04002C51 RID: 11345
		[CompilerGenerated]
		private int #d;
	}
}
