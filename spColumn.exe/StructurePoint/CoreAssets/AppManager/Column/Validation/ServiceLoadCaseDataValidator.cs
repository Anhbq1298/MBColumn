using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #2be;
using #7hc;
using #9pe;
using FluentValidation;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02001014 RID: 4116
	public sealed class ServiceLoadCaseDataValidator : #tce<#qqe>
	{
		// Token: 0x06008DC3 RID: 36291 RVA: 0x001E2EC8 File Offset: 0x001E10C8
		public ServiceLoadCaseDataValidator(#ice context, int? serviceLoadIndex, #Nce itemType)
		{
			ServiceLoadCaseDataValidator.#GTb #GTb = new ServiceLoadCaseDataValidator.#GTb();
			#GTb.#a = context;
			base..ctor(#GTb.#a);
			ParameterExpression parameterExpression = Expression.Parameter(typeof(#qqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#qqe, float>>(Expression.Property(parameterExpression, methodof(#qqe.get_AxialLoad())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Loads.AxialLoad).#Vce(new #xce(itemType, #Oce.#fb, serviceLoadIndex, null));
			parameterExpression = Expression.Parameter(typeof(#qqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#qqe, float>>(Expression.Property(parameterExpression, methodof(#qqe.get_MomentXBottom())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Loads.MomentX).When(new Func<#qqe, bool>(#GTb.#g9e), ApplyConditionTo.AllValidators).#Vce(new #xce(itemType, #Oce.#hb, serviceLoadIndex, null));
			parameterExpression = Expression.Parameter(typeof(#qqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#qqe, float>>(Expression.Property(parameterExpression, methodof(#qqe.get_MomentXTop())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Loads.MomentX).When(new Func<#qqe, bool>(#GTb.#Q9e), ApplyConditionTo.AllValidators).#Vce(new #xce(itemType, #Oce.#gb, serviceLoadIndex, null));
			parameterExpression = Expression.Parameter(typeof(#qqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#qqe, float>>(Expression.Property(parameterExpression, methodof(#qqe.get_MomentYBottom())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Loads.MomentY).When(new Func<#qqe, bool>(#GTb.#M9e), ApplyConditionTo.AllValidators).#Vce(new #xce(itemType, #Oce.#jb, serviceLoadIndex, null));
			parameterExpression = Expression.Parameter(typeof(#qqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#qqe, float>>(Expression.Property(parameterExpression, methodof(#qqe.get_MomentYTop())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Loads.MomentY).When(new Func<#qqe, bool>(#GTb.#R9e), ApplyConditionTo.AllValidators).#Vce(new #xce(itemType, #Oce.#ib, serviceLoadIndex, null));
		}

		// Token: 0x02001016 RID: 4118
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06008DC7 RID: 36295 RVA: 0x00072FF5 File Offset: 0x000711F5
			internal bool #g9e(#qqe #Hi)
			{
				return this.#a.IsXAxisEnabled;
			}

			// Token: 0x06008DC8 RID: 36296 RVA: 0x00072FF5 File Offset: 0x000711F5
			internal bool #Q9e(#qqe #Hi)
			{
				return this.#a.IsXAxisEnabled;
			}

			// Token: 0x06008DC9 RID: 36297 RVA: 0x00073002 File Offset: 0x00071202
			internal bool #M9e(#qqe #Hi)
			{
				return this.#a.IsYAxisEnabled;
			}

			// Token: 0x06008DCA RID: 36298 RVA: 0x00073002 File Offset: 0x00071202
			internal bool #R9e(#qqe #Hi)
			{
				return this.#a.IsYAxisEnabled;
			}

			// Token: 0x04003AEA RID: 15082
			public #ice #a;
		}
	}
}
