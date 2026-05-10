using System;
using #hZe;
using #wUe;
using #X7e;
using #y6e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x020012BD RID: 4797
	internal sealed class #RQe
	{
		// Token: 0x0600A0AE RID: 41134 RVA: 0x0007E1F1 File Offset: 0x0007C3F1
		public #RQe(InputModel #hMe, RuntimeModel #iMe, #38e #jMe)
		{
			this.#a = #hMe;
			this.#b = #iMe;
			this.#c = #jMe;
		}

		// Token: 0x17002E41 RID: 11841
		// (get) Token: 0x0600A0AF RID: 41135 RVA: 0x0007E20E File Offset: 0x0007C40E
		private bool NominalInteraction
		{
			get
			{
				return this.#b.NominalInteraction;
			}
		}

		// Token: 0x17002E42 RID: 11842
		// (get) Token: 0x0600A0B0 RID: 41136 RVA: 0x0007E21B File Offset: 0x0007C41B
		private float Rho
		{
			get
			{
				return this.#b.GeometryProperties.Rho;
			}
		}

		// Token: 0x17002E43 RID: 11843
		// (get) Token: 0x0600A0B1 RID: 41137 RVA: 0x0007E22D File Offset: 0x0007C42D
		private #K2 MaterialProperties
		{
			get
			{
				return this.#a.MaterialProperties;
			}
		}

		// Token: 0x17002E44 RID: 11844
		// (get) Token: 0x0600A0B2 RID: 41138 RVA: 0x0007E23A File Offset: 0x0007C43A
		private Options Options
		{
			get
			{
				return this.#a.Options;
			}
		}

		// Token: 0x17002E45 RID: 11845
		// (get) Token: 0x0600A0B3 RID: 41139 RVA: 0x0007E247 File Offset: 0x0007C447
		private #Fce ReductionFactors
		{
			get
			{
				return this.#b.ReductionFactors;
			}
		}

		// Token: 0x0600A0B4 RID: 41140 RVA: 0x0022393C File Offset: 0x00221B3C
		public void #NQe(float #OQe, ref #TZe #PQe)
		{
			if (this.Options.Unit == #D6e.#a)
			{
				#PQe.MomentX /= 12f;
				#PQe.MomentY /= 12f;
			}
			else
			{
				#PQe.AxialLoad /= 1000f;
				#PQe.MomentX /= 1000000f;
				#PQe.MomentY /= 1000000f;
			}
			this.#QQe(#OQe, ref #PQe);
			if (this.Options.ConsideredAxis != #C6e.#c)
			{
				#PQe.AbsoluteMomentMagnitudeR = #PQe.MomentX;
				return;
			}
			float num = #xke.#ike(#PQe.MomentX, #PQe.MomentY);
			#PQe.AbsoluteMomentMagnitudeR = ((#PQe.AbsoluteMomentMagnitudeR > 0f) ? 1f : -1f) * num;
		}

		// Token: 0x0600A0B5 RID: 41141 RVA: 0x00223A08 File Offset: 0x00221C08
		private void #QQe(float #OQe, ref #TZe #PQe)
		{
			float num = this.#c.#b8e(#OQe, this.MaterialProperties.Eyt, this.ReductionFactors, this.Rho, this.NominalInteraction, this.#a);
			#PQe.AxialLoad *= num;
			#PQe.MomentX *= num;
			#PQe.MomentY *= num;
		}

		// Token: 0x04004648 RID: 17992
		private readonly InputModel #a;

		// Token: 0x04004649 RID: 17993
		private readonly RuntimeModel #b;

		// Token: 0x0400464A RID: 17994
		private readonly #38e #c;
	}
}
