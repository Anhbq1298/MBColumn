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
	// Token: 0x02000073 RID: 115
	internal sealed class FactoredLoadsPanelView : ColumnBaseView, IComponentConnector, IView, #Nb, #jc, #ic
	{
		// Token: 0x06000442 RID: 1090 RVA: 0x00009369 File Offset: 0x00007569
		public FactoredLoadsPanelView()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x00009377 File Offset: 0x00007577
		public BaseGridControl Table
		{
			get
			{
				return this.FactoredLoadGrid;
			}
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00009383 File Offset: 0x00007583
		public void ClearIsCurrent()
		{
			this.Table.ClearIsCurrent();
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00087BDC File Offset: 0x00085DDC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107386233), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x00087C20 File Offset: 0x00085E20
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
				this.DataGridControlBar = (DataGridControlBar)target;
				return;
			case 3:
				this.FactoredLoadGrid = (BaseGridControl)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040000B0 RID: 176
		internal Grid LayoutRoot;

		// Token: 0x040000B1 RID: 177
		internal DataGridControlBar DataGridControlBar;

		// Token: 0x040000B2 RID: 178
		internal BaseGridControl FactoredLoadGrid;

		// Token: 0x040000B3 RID: 179
		private bool _contentLoaded;
	}
}
