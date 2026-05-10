using System;
using System.Windows.Media;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A0F RID: 2575
	public interface ISphereDrawingResult : IDrawingResult
	{
		// Token: 0x17001871 RID: 6257
		// (get) Token: 0x060054EB RID: 21739
		// (set) Token: 0x060054EC RID: 21740
		Color Color { get; set; }

		// Token: 0x17001872 RID: 6258
		// (get) Token: 0x060054ED RID: 21741
		// (set) Token: 0x060054EE RID: 21742
		Point3D Center { get; set; }

		// Token: 0x17001873 RID: 6259
		// (get) Token: 0x060054EF RID: 21743
		// (set) Token: 0x060054F0 RID: 21744
		double Radius { get; set; }
	}
}
