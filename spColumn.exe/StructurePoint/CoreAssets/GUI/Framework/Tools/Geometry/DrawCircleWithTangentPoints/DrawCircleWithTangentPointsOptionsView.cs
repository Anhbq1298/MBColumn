using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #DPc;
using #ezc;
using #YKc;

namespace StructurePoint.CoreAssets.GUI.Framework.Tools.Geometry.DrawCircleWithTangentPoints
{
	// Token: 0x02000C03 RID: 3075
	public sealed class DrawCircleWithTangentPointsOptionsView : ToolOptionsViewBase, IComponentConnector, #QBc, #SBc, #9Kc, #EPc
	{
		// Token: 0x06006404 RID: 25604 RVA: 0x000512A5 File Offset: 0x0004F4A5
		public DrawCircleWithTangentPointsOptionsView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06006405 RID: 25605 RVA: 0x00187AD8 File Offset: 0x00185CD8
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
						int num2 = num = 107445011;
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

		// Token: 0x06006406 RID: 25606 RVA: 0x000512B3 File Offset: 0x0004F4B3
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

		// Token: 0x06006407 RID: 25607 RVA: 0x000086AB File Offset: 0x000068AB
		object #9Kc.get_DataContext()
		{
			return base.DataContext;
		}

		// Token: 0x06006408 RID: 25608 RVA: 0x0004F625 File Offset: 0x0004D825
		void #9Kc.set_DataContext(object value)
		{
			if (!false)
			{
				base.DataContext = value;
			}
		}

		// Token: 0x04002905 RID: 10501
		private bool _contentLoaded;
	}
}
