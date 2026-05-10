using System;
using System.Windows;
using System.Windows.Controls;
using #7Pb;

namespace StructurePoint.Products.Column.Core.Status
{
	// Token: 0x020006B6 RID: 1718
	internal sealed class StatusBarItemTemplateSelector : DataTemplateSelector
	{
		// Token: 0x17001191 RID: 4497
		// (get) Token: 0x06003922 RID: 14626 RVA: 0x00031A13 File Offset: 0x0002FC13
		// (set) Token: 0x06003923 RID: 14627 RVA: 0x00031A1F File Offset: 0x0002FC1F
		public DataTemplate RegularItemTemplate { get; set; }

		// Token: 0x17001192 RID: 4498
		// (get) Token: 0x06003924 RID: 14628 RVA: 0x00031A30 File Offset: 0x0002FC30
		// (set) Token: 0x06003925 RID: 14629 RVA: 0x00031A3C File Offset: 0x0002FC3C
		public DataTemplate SeparatorItemTemplate { get; set; }

		// Token: 0x06003926 RID: 14630 RVA: 0x0011148C File Offset: 0x0010F68C
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			#nQb #nQb = item as #nQb;
			#nQb #nQb2;
			if (!false)
			{
				#nQb2 = #nQb;
			}
			if (#nQb2 == null)
			{
				return null;
			}
			if (!#nQb2.IsSeparator)
			{
				return this.RegularItemTemplate;
			}
			return this.SeparatorItemTemplate;
		}
	}
}
