using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.GUI.Framework.PreciseInput
{
	// Token: 0x02000C75 RID: 3189
	public sealed class PreciseInputCompletedEventArgs : PreciseInputChangedEventArgs
	{
		// Token: 0x060066B1 RID: 26289 RVA: 0x00052748 File Offset: 0x00050948
		public PreciseInputCompletedEventArgs(Point point, bool requestClose) : base(point)
		{
			this.RequestClose = requestClose;
		}

		// Token: 0x17001C7E RID: 7294
		// (get) Token: 0x060066B2 RID: 26290 RVA: 0x00052758 File Offset: 0x00050958
		// (set) Token: 0x060066B3 RID: 26291 RVA: 0x00052760 File Offset: 0x00050960
		public bool RequestClose { get; private set; }

		// Token: 0x04002A52 RID: 10834
		[CompilerGenerated]
		private bool #a;
	}
}
