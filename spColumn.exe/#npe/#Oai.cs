using System;
using #7hc;
using #9pe;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace #npe
{
	// Token: 0x02001116 RID: 4374
	internal static class #Oai
	{
		// Token: 0x06009419 RID: 37913 RVA: 0x001F9230 File Offset: 0x001F7430
		public static bool #uC(#8pe #uai, #8pe #vai)
		{
			if (#uai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288762));
			}
			if (#vai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288753));
			}
			return #Oai.#e(#uai.FinalLoad, #vai.FinalLoad, 5) && #Oai.#e(#uai.Increment, #vai.Increment, 5) && #Oai.#e(#uai.InitialLoad, #vai.InitialLoad, 5);
		}

		// Token: 0x0600941A RID: 37914 RVA: 0x001F92A0 File Offset: 0x001F74A0
		public static bool #uC(#pqe #uai, #pqe #vai)
		{
			if (#uai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288762));
			}
			if (#vai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288753));
			}
			return #Oai.#uC(#uai.Dead, #vai.Dead) && #Oai.#uC(#uai.Live, #vai.Live) && #Oai.#uC(#uai.Snow, #vai.Snow) && #Oai.#uC(#uai.Wind, #vai.Wind) && #Oai.#uC(#uai.Earthquake, #vai.Earthquake);
		}

		// Token: 0x0600941B RID: 37915 RVA: 0x001F9334 File Offset: 0x001F7534
		public static bool #uC(#dqe #uai, #dqe #vai)
		{
			if (#uai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288762));
			}
			if (#vai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288753));
			}
			return #Oai.#e(#uai.AxialLoad, #vai.AxialLoad, 5) && #Oai.#e(#uai.MomentX, #vai.MomentX, 5) && #Oai.#e(#uai.MomentY, #vai.MomentY, 5);
		}

		// Token: 0x0600941C RID: 37916 RVA: 0x001F93A4 File Offset: 0x001F75A4
		public static bool #uC(#gqe #uai, #gqe #vai)
		{
			if (#uai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288762));
			}
			if (#vai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288753));
			}
			return #Oai.#e(#uai.Live, #vai.Live, 5) && #Oai.#e(#uai.Dead, #vai.Dead, 5) && #Oai.#e(#uai.Snow, #vai.Snow, 5) && #Oai.#e(#uai.Wind, #vai.Wind, 5) && #Oai.#e(#uai.Earthquake, #vai.Earthquake, 5);
		}

		// Token: 0x0600941D RID: 37917 RVA: 0x001F943C File Offset: 0x001F763C
		public static bool #uC(#kqe #wai, #kqe #xai)
		{
			if (#wai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288712));
			}
			if (#xai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288727));
			}
			return #Oai.#e(#wai.A, #xai.A, 5) && #Oai.#e(#wai.B, #xai.B, 5) && #Oai.#e(#wai.C, #xai.C, 5) && #Oai.#e(#wai.Trans, #xai.Trans, 5) && #Oai.#e(#wai.MinDimension, #xai.MinDimension, 5);
		}

		// Token: 0x0600941E RID: 37918 RVA: 0x001F94D4 File Offset: 0x001F76D4
		public static bool #uC(#Uai #yai, #Uai #zai)
		{
			if (#yai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288678));
			}
			if (#zai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288697));
			}
			return #Oai.#e(#yai.Fcp, #zai.Fcp, 5) && #Oai.#e(#yai.Ec, #zai.Ec, 5) && #Oai.#e(#yai.Fc, #zai.Fc, 5) && #Oai.#e(#yai.Beta1, #zai.Beta1, 5) && #Oai.#e(#yai.Eps, #zai.Eps, 5) && #yai.IsConcreteStandard == #zai.IsConcreteStandard && #yai.Precast == #zai.Precast;
		}

		// Token: 0x0600941F RID: 37919 RVA: 0x001F958C File Offset: 0x001F778C
		public static bool #uC(#Vai #Aai, #Vai #Bai)
		{
			if (#Aai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288652));
			}
			if (#Bai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288643));
			}
			return #Oai.#e(#Aai.Es, #Bai.Es, 5) && #Oai.#e(#Aai.Eyt, #Bai.Eyt, 5) && #Oai.#e(#Aai.Fy, #Bai.Fy, 5) && #Aai.IsSteelStandard == #Bai.IsSteelStandard;
		}

		// Token: 0x06009420 RID: 37920 RVA: 0x001F960C File Offset: 0x001F780C
		public static bool #uC(IStandardBar #Cai, IStandardBar #Dai)
		{
			if (#Cai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288666));
			}
			if (#Dai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288657));
			}
			return #Oai.#e(#Cai.Diameter, #Dai.Diameter, 3) && #Oai.#e(#Cai.Area, #Dai.Area, 3) && #Oai.#e((float)#Cai.Size, (float)#Dai.Size, 5) && #Oai.#e(#Cai.Weight, #Dai.Weight, 3);
		}

		// Token: 0x06009421 RID: 37921 RVA: 0x001F9694 File Offset: 0x001F7894
		public static bool #uC(IBeam #Eai, IBeam #Fai)
		{
			if (#Eai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288616));
			}
			if (#Fai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288639));
			}
			return #Oai.#e(#Eai.Width, #Fai.Width, 5) && #Oai.#e(#Eai.MofI, #Fai.MofI, 5) && #Oai.#e(#Eai.Length, #Fai.Length, 5) && #Oai.#e(#Eai.Fcp, #Fai.Fcp, 5) && #Oai.#e(#Eai.Ec, #Fai.Ec, 5) && #Oai.#e(#Eai.Depth, #Fai.Depth, 5) && #Eai.BeamType == #Fai.BeamType && #Eai.IsConcreteStandard == #Fai.IsConcreteStandard && #Eai.IsInertiaStandard == #Fai.IsInertiaStandard;
		}

		// Token: 0x06009422 RID: 37922 RVA: 0x001F9770 File Offset: 0x001F7970
		public static bool #uC(ISlendernessOfDesignedColumn #Gai, ISlendernessOfDesignedColumn #Hai)
		{
			if (#Gai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288630));
			}
			if (#Hai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288577));
			}
			return #Oai.#e(#Gai.Height, #Hai.Height, 5) && #Oai.#e(#Gai.Kbraced, #Hai.Kbraced, 5) && #Oai.#e(#Gai.Ksway, #Hai.Ksway, 5) && #Oai.#e(#Gai.SumPc, #Hai.SumPc, 5) && #Oai.#e(#Gai.SumPu, #Hai.SumPu, 5) && #Gai.CheckSwayAtEndsOnly == #Hai.CheckSwayAtEndsOnly && #Gai.IsBraced == #Hai.IsBraced && #Gai.EndCondition == #Hai.EndCondition && #Gai.Kmode == #Hai.Kmode;
		}

		// Token: 0x06009423 RID: 37923 RVA: 0x001F9844 File Offset: 0x001F7A44
		public static bool #uC(#rqe #Iai, #rqe #Jai)
		{
			if (#Iai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107289068));
			}
			if (#Jai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107289075));
			}
			return #Oai.#e(#Iai.Height, #Jai.Height, 5) && #Oai.#e(#Iai.Depth, #Jai.Depth, 5) && #Oai.#e(#Iai.Width, #Jai.Width, 5) && #Oai.#e(#Iai.Ec, #Jai.Ec, 5) && #Oai.#e(#Iai.Fcp, #Jai.Fcp, 5) && #Iai.SlendernessColumnType == #Jai.SlendernessColumnType && #Iai.IsConcreteStandard == #Jai.IsConcreteStandard;
		}

		// Token: 0x06009424 RID: 37924 RVA: 0x001F98FC File Offset: 0x001F7AFC
		public static bool #uC(IReinforcementRatios #Kai, IReinforcementRatios #Lai)
		{
			if (#Kai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107289050));
			}
			if (#Lai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107289021));
			}
			return #Oai.#e(#Kai.MinReinforcementRatio, #Lai.MinReinforcementRatio * 100f, 5) && #Oai.#e(#Kai.MaxReinforcementRatio, #Lai.MaxReinforcementRatio * 100f, 5);
		}

		// Token: 0x06009425 RID: 37925 RVA: 0x001F9964 File Offset: 0x001F7B64
		public static bool #uC(#Xpe #Mai, #Xpe #Nai)
		{
			if (#Mai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288960));
			}
			if (#Nai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288935));
			}
			return #Oai.#e(#Mai.CrackedIBeams, #Nai.CrackedIBeams, 5) && #Oai.#e(#Mai.CrackedIColumn, #Nai.CrackedIColumn, 5) && #Oai.#e(#Mai.StiffnessReductionFactorPhi, #Nai.StiffnessReductionFactorPhi, 5);
		}

		// Token: 0x06009426 RID: 37926 RVA: 0x0007662B File Offset: 0x0007482B
		private static bool #e(float #4gb, float #5gb, int #8W = 5)
		{
			return (double)Math.Abs(#4gb - #5gb) < Math.Pow(10.0, (double)(-(double)#8W));
		}

		// Token: 0x06009427 RID: 37927 RVA: 0x001F99D4 File Offset: 0x001F7BD4
		private static bool #uC(#qqe #uai, #qqe #vai)
		{
			if (#uai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288762));
			}
			if (#vai == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107288753));
			}
			return #uai.AxialLoad == #vai.AxialLoad && #uai.MomentXBottom == #vai.MomentXBottom && #uai.MomentXTop == #vai.MomentXTop && #uai.MomentYBottom == #vai.MomentYBottom && #uai.MomentYTop == #vai.MomentYTop;
		}
	}
}
