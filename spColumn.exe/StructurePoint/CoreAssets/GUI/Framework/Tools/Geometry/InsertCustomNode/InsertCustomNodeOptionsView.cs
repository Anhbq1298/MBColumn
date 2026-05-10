using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #ezc;
using #NPc;
using #YKc;

namespace StructurePoint.CoreAssets.GUI.Framework.Tools.Geometry.InsertCustomNode
{
	// Token: 0x02000C0F RID: 3087
	public sealed class InsertCustomNodeOptionsView : ToolOptionsViewBase, IComponentConnector, #QBc, #SBc, #9Kc, #MPc
	{
		// Token: 0x06006479 RID: 25721 RVA: 0x000515F1 File Offset: 0x0004F7F1
		public InsertCustomNodeOptionsView()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600647A RID: 25722 RVA: 0x00189EDC File Offset: 0x001880DC
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
						int num2 = num = 107444699;
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

		// Token: 0x0600647B RID: 25723 RVA: 0x000515FF File Offset: 0x0004F7FF
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

		// Token: 0x0600647C RID: 25724 RVA: 0x000086AB File Offset: 0x000068AB
		object #9Kc.get_DataContext()
		{
			return base.DataContext;
		}

		// Token: 0x0600647D RID: 25725 RVA: 0x0004F625 File Offset: 0x0004D825
		void #9Kc.set_DataContext(object value)
		{
			if (!false)
			{
				base.DataContext = value;
			}
		}

		// Token: 0x04002932 RID: 10546
		private bool _contentLoaded;
	}
}
