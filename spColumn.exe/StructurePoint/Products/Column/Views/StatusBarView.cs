using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using #1b;
using #7hc;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.Views
{
	// Token: 0x02000032 RID: 50
	internal sealed class StatusBarView : ColumnBaseView, IComponentConnector, IView, #ac
	{
		// Token: 0x06000368 RID: 872 RVA: 0x0000887D File Offset: 0x00006A7D
		public StatusBarView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000369 RID: 873 RVA: 0x00086418 File Offset: 0x00084618
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107389244), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600036A RID: 874 RVA: 0x0008645C File Offset: 0x0008465C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.SnapButton = (RadToggleButton)target;
				return;
			case 2:
				this.MyPopup = (Popup)target;
				return;
			case 3:
				this.DrawingGridButton = (RadToggleButton)target;
				return;
			case 4:
				this.DynamicInputButton = (RadToggleButton)target;
				return;
			case 5:
				this.ObjectSnapButton = (RadToggleButton)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x04000060 RID: 96
		internal RadToggleButton SnapButton;

		// Token: 0x04000061 RID: 97
		internal Popup MyPopup;

		// Token: 0x04000062 RID: 98
		internal RadToggleButton DrawingGridButton;

		// Token: 0x04000063 RID: 99
		internal RadToggleButton DynamicInputButton;

		// Token: 0x04000064 RID: 100
		internal RadToggleButton ObjectSnapButton;

		// Token: 0x04000065 RID: 101
		private bool _contentLoaded;
	}
}
