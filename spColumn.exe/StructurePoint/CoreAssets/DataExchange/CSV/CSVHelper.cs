using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using #7hc;
using #cYd;
using #o1d;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.DataExchange.CSV
{
	// Token: 0x02000785 RID: 1925
	public static class CSVHelper
	{
		// Token: 0x170012E0 RID: 4832
		// (get) Token: 0x06003DF0 RID: 15856 RVA: 0x00034F15 File Offset: 0x00033115
		// (set) Token: 0x06003DF1 RID: 15857 RVA: 0x00034F42 File Offset: 0x00033142
		public static string DefaultColumnSeparator
		{
			get
			{
				if (string.IsNullOrEmpty(CSVHelper.#b))
				{
					string listSeparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;
					if (4 != 0)
					{
						CSVHelper.#4kc(listSeparator);
					}
				}
				return CSVHelper.#b;
			}
			set
			{
				if (6 != 0)
				{
					CSVHelper.#4kc(value);
				}
			}
		}

		// Token: 0x170012E1 RID: 4833
		// (get) Token: 0x06003DF2 RID: 15858 RVA: 0x00034F50 File Offset: 0x00033150
		// (set) Token: 0x06003DF3 RID: 15859 RVA: 0x00034F73 File Offset: 0x00033173
		public static string RowSeparator
		{
			get
			{
				if (string.IsNullOrWhiteSpace(CSVHelper.#d))
				{
					string newLine = Environment.NewLine;
					if (7 != 0)
					{
						CSVHelper.#3kc(newLine);
					}
				}
				return CSVHelper.#d;
			}
			set
			{
				if (6 != 0)
				{
					CSVHelper.#3kc(value);
				}
			}
		}

		// Token: 0x170012E2 RID: 4834
		// (get) Token: 0x06003DF4 RID: 15860 RVA: 0x00034F81 File Offset: 0x00033181
		// (set) Token: 0x06003DF5 RID: 15861 RVA: 0x00034F9F File Offset: 0x0003319F
		public static CultureInfo CultureInfo
		{
			get
			{
				if (CSVHelper.#c == null)
				{
					CultureInfo currentCulture = CultureInfo.CurrentCulture;
					if (!false)
					{
						CSVHelper.#6kc(currentCulture);
					}
				}
				return CSVHelper.#c;
			}
			set
			{
				if (6 != 0)
				{
					CSVHelper.#6kc(value);
				}
			}
		}

		// Token: 0x06003DF6 RID: 15862 RVA: 0x0011C80C File Offset: 0x0011AA0C
		public static IList<CSVRow> #Tkc(string #Ukc, params string[] #Vkc)
		{
			IList<CSVRow> result;
			for (;;)
			{
				string #R0d = #Phc.#3hc(107377186);
				Component #x6c = Component.GUI;
				string #Qic = #Phc.#3hc(107377205);
				if (!false)
				{
					#X0d.#V0d(#Ukc, #R0d, #x6c, #Qic);
				}
				for (;;)
				{
					MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(#Ukc));
					MemoryStream memoryStream2;
					if (!false)
					{
						memoryStream2 = memoryStream;
						goto IL_31;
					}
					try
					{
						do
						{
							IL_31:
							IList<CSVRow> list = CSVHelper.#Tkc(memoryStream2, #Vkc);
							if (!false)
							{
								result = list;
							}
						}
						while (5 == 0);
					}
					finally
					{
						if (memoryStream2 != null)
						{
							((IDisposable)memoryStream2).Dispose();
						}
					}
					if (!true)
					{
						break;
					}
					if (!false)
					{
						return result;
					}
				}
			}
			return result;
		}

		// Token: 0x06003DF7 RID: 15863 RVA: 0x0011C888 File Offset: 0x0011AA88
		public static IList<CSVRow> #Tkc(Stream #gp, params string[] #Vkc)
		{
			string #R0d = #Phc.#3hc(107377314);
			Component #x6c = Component.DataExchange;
			string #Qic = #Phc.#3hc(107377632);
			if (!false)
			{
				#X0d.#V0d(#gp, #R0d, #x6c, #Qic);
			}
			if (#Vkc == null || !#Vkc.Any<string>())
			{
				string[] array = new string[]
				{
					CSVHelper.DefaultColumnSeparator
				};
				if (-1 != 0)
				{
					#Vkc = array;
				}
			}
			List<IList<CSVRow>> list = new List<IList<CSVRow>>();
			List<IList<CSVRow>> list2;
			if (!false)
			{
				list2 = list;
			}
			StreamReader streamReader = new StreamReader(#gp);
			StreamReader streamReader2;
			if (4 != 0)
			{
				streamReader2 = streamReader;
				goto IL_5A;
			}
			try
			{
				for (;;)
				{
					IL_5A:
					string[] array2 = #Vkc;
					string[] array3;
					if (!false)
					{
						array3 = array2;
					}
					int num = 0;
					int num2;
					if (5 != 0)
					{
						num2 = num;
					}
					while (!false)
					{
						if (num2 >= array3.Length)
						{
							goto Block_7;
						}
						string #Xkc = array3[num2];
						try
						{
							list2.Add(CSVHelper.#alc(streamReader2, #Xkc));
						}
						catch (#hYd)
						{
						}
						num2++;
					}
				}
				Block_7:;
			}
			finally
			{
				do
				{
					if (streamReader2 != null)
					{
						((IDisposable)streamReader2).Dispose();
					}
				}
				while (4 == 0);
			}
			if (!list2.Any<IList<CSVRow>>())
			{
				throw new #hYd(#Phc.#3hc(107377314), Strings.StringTheCSVDataHaveInvalidStructure.#z2d(), #Phc.#3hc(107377579), Component.GUI, #IYd.#b, #JYd.#b);
			}
			using (List<IList<CSVRow>>.Enumerator enumerator = list2.GetEnumerator())
			{
				IList<CSVRow> list3;
				if (!false)
				{
					while (enumerator.MoveNext())
					{
						if (!false)
						{
							list3 = enumerator.Current;
						}
						if (list3.Any<CSVRow>() && list3[0].Cells.Count > 1)
						{
							goto IL_10B;
						}
					}
					goto IL_12A;
				}
				IL_10B:
				return list3;
			}
			IL_12A:
			return list2.First<IList<CSVRow>>();
		}

		// Token: 0x06003DF8 RID: 15864 RVA: 0x00034FAD File Offset: 0x000331AD
		public static string #Wkc(IList<CSVRow> #Zgb)
		{
			return CSVHelper.#Wkc(#Zgb, CSVHelper.DefaultColumnSeparator);
		}

		// Token: 0x06003DF9 RID: 15865 RVA: 0x0011CA10 File Offset: 0x0011AC10
		public static string #Wkc(IList<CSVRow> #Zgb, string #Xkc)
		{
			do
			{
				if (4 != 0)
				{
					string #R0d = #Phc.#3hc(107377558);
					Component #x6c = Component.GUI;
					string #Qic = #Phc.#3hc(107377517);
					if (!false)
					{
						#X0d.#V0d(#Zgb, #R0d, #x6c, #Qic);
					}
				}
			}
			while (-1 == 0);
			MemoryStream memoryStream = new MemoryStream();
			MemoryStream memoryStream2;
			if (!false)
			{
				memoryStream2 = memoryStream;
				goto IL_2C;
			}
			string result;
			try
			{
				do
				{
					IL_2C:
					Stream #gp = memoryStream2;
					bool #Zkc = true;
					if (7 != 0)
					{
						CSVHelper.#Ykc(#Zgb, #gp, #Xkc, #Zkc);
					}
				}
				while (false);
				memoryStream2.#i2d();
				string text = new StreamReader(memoryStream2, Encoding.UTF8, true, 8192).ReadToEnd();
				if (4 != 0)
				{
					result = text;
				}
			}
			finally
			{
				while (memoryStream2 != null)
				{
					if (true)
					{
						((IDisposable)memoryStream2).Dispose();
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x06003DFA RID: 15866 RVA: 0x0011CAAC File Offset: 0x0011ACAC
		public static void #Ykc(IList<CSVRow> #Zgb, Stream #gp, string #Xkc, bool #Zkc)
		{
			string #R0d = #Phc.#3hc(107377558);
			Component #x6c = Component.GUI;
			string #Qic = #Phc.#3hc(107377496);
			if (!false)
			{
				#X0d.#V0d(#Zgb, #R0d, #x6c, #Qic);
			}
			if (!false)
			{
				string #R0d2 = #Phc.#3hc(107377314);
				Component #x6c2 = Component.GUI;
				string #Qic2 = #Phc.#3hc(107377411);
				if (true)
				{
					#X0d.#V0d(#gp, #R0d2, #x6c2, #Qic2);
				}
				if (string.IsNullOrEmpty(#Xkc))
				{
					string text = CSVHelper.DefaultColumnSeparator;
					if (!false)
					{
						#Xkc = text;
					}
				}
				#gp.#i2d();
			}
			StreamWriter streamWriter = null;
			StreamWriter streamWriter2;
			if (3 != 0)
			{
				streamWriter2 = streamWriter;
			}
			try
			{
				if (false)
				{
					goto IL_D2;
				}
				StreamWriter streamWriter3 = new StreamWriter(#gp, Encoding.UTF8, 8192);
				if (!false)
				{
					streamWriter2 = streamWriter3;
				}
				CSVRow[] array;
				if ((array = (#Zgb as CSVRow[])) == null)
				{
					array = #Zgb.ToArray<CSVRow>();
				}
				CSVRow[] array2;
				if (true)
				{
					array2 = array;
				}
				CSVRow[] array3 = array2;
				IL_96:
				int num = 0;
				goto IL_F6;
				IL_D2:
				CSVRow csvrow;
				if (csvrow != array2.First<CSVRow>())
				{
					streamWriter2.Write(CSVHelper.RowSeparator);
				}
				string value;
				streamWriter2.Write(value);
				int num3;
				int num2 = num3 = num;
				int num5;
				int num4 = num5 = 1;
				if (num4 == 0)
				{
					goto IL_FD;
				}
				num = num2 + num4;
				IL_F6:
				if (!true)
				{
					goto IL_96;
				}
				num3 = num;
				num5 = array3.Length;
				IL_FD:
				if (num3 < num5)
				{
					csvrow = array3[num];
					value = string.Join(#Xkc, csvrow.Cells.Select(new Func<CSVCell, string>(CSVHelper.<>c.<>9.#flc)));
					goto IL_D2;
				}
				streamWriter2.Flush();
			}
			finally
			{
				if (!#Zkc && streamWriter2 != null)
				{
					streamWriter2.Dispose();
				}
			}
		}

		// Token: 0x06003DFB RID: 15867 RVA: 0x0011CC0C File Offset: 0x0011AE0C
		public static IList<CSVRow> #0kc(IList<CSVRow> #1kc, IList<string> #2kc)
		{
			string #R0d = #Phc.#3hc(107376846);
			Component #x6c = Component.GUI;
			string #Qic = #Phc.#3hc(107376833);
			if (!false)
			{
				#X0d.#V0d(#1kc, #R0d, #x6c, #Qic);
			}
			string #R0d2 = #Phc.#3hc(107376780);
			Component #x6c2 = Component.GUI;
			string #Qic2 = #Phc.#3hc(107376799);
			if (!false)
			{
				#X0d.#V0d(#2kc, #R0d2, #x6c2, #Qic2);
			}
			IList<int> list2;
			List<CSVRow> list4;
			if (!#2kc.Any<string>() || !#1kc.Any<CSVRow>())
			{
				if (!false)
				{
					return #1kc;
				}
				goto IL_CB;
			}
			else
			{
				IList<int> list = CSVHelper.#8kc(#1kc.First<CSVRow>(), #2kc);
				if (!false)
				{
					list2 = list;
				}
				if (list2.Count != #2kc.Count)
				{
					throw new #hYd(#Phc.#3hc(107376846), #Phc.#3hc(107376714), Strings.StringTheCSVDataAreMissingRequiredColumns.#z2d(), Component.GUI, #IYd.#b);
				}
				if (list2.Count == 0)
				{
					return #1kc;
				}
				List<CSVRow> list3 = new List<CSVRow>();
				if (!false)
				{
					list4 = list3;
				}
			}
			IL_B3:
			int num = 1;
			int num2;
			if (!false)
			{
				num2 = num;
			}
			goto IL_12A;
			IL_CB:
			if (4 == 0)
			{
				goto IL_B3;
			}
			CSVRow csvrow = new CSVRow();
			IEnumerator<int> enumerator = list2.GetEnumerator();
			CSVRow csvrow2;
			try
			{
				while (enumerator.MoveNext())
				{
					int index = enumerator.Current;
					csvrow.Cells.Add(csvrow2.Cells[index]);
				}
			}
			finally
			{
				do
				{
					if (enumerator != null)
					{
						if (false)
						{
							continue;
						}
						enumerator.Dispose();
					}
				}
				while (false);
			}
			list4.Add(csvrow);
			num2++;
			IL_12A:
			if (num2 >= #1kc.Count)
			{
				return list4;
			}
			CSVRow csvrow3 = #1kc[num2];
			if (3 == 0)
			{
				goto IL_CB;
			}
			csvrow2 = csvrow3;
			goto IL_CB;
		}

		// Token: 0x06003DFC RID: 15868 RVA: 0x00034FBA File Offset: 0x000331BA
		private static void #3kc(string #f)
		{
			CSVHelper.#d = #f;
		}

		// Token: 0x06003DFD RID: 15869 RVA: 0x00034FC2 File Offset: 0x000331C2
		private static void #4kc(string #5kc)
		{
			CSVHelper.#b = #5kc;
		}

		// Token: 0x06003DFE RID: 15870 RVA: 0x00034FCA File Offset: 0x000331CA
		private static void #6kc(CultureInfo #7kc)
		{
			CSVHelper.#c = #7kc;
		}

		// Token: 0x06003DFF RID: 15871 RVA: 0x0011CD8C File Offset: 0x0011AF8C
		private static IList<int> #8kc(CSVRow #9kc, IEnumerable<string> #2kc)
		{
			List<int> list = new List<int>();
			List<int> list2;
			if (!false)
			{
				list2 = list;
			}
			IEnumerator<string> enumerator = #2kc.GetEnumerator();
			IEnumerator<string> enumerator2;
			if (5 != 0)
			{
				enumerator2 = enumerator;
				goto IL_19;
			}
			try
			{
				for (;;)
				{
					IL_19:
					if (-1 == 0)
					{
						goto IL_33;
					}
					IL_69:
					if (false)
					{
						continue;
					}
					int num;
					bool flag = (num = (enumerator2.MoveNext() ? 1 : 0)) != 0;
					if (!true)
					{
						goto IL_5D;
					}
					if (!flag)
					{
						break;
					}
					CSVHelper.#XWb #XWb = new CSVHelper.#XWb();
					CSVHelper.#XWb #XWb2;
					if (2 != 0)
					{
						#XWb2 = #XWb;
					}
					#XWb2.#a = enumerator2.Current;
					IL_33:
					CSVCell csvcell = #9kc.Cells.FirstOrDefault(new Func<CSVCell, bool>(#XWb2.#hlc));
					CSVCell csvcell2;
					if (5 != 0)
					{
						csvcell2 = csvcell;
					}
					if (csvcell2 == null)
					{
						goto IL_69;
					}
					num = #9kc.Cells.IndexOf(csvcell2);
					IL_5D:
					int num2;
					if (8 != 0)
					{
						num2 = num;
					}
					List<int> list3 = list2;
					int item = num2;
					if (false)
					{
						goto IL_69;
					}
					list3.Add(item);
					goto IL_69;
				}
			}
			finally
			{
				if (-1 != 0 && enumerator2 != null)
				{
					enumerator2.Dispose();
				}
			}
			return list2;
		}

		// Token: 0x06003E00 RID: 15872 RVA: 0x0011CE50 File Offset: 0x0011B050
		private static IList<CSVRow> #alc(StreamReader #blc, string #Xkc)
		{
			int? num = null;
			List<CSVRow> list = new List<CSVRow>();
			List<CSVRow> list2;
			if (!false)
			{
				list2 = list;
			}
			#blc.BaseStream.Seek(0L, SeekOrigin.Begin);
			if (5 != 0)
			{
				#blc.DiscardBufferedData();
			}
			while (#blc.Peek() >= 0)
			{
				string text = #blc.ReadLine();
				string text2;
				if (!false)
				{
					text2 = text;
				}
				if (!string.IsNullOrEmpty(text2))
				{
					List<string> list3 = text2.Split(new string[]
					{
						#Xkc
					}, StringSplitOptions.None).ToList<string>();
					List<string> list4;
					if (3 != 0)
					{
						list4 = list3;
					}
					bool flag2;
					bool flag = flag2 = (num != null);
					if (!false)
					{
						if (flag)
						{
							int? num2 = num;
							int? num3;
							if (!false)
							{
								num3 = num2;
							}
							int count = list4.Count;
							int num4;
							if (-1 != 0)
							{
								num4 = count;
							}
							if (!(num3.GetValueOrDefault() == num4 & num3 != null))
							{
								throw new #hYd(#Phc.#3hc(107377314), Strings.StringTheCSVDataHaveInvalidStructure.#z2d(), #Phc.#3hc(107376693), Component.GUI, #IYd.#b, #JYd.#b);
							}
						}
						flag2 = (num != null);
					}
					if (!flag2)
					{
						num = new int?(list4.Count);
					}
					if (list2.Count == 0)
					{
						list4 = list4.Select(new Func<string, string>(CSVHelper.<>c.<>9.#glc)).ToList<string>();
					}
					CSVRow csvrow = new CSVRow();
					csvrow.#elc(list4);
					list2.Add(csvrow);
				}
			}
			return list2;
		}

		// Token: 0x04001C25 RID: 7205
		private const int #a = 8192;

		// Token: 0x04001C26 RID: 7206
		private static string #b;

		// Token: 0x04001C27 RID: 7207
		private static CultureInfo #c;

		// Token: 0x04001C28 RID: 7208
		private static string #d;

		// Token: 0x02000787 RID: 1927
		[CompilerGenerated]
		private sealed class #XWb
		{
			// Token: 0x06003E06 RID: 15878 RVA: 0x00034FEE File Offset: 0x000331EE
			internal bool #hlc(CSVCell #Rf)
			{
				return string.Equals(#Rf.Value, this.#a, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x04001C2C RID: 7212
			public string #a;
		}
	}
}
