using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using #aic;

namespace #qhc
{
	// Token: 0x02000732 RID: 1842
	internal sealed class #xhc
	{
		// Token: 0x06003C9B RID: 15515
		[DllImport("kernel32", EntryPoint = "MoveFileEx")]
		private static extern bool #rhc(string #shc, string #thc, int #ri);

		// Token: 0x1700125E RID: 4702
		// (get) Token: 0x06003C9C RID: 15516 RVA: 0x0011A310 File Offset: 0x00118510
		internal static bool IsWebApplication
		{
			get
			{
				try
				{
					string a = Process.GetCurrentProcess().MainModule.ModuleName.ToLower();
					if (a == "w3wp.exe")
					{
						return true;
					}
					if (a == "aspnet_wp.exe")
					{
						return true;
					}
				}
				catch
				{
				}
				return false;
			}
		}

		// Token: 0x06003C9D RID: 15517 RVA: 0x0011A378 File Offset: 0x00118578
		internal static void #vhc()
		{
			try
			{
				AppDomain.CurrentDomain.AssemblyResolve += #xhc.#whc;
			}
			catch
			{
			}
		}

		// Token: 0x06003C9E RID: 15518 RVA: 0x0011A3B8 File Offset: 0x001185B8
		internal static Assembly #whc(object #Ge, ResolveEventArgs #He)
		{
			#xhc.#Dhc #Dhc = new #xhc.#Dhc(#He.Name);
			string s = #Dhc.#Bhc(false);
			string b = Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
			string[] array = "ezY1NmJmMWYwLWQ4MTktNGJkYS05OTgzLWM4OWY3ZjAwMGY4MH0sIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49M2U1NjM1MDY5M2Y3MzU1ZQ==,[z]{13a9d942-da3a-4c44-9862-cdaf299b4b28},ezY1NmJmMWYwLWQ4MTktNGJkYS05OTgzLWM4OWY3ZjAwMGY4MH0=,[z]{13a9d942-da3a-4c44-9862-cdaf299b4b28}".Split(new char[]
			{
				','
			});
			string text = string.Empty;
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < array.Length - 1; i += 2)
			{
				if (array[i] == b)
				{
					text = array[i + 1];
					break;
				}
			}
			if (text.Length == 0 && #Dhc.#d.Length == 0)
			{
				b = Convert.ToBase64String(Encoding.UTF8.GetBytes(#Dhc.#a));
				for (int j = 0; j < array.Length - 1; j += 2)
				{
					if (array[j] == b)
					{
						text = array[j + 1];
						break;
					}
				}
			}
			if (text.Length > 0)
			{
				if (text[0] == '[')
				{
					int num = text.IndexOf(']');
					string text2 = text.Substring(1, num - 1);
					flag = (text2.IndexOf('z') >= 0);
					flag2 = (text2.IndexOf('t') >= 0);
					text = text.Substring(num + 1);
				}
				Dictionary<string, Assembly> obj = #xhc.#c;
				lock (obj)
				{
					if (#xhc.#c.ContainsKey(text))
					{
						return #xhc.#c[text];
					}
					Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(text);
					if (manifestResourceStream != null)
					{
						int num2 = (int)manifestResourceStream.Length;
						byte[] array2 = new byte[num2];
						manifestResourceStream.Read(array2, 0, num2);
						if (flag)
						{
							array2 = #dic.#cic(array2);
						}
						Assembly assembly = null;
						if (!flag2)
						{
							try
							{
								assembly = Assembly.Load(array2);
							}
							catch (FileLoadException)
							{
								flag2 = true;
							}
							catch (BadImageFormatException)
							{
								flag2 = true;
							}
						}
						if (flag2)
						{
							try
							{
								string text3 = string.Format("{0}{1}\\", Path.GetTempPath(), text);
								Directory.CreateDirectory(text3);
								string text4 = text3 + #Dhc.#a + ".dll";
								if (!File.Exists(text4))
								{
									FileStream fileStream = File.OpenWrite(text4);
									fileStream.Write(array2, 0, array2.Length);
									fileStream.Close();
									#xhc.#rhc(text4, null, 4);
									#xhc.#rhc(text3, null, 4);
								}
								assembly = Assembly.LoadFile(text4);
							}
							catch
							{
							}
						}
						#xhc.#c[text] = assembly;
						return assembly;
					}
				}
			}
			return null;
		}

		// Token: 0x04001B67 RID: 7015
		internal const string #a = "{71461f04-2faa-4bb9-a0dd-28a79101b599}";

		// Token: 0x04001B68 RID: 7016
		private const int #b = 4;

		// Token: 0x04001B69 RID: 7017
		private static Dictionary<string, Assembly> #c = new Dictionary<string, Assembly>();

		// Token: 0x02000733 RID: 1843
		internal struct #Dhc
		{
			// Token: 0x06003CA1 RID: 15521 RVA: 0x0011A698 File Offset: 0x00118898
			public string #Bhc(bool #Chc)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(this.#a);
				if (#Chc && this.#b != null)
				{
					stringBuilder.Append(", Version=");
					stringBuilder.Append(this.#b);
				}
				stringBuilder.Append(", Culture=");
				stringBuilder.Append((this.#c.Length == 0) ? "neutral" : this.#c);
				stringBuilder.Append(", PublicKeyToken=");
				stringBuilder.Append((this.#d.Length == 0) ? "null" : this.#d);
				return stringBuilder.ToString();
			}

			// Token: 0x06003CA2 RID: 15522 RVA: 0x0011A760 File Offset: 0x00118960
			public #Dhc(string #Ehc)
			{
				this.#b = null;
				this.#c = string.Empty;
				this.#d = string.Empty;
				this.#a = string.Empty;
				string[] array = #Ehc.Split(new char[]
				{
					','
				});
				for (int i = 0; i < array.Length; i++)
				{
					string text = array[i].Trim();
					if (text.StartsWith("Version="))
					{
						this.#b = new Version(text.Substring(8));
					}
					else if (text.StartsWith("Culture="))
					{
						this.#c = text.Substring(8);
						if (this.#c == "neutral")
						{
							this.#c = string.Empty;
						}
					}
					else if (text.StartsWith("PublicKeyToken="))
					{
						this.#d = text.Substring(15);
						if (this.#d == "null")
						{
							this.#d = string.Empty;
						}
					}
					else
					{
						this.#a = text;
					}
				}
			}

			// Token: 0x04001B6A RID: 7018
			public string #a;

			// Token: 0x04001B6B RID: 7019
			public Version #b;

			// Token: 0x04001B6C RID: 7020
			public string #c;

			// Token: 0x04001B6D RID: 7021
			public string #d;
		}
	}
}
