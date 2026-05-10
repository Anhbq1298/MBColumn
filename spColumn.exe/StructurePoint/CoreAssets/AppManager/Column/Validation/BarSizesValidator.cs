using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #2be;
using #7hc;
using FluentValidation;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02000FC1 RID: 4033
	public sealed class BarSizesValidator : #tce<ColumnStorageModel>
	{
		// Token: 0x06008C18 RID: 35864 RVA: 0x001DDDB8 File Offset: 0x001DBFB8
		public BarSizesValidator(#ice context)
		{
			BarSizesValidator.#GTb #GTb = new BarSizesValidator.#GTb();
			#GTb.#a = context;
			base..ctor(#GTb.#a);
			ParameterExpression parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<DesignReinforcement>(Expression.Lambda<Func<ColumnStorageModel, DesignReinforcement>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_DesignReinforcement())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new DesignReinforcementValidator(#GTb.#a), Array.Empty<string>()).When(new Func<ColumnStorageModel, bool>(#GTb.#P7b), ApplyConditionTo.AllValidators);
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<InvestigationReinforcement>(Expression.Lambda<Func<ColumnStorageModel, InvestigationReinforcement>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_InvestigationReinforcement())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new InvestigationReinforcementValidator(#GTb.#a), Array.Empty<string>()).When(new Func<ColumnStorageModel, bool>(#GTb.#78e), ApplyConditionTo.AllValidators);
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<Ties>(Expression.Lambda<Func<ColumnStorageModel, Ties>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_Ties())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new TiesValidator(#GTb.#a), Array.Empty<string>()).When(new Func<ColumnStorageModel, bool>(#GTb.#88e), ApplyConditionTo.AllValidators);
		}

		// Token: 0x06008C19 RID: 35865 RVA: 0x001DDF24 File Offset: 0x001DC124
		public static IList<ValidationFailure> #NRb(ColumnStorageModel #Od)
		{
			BarSizesValidator.#v0b #v0b = new BarSizesValidator.#v0b();
			ValidationResult validationResult = new BarSizesValidator(#Od.CreateContext()).Validate(#Od);
			#v0b.#a = new HashSet<#Oce>
			{
				#Oce.#p,
				#Oce.#q,
				#Oce.#r,
				#Oce.#s,
				#Oce.#F,
				#Oce.#G,
				#Oce.#H,
				#Oce.#I,
				#Oce.#k,
				#Oce.#y,
				#Oce.#A,
				#Oce.#6,
				#Oce.#7,
				#Oce.#8
			};
			return validationResult.Errors.Where(new Func<ValidationFailure, bool>(#v0b.#hdc)).ToList<ValidationFailure>();
		}

		// Token: 0x02000FC3 RID: 4035
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06008C1D RID: 35869 RVA: 0x00072078 File Offset: 0x00070278
			internal bool #P7b(ColumnStorageModel #Hi)
			{
				return this.#a.#fce();
			}

			// Token: 0x06008C1E RID: 35870 RVA: 0x00072085 File Offset: 0x00070285
			internal bool #78e(ColumnStorageModel #Hi)
			{
				return this.#a.#gce() && (this.#a.SectionType == SectionType.Rectangle || this.#a.SectionType == SectionType.Circle);
			}

			// Token: 0x06008C1F RID: 35871 RVA: 0x000720B3 File Offset: 0x000702B3
			internal bool #88e(ColumnStorageModel #Hi)
			{
				return this.#a.SectionType == SectionType.Rectangle || this.#a.SectionType == SectionType.Circle;
			}

			// Token: 0x04003A20 RID: 14880
			public #ice #a;
		}

		// Token: 0x02000FC4 RID: 4036
		[CompilerGenerated]
		private sealed class #v0b
		{
			// Token: 0x06008C21 RID: 35873 RVA: 0x000720D2 File Offset: 0x000702D2
			internal bool #hdc(ValidationFailure #Rf)
			{
				return this.#a.Contains(((#xce)#Rf.CustomState).Property);
			}

			// Token: 0x04003A21 RID: 14881
			public HashSet<#Oce> #a;
		}
	}
}
