using System;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls
{
	// Token: 0x02000884 RID: 2180
	public sealed class HelpID
	{
		// Token: 0x060044F5 RID: 17653 RVA: 0x000396A1 File Offset: 0x000378A1
		public HelpID(string identifier) : this(identifier, null)
		{
		}

		// Token: 0x060044F6 RID: 17654 RVA: 0x000396AB File Offset: 0x000378AB
		public HelpID(string identifier, string info)
		{
			#X0d.#W0d(identifier, #Phc.#3hc(107454982), Component.DesktopControls, #Phc.#3hc(107454997));
			this.Identifier = identifier;
			this.Info = info;
		}

		// Token: 0x060044F7 RID: 17655 RVA: 0x000035C3 File Offset: 0x000017C3
		internal HelpID()
		{
		}

		// Token: 0x060044F8 RID: 17656 RVA: 0x000396DC File Offset: 0x000378DC
		public override string ToString()
		{
			return this.Identifier;
		}

		// Token: 0x17001434 RID: 5172
		// (get) Token: 0x060044F9 RID: 17657 RVA: 0x000396EC File Offset: 0x000378EC
		// (set) Token: 0x060044FA RID: 17658 RVA: 0x000396F8 File Offset: 0x000378F8
		public string Identifier { get; private set; }

		// Token: 0x17001435 RID: 5173
		// (get) Token: 0x060044FB RID: 17659 RVA: 0x00039709 File Offset: 0x00037909
		// (set) Token: 0x060044FC RID: 17660 RVA: 0x00039715 File Offset: 0x00037915
		public string Info { get; private set; }
	}
}
