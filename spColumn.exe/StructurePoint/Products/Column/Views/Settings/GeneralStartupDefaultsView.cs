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
	// Token: 0x02000061 RID: 97
	internal sealed class GeneralStartupDefaultsView : ColumnBaseView, IComponentConnector, IView, #yc
	{
		// Token: 0x060003FD RID: 1021 RVA: 0x00008F46 File Offset: 0x00007146
		public GeneralStartupDefaultsView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x000871B4 File Offset: 0x000853B4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107387320), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x00008F54 File Offset: 0x00007154
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000097 RID: 151
		private bool _contentLoaded;
	}
}
