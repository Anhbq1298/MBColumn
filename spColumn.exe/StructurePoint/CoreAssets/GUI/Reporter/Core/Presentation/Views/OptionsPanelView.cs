using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Markup;
using #5Kd;
using #7hc;
using #ezc;
using #hId;
using StructurePoint.CoreAssets.GUI.Framework;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Printing.Presentation;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Views
{
	// Token: 0x02000DCC RID: 3532
	public sealed class OptionsPanelView : UserControl, IComponentConnector, #QBc, #8Kd
	{
		// Token: 0x06007FBD RID: 32701 RVA: 0x0006814C File Offset: 0x0006634C
		public OptionsPanelView()
		{
			this.InitializeComponent();
			this.Title = string.Empty;
			this.PrintOptionsControl.PageSetupChanged += this.PrintOptionsControl_PageSetupChanged;
		}

		// Token: 0x140001A7 RID: 423
		// (add) Token: 0x06007FBE RID: 32702 RVA: 0x001BECF4 File Offset: 0x001BCEF4
		// (remove) Token: 0x06007FBF RID: 32703 RVA: 0x001BED3C File Offset: 0x001BCF3C
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

		// Token: 0x17002640 RID: 9792
		// (get) Token: 0x06007FC0 RID: 32704 RVA: 0x0006817C File Offset: 0x0006637C
		// (set) Token: 0x06007FC1 RID: 32705 RVA: 0x00068188 File Offset: 0x00066388
		public string Title { get; private set; }

		// Token: 0x17002641 RID: 9793
		// (get) Token: 0x06007FC2 RID: 32706 RVA: 0x00068199 File Offset: 0x00066399
		// (set) Token: 0x06007FC3 RID: 32707 RVA: 0x000681A5 File Offset: 0x000663A5
		public IViewModel ViewModel { get; private set; }

		// Token: 0x06007FC4 RID: 32708 RVA: 0x000681B6 File Offset: 0x000663B6
		public void SetViewModel(IViewModel viewModel)
		{
			\u008A.\u008D\u0002(this, viewModel);
			this.ViewModel = viewModel;
		}

		// Token: 0x06007FC5 RID: 32709 RVA: 0x000681D7 File Offset: 0x000663D7
		public void InitializePrintOptions(#gId options)
		{
			this.PrintOptionsControl.Initialize(options);
		}

		// Token: 0x06007FC6 RID: 32710 RVA: 0x000681F1 File Offset: 0x000663F1
		public void UpdatePrintOptions(PrintOptionsSetup printOptionsSetup)
		{
			this.PrintOptionsControl.Update(printOptionsSetup);
		}

		// Token: 0x06007FC7 RID: 32711 RVA: 0x0006820B File Offset: 0x0006640B
		public #jJd GetPrintOptions()
		{
			return this.PrintOptionsControl.GetOptions();
		}

		// Token: 0x06007FC8 RID: 32712 RVA: 0x001BED84 File Offset: 0x001BCF84
		protected void OnPageSetupChanged()
		{
			EventHandler pageSetupChanged = this.PageSetupChanged;
			if (pageSetupChanged != null)
			{
				\u001C\u0005.~\u0010\u000F(pageSetupChanged, this, EventArgs.Empty);
			}
		}

		// Token: 0x06007FC9 RID: 32713 RVA: 0x00068220 File Offset: 0x00066420
		private void PrintOptionsControl_PageSetupChanged(object sender, EventArgs e)
		{
			this.OnPageSetupChanged();
		}

		// Token: 0x06007FCA RID: 32714 RVA: 0x001BEDB8 File Offset: 0x001BCFB8
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri uri = new Uri(#Phc.#3hc(107279390), UriKind.Relative);
			\u0098.\u0091\u0003(this, uri);
		}

		// Token: 0x06007FCB RID: 32715 RVA: 0x00067E3E File Offset: 0x0006603E
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return \u008B\u0005.\u0083\u000F(delegateType, this, handler);
		}

		// Token: 0x06007FCC RID: 32716 RVA: 0x00068230 File Offset: 0x00066430
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				this.PrintOptionsControl = (PrintOptionsControl)target;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x04003465 RID: 13413
		internal PrintOptionsControl PrintOptionsControl;

		// Token: 0x04003466 RID: 13414
		private bool _contentLoaded;
	}
}
