using System;
using System.Runtime.CompilerServices;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Printing
{
	// Token: 0x02000D9F RID: 3487
	public sealed class PageMarginsSpecification
	{
		// Token: 0x06007E30 RID: 32304 RVA: 0x00066BEE File Offset: 0x00064DEE
		public PageMarginsSpecification(PageMarginType marginType, string displayValue, double left, double top, double right, double bottom)
		{
			this.MarginType = marginType;
			this.DisplayValue = displayValue;
			this.Left = left;
			this.Top = top;
			this.Right = right;
			this.Bottom = bottom;
		}

		// Token: 0x06007E31 RID: 32305 RVA: 0x000035C3 File Offset: 0x000017C3
		public PageMarginsSpecification()
		{
		}

		// Token: 0x170025D0 RID: 9680
		// (get) Token: 0x06007E32 RID: 32306 RVA: 0x00066C23 File Offset: 0x00064E23
		// (set) Token: 0x06007E33 RID: 32307 RVA: 0x00066C2F File Offset: 0x00064E2F
		public PageMarginType MarginType { get; set; }

		// Token: 0x170025D1 RID: 9681
		// (get) Token: 0x06007E34 RID: 32308 RVA: 0x00066C40 File Offset: 0x00064E40
		// (set) Token: 0x06007E35 RID: 32309 RVA: 0x00066C4C File Offset: 0x00064E4C
		public string DisplayValue { get; set; }

		// Token: 0x170025D2 RID: 9682
		// (get) Token: 0x06007E36 RID: 32310 RVA: 0x00066C5D File Offset: 0x00064E5D
		// (set) Token: 0x06007E37 RID: 32311 RVA: 0x00066C69 File Offset: 0x00064E69
		public double Left { get; set; }

		// Token: 0x170025D3 RID: 9683
		// (get) Token: 0x06007E38 RID: 32312 RVA: 0x00066C7A File Offset: 0x00064E7A
		// (set) Token: 0x06007E39 RID: 32313 RVA: 0x00066C86 File Offset: 0x00064E86
		public double Top { get; set; }

		// Token: 0x170025D4 RID: 9684
		// (get) Token: 0x06007E3A RID: 32314 RVA: 0x00066C97 File Offset: 0x00064E97
		// (set) Token: 0x06007E3B RID: 32315 RVA: 0x00066CA3 File Offset: 0x00064EA3
		public double Right { get; set; }

		// Token: 0x170025D5 RID: 9685
		// (get) Token: 0x06007E3C RID: 32316 RVA: 0x00066CB4 File Offset: 0x00064EB4
		// (set) Token: 0x06007E3D RID: 32317 RVA: 0x00066CC0 File Offset: 0x00064EC0
		public double Bottom { get; set; }

		// Token: 0x06007E3E RID: 32318 RVA: 0x001BC06C File Offset: 0x001BA26C
		public PageMarginsSpecification #mg(PageMarginsSpecification #wId)
		{
			if (#wId == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107281070));
			}
			this.MarginType = #wId.MarginType;
			this.DisplayValue = #wId.DisplayValue;
			this.Left = #wId.Left;
			this.Top = #wId.Top;
			this.Right = #wId.Right;
			this.Bottom = #wId.Bottom;
			return this;
		}

		// Token: 0x06007E3F RID: 32319 RVA: 0x001BC0E4 File Offset: 0x001BA2E4
		public PageMarginsSpecification #xId(bool #yId)
		{
			PageMarginsSpecification pageMarginsSpecification = new PageMarginsSpecification();
			pageMarginsSpecification.#mg(this);
			if (#yId)
			{
				pageMarginsSpecification.Left *= 72.0;
				pageMarginsSpecification.Top *= 72.0;
				pageMarginsSpecification.Right *= 72.0;
				pageMarginsSpecification.Bottom *= 72.0;
			}
			else
			{
				double num = 2.834645669291339;
				pageMarginsSpecification.Left *= num;
				pageMarginsSpecification.Top *= num;
				pageMarginsSpecification.Right *= num;
				pageMarginsSpecification.Bottom *= num;
			}
			return pageMarginsSpecification;
		}

		// Token: 0x040033A8 RID: 13224
		[CompilerGenerated]
		private PageMarginType #a;

		// Token: 0x040033A9 RID: 13225
		[CompilerGenerated]
		private string #b;

		// Token: 0x040033AA RID: 13226
		[CompilerGenerated]
		private double #c;

		// Token: 0x040033AB RID: 13227
		[CompilerGenerated]
		private double #d;

		// Token: 0x040033AC RID: 13228
		[CompilerGenerated]
		private double #e;

		// Token: 0x040033AD RID: 13229
		[CompilerGenerated]
		private double #f;
	}
}
