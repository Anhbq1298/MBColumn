using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Printing;

namespace #hId
{
	// Token: 0x02000DAC RID: 3500
	internal sealed class #kJd : PrinterItem
	{
		// Token: 0x06007E86 RID: 32390 RVA: 0x00067150 File Offset: 0x00065350
		public #kJd() : base(#Phc.#3hc(107280582), #Phc.#3hc(107280593))
		{
			base.IsRealDevice = false;
		}

		// Token: 0x170025ED RID: 9709
		// (get) Token: 0x06007E87 RID: 32391 RVA: 0x00003375 File Offset: 0x00001575
		public override bool IsReady
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170025EE RID: 9710
		// (get) Token: 0x06007E88 RID: 32392 RVA: 0x0000C78B File Offset: 0x0000A98B
		public override #GId PrinterStatus
		{
			get
			{
				return #GId.#a;
			}
		}

		// Token: 0x06007E89 RID: 32393 RVA: 0x001BC89C File Offset: 0x001BAA9C
		public override IReadOnlyList<PaperSizeItem> #UId()
		{
			#kJd.#MZb #MZb = new #kJd.#MZb();
			List<PaperSizeItem> list = new List<PaperSizeItem>();
			#MZb.#a = (CultureInfo.CurrentCulture.Name.Contains(#Phc.#3hc(107280572)) ? PaperSize.Letter : PaperSize.A4);
			list.AddRange(Enum.GetValues(typeof(PaperSize)).OfType<PaperSize>().Select(new Func<PaperSize, PaperSizeItem>(#MZb.#pVd)));
			return list;
		}

		// Token: 0x02000DAD RID: 3501
		[CompilerGenerated]
		private sealed class #MZb
		{
			// Token: 0x06007E8B RID: 32395 RVA: 0x00067173 File Offset: 0x00065373
			internal PaperSizeItem #pVd(PaperSize #Rf)
			{
				return new PaperSizeItem(#Rf, #Rf == this.#a);
			}

			// Token: 0x040033DC RID: 13276
			public PaperSize #a;
		}
	}
}
