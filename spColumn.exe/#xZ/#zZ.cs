using System;
using System.Runtime.CompilerServices;
using #7hc;

namespace #xZ
{
	// Token: 0x0200038A RID: 906
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	internal sealed class #zZ : Attribute
	{
		// Token: 0x06001D5F RID: 7519 RVA: 0x0001C240 File Offset: 0x0001A440
		public #zZ(Type #C)
		{
			if (#C == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107383497));
			}
			this.#a = #C;
		}

		// Token: 0x17000A44 RID: 2628
		// (get) Token: 0x06001D60 RID: 7520 RVA: 0x0001C263 File Offset: 0x0001A463
		public Type ValidatorType { get; }

		// Token: 0x04000BBD RID: 3005
		[CompilerGenerated]
		private readonly Type #a;
	}
}
