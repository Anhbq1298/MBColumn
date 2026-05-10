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
	// Token: 0x020005EB RID: 1515
	internal sealed class SideDifferentDesign : UserControl, IComponentConnector
	{
		// Token: 0x0600341D RID: 13341 RVA: 0x0002DE55 File Offset: 0x0002C055
		public SideDifferentDesign()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600341E RID: 13342 RVA: 0x00103F50 File Offset: 0x00102150
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107353177), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600341F RID: 13343 RVA: 0x0002DE63 File Offset: 0x0002C063
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04001578 RID: 5496
		private bool _contentLoaded;
	}
}
