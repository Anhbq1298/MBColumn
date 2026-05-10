using System;
using System.Drawing.Printing;
using System.Runtime.CompilerServices;
using #7hc;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Printing
{
	// Token: 0x02000DA5 RID: 3493
	public sealed class PaperSizeItem : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06007E48 RID: 32328 RVA: 0x00066D8F File Offset: 0x00064F8F
		public PaperSizeItem(System.Drawing.Printing.PaperSize paperSize, bool isDefault)
		{
			if (paperSize == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107281293));
			}
			this.PaperSize = paperSize;
			this.IsDefault = isDefault;
			this.DisplayValue = paperSize.PaperName;
		}

		// Token: 0x06007E49 RID: 32329 RVA: 0x00066DC4 File Offset: 0x00064FC4
		public PaperSizeItem(Aspose.Words.PaperSize paperSize, bool isDefault)
		{
			this.AsposePaperSize = new Aspose.Words.PaperSize?(paperSize);
			this.IsDefault = isDefault;
			this.DisplayValue = paperSize.ToString();
		}

		// Token: 0x170025D6 RID: 9686
		// (get) Token: 0x06007E4A RID: 32330 RVA: 0x00066DF2 File Offset: 0x00064FF2
		// (set) Token: 0x06007E4B RID: 32331 RVA: 0x00066DFE File Offset: 0x00064FFE
		public System.Drawing.Printing.PaperSize PaperSize { get; private set; }

		// Token: 0x170025D7 RID: 9687
		// (get) Token: 0x06007E4C RID: 32332 RVA: 0x00066E0F File Offset: 0x0006500F
		// (set) Token: 0x06007E4D RID: 32333 RVA: 0x00066E1B File Offset: 0x0006501B
		public Aspose.Words.PaperSize? AsposePaperSize { get; private set; }

		// Token: 0x170025D8 RID: 9688
		// (get) Token: 0x06007E4E RID: 32334 RVA: 0x00066E2C File Offset: 0x0006502C
		// (set) Token: 0x06007E4F RID: 32335 RVA: 0x00066E38 File Offset: 0x00065038
		public bool IsDefault { get; private set; }

		// Token: 0x170025D9 RID: 9689
		// (get) Token: 0x06007E50 RID: 32336 RVA: 0x00066E49 File Offset: 0x00065049
		// (set) Token: 0x06007E51 RID: 32337 RVA: 0x00066E55 File Offset: 0x00065055
		public string DisplayValue { get; private set; }

		// Token: 0x040033BC RID: 13244
		[CompilerGenerated]
		private System.Drawing.Printing.PaperSize #a;

		// Token: 0x040033BD RID: 13245
		[CompilerGenerated]
		private Aspose.Words.PaperSize? #b;

		// Token: 0x040033BE RID: 13246
		[CompilerGenerated]
		private bool #c;

		// Token: 0x040033BF RID: 13247
		[CompilerGenerated]
		private string #d;
	}
}
