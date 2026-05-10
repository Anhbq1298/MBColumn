using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #2be;
using #7hc;
using FluentValidation;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02001028 RID: 4136
	public sealed class ExtendedStandardBarValidator : StandardBarValidator
	{
		// Token: 0x06008DFB RID: 36347 RVA: 0x001E3E20 File Offset: 0x001E2020
		public ExtendedStandardBarValidator(#ice context, Func<IList<IStandardBar>> totalBars, int? index = null)
		{
			ExtendedStandardBarValidator.#GTb #GTb = new ExtendedStandardBarValidator.#GTb();
			#GTb.#b = totalBars;
			base..ctor(context, index);
			#GTb.#a = this;
			ParameterExpression parameterExpression = Expression.Parameter(typeof(IStandardBar), #Phc.#3hc(107398878));
			base.RuleFor<int>(Expression.Lambda<Func<IStandardBar, int>>(Expression.Property(parameterExpression, methodof(IStandardBar.get_Size())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<IStandardBar, int, bool>(#GTb.#P7b)).WithMessage(new Func<IStandardBar, string>(ExtendedStandardBarValidator.<>c.<>9.#Kbe)).#Vce(#Mce.#Hce(#Oce.#9, index));
			parameterExpression = Expression.Parameter(typeof(IStandardBar), #Phc.#3hc(107398878));
			base.RuleFor<float>(Expression.Lambda<Func<IStandardBar, float>>(Expression.Property(parameterExpression, methodof(IStandardBar.get_Diameter())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<IStandardBar, float, bool>(#GTb.#Q9e)).WithMessage(new Func<IStandardBar, string>(ExtendedStandardBarValidator.<>c.<>9.#c9e)).#Vce(#Mce.#Hce(#Oce.#ab, index));
			parameterExpression = Expression.Parameter(typeof(IStandardBar), #Phc.#3hc(107398878));
			base.RuleFor<float>(Expression.Lambda<Func<IStandardBar, float>>(Expression.Property(parameterExpression, methodof(IStandardBar.get_Area())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<IStandardBar, float, bool>(#GTb.#h9e)).WithMessage(new Func<IStandardBar, string>(ExtendedStandardBarValidator.<>c.<>9.#e9e)).#Vce(#Mce.#Hce(#Oce.#L, index));
			parameterExpression = Expression.Parameter(typeof(IStandardBar), #Phc.#3hc(107398878));
			base.RuleFor<float>(Expression.Lambda<Func<IStandardBar, float>>(Expression.Property(parameterExpression, methodof(IStandardBar.get_Weight())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<IStandardBar, float, bool>(#GTb.#j9e)).WithMessage(new Func<IStandardBar, string>(ExtendedStandardBarValidator.<>c.<>9.#y9e)).#Vce(#Mce.#Hce(#Oce.#bb, index));
		}

		// Token: 0x06008DFC RID: 36348 RVA: 0x001E4068 File Offset: 0x001E2268
		private bool #Sbe(Func<IList<IStandardBar>> #Tbe, IStandardBar #Ube, Func<IStandardBar, float> #Vbe)
		{
			List<IStandardBar> list = #Tbe().ToList<IStandardBar>();
			int num = list.IndexOf(#Ube);
			if (!list.Any<IStandardBar>() || num < 0)
			{
				return true;
			}
			float num2 = #Vbe(#Ube);
			bool flag = true;
			if (num - 1 >= 0)
			{
				float num3 = list.Select(#Vbe).ElementAtOrDefault(num - 1);
				flag = (num2 > num3);
			}
			bool flag2 = true;
			if (num + 1 < list.Count - 1)
			{
				float num4 = list.Select(#Vbe).ElementAtOrDefault(num + 1);
				flag2 = (num4 == 0f || num2 < num4);
			}
			return flag && flag2;
		}

		// Token: 0x0200102A RID: 4138
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06008E08 RID: 36360 RVA: 0x000731B2 File Offset: 0x000713B2
			internal bool #P7b(IStandardBar #Rf, int #Hi)
			{
				return this.#a.#Sbe(this.#b, #Rf, new Func<IStandardBar, float>(ExtendedStandardBarValidator.<>c.<>9.#p9e));
			}

			// Token: 0x06008E09 RID: 36361 RVA: 0x000731E5 File Offset: 0x000713E5
			internal bool #Q9e(IStandardBar #Rf, float #Hi)
			{
				return this.#a.#Sbe(this.#b, #Rf, new Func<IStandardBar, float>(ExtendedStandardBarValidator.<>c.<>9.#t9e));
			}

			// Token: 0x06008E0A RID: 36362 RVA: 0x00073218 File Offset: 0x00071418
			internal bool #h9e(IStandardBar #Rf, float #Hi)
			{
				return this.#a.#Sbe(this.#b, #Rf, new Func<IStandardBar, float>(ExtendedStandardBarValidator.<>c.<>9.#U9e));
			}

			// Token: 0x06008E0B RID: 36363 RVA: 0x0007324B File Offset: 0x0007144B
			internal bool #j9e(IStandardBar #Rf, float #Hi)
			{
				return this.#a.#Sbe(this.#b, #Rf, new Func<IStandardBar, float>(ExtendedStandardBarValidator.<>c.<>9.#z9e));
			}

			// Token: 0x04003B0C RID: 15116
			public ExtendedStandardBarValidator #a;

			// Token: 0x04003B0D RID: 15117
			public Func<IList<IStandardBar>> #b;
		}
	}
}
