using System;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #gfe;
using StructurePoint.CoreAssets.AppManager.Column.Templates;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Storage;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace #3wb
{
	// Token: 0x020004B7 RID: 1207
	internal sealed class #ixb : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06002C46 RID: 11334 RVA: 0x00027CFF File Offset: 0x00025EFF
		public #ixb(SectionTemplateDefinition #xS, string #wy, string #jxb)
		{
			this.#b = #xS;
			this.#c = #wy;
			this.#d = #jxb;
			this.#a = #Afe.#zfe(#xS, TemplateFileType.Selector);
		}

		// Token: 0x17000ED9 RID: 3801
		// (get) Token: 0x06002C47 RID: 11335 RVA: 0x00027D29 File Offset: 0x00025F29
		public ImageSource ImageSource { get; }

		// Token: 0x17000EDA RID: 3802
		// (get) Token: 0x06002C48 RID: 11336 RVA: 0x00027D35 File Offset: 0x00025F35
		public SectionTemplateDefinition Definition { get; }

		// Token: 0x17000EDB RID: 3803
		// (get) Token: 0x06002C49 RID: 11337 RVA: 0x00027D41 File Offset: 0x00025F41
		public string Name { get; }

		// Token: 0x17000EDC RID: 3804
		// (get) Token: 0x06002C4A RID: 11338 RVA: 0x00027D4D File Offset: 0x00025F4D
		public string TemplateDefinitionPath { get; }

		// Token: 0x040011BB RID: 4539
		[CompilerGenerated]
		private readonly ImageSource #a;

		// Token: 0x040011BC RID: 4540
		[CompilerGenerated]
		private readonly SectionTemplateDefinition #b;

		// Token: 0x040011BD RID: 4541
		[CompilerGenerated]
		private readonly string #c;

		// Token: 0x040011BE RID: 4542
		[CompilerGenerated]
		private readonly string #d;
	}
}
