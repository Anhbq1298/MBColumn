using System;
using System.Runtime.CompilerServices;
using #5Fd;
using #7hc;
using #owe;

namespace #yze
{
	// Token: 0x020011F5 RID: 4597
	internal sealed class #Bze : #ZGd
	{
		// Token: 0x06009A3B RID: 39483 RVA: 0x0007A290 File Offset: 0x00078490
		public #Bze(#lHd #0Gd, bool #RVb, string #SVb, #uwe #mA) : base(#0Gd, new #6Fd(), #RVb, #SVb)
		{
			if (#0Gd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107281450));
			}
			if (#mA == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107360163));
			}
			this.Options = #mA;
		}

		// Token: 0x17002CBB RID: 11451
		// (get) Token: 0x06009A3C RID: 39484 RVA: 0x0007A2CF File Offset: 0x000784CF
		public #uwe Options { get; }

		// Token: 0x04004239 RID: 16953
		[CompilerGenerated]
		private readonly #uwe #a;
	}
}
