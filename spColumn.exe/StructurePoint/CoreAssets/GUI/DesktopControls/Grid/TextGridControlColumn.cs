using System;
using System.Windows;
using System.Windows.Media;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Grid
{
	// Token: 0x020009C2 RID: 2498
	internal sealed class TextGridControlColumn : GridViewDataColumn, IGridControlColumn
	{
		// Token: 0x1700174E RID: 5966
		// (get) Token: 0x06005136 RID: 20790 RVA: 0x0004378F File Offset: 0x0004198F
		// (set) Token: 0x06005137 RID: 20791 RVA: 0x000439F6 File Offset: 0x00041BF6
		public GridViewLength ColumnWidth
		{
			get
			{
				return GridViewLength.CreateFromProviderValue(base.Width);
			}
			set
			{
				#X0d.#V0d(value, #Phc.#3hc(107386484), Component.DesktopControls, #Phc.#3hc(107465511));
				base.Width = value.ConvertToProviderValue();
			}
		}

		// Token: 0x1700174F RID: 5967
		// (get) Token: 0x06005138 RID: 20792 RVA: 0x00043723 File Offset: 0x00041923
		// (set) Token: 0x06005139 RID: 20793 RVA: 0x00043733 File Offset: 0x00041933
		public HelpID HelpId
		{
			get
			{
				return ContextualHelp.GetHelpID(this);
			}
			set
			{
				ContextualHelp.SetHelpID(this, value);
			}
		}

		// Token: 0x17001750 RID: 5968
		// (get) Token: 0x0600513A RID: 20794 RVA: 0x00043748 File Offset: 0x00041948
		// (set) Token: 0x0600513B RID: 20795 RVA: 0x0004376B File Offset: 0x0004196B
		public bool UseGridHelpId
		{
			get
			{
				return ContextualHelp.GetParentElementType(this) == typeof(GridControl);
			}
			set
			{
				ContextualHelp.SetParentElementType(this, value ? typeof(GridControl) : null);
			}
		}

		// Token: 0x0600513C RID: 20796 RVA: 0x0015F890 File Offset: 0x0015DA90
		public override FrameworkElement CreateCellEditElement(GridViewCell cell, object dataItem)
		{
			FrameworkElement frameworkElement = base.CreateCellEditElement(cell, dataItem);
			if (frameworkElement != null)
			{
				frameworkElement.SetValue(ContextualHelp.HelpIDProperty, this.HelpId);
				frameworkElement.SetValue(ContextualHelp.ParentElementTypeProperty, ContextualHelp.GetParentElementType(this));
			}
			return frameworkElement;
		}

		// Token: 0x0600513E RID: 20798 RVA: 0x00043913 File Offset: 0x00041B13
		void IGridControlColumn.set_MinWidth(double value)
		{
			base.MinWidth = value;
		}

		// Token: 0x0600513F RID: 20799 RVA: 0x00043928 File Offset: 0x00041B28
		void IGridControlColumn.set_MaxWidth(double value)
		{
			base.MaxWidth = value;
		}

		// Token: 0x06005140 RID: 20800 RVA: 0x0004393D File Offset: 0x00041B3D
		Style IGridControlColumn.get_HeaderCellStyle()
		{
			return base.HeaderCellStyle;
		}

		// Token: 0x06005141 RID: 20801 RVA: 0x0004394D File Offset: 0x00041B4D
		void IGridControlColumn.set_HeaderCellStyle(Style value)
		{
			base.HeaderCellStyle = value;
		}

		// Token: 0x06005142 RID: 20802 RVA: 0x00043962 File Offset: 0x00041B62
		Style IGridControlColumn.get_EditorStyle()
		{
			return base.EditorStyle;
		}

		// Token: 0x06005143 RID: 20803 RVA: 0x00043972 File Offset: 0x00041B72
		void IGridControlColumn.set_EditorStyle(Style value)
		{
			base.EditorStyle = value;
		}

		// Token: 0x06005144 RID: 20804 RVA: 0x00043987 File Offset: 0x00041B87
		Brush IGridControlColumn.get_Background()
		{
			return base.Background;
		}

		// Token: 0x06005145 RID: 20805 RVA: 0x00043997 File Offset: 0x00041B97
		void IGridControlColumn.set_Background(Brush value)
		{
			base.Background = value;
		}

		// Token: 0x06005146 RID: 20806 RVA: 0x000439AC File Offset: 0x00041BAC
		string IGridControlColumn.get_FilterMemberPath()
		{
			return base.FilterMemberPath;
		}

		// Token: 0x06005147 RID: 20807 RVA: 0x000439BC File Offset: 0x00041BBC
		void IGridControlColumn.set_FilterMemberPath(string value)
		{
			base.FilterMemberPath = value;
		}

		// Token: 0x06005148 RID: 20808 RVA: 0x000439D1 File Offset: 0x00041BD1
		Type IGridControlColumn.get_FilterMemberType()
		{
			return base.FilterMemberType;
		}

		// Token: 0x06005149 RID: 20809 RVA: 0x000439E1 File Offset: 0x00041BE1
		void IGridControlColumn.set_FilterMemberType(Type value)
		{
			base.FilterMemberType = value;
		}
	}
}
