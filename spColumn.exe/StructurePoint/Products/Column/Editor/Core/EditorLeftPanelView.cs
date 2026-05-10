using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #RJb;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.Editor.Core
{
	// Token: 0x02000670 RID: 1648
	internal sealed class EditorLeftPanelView : ColumnBaseView, IComponentConnector, IView, #eLb
	{
		// Token: 0x06003776 RID: 14198 RVA: 0x000303C8 File Offset: 0x0002E5C8
		public EditorLeftPanelView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06003777 RID: 14199 RVA: 0x0010D4B0 File Offset: 0x0010B6B0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107351654), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06003778 RID: 14200 RVA: 0x000303D6 File Offset: 0x0002E5D6
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PropertiesPanelToggleButton = (RadToggleButton)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x0400171F RID: 5919
		internal RadToggleButton PropertiesPanelToggleButton;

		// Token: 0x04001720 RID: 5920
		private bool _contentLoaded;
	}
}
