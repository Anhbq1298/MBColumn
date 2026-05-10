using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #2be;
using #7hc;
using FluentValidation;
using StructurePoint.CoreAssets.AppManager.Column.Helpers;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02000FF4 RID: 4084
	public sealed class SectionPolygonValidator : #tce<SectionPolygon>
	{
		// Token: 0x06008D57 RID: 36183 RVA: 0x001E1940 File Offset: 0x001DFB40
		public SectionPolygonValidator(#ice context, int index) : base(context)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(SectionPolygon), #Phc.#3hc(107399958));
			base.RuleFor<int>(Expression.Lambda<Func<SectionPolygon, int>>(Expression.Property(Expression.Property(parameterExpression, methodof(SectionPolygon.get_Points())), methodof(List<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point>.get_Count())), new ParameterExpression[]
			{
				parameterExpression
			})).#Tce(base.Boundaries.Core.SectionPolygonPointsNumber).#Vce(new #xce(#Nce.#M, #Oce.#Cb));
			parameterExpression = Expression.Parameter(typeof(SectionPolygon), #Phc.#3hc(107399958));
			base.RuleFor<SectionPolygon>(Expression.Lambda<Func<SectionPolygon, SectionPolygon>>(parameterExpression, new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<SectionPolygon, bool>(this.#Jbe)).When(new Func<SectionPolygon, bool>(this.#Kbe), ApplyConditionTo.AllValidators).WithMessage(string.Format(#Phc.#3hc(107246296), index + 1).#z2d()).#Vce(new #xce(#Nce.#M, #Oce.#Db));
		}

		// Token: 0x06008D58 RID: 36184 RVA: 0x001E1A58 File Offset: 0x001DFC58
		private bool #Jbe(SectionPolygon #JP)
		{
			bool result;
			try
			{
				result = ColumnGeometryHelper.#1lc(#JP.Points.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, Point3D>(SectionPolygonValidator.<>c.<>9.#G9e)).ToList<Point3D>());
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06008D59 RID: 36185 RVA: 0x00072B6F File Offset: 0x00070D6F
		[CompilerGenerated]
		private bool #Kbe(SectionPolygon #JP)
		{
			return base.Boundaries.Core.SectionPolygonPointsNumber.#K6c((double)#JP.Points.Count);
		}
	}
}
