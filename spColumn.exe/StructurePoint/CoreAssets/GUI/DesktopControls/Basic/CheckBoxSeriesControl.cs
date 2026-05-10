using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Basic
{
	// Token: 0x02000ABA RID: 2746
	public sealed class CheckBoxSeriesControl : UserControl, IComponentConnector
	{
		// Token: 0x0600598C RID: 22924 RVA: 0x0016D174 File Offset: 0x0016B374
		public CheckBoxSeriesControl()
		{
			this.InitializeComponent();
			BindingHelper.SetBinding<IEnumerable<ICheckBoxData>>(new BindingHelperParametersContainer<IEnumerable<ICheckBoxData>>
			{
				Target = this.ItemsControl,
				TargetProperty = ItemsControl.ItemsSourceProperty,
				Source = this,
				PropertyExpression = (() => this.CheckBoxes),
				BindingMode = BindingMode.TwoWay
			}, false);
		}

		// Token: 0x17001953 RID: 6483
		// (get) Token: 0x0600598D RID: 22925 RVA: 0x0004A537 File Offset: 0x00048737
		// (set) Token: 0x0600598E RID: 22926 RVA: 0x0004A551 File Offset: 0x00048751
		public IEnumerable<ICheckBoxData> CheckBoxes
		{
			get
			{
				return (IEnumerable<ICheckBoxData>)base.GetValue(CheckBoxSeriesControl.CheckBoxesProperty);
			}
			set
			{
				base.SetValue(CheckBoxSeriesControl.CheckBoxesProperty, value);
			}
		}

		// Token: 0x0600598F RID: 22927 RVA: 0x0016D1F4 File Offset: 0x0016B3F4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107426185), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06005990 RID: 22928 RVA: 0x0004A56B File Offset: 0x0004876B
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.ItemsControl = (ItemsControl)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x04002566 RID: 9574
		public static readonly DependencyProperty CheckBoxesProperty = DependencyProperty.Register(#Phc.#3hc(107426112), typeof(IEnumerable<ICheckBoxData>), typeof(CheckBoxSeriesControl), new PropertyMetadata(null));

		// Token: 0x04002567 RID: 9575
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal ItemsControl ItemsControl;

		// Token: 0x04002568 RID: 9576
		private bool _contentLoaded;
	}
}
