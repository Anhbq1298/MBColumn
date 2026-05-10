using System;
using System.Windows;
using System.Windows.Controls;
using #Hl;

namespace StructurePoint.Products.Column.Core
{
	// Token: 0x020006B3 RID: 1715
	internal sealed class ResourceLInkTemplateSelector : DataTemplateSelector
	{
		// Token: 0x1700118A RID: 4490
		// (get) Token: 0x06003911 RID: 14609 RVA: 0x00031995 File Offset: 0x0002FB95
		// (set) Token: 0x06003912 RID: 14610 RVA: 0x000319A1 File Offset: 0x0002FBA1
		public DataTemplate ReguralTemplate { get; set; }

		// Token: 0x1700118B RID: 4491
		// (get) Token: 0x06003913 RID: 14611 RVA: 0x000319B2 File Offset: 0x0002FBB2
		// (set) Token: 0x06003914 RID: 14612 RVA: 0x000319BE File Offset: 0x0002FBBE
		public DataTemplate WithImageTemplate { get; set; }

		// Token: 0x06003915 RID: 14613 RVA: 0x001111A0 File Offset: 0x0010F3A0
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			#Gl #Gl = item as #Gl;
			#Gl #Gl2;
			if (!false)
			{
				#Gl2 = #Gl;
			}
			if (#Gl2 != null && #Gl2.Image != null)
			{
				return this.WithImageTemplate;
			}
			return this.ReguralTemplate;
		}
	}
}
