using System;
using System.Collections.Generic;
using #7hc;
using Ab3d.Visuals;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl
{
	// Token: 0x0200094E RID: 2382
	internal sealed class ViewCubeVisualElement
	{
		// Token: 0x06004D86 RID: 19846 RVA: 0x00040FDB File Offset: 0x0003F1DB
		public ViewCubeVisualElement(CubeElementType type, PredefinedPositionsOfCamera cameraPosition, PlaneVisual3D plane)
		{
			if (plane == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107469661));
			}
			this.CameraPosition = cameraPosition;
			this.Type = type;
			this.Planes = new List<PlaneVisual3D>
			{
				plane
			};
		}

		// Token: 0x06004D87 RID: 19847 RVA: 0x00041016 File Offset: 0x0003F216
		public ViewCubeVisualElement(CubeElementType type, PredefinedPositionsOfCamera cameraPosition, IEnumerable<PlaneVisual3D> planes)
		{
			if (planes == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107469652));
			}
			this.CameraPosition = cameraPosition;
			this.Type = type;
			this.Planes = new List<PlaneVisual3D>(planes);
		}

		// Token: 0x1700167E RID: 5758
		// (get) Token: 0x06004D88 RID: 19848 RVA: 0x0004104B File Offset: 0x0003F24B
		// (set) Token: 0x06004D89 RID: 19849 RVA: 0x00041057 File Offset: 0x0003F257
		public CubeElementType Type { get; private set; }

		// Token: 0x1700167F RID: 5759
		// (get) Token: 0x06004D8A RID: 19850 RVA: 0x00041068 File Offset: 0x0003F268
		// (set) Token: 0x06004D8B RID: 19851 RVA: 0x00041074 File Offset: 0x0003F274
		public PredefinedPositionsOfCamera CameraPosition { get; private set; }

		// Token: 0x17001680 RID: 5760
		// (get) Token: 0x06004D8C RID: 19852 RVA: 0x00041085 File Offset: 0x0003F285
		// (set) Token: 0x06004D8D RID: 19853 RVA: 0x00041091 File Offset: 0x0003F291
		public IReadOnlyList<PlaneVisual3D> Planes { get; private set; }
	}
}
