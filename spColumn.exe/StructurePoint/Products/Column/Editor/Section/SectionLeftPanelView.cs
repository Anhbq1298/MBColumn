using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #APb;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.Editor.Section
{
	// Token: 0x02000498 RID: 1176
	internal sealed class SectionLeftPanelView : ColumnBaseView, IComponentConnector, IView, #TPb
	{
		// Token: 0x06002BC6 RID: 11206 RVA: 0x000277D0 File Offset: 0x000259D0
		public SectionLeftPanelView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06002BC7 RID: 11207 RVA: 0x000EA390 File Offset: 0x000E8590
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107356852), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06002BC8 RID: 11208 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06002BC9 RID: 11209 RVA: 0x000277DE File Offset: 0x000259DE
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400117B RID: 4475
		private bool _contentLoaded;
	}
}
