using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using #7hc;
using #NDb;
using #Ob;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Grid;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Reinforcement
{
	// Token: 0x0200056F RID: 1391
	internal sealed class EditIrregularReinforcementBarsView : ColumnBaseView, IComponentConnector, IView, #Nb, #MDb
	{
		// Token: 0x06003166 RID: 12646 RVA: 0x0002BCC0 File Offset: 0x00029EC0
		public EditIrregularReinforcementBarsView()
		{
			this.InitializeComponent();
			base.PreviewKeyDown += this.EditIrregularReinforcementBarsView_KeyUp;
		}

		// Token: 0x140000CD RID: 205
		// (add) Token: 0x06003167 RID: 12647 RVA: 0x000FC484 File Offset: 0x000FA684
		// (remove) Token: 0x06003168 RID: 12648 RVA: 0x000FC4C8 File Offset: 0x000FA6C8
		public event EventHandler ViewRequestedCancel;

		// Token: 0x17000FD8 RID: 4056
		// (get) Token: 0x06003169 RID: 12649 RVA: 0x0002BCE0 File Offset: 0x00029EE0
		public BaseGridControl Table
		{
			get
			{
				return this.IrregularBarsTable;
			}
		}

		// Token: 0x0600316A RID: 12650 RVA: 0x0002BCEC File Offset: 0x00029EEC
		protected void OnViewRequestedCancel()
		{
			EventHandler viewRequestedCancel = this.ViewRequestedCancel;
			if (viewRequestedCancel == null)
			{
				return;
			}
			viewRequestedCancel(this, EventArgs.Empty);
		}

		// Token: 0x0600316B RID: 12651 RVA: 0x0002BD10 File Offset: 0x00029F10
		private void EditIrregularReinforcementBarsView_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
			{
				if (this.IrregularBarsTable.RowInEditMode != null)
				{
					this.IrregularBarsTable.CancelEdit();
					e.Handled = true;
					return;
				}
				this.OnViewRequestedCancel();
			}
		}

		// Token: 0x0600316C RID: 12652 RVA: 0x000FC50C File Offset: 0x000FA70C
		private void IrregularBarsTable_OnScrollChanged(object sender, ScrollChangedEventArgs e)
		{
			if (((ScrollViewer)e.OriginalSource).VerticalScrollBarVisibility == ScrollBarVisibility.Auto)
			{
				this.IrregularBarsTable.Columns[this.IrregularBarsTable.Columns.Count - 1].Width = new Telerik.Windows.Controls.GridViewLength(1.0, Telerik.Windows.Controls.GridViewLengthUnitType.Star);
			}
		}

		// Token: 0x0600316D RID: 12653 RVA: 0x000FC570 File Offset: 0x000FA770
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107354695), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600316E RID: 12654 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x0600316F RID: 12655 RVA: 0x000FC5B4 File Offset: 0x000FA7B4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.IrregularBarsTable = (BaseGridControl)target;
				this.IrregularBarsTable.AddHandler(ScrollViewer.ScrollChangedEvent, new ScrollChangedEventHandler(this.IrregularBarsTable_OnScrollChanged));
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x04001418 RID: 5144
		internal BaseGridControl IrregularBarsTable;

		// Token: 0x04001419 RID: 5145
		private bool _contentLoaded;
	}
}
