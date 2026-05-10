using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using #12e;
using #3Qb;
using #7hc;
using #9I;
using #cYd;
using #eU;
using #g7e;
using #kB;
using #lH;
using #Mn;
using #nc;
using #P6e;
using #qJ;
using #qPb;
using #UYd;
using #wqe;
using #Wse;
using #y6e;
using Alphaleonis.Win32.Filesystem;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Communication;
using StructurePoint.CoreAssets.AppManager.Column.Reporting;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.Editor.Section;
using StructurePoint.Products.Column.Services.API;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.ViewModels.Solver
{
	// Token: 0x02000122 RID: 290
	internal sealed class SolverWindowViewModel : #HH<#mc>, INotifyPropertyChanged, IViewModel<IColumnWindow>, IViewModel, #8I
	{
		// Token: 0x0600097A RID: 2426 RVA: 0x000963A8 File Offset: 0x000945A8
		public SolverWindowViewModel(Lazy<#mc> view, #wU commandsManager, IExtendedServices services, #qW designEngineService, #UV messageBus, #zJ designEngineAvailabilityChecker, #LJ modelValidationService, #lB reporterDataProvider, #AWh leftPanelErrorsChecker) : base(view, services)
		{
			this.#a = commandsManager;
			this.#b = services;
			this.#c = designEngineService;
			this.#d = messageBus;
			this.#e = designEngineAvailabilityChecker;
			this.#f = modelValidationService;
			this.#g = reporterDataProvider;
			this.#h = leftPanelErrorsChecker;
			this.#l = new #yp(base.Project);
			this.#F = new DelegateCommand(new Action<object>(this.#Tp));
			this.#G = new DelegateCommand(new Action<object>(this.#Up));
			this.#C = new DispatcherTimer(TimeSpan.FromMilliseconds(100.0), DispatcherPriority.Normal, new EventHandler(this.#mTh), Dispatcher.CurrentDispatcher);
		}

		// Token: 0x170003F6 RID: 1014
		// (get) Token: 0x0600097B RID: 2427 RVA: 0x0000D3C5 File Offset: 0x0000B5C5
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x170003F7 RID: 1015
		// (get) Token: 0x0600097C RID: 2428 RVA: 0x0000D3D5 File Offset: 0x0000B5D5
		public DelegateCommand ExecuteCloseCommand { get; }

		// Token: 0x170003F8 RID: 1016
		// (get) Token: 0x0600097D RID: 2429 RVA: 0x0000D3E1 File Offset: 0x0000B5E1
		public DelegateCommand ExecuteCancelCommand { get; }

		// Token: 0x170003F9 RID: 1017
		// (get) Token: 0x0600097E RID: 2430 RVA: 0x0000D3ED File Offset: 0x0000B5ED
		public new IColumnWindow View
		{
			get
			{
				return base.View;
			}
		}

		// Token: 0x170003FA RID: 1018
		// (get) Token: 0x0600097F RID: 2431 RVA: 0x0000D3FD File Offset: 0x0000B5FD
		public CustomObservableCollection<AnalysisReportItem> ReportItems { get; }

		// Token: 0x170003FB RID: 1019
		// (get) Token: 0x06000980 RID: 2432 RVA: 0x0000D409 File Offset: 0x0000B609
		// (set) Token: 0x06000981 RID: 2433 RVA: 0x0000D415 File Offset: 0x0000B615
		public string ProcessingStateMsg
		{
			get
			{
				return this.#i;
			}
			private set
			{
				this.SetProperty<string>(ref this.#i, value, #Phc.#3hc(107413056));
			}
		}

		// Token: 0x170003FC RID: 1020
		// (get) Token: 0x06000982 RID: 2434 RVA: 0x0000D43B File Offset: 0x0000B63B
		// (set) Token: 0x06000983 RID: 2435 RVA: 0x0000D447 File Offset: 0x0000B647
		public int Progress
		{
			get
			{
				return this.#j;
			}
			private set
			{
				this.SetProperty<int>(ref this.#j, value, #Phc.#3hc(107413031));
			}
		}

		// Token: 0x170003FD RID: 1021
		// (get) Token: 0x06000984 RID: 2436 RVA: 0x0000D46D File Offset: 0x0000B66D
		// (set) Token: 0x06000985 RID: 2437 RVA: 0x0000D479 File Offset: 0x0000B679
		public bool ProcessingComplete
		{
			get
			{
				return this.#v;
			}
			set
			{
				this.SetProperty<bool>(ref this.#v, value, #Phc.#3hc(107413050));
			}
		}

		// Token: 0x170003FE RID: 1022
		// (get) Token: 0x06000986 RID: 2438 RVA: 0x0000D49F File Offset: 0x0000B69F
		// (set) Token: 0x06000987 RID: 2439 RVA: 0x0000D4AB File Offset: 0x0000B6AB
		public bool IsWorking
		{
			get
			{
				return this.#w;
			}
			private set
			{
				this.SetProperty<bool>(ref this.#w, value, #Phc.#3hc(107412993));
			}
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x0000D4D1 File Offset: 0x0000B6D1
		protected override void #uh(#mc #Ee)
		{
			base.#uh(#Ee);
			#Ee.Closing += this.#Dh;
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x000964E8 File Offset: 0x000946E8
		public bool #od(bool #Jp = false)
		{
			if (this.#A.#YXd())
			{
				try
				{
					Window #WSc = base.Services.WindowLocator.#VP() as Window;
					#SJ #SJ = this.#f.#IH(base.Project.Model);
					if (!#SJ.IsValid)
					{
						string #SSc = base.DialogService.#5Sc(Strings.StringCannotSolveTheModel, #SJ.FormattedErrors);
						base.DialogService.#qn(#WSc, #SSc);
						return false;
					}
					if (this.#h.#wWh(true, true, true))
					{
						string #SSc2 = base.DialogService.#5Sc(Strings.StringCannotSolveTheModel, Strings.StringPleaseFixTheErrorsInTheLeftPanel.#z2d());
						base.DialogService.#qn(#WSc, #SSc2);
						return false;
					}
					IList<Message> list = this.#Mp();
					if (list.Any<Message>())
					{
						this.#Kp(list);
						return false;
					}
					if (#SJ.Warnings.Any(new Func<ValidationFailure, bool>(SolverWindowViewModel.<>c.<>9.#6Wh)))
					{
						string #SSc3 = base.DialogService.#5Sc(Strings.StringSectionContainsOverlappingBars, Strings.StringDoYouWantToContinue.#J2d());
						MessageBoxResult messageBoxResult = base.DialogService.#od(#WSc, #SSc3, MessageBoxButton.OKCancel, MessageBoxImage.Exclamation, MessageBoxResult.OK, MessageBoxOptions.None);
						if (messageBoxResult != MessageBoxResult.OK)
						{
							return false;
						}
					}
					this.#m = #Jp;
					this.#Vp();
					this.#0();
					this.View.SetOwner(base.Services.WindowLocator.#VP());
					this.View.ShowDialog();
					this.#Wp();
				}
				finally
				{
					this.#A.#ZXd();
				}
				return true;
			}
			return true;
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x0000D4F8 File Offset: 0x0000B6F8
		private void #Dh(object #Ge, CancelEventArgs #He)
		{
			if (this.IsWorking && !this.#k)
			{
				#He.Cancel = true;
				this.#Up(null);
			}
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x000966BC File Offset: 0x000948BC
		private void #Np(object #Ge, #pW #He)
		{
			#g7e.#nW #nW;
			if (#He == null)
			{
				#nW = null;
			}
			else
			{
				DesignEngine designEngine = #He.DesignEngine;
				#nW = ((designEngine != null) ? designEngine.MessageBus : null);
			}
			#g7e.#nW #nW2 = #nW;
			if (#nW2 == null)
			{
				return;
			}
			#nW2.DialogRequested += this.#Rp;
			#nW2.NotificationOccurred += this.#2p;
			#nW2.ProgressChanged += this.#Qp;
			#nW2.SolveProcessStarted += this.#Pp;
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x0009673C File Offset: 0x0009493C
		private void #Op(object #Ge, #pW #He)
		{
			#g7e.#nW #nW;
			if (#He == null)
			{
				#nW = null;
			}
			else
			{
				DesignEngine designEngine = #He.DesignEngine;
				#nW = ((designEngine != null) ? designEngine.MessageBus : null);
			}
			#g7e.#nW #nW2 = #nW;
			if (#nW2 != null)
			{
				#nW2.NotificationOccurred -= this.#2p;
				#nW2.DialogRequested -= this.#Rp;
				#nW2.ProgressChanged -= this.#Qp;
				#nW2.SolveProcessStarted -= this.#Pp;
			}
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x00009E6A File Offset: 0x0000806A
		private void #Pp(object #Ge, CancelEventArgs #He)
		{
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x000967BC File Offset: 0x000949BC
		private void #Qp(object #Ge, #q7e #He)
		{
			if (this.#k)
			{
				if (!this.#x)
				{
					this.#4p(Strings.StringCancel, true, null);
				}
				this.#x = true;
				#He.Cancel = true;
				return;
			}
			#q7e.#Mif? #Mif = #He.SolveProcessStage;
			if (#Mif != null)
			{
				switch (#Mif.GetValueOrDefault())
				{
				case #q7e.#Mif.#a:
					this.ProcessingStateMsg = this.#l.#up(#He.SolveProcessStage);
					if (!this.#o)
					{
						this.#4p(this.ProcessingStateMsg, true, null);
					}
					this.#o = true;
					break;
				case #q7e.#Mif.#b:
					this.ProcessingStateMsg = this.#l.#up(#He.SolveProcessStage);
					if (!this.#p)
					{
						this.#4p(this.ProcessingStateMsg, true, null);
					}
					this.#p = true;
					break;
				case #q7e.#Mif.#c:
					this.ProcessingStateMsg = string.Format(Strings.StringComputingCapacityOfLoadNo0Of1, #He.Current, #He.Total);
					if (!this.#n)
					{
						this.#4p(this.#l.#up(#He.SolveProcessStage) ?? #Phc.#3hc(107381628), true, null);
					}
					this.#n = true;
					break;
				}
			}
			this.Progress = #He.ProgressPercentage.GetValueOrDefault();
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x00096944 File Offset: 0x00094B44
		private void #Rp(object #Ge, #w7e #He)
		{
			MessageBoxResult messageBoxResult = this.#Sp(#He);
			if (messageBoxResult == MessageBoxResult.Cancel)
			{
				this.#k = true;
				return;
			}
			#He.Response = (messageBoxResult == MessageBoxResult.Yes || messageBoxResult == MessageBoxResult.OK);
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x00096984 File Offset: 0x00094B84
		private void #mTh(object #Ge, EventArgs #Lg)
		{
			if (this.#E.#YXd())
			{
				try
				{
					List<AnalysisReportItem> list = null;
					List<AnalysisReportItem> list2;
					if (!false)
					{
						list2 = list;
					}
					if (this.#I.TryEnterReadLock(10))
					{
						try
						{
							list2 = this.#z.Skip(this.#D).ToList<AnalysisReportItem>();
							this.#D += list2.Count;
						}
						finally
						{
							this.#I.ExitReadLock();
						}
					}
					if (list2 != null)
					{
						this.ReportItems.#pR(list2);
						if (this.ReportItems.Count > 1000)
						{
							this.ReportItems.#B3h(500);
						}
					}
				}
				catch (Exception exception)
				{
					base.Logger.Log(LoggingLevel.Error, exception);
				}
				finally
				{
					this.#E.#ZXd();
				}
			}
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x00096A80 File Offset: 0x00094C80
		private void #Kp(IEnumerable<Message> #Lp)
		{
			IEnumerable<string> values = #Lp.Select(new Func<Message, string>(this.#nTh));
			string #Ukc = string.Join(Environment.NewLine, values);
			string #SSc = base.DialogService.#5Sc(Strings.StringCannotSolveTheModel, #Ukc);
			base.DialogService.#qn(base.MainWindow, #SSc);
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x00096ADC File Offset: 0x00094CDC
		private IList<Message> #Mp()
		{
			ColumnStorageModel storageModel = this.#b.Project.Model.#CY();
			#O6e configuration = new #O6e(this.#b.Settings.DiagramInterpolationConvergenceEpsilonPercentage);
			DesignEngine designEngine = new DesignEngine(storageModel, configuration);
			if (!designEngine.#qOe())
			{
				return designEngine.OutputModel.Messages.Where(new Func<Message, bool>(this.#oTh)).ToList<Message>();
			}
			return new List<Message>();
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x00096B58 File Offset: 0x00094D58
		private MessageBoxResult #Sp(#w7e #He)
		{
			SolverWindowViewModel.#nVb #nVb = new SolverWindowViewModel.#nVb();
			#nVb.#b = this;
			#nVb.#d = this.#l.#rp(#He.Question);
			#nVb.#c = (this.View as Window);
			#nVb.#e = new ManualResetEvent(false);
			#nVb.#a = MessageBoxResult.None;
			#w7e.#Nif #Nif = #He.Question;
			if (#Nif == #w7e.#Nif.#a)
			{
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(#nVb.#ZVb));
				#nVb.#e.WaitOne();
				#nVb.#e.Close();
				return #nVb.#a;
			}
			if (#Nif - #w7e.#Nif.#b > 1)
			{
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107413012), #He.Question, null);
			}
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(#nVb.#0Vb));
			#nVb.#e.WaitOne();
			#nVb.#e.Close();
			return #nVb.#a;
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x0000D524 File Offset: 0x0000B724
		private void #Tp(object #Vg)
		{
			this.View.Close();
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x0000D53D File Offset: 0x0000B73D
		private void #Up(object #Vg)
		{
			this.#k = true;
			this.ProcessingStateMsg = Strings.StringCancelling.#B2d();
			Thread thread = this.#B;
			if (thread == null)
			{
				return;
			}
			thread.Abort();
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x00096C58 File Offset: 0x00094E58
		private void #Vp()
		{
			this.#D = 0;
			this.#g.SolverMessages.Clear();
			base.#EH();
			this.#n = false;
			this.#p = false;
			this.#o = false;
			this.#k = false;
			this.ProcessingStateMsg = Strings.StringRunningSolver.#B2d();
			this.ReportItems.Clear();
			this.#z.Clear();
			this.Progress = 0;
			this.#q = false;
			this.#s = false;
			this.#r = false;
			this.ProcessingComplete = false;
			this.#t = false;
			this.IsWorking = false;
			this.#x = false;
			this.#y = false;
			this.#C.IsEnabled = true;
			this.#c.StartingCalculations += this.#Np;
			this.#c.FinishedCalculations += this.#Op;
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x00096D5C File Offset: 0x00094F5C
		private void #Wp()
		{
			this.#C.IsEnabled = false;
			this.#c.StartingCalculations -= this.#Np;
			this.#c.FinishedCalculations -= this.#Op;
			if (this.#t)
			{
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#pTh));
				return;
			}
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#qTh));
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x00096DDC File Offset: 0x00094FDC
		private bool #Xp(out string #Yp)
		{
			#2Qb #2Qb = base.Services.Settings.#XN();
			#Yp = string.Empty;
			if (!string.IsNullOrWhiteSpace(base.Project.LoadedFilePath))
			{
				#Yp = Path.ChangeExtension(base.Project.LoadedFilePath, #Phc.#3hc(107413479));
			}
			if (#2Qb.AutomaticallyGenerateTextResultsFile && !string.IsNullOrWhiteSpace(#Yp) && base.FileSystem.#V1c(#Yp))
			{
				base.FileSystem.#W1c(#Yp);
			}
			return #2Qb.AutomaticallyGenerateTextResultsFile && !string.IsNullOrWhiteSpace(#Yp);
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x00096E90 File Offset: 0x00095090
		private void #0()
		{
			this.IsWorking = true;
			try
			{
				this.#B = new Thread(new ThreadStart(this.#rTh));
				this.#B.Start();
			}
			catch (ThreadAbortException)
			{
				this.#Zp();
			}
			catch (OperationCanceledException)
			{
				this.#Zp();
			}
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x0000D572 File Offset: 0x0000B772
		private void #Zp()
		{
			this.IsWorking = false;
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#wTh));
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x00096F04 File Offset: 0x00095104
		public static Message.EnumType #0p(Message #5, bool #1p)
		{
			switch (#5.Code)
			{
			case #M6e.#a:
			case #M6e.#b:
			case #M6e.#c:
			case #M6e.#f:
			case #M6e.#g:
			case #M6e.#i:
			case #M6e.#k:
			case #M6e.#r:
			case #M6e.#s:
			case #M6e.#t:
			case #M6e.#u:
			case #M6e.#v:
			case #M6e.#w:
			case #M6e.#A:
				return Message.EnumType.Error;
			case #M6e.#d:
			case #M6e.#h:
			case #M6e.#j:
			case #M6e.#l:
			case #M6e.#m:
			case #M6e.#n:
			case #M6e.#o:
			case #M6e.#p:
			case #M6e.#y:
			case #M6e.#z:
				return Message.EnumType.Warning;
			case #M6e.#e:
				if (!#1p)
				{
					return #5.Type;
				}
				return Message.EnumType.Warning;
			}
			return #5.Type;
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x0000D599 File Offset: 0x0000B799
		private void #2p(object #Ge, #k7e #He)
		{
			if (this.#k)
			{
				return;
			}
			this.#3p(#He);
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x00096FC0 File Offset: 0x000951C0
		private void #3p(#k7e #op)
		{
			string text = this.#bq(#op.Message);
			if (string.IsNullOrWhiteSpace(text))
			{
				return;
			}
			Message.EnumType enumType = SolverWindowViewModel.#0p(#op.Message, false);
			this.#q = (this.#q || enumType == Message.EnumType.Error);
			this.#s = (this.#s || enumType == Message.EnumType.Warning);
			this.#r = (this.#r || enumType == Message.EnumType.Note);
			string text2 = this.#l.#pp(#op.Message);
			text = (text ?? #Phc.#3hc(107381628));
			this.#4p(string.Concat(new string[]
			{
				Environment.NewLine,
				text,
				Environment.NewLine,
				text2,
				Environment.NewLine
			}), false, new Message.EnumType?(enumType));
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x000970A8 File Offset: 0x000952A8
		private void #4p(string #5, bool #5p, Message.EnumType? #C = null)
		{
			string text = DateTime.Now.ToString(#Phc.#3hc(107413474)) + #Phc.#3hc(107382888);
			if (#5p)
			{
				List<AnalysisReportItem> list = new List<AnalysisReportItem>();
				AnalysisReportItem analysisReportItem = new AnalysisReportItem();
				analysisReportItem.Text = #5;
				analysisReportItem.Prefix = (string.IsNullOrWhiteSpace(#5) ? string.Empty : text);
				Message.EnumType? enumType = #C;
				Message.EnumType enumType2 = Message.EnumType.Error;
				analysisReportItem.IsError = (enumType.GetValueOrDefault() == enumType2 & enumType != null);
				enumType = #C;
				enumType2 = Message.EnumType.Warning;
				analysisReportItem.IsWarning = (enumType.GetValueOrDefault() == enumType2 & enumType != null);
				list.Add(analysisReportItem);
				this.#9p(list);
				return;
			}
			if (!this.#z.Any<AnalysisReportItem>() || (#5.StartsWith(Environment.NewLine) && this.#z.Last<AnalysisReportItem>().Text.EndsWith(Environment.NewLine)))
			{
				#5 = #5.TrimStart(Array.Empty<char>());
			}
			List<string> list2 = #5.Split(new string[]
			{
				Environment.NewLine
			}, StringSplitOptions.None).ToList<string>();
			for (int i = list2.Count - 1; i >= 0; i--)
			{
				string text2 = list2[i].#12d(75).TrimEnd(Array.Empty<char>());
				string[] collection = text2.Split(new string[]
				{
					Environment.NewLine
				}, StringSplitOptions.None);
				list2.RemoveAt(i);
				list2.InsertRange(i, collection);
			}
			List<AnalysisReportItem> list3 = new List<AnalysisReportItem>();
			bool flag = false;
			for (int j = 0; j < list2.Count; j++)
			{
				string value = list2[j];
				string text3 = string.Empty;
				if (!flag)
				{
					if (!string.IsNullOrWhiteSpace(value))
					{
						text3 = text;
						flag = true;
					}
				}
				else if (!string.IsNullOrWhiteSpace(value))
				{
					text3 = string.Empty.PadLeft(text.Length);
				}
				List<AnalysisReportItem> list4 = list3;
				AnalysisReportItem analysisReportItem2 = new AnalysisReportItem();
				analysisReportItem2.Text = value;
				analysisReportItem2.Prefix = text3;
				Message.EnumType? enumType = #C;
				Message.EnumType enumType2 = Message.EnumType.Error;
				analysisReportItem2.IsError = (enumType.GetValueOrDefault() == enumType2 & enumType != null);
				enumType = #C;
				enumType2 = Message.EnumType.Warning;
				analysisReportItem2.IsWarning = (enumType.GetValueOrDefault() == enumType2 & enumType != null);
				list4.Add(analysisReportItem2);
			}
			this.#9p(list3);
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x000972EC File Offset: 0x000954EC
		private void #6p(IList<AnalysisReportItem> #7p, List<AnalysisReportItem> #8p)
		{
			if (!#7p.Any<AnalysisReportItem>())
			{
				AnalysisReportItem.#Wm(#8p);
				#8p.Add(AnalysisReportItem.#Tm());
			}
			else if (#8p.Count > 1)
			{
				#8p.Insert(0, AnalysisReportItem.#Tm());
			}
			AnalysisReportItem.#Um(#8p);
			#7p.#pR(new ICollection<AnalysisReportItem>[]
			{
				#8p
			});
			AnalysisReportItem.#Vm(#7p);
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x00097354 File Offset: 0x00095554
		private void #9p(List<AnalysisReportItem> #8f)
		{
			this.#I.EnterWriteLock();
			try
			{
				this.#6p(this.#z, #8f.ToList<AnalysisReportItem>());
			}
			finally
			{
				this.#I.ExitWriteLock();
			}
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x000973A8 File Offset: 0x000955A8
		private void #aq()
		{
			this.ProcessingStateMsg = Strings.StringProcessingComplete.#z2d();
			if (this.#q)
			{
				this.#4p(string.Empty, true, null);
				this.#4p(Strings.StringSolverInterrupted.#z2d(), true, new Message.EnumType?(Message.EnumType.Error));
				return;
			}
			this.#4p(string.Empty, true, null);
			this.#4p(Strings.StringSolutionCompleted, true, null);
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x00097434 File Offset: 0x00095634
		private string #bq(Message #5)
		{
			switch (SolverWindowViewModel.#0p(#5, false))
			{
			case Message.EnumType.Error:
				return Strings.StringError_UPPER;
			case Message.EnumType.Warning:
				return Strings.StringWarning_UPPER;
			case Message.EnumType.Note:
				return Strings.StringNote_UPPER;
			default:
				return string.Empty;
			}
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x0000D5B7 File Offset: 0x0000B7B7
		[CompilerGenerated]
		private string #nTh(Message #dq)
		{
			return #Phc.#3hc(107383610) + this.#l.#pp(#dq).#A2d();
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x0000D5E5 File Offset: 0x0000B7E5
		[CompilerGenerated]
		private bool #oTh(Message #Rf)
		{
			return this.#u.Contains(#Rf.Code);
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x0000D604 File Offset: 0x0000B804
		[CompilerGenerated]
		private void #pTh()
		{
			this.#e.#xJ();
			this.View.Close();
			this.#d.#JV(new #fW(this.#m, this.#t));
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x00097480 File Offset: 0x00095680
		[CompilerGenerated]
		private void #qTh()
		{
			if (this.#y)
			{
				this.#a.ActivateScopeWithParameters.Execute(new SectionScopeActivationParameters());
			}
			this.#d.#JV(new #fW(this.#m, this.#t));
		}

		// Token: 0x060009A7 RID: 2471 RVA: 0x000974D4 File Offset: 0x000956D4
		[CompilerGenerated]
		private void #rTh()
		{
			try
			{
				SolverWindowViewModel.#dDg #dDg = new SolverWindowViewModel.#dDg();
				if (this.#b.Settings.CurrentGeneralOptions.ReorderSolidAndOpeningLabelsBeforeSolve || !base.Project.Model.#gVh())
				{
					base.Project.Model.#hVh();
				}
				string text;
				bool flag = this.#Xp(out text);
				#dDg.#a = new #uzc();
				this.#c.#0(new #EJ(true, true, true, false, this.#b.Settings.DiagramInterpolationConvergenceEpsilonPercentage));
				#dDg.#a.#szc(#Phc.#3hc(107413493));
				#lte #lte = null;
				if (!this.#k)
				{
					#lte = this.#g.#LA(true, true);
					#dDg.#a.#szc(#Phc.#3hc(107413464));
				}
				if (!this.#k)
				{
					DesignEngine designEngine = this.#c.DesignEngine;
					if (((designEngine != null) ? designEngine.OutputModel : null) != null)
					{
						if (this.#c.DesignEngine.OutputModel.Messages.Any(new Func<Message, bool>(this.#sTh)))
						{
							this.#c.#xQ();
						}
						if (flag)
						{
							this.#4p(Strings.StringGeneratingTextResultsFile.#B2d(), true, null);
							#vqe #vqe = new #vqe(base.Logger, base.Services.ReporterSettings, null, null);
							#vqe.#fp(#lte, this.#c.DesignEngine, new CommandLineReportGeneratorSettings
							{
								TxtReportPath = text
							});
							#dDg.#a.#szc(#Phc.#3hc(107413435));
						}
					}
				}
				base.Logger.Log(LoggingLevel.Debug, new Func<string>(#dDg.#2Vb));
				this.ProcessingComplete = true;
				this.#aq();
				if (!this.#k)
				{
					if (#lte != null)
					{
						#lte.SolverMessages.Clear();
						#lte.SolverMessages.AddRange(this.#z.Where(new Func<AnalysisReportItem, bool>(SolverWindowViewModel.<>c.<>9.#7Wh)).Select(new Func<AnalysisReportItem, SolverMessage>(SolverWindowViewModel.<>c.<>9.#8Wh)));
					}
					this.#g.SolverMessages.AddRange(this.#z.Where(new Func<AnalysisReportItem, bool>(SolverWindowViewModel.<>c.<>9.#9Wh)).Select(new Func<AnalysisReportItem, SolverMessage>(SolverWindowViewModel.<>c.<>9.#aXh)));
				}
				if (!this.#k)
				{
					DesignEngine designEngine2 = this.#c.DesignEngine;
					bool? flag2;
					if (designEngine2 == null)
					{
						flag2 = null;
					}
					else
					{
						#l4e #l4e = designEngine2.OutputModel;
						flag2 = ((#l4e != null) ? new bool?(#l4e.SolveCompleted) : null);
					}
					bool? flag3 = flag2;
					if (flag3.GetValueOrDefault())
					{
						this.#t = true;
						if (!this.#q && !this.#s && !this.#r)
						{
							LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#tTh));
							goto IL_32D;
						}
						goto IL_32D;
					}
				}
				if (this.#k)
				{
					this.#c.#DQ();
					this.#c.#xQ();
					LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#uTh));
				}
				IL_32D:;
			}
			catch (OperationCanceledException)
			{
				this.#Zp();
			}
			catch (ThreadAbortException)
			{
				this.#Zp();
			}
			catch (Exception ex)
			{
				this.IsWorking = false;
				if (!this.#k)
				{
					base.Logger.Log(LoggingLevel.Error, ex);
					this.#c.#xQ();
					string # = Strings.StringAnUnknownErrorOccrued.#z2d(true) + #sYd.#oYd(ex);
					this.#4p(#, true, null);
					base.DialogService.#2Sc(new Func<Window>(this.#vTh), ColumnGlobalInfo.ShortName, #, MessageBoxButton.OK, MessageBoxImage.Hand);
					this.ProcessingComplete = true;
				}
				else
				{
					this.#Zp();
				}
			}
			finally
			{
				this.IsWorking = false;
			}
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x0000D5E5 File Offset: 0x0000B7E5
		[CompilerGenerated]
		private bool #sTh(Message #dq)
		{
			return this.#u.Contains(#dq.Code);
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x0000D524 File Offset: 0x0000B724
		[CompilerGenerated]
		private void #tTh()
		{
			this.View.Close();
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x0000D524 File Offset: 0x0000B724
		[CompilerGenerated]
		private void #uTh()
		{
			this.View.Close();
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x0000D644 File Offset: 0x0000B844
		[CompilerGenerated]
		private Window #vTh()
		{
			return base.ActiveWindow;
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x0000D654 File Offset: 0x0000B854
		[CompilerGenerated]
		private void #wTh()
		{
			this.#c.#xQ();
			this.View.Close();
		}

		// Token: 0x0400033F RID: 831
		private readonly #wU #a;

		// Token: 0x04000340 RID: 832
		private readonly IExtendedServices #b;

		// Token: 0x04000341 RID: 833
		private readonly #qW #c;

		// Token: 0x04000342 RID: 834
		private readonly #UV #d;

		// Token: 0x04000343 RID: 835
		private readonly #zJ #e;

		// Token: 0x04000344 RID: 836
		private readonly #LJ #f;

		// Token: 0x04000345 RID: 837
		private readonly #lB #g;

		// Token: 0x04000346 RID: 838
		private readonly #AWh #h;

		// Token: 0x04000347 RID: 839
		private string #i;

		// Token: 0x04000348 RID: 840
		private int #j;

		// Token: 0x04000349 RID: 841
		private bool #k;

		// Token: 0x0400034A RID: 842
		private readonly #yp #l;

		// Token: 0x0400034B RID: 843
		private bool #m;

		// Token: 0x0400034C RID: 844
		private bool #n;

		// Token: 0x0400034D RID: 845
		private bool #o;

		// Token: 0x0400034E RID: 846
		private bool #p;

		// Token: 0x0400034F RID: 847
		private bool #q;

		// Token: 0x04000350 RID: 848
		private bool #r;

		// Token: 0x04000351 RID: 849
		private bool #s;

		// Token: 0x04000352 RID: 850
		private bool #t;

		// Token: 0x04000353 RID: 851
		private readonly HashSet<#M6e> #u = new HashSet<#M6e>
		{
			#M6e.#r,
			#M6e.#s,
			#M6e.#t,
			#M6e.#u,
			#M6e.#v,
			#M6e.#w,
			#M6e.#c
		};

		// Token: 0x04000354 RID: 852
		private bool #v;

		// Token: 0x04000355 RID: 853
		private bool #w;

		// Token: 0x04000356 RID: 854
		private bool #x;

		// Token: 0x04000357 RID: 855
		private bool #y;

		// Token: 0x04000358 RID: 856
		private readonly List<AnalysisReportItem> #z = new List<AnalysisReportItem>();

		// Token: 0x04000359 RID: 857
		private readonly NonBlockingLock #A = new NonBlockingLock();

		// Token: 0x0400035A RID: 858
		private Thread #B;

		// Token: 0x0400035B RID: 859
		private readonly DispatcherTimer #C;

		// Token: 0x0400035C RID: 860
		private int #D;

		// Token: 0x0400035D RID: 861
		private readonly NonBlockingLock #E = new NonBlockingLock();

		// Token: 0x0400035E RID: 862
		[CompilerGenerated]
		private readonly DelegateCommand #F;

		// Token: 0x0400035F RID: 863
		[CompilerGenerated]
		private readonly DelegateCommand #G;

		// Token: 0x04000360 RID: 864
		[CompilerGenerated]
		private readonly CustomObservableCollection<AnalysisReportItem> #H = new CustomObservableCollection<AnalysisReportItem>();

		// Token: 0x04000361 RID: 865
		private readonly ReaderWriterLockSlim #I = new ReaderWriterLockSlim();

		// Token: 0x02000124 RID: 292
		[CompilerGenerated]
		private sealed class #nVb
		{
			// Token: 0x060009B5 RID: 2485 RVA: 0x0000D6EB File Offset: 0x0000B8EB
			internal void #ZVb()
			{
				this.#a = this.#b.DialogService.#3Sc(this.#c, this.#d, MessageBoxButton.YesNoCancel, MessageBoxResult.Yes);
				this.#e.Set();
			}

			// Token: 0x060009B6 RID: 2486 RVA: 0x00097938 File Offset: 0x00095B38
			internal void #0Vb()
			{
				this.#a = this.#b.DialogService.#3Sc(this.#c, this.#d, MessageBoxButton.OKCancel, MessageBoxResult.OK);
				if (this.#a == MessageBoxResult.Cancel)
				{
					this.#b.#y = true;
				}
				this.#e.Set();
			}

			// Token: 0x04000368 RID: 872
			public MessageBoxResult #a;

			// Token: 0x04000369 RID: 873
			public SolverWindowViewModel #b;

			// Token: 0x0400036A RID: 874
			public Window #c;

			// Token: 0x0400036B RID: 875
			public string #d;

			// Token: 0x0400036C RID: 876
			public ManualResetEvent #e;
		}

		// Token: 0x02000125 RID: 293
		[CompilerGenerated]
		private sealed class #dDg
		{
			// Token: 0x060009B8 RID: 2488 RVA: 0x0000D729 File Offset: 0x0000B929
			internal string #2Vb()
			{
				return this.#a.ToString();
			}

			// Token: 0x0400036D RID: 877
			public #uzc #a;
		}
	}
}
