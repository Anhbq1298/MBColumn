using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.Views.Common
{
	// Token: 0x02000092 RID: 146
	internal sealed class WindowOkCancelButtons : UserControl, IComponentConnector
	{
		// Token: 0x060004AE RID: 1198 RVA: 0x0000993D File Offset: 0x00007B3D
		public WindowOkCancelButtons()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x060004AF RID: 1199 RVA: 0x0000994B File Offset: 0x00007B4B
		// (set) Token: 0x060004B0 RID: 1200 RVA: 0x00009965 File Offset: 0x00007B65
		public DelegateCommand ResetCommand
		{
			get
			{
				return (DelegateCommand)base.GetValue(WindowOkCancelButtons.ResetCommandProperty);
			}
			set
			{
				base.SetValue(WindowOkCancelButtons.ResetCommandProperty, value);
			}
		}

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x060004B1 RID: 1201 RVA: 0x0000997F File Offset: 0x00007B7F
		// (set) Token: 0x060004B2 RID: 1202 RVA: 0x00009999 File Offset: 0x00007B99
		public DelegateCommand ApplyCommand
		{
			get
			{
				return (DelegateCommand)base.GetValue(WindowOkCancelButtons.ApplyCommandProperty);
			}
			set
			{
				base.SetValue(WindowOkCancelButtons.ApplyCommandProperty, value);
			}
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x00088694 File Offset: 0x00086894
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107384808), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x000099B3 File Offset: 0x00007BB3
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040000DE RID: 222
		public static readonly DependencyProperty ResetCommandProperty = DependencyProperty.Register(#Phc.#3hc(107384435), typeof(DelegateCommand), typeof(WindowOkCancelButtons), new PropertyMetadata(null));

		// Token: 0x040000DF RID: 223
		public static readonly DependencyProperty ApplyCommandProperty = DependencyProperty.Register(#Phc.#3hc(107384386), typeof(DelegateCommand), typeof(WindowOkCancelButtons), new PropertyMetadata(null));

		// Token: 0x040000E0 RID: 224
		private bool _contentLoaded;
	}
}
