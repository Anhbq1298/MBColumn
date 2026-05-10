using System;
using System.Runtime.CompilerServices;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Printing.Presentation
{
	// Token: 0x02000DB1 RID: 3505
	public sealed class PageMarginsViewModel : NotifyPropertyChangedObjectBase
	{
		// Token: 0x170025F7 RID: 9719
		// (get) Token: 0x06007EA7 RID: 32423 RVA: 0x00067446 File Offset: 0x00065646
		// (set) Token: 0x06007EA8 RID: 32424 RVA: 0x00067452 File Offset: 0x00065652
		public PageMarginType Key { get; set; }

		// Token: 0x170025F8 RID: 9720
		// (get) Token: 0x06007EA9 RID: 32425 RVA: 0x00067463 File Offset: 0x00065663
		// (set) Token: 0x06007EAA RID: 32426 RVA: 0x0006746F File Offset: 0x0006566F
		public string DisplayValue { get; set; }

		// Token: 0x170025F9 RID: 9721
		// (get) Token: 0x06007EAB RID: 32427 RVA: 0x00067480 File Offset: 0x00065680
		// (set) Token: 0x06007EAC RID: 32428 RVA: 0x0006748C File Offset: 0x0006568C
		public double Left { get; set; }

		// Token: 0x170025FA RID: 9722
		// (get) Token: 0x06007EAD RID: 32429 RVA: 0x0006749D File Offset: 0x0006569D
		// (set) Token: 0x06007EAE RID: 32430 RVA: 0x000674A9 File Offset: 0x000656A9
		public double Top { get; set; }

		// Token: 0x170025FB RID: 9723
		// (get) Token: 0x06007EAF RID: 32431 RVA: 0x000674BA File Offset: 0x000656BA
		// (set) Token: 0x06007EB0 RID: 32432 RVA: 0x000674C6 File Offset: 0x000656C6
		public double Right { get; set; }

		// Token: 0x170025FC RID: 9724
		// (get) Token: 0x06007EB1 RID: 32433 RVA: 0x000674D7 File Offset: 0x000656D7
		// (set) Token: 0x06007EB2 RID: 32434 RVA: 0x000674E3 File Offset: 0x000656E3
		public double Bottom { get; set; }

		// Token: 0x06007EB3 RID: 32435 RVA: 0x001BCB58 File Offset: 0x001BAD58
		public PageMarginsViewModel #mg(PageMarginsSpecification #wId)
		{
			if (#wId == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107281070));
			}
			this.Key = #wId.MarginType;
			this.DisplayValue = #wId.DisplayValue;
			this.Left = #wId.Left;
			this.Top = #wId.Top;
			this.Right = #wId.Right;
			this.Bottom = #wId.Bottom;
			return this;
		}

		// Token: 0x06007EB4 RID: 32436 RVA: 0x001BCBD0 File Offset: 0x001BADD0
		public PageMarginsSpecification #77c(PageMarginsSpecification #wId)
		{
			if (#wId == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107281070));
			}
			#wId.MarginType = this.Key;
			#wId.DisplayValue = this.DisplayValue;
			#wId.Left = this.Left;
			#wId.Right = this.Right;
			#wId.Top = this.Top;
			#wId.Bottom = this.Bottom;
			return #wId;
		}

		// Token: 0x040033EB RID: 13291
		[CompilerGenerated]
		private PageMarginType #a;

		// Token: 0x040033EC RID: 13292
		[CompilerGenerated]
		private string #b;

		// Token: 0x040033ED RID: 13293
		[CompilerGenerated]
		private double #c;

		// Token: 0x040033EE RID: 13294
		[CompilerGenerated]
		private double #d;

		// Token: 0x040033EF RID: 13295
		[CompilerGenerated]
		private double #e;

		// Token: 0x040033F0 RID: 13296
		[CompilerGenerated]
		private double #f;
	}
}
