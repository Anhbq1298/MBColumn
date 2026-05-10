using System;
using #6s;
using #7hc;
using #vW;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace #WQ
{
	// Token: 0x020002D4 RID: 724
	internal sealed class #VQ : NotifyPropertyChangedObjectBase, #uW
	{
		// Token: 0x17000963 RID: 2403
		// (get) Token: 0x0600194C RID: 6476 RVA: 0x00019524 File Offset: 0x00017724
		// (set) Token: 0x0600194D RID: 6477 RVA: 0x00019530 File Offset: 0x00017730
		public #9s BeamsXAxis
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.SetProperty<#9s>(ref this.#a, value, #Phc.#3hc(107400954));
			}
		}

		// Token: 0x17000964 RID: 2404
		// (get) Token: 0x0600194E RID: 6478 RVA: 0x00019556 File Offset: 0x00017756
		// (set) Token: 0x0600194F RID: 6479 RVA: 0x00019562 File Offset: 0x00017762
		public #9s BeamsYAxis
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<#9s>(ref this.#b, value, #Phc.#3hc(107400905));
			}
		}

		// Token: 0x040009A8 RID: 2472
		private #9s #a;

		// Token: 0x040009A9 RID: 2473
		private #9s #b;
	}
}
