using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000AAB RID: 2731
	public sealed class TextColumnsValue
	{
		// Token: 0x06005903 RID: 22787 RVA: 0x000035C3 File Offset: 0x000017C3
		public TextColumnsValue()
		{
		}

		// Token: 0x06005904 RID: 22788 RVA: 0x00049BE6 File Offset: 0x00047DE6
		public TextColumnsValue(string prefix, string value)
		{
			this.Prefix = prefix;
			this.Value = value;
		}

		// Token: 0x1700193E RID: 6462
		// (get) Token: 0x06005905 RID: 22789 RVA: 0x00049BFC File Offset: 0x00047DFC
		// (set) Token: 0x06005906 RID: 22790 RVA: 0x00049C08 File Offset: 0x00047E08
		public string Prefix { get; set; }

		// Token: 0x1700193F RID: 6463
		// (get) Token: 0x06005907 RID: 22791 RVA: 0x00049C19 File Offset: 0x00047E19
		// (set) Token: 0x06005908 RID: 22792 RVA: 0x00049C25 File Offset: 0x00047E25
		public string Value { get; set; }

		// Token: 0x17001940 RID: 6464
		// (get) Token: 0x06005909 RID: 22793 RVA: 0x00049C36 File Offset: 0x00047E36
		// (set) Token: 0x0600590A RID: 22794 RVA: 0x00049C42 File Offset: 0x00047E42
		public bool SkipPrefixing { get; set; }

		// Token: 0x17001941 RID: 6465
		// (get) Token: 0x0600590B RID: 22795 RVA: 0x00049C53 File Offset: 0x00047E53
		// (set) Token: 0x0600590C RID: 22796 RVA: 0x00049C5F File Offset: 0x00047E5F
		internal double FinalWidth { get; set; }
	}
}
