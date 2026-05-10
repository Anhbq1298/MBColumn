using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #dQc;
using #ezc;
using #YKc;

namespace StructurePoint.CoreAssets.GUI.Framework.Tools.Geometry.InsertNodeOnEdge
{
	// Token: 0x02000C1E RID: 3102
	public sealed class InsertNodeOnEdgeOptionsView : ToolOptionsViewBase, IComponentConnector, #QBc, #SBc, #9Kc, #fQc
	{
		// Token: 0x060064C5 RID: 25797 RVA: 0x000517B9 File Offset: 0x0004F9B9
		public InsertNodeOnEdgeOptionsView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060064C6 RID: 25798 RVA: 0x0018B9C0 File Offset: 0x00189BC0
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
						int num2 = num = 107444100;
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

		// Token: 0x060064C7 RID: 25799 RVA: 0x000517C7 File Offset: 0x0004F9C7
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

		// Token: 0x060064C8 RID: 25800 RVA: 0x000086AB File Offset: 0x000068AB
		object #9Kc.get_DataContext()
		{
			return base.DataContext;
		}

		// Token: 0x060064C9 RID: 25801 RVA: 0x0004F625 File Offset: 0x0004D825
		void #9Kc.set_DataContext(object value)
		{
			if (!false)
			{
				base.DataContext = value;
			}
		}

		// Token: 0x04002952 RID: 10578
		private bool _contentLoaded;
	}
}
