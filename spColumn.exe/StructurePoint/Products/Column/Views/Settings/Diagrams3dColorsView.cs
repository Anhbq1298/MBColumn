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
	// Token: 0x02000059 RID: 89
	internal sealed class Diagrams3dColorsView : ColumnBaseView, IComponentConnector, IView, #sc
	{
		// Token: 0x060003F1 RID: 1009 RVA: 0x00008EDA File Offset: 0x000070DA
		public Diagrams3dColorsView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x000870A4 File Offset: 0x000852A4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107387104), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x00008EE8 File Offset: 0x000070E8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000093 RID: 147
		private bool _contentLoaded;
	}
}
