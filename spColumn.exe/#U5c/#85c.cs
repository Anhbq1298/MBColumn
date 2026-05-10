using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using #7hc;
using Alphaleonis.Win32.Filesystem;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #U5c
{
	// Token: 0x02000CDF RID: 3295
	internal abstract class #85c : #V5c
	{
		// Token: 0x06006BD3 RID: 27603 RVA: 0x00054A84 File Offset: 0x00052C84
		protected #85c(string #95c, int #a6c, string #b6c)
		{
			this.#d = #b6c;
			this.#e = #Phc.#3hc(107265965).#D2d(new object[]
			{
				#95c
			});
			this.CurrentVersion = #a6c;
		}

		// Token: 0x17001D93 RID: 7571
		// (get) Token: 0x06006BD4 RID: 27604 RVA: 0x00054AC4 File Offset: 0x00052CC4
		// (set) Token: 0x06006BD5 RID: 27605 RVA: 0x00054ACC File Offset: 0x00052CCC
		private protected int CurrentVersion { protected get; private set; }

		// Token: 0x17001D94 RID: 7572
		// (get) Token: 0x06006BD6 RID: 27606 RVA: 0x00054AD5 File Offset: 0x00052CD5
		protected string RegistryPath
		{
			get
			{
				return Path.Combine(new string[]
				{
					#Phc.#3hc(107265972),
					this.#d
				});
			}
		}

		// Token: 0x17001D95 RID: 7573
		// (get) Token: 0x06006BD7 RID: 27607 RVA: 0x00054AF8 File Offset: 0x00052CF8
		// (set) Token: 0x06006BD8 RID: 27608 RVA: 0x00054B00 File Offset: 0x00052D00
		private protected bool Handled { protected get; private set; }

		// Token: 0x06006BD9 RID: 27609 RVA: 0x001A0D00 File Offset: 0x0019EF00
		public void #uRb()
		{
			object obj2;
			if (3 != 0)
			{
				if (this.Handled)
				{
					return;
				}
				object obj = this.#c;
				if (2 != 0)
				{
					obj2 = obj;
				}
			}
			bool flag = false;
			bool flag2;
			if (!false)
			{
				flag2 = flag;
			}
			try
			{
				object obj3 = obj2;
				if (!false)
				{
					Monitor.Enter(obj3, ref flag2);
				}
				if (!this.Handled)
				{
					int num = this.#65c();
					int num2;
					if (3 != 0)
					{
						num2 = num;
					}
					int num4;
					int num3 = num4 = num2;
					int num6;
					int num5 = num6 = 0;
					if (num5 != 0)
					{
						goto IL_4F;
					}
					if (num3 > num5)
					{
						goto IL_48;
					}
					IL_41:
					int #25c = num2;
					if (7 != 0)
					{
						this.#35c(#25c);
					}
					IL_48:
					num4 = num2;
					num6 = this.CurrentVersion;
					IL_4F:
					if (num4 < num6)
					{
						int #25c2 = num2;
						if (!false)
						{
							this.#15c(#25c2);
						}
						if (-1 == 0)
						{
							goto IL_41;
						}
						this.#75c();
					}
					this.Handled = true;
				}
			}
			finally
			{
				if (4 == 0 || flag2)
				{
					Monitor.Exit(obj2);
				}
			}
		}

		// Token: 0x06006BDA RID: 27610 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #15c(int #25c)
		{
		}

		// Token: 0x06006BDB RID: 27611 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #35c(int #25c)
		{
		}

		// Token: 0x06006BDC RID: 27612 RVA: 0x001A0DB8 File Offset: 0x0019EFB8
		protected void #45c(string #55c)
		{
			for (;;)
			{
				if (true)
				{
					RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(#55c, RegistryKeyPermissionCheck.ReadWriteSubTree);
					RegistryKey registryKey2;
					if (!false)
					{
						registryKey2 = registryKey;
					}
					if (registryKey2 == null)
					{
						break;
					}
					RegistryKey registryKey3 = registryKey2;
					RegistryKey registryKey4;
					if (5 != 0)
					{
						registryKey4 = registryKey3;
					}
					try
					{
						string[] array;
						int num2;
						if (4 != 0)
						{
							string[] valueNames = registryKey2.GetValueNames();
							if (!false)
							{
								array = valueNames;
							}
							int num = 0;
							if (!false)
							{
								num2 = num;
							}
							goto IL_51;
						}
						goto IL_40;
						IL_39:
						string text = array[num2];
						string text2;
						if (4 != 0)
						{
							text2 = text;
						}
						IL_40:
						RegistryKey registryKey5 = registryKey2;
						string name = text2;
						bool throwOnMissingValue = false;
						if (!false)
						{
							registryKey5.DeleteValue(name, throwOnMissingValue);
						}
						if (-1 == 0)
						{
							goto IL_39;
						}
						num2++;
						IL_51:
						if (num2 < array.Length)
						{
							goto IL_39;
						}
					}
					finally
					{
						if (registryKey4 != null)
						{
							((IDisposable)registryKey4).Dispose();
						}
					}
				}
				if (7 != 0)
				{
					return;
				}
			}
		}

		// Token: 0x06006BDD RID: 27613 RVA: 0x001A0E5C File Offset: 0x0019F05C
		private int #65c()
		{
			object obj;
			if (7 != 0 && !false)
			{
				object value = Registry.GetValue(this.RegistryPath, this.#e, 0);
				if (!false)
				{
					obj = value;
				}
				if (obj == null)
				{
					return 0;
				}
			}
			int num = Information.IsNumeric(obj) ? 1 : 0;
			double num2;
			while (num != 0 && double.TryParse(Convert.ToString(obj, CultureInfo.InvariantCulture), NumberStyles.Any, NumberFormatInfo.InvariantInfo, out num2))
			{
				int result = num = (int)num2;
				if (-1 != 0)
				{
					return result;
				}
			}
			return 0;
		}

		// Token: 0x06006BDE RID: 27614 RVA: 0x00054B09 File Offset: 0x00052D09
		private void #75c()
		{
			string keyName = this.RegistryPath;
			string valueName = this.#e;
			object value = this.CurrentVersion;
			if (4 != 0)
			{
				Registry.SetValue(keyName, valueName, value);
			}
		}

		// Token: 0x04002BE8 RID: 11240
		private const int #a = 0;

		// Token: 0x04002BE9 RID: 11241
		private const string #b = "HKEY_CURRENT_USER";

		// Token: 0x04002BEA RID: 11242
		private readonly object #c = new object();

		// Token: 0x04002BEB RID: 11243
		private readonly string #d;

		// Token: 0x04002BEC RID: 11244
		private readonly string #e;

		// Token: 0x04002BED RID: 11245
		[CompilerGenerated]
		private int #f;

		// Token: 0x04002BEE RID: 11246
		[CompilerGenerated]
		private bool #g;
	}
}
