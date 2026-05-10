using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;
using #u3d;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A06 RID: 2566
	[SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "PolyLine")]
	public interface IMultiPolyLineDrawingResult : IDrawingResult
	{
		// Token: 0x1700184A RID: 6218
		// (get) Token: 0x06005488 RID: 21640
		// (set) Token: 0x06005489 RID: 21641
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		IEnumerable<List<Point3D>> Positions { get; set; }

		// Token: 0x1700184B RID: 6219
		// (get) Token: 0x0600548A RID: 21642
		// (set) Token: 0x0600548B RID: 21643
		Color LineColor { get; set; }

		// Token: 0x1700184C RID: 6220
		// (get) Token: 0x0600548C RID: 21644
		// (set) Token: 0x0600548D RID: 21645
		bool IsClosed { get; set; }

		// Token: 0x1700184D RID: 6221
		// (get) Token: 0x0600548E RID: 21646
		// (set) Token: 0x0600548F RID: 21647
		double LineThickness { get; set; }

		// Token: 0x06005490 RID: 21648
		void SetTransforms(#c4d? translateVector, #c4d? scaleVector);

		// Token: 0x06005491 RID: 21649
		void RecreateVisual();
	}
}
