using System;
using System.Runtime.CompilerServices;
using System.Windows.Shapes;

namespace StructurePoint.Products.Column.FailureSurface.Controls
{
	// Token: 0x0200048E RID: 1166
	internal sealed class PolylineMetadata
	{
		// Token: 0x06002B5D RID: 11101 RVA: 0x0002728B File Offset: 0x0002548B
		public PolylineMetadata(Polyline polyline)
		{
			this.Polyline = polyline;
			this.StrokeThickness = polyline.StrokeThickness;
		}

		// Token: 0x17000EA2 RID: 3746
		// (get) Token: 0x06002B5E RID: 11102 RVA: 0x000272A6 File Offset: 0x000254A6
		// (set) Token: 0x06002B5F RID: 11103 RVA: 0x000272B2 File Offset: 0x000254B2
		public Polyline Polyline { get; private set; }

		// Token: 0x17000EA3 RID: 3747
		// (get) Token: 0x06002B60 RID: 11104 RVA: 0x000272C3 File Offset: 0x000254C3
		// (set) Token: 0x06002B61 RID: 11105 RVA: 0x000272CF File Offset: 0x000254CF
		public double StrokeThickness { get; private set; }

		// Token: 0x04001154 RID: 4436
		[CompilerGenerated]
		private Polyline #a;

		// Token: 0x04001155 RID: 4437
		[CompilerGenerated]
		private double #b;
	}
}
