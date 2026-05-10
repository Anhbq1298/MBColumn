using System;
using System.Runtime.CompilerServices;
using #Gke;
using #X7e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace #hZe
{
	// Token: 0x02001336 RID: 4918
	internal sealed class #Fce
	{
		// Token: 0x0600A44E RID: 42062 RVA: 0x0022FA08 File Offset: 0x0022DC08
		public #Fce(ReductionFactors #Zpe)
		{
			this.#a = #Zpe.A;
			this.B = #Zpe.B;
			this.C = #Zpe.C;
			this.Trans = #Zpe.Trans;
			this.MinDimension = #Zpe.MinDimension;
		}

		// Token: 0x0600A44F RID: 42063 RVA: 0x00080580 File Offset: 0x0007E780
		private #Fce(float #5Gb, float #6Gb, float #uYb, float #F1e, float #G1e)
		{
			this.#a = #5Gb;
			this.B = #6Gb;
			this.C = #uYb;
			this.Trans = #F1e;
			this.MinDimension = #G1e;
		}

		// Token: 0x17002F32 RID: 12082
		// (get) Token: 0x0600A450 RID: 42064 RVA: 0x000805AD File Offset: 0x0007E7AD
		// (set) Token: 0x0600A451 RID: 42065 RVA: 0x000805B5 File Offset: 0x0007E7B5
		public float B { get; private set; }

		// Token: 0x17002F33 RID: 12083
		// (get) Token: 0x0600A452 RID: 42066 RVA: 0x000805BE File Offset: 0x0007E7BE
		// (set) Token: 0x0600A453 RID: 42067 RVA: 0x000805C6 File Offset: 0x0007E7C6
		public float C { get; private set; }

		// Token: 0x17002F34 RID: 12084
		// (get) Token: 0x0600A454 RID: 42068 RVA: 0x000805CF File Offset: 0x0007E7CF
		// (set) Token: 0x0600A455 RID: 42069 RVA: 0x000805D7 File Offset: 0x0007E7D7
		public float Trans { get; private set; }

		// Token: 0x17002F35 RID: 12085
		// (get) Token: 0x0600A456 RID: 42070 RVA: 0x000805E0 File Offset: 0x0007E7E0
		// (set) Token: 0x0600A457 RID: 42071 RVA: 0x000805E8 File Offset: 0x0007E7E8
		public float MinDimension { get; private set; }

		// Token: 0x0600A458 RID: 42072 RVA: 0x000805F1 File Offset: 0x0007E7F1
		public #Fce #EA()
		{
			return new #Fce(this.#a, this.B, this.C, this.Trans, this.MinDimension);
		}

		// Token: 0x0600A459 RID: 42073 RVA: 0x00080616 File Offset: 0x0007E816
		public void #mg(#Fce #Zpe)
		{
			this.#a = #Zpe.#a;
			this.B = #Zpe.B;
			this.C = #Zpe.C;
			this.Trans = #Zpe.Trans;
			this.MinDimension = #Zpe.MinDimension;
		}

		// Token: 0x0600A45A RID: 42074 RVA: 0x00080654 File Offset: 0x0007E854
		internal static #Fce #Dge(#Qle #L0)
		{
			return new #Fce(#L0.#a, #L0.#b, #L0.#c, #L0.#d, #L0.#e);
		}

		// Token: 0x0600A45B RID: 42075 RVA: 0x00080679 File Offset: 0x0007E879
		internal void #D1e()
		{
			this.#a = 1f;
			this.B = 1f;
			this.C = 1f;
			this.Trans = 1f;
		}

		// Token: 0x0600A45C RID: 42076 RVA: 0x000806A7 File Offset: 0x0007E8A7
		internal float #E1e(InputModel #hMe, RuntimeModel #iMe, #38e #jMe)
		{
			if (#iMe.NominalInteraction)
			{
				return 1f;
			}
			return #jMe.#j8e(#hMe, #iMe, this.#a, this.MinDimension);
		}

		// Token: 0x04004804 RID: 18436
		private float #a;

		// Token: 0x04004805 RID: 18437
		[CompilerGenerated]
		private float #b;

		// Token: 0x04004806 RID: 18438
		[CompilerGenerated]
		private float #c;

		// Token: 0x04004807 RID: 18439
		[CompilerGenerated]
		private float #d;

		// Token: 0x04004808 RID: 18440
		[CompilerGenerated]
		private float #e;
	}
}
