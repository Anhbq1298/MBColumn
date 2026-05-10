using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #9Nc;
using #ezc;
using #YKc;

namespace StructurePoint.CoreAssets.GUI.Framework.Tools.Geometry.FillGridWithShape
{
	// Token: 0x02000BEB RID: 3051
	public sealed class FillGridWithShapeToolOptionsView : ToolOptionsViewBase, IComponentConnector, #QBc, #SBc, #9Kc, #aOc
	{
		// Token: 0x06006349 RID: 25417 RVA: 0x00050D3B File Offset: 0x0004EF3B
		public FillGridWithShapeToolOptionsView()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600634A RID: 25418 RVA: 0x00183EBC File Offset: 0x001820BC
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
						int num2 = num = 107446239;
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

		// Token: 0x0600634B RID: 25419 RVA: 0x00050D49 File Offset: 0x0004EF49
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

		// Token: 0x0600634C RID: 25420 RVA: 0x000086AB File Offset: 0x000068AB
		object #9Kc.get_DataContext()
		{
			return base.DataContext;
		}

		// Token: 0x0600634D RID: 25421 RVA: 0x0004F625 File Offset: 0x0004D825
		void #9Kc.set_DataContext(object value)
		{
			if (!false)
			{
				base.DataContext = value;
			}
		}

		// Token: 0x040028C4 RID: 10436
		private bool _contentLoaded;
	}
}
