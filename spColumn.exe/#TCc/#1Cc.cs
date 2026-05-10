using System;
using System.Runtime.CompilerServices;
using #7hc;

namespace #TCc
{
	// Token: 0x02000B65 RID: 2917
	[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
	internal sealed class #1Cc : Attribute
	{
		// Token: 0x06005F2E RID: 24366 RVA: 0x0004EF7C File Offset: 0x0004D17C
		public #1Cc(Type #wx, string #opb)
		{
			if (#wx == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107418013));
			}
			this.Provider = #wx;
			if (#opb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107405805));
			}
			this.Factory = #opb;
		}

		// Token: 0x17001B01 RID: 6913
		// (get) Token: 0x06005F2F RID: 24367 RVA: 0x0004EFBA File Offset: 0x0004D1BA
		public Type Provider { get; }

		// Token: 0x17001B02 RID: 6914
		// (get) Token: 0x06005F30 RID: 24368 RVA: 0x0004EFC2 File Offset: 0x0004D1C2
		public string Factory { get; }

		// Token: 0x04002752 RID: 10066
		[CompilerGenerated]
		private readonly Type #a;

		// Token: 0x04002753 RID: 10067
		[CompilerGenerated]
		private readonly string #b;
	}
}
