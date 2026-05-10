using System;
using #hZe;
using #wUe;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #KUe
{
	// Token: 0x020012E3 RID: 4835
	internal sealed class #JUe : #YUe
	{
		// Token: 0x0600A199 RID: 41369 RVA: 0x0007EA41 File Offset: 0x0007CC41
		public #JUe(InputModel #hMe, RuntimeModel #iMe, Section #bLb) : base(#hMe, #iMe, #bLb)
		{
		}

		// Token: 0x0600A19A RID: 41370 RVA: 0x00227F64 File Offset: 0x00226164
		protected override int #yUe(float #Udb, ref float #lTe, ref int #PE)
		{
			int num = base.DesignReinforcement.AmountOfBars[0];
			int num2 = base.DesignReinforcement.AmountOfBars[1];
			int num3 = base.DesignReinforcement.AmountOfBars[2];
			int num4 = base.DesignReinforcement.AmountOfBars[3];
			int num5 = base.DesignReinforcement.BarNumber[0];
			int num6 = base.DesignReinforcement.BarNumber[1];
			for (int i = num3; i <= num4; i += 2)
			{
				for (int j = num; j <= num2; j += 2)
				{
					for (int k = num5; k <= num6; k++)
					{
						base.RuntimeModel.#Fci();
						base.InvestigateReinforcement.#oSe(k);
						base.InvestigateReinforcement.#z0e(j, i);
						int #kTe = i + j;
						#OZe #OZe = base.Section.#jTe(k, #kTe, #lTe, #Udb);
						#PE = (int)#OZe.Result;
						#lTe = #OZe.Usf;
						if (#xke.#U3(#PE))
						{
							return 1;
						}
					}
				}
			}
			return 0;
		}

		// Token: 0x0600A19B RID: 41371 RVA: 0x00228060 File Offset: 0x00226260
		protected override int #zUe(float #Udb, ref float #lTe, ref int #PE)
		{
			#8Ze #8Ze = new #8Ze();
			#8Ze #EUe = new #8Ze();
			bool flag = false;
			this.#AUe(#Udb, #8Ze, ref #lTe, ref #PE, ref flag);
			if (!flag)
			{
				return 0;
			}
			#lTe = this.#DUe(#Udb, #lTe, #EUe, #8Ze);
			base.InvestigateReinforcement.#CSe(#8Ze);
			base.InvestigateReinforcement.#oSe(#8Ze.BarIndex);
			base.RuntimeModel.#Fci();
			base.Section.#jTe(#8Ze.BarIndex, #8Ze.TotalBarCount, #lTe, #Udb);
			return 1;
		}

		// Token: 0x0600A19C RID: 41372 RVA: 0x002280E0 File Offset: 0x002262E0
		private void #AUe(float #Udb, #8Ze #BUe, ref float #lTe, ref int #PE, ref bool #CUe)
		{
			int num = base.DesignReinforcement.AmountOfBars[0];
			int num2 = base.DesignReinforcement.AmountOfBars[1];
			int num3 = base.DesignReinforcement.AmountOfBars[2];
			int num4 = base.DesignReinforcement.AmountOfBars[3];
			int num5 = base.DesignReinforcement.BarNumber[0];
			int num6 = base.DesignReinforcement.BarNumber[1];
			for (int i = num5; i <= num6; i++)
			{
				for (int j = num; j <= num2; j += 2)
				{
					for (int k = num3; k <= num4; k += 2)
					{
						base.RuntimeModel.#Fci();
						base.InvestigateReinforcement.#oSe(i);
						base.InvestigateReinforcement.#z0e(j, k);
						int #kTe = k + j;
						#OZe #OZe = base.Section.#jTe(i, #kTe, #lTe, #Udb);
						#PE = (int)#OZe.Result;
						#lTe = #OZe.Usf;
						if (#xke.#U3(#PE))
						{
							this.#FUe(#BUe, #lTe, i, j, k, #kTe);
							#CUe = true;
						}
					}
				}
			}
		}

		// Token: 0x0600A19D RID: 41373 RVA: 0x002281F4 File Offset: 0x002263F4
		private float #DUe(float #Udb, float #lTe, #8Ze #EUe, #8Ze #BUe)
		{
			int num = base.DesignReinforcement.AmountOfBars[0];
			int num2 = base.DesignReinforcement.AmountOfBars[1];
			int num3 = base.DesignReinforcement.AmountOfBars[2];
			int num4 = base.DesignReinforcement.AmountOfBars[3];
			int num5 = base.DesignReinforcement.BarNumber[0];
			int num6 = base.DesignReinforcement.BarNumber[1];
			for (int i = num5; i <= num6; i++)
			{
				for (int j = num; j <= num2; j += 2)
				{
					for (int k = num3; k <= num4; k += 2)
					{
						base.RuntimeModel.#Fci();
						base.InvestigateReinforcement.#oSe(i);
						base.InvestigateReinforcement.#z0e(j, k);
						int #kTe = k + j;
						#OZe #OZe = base.Section.#jTe(i, #kTe, #lTe, #Udb);
						#lTe = #OZe.Usf;
						if (#xke.#U3((int)#OZe.Result))
						{
							this.#FUe(#EUe, #lTe, i, j, k, #kTe);
							if (#YUe.#XUe(#EUe, #BUe))
							{
								#BUe.#mg(#EUe);
							}
						}
					}
				}
			}
			return #lTe;
		}

		// Token: 0x0600A19E RID: 41374 RVA: 0x0022830C File Offset: 0x0022650C
		private void #FUe(#8Ze #GUe, float #lTe, int #Ece, int #HUe, int #IUe, int #kTe)
		{
			#GUe.BarIndex = #Ece;
			#GUe.BarArea = base.InputModel.Bars[#Ece].Area;
			#GUe.TopBarCount = #HUe / 2;
			#GUe.SideBarCount = #IUe / 2;
			#GUe.TotalBarCount = #kTe;
			#GUe.TotalBarArea = #GUe.BarArea * (float)#GUe.TotalBarCount;
			#GUe.Usf = #lTe;
		}
	}
}
