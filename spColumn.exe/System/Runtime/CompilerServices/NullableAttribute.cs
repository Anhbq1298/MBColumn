using System;
using Microsoft.CodeAnalysis;

namespace System.Runtime.CompilerServices
{
	// Token: 0x02000820 RID: 2080
	[CompilerGenerated]
	[EmbeddedAttribute4]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableAttribute : Attribute
	{
		// Token: 0x060042B0 RID: 17072 RVA: 0x00037FDB File Offset: 0x000361DB
		public NullableAttribute(byte A_1)
		{
			this.NullableFlags = new byte[]
			{
				A_1
			};
		}

		// Token: 0x060042B1 RID: 17073 RVA: 0x00037FF3 File Offset: 0x000361F3
		public NullableAttribute(byte[] A_1)
		{
			this.NullableFlags = A_1;
		}

		// Token: 0x04001E0B RID: 7691
		public readonly byte[] NullableFlags;
	}
}
