using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #Uwb;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.Editor.Section.Templates.Views
{
	// Token: 0x020004AF RID: 1199
	internal sealed class TemplatesToolbarView : ColumnBaseView, IComponentConnector, IView, #Wwb
	{
		// Token: 0x06002C1E RID: 11294 RVA: 0x00027BB8 File Offset: 0x00025DB8
		public TemplatesToolbarView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06002C1F RID: 11295 RVA: 0x000EB494 File Offset: 0x000E9694
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107357048), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06002C20 RID: 11296 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06002C21 RID: 11297 RVA: 0x00027BC6 File Offset: 0x00025DC6
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040011AC RID: 4524
		private bool _contentLoaded;
	}
}
