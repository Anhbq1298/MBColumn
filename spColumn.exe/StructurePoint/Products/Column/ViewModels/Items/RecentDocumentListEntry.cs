using System;
using System.IO;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.Products.Column.ViewModels.Items
{
	// Token: 0x020000F3 RID: 243
	internal sealed class RecentDocumentListEntry : NotifyPropertyChangedObjectBase
	{
		// Token: 0x060007C9 RID: 1993 RVA: 0x0000BEF5 File Offset: 0x0000A0F5
		private RecentDocumentListEntry(string fullPath, string displayValue, string directoryPath)
		{
			this.#a = fullPath;
			this.#b = displayValue;
			this.#c = directoryPath;
		}

		// Token: 0x17000348 RID: 840
		// (get) Token: 0x060007CA RID: 1994 RVA: 0x0000BF12 File Offset: 0x0000A112
		public string FullPath { get; }

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x060007CB RID: 1995 RVA: 0x0000BF1E File Offset: 0x0000A11E
		public string DisplayValue { get; }

		// Token: 0x1700034A RID: 842
		// (get) Token: 0x060007CC RID: 1996 RVA: 0x0000BF2A File Offset: 0x0000A12A
		public string DirectoryPath { get; }

		// Token: 0x060007CD RID: 1997 RVA: 0x00091F94 File Offset: 0x00090194
		public static RecentDocumentListEntry #ul(string #vl)
		{
			RecentDocumentListEntry result = null;
			try
			{
				string directoryName = Path.GetDirectoryName(#vl);
				string fileName = Path.GetFileName(#vl);
				if (!string.IsNullOrWhiteSpace(fileName) && !string.IsNullOrWhiteSpace(directoryName) && !string.IsNullOrWhiteSpace(#vl))
				{
					result = new RecentDocumentListEntry(#vl, fileName, directoryName);
				}
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x0400022D RID: 557
		[CompilerGenerated]
		private readonly string #a;

		// Token: 0x0400022E RID: 558
		[CompilerGenerated]
		private readonly string #b;

		// Token: 0x0400022F RID: 559
		[CompilerGenerated]
		private readonly string #c;
	}
}
