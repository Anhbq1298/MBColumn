using System;
using #hZe;
using #wUe;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x020012DA RID: 4826
	internal sealed class #cUe
	{
		// Token: 0x0600A15A RID: 41306 RVA: 0x0007E908 File Offset: 0x0007CB08
		public #cUe(InputModel #hMe, RuntimeModel #iMe)
		{
			this.#a = #hMe;
			this.#b = #iMe;
		}

		// Token: 0x17002E68 RID: 11880
		// (get) Token: 0x0600A15B RID: 41307 RVA: 0x0007E91E File Offset: 0x0007CB1E
		private float[] SectionDimensions
		{
			get
			{
				return this.#b.SectionDimensionsForInvestigate;
			}
		}

		// Token: 0x17002E69 RID: 11881
		// (get) Token: 0x0600A15C RID: 41308 RVA: 0x0007E92B File Offset: 0x0007CB2B
		private #x0e GeometryProperties
		{
			get
			{
				return this.#b.GeometryProperties;
			}
		}

		// Token: 0x0600A15D RID: 41309 RVA: 0x00227254 File Offset: 0x00225454
		public void #yl()
		{
			this.#9Te();
			float #HS = this.#a.Bars[this.#b.InvestigateReinforcement.BarNumber[0]].Diameter;
			if (this.#a.Options.ReinforcementLayout == #F6e.#a)
			{
				this.#bUe(#HS);
				return;
			}
			this.#7Te(#HS);
		}

		// Token: 0x0600A15E RID: 41310 RVA: 0x002272AC File Offset: 0x002254AC
		private void #9Te()
		{
			float num = this.#b.InvestigateReinforcement.ClearCover[0];
			int #nSe = this.#b.InvestigateReinforcement.BarNumber[0];
			this.GeometryProperties.Cover = num + #ISe.#qP(#nSe, this.#a);
		}

		// Token: 0x0600A15F RID: 41311 RVA: 0x002272F8 File Offset: 0x002254F8
		private void #7Te(float #HS)
		{
			this.#aUe();
			this.GeometryProperties.Space -= 2f * this.GeometryProperties.Cover + #HS;
			this.GeometryProperties.Space *= #xke.#qke(3.1415927f / (float)this.#b.ReinforcementBars.NumberOfBars);
			this.GeometryProperties.Space -= #HS;
		}

		// Token: 0x0600A160 RID: 41312 RVA: 0x00227374 File Offset: 0x00225574
		private void #aUe()
		{
			if (this.#a.Options.SectionType == #G6e.#b)
			{
				this.GeometryProperties.Space = this.SectionDimensions[0];
				return;
			}
			this.GeometryProperties.Space = #xke.#rke(this.SectionDimensions[0], this.SectionDimensions[1]);
		}

		// Token: 0x0600A161 RID: 41313 RVA: 0x002273C8 File Offset: 0x002255C8
		private void #bUe(float #HS)
		{
			float num;
			float num2;
			if (this.#a.Options.SectionType == #G6e.#a)
			{
				num = this.SectionDimensions[0] - 2f * this.GeometryProperties.Cover;
				num2 = this.SectionDimensions[1] - 2f * this.GeometryProperties.Cover;
			}
			else
			{
				num = (this.SectionDimensions[0] - 2f * this.GeometryProperties.Cover - #HS) * 0.707107f + #HS;
				num2 = num;
			}
			int num3 = this.#b.ReinforcementBars.NumberOfBars / 4 + 1;
			float #4gb = (num - (float)num3 * #HS) / (float)(num3 - 1);
			float #5gb = (num2 - (float)num3 * #HS) / (float)(num3 - 1);
			this.GeometryProperties.Space = #xke.#rke(#4gb, #5gb);
		}

		// Token: 0x040046A1 RID: 18081
		private readonly InputModel #a;

		// Token: 0x040046A2 RID: 18082
		private readonly RuntimeModel #b;
	}
}
