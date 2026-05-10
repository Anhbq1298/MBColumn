using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #ezc;
using #pOc;
using #YKc;

namespace StructurePoint.CoreAssets.GUI.Framework.Tools.Geometry.DrawRectangle
{
	// Token: 0x02000BED RID: 3053
	public sealed class DrawRectangleOptionsView : ToolOptionsViewBase, IComponentConnector, #QBc, #SBc, #9Kc, #rOc
	{
		// Token: 0x0600634E RID: 25422 RVA: 0x00050D52 File Offset: 0x0004EF52
		public DrawRectangleOptionsView()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600634F RID: 25423 RVA: 0x00183F08 File Offset: 0x00182108
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
						int num2 = num = 107446086;
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

		// Token: 0x06006350 RID: 25424 RVA: 0x00050D60 File Offset: 0x0004EF60
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

		// Token: 0x06006351 RID: 25425 RVA: 0x000086AB File Offset: 0x000068AB
		object #9Kc.get_DataContext()
		{
			return base.DataContext;
		}

		// Token: 0x06006352 RID: 25426 RVA: 0x0004F625 File Offset: 0x0004D825
		void #9Kc.set_DataContext(object value)
		{
			if (!false)
			{
				base.DataContext = value;
			}
		}

		// Token: 0x040028C5 RID: 10437
		private bool _contentLoaded;
	}
}
