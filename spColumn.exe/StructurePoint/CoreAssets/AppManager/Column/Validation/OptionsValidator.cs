using System;
using System.Linq.Expressions;
using #2be;
using #7hc;
using FluentValidation;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02000FCB RID: 4043
	public sealed class OptionsValidator : #tce<Options>
	{
		// Token: 0x06008CA5 RID: 36005 RVA: 0x001DEEB4 File Offset: 0x001DD0B4
		public OptionsValidator(#ice context) : base(context)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(Options), #Phc.#3hc(107380695));
			base.RuleFor<LoadType>(Expression.Lambda<Func<Options, LoadType>>(Expression.Property(parameterExpression, methodof(Options.get_DesignLoad())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<LoadType, bool>(OptionsValidator.<>c.<>9.#98e)).When(new Func<Options, bool>(OptionsValidator.<>c.<>9.#Kbe), ApplyConditionTo.AllValidators).#Vce(#Mce.#k3(#Oce.#Ab)).WithMessage(new Func<Options, LoadType, string>(OptionsValidator.<>c.<>9.#b9e));
			parameterExpression = Expression.Parameter(typeof(Options), #Phc.#3hc(107380695));
			base.RuleFor<LoadType>(Expression.Lambda<Func<Options, LoadType>>(Expression.Property(parameterExpression, methodof(Options.get_ActiveLoad())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<LoadType, bool>(OptionsValidator.<>c.<>9.#c9e)).When(new Func<Options, bool>(OptionsValidator.<>c.<>9.#d9e), ApplyConditionTo.AllValidators).#Vce(#Mce.#k3(#Oce.#Ab)).WithMessage(Strings.StringUnallowedLoadType.#z2d(true) + Strings.StringOnlyServiceLoadsAreAllowedWhenSlendernessIsConsideredInRunOptions.#z2d());
			parameterExpression = Expression.Parameter(typeof(Options), #Phc.#3hc(107380695));
			base.RuleFor<SectionType>(Expression.Lambda<Func<Options, SectionType>>(Expression.Property(parameterExpression, methodof(Options.get_SectionType())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<SectionType, bool>(OptionsValidator.<>c.<>9.#e9e)).When(new Func<Options, bool>(OptionsValidator.<>c.<>9.#f9e), ApplyConditionTo.AllValidators).#Vce(#Mce.#k3(#Oce.#Bb)).WithMessage(Strings.StringUnallowedSectionType.#z2d(true) + Strings.StringOnlyRectangularOrCircularSectionsAreAllowedInDesignMode.#z2d());
		}
	}
}
