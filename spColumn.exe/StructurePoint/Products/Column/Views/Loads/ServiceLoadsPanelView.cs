using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;
using #hc;
using #Ob;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Grid;

namespace StructurePoint.Products.Column.Views.Loads
{
	// Token: 0x02000079 RID: 121
	internal sealed class ServiceLoadsPanelView : ColumnBaseView, IComponentConnector, IView, #Nb, #jc, #lc
	{
		// Token: 0x06000450 RID: 1104 RVA: 0x000093F2 File Offset: 0x000075F2
		public ServiceLoadsPanelView()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000283 RID: 643
		// (get) Token: 0x06000451 RID: 1105 RVA: 0x00009400 File Offset: 0x00007600
		public BaseGridControl Table
		{
			get
			{
				return this.ServiceLoadGridTable;
			}
		}

		// Token: 0x17000284 RID: 644
		// (get) Token: 0x06000452 RID: 1106 RVA: 0x0000940C File Offset: 0x0000760C
		public BaseGridControl LoadCaseTable
		{
			get
			{
				return this.ColumnGrid;
			}
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x00009418 File Offset: 0x00007618
		public void ClearIsCurrent()
		{
			this.Table.ClearIsCurrent();
			this.LoadCaseTable.ClearIsCurrent();
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x00087D08 File Offset: 0x00085F08
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107385494), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00087D4C File Offset: 0x00085F4C
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
				this.ColumnGrid = (BaseGridControl)target;
				return;
			case 3:
				this.ServiceLoadGridTable = (BaseGridControl)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040000B7 RID: 183
		internal Grid LayoutRoot;

		// Token: 0x040000B8 RID: 184
		internal BaseGridControl ColumnGrid;

		// Token: 0x040000B9 RID: 185
		internal BaseGridControl ServiceLoadGridTable;

		// Token: 0x040000BA RID: 186
		private bool _contentLoaded;
	}
}
