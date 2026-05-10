using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using #7hc;
using #UYd;
using HelixToolkit.Wpf;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A2C RID: 2604
	public sealed class PolygonsDrawingResult : DrawingResultBase, IDrawingResult, IPolygonsDrawingResult
	{
		// Token: 0x0600564D RID: 22093 RVA: 0x001659EC File Offset: 0x00163BEC
		public PolygonsDrawingResult()
		{
			this.linesVisibility = Visibility.Visible;
			this.surfacesVisibility = Visibility.Visible;
			this.OuterPolygonModelVisual3D = new MeshGeometryVisual3D();
			this.InnerPolygonModelVisual3D = new MeshGeometryVisual3D();
		}

		// Token: 0x0600564E RID: 22094 RVA: 0x000478B0 File Offset: 0x00045AB0
		public void ChangeSurfacesVisibility(Visibility visibility)
		{
			Console.WriteLine(visibility);
			Console.WriteLine(this.linesVisibility);
		}

		// Token: 0x0600564F RID: 22095 RVA: 0x000478B0 File Offset: 0x00045AB0
		public void ChangePointsVisibility(Visibility visibility)
		{
			Console.WriteLine(visibility);
			Console.WriteLine(this.linesVisibility);
		}

		// Token: 0x06005650 RID: 22096 RVA: 0x000478D9 File Offset: 0x00045AD9
		internal void ClearVisualModels()
		{
			this.innerEdges.Clear();
			this.outerEdges.Clear();
		}

		// Token: 0x170018DD RID: 6365
		// (get) Token: 0x06005651 RID: 22097 RVA: 0x000478FD File Offset: 0x00045AFD
		// (set) Token: 0x06005652 RID: 22098 RVA: 0x00047909 File Offset: 0x00045B09
		internal MeshGeometryVisual3D OuterPolygonModelVisual3D { get; private set; }

		// Token: 0x170018DE RID: 6366
		// (get) Token: 0x06005653 RID: 22099 RVA: 0x0004791A File Offset: 0x00045B1A
		// (set) Token: 0x06005654 RID: 22100 RVA: 0x00047926 File Offset: 0x00045B26
		internal MeshGeometryVisual3D InnerPolygonModelVisual3D { get; private set; }

		// Token: 0x170018DF RID: 6367
		// (get) Token: 0x06005655 RID: 22101 RVA: 0x00047937 File Offset: 0x00045B37
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public IEnumerable<IPolylineDrawingResult> OuterEdgesDrawingResults
		{
			get
			{
				return this.outerEdges;
			}
		}

		// Token: 0x170018E0 RID: 6368
		// (get) Token: 0x06005656 RID: 22102 RVA: 0x00047943 File Offset: 0x00045B43
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public IEnumerable<IPolylineDrawingResult> InnerEdgesDrawingResults
		{
			get
			{
				return this.innerEdges;
			}
		}

		// Token: 0x06005657 RID: 22103 RVA: 0x0004794F File Offset: 0x00045B4F
		public void AddOuterEdge(IPolylineDrawingResult polylineDrawingResult)
		{
			#X0d.#V0d(polylineDrawingResult, #Phc.#3hc(107429878), Component.DesktopControls, #Phc.#3hc(107429849));
			this.outerEdges.Add(polylineDrawingResult);
		}

		// Token: 0x06005658 RID: 22104 RVA: 0x00047984 File Offset: 0x00045B84
		public void RemoveOuterEdge(IPolylineDrawingResult polylineDrawingResult)
		{
			#X0d.#V0d(polylineDrawingResult, #Phc.#3hc(107429878), Component.DesktopControls, #Phc.#3hc(107429764));
			this.outerEdges.Remove(polylineDrawingResult);
		}

		// Token: 0x06005659 RID: 22105 RVA: 0x000479BA File Offset: 0x00045BBA
		public void AddInnerEdge(IPolylineDrawingResult polylineDrawingResult)
		{
			#X0d.#V0d(polylineDrawingResult, #Phc.#3hc(107429878), Component.DesktopControls, #Phc.#3hc(107429711));
			this.innerEdges.Add(polylineDrawingResult);
		}

		// Token: 0x0600565A RID: 22106 RVA: 0x000479EF File Offset: 0x00045BEF
		public void RemoveInnerEdge(IPolylineDrawingResult polylineDrawingResult)
		{
			#X0d.#V0d(polylineDrawingResult, #Phc.#3hc(107429878), Component.DesktopControls, #Phc.#3hc(107429690));
			this.innerEdges.Remove(polylineDrawingResult);
		}

		// Token: 0x170018E1 RID: 6369
		// (get) Token: 0x0600565B RID: 22107 RVA: 0x00047A25 File Offset: 0x00045C25
		// (set) Token: 0x0600565C RID: 22108 RVA: 0x00047A31 File Offset: 0x00045C31
		public IPointsDrawingResult PointsModelDrawingResult { get; set; }

		// Token: 0x170018E2 RID: 6370
		// (get) Token: 0x0600565D RID: 22109 RVA: 0x00047A42 File Offset: 0x00045C42
		// (set) Token: 0x0600565E RID: 22110 RVA: 0x00165A3C File Offset: 0x00163C3C
		public Color OuterSurfacesFillColor
		{
			get
			{
				return this.outerSurfacesFillColor;
			}
			set
			{
				if (this.outerSurfacesFillColor != value)
				{
					this.outerSurfacesFillColor = value;
					if (this.OuterPolygonModelVisual3D != null)
					{
						Material material = MaterialHelper.CreateMaterial(value);
						this.OuterPolygonModelVisual3D.Material = material;
						this.OuterPolygonModelVisual3D.BackMaterial = material;
					}
				}
			}
		}

		// Token: 0x170018E3 RID: 6371
		// (get) Token: 0x0600565F RID: 22111 RVA: 0x00047A4E File Offset: 0x00045C4E
		// (set) Token: 0x06005660 RID: 22112 RVA: 0x00165A94 File Offset: 0x00163C94
		public Color InnerSurfacesFillColor
		{
			get
			{
				return this.innerSurfacesFillColor;
			}
			set
			{
				if (this.innerSurfacesFillColor != value)
				{
					this.innerSurfacesFillColor = value;
					if (this.InnerPolygonModelVisual3D != null)
					{
						Material material = MaterialHelper.CreateMaterial(value);
						this.InnerPolygonModelVisual3D.Material = material;
						this.InnerPolygonModelVisual3D.BackMaterial = material;
					}
				}
			}
		}

		// Token: 0x170018E4 RID: 6372
		// (get) Token: 0x06005661 RID: 22113 RVA: 0x00047A5A File Offset: 0x00045C5A
		// (set) Token: 0x06005662 RID: 22114 RVA: 0x00047A66 File Offset: 0x00045C66
		public Visibility SurfacesVisibility
		{
			get
			{
				return this.surfacesVisibility;
			}
			set
			{
				if (this.surfacesVisibility != value)
				{
					this.ChangeSurfacesVisibility(value);
					this.surfacesVisibility = value;
				}
			}
		}

		// Token: 0x170018E5 RID: 6373
		// (get) Token: 0x06005663 RID: 22115 RVA: 0x00047A8B File Offset: 0x00045C8B
		// (set) Token: 0x06005664 RID: 22116 RVA: 0x00047A97 File Offset: 0x00045C97
		public Visibility PointsVisibility
		{
			get
			{
				return this.pointsVisibility;
			}
			set
			{
				if (this.pointsVisibility != value)
				{
					this.ChangePointsVisibility(value);
					this.pointsVisibility = value;
				}
			}
		}

		// Token: 0x06005665 RID: 22117 RVA: 0x00165AEC File Offset: 0x00163CEC
		protected internal override IEnumerable<object> RetrieveDisplayedObjects()
		{
			List<object> list = new List<object>();
			if (this.OuterPolygonModelVisual3D != null)
			{
				list.Add(this.OuterPolygonModelVisual3D);
			}
			if (this.InnerPolygonModelVisual3D != null)
			{
				list.Add(this.InnerPolygonModelVisual3D);
			}
			if (this.PointsModelDrawingResult != null)
			{
				list.AddRange(this.PointsModelDrawingResult.RetrieveDisplayedObjects());
			}
			list.AddRange(this.OuterEdgesDrawingResults.SelectMany((IPolylineDrawingResult edge) => edge.RetrieveDisplayedObjects()));
			list.AddRange(this.InnerEdgesDrawingResults.SelectMany((IPolylineDrawingResult edge) => edge.RetrieveDisplayedObjects()));
			return (from item in list
			where item != null
			select item).ToList<object>();
		}

		// Token: 0x04002485 RID: 9349
		private readonly Visibility linesVisibility;

		// Token: 0x04002486 RID: 9350
		private Visibility surfacesVisibility;

		// Token: 0x04002487 RID: 9351
		private Visibility pointsVisibility;

		// Token: 0x04002488 RID: 9352
		private Color outerSurfacesFillColor;

		// Token: 0x04002489 RID: 9353
		private Color innerSurfacesFillColor;

		// Token: 0x0400248A RID: 9354
		private readonly List<IPolylineDrawingResult> outerEdges = new List<IPolylineDrawingResult>();

		// Token: 0x0400248B RID: 9355
		private readonly List<IPolylineDrawingResult> innerEdges = new List<IPolylineDrawingResult>();
	}
}
