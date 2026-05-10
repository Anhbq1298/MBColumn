using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using #7hc;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000927 RID: 2343
	public sealed class PanelControls2D : UserControl, IComponentConnector
	{
		// Token: 0x06004C5A RID: 19546 RVA: 0x0003FF6F File Offset: 0x0003E16F
		public PanelControls2D()
		{
			this.InitializeComponent();
			this.ResetButton.Click += this.ResetButton_Click;
		}

		// Token: 0x06004C5B RID: 19547 RVA: 0x0003FF94 File Offset: 0x0003E194
		private void ResetButton_Click(object sender, RoutedEventArgs e)
		{
			this.RaiseResetButtonClicked();
		}

		// Token: 0x1400011D RID: 285
		// (add) Token: 0x06004C5C RID: 19548 RVA: 0x0014CA80 File Offset: 0x0014AC80
		// (remove) Token: 0x06004C5D RID: 19549 RVA: 0x0014CAC4 File Offset: 0x0014ACC4
		public event EventHandler ResetButtonClicked;

		// Token: 0x06004C5E RID: 19550 RVA: 0x0014CB08 File Offset: 0x0014AD08
		[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
		protected void RaiseResetButtonClicked()
		{
			EventHandler resetButtonClicked = this.ResetButtonClicked;
			if (resetButtonClicked != null)
			{
				resetButtonClicked(this, EventArgs.Empty);
			}
		}

		// Token: 0x06004C5F RID: 19551 RVA: 0x0014CB38 File Offset: 0x0014AD38
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107470445), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06004C60 RID: 19552 RVA: 0x0014CB7C File Offset: 0x0014AD7C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.ResetButton = (RadButton)target;
				return;
			case 2:
				this.ResetToModel = (RadButton)target;
				return;
			case 3:
				this.ZoomToWindowButton = (RadToggleButton)target;
				return;
			case 4:
				this.ZoomInButton = (RadButton)target;
				return;
			case 5:
				this.ZoomOutButton = (RadButton)target;
				return;
			case 6:
				this.PanButton = (RadToggleButton)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x040021BE RID: 8638
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadButton ResetButton;

		// Token: 0x040021BF RID: 8639
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadButton ResetToModel;

		// Token: 0x040021C0 RID: 8640
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadToggleButton ZoomToWindowButton;

		// Token: 0x040021C1 RID: 8641
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadButton ZoomInButton;

		// Token: 0x040021C2 RID: 8642
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadButton ZoomOutButton;

		// Token: 0x040021C3 RID: 8643
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal RadToggleButton PanButton;

		// Token: 0x040021C4 RID: 8644
		private bool _contentLoaded;
	}
}
