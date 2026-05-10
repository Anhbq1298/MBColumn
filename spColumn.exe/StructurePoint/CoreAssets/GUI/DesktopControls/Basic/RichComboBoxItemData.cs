using System;
using System.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AC8 RID: 2760
	public sealed class RichComboBoxItemData<TValue> : IRichComboBoxItemData
	{
		// Token: 0x060059D9 RID: 23001 RVA: 0x0004A9C7 File Offset: 0x00048BC7
		public RichComboBoxItemData(string header, string description, TValue value, Image image)
		{
			this.Header = header;
			this.Description = description;
			this.Value = value;
			this.Image = image;
		}

		// Token: 0x060059DA RID: 23002 RVA: 0x0004A9EC File Offset: 0x00048BEC
		public RichComboBoxItemData(string header, TValue value, Image image)
		{
			this.Header = header;
			this.Description = null;
			this.Value = value;
			this.Image = image;
		}

		// Token: 0x17001960 RID: 6496
		// (get) Token: 0x060059DB RID: 23003 RVA: 0x0004AA10 File Offset: 0x00048C10
		// (set) Token: 0x060059DC RID: 23004 RVA: 0x0004AA1C File Offset: 0x00048C1C
		public string Header { get; set; }

		// Token: 0x17001961 RID: 6497
		// (get) Token: 0x060059DD RID: 23005 RVA: 0x0004AA2D File Offset: 0x00048C2D
		// (set) Token: 0x060059DE RID: 23006 RVA: 0x0004AA39 File Offset: 0x00048C39
		public string Description { get; set; }

		// Token: 0x17001962 RID: 6498
		// (get) Token: 0x060059DF RID: 23007 RVA: 0x0004AA4A File Offset: 0x00048C4A
		// (set) Token: 0x060059E0 RID: 23008 RVA: 0x0004AA56 File Offset: 0x00048C56
		public TValue Value { get; set; }

		// Token: 0x17001963 RID: 6499
		// (get) Token: 0x060059E1 RID: 23009 RVA: 0x0004AA67 File Offset: 0x00048C67
		// (set) Token: 0x060059E2 RID: 23010 RVA: 0x0004AA73 File Offset: 0x00048C73
		public Image Image { get; set; }
	}
}
