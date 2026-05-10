using System;
using System.Collections;
using System.Collections.Generic;

namespace #N6c
{
	// Token: 0x02000CFA RID: 3322
	internal interface #Z7c<#Fu> : IEnumerable, IEnumerable<!0>, IReadOnlyCollection<!0>
	{
		// Token: 0x06006C8C RID: 27788
		bool Contains(#Fu item);

		// Token: 0x06006C8D RID: 27789
		bool IsSubsetOf(IEnumerable<#Fu> other);

		// Token: 0x06006C8E RID: 27790
		bool IsSupersetOf(IEnumerable<#Fu> other);

		// Token: 0x06006C8F RID: 27791
		bool IsProperSupersetOf(IEnumerable<#Fu> other);

		// Token: 0x06006C90 RID: 27792
		bool IsProperSubsetOf(IEnumerable<#Fu> other);

		// Token: 0x06006C91 RID: 27793
		bool Overlaps(IEnumerable<#Fu> other);

		// Token: 0x06006C92 RID: 27794
		bool SetEquals(IEnumerable<#Fu> other);
	}
}
