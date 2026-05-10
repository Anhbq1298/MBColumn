using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #2be;
using #7hc;
using devDept.Geometry;
using FluentValidation;
using NetTopologySuite.Geometries;
using StructurePoint.CoreAssets.AppManager.Column.Helpers;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.AppManager.Column.Validation
{
	// Token: 0x02000FF8 RID: 4088
	public sealed class IrregularSectionValidator : #tce<ColumnStorageModel>
	{
		// Token: 0x06008D77 RID: 36215 RVA: 0x001E1B84 File Offset: 0x001DFD84
		public IrregularSectionValidator(#ice context)
		{
			IrregularSectionValidator.#GTb #GTb = new IrregularSectionValidator.#GTb();
			#GTb.#a = context;
			base..ctor(#GTb.#a);
			#GTb.#b = this;
			ParameterExpression parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleForEach<SectionPolygon>(Expression.Lambda<Func<ColumnStorageModel, IEnumerable<SectionPolygon>>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_Polygons())), new ParameterExpression[]
			{
				parameterExpression
			})).SetValidator<SectionPolygonValidator>(new Func<ColumnStorageModel, SectionPolygon, SectionPolygonValidator>(#GTb.#P7b), Array.Empty<string>());
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<List<SectionPolygon>>(Expression.Lambda<Func<ColumnStorageModel, List<SectionPolygon>>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_Polygons())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<List<SectionPolygon>, bool>(IrregularSectionValidator.<>c.<>9.#b9e)).WithMessage(#Phc.#3hc(107246183).#z2d()).#Vce(new #xce(#Nce.#M, #Oce.#Eb));
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<List<SectionPolygon>>(Expression.Lambda<Func<ColumnStorageModel, List<SectionPolygon>>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_Polygons())), new ParameterExpression[]
			{
				parameterExpression
			})).Transform<List<IrregularSectionValidator.SectionFigure>>(new Func<List<SectionPolygon>, List<IrregularSectionValidator.SectionFigure>>(IrregularSectionValidator.<>c.<>9.#c9e)).SetValidator(new IrregularSectionValidator.FiguresValidator(), Array.Empty<string>()).When(new Func<ColumnStorageModel, bool>(#GTb.#M9e), ApplyConditionTo.AllValidators).#Vce(new #xce(#Nce.#M, #Oce.#Eb));
			parameterExpression = Expression.Parameter(typeof(ColumnStorageModel), #Phc.#3hc(107230552));
			base.RuleFor<List<ReinforcementBar>>(Expression.Lambda<Func<ColumnStorageModel, List<ReinforcementBar>>>(Expression.Property(parameterExpression, methodof(ColumnStorageModel.get_ReinforcementBars())), new ParameterExpression[]
			{
				parameterExpression
			})).Must(new Func<List<ReinforcementBar>, bool>(this.#Lbe)).WithMessage(Strings.StringSectionContainsOverlappingBars.#z2d()).#Vce(new #xce(#Nce.#m, #Oce.#Ib)).WithSeverity(Severity.Warning);
		}

		// Token: 0x06008D78 RID: 36216 RVA: 0x001E1DA8 File Offset: 0x001DFFA8
		private bool #Lbe(IList<ReinforcementBar> #KJ)
		{
			List<IrregularSectionValidator.BarDistanceMetadata> list = #KJ.Where(new Func<ReinforcementBar, bool>(IrregularSectionValidator.<>c.<>9.#N9e)).Select(new Func<ReinforcementBar, IrregularSectionValidator.BarDistanceMetadata>(IrregularSectionValidator.<>c.<>9.#O9e)).ToList<IrregularSectionValidator.BarDistanceMetadata>();
			for (int i = 0; i < list.Count; i++)
			{
				IrregularSectionValidator.BarDistanceMetadata value = list[i];
				Point3D point3D = value.Location;
				double num = value.Radius;
				value.Box = new EyeshotBoundingBoxDataLight(point3D.X - num, point3D.X + num, point3D.Y - num, point3D.Y + num);
				list[i] = value;
			}
			for (int j = 0; j < list.Count; j++)
			{
				IrregularSectionValidator.BarDistanceMetadata barDistanceMetadata = list[j];
				Point3D a = barDistanceMetadata.Location;
				EyeshotBoundingBoxDataLight eyeshotBoundingBoxDataLight = barDistanceMetadata.Box;
				for (int k = j + 1; k < list.Count; k++)
				{
					IrregularSectionValidator.BarDistanceMetadata barDistanceMetadata2 = list[k];
					if (eyeshotBoundingBoxDataLight.Overlaps(barDistanceMetadata2.Box))
					{
						double num2 = barDistanceMetadata.Radius + barDistanceMetadata2.Radius;
						double num3 = num2 * num2;
						if (Point3D.DistanceSquared(a, barDistanceMetadata2.Location) < num3)
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		// Token: 0x06008D79 RID: 36217 RVA: 0x001E1EF4 File Offset: 0x001E00F4
		private bool #Mbe(#ice #ib, ColumnStorageModel #Od)
		{
			IrregularSectionValidator.#wbc #wbc = new IrregularSectionValidator.#wbc();
			#wbc.#a = #ib;
			#wbc.#b = #Od;
			return #wbc.#b.Polygons.All(new Func<SectionPolygon, bool>(#wbc.#P9e));
		}

		// Token: 0x02000FF9 RID: 4089
		private struct BarDistanceMetadata
		{
			// Token: 0x1700293D RID: 10557
			// (get) Token: 0x06008D7A RID: 36218 RVA: 0x00072D09 File Offset: 0x00070F09
			// (set) Token: 0x06008D7B RID: 36219 RVA: 0x00072D11 File Offset: 0x00070F11
			public Point3D Location { readonly get; set; }

			// Token: 0x1700293E RID: 10558
			// (get) Token: 0x06008D7C RID: 36220 RVA: 0x00072D1A File Offset: 0x00070F1A
			// (set) Token: 0x06008D7D RID: 36221 RVA: 0x00072D22 File Offset: 0x00070F22
			public double Radius { readonly get; set; }

			// Token: 0x1700293F RID: 10559
			// (get) Token: 0x06008D7E RID: 36222 RVA: 0x00072D2B File Offset: 0x00070F2B
			// (set) Token: 0x06008D7F RID: 36223 RVA: 0x00072D33 File Offset: 0x00070F33
			public EyeshotBoundingBoxDataLight Box { readonly get; set; }

			// Token: 0x04003AC3 RID: 15043
			[CompilerGenerated]
			private Point3D #a;

			// Token: 0x04003AC4 RID: 15044
			[CompilerGenerated]
			private double #b;

			// Token: 0x04003AC5 RID: 15045
			[CompilerGenerated]
			private EyeshotBoundingBoxDataLight #c;
		}

		// Token: 0x02000FFA RID: 4090
		private sealed class SectionFigure
		{
			// Token: 0x06008D80 RID: 36224 RVA: 0x001E1F34 File Offset: 0x001E0134
			public SectionFigure(SectionPolygon polygon)
			{
				this.Polygon = polygon;
				Coordinate[] points = polygon.Points.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Point, Coordinate>(IrregularSectionValidator.SectionFigure.<>c.<>9.#22b)).ToArray<Coordinate>();
				this.Geometry = new Polygon(new LinearRing(points));
			}

			// Token: 0x17002940 RID: 10560
			// (get) Token: 0x06008D81 RID: 36225 RVA: 0x00072D3C File Offset: 0x00070F3C
			public SectionPolygon Polygon { get; }

			// Token: 0x17002941 RID: 10561
			// (get) Token: 0x06008D82 RID: 36226 RVA: 0x00072D44 File Offset: 0x00070F44
			public bool IsSolid
			{
				get
				{
					return this.Polygon.Application == PolygonApplication.Solid;
				}
			}

			// Token: 0x17002942 RID: 10562
			// (get) Token: 0x06008D83 RID: 36227 RVA: 0x00072D54 File Offset: 0x00070F54
			public Geometry Geometry { get; }

			// Token: 0x04003AC6 RID: 15046
			[CompilerGenerated]
			private readonly SectionPolygon #a;

			// Token: 0x04003AC7 RID: 15047
			[CompilerGenerated]
			private readonly Geometry #b;
		}

		// Token: 0x02000FFC RID: 4092
		private sealed class FiguresValidator : AbstractValidator<List<IrregularSectionValidator.SectionFigure>>
		{
			// Token: 0x06008D87 RID: 36231 RVA: 0x001E1F90 File Offset: 0x001E0190
			public FiguresValidator()
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(List<IrregularSectionValidator.SectionFigure>), #Phc.#3hc(107398878));
				base.RuleFor<List<IrregularSectionValidator.SectionFigure>>(Expression.Lambda<Func<List<IrregularSectionValidator.SectionFigure>, List<IrregularSectionValidator.SectionFigure>>>(parameterExpression, new ParameterExpression[]
				{
					parameterExpression
				})).Must(new Func<List<IrregularSectionValidator.SectionFigure>, bool>(this.#J9e)).WithMessage(#Phc.#3hc(107310067).#z2d()).#Vce(new #xce(#Nce.#M, #Oce.#Fb));
				parameterExpression = Expression.Parameter(typeof(List<IrregularSectionValidator.SectionFigure>), #Phc.#3hc(107398878));
				base.RuleFor<List<IrregularSectionValidator.SectionFigure>>(Expression.Lambda<Func<List<IrregularSectionValidator.SectionFigure>, List<IrregularSectionValidator.SectionFigure>>>(parameterExpression, new ParameterExpression[]
				{
					parameterExpression
				})).Must(new Func<List<IrregularSectionValidator.SectionFigure>, bool>(this.#I9e)).WithMessage(#Phc.#3hc(107310006).#z2d()).#Vce(new #xce(#Nce.#M, #Oce.#Gb));
				parameterExpression = Expression.Parameter(typeof(List<IrregularSectionValidator.SectionFigure>), #Phc.#3hc(107398878));
				base.RuleFor<List<IrregularSectionValidator.SectionFigure>>(Expression.Lambda<Func<List<IrregularSectionValidator.SectionFigure>, List<IrregularSectionValidator.SectionFigure>>>(parameterExpression, new ParameterExpression[]
				{
					parameterExpression
				})).Must(new Func<List<IrregularSectionValidator.SectionFigure>, bool>(this.#K9e)).WithMessage(#Phc.#3hc(107309937)).#Vce(new #xce(#Nce.#M, #Oce.#Hb));
			}

			// Token: 0x06008D88 RID: 36232 RVA: 0x001E20DC File Offset: 0x001E02DC
			private bool #I9e(IList<IrregularSectionValidator.SectionFigure> #5Se)
			{
				List<IrregularSectionValidator.SectionFigure> #5Se2 = #5Se.Where(new Func<IrregularSectionValidator.SectionFigure, bool>(IrregularSectionValidator.FiguresValidator.<>c.<>9.#Xif)).ToList<IrregularSectionValidator.SectionFigure>();
				return !this.#L9e(#5Se2);
			}

			// Token: 0x06008D89 RID: 36233 RVA: 0x001E2120 File Offset: 0x001E0320
			private bool #J9e(IList<IrregularSectionValidator.SectionFigure> #5Se)
			{
				List<IrregularSectionValidator.SectionFigure> #5Se2 = #5Se.Where(new Func<IrregularSectionValidator.SectionFigure, bool>(IrregularSectionValidator.FiguresValidator.<>c.<>9.#Yif)).ToList<IrregularSectionValidator.SectionFigure>();
				return !this.#L9e(#5Se2);
			}

			// Token: 0x06008D8A RID: 36234 RVA: 0x001E2164 File Offset: 0x001E0364
			private bool #K9e(IList<IrregularSectionValidator.SectionFigure> #5Se)
			{
				List<IrregularSectionValidator.SectionFigure> list = #5Se.Where(new Func<IrregularSectionValidator.SectionFigure, bool>(IrregularSectionValidator.FiguresValidator.<>c.<>9.#Zif)).ToList<IrregularSectionValidator.SectionFigure>();
				List<IrregularSectionValidator.SectionFigure> list2 = #5Se.Where(new Func<IrregularSectionValidator.SectionFigure, bool>(IrregularSectionValidator.FiguresValidator.<>c.<>9.#0if)).ToList<IrregularSectionValidator.SectionFigure>();
				foreach (IrregularSectionValidator.SectionFigure sectionFigure in list)
				{
					int num = 0;
					foreach (IrregularSectionValidator.SectionFigure sectionFigure2 in list2)
					{
						Geometry g = sectionFigure.Geometry;
						Geometry geometry = sectionFigure2.Geometry;
						ColumnGeometryHelper.#DKe(ref geometry, ref g);
						if (geometry.Contains(g))
						{
							num++;
						}
						if (num > 1)
						{
							break;
						}
					}
					if (num != 1)
					{
						return false;
					}
				}
				return true;
			}

			// Token: 0x06008D8B RID: 36235 RVA: 0x001E2274 File Offset: 0x001E0474
			private bool #L9e(IList<IrregularSectionValidator.SectionFigure> #5Se)
			{
				for (int i = 0; i < #5Se.Count; i++)
				{
					IrregularSectionValidator.SectionFigure sectionFigure = #5Se[i];
					for (int j = i + 1; j < #5Se.Count; j++)
					{
						IrregularSectionValidator.SectionFigure sectionFigure2 = #5Se[j];
						Geometry geometry = sectionFigure.Geometry.Intersection(sectionFigure2.Geometry);
						if (!geometry.IsEmpty && geometry.Area > this.#a)
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x04003ACA RID: 15050
			private readonly double #a = 0.001;
		}

		// Token: 0x02000FFF RID: 4095
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06008D9B RID: 36251 RVA: 0x00072E00 File Offset: 0x00071000
			internal SectionPolygonValidator #P7b(ColumnStorageModel #Rf, SectionPolygon #f)
			{
				return new SectionPolygonValidator(this.#a, #Rf.Polygons.IndexOf(#f));
			}

			// Token: 0x06008D9C RID: 36252 RVA: 0x00072E19 File Offset: 0x00071019
			internal bool #M9e(ColumnStorageModel #Od)
			{
				return this.#b.#Mbe(this.#a, #Od);
			}

			// Token: 0x04003AD7 RID: 15063
			public #ice #a;

			// Token: 0x04003AD8 RID: 15064
			public IrregularSectionValidator #b;
		}

		// Token: 0x02001000 RID: 4096
		[CompilerGenerated]
		private sealed class #wbc
		{
			// Token: 0x06008D9E RID: 36254 RVA: 0x00072E2D File Offset: 0x0007102D
			internal bool #P9e(SectionPolygon #JP)
			{
				return new SectionPolygonValidator(this.#a, this.#b.Polygons.IndexOf(#JP)).Validate(#JP).IsValid;
			}

			// Token: 0x04003AD9 RID: 15065
			public #ice #a;

			// Token: 0x04003ADA RID: 15066
			public ColumnStorageModel #b;
		}
	}
}
