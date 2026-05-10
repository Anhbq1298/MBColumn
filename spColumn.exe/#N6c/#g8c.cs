using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace #N6c
{
	// Token: 0x02000CFF RID: 3327
	internal sealed class #g8c<#Fu> : HashSet<!0>, IEnumerable, IEnumerable<!0>, IReadOnlyCollection<!0>, #Z7c<!0>
	{
		// Token: 0x06006CB5 RID: 27829 RVA: 0x00055345 File Offset: 0x00053545
		public #g8c()
		{
		}

		// Token: 0x06006CB6 RID: 27830 RVA: 0x0005534D File Offset: 0x0005354D
		public #g8c(IEqualityComparer<#Fu> #AC) : base(#AC)
		{
		}

		// Token: 0x06006CB7 RID: 27831 RVA: 0x00055356 File Offset: 0x00053556
		public #g8c(IEnumerable<#Fu> #Du) : base(#Du)
		{
		}

		// Token: 0x06006CB8 RID: 27832 RVA: 0x0005535F File Offset: 0x0005355F
		public #g8c(IEnumerable<#Fu> #Du, IEqualityComparer<#Fu> #AC) : base(#Du, #AC)
		{
		}

		// Token: 0x06006CB9 RID: 27833 RVA: 0x00055369 File Offset: 0x00053569
		protected #g8c(SerializationInfo #6h, StreamingContext #ib) : base(#6h, #ib)
		{
		}
	}
}
