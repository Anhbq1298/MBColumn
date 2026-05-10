using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using #7hc;
using #UYd;
using HelixToolkit.Wpf;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A26 RID: 2598
	public sealed class PointsDrawingResult : DrawingResultBase, IDrawingResult, IPointsDrawingResult
	{
		// Token: 0x060055FB RID: 22011 RVA: 0x00047280 File Offset: 0x00045480
		public PointsDrawingResult()
		{
			this.PointsVisual = new PointsVisual3D();
		}

		// Token: 0x170018C2 RID: 6338
		// (get) Token: 0x060055FC RID: 22012 RVA: 0x00047293 File Offset: 0x00045493
		// (set) Token: 0x060055FD RID: 22013 RVA: 0x0004729F File Offset: 0x0004549F
		internal PointsVisual3D PointsVisual { get; private set; }

		// Token: 0x170018C3 RID: 6339
		// (get) Token: 0x060055FE RID: 22014 RVA: 0x000472B0 File Offset: 0x000454B0
		// (set) Token: 0x060055FF RID: 22015 RVA: 0x000472BC File Offset: 0x000454BC
		public IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> Points
		{
			get
			{
				return this.points;
			}
			set
			{
				if (this.PointsVisual != null)
				{
					this.points = value;
					this.MyUpdateMesh();
				}
			}
		}

		// Token: 0x170018C4 RID: 6340
		// (get) Token: 0x06005600 RID: 22016 RVA: 0x000472DF File Offset: 0x000454DF
		// (set) Token: 0x06005601 RID: 22017 RVA: 0x000472EB File Offset: 0x000454EB
		public double PointSize
		{
			get
			{
				return this.pointSize;
			}
			set
			{
				if (this.pointSize != value)
				{
					this.PointsVisual.Size = value;
					this.pointSize = value;
					this.MyUpdateMesh();
				}
			}
		}

		// Token: 0x170018C5 RID: 6341
		// (get) Token: 0x06005602 RID: 22018 RVA: 0x0004731B File Offset: 0x0004551B
		// (set) Token: 0x06005603 RID: 22019 RVA: 0x00047327 File Offset: 0x00045527
		public Color PointColor
		{
			get
			{
				return this.pointColor;
			}
			set
			{
				if (this.pointColor != value)
				{
					if (this.PointsVisual != null)
					{
						this.PointsVisual.Color = value;
					}
					this.pointColor = value;
				}
			}
		}

		// Token: 0x06005604 RID: 22020 RVA: 0x0004735E File Offset: 0x0004555E
		public void ChangeVisibility(IModelEditorControl modelEditorControl, Visibility visibility)
		{
			#X0d.#V0d(modelEditorControl, #Phc.#3hc(107359181), Component.DesktopControls, #Phc.#3hc(107462924));
			if (visibility == Visibility.Visible)
			{
				modelEditorControl.RemoveFromView(this);
				return;
			}
			modelEditorControl.AddToView(this);
		}

		// Token: 0x06005605 RID: 22021 RVA: 0x001656A0 File Offset: 0x001638A0
		private void MyUpdateMesh()
		{
			IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> enumerable = this.points;
			if (enumerable == null)
			{
				return;
			}
			this.PointsVisual.Points = enumerable.Convert().ToList<System.Windows.Media.Media3D.Point3D>();
		}

		// Token: 0x06005606 RID: 22022 RVA: 0x00047399 File Offset: 0x00045599
		protected internal override object RetrieveDisplayedObject()
		{
			return this.PointsVisual;
		}

		// Token: 0x0400246C RID: 9324
		private IEnumerable<StructurePoint.CoreAssets.Infrastructure.Data.Point3D> points;

		// Token: 0x0400246D RID: 9325
		private double pointSize;

		// Token: 0x0400246E RID: 9326
		private Color pointColor;
	}
}
