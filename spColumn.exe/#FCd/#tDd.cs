using System;
using #7hc;
using #Qcd;
using #Ted;
using Aspose.Words;

namespace #FCd
{
	// Token: 0x02000D61 RID: 3425
	internal static class #tDd
	{
		// Token: 0x06007C69 RID: 31849 RVA: 0x000650D9 File Offset: 0x000632D9
		public static void #jDd(this #5Dd #Ipb, bool #kDd, string #lDd)
		{
			if (#Ipb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107251224));
			}
			if (#kDd)
			{
				#Ipb.#QDd(new string[]
				{
					#lDd
				});
			}
		}

		// Token: 0x06007C6A RID: 31850 RVA: 0x0006510D File Offset: 0x0006330D
		public static void #jDd(this #5Dd #Ipb, bool #mDd, bool #nDd, string #lDd, string #oDd)
		{
			if (#Ipb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107251224));
			}
			if (#mDd)
			{
				#Ipb.#QDd(new string[]
				{
					#nDd ? #lDd : #oDd
				});
			}
		}

		// Token: 0x06007C6B RID: 31851 RVA: 0x00065148 File Offset: 0x00063348
		public static void #pDd(this #5Dd #Ipb, bool #nDd, int #1f, string #lDd, ParagraphAlignment #rT = ParagraphAlignment.Left)
		{
			if (#Ipb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107251224));
			}
			if (#nDd)
			{
				#Ipb.#Fhd(#1f, #rT, new string[]
				{
					#lDd
				});
			}
		}

		// Token: 0x06007C6C RID: 31852 RVA: 0x0006517F File Offset: 0x0006337F
		public static void #qDd(this #5Dd #Ipb, bool #nDd, int #Upb)
		{
			if (#Ipb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107251224));
			}
			if (#nDd)
			{
				#Ipb.#rDd(#Upb);
			}
		}

		// Token: 0x06007C6D RID: 31853 RVA: 0x001B5ED0 File Offset: 0x001B40D0
		public static void #rDd(this #5Dd #Ipb, int #1f)
		{
			if (#Ipb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107251224));
			}
			for (int i = 0; i < #1f; i++)
			{
				#Ipb.#QDd(new string[]
				{
					string.Empty
				});
			}
		}

		// Token: 0x06007C6E RID: 31854 RVA: 0x000651AA File Offset: 0x000633AA
		public static void #jDd(this #5Dd #Ipb, bool #nDd, string #lDd, string #oDd)
		{
			if (#Ipb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107251224));
			}
			#Ipb.#QDd(new string[]
			{
				#nDd ? #lDd : #oDd
			});
		}

		// Token: 0x06007C6F RID: 31855 RVA: 0x001B5F1C File Offset: 0x001B411C
		public static void #sDd(this #5Dd #Ipb, double #f)
		{
			if (#Ipb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107251224));
			}
			if (#Ipb.#Jcd())
			{
				#Ihd #Ihd = #Ipb as #Ihd;
				if (#Ihd != null)
				{
					#Ihd.Renderer.ReferenceTableWidth = #f;
				}
			}
		}
	}
}
