using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;
using #Bc;
using #Ob;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Grid;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.Views.Definitions
{
	// Token: 0x02000081 RID: 129
	internal sealed class BarSetView : ColumnBaseView, IComponentConnector, IView, #Nb, #Fc, #fSh
	{
		// Token: 0x0600046B RID: 1131 RVA: 0x000095A3 File Offset: 0x000077A3
		public BarSetView()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000289 RID: 649
		// (get) Token: 0x0600046C RID: 1132 RVA: 0x000095B1 File Offset: 0x000077B1
		public BaseGridControl Table
		{
			get
			{
				return this.ColumnGrid;
			}
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x000095BD File Offset: 0x000077BD
		public void ClearIsCurrent()
		{
			this.Table.ClearIsCurrent();
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x00087EE4 File Offset: 0x000860E4
		public void ScrollToLastItem()
		{
			int count = this.Table.Items.Count;
			if (count < 1)
			{
				return;
			}
			object obj = this.Table.Items[count - 1];
			this.Table.ScrollIndexIntoView(count);
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x00087F34 File Offset: 0x00086134
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107385610), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x00087F78 File Offset: 0x00086178
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.LayoutRoot = (Grid)target;
				return;
			case 2:
				this.RemoveRowButton = (RadButton)target;
				return;
			case 3:
				this.ColumnGrid = (BaseGridControl)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040000C6 RID: 198
		internal Grid LayoutRoot;

		// Token: 0x040000C7 RID: 199
		internal RadButton RemoveRowButton;

		// Token: 0x040000C8 RID: 200
		internal BaseGridControl ColumnGrid;

		// Token: 0x040000C9 RID: 201
		private bool _contentLoaded;
	}
}
