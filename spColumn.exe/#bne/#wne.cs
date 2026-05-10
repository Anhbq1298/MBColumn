using System;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace #bne
{
	// Token: 0x020010F0 RID: 4336
	internal sealed class #wne : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06009322 RID: 37666 RVA: 0x00075EE6 File Offset: 0x000740E6
		public #wne(#vne #C, string #5)
		{
			this.#a = #C;
			this.#b = #5;
		}

		// Token: 0x06009323 RID: 37667 RVA: 0x0000C5B9 File Offset: 0x0000A7B9
		public #wne()
		{
		}

		// Token: 0x17002A8B RID: 10891
		// (get) Token: 0x06009324 RID: 37668 RVA: 0x00075EFC File Offset: 0x000740FC
		// (set) Token: 0x06009325 RID: 37669 RVA: 0x00075F04 File Offset: 0x00074104
		public #vne Type
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.SetProperty<#vne>(ref this.#a, value, #Phc.#3hc(107462703));
			}
		}

		// Token: 0x17002A8C RID: 10892
		// (get) Token: 0x06009326 RID: 37670 RVA: 0x00075F1E File Offset: 0x0007411E
		// (set) Token: 0x06009327 RID: 37671 RVA: 0x00075F26 File Offset: 0x00074126
		public string Message
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<string>(ref this.#b, value, #Phc.#3hc(107383983));
			}
		}

		// Token: 0x17002A8D RID: 10893
		// (get) Token: 0x06009328 RID: 37672 RVA: 0x00075F40 File Offset: 0x00074140
		public bool IsWarning
		{
			get
			{
				return this.Type == #vne.#b;
			}
		}

		// Token: 0x04003E97 RID: 16023
		private #vne #a;

		// Token: 0x04003E98 RID: 16024
		private string #b;
	}
}
