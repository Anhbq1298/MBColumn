using System;
using System.Drawing;
using System.Windows.Input;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon
{
	// Token: 0x020008A2 RID: 2210
	public sealed class RibbonBackstageButtonParameters
	{
		// Token: 0x17001459 RID: 5209
		// (get) Token: 0x060045A8 RID: 17832 RVA: 0x0003A2E2 File Offset: 0x000384E2
		// (set) Token: 0x060045A9 RID: 17833 RVA: 0x0003A2EE File Offset: 0x000384EE
		public Image Image { get; set; }

		// Token: 0x1700145A RID: 5210
		// (get) Token: 0x060045AA RID: 17834 RVA: 0x0003A2FF File Offset: 0x000384FF
		// (set) Token: 0x060045AB RID: 17835 RVA: 0x0003A30B File Offset: 0x0003850B
		public string Text { get; set; }

		// Token: 0x1700145B RID: 5211
		// (get) Token: 0x060045AC RID: 17836 RVA: 0x0003A31C File Offset: 0x0003851C
		// (set) Token: 0x060045AD RID: 17837 RVA: 0x0003A328 File Offset: 0x00038528
		public bool Large { get; set; }

		// Token: 0x1700145C RID: 5212
		// (get) Token: 0x060045AE RID: 17838 RVA: 0x0003A339 File Offset: 0x00038539
		// (set) Token: 0x060045AF RID: 17839 RVA: 0x0003A345 File Offset: 0x00038545
		public ICommand Command { get; set; }

		// Token: 0x1700145D RID: 5213
		// (get) Token: 0x060045B0 RID: 17840 RVA: 0x0003A356 File Offset: 0x00038556
		// (set) Token: 0x060045B1 RID: 17841 RVA: 0x0003A362 File Offset: 0x00038562
		public object CommandParameter { get; set; }

		// Token: 0x1700145E RID: 5214
		// (get) Token: 0x060045B2 RID: 17842 RVA: 0x0003A373 File Offset: 0x00038573
		// (set) Token: 0x060045B3 RID: 17843 RVA: 0x0003A37F File Offset: 0x0003857F
		public bool CloseOnClick { get; set; }

		// Token: 0x1700145F RID: 5215
		// (get) Token: 0x060045B4 RID: 17844 RVA: 0x0003A390 File Offset: 0x00038590
		// (set) Token: 0x060045B5 RID: 17845 RVA: 0x0003A39C File Offset: 0x0003859C
		public bool IsEnabled { get; set; }

		// Token: 0x17001460 RID: 5216
		// (get) Token: 0x060045B6 RID: 17846 RVA: 0x0003A3AD File Offset: 0x000385AD
		// (set) Token: 0x060045B7 RID: 17847 RVA: 0x0003A3B9 File Offset: 0x000385B9
		public bool IsSelectable { get; set; }

		// Token: 0x17001461 RID: 5217
		// (get) Token: 0x060045B8 RID: 17848 RVA: 0x0003A3CA File Offset: 0x000385CA
		// (set) Token: 0x060045B9 RID: 17849 RVA: 0x0003A3D6 File Offset: 0x000385D6
		public bool IsSelected { get; set; }

		// Token: 0x17001462 RID: 5218
		// (get) Token: 0x060045BA RID: 17850 RVA: 0x0003A3E7 File Offset: 0x000385E7
		// (set) Token: 0x060045BB RID: 17851 RVA: 0x0003A3F3 File Offset: 0x000385F3
		public object SelectableContent { get; set; }
	}
}
