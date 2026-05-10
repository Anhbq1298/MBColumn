using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using #u3d;
using Ab3d.Visuals;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A07 RID: 2567
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Multi")]
	public sealed class MultiPolyLineDrawingResult : DrawingResultBase, IDrawingResult, IMultiPolyLineDrawingResult
	{
		// Token: 0x06005492 RID: 21650 RVA: 0x000460E8 File Offset: 0x000442E8
		public MultiPolyLineDrawingResult()
		{
			this.MultiPolyLineVisual = new MultiPolyLineVisual3D();
		}

		// Token: 0x1700184E RID: 6222
		// (get) Token: 0x06005493 RID: 21651 RVA: 0x00046106 File Offset: 0x00044306
		// (set) Token: 0x06005494 RID: 21652 RVA: 0x00046112 File Offset: 0x00044312
		internal MultiPolyLineVisual3D MultiPolyLineVisual { get; private set; }

		// Token: 0x1700184F RID: 6223
		// (get) Token: 0x06005495 RID: 21653 RVA: 0x00046123 File Offset: 0x00044323
		// (set) Token: 0x06005496 RID: 21654 RVA: 0x0016497C File Offset: 0x00162B7C
		public IEnumerable<List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>> Positions
		{
			get
			{
				return this.positions;
			}
			set
			{
				if (this.positions != value)
				{
					this.positions = value;
					MultiPolyLineVisual3D multiPolyLineVisual = this.MultiPolyLineVisual;
					List<Point3DCollection> positionsList;
					if (value != null)
					{
						positionsList = (from item in value
						select new Point3DCollection(item.Convert())).ToList<Point3DCollection>();
					}
					else
					{
						positionsList = new List<Point3DCollection>();
					}
					multiPolyLineVisual.PositionsList = positionsList;
				}
			}
		}

		// Token: 0x17001850 RID: 6224
		// (get) Token: 0x06005497 RID: 21655 RVA: 0x0004612F File Offset: 0x0004432F
		// (set) Token: 0x06005498 RID: 21656 RVA: 0x00046148 File Offset: 0x00044348
		public Color LineColor
		{
			get
			{
				return this.MultiPolyLineVisual.LineColor;
			}
			set
			{
				if (this.MultiPolyLineVisual.LineColor != value)
				{
					this.MultiPolyLineVisual.LineColor = value;
				}
			}
		}

		// Token: 0x17001851 RID: 6225
		// (get) Token: 0x06005499 RID: 21657 RVA: 0x00046175 File Offset: 0x00044375
		// (set) Token: 0x0600549A RID: 21658 RVA: 0x0004618E File Offset: 0x0004438E
		public bool IsClosed
		{
			get
			{
				return this.MultiPolyLineVisual.IsClosed;
			}
			set
			{
				this.MultiPolyLineVisual.IsClosed = value;
			}
		}

		// Token: 0x17001852 RID: 6226
		// (get) Token: 0x0600549B RID: 21659 RVA: 0x000461A8 File Offset: 0x000443A8
		// (set) Token: 0x0600549C RID: 21660 RVA: 0x000461C1 File Offset: 0x000443C1
		public double LineThickness
		{
			get
			{
				return this.MultiPolyLineVisual.LineThickness;
			}
			set
			{
				if (this.MultiPolyLineVisual.LineThickness != value)
				{
					this.MultiPolyLineVisual.LineThickness = value;
				}
			}
		}

		// Token: 0x0600549D RID: 21661 RVA: 0x001649E4 File Offset: 0x00162BE4
		public void SetTransforms(#c4d? translateVector, #c4d? scaleVector)
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
			this.MultiPolyLineVisual.Transform = transform3DGroup;
		}

		// Token: 0x0600549E RID: 21662 RVA: 0x00164A6C File Offset: 0x00162C6C
		public void RecreateVisual()
		{
			MultiPolyLineVisual3D multiPolyLineVisual3D = new MultiPolyLineVisual3D();
			MultiPolyLineVisual3D multiPolyLineVisual3D2;
			if (2 != 0)
			{
				multiPolyLineVisual3D2 = multiPolyLineVisual3D;
			}
			multiPolyLineVisual3D2.BeginInit();
			multiPolyLineVisual3D2.IsClosed = this.MultiPolyLineVisual.IsClosed;
			multiPolyLineVisual3D2.PositionsList = this.MultiPolyLineVisual.PositionsList;
			multiPolyLineVisual3D2.LineColor = this.MultiPolyLineVisual.LineColor;
			multiPolyLineVisual3D2.Transform = this.MultiPolyLineVisual.Transform;
			multiPolyLineVisual3D2.LineThickness = this.MultiPolyLineVisual.LineThickness;
			multiPolyLineVisual3D2.EndInit();
			this.MultiPolyLineVisual = multiPolyLineVisual3D2;
		}

		// Token: 0x0600549F RID: 21663 RVA: 0x000461E9 File Offset: 0x000443E9
		protected internal override object RetrieveDisplayedObject()
		{
			return this.MultiPolyLineVisual;
		}

		// Token: 0x04002441 RID: 9281
		private IEnumerable<List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>> positions = new List<List<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>>();
	}
}
