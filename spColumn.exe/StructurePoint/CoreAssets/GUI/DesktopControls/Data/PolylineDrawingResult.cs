using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using #u3d;
using Ab3d.Visuals;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A27 RID: 2599
	public sealed class PolylineDrawingResult : LinesDrawingResultBase, IEditableObject, IDrawingResult, ILinesDrawingResultBase, IPolylineDrawingResult
	{
		// Token: 0x06005607 RID: 22023 RVA: 0x000473A9 File Offset: 0x000455A9
		public PolylineDrawingResult()
		{
			this.PolyLineVisual = new PolyLineVisual3D();
			base.Visibility = Visibility.Visible;
		}

		// Token: 0x170018C6 RID: 6342
		// (get) Token: 0x06005608 RID: 22024 RVA: 0x000473C3 File Offset: 0x000455C3
		// (set) Token: 0x06005609 RID: 22025 RVA: 0x000473CF File Offset: 0x000455CF
		internal PolyLineVisual3D PolyLineVisual { get; private set; }

		// Token: 0x170018C7 RID: 6343
		// (get) Token: 0x0600560A RID: 22026 RVA: 0x000473E0 File Offset: 0x000455E0
		// (set) Token: 0x0600560B RID: 22027 RVA: 0x000473F9 File Offset: 0x000455F9
		public bool IsClosed
		{
			get
			{
				return this.PolyLineVisual.IsClosed;
			}
			set
			{
				this.PolyLineVisual.IsClosed = value;
			}
		}

		// Token: 0x170018C8 RID: 6344
		// (get) Token: 0x0600560C RID: 22028 RVA: 0x00047413 File Offset: 0x00045613
		// (set) Token: 0x0600560D RID: 22029 RVA: 0x0004742C File Offset: 0x0004562C
		public bool IsVisible
		{
			get
			{
				return this.PolyLineVisual.IsVisible;
			}
			set
			{
				this.PolyLineVisual.IsVisible = value;
			}
		}

		// Token: 0x0600560E RID: 22030 RVA: 0x001656DC File Offset: 0x001638DC
		public void RecreateVisual()
		{
			this.PolyLineVisual = new PolyLineVisual3D
			{
				IsVisible = this.PolyLineVisual.IsVisible,
				LineColor = this.PolyLineVisual.LineColor,
				LineThickness = this.PolyLineVisual.LineThickness,
				Positions = this.PolyLineVisual.Positions,
				IsClosed = this.PolyLineVisual.IsClosed,
				Transform = this.PolyLineVisual.Transform
			};
		}

		// Token: 0x0600560F RID: 22031 RVA: 0x00165774 File Offset: 0x00163974
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
			this.PolyLineVisual.Transform = transform3DGroup;
		}

		// Token: 0x06005610 RID: 22032 RVA: 0x00047446 File Offset: 0x00045646
		protected override void OnVisibilityChanged(Visibility newVisibility)
		{
			this.PolyLineVisual.IsVisible = (newVisibility == Visibility.Visible);
		}

		// Token: 0x06005611 RID: 22033 RVA: 0x00047463 File Offset: 0x00045663
		protected override void OnPositionsChanged(IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> newPositions)
		{
			this.PolyLineVisual.Positions = ((newPositions == null) ? null : new Point3DCollection(newPositions.Convert()));
		}

		// Token: 0x06005612 RID: 22034 RVA: 0x0004748D File Offset: 0x0004568D
		protected override void OnLineColorChanged(Color newLineColor)
		{
			this.PolyLineVisual.LineColor = newLineColor;
		}

		// Token: 0x06005613 RID: 22035 RVA: 0x000474A7 File Offset: 0x000456A7
		protected override void OnLineThicknessChanged(double newThickness)
		{
			this.PolyLineVisual.LineThickness = newThickness;
		}

		// Token: 0x06005614 RID: 22036 RVA: 0x000474C1 File Offset: 0x000456C1
		public void BeginEdit()
		{
			this.PolyLineVisual.BeginInit();
		}

		// Token: 0x06005615 RID: 22037 RVA: 0x000474DA File Offset: 0x000456DA
		public void EndEdit()
		{
			this.PolyLineVisual.EndInit();
		}

		// Token: 0x06005616 RID: 22038 RVA: 0x00009E6A File Offset: 0x0000806A
		public void CancelEdit()
		{
		}

		// Token: 0x06005617 RID: 22039 RVA: 0x000474F3 File Offset: 0x000456F3
		protected internal override object RetrieveDisplayedObject()
		{
			return this.PolyLineVisual;
		}
	}
}
