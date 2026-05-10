using System;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Docking
{
	// Token: 0x020009A3 RID: 2467
	public sealed class DockableViewStartOptions
	{
		// Token: 0x06005001 RID: 20481 RVA: 0x0015D0AC File Offset: 0x0015B2AC
		public DockableViewStartOptions(DockPositionType dockPositionType, bool canUserClose, string title, string uniqueIdentifier)
		{
			#X0d.#V0d(title, #Phc.#3hc(107466619), Component.GUI, #Phc.#3hc(107466610));
			#X0d.#V0d(uniqueIdentifier, #Phc.#3hc(107466557), Component.GUI, #Phc.#3hc(107466500));
			this.Title = title;
			this.UniqueIdentifier = uniqueIdentifier;
			this.CanUserClose = canUserClose;
			this.DockPositionType = dockPositionType;
			this.UniqueIdentifier = uniqueIdentifier;
		}

		// Token: 0x06005002 RID: 20482 RVA: 0x00042C4A File Offset: 0x00040E4A
		public DockableViewStartOptions(DockPositionType dockPositionType, bool canUserClose, string title) : this(dockPositionType, canUserClose, title, title)
		{
		}

		// Token: 0x170016FE RID: 5886
		// (get) Token: 0x06005003 RID: 20483 RVA: 0x00042C56 File Offset: 0x00040E56
		// (set) Token: 0x06005004 RID: 20484 RVA: 0x00042C62 File Offset: 0x00040E62
		public double? MinFloatingWidth { get; set; }

		// Token: 0x170016FF RID: 5887
		// (get) Token: 0x06005005 RID: 20485 RVA: 0x00042C73 File Offset: 0x00040E73
		// (set) Token: 0x06005006 RID: 20486 RVA: 0x00042C7F File Offset: 0x00040E7F
		public double? MinFloatingHeight { get; set; }

		// Token: 0x17001700 RID: 5888
		// (get) Token: 0x06005007 RID: 20487 RVA: 0x00042C90 File Offset: 0x00040E90
		// (set) Token: 0x06005008 RID: 20488 RVA: 0x00042C9C File Offset: 0x00040E9C
		public string UniqueIdentifier { get; private set; }

		// Token: 0x17001701 RID: 5889
		// (get) Token: 0x06005009 RID: 20489 RVA: 0x00042CAD File Offset: 0x00040EAD
		// (set) Token: 0x0600500A RID: 20490 RVA: 0x00042CB9 File Offset: 0x00040EB9
		public DockPositionType DockPositionType { get; private set; }

		// Token: 0x17001702 RID: 5890
		// (get) Token: 0x0600500B RID: 20491 RVA: 0x00042CCA File Offset: 0x00040ECA
		// (set) Token: 0x0600500C RID: 20492 RVA: 0x00042CD6 File Offset: 0x00040ED6
		public bool CanUserClose { get; private set; }

		// Token: 0x17001703 RID: 5891
		// (get) Token: 0x0600500D RID: 20493 RVA: 0x00042CE7 File Offset: 0x00040EE7
		// (set) Token: 0x0600500E RID: 20494 RVA: 0x00042CF3 File Offset: 0x00040EF3
		public string Title { get; private set; }
	}
}
