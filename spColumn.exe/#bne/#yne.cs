using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Framework.Collections;

namespace #bne
{
	// Token: 0x020010F1 RID: 4337
	internal sealed class #yne : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06009329 RID: 37673 RVA: 0x00075F4B File Offset: 0x0007414B
		public #yne(string #5)
		{
			this.Parts.Add(new #wne(#vne.#a, #5));
		}

		// Token: 0x0600932A RID: 37674 RVA: 0x00075F70 File Offset: 0x00074170
		public #yne(string #5, string #zne)
		{
			this.Parts.Add(new #wne(#vne.#a, #5));
			this.Parts.Add(new #wne(#vne.#b, #zne));
		}

		// Token: 0x0600932B RID: 37675 RVA: 0x00075FA7 File Offset: 0x000741A7
		public #yne()
		{
		}

		// Token: 0x17002A8E RID: 10894
		// (get) Token: 0x0600932C RID: 37676 RVA: 0x00075FBA File Offset: 0x000741BA
		public CustomObservableCollection<#wne> Parts { get; } = new CustomObservableCollection<#wne>();

		// Token: 0x04003E99 RID: 16025
		[CompilerGenerated]
		private readonly CustomObservableCollection<#wne> #a;
	}
}
