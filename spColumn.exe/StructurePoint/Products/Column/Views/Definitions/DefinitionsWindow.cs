using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #Bc;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.Views.Definitions
{
	// Token: 0x02000089 RID: 137
	internal sealed class DefinitionsWindow : ColumnWindow, IComponentConnector, IColumnWindow, IView, #Gc
	{
		// Token: 0x0600047D RID: 1149 RVA: 0x00009685 File Offset: 0x00007885
		public DefinitionsWindow()
		{
			this.InitializeComponent();
			base.CloseWithEscape = true;
			base.ResizeMode = ResizeMode.NoResize;
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x000880A4 File Offset: 0x000862A4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107385282), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x000096A1 File Offset: 0x000078A1
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040000D1 RID: 209
		private bool _contentLoaded;
	}
}
