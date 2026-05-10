using System;
using System.Reflection;

namespace #pXd
{
	// Token: 0x02000EAA RID: 3754
	internal sealed class #1Xd<#Fu>
	{
		// Token: 0x060085E2 RID: 34274 RVA: 0x0006D00F File Offset: 0x0006B20F
		public #1Xd(PropertyInfo #F, object #WSc)
		{
			this.#b = #WSc;
			this.#a = #F;
		}

		// Token: 0x1700280C RID: 10252
		// (get) Token: 0x060085E3 RID: 34275 RVA: 0x0006D025 File Offset: 0x0006B225
		// (set) Token: 0x060085E4 RID: 34276 RVA: 0x0006D03E File Offset: 0x0006B23E
		public #Fu Property
		{
			get
			{
				return (!0)((object)this.#a.GetValue(this.#b, null));
			}
			set
			{
				PropertyInfo propertyInfo = this.#a;
				object obj = this.#b;
				object value2 = value;
				object[] index = null;
				if (4 != 0)
				{
					propertyInfo.SetValue(obj, value2, index);
				}
			}
		}

		// Token: 0x04003748 RID: 14152
		private readonly PropertyInfo #a;

		// Token: 0x04003749 RID: 14153
		private readonly object #b;
	}
}
