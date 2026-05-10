using System;
using #7hc;

namespace #c1d
{
	// Token: 0x02000EDB RID: 3803
	internal static class #b1d
	{
		// Token: 0x17002821 RID: 10273
		// (get) Token: 0x060086E9 RID: 34537 RVA: 0x0006DB57 File Offset: 0x0006BD57
		public static string CurrentExtension
		{
			get
			{
				return #Phc.#3hc(107225812);
			}
		}

		// Token: 0x17002822 RID: 10274
		// (get) Token: 0x060086EA RID: 34538 RVA: 0x0006DB63 File Offset: 0x0006BD63
		public static string LegacyExtension
		{
			get
			{
				return #Phc.#3hc(107225771);
			}
		}

		// Token: 0x17002823 RID: 10275
		// (get) Token: 0x060086EB RID: 34539 RVA: 0x0006DB6F File Offset: 0x0006BD6F
		public static string LegacyTextExtension
		{
			get
			{
				return #Phc.#3hc(107350271);
			}
		}

		// Token: 0x17002824 RID: 10276
		// (get) Token: 0x060086EC RID: 34540 RVA: 0x0006DB7B File Offset: 0x0006BD7B
		public static string DxfExtension
		{
			get
			{
				return #Phc.#3hc(107350266);
			}
		}

		// Token: 0x17002825 RID: 10277
		// (get) Token: 0x060086ED RID: 34541 RVA: 0x0006DB87 File Offset: 0x0006BD87
		public static string ReinforcementBarSetExtension
		{
			get
			{
				return #Phc.#3hc(107225766);
			}
		}

		// Token: 0x17002826 RID: 10278
		// (get) Token: 0x060086EE RID: 34542 RVA: 0x0006DB93 File Offset: 0x0006BD93
		public static string TextExtension
		{
			get
			{
				return #Phc.#3hc(107413479);
			}
		}

		// Token: 0x17002827 RID: 10279
		// (get) Token: 0x060086EF RID: 34543 RVA: 0x0006DB9F File Offset: 0x0006BD9F
		public static string XmlExtension
		{
			get
			{
				return #Phc.#3hc(107225761);
			}
		}

		// Token: 0x17002828 RID: 10280
		// (get) Token: 0x060086F0 RID: 34544 RVA: 0x0006DBAB File Offset: 0x0006BDAB
		public static string EdbExtension
		{
			get
			{
				return #Phc.#3hc(107225788);
			}
		}

		// Token: 0x17002829 RID: 10281
		// (get) Token: 0x060086F1 RID: 34545 RVA: 0x0006DBB7 File Offset: 0x0006BDB7
		public static string AllProjectExtensions
		{
			get
			{
				return string.Concat(new string[]
				{
					#b1d.CurrentExtension,
					#Phc.#3hc(107408443),
					#b1d.LegacyExtension,
					#Phc.#3hc(107408443),
					#b1d.LegacyTextExtension
				});
			}
		}

		// Token: 0x060086F2 RID: 34546 RVA: 0x0006DBF6 File Offset: 0x0006BDF6
		public static bool #70d(string #So)
		{
			int result;
			if (4 != 0)
			{
				if (#So == null && 3 != 0)
				{
					int num = result = 107226730;
					if (num != 0)
					{
						throw new ArgumentNullException(#Phc.#3hc(num));
					}
					return result != 0;
				}
				else
				{
					string text = #So.Trim();
					if (!false)
					{
						#So = text;
					}
				}
			}
			result = (#So.EndsWith(#b1d.LegacyExtension, StringComparison.OrdinalIgnoreCase) ? 1 : 0);
			return result != 0;
		}

		// Token: 0x060086F3 RID: 34547 RVA: 0x0006DBF6 File Offset: 0x0006BDF6
		public static bool #80d(string #So)
		{
			int result;
			if (4 != 0)
			{
				if (#So == null && 3 != 0)
				{
					int num = result = 107226730;
					if (num != 0)
					{
						throw new ArgumentNullException(#Phc.#3hc(num));
					}
					return result != 0;
				}
				else
				{
					string text = #So.Trim();
					if (!false)
					{
						#So = text;
					}
				}
			}
			result = (#So.EndsWith(#b1d.LegacyExtension, StringComparison.OrdinalIgnoreCase) ? 1 : 0);
			return result != 0;
		}

		// Token: 0x060086F4 RID: 34548 RVA: 0x0006DC2E File Offset: 0x0006BE2E
		public static bool #90d(string #So)
		{
			int result;
			if (4 != 0)
			{
				if (#So == null && 3 != 0)
				{
					int num = result = 107226730;
					if (num != 0)
					{
						throw new ArgumentNullException(#Phc.#3hc(num));
					}
					return result != 0;
				}
				else
				{
					string text = #So.Trim();
					if (!false)
					{
						#So = text;
					}
				}
			}
			result = (#So.EndsWith(#b1d.LegacyTextExtension, StringComparison.OrdinalIgnoreCase) ? 1 : 0);
			return result != 0;
		}

		// Token: 0x060086F5 RID: 34549 RVA: 0x0006DC66 File Offset: 0x0006BE66
		public static bool #a1d(string #So)
		{
			int num;
			if (false || #So == null)
			{
				num = 107226730;
			}
			else
			{
				bool result = (num = (#So.Trim().EndsWith(#b1d.CurrentExtension, StringComparison.OrdinalIgnoreCase) ? 1 : 0)) != 0;
				if (!false)
				{
					return result;
				}
			}
			throw new ArgumentNullException(#Phc.#3hc(num));
		}
	}
}
