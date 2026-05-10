using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;

namespace StructurePoint.Products.Column.Editor.Section.Design.Reinforcement
{
	// Token: 0x020005E2 RID: 1506
	internal sealed class EqualReinforcementDesign : UserControl, IComponentConnector
	{
		// Token: 0x060033E8 RID: 13288 RVA: 0x0002DBAA File Offset: 0x0002BDAA
		public EqualReinforcementDesign()
		{
			this.InitializeComponent();
		}

		// Token: 0x060033E9 RID: 13289 RVA: 0x001036CC File Offset: 0x001018CC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107353280), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060033EA RID: 13290 RVA: 0x0002DBB8 File Offset: 0x0002BDB8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04001556 RID: 5462
		private bool _contentLoaded;
	}
}
