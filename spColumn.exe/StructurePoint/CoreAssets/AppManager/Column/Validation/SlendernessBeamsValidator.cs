using System;
using System.Linq.Expressions;
using #2be;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02001017 RID: 4119
	public sealed class SlendernessBeamsValidator : #tce<SlendernessOfBeams>
	{
		// Token: 0x06008DCB RID: 36299 RVA: 0x001E316C File Offset: 0x001E136C
		public SlendernessBeamsValidator(#ice context, bool isX) : base(context)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(SlendernessOfBeams), #Phc.#3hc(107398878));
			base.RuleFor<Beam>(Expression.Lambda<Func<SlendernessOfBeams, Beam>>(Expression.Property(parameterExpression, methodof(SlendernessOfBeams.get_AboveLeft())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new SlendernessBeamValidator(context, isX ? #Nce.#E : #Nce.#I), Array.Empty<string>());
			parameterExpression = Expression.Parameter(typeof(SlendernessOfBeams), #Phc.#3hc(107398878));
			base.RuleFor<Beam>(Expression.Lambda<Func<SlendernessOfBeams, Beam>>(Expression.Property(parameterExpression, methodof(SlendernessOfBeams.get_AboveRight())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new SlendernessBeamValidator(context, isX ? #Nce.#F : #Nce.#J), Array.Empty<string>());
			parameterExpression = Expression.Parameter(typeof(SlendernessOfBeams), #Phc.#3hc(107398878));
			base.RuleFor<Beam>(Expression.Lambda<Func<SlendernessOfBeams, Beam>>(Expression.Property(parameterExpression, methodof(SlendernessOfBeams.get_BelowLeft())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new SlendernessBeamValidator(context, isX ? #Nce.#G : #Nce.#K), Array.Empty<string>());
			parameterExpression = Expression.Parameter(typeof(SlendernessOfBeams), #Phc.#3hc(107398878));
			base.RuleFor<Beam>(Expression.Lambda<Func<SlendernessOfBeams, Beam>>(Expression.Property(parameterExpression, methodof(SlendernessOfBeams.get_BelowRight())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator(new SlendernessBeamValidator(context, isX ? #Nce.#H : #Nce.#L), Array.Empty<string>());
		}
	}
}
