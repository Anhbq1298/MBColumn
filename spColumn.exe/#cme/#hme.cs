using System;
using #7hc;

namespace #cme
{
	// Token: 0x020010D3 RID: 4307
	internal static class #hme
	{
		// Token: 0x06009287 RID: 37511 RVA: 0x001F0CA4 File Offset: 0x001EEEA4
		public static bool #dme(string #eme, string #fme)
		{
			if (#hme.#gme(#eme, #Phc.#3hc(107290951)))
			{
				return #hme.#gme(#Phc.#3hc(107290951), #fme) || #hme.#gme(#Phc.#3hc(107290966), #fme);
			}
			if (#hme.#gme(#eme, #Phc.#3hc(107290917)))
			{
				return #hme.#gme(#Phc.#3hc(107290917), #fme) || #hme.#gme(#Phc.#3hc(107290928), #fme);
			}
			return #hme.#gme(#eme, #fme);
		}

		// Token: 0x06009288 RID: 37512 RVA: 0x00075B6E File Offset: 0x00073D6E
		private static bool #gme(string #eme, string #fme)
		{
			#eme = ((#eme != null) ? #eme.Trim() : null);
			#fme = ((#fme != null) ? #fme.Trim() : null);
			return string.Equals(#eme, #fme, StringComparison.OrdinalIgnoreCase);
		}

		// Token: 0x04003E25 RID: 15909
		public const string #a = "#spColumn Text Input (CTI) File";

		// Token: 0x04003E26 RID: 15910
		public const string #b = "[spColumn Version]";

		// Token: 0x04003E27 RID: 15911
		public const string #c = "[Project]";

		// Token: 0x04003E28 RID: 15912
		public const string #d = "[Column ID]";

		// Token: 0x04003E29 RID: 15913
		public const string #e = "[Engineer]";

		// Token: 0x04003E2A RID: 15914
		public const string #f = "[Investigation Run Flag]";

		// Token: 0x04003E2B RID: 15915
		public const string #g = "[Design Run Flag]";

		// Token: 0x04003E2C RID: 15916
		public const string #h = "[Slenderness Flag]";

		// Token: 0x04003E2D RID: 15917
		public const string #i = "[User Options]";

		// Token: 0x04003E2E RID: 15918
		public const string #j = "[Irregular Options]";

		// Token: 0x04003E2F RID: 15919
		public const string #k = "[Ties]";

		// Token: 0x04003E30 RID: 15920
		public const string #l = "[Investigation Reinforcement]";

		// Token: 0x04003E31 RID: 15921
		public const string #m = "[Design Reinforcement]";

		// Token: 0x04003E32 RID: 15922
		public const string #n = "[Investigation Section Dimensions]";

		// Token: 0x04003E33 RID: 15923
		public const string #o = "[Design Section Dimensions]";

		// Token: 0x04003E34 RID: 15924
		public const string #p = "[Material Properties]";

		// Token: 0x04003E35 RID: 15925
		public const string #q = "[Reduction Factors]";

		// Token: 0x04003E36 RID: 15926
		public const string #r = "[Design Criteria]";

		// Token: 0x04003E37 RID: 15927
		public const string #s = "[External Points]";

		// Token: 0x04003E38 RID: 15928
		public const string #t = "[Internal Points]";

		// Token: 0x04003E39 RID: 15929
		public const string #u = "[Reinforcement Bars]";

		// Token: 0x04003E3A RID: 15930
		public const string #v = "[Factored Loads]";

		// Token: 0x04003E3B RID: 15931
		public const string #w = "[Slenderness: Column]";

		// Token: 0x04003E3C RID: 15932
		public const string #x = "[Slenderness: Column Above And Below]";

		// Token: 0x04003E3D RID: 15933
		public const string #y = "[Slenderness: Beams]";

		// Token: 0x04003E3E RID: 15934
		public const string #z = "[EI]";

		// Token: 0x04003E3F RID: 15935
		public const string #A = "[SldOptFact]";

		// Token: 0x04003E40 RID: 15936
		public const string #B = "[Phi_Delta]";

		// Token: 0x04003E41 RID: 15937
		public const string #C = "[Cracked I]";

		// Token: 0x04003E42 RID: 15938
		public const string #D = "[Service Loads]";

		// Token: 0x04003E43 RID: 15939
		public const string #E = "[Load Combinations]";

		// Token: 0x04003E44 RID: 15940
		public const string #F = "[BarGroupType]";

		// Token: 0x04003E45 RID: 15941
		public const string #G = "[User Defined Bars]";

		// Token: 0x04003E46 RID: 15942
		public const string #H = "[Sustained Load Factors]";

		// Token: 0x04003E47 RID: 15943
		private const string #I = "[CrackedI]";

		// Token: 0x04003E48 RID: 15944
		private const string #J = "[ServiceLoads]";
	}
}
