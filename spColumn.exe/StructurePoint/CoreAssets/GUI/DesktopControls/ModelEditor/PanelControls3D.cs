using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x0200090D RID: 2317
	public sealed class PanelControls3D : UserControl, IComponentConnector
	{
		// Token: 0x060049A4 RID: 18852 RVA: 0x0003E20F File Offset: 0x0003C40F
		public PanelControls3D()
		{
			this.InitializeComponent();
		}

		// Token: 0x060049A5 RID: 18853 RVA: 0x001452F4 File Offset: 0x001434F4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107449838), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060049A6 RID: 18854 RVA: 0x00145338 File Offset: 0x00143538
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.ShowHideViewCubeButton = (RadToggleButton)target;
				return;
			case 2:
				this.Rotate3DButton = (RadToggleButton)target;
				return;
			case 3:
				this.CustomButton1 = (RadToggleButton)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x0400210D RID: 8461
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadToggleButton ShowHideViewCubeButton;

		// Token: 0x0400210E RID: 8462
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadToggleButton Rotate3DButton;

		// Token: 0x0400210F RID: 8463
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadToggleButton CustomButton1;

		// Token: 0x04002110 RID: 8464
		private bool _contentLoaded;
	}
}
