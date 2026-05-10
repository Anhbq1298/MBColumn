using System;
using #hZe;
using #wUe;
using #X7e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x0200129B RID: 4763
	internal sealed class #fNe
	{
		// Token: 0x06009FA3 RID: 40867 RVA: 0x0007D744 File Offset: 0x0007B944
		public #fNe(InputModel #hMe, RuntimeModel #iMe, #38e #jMe)
		{
			this.#a = #hMe;
			this.#b = #iMe;
			this.#c = #jMe;
		}

		// Token: 0x17002DF0 RID: 11760
		// (get) Token: 0x06009FA4 RID: 40868 RVA: 0x0007D761 File Offset: 0x0007B961
		private #K2 MaterialProperties
		{
			get
			{
				return this.#a.MaterialProperties;
			}
		}

		// Token: 0x17002DF1 RID: 11761
		// (get) Token: 0x06009FA5 RID: 40869 RVA: 0x0007D76E File Offset: 0x0007B96E
		private #x0e GeometryProperties
		{
			get
			{
				return this.#b.GeometryProperties;
			}
		}

		// Token: 0x17002DF2 RID: 11762
		// (get) Token: 0x06009FA6 RID: 40870 RVA: 0x0007D77B File Offset: 0x0007B97B
		private #Fce ReductionFactors
		{
			get
			{
				return this.#b.ReductionFactors;
			}
		}

		// Token: 0x17002DF3 RID: 11763
		// (get) Token: 0x06009FA7 RID: 40871 RVA: 0x0007D788 File Offset: 0x0007B988
		private Options Options
		{
			get
			{
				return this.#a.Options;
			}
		}

		// Token: 0x06009FA8 RID: 40872 RVA: 0x0021DF6C File Offset: 0x0021C16C
		public #vZe #bpb()
		{
			float #87e = #xke.#rke(this.MaterialProperties.Fy, this.MaterialProperties.Eps * this.MaterialProperties.Es);
			float #Qje = this.#b.Fc;
			#vZe #vZe = this.#c.#77e(#Qje, #87e, this.GeometryProperties, this.ReductionFactors, this.MaterialProperties.Fy, this.#a, this.#b.NominalInteraction);
			float num = this.Options.#65e();
			float #wZe = #vZe.Maximum / num;
			float #xZe = #vZe.Minimum / num;
			return new #vZe(#wZe, #xZe);
		}

		// Token: 0x040045B1 RID: 17841
		private readonly InputModel #a;

		// Token: 0x040045B2 RID: 17842
		private readonly RuntimeModel #b;

		// Token: 0x040045B3 RID: 17843
		private readonly #38e #c;
	}
}
