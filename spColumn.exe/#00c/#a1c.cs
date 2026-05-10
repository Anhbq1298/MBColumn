using System;
using System.Diagnostics.CodeAnalysis;
using StructurePoint.CoreAssets.GUI.DesktopControls;

namespace #00c
{
	// Token: 0x02000CB6 RID: 3254
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Invalidatable")]
	[SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "DataBase", Justification = "It is not database")]
	internal sealed class #a1c : #Z0c, IContextMenuItemBase, IInvalidatableContextMenuItemData
	{
		// Token: 0x17001D4B RID: 7499
		// (get) Token: 0x06006A39 RID: 27193 RVA: 0x00053EBF File Offset: 0x000520BF
		// (set) Token: 0x06006A3A RID: 27194 RVA: 0x00053EC7 File Offset: 0x000520C7
		public IDelegateCommand Command
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

		// Token: 0x04002B7B RID: 11131
		private IDelegateCommand #a;
	}
}
