using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using #7hc;
using Ab3d.Cameras;
using Ab3d.Common.Utilities;
using Ab3d.Utilities;
using HelixToolkit.Wpf;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000939 RID: 2361
	[CLSCompliant(false)]
	public sealed class CustomTransparencySorter : TransparencySorter
	{
		// Token: 0x06004D22 RID: 19746 RVA: 0x00040BCF File Offset: 0x0003EDCF
		public CustomTransparencySorter(Model3DGroup rootModelGroup, SphericalCamera usedCamera) : base(rootModelGroup, usedCamera)
		{
			this.ExcludedVisuals = new List<Visual3D>();
			this.AlwaysOnTopVisuals = new List<Visual3D>();
		}

		// Token: 0x06004D23 RID: 19747 RVA: 0x00040BEF File Offset: 0x0003EDEF
		public CustomTransparencySorter(Model3DGroup rootModelGroup, SphericalCamera usedCamera, double cameraAngleChange) : base(rootModelGroup, usedCamera, cameraAngleChange)
		{
			this.ExcludedVisuals = new List<Visual3D>();
			this.AlwaysOnTopVisuals = new List<Visual3D>();
		}

		// Token: 0x06004D24 RID: 19748 RVA: 0x00040C10 File Offset: 0x0003EE10
		public CustomTransparencySorter(ModelVisual3D rootModelVisual3D) : base(rootModelVisual3D)
		{
			this.ExcludedVisuals = new List<Visual3D>();
			this.AlwaysOnTopVisuals = new List<Visual3D>();
		}

		// Token: 0x06004D25 RID: 19749 RVA: 0x00040C2F File Offset: 0x0003EE2F
		public CustomTransparencySorter(Visual3DCollection rootVisual3DCollection) : base(rootVisual3DCollection)
		{
			this.ExcludedVisuals = new List<Visual3D>();
			this.AlwaysOnTopVisuals = new List<Visual3D>();
		}

		// Token: 0x06004D26 RID: 19750 RVA: 0x00040C4E File Offset: 0x0003EE4E
		public CustomTransparencySorter(ContainerUIElement3D containerUiElement3D) : base(containerUiElement3D)
		{
			this.ExcludedVisuals = new List<Visual3D>();
			this.AlwaysOnTopVisuals = new List<Visual3D>();
		}

		// Token: 0x06004D27 RID: 19751 RVA: 0x00040C6D File Offset: 0x0003EE6D
		public CustomTransparencySorter(Viewport3D rootViewport3D) : base(rootViewport3D)
		{
			this.ExcludedVisuals = new List<Visual3D>();
			this.AlwaysOnTopVisuals = new List<Visual3D>();
		}

		// Token: 0x06004D28 RID: 19752 RVA: 0x00040C8C File Offset: 0x0003EE8C
		public CustomTransparencySorter(Viewport3D rootViewport3D, SphericalCamera usedCamera) : base(rootViewport3D, usedCamera)
		{
			this.ExcludedVisuals = new List<Visual3D>();
			this.AlwaysOnTopVisuals = new List<Visual3D>();
		}

		// Token: 0x06004D29 RID: 19753 RVA: 0x00040CAC File Offset: 0x0003EEAC
		public CustomTransparencySorter(Viewport3D rootViewport3D, SphericalCamera usedCamera, double cameraAngleChange) : base(rootViewport3D, usedCamera, cameraAngleChange)
		{
			this.ExcludedVisuals = new List<Visual3D>();
			this.AlwaysOnTopVisuals = new List<Visual3D>();
		}

		// Token: 0x06004D2A RID: 19754 RVA: 0x00040CCD File Offset: 0x0003EECD
		public CustomTransparencySorter(Model3DGroup rootModelGroup) : base(rootModelGroup)
		{
			this.ExcludedVisuals = new List<Visual3D>();
			this.AlwaysOnTopVisuals = new List<Visual3D>();
		}

		// Token: 0x1700166F RID: 5743
		// (get) Token: 0x06004D2B RID: 19755 RVA: 0x00040CEC File Offset: 0x0003EEEC
		// (set) Token: 0x06004D2C RID: 19756 RVA: 0x00040CF8 File Offset: 0x0003EEF8
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<Visual3D> ExcludedVisuals { get; private set; }

		// Token: 0x17001670 RID: 5744
		// (get) Token: 0x06004D2D RID: 19757 RVA: 0x00040D09 File Offset: 0x0003EF09
		// (set) Token: 0x06004D2E RID: 19758 RVA: 0x00040D15 File Offset: 0x0003EF15
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<Visual3D> AlwaysOnTopVisuals { get; private set; }

		// Token: 0x17001671 RID: 5745
		// (get) Token: 0x06004D2F RID: 19759 RVA: 0x00040D26 File Offset: 0x0003EF26
		// (set) Token: 0x06004D30 RID: 19760 RVA: 0x00040D32 File Offset: 0x0003EF32
		public CustomSortingModeType CustomSortingMode { get; set; }

		// Token: 0x06004D31 RID: 19761 RVA: 0x00040D43 File Offset: 0x0003EF43
		public void AddAlwaysOnTopVisual(Visual3D visual3D)
		{
			this.AlwaysOnTopVisuals.Add(visual3D);
		}

		// Token: 0x06004D32 RID: 19762 RVA: 0x00040D5D File Offset: 0x0003EF5D
		public void RemoveAlwaysOnTopVisual(Visual3D visual3D)
		{
			this.AlwaysOnTopVisuals.Remove(visual3D);
		}

		// Token: 0x06004D33 RID: 19763 RVA: 0x0014E258 File Offset: 0x0014C458
		protected override double CalculateSortedValue(BaseTransparentObject3D transparentModel3D, TransparencySorter.SortingModeTypes sortingType)
		{
			TransparentModelVisual3D transparentModelVisual3D = transparentModel3D as TransparentModelVisual3D;
			switch (this.CustomSortingMode)
			{
			case CustomSortingModeType.CustomByCameraDistance:
			{
				if (transparentModelVisual3D == null)
				{
					return 1E-05;
				}
				if (this.ExcludedVisuals != null && this.AlwaysOnTopVisuals.Contains(transparentModelVisual3D.ModelVisual3D))
				{
					return 9E+99;
				}
				if (this.ExcludedVisuals != null && this.ExcludedVisuals.Contains(transparentModelVisual3D.ModelVisual3D))
				{
					return 1E-05;
				}
				Rect3D bounds = transparentModelVisual3D.ModelVisual3D.Content.Bounds;
				return (from item in new List<Point3D>
				{
					new Point3D(bounds.X, bounds.Y, bounds.Z),
					new Point3D(bounds.X + bounds.SizeX, bounds.Y, bounds.Z),
					new Point3D(bounds.X + bounds.SizeX, bounds.Y + bounds.SizeY, bounds.Z),
					new Point3D(bounds.X, bounds.Y + bounds.SizeY, bounds.Z),
					new Point3D(bounds.X, bounds.Y, bounds.Z + bounds.SizeZ),
					new Point3D(bounds.X + bounds.SizeX, bounds.Y, bounds.Z + bounds.SizeZ),
					new Point3D(bounds.X + bounds.SizeX, bounds.Y + bounds.SizeY, bounds.Z + bounds.SizeZ),
					new Point3D(bounds.X, bounds.Y + bounds.SizeY, bounds.Z + bounds.SizeZ)
				}
				select Math.Pow(base.UsedCamera.GetCameraPosition().X - item.X, 2.0) + Math.Pow(base.UsedCamera.GetCameraPosition().Y - item.Y, 2.0) + Math.Pow(base.UsedCamera.GetCameraPosition().Z - item.Z, 2.0)).Min();
			}
			case CustomSortingModeType.OriginalByCameraDistance:
				return base.CalculateSortedValue(transparentModel3D, TransparencySorter.SortingModeTypes.ByCameraDistance);
			case CustomSortingModeType.Disabled:
				return base.CalculateSortedValue(transparentModel3D, TransparencySorter.SortingModeTypes.Disabled);
			case CustomSortingModeType.ByModelZValue:
			{
				if (transparentModelVisual3D == null)
				{
					return 1E-05;
				}
				Rect3D rect3D = transparentModelVisual3D.ModelVisual3D.Content.Bounds;
				if (rect3D.IsEmpty)
				{
					rect3D = transparentModelVisual3D.ModelVisual3D.FindBounds(transparentModelVisual3D.ModelVisual3D.Transform);
				}
				return double.MaxValue - rect3D.Z;
			}
			case CustomSortingModeType.Simple:
				return base.CalculateSortedValue(transparentModel3D, TransparencySorter.SortingModeTypes.Simple);
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107469441));
			}
		}
	}
}
