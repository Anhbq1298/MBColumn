using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #ezc;
using #PMc;
using #YKc;

namespace StructurePoint.CoreAssets.GUI.Framework.Tools.Geometry.ModifyNode
{
	// Token: 0x02000BD7 RID: 3031
	public sealed class ModifyNodeOptionsView : ToolOptionsViewBase, IComponentConnector, #QBc, #SBc, #9Kc, #OMc
	{
		// Token: 0x060062D2 RID: 25298 RVA: 0x00050932 File Offset: 0x0004EB32
		public ModifyNodeOptionsView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060062D3 RID: 25299 RVA: 0x00181900 File Offset: 0x0017FB00
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
						int num2 = num = 107413714;
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

		// Token: 0x060062D4 RID: 25300 RVA: 0x00050940 File Offset: 0x0004EB40
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

		// Token: 0x060062D5 RID: 25301 RVA: 0x000086AB File Offset: 0x000068AB
		object #9Kc.get_DataContext()
		{
			return base.DataContext;
		}

		// Token: 0x060062D6 RID: 25302 RVA: 0x0004F625 File Offset: 0x0004D825
		void #9Kc.set_DataContext(object value)
		{
			if (!false)
			{
				base.DataContext = value;
			}
		}

		// Token: 0x0400288F RID: 10383
		private bool _contentLoaded;
	}
}
