using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using #7hc;
using Microsoft.Win32;

namespace StructurePoint.Kernel.CoreAssets.Importer.Core
{
	// Token: 0x02000E63 RID: 3683
	internal sealed class EtabsPathFinder
	{
		// Token: 0x060083DE RID: 33758 RVA: 0x001C61C4 File Offset: 0x001C43C4
		public static string #i7i()
		{
			string result;
			try
			{
				Logger.#pn(#Phc.#3hc(107269232));
				string[] array = EtabsPathFinder.#k7i(#Phc.#3hc(107269131)).Select(new Func<string, string>(EtabsPathFinder.<>c.<>9.#o7i)).Where(new Func<string, bool>(File.Exists)).ToArray<string>();
				if (!array.Any<string>())
				{
					Logger.#pn(#Phc.#3hc(107269122));
					result = null;
				}
				else
				{
					array = array.OrderByDescending(new Func<string, int>(EtabsPathFinder.<>c.<>9.#p7i)).ToArray<string>();
					Logger.#pn((#Phc.#3hc(107269577) + Environment.NewLine + string.Join(Environment.NewLine, array)).#Q1i(#Phc.#3hc(107464305), 1, true));
					string text = array.First<string>();
					Logger.#DSi(#Phc.#3hc(107269544) + text + #Phc.#3hc(107350811));
					result = text;
				}
			}
			catch (Exception #N1i)
			{
				Logger.#qn(#Phc.#3hc(107269531), #N1i);
				result = null;
			}
			return result;
		}

		// Token: 0x060083DF RID: 33759 RVA: 0x001C6304 File Offset: 0x001C4504
		public static string #j7i()
		{
			string result;
			try
			{
				Logger.#DSi(#Phc.#3hc(107269414));
				string directoryName = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
				if (directoryName == null)
				{
					Logger.#qn(#Phc.#3hc(107268837));
					result = null;
				}
				else
				{
					string text = Path.Combine(directoryName, #Phc.#3hc(107268824));
					Logger.#DSi(string.Concat(new string[]
					{
						#Phc.#3hc(107268771),
						Environment.NewLine,
						#Phc.#3hc(107350811),
						text,
						#Phc.#3hc(107350811)
					}).#Q1i(#Phc.#3hc(107464305), 1, true));
					if (!File.Exists(text))
					{
						Logger.#DSi(#Phc.#3hc(107268754));
						result = null;
					}
					else
					{
						Logger.#DSi(#Phc.#3hc(107268693));
						string text2 = File.ReadLines(text).Select(new Func<string, string>(EtabsPathFinder.<>c.<>9.#q7i)).FirstOrDefault(new Func<string, bool>(EtabsPathFinder.<>c.<>9.#r7i)) ?? #Phc.#3hc(107381628);
						if (string.IsNullOrWhiteSpace(text2))
						{
							Logger.#DSi(#Phc.#3hc(107268624));
							result = null;
						}
						else
						{
							Logger.#DSi(string.Concat(new string[]
							{
								#Phc.#3hc(107269079),
								Environment.NewLine,
								#Phc.#3hc(107350811),
								text2,
								#Phc.#3hc(107350811)
							}).#Q1i(#Phc.#3hc(107464305), 1, true));
							if (!Path.GetFileName(text2).Equals(#Phc.#3hc(107269026), StringComparison.InvariantCultureIgnoreCase))
							{
								Logger.#DSi(#Phc.#3hc(107269045));
								result = null;
							}
							else if (!File.Exists(text2))
							{
								Logger.#DSi(#Phc.#3hc(107268964));
								result = null;
							}
							else
							{
								result = text2;
							}
						}
					}
				}
			}
			catch (Exception #N1i)
			{
				Logger.#qn(#Phc.#3hc(107268955), #N1i);
				result = null;
			}
			return result;
		}

		// Token: 0x060083E0 RID: 33760 RVA: 0x001C6534 File Offset: 0x001C4734
		private static string[] #k7i(string #xxi)
		{
			EtabsPathFinder.#xTb #xTb = new EtabsPathFinder.#xTb();
			#xTb.#a = #xxi;
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(#Phc.#3hc(107268330));
			if (registryKey == null)
			{
				registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(#Phc.#3hc(107268330));
			}
			if (registryKey == null)
			{
				return null;
			}
			return registryKey.GetValueNames().Where(new Func<string, bool>(#xTb.#s7i)).ToArray<string>();
		}

		// Token: 0x04003659 RID: 13913
		private const string #a = "ETABS.exe";

		// Token: 0x0400365A RID: 13914
		private const string #b = "ETABS";

		// Token: 0x02000E65 RID: 3685
		[CompilerGenerated]
		private sealed class #xTb
		{
			// Token: 0x060083E9 RID: 33769 RVA: 0x0006B8C4 File Offset: 0x00069AC4
			internal bool #s7i(string #t7i)
			{
				return #t7i.IndexOf(this.#a, StringComparison.InvariantCultureIgnoreCase) > -1;
			}

			// Token: 0x04003660 RID: 13920
			public string #a;
		}
	}
}
