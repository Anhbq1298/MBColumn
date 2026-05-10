using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #ezc;
using #FOc;
using #YKc;

namespace StructurePoint.CoreAssets.GUI.Framework.Tools.Geometry.DrawPolygon
{
	// Token: 0x02000BF2 RID: 3058
	public sealed class DrawPolygonOptionsView : ToolOptionsViewBase, IComponentConnector, #QBc, #SBc, #9Kc, #EOc
	{
		// Token: 0x0600637A RID: 25466 RVA: 0x00050EDE File Offset: 0x0004F0DE
		public DrawPolygonOptionsView()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600637B RID: 25467 RVA: 0x00184CC0 File Offset: 0x00182EC0
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
						int num2 = num = 107445715;
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

		// Token: 0x0600637C RID: 25468 RVA: 0x00050EEC File Offset: 0x0004F0EC
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

		// Token: 0x0600637D RID: 25469 RVA: 0x000086AB File Offset: 0x000068AB
		object #9Kc.get_DataContext()
		{
			return base.DataContext;
		}

		// Token: 0x0600637E RID: 25470 RVA: 0x0004F625 File Offset: 0x0004D825
		void #9Kc.set_DataContext(object value)
		{
			if (!false)
			{
				base.DataContext = value;
			}
		}

		// Token: 0x040028D2 RID: 10450
		private bool _contentLoaded;
	}
}
