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
	// Token: 0x02000A84 RID: 2692
	public sealed class ButtonSeriesControl : UserControl, IComponentConnector
	{
		// Token: 0x060057E1 RID: 22497 RVA: 0x001684AC File Offset: 0x001666AC
		public ButtonSeriesControl()
		{
			this.InitializeComponent();
			BindingHelper.SetBinding<IEnumerable<IButtonData>>(new BindingHelperParametersContainer<IEnumerable<IButtonData>>
			{
				Target = this.ItemsControl,
				TargetProperty = ItemsControl.ItemsSourceProperty,
				Source = this,
				PropertyExpression = (() => this.Buttons),
				BindingMode = BindingMode.TwoWay
			}, false);
		}

		// Token: 0x1700190D RID: 6413
		// (get) Token: 0x060057E2 RID: 22498 RVA: 0x00048917 File Offset: 0x00046B17
		// (set) Token: 0x060057E3 RID: 22499 RVA: 0x00048931 File Offset: 0x00046B31
		public IEnumerable<IButtonData> Buttons
		{
			get
			{
				return (IEnumerable<IButtonData>)base.GetValue(ButtonSeriesControl.ButtonsProperty);
			}
			set
			{
				base.SetValue(ButtonSeriesControl.ButtonsProperty, value);
			}
		}

		// Token: 0x060057E4 RID: 22500 RVA: 0x0016852C File Offset: 0x0016672C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107428751), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060057E5 RID: 22501 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060057E6 RID: 22502 RVA: 0x0004894B File Offset: 0x00046B4B
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

		// Token: 0x040024CD RID: 9421
		public static readonly DependencyProperty ButtonsProperty = DependencyProperty.Register(#Phc.#3hc(107428682), typeof(IEnumerable<IButtonData>), typeof(ButtonSeriesControl), new PropertyMetadata(null));

		// Token: 0x040024CE RID: 9422
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal ItemsControl ItemsControl;

		// Token: 0x040024CF RID: 9423
		private bool _contentLoaded;
	}
}
