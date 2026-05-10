using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #2be;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02001024 RID: 4132
	public sealed class StandardBarsValidator : #tce<IList<IStandardBar>>
	{
		// Token: 0x06008DF4 RID: 36340 RVA: 0x001E3CF8 File Offset: 0x001E1EF8
		public StandardBarsValidator(#ice context)
		{
			StandardBarsValidator.#GTb #GTb = new StandardBarsValidator.#GTb();
			#GTb.#a = context;
			base..ctor(#GTb.#a);
			ParameterExpression parameterExpression = Expression.Parameter(typeof(IList<IStandardBar>), #Phc.#3hc(107380695));
			base.RuleForEach<IStandardBar>(Expression.Lambda<Func<IList<IStandardBar>, IEnumerable<IStandardBar>>>(parameterExpression, new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator<ExtendedStandardBarValidator>(new Func<IList<IStandardBar>, IStandardBar, ExtendedStandardBarValidator>(#GTb.#P7b), Array.Empty<string>());
			parameterExpression = Expression.Parameter(typeof(IList<IStandardBar>), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<IList<IStandardBar>, int>>(Expression.Property(parameterExpression, methodof(ICollection<IStandardBar>.get_Count())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.StandardBars.Count).#Vce(#Mce.#Hce(#Oce.#Jb, null));
		}

		// Token: 0x02001026 RID: 4134
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06008DF8 RID: 36344 RVA: 0x001E3DDC File Offset: 0x001E1FDC
			internal ExtendedStandardBarValidator #P7b(IList<IStandardBar> #Rf, IStandardBar #f)
			{
				StandardBarsValidator.#o7b #o7b = new StandardBarsValidator.#o7b();
				#o7b.#a = #Rf;
				return new ExtendedStandardBarValidator(this.#a, new Func<IList<IStandardBar>>(#o7b.#78e), new int?(#o7b.#a.IndexOf(#f)));
			}

			// Token: 0x04003B01 RID: 15105
			public #ice #a;
		}

		// Token: 0x02001027 RID: 4135
		[CompilerGenerated]
		private sealed class #o7b
		{
			// Token: 0x06008DFA RID: 36346 RVA: 0x00073176 File Offset: 0x00071376
			internal IList<IStandardBar> #78e()
			{
				return this.#a;
			}

			// Token: 0x04003B02 RID: 15106
			public IList<IStandardBar> #a;
		}
	}
}
