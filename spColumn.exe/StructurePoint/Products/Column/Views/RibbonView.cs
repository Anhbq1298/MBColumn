using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using #1b;
using #7hc;
using #sg;
using #U5c;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.Column.Core.Core.Diagnostics;
using StructurePoint.Products.Column.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.RibbonView;

namespace StructurePoint.Products.Column.Views
{
	// Token: 0x0200002C RID: 44
	internal sealed class RibbonView : ColumnBaseView, IComponentConnector, IView, #8b
	{
		// Token: 0x06000348 RID: 840 RVA: 0x00008778 File Offset: 0x00006978
		public RibbonView()
		{
			this.InitializeComponent();
			base.Loaded += this.RibbonView_Loaded;
			base.SizeChanged += new SizeChangedEventHandler(this.RibbonBackstageUpdateOnSizeChange);
		}

		// Token: 0x06000349 RID: 841 RVA: 0x00085FB4 File Offset: 0x000841B4
		private void RibbonView_Loaded(object sender, RoutedEventArgs e)
		{
			RadRibbonView ribbonViewControl = this.RibbonViewControl;
			MainWindow mainWindow = this.ParentOfType<MainWindow>();
			ribbonViewControl.BackstageClippingElement = ((mainWindow != null) ? mainWindow.RootGrid : null);
			#qk #qk = base.DataContext as #qk;
			this.ReporterDropDownButton.Button.Command = ((#qk != null) ? #qk.Services.Commands.OpenReporter : null);
			this.ForceCustomRadRibbonToggleButtonAlwaysEnabled();
		}

		// Token: 0x0600034A RID: 842 RVA: 0x000087AA File Offset: 0x000069AA
		private void RibbonBackstageUpdateOnSizeChange(object sender, RoutedEventArgs e)
		{
			if (this.RibbonViewControl.IsBackstageOpen)
			{
				this.RibbonViewControl.Backstage.BackstagePosition = BackstagePosition.Office2013;
				this.RibbonViewControl.Backstage.BackstagePosition = BackstagePosition.Office2010;
			}
		}

		// Token: 0x0600034B RID: 843 RVA: 0x000087E7 File Offset: 0x000069E7
		private void Backstage_OnPreviewKeyUpDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
			{
				e.Handled = true;
			}
		}

		// Token: 0x0600034C RID: 844 RVA: 0x00086024 File Offset: 0x00084224
		private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (#T5c.#S5c())
			{
				Process currentProcess = Process.GetCurrentProcess();
				StringBuilder builder = new StringBuilder();
				builder.AppendLine(#Phc.#3hc(107389436));
				builder.AppendLine(#Phc.#3hc(107389431));
				builder.AppendLine(string.Format(#Phc.#3hc(107389390), (double)currentProcess.WorkingSet64 / 1048576.0));
				builder.AppendLine(string.Format(#Phc.#3hc(107389377), (double)currentProcess.PrivateMemorySize64 / 1048576.0));
				GC.Collect();
				GC.WaitForPendingFinalizers();
				GC.Collect();
				currentProcess.Refresh();
				builder.AppendLine(#Phc.#3hc(107389392));
				builder.AppendLine(string.Format(#Phc.#3hc(107389390), (double)currentProcess.WorkingSet64 / 1048576.0));
				builder.AppendLine(string.Format(#Phc.#3hc(107389377), (double)currentProcess.PrivateMemorySize64 / 1048576.0));
				Logger.Debug(() => builder.ToString());
			}
		}

		// Token: 0x0600034D RID: 845 RVA: 0x0008619C File Offset: 0x0008439C
		private void ForceCustomRadRibbonToggleButtonAlwaysEnabled()
		{
			IEnumerable<RadRibbonToggleButton> enumerable = this.RibbonViewControl.ChildrenOfType<RadRibbonToggleButton>();
			foreach (RadRibbonToggleButton radRibbonToggleButton in enumerable)
			{
				if (string.Equals(radRibbonToggleButton.Name, #Phc.#3hc(107389351)))
				{
					radRibbonToggleButton.IsEnabled = true;
					break;
				}
			}
		}

		// Token: 0x0600034E RID: 846 RVA: 0x00086218 File Offset: 0x00084418
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107389362), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600034F RID: 847 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0008625C File Offset: 0x0008445C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.RibbonViewControl = (RadRibbonView)target;
				return;
			case 2:
				this.ToolsDropDownButton = (RadDropDownButton)target;
				return;
			case 3:
				this.SolverButton = (RadRibbonButton)target;
				return;
			case 4:
				this.ReporterDropDownButton = (ColumnRibbonDropdownButton)target;
				return;
			case 5:
				this.DisplayOptionsButton = (RadRibbonToggleButton)target;
				return;
			case 6:
				this.DisplayOptionsPopup = (Popup)target;
				return;
			case 7:
				this.ViewportsDropDownButton = (RadDropDownButton)target;
				return;
			case 8:
				((RadRibbonBackstage)target).PreviewKeyDown += this.Backstage_OnPreviewKeyUpDown;
				((RadRibbonBackstage)target).PreviewKeyUp += this.Backstage_OnPreviewKeyUpDown;
				return;
			case 9:
				((TextBlock)target).MouseLeftButtonDown += this.UIElement_OnMouseLeftButtonDown;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x04000053 RID: 83
		private const string TelerikMinimizeButtonName = "MinimizeButton";

		// Token: 0x04000054 RID: 84
		internal RadRibbonView RibbonViewControl;

		// Token: 0x04000055 RID: 85
		internal RadDropDownButton ToolsDropDownButton;

		// Token: 0x04000056 RID: 86
		internal RadRibbonButton SolverButton;

		// Token: 0x04000057 RID: 87
		internal ColumnRibbonDropdownButton ReporterDropDownButton;

		// Token: 0x04000058 RID: 88
		internal RadRibbonToggleButton DisplayOptionsButton;

		// Token: 0x04000059 RID: 89
		internal Popup DisplayOptionsPopup;

		// Token: 0x0400005A RID: 90
		internal RadDropDownButton ViewportsDropDownButton;

		// Token: 0x0400005B RID: 91
		private bool _contentLoaded;
	}
}
