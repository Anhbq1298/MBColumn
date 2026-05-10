using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Visualization2D
{
	// Token: 0x020008D5 RID: 2261
	public sealed class Visualization2DControl : UserControl, IComponentConnector, IVisualization2DControl
	{
		// Token: 0x0600479F RID: 18335 RVA: 0x0003C6D2 File Offset: 0x0003A8D2
		public Visualization2DControl()
		{
			this.InitializeComponent();
			this.Root.Children.Add(this.shapesHost);
		}

		// Token: 0x170014FA RID: 5370
		// (get) Token: 0x060047A0 RID: 18336 RVA: 0x0003C702 File Offset: 0x0003A902
		// (set) Token: 0x060047A1 RID: 18337 RVA: 0x0003C71C File Offset: 0x0003A91C
		public string LabelText
		{
			get
			{
				return (string)base.GetValue(Visualization2DControl.LabelTextProperty);
			}
			set
			{
				base.SetValue(Visualization2DControl.LabelTextProperty, value);
			}
		}

		// Token: 0x060047A2 RID: 18338 RVA: 0x0003C736 File Offset: 0x0003A936
		public void Clear()
		{
			this.shapesHost.Visuals.Clear();
		}

		// Token: 0x060047A3 RID: 18339 RVA: 0x00141E58 File Offset: 0x00140058
		public void Draw(IEnumerable<PolygonsDrawingData> polygons, StructurePoint.CoreAssets.Infrastructure.Data.Rect modelBounds)
		{
			#X0d.#V0d(polygons, #Phc.#3hc(107372425), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls, #Phc.#3hc(107451992));
			StructurePoint.CoreAssets.Infrastructure.Data.Size targetSize = new StructurePoint.CoreAssets.Infrastructure.Data.Size(this.DrawingsContainer.ActualWidth * 0.9, this.DrawingsContainer.ActualHeight * 0.9);
			ShapeDrawingVisual shapeDrawingVisual = this.MyCreateDrawingVisual();
			BoundingBoxData boundingBox = new BoundingBoxData(modelBounds);
			double scale = TransformationHelper.CalculateViewScale(targetSize, boundingBox);
			StructurePoint.CoreAssets.Infrastructure.Data.Vector translationVector = TransformationHelper.CalculateModelCenterVector(boundingBox);
			foreach (PolygonsDrawingData polygonsDrawingData in polygons.Where(delegate(PolygonsDrawingData item)
			{
				Color? outerSurfacesFillColor = item.OuterSurfacesFillColor;
				return outerSurfacesFillColor != null;
			}))
			{
				IEnumerable<PolygonDrawingData> polygons2 = polygonsDrawingData.Polygons;
				Func<PolygonDrawingData, IList<StructurePoint.CoreAssets.Infrastructure.Data.Point>> selector;
				if ((selector = Visualization2DControl.<>O.<0>__MyGetPoints) == null)
				{
					selector = (Visualization2DControl.<>O.<0>__MyGetPoints = new Func<PolygonDrawingData, IList<StructurePoint.CoreAssets.Infrastructure.Data.Point>>(Visualization2DControl.MyGetPoints));
				}
				List<IList<System.Windows.Point>> polygonPoints = (from item in TransformationHelper.TransformToScreenCoordinates(TransformationHelper.Translate(TransformationHelper.TranslateAndScale(polygons2.Select(selector).ToList<IList<StructurePoint.CoreAssets.Infrastructure.Data.Point>>(), scale, translationVector), new StructurePoint.CoreAssets.Infrastructure.Data.Vector((targetSize.Width - targetSize.Width * 0.9) * 0.5, -0.5 * (targetSize.Height - targetSize.Height * 0.9))), targetSize)
				select (from p in item
				select p.Convert()).ToList<System.Windows.Point>()).ToList<IList<System.Windows.Point>>();
				if (polygonsDrawingData.OuterSurfacesFillColor != null)
				{
					SolidColorBrush fill = new SolidColorBrush(polygonsDrawingData.OuterSurfacesFillColor.Value);
					SolidColorBrush borderBrush = (polygonsDrawingData.OuterLinesFormat != null) ? new SolidColorBrush(polygonsDrawingData.OuterLinesFormat.Color) : null;
					double borderThickness = (polygonsDrawingData.OuterLinesFormat != null) ? polygonsDrawingData.OuterLinesFormat.Thickness : 0.0;
					shapeDrawingVisual.RenderPolygon(polygonPoints, borderBrush, borderThickness, fill);
				}
			}
		}

		// Token: 0x060047A4 RID: 18340 RVA: 0x0014208C File Offset: 0x0014028C
		public void Draw(IList<CircleData> circles, StructurePoint.CoreAssets.Infrastructure.Data.Rect modelBounds, Brush fill)
		{
			#X0d.#V0d(circles, #Phc.#3hc(107451907), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls, #Phc.#3hc(107451926));
			#X0d.#V0d(fill, #Phc.#3hc(107452353), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls, #Phc.#3hc(107452376));
			StructurePoint.CoreAssets.Infrastructure.Data.Size targetSize = new StructurePoint.CoreAssets.Infrastructure.Data.Size(this.DrawingsContainer.ActualWidth * 0.9, this.DrawingsContainer.ActualHeight * 0.9);
			ShapeDrawingVisual shapeDrawingVisual = this.MyCreateDrawingVisual();
			BoundingBoxData boundingBox = new BoundingBoxData(modelBounds);
			double num = TransformationHelper.CalculateViewScale(targetSize, boundingBox);
			StructurePoint.CoreAssets.Infrastructure.Data.Vector translationVector = TransformationHelper.CalculateModelCenterVector(boundingBox);
			List<CircleData> list = new List<CircleData>();
			foreach (IGrouping<double, CircleData> grouping in from item in circles
			group item by item.Radius)
			{
				IList<StructurePoint.CoreAssets.Infrastructure.Data.Point> list2 = TransformationHelper.TranslateAndScale(grouping.Select((CircleData item) => item.Center).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>(), num, translationVector);
				list2 = TransformationHelper.Translate(list2, new StructurePoint.CoreAssets.Infrastructure.Data.Vector((targetSize.Width - targetSize.Width * 0.9) * 0.5, -0.5 * (targetSize.Height - targetSize.Height * 0.9)));
				list2 = TransformationHelper.TransformToScreenCoordinates(list2, targetSize);
				double radius = grouping.Key * num;
				list.AddRange(list2.Select((StructurePoint.CoreAssets.Infrastructure.Data.Point item) => new CircleData(item, radius)));
			}
			shapeDrawingVisual.RenderCircles(list, fill);
		}

		// Token: 0x060047A5 RID: 18341 RVA: 0x00142278 File Offset: 0x00140478
		private static IList<StructurePoint.CoreAssets.Infrastructure.Data.Point> MyGetPoints(PolygonDrawingData drawingData)
		{
			List<StructurePoint.CoreAssets.Infrastructure.Data.Point> list = drawingData.Points.ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>();
			if (list.Count >= 2 && !PointsConverter.#uC(list.First<StructurePoint.CoreAssets.Infrastructure.Data.Point>(), list.Last<StructurePoint.CoreAssets.Infrastructure.Data.Point>()))
			{
				list.Add(list.First<StructurePoint.CoreAssets.Infrastructure.Data.Point>());
			}
			return list;
		}

		// Token: 0x060047A6 RID: 18342 RVA: 0x001422C8 File Offset: 0x001404C8
		private ShapeDrawingVisual MyCreateDrawingVisual()
		{
			ShapeDrawingVisual shapeDrawingVisual = new ShapeDrawingVisual();
			this.shapesHost.Visuals.Add(shapeDrawingVisual);
			return shapeDrawingVisual;
		}

		// Token: 0x060047A7 RID: 18343 RVA: 0x001422FC File Offset: 0x001404FC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107452291), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060047A8 RID: 18344 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060047A9 RID: 18345 RVA: 0x0003C754 File Offset: 0x0003A954
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.Root = (Grid)target;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.DrawingsContainer = (DockPanel)target;
		}

		// Token: 0x0400206C RID: 8300
		private readonly DrawingVisualHost shapesHost = new DrawingVisualHost();

		// Token: 0x0400206D RID: 8301
		public static readonly DependencyProperty LabelTextProperty = DependencyProperty.Register(#Phc.#3hc(107452206), typeof(string), typeof(Visualization2DControl), new PropertyMetadata(string.Empty));

		// Token: 0x0400206E RID: 8302
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal Grid Root;

		// Token: 0x0400206F RID: 8303
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal DockPanel DrawingsContainer;

		// Token: 0x04002070 RID: 8304
		private bool _contentLoaded;

		// Token: 0x020008D6 RID: 2262
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x04002071 RID: 8305
			public static Func<PolygonDrawingData, IList<StructurePoint.CoreAssets.Infrastructure.Data.Point>> <0>__MyGetPoints;
		}
	}
}
