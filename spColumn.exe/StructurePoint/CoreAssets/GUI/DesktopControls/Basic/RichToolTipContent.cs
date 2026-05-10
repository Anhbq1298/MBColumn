using System;
using System.Drawing;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.SharedResources.Icons.Tools;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AC9 RID: 2761
	public sealed class RichToolTipContent : NotifyPropertyChangedObjectBase
	{
		// Token: 0x17001964 RID: 6500
		// (get) Token: 0x060059E3 RID: 23011 RVA: 0x0004AA84 File Offset: 0x00048C84
		// (set) Token: 0x060059E4 RID: 23012 RVA: 0x0004AA90 File Offset: 0x00048C90
		public string Title { get; set; }

		// Token: 0x17001965 RID: 6501
		// (get) Token: 0x060059E5 RID: 23013 RVA: 0x0004AAA1 File Offset: 0x00048CA1
		// (set) Token: 0x060059E6 RID: 23014 RVA: 0x0004AAAD File Offset: 0x00048CAD
		public string Description { get; set; }

		// Token: 0x17001966 RID: 6502
		// (get) Token: 0x060059E7 RID: 23015 RVA: 0x0004AABE File Offset: 0x00048CBE
		// (set) Token: 0x060059E8 RID: 23016 RVA: 0x0004AACA File Offset: 0x00048CCA
		public Bitmap PreciseInputIcon { get; private set; }

		// Token: 0x17001967 RID: 6503
		// (get) Token: 0x060059E9 RID: 23017 RVA: 0x0004AADB File Offset: 0x00048CDB
		// (set) Token: 0x060059EA RID: 23018 RVA: 0x0004AAE7 File Offset: 0x00048CE7
		public string PreciseInputTitle { get; private set; }

		// Token: 0x17001968 RID: 6504
		// (get) Token: 0x060059EB RID: 23019 RVA: 0x0004AAF8 File Offset: 0x00048CF8
		// (set) Token: 0x060059EC RID: 23020 RVA: 0x0004AB04 File Offset: 0x00048D04
		public Bitmap HelpIcon { get; private set; }

		// Token: 0x17001969 RID: 6505
		// (get) Token: 0x060059ED RID: 23021 RVA: 0x0004AB15 File Offset: 0x00048D15
		// (set) Token: 0x060059EE RID: 23022 RVA: 0x0004AB21 File Offset: 0x00048D21
		public string HelpTitle { get; private set; }

		// Token: 0x1700196A RID: 6506
		// (get) Token: 0x060059EF RID: 23023 RVA: 0x0004AB32 File Offset: 0x00048D32
		// (set) Token: 0x060059F0 RID: 23024 RVA: 0x0004AB3E File Offset: 0x00048D3E
		public bool IsPreciseInputEnabled { get; private set; }

		// Token: 0x1700196B RID: 6507
		// (get) Token: 0x060059F1 RID: 23025 RVA: 0x0004AB4F File Offset: 0x00048D4F
		// (set) Token: 0x060059F2 RID: 23026 RVA: 0x0004AB5B File Offset: 0x00048D5B
		public bool IsHelpEnabled { get; private set; }

		// Token: 0x060059F3 RID: 23027 RVA: 0x0000C5B9 File Offset: 0x0000A7B9
		public RichToolTipContent()
		{
		}

		// Token: 0x060059F4 RID: 23028 RVA: 0x0016DE1C File Offset: 0x0016C01C
		public RichToolTipContent(bool isPreciseInputEnabled, bool isHelpEnabled)
		{
			this.PreciseInputIcon = ToolsIcons.F10;
			this.PreciseInputTitle = #Phc.#3hc(107425036);
			this.HelpIcon = ToolsIcons.F1;
			this.HelpTitle = #Phc.#3hc(107424487);
			this.IsPreciseInputEnabled = isPreciseInputEnabled;
			this.IsHelpEnabled = isHelpEnabled;
		}

		// Token: 0x060059F5 RID: 23029 RVA: 0x0016DE74 File Offset: 0x0016C074
		public RichToolTipContent(string title, string description, bool isPreciseInputEnabled, bool isHelpEnabled)
		{
			this.Title = title;
			this.Description = description;
			this.PreciseInputIcon = ToolsIcons.F10;
			this.PreciseInputTitle = #Phc.#3hc(107425036);
			this.HelpIcon = ToolsIcons.F1;
			this.HelpTitle = #Phc.#3hc(107424487);
			this.IsPreciseInputEnabled = isPreciseInputEnabled;
			this.IsHelpEnabled = isHelpEnabled;
		}
	}
}
