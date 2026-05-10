using System;
using #5Z;
using #7hc;
using #n8;
using #vW;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace #WQ
{
	// Token: 0x020002D6 RID: 726
	internal sealed class #1Q : NotifyPropertyChangedObjectBase, #wW
	{
		// Token: 0x06001955 RID: 6485 RVA: 0x00019588 File Offset: 0x00017788
		public #1Q()
		{
			this.DesignColumnXAxis = new #X3();
			this.DesignColumnYAxis = new #X3();
		}

		// Token: 0x17000967 RID: 2407
		// (get) Token: 0x06001956 RID: 6486 RVA: 0x000195A6 File Offset: 0x000177A6
		// (set) Token: 0x06001957 RID: 6487 RVA: 0x000195B2 File Offset: 0x000177B2
		public #N8 DesignColumnXAxis
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.SetProperty<#N8>(ref this.#a, value, #Phc.#3hc(107400920));
			}
		}

		// Token: 0x17000968 RID: 2408
		// (get) Token: 0x06001958 RID: 6488 RVA: 0x000195D8 File Offset: 0x000177D8
		// (set) Token: 0x06001959 RID: 6489 RVA: 0x000195E4 File Offset: 0x000177E4
		public #N8 DesignColumnYAxis
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<#N8>(ref this.#b, value, #Phc.#3hc(107400895));
			}
		}

		// Token: 0x040009AA RID: 2474
		private #N8 #a;

		// Token: 0x040009AB RID: 2475
		private #N8 #b;
	}
}
