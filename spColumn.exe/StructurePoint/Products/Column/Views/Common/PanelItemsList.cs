using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;

namespace StructurePoint.Products.Column.Views.Common
{
	// Token: 0x02000091 RID: 145
	internal sealed class PanelItemsList : UserControl, IComponentConnector
	{
		// Token: 0x060004A7 RID: 1191 RVA: 0x000098E9 File Offset: 0x00007AE9
		public PanelItemsList()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x060004A8 RID: 1192 RVA: 0x000098F7 File Offset: 0x00007AF7
		// (set) Token: 0x060004A9 RID: 1193 RVA: 0x00009911 File Offset: 0x00007B11
		public bool LockOnErrors
		{
			get
			{
				return (bool)base.GetValue(PanelItemsList.LockOnErrorsProperty);
			}
			set
			{
				base.SetValue(PanelItemsList.LockOnErrorsProperty, value);
			}
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x00088604 File Offset: 0x00086804
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107384401), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x00009930 File Offset: 0x00007B30
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040000DC RID: 220
		public static readonly DependencyProperty LockOnErrorsProperty = DependencyProperty.Register(#Phc.#3hc(107385103), typeof(bool), typeof(PanelItemsList), new PropertyMetadata(false));

		// Token: 0x040000DD RID: 221
		private bool _contentLoaded;
	}
}
