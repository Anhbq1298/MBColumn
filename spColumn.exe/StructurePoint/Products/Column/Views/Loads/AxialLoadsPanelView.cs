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
	// Token: 0x02000070 RID: 112
	internal sealed class AxialLoadsPanelView : ColumnBaseView, IComponentConnector, IView, #Nb, #gc, #jc
	{
		// Token: 0x0600043B RID: 1083 RVA: 0x00009336 File Offset: 0x00007536
		public AxialLoadsPanelView()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000281 RID: 641
		// (get) Token: 0x0600043C RID: 1084 RVA: 0x00009344 File Offset: 0x00007544
		public BaseGridControl Table
		{
			get
			{
				return this.AxialLoadGrid;
			}
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x00009350 File Offset: 0x00007550
		public void ClearIsCurrent()
		{
			this.Table.ClearIsCurrent();
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x00087B38 File Offset: 0x00085D38
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107386278), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x00087B7C File Offset: 0x00085D7C
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
				this.AxialLoadGrid = (BaseGridControl)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040000AC RID: 172
		internal Grid LayoutRoot;

		// Token: 0x040000AD RID: 173
		internal DataGridControlBar DataGridControlBar;

		// Token: 0x040000AE RID: 174
		internal BaseGridControl AxialLoadGrid;

		// Token: 0x040000AF RID: 175
		private bool _contentLoaded;
	}
}
