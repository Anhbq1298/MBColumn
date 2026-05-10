using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #2be;
using #7hc;
using FluentValidation;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x0200101A RID: 4122
	public sealed class SlendernessBeamValidator : #tce<IBeam>
	{
		// Token: 0x06008DD8 RID: 36312 RVA: 0x001E3350 File Offset: 0x001E1550
		public SlendernessBeamValidator(#ice context, #Nce itemType)
		{
			SlendernessBeamValidator.#GTb #GTb = new SlendernessBeamValidator.#GTb();
			#GTb.#b = context;
			base..ctor(#GTb.#b);
			#GTb.#a = this;
			ParameterExpression parameterExpression = Expression.Parameter(typeof(IBeam), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<IBeam, float>>(Expression.Property(parameterExpression, methodof(IBeam.get_Width())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Slenderness.SlendernessBeamWidth).When(new Func<IBeam, bool>(SlendernessBeamValidator.<>c.<>9.#98e), ApplyConditionTo.AllValidators).#Vce(new #xce(itemType, #Oce.#xb));
			parameterExpression = Expression.Parameter(typeof(IBeam), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<IBeam, float>>(Expression.Property(parameterExpression, methodof(IBeam.get_Depth())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Slenderness.SlendernessBeamDepth).When(new Func<IBeam, bool>(SlendernessBeamValidator.<>c.<>9.#b9e), ApplyConditionTo.AllValidators).#Vce(new #xce(itemType, #Oce.#wb));
			parameterExpression = Expression.Parameter(typeof(IBeam), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<IBeam, float>>(Expression.Property(parameterExpression, methodof(IBeam.get_Ec())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Slenderness.SlendernessBeamEc).When(new Func<IBeam, bool>(SlendernessBeamValidator.<>c.<>9.#c9e), ApplyConditionTo.AllValidators).#Vce(new #xce(itemType, #Oce.#P));
			parameterExpression = Expression.Parameter(typeof(IBeam), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<IBeam, float>>(Expression.Property(parameterExpression, methodof(IBeam.get_Fcp())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(new Func<IBeam, float, #6ce>(#GTb.#h9e)).When(new Func<IBeam, bool>(SlendernessBeamValidator.<>c.<>9.#e9e), ApplyConditionTo.AllValidators).#Vce(new #xce(itemType, #Oce.#W));
			parameterExpression = Expression.Parameter(typeof(IBeam), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<IBeam, float>>(Expression.Property(parameterExpression, methodof(IBeam.get_Length())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Slenderness.SlendernessBeamLength).When(new Func<IBeam, bool>(SlendernessBeamValidator.<>c.<>9.#S9e), ApplyConditionTo.AllValidators).#Vce(new #xce(itemType, #Oce.#yb));
			parameterExpression = Expression.Parameter(typeof(IBeam), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<IBeam, float>>(Expression.Property(parameterExpression, methodof(IBeam.get_MofI())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Slenderness.SlendernessBeamMofi).When(new Func<IBeam, bool>(SlendernessBeamValidator.<>c.<>9.#p9e), ApplyConditionTo.AllValidators).#Vce(new #xce(itemType, #Oce.#zb));
		}

		// Token: 0x0200101C RID: 4124
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06008DE2 RID: 36322 RVA: 0x000730AA File Offset: 0x000712AA
			internal #6ce #h9e(IBeam #Rf, float #Hi)
			{
				return this.#a.Boundaries.Materials.#1de(this.#b, #Rf.IsConcreteStandard);
			}

			// Token: 0x04003AF7 RID: 15095
			public SlendernessBeamValidator #a;

			// Token: 0x04003AF8 RID: 15096
			public #ice #b;
		}
	}
}
