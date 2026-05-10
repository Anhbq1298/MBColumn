using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #3Rd;
using #7hc;
using #FCd;

namespace #Ded
{
	// Token: 0x020006E8 RID: 1768
	internal abstract class #Led
	{
		// Token: 0x170011FB RID: 4603
		// (get) Token: 0x06003AB5 RID: 15029 RVA: 0x00032ED1 File Offset: 0x000310D1
		public #qSd DocumentMap
		{
			get
			{
				return this.Definition.DocumentMap;
			}
		}

		// Token: 0x170011FC RID: 4604
		// (get) Token: 0x06003AB6 RID: 15030 RVA: 0x00032EEA File Offset: 0x000310EA
		// (set) Token: 0x06003AB7 RID: 15031 RVA: 0x00032EF6 File Offset: 0x000310F6
		private protected #Ced Definition { protected get; private set; }

		// Token: 0x06003AB8 RID: 15032
		protected abstract void #Rcd(string #wy, #uDd #Xpb);

		// Token: 0x06003AB9 RID: 15033
		protected abstract void #ved(#Red #bLb);

		// Token: 0x06003ABA RID: 15034 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #Fed(#Red #bLb)
		{
		}

		// Token: 0x06003ABB RID: 15035 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #Ged()
		{
		}

		// Token: 0x06003ABC RID: 15036 RVA: 0x0001233F File Offset: 0x0001053F
		protected virtual int[] #Hed(#uDd #Xpb)
		{
			return null;
		}

		// Token: 0x06003ABD RID: 15037 RVA: 0x00115AA4 File Offset: 0x00113CA4
		protected virtual void #Ied()
		{
			this.#Ked();
			this.Definition.#ued();
			IEnumerator<#Red> enumerator = this.Definition.Sections.GetEnumerator();
			try
			{
				while (\u0010\u0002.~\u0019\u0004(enumerator))
				{
					#Red #bLb = enumerator.Current;
					this.#Fed(#bLb);
				}
			}
			finally
			{
				if (enumerator != null)
				{
					\u0007.~\u000E(enumerator);
				}
			}
		}

		// Token: 0x06003ABE RID: 15038 RVA: 0x00115B20 File Offset: 0x00113D20
		protected virtual void #Jed()
		{
			this.#Ked();
			this.Definition.#ued();
			IEnumerator<#Red> enumerator = this.Definition.Sections.GetEnumerator();
			try
			{
				while (\u0010\u0002.~\u0019\u0004(enumerator))
				{
					#Red #bLb = enumerator.Current;
					this.#ved(#bLb);
				}
			}
			finally
			{
				if (enumerator != null)
				{
					\u0007.~\u000E(enumerator);
				}
			}
		}

		// Token: 0x06003ABF RID: 15039 RVA: 0x00032F07 File Offset: 0x00031107
		protected void #Ked()
		{
			if (!this.#a)
			{
				throw new InvalidOperationException(#Phc.#3hc(107253284));
			}
		}

		// Token: 0x06003AC0 RID: 15040 RVA: 0x00032F2D File Offset: 0x0003112D
		protected void #eb(#Ced #xS)
		{
			if (#xS == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107253735));
			}
			this.Definition = #xS;
			this.#a = true;
		}

		// Token: 0x04001902 RID: 6402
		private bool #a;

		// Token: 0x04001903 RID: 6403
		[CompilerGenerated]
		private #Ced #b;
	}
}
