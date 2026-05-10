using System;
using System.Runtime.CompilerServices;
using #3Rd;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Data
{
	// Token: 0x02000E30 RID: 3632
	public sealed class ScreenshootOption : Option
	{
		// Token: 0x06008252 RID: 33362 RVA: 0x0006A1AC File Offset: 0x000683AC
		public ScreenshootOption(#oSd drawing, string bookmarkname = null) : base(bookmarkname)
		{
			this.Drawing = drawing;
			base.IsEnabled = true;
		}

		// Token: 0x06008253 RID: 33363 RVA: 0x0006A1C3 File Offset: 0x000683C3
		public ScreenshootOption(Option parent, #oSd drawing, string bookmarkName = null) : base(parent, bookmarkName)
		{
			this.Drawing = drawing;
			base.IsEnabled = true;
		}

		// Token: 0x170026E7 RID: 9959
		// (get) Token: 0x06008254 RID: 33364 RVA: 0x0006A1DB File Offset: 0x000683DB
		// (set) Token: 0x06008255 RID: 33365 RVA: 0x0006A1E7 File Offset: 0x000683E7
		public #oSd Drawing { get; private set; }

		// Token: 0x170026E8 RID: 9960
		// (get) Token: 0x06008256 RID: 33366 RVA: 0x0006A1F8 File Offset: 0x000683F8
		// (set) Token: 0x06008257 RID: 33367 RVA: 0x0006A204 File Offset: 0x00068404
		public object Tag { get; set; }

		// Token: 0x0400357D RID: 13693
		[CompilerGenerated]
		private #oSd #a;

		// Token: 0x0400357E RID: 13694
		[CompilerGenerated]
		private object #b;
	}
}
