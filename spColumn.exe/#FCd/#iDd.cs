using System;
using #7hc;
using #Qcd;
using Aspose.Words.Tables;

namespace #FCd
{
	// Token: 0x02000D60 RID: 3424
	internal static class #iDd
	{
		// Token: 0x06007C66 RID: 31846 RVA: 0x0006506B File Offset: 0x0006326B
		public static void #fDd(this #5Dd #Ipb, float #6Q)
		{
			if (#Ipb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107251224));
			}
			#Ipb.EnforceTableAlignment = true;
			#Ipb.TableAlignment = TableAlignment.Left;
			#Ipb.PreferredWidth = #6Q;
		}

		// Token: 0x06007C67 RID: 31847 RVA: 0x000650A1 File Offset: 0x000632A1
		public static void #gDd(this #5Dd #Ipb)
		{
			#Ipb.AutoSizeMode = #sdd.#c;
			#Ipb.TableAlignment = TableAlignment.Left;
		}

		// Token: 0x06007C68 RID: 31848 RVA: 0x000650BD File Offset: 0x000632BD
		public static void #hDd(this #5Dd #Ipb)
		{
			#Ipb.AutoSizeMode = #sdd.#b;
			#Ipb.TableAlignment = TableAlignment.Center;
		}
	}
}
