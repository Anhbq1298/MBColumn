using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using #7hc;
using #hId;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation;
using StructurePoint.CoreAssets.Logger;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Printing.Presentation
{
	// Token: 0x02000DB2 RID: 3506
	public sealed class PrintOptionsControl : UserControl, IComponentConnector, IStyleConnector
	{
		// Token: 0x06007EB6 RID: 32438 RVA: 0x000674F4 File Offset: 0x000656F4
		public PrintOptionsControl()
		{
			this.InitializeComponent();
		}

		// Token: 0x140001A4 RID: 420
		// (add) Token: 0x06007EB7 RID: 32439 RVA: 0x001BCC48 File Offset: 0x001BAE48
		// (remove) Token: 0x06007EB8 RID: 32440 RVA: 0x001BCC90 File Offset: 0x001BAE90
		public event EventHandler PageSetupChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.PageSetupChanged;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)\u008D.\u0097\u0002(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.PageSetupChanged, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.PageSetupChanged;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)\u008D.\u0098\u0002(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.PageSetupChanged, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x06007EB9 RID: 32441 RVA: 0x001BCCD8 File Offset: 0x001BAED8
		public void Initialize(#gId options)
		{
			if (this.viewModel == null)
			{
				this.viewModel = new PrintOptionsViewModel(options.Settings, options.FontSizeInfoProvider, options.Logger, options.DialogService);
				this.viewModel.PageSetupChanged += this.ViewModel_PageSetupChanged;
				\u008A.\u008D\u0002(this, this.viewModel);
			}
			this.viewModel.#eb(options);
		}

		// Token: 0x06007EBA RID: 32442 RVA: 0x00067502 File Offset: 0x00065702
		public void Update(PrintOptionsSetup optionsSetup)
		{
			LayoutHelper.BeginInvokeOnApplicationThread(delegate()
			{
				this.viewModel.#uP(optionsSetup);
			});
		}

		// Token: 0x06007EBB RID: 32443 RVA: 0x0006752C File Offset: 0x0006572C
		public #jJd GetOptions()
		{
			return this.viewModel.#2Jd();
		}

		// Token: 0x06007EBC RID: 32444 RVA: 0x001BCD50 File Offset: 0x001BAF50
		protected void OnPageSetupChanged()
		{
			EventHandler pageSetupChanged = this.PageSetupChanged;
			if (pageSetupChanged != null)
			{
				\u001C\u0005.~\u0010\u000F(pageSetupChanged, this, EventArgs.Empty);
			}
		}

		// Token: 0x06007EBD RID: 32445 RVA: 0x00067541 File Offset: 0x00065741
		private void ViewModel_PageSetupChanged(object sender, EventArgs e)
		{
			this.OnPageSetupChanged();
		}

		// Token: 0x06007EBE RID: 32446 RVA: 0x001BCD84 File Offset: 0x001BAF84
		private void CustomPages_KeyDown(object sender, KeyEventArgs e)
		{
			if (\u0018\u0005.~\u0007\u000F(e) == Key.Return || \u0018\u0005.~\u0007\u000F(e) == Key.Tab)
			{
				\u001D\u0005 ~_u0011_u000F = \u001D\u0005.~\u0011\u000F;
				RadWatermarkTextBox box = (RadWatermarkTextBox)sender;
				Ignore.#14d<Exception>(delegate()
				{
					box.UpdateBindingSource(false);
				}, null);
				BindingExpression bindingExpression = ~_u0011_u000F(box, RadWatermarkTextBox.CurrentTextProperty);
				if (bindingExpression != null)
				{
					\u0007.~\u001E(bindingExpression);
				}
			}
		}

		// Token: 0x06007EBF RID: 32447 RVA: 0x00067551 File Offset: 0x00065751
		private void CustomPages_OnGotFocus(object sender, RoutedEventArgs e)
		{
			\u0007.~\u001F((RadWatermarkTextBox)sender);
		}

		// Token: 0x06007EC0 RID: 32448 RVA: 0x001BCE00 File Offset: 0x001BB000
		private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (\u0010\u0002.~\u001D\u0004(this.MarginsComboBox))
			{
				FrameworkElement frameworkElement = sender as FrameworkElement;
				PageMarginsViewModel pageMarginsViewModel = (frameworkElement != null) ? (\u0092\u0002.~\u0001\u0006(frameworkElement) as PageMarginsViewModel) : null;
				if (pageMarginsViewModel != null)
				{
					this.viewModel.#0Jd(pageMarginsViewModel);
				}
			}
		}

		// Token: 0x06007EC1 RID: 32449 RVA: 0x001BCE58 File Offset: 0x001BB058
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri uri = new Uri(#Phc.#3hc(107280890), UriKind.Relative);
			\u0098.\u0091\u0003(this, uri);
		}

		// Token: 0x06007EC2 RID: 32450 RVA: 0x001BCEA0 File Offset: 0x001BB0A0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.MarginsComboBox = (RadComboBox)target;
				return;
			}
			if (connectionId != 3)
			{
				this._contentLoaded = true;
				return;
			}
			\u001E\u0005.~\u0012\u000F((RadWatermarkTextBox)target, new KeyEventHandler(this.CustomPages_KeyDown));
			\u001F\u0005.~\u0015\u000F((RadWatermarkTextBox)target, new RoutedEventHandler(this.CustomPages_OnGotFocus));
		}

		// Token: 0x06007EC3 RID: 32451 RVA: 0x0006756B File Offset: 0x0006576B
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 2)
			{
				\u007F\u0005.~\u0018\u000F((TextBlock)target, new MouseButtonEventHandler(this.UIElement_OnMouseLeftButtonDown));
			}
		}

		// Token: 0x040033F1 RID: 13297
		private PrintOptionsViewModel viewModel;

		// Token: 0x040033F3 RID: 13299
		internal RadComboBox MarginsComboBox;

		// Token: 0x040033F4 RID: 13300
		private bool _contentLoaded;
	}
}
