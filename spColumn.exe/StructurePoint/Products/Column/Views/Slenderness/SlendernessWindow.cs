using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using #cc;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.Views.Slenderness
{
	// Token: 0x0200004D RID: 77
	internal sealed class SlendernessWindow : ColumnWindow, IComponentConnector, IColumnWindow, IView, #ec
	{
		// Token: 0x060003DE RID: 990 RVA: 0x00008DF8 File Offset: 0x00006FF8
		public SlendernessWindow()
		{
			this.InitializeComponent();
			base.CloseWithEscape = true;
			base.ResizeMode = ResizeMode.NoResize;
		}

		// Token: 0x060003DF RID: 991 RVA: 0x00086F0C File Offset: 0x0008510C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107387590), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x00008E14 File Offset: 0x00007014
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400008B RID: 139
		private bool _contentLoaded;
	}
}
