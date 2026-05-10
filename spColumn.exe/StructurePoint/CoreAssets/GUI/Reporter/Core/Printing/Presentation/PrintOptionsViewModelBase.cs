using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using #7hc;
using #BTd;
using #ezc;
using #hId;
using #LQc;
using #sUd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Logger;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Printing.Presentation
{
	// Token: 0x02000DB7 RID: 3511
	public abstract class PrintOptionsViewModelBase : NotifyPropertyChangedObjectWithValidation
	{
		// Token: 0x06007ECD RID: 32461 RVA: 0x001BCF88 File Offset: 0x001BB188
		protected PrintOptionsViewModelBase(#wUd settingsManager, #ATd fontSizeInfoProvider, ILogger logger, #8Sc dialogService)
		{
			this.#p = logger;
			this.#s = settingsManager;
			this.#t = fontSizeInfoProvider;
			this.#x = new RadObservableCollection<PaperSizeItem>();
			this.#w = new RadObservableCollection<PrinterItem>();
			this.#z = new RadObservableCollection<ComboItem<PaperOrientation>>();
			this.#y = new RadObservableCollection<ComboItem<PageSelectionMode>>();
			this.PageOrientations.Add(new ComboItem<PaperOrientation>(PaperOrientation.Portrait, #Phc.#3hc(107280769)));
			this.PageOrientations.Add(new ComboItem<PaperOrientation>(PaperOrientation.Landscape, #Phc.#3hc(107280788)));
			this.PageSelectionModes.Add(new ComboItem<PageSelectionMode>(PageSelectionMode.AllPages, #Phc.#3hc(107280743)));
			this.PageSelectionModes.Add(new ComboItem<PageSelectionMode>(PageSelectionMode.CurrentPage, #Phc.#3hc(107280762)));
			this.PageSelectionModes.Add(new ComboItem<PageSelectionMode>(PageSelectionMode.Selection, #Phc.#3hc(107280713)));
			this.#A = new RadObservableCollection<PageMarginsViewModel>();
			this.#u = new DelegateCommand(new Action<object>(this.#7Jd));
			this.#v = new DelegateCommand(new Action<object>(this.#6Jd));
			this.#D = dialogService;
			this.#k = new PrinterSettings();
		}

		// Token: 0x140001A5 RID: 421
		// (add) Token: 0x06007ECE RID: 32462 RVA: 0x001BD0B8 File Offset: 0x001BB2B8
		// (remove) Token: 0x06007ECF RID: 32463 RVA: 0x001BD100 File Offset: 0x001BB300
		public event EventHandler PageSetupChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#r;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)\u008D.\u0097\u0002(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#r, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#r;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)\u008D.\u0098\u0002(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#r, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x170025FD RID: 9725
		// (get) Token: 0x06007ED0 RID: 32464 RVA: 0x000675F1 File Offset: 0x000657F1
		public #wUd SettingsManager { get; }

		// Token: 0x170025FE RID: 9726
		// (get) Token: 0x06007ED1 RID: 32465 RVA: 0x000675FD File Offset: 0x000657FD
		public #ATd FontSizeInfoProvider { get; }

		// Token: 0x170025FF RID: 9727
		// (get) Token: 0x06007ED2 RID: 32466 RVA: 0x00067609 File Offset: 0x00065809
		public DelegateCommand OpenPropertiesCommand { get; }

		// Token: 0x17002600 RID: 9728
		// (get) Token: 0x06007ED3 RID: 32467 RVA: 0x00067615 File Offset: 0x00065815
		public DelegateCommand InvalidateValidationMessagesCommand { get; }

		// Token: 0x17002601 RID: 9729
		// (get) Token: 0x06007ED4 RID: 32468 RVA: 0x00067621 File Offset: 0x00065821
		// (set) Token: 0x06007ED5 RID: 32469 RVA: 0x0006762D File Offset: 0x0006582D
		public PrinterItem SelectedPrinter
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.#d != value)
				{
					this.#d = value;
					this.#eKd(value);
					base.RaisePropertyChanged(#Phc.#3hc(107280728));
				}
			}
		}

		// Token: 0x17002602 RID: 9730
		// (get) Token: 0x06007ED6 RID: 32470 RVA: 0x00067662 File Offset: 0x00065862
		public RadObservableCollection<PrinterItem> Printers { get; }

		// Token: 0x17002603 RID: 9731
		// (get) Token: 0x06007ED7 RID: 32471 RVA: 0x0006766E File Offset: 0x0006586E
		public RadObservableCollection<PaperSizeItem> PaperSizes { get; }

		// Token: 0x17002604 RID: 9732
		// (get) Token: 0x06007ED8 RID: 32472 RVA: 0x0006767A File Offset: 0x0006587A
		public RadObservableCollection<ComboItem<PageSelectionMode>> PageSelectionModes { get; }

		// Token: 0x17002605 RID: 9733
		// (get) Token: 0x06007ED9 RID: 32473 RVA: 0x00067686 File Offset: 0x00065886
		public RadObservableCollection<ComboItem<PaperOrientation>> PageOrientations { get; }

		// Token: 0x17002606 RID: 9734
		// (get) Token: 0x06007EDA RID: 32474 RVA: 0x00067692 File Offset: 0x00065892
		public RadObservableCollection<PageMarginsViewModel> PageMargins { get; }

		// Token: 0x17002607 RID: 9735
		// (get) Token: 0x06007EDB RID: 32475 RVA: 0x0006769E File Offset: 0x0006589E
		// (set) Token: 0x06007EDC RID: 32476 RVA: 0x000676AA File Offset: 0x000658AA
		public int LinesPerPage
		{
			get
			{
				return this.#l;
			}
			set
			{
				if (this.#l != value)
				{
					this.#l = value;
					this.#4Jd();
					base.RaisePropertyChanged(#Phc.#3hc(107280675));
				}
			}
		}

		// Token: 0x17002608 RID: 9736
		// (get) Token: 0x06007EDD RID: 32477 RVA: 0x000676DE File Offset: 0x000658DE
		// (set) Token: 0x06007EDE RID: 32478 RVA: 0x000676EA File Offset: 0x000658EA
		public bool UseLinesPerPageOptions
		{
			get
			{
				return this.#m;
			}
			set
			{
				if (this.#m != value)
				{
					this.#m = value;
					base.RaisePropertyChanged(#Phc.#3hc(107280690));
				}
			}
		}

		// Token: 0x17002609 RID: 9737
		// (get) Token: 0x06007EDF RID: 32479 RVA: 0x00067718 File Offset: 0x00065918
		// (set) Token: 0x06007EE0 RID: 32480 RVA: 0x001BD148 File Offset: 0x001BB348
		public PageMarginsViewModel SelectedMargins
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value)
				{
					if (value != null && value.Key == PageMarginType.Custom)
					{
						if (!this.#j || this.#8Jd(value))
						{
							this.#a = value;
							this.#4Jd();
							base.RaisePropertyChanged(#Phc.#3hc(107280657));
							return;
						}
						base.RaisePropertyChanged(#Phc.#3hc(107280657));
						return;
					}
					else
					{
						this.#a = value;
						this.#4Jd();
						base.RaisePropertyChanged(#Phc.#3hc(107280657));
					}
				}
			}
		}

		// Token: 0x1700260A RID: 9738
		// (get) Token: 0x06007EE1 RID: 32481 RVA: 0x00067724 File Offset: 0x00065924
		// (set) Token: 0x06007EE2 RID: 32482 RVA: 0x00067730 File Offset: 0x00065930
		public ComboItem<PaperOrientation> SelectedPageOrientation
		{
			get
			{
				return this.#g;
			}
			set
			{
				if (this.#g != value)
				{
					this.#g = value;
					this.#4Jd();
					base.RaisePropertyChanged(#Phc.#3hc(107280124));
				}
			}
		}

		// Token: 0x1700260B RID: 9739
		// (get) Token: 0x06007EE3 RID: 32483 RVA: 0x00067764 File Offset: 0x00065964
		// (set) Token: 0x06007EE4 RID: 32484 RVA: 0x00067770 File Offset: 0x00065970
		public ComboItem<PageSelectionMode> SelectedPageSelectionMode
		{
			get
			{
				return this.#f;
			}
			set
			{
				if (this.#f != value)
				{
					this.#f = value;
					this.#bKd();
					base.RaisePropertyChanged(#Phc.#3hc(107280091));
				}
			}
		}

		// Token: 0x1700260C RID: 9740
		// (get) Token: 0x06007EE5 RID: 32485 RVA: 0x000677A5 File Offset: 0x000659A5
		// (set) Token: 0x06007EE6 RID: 32486 RVA: 0x000677B1 File Offset: 0x000659B1
		public PaperSizeItem SelectedPaperSize
		{
			get
			{
				return this.#h;
			}
			set
			{
				if (this.#h != value)
				{
					this.#h = value;
					this.#4Jd();
					base.RaisePropertyChanged(#Phc.#3hc(107280054));
				}
			}
		}

		// Token: 0x1700260D RID: 9741
		// (get) Token: 0x06007EE7 RID: 32487 RVA: 0x000677E5 File Offset: 0x000659E5
		// (set) Token: 0x06007EE8 RID: 32488 RVA: 0x001BD1E4 File Offset: 0x001BB3E4
		public string LastValidSelectedPages
		{
			get
			{
				return this.#B;
			}
			private set
			{
				if (\u0093.\u0015\u0003(this.#B, value))
				{
					base.RaisePropertyChanging(#Phc.#3hc(107280029));
					this.#B = value;
					base.RaisePropertyChanged(#Phc.#3hc(107280029));
				}
			}
		}

		// Token: 0x1700260E RID: 9742
		// (get) Token: 0x06007EE9 RID: 32489 RVA: 0x000677F1 File Offset: 0x000659F1
		// (set) Token: 0x06007EEA RID: 32490 RVA: 0x001BD238 File Offset: 0x001BB438
		public string SelectedPages
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (\u0093.\u0015\u0003(this.#e, value))
				{
					this.#e = value;
					if (this.#bKd())
					{
						this.LastValidSelectedPages = value;
					}
					base.RaisePropertyChanged(#Phc.#3hc(107279996));
				}
			}
		}

		// Token: 0x1700260F RID: 9743
		// (get) Token: 0x06007EEB RID: 32491 RVA: 0x000677FD File Offset: 0x000659FD
		// (set) Token: 0x06007EEC RID: 32492 RVA: 0x00067809 File Offset: 0x00065A09
		public bool IsReportPrintable
		{
			get
			{
				return this.#b;
			}
			private set
			{
				if (this.#b != value)
				{
					this.#b = value;
					base.RaisePropertyChanged(#Phc.#3hc(107279943));
				}
			}
		}

		// Token: 0x17002610 RID: 9744
		// (get) Token: 0x06007EED RID: 32493 RVA: 0x00067837 File Offset: 0x00065A37
		// (set) Token: 0x06007EEE RID: 32494 RVA: 0x00067843 File Offset: 0x00065A43
		public bool IsRealPrinterSelected
		{
			get
			{
				return this.#i;
			}
			private set
			{
				if (this.#i != value)
				{
					this.#i = value;
					base.RaisePropertyChanged(#Phc.#3hc(107279918));
				}
			}
		}

		// Token: 0x17002611 RID: 9745
		// (get) Token: 0x06007EEF RID: 32495 RVA: 0x00067871 File Offset: 0x00065A71
		// (set) Token: 0x06007EF0 RID: 32496 RVA: 0x0006787D File Offset: 0x00065A7D
		public bool CanChangePrintSettings
		{
			get
			{
				return this.#o;
			}
			private set
			{
				if (this.#o != value)
				{
					this.#o = value;
					base.RaisePropertyChanged(#Phc.#3hc(107279921));
				}
			}
		}

		// Token: 0x17002612 RID: 9746
		// (get) Token: 0x06007EF1 RID: 32497 RVA: 0x000678AB File Offset: 0x00065AAB
		// (set) Token: 0x06007EF2 RID: 32498 RVA: 0x000678B7 File Offset: 0x00065AB7
		private protected PrintOptionsSetup OptionsSetup { protected get; private set; }

		// Token: 0x17002613 RID: 9747
		// (get) Token: 0x06007EF3 RID: 32499 RVA: 0x000678C8 File Offset: 0x00065AC8
		protected #8Sc DialogService { get; }

		// Token: 0x17002614 RID: 9748
		// (get) Token: 0x06007EF4 RID: 32500 RVA: 0x000678D4 File Offset: 0x00065AD4
		// (set) Token: 0x06007EF5 RID: 32501 RVA: 0x000678E0 File Offset: 0x00065AE0
		public Visibility PageRangeOptionsVisibility
		{
			get
			{
				return this.#q;
			}
			set
			{
				if (this.#q != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107279888));
					this.#q = value;
					base.RaisePropertyChanged(#Phc.#3hc(107279888));
				}
			}
		}

		// Token: 0x06007EF6 RID: 32502 RVA: 0x001BD28C File Offset: 0x001BB48C
		public void #0Jd(PageMarginsViewModel #Rf)
		{
			if (#Rf.Key != PageMarginType.Custom || #Rf != this.SelectedMargins)
			{
				return;
			}
			if (this.#n == null)
			{
				this.#n = new MarginSetupViewModel(this.DialogService);
			}
			if (this.#n.#0Pb(#Rf, this.#c))
			{
				this.#4Jd();
			}
		}

		// Token: 0x06007EF7 RID: 32503 RVA: 0x001BD2EC File Offset: 0x001BB4EC
		public void #eb(#gId #1Jd)
		{
			PrintOptionsViewModelBase.#3Tb #3Tb = new PrintOptionsViewModelBase.#3Tb();
			#3Tb.#a = this;
			#3Tb.#b = #1Jd;
			if (#3Tb.#b == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107280331));
			}
			this.#9Jd(false, new Action(#3Tb.#8bd));
		}

		// Token: 0x06007EF8 RID: 32504 RVA: 0x001BD344 File Offset: 0x001BB544
		public void #uP(PrintOptionsSetup #bFd)
		{
			PrintOptionsViewModelBase.#NUb #NUb = new PrintOptionsViewModelBase.#NUb();
			#NUb.#a = this;
			#NUb.#b = #bFd;
			this.OptionsSetup = #NUb.#b;
			this.#3Jd();
			if (#NUb.#b == null)
			{
				return;
			}
			this.#9Jd(false, new Action(#NUb.#zVd));
		}

		// Token: 0x06007EF9 RID: 32505 RVA: 0x001BD3A0 File Offset: 0x001BB5A0
		public virtual #jJd #2Jd()
		{
			List<IPageSelection> list = this.#dKd();
			#jJd #jJd = new #jJd();
			PaperSizeItem paperSizeItem = this.SelectedPaperSize;
			#jJd.AsposePaperSize = ((paperSizeItem != null) ? paperSizeItem.AsposePaperSize : null);
			PaperSizeItem paperSizeItem2 = this.SelectedPaperSize;
			#jJd.PaperSize = ((paperSizeItem2 != null) ? paperSizeItem2.PaperSize : null);
			#jJd.NoPaperSelected = (this.SelectedPaperSize == null);
			#jJd.Printer = this.SelectedPrinter.Value;
			#jJd.PrinterStatus = this.SelectedPrinter.PrinterStatus;
			#jJd.IsRealPrinterDevice = this.SelectedPrinter.IsRealDevice;
			#jJd.Orientation = this.SelectedPageOrientation.Value;
			#jJd.PageSelectionMode = this.SelectedPageSelectionMode.Value;
			#jJd.PageSelectionRaw = this.SelectedPages;
			#jJd.PrinterSettings = this.#k;
			#jJd.LinesPerPage = this.LinesPerPage;
			#jJd.InvalidPageSelection = false;
			#jJd.FontInfo = ((this.FontSizeInfoProvider != null) ? this.FontSizeInfoProvider.#3hc(this.SettingsManager.ReportFontSize) : ReportFontSizeInfoProvider.Instance.#3hc(ReportFontSizes.Large));
			#jJd #jJd2 = #jJd;
			this.SelectedMargins.#77c(#jJd2.Margins);
			if (list != null)
			{
				#jJd2.Pages.AddRange(list);
			}
			else
			{
				#jJd2.InvalidPageSelection = true;
			}
			return #jJd2;
		}

		// Token: 0x06007EFA RID: 32506 RVA: 0x001BD4FC File Offset: 0x001BB6FC
		public void #3Jd()
		{
			PrinterItem printerItem = this.SelectedPrinter;
			this.IsRealPrinterSelected = (printerItem != null && printerItem.IsRealDevice);
			this.IsReportPrintable = (this.OptionsSetup != null);
			this.CanChangePrintSettings = (this.IsReportPrintable && printerItem != null && printerItem.IsReady);
		}

		// Token: 0x06007EFB RID: 32507
		protected abstract IntPtr #tJd();

		// Token: 0x06007EFC RID: 32508 RVA: 0x001BD558 File Offset: 0x001BB758
		protected virtual void #4Jd()
		{
			if (this.IsRealPrinterSelected && this.SelectedPaperSize != null)
			{
				System.Drawing.Printing.PaperSize paperSize = \u0015\u0005.~\u0004\u000F(this.#k).OfType<System.Drawing.Printing.PaperSize>().FirstOrDefault(new Func<System.Drawing.Printing.PaperSize, bool>(this.#fKd));
				if (paperSize != null && \u008D\u0002.~\u0094\u0005(paperSize) != \u008D\u0002.~\u0094\u0005(\u0017\u0005.~\u0006\u000F(\u0016\u0005.~\u0005\u000F(this.#k))))
				{
					\u0083\u0005.~\u001D\u000F(\u0016\u0005.~\u0005\u000F(this.#k), this.SelectedPaperSize.PaperSize);
				}
				\u0095.~\u008D\u0003(\u0016\u0005.~\u0005\u000F(this.#k), this.SelectedPageOrientation.Value == PaperOrientation.Landscape);
			}
			if (this.#j)
			{
				EventHandler eventHandler = this.#r;
				if (eventHandler == null)
				{
					return;
				}
				eventHandler(this, EventArgs.Empty);
			}
		}

		// Token: 0x06007EFD RID: 32509 RVA: 0x001BD660 File Offset: 0x001BB860
		private PrinterItem #5Jd(string #wy)
		{
			PrintOptionsViewModelBase.#aUb #aUb = new PrintOptionsViewModelBase.#aUb();
			#aUb.#a = #wy;
			PrinterItem printerItem = this.Printers.FirstOrDefault(new Func<PrinterItem, bool>(#aUb.#AVd));
			#aUb.#b = null;
			try
			{
				PrinterSettings printerSettings = new PrinterSettings();
				#aUb.#b = \u007F.~\u0017\u0002(printerSettings);
			}
			catch
			{
			}
			if (printerItem == null)
			{
				printerItem = ((!\u0003.\u0004(#aUb.#b)) ? this.Printers.FirstOrDefault(new Func<PrinterItem, bool>(#aUb.#BVd)) : null);
			}
			return printerItem ?? this.Printers.First<PrinterItem>();
		}

		// Token: 0x06007EFE RID: 32510 RVA: 0x0006791E File Offset: 0x00065B1E
		private void #6Jd(object #GA)
		{
			\u0086\u0005.~\u001F\u000F(\u0084\u0005.~\u001E\u000F(\u0098\u0002.\u000F\u0006()), DispatcherPriority.ApplicationIdle, new Func<bool>(this.#gKd));
		}

		// Token: 0x06007EFF RID: 32511 RVA: 0x001BD724 File Offset: 0x001BB924
		private void #7Jd(object #GA)
		{
			try
			{
				if (#0zc.#Nzc(this.#tJd(), this.#k) == DialogResult.OK)
				{
					PrintOptionsViewModelBase.#PUb #PUb = new PrintOptionsViewModelBase.#PUb();
					this.SelectedPaperSize = (this.PaperSizes.FirstOrDefault(new Func<PaperSizeItem, bool>(this.#hKd)) ?? this.SelectedPaperSize);
					#PUb.#a = (\u0010\u0002.~\u001E\u0004(\u0016\u0005.~\u0005\u000F(this.#k)) ? PaperOrientation.Landscape : PaperOrientation.Portrait);
					this.SelectedPageOrientation = this.PageOrientations.First(new Func<ComboItem<PaperOrientation>, bool>(#PUb.#CVd));
				}
			}
			catch (Exception ex)
			{
				this.DialogService.#qn(\u007F.~\u0018\u0002(ex));
			}
		}

		// Token: 0x06007F00 RID: 32512 RVA: 0x00067958 File Offset: 0x00065B58
		private bool #8Jd(PageMarginsViewModel #Rf)
		{
			if (this.#n == null)
			{
				this.#n = new MarginSetupViewModel(this.DialogService);
			}
			return this.#n.#0Pb(#Rf, this.#c);
		}

		// Token: 0x06007F01 RID: 32513 RVA: 0x001BD800 File Offset: 0x001BBA00
		private void #9Jd(bool #aKd, Action #nd)
		{
			bool flag = this.#j;
			try
			{
				this.#j = false;
				\u0007.~\u007F(#nd);
			}
			finally
			{
				this.#j = flag;
				if (#aKd)
				{
					this.#4Jd();
				}
			}
		}

		// Token: 0x06007F02 RID: 32514 RVA: 0x001BD858 File Offset: 0x001BBA58
		private bool #bKd()
		{
			base.RaisePropertyChanged<ComboItem<PageSelectionMode>>(System.Linq.Expressions.Expression.Lambda<Func<ComboItem<PageSelectionMode>>>(\u0089\u0005.\u0081\u000F(\u0087\u0005.\u007F\u000F(this, \u001E.\u000F\u0002(typeof(PrintOptionsViewModelBase).TypeHandle)), (MethodInfo)\u0088\u0005.\u0080\u000F(methodof(PrintOptionsViewModelBase.#KJd()).MethodHandle)), new ParameterExpression[0]));
			base.RaisePropertyChanged<string>(System.Linq.Expressions.Expression.Lambda<Func<string>>(\u0089\u0005.\u0081\u000F(\u0087\u0005.\u007F\u000F(this, \u001E.\u000F\u0002(typeof(PrintOptionsViewModelBase).TypeHandle)), (MethodInfo)\u0088\u0005.\u0080\u000F(methodof(PrintOptionsViewModelBase.#QJd()).MethodHandle)), new ParameterExpression[0]));
			base.RemoveError(#Phc.#3hc(107279996));
			if (this.SelectedPageSelectionMode.Value == PageSelectionMode.Selection && !\u0003.\u0004(this.SelectedPages) && !this.#cKd())
			{
				this.AddError(#Phc.#3hc(107279996), StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringInvalidPageNumbersSpecified.#z2d());
				return false;
			}
			return true;
		}

		// Token: 0x06007F03 RID: 32515 RVA: 0x001BD96C File Offset: 0x001BBB6C
		private bool #cKd()
		{
			try
			{
				PrintOptionsViewModelBase.#EVd #EVd = new PrintOptionsViewModelBase.#EVd();
				#EVd.#a = this.OptionsSetup;
				if (#EVd.#a == null || #EVd.#a.PagesCount == null)
				{
					return false;
				}
				string text = this.SelectedPages;
				if (\u0003.\u0004(text))
				{
					return false;
				}
				IReadOnlyList<IPageSelection> readOnlyList = #FId.#1vb(text, 1, #EVd.#a.PagesCount.Value);
				if (readOnlyList == null)
				{
					return false;
				}
				if (readOnlyList.Any(new Func<IPageSelection, bool>(#EVd.#DVd)))
				{
					return false;
				}
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		// Token: 0x06007F04 RID: 32516 RVA: 0x001BDA3C File Offset: 0x001BBC3C
		private List<IPageSelection> #dKd()
		{
			List<IPageSelection> result;
			try
			{
				List<IPageSelection> list = new List<IPageSelection>();
				PrintOptionsSetup printOptionsSetup = this.OptionsSetup;
				if (printOptionsSetup == null || printOptionsSetup.PagesCount == null)
				{
					result = list;
				}
				else
				{
					int value = printOptionsSetup.PagesCount.Value;
					if (this.SelectedPageSelectionMode.Value == PageSelectionMode.AllPages)
					{
						list.Add(new #zId(1, value));
					}
					else if (this.SelectedPageSelectionMode.Value == PageSelectionMode.Selection)
					{
						IReadOnlyList<IPageSelection> readOnlyList = #FId.#1vb(this.SelectedPages, 1, value);
						if (readOnlyList == null)
						{
							return null;
						}
						list.AddRange(readOnlyList);
					}
					if (this.#f.Value != PageSelectionMode.CurrentPage && !list.Any<IPageSelection>())
					{
						list.Add(new #zId(1, value));
					}
					result = list;
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06007F05 RID: 32517 RVA: 0x001BDB28 File Offset: 0x001BBD28
		private void #eKd(PrinterItem #f)
		{
			PrintOptionsViewModelBase.#a9c #a9c = new PrintOptionsViewModelBase.#a9c();
			#a9c.#a = this;
			#a9c.#b = #f;
			this.#9Jd(true, new Action(#a9c.#FVd));
		}

		// Token: 0x06007F06 RID: 32518 RVA: 0x00067991 File Offset: 0x00065B91
		[CompilerGenerated]
		private bool #fKd(System.Drawing.Printing.PaperSize #Rf)
		{
			return \u008D\u0002.~\u0094\u0005(#Rf) == \u008D\u0002.~\u0094\u0005(this.SelectedPaperSize.PaperSize);
		}

		// Token: 0x06007F07 RID: 32519 RVA: 0x000679C1 File Offset: 0x00065BC1
		[CompilerGenerated]
		private bool #gKd()
		{
			return this.#bKd();
		}

		// Token: 0x06007F08 RID: 32520 RVA: 0x001BDB68 File Offset: 0x001BBD68
		[CompilerGenerated]
		private bool #hKd(PaperSizeItem #Rf)
		{
			return \u008D\u0002.~\u0094\u0005(#Rf.PaperSize) == \u008D\u0002.~\u0094\u0005(\u0017\u0005.~\u0006\u000F(\u0016\u0005.~\u0005\u000F(this.#k)));
		}

		// Token: 0x040033FA RID: 13306
		private PageMarginsViewModel #a;

		// Token: 0x040033FB RID: 13307
		private bool #b;

		// Token: 0x040033FC RID: 13308
		private string #c;

		// Token: 0x040033FD RID: 13309
		private PrinterItem #d;

		// Token: 0x040033FE RID: 13310
		private string #e;

		// Token: 0x040033FF RID: 13311
		private ComboItem<PageSelectionMode> #f;

		// Token: 0x04003400 RID: 13312
		private ComboItem<PaperOrientation> #g;

		// Token: 0x04003401 RID: 13313
		private PaperSizeItem #h;

		// Token: 0x04003402 RID: 13314
		private bool #i;

		// Token: 0x04003403 RID: 13315
		private bool #j = true;

		// Token: 0x04003404 RID: 13316
		private PrinterSettings #k;

		// Token: 0x04003405 RID: 13317
		private int #l;

		// Token: 0x04003406 RID: 13318
		private bool #m;

		// Token: 0x04003407 RID: 13319
		private MarginSetupViewModel #n;

		// Token: 0x04003408 RID: 13320
		private bool #o;

		// Token: 0x04003409 RID: 13321
		private readonly ILogger #p;

		// Token: 0x0400340A RID: 13322
		private Visibility #q;

		// Token: 0x0400340B RID: 13323
		[CompilerGenerated]
		private EventHandler #r;

		// Token: 0x0400340C RID: 13324
		[CompilerGenerated]
		private readonly #wUd #s;

		// Token: 0x0400340D RID: 13325
		[CompilerGenerated]
		private readonly #ATd #t;

		// Token: 0x0400340E RID: 13326
		[CompilerGenerated]
		private readonly DelegateCommand #u;

		// Token: 0x0400340F RID: 13327
		[CompilerGenerated]
		private readonly DelegateCommand #v;

		// Token: 0x04003410 RID: 13328
		[CompilerGenerated]
		private readonly RadObservableCollection<PrinterItem> #w;

		// Token: 0x04003411 RID: 13329
		[CompilerGenerated]
		private readonly RadObservableCollection<PaperSizeItem> #x;

		// Token: 0x04003412 RID: 13330
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<PageSelectionMode>> #y;

		// Token: 0x04003413 RID: 13331
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<PaperOrientation>> #z;

		// Token: 0x04003414 RID: 13332
		[CompilerGenerated]
		private readonly RadObservableCollection<PageMarginsViewModel> #A;

		// Token: 0x04003415 RID: 13333
		private string #B;

		// Token: 0x04003416 RID: 13334
		[CompilerGenerated]
		private PrintOptionsSetup #C;

		// Token: 0x04003417 RID: 13335
		[CompilerGenerated]
		private readonly #8Sc #D;

		// Token: 0x02000DB9 RID: 3513
		[CompilerGenerated]
		private sealed class #aUb
		{
			// Token: 0x06007F11 RID: 32529 RVA: 0x00067A32 File Offset: 0x00065C32
			internal bool #AVd(PrinterItem #Rf)
			{
				return \u0093.\u0017\u0003(#Rf.Value, this.#a);
			}

			// Token: 0x06007F12 RID: 32530 RVA: 0x00067A56 File Offset: 0x00065C56
			internal bool #BVd(PrinterItem #Rf)
			{
				return \u0093.\u0017\u0003(#Rf.Value, this.#b);
			}

			// Token: 0x0400341E RID: 13342
			public string #a;

			// Token: 0x0400341F RID: 13343
			public string #b;
		}

		// Token: 0x02000DBA RID: 3514
		[CompilerGenerated]
		private sealed class #PUb
		{
			// Token: 0x06007F14 RID: 32532 RVA: 0x00067A7A File Offset: 0x00065C7A
			internal bool #CVd(ComboItem<PaperOrientation> #Rf)
			{
				return #Rf.Value == this.#a;
			}

			// Token: 0x04003420 RID: 13344
			public PaperOrientation #a;
		}

		// Token: 0x02000DBB RID: 3515
		[CompilerGenerated]
		private sealed class #EVd
		{
			// Token: 0x06007F16 RID: 32534 RVA: 0x001BDBB8 File Offset: 0x001BBDB8
			internal bool #DVd(IPageSelection #Rf)
			{
				return #Rf.Start < 1 || #Rf.End > this.#a.PagesCount.Value;
			}

			// Token: 0x04003421 RID: 13345
			public PrintOptionsSetup #a;
		}

		// Token: 0x02000DBC RID: 3516
		[CompilerGenerated]
		private sealed class #a9c
		{
			// Token: 0x06007F18 RID: 32536 RVA: 0x001BDBF8 File Offset: 0x001BBDF8
			internal void #FVd()
			{
				this.#a.PaperSizes.Clear();
				this.#a.SelectedPaperSize = null;
				this.#a.#3Jd();
				if (this.#b == null)
				{
					return;
				}
				if (this.#a.IsRealPrinterSelected)
				{
					this.#a.#k = new PrinterSettings
					{
						PrinterName = this.#b.Value
					};
				}
				this.#a.PaperSizes.AddRange(this.#b.#UId());
				this.#a.SelectedPaperSize = this.#a.PaperSizes.FirstOrDefault(new Func<PaperSizeItem, bool>(PrintOptionsViewModelBase.<>c.<>9.#yVd));
			}

			// Token: 0x04003422 RID: 13346
			public PrintOptionsViewModelBase #a;

			// Token: 0x04003423 RID: 13347
			public PrinterItem #b;
		}

		// Token: 0x02000DBD RID: 3517
		[CompilerGenerated]
		private sealed class #3Tb
		{
			// Token: 0x06007F1A RID: 32538 RVA: 0x001BDCD8 File Offset: 0x001BBED8
			internal void #8bd()
			{
				try
				{
					this.#a.#c = this.#b.UnitString;
					this.#a.PageRangeOptionsVisibility = this.#b.PageRangeOptionsVisibility;
					this.#a.SelectedPageSelectionMode = this.#a.PageSelectionModes.First<ComboItem<PageSelectionMode>>();
					PrintOptionsViewModelBase printOptionsViewModelBase = this.#a;
					IEnumerable<ComboItem<PaperOrientation>> source = this.#a.PageOrientations;
					Func<ComboItem<PaperOrientation>, bool> predicate;
					if ((predicate = this.#c) == null)
					{
						predicate = (this.#c = new Func<ComboItem<PaperOrientation>, bool>(this.#rVd));
					}
					printOptionsViewModelBase.SelectedPageOrientation = (source.FirstOrDefault(predicate) ?? this.#a.PageOrientations.First<ComboItem<PaperOrientation>>());
					this.#a.Printers.Clear();
					this.#a.Printers.AddRange(#OId.#IId().Select(new Func<string, PrinterItem>(PrintOptionsViewModelBase.<>c.<>9.#uVd)));
					if (!this.#a.Printers.Any<PrinterItem>())
					{
						this.#a.Printers.Add(new #kJd());
					}
					this.#a.SelectedPrinter = this.#a.#5Jd(this.#b.PrinterName);
					if (this.#a.PaperSizes.Any<PaperSizeItem>())
					{
						PrintOptionsViewModelBase printOptionsViewModelBase2 = this.#a;
						IEnumerable<PaperSizeItem> source2 = this.#a.PaperSizes;
						Func<PaperSizeItem, bool> predicate2;
						if ((predicate2 = this.#d) == null)
						{
							predicate2 = (this.#d = new Func<PaperSizeItem, bool>(this.#sVd));
						}
						PaperSizeItem #f;
						if ((#f = source2.FirstOrDefault(predicate2)) == null)
						{
							#f = (this.#a.PaperSizes.FirstOrDefault(new Func<PaperSizeItem, bool>(PrintOptionsViewModelBase.<>c.<>9.#vVd)) ?? this.#a.PaperSizes.FirstOrDefault<PaperSizeItem>());
						}
						printOptionsViewModelBase2.SelectedPaperSize = #f;
					}
					else
					{
						this.#a.SelectedPaperSize = null;
					}
					this.#a.PageMargins.Clear();
					this.#a.PageMargins.AddRange(this.#b.PageMargins.Select(new Func<PageMarginsSpecification, PageMarginsViewModel>(PrintOptionsViewModelBase.<>c.<>9.#wVd)));
					PrintOptionsViewModelBase printOptionsViewModelBase3 = this.#a;
					IEnumerable<PageMarginsViewModel> source3 = this.#a.PageMargins;
					Func<PageMarginsViewModel, bool> predicate3;
					if ((predicate3 = this.#e) == null)
					{
						predicate3 = (this.#e = new Func<PageMarginsViewModel, bool>(this.#tVd));
					}
					PageMarginsViewModel #f2;
					if ((#f2 = source3.FirstOrDefault(predicate3)) == null)
					{
						#f2 = this.#a.PageMargins.FirstOrDefault(new Func<PageMarginsViewModel, bool>(PrintOptionsViewModelBase.<>c.<>9.#xVd));
					}
					printOptionsViewModelBase3.SelectedMargins = #f2;
				}
				catch (Exception exception)
				{
					this.#a.#p.Log(LoggingLevel.Error, exception);
					throw;
				}
			}

			// Token: 0x06007F1B RID: 32539 RVA: 0x00067A96 File Offset: 0x00065C96
			internal bool #rVd(ComboItem<PaperOrientation> #Rf)
			{
				return #Rf.Value == this.#b.PaperOrientation;
			}

			// Token: 0x06007F1C RID: 32540 RVA: 0x001BDFBC File Offset: 0x001BC1BC
			internal bool #sVd(PaperSizeItem #Rf)
			{
				Aspose.Words.PaperSize? paperSize = #Rf.AsposePaperSize;
				if (paperSize != null)
				{
					paperSize = #Rf.AsposePaperSize;
					Aspose.Words.PaperSize? paperSize2 = this.#b.AsposePaperSize;
					if (paperSize.GetValueOrDefault() == paperSize2.GetValueOrDefault() & paperSize != null == (paperSize2 != null))
					{
						return true;
					}
				}
				if (#Rf.PaperSize != null)
				{
					int num = \u008D\u0002.~\u0094\u0005(#Rf.PaperSize);
					int? num2 = this.#b.PaperRawKind;
					return num == num2.GetValueOrDefault() & num2 != null;
				}
				return false;
			}

			// Token: 0x06007F1D RID: 32541 RVA: 0x00067AB7 File Offset: 0x00065CB7
			internal bool #tVd(PageMarginsViewModel #Rf)
			{
				return #Rf.Key == this.#b.SelectedMarginType;
			}

			// Token: 0x04003424 RID: 13348
			public PrintOptionsViewModelBase #a;

			// Token: 0x04003425 RID: 13349
			public #gId #b;

			// Token: 0x04003426 RID: 13350
			public Func<ComboItem<PaperOrientation>, bool> #c;

			// Token: 0x04003427 RID: 13351
			public Func<PaperSizeItem, bool> #d;

			// Token: 0x04003428 RID: 13352
			public Func<PageMarginsViewModel, bool> #e;
		}

		// Token: 0x02000DBE RID: 3518
		[CompilerGenerated]
		private sealed class #NUb
		{
			// Token: 0x06007F1F RID: 32543 RVA: 0x00067AD8 File Offset: 0x00065CD8
			internal void #zVd()
			{
				this.#a.LinesPerPage = this.#b.NumberOfLinesPerPage;
				this.#a.UseLinesPerPageOptions = this.#b.LinesPerPageMode;
			}

			// Token: 0x04003429 RID: 13353
			public PrintOptionsViewModelBase #a;

			// Token: 0x0400342A RID: 13354
			public PrintOptionsSetup #b;
		}
	}
}
