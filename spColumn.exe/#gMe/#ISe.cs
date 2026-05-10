using System;
using #hZe;
using #wUe;
using #y6e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Enums;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x020012CB RID: 4811
	internal sealed class #ISe
	{
		// Token: 0x0600A107 RID: 41223 RVA: 0x0007E5D4 File Offset: 0x0007C7D4
		public #ISe(InputModel #hMe, RuntimeModel #iMe, #dTe #JSe)
		{
			this.#a = #hMe;
			this.#b = #iMe;
			this.#c = new #8Te(#hMe, #iMe, #JSe);
		}

		// Token: 0x17002E5C RID: 11868
		// (get) Token: 0x0600A108 RID: 41224 RVA: 0x0007E5F8 File Offset: 0x0007C7F8
		private StandardBar[] InputModelBars
		{
			get
			{
				return this.#a.Bars;
			}
		}

		// Token: 0x17002E5D RID: 11869
		// (get) Token: 0x0600A109 RID: 41225 RVA: 0x0007E605 File Offset: 0x0007C805
		private #K1e ReinforcementBars
		{
			get
			{
				return this.#b.ReinforcementBars;
			}
		}

		// Token: 0x17002E5E RID: 11870
		// (get) Token: 0x0600A10A RID: 41226 RVA: 0x0007E612 File Offset: 0x0007C812
		private float[] SectionDimensions
		{
			get
			{
				return this.#b.SectionDimensionsForInvestigate;
			}
		}

		// Token: 0x17002E5F RID: 11871
		// (get) Token: 0x0600A10B RID: 41227 RVA: 0x0007E61F File Offset: 0x0007C81F
		private #A0e InvestigateReinforcement
		{
			get
			{
				return this.#b.InvestigateReinforcement;
			}
		}

		// Token: 0x17002E60 RID: 11872
		// (get) Token: 0x0600A10C RID: 41228 RVA: 0x0007E62C File Offset: 0x0007C82C
		private Options Options
		{
			get
			{
				return this.#a.Options;
			}
		}

		// Token: 0x0600A10D RID: 41229 RVA: 0x00224904 File Offset: 0x00222B04
		public static float #qP(int #nSe, InputModel #Od)
		{
			int num = (#nSe <= #Od.Ties.LongitudinalBar) ? #Od.Ties.SmallTie : #Od.Ties.LargeTie;
			if (#Od.Options.ClearCover[(int)#Od.Options.ProblemType] == ClearCover.ToTranverseBar)
			{
				return #Od.Bars[num].Diameter;
			}
			return 0f;
		}

		// Token: 0x0600A10E RID: 41230 RVA: 0x00224964 File Offset: 0x00222B64
		public void #tOe()
		{
			ReinforcementType reinforcementType = this.Options.ReinforcementType[(int)this.Options.ProblemType];
			if (reinforcementType == ReinforcementType.Irregular)
			{
				this.#HSe();
				return;
			}
			if (this.InvestigateReinforcement.AmountOfBars[0] == 0)
			{
				this.ReinforcementBars.NumberOfBars = 0;
				return;
			}
			#c6e #c6e = #c6e.#Dge(this.InvestigateReinforcement);
			int #qSe = #c6e.BarNumber[0];
			#ISe.#oSe(#c6e, #qSe);
			float #tSe = this.SectionDimensions[0] / 2f;
			float #sSe = this.#GSe(#tSe);
			if (reinforcementType == ReinforcementType.AllEqual)
			{
				if (this.#ESe(#c6e, #qSe, ref #sSe, ref #tSe))
				{
					return;
				}
			}
			else if (reinforcementType == ReinforcementType.EqualSpace)
			{
				this.#BSe(#c6e);
			}
			else
			{
				int num = 0;
				for (int i = 0; i < 4; i++)
				{
					num += #c6e.AmountOfBars[i];
				}
				this.ReinforcementBars.NumberOfBars = num;
			}
			if (this.Options.ClearCover[(int)this.Options.ProblemType] == ClearCover.ToTranverseBar)
			{
				for (int j = 0; j < 4; j++)
				{
					#c6e.ClearCover[j] += #ISe.#qP(#c6e.BarNumber[j], this.#a);
				}
			}
			this.#rSe(#c6e, #sSe, #tSe);
			this.#c.#yl();
		}

		// Token: 0x0600A10F RID: 41231 RVA: 0x00224A94 File Offset: 0x00222C94
		private static void #oSe(#c6e #pSe, int #qSe)
		{
			for (int i = 0; i < 4; i++)
			{
				if (#pSe.BarNumber[i] < 0)
				{
					#pSe.BarNumber[i] = #qSe;
				}
			}
		}

		// Token: 0x0600A110 RID: 41232 RVA: 0x00224AC4 File Offset: 0x00222CC4
		private void #rSe(#c6e #pSe, float #sSe, float #tSe)
		{
			int #vSe = 0;
			float #wSe = this.#ASe(#pSe, #sSe, #tSe, ref #vSe);
			float #xSe = this.#zSe(#pSe, #sSe, #tSe, ref #vSe);
			if (#pSe.AmountOfBars[2] > 0)
			{
				#vSe = this.#ySe(#pSe, #tSe, #vSe, #wSe, #xSe);
			}
			if (#pSe.AmountOfBars[3] > 0)
			{
				this.#uSe(#pSe, #tSe, #vSe, #wSe, #xSe);
			}
		}

		// Token: 0x0600A111 RID: 41233 RVA: 0x00224B18 File Offset: 0x00222D18
		private void #uSe(#c6e #pSe, float #tSe, int #vSe, float #wSe, float #xSe)
		{
			int num = #vSe;
			#vSe += #pSe.AmountOfBars[3];
			int num2 = #pSe.BarNumber[3];
			float num3 = this.InputModelBars[num2].Diameter;
			float #f = this.InputModelBars[num2].Area;
			float #f2 = #tSe - #pSe.ClearCover[3] - num3 / 2f;
			float num4 = #wSe;
			float num5 = (#wSe - #xSe) / (float)(#pSe.AmountOfBars[3] + 1);
			for (int i = num; i < #vSe; i++)
			{
				num4 -= num5;
				this.ReinforcementBars.Bars[i].Area = #f;
				this.ReinforcementBars.Bars[i].X = #f2;
				this.ReinforcementBars.Bars[i].Y = num4;
			}
		}

		// Token: 0x0600A112 RID: 41234 RVA: 0x00224BD4 File Offset: 0x00222DD4
		private int #ySe(#c6e #pSe, float #tSe, int #vSe, float #wSe, float #xSe)
		{
			int num = #vSe;
			#vSe += #pSe.AmountOfBars[2];
			int num2 = #pSe.BarNumber[2];
			float num3 = this.InputModelBars[num2].Diameter;
			float #f = this.InputModelBars[num2].Area;
			float #f2 = -#tSe + #pSe.ClearCover[2] + num3 / 2f;
			float num4 = #wSe;
			float num5 = (#wSe - #xSe) / (float)(#pSe.AmountOfBars[2] + 1);
			for (int i = num; i < #vSe; i++)
			{
				num4 -= num5;
				this.ReinforcementBars.Bars[i].Area = #f;
				this.ReinforcementBars.Bars[i].X = #f2;
				this.ReinforcementBars.Bars[i].Y = num4;
			}
			return #vSe;
		}

		// Token: 0x0600A113 RID: 41235 RVA: 0x00224C94 File Offset: 0x00222E94
		private float #zSe(#c6e #pSe, float #sSe, float #tSe, ref int #vSe)
		{
			float[] array = #pSe.ClearCover;
			int num = #vSe;
			#vSe += #pSe.AmountOfBars[1];
			int num2 = #pSe.BarNumber[1];
			float num3 = this.InputModelBars[num2].Diameter;
			float #f = this.InputModelBars[num2].Area;
			float num4 = -#sSe + array[1] + num3 / 2f;
			float num5 = -#tSe + array[2] + num3 / 2f;
			float num6 = (#tSe * 2f - array[2] - array[3] - num3) / ((float)#pSe.AmountOfBars[1] - 1f);
			for (int i = num; i < #vSe; i++)
			{
				this.ReinforcementBars.Bars[i].Area = #f;
				this.ReinforcementBars.Bars[i].X = num5;
				this.ReinforcementBars.Bars[i].Y = num4;
				num5 += num6;
			}
			return num4;
		}

		// Token: 0x0600A114 RID: 41236 RVA: 0x00224D7C File Offset: 0x00222F7C
		private float #ASe(#c6e #pSe, float #sSe, float #tSe, ref int #vSe)
		{
			float[] array = #pSe.ClearCover;
			int num = #vSe;
			#vSe += #pSe.AmountOfBars[0];
			int num2 = #pSe.BarNumber[0];
			float num3 = this.InputModelBars[num2].Diameter;
			float #f = this.InputModelBars[num2].Area;
			float num4 = #sSe - array[0] - num3 / 2f;
			float num5 = -#tSe + array[2] + num3 / 2f;
			float num6 = (#tSe * 2f - array[2] - array[3] - num3) / ((float)#pSe.AmountOfBars[0] - 1f);
			for (int i = num; i < #vSe; i++)
			{
				this.ReinforcementBars.Bars[i].Area = #f;
				this.ReinforcementBars.Bars[i].X = num5;
				this.ReinforcementBars.Bars[i].Y = num4;
				num5 += num6;
			}
			return num4;
		}

		// Token: 0x0600A115 RID: 41237 RVA: 0x00224E64 File Offset: 0x00223064
		private void #BSe(#c6e #pSe)
		{
			int num = #pSe.AmountOfBars[0];
			float num2 = this.#DSe(0);
			float num3 = this.#DSe(1);
			if (this.Options.ClearCover[(int)this.Options.ProblemType] == ClearCover.ToTranverseBar)
			{
				float num4 = 2f * #ISe.#qP(this.InvestigateReinforcement.BarNumber[0], this.#a);
				num2 -= num4;
				num3 -= num4;
			}
			this.#CSe(#pSe, num2, num3, num);
			for (int i = 1; i < 4; i++)
			{
				this.InvestigateReinforcement.AmountOfBars[i] = #pSe.AmountOfBars[i];
				this.InvestigateReinforcement.BarNumber[i] = this.InvestigateReinforcement.BarNumber[0];
				this.InvestigateReinforcement.ClearCover[i] = this.InvestigateReinforcement.ClearCover[0];
				#pSe.BarNumber[i] = this.InvestigateReinforcement.BarNumber[0];
				#pSe.ClearCover[i] = this.InvestigateReinforcement.ClearCover[0];
			}
			this.ReinforcementBars.NumberOfBars = num;
		}

		// Token: 0x0600A116 RID: 41238 RVA: 0x00224F6C File Offset: 0x0022316C
		private void #CSe(#c6e #pSe, float #6Q, float #5Q, int #Dbe)
		{
			float num = (float)this.InvestigateReinforcement.AmountOfBars[0] / (2f * (#6Q + #5Q));
			#pSe.AmountOfBars[0] = #xke.#ske(2, #xke.#wke((double)(#6Q * num + 0.5f)) + 1);
			#pSe.AmountOfBars[1] = #pSe.AmountOfBars[0];
			#pSe.AmountOfBars[2] = (this.InvestigateReinforcement.AmountOfBars[0] - 2 * #pSe.AmountOfBars[0]) / 2;
			#pSe.AmountOfBars[3] = #pSe.AmountOfBars[2];
			if (2 * #pSe.AmountOfBars[0] > #Dbe)
			{
				#pSe.AmountOfBars[2] = #xke.#ske(2, #xke.#wke((double)(#5Q * num + 0.5f)) + 1) - 2;
				#pSe.AmountOfBars[3] = #pSe.AmountOfBars[0];
				#pSe.AmountOfBars[0] = (#Dbe - 2 * #pSe.AmountOfBars[2]) / 2;
				#pSe.AmountOfBars[1] = #pSe.AmountOfBars[0];
			}
		}

		// Token: 0x0600A117 RID: 41239 RVA: 0x0022505C File Offset: 0x0022325C
		private float #DSe(int #oue)
		{
			float num = this.InputModelBars[this.InvestigateReinforcement.BarNumber[0]].Diameter;
			return this.SectionDimensions[#oue] - 2f * this.InvestigateReinforcement.ClearCover[0] - num;
		}

		// Token: 0x0600A118 RID: 41240 RVA: 0x002250A4 File Offset: 0x002232A4
		private bool #ESe(#c6e #pSe, int #qSe, ref float #sSe, ref float #tSe)
		{
			int num = #pSe.AmountOfBars[0];
			if (this.Options.ReinforcementLayout == #F6e.#b)
			{
				this.#FSe(#pSe, #qSe, #sSe, #tSe, num);
				return true;
			}
			int num2 = num / 4;
			if (num <= num2 * 4)
			{
				#pSe.AmountOfBars[0] = num2 + 1;
			}
			else
			{
				#pSe.AmountOfBars[0] = num2 + 2;
			}
			#pSe.AmountOfBars[1] = #pSe.AmountOfBars[0];
			#pSe.AmountOfBars[2] = num2 - 1;
			#pSe.AmountOfBars[3] = #pSe.AmountOfBars[2];
			for (int i = 1; i < 4; i++)
			{
				this.InvestigateReinforcement.AmountOfBars[i] = #pSe.AmountOfBars[i];
				this.InvestigateReinforcement.BarNumber[i] = this.InvestigateReinforcement.BarNumber[0];
				this.InvestigateReinforcement.ClearCover[i] = this.InvestigateReinforcement.ClearCover[0];
				#pSe.BarNumber[i] = #pSe.BarNumber[0];
				#pSe.ClearCover[i] = #pSe.ClearCover[0];
			}
			if (this.Options.SectionType == #G6e.#b)
			{
				float num3 = this.InputModelBars[#pSe.BarNumber[0]].Diameter;
				float num4 = #pSe.ClearCover[0];
				#tSe = (#tSe - num4 - num3 / 2f) * 0.70710677f + num4 + num3 / 2f;
				if (this.Options.ClearCover[(int)this.Options.ProblemType] == ClearCover.ToTranverseBar)
				{
					#tSe += #ISe.#qP(this.InvestigateReinforcement.BarNumber[0], this.#a) * 0.29289323f;
				}
				#sSe = #tSe;
			}
			this.ReinforcementBars.NumberOfBars = num;
			return false;
		}

		// Token: 0x0600A119 RID: 41241 RVA: 0x0022523C File Offset: 0x0022343C
		private void #FSe(#c6e #pSe, int #qSe, float #sSe, float #tSe, int #Dbe)
		{
			#A0e #A0e = this.InvestigateReinforcement;
			#A0e.AmountOfBars[1] = #A0e.AmountOfBars[0] / 2;
			#A0e.AmountOfBars[2] = (#A0e.AmountOfBars[3] = 0);
			for (int i = 1; i < 4; i++)
			{
				#A0e.BarNumber[i] = #A0e.BarNumber[0];
				#A0e.ClearCover[i] = #A0e.ClearCover[0];
			}
			float num = this.InputModelBars[#qSe].Diameter;
			float #f = this.InputModelBars[#qSe].Area;
			float num2 = (#sSe <= #tSe) ? #sSe : #tSe;
			if (this.Options.ClearCover[(int)this.Options.ProblemType] == ClearCover.ToTranverseBar)
			{
				#pSe.ClearCover[0] += #ISe.#qP(#A0e.BarNumber[0], this.#a);
			}
			num2 = num2 - #pSe.ClearCover[0] - num / 2f;
			float num3 = 6.2831855f / (float)#Dbe;
			for (int j = 0; j < #Dbe; j++)
			{
				float #pke = (float)j * num3;
				this.ReinforcementBars.Bars[j].Area = #f;
				this.ReinforcementBars.Bars[j].X = num2 * #xke.#qke(#pke);
				this.ReinforcementBars.Bars[j].Y = num2 * #xke.#oke(#pke);
			}
			this.ReinforcementBars.NumberOfBars = #Dbe;
			this.#c.#yl();
		}

		// Token: 0x0600A11A RID: 41242 RVA: 0x0007E639 File Offset: 0x0007C839
		private float #GSe(float #tSe)
		{
			if (this.Options.SectionType == #G6e.#b)
			{
				return #tSe;
			}
			return this.SectionDimensions[1] / 2f;
		}

		// Token: 0x0600A11B RID: 41243 RVA: 0x002253A8 File Offset: 0x002235A8
		private void #HSe()
		{
			this.#c.#yl();
			#A0e #A0e = this.InvestigateReinforcement;
			#A0e.AmountOfBars[1] = this.ReinforcementBars.NumberOfBars / 2;
			#A0e.AmountOfBars[2] = (#A0e.AmountOfBars[3] = 0);
			for (int i = 1; i < 4; i++)
			{
				#A0e.BarNumber[i] = #A0e.BarNumber[0];
				#A0e.ClearCover[i] = #A0e.ClearCover[0];
			}
		}

		// Token: 0x0400466F RID: 18031
		private readonly InputModel #a;

		// Token: 0x04004670 RID: 18032
		private readonly RuntimeModel #b;

		// Token: 0x04004671 RID: 18033
		private readonly #8Te #c;
	}
}
