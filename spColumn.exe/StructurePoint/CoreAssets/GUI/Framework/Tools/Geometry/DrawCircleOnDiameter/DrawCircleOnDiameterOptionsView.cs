using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #ezc;
using #JPc;
using #YKc;

namespace StructurePoint.CoreAssets.GUI.Framework.Tools.Geometry.DrawCircleOnDiameter
{
	// Token: 0x02000C09 RID: 3081
	public sealed class DrawCircleOnDiameterOptionsView : ToolOptionsViewBase, IComponentConnector, #QBc, #SBc, #9Kc, #KPc
	{
		// Token: 0x06006442 RID: 25666 RVA: 0x0005145B File Offset: 0x0004F65B
		public DrawCircleOnDiameterOptionsView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06006443 RID: 25667 RVA: 0x00188DD8 File Offset: 0x00186FD8
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
						int num2 = num = 107444312;
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

		// Token: 0x06006444 RID: 25668 RVA: 0x00051469 File Offset: 0x0004F669
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

		// Token: 0x06006445 RID: 25669 RVA: 0x000086AB File Offset: 0x000068AB
		object #9Kc.get_DataContext()
		{
			return base.DataContext;
		}

		// Token: 0x06006446 RID: 25670 RVA: 0x0004F625 File Offset: 0x0004D825
		void #9Kc.set_DataContext(object value)
		{
			if (!false)
			{
				base.DataContext = value;
			}
		}

		// Token: 0x0400291E RID: 10526
		private bool _contentLoaded;
	}
}
