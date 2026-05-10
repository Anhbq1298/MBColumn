using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009D1 RID: 2513
	public sealed class GridControlFiltersStateChangedEventArgs : EventArgs
	{
		// Token: 0x060051E3 RID: 20963 RVA: 0x00043F96 File Offset: 0x00042196
		public GridControlFiltersStateChangedEventArgs(bool enabled)
		{
			this.enabled = enabled;
		}

		// Token: 0x17001773 RID: 6003
		// (get) Token: 0x060051E4 RID: 20964 RVA: 0x00043FA5 File Offset: 0x000421A5
		public bool Enabled
		{
			get
			{
				return this.enabled;
			}
		}

		// Token: 0x040023AE RID: 9134
		private readonly bool enabled;
	}
}
