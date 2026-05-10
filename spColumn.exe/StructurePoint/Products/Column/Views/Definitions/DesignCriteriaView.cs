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
using StructurePoint.Products.Column.Views.API.Definitions;

namespace StructurePoint.Products.Column.Views.Definitions
{
	// Token: 0x02000083 RID: 131
	internal sealed class DesignCriteriaView : ColumnBaseView, IComponentConnector, IView, #Fc, IDesignCriteriaView
	{
		// Token: 0x06000474 RID: 1140 RVA: 0x000095D6 File Offset: 0x000077D6
		public DesignCriteriaView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x00087FD8 File Offset: 0x000861D8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107385025), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x000095E4 File Offset: 0x000077E4
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

		// Token: 0x040000CA RID: 202
		internal Grid LayoutRoot;

		// Token: 0x040000CB RID: 203
		private bool _contentLoaded;
	}
}
