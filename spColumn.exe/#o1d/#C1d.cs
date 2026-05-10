using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #o1d
{
	// Token: 0x02000EE1 RID: 3809
	internal static class #C1d
	{
		// Token: 0x0600870D RID: 34573 RVA: 0x001CF4E4 File Offset: 0x001CD6E4
		public static #Fu #w1d<#Fu>(this Enum #f, #Fu #x1d)
		{
			string #R0d = #Phc.#3hc(107386484);
			Component #x6c = Component.Infrastructure;
			string #Qic = #Phc.#3hc(107225675);
			if (true)
			{
				#X0d.#V0d(#f, #R0d, #x6c, #Qic);
			}
			Type type2;
			object obj;
			#C1d.#u4d #u4d2;
			if (!false)
			{
				Type type = #f.GetType();
				if (!false)
				{
					type2 = type;
				}
				if (!false)
				{
					obj = #f;
				}
				#C1d.#u4d #u4d = new #C1d.#u4d(#x1d, type2);
				if (4 != 0)
				{
					#u4d2 = #u4d;
				}
			}
			long? num = #u4d2.Signed;
			long? num2;
			if (!false)
			{
				num2 = num;
			}
			long num3;
			ulong num5;
			if (num2 != null)
			{
				num3 = Convert.ToInt64(#f, CultureInfo.CurrentCulture);
			}
			else
			{
				if (#u4d2.Unsigned == null)
				{
					goto IL_BE;
				}
				ulong num4 = (ulong)(num3 = (long)(num5 = Convert.ToUInt64(#f, CultureInfo.CurrentCulture)));
				if (!false)
				{
					obj = (num4 | #u4d2.Unsigned.Value);
					goto IL_BE;
				}
				goto IL_7E;
			}
			IL_6C:
			long? num6 = #u4d2.Signed;
			if (!false)
			{
				num2 = num6;
			}
			num5 = (ulong)(num3 |= num2.Value);
			IL_7E:
			if (false)
			{
				goto IL_6C;
			}
			obj = (long)num5;
			IL_BE:
			return (!!0)((object)Enum.Parse(type2, obj.ToString(), false));
		}

		// Token: 0x0600870E RID: 34574 RVA: 0x001CF5EC File Offset: 0x001CD7EC
		public static #Fu #F7c<#Fu>(this Enum #f, #Fu #y1d)
		{
			string #R0d = #Phc.#3hc(107386484);
			Component #x6c = Component.Infrastructure;
			string #Qic = #Phc.#3hc(107225654);
			if (!false)
			{
				#X0d.#V0d(#f, #R0d, #x6c, #Qic);
			}
			Type type = #f.GetType();
			Type type2;
			if (!false)
			{
				type2 = type;
			}
			object obj;
			if (!false)
			{
				obj = #f;
			}
			#C1d.#u4d #u4d = new #C1d.#u4d(#y1d, type2);
			#C1d.#u4d #u4d2;
			if (8 != 0)
			{
				#u4d2 = #u4d;
			}
			long? num = #u4d2.Signed;
			long? num2;
			if (!false)
			{
				num2 = num;
			}
			if (num2 != null)
			{
				long num3 = Convert.ToInt64(#f, CultureInfo.CurrentCulture);
				long? num4 = #u4d2.Signed;
				if (3 != 0)
				{
					num2 = num4;
				}
				obj = (num3 & ~num2.Value);
			}
			else if (!false)
			{
				if (#u4d2.Unsigned != null)
				{
					ulong num6;
					ulong num5 = num6 = Convert.ToUInt64(#f, CultureInfo.CurrentCulture);
					if (!false)
					{
						num6 = (num5 & ~#u4d2.Unsigned.Value);
					}
					obj = num6;
				}
			}
			return (!!0)((object)Enum.Parse(type2, obj.ToString(), false));
		}

		// Token: 0x0600870F RID: 34575 RVA: 0x001CF6F4 File Offset: 0x001CD8F4
		public static bool #z1d<#Fu>(this Enum #f, #Fu #A1d)
		{
			string #R0d = #Phc.#3hc(107386484);
			Component #x6c = Component.Infrastructure;
			string #Qic = #Phc.#3hc(107226081);
			if (!false)
			{
				#X0d.#V0d(#f, #R0d, #x6c, #Qic);
			}
			#C1d.#u4d #u4d2;
			long? num2;
			ulong num4;
			if (2 != 0)
			{
				Type type = #f.GetType();
				Type #C;
				if (!false)
				{
					#C = type;
				}
				#C1d.#u4d #u4d = new #C1d.#u4d(#A1d, #C);
				if (6 != 0)
				{
					#u4d2 = #u4d;
				}
				long? num = #u4d2.Signed;
				if (!false)
				{
					num2 = num;
				}
				if (num2 == null)
				{
					if (#u4d2.Unsigned == null)
					{
						return false;
					}
					ulong num3 = num4 = Convert.ToUInt64(#f, CultureInfo.CurrentCulture);
					if (false)
					{
						goto IL_6E;
					}
					ulong num5 = num4 = (num3 & #u4d2.Unsigned.Value);
					if (!false)
					{
						return num5 == #u4d2.Unsigned.Value;
					}
					goto IL_6E;
				}
			}
			num4 = (ulong)Convert.ToInt64(#f, CultureInfo.CurrentCulture);
			long? num6 = #u4d2.Signed;
			if (3 != 0)
			{
				num2 = num6;
			}
			IL_6E:
			long num7 = (long)(num4 & (ulong)num2.Value);
			long? num8 = #u4d2.Signed;
			if (6 != 0)
			{
				num2 = num8;
			}
			bool result2;
			bool result = result2 = (num7 == num2.Value);
			if (!false)
			{
				return result;
			}
			return result2;
		}

		// Token: 0x06008710 RID: 34576 RVA: 0x0006DDCE File Offset: 0x0006BFCE
		public static bool #B1d<#Fu>(this Enum #Vg, #Fu #f)
		{
			return !#Vg.#z1d(#f);
		}

		// Token: 0x02000EE2 RID: 3810
		private sealed class #u4d
		{
			// Token: 0x06008711 RID: 34577 RVA: 0x001CF7F8 File Offset: 0x001CD9F8
			public #u4d(object #f, Type #C)
			{
				if (!#C.IsEnum)
				{
					throw new ArgumentException(#Phc.#3hc(107224041));
				}
				Type underlyingType = Enum.GetUnderlyingType(#C);
				if (underlyingType == #C1d.#u4d.#b || underlyingType == #C1d.#u4d.#a)
				{
					this.Unsigned = new ulong?(Convert.ToUInt64(#f, CultureInfo.CurrentCulture));
					return;
				}
				this.Signed = new long?(Convert.ToInt64(#f, CultureInfo.CurrentCulture));
			}

			// Token: 0x17002831 RID: 10289
			// (get) Token: 0x06008712 RID: 34578 RVA: 0x0006DDDA File Offset: 0x0006BFDA
			// (set) Token: 0x06008713 RID: 34579 RVA: 0x0006DDE2 File Offset: 0x0006BFE2
			public long? Signed { get; set; }

			// Token: 0x17002832 RID: 10290
			// (get) Token: 0x06008714 RID: 34580 RVA: 0x0006DDEB File Offset: 0x0006BFEB
			// (set) Token: 0x06008715 RID: 34581 RVA: 0x0006DDF3 File Offset: 0x0006BFF3
			public ulong? Unsigned { get; set; }

			// Token: 0x040037C8 RID: 14280
			private static readonly Type #a = typeof(ulong);

			// Token: 0x040037C9 RID: 14281
			private static readonly Type #b = typeof(long);

			// Token: 0x040037CA RID: 14282
			[CompilerGenerated]
			private long? #c;

			// Token: 0x040037CB RID: 14283
			[CompilerGenerated]
			private ulong? #d;
		}
	}
}
