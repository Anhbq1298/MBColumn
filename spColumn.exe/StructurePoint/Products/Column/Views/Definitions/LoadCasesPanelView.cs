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

namespace StructurePoint.Products.Column.Views.Definitions
{
	// Token: 0x0200008B RID: 139
	internal sealed class LoadCasesPanelView : ColumnBaseView, IComponentConnector, IView, #Nb, #Fc, #Cc
	{
		// Token: 0x06000481 RID: 1153 RVA: 0x000096AE File Offset: 0x000078AE
		public LoadCasesPanelView()
		{
			this.InitializeComponent();
		}

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x06000482 RID: 1154 RVA: 0x000096BC File Offset: 0x000078BC
		public BaseGridControl Table
		{
			get
			{
				return this.LoadCasesGrid;
			}
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x000096C8 File Offset: 0x000078C8
		public void ClearIsCurrent()
		{
			this.Table.ClearIsCurrent();
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x000880E8 File Offset: 0x000862E8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107385233), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x000096E1 File Offset: 0x000078E1
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.LayoutRoot = (Grid)target;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.LoadCasesGrid = (BaseGridControl)target;
		}

		// Token: 0x040000D2 RID: 210
		internal Grid LayoutRoot;

		// Token: 0x040000D3 RID: 211
		internal BaseGridControl LoadCasesGrid;

		// Token: 0x040000D4 RID: 212
		private bool _contentLoaded;
	}
}
