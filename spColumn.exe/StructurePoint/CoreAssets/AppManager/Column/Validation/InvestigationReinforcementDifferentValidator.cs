using System;
using System.Linq.Expressions;
using #0be;
using #2be;
using #7hc;
using #9pe;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02000FF0 RID: 4080
	public sealed class InvestigationReinforcementDifferentValidator : #tce<#bqe>
	{
		// Token: 0x06008D51 RID: 36177 RVA: 0x001E1154 File Offset: 0x001DF354
		public InvestigationReinforcementDifferentValidator(#ice context) : base(context)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(#bqe), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<#bqe, int>>(Expression.Property(parameterExpression, methodof(#bqe.get_LeftBarSize())), new ParameterExpression[]
			{
				parameterExpression
			})).#Sce(context).#Vce(#Mce.#Ace(#Oce.#r));
			parameterExpression = Expression.Parameter(typeof(#bqe), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<#bqe, int>>(Expression.Property(parameterExpression, methodof(#bqe.get_RightBarSize())), new ParameterExpression[]
			{
				parameterExpression
			})).#Sce(context).#Vce(#Mce.#Ace(#Oce.#s));
			parameterExpression = Expression.Parameter(typeof(#bqe), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<#bqe, int>>(Expression.Property(parameterExpression, methodof(#bqe.get_TopBarSize())), new ParameterExpression[]
			{
				parameterExpression
			})).#Sce(context).#Vce(#Mce.#Ace(#Oce.#p));
			parameterExpression = Expression.Parameter(typeof(#bqe), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<#bqe, int>>(Expression.Property(parameterExpression, methodof(#bqe.get_BottomBarSize())), new ParameterExpression[]
			{
				parameterExpression
			})).#Sce(context).#Vce(#Mce.#Ace(#Oce.#q));
			parameterExpression = Expression.Parameter(typeof(#bqe), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<#bqe, int>>(Expression.Property(parameterExpression, methodof(#bqe.get_LeftNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})).#Pce(base.Boundaries.Reinforcement.InvestigationDifferentLeftRightNumberOfBars).#Vce(#Mce.#Ace(#Oce.#n));
			parameterExpression = Expression.Parameter(typeof(#bqe), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<#bqe, int>>(Expression.Property(parameterExpression, methodof(#bqe.get_RightNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})).#Pce(base.Boundaries.Reinforcement.InvestigationDifferentLeftRightNumberOfBars).#Vce(#Mce.#Ace(#Oce.#o));
			parameterExpression = Expression.Parameter(typeof(#bqe), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<#bqe, int>>(Expression.Property(parameterExpression, methodof(#bqe.get_TopNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})).#Pce(base.Boundaries.Reinforcement.InvestigationDifferentTopBottomNumberOfBars).#Vce(#Mce.#Ace(#Oce.#l));
			parameterExpression = Expression.Parameter(typeof(#bqe), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<#bqe, int>>(Expression.Property(parameterExpression, methodof(#bqe.get_BottomNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})).#Pce(base.Boundaries.Reinforcement.InvestigationDifferentTopBottomNumberOfBars).#Vce(#Mce.#Ace(#Oce.#m));
			parameterExpression = Expression.Parameter(typeof(#bqe), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<#bqe, int>>(Expression.Property(parameterExpression, methodof(#bqe.get_LeftNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})).#Rce(base.Boundaries.Reinforcement.InvestigationDifferentLeftRightNumberOfBars).#Vce(#Mce.#Ace(#Oce.#n));
			parameterExpression = Expression.Parameter(typeof(#bqe), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<#bqe, int>>(Expression.Property(parameterExpression, methodof(#bqe.get_RightNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})).#Rce(base.Boundaries.Reinforcement.InvestigationDifferentLeftRightNumberOfBars).#Vce(#Mce.#Ace(#Oce.#o));
			parameterExpression = Expression.Parameter(typeof(#bqe), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<#bqe, int>>(Expression.Property(parameterExpression, methodof(#bqe.get_TopNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})).#Rce(base.Boundaries.Reinforcement.InvestigationDifferentTopBottomNumberOfBars).#Vce(#Mce.#Ace(#Oce.#l));
			parameterExpression = Expression.Parameter(typeof(#bqe), #Phc.#3hc(107380695));
			base.RuleFor<int>(Expression.Lambda<Func<#bqe, int>>(Expression.Property(parameterExpression, methodof(#bqe.get_BottomNumberOfBars())), new ParameterExpression[]
			{
				parameterExpression
			})).#Rce(base.Boundaries.Reinforcement.InvestigationDifferentTopBottomNumberOfBars).#Vce(#Mce.#Ace(#Oce.#m));
			parameterExpression = Expression.Parameter(typeof(#bqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#bqe, float>>(Expression.Property(parameterExpression, methodof(#bqe.get_LeftClearCover())), new ParameterExpression[]
			{
				parameterExpression
			})).#IBb(base.Boundaries.Reinforcement.ClearCover, context).#Vce(#Mce.#Ace(#Oce.#v));
			parameterExpression = Expression.Parameter(typeof(#bqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#bqe, float>>(Expression.Property(parameterExpression, methodof(#bqe.get_RightClearCover())), new ParameterExpression[]
			{
				parameterExpression
			})).#IBb(base.Boundaries.Reinforcement.ClearCover, context).#Vce(#Mce.#Ace(#Oce.#w));
			parameterExpression = Expression.Parameter(typeof(#bqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#bqe, float>>(Expression.Property(parameterExpression, methodof(#bqe.get_TopClearCover())), new ParameterExpression[]
			{
				parameterExpression
			})).#IBb(base.Boundaries.Reinforcement.ClearCover, context).#Vce(#Mce.#Ace(#Oce.#t));
			parameterExpression = Expression.Parameter(typeof(#bqe), #Phc.#3hc(107380695));
			base.RuleFor<float>(Expression.Lambda<Func<#bqe, float>>(Expression.Property(parameterExpression, methodof(#bqe.get_BottomClearCover())), new ParameterExpression[]
			{
				parameterExpression
			})).#IBb(base.Boundaries.Reinforcement.ClearCover, context).#Vce(#Mce.#Ace(#Oce.#u));
		}
	}
}
