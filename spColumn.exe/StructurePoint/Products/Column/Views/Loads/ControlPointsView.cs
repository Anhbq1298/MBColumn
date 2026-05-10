using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;
using #Zb;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.Views.Loads
{
	// Token: 0x02000078 RID: 120
	internal sealed class ControlPointsView : ColumnBaseView, IComponentConnector, IView, #cSh
	{
		// Token: 0x0600044D RID: 1101 RVA: 0x000093BE File Offset: 0x000075BE
		public ControlPointsView()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x00087CC4 File Offset: 0x00085EC4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107385567), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x000093CC File Offset: 0x000075CC
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

		// Token: 0x040000B5 RID: 181
		internal Grid LayoutRoot;

		// Token: 0x040000B6 RID: 182
		private bool _contentLoaded;
	}
}
