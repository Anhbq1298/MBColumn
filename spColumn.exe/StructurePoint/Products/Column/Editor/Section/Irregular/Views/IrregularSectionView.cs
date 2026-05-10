using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using #3yb;
using #6yb;
using #7hc;
using #cMb;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.Editor.Section.Irregular.Views
{
	// Token: 0x020004CE RID: 1230
	internal sealed class IrregularSectionView : ColumnBaseView, IComponentConnector, IStyleConnector, IView, #2yb
	{
		// Token: 0x06002D35 RID: 11573 RVA: 0x00028808 File Offset: 0x00026A08
		public IrregularSectionView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06002D36 RID: 11574 RVA: 0x00028816 File Offset: 0x00026A16
		private void ItemsControlSelector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.CircleTypesDropDown.IsOpen = false;
		}

		// Token: 0x06002D37 RID: 11575 RVA: 0x000EDBD0 File Offset: 0x000EBDD0
		private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			#dzb #dzb = base.DataContext as #dzb;
			if (#dzb != null)
			{
				#cOb #cOb = #dzb.Toolbar.AddCircleSlabWrapper;
				if (!#cOb.IsSelected)
				{
					#dzb.Toolbar.#8vb(#cOb);
					this.CircleTypesDropDown.IsOpen = false;
				}
			}
		}

		// Token: 0x06002D38 RID: 11576 RVA: 0x000EDC24 File Offset: 0x000EBE24
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107356596), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06002D39 RID: 11577 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06002D3A RID: 11578 RVA: 0x000EDC68 File Offset: 0x000EBE68
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.CircleTypesBorder = (Border)target;
				return;
			case 2:
				this.CircleTypesButton = (RadRadioButton)target;
				return;
			case 3:
				this.CircleTypesDropDown = (RadDropDownButton)target;
				return;
			case 4:
				((RadListBox)target).SelectionChanged += this.ItemsControlSelector_OnSelectionChanged;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x06002D3B RID: 11579 RVA: 0x0002882C File Offset: 0x00026A2C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 5)
			{
				((Grid)target).MouseLeftButtonDown += this.UIElement_OnMouseLeftButtonDown;
			}
		}

		// Token: 0x0400123F RID: 4671
		internal Border CircleTypesBorder;

		// Token: 0x04001240 RID: 4672
		internal RadRadioButton CircleTypesButton;

		// Token: 0x04001241 RID: 4673
		internal RadDropDownButton CircleTypesDropDown;

		// Token: 0x04001242 RID: 4674
		private bool _contentLoaded;
	}
}
