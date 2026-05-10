using System;
using #hZe;
using #wUe;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x020012DC RID: 4828
	internal sealed class #iUe
	{
		// Token: 0x0600A164 RID: 41316 RVA: 0x0007E94E File Offset: 0x0007CB4E
		public #iUe(InputModel #hMe, RuntimeModel #iMe)
		{
			this.#a = #hMe;
			this.#b = #iMe;
		}

		// Token: 0x17002E6A RID: 11882
		// (get) Token: 0x0600A165 RID: 41317 RVA: 0x0007E964 File Offset: 0x0007CB64
		private #x0e GeometryProperties
		{
			get
			{
				return this.#b.GeometryProperties;
			}
		}

		// Token: 0x17002E6B RID: 11883
		// (get) Token: 0x0600A166 RID: 41318 RVA: 0x0007E971 File Offset: 0x0007CB71
		private #K1e ReinforcementBars
		{
			get
			{
				return this.#b.ReinforcementBars;
			}
		}

		// Token: 0x0600A167 RID: 41319 RVA: 0x002275AC File Offset: 0x002257AC
		public void #yl()
		{
			ReinforcementBar[] array = this.ReinforcementBars.Bars;
			float num = #xke.#eke(array[0].Area / 3.1415927f);
			float num2 = #xke.#eke(array[1].Area / 3.1415927f);
			float num3 = array[0].X - array[1].X;
			float num4 = array[0].Y - array[1].Y;
			this.GeometryProperties.Space = #xke.#eke(num3 * num3 + num4 * num4) - (num + num2);
			this.#aUe();
			this.#9Te();
		}

		// Token: 0x0600A168 RID: 41320 RVA: 0x0022763C File Offset: 0x0022583C
		private static float #eUe(ReinforcementBar[] #KJ, int #Ttb, int #Cje)
		{
			float num = #KJ[#Ttb].Y - #KJ[#Cje].Y;
			if (num < 0f)
			{
				return -num;
			}
			return num;
		}

		// Token: 0x0600A169 RID: 41321 RVA: 0x00227668 File Offset: 0x00225868
		private static float #fUe(ReinforcementBar[] #KJ, int #Ttb, int #Cje)
		{
			float num = #KJ[#Ttb].X - #KJ[#Cje].X;
			if (num < 0f)
			{
				return -num;
			}
			return num;
		}

		// Token: 0x0600A16A RID: 41322 RVA: 0x00227694 File Offset: 0x00225894
		private void #aUe()
		{
			int num = this.ReinforcementBars.NumberOfBars;
			ReinforcementBar[] array = this.ReinforcementBars.Bars;
			for (int i = 0; i < num - 1; i++)
			{
				float num2 = #xke.#eke(array[i].Area / 3.1415927f);
				for (int j = i + 1; j < num; j++)
				{
					float num3 = #xke.#eke(array[j].Area / 3.1415927f);
					float num4 = this.GeometryProperties.Space + (num2 + num3);
					float num5 = #iUe.#fUe(array, i, j);
					if (num5 < num4)
					{
						float num6 = #iUe.#eUe(array, i, j);
						if (num6 < num4)
						{
							float num7 = #xke.#eke(num5 * num5 + num6 * num6) - (num2 + num3);
							if (num7 < this.GeometryProperties.Space)
							{
								this.GeometryProperties.Space = num7;
							}
						}
					}
				}
			}
		}

		// Token: 0x0600A16B RID: 41323 RVA: 0x00227778 File Offset: 0x00225978
		private void #9Te()
		{
			if (this.#a.Options.SectionType == #G6e.#a)
			{
				this.#gUe();
				return;
			}
			if (this.#a.Options.SectionType == #G6e.#b)
			{
				this.#hUe();
				return;
			}
			this.GeometryProperties.Cover = 0f;
		}

		// Token: 0x0600A16C RID: 41324 RVA: 0x002277C8 File Offset: 0x002259C8
		private void #gUe()
		{
			int num = this.ReinforcementBars.NumberOfBars;
			ReinforcementBar[] array = this.ReinforcementBars.Bars;
			float num2 = 0.5f * this.#b.SectionDimensionsForInvestigate[0];
			float num3 = #xke.#eke(array[1].Area / 3.1415927f);
			this.GeometryProperties.Cover = num2 - #xke.#hke(array[1].X) - num3;
			float num4 = 0.5f * this.#b.SectionDimensionsForInvestigate[1];
			for (int i = 0; i < num; i++)
			{
				num3 = #xke.#eke(array[i].Area / 3.1415927f);
				float num5 = num2 - #xke.#hke(array[i].X) - num3;
				if (this.GeometryProperties.Cover > num5)
				{
					this.GeometryProperties.Cover = num5;
				}
				num5 = num4 - #xke.#hke(array[i].Y) - num3;
				if (this.GeometryProperties.Cover > num5)
				{
					this.GeometryProperties.Cover = num5;
				}
			}
		}

		// Token: 0x0600A16D RID: 41325 RVA: 0x002278D0 File Offset: 0x00225AD0
		private void #hUe()
		{
			int num = this.ReinforcementBars.NumberOfBars;
			ReinforcementBar[] array = this.ReinforcementBars.Bars;
			float num2 = 0.5f * this.#b.SectionDimensionsForInvestigate[0];
			float num3 = #xke.#eke(#xke.#fke(array[1].X, 2f) + #xke.#fke(array[1].Y, 2f));
			float num4 = #xke.#eke(array[1].Area / 3.1415927f);
			this.GeometryProperties.Cover = num2 - num3 - num4;
			for (int i = 0; i < num; i++)
			{
				num3 = #xke.#eke(#xke.#fke(array[i].X, 2f) + #xke.#fke(array[i].Y, 2f));
				num4 = #xke.#eke(array[i].Area / 3.1415927f);
				float num5 = num2 - num3 - num4;
				if (this.GeometryProperties.Cover > num5)
				{
					this.GeometryProperties.Cover = num5;
				}
			}
		}

		// Token: 0x040046A5 RID: 18085
		private readonly InputModel #a;

		// Token: 0x040046A6 RID: 18086
		private readonly RuntimeModel #b;
	}
}
