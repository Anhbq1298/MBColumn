using System;
using System.Windows;
using System.Windows.Media;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Visualization2D
{
	// Token: 0x020008C9 RID: 2249
	public sealed class DrawingVisualHost : FrameworkElement
	{
		// Token: 0x06004749 RID: 18249 RVA: 0x0003C147 File Offset: 0x0003A347
		public DrawingVisualHost()
		{
			this.Visuals = new VisualCollection(this);
		}

		// Token: 0x170014ED RID: 5357
		// (get) Token: 0x0600474A RID: 18250 RVA: 0x0003C15B File Offset: 0x0003A35B
		// (set) Token: 0x0600474B RID: 18251 RVA: 0x0003C167 File Offset: 0x0003A367
		public VisualCollection Visuals { get; private set; }

		// Token: 0x170014EE RID: 5358
		// (get) Token: 0x0600474C RID: 18252 RVA: 0x0003C178 File Offset: 0x0003A378
		protected override int VisualChildrenCount
		{
			get
			{
				return this.Visuals.Count;
			}
		}

		// Token: 0x0600474D RID: 18253 RVA: 0x0003C191 File Offset: 0x0003A391
		protected override Visual GetVisualChild(int index)
		{
			return this.Visuals[index];
		}
	}
}
