using System;
using System.Diagnostics;
using #7hc;
using Microsoft.Win32;

namespace #v1c
{
	// Token: 0x02000CBC RID: 3260
	internal static class #G1c
	{
		// Token: 0x06006A61 RID: 27233 RVA: 0x00053FC9 File Offset: 0x000521C9
		public static void #jhc(string #Jl)
		{
			for (;;)
			{
				if (#Jl == null)
				{
					if (8 != 0)
					{
						break;
					}
				}
				else
				{
					do
					{
						ProcessStartInfo processStartInfo = new ProcessStartInfo();
						processStartInfo.FileName = #Jl;
						bool useShellExecute = true;
						if (4 != 0)
						{
							processStartInfo.UseShellExecute = useShellExecute;
						}
						Process.Start(processStartInfo);
					}
					while (false);
					if (!false)
					{
						return;
					}
				}
			}
			throw new ArgumentNullException(#Phc.#3hc(107381753));
		}

		// Token: 0x06006A62 RID: 27234 RVA: 0x0019CC80 File Offset: 0x0019AE80
		public static string #F1c()
		{
			string text;
			do
			{
				if (true)
				{
					string empty = string.Empty;
					if (!false)
					{
						text = empty;
					}
				}
			}
			while (false);
			RegistryKey registryKey = null;
			RegistryKey registryKey2;
			if (!false)
			{
				registryKey2 = registryKey;
			}
			try
			{
				RegistryKey registryKey3 = Registry.ClassesRoot.OpenSubKey(#Phc.#3hc(107430592), false);
				if (5 != 0)
				{
					registryKey2 = registryKey3;
				}
				string result;
				if (registryKey2 == null)
				{
					string empty2 = string.Empty;
					if (8 != 0)
					{
						result = empty2;
					}
					return result;
				}
				string text2 = registryKey2.GetValue(null).ToString().Replace(#Phc.#3hc(107350811), string.Empty);
				if (!false)
				{
					text = text2;
				}
				if (string.IsNullOrWhiteSpace(text))
				{
					string empty3 = string.Empty;
					if (5 != 0)
					{
						result = empty3;
					}
					return result;
				}
				if (!text.EndsWith(#Phc.#3hc(107430591), StringComparison.OrdinalIgnoreCase))
				{
					text = text.Substring(0, text.LastIndexOf(#Phc.#3hc(107430586), StringComparison.OrdinalIgnoreCase) + 4);
				}
			}
			catch (Exception)
			{
			}
			finally
			{
				if (registryKey2 != null)
				{
					registryKey2.Close();
				}
			}
			return text;
		}
	}
}
