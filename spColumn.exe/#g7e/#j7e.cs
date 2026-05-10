using System;
using System.Collections.Generic;
using #7hc;
using #y6e;
using StructurePoint.CoreAssets.Localizer;

namespace #g7e
{
	// Token: 0x0200138C RID: 5004
	internal static class #j7e
	{
		// Token: 0x0600A77E RID: 42878 RVA: 0x00232D10 File Offset: 0x00230F10
		public static string #h7e(#M6e #3)
		{
			string result;
			if (!#j7e.#a.TryGetValue(#3, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0600A77F RID: 42879 RVA: 0x00232D30 File Offset: 0x00230F30
		public static string #i7e(#M6e #3)
		{
			string result;
			if (!#j7e.#b.TryGetValue(#3, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x04004A26 RID: 18982
		private static readonly Dictionary<#M6e, string> #a = new Dictionary<#M6e, string>
		{
			{
				#M6e.#a,
				#Phc.#3hc(107311449)
			},
			{
				#M6e.#b,
				#Phc.#3hc(107311380)
			},
			{
				#M6e.#c,
				#Phc.#3hc(107310767)
			},
			{
				#M6e.#d,
				#Phc.#3hc(107310778)
			},
			{
				#M6e.#e,
				#Phc.#3hc(107310749)
			},
			{
				#M6e.#f,
				#Phc.#3hc(107310696)
			},
			{
				#M6e.#g,
				#Phc.#3hc(107310655)
			},
			{
				#M6e.#h,
				#Phc.#3hc(107311090)
			},
			{
				#M6e.#i,
				#Phc.#3hc(107311057)
			},
			{
				#M6e.#k,
				#Phc.#3hc(107310984)
			},
			{
				#M6e.#l,
				#Phc.#3hc(107310927)
			},
			{
				#M6e.#m,
				#Phc.#3hc(107310330)
			},
			{
				#M6e.#n,
				#Phc.#3hc(107310209)
			},
			{
				#M6e.#o,
				#Phc.#3hc(107310192)
			},
			{
				#M6e.#p,
				#Phc.#3hc(107310139)
			},
			{
				#M6e.#q,
				#Phc.#3hc(107310574)
			},
			{
				#M6e.#r,
				#Phc.#3hc(107310585)
			},
			{
				#M6e.#s,
				#Phc.#3hc(107310552)
			},
			{
				#M6e.#t,
				#Phc.#3hc(107310527)
			},
			{
				#M6e.#u,
				#Phc.#3hc(107310514)
			},
			{
				#M6e.#v,
				#Phc.#3hc(107310485)
			},
			{
				#M6e.#w,
				#Phc.#3hc(107310420)
			},
			{
				#M6e.#y,
				#Phc.#3hc(107310347)
			}
		};

		// Token: 0x04004A27 RID: 18983
		private static readonly Dictionary<#M6e, string> #b = new Dictionary<#M6e, string>
		{
			{
				#M6e.#i,
				Strings.StringMessageCodeIdsServ1001
			},
			{
				#M6e.#j,
				Strings.StringMessageCodeIdsServ1008
			},
			{
				#M6e.#k,
				Strings.StringMessageCodeIdsPugtpcrit
			},
			{
				#M6e.#l,
				Strings.StringMessageCodeIdsSwayunstable
			},
			{
				#M6e.#m,
				Strings.StringMessageCodeIdsSecordmax
			},
			{
				#M6e.#n,
				Strings.StringMessageCodeIdsLtasmin
			},
			{
				#M6e.#o,
				Strings.StringMessageCodeIdsGtasmax
			},
			{
				#M6e.#p,
				Strings.StringMessageCodeIdsLtminspacing
			},
			{
				#M6e.#h,
				Strings.StringMessageCodeIdsCapinadqt
			},
			{
				#M6e.#r,
				Strings.StringMessageCodeIdsNeedprop
			},
			{
				#M6e.#c,
				Strings.StringMessageCodeIdsNeedconc
			},
			{
				#M6e.#s,
				Strings.StringMessageCodeIdsNeedreinf
			},
			{
				#M6e.#t,
				Strings.StringMessageCodeIdsNeedloads
			},
			{
				#M6e.#u,
				Strings.StringMessageCodeIdsNeeddescol
			},
			{
				#M6e.#v,
				Strings.StringMessageCodeIdsNeedcolabvblw
			},
			{
				#M6e.#w,
				Strings.StringMessageCodeIdsNeedbeams
			},
			{
				#M6e.#a,
				Strings.StringMessageCodeIdsMatInvalidEyt
			},
			{
				#M6e.#b,
				Strings.StringMessageCodeIdsMatInvalidFc
			},
			{
				#M6e.#d,
				Strings.StringMessageCodeIdsBatchBarsoutsidesection
			},
			{
				#M6e.#e,
				Strings.StringMessageCodeIdsSteelExceeded
			},
			{
				#M6e.#f,
				Strings.StringMessageCodeIdsMinlimits
			},
			{
				#M6e.#g,
				Strings.StringMessageCodeIdsMaxlimits
			},
			{
				#M6e.#z,
				Strings.StringMessageCodeIdsKlurgt100
			},
			{
				#M6e.#A,
				Strings.StringMessageCodeIdsPugtpcrit
			},
			{
				#M6e.#y,
				Strings.StringMessageCodeIdsMomconverge
			}
		};
	}
}
