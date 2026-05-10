using System;
using System.Runtime.CompilerServices;

namespace StructurePoint.CoreAssets.Infrastructure.IO
{
	// Token: 0x02000EBF RID: 3775
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class BitFieldAttribute : Attribute
	{
		// Token: 0x06008620 RID: 34336 RVA: 0x0006D36F File Offset: 0x0006B56F
		public BitFieldAttribute(int fieldOffset, int size)
		{
			this.FieldOffset = fieldOffset;
			this.Size = size;
		}

		// Token: 0x17002812 RID: 10258
		// (get) Token: 0x06008621 RID: 34337 RVA: 0x0006D385 File Offset: 0x0006B585
		// (set) Token: 0x06008622 RID: 34338 RVA: 0x0006D38D File Offset: 0x0006B58D
		public int Size { get; private set; }

		// Token: 0x17002813 RID: 10259
		// (get) Token: 0x06008623 RID: 34339 RVA: 0x0006D396 File Offset: 0x0006B596
		// (set) Token: 0x06008624 RID: 34340 RVA: 0x0006D39E File Offset: 0x0006B59E
		public int FieldOffset { get; private set; }

		// Token: 0x0400378E RID: 14222
		[CompilerGenerated]
		private int #a;

		// Token: 0x0400378F RID: 14223
		[CompilerGenerated]
		private int #b;
	}
}
