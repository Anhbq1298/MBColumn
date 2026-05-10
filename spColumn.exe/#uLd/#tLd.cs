using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using #0Kd;
using #7hc;
using #ezc;
using #FTd;
using #hId;
using #hPd;
using #LQc;
using #mKd;
using #o1d;
using #qPd;
using #sUd;
using #v1c;
using #VEd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.Framework;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Application.API;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Printing;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Logger;
using Telerik.Windows.Controls;
using Telerik.Windows.Documents.Fixed;
using Telerik.Windows.Documents.Fixed.UI;

namespace #uLd
{
	// Token: 0x0200019B RID: 411
	internal abstract class #tLd : #CBc<#ZKd>, INotifyPropertyChanged, #RBc<#ZKd>, #sPd, IViewModel
	{
		// Token: 0x06000D66 RID: 3430 RVA: 0x0009E160 File Offset: 0x0009C360
		protected #tLd(#GBc #2x, #ZKd #Ee, ILogger #3x, #wUd #iw, #v2c #4x, #tUd #5x, #8Sc #ls, #xAc #6x) : base(#2x, #Ee, #3x)
		{
			if (#iw == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107381742));
			}
			this.#a = #iw;
			if (#4x == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107404926));
			}
			this.#b = #4x;
			if (#5x == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107409281));
			}
			this.#c = #5x;
			if (#ls == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107409397));
			}
			this.#d = #ls;
			if (#6x == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107408977));
			}
			this.#e = #6x;
			this.#n = new DelegateCommand(new Action<object>(this.#lLd), new Predicate<object>(this.#mLd));
			this.#o = new DelegateCommand(new Action<object>(this.#nLd), new Predicate<object>(this.#dA));
			base.View.PrintOptionsControl.PageSetupChanged += this.#gLd;
			base.View.WordAndPdfReportPage.Viewer.DocumentChanged += this.#fLd;
			base.View.WordAndPdfReportPage.Viewer.ScaleModeChanged += this.#eLd;
		}

