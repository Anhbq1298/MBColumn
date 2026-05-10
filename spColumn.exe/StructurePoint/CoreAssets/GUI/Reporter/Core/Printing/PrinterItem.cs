using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using #hId;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Printing
{
	// Token: 0x02000DA9 RID: 3497
	public class PrinterItem : ComboItem<string>
	{
		// Token: 0x06007E5C RID: 32348 RVA: 0x00066EB9 File Offset: 0x000650B9
		public PrinterItem(string value, string displayValue) : base(value, displayValue)
		{
			this.IsRealDevice = true;
			this.#a = new Lazy<#GId>(new Func<#GId>(this.#8Zb));
		}

		// Token: 0x170025DA RID: 9690
		// (get) Token: 0x06007E5D RID: 32349 RVA: 0x00066EE1 File Offset: 0x000650E1
		// (set) Token: 0x06007E5E RID: 32350 RVA: 0x00066EED File Offset: 0x000650ED
		public bool IsRealDevice { get; protected set; }

		// Token: 0x170025DB RID: 9691
		// (get) Token: 0x06007E5F RID: 32351 RVA: 0x00066EFE File Offset: 0x000650FE
		public virtual #GId PrinterStatus
		{
			get
			{
				return this.#a.Value;
			}
		}

		// Token: 0x170025DC RID: 9692
		// (get) Token: 0x06007E60 RID: 32352 RVA: 0x00066F13 File Offset: 0x00065113
		public virtual bool IsReady
		{
			get
			{
				return this.PrinterStatus == #GId.#a;
			}
		}

		// Token: 0x170025DD RID: 9693
		// (get) Token: 0x06007E61 RID: 32353 RVA: 0x00066F26 File Offset: 0x00065126
		public virtual string Status
		{
			get
			{
				return #OId.#JId(this.PrinterStatus);
			}
		}

		// Token: 0x06007E62 RID: 32354 RVA: 0x001BC6AC File Offset: 0x001BA8AC
		public virtual IReadOnlyList<PaperSizeItem> #UId()
		{
			PrinterItem.#iZb #iZb = new PrinterItem.#iZb();
			#iZb.#a = this;
			List<PaperSizeItem> list = new List<PaperSizeItem>();
			base.RaisePropertyChanged<bool>(() => this.#SId);
			base.RaisePropertyChanged<string>(() => this.#TId);
			if (!this.IsReady)
			{
				return list;
			}
			PrinterSettings printerSettings = new PrinterSettings();
			printerSettings.PrinterName = base.Value;
			#iZb.#b = printerSettings.DefaultPageSettings.PaperSize.RawKind;
			list.AddRange(printerSettings.PaperSizes.OfType<PaperSize>().Select(new Func<PaperSize, PaperSizeItem>(#iZb.#oVd)));
			return list;
		}

		// Token: 0x06007E63 RID: 32355 RVA: 0x00066F3F File Offset: 0x0006513F
		[CompilerGenerated]
		private #GId #8Zb()
		{
			return #OId.#HId(base.Value);
		}

		// Token: 0x040033C9 RID: 13257
		private readonly Lazy<#GId> #a;

		// Token: 0x040033CA RID: 13258
		[CompilerGenerated]
		private bool #b;

		// Token: 0x02000DAA RID: 3498
		[CompilerGenerated]
		private sealed class #iZb
		{
			// Token: 0x06007E65 RID: 32357 RVA: 0x00066F58 File Offset: 0x00065158
			internal PaperSizeItem #oVd(PaperSize #Rf)
			{
				return new PaperSizeItem(#Rf, \u008D\u0002.~\u0094\u0005(#Rf) == this.#b);
			}

			// Token: 0x040033CB RID: 13259
			public PrinterItem #a;

			// Token: 0x040033CC RID: 13260
			public int #b;
		}
	}
}
