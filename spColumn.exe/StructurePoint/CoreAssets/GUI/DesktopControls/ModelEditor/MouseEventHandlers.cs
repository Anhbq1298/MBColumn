using System;
using Ab3d.Common.EventManager3D;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000910 RID: 2320
	internal sealed class MouseEventHandlers
	{
		// Token: 0x060049BF RID: 18879 RVA: 0x0003E302 File Offset: 0x0003C502
		public MouseEventHandlers(Mouse3DEventHandler mouseEnter, Mouse3DEventHandler mouseLeave, MouseButton3DEventHandler mouseClick)
		{
			this.MouseEnter = mouseEnter;
			this.MouseLeave = mouseLeave;
			this.MouseClick = mouseClick;
		}

		// Token: 0x17001595 RID: 5525
		// (get) Token: 0x060049C0 RID: 18880 RVA: 0x0003E31F File Offset: 0x0003C51F
		// (set) Token: 0x060049C1 RID: 18881 RVA: 0x0003E32B File Offset: 0x0003C52B
		public Mouse3DEventHandler MouseEnter { get; private set; }

		// Token: 0x17001596 RID: 5526
		// (get) Token: 0x060049C2 RID: 18882 RVA: 0x0003E33C File Offset: 0x0003C53C
		// (set) Token: 0x060049C3 RID: 18883 RVA: 0x0003E348 File Offset: 0x0003C548
		public Mouse3DEventHandler MouseLeave { get; private set; }

		// Token: 0x17001597 RID: 5527
		// (get) Token: 0x060049C4 RID: 18884 RVA: 0x0003E359 File Offset: 0x0003C559
		// (set) Token: 0x060049C5 RID: 18885 RVA: 0x0003E365 File Offset: 0x0003C565
		public MouseButton3DEventHandler MouseClick { get; private set; }
	}
}
