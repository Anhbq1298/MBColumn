using System;
using System.Runtime.CompilerServices;
using System.Windows;
using #APb;
using #eU;
using #RJb;
using #v1c;

namespace #qPb
{
	// Token: 0x020006A4 RID: 1700
	internal sealed class #BWh : #AWh
	{
		// Token: 0x060038DC RID: 14556 RVA: 0x0003173B File Offset: 0x0002F93B
		public #BWh(#oW #xn, #R2c #ts)
		{
			this.#a = #xn;
			this.#b = #ts;
		}

		// Token: 0x1700117F RID: 4479
		// (get) Token: 0x060038DD RID: 14557 RVA: 0x00031751 File Offset: 0x0002F951
		// (set) Token: 0x060038DE RID: 14558 RVA: 0x0003175D File Offset: 0x0002F95D
		public #UPb SectionLeftPanelViewModel { get; set; }

		// Token: 0x17001180 RID: 4480
		// (get) Token: 0x060038DF RID: 14559 RVA: 0x0003176E File Offset: 0x0002F96E
		// (set) Token: 0x060038E0 RID: 14560 RVA: 0x0003177A File Offset: 0x0002F97A
		public #MPb ProjectLeftPanelViewModel { get; set; }

		// Token: 0x17001181 RID: 4481
		// (get) Token: 0x060038E1 RID: 14561 RVA: 0x0003178B File Offset: 0x0002F98B
		// (set) Token: 0x060038E2 RID: 14562 RVA: 0x00031797 File Offset: 0x0002F997
		public #BLb ScopesManager { get; set; }

		// Token: 0x060038E3 RID: 14563 RVA: 0x0011076C File Offset: 0x0010E96C
		public bool #wWh(bool #xWh, bool #yWh = true, bool #zWh = true)
		{
			if (#yWh && this.ScopesManager.Project.IsActive)
			{
				return this.#b.#N2c(this.ScopesManager.Project.PanelView as DependencyObject, true, true);
			}
			if (#zWh && this.ScopesManager.Section.IsActive)
			{
				bool flag = this.#b.#N2c(this.ScopesManager.Section.PanelView as DependencyObject, true, true);
				if (!flag)
				{
					#UPb #UPb = (#UPb)this.ScopesManager.Section.PanelViewModel;
					flag = #UPb.#2Vh();
				}
				return flag;
			}
			return false;
		}

		// Token: 0x040017D5 RID: 6101
		private readonly #oW #a;

		// Token: 0x040017D6 RID: 6102
		private readonly #R2c #b;

		// Token: 0x040017D7 RID: 6103
		[CompilerGenerated]
		private #UPb #c;

		// Token: 0x040017D8 RID: 6104
		[CompilerGenerated]
		private #MPb #d;

		// Token: 0x040017D9 RID: 6105
		[CompilerGenerated]
		private #BLb #e;
	}
}
