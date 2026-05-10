using System;
using System.Windows;
using System.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000A83 RID: 2691
	public sealed class ButtonDataTemplateSelector : DataTemplateSelector
	{
		// Token: 0x1700190B RID: 6411
		// (get) Token: 0x060057DB RID: 22491 RVA: 0x000488DD File Offset: 0x00046ADD
		// (set) Token: 0x060057DC RID: 22492 RVA: 0x000488E9 File Offset: 0x00046AE9
		public DataTemplate ToggleButtonTemplate { get; set; }

		// Token: 0x1700190C RID: 6412
		// (get) Token: 0x060057DD RID: 22493 RVA: 0x000488FA File Offset: 0x00046AFA
		// (set) Token: 0x060057DE RID: 22494 RVA: 0x00048906 File Offset: 0x00046B06
		public DataTemplate SimpleButtonTemplate { get; set; }

		// Token: 0x060057DF RID: 22495 RVA: 0x00168468 File Offset: 0x00166668
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			bool flag = item is ToggleButtonData;
			ButtonData buttonData = item as ButtonData;
			if (flag)
			{
				return this.ToggleButtonTemplate;
			}
			if (buttonData != null)
			{
				return this.SimpleButtonTemplate;
			}
			return base.SelectTemplate(item, container);
		}
	}
}
