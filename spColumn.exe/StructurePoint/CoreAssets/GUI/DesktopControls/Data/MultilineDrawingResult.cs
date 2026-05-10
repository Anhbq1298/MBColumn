using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using #u3d;
using Ab3d.Visuals;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A25 RID: 2597
	[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
	public sealed class MultilineDrawingResult : LinesDrawingResultBase, IDrawingResult, ILinesDrawingResultBase, IMultilineDrawingResult
	{
		// Token: 0x060055F1 RID: 22001 RVA: 0x000471BE File Offset: 0x000453BE
		public MultilineDrawingResult()
		{
			this.MultiLineVisual = new MultiLineVisual3D();
			base.Visibility = Visibility.Visible;
		}

		// Token: 0x170018C1 RID: 6337
		// (get) Token: 0x060055F2 RID: 22002 RVA: 0x000471D8 File Offset: 0x000453D8
		// (set) Token: 0x060055F3 RID: 22003 RVA: 0x000471E4 File Offset: 0x000453E4
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
		internal MultiLineVisual3D MultiLineVisual { get; private set; }

		// Token: 0x060055F4 RID: 22004 RVA: 0x001655AC File Offset: 0x001637AC
		public void RecreateVisual()
		{
			this.MultiLineVisual = new MultiLineVisual3D
			{
				IsVisible = this.MultiLineVisual.IsVisible,
				LineColor = this.MultiLineVisual.LineColor,
				LineThickness = this.MultiLineVisual.LineThickness,
				Positions = this.MultiLineVisual.Positions
			};
		}

		// Token: 0x060055F5 RID: 22005 RVA: 0x000471F5 File Offset: 0x000453F5
		protected override void OnVisibilityChanged(Visibility newVisibility)
		{
			this.MultiLineVisual.IsVisible = (newVisibility == Visibility.Visible);
		}

		// Token: 0x060055F6 RID: 22006 RVA: 0x00047212 File Offset: 0x00045412
		protected override void OnPositionsChanged(IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> newPositions)
		{
			this.MultiLineVisual.Positions = ((newPositions == null) ? null : new Point3DCollection(newPositions.Convert()));
		}

		// Token: 0x060055F7 RID: 22007 RVA: 0x0004723C File Offset: 0x0004543C
		protected override void OnLineColorChanged(Color newLineColor)
		{
			this.MultiLineVisual.LineColor = newLineColor;
		}

		// Token: 0x060055F8 RID: 22008 RVA: 0x00047256 File Offset: 0x00045456
		protected override void OnLineThicknessChanged(double newThickness)
		{
			this.MultiLineVisual.LineThickness = newThickness;
		}

		// Token: 0x060055F9 RID: 22009 RVA: 0x00165618 File Offset: 0x00163818
		public override void SetTransforms(#c4d? translateVector, #c4d? scaleVector)
		{
			if (translateVector == null && scaleVector == null)
			{
				return;
			}
			Transform3DGroup transform3DGroup = new Transform3DGroup();
			if (translateVector != null)
			{
				transform3DGroup.Children.Add(new TranslateTransform3D(translateVector.Value.Convert()));
			}
			if (scaleVector != null)
			{
				transform3DGroup.Children.Add(new ScaleTransform3D(scaleVector.Value.Convert()));
			}
			this.MultiLineVisual.Transform = transform3DGroup;
		}

		// Token: 0x060055FA RID: 22010 RVA: 0x00047270 File Offset: 0x00045470
		protected internal override object RetrieveDisplayedObject()
		{
			return this.MultiLineVisual;
		}
	}
}
