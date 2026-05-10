using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using #3ve;
using #7hc;
using #EWc;
using #Vob;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Units.Formatters;

namespace StructurePoint.Products.Column.FailureSurface.Model
{
	// Token: 0x02000453 RID: 1107
	internal sealed class ModelStatisticsCalculator : NotifyPropertyChangedObjectBase, #Uob
	{
		// Token: 0x060028B9 RID: 10425 RVA: 0x000DC344 File Offset: 0x000DA544
		public ModelStatisticsCalculator()
		{
			this.#c = new #GWc
			{
				Name = Strings.StringDimensions.#u2d()
			};
			this.#d = new #GWc
			{
				Name = Strings.StringConcreteArea.#u2d()
			};
			this.#e = new #GWc
			{
				Name = Strings.StringReinfArea.#u2d()
			};
			this.#a = new CustomObservableCollection<#GWc>
			{
				this.#c,
				this.#d,
				this.#e
			};
		}

		// Token: 0x17000DB2 RID: 3506
		// (get) Token: 0x060028BA RID: 10426 RVA: 0x0002573C File Offset: 0x0002393C
		public IEnumerable<#DWc> Statistics
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x060028BB RID: 10427 RVA: 0x00025748 File Offset: 0x00023948
		public void #NQ(#lte #Wdb)
		{
			this.#1ob(#Wdb, #Wdb.FailureSurface);
			this.#3ob(#Wdb, #Wdb.FailureSurface);
			this.#4ob(#Wdb, #Wdb.FailureSurface);
		}

		// Token: 0x060028BC RID: 10428 RVA: 0x000DC3E4 File Offset: 0x000DA5E4
		private static BoundingBoxData #0ob(#lte #Wdb)
		{
			List<StructurePoint.CoreAssets.Infrastructure.Data.Point> list = #Wdb.Output.SectionPolygons.SelectMany(new Func<PolygonData, IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point>>(ModelStatisticsCalculator.<>c.<>9.#L6b)).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
			list.AddRange(#Wdb.Output.ReinforcementBars.Select(new Func<ReinforcementBar, StructurePoint.CoreAssets.Infrastructure.Data.Point>(ModelStatisticsCalculator.<>c.<>9.#M6b)));
			if (list.Count < 2)
			{
				return null;
			}
			return new BoundingBoxData(list);
		}

		// Token: 0x060028BD RID: 10429 RVA: 0x000DC488 File Offset: 0x000DA688
		private void #1ob(#lte #Wdb, #hwe #2ob)
		{
			BoundingBoxData boundingBoxData = ModelStatisticsCalculator.#0ob(#Wdb);
			string arg = this.#b.CreateDisplayValue(((boundingBoxData != null) ? boundingBoxData.Width : 0.0).ToString(CultureInfo.CurrentCulture));
			string arg2 = this.#b.CreateDisplayValue(((boundingBoxData != null) ? boundingBoxData.Height : 0.0).ToString(CultureInfo.CurrentCulture));
			string #f = string.Format(CultureInfo.CurrentCulture, #Phc.#3hc(107360216), arg, arg2, #2ob.GeometryDimensionUnitSymbol);
			this.#c.DisplayValue = #f;
		}

		// Token: 0x060028BE RID: 10430 RVA: 0x000DC540 File Offset: 0x000DA740
		private void #3ob(#lte #Wdb, #hwe #2ob)
		{
			ShapeData shapeData = #Wdb.Output.SectionPolygons.Any<PolygonData>() ? ShapeData.#6wc(#Wdb.Output.SectionPolygons) : null;
			double num = (shapeData != null) ? shapeData.Area : 0.0;
			string arg = this.#b.CreateDisplayValue(num.ToString(CultureInfo.CurrentCulture));
			string arg2 = #2ob.GeometryDimensionUnitSymbol.#U2d().#V2d().#S2d();
			this.#d.DisplayValue = string.Format(CultureInfo.CurrentCulture, #Phc.#3hc(107408730), arg, arg2);
		}

		// Token: 0x060028BF RID: 10431 RVA: 0x000DC5F8 File Offset: 0x000DA7F8
		private void #4ob(#lte #Wdb, #hwe #2ob)
		{
			double num;
			if (#Wdb.Output.ReinforcementBars.Any<ReinforcementBar>())
			{
				num = (double)#Wdb.Output.ReinforcementBars.Sum(new Func<ReinforcementBar, float>(ModelStatisticsCalculator.<>c.<>9.#N6b));
			}
			else
			{
				num = 0.0;
			}
			double num2 = num;
			string arg = this.#b.CreateDisplayValue(num2.ToString(CultureInfo.CurrentCulture));
			this.#e.DisplayValue = string.Format(CultureInfo.CurrentCulture, #Phc.#3hc(107408730), arg, HttpUtility.HtmlDecode(#2ob.ReinforcementAreaUnitSymbol));
		}

		// Token: 0x04001028 RID: 4136
		private readonly CustomObservableCollection<#GWc> #a;

		// Token: 0x04001029 RID: 4137
		private readonly IUnitValueFormatter #b = new FloatingPointUnitValueFormatter(3);

		// Token: 0x0400102A RID: 4138
		private readonly #GWc #c;

		// Token: 0x0400102B RID: 4139
		private readonly #GWc #d;

		// Token: 0x0400102C RID: 4140
		private readonly #GWc #e;
	}
}
