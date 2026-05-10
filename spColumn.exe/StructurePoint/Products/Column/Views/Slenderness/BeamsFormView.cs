using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.Views.Slenderness
{
	// Token: 0x02000047 RID: 71
	internal sealed class BeamsFormView : ColumnBaseView, IComponentConnector
	{
		// Token: 0x060003D4 RID: 980 RVA: 0x00008D5C File Offset: 0x00006F5C
		public BeamsFormView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x00086E40 File Offset: 0x00085040
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107388361), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x00008D6A File Offset: 0x00006F6A
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.ColumnTypeRadComboBox = (RadComboBox)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x04000085 RID: 133
		internal RadComboBox ColumnTypeRadComboBox;

		// Token: 0x04000086 RID: 134
		private bool _contentLoaded;
	}
}
