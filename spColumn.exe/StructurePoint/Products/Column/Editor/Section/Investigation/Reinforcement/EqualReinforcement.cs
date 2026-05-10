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
	// Token: 0x020005B3 RID: 1459
	internal sealed class EqualReinforcement : UserControl, IComponentConnector
	{
		// Token: 0x060032DE RID: 13022 RVA: 0x0002CF63 File Offset: 0x0002B163
		public EqualReinforcement()
		{
			this.InitializeComponent();
		}

		// Token: 0x060032DF RID: 13023 RVA: 0x00100E44 File Offset: 0x000FF044
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107353781), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060032E0 RID: 13024 RVA: 0x0002CF71 File Offset: 0x0002B171
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040014BB RID: 5307
		private bool _contentLoaded;
	}
}
