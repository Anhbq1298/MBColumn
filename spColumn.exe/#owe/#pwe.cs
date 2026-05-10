using System;
using System.Runtime.CompilerServices;
using #7hc;
using #Qcd;
using #Wse;
using #yEd;

namespace #owe
{
	// Token: 0x02001194 RID: 4500
	internal sealed class #pwe : #HEd
	{
		// Token: 0x06009896 RID: 39062 RVA: 0x000790E1 File Offset: 0x000772E1
		public #pwe(#ldd #hL, #uwe #mA, #lte #Od) : base(#hL, false)
		{
			if (#mA == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107360163));
			}
			this.Options = #mA;
			if (#Od == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399786));
			}
			this.Model = #Od;
		}

		// Token: 0x17002C4C RID: 11340
		// (get) Token: 0x06009897 RID: 39063 RVA: 0x00079121 File Offset: 0x00077321
		public #uwe Options { get; }

		// Token: 0x17002C4D RID: 11341
		// (get) Token: 0x06009898 RID: 39064 RVA: 0x00079129 File Offset: 0x00077329
		public #lte Model { get; }

		// Token: 0x040041AB RID: 16811
		[CompilerGenerated]
		private readonly #uwe #a;

		// Token: 0x040041AC RID: 16812
		[CompilerGenerated]
		private readonly #lte #b;
	}
}
