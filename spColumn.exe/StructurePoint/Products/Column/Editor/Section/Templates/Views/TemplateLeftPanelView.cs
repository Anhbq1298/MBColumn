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
	// Token: 0x020004AC RID: 1196
	internal sealed class TemplateLeftPanelView : ColumnBaseView, IComponentConnector, IView, #Twb
	{
		// Token: 0x06002C17 RID: 11287 RVA: 0x00027B82 File Offset: 0x00025D82
		public TemplateLeftPanelView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06002C18 RID: 11288 RVA: 0x000EB40C File Offset: 0x000E960C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107356714), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06002C19 RID: 11289 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06002C1A RID: 11290 RVA: 0x00027B90 File Offset: 0x00025D90
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040011AA RID: 4522
		private bool _contentLoaded;
	}
}