		// Token: 0x17000550 RID: 1360
		// (get) Token: 0x06000D67 RID: 3431 RVA: 0x0001064B File Offset: 0x0000E84B
		// (set) Token: 0x06000D68 RID: 3432 RVA: 0x0009E2CC File Offset: 0x0009C4CC
		public GraphicalReporterResultActionType SelectedAction
		{
			get
			{
				return this.#f;
			}
			set
			{
				if (this.#f != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107278539));
					this.#f = value;
					this.#vh();
					base.RaisePropertyChanged(#Phc.#3hc(107278539));
				}
			}
		}

		// Token: 0x17000551 RID: 1361
		// (get) Token: 0x06000D69 RID: 3433 RVA: 0x00010657 File Offset: 0x0000E857
		// (set) Token: 0x06000D6A RID: 3434 RVA: 0x0009E31C File Offset: 0x0009C51C
		public string WindowTitle
		{
			get
			{
				return this.#i;
			}
			private set
			{
				if (\u0093.\u0015\u0003(this.#i, value))
				{
					base.RaisePropertyChanging(#Phc.#3hc(107383632));
					this.#i = value;
					base.RaisePropertyChanged(#Phc.#3hc(107383632));
				}
			}
		}

		// Token: 0x17000552 RID: 1362
		// (get) Token: 0x06000D6B RID: 3435 RVA: 0x00010663 File Offset: 0x0000E863
		public DelegateCommand PrintCommand { get; }

		// Token: 0x17000553 RID: 1363
		// (get) Token: 0x06000D6C RID: 3436 RVA: 0x0001066F File Offset: 0x0000E86F
		public DelegateCommand ExportCommand { get; }

		// Token: 0x17000554 RID: 1364
		// (get) Token: 0x06000D6D RID: 3437 RVA: 0x0001067B File Offset: 0x0000E87B
		// (set) Token: 0x06000D6E RID: 3438 RVA: 0x00010687 File Offset: 0x0000E887
		public #oPd GeneratorResult
		{
			get
			{
				return this.#k;
			}
			private set
			{
				this.#k = value;
				this.#vh();
			}
		}

		// Token: 0x17000555 RID: 1365
		// (get) Token: 0x06000D6F RID: 3439 RVA: 0x000106A2 File Offset: 0x0000E8A2
		// (set) Token: 0x06000D70 RID: 3440 RVA: 0x0009E370 File Offset: 0x0009C570
		public bool IsBusy
		{
			get
			{
				return this.#l;
			}
			private set
			{
				if (this.#l != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107413161));
					this.#l = value;
					this.#vh();
					base.RaisePropertyChanged(#Phc.#3hc(107413161));
				}
			}
		}

		// Token: 0x17000556 RID: 1366
		// (get) Token: 0x06000D71 RID: 3441 RVA: 0x000106AE File Offset: 0x0000E8AE
		// (set) Token: 0x06000D72 RID: 3442 RVA: 0x0009E3C0 File Offset: 0x0009C5C0
		public string BusyMessage
		{
			get
			{
				return this.#m;
			}
			private set
			{
				if (\u0093.\u0015\u0003(this.#m, value))
				{
					base.RaisePropertyChanging(#Phc.#3hc(107381157));
					this.#m = value;
					base.RaisePropertyChanged(#Phc.#3hc(107381157));
				}
			}
		}

		// Token: 0x17000557 RID: 1367
		// (get) Token: 0x06000D73 RID: 3443 RVA: 0x000106BA File Offset: 0x0000E8BA
		public #kPd Result { get; }

		// Token: 0x17000558 RID: 1368
		// (get) Token: 0x06000D74 RID: 3444 RVA: 0x000106C6 File Offset: 0x0000E8C6
		// (set) Token: 0x06000D75 RID: 3445 RVA: 0x000106D2 File Offset: 0x0000E8D2
		protected virtual string GeneratingBusyMessage { get; set; }

		// Token: 0x06000D76 RID: 3446
		protected abstract void #0x();

		// Token: 0x06000D77 RID: 3447 RVA: 0x0009E414 File Offset: 0x0009C614
		public virtual #kPd #0(#tPd #TKd, #gPd #Pc)
		{
			if (#Pc == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107395311));
			}
			if (#TKd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107278550));
			}
			this.#h = #TKd;
			this.GeneratorResult = null;
			this.#hLd(base.View.WordAndPdfReportPage.MyPdfViewer);
			this.SelectedAction = this.#a.GraphicalReporterResultActionType;
			this.Result.ResultAction = GraphicalReporterResultActionType.None;
			this.Result.PrintOptions = null;
			this.#WUc(#Pc);
			this.#kLd();
			base.View.#TBc();
			this.#a.GraphicalReporterResultActionType = this.SelectedAction;
			return this.Result;
		}

		// Token: 0x06000D78 RID: 3448 RVA: 0x0009E4E4 File Offset: 0x0009C6E4
		private void #eLd(object #Ge, EventArgs #He)
		{
			RadPdfViewer radPdfViewer = (RadPdfViewer)#Ge;
			RadPdfViewer radPdfViewer2;
			if (!false)
			{
				radPdfViewer2 = radPdfViewer;
			}
			if (\u0014\u0006.~\u0014\u0010(radPdfViewer2) == ScaleMode.Normal)
			{
				\u0016\u0006.~\u0016\u0010(radPdfViewer2, \u0015\u0006.~\u0015\u0010(radPdfViewer2, #Phc.#3hc(107278505)));
			}
		}

		// Token: 0x06000D79 RID: 3449 RVA: 0x0009E534 File Offset: 0x0009C734
		private void #fLd(object #Ge, DocumentChangedEventArgs #He)
		{
			#tLd.#WUb #WUb = new #tLd.#WUb();
			#WUb.#a = this;
			#WUb.#b = base.View.WordAndPdfReportPage.Viewer;
			if (#WUb.#b != #Ge || \u0017\u0006.~\u0017\u0010(#He) == null)
			{
				return;
			}
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(#WUb.#GVd));
		}

		// Token: 0x06000D7A RID: 3450 RVA: 0x000106E3 File Offset: 0x0000E8E3
		private void #gLd(object #Ge, EventArgs #He)
		{
			this.#kLd();
		}

		// Token: 0x06000D7B RID: 3451 RVA: 0x0009E59C File Offset: 0x0009C79C
		private void #hLd(RadPdfViewer #iLd)
		{
			if (\u0018\u0006.~\u0019\u0010(#iLd) == null)
			{
				return;
			}
			this.#j.Scale = \u001B\u0002.~\u0003\u0005(#iLd);
			this.#j.ScaleMode = \u0014\u0006.~\u0014\u0010(#iLd);
			\u0019\u0006.~\u001A\u0010(#iLd, null);
			\u001A\u0006.~\u001B\u0010(#iLd, null);
		}

		// Token: 0x06000D7C RID: 3452 RVA: 0x000106F3 File Offset: 0x0000E8F3
		private void #vh()
		{
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#qLd));
		}

		// Token: 0x06000D7D RID: 3453 RVA: 0x0009E608 File Offset: 0x0009C808
		private #jJd #ey()
		{
			#jJd options = base.View.PrintOptionsControl.GetOptions();
			PageMarginsSpecification #wId = options.Margins.#xId(this.#g.UnitSystem == ReporterUnitsSystem.English);
			options.Margins.#mg(#wId);
			options.FontInfo = ReportFontSizeInfoProvider.Instance.#3hc(this.#a.ReportFontSize);
			return options;
		}

		// Token: 0x06000D7E RID: 3454 RVA: 0x0009E674 File Offset: 0x0009C874
		private void #jLd(#jJd #mA)
		{
			try
			{
				#wUd #wUd = this.#a;
				#NTd #kUd = #NTd.#b;
				if (2 != 0)
				{
					#wUd.#mUd(#mA, #kUd);
				}
				this.GeneratorResult = this.#h.#fp(this.#g, #mA);
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#rLd));
			}
			catch (Exception ex)
			{
				#tLd.#oUb #oUb = new #tLd.#oUb();
				#oUb.#b = this;
				Exception ex2 = ex;
				#oUb.#a = ex2;
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(#oUb.#HVd));
			}
		}

		// Token: 0x06000D7F RID: 3455 RVA: 0x0009E704 File Offset: 0x0009C904
		private void #kLd()
		{
			#tLd.#l0b #l0b = new #tLd.#l0b();
			#l0b.#a = this;
			this.BusyMessage = this.GeneratingBusyMessage;
			this.IsBusy = true;
			#l0b.#b = this.#ey();
			LayoutHelper.DelayOperation(\u001C.\u0006\u0002(1.0), new Action(#l0b.#IVd));
		}

		// Token: 0x06000D80 RID: 3456 RVA: 0x0009E770 File Offset: 0x0009C970
		private void #lLd(object #Sb)
		{
			#tLd.#KVd #KVd;
			#KVd.#b = \u001B\u0006.\u001C\u0010();
			#KVd.#c = this;
			#KVd.#a = -1;
			#KVd.#b.Start<#tLd.#KVd>(ref #KVd);
		}

		// Token: 0x06000D81 RID: 3457 RVA: 0x0001070F File Offset: 0x0000E90F
		private bool #mLd(object #Sb)
		{
			return this.GeneratorResult != null;
		}

		// Token: 0x06000D82 RID: 3458 RVA: 0x0009E7B8 File Offset: 0x0009C9B8
		private void #nLd(object #Sb)
		{
			switch (this.SelectedAction)
			{
			case GraphicalReporterResultActionType.SaveToFileEmf:
			case GraphicalReporterResultActionType.SaveToFileBpm:
				this.#pLd();
				return;
			case GraphicalReporterResultActionType.AddToReport:
				this.Result.PrintOptions = this.#ey();
				this.Result.ResultAction = GraphicalReporterResultActionType.AddToReport;
				this.#d.#od(\u001C.\u0006\u0002(1.0), base.View as Window, \u008E.\u009B\u0002().#z2d(), this.#e.ApplicationName, MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK, MessageBoxOptions.None);
				return;
			case GraphicalReporterResultActionType.SendToClipboard:
				this.#oLd();
				return;
			default:
				return;
			}
		}

		// Token: 0x06000D83 RID: 3459 RVA: 0x0001070F File Offset: 0x0000E90F
		private bool #dA(object #Sb)
		{
			return this.GeneratorResult != null;
		}

		// Token: 0x06000D84 RID: 3460 RVA: 0x0009E878 File Offset: 0x0009CA78
		private void #oLd()
		{
			try
			{
				MemoryStream memoryStream = new MemoryStream();
				try
				{
					this.#k.Document.#aFd(memoryStream, SaveFormat.Png, 2, null);
					memoryStream.#i2d();
					\u001D\u0006 u001E_u = \u001D\u0006.\u001E\u0010;
					BitmapImage bitmapImage = new BitmapImage();
					bitmapImage.BeginInit();
					bitmapImage.StreamSource = memoryStream;
					bitmapImage.CacheOption = BitmapCacheOption.None;
					bitmapImage.EndInit();
					u001E_u(bitmapImage);
					this.#d.#od(\u008E.\u009C\u0002().#z2d(), MessageBoxButton.OK, MessageBoxImage.Asterisk);
				}
				finally
				{
					if (memoryStream != null)
					{
						\u0007.~\u000E(memoryStream);
					}
				}
			}
			catch (Exception #ob)
			{
				this.#c.#3Ab(\u008E.\u009D\u0002().#z2d(), #ob);
			}
		}

		// Token: 0x06000D85 RID: 3461 RVA: 0x0009E95C File Offset: 0x0009CB5C
		private void #pLd()
		{
			string text = string.Empty;
			try
			{
				#L1c[] array;
				if (this.SelectedAction != GraphicalReporterResultActionType.SaveToFileEmf)
				{
					(array = new #L1c[1])[0] = new #L1c(\u008E.\u009E\u0002(), #Phc.#3hc(107278468));
				}
				else
				{
					(array = new #L1c[1])[0] = new #L1c(\u008E.\u009F\u0002(), #Phc.#3hc(107278495));
				}
				#L1c[] array2 = array;
				string text2 = \u0003.\u0004(this.#g.FilePath) ? \u001E\u0006.\u001F\u0010(Environment.SpecialFolder.Personal) : \u009D.\u0099\u0003(this.#g.FilePath);
				if (!this.#b.#X1c(text2))
				{
					text2 = \u001E\u0006.\u001F\u0010(Environment.SpecialFolder.Desktop);
				}
				string text3 = this.#b.#V1c(this.#g.FilePath) ? \u0019.\u0003\u0002(\u009D.\u009A\u0003(this.#g.FilePath), array2[0].Extension) : this.#g.FilePath;
				if (\u0003.\u0004(text3))
				{
					text3 = \u008E.\u0001\u0003();
				}
				#L1c #L1c;
				text = this.#b.#11c(new #62c(array2, array2[0].Extension, text2)
				{
					InitialFileName = text3
				}, out #L1c);
				if (!\u0003.\u0004(text))
				{
					Stream stream = this.#b.#T1c(text);
					try
					{
						SaveFormat #cA = (this.SelectedAction == GraphicalReporterResultActionType.SaveToFileBpm) ? SaveFormat.Bmp : SaveFormat.Emf;
						this.#k.Document.#aFd(stream, #cA, 3, null);
					}
					finally
					{
						if (stream != null)
						{
							\u0007.~\u000E(stream);
						}
					}
					this.#d.#od(\u008E.\u0002\u0003().#z2d(), MessageBoxButton.OK, MessageBoxImage.Asterisk);
				}
			}
			catch (Exception #ob)
			{
				this.#c.#3Ab(\u008E.\u0003\u0003().#D2d(new object[]
				{
					text
				}).#z2d(), #ob);
			}
		}

		// Token: 0x06000D86 RID: 3462 RVA: 0x0009EB9C File Offset: 0x0009CD9C
		private void #WUc(#gPd #Pc)
		{
			this.#g = #Pc;
			base.View.SetViewModel(this);
			base.View.SetOwner(#Pc.WindowOwner);
			this.#0x();
			this.WindowTitle = #Phc.#3hc(107278490).#G2d(true) + (\u0003.\u0004(#Pc.FilePath) ? \u008E.\u0001\u0003() : \u009D.\u009A\u0003(#Pc.FilePath));
		}

		// Token: 0x06000D87 RID: 3463 RVA: 0x00010722 File Offset: 0x0000E922
		[CompilerGenerated]
		private void #qLd()
		{
			\u0007.~\u000F(this.PrintCommand);
			\u0007.~\u000F(this.ExportCommand);
		}

		// Token: 0x06000D88 RID: 3464 RVA: 0x0009EC34 File Offset: 0x0009CE34
		[CompilerGenerated]
		private void #rLd()
		{
			this.IsBusy = false;
			FixedDocumentViewerBase viewer = base.View.WordAndPdfReportPage.Viewer;
			#oPd #oPd = this.GeneratorResult;
			viewer.DocumentSource = ((((#oPd != null) ? #oPd.PdfReport : null) != null) ? new PdfDocumentSource(this.GeneratorResult.PdfReport) : null);
		}

		// Token: 0x06000D89 RID: 3465 RVA: 0x00010750 File Offset: 0x0000E950
		[CompilerGenerated]
		private void #sLd()
		{
			AsposeDocumentPrinter.#SHd(this.#k.Document, this.#ey());
		}

		// Token: 0x04000506 RID: 1286
		private readonly #wUd #a;

		// Token: 0x04000507 RID: 1287
		private readonly #v2c #b;

		// Token: 0x04000508 RID: 1288
		private readonly #tUd #c;

		// Token: 0x04000509 RID: 1289
		private readonly #8Sc #d;

		// Token: 0x0400050A RID: 1290
		private readonly #xAc #e;

		// Token: 0x0400050B RID: 1291
		private GraphicalReporterResultActionType #f;

		// Token: 0x0400050C RID: 1292
		private #gPd #g;

		// Token: 0x0400050D RID: 1293
		private #tPd #h;

		// Token: 0x0400050E RID: 1294
		private string #i;

		// Token: 0x0400050F RID: 1295
		private readonly #wKd #j = new #wKd();

		// Token: 0x04000510 RID: 1296
		private #oPd #k;

		// Token: 0x04000511 RID: 1297
		private bool #l;

		// Token: 0x04000512 RID: 1298
		private string #m;

		// Token: 0x04000513 RID: 1299
		[CompilerGenerated]
		private readonly DelegateCommand #n;

		// Token: 0x04000514 RID: 1300
		[CompilerGenerated]
		private readonly DelegateCommand #o;

		// Token: 0x04000515 RID: 1301
		[CompilerGenerated]
		private readonly #kPd #p = new #kPd();

		// Token: 0x04000516 RID: 1302
		[CompilerGenerated]
		private string #q = StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringGeneratingReport.#B2d();

		// Token: 0x0200019C RID: 412
		[CompilerGenerated]
		private sealed class #WUb
		{
			// Token: 0x06000D8B RID: 3467 RVA: 0x0009EC90 File Offset: 0x0009CE90
			internal void #GVd()
			{
				try
				{
					if (this.#a.#j.IsFirstDocumentChange)
					{
						\u008A.~\u0093\u0002(\u000F\u0006.~\u000F\u0010(\u0002\u0006.~\u009E\u000F(\u0001\u0006.~\u009D\u000F(this.#b))), null);
						this.#a.#j.IsFirstDocumentChange = false;
					}
					else if (this.#a.#j.ScaleMode == ScaleMode.Normal)
					{
						if (this.#a.#j.Scale > 0.0)
						{
							\u009F\u0002.~\u0095\u0006(this.#b, this.#a.#j.Scale);
						}
					}
					else if (this.#a.#j.ScaleMode == ScaleMode.FitToWidth)
					{
						\u008A.~\u0093\u0002(\u000F\u0006.~\u000F\u0010(\u0002\u0006.~\u009F\u000F(\u0001\u0006.~\u009D\u000F(this.#b))), null);
					}
					else if (this.#a.#j.ScaleMode == ScaleMode.FitToPage)
					{
						\u008A.~\u0093\u0002(\u000F\u0006.~\u000F\u0010(\u0002\u0006.~\u009E\u000F(\u0001\u0006.~\u009D\u000F(this.#b))), null);
					}
				}
				catch (Exception exception)
				{
					this.#a.Logger.Log(LoggingLevel.Error, exception);
				}
			}

			// Token: 0x04000517 RID: 1303
			public #tLd #a;

			// Token: 0x04000518 RID: 1304
			public RadPdfViewer #b;
		}

		// Token: 0x0200019D RID: 413
		[CompilerGenerated]
		private sealed class #oUb
		{
			// Token: 0x06000D8D RID: 3469 RVA: 0x0009EE20 File Offset: 0x0009D020
			internal void #HVd()
			{
				this.#b.IsBusy = false;
				\u0019\u0006.~\u001A\u0010(this.#b.View.WordAndPdfReportPage.Viewer, null);
				this.#b.#c.#3Ab(\u008E.\u0007\u0003().#z2d(), this.#a);
			}

			// Token: 0x04000519 RID: 1305
			public Exception #a;

			// Token: 0x0400051A RID: 1306
			public #tLd #b;
		}

		// Token: 0x0200019E RID: 414
		[CompilerGenerated]
		private sealed class #l0b
		{
			// Token: 0x06000D8F RID: 3471 RVA: 0x0009EE8C File Offset: 0x0009D08C
			internal void #IVd()
			{
				TaskFactory taskFactory = \u0081\u0006.\u0082\u0010();
				Action action;
				if ((action = this.#c) == null)
				{
					action = (this.#c = new Action(this.#JVd));
				}
				taskFactory.StartNew(action);
			}

			// Token: 0x06000D90 RID: 3472 RVA: 0x00010774 File Offset: 0x0000E974
			internal void #JVd()
			{
				this.#a.#jLd(this.#b);
			}

			// Token: 0x0400051B RID: 1307
			public #tLd #a;

			// Token: 0x0400051C RID: 1308
			public #jJd #b;

			// Token: 0x0400051D RID: 1309
			public Action #c;
		}
	}
}
