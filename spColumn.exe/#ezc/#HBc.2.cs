using System;
using System.Diagnostics.CodeAnalysis;

namespace #ezc
{
	// Token: 0x02000B48 RID: 2888
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Ioc")]
	internal interface #HBc : IDisposable
	{
		// Token: 0x06005E51 RID: 24145
		[SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
		void #P<#eBc, #fBc>() where #fBc : !!0;

		// Token: 0x06005E52 RID: 24146
		[SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
		void #P<#eBc, #fBc>(string #wy) where #fBc : !!0;

		// Token: 0x06005E53 RID: 24147
		void #sy<#Fu>(#Fu #ty);

		// Token: 0x06005E54 RID: 24148
		#Fu #vy<#Fu>();

		// Token: 0x06005E55 RID: 24149
		#Fu #vy<#Fu>(string #wy);

		// Token: 0x06005E56 RID: 24150
		[SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
		void #gBc<#eBc, #fBc>() where #fBc : !!0;
	}
}
