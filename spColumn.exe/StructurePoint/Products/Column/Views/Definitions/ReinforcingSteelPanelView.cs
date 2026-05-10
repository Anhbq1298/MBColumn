using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;
using #Bc;
using #eSh;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.Views.Definitions
{
	// Token: 0x0200007D RID: 125
	public sealed class ReinforcingSteelPanelView : ColumnBaseView, IComponentConnector, IView, #dSh, #Fc
	{
		// Token: 0x06000459 RID: 1113 RVA: 0x0000943C File Offset: 0x0000763C
		public ReinforcingSteelPanelView()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x00087DAC File Offset: 0x00085FAC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107385381), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x0000944A File Offset: 0x0000764A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.LayoutRoot = (Grid)target;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.StandardSteelProperties = (CheckBox)target;
		}

		// Token: 0x040000BB RID: 187
		internal Grid LayoutRoot;

		// Token: 0x040000BC RID: 188
		internal CheckBox StandardSteelProperties;

		// Token: 0x040000BD RID: 189
		private bool _contentLoaded;
	}
}
