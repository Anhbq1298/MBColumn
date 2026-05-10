using System;
using #hZe;
using #wUe;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Enums;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #KUe
{
	// Token: 0x020012E6 RID: 4838
	internal sealed class #SUe : #YUe
	{
		// Token: 0x0600A1AA RID: 41386 RVA: 0x0007EA41 File Offset: 0x0007CC41
		public #SUe(InputModel #hMe, RuntimeModel #iMe, Section #bLb) : base(#hMe, #iMe, #bLb)
		{
		}

		// Token: 0x0600A1AB RID: 41387 RVA: 0x0022842C File Offset: 0x0022662C
		protected override int #zUe(float #Udb, ref float #lTe, ref int #PE)
		{
			#C2e #C2e = new #C2e();
			#C2e #C2e2 = new #C2e();
			bool flag = false;
			int num = this.#RUe();
			int num2 = base.DesignReinforcement.BarNumber[0];
			int num3 = base.DesignReinforcement.BarNumber[1];
			int num4 = base.DesignReinforcement.AmountOfBars[0];
			int num5 = base.DesignReinforcement.AmountOfBars[1];
			this.#LUe(#Udb, num2, num3, num4, num5, num, #C2e, ref #lTe, ref #PE, ref flag);
			if (!flag)
			{
				return 0;
			}
			for (int i = num2; i <= num3; i++)
			{
				for (int j = num4; j <= num5; j += num)
				{
					base.RuntimeModel.#Fci();
					base.InvestigateReinforcement.BarNumber[0] = i;
					base.InvestigateReinforcement.AmountOfBars[0] = j;
					#OZe #OZe = base.Section.#jTe(i, j, #lTe, #Udb);
					#PE = (int)#OZe.Result;
					#lTe = #OZe.Usf;
					if (#xke.#U3(#PE))
					{
						this.#FUe(#C2e2, #lTe, i, j);
						if (#YUe.#XUe(#C2e2, #C2e))
						{
							#C2e.#mg(#C2e2);
						}
					}
				}
			}
			base.RuntimeModel.#Fci();
			base.InvestigateReinforcement.BarNumber[0] = #C2e.BarIndex;
			base.InvestigateReinforcement.AmountOfBars[0] = #C2e.TotalBarCount;
			base.Section.#jTe(#C2e.BarIndex, #C2e.TotalBarCount, #lTe, #Udb);
			return 1;
		}

		// Token: 0x0600A1AC RID: 41388 RVA: 0x00228594 File Offset: 0x00226794
		protected override int #yUe(float #Udb, ref float #lTe, ref int #PE)
		{
			int num = base.DesignReinforcement.BarNumber[0];
			int num2 = base.DesignReinforcement.BarNumber[1];
			int num3 = base.DesignReinforcement.AmountOfBars[0];
			int num4 = base.DesignReinforcement.AmountOfBars[1];
			int num5 = this.#RUe();
			for (int i = num3; i <= num4; i += num5)
			{
				for (int j = num; j <= num2; j++)
				{
					base.RuntimeModel.#Fci();
					base.InvestigateReinforcement.BarNumber[0] = j;
					base.InvestigateReinforcement.AmountOfBars[0] = i;
					#OZe #OZe = base.Section.#jTe(j, i, #lTe, #Udb);
					#PE = (int)#OZe.Result;
					#lTe = #OZe.Usf;
					if (#xke.#U3(#PE))
					{
						return 1;
					}
				}
			}
			return 0;
		}

		// Token: 0x0600A1AD RID: 41389 RVA: 0x0022865C File Offset: 0x0022685C
		private void #LUe(float #Udb, int #MUe, int #NUe, int #OUe, int #PUe, int #jEd, #C2e #BUe, ref float #QUe, ref int #PE, ref bool #CUe)
		{
			for (int i = #MUe; i <= #NUe; i++)
			{
				for (int j = #OUe; j <= #PUe; j += #jEd)
				{
					base.RuntimeModel.#Fci();
					base.InvestigateReinforcement.BarNumber[0] = i;
					base.InvestigateReinforcement.AmountOfBars[0] = j;
					#OZe #OZe = base.Section.#jTe(i, j, #QUe, #Udb);
					#PE = (int)#OZe.Result;
					#QUe = #OZe.Usf;
					if (#xke.#U3(#PE))
					{
						this.#FUe(#BUe, #QUe, i, j);
						#CUe = true;
					}
				}
			}
		}

		// Token: 0x0600A1AE RID: 41390 RVA: 0x002286F0 File Offset: 0x002268F0
		private void #FUe(#C2e #GUe, float #lTe, int #Ece, int #kTe)
		{
			#GUe.BarIndex = #Ece;
			#GUe.BarArea = base.InputModel.Bars[#Ece].Area;
			#GUe.TotalBarCount = #kTe;
			#GUe.TotalBarArea = #GUe.BarArea * (float)#GUe.TotalBarCount;
			#GUe.Usf = #lTe;
		}

		// Token: 0x0600A1AF RID: 41391 RVA: 0x00228740 File Offset: 0x00226940
		private int #RUe()
		{
			ReinforcementType[] array = base.InputModel.Options.ReinforcementType;
			#G6e #G6e = base.InputModel.Options.SectionType;
			if (array[1] == ReinforcementType.EqualSpace)
			{
				return 2;
			}
			if (array[1] == ReinforcementType.AllEqual && #G6e == #G6e.#b && base.InputModel.Options.ReinforcementLayout == #F6e.#a)
			{
				return 4;
			}
			if (array[1] != ReinforcementType.AllEqual)
			{
				return 0;
			}
			if (#G6e != #G6e.#b)
			{
				return 4;
			}
			return 1;
		}
	}
}
