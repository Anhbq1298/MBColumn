using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using #7hc;
using #coe;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.AppManager.Column.Storage.Core
{
	// Token: 0x020010B9 RID: 4281
	public class ImportBase
	{
		// Token: 0x060091F9 RID: 37369 RVA: 0x000756A6 File Offset: 0x000738A6
		protected void #ame(string #hoe)
		{
			throw new #ooe(Strings.StringErrorReadingLine0.#D2d(new object[]
			{
				this.#a
			}).#z2d().#Tm() + #hoe);
		}

		// Token: 0x060091FA RID: 37370 RVA: 0x000756DB File Offset: 0x000738DB
		protected string #Vle(StreamReader #blc)
		{
			this.#a++;
			return #blc.ReadLine();
		}

		// Token: 0x060091FB RID: 37371 RVA: 0x001F01DC File Offset: 0x001EE3DC
		protected int #Gic(string #ioe)
		{
			int result = 0;
			if (string.IsNullOrWhiteSpace(#ioe) || #ioe.Contains(#Phc.#3hc(107408397)) || !int.TryParse(#ioe, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
			{
				this.#ame(Strings.StringCannotReadFieldOfType0.#D2d(new object[]
				{
					#Phc.#3hc(107289580)
				}).#z2d());
			}
			return result;
		}

		// Token: 0x060091FC RID: 37372 RVA: 0x001F0244 File Offset: 0x001EE444
		protected float #d6d(string #ioe)
		{
			float result = 0f;
			if (string.IsNullOrWhiteSpace(#ioe) || #ioe.Contains(#Phc.#3hc(107408397)) || !float.TryParse(#ioe, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
			{
				this.#ame(Strings.StringCannotReadFieldOfType0.#D2d(new object[]
				{
					#Phc.#3hc(107289575)
				}).#z2d());
			}
			return result;
		}

		// Token: 0x060091FD RID: 37373 RVA: 0x001F02B0 File Offset: 0x001EE4B0
		protected double #SAc(string #ioe)
		{
			double result = 0.0;
			if (string.IsNullOrWhiteSpace(#ioe) || #ioe.Contains(#Phc.#3hc(107408397)) || !double.TryParse(#ioe, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
			{
				this.#ame(Strings.StringCannotReadFieldOfType0.#D2d(new object[]
				{
					#Phc.#3hc(107289598)
				}).#z2d());
			}
			return result;
		}

		// Token: 0x060091FE RID: 37374 RVA: 0x001F0320 File Offset: 0x001EE520
		protected string[] #zuc(string #ioe, int #joe)
		{
			this.#noe(#ioe);
			char[] separator = new char[]
			{
				' ',
				'\t'
			};
			string[] array = this.#moe(#ioe.Split(separator, #joe));
			if (array.Length != #joe)
			{
				this.#ame(Strings.StringExpected0Parameters.#D2d(new object[]
				{
					#joe
				}).#z2d());
			}
			return array;
		}

		// Token: 0x060091FF RID: 37375 RVA: 0x001F0380 File Offset: 0x001EE580
		protected string[] #koe(string #ioe, string #loe, int #joe)
		{
			this.#noe(#ioe);
			string[] array = this.#moe(Regex.Split(#ioe, #loe));
			if (array.Length != #joe)
			{
				this.#ame(Strings.StringExpected0Parameters.#D2d(new object[]
				{
					#joe
				}).#z2d());
			}
			return array;
		}

		// Token: 0x06009200 RID: 37376 RVA: 0x000756F1 File Offset: 0x000738F1
		private string[] #moe(string[] #7me)
		{
			return #7me.Where(new Func<string, bool>(ImportBase.<>c.<>9.#ubf)).ToArray<string>();
		}

		// Token: 0x06009201 RID: 37377 RVA: 0x0007571D File Offset: 0x0007391D
		private void #noe(string #ioe)
		{
			if (string.IsNullOrWhiteSpace(#ioe))
			{
				this.#ame(Strings.StringCannotReadFieldOfTypeString.#z2d());
			}
		}

		// Token: 0x04003D68 RID: 15720
		protected int #a;
	}
}
