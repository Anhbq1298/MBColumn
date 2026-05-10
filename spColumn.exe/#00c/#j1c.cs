using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;
using StructurePoint.CoreAssets.GUI.DesktopControls;

namespace #00c
{
	// Token: 0x02000CB8 RID: 3256
	[SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "DataBase", Justification = "It is not database")]
	internal sealed class #j1c : #Z0c, IContextMenuItemBase, IContextMenuItemData
	{
		// Token: 0x17001D51 RID: 7505
		// (get) Token: 0x06006A48 RID: 27208 RVA: 0x00053F09 File Offset: 0x00052109
		// (set) Token: 0x06006A49 RID: 27209 RVA: 0x00053F11 File Offset: 0x00052111
		public ICommand Command
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.#a = value;
			}
		}

		// Token: 0x04002B81 RID: 11137
		private ICommand #a;
	}
}
