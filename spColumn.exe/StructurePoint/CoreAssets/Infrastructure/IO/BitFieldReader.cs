using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace StructurePoint.CoreAssets.Infrastructure.IO
{
	// Token: 0x02000EC0 RID: 3776
	[CLSCompliant(false)]
	public static class BitFieldReader
	{
		// Token: 0x06008625 RID: 34341 RVA: 0x0006D3A7 File Offset: 0x0006B5A7
		public static #Fu #Cjc<#Fu>(uint #f) where #Fu : new()
		{
			return BitFieldReader.#NYd<#Fu>(BitConverter.GetBytes(#f));
		}

		// Token: 0x06008626 RID: 34342 RVA: 0x0006D3B4 File Offset: 0x0006B5B4
		public static #Fu #Cjc<#Fu>(int #f) where #Fu : new()
		{
			return BitFieldReader.#NYd<#Fu>(BitConverter.GetBytes(#f));
		}

		// Token: 0x06008627 RID: 34343 RVA: 0x0006D3C1 File Offset: 0x0006B5C1
		public static #Fu #Cjc<#Fu>(long #f) where #Fu : new()
		{
			return BitFieldReader.#NYd<#Fu>(BitConverter.GetBytes(#f));
		}

		// Token: 0x06008628 RID: 34344 RVA: 0x0006D3CE File Offset: 0x0006B5CE
		public static #Fu #Cjc<#Fu>(short #f) where #Fu : new()
		{
			return BitFieldReader.#NYd<#Fu>(BitConverter.GetBytes(#f));
		}

		// Token: 0x06008629 RID: 34345 RVA: 0x0006D3DB File Offset: 0x0006B5DB
		public static #Fu #Cjc<#Fu>(ulong #f) where #Fu : new()
		{
			return BitFieldReader.#NYd<#Fu>(BitConverter.GetBytes(#f));
		}

		// Token: 0x0600862A RID: 34346 RVA: 0x0006D3E8 File Offset: 0x0006B5E8
		public static #Fu #Cjc<#Fu>(ushort #f) where #Fu : new()
		{
			return BitFieldReader.#NYd<#Fu>(BitConverter.GetBytes(#f));
		}

		// Token: 0x0600862B RID: 34347 RVA: 0x0006D3F5 File Offset: 0x0006B5F5
		public static #Fu #Cjc<#Fu>(byte #f) where #Fu : new()
		{
			return BitFieldReader.#NYd<#Fu>(new byte[]
			{
				#f
			});
		}

		// Token: 0x0600862C RID: 34348 RVA: 0x001CC2CC File Offset: 0x001CA4CC
		private static #Fu #NYd<#Fu>(byte[] #OYd) where #Fu : new()
		{
			BitArray bitArray = new BitArray(#OYd);
			BitArray #RYd;
			if (4 != 0)
			{
				#RYd = bitArray;
			}
			#Fu #Fu = Activator.CreateInstance<#Fu>();
			#Fu #Fu2;
			if (!false)
			{
				#Fu2 = #Fu;
			}
			var enumerator = typeof(!!0).GetProperties(BindingFlags.Instance | BindingFlags.Public).Select(new Func<PropertyInfo, <>f__AnonymousType1<PropertyInfo, BitFieldAttribute>>(BitFieldReader.<>c__7<!!0>.<>9.#h4d)).Where(new Func<<>f__AnonymousType1<PropertyInfo, BitFieldAttribute>, bool>(BitFieldReader.<>c__7<!!0>.<>9.#i4d)).OrderBy(new Func<<>f__AnonymousType1<PropertyInfo, BitFieldAttribute>, int>(BitFieldReader.<>c__7<!!0>.<>9.#j4d)).Select(new Func<<>f__AnonymousType1<PropertyInfo, BitFieldAttribute>, <>f__AnonymousType2<PropertyInfo, BitFieldAttribute>>(BitFieldReader.<>c__7<!!0>.<>9.#k4d)).ToList().GetEnumerator();
			var enumerator2;
			if (!false)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					var <>f__AnonymousType = enumerator2.Current;
					var <>f__AnonymousType2;
					if (8 != 0)
					{
						<>f__AnonymousType2 = <>f__AnonymousType;
					}
					ulong num = BitFieldReader.#QYd(#RYd, <>f__AnonymousType2.Attribute.FieldOffset, <>f__AnonymousType2.Attribute.Size);
					ulong num2;
					if (!false)
					{
						num2 = num;
					}
					#Fu #Rf = #Fu2;
					PropertyInfo #F = <>f__AnonymousType2.Property;
					ulong #f = num2;
					if (!false)
					{
						BitFieldReader.#PYd<#Fu>(#Rf, #F, #f);
					}
				}
			}
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
			return #Fu2;
		}

		// Token: 0x0600862D RID: 34349 RVA: 0x001CC428 File Offset: 0x001CA628
		private static void #PYd<#Fu>(#Fu #Rf, PropertyInfo #F, ulong #f)
		{
			do
			{
				object obj2;
				if (-1 != 0)
				{
					Type propertyType = #F.PropertyType;
					Type conversionType;
					if (!false)
					{
						conversionType = propertyType;
					}
					object obj = Convert.ChangeType(#f, conversionType, CultureInfo.InvariantCulture);
					if (!false)
					{
						obj2 = obj;
					}
				}
				do
				{
					object obj3 = #Rf;
					object value = obj2;
					object[] index = null;
					if (!false)
					{
						#F.SetValue(obj3, value, index);
					}
				}
				while (false);
			}
			while (false);
		}

		// Token: 0x0600862E RID: 34350 RVA: 0x001CC47C File Offset: 0x001CA67C
		private static ulong #QYd(BitArray #RYd, int #Akb, int #1f)
		{
			ulong num = 0UL;
			ulong num2;
			if (!false)
			{
				num2 = num;
			}
			int num3 = #Akb;
			int num4 = #1f;
			for (;;)
			{
				int num5 = num3 + num4 - 1;
				if (!false)
				{
					#Akb = num5;
				}
				for (;;)
				{
					ulong num7;
					ulong num6 = num7 = num2;
					if (4 != 0)
					{
						ulong num8 = num6 << 1;
						if (!false)
						{
							num2 = num8;
						}
						if (!#RYd.Get(#Akb))
						{
							num7 = 0UL;
						}
						else
						{
							num7 = 1UL;
						}
					}
					IL_28:
					ulong num9;
					if (5 != 0)
					{
						num9 = num7;
					}
					ulong num10 = num7 = num2;
					if (-1 != 0)
					{
						ulong num11 = num10 | num9;
						if (!false)
						{
							num2 = num11;
						}
						int num12 = #Akb;
						int num13;
						do
						{
							num13 = --num12;
						}
						while (false);
						if (!false)
						{
							#Akb = num13;
						}
						#1f--;
						int num14 = num3 = #1f;
						int num15 = num4 = 0;
						if (num15 != 0)
						{
							break;
						}
						if (num14 <= num15)
						{
							return num2;
						}
						continue;
					}
					goto IL_28;
				}
			}
			return num2;
		}
	}
}
