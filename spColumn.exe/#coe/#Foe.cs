using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using #7hc;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #coe
{
	// Token: 0x020010DF RID: 4319
	internal class #Foe
	{
		// Token: 0x060092CA RID: 37578 RVA: 0x001F29BC File Offset: 0x001F0BBC
		public #Foe(Stream #gp)
		{
			#gp.Seek(0L, SeekOrigin.Begin);
			this.#b = new StreamReader(#gp);
			this.#c = new List<string>();
			while (!this.#b.EndOfStream)
			{
				string #Ztc = this.#b.ReadLine();
				string item = this.#Aoe(#Ztc);
				this.#c.Add(item);
			}
		}

		// Token: 0x17002A8A RID: 10890
		// (get) Token: 0x060092CB RID: 37579 RVA: 0x00075CC1 File Offset: 0x00073EC1
		// (set) Token: 0x060092CC RID: 37580 RVA: 0x00075CC9 File Offset: 0x00073EC9
		public int Index { get; private set; }

		// Token: 0x060092CD RID: 37581 RVA: 0x00075CD2 File Offset: 0x00073ED2
		public void #poe()
		{
			this.Index = 0;
		}

		// Token: 0x060092CE RID: 37582 RVA: 0x001F2A20 File Offset: 0x001F0C20
		public bool #qoe(string #Zme)
		{
			#Foe.#s0b #s0b = new #Foe.#s0b();
			#s0b.#a = this;
			#s0b.#b = #Zme;
			List<string> list = this.#c.FindAll(new Predicate<string>(#s0b.#vbf));
			if (list.Count == 0)
			{
				return false;
			}
			if (list.Count == 1)
			{
				return true;
			}
			throw new #ooe(Strings.StringExpectedOnlyOneKeywordInFileButFound0.#D2d(new object[]
			{
				list.Count
			}).#z2d());
		}

		// Token: 0x060092CF RID: 37583 RVA: 0x001F2A98 File Offset: 0x001F0C98
		public int #roe(string #Xme, bool #soe)
		{
			int i = 0;
			while (i < this.#c.Count)
			{
				if (this.#Boe(this.#c[i], #Xme))
				{
					this.Index = i;
					if (!#soe)
					{
						return this.Index;
					}
					int num = this.Index + 1;
					this.Index = num;
					return num;
				}
				else
				{
					i++;
				}
			}
			throw new #ooe(Strings.StringCannotFind0Keyword.#D2d(new object[]
			{
				#Xme
			}).#z2d());
		}

		// Token: 0x060092D0 RID: 37584 RVA: 0x001F2B14 File Offset: 0x001F0D14
		public int #toe(bool #soe)
		{
			string #ioe = this.#Vle(#soe);
			return this.#yZd(#ioe);
		}

		// Token: 0x060092D1 RID: 37585 RVA: 0x001F2B30 File Offset: 0x001F0D30
		public int? #uoe()
		{
			this.#poe();
			string text = this.#Vle(false);
			this.#Eoe(text);
			int num;
			if (int.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out num) && num >= 0)
			{
				return new int?(num);
			}
			return null;
		}

		// Token: 0x060092D2 RID: 37586 RVA: 0x00075CDB File Offset: 0x00073EDB
		protected void #ame(string #hoe)
		{
			throw new #ooe(Strings.StringErrorReadingLine0.#D2d(new object[]
			{
				this.Index
			}).#z2d().#Tm() + #hoe);
		}

		// Token: 0x060092D3 RID: 37587 RVA: 0x001F2B7C File Offset: 0x001F0D7C
		public void #voe(out float #woe, out float #xoe, out float #yoe, bool #soe)
		{
			string #ioe = this.#Vle(#soe);
			float[] array = this.#zuc(#ioe, 3).Select(new Func<string, float>(this.#Coe)).ToArray<float>();
			#woe = array[0];
			#xoe = array[1];
			#yoe = array[2];
		}

		// Token: 0x060092D4 RID: 37588 RVA: 0x001F2BC0 File Offset: 0x001F0DC0
		public List<float> #voe(int #1f, bool #soe)
		{
			string #ioe = this.#Vle(#soe);
			return this.#zuc(#ioe, #1f).Select(new Func<string, float>(this.#Coe)).ToList<float>();
		}

		// Token: 0x060092D5 RID: 37589 RVA: 0x001F2BF4 File Offset: 0x001F0DF4
		public Stream #zoe()
		{
			MemoryStream memoryStream = new MemoryStream();
			StreamWriter streamWriter = new StreamWriter(memoryStream);
			for (int i = this.Index; i < this.#c.Count; i++)
			{
				streamWriter.WriteLine(this.#c[i]);
			}
			streamWriter.Flush();
			memoryStream.Position = 0L;
			return memoryStream;
		}

		// Token: 0x060092D6 RID: 37590 RVA: 0x00075D10 File Offset: 0x00073F10
		private string #Aoe(string #Ztc)
		{
			return Regex.Replace(#Ztc, #Phc.#3hc(107289589), string.Empty);
		}

		// Token: 0x060092D7 RID: 37591 RVA: 0x00075D27 File Offset: 0x00073F27
		private bool #Boe(string #ioe, string #Zme)
		{
			return !this.#Doe(#ioe) && #ioe.Trim().Equals(#Zme, StringComparison.InvariantCulture);
		}

		// Token: 0x060092D8 RID: 37592 RVA: 0x001F2C4C File Offset: 0x001F0E4C
		private int #yZd(string #ioe)
		{
			this.#Eoe(#ioe);
			int result;
			if (!int.TryParse(#ioe, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
			{
				this.#ame(Strings.StringCannotReadFieldOfType0.#D2d(new object[]
				{
					#Phc.#3hc(107289580)
				}).#z2d());
			}
			return result;
		}

		// Token: 0x060092D9 RID: 37593 RVA: 0x001F2CA0 File Offset: 0x001F0EA0
		private float #Coe(string #ioe)
		{
			this.#Eoe(#ioe);
			float result;
			if (!float.TryParse(#ioe, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
			{
				this.#ame(Strings.StringCannotReadFieldOfType0.#D2d(new object[]
				{
					#Phc.#3hc(107289575)
				}).#z2d());
			}
			return result;
		}

		// Token: 0x060092DA RID: 37594 RVA: 0x001F2CF4 File Offset: 0x001F0EF4
		private string #Vle(bool #soe)
		{
			string text;
			try
			{
				for (;;)
				{
					text = this.#c[this.Index];
					text = ((text != null) ? text.Trim() : null);
					if (!this.#Doe(text))
					{
						break;
					}
					int num = this.Index;
					this.Index = num + 1;
				}
			}
			catch (IndexOutOfRangeException)
			{
				throw new #ooe(Strings.StringUnexpectedEndOfFile.#z2d());
			}
			catch (ArgumentOutOfRangeException)
			{
				throw new #ooe(Strings.StringUnexpectedEndOfFile.#z2d());
			}
			if (#soe)
			{
				int num = this.Index;
				this.Index = num + 1;
			}
			return text;
		}

		// Token: 0x060092DB RID: 37595 RVA: 0x00075D41 File Offset: 0x00073F41
		private bool #Doe(string #Ztc)
		{
			return string.IsNullOrWhiteSpace(#Ztc);
		}

		// Token: 0x060092DC RID: 37596 RVA: 0x00075D49 File Offset: 0x00073F49
		private void #Eoe(string #Ztc)
		{
			if (string.IsNullOrWhiteSpace(#Ztc) || #Ztc.Contains(#Phc.#3hc(107408397)))
			{
				this.#ame(Strings.StringCannotReadFieldOfTypeString.#z2d());
			}
		}

		// Token: 0x060092DD RID: 37597 RVA: 0x001F2D90 File Offset: 0x001F0F90
		private string[] #zuc(string #ioe, int #1f)
		{
			string[] array = new string[0];
			try
			{
				char[] separator = new char[]
				{
					' ',
					'\t'
				};
				array = #ioe.Split(separator, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length != #1f)
				{
					throw new Exception();
				}
			}
			catch (Exception)
			{
				this.#ame(Strings.StringExpected0Parameters.#D2d(new object[]
				{
					#1f
				}).#z2d());
			}
			return array;
		}

		// Token: 0x04003E69 RID: 15977
		private const string #a = "\\/\\/.*$";

		// Token: 0x04003E6A RID: 15978
		private readonly StreamReader #b;

		// Token: 0x04003E6B RID: 15979
		private readonly List<string> #c;

		// Token: 0x04003E6C RID: 15980
		[CompilerGenerated]
		private int #d;

		// Token: 0x020010E0 RID: 4320
		[CompilerGenerated]
		private sealed class #s0b
		{
			// Token: 0x060092DF RID: 37599 RVA: 0x00075D75 File Offset: 0x00073F75
			internal bool #vbf(string #9o)
			{
				return this.#a.#Boe(#9o, this.#b);
			}

			// Token: 0x04003E6D RID: 15981
			public #Foe #a;

			// Token: 0x04003E6E RID: 15982
			public string #b;
		}
	}
}
