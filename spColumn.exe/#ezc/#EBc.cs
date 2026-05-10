using System;
using System.Runtime.CompilerServices;

namespace #ezc
{
	// Token: 0x02000B4F RID: 2895
	internal sealed class #EBc
	{
		// Token: 0x06005E7F RID: 24191 RVA: 0x0004EA13 File Offset: 0x0004CC13
		public #EBc(string #wy, object #f, bool #DCb, string #nzb)
		{
			this.ErrorMessage = #nzb;
			this.IsValid = #DCb;
			this.Value = #f;
			this.Name = #wy;
		}

		// Token: 0x17001ACC RID: 6860
		// (get) Token: 0x06005E80 RID: 24192 RVA: 0x0004EA38 File Offset: 0x0004CC38
		// (set) Token: 0x06005E81 RID: 24193 RVA: 0x0004EA40 File Offset: 0x0004CC40
		public string Name { get; private set; }

		// Token: 0x17001ACD RID: 6861
		// (get) Token: 0x06005E82 RID: 24194 RVA: 0x0004EA49 File Offset: 0x0004CC49
		// (set) Token: 0x06005E83 RID: 24195 RVA: 0x0004EA51 File Offset: 0x0004CC51
		public bool IsValid { get; private set; }

		// Token: 0x17001ACE RID: 6862
		// (get) Token: 0x06005E84 RID: 24196 RVA: 0x0004EA5A File Offset: 0x0004CC5A
		// (set) Token: 0x06005E85 RID: 24197 RVA: 0x0004EA62 File Offset: 0x0004CC62
		public string ErrorMessage { get; private set; }

		// Token: 0x17001ACF RID: 6863
		// (get) Token: 0x06005E86 RID: 24198 RVA: 0x0004EA6B File Offset: 0x0004CC6B
		// (set) Token: 0x06005E87 RID: 24199 RVA: 0x0004EA73 File Offset: 0x0004CC73
		public object Value { get; private set; }

		// Token: 0x04002725 RID: 10021
		[CompilerGenerated]
		private string #a;

		// Token: 0x04002726 RID: 10022
		[CompilerGenerated]
		private bool #b;

		// Token: 0x04002727 RID: 10023
		[CompilerGenerated]
		private string #c;

		// Token: 0x04002728 RID: 10024
		[CompilerGenerated]
		private object #d;
	}
}
