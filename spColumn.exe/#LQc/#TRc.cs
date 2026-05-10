using System;
using System.Diagnostics.CodeAnalysis;
using #7hc;
using #UYd;
using Alphaleonis.Win32.Filesystem;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #LQc
{
	// Token: 0x02000C3E RID: 3134
	internal static class #TRc
	{
		// Token: 0x06006599 RID: 26009 RVA: 0x0018EF38 File Offset: 0x0018D138
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "3#")]
		public static bool #NRc(string #ORc, HelpID #PRc, string #QRc, out string #RRc)
		{
			string #R0d = #Phc.#3hc(107443034);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107443025);
			if (!false)
			{
				#X0d.#V0d(#PRc, #R0d, #x6c, #Qic);
			}
			string #R0d2 = #Phc.#3hc(107442972);
			Component #x6c2 = Component.GUIFramework;
			string #Qic2 = #Phc.#3hc(107442411);
			if (!false)
			{
				#X0d.#W0d(#ORc, #R0d2, #x6c2, #Qic2);
			}
			string #R0d3 = #Phc.#3hc(107442390);
			Component #x6c3 = Component.GUIFramework;
			string #Qic3 = #Phc.#3hc(107442341);
			if (3 != 0)
			{
				#X0d.#W0d(#QRc, #R0d3, #x6c3, #Qic3);
			}
			#RRc = null;
			string fileName = Path.GetFileName(#ORc);
			string #f;
			if (-1 != 0)
			{
				#f = fileName;
			}
			if (#f.#7tc(#Phc.#3hc(107442320), StringComparison.OrdinalIgnoreCase))
			{
				#RRc = #Phc.#3hc(107442275).#D2d(new object[]
				{
					#TRc.#SRc(#PRc),
					#QRc
				});
				return true;
			}
			if (#f.#7tc(#Phc.#3hc(107442214), StringComparison.OrdinalIgnoreCase))
			{
				#RRc = #Phc.#3hc(107442229).#D2d(new object[]
				{
					#TRc.#SRc(#PRc),
					#QRc
				});
				return true;
			}
			if (#f.#7tc(#Phc.#3hc(107442196), StringComparison.OrdinalIgnoreCase))
			{
				#RRc = #Phc.#3hc(107442667).#D2d(new object[]
				{
					#TRc.#SRc(#PRc),
					#QRc
				});
				return true;
			}
			if (#ORc.#7tc(#Phc.#3hc(107442634), StringComparison.OrdinalIgnoreCase))
			{
				#RRc = #Phc.#3hc(107442275).#D2d(new object[]
				{
					#TRc.#SRc(#PRc),
					#QRc
				});
				return true;
			}
			return false;
		}

		// Token: 0x0600659A RID: 26010 RVA: 0x00051F32 File Offset: 0x00050132
		private static string #SRc(HelpID #PRc)
		{
			return #PRc.Identifier;
		}
	}
}
