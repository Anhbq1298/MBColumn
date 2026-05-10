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
	// Token: 0x0200007F RID: 127
	internal sealed class LoadCombinationsPanelView : ColumnBaseView, IComponentConnector, IView, #Nb, #Fc, #Ac
	{
		// Token: 0x06000464 RID: 1124 RVA: 0x00009537 File Offset: 0x00007737
		public LoadCombinationsPanelView()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x06000465 RID: 1125 RVA: 0x00009545 File Offset: 0x00007745
		public BaseGridControl Table
		{
			get
			{
				return this.LoadCombinationsGrid;
			}
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x00009551 File Offset: 0x00007751
		public void ClearIsCurrent()
		{
			this.Table.ClearIsCurrent();
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x00087EA0 File Offset: 0x000860A0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107385703), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x0000956A File Offset: 0x0000776A
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
			this.LoadCombinationsGrid = (BaseGridControl)target;
		}

		// Token: 0x040000C3 RID: 195
		internal Grid LayoutRoot;

		// Token: 0x040000C4 RID: 196
		internal BaseGridControl LoadCombinationsGrid;

		// Token: 0x040000C5 RID: 197
		private bool _contentLoaded;
	}
}
