using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using #u3d;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A1A RID: 2586
	public interface ILinesDrawingResultBase
	{
		// Token: 0x17001899 RID: 6297
		// (get) Token: 0x06005566 RID: 21862
		// (set) Token: 0x06005567 RID: 21863
		Visibility Visibility { get; set; }

		// Token: 0x1700189A RID: 6298
		// (get) Token: 0x06005568 RID: 21864
		// (set) Token: 0x06005569 RID: 21865
		IEnumerable<Point3D> Positions { get; set; }

		// Token: 0x1700189B RID: 6299
		// (get) Token: 0x0600556A RID: 21866
		// (set) Token: 0x0600556B RID: 21867
		Color LineColor { get; set; }

		// Token: 0x1700189C RID: 6300
		// (get) Token: 0x0600556C RID: 21868
		// (set) Token: 0x0600556D RID: 21869
		double LineThickness { get; set; }

		// Token: 0x0600556E RID: 21870
		void SetTransforms(#c4d? translateVector, #c4d? scaleVector);
	}
}
