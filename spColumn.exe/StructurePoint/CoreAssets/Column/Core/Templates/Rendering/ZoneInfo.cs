using System;
using System.Drawing;

namespace StructurePoint.CoreAssets.Column.Core.Templates.Rendering
{
	// Token: 0x0200084F RID: 2127
	public sealed class ZoneInfo
	{
		// Token: 0x170013F4 RID: 5108
		// (get) Token: 0x060043BB RID: 17339 RVA: 0x00038AF4 File Offset: 0x00036CF4
		// (set) Token: 0x060043BC RID: 17340 RVA: 0x00038AFC File Offset: 0x00036CFC
		public int Id { get; set; }

		// Token: 0x170013F5 RID: 5109
		// (get) Token: 0x060043BD RID: 17341 RVA: 0x00038B05 File Offset: 0x00036D05
		// (set) Token: 0x060043BE RID: 17342 RVA: 0x00038B0D File Offset: 0x00036D0D
		public Color GroupColor { get; set; }

		// Token: 0x170013F6 RID: 5110
		// (get) Token: 0x060043BF RID: 17343 RVA: 0x00038B16 File Offset: 0x00036D16
		// (set) Token: 0x060043C0 RID: 17344 RVA: 0x00038B1E File Offset: 0x00036D1E
		public Color ShapeColor { get; set; }

		// Token: 0x170013F7 RID: 5111
		// (get) Token: 0x060043C1 RID: 17345 RVA: 0x00038B27 File Offset: 0x00036D27
		// (set) Token: 0x060043C2 RID: 17346 RVA: 0x00038B2F File Offset: 0x00036D2F
		public int ColorIndex { get; set; }
	}
}
