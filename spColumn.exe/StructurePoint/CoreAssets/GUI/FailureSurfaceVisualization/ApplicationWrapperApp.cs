using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Markup;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.FailureSurfaceVisualization
{
	// Token: 0x02000B31 RID: 2865
	public sealed class ApplicationWrapperApp : Application, IComponentConnector
	{
		// Token: 0x06005DC9 RID: 24009 RVA: 0x0004E2A5 File Offset: 0x0004C4A5
		public ApplicationWrapperApp()
		{
			this.InitializeComponent();
		}

		// Token: 0x06005DCA RID: 24010 RVA: 0x001760A0 File Offset: 0x001742A0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			int num = this._contentLoaded ? 1 : 0;
			IL_06:
			while (num == 0)
			{
				do
				{
					this._contentLoaded = true;
					if (!false)
					{
						int num2 = num = 107420352;
						if (num2 == 0)
						{
							goto IL_06;
						}
						Uri uri = new Uri(#Phc.#3hc(num2), UriKind.Relative);
						Uri uri2;
						if (!false)
						{
							uri2 = uri;
						}
						Uri resourceLocator = uri2;
						if (!false)
						{
							Application.LoadComponent(this, resourceLocator);
						}
					}
				}
				while (-1 == 0);
				return;
			}
		}

		// Token: 0x06005DCB RID: 24011 RVA: 0x0004E2B3 File Offset: 0x0004C4B3
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

		// Token: 0x040026F6 RID: 9974
		private bool _contentLoaded;
	}
}
