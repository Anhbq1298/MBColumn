using System;
using #wUe;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x020012DB RID: 4827
	internal sealed class #dUe
	{
		// Token: 0x0600A162 RID: 41314 RVA: 0x0007E938 File Offset: 0x0007CB38
		public #dUe(InputModel #hMe, RuntimeModel #iMe)
		{
			this.#a = #hMe;
			this.#b = #iMe;
		}

		// Token: 0x0600A163 RID: 41315 RVA: 0x00227488 File Offset: 0x00225688
		public void #yl()
		{
			float[] array = this.#b.InvestigateReinforcement.ClearCover;
			int[] array2 = this.#b.InvestigateReinforcement.BarNumber;
			float[] array3 = this.#b.SectionDimensionsForInvestigate;
			float num = #xke.#rke(array[0], array[2]);
			this.#b.GeometryProperties.Cover = num + #ISe.#qP(array2[0], this.#a);
			float num2 = array3[0] - 2f * (array[2] + #ISe.#qP(array2[2], this.#a));
			float num3 = array3[1] - 2f * (array[0] + #ISe.#qP(array2[0], this.#a));
			int num4 = this.#b.InvestigateReinforcement.AmountOfBars[0];
			int num5 = this.#b.InvestigateReinforcement.AmountOfBars[2] + 2;
			float #4gb = (num2 - (float)num4 * this.#a.Bars[array2[0]].Diameter) / (float)(num4 - 1);
			float #5gb = (num3 - (float)num5 * this.#a.Bars[array2[2]].Diameter) / (float)(num5 - 1);
			this.#b.GeometryProperties.Space = #xke.#rke(#4gb, #5gb);
		}

		// Token: 0x040046A3 RID: 18083
		private readonly InputModel #a;

		// Token: 0x040046A4 RID: 18084
		private readonly RuntimeModel #b;
	}
}
