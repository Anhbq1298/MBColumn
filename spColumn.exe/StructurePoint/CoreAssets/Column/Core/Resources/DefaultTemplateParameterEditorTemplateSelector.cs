using System;
using System.Windows;
using System.Windows.Controls;
using StructurePoint.CoreAssets.AppManager.Column.Templates;
using StructurePoint.CoreAssets.Column.Core.ViewModels.Templates;

namespace StructurePoint.CoreAssets.Column.Core.Resources
{
	// Token: 0x0200086C RID: 2156
	public sealed class DefaultTemplateParameterEditorTemplateSelector : DataTemplateSelector
	{
		// Token: 0x1700141B RID: 5147
		// (get) Token: 0x0600447D RID: 17533 RVA: 0x0003925C File Offset: 0x0003745C
		// (set) Token: 0x0600447E RID: 17534 RVA: 0x00039264 File Offset: 0x00037464
		public DataTemplate DoubleValueTemplate { get; set; }

		// Token: 0x1700141C RID: 5148
		// (get) Token: 0x0600447F RID: 17535 RVA: 0x0003926D File Offset: 0x0003746D
		// (set) Token: 0x06004480 RID: 17536 RVA: 0x00039275 File Offset: 0x00037475
		public DataTemplate SelectIntegerTemplate { get; set; }

		// Token: 0x1700141D RID: 5149
		// (get) Token: 0x06004481 RID: 17537 RVA: 0x0003927E File Offset: 0x0003747E
		// (set) Token: 0x06004482 RID: 17538 RVA: 0x00039286 File Offset: 0x00037486
		public DataTemplate IntegerTemplate { get; set; }

		// Token: 0x1700141E RID: 5150
		// (get) Token: 0x06004483 RID: 17539 RVA: 0x0003928F File Offset: 0x0003748F
		// (set) Token: 0x06004484 RID: 17540 RVA: 0x00039297 File Offset: 0x00037497
		public DataTemplate BooleanTemplate { get; set; }

		// Token: 0x1700141F RID: 5151
		// (get) Token: 0x06004485 RID: 17541 RVA: 0x000392A0 File Offset: 0x000374A0
		// (set) Token: 0x06004486 RID: 17542 RVA: 0x000392A8 File Offset: 0x000374A8
		public DataTemplate BarSizeTemplate { get; set; }

		// Token: 0x17001420 RID: 5152
		// (get) Token: 0x06004487 RID: 17543 RVA: 0x000392B1 File Offset: 0x000374B1
		// (set) Token: 0x06004488 RID: 17544 RVA: 0x000392B9 File Offset: 0x000374B9
		public DataTemplate DoubleListTemplate { get; set; }

		// Token: 0x17001421 RID: 5153
		// (get) Token: 0x06004489 RID: 17545 RVA: 0x000392C2 File Offset: 0x000374C2
		// (set) Token: 0x0600448A RID: 17546 RVA: 0x000392CA File Offset: 0x000374CA
		public DataTemplate GenericListTemplate { get; set; }

		// Token: 0x0600448B RID: 17547 RVA: 0x0013BD48 File Offset: 0x00139F48
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			TemplateParameterViewModelBase templateParameterViewModelBase = item as TemplateParameterViewModelBase;
			if (templateParameterViewModelBase == null)
			{
				return base.SelectTemplate(item, container);
			}
			switch (templateParameterViewModelBase.ParameterType)
			{
			case TemplateParameterType.Integer:
				return this.IntegerTemplate;
			case TemplateParameterType.Double:
				return this.DoubleValueTemplate;
			case TemplateParameterType.Boolean:
				return this.BooleanTemplate;
			case TemplateParameterType.BarSize:
				return this.BarSizeTemplate;
			case TemplateParameterType.IntegerList:
				return this.SelectIntegerTemplate;
			case TemplateParameterType.DoubleList:
				return this.DoubleListTemplate;
			case TemplateParameterType.List:
				return this.GenericListTemplate;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}
}
