using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.Framework.PreciseInput
{
	// Token: 0x02000C74 RID: 3188
	public class PreciseInputChangedEventArgs : EventArgs
	{
		// Token: 0x060066AE RID: 26286 RVA: 0x00052728 File Offset: 0x00050928
		public PreciseInputChangedEventArgs(Point point)
		{
			this.Point = point;
		}

		// Token: 0x17001C7D RID: 7293
		// (get) Token: 0x060066AF RID: 26287 RVA: 0x00052737 File Offset: 0x00050937
		// (set) Token: 0x060066B0 RID: 26288 RVA: 0x0005273F File Offset: 0x0005093F
		public Point Point { get; private set; }

		// Token: 0x04002A51 RID: 10833
		[CompilerGenerated]
		private Point #a;
	}
}
