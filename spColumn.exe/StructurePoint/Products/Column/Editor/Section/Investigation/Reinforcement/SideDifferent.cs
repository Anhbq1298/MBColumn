using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;

namespace StructurePoint.Products.Column.Editor.Section.Investigation.Reinforcement
{
	// Token: 0x020005B7 RID: 1463
	internal sealed class SideDifferent : UserControl, IComponentConnector
	{
		// Token: 0x06003301 RID: 13057 RVA: 0x0002D1E5 File Offset: 0x0002B3E5
		public SideDifferent()
		{
			this.InitializeComponent();
		}

		// Token: 0x06003302 RID: 13058 RVA: 0x001012B8 File Offset: 0x000FF4B8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107353659), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06003303 RID: 13059 RVA: 0x0002D1F3 File Offset: 0x0002B3F3
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040014CD RID: 5325
		private bool _contentLoaded;
	}
}
