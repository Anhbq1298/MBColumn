using System;
using #7hc;
using #Cgc;
using StructurePoint.CoreAssets.Licensing.UI.Views;

namespace #Yfc
{
	// Token: 0x02000722 RID: 1826
	internal sealed class #igc
	{
		// Token: 0x06003C2D RID: 15405 RVA: 0x00034001 File Offset: 0x00032201
		public #igc(#dgc #AQ)
		{
			if (#AQ == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107378398));
			}
			this.#a = #AQ;
		}

		// Token: 0x06003C2E RID: 15406 RVA: 0x00119240 File Offset: 0x00117440
		public #0fc #5b()
		{
			ActivatorWindow activatorWindow = new ActivatorWindow();
			#lhc #lhc = new #lhc(this.#a, activatorWindow);
			\u008A.~\u008D\u0002(activatorWindow, #lhc);
			if (!\u008B.~\u0094\u0002(activatorWindow).GetValueOrDefault())
			{
				return #0fc.#a;
			}
			return #0fc.#b;
		}

		// Token: 0x04001B39 RID: 6969
		private readonly #dgc #a;
	}
}
