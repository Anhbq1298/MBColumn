using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.Products.Column.Model.Entities;

namespace #5Z
{
	// Token: 0x0200038B RID: 907
	internal sealed class #4Z : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06001D61 RID: 7521 RVA: 0x0001C26F File Offset: 0x0001A46F
		public #4Z()
		{
			this.#a = new #W3();
			this.#b = new #W3();
			this.#c = new SlendernessOfColumn();
			this.#d = new SlendernessOfColumn();
		}

		// Token: 0x17000A45 RID: 2629
		// (get) Token: 0x06001D62 RID: 7522 RVA: 0x0001C2A3 File Offset: 0x0001A4A3
		public #W3 BeamX { get; }

		// Token: 0x17000A46 RID: 2630
		// (get) Token: 0x06001D63 RID: 7523 RVA: 0x0001C2AF File Offset: 0x0001A4AF
		public #W3 BeamY { get; }

		// Token: 0x17000A47 RID: 2631
		// (get) Token: 0x06001D64 RID: 7524 RVA: 0x0001C2BB File Offset: 0x0001A4BB
		public SlendernessOfColumn ColumnAbove { get; }

		// Token: 0x17000A48 RID: 2632
		// (get) Token: 0x06001D65 RID: 7525 RVA: 0x0001C2C7 File Offset: 0x0001A4C7
		public SlendernessOfColumn ColumnBelow { get; }

		// Token: 0x04000BBE RID: 3006
		[CompilerGenerated]
		private readonly #W3 #a;

		// Token: 0x04000BBF RID: 3007
		[CompilerGenerated]
		private readonly #W3 #b;

		// Token: 0x04000BC0 RID: 3008
		[CompilerGenerated]
		private readonly SlendernessOfColumn #c;

		// Token: 0x04000BC1 RID: 3009
		[CompilerGenerated]
		private readonly SlendernessOfColumn #d;
	}
}
