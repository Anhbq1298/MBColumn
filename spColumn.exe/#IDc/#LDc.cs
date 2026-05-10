using System;
using #7hc;
using #ezc;
using #Fmc;
using #T0c;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #IDc
{
	// Token: 0x02000B78 RID: 2936
	internal sealed class #LDc : #Wsc
	{
		// Token: 0x06005FD4 RID: 24532 RVA: 0x0004F635 File Offset: 0x0004D835
		public #LDc(#GBc #2x)
		{
			#X0d.#V0d(#2x, #Phc.#3hc(107417812), Component.GUI, #Phc.#3hc(107416699));
			this.#a = #2x;
		}

		// Token: 0x06005FD5 RID: 24533 RVA: 0x00179970 File Offset: 0x00177B70
		public bool #Usc(#juc #Vsc)
		{
			if (2 != 0)
			{
				this.#KDc();
			}
			int num;
			int result = num = #Vsc - #juc.#b;
			while (!false)
			{
				switch (num)
				{
				case 0:
					break;
				case 1:
					return this.#b.AreNodesVisible;
				case 2:
					if (!false)
					{
						return this.#b.AreLinearObjectsVisible;
					}
					break;
				case 3:
					if (6 != 0)
					{
						return this.#b.AreGridLinesVisible;
					}
					goto IL_90;
				case 4:
					return this.#b.AreNodesVisible;
				case 5:
				{
					bool result2 = (num = (result = (this.#b.AreShapesVisible ? 1 : 0))) != 0;
					if (!false)
					{
						return result2;
					}
					continue;
				}
				case 6:
					goto IL_90;
				case 7:
					goto IL_9E;
				case 8:
					return true;
				default:
					goto IL_9E;
				}
				return this.#b.AreShapesVisible;
				IL_90:
				return this.#b.AreShapesVisible;
				IL_9E:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107416614));
			}
			return result != 0;
		}

		// Token: 0x06005FD6 RID: 24534 RVA: 0x0004F65F File Offset: 0x0004D85F
		private void #KDc()
		{
			if (this.#b == null)
			{
				this.#b = this.#a.#vy<#V0c>();
			}
		}

		// Token: 0x04002781 RID: 10113
		private readonly #GBc #a;

		// Token: 0x04002782 RID: 10114
		private #V0c #b;
	}
}
