using System;
using System.Runtime.CompilerServices;
using #7hc;
using #9pe;
using #u9d;
using FluentValidation;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #2be
{
	// Token: 0x0200103C RID: 4156
	internal static class #Xce
	{
		// Token: 0x06008E78 RID: 36472 RVA: 0x001E5984 File Offset: 0x001E3B84
		public static IRuleBuilderOptions<#bqe, int> #Pce(this IRuleBuilder<#bqe, int> #Qce, #6ce #LBb)
		{
			double valueOrDefault = #LBb.Min.GetValueOrDefault();
			return #Qce.GreaterThanOrEqualTo((int)valueOrDefault).WithMessage(Strings.StringTheValueShallBeGreaterOrEqualToX.#D2d(new object[]
			{
				valueOrDefault
			}));
		}

		// Token: 0x06008E79 RID: 36473 RVA: 0x001E59C8 File Offset: 0x001E3BC8
		public static IRuleBuilderOptions<#bqe, int> #Rce(this IRuleBuilder<#bqe, int> #Qce, #6ce #LBb)
		{
			#Xce.#v0b #v0b = new #Xce.#v0b();
			#v0b.#a = #LBb.Max.GetValueOrDefault();
			return #Qce.Must(new Func<#bqe, int, bool>(#v0b.#caf)).WithMessage(Strings.StringMaximumNumberOfBarsExceededX.#D2d(new object[]
			{
				#v0b.#a
			}));
		}

		// Token: 0x06008E7A RID: 36474 RVA: 0x001E5A24 File Offset: 0x001E3C24
		public static IRuleBuilderOptions<#Fu, int> #Sce<#Fu>(this IRuleBuilder<#Fu, int> #Qce, #ice #ib)
		{
			#Xce<#Fu>.#Xad #Xad = new #Xce<!!0>.#Xad();
			#Xad.#a = #ib;
			return #Qce.Must(new Func<int, bool>(#Xad.#daf)).WithMessage(#Phc.#3hc(107246365).#z2d());
		}

		// Token: 0x06008E7B RID: 36475 RVA: 0x001E5A64 File Offset: 0x001E3C64
		public static IRuleBuilderOptions<#Fu, double> #Tce<#Fu>(this IRuleBuilder<#Fu, double> #Qce, #6ce #LBb)
		{
			#Xce<#Fu>.#jcd #jcd = new #Xce<!!0>.#jcd();
			#jcd.#a = #LBb;
			return #Qce.Must(new Func<!!0, double, bool>(#jcd.#eaf)).WithMessage(new Func<!!0, double, string>(#jcd.#faf));
		}

		// Token: 0x06008E7C RID: 36476 RVA: 0x00073748 File Offset: 0x00071948
		public static bool #K6c(this #6ce #LBb, double #f)
		{
			return new #t9d(#LBb.Min, #LBb.Max, #LBb.IncludeMin, #LBb.IncludeMax).#IH(#LBb.Formatter, #f, string.Empty).IsValid;
		}

		// Token: 0x06008E7D RID: 36477 RVA: 0x001E5AA4 File Offset: 0x001E3CA4
		public static IRuleBuilderOptions<#Fu, int> #Tce<#Fu>(this IRuleBuilder<#Fu, int> #Qce, #6ce #LBb)
		{
			#Xce<#Fu>.#I4d #I4d = new #Xce<!!0>.#I4d();
			#I4d.#a = #LBb;
			return #Qce.Must(new Func<!!0, int, bool>(#I4d.#eaf)).WithMessage(new Func<!!0, int, string>(#I4d.#faf));
		}

		// Token: 0x06008E7E RID: 36478 RVA: 0x001E5AE4 File Offset: 0x001E3CE4
		public static IRuleBuilderOptions<#Fu, float> #Tce<#Fu>(this IRuleBuilder<#Fu, float> #Qce, #6ce #LBb)
		{
			#Xce<#Fu>.#gaf #gaf = new #Xce<!!0>.#gaf();
			#gaf.#a = #LBb;
			return #Qce.Must(new Func<!!0, float, bool>(#gaf.#eaf)).WithMessage(new Func<!!0, float, string>(#gaf.#faf));
		}

		// Token: 0x06008E7F RID: 36479 RVA: 0x001E5B24 File Offset: 0x001E3D24
		public static IRuleBuilderOptions<#Fu, float> #Tce<#Fu>(this IRuleBuilder<#Fu, float> #Qce, Func<#Fu, float, #6ce> #Uce)
		{
			#Xce<#Fu>.#haf #haf = new #Xce<!!0>.#haf();
			#haf.#a = #Uce;
			return #Qce.Must(new Func<!!0, float, bool>(#haf.#eaf)).WithMessage(new Func<!!0, float, string>(#haf.#faf));
		}

		// Token: 0x06008E80 RID: 36480 RVA: 0x001E5B64 File Offset: 0x001E3D64
		public static IRuleBuilderOptions<#Fu, #10> #Vce<#Fu, #10>(this IRuleBuilderOptions<#Fu, #10> #Wce, #xce #3ab)
		{
			#Xce<#Fu, #10>.#jaf #jaf = new #Xce<!!0, !!1>.#jaf();
			#jaf.#a = #3ab;
			return #Wce.WithState(new Func<!!0, object>(#jaf.#iaf)).WithSeverity(Severity.Error);
		}

		// Token: 0x06008E81 RID: 36481 RVA: 0x001E5B98 File Offset: 0x001E3D98
		public static #IWc #IH(#6ce #LBb, double #f)
		{
			#f = #LBb.#3ce(#f);
			#LBb.#2ce();
			return new #t9d(#LBb.Min, #LBb.Max, #LBb.IncludeMin, #LBb.IncludeMax)
			{
				ForceFormatter = true,
				DisplayValueMultiplier = #LBb.DisplayValueMultiplier
			}.#IH(#LBb.Formatter, #f, string.Empty);
		}

		// Token: 0x0200103D RID: 4157
		[CompilerGenerated]
		private sealed class #v0b
		{
			// Token: 0x06008E83 RID: 36483 RVA: 0x0007377D File Offset: 0x0007197D
			internal bool #caf(#bqe #Rf, int #f)
			{
				return (double)(#Rf.LeftNumberOfBars + #Rf.RightNumberOfBars + #Rf.TopNumberOfBars + #Rf.BottomNumberOfBars) <= this.#a;
			}

			// Token: 0x04003BBD RID: 15293
			public double #a;
		}

		// Token: 0x0200103E RID: 4158
		[CompilerGenerated]
		private sealed class #Xad<#Fu>
		{
			// Token: 0x06008E85 RID: 36485 RVA: 0x000737A6 File Offset: 0x000719A6
			internal bool #daf(int #f)
			{
				return this.#a.#bce(#f);
			}

			// Token: 0x04003BBE RID: 15294
			public #ice #a;
		}

		// Token: 0x0200103F RID: 4159
		[CompilerGenerated]
		private sealed class #jcd<#Fu>
		{
			// Token: 0x06008E87 RID: 36487 RVA: 0x000737B4 File Offset: 0x000719B4
			internal bool #eaf(#Fu #Rf, double #f)
			{
				return #Xce.#IH(this.#a, #f).IsValid;
			}

			// Token: 0x06008E88 RID: 36488 RVA: 0x000737C7 File Offset: 0x000719C7
			internal string #faf(#Fu #Rf, double #f)
			{
				#IWc #IWc = #Xce.#IH(this.#a, #f);
				if (#IWc == null)
				{
					return null;
				}
				return #IWc.ErrorMessage;
			}

			// Token: 0x04003BBF RID: 15295
			public #6ce #a;
		}

		// Token: 0x02001040 RID: 4160
		[CompilerGenerated]
		private sealed class #I4d<#Fu>
		{
			// Token: 0x06008E8A RID: 36490 RVA: 0x000737E0 File Offset: 0x000719E0
			internal bool #eaf(#Fu #Rf, int #f)
			{
				return #Xce.#IH(this.#a, (double)#f).IsValid;
			}

			// Token: 0x06008E8B RID: 36491 RVA: 0x000737F4 File Offset: 0x000719F4
			internal string #faf(#Fu #Rf, int #f)
			{
				#IWc #IWc = #Xce.#IH(this.#a, (double)#f);
				if (#IWc == null)
				{
					return null;
				}
				return #IWc.ErrorMessage;
			}

			// Token: 0x04003BC0 RID: 15296
			public #6ce #a;
		}

		// Token: 0x02001041 RID: 4161
		[CompilerGenerated]
		private sealed class #gaf<#Fu>
		{
			// Token: 0x06008E8D RID: 36493 RVA: 0x0007380E File Offset: 0x00071A0E
			internal bool #eaf(#Fu #Rf, float #f)
			{
				return #Xce.#IH(this.#a, (double)#f).IsValid;
			}

			// Token: 0x06008E8E RID: 36494 RVA: 0x00073822 File Offset: 0x00071A22
			internal string #faf(#Fu #Rf, float #f)
			{
				#IWc #IWc = #Xce.#IH(this.#a, (double)#f);
				if (#IWc == null)
				{
					return null;
				}
				return #IWc.ErrorMessage;
			}

			// Token: 0x04003BC1 RID: 15297
			public #6ce #a;
		}

		// Token: 0x02001042 RID: 4162
		[CompilerGenerated]
		private sealed class #haf<#Fu>
		{
			// Token: 0x06008E90 RID: 36496 RVA: 0x0007383C File Offset: 0x00071A3C
			internal bool #eaf(#Fu #Rf, float #f)
			{
				return #Xce.#IH(this.#a(#Rf, #f), (double)#f).IsValid;
			}

			// Token: 0x06008E91 RID: 36497 RVA: 0x00073857 File Offset: 0x00071A57
			internal string #faf(#Fu #Rf, float #f)
			{
				return #Xce.#IH(this.#a(#Rf, #f), (double)#f).ErrorMessage;
			}

			// Token: 0x04003BC2 RID: 15298
			public Func<#Fu, float, #6ce> #a;
		}

		// Token: 0x02001043 RID: 4163
		[CompilerGenerated]
		private sealed class #jaf<#Fu, #10>
		{
			// Token: 0x06008E93 RID: 36499 RVA: 0x00073872 File Offset: 0x00071A72
			internal object #iaf(#Fu #Rf)
			{
				return this.#a;
			}

			// Token: 0x04003BC3 RID: 15299
			public #xce #a;
		}
	}
}
