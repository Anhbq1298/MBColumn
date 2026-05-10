using System;
using #7hc;
using #UYd;
using Microsoft.Win32;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #J6d
{
	// Token: 0x02000F3D RID: 3901
	internal static class #I6d
	{
		// Token: 0x06008A11 RID: 35345 RVA: 0x001D6C24 File Offset: 0x001D4E24
		public static bool #F6d(RegistryKey #G6d, string #So)
		{
			#X0d.#V0d(#G6d, #Phc.#3hc(107222262), Component.StorageFile, #Phc.#3hc(107222217));
			#X0d.#W0d(#So, #Phc.#3hc(107226730), Component.StorageFile, #Phc.#3hc(107222196));
			RegistryKey registryKey = #G6d.OpenSubKey(#So);
			if (registryKey != null)
			{
				registryKey.Dispose();
			}
			return registryKey != null;
		}

		// Token: 0x06008A12 RID: 35346 RVA: 0x001D6C88 File Offset: 0x001D4E88
		public static RegistryKey #H6d(RegistryKey #G6d, string #So)
		{
			#X0d.#V0d(#G6d, #Phc.#3hc(107222262), Component.StorageFile, #Phc.#3hc(107222143));
			if (string.IsNullOrEmpty(#So))
			{
				throw new ArgumentNullException(#Phc.#3hc(107226730));
			}
			if (!#I6d.#F6d(#G6d, #So))
			{
				#G6d.CreateSubKey(#So, RegistryKeyPermissionCheck.ReadWriteSubTree);
			}
			return #G6d.OpenSubKey(#So, RegistryKeyPermissionCheck.ReadWriteSubTree);
		}
	}
}
