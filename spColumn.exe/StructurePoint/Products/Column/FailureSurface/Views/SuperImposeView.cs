using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using #7hc;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Grid;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.FailureSurface.Views
{
	// Token: 0x020003F2 RID: 1010
	public sealed class SuperImposeView : ColumnBaseView, IComponentConnector, IView, ISuperImposeView
	{
		// Token: 0x060022D9 RID: 8921 RVA: 0x0002199D File Offset: 0x0001FB9D
		public SuperImposeView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060022DA RID: 8922 RVA: 0x000CB530 File Offset: 0x000C9730
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107363173), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060022DB RID: 8923 RVA: 0x000219AB File Offset: 0x0001FBAB
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.RemoveRowButton = (RadButton)target;
				return;
			}
			if (connectionId != 2)
			{
				this._contentLoaded = true;
				return;
			}
			this.ImposedDiagramsGrid = (BaseGridControl)target;
		}

		// Token: 0x04000DEC RID: 3564
		internal RadButton RemoveRowButton;

		// Token: 0x04000DED RID: 3565
		internal BaseGridControl ImposedDiagramsGrid;

		// Token: 0x04000DEE RID: 3566
		private bool _contentLoaded;
	}
}
