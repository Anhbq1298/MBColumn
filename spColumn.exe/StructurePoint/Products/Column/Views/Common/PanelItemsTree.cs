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
	// Token: 0x02000090 RID: 144
	internal sealed class PanelItemsTree : UserControl, IComponentConnector
	{
		// Token: 0x0600049C RID: 1180 RVA: 0x0000982D File Offset: 0x00007A2D
		public PanelItemsTree()
		{
			this.InitializeComponent();
		}

		// Token: 0x1700028D RID: 653
		// (get) Token: 0x0600049D RID: 1181 RVA: 0x0000983B File Offset: 0x00007A3B
		// (set) Token: 0x0600049E RID: 1182 RVA: 0x00009855 File Offset: 0x00007A55
		public DelegateCommand ExpandCommand
		{
			get
			{
				return (DelegateCommand)base.GetValue(PanelItemsTree.ExpandCommandProperty);
			}
			set
			{
				base.SetValue(PanelItemsTree.ExpandCommandProperty, value);
			}
		}

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x0600049F RID: 1183 RVA: 0x0000986F File Offset: 0x00007A6F
		// (set) Token: 0x060004A0 RID: 1184 RVA: 0x00009889 File Offset: 0x00007A89
		public DelegateCommand CollapseCommand
		{
			get
			{
				return (DelegateCommand)base.GetValue(PanelItemsTree.CollapseCommandProperty);
			}
			set
			{
				base.SetValue(PanelItemsTree.CollapseCommandProperty, value);
			}
		}

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x060004A1 RID: 1185 RVA: 0x000098A3 File Offset: 0x00007AA3
		// (set) Token: 0x060004A2 RID: 1186 RVA: 0x000098BD File Offset: 0x00007ABD
		public bool LockOnErrors
		{
			get
			{
				return (bool)base.GetValue(PanelItemsTree.LockOnErrorsProperty);
			}
			set
			{
				base.SetValue(PanelItemsTree.LockOnErrorsProperty, value);
			}
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x00088504 File Offset: 0x00086704
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107384508), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x000098DC File Offset: 0x00007ADC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040000D8 RID: 216
		public static readonly DependencyProperty ExpandCommandProperty = DependencyProperty.Register(#Phc.#3hc(107384435), typeof(DelegateCommand), typeof(PanelItemsTree), new PropertyMetadata(null));

		// Token: 0x040000D9 RID: 217
		public static readonly DependencyProperty CollapseCommandProperty = DependencyProperty.Register(#Phc.#3hc(107384386), typeof(DelegateCommand), typeof(PanelItemsTree), new PropertyMetadata(null));

		// Token: 0x040000DA RID: 218
		public static readonly DependencyProperty LockOnErrorsProperty = DependencyProperty.Register(#Phc.#3hc(107385103), typeof(bool), typeof(PanelItemsTree), new PropertyMetadata(false));

		// Token: 0x040000DB RID: 219
		private bool _contentLoaded;
	}
}
