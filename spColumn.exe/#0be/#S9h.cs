using System;
using System.Runtime.CompilerServices;
using #2be;
using #u9d;
using FluentValidation;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #0be
{
	// Token: 0x02000FCE RID: 4046
	internal static class #S9h
	{
		// Token: 0x06008CEA RID: 36074 RVA: 0x001DF258 File Offset: 0x001DD458
		public static IRuleBuilderOptions<#Fu, float> #IBb<#Fu>(this IRuleBuilder<#Fu, float> #Qce, #6ce #LBb, #ice #ib)
		{
			#S9h<#Fu>.#EUd #EUd = new #S9h<!!0>.#EUd();
			#EUd.#a = #LBb;
			if (#ib.#Qbe() || #ib.#Pbe())
			{
				#S9h<#Fu>.#sbi #sbi = new #S9h<!!0>.#sbi();
				#sbi.#b = #EUd;
				if (#ib.ProblemType == ProblemType.Investigation)
				{
					#sbi.#a = (#ib.#Qbe() ? Math.Min(#ib.InvestigationDimensions.DimensionA, #ib.InvestigationDimensions.DimensionB) : #ib.InvestigationDimensions.DimensionA);
				}
				else
				{
					#sbi.#a = (#ib.#Qbe() ? Math.Min(#ib.DesignDimensions.MinWidth, #ib.DesignDimensions.MinHeight) : #ib.DesignDimensions.MinWidth);
				}
				#sbi.#a = (float)#sbi.#b.#a.#3ce((double)(#sbi.#a / 3f));
				return #Qce.Must(new Func<float, bool>(#sbi.#qbi)).WithMessage(new Func<!!0, float, string>(#sbi.#rbi));
			}
			return #Qce.Must(new Func<!!0, float, bool>(#EUd.#obi)).WithMessage(new Func<!!0, float, string>(#EUd.#pbi));
		}

		// Token: 0x02000FCF RID: 4047
		[CompilerGenerated]
		private sealed class #EUd<#Fu>
		{
			// Token: 0x06008CEC RID: 36076 RVA: 0x00072779 File Offset: 0x00070979
			internal bool #obi(#Fu #Hi, float #f)
			{
				return #Xce.#IH(this.#a, (double)#f).IsValid;
			}

			// Token: 0x06008CED RID: 36077 RVA: 0x0007278D File Offset: 0x0007098D
			internal string #pbi(#Fu #Hi, float #f)
			{
				#IWc #IWc = #Xce.#IH(this.#a, (double)#f);
				if (#IWc == null)
				{
					return null;
				}
				return #IWc.ErrorMessage;
			}

			// Token: 0x04003A87 RID: 14983
			public #6ce #a;
		}

		// Token: 0x02000FD0 RID: 4048
		[CompilerGenerated]
		private sealed class #sbi<#Fu>
		{
			// Token: 0x06008CEF RID: 36079 RVA: 0x000727A7 File Offset: 0x000709A7
			internal bool #qbi(float #f)
			{
				return #f > 0f && #f <= this.#a;
			}

			// Token: 0x06008CF0 RID: 36080 RVA: 0x001DF374 File Offset: 0x001DD574
			internal string #rbi(#Fu #Hi, float #f)
			{
				if (#f <= 0f)
				{
					return Strings.StringTheValueShallBeGreaterThanX.#D2d(new object[]
					{
						this.#b.#a.Formatter.CreateDisplayValue(0.0)
					}).#z2d();
				}
				if (#f > this.#a)
				{
					return Strings.StringTheValueShallBeSmallerOrEqualTo13OfTheSmallestCrossSectionalDimension.#z2d();
				}
				return string.Empty;
			}

			// Token: 0x04003A88 RID: 14984
			public float #a;

			// Token: 0x04003A89 RID: 14985
			public #S9h<#Fu>.#EUd #b;
		}
	}
}
