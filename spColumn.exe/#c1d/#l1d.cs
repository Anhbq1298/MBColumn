using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using #7hc;

namespace #c1d
{
	// Token: 0x02000EDC RID: 3804
	internal static class #l1d
	{
		// Token: 0x1700282A RID: 10282
		// (get) Token: 0x060086F6 RID: 34550 RVA: 0x0006DC92 File Offset: 0x0006BE92
		public static string AllProjectExtensions
		{
			get
			{
				return #Phc.#3hc(107225783);
			}
		}

		// Token: 0x1700282B RID: 10283
		// (get) Token: 0x060086F7 RID: 34551 RVA: 0x0006DC9E File Offset: 0x0006BE9E
		public static string CurrentMatsExtension
		{
			get
			{
				return #Phc.#3hc(107225734);
			}
		}

		// Token: 0x1700282C RID: 10284
		// (get) Token: 0x060086F8 RID: 34552 RVA: 0x0006DCAA File Offset: 0x0006BEAA
		public static string CurrentMatsOutputFileExtension
		{
			get
			{
				return #Phc.#3hc(107225757);
			}
		}

		// Token: 0x1700282D RID: 10285
		// (get) Token: 0x060086F9 RID: 34553 RVA: 0x0006DCB6 File Offset: 0x0006BEB6
		public static string LegacyMats6Extension
		{
			get
			{
				return #Phc.#3hc(107225748);
			}
		}

		// Token: 0x1700282E RID: 10286
		// (get) Token: 0x060086FA RID: 34554 RVA: 0x0006DCC2 File Offset: 0x0006BEC2
		public static string LegacyMats7Extension
		{
			get
			{
				return #Phc.#3hc(107225711);
			}
		}

		// Token: 0x1700282F RID: 10287
		// (get) Token: 0x060086FB RID: 34555 RVA: 0x0006DCCE File Offset: 0x0006BECE
		public static string LegacyMats8Extension
		{
			get
			{
				return #Phc.#3hc(107225706);
			}
		}

		// Token: 0x17002830 RID: 10288
		// (get) Token: 0x060086FC RID: 34556 RVA: 0x0006DCDA File Offset: 0x0006BEDA
		public static string LegacyMatsExtension
		{
			get
			{
				return #Phc.#3hc(107225701);
			}
		}

		// Token: 0x060086FD RID: 34557 RVA: 0x0006DCE6 File Offset: 0x0006BEE6
		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Method is better here.")]
		public static IEnumerable<string> #j1d()
		{
			return #l1d.#g;
		}

		// Token: 0x060086FE RID: 34558 RVA: 0x0006DCED File Offset: 0x0006BEED
		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Method is better here.")]
		public static IEnumerable<string> #k1d()
		{
			return #l1d.#h;
		}

		// Token: 0x040037BB RID: 14267
		private const string #a = "matx";

		// Token: 0x040037BC RID: 14268
		private const string #b = "matox";

		// Token: 0x040037BD RID: 14269
		private const string #c = "ma6";

		// Token: 0x040037BE RID: 14270
		private const string #d = "ma7";

		// Token: 0x040037BF RID: 14271
		private const string #e = "ma8";

		// Token: 0x040037C0 RID: 14272
		private const string #f = "mat";

		// Token: 0x040037C1 RID: 14273
		private static readonly string[] #g = new string[]
		{
			#Phc.#3hc(107225701),
			#Phc.#3hc(107225748),
			#Phc.#3hc(107225711),
			#Phc.#3hc(107225706),
			#Phc.#3hc(107225734)
		};

		// Token: 0x040037C2 RID: 14274
		private static readonly string[] #h = new string[]
		{
			#Phc.#3hc(107225701),
			#Phc.#3hc(107225748),
			#Phc.#3hc(107225711),
			#Phc.#3hc(107225706)
		};
	}
}
