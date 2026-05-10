using System;
using System.Windows;
using System.Windows.Controls;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Toolbox
{
	// Token: 0x020008E8 RID: 2280
	internal sealed class EditionToolDataTemplateSelector : DataTemplateSelector
	{
		// Token: 0x17001532 RID: 5426
		// (get) Token: 0x0600486F RID: 18543 RVA: 0x0003D023 File Offset: 0x0003B223
		// (set) Token: 0x06004870 RID: 18544 RVA: 0x0003D02F File Offset: 0x0003B22F
		public DataTemplate SimpleToolDataTemplate { get; set; }

		// Token: 0x17001533 RID: 5427
		// (get) Token: 0x06004871 RID: 18545 RVA: 0x0003D040 File Offset: 0x0003B240
		// (set) Token: 0x06004872 RID: 18546 RVA: 0x0003D04C File Offset: 0x0003B24C
		public DataTemplate GroupingToolDataTemplate { get; set; }

		// Token: 0x06004873 RID: 18547 RVA: 0x00143988 File Offset: 0x00141B88
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			bool flag = item is IGroupingEditionToolData;
			bool flag2 = item is IEditionToolData;
			if (flag)
			{
				return this.GroupingToolDataTemplate;
			}
			if (!flag2)
			{
				return base.SelectTemplate(item, container);
			}
			return this.SimpleToolDataTemplate;
		}
	}
}
