using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using #7hc;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.FailureSurface.Views
{
	// Token: 0x020003EF RID: 1007
	internal sealed class LeftPanelView : ColumnBaseView, IComponentConnector, IView, ILeftPanelView
	{
		// Token: 0x060022CB RID: 8907 RVA: 0x000CB32C File Offset: 0x000C952C
		public LeftPanelView()
		{
			this.InitializeComponent();
			this.AxialLoadComboBox.DropDownClosed += this.ComboBox_DropDownClosed;
			this.AngleComboBox.DropDownClosed += this.ComboBox_DropDownClosed;
			this.AxialLoadComboBox.KeyDown += this.AxialLoadComboBox_KeyDown;
			this.AngleComboBox.KeyDown += this.AxialLoadComboBox_KeyDown;
		}

		// Token: 0x060022CC RID: 8908 RVA: 0x000218F0 File Offset: 0x0001FAF0
		private void AxialLoadComboBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				((FrameworkElement)sender).UpdateBindingSource(RadComboBox.TextProperty);
			}
		}

		// Token: 0x060022CD RID: 8909 RVA: 0x00021918 File Offset: 0x0001FB18
		private void ComboBox_DropDownClosed(object sender, EventArgs e)
		{
			((FrameworkElement)sender).UpdateBindingSource(RadComboBox.TextProperty);
		}

		// Token: 0x060022CE RID: 8910 RVA: 0x000CB3A4 File Offset: 0x000C95A4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107362867), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060022CF RID: 8911 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060022D0 RID: 8912 RVA: 0x000CB3E8 File Offset: 0x000C95E8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.NavigatePanel = (Border)target;
				return;
			case 2:
				this.NavigationRowGrid = (Grid)target;
				return;
			case 3:
				this.NavigationRow = (RowDefinition)target;
				return;
			case 4:
				this.AngleComboBox = (CustomRadComboBox)target;
				return;
			case 5:
				this.AxialLoadComboBox = (CustomRadComboBox)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x060022D1 RID: 8913 RVA: 0x00021771 File Offset: 0x0001F971
		void ILeftPanelView.add_SizeChanged(SizeChangedEventHandler value)
		{
			base.SizeChanged += value;
		}

		// Token: 0x060022D2 RID: 8914 RVA: 0x00021786 File Offset: 0x0001F986
		void ILeftPanelView.remove_SizeChanged(SizeChangedEventHandler value)
		{
			base.SizeChanged -= value;
		}

		// Token: 0x04000DE3 RID: 3555
		internal Border NavigatePanel;

		// Token: 0x04000DE4 RID: 3556
		internal Grid NavigationRowGrid;

		// Token: 0x04000DE5 RID: 3557
		internal RowDefinition NavigationRow;

		// Token: 0x04000DE6 RID: 3558
		internal CustomRadComboBox AngleComboBox;

		// Token: 0x04000DE7 RID: 3559
		internal CustomRadComboBox AxialLoadComboBox;

		// Token: 0x04000DE8 RID: 3560
		private bool _contentLoaded;
	}
}
