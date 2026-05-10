using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon
{
	// Token: 0x020008AD RID: 2221
	public sealed class ButtonsTemplateSelector : DataTemplateSelector
	{
		// Token: 0x17001479 RID: 5241
		// (get) Token: 0x060045FF RID: 17919 RVA: 0x0003A86D File Offset: 0x00038A6D
		// (set) Token: 0x06004600 RID: 17920 RVA: 0x0003A879 File Offset: 0x00038A79
		public DataTemplate Button { get; set; }

		// Token: 0x1700147A RID: 5242
		// (get) Token: 0x06004601 RID: 17921 RVA: 0x0003A88A File Offset: 0x00038A8A
		// (set) Token: 0x06004602 RID: 17922 RVA: 0x0003A896 File Offset: 0x00038A96
		public DataTemplate SplitButton { get; set; }

		// Token: 0x1700147B RID: 5243
		// (get) Token: 0x06004603 RID: 17923 RVA: 0x0003A8A7 File Offset: 0x00038AA7
		// (set) Token: 0x06004604 RID: 17924 RVA: 0x0003A8B3 File Offset: 0x00038AB3
		public DataTemplate ButtonsGroup { get; set; }

		// Token: 0x1700147C RID: 5244
		// (get) Token: 0x06004605 RID: 17925 RVA: 0x0003A8C4 File Offset: 0x00038AC4
		// (set) Token: 0x06004606 RID: 17926 RVA: 0x0003A8D0 File Offset: 0x00038AD0
		public DataTemplate RadioButtonsGroup { get; set; }

		// Token: 0x1700147D RID: 5245
		// (get) Token: 0x06004607 RID: 17927 RVA: 0x0003A8E1 File Offset: 0x00038AE1
		// (set) Token: 0x06004608 RID: 17928 RVA: 0x0003A8ED File Offset: 0x00038AED
		public DataTemplate RibbonRadioButton { get; set; }

		// Token: 0x1700147E RID: 5246
		// (get) Token: 0x06004609 RID: 17929 RVA: 0x0003A8FE File Offset: 0x00038AFE
		// (set) Token: 0x0600460A RID: 17930 RVA: 0x0003A90A File Offset: 0x00038B0A
		public DataTemplate RibbonToggleButtonGroup { get; set; }

		// Token: 0x1700147F RID: 5247
		// (get) Token: 0x0600460B RID: 17931 RVA: 0x0003A91B File Offset: 0x00038B1B
		// (set) Token: 0x0600460C RID: 17932 RVA: 0x0003A927 File Offset: 0x00038B27
		public DataTemplate RibbonToggleButton { get; set; }

		// Token: 0x0600460D RID: 17933 RVA: 0x0013D69C File Offset: 0x0013B89C
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			if (item is RibbonSplitButton)
			{
				return this.SplitButton;
			}
			if (item is RibbonRadioButtonGroup)
			{
				return this.RadioButtonsGroup;
			}
			if (item is RibbonButtonGroup)
			{
				return this.ButtonsGroup;
			}
			if (item is RibbonRadioButton)
			{
				return this.RibbonRadioButton;
			}
			if (item is RibbonToggleButtonGroup)
			{
				return this.RibbonToggleButtonGroup;
			}
			if (item is RibbonToggleButton)
			{
				return this.RibbonToggleButton;
			}
			return this.Button;
		}
	}
}
