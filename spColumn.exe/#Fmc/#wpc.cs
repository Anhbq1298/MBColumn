using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #Fmc
{
	// Token: 0x020007CD RID: 1997
	[DebuggerDisplay("S({Segment.StartPoint} -> {Segment.EndPoint}) - O({Point})")]
	internal sealed class #wpc
	{
		// Token: 0x06003FFE RID: 16382 RVA: 0x00036180 File Offset: 0x00034380
		public #wpc(SegmentData #PP, Point #Ng)
		{
			this.Segment = #PP;
			this.Point = #Ng;
			this.BoundingRect = new Rect(#PP.StartPoint, #PP.EndPoint);
		}

		// Token: 0x1700132D RID: 4909
		// (get) Token: 0x06003FFF RID: 16383 RVA: 0x000361AD File Offset: 0x000343AD
		// (set) Token: 0x06004000 RID: 16384 RVA: 0x000361B9 File Offset: 0x000343B9
		public SegmentData Segment { get; private set; }

		// Token: 0x1700132E RID: 4910
		// (get) Token: 0x06004001 RID: 16385 RVA: 0x000361CA File Offset: 0x000343CA
		// (set) Token: 0x06004002 RID: 16386 RVA: 0x000361D6 File Offset: 0x000343D6
		public Point Point { get; private set; }

		// Token: 0x1700132F RID: 4911
		// (get) Token: 0x06004003 RID: 16387 RVA: 0x000361E7 File Offset: 0x000343E7
		// (set) Token: 0x06004004 RID: 16388 RVA: 0x000361F3 File Offset: 0x000343F3
		public Rect BoundingRect { get; private set; }

		// Token: 0x04001CFB RID: 7419
		[CompilerGenerated]
		private SegmentData #a;

		// Token: 0x04001CFC RID: 7420
		[CompilerGenerated]
		private Point #b;

		// Token: 0x04001CFD RID: 7421
		[CompilerGenerated]
		private Rect #c;
	}
}
