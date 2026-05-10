using System;
using #7hc;
using #cYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Docking
{
	// Token: 0x020009A9 RID: 2473
	public sealed class ViewLoadingEventArgs : EventArgs
	{
		// Token: 0x06005057 RID: 20567 RVA: 0x00042F08 File Offset: 0x00041108
		public ViewLoadingEventArgs(string viewGuid)
		{
			if (string.IsNullOrEmpty(viewGuid))
			{
				throw new #iYd(#Phc.#3hc(107465402), #Phc.#3hc(107465357), Component.DesktopControls, #IYd.#c);
			}
			this.ViewGuid = viewGuid;
		}

		// Token: 0x1700171B RID: 5915
		// (get) Token: 0x06005058 RID: 20568 RVA: 0x00042F3C File Offset: 0x0004113C
		// (set) Token: 0x06005059 RID: 20569 RVA: 0x00042F48 File Offset: 0x00041148
		public string ViewGuid { get; private set; }

		// Token: 0x1700171C RID: 5916
		// (get) Token: 0x0600505A RID: 20570 RVA: 0x00042F59 File Offset: 0x00041159
		// (set) Token: 0x0600505B RID: 20571 RVA: 0x00042F65 File Offset: 0x00041165
		public object ViewObject { get; set; }
	}
}
