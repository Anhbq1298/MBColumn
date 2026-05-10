using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.Geometry.Data
{
	// Token: 0x02000819 RID: 2073
	public sealed class PolyLine3D
	{
		// Token: 0x0600428E RID: 17038 RVA: 0x00037DF6 File Offset: 0x00035FF6
		public PolyLine3D(IEnumerable<Point3D> points)
		{
			this.Points = points.ToList<Point3D>();
		}

		// Token: 0x0600428F RID: 17039 RVA: 0x00037E0A File Offset: 0x0003600A
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public PolyLine3D(List<Point3D> points)
		{
			this.Points = points;
		}

		// Token: 0x170013A5 RID: 5029
		// (get) Token: 0x06004290 RID: 17040 RVA: 0x00037E19 File Offset: 0x00036019
		// (set) Token: 0x06004291 RID: 17041 RVA: 0x00037E25 File Offset: 0x00036025
		public IReadOnlyList<Point3D> Points { get; private set; }

		// Token: 0x04001E00 RID: 7680
		[CompilerGenerated]
		private IReadOnlyList<Point3D> #a;
	}
}
