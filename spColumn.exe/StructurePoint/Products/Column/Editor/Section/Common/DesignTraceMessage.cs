using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.Products.Column.Editor.Section.Common
{
	// Token: 0x0200061A RID: 1562
	internal sealed class DesignTraceMessage : NotifyPropertyChangedObjectBase
	{
		// Token: 0x060034ED RID: 13549 RVA: 0x0002E635 File Offset: 0x0002C835
		public DesignTraceMessage(string message)
		{
			this.Message = message;
		}

		// Token: 0x17001085 RID: 4229
		// (get) Token: 0x060034EE RID: 13550 RVA: 0x0002E644 File Offset: 0x0002C844
		// (set) Token: 0x060034EF RID: 13551 RVA: 0x0002E650 File Offset: 0x0002C850
		public string Message { get; set; }

		// Token: 0x040015E8 RID: 5608
		[CompilerGenerated]
		private string #a;
	}
}
