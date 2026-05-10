using System;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #xBe
{
	// Token: 0x02001215 RID: 4629
	internal static class #LBe
	{
		// Token: 0x06009B33 RID: 39731 RVA: 0x0007ABC7 File Offset: 0x00078DC7
		public static string #EBe(string #So)
		{
			if (string.IsNullOrWhiteSpace(#So) || !#So.EndsWith(#Phc.#3hc(107413479), StringComparison.OrdinalIgnoreCase))
			{
				return #Phc.#3hc(107408397);
			}
			return #Phc.#3hc(107464305);
		}

		// Token: 0x06009B34 RID: 39732 RVA: 0x0020F950 File Offset: 0x0020DB50
		public static string #FBe(string #C6c, bool #OAe)
		{
			string #f = #LBe.#HBe(#OAe ? 6 : 5, #C6c, new int[]
			{
				6,
				6,
				6,
				0,
				6,
				6
			});
			string text = #OAe ? #Phc.#3hc(107252016) : #Phc.#3hc(107251998);
			return #f.#D2d(new object[]
			{
				#Phc.#3hc(107283372),
				#Phc.#3hc(107283000),
				#Phc.#3hc(107283437),
				#Phc.#3hc(107283452),
				text,
				#Phc.#3hc(107283398)
			});
		}

		// Token: 0x06009B35 RID: 39733 RVA: 0x0020F9E8 File Offset: 0x0020DBE8
		public static string #GBe(string #C6c, bool #OAe)
		{
			return #LBe.#HBe(#OAe ? 8 : 7, #C6c, new int[]
			{
				6,
				6,
				6,
				6,
				6,
				6,
				6,
				6
			}).#D2d(new object[]
			{
				#Phc.#3hc(107283000),
				#Phc.#3hc(107282951),
				#Phc.#3hc(107282970),
				#Phc.#3hc(107283437),
				#Phc.#3hc(107283452),
				#Phc.#3hc(107283403),
				#Phc.#3hc(107252016),
				#Phc.#3hc(107283398)
			});
		}

		// Token: 0x06009B36 RID: 39734 RVA: 0x0020FA88 File Offset: 0x0020DC88
		public static string #HBe(int #IBe, string #C6c, params int[] #JBe)
		{
			#LBe.#W9b #W9b = new #LBe.#W9b();
			#W9b.#a = #JBe;
			return string.Join(#C6c, Enumerable.Range(0, #IBe).Select(new Func<int, string>(#W9b.#Jdf)));
		}

		// Token: 0x06009B37 RID: 39735 RVA: 0x0007ABF9 File Offset: 0x00078DF9
		private static string #KBe(int #tsc)
		{
			if (#tsc <= 0)
			{
				return #Phc.#3hc(107283363);
			}
			return #Phc.#3hc(107283363) + string.Empty.PadLeft(#tsc, '0');
		}

		// Token: 0x040042CB RID: 17099
		public const int #a = 6;

		// Token: 0x040042CC RID: 17100
		public const int #b = 6;

		// Token: 0x040042CD RID: 17101
		public const int #c = 5;

		// Token: 0x040042CE RID: 17102
		public const int #d = 8;

		// Token: 0x040042CF RID: 17103
		public const int #e = 7;

		// Token: 0x02001216 RID: 4630
		[CompilerGenerated]
		private sealed class #W9b
		{
			// Token: 0x06009B39 RID: 39737 RVA: 0x0007AC26 File Offset: 0x00078E26
			internal string #Jdf(int #4jb)
			{
				return #Phc.#3hc(107309123) + #4jb.ToString(CultureInfo.InvariantCulture) + #LBe.#KBe(this.#a[#4jb]) + #Phc.#3hc(107223771);
			}

			// Token: 0x040042D0 RID: 17104
			public int[] #a;
		}
	}
}
