using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;
using #Bc;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.Views.Definitions
{
	// Token: 0x02000085 RID: 133
	internal sealed class ReductionFactorsView : ColumnBaseView, IComponentConnector, IView, #Fc, #FTi
	{
		// Token: 0x06000477 RID: 1143 RVA: 0x0000960A File Offset: 0x0000780A
		public ReductionFactorsView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x0008801C File Offset: 0x0008621C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107384940), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x00009618 File Offset: 0x00007818
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
			this._contentLoaded = true;
		}

		// Token: 0x040000CC RID: 204
		internal Grid LayoutRoot;

		// Token: 0x040000CD RID: 205
		private bool _contentLoaded;
	}
}
