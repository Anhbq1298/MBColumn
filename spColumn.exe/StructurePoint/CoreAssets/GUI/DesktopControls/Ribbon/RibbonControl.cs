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

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon
{
	// Token: 0x020008A9 RID: 2217
	public sealed class RibbonControl : UserControl, IComponentConnector
	{
		// Token: 0x060045E3 RID: 17891 RVA: 0x0003A674 File Offset: 0x00038874
		public RibbonControl()
		{
			this.InitializeComponent();
		}

		// Token: 0x060045E4 RID: 17892 RVA: 0x0013D488 File Offset: 0x0013B688
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107454298), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060045E5 RID: 17893 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060045E6 RID: 17894 RVA: 0x0003A682 File Offset: 0x00038882
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.RibbonView = (RadRibbonView)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x04001FB7 RID: 8119
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadRibbonView RibbonView;

		// Token: 0x04001FB8 RID: 8120
		private bool _contentLoaded;
	}
}
