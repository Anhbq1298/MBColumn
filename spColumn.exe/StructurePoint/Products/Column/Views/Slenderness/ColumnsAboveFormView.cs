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
	// Token: 0x02000046 RID: 70
	internal sealed class ColumnsAboveFormView : ColumnBaseView, IComponentConnector
	{
		// Token: 0x060003D0 RID: 976 RVA: 0x00008D28 File Offset: 0x00006F28
		public ColumnsAboveFormView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x00086DFC File Offset: 0x00084FFC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107387966), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00008D36 File Offset: 0x00006F36
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

		// Token: 0x04000083 RID: 131
		internal RadComboBox ColumnTypeRadComboBox;

		// Token: 0x04000084 RID: 132
		private bool _contentLoaded;
	}
}
