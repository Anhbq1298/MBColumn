using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Media;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Visualization2D
{
	// Token: 0x020008C6 RID: 2246
	public sealed class ArrowPolyline : ArrowLineBase
	{
		// Token: 0x06004723 RID: 18211 RVA: 0x0003BE40 File Offset: 0x0003A040
		public ArrowPolyline()
		{
			this.Points = new PointCollection();
		}

		// Token: 0x170014E6 RID: 5350
		// (get) Token: 0x06004724 RID: 18212 RVA: 0x0003BE53 File Offset: 0x0003A053
		// (set) Token: 0x06004725 RID: 18213 RVA: 0x0003BE6D File Offset: 0x0003A06D
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public PointCollection Points
		{
			get
			{
				return (PointCollection)base.GetValue(ArrowPolyline.PointsProperty);
			}
			set
			{
				base.SetValue(ArrowPolyline.PointsProperty, value);
			}
		}

		// Token: 0x170014E7 RID: 5351
		// (get) Token: 0x06004726 RID: 18214 RVA: 0x001409A8 File Offset: 0x0013EBA8
		protected override Geometry DefiningGeometry
		{
			get
			{
				base.PathGeometry.Figures.Clear();
				if (this.Points.Count > 0)
				{
					base.PathFigure.StartPoint = this.Points[0];
					base.PolyLineSegment.Points.Clear();
					for (int i = 1; i < this.Points.Count; i++)
					{
						base.PolyLineSegment.Points.Add(this.Points[i]);
					}
					base.PathGeometry.Figures.Add(base.PathFigure);
				}
				return base.DefiningGeometry;
			}
		}

		// Token: 0x04002041 RID: 8257
		public static readonly DependencyProperty PointsProperty = DependencyProperty.Register(#Phc.#3hc(107453385), typeof(PointCollection), typeof(ArrowPolyline), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure));
	}
}
