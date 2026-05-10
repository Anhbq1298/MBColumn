using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A05 RID: 2565
	public interface ICirclesDrawingResult : IDrawingResult
	{
		// Token: 0x17001844 RID: 6212
		// (get) Token: 0x0600547D RID: 21629
		// (set) Token: 0x0600547E RID: 21630
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		IList<Point3D> Points { get; set; }

		// Token: 0x17001845 RID: 6213
		// (get) Token: 0x0600547F RID: 21631
		// (set) Token: 0x06005480 RID: 21632
		Color Color { get; set; }

		// Token: 0x17001846 RID: 6214
		// (get) Token: 0x06005481 RID: 21633
		// (set) Token: 0x06005482 RID: 21634
		double Radius { get; set; }

		// Token: 0x17001847 RID: 6215
		// (get) Token: 0x06005483 RID: 21635
		// (set) Token: 0x06005484 RID: 21636
		int Sides { get; set; }

		// Token: 0x17001848 RID: 6216
		// (get) Token: 0x06005485 RID: 21637
		IEnumerable<PolyLine3D> Polylines { get; }

		// Token: 0x17001849 RID: 6217
		// (get) Token: 0x06005486 RID: 21638
		// (set) Token: 0x06005487 RID: 21639
		bool GeneratePolylines { get; set; }
	}
}
