using System;
using #7hc;
using #QZ;
using #xZ;
using StructurePoint.Products.Column.Model.Entities;

namespace #5Z
{
	// Token: 0x02000361 RID: 865
	[#zZ(typeof(#VZ))]
	internal sealed class #v0 : ValidatableBaseEntity
	{
		// Token: 0x06001D0D RID: 7437 RVA: 0x0001BEA8 File Offset: 0x0001A0A8
		public #v0(float #f)
		{
			this.Value = #f;
		}

		// Token: 0x17000A2F RID: 2607
		// (get) Token: 0x06001D0E RID: 7438 RVA: 0x0001BEB7 File Offset: 0x0001A0B7
		// (set) Token: 0x06001D0F RID: 7439 RVA: 0x0001BEC3 File Offset: 0x0001A0C3
		public float Value
		{
			get
			{
				return this.#a;
			}
			set
			{
				base.#Z0<float>(ref this.#a, value, #Phc.#3hc(107399374));
			}
		}

		// Token: 0x04000BA6 RID: 2982
		private float #a;
	}
}
