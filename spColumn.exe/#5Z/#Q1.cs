using System;
using #7hc;
using #9pe;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace #5Z
{
	// Token: 0x0200039D RID: 925
	internal sealed class #Q1 : #20, #aqe
	{
		// Token: 0x06001E2E RID: 7726 RVA: 0x0001CC2D File Offset: 0x0001AE2D
		public #Q1()
		{
		}

		// Token: 0x06001E2F RID: 7727 RVA: 0x0001D0D1 File Offset: 0x0001B2D1
		public #Q1(float #R1, float #S1)
		{
			this.DimensionA = #R1;
			this.DimensionB = #S1;
		}

		// Token: 0x06001E30 RID: 7728 RVA: 0x0001D0E7 File Offset: 0x0001B2E7
		public #Q1(InvestigationDimensions #Rf)
		{
			this.DimensionA = #Rf.DimensionA;
			this.DimensionB = #Rf.DimensionB;
		}

		// Token: 0x17000A84 RID: 2692
		// (get) Token: 0x06001E31 RID: 7729 RVA: 0x0001D107 File Offset: 0x0001B307
		// (set) Token: 0x06001E32 RID: 7730 RVA: 0x0001D113 File Offset: 0x0001B313
		public float DimensionA
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.SetProperty<float>(ref this.#a, value, #Phc.#3hc(107398798));
			}
		}

		// Token: 0x17000A85 RID: 2693
		// (get) Token: 0x06001E33 RID: 7731 RVA: 0x0001D139 File Offset: 0x0001B339
		// (set) Token: 0x06001E34 RID: 7732 RVA: 0x0001D145 File Offset: 0x0001B345
		public float DimensionB
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<float>(ref this.#b, value, #Phc.#3hc(107398813));
			}
		}

		// Token: 0x06001E35 RID: 7733 RVA: 0x0001D16B File Offset: 0x0001B36B
		public InvestigationDimensions #CY()
		{
			return new InvestigationDimensions
			{
				DimensionA = this.DimensionA,
				DimensionB = this.DimensionB
			};
		}

		// Token: 0x04000C05 RID: 3077
		private float #a;

		// Token: 0x04000C06 RID: 3078
		private float #b;
	}
}
