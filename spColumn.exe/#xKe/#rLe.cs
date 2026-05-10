using System;
using #9pe;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Units;

namespace #xKe
{
	// Token: 0x0200127B RID: 4731
	internal sealed class #rLe
	{
		// Token: 0x06009EA4 RID: 40612 RVA: 0x0007CCFD File Offset: 0x0007AEFD
		public void #5Uh(#Uai #OQ, UnitSystem #Qg, DesignCodes #is)
		{
			if (#OQ.IsConcreteStandard && #OQ.Fcp > 0f)
			{
				this.#jLe(#OQ, #is, #Qg == UnitSystem.USCustomary);
				#OQ.Eps = this.#nLe(#is);
			}
		}

		// Token: 0x06009EA5 RID: 40613 RVA: 0x0007CD2D File Offset: 0x0007AF2D
		public void #NQ(#jqe #OQ, UnitSystem #Qg, DesignCodes #is)
		{
			this.#5Uh(#OQ, #Qg, #is);
			this.#4Uh(#OQ, #Qg, #is);
		}

		// Token: 0x06009EA6 RID: 40614 RVA: 0x0021A450 File Offset: 0x00218650
		public void #4Uh(#Vai #OQ, UnitSystem #Qg, DesignCodes #is)
		{
			if (#OQ.IsSteelStandard)
			{
				this.#hLe(#OQ, #is, #Qg == UnitSystem.USCustomary);
				return;
			}
			if (!#OQ.IsSteelStandard && new #N5e((#A5e)#is).IsCodeCsa)
			{
				#OQ.Eyt = this.#pLe(#is, #OQ.Fy, #OQ.Es);
			}
		}

		// Token: 0x06009EA7 RID: 40615 RVA: 0x0007CD41 File Offset: 0x0007AF41
		private void #hLe(#Vai #OQ, DesignCodes #3, bool #iLe)
		{
			#OQ.Es = this.#oLe(#iLe);
			#OQ.Eyt = this.#pLe(#3, #OQ.Fy, #OQ.Es);
		}

		// Token: 0x06009EA8 RID: 40616 RVA: 0x0007CD69 File Offset: 0x0007AF69
		private void #jLe(#Uai #OQ, DesignCodes #3, bool #iLe)
		{
			#OQ.Ec = this.#kLe(#OQ.Fcp, #3, #iLe);
			#OQ.Fc = this.#lLe(#OQ.Fcp, #3, #iLe);
			#OQ.Beta1 = this.#mLe(#OQ.Fcp, #3, #iLe);
		}

		// Token: 0x06009EA9 RID: 40617 RVA: 0x0021A4A0 File Offset: 0x002186A0
		private float #kLe(float #3Q, DesignCodes #3, bool #iLe)
		{
			float num = 0f;
			if (#3Q <= 0f)
			{
				return 0f;
			}
			switch (#3)
			{
			case DesignCodes.ACI02:
			case DesignCodes.ACI05:
			case DesignCodes.ACI08:
			case DesignCodes.ACI11:
			case DesignCodes.ACI14:
			case DesignCodes.ACI19:
				num = (#iLe ? (1802.5f * (float)Math.Sqrt((double)#3Q)) : (4700f * (float)Math.Sqrt((double)#3Q)));
				break;
			case DesignCodes.CSA94:
			case DesignCodes.CSA04:
			case DesignCodes.CSA14:
			case DesignCodes.CSA19:
				if (#iLe)
				{
					#3Q *= 6.895f;
				}
				num = 3517.51f * (float)Math.Sqrt((double)#3Q) + 7354.864f;
				if (#iLe)
				{
					num /= 6.895f;
				}
				break;
			}
			return num;
		}

		// Token: 0x06009EAA RID: 40618 RVA: 0x0021A544 File Offset: 0x00218744
		private float #lLe(float #3Q, DesignCodes #3, bool #iLe)
		{
			float num = 0f;
			if (#3Q <= 0f)
			{
				return 0f;
			}
			switch (#3)
			{
			case DesignCodes.ACI02:
			case DesignCodes.ACI05:
			case DesignCodes.ACI08:
			case DesignCodes.ACI11:
			case DesignCodes.ACI14:
			case DesignCodes.ACI19:
				num = 0.85f * #3Q;
				break;
			case DesignCodes.CSA94:
			case DesignCodes.CSA04:
			case DesignCodes.CSA14:
			case DesignCodes.CSA19:
				num = 0.85f - 0.0015f * #3Q * (#iLe ? 6.895f : 1f);
				num = Math.Max(num, 0.67f) * #3Q;
				break;
			}
			return num;
		}

		// Token: 0x06009EAB RID: 40619 RVA: 0x0021A5CC File Offset: 0x002187CC
		private float #mLe(float #3Q, DesignCodes #3, bool #iLe)
		{
			float num = 0f;
			if (#3Q == 0f)
			{
				return 0f;
			}
			switch (#3)
			{
			case DesignCodes.ACI02:
			case DesignCodes.ACI05:
			case DesignCodes.ACI08:
			case DesignCodes.ACI11:
			case DesignCodes.ACI14:
			case DesignCodes.ACI19:
				num = 1.05f - 0.05f * #3Q * (#iLe ? 1f : 0.145033f);
				num = Math.Min(0.85f, Math.Max(0.65f, num));
				break;
			case DesignCodes.CSA94:
			case DesignCodes.CSA04:
			case DesignCodes.CSA14:
			case DesignCodes.CSA19:
				num = 0.97f - 0.0025f * #3Q * (#iLe ? 6.895f : 1f);
				num = Math.Max(num, 0.67f);
				break;
			}
			return num;
		}

		// Token: 0x06009EAC RID: 40620 RVA: 0x0007CDA7 File Offset: 0x0007AFA7
		private float #nLe(DesignCodes #3)
		{
			if (!new #N5e((#A5e)#3).IsCodeCsa)
			{
				return 0.003f;
			}
			return 0.0035f;
		}

		// Token: 0x06009EAD RID: 40621 RVA: 0x0007CDC1 File Offset: 0x0007AFC1
		private float #oLe(bool #iLe)
		{
			if (!#iLe)
			{
				return 200000f;
			}
			return 29000f;
		}

		// Token: 0x06009EAE RID: 40622 RVA: 0x0021A680 File Offset: 0x00218880
		private float #pLe(DesignCodes #3, float #Mje, float #qLe)
		{
			float num = 0.002f;
			if (#qLe > 0f)
			{
				num = #Mje / #qLe;
			}
			if (new #N5e((#A5e)#3).IsCodeCsa || num < 0.005f)
			{
				return num;
			}
			return 0.002f;
		}
	}
}
