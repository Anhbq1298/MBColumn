using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace StructurePoint.CoreAssets.Infrastructure.Extensions
{
	// Token: 0x02000EE8 RID: 3816
	public sealed class HierarchyNode<T> where T : class
	{
		// Token: 0x17002835 RID: 10293
		// (get) Token: 0x0600872E RID: 34606 RVA: 0x0006DEAD File Offset: 0x0006C0AD
		// (set) Token: 0x0600872F RID: 34607 RVA: 0x0006DEB5 File Offset: 0x0006C0B5
		public T Entity { get; set; }

		// Token: 0x17002836 RID: 10294
		// (get) Token: 0x06008730 RID: 34608 RVA: 0x0006DEBE File Offset: 0x0006C0BE
		// (set) Token: 0x06008731 RID: 34609 RVA: 0x0006DEC6 File Offset: 0x0006C0C6
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		public IEnumerable<HierarchyNode<T>> ChildNodes { get; set; }

		// Token: 0x17002837 RID: 10295
		// (get) Token: 0x06008732 RID: 34610 RVA: 0x0006DECF File Offset: 0x0006C0CF
		// (set) Token: 0x06008733 RID: 34611 RVA: 0x0006DED7 File Offset: 0x0006C0D7
		public int Depth { get; set; }

		// Token: 0x17002838 RID: 10296
		// (get) Token: 0x06008734 RID: 34612 RVA: 0x0006DEE0 File Offset: 0x0006C0E0
		// (set) Token: 0x06008735 RID: 34613 RVA: 0x0006DEE8 File Offset: 0x0006C0E8
		public T Parent { get; set; }

		// Token: 0x040037D6 RID: 14294
		[CompilerGenerated]
		private T #a;

		// Token: 0x040037D7 RID: 14295
		[CompilerGenerated]
		private IEnumerable<HierarchyNode<T>> #b;

		// Token: 0x040037D8 RID: 14296
		[CompilerGenerated]
		private int #c;

		// Token: 0x040037D9 RID: 14297
		[CompilerGenerated]
		private T #d;
	}
}
