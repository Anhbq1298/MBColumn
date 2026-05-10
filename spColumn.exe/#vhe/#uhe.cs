using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using #7hc;
using #Nhe;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Units;

namespace #vhe
{
	// Token: 0x02001089 RID: 4233
	internal sealed class #uhe
	{
		// Token: 0x060090B1 RID: 37041 RVA: 0x001EA428 File Offset: 0x001E8628
		public #uhe(UnitSystem #Qg)
		{
			this.#a = #Qg;
		}

		// Token: 0x060090B2 RID: 37042 RVA: 0x001EA490 File Offset: 0x001E8690
		public #Mhe #1vb(string #qhe, string #3)
		{
			#uhe.#dZb #dZb = new #uhe.#dZb();
			#dZb.#b = #3;
			#uhe.#dZb #dZb2 = #dZb;
			string text = #dZb.#b;
			#dZb2.#b = ((text != null) ? text.Trim() : null);
			if (string.IsNullOrWhiteSpace(#dZb.#b))
			{
				return null;
			}
			string #f;
			if (!this.#rhe(#qhe, #dZb.#b, out #f, out #dZb.#a))
			{
				#dZb.#a = #dZb.#b;
				this.#b.ForEach(new Action<string>(#dZb.#Saf));
				#f = (this.#b.Any(new Func<string, bool>(#dZb.#odc)) ? (#qhe.#O2d() + #dZb.#b) : #dZb.#b);
			}
			string #f2 = string.Empty;
			if (#dZb.#b.Contains(#Phc.#3hc(107333712)))
			{
				#f2 = Strings.StringTheValueShallBeSmallerOrEqualToX.#D2d(new object[]
				{
					#dZb.#a
				});
			}
			else if (#dZb.#b.Contains(#Phc.#3hc(107224249)))
			{
				#f2 = Strings.StringTheValueShallBeSmallerThanX.#D2d(new object[]
				{
					#dZb.#a
				});
			}
			else if (#dZb.#b.Contains(#Phc.#3hc(107333675)))
			{
				#f2 = Strings.StringTheValueShallBeGreaterOrEqualToX.#D2d(new object[]
				{
					#dZb.#a
				});
			}
			else if (#dZb.#b.Contains(#Phc.#3hc(107352984)))
			{
				#f2 = Strings.StringTheValueShallBeGreaterThanX.#D2d(new object[]
				{
					#dZb.#a
				});
			}
			return new #Mhe
			{
				ErrorMessage = #f2,
				ExecutionCode = #f
			};
		}

		// Token: 0x060090B3 RID: 37043 RVA: 0x001EA624 File Offset: 0x001E8824
		private bool #rhe(string #sge, string #3, out string #she, out string #the)
		{
			#uhe.#xTb #xTb = new #uhe.#xTb();
			#xTb.#a = this;
			Regex regex = new Regex(#Phc.#3hc(107333670), RegexOptions.IgnoreCase | RegexOptions.Compiled);
			#the = null;
			#xTb.#b = null;
			#she = #sge + #Phc.#3hc(107399922) + regex.Replace(#3, new MatchEvaluator(#xTb.#Taf));
			#the = #xTb.#b;
			return !string.IsNullOrWhiteSpace(#xTb.#b);
		}

		// Token: 0x04003CCC RID: 15564
		private readonly UnitSystem #a;

		// Token: 0x04003CCD RID: 15565
		private readonly List<string> #b = new List<string>
		{
			#Phc.#3hc(107333712),
			#Phc.#3hc(107224249),
			#Phc.#3hc(107333675),
			#Phc.#3hc(107352984)
		};

		// Token: 0x0200108A RID: 4234
		[CompilerGenerated]
		private sealed class #dZb
		{
			// Token: 0x060090B5 RID: 37045 RVA: 0x00074BB0 File Offset: 0x00072DB0
			internal void #Saf(string #Rf)
			{
				this.#a = this.#a.Replace(#Rf, string.Empty);
			}

			// Token: 0x060090B6 RID: 37046 RVA: 0x00074BC9 File Offset: 0x00072DC9
			internal bool #odc(string #Rf)
			{
				return this.#b.StartsWith(#Rf);
			}

			// Token: 0x04003CCE RID: 15566
			public string #a;

			// Token: 0x04003CCF RID: 15567
			public string #b;
		}

		// Token: 0x0200108B RID: 4235
		[CompilerGenerated]
		private sealed class #xTb
		{
			// Token: 0x060090B8 RID: 37048 RVA: 0x001EA698 File Offset: 0x001E8898
			internal string #Taf(Match #a2d)
			{
				string result = (this.#a.#a == UnitSystem.USCustomary) ? #a2d.Groups[#Phc.#3hc(107309855)].Value : #a2d.Groups[#Phc.#3hc(107309872)].Value;
				this.#b = result;
				return result;
			}

			// Token: 0x04003CD0 RID: 15568
			public #uhe #a;

			// Token: 0x04003CD1 RID: 15569
			public string #b;
		}
	}
}
