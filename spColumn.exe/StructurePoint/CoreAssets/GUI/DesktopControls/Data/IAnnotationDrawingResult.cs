using System;
using System.Windows.Media;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A15 RID: 2581
	public interface IAnnotationDrawingResult : IDrawingResult
	{
		// Token: 0x17001880 RID: 6272
		// (get) Token: 0x0600551E RID: 21790
		// (set) Token: 0x0600551F RID: 21791
		Point3D Position { get; set; }

		// Token: 0x17001881 RID: 6273
		// (get) Token: 0x06005520 RID: 21792
		// (set) Token: 0x06005521 RID: 21793
		string Text { get; set; }

		// Token: 0x06005522 RID: 21794
		void SetAnnotationBackground(Color color);

		// Token: 0x06005523 RID: 21795
		void SetAnnotationForeground(Color color);

		// Token: 0x06005524 RID: 21796
		void SetAnnotationBorder(Color color);

		// Token: 0x06005525 RID: 21797
		void SetAnnotationRadius(double radius);

		// Token: 0x06005526 RID: 21798
		void BeginInit();

		// Token: 0x06005527 RID: 21799
		void EndInit();
	}
}
