using System;
using Telerik.Windows.Controls;
using Telerik.Windows.Documents.Commands.Descriptors;

namespace #LPd
{
	// Token: 0x02000DF7 RID: 3575
	internal sealed class #RPd : DefaultCommandDescriptors
	{
		// Token: 0x060080F3 RID: 33011 RVA: 0x00069020 File Offset: 0x00067220
		public #RPd(FixedDocumentViewerBase #SPd) : base(#SPd)
		{
			this.#a = new CommandDescriptor(new #YPd(#SPd), true);
		}

		// Token: 0x17002678 RID: 9848
		// (get) Token: 0x060080F4 RID: 33012 RVA: 0x0006903B File Offset: 0x0006723B
		public CommandDescriptorBase ZoomOutCommandDescriptor
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x040034E2 RID: 13538
		private readonly CommandDescriptorBase #a;
	}
}
