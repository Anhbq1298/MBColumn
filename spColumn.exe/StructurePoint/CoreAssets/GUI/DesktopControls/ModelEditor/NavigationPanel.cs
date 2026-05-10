using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;
using Ab3d.Cameras;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000930 RID: 2352
	[CLSCompliant(false)]
	public sealed class NavigationPanel : UserControl, IComponentConnector
	{
		// Token: 0x06004C97 RID: 19607 RVA: 0x00040226 File Offset: 0x0003E426
		public NavigationPanel()
		{
			this.InitializeComponent();
		}

		// Token: 0x1700164D RID: 5709
		// (get) Token: 0x06004C98 RID: 19608 RVA: 0x00040234 File Offset: 0x0003E434
		// (set) Token: 0x06004C99 RID: 19609 RVA: 0x0004024E File Offset: 0x0003E44E
		public BaseCamera TargetCamera
		{
			get
			{
				return (BaseCamera)base.GetValue(NavigationPanel.TargetCameraProperty);
			}
			set
			{
				base.SetValue(NavigationPanel.TargetCameraProperty, value);
			}
		}

		// Token: 0x06004C9A RID: 19610 RVA: 0x0014CE68 File Offset: 0x0014B068
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107470742), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06004C9B RID: 19611 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06004C9C RID: 19612 RVA: 0x00040268 File Offset: 0x0003E468
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040021D3 RID: 8659
		public static readonly DependencyProperty TargetCameraProperty = DependencyProperty.Register(#Phc.#3hc(107470649), typeof(BaseCamera), typeof(NavigationPanel), null);

		// Token: 0x040021D4 RID: 8660
		private bool _contentLoaded;
	}
}
