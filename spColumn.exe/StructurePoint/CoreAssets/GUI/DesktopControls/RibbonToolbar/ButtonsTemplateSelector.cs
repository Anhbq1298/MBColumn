using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.RibbonToolbar
{
	// Token: 0x02000903 RID: 2307
	internal sealed class ButtonsTemplateSelector : DataTemplateSelector
	{
		// Token: 0x17001589 RID: 5513
		// (get) Token: 0x0600497F RID: 18815 RVA: 0x0003E02C File Offset: 0x0003C22C
		// (set) Token: 0x06004980 RID: 18816 RVA: 0x0003E038 File Offset: 0x0003C238
		public DataTemplate Button { get; set; }

		// Token: 0x1700158A RID: 5514
		// (get) Token: 0x06004981 RID: 18817 RVA: 0x0003E049 File Offset: 0x0003C249
		// (set) Token: 0x06004982 RID: 18818 RVA: 0x0003E055 File Offset: 0x0003C255
		public DataTemplate RadioButton { get; set; }

		// Token: 0x1700158B RID: 5515
		// (get) Token: 0x06004983 RID: 18819 RVA: 0x0003E066 File Offset: 0x0003C266
		// (set) Token: 0x06004984 RID: 18820 RVA: 0x0003E072 File Offset: 0x0003C272
		public DataTemplate ToggleButton { get; set; }

		// Token: 0x1700158C RID: 5516
		// (get) Token: 0x06004985 RID: 18821 RVA: 0x0003E083 File Offset: 0x0003C283
		// (set) Token: 0x06004986 RID: 18822 RVA: 0x0003E08F File Offset: 0x0003C28F
		public DataTemplate ButtonsGroup { get; set; }

		// Token: 0x1700158D RID: 5517
		// (get) Token: 0x06004987 RID: 18823 RVA: 0x0003E0A0 File Offset: 0x0003C2A0
		// (set) Token: 0x06004988 RID: 18824 RVA: 0x0003E0AC File Offset: 0x0003C2AC
		public DataTemplate DropDownRadioButton { get; set; }

		// Token: 0x06004989 RID: 18825 RVA: 0x00145048 File Offset: 0x00143248
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			if (item is RibbonToolbarButtonGroup)
			{
				return this.ButtonsGroup;
			}
			if (item is IRibbonToolbarDropDownRadioButton)
			{
				return this.DropDownRadioButton;
			}
			if (item is IRibbonToolbarRadioButton)
			{
				return this.RadioButton;
			}
			if (item is IRibbonToolbarToggleButton)
			{
				return this.ToggleButton;
			}
			return this.Button;
		}
	}
}
