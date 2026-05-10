using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #pc;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.Views.Settings
{
	// Token: 0x02000067 RID: 103
	internal sealed class SettingsWindow : ColumnWindow, IComponentConnector, IColumnWindow, IView, #zc
	{
		// Token: 0x06000406 RID: 1030 RVA: 0x00008F97 File Offset: 0x00007197
		public SettingsWindow()
		{
			this.InitializeComponent();
			base.CloseWithEscape = true;
			base.ResizeMode = ResizeMode.NoResize;
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x00087280 File Offset: 0x00085480
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107386557), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x00008FB3 File Offset: 0x000071B3
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400009A RID: 154
		private bool _contentLoaded;
	}
}
