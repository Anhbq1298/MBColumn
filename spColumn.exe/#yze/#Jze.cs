using System;
using System.Runtime.CompilerServices;
using #7hc;
using #owe;
using #VEd;
using #Wse;
using Aspose.Words;

namespace #yze
{
	// Token: 0x020011F9 RID: 4601
	internal sealed class #Jze : #4Ed
	{
		// Token: 0x06009A47 RID: 39495 RVA: 0x0007A343 File Offset: 0x00078543
		public #Jze(#lte #Od, #uwe #mA)
		{
			if (#Od == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399786));
			}
			this.Model = #Od;
			if (#mA == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107360163));
			}
			this.Options = #mA;
		}

		// Token: 0x06009A48 RID: 39496 RVA: 0x0007A381 File Offset: 0x00078581
		public #Jze(DocumentBuilder #tCd, #lte #Od, #uwe #mA) : base(#tCd)
		{
			this.Model = #Od;
			this.Options = #mA;
		}

		// Token: 0x17002CBE RID: 11454
		// (get) Token: 0x06009A49 RID: 39497 RVA: 0x0007A398 File Offset: 0x00078598
		public #lte Model { get; }

		// Token: 0x17002CBF RID: 11455
		// (get) Token: 0x06009A4A RID: 39498 RVA: 0x0007A3A0 File Offset: 0x000785A0
		public #uwe Options { get; }

		// Token: 0x0400423D RID: 16957
		[CompilerGenerated]
		private readonly #lte #a;

		// Token: 0x0400423E RID: 16958
		[CompilerGenerated]
		private readonly #uwe #b;
	}
}
