using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using #6re;
using #7hc;
using #eU;
using #lH;
using #Mbb;
using #o1d;
using #Oze;
using #S9;
using #sUd;
using #Wse;
using #xBe;
using #Xc;
using #Zjb;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.DTO;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.GraphicalReport;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Menu;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.Editor.Core;
using StructurePoint.Products.Column.FailureSurface.Views;
using StructurePoint.Products.Column.Resources.Images;
using StructurePoint.Products.Column.Services.API;
using Telerik.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.FailureSurface.ViewModels
{
	// Token: 0x02000400 RID: 1024
	internal sealed class DiagramPresenterViewModel : #HH<IDiagramPresenterView>, IDisposable, INotifyPropertyChanged, INotifyPropertyChanging, IViewModel<IDiagramPresenterView>, IViewModel, IDiagramPresenterViewModel
	{
		// Token: 0x14000083 RID: 131
		// (add) Token: 0x06002347 RID: 9031 RVA: 0x000CCD34 File Offset: 0x000CAF34
		// (remove) Token: 0x06002348 RID: 9032 RVA: 0x000CCD78 File Offset: 0x000CAF78
		public event EventHandler ButtonStatesInvalidated
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#a;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#a, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#a;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#a, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x17000C1C RID: 3100
		// (get) Token: 0x06002349 RID: 9033 RVA: 0x00021EAA File Offset: 0x000200AA
		public bool IsDiagramMMChecked
		{
			get
			{
				return this.PresenterType == DiagramPresenterType.#b && this.Diagram2DType == Diagram2DType.DiagramMM;
			}
		}

		// Token: 0x17000C1D RID: 3101
		// (get) Token: 0x0600234A RID: 9034 RVA: 0x00021ECC File Offset: 0x000200CC
		public bool IsDiagramPMChecked
		{
			get
			{
				return this.PresenterType == DiagramPresenterType.#b && this.Diagram2DType == Diagram2DType.DiagramPM;
			}
		}

		// Token: 0x17000C1E RID: 3102
		// (get) Token: 0x0600234B RID: 9035 RVA: 0x00021EEE File Offset: 0x000200EE
		public bool IsDiagramPMPlusChecked
		{
			get
			{
				return this.PresenterType == DiagramPresenterType.#b && this.Diagram2DType == Diagram2DType.DiagramPMPlus;
			}
		}

		// Token: 0x17000C1F RID: 3103
		// (get) Token: 0x0600234C RID: 9036 RVA: 0x00021F10 File Offset: 0x00020110
		public bool IsDiagramPMMinusChecked
		{
			get
			{
				return this.PresenterType == DiagramPresenterType.#b && this.Diagram2DType == Diagram2DType.DiagramPMMinus;
			}
		}

		// Token: 0x17000C20 RID: 3104
		// (get) Token: 0x0600234D RID: 9037 RVA: 0x00021F32 File Offset: 0x00020132
		public bool IsDiagramPMGroupChecked
		{
			get
			{
				return this.IsDiagramPMChecked || this.IsDiagramPMMinusChecked || this.IsDiagramPMPlusChecked;
			}
		}

		// Token: 0x17000C21 RID: 3105
		// (get) Token: 0x0600234E RID: 9038 RVA: 0x00021F58 File Offset: 0x00020158
		public bool IsDiagram3DHorizontalChecked
		{
			get
			{
				return this.PresenterType == DiagramPresenterType.#a && this.DefinedDiagram3DCutType == Diagram3DCutType.#b;
			}
		}

		// Token: 0x17000C22 RID: 3106
		// (get) Token: 0x0600234F RID: 9039 RVA: 0x00021F79 File Offset: 0x00020179
		public bool IsDiagram3DVerticalChecked
		{
			get
			{
				return this.PresenterType == DiagramPresenterType.#a && this.DefinedDiagram3DCutType == Diagram3DCutType.#c;
			}
		}

		// Token: 0x06002350 RID: 9040 RVA: 0x000CCDBC File Offset: 0x000CAFBC
		public void #gab()
		{
			base.RaisePropertyChanged<bool>(System.Linq.Expressions.Expression.Lambda<Func<bool>>(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Constant(this, typeof(DiagramPresenterViewModel)), methodof(DiagramPresenterViewModel.#a9())), Array.Empty<ParameterExpression>()));
			base.RaisePropertyChanged<bool>(System.Linq.Expressions.Expression.Lambda<Func<bool>>(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Constant(this, typeof(DiagramPresenterViewModel)), methodof(DiagramPresenterViewModel.#e9())), Array.Empty<ParameterExpression>()));
			base.RaisePropertyChanged<bool>(System.Linq.Expressions.Expression.Lambda<Func<bool>>(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Constant(this, typeof(DiagramPresenterViewModel)), methodof(DiagramPresenterViewModel.#g9())), Array.Empty<ParameterExpression>()));
			base.RaisePropertyChanged<bool>(System.Linq.Expressions.Expression.Lambda<Func<bool>>(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Constant(this, typeof(DiagramPresenterViewModel)), methodof(DiagramPresenterViewModel.#i9())), Array.Empty<ParameterExpression>()));
			base.RaisePropertyChanged<bool>(System.Linq.Expressions.Expression.Lambda<Func<bool>>(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Constant(this, typeof(DiagramPresenterViewModel)), methodof(DiagramPresenterViewModel.#k9())), Array.Empty<ParameterExpression>()));
			base.RaisePropertyChanged<bool>(System.Linq.Expressions.Expression.Lambda<Func<bool>>(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Constant(this, typeof(DiagramPresenterViewModel)), methodof(DiagramPresenterViewModel.#m9())), Array.Empty<ParameterExpression>()));
			base.RaisePropertyChanged<bool>(System.Linq.Expressions.Expression.Lambda<Func<bool>>(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Constant(this, typeof(DiagramPresenterViewModel)), methodof(DiagramPresenterViewModel.#o9())), Array.Empty<ParameterExpression>()));
			this.#Jcb();
		}

		// Token: 0x06002351 RID: 9041 RVA: 0x000CCF5C File Offset: 0x000CB15C
		protected void #Jcb()
		{
			EventHandler eventHandler = this.#a;
			if (eventHandler != null)
			{
				eventHandler(this, EventArgs.Empty);
			}
		}

		// Token: 0x17000C23 RID: 3107
		// (get) Token: 0x06002352 RID: 9042 RVA: 0x00021F9A File Offset: 0x0002019A
		public DelegateCommandAdapter OnContextMenuOpeningCommand { get; }

		// Token: 0x17000C24 RID: 3108
		// (get) Token: 0x06002353 RID: 9043 RVA: 0x00021FA6 File Offset: 0x000201A6
		public RadObservableCollection<MenuItemExt> ContextMenuItems { get; }

		// Token: 0x17000C25 RID: 3109
		// (get) Token: 0x06002354 RID: 9044 RVA: 0x00021FB2 File Offset: 0x000201B2
		public DelegateCommandAdapter ChangeCutTypeCommand { get; }

		// Token: 0x17000C26 RID: 3110
		// (get) Token: 0x06002355 RID: 9045 RVA: 0x00021FBE File Offset: 0x000201BE
		public DelegateCommandAdapter ChangeDiagram2DTypeCommand { get; }

		// Token: 0x17000C27 RID: 3111
		// (get) Token: 0x06002356 RID: 9046 RVA: 0x00021FCA File Offset: 0x000201CA
		public DelegateCommandAdapter CutCommand { get; }

		// Token: 0x17000C28 RID: 3112
		// (get) Token: 0x06002357 RID: 9047 RVA: 0x00021FD6 File Offset: 0x000201D6
		public DelegateCommandAdapter ChangePresenterTypeCommand { get; }

		// Token: 0x17000C29 RID: 3113
		// (get) Token: 0x06002358 RID: 9048 RVA: 0x00021FE2 File Offset: 0x000201E2
		public DelegateCommandAdapter ShowPlaneCommand { get; }

		// Token: 0x06002359 RID: 9049 RVA: 0x00021FEE File Offset: 0x000201EE
		private bool #Mcb(object #Sb)
		{
			return this.#aeb() && this.PresenterType == DiagramPresenterType.#a && (this.#q.ShowNominal || this.#q.ShowFactored);
		}

		// Token: 0x0600235A RID: 9050 RVA: 0x00022028 File Offset: 0x00020228
		private void #Ncb(object #Sb)
		{
			if (this.DefinedDiagram3DCutType == Diagram3DCutType.#b)
			{
				this.Diagram3DIsHorizontalCutEnabled = !this.Diagram3DIsHorizontalCutEnabled;
				return;
			}
			if (this.DefinedDiagram3DCutType == Diagram3DCutType.#c)
			{
				this.Diagram3DIsVerticalCutEnabled = !this.Diagram3DIsVerticalCutEnabled;
			}
		}

		// Token: 0x0600235B RID: 9051 RVA: 0x00003375 File Offset: 0x00001575
		private bool #Ocb(object #Sb)
		{
			return true;
		}

		// Token: 0x0600235C RID: 9052 RVA: 0x000CCF8C File Offset: 0x000CB18C
		private void #Pcb(object #Sb)
		{
			try
			{
				this.#vh();
				RadRoutedEventArgs radRoutedEventArgs = #Sb as RadRoutedEventArgs;
				if (radRoutedEventArgs != null)
				{
					RadContextMenu radContextMenu = radRoutedEventArgs.OriginalSource as RadContextMenu;
					if (radContextMenu != null && radContextMenu.ActualHeight <= 0.0)
					{
						radContextMenu.Measure(new Size(500.0, 800.0));
						radContextMenu.Arrange(new Rect(radContextMenu.DesiredSize));
					}
					radRoutedEventArgs.Handled = ((this.PresenterType == DiagramPresenterType.#a) ? this.#A.#Wbb() : this.#B.#Wbb());
				}
			}
			catch (Exception #ob)
			{
				this.#s.#3Ab(#ob);
			}
		}

		// Token: 0x0600235D RID: 9053 RVA: 0x000CD05C File Offset: 0x000CB25C
		private void #Aab(object #GA)
		{
			try
			{
				DiagramPresenterType diagramPresenterType = (DiagramPresenterType)#GA;
				DiagramPresenterType diagramPresenterType2;
				if (!false)
				{
					diagramPresenterType2 = diagramPresenterType;
				}
				this.PresenterType = diagramPresenterType2;
				this.#Wcb();
			}
			catch (Exception #ob)
			{
				this.#s.#3Ab(#ob);
			}
		}

		// Token: 0x0600235E RID: 9054 RVA: 0x000CD0AC File Offset: 0x000CB2AC
		private bool #Qcb(object #Sb)
		{
			return this.#aeb() && this.PresenterType == DiagramPresenterType.#a && (this.Diagram3DIsVerticalCutEnabled || this.Diagram3DIsHorizontalCutEnabled) && (this.#q.ShowFactored || this.#q.ShowNominal);
		}

		// Token: 0x0600235F RID: 9055 RVA: 0x000CD104 File Offset: 0x000CB304
		private void #Rcb(object #Sb)
		{
			if (this.PresenterType != DiagramPresenterType.#a)
			{
				return;
			}
			this.Diagram3DEnableCutOnValueChange = !this.Diagram3DEnableCutOnValueChange;
			if (this.Diagram3DEnableCutOnValueChange)
			{
				this.#feb();
				return;
			}
			if (this.#A != null)
			{
				this.#A.#vfb();
			}
		}

		// Token: 0x06002360 RID: 9056 RVA: 0x00022067 File Offset: 0x00020267
		private bool #Scb(object #Sb)
		{
			return this.#aeb();
		}

		// Token: 0x06002361 RID: 9057 RVA: 0x000CD158 File Offset: 0x000CB358
		private void #Tcb(object #Sb)
		{
			Diagram3DCutType diagram3DCutType = (Diagram3DCutType)#Sb;
			if (diagram3DCutType == Diagram3DCutType.#b)
			{
				this.Diagram3DIsHorizontalCutEnabled = (this.Diagram3DCutType != Diagram3DCutType.#b);
			}
			else if (diagram3DCutType == Diagram3DCutType.#c)
			{
				this.Diagram3DIsVerticalCutEnabled = (this.Diagram3DCutType != Diagram3DCutType.#c);
			}
			this.#Wcb();
		}

		// Token: 0x06002362 RID: 9058 RVA: 0x00022077 File Offset: 0x00020277
		private void #Ucb(MenuItemExt #Rf, bool #Vcb)
		{
			if (#Rf != null)
			{
				#Rf.IsChecked = #Vcb;
			}
		}

		// Token: 0x06002363 RID: 9059 RVA: 0x000CD1AC File Offset: 0x000CB3AC
		private void #Wcb()
		{
			bool flag = this.PresenterType == DiagramPresenterType.#a;
			this.#Ucb(this.#b, this.IsDiagram3DHorizontalChecked);
			this.#Ucb(this.#c, this.IsDiagram3DVerticalChecked);
			this.#Ucb(this.#e, this.IsDiagramMMChecked);
			this.#Ucb(this.#f, this.IsDiagramPMChecked);
			this.#Ucb(this.#g, this.IsDiagramPMPlusChecked);
			this.#Ucb(this.#h, this.IsDiagramPMMinusChecked);
			this.#Ucb(this.#i, flag && (this.Diagram3DCutType == Diagram3DCutType.#b || this.Diagram3DCutType == Diagram3DCutType.#c));
			this.#Ucb(this.#d, this.Diagram3DEnableCutOnValueChange);
		}

		// Token: 0x06002364 RID: 9060 RVA: 0x000CD288 File Offset: 0x000CB488
		private void #Xcb()
		{
			this.ContextMenuItems.Add(new MenuItemExt
			{
				Command = this.ActivateDiagramCommand,
				Text = #Phc.#3hc(107362508),
				CommandParameter = ActivateDiagramParameters.Diagram3DVertical,
				Icon = ColumnImages.Diagram3DPM_24X24
			});
			this.#c = this.ContextMenuItems.Last<MenuItemExt>();
			this.ContextMenuItems.Add(new MenuItemExt
			{
				Command = this.ActivateDiagramCommand,
				Text = #Phc.#3hc(107362499),
				CommandParameter = ActivateDiagramParameters.Diagram3DHorizontal,
				Icon = ColumnImages.Diagram3DMM_24X24
			});
			this.#b = this.ContextMenuItems.Last<MenuItemExt>();
			if (this.PresenterType == DiagramPresenterType.#a)
			{
				this.ContextMenuItems.Add(new MenuItemExt
				{
					IsSeparator = true
				});
				this.ContextMenuItems.Add(new MenuItemExt
				{
					Text = #Phc.#3hc(107362522),
					Icon = ((this.DefinedDiagram3DCutType == Diagram3DCutType.#b) ? ColumnImages.Diagram3DMM_24X24 : ColumnImages.Diagram3DPM_24X24),
					Command = this.ShowPlaneCommand
				});
				this.#i = this.ContextMenuItems.Last<MenuItemExt>();
				this.ContextMenuItems.Add(new MenuItemExt
				{
					Command = this.CutCommand,
					Text = Strings.StringCut,
					CommandParameter = null,
					Icon = ColumnImages.DiagramCut_24X24
				});
				this.#d = this.ContextMenuItems.Last<MenuItemExt>();
				this.ContextMenuItems.Add(new MenuItemExt
				{
					Command = this.Diagram3DFlipCommand,
					Text = Strings.StringSwap,
					CommandParameter = null,
					Icon = ((this.DefinedDiagram3DCutType == Diagram3DCutType.#b) ? ColumnImages.DiagramSwapMM_24X24 : ColumnImages.DiagramSwapPM_24X24)
				});
			}
		}

		// Token: 0x06002365 RID: 9061 RVA: 0x000CD468 File Offset: 0x000CB668
		private void #Ycb()
		{
			MenuItemExt menuItemExt = new MenuItemExt
			{
				Text = #Phc.#3hc(107362473),
				Icon = ColumnImages.Diagram2DPM_24X24
			};
			this.ContextMenuItems.Add(menuItemExt);
			menuItemExt.SubItems.Add(new MenuItemExt
			{
				Command = this.ActivateDiagramCommand,
				Text = #Phc.#3hc(107362473),
				CommandParameter = ActivateDiagramParameters.Diagram2DPM,
				Icon = ColumnImages.Diagram2DPM_24X24
			});
			this.#f = menuItemExt.SubItems.Last<MenuItemExt>();
			menuItemExt.SubItems.Add(new MenuItemExt
			{
				Command = this.ActivateDiagramCommand,
				Text = #Phc.#3hc(107362468),
				CommandParameter = ActivateDiagramParameters.Diagram2DPMPlus,
				Icon = ColumnImages.Diagram2DPMPlus_24X24
			});
			this.#g = menuItemExt.SubItems.Last<MenuItemExt>();
			menuItemExt.SubItems.Add(new MenuItemExt
			{
				Command = this.ActivateDiagramCommand,
				Text = #Phc.#3hc(107362495),
				CommandParameter = ActivateDiagramParameters.Diagram2DPMMinus,
				Icon = ColumnImages.Diagram2DPMMinus_24X24
			});
			this.#h = menuItemExt.SubItems.Last<MenuItemExt>();
			this.ContextMenuItems.Add(new MenuItemExt
			{
				Command = this.ActivateDiagramCommand,
				Text = #Phc.#3hc(107362490),
				CommandParameter = ActivateDiagramParameters.Diagram2DMM,
				Icon = ColumnImages.Diagram2DMM_24X24
			});
			this.#e = this.ContextMenuItems.Last<MenuItemExt>();
		}

		// Token: 0x06002366 RID: 9062 RVA: 0x000CD60C File Offset: 0x000CB80C
		private void #Zcb()
		{
			if (this.PresenterType != DiagramPresenterType.#b)
			{
				return;
			}
			this.ContextMenuItems.Add(MenuItemExt.CreateSeparator());
			this.ContextMenuItems.Add(new MenuItemExt
			{
				Text = Strings.StringCopyToClipboard,
				Command = this.CopyToClipboardCommand,
				Icon = ColumnImages.CopyContent_24X24
			});
			this.ContextMenuItems.Add(new MenuItemExt
			{
				Text = Strings.StringAddToReport_PASCAL,
				Command = this.AddToReportCommand,
				Icon = ColumnImages.AddToReport_24X24,
				Shortcut = EditorContextMenu.AddToReportItemData.Shortcut
			});
			this.ContextMenuItems.Add(new MenuItemExt
			{
				Text = Strings.StringPrintExport,
				Command = this.PrintExportCommand,
				Icon = ColumnImages.PrintExport_24X24,
				Shortcut = EditorContextMenu.PrintExportItemData.Shortcut
			});
			this.ContextMenuItems.Add(MenuItemExt.CreateSeparator());
			this.ContextMenuItems.Add(new MenuItemExt
			{
				Text = Strings.StringExportDiagram,
				Icon = ColumnImages.ExportResults_24X24
			});
			this.ContextMenuItems.Last<MenuItemExt>().SubItems.Add(new MenuItemExt
			{
				Text = Strings.StringFactoredInteractionDiagram.#B2d(),
				Command = this.ExportDiagramCommand,
				CommandParameter = ExportDiagramType.Factored
			});
			this.ContextMenuItems.Last<MenuItemExt>().SubItems.Add(new MenuItemExt
			{
				Text = Strings.StringNominalInteractionDiagram.#B2d(),
				Command = this.ExportDiagramCommand,
				CommandParameter = ExportDiagramType.Nominal
			});
		}

		// Token: 0x06002367 RID: 9063 RVA: 0x000CD7C4 File Offset: 0x000CB9C4
		private void #0cb()
		{
			if (this.PresenterType != DiagramPresenterType.#a)
			{
				return;
			}
			this.ContextMenuItems.Add(MenuItemExt.CreateSeparator());
			this.ContextMenuItems.Add(new MenuItemExt
			{
				Text = Strings.StringExportDiagram,
				Icon = ColumnImages.ExportResults_24X24
			});
			this.ContextMenuItems.Last<MenuItemExt>().SubItems.Add(new MenuItemExt
			{
				Text = Strings.StringFactored3DFailureSurface.#B2d(),
				Command = this.ExportDiagramCommand,
				CommandParameter = ExportDiagramType.Factored
			});
			this.ContextMenuItems.Last<MenuItemExt>().SubItems.Add(new MenuItemExt
			{
				Text = Strings.StringNominal3DFailureSurface.#B2d(),
				Command = this.ExportDiagramCommand,
				CommandParameter = ExportDiagramType.Nominal
			});
		}

		// Token: 0x06002368 RID: 9064 RVA: 0x000CD8B4 File Offset: 0x000CBAB4
		private void #1cb()
		{
			this.ContextMenuItems.Clear();
			this.#Ycb();
			this.ContextMenuItems.Add(MenuItemExt.CreateSeparator());
			this.#Xcb();
			this.#Zcb();
			this.#0cb();
			this.#Wcb();
		}

		// Token: 0x06002369 RID: 9065 RVA: 0x000CD908 File Offset: 0x000CBB08
		private bool #2cb(object #Sb)
		{
			try
			{
				if (#Sb == null || !this.#aeb())
				{
					return false;
				}
				if ((Diagram2DType)#Sb == Diagram2DType.DiagramMM)
				{
					return this.#G.Input.Options.ConsideredAxis == ConsideredAxis.Both;
				}
			}
			catch (Exception #ob)
			{
				this.#s.#3Ab(#ob);
				return false;
			}
			return true;
		}

		// Token: 0x0600236A RID: 9066 RVA: 0x0002208F File Offset: 0x0002028F
		private void #3cb(object #Sb)
		{
			if (this.#2cb(#Sb))
			{
				this.Diagram2DType = (Diagram2DType)#Sb;
			}
		}

		// Token: 0x0600236B RID: 9067 RVA: 0x000CD97C File Offset: 0x000CBB7C
		public DiagramPresenterViewModel(Lazy<IDiagramPresenterView> view, ICoreServices services, #Ke host, ISettingsManager settingsManager, #yse reporterSettings, #tUd exceptionHandler, #yBe diagramExporter, #qW designEngine, #mAe superImposeContext, #tbb diagramsContext) : base(view, services)
		{
			this.#q = settingsManager;
			this.#r = reporterSettings;
			this.#s = exceptionHandler;
			this.#t = diagramExporter;
			this.#u = designEngine;
			this.#v = superImposeContext;
			this.#w = diagramsContext;
			this.#X = host;
			this.#Y = new DelegateCommandAdapter(new Action<object>(this.#eeb), new Predicate<object>(this.#beb));
			this.#m = new DelegateCommandAdapter(new Action<object>(this.#3cb), new Predicate<object>(this.#2cb));
			this.#l = new DelegateCommandAdapter(new Action<object>(this.#Tcb), new Predicate<object>(this.#Scb));
			this.#n = new DelegateCommandAdapter(new Action<object>(this.#Rcb), new Predicate<object>(this.#Qcb));
			this.#1 = new DelegateCommandAdapter(new Action<object>(this.#deb), new Predicate<object>(this.#ceb));
			this.#o = new DelegateCommandAdapter(new Action<object>(this.#Aab), new Predicate<object>(this.#Bab));
			this.#j = new DelegateCommandAdapter(new Action<object>(this.#Pcb), new Predicate<object>(this.#Ocb));
			this.#2 = new DelegateCommandAdapter(new Action<object>(this.#9db), new Predicate<object>(this.#8db));
			this.#p = new DelegateCommandAdapter(new Action<object>(this.#Ncb), new Predicate<object>(this.#Mcb));
			this.#5 = new DelegateCommandAdapter(new Action<object>(this.#seb), new Predicate<object>(this.#teb));
			this.#7 = new DelegateCommandAdapter(new Action<object>(this.#7h), new Predicate<object>(this.#reb));
			this.#6 = new DelegateCommandAdapter(new Action<object>(this.#2h), new Predicate<object>(this.#qeb));
			this.#D = false;
			this.#k = new RadObservableCollection<MenuItemExt>();
			this.#1cb();
			this.#L = true;
			base.View.DataContext = this;
			base.View.SizeChanged += this.#scb;
			base.View.MouseLeave += this.#7db;
		}

		// Token: 0x14000084 RID: 132
		// (add) Token: 0x0600236C RID: 9068 RVA: 0x000CDBD8 File Offset: 0x000CBDD8
		// (remove) Token: 0x0600236D RID: 9069 RVA: 0x000CDC1C File Offset: 0x000CBE1C
		public event EventHandler<#pkb> AxialLoadChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#pkb> eventHandler = this.#Q;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#Q, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#pkb> eventHandler = this.#Q;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#Q, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000085 RID: 133
		// (add) Token: 0x0600236E RID: 9070 RVA: 0x000CDC60 File Offset: 0x000CBE60
		// (remove) Token: 0x0600236F RID: 9071 RVA: 0x000CDCA4 File Offset: 0x000CBEA4
		public event EventHandler<#pkb> AngleChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#pkb> eventHandler = this.#R;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#R, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#pkb> eventHandler = this.#R;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#R, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000086 RID: 134
		// (add) Token: 0x06002370 RID: 9072 RVA: 0x000CDCE8 File Offset: 0x000CBEE8
		// (remove) Token: 0x06002371 RID: 9073 RVA: 0x000CDD2C File Offset: 0x000CBF2C
		public event EventHandler<#pkb> AxialLoadChanging
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#pkb> eventHandler = this.#S;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#S, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#pkb> eventHandler = this.#S;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#S, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000087 RID: 135
		// (add) Token: 0x06002372 RID: 9074 RVA: 0x000CDD70 File Offset: 0x000CBF70
		// (remove) Token: 0x06002373 RID: 9075 RVA: 0x000CDDB4 File Offset: 0x000CBFB4
		public event EventHandler<#pkb> AngleChanging
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#pkb> eventHandler = this.#T;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#T, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#pkb> eventHandler = this.#T;
				EventHandler<#pkb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#pkb> value2 = (EventHandler<#pkb>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#pkb>>(ref this.#T, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000088 RID: 136
		// (add) Token: 0x06002374 RID: 9076 RVA: 0x000CDDF8 File Offset: 0x000CBFF8
		// (remove) Token: 0x06002375 RID: 9077 RVA: 0x000CDE3C File Offset: 0x000CC03C
		public event EventHandler<#Yjb> LoadPointClickedEventArgs
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#Yjb> eventHandler = this.#U;
				EventHandler<#Yjb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#Yjb> value2 = (EventHandler<#Yjb>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#Yjb>>(ref this.#U, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#Yjb> eventHandler = this.#U;
				EventHandler<#Yjb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#Yjb> value2 = (EventHandler<#Yjb>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#Yjb>>(ref this.#U, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000089 RID: 137
		// (add) Token: 0x06002376 RID: 9078 RVA: 0x000CDE80 File Offset: 0x000CC080
		// (remove) Token: 0x06002377 RID: 9079 RVA: 0x000CDEC4 File Offset: 0x000CC0C4
		public event EventHandler DiagramParameterChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#V;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#V, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#V;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#V, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x1400008A RID: 138
		// (add) Token: 0x06002378 RID: 9080 RVA: 0x000CDF08 File Offset: 0x000CC108
		// (remove) Token: 0x06002379 RID: 9081 RVA: 0x000CDF4C File Offset: 0x000CC14C
		public event EventHandler PresenterTypeChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#W;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#W, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.#W;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#W, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x17000C2A RID: 3114
		// (get) Token: 0x0600237A RID: 9082 RVA: 0x000220B2 File Offset: 0x000202B2
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x17000C2B RID: 3115
		// (get) Token: 0x0600237B RID: 9083 RVA: 0x000220C2 File Offset: 0x000202C2
		// (set) Token: 0x0600237C RID: 9084 RVA: 0x000220CE File Offset: 0x000202CE
		public bool IsActive
		{
			get
			{
				return this.#J;
			}
			set
			{
				if (this.#J != value)
				{
					this.#J = value;
					base.RaisePropertyChanged(#Phc.#3hc(107362485));
				}
			}
		}

		// Token: 0x17000C2C RID: 3116
		// (get) Token: 0x0600237D RID: 9085 RVA: 0x000220FC File Offset: 0x000202FC
		public IReadOnlyList<LoadPointDrawingData> VisibleLoadPoints
		{
			get
			{
				if (this.PresenterType != DiagramPresenterType.#a && this.#B != null)
				{
					return this.#B.VisibleLoadPoints;
				}
				return null;
			}
		}

		// Token: 0x17000C2D RID: 3117
		// (get) Token: 0x0600237E RID: 9086 RVA: 0x00022127 File Offset: 0x00020327
		public #Ke PresenterHost { get; }

		// Token: 0x17000C2E RID: 3118
		// (get) Token: 0x0600237F RID: 9087 RVA: 0x00022133 File Offset: 0x00020333
		// (set) Token: 0x06002380 RID: 9088 RVA: 0x0002213F File Offset: 0x0002033F
		public IView ActiveView
		{
			get
			{
				return this.#y;
			}
			private set
			{
				if (this.#y != value)
				{
					this.#y = value;
					base.RaisePropertyChanged(#Phc.#3hc(107362440));
				}
			}
		}

		// Token: 0x17000C2F RID: 3119
		// (get) Token: 0x06002381 RID: 9089 RVA: 0x0002216D File Offset: 0x0002036D
		// (set) Token: 0x06002382 RID: 9090 RVA: 0x00022179 File Offset: 0x00020379
		public DiagramPresenterType PresenterType
		{
			get
			{
				return this.#C;
			}
			set
			{
				if (this.#C != value)
				{
					this.#Vdb(value);
					this.#hz();
					this.#3db();
					this.#4db();
					base.RaisePropertyChanged(#Phc.#3hc(107362455));
				}
			}
		}

		// Token: 0x17000C30 RID: 3120
		// (get) Token: 0x06002383 RID: 9091 RVA: 0x000221B9 File Offset: 0x000203B9
		// (set) Token: 0x06002384 RID: 9092 RVA: 0x000CDF90 File Offset: 0x000CC190
		public bool Diagram3DIsVerticalCutEnabled
		{
			get
			{
				return this.#I;
			}
			set
			{
				if (this.#I != value)
				{
					this.#I = value;
					if (value)
					{
						this.#H = false;
						base.RaisePropertyChanged<bool>(System.Linq.Expressions.Expression.Lambda<Func<bool>>(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Constant(this, typeof(DiagramPresenterViewModel)), methodof(DiagramPresenterViewModel.#pdb())), Array.Empty<ParameterExpression>()));
					}
					this.#5db();
					base.RaisePropertyChanged(#Phc.#3hc(107362402));
				}
			}
		}

		// Token: 0x17000C31 RID: 3121
		// (get) Token: 0x06002385 RID: 9093 RVA: 0x000221C5 File Offset: 0x000203C5
		// (set) Token: 0x06002386 RID: 9094 RVA: 0x000CE010 File Offset: 0x000CC210
		public bool Diagram3DIsHorizontalCutEnabled
		{
			get
			{
				return this.#H;
			}
			set
			{
				if (this.#H != value)
				{
					this.#H = value;
					if (value)
					{
						this.#I = false;
						base.RaisePropertyChanged<bool>(System.Linq.Expressions.Expression.Lambda<Func<bool>>(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Constant(this, typeof(DiagramPresenterViewModel)), methodof(DiagramPresenterViewModel.#ndb())), Array.Empty<ParameterExpression>()));
					}
					this.#5db();
					base.RaisePropertyChanged(#Phc.#3hc(107362393));
				}
			}
		}

		// Token: 0x17000C32 RID: 3122
		// (get) Token: 0x06002387 RID: 9095 RVA: 0x000221D1 File Offset: 0x000203D1
		// (set) Token: 0x06002388 RID: 9096 RVA: 0x000221DD File Offset: 0x000203DD
		public Diagram3DCutType Diagram3DCutType
		{
			get
			{
				return this.#E;
			}
			private set
			{
				if (this.#E != value)
				{
					this.#E = value;
					this.#4db();
					this.#1cb();
					base.RaisePropertyChanged(#Phc.#3hc(107362316));
				}
			}
		}

		// Token: 0x17000C33 RID: 3123
		// (get) Token: 0x06002389 RID: 9097 RVA: 0x00022217 File Offset: 0x00020417
		// (set) Token: 0x0600238A RID: 9098 RVA: 0x00022223 File Offset: 0x00020423
		public Diagram3DCutType DefinedDiagram3DCutType
		{
			get
			{
				return this.#M;
			}
			set
			{
				if (this.#M != value)
				{
					this.#M = value;
					this.#1cb();
					base.RaisePropertyChanged(#Phc.#3hc(107362323));
				}
			}
		}

		// Token: 0x17000C34 RID: 3124
		// (get) Token: 0x0600238B RID: 9099 RVA: 0x00022257 File Offset: 0x00020457
		// (set) Token: 0x0600238C RID: 9100 RVA: 0x00022263 File Offset: 0x00020463
		public Diagram2DType Diagram2DType
		{
			get
			{
				return this.#F;
			}
			set
			{
				if (this.#F != value)
				{
					this.#F = value;
					this.#hz();
					this.#3db();
					base.RaisePropertyChanged(#Phc.#3hc(107362802));
				}
			}
		}

		// Token: 0x17000C35 RID: 3125
		// (get) Token: 0x0600238D RID: 9101 RVA: 0x0002229D File Offset: 0x0002049D
		// (set) Token: 0x0600238E RID: 9102 RVA: 0x000222A9 File Offset: 0x000204A9
		public bool Diagram3DEnableCutOnValueChange
		{
			get
			{
				return this.#D;
			}
			set
			{
				if (this.#D != value)
				{
					this.#D = value;
					this.#vh();
					this.#Wcb();
					this.#4db();
					base.RaisePropertyChanged(#Phc.#3hc(107363402));
				}
			}
		}

		// Token: 0x17000C36 RID: 3126
		// (get) Token: 0x0600238F RID: 9103 RVA: 0x000222E9 File Offset: 0x000204E9
		public DelegateCommandAdapter Diagram3DFlipCommand { get; }

		// Token: 0x17000C37 RID: 3127
		// (get) Token: 0x06002390 RID: 9104 RVA: 0x000222F5 File Offset: 0x000204F5
		// (set) Token: 0x06002391 RID: 9105 RVA: 0x00022301 File Offset: 0x00020501
		public double Angle { get; set; }

		// Token: 0x17000C38 RID: 3128
		// (get) Token: 0x06002392 RID: 9106 RVA: 0x00022312 File Offset: 0x00020512
		// (set) Token: 0x06002393 RID: 9107 RVA: 0x0002231E File Offset: 0x0002051E
		public double AxialLoad { get; set; }

		// Token: 0x17000C39 RID: 3129
		// (get) Token: 0x06002394 RID: 9108 RVA: 0x0002232F File Offset: 0x0002052F
		public DelegateCommandAdapter ExportDiagramCommand { get; }

		// Token: 0x17000C3A RID: 3130
		// (get) Token: 0x06002395 RID: 9109 RVA: 0x0002233B File Offset: 0x0002053B
		// (set) Token: 0x06002396 RID: 9110 RVA: 0x00022347 File Offset: 0x00020547
		public Brush Background
		{
			get
			{
				return this.#K;
			}
			set
			{
				if (!object.Equals(this.#K, value))
				{
					this.#K = value;
					base.RaisePropertyChanged(#Phc.#3hc(107363120));
				}
			}
		}

		// Token: 0x17000C3B RID: 3131
		// (get) Token: 0x06002397 RID: 9111 RVA: 0x0002237A File Offset: 0x0002057A
		public DelegateCommandAdapter ActivateDiagramCommand { get; }

		// Token: 0x17000C3C RID: 3132
		// (get) Token: 0x06002398 RID: 9112 RVA: 0x00022386 File Offset: 0x00020586
		// (set) Token: 0x06002399 RID: 9113 RVA: 0x00022392 File Offset: 0x00020592
		public bool IsReportSourceValid
		{
			get
			{
				return this.#O;
			}
			set
			{
				if (this.#O != value)
				{
					this.#O = value;
					base.RaisePropertyChanged(#Phc.#3hc(107397470));
				}
			}
		}

		// Token: 0x17000C3D RID: 3133
		// (get) Token: 0x0600239A RID: 9114 RVA: 0x000223C0 File Offset: 0x000205C0
		// (set) Token: 0x0600239B RID: 9115 RVA: 0x000223CC File Offset: 0x000205CC
		private #xbb PartToCutHorizontally { get; set; }

		// Token: 0x17000C3E RID: 3134
		// (get) Token: 0x0600239C RID: 9116 RVA: 0x000223DD File Offset: 0x000205DD
		// (set) Token: 0x0600239D RID: 9117 RVA: 0x000223E9 File Offset: 0x000205E9
		private #ybb PartToCutVertically { get; set; }

		// Token: 0x0600239E RID: 9118 RVA: 0x000223FA File Offset: 0x000205FA
		public override void RefreshAllProperties()
		{
			base.RefreshAllProperties();
		}

		// Token: 0x0600239F RID: 9119 RVA: 0x0002240A File Offset: 0x0002060A
		public override void UnsubscribeAllEvents()
		{
			base.UnsubscribeAllEvents();
		}

		// Token: 0x060023A0 RID: 9120 RVA: 0x000CE090 File Offset: 0x000CC290
		public void #Ybb()
		{
			try
			{
				bool flag = this.IsActive && this.#q.ViewControlsPanelVisible;
				if (this.#B != null)
				{
					this.#B.#Ybb(flag, this.#q.ViewControlsPanelPosition);
				}
				if (this.#A != null)
				{
					this.#A.ViewControlsPanelVisibility = (flag ? Visibility.Visible : Visibility.Collapsed);
				}
				this.#Wcb();
			}
			catch (Exception #ob)
			{
				this.#s.#3Ab(#ob);
			}
		}

		// Token: 0x060023A1 RID: 9121 RVA: 0x0002241A File Offset: 0x0002061A
		public void #Gdb()
		{
			if (this.PresenterType == DiagramPresenterType.#a)
			{
				#Wgb #Wgb = this.#A;
				if (#Wgb == null)
				{
					return;
				}
				#Wgb.#8fb(null);
			}
		}

		// Token: 0x060023A2 RID: 9122 RVA: 0x000CE120 File Offset: 0x000CC320
		internal static bool #Hdb(#lte #Idb, ActivateDiagramParameters #Jdb)
		{
			if (#Idb == null || !#Idb.IsReportSourceValid)
			{
				return false;
			}
			if (#Jdb.PresenterType != DiagramPresenterType.#a)
			{
				if (#Jdb.PresenterType == DiagramPresenterType.#b)
				{
					Diagram2DType? diagram2DType = #Jdb.Diagram2DType;
					Diagram2DType diagram2DType2 = Diagram2DType.DiagramMM;
					if (diagram2DType.GetValueOrDefault() == diagram2DType2 & diagram2DType != null)
					{
						goto IL_3A;
					}
				}
				return true;
			}
			IL_3A:
			return #Idb.Input.Options.ConsideredAxis == ConsideredAxis.Both;
		}

		// Token: 0x060023A3 RID: 9123 RVA: 0x000CE18C File Offset: 0x000CC38C
		public void #Pd(ActivateDiagramParameters #Jdb)
		{
			if (#Jdb == null)
			{
				return;
			}
			bool flag = #Jdb.PresenterType != this.PresenterType;
			if (#Jdb.CutType != null)
			{
				this.DefinedDiagram3DCutType = #Jdb.CutType.Value;
				if (flag)
				{
					this.#Aab(#Jdb.PresenterType);
				}
				Diagram3DCutType? cutType = #Jdb.CutType;
				Diagram3DCutType diagram3DCutType = Diagram3DCutType.#b;
				if (cutType.GetValueOrDefault() == diagram3DCutType & cutType != null)
				{
					this.Diagram3DIsHorizontalCutEnabled = true;
				}
				cutType = #Jdb.CutType;
				diagram3DCutType = Diagram3DCutType.#c;
				if (cutType.GetValueOrDefault() == diagram3DCutType & cutType != null)
				{
					this.Diagram3DIsVerticalCutEnabled = true;
				}
			}
			else if (#Jdb.Diagram2DType != null)
			{
				this.#N = true;
				if (flag)
				{
					this.#F = #Jdb.Diagram2DType.Value;
					this.#Aab(#Jdb.PresenterType);
				}
				else
				{
					this.Diagram2DType = #Jdb.Diagram2DType.Value;
				}
			}
			this.#6db();
		}

		// Token: 0x060023A4 RID: 9124 RVA: 0x00022441 File Offset: 0x00020641
		public void #Kdb()
		{
			if (this.PresenterType == DiagramPresenterType.#a)
			{
				#Wgb #Wgb = this.#A;
				if (#Wgb == null)
				{
					return;
				}
				#Wgb.#ufb();
			}
		}

		// Token: 0x060023A5 RID: 9125 RVA: 0x00022467 File Offset: 0x00020667
		public Diagram2DData #Ldb(bool #5bb = false)
		{
			if (this.PresenterType != DiagramPresenterType.#b)
			{
				return null;
			}
			return this.#B.#4bb(#5bb);
		}

		// Token: 0x060023A6 RID: 9126 RVA: 0x000CE2AC File Offset: 0x000CC4AC
		public void #Mdb(IEnumerable<SelectedLoadData> #tk)
		{
			if (#tk == null)
			{
				return;
			}
			this.#x.Clear();
			this.#x.AddRange(#tk);
			if (this.PresenterType == DiagramPresenterType.#a)
			{
				#Wgb #Wgb = this.#A;
				if (#Wgb == null)
				{
					return;
				}
				#Wgb.#Mdb(this.#x);
			}
		}

		// Token: 0x060023A7 RID: 9127 RVA: 0x000CE300 File Offset: 0x000CC500
		public void #Ndb(Diagram3DCutType #Odb)
		{
			this.#E = #Odb;
			base.RaisePropertyChanged<Diagram3DCutType>(System.Linq.Expressions.Expression.Lambda<Func<Diagram3DCutType>>(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Constant(this, typeof(DiagramPresenterViewModel)), methodof(DiagramPresenterViewModel.#rdb())), Array.Empty<ParameterExpression>()));
		}

		// Token: 0x060023A8 RID: 9128 RVA: 0x000CE354 File Offset: 0x000CC554
		public void #Pdb(double #f)
		{
			this.Angle = #f;
			if (this.PresenterType == DiagramPresenterType.#b && this.Diagram2DType != Diagram2DType.DiagramMM)
			{
				this.#keb(this.#G);
			}
			else if (this.PresenterType == DiagramPresenterType.#a && this.Diagram3DCutType == Diagram3DCutType.#c)
			{
				this.#A.#zfb(#f, this.Diagram3DEnableCutOnValueChange);
			}
			this.#vh();
		}

		// Token: 0x060023A9 RID: 9129 RVA: 0x000CE3BC File Offset: 0x000CC5BC
		public void #Qdb(Diagram2DType #C)
		{
			this.#F = #C;
			base.RaisePropertyChanged<Diagram2DType>(System.Linq.Expressions.Expression.Lambda<Func<Diagram2DType>>(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Constant(this, typeof(DiagramPresenterViewModel)), methodof(DiagramPresenterViewModel.#vdb())), Array.Empty<ParameterExpression>()));
		}

		// Token: 0x060023AA RID: 9130 RVA: 0x000CE410 File Offset: 0x000CC610
		public void #Rdb(double #f)
		{
			this.AxialLoad = #f;
			if (this.PresenterType == DiagramPresenterType.#b && this.Diagram2DType == Diagram2DType.DiagramMM)
			{
				this.#keb(this.#G);
			}
			else if (this.PresenterType == DiagramPresenterType.#a && this.Diagram3DCutType == Diagram3DCutType.#b)
			{
				this.#A.#zfb(#f, this.Diagram3DEnableCutOnValueChange);
			}
			this.#vh();
		}

		// Token: 0x060023AB RID: 9131 RVA: 0x0002248C File Offset: 0x0002068C
		public void #Sdb(double #Tdb, double #Udb)
		{
			this.AxialLoad = #Tdb;
			this.Angle = #Udb;
		}

		// Token: 0x060023AC RID: 9132 RVA: 0x000CE478 File Offset: 0x000CC678
		public void #Vdb(DiagramPresenterType #C)
		{
			if (this.PresenterType != #C || !this.#z)
			{
				this.#P = ((#C == DiagramPresenterType.#b && this.#B == null) || (#C == DiagramPresenterType.#a && this.#A == null));
				this.#C = #C;
				this.#1cb();
				if (#C != DiagramPresenterType.#a)
				{
					if (#C != DiagramPresenterType.#b)
					{
						throw new ArgumentOutOfRangeException(#Phc.#3hc(107383497), #C, null);
					}
					this.#meb();
				}
				else
				{
					this.#leb();
				}
				this.PresenterHost.#od(base.View);
				this.#z = true;
			}
			this.#6db();
		}

		// Token: 0x060023AD RID: 9133 RVA: 0x000224A8 File Offset: 0x000206A8
		public bool #pA(#lte #Wdb)
		{
			if (#Wdb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107362781));
			}
			return true;
		}

		// Token: 0x060023AE RID: 9134 RVA: 0x000224CA File Offset: 0x000206CA
		public void #hz(#lte #Wdb)
		{
			if (#Wdb == null)
			{
				return;
			}
			this.#G = #Wdb;
			if (this.#A != null)
			{
				this.#A.CurrentReportingModel = #Wdb;
			}
			if (!this.#z)
			{
				return;
			}
			this.#hz();
		}

		// Token: 0x060023AF RID: 9135 RVA: 0x00022506 File Offset: 0x00020706
		public void #GVh()
		{
			#Wgb #Wgb = this.#A;
			if (#Wgb == null)
			{
				return;
			}
			#Wgb.#GVh();
		}

		// Token: 0x060023B0 RID: 9136 RVA: 0x000CE534 File Offset: 0x000CC734
		public void #Xdb()
		{
			DiagramPresenterViewModel.#z0h #z0h = new DiagramPresenterViewModel.#z0h();
			#z0h.#a = this;
			if (this.PresenterType == DiagramPresenterType.#a && this.#A != null)
			{
				this.#A.#Dfb();
				this.#A.#Efb();
			}
			if (this.PresenterType == DiagramPresenterType.#b && this.#B != null)
			{
				#z0h.#b = this.#N;
				this.#N = false;
				if (this.#P)
				{
					LayoutHelper.BeginInvokeOnApplicationThread(new Action(#z0h.#R5b));
				}
				else
				{
					this.#B.#6bb(this.#G, this.Diagram2DType, (this.Diagram2DType == Diagram2DType.DiagramMM) ? this.AxialLoad : this.Angle, this.#x, #z0h.#b);
				}
			}
			this.#ieb();
			this.#6db();
		}

		// Token: 0x060023B1 RID: 9137 RVA: 0x000CE618 File Offset: 0x000CC818
		protected override void #vh()
		{
			this.#gab();
			this.Diagram3DFlipCommand.InvalidateCanExecute();
			this.ChangeDiagram2DTypeCommand.InvalidateCanExecute();
			this.ChangeCutTypeCommand.InvalidateCanExecute();
			this.CutCommand.InvalidateCanExecute();
			this.ExportDiagramCommand.InvalidateCanExecute();
			this.ChangePresenterTypeCommand.InvalidateCanExecute();
			this.OnContextMenuOpeningCommand.InvalidateCanExecute();
			this.ActivateDiagramCommand.InvalidateCanExecute();
			this.ShowPlaneCommand.InvalidateCanExecute();
		}

		// Token: 0x060023B2 RID: 9138 RVA: 0x000CE69C File Offset: 0x000CC89C
		protected void #Ydb(#pkb #He)
		{
			EventHandler<#pkb> eventHandler = this.#S;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x060023B3 RID: 9139 RVA: 0x000CE6C8 File Offset: 0x000CC8C8
		protected void #Zdb(#pkb #He)
		{
			EventHandler<#pkb> eventHandler = this.#T;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x060023B4 RID: 9140 RVA: 0x000CE6F4 File Offset: 0x000CC8F4
		protected void #0db(#pkb #He)
		{
			EventHandler<#pkb> eventHandler = this.#R;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x060023B5 RID: 9141 RVA: 0x000CE720 File Offset: 0x000CC920
		protected void #1db(#pkb #He)
		{
			EventHandler<#pkb> eventHandler = this.#Q;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x060023B6 RID: 9142 RVA: 0x000CE74C File Offset: 0x000CC94C
		protected void #2db(#Yjb #He)
		{
			EventHandler<#Yjb> eventHandler = this.#U;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x060023B7 RID: 9143 RVA: 0x000CE778 File Offset: 0x000CC978
		protected void #3db()
		{
			this.#gab();
			EventHandler eventHandler = this.#W;
			if (eventHandler != null)
			{
				eventHandler(this, EventArgs.Empty);
			}
		}

		// Token: 0x060023B8 RID: 9144 RVA: 0x000CE7B0 File Offset: 0x000CC9B0
		protected void #4db()
		{
			this.#gab();
			EventHandler eventHandler = this.#V;
			if (eventHandler != null)
			{
				eventHandler(this, EventArgs.Empty);
			}
		}

		// Token: 0x060023B9 RID: 9145 RVA: 0x000CE7E8 File Offset: 0x000CC9E8
		internal void #5db()
		{
			if (this.PresenterType != DiagramPresenterType.#a)
			{
				return;
			}
			Diagram3DCutType diagram3DCutType = Diagram3DCutType.#a;
			if (this.Diagram3DIsHorizontalCutEnabled)
			{
				diagram3DCutType = Diagram3DCutType.#b;
			}
			else if (this.Diagram3DIsVerticalCutEnabled)
			{
				diagram3DCutType = Diagram3DCutType.#c;
			}
			if (diagram3DCutType != this.Diagram3DCutType)
			{
				this.#A.#Bfb(diagram3DCutType);
				this.Diagram3DCutType = diagram3DCutType;
				this.#geb();
			}
			this.#vh();
			this.#Wcb();
			this.#4db();
			this.#6db();
		}

		// Token: 0x060023BA RID: 9146 RVA: 0x000CE85C File Offset: 0x000CCA5C
		public void #6db()
		{
			this.#vh();
			if (this.PresenterType != DiagramPresenterType.#b)
			{
				if (this.PresenterType == DiagramPresenterType.#a)
				{
					if (this.DefinedDiagram3DCutType == Diagram3DCutType.#b)
					{
						this.PresenterHost.Header = Strings.String3DMM;
						return;
					}
					if (this.DefinedDiagram3DCutType == Diagram3DCutType.#c)
					{
						this.PresenterHost.Header = Strings.String3DPM;
						return;
					}
					this.PresenterHost.Header = Strings.StringDiagram3D;
				}
				return;
			}
			switch (this.Diagram2DType)
			{
			case Diagram2DType.DiagramMM:
				this.PresenterHost.Header = Strings.StringMM_UPPER;
				return;
			case Diagram2DType.DiagramPM:
				this.PresenterHost.Header = Strings.StringPM;
				return;
			case Diagram2DType.DiagramPMPlus:
				this.PresenterHost.Header = Strings.StringPlusSpacePM;
				return;
			case Diagram2DType.DiagramPMMinus:
				this.PresenterHost.Header = Strings.StringMinusSpacePM;
				return;
			default:
				this.PresenterHost.Header = Strings.StringDiagram2D;
				return;
			}
		}

		// Token: 0x060023BB RID: 9147 RVA: 0x000CE958 File Offset: 0x000CCB58
		public void #1()
		{
			#Wgb #Wgb = this.#A;
			if (#Wgb != null)
			{
				#Wgb.#yl();
			}
			base.#FH();
			Ignore.#14d<Exception>(new Action(this.#HVh), null);
			Ignore.#14d<Exception>(new Action(this.#IVh), null);
		}

		// Token: 0x060023BC RID: 9148 RVA: 0x00022520 File Offset: 0x00020720
		private void #7db(object #Ge, MouseEventArgs #He)
		{
			if (this.#A != null && #He.LeftButton == MouseButtonState.Pressed)
			{
				this.#A.#tfb();
			}
		}

		// Token: 0x060023BD RID: 9149 RVA: 0x0002254A File Offset: 0x0002074A
		private void #scb(object #Ge, SizeChangedEventArgs #He)
		{
			this.#Kdb();
		}

		// Token: 0x060023BE RID: 9150 RVA: 0x000CE9B0 File Offset: 0x000CCBB0
		private bool #8db(object #Sb)
		{
			ActivateDiagramParameters activateDiagramParameters = #Sb as ActivateDiagramParameters;
			return activateDiagramParameters != null && DiagramPresenterViewModel.#Hdb(this.#G, activateDiagramParameters);
		}

		// Token: 0x060023BF RID: 9151 RVA: 0x000CE9E4 File Offset: 0x000CCBE4
		private void #9db(object #Sb)
		{
			ActivateDiagramParameters activateDiagramParameters = #Sb as ActivateDiagramParameters;
			if (activateDiagramParameters == null)
			{
				return;
			}
			this.#Pd(activateDiagramParameters);
		}

		// Token: 0x060023C0 RID: 9152 RVA: 0x000CEA10 File Offset: 0x000CCC10
		private bool #Bab(object #GA)
		{
			try
			{
				if (!this.#aeb())
				{
					return false;
				}
				DiagramPresenterType diagramPresenterType = (DiagramPresenterType)#GA;
				if (diagramPresenterType == DiagramPresenterType.#b)
				{
					return true;
				}
				if (diagramPresenterType == DiagramPresenterType.#a)
				{
					return this.#G != null && this.#G.Input.Options.ConsideredAxis == ConsideredAxis.Both;
				}
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x060023C1 RID: 9153 RVA: 0x0002255A File Offset: 0x0002075A
		private bool #aeb()
		{
			return this.#G != null && this.#G.IsReportSourceValid;
		}

		// Token: 0x060023C2 RID: 9154 RVA: 0x0002257D File Offset: 0x0002077D
		private bool #beb(object #GA)
		{
			return this.#aeb() && this.PresenterType == DiagramPresenterType.#a && this.Diagram3DEnableCutOnValueChange && (this.Diagram3DIsVerticalCutEnabled || this.Diagram3DIsHorizontalCutEnabled);
		}

		// Token: 0x060023C3 RID: 9155 RVA: 0x000CEA88 File Offset: 0x000CCC88
		private bool #ceb(object #Sb)
		{
			bool result;
			try
			{
				if (!this.#aeb() || #Sb == null)
				{
					result = false;
				}
				else
				{
					ExportDiagramType #2bb = (ExportDiagramType)#Sb;
					#Kgb #Kgb2;
					if (this.PresenterType != DiagramPresenterType.#b)
					{
						#Kgb #Kgb = this.#A;
						#Kgb2 = #Kgb;
					}
					else
					{
						#Kgb #Kgb = this.#B;
						#Kgb2 = #Kgb;
					}
					#Kgb #Kgb3 = #Kgb2;
					result = (#Kgb3 != null && #Kgb3.#3bb(#2bb));
				}
			}
			catch (Exception #ob)
			{
				this.#s.#3Ab(#ob);
				result = false;
			}
			return result;
		}

		// Token: 0x060023C4 RID: 9156 RVA: 0x000CEB08 File Offset: 0x000CCD08
		private void #deb(object #Sb)
		{
			DiagramPresenterViewModel.#A0h #A0h = new DiagramPresenterViewModel.#A0h();
			DiagramPresenterViewModel.#A0h #A0h2;
			if (!false)
			{
				#A0h2 = #A0h;
			}
			#A0h2.#a = #Sb;
			#A0h2.#b = this;
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(#A0h2.#T5b));
		}

		// Token: 0x060023C5 RID: 9157 RVA: 0x000CEB4C File Offset: 0x000CCD4C
		private void #eeb(object #GA)
		{
			if (this.PresenterType != DiagramPresenterType.#a)
			{
				return;
			}
			this.PartToCutHorizontally = ((this.PartToCutHorizontally == #xbb.#a) ? #xbb.#b : #xbb.#a);
			this.PartToCutVertically = ((this.PartToCutVertically == #ybb.#b) ? #ybb.#a : #ybb.#b);
			this.#A.#wfb(this.PartToCutHorizontally, this.PartToCutVertically);
			this.#feb();
		}

		// Token: 0x060023C6 RID: 9158 RVA: 0x000225B5 File Offset: 0x000207B5
		private void #feb()
		{
			this.#Rdb(this.AxialLoad);
			this.#Pdb(this.Angle);
			this.#vh();
		}

		// Token: 0x060023C7 RID: 9159 RVA: 0x000CEBB0 File Offset: 0x000CCDB0
		private void #geb()
		{
			if (this.PresenterType != DiagramPresenterType.#a)
			{
				return;
			}
			if (this.Diagram3DCutType != Diagram3DCutType.#a || this.Diagram3DEnableCutOnValueChange)
			{
				this.#feb();
			}
			else
			{
				this.#A.#vfb();
			}
			this.#Wcb();
			this.#vh();
		}

		// Token: 0x060023C8 RID: 9160 RVA: 0x000CEC04 File Offset: 0x000CCE04
		private double #heb()
		{
			if (this.PresenterType == DiagramPresenterType.#b)
			{
				if (this.Diagram2DType == Diagram2DType.DiagramMM)
				{
					return this.AxialLoad;
				}
				return this.Angle;
			}
			else
			{
				if (this.Diagram3DCutType == Diagram3DCutType.#b)
				{
					return this.AxialLoad;
				}
				if (this.Diagram3DCutType == Diagram3DCutType.#c)
				{
					return this.Angle;
				}
				return 0.0;
			}
		}

		// Token: 0x060023C9 RID: 9161 RVA: 0x000CEC68 File Offset: 0x000CCE68
		private void #ieb()
		{
			this.PresenterHost.Pane.Background = ((this.PresenterType == DiagramPresenterType.#a || this.#B == null) ? Brushes.Transparent : this.#B.Background);
			this.Background = this.PresenterHost.Pane.Background;
		}

		// Token: 0x060023CA RID: 9162 RVA: 0x000225E1 File Offset: 0x000207E1
		private void #hz()
		{
			this.#jeb(this.#G);
			this.#keb(this.#G);
			this.#ieb();
			this.#6db();
			this.#vh();
		}

		// Token: 0x060023CB RID: 9163 RVA: 0x000CECCC File Offset: 0x000CCECC
		private void #jeb(#lte #Wdb)
		{
			if (((#Wdb != null) ? #Wdb.FailureSurface : null) == null)
			{
				return;
			}
			if (this.PresenterType == DiagramPresenterType.#a)
			{
				#Wgb #Wgb = this.#A;
				if (#Wgb == null)
				{
					return;
				}
				if (#Wgb.IsLoaded)
				{
					#Wgb.#yl();
				}
				#Wgb.CurrentReportingModel = #Wdb;
				#Wgb.#Cfb(#Wdb);
				this.#geb();
			}
			this.#6db();
		}

		// Token: 0x060023CC RID: 9164 RVA: 0x000CED30 File Offset: 0x000CCF30
		private void #keb(#lte #Wdb)
		{
			DiagramPresenterViewModel.#B0h #B0h = new DiagramPresenterViewModel.#B0h();
			#B0h.#a = this;
			#B0h.#b = #Wdb;
			#lte #lte = #B0h.#b;
			if (((#lte != null) ? #lte.FailureSurface : null) == null)
			{
				return;
			}
			if (this.PresenterType == DiagramPresenterType.#b)
			{
				#B0h.#c = this.#N;
				this.#N = false;
				if (this.#P)
				{
					LayoutHelper.BeginInvokeOnApplicationThread(new Action(#B0h.#V5b));
				}
				else
				{
					this.#B.#6bb(#B0h.#b, this.Diagram2DType, this.#heb(), this.#x, #B0h.#c);
				}
				this.#P = false;
				this.#ieb();
			}
			this.#6db();
			this.#Wcb();
		}

		// Token: 0x060023CD RID: 9165 RVA: 0x000CEE00 File Offset: 0x000CD000
		private void #leb()
		{
			if (this.#A == null)
			{
				this.#A = new FailureSurfaceViewModel(base.Services, new Lazy<IFailureSurfaceView>(new Func<IFailureSurfaceView>(DiagramPresenterViewModel.<>c.<>9.#C0h)), base.Services.GuiController, this.#t, new DefaultDrawingResultsFactory(), new EventManagerFactory(), this.PresenterHost, this.#s, this.#w);
				this.#A.AxialLoadChanged += this.#JVh;
				this.#A.AngleChanged += this.#KVh;
				this.#A.AxialLoadChanging += this.#LVh;
				this.#A.AngleChanging += this.#MVh;
				this.#A.LoadPointClickedEventArgs += this.#NVh;
				this.#A.#Mdb(this.#x);
			}
			#Wgb #Wgb = this.#A;
			this.ActiveView = ((#Wgb != null) ? #Wgb.View : null);
		}

		// Token: 0x060023CE RID: 9166 RVA: 0x000CEF34 File Offset: 0x000CD134
		private void #meb()
		{
			if (this.#B == null)
			{
				this.#B = new Diagram2DViewModel(base.Services, new Lazy<IDiagram2DView>(new Func<IDiagram2DView>(DiagramPresenterViewModel.<>c.<>9.#D0h)), this.#r, this.#t, this.#q, this.#s, base.Services.GuiController, this.#u, this.#v);
				this.#B.LoadPointClicked += this.#OVh;
			}
			this.ActiveView = this.#B.View;
		}

		// Token: 0x17000C3F RID: 3135
		// (get) Token: 0x060023CF RID: 9167 RVA: 0x00022619 File Offset: 0x00020819
		public IDelegateCommand CopyToClipboardCommand { get; }

		// Token: 0x17000C40 RID: 3136
		// (get) Token: 0x060023D0 RID: 9168 RVA: 0x00022625 File Offset: 0x00020825
		public IDelegateCommand PrintExportCommand { get; }

		// Token: 0x17000C41 RID: 3137
		// (get) Token: 0x060023D1 RID: 9169 RVA: 0x00022631 File Offset: 0x00020831
		public IDelegateCommand AddToReportCommand { get; }

		// Token: 0x060023D2 RID: 9170 RVA: 0x0002263D File Offset: 0x0002083D
		private void #2h(object #Sb)
		{
			base.Services.Commands.PrintExport.Execute(#Sb);
		}

		// Token: 0x060023D3 RID: 9171 RVA: 0x00003375 File Offset: 0x00001575
		private bool #qeb(object #Sb)
		{
			return true;
		}

		// Token: 0x060023D4 RID: 9172 RVA: 0x00022661 File Offset: 0x00020861
		private void #7h(object #Sb)
		{
			base.Services.Commands.AddToReport.Execute(#Sb);
		}

		// Token: 0x060023D5 RID: 9173 RVA: 0x00003375 File Offset: 0x00001575
		private bool #reb(object #Sb)
		{
			return true;
		}

		// Token: 0x060023D6 RID: 9174 RVA: 0x00022685 File Offset: 0x00020885
		private void #seb(object #Sb)
		{
			this.#ueb();
		}

		// Token: 0x060023D7 RID: 9175 RVA: 0x00022695 File Offset: 0x00020895
		private bool #teb(object #Sb)
		{
			return this.PresenterType == DiagramPresenterType.#b;
		}

		// Token: 0x060023D8 RID: 9176 RVA: 0x000226A8 File Offset: 0x000208A8
		private void #ueb()
		{
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#PVh));
		}

		// Token: 0x060023D9 RID: 9177 RVA: 0x000226C4 File Offset: 0x000208C4
		[CompilerGenerated]
		private void #HVh()
		{
			#Wgb #Wgb = this.#A;
			if (#Wgb == null)
			{
				return;
			}
			#Wgb.#Vbb();
		}

		// Token: 0x060023DA RID: 9178 RVA: 0x000226DE File Offset: 0x000208DE
		[CompilerGenerated]
		private void #IVh()
		{
			#Jgb #Jgb = this.#B;
			if (#Jgb == null)
			{
				return;
			}
			#Jgb.#Vbb();
		}

		// Token: 0x060023DB RID: 9179 RVA: 0x000226F8 File Offset: 0x000208F8
		[CompilerGenerated]
		private void #JVh(object #Ge, #pkb #Lg)
		{
			this.#1db(#Lg);
		}

		// Token: 0x060023DC RID: 9180 RVA: 0x0002270D File Offset: 0x0002090D
		[CompilerGenerated]
		private void #KVh(object #Ge, #pkb #Lg)
		{
			this.#0db(#Lg);
		}

		// Token: 0x060023DD RID: 9181 RVA: 0x00022722 File Offset: 0x00020922
		[CompilerGenerated]
		private void #LVh(object #Ge, #pkb #Lg)
		{
			this.#Ydb(#Lg);
		}

		// Token: 0x060023DE RID: 9182 RVA: 0x00022737 File Offset: 0x00020937
		[CompilerGenerated]
		private void #MVh(object #Ge, #pkb #Lg)
		{
			this.#Zdb(#Lg);
		}

		// Token: 0x060023DF RID: 9183 RVA: 0x0002274C File Offset: 0x0002094C
		[CompilerGenerated]
		private void #NVh(object #Ge, #Yjb #Lg)
		{
			this.#2db(#Lg);
		}

		// Token: 0x060023E0 RID: 9184 RVA: 0x0002274C File Offset: 0x0002094C
		[CompilerGenerated]
		private void #OVh(object #Ge, #Yjb #Lg)
		{
			this.#2db(#Lg);
		}

		// Token: 0x060023E1 RID: 9185 RVA: 0x000CEFF8 File Offset: 0x000CD1F8
		[CompilerGenerated]
		private void #PVh()
		{
			try
			{
				DiagramImageGenerator diagramImageGenerator = new DiagramImageGenerator();
				DiagramImageGenerator diagramImageGenerator2;
				if (!false)
				{
					diagramImageGenerator2 = diagramImageGenerator;
				}
				Diagram2DData diagram2DData = this.#Ldb(false);
				if (diagram2DData != null)
				{
					using (MemoryStream memoryStream = new MemoryStream())
					{
						diagramImageGenerator2.#Ite(this.#G, diagram2DData, memoryStream);
						memoryStream.#i2d();
						BitmapImage bitmapImage = new BitmapImage();
						bitmapImage.BeginInit();
						bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
						bitmapImage.StreamSource = memoryStream;
						bitmapImage.EndInit();
						Clipboard.SetImage(bitmapImage);
						base.Services.DialogService.#pn(base.Services.DialogService.ActiveWindow, Strings.StringDiagramHasBeenCopiedToClipboardAndIsReadyToBePasted.#z2d());
					}
				}
			}
			catch (Exception #ob)
			{
				this.#s.#3Ab(#ob);
			}
		}

		// Token: 0x04000E28 RID: 3624
		[CompilerGenerated]
		private EventHandler #a;

		// Token: 0x04000E29 RID: 3625
		private MenuItemExt #b;

		// Token: 0x04000E2A RID: 3626
		private MenuItemExt #c;

		// Token: 0x04000E2B RID: 3627
		private MenuItemExt #d;

		// Token: 0x04000E2C RID: 3628
		private MenuItemExt #e;

		// Token: 0x04000E2D RID: 3629
		private MenuItemExt #f;

		// Token: 0x04000E2E RID: 3630
		private MenuItemExt #g;

		// Token: 0x04000E2F RID: 3631
		private MenuItemExt #h;

		// Token: 0x04000E30 RID: 3632
		private MenuItemExt #i;

		// Token: 0x04000E31 RID: 3633
		[CompilerGenerated]
		private readonly DelegateCommandAdapter #j;

		// Token: 0x04000E32 RID: 3634
		[CompilerGenerated]
		private readonly RadObservableCollection<MenuItemExt> #k;

		// Token: 0x04000E33 RID: 3635
		[CompilerGenerated]
		private readonly DelegateCommandAdapter #l;

		// Token: 0x04000E34 RID: 3636
		[CompilerGenerated]
		private readonly DelegateCommandAdapter #m;

		// Token: 0x04000E35 RID: 3637
		[CompilerGenerated]
		private readonly DelegateCommandAdapter #n;

		// Token: 0x04000E36 RID: 3638
		[CompilerGenerated]
		private readonly DelegateCommandAdapter #o;

		// Token: 0x04000E37 RID: 3639
		[CompilerGenerated]
		private readonly DelegateCommandAdapter #p;

		// Token: 0x04000E38 RID: 3640
		private readonly ISettingsManager #q;

		// Token: 0x04000E39 RID: 3641
		private readonly #yse #r;

		// Token: 0x04000E3A RID: 3642
		private readonly #tUd #s;

		// Token: 0x04000E3B RID: 3643
		private readonly #yBe #t;

		// Token: 0x04000E3C RID: 3644
		private readonly #qW #u;

		// Token: 0x04000E3D RID: 3645
		private readonly #mAe #v;

		// Token: 0x04000E3E RID: 3646
		private readonly #tbb #w;

		// Token: 0x04000E3F RID: 3647
		private readonly List<SelectedLoadData> #x = new List<SelectedLoadData>();

		// Token: 0x04000E40 RID: 3648
		private IView #y;

		// Token: 0x04000E41 RID: 3649
		private bool #z;

		// Token: 0x04000E42 RID: 3650
		private #Wgb #A;

		// Token: 0x04000E43 RID: 3651
		private #Jgb #B;

		// Token: 0x04000E44 RID: 3652
		private DiagramPresenterType #C;

		// Token: 0x04000E45 RID: 3653
		private bool #D;

		// Token: 0x04000E46 RID: 3654
		private Diagram3DCutType #E;

		// Token: 0x04000E47 RID: 3655
		private Diagram2DType #F;

		// Token: 0x04000E48 RID: 3656
		private #lte #G;

		// Token: 0x04000E49 RID: 3657
		private bool #H;

		// Token: 0x04000E4A RID: 3658
		private bool #I;

		// Token: 0x04000E4B RID: 3659
		private bool #J;

		// Token: 0x04000E4C RID: 3660
		private Brush #K;

		// Token: 0x04000E4D RID: 3661
		private bool #L;

		// Token: 0x04000E4E RID: 3662
		private Diagram3DCutType #M;

		// Token: 0x04000E4F RID: 3663
		private bool #N;

		// Token: 0x04000E50 RID: 3664
		private bool #O;

		// Token: 0x04000E51 RID: 3665
		private bool #P;

		// Token: 0x04000E52 RID: 3666
		[CompilerGenerated]
		private EventHandler<#pkb> #Q;

		// Token: 0x04000E53 RID: 3667
		[CompilerGenerated]
		private EventHandler<#pkb> #R;

		// Token: 0x04000E54 RID: 3668
		[CompilerGenerated]
		private EventHandler<#pkb> #S;

		// Token: 0x04000E55 RID: 3669
		[CompilerGenerated]
		private EventHandler<#pkb> #T;

		// Token: 0x04000E56 RID: 3670
		[CompilerGenerated]
		private EventHandler<#Yjb> #U;

		// Token: 0x04000E57 RID: 3671
		[CompilerGenerated]
		private EventHandler #V;

		// Token: 0x04000E58 RID: 3672
		[CompilerGenerated]
		private EventHandler #W;

		// Token: 0x04000E59 RID: 3673
		[CompilerGenerated]
		private readonly #Ke #X;

		// Token: 0x04000E5A RID: 3674
		[CompilerGenerated]
		private readonly DelegateCommandAdapter #Y;

		// Token: 0x04000E5B RID: 3675
		[CompilerGenerated]
		private double #Z;

		// Token: 0x04000E5C RID: 3676
		[CompilerGenerated]
		private double #0;

		// Token: 0x04000E5D RID: 3677
		[CompilerGenerated]
		private readonly DelegateCommandAdapter #1;

		// Token: 0x04000E5E RID: 3678
		[CompilerGenerated]
		private readonly DelegateCommandAdapter #2;

		// Token: 0x04000E5F RID: 3679
		[CompilerGenerated]
		private #xbb #3;

		// Token: 0x04000E60 RID: 3680
		[CompilerGenerated]
		private #ybb #4;

		// Token: 0x04000E61 RID: 3681
		[CompilerGenerated]
		private readonly IDelegateCommand #5;

		// Token: 0x04000E62 RID: 3682
		[CompilerGenerated]
		private readonly IDelegateCommand #6;

		// Token: 0x04000E63 RID: 3683
		[CompilerGenerated]
		private readonly IDelegateCommand #7;

		// Token: 0x02000402 RID: 1026
		[CompilerGenerated]
		private sealed class #z0h
		{
			// Token: 0x060023E7 RID: 9191 RVA: 0x000CF0E4 File Offset: 0x000CD2E4
			internal void #R5b()
			{
				this.#a.#B.#6bb(this.#a.#G, this.#a.Diagram2DType, (this.#a.Diagram2DType == Diagram2DType.DiagramMM) ? this.#a.AxialLoad : this.#a.Angle, this.#a.#x, this.#b);
			}

			// Token: 0x04000E67 RID: 3687
			public DiagramPresenterViewModel #a;

			// Token: 0x04000E68 RID: 3688
			public bool #b;
		}

		// Token: 0x02000403 RID: 1027
		[CompilerGenerated]
		private sealed class #A0h
		{
			// Token: 0x060023E9 RID: 9193 RVA: 0x000CF15C File Offset: 0x000CD35C
			internal void #T5b()
			{
				try
				{
					ExportDiagramType #2bb = (ExportDiagramType)this.#a;
					#Kgb #Kgb2;
					if (this.#b.PresenterType != DiagramPresenterType.#b)
					{
						#Kgb #Kgb = this.#b.#A;
						#Kgb2 = #Kgb;
					}
					else
					{
						#Kgb #Kgb = this.#b.#B;
						#Kgb2 = #Kgb;
					}
					#Kgb #Kgb3 = #Kgb2;
					if (#Kgb3 != null && #Kgb3.#3bb(#2bb))
					{
						#Kgb3.#1bb(this.#b.#G, #2bb);
					}
				}
				catch (Exception #ob)
				{
					this.#b.#s.#3Ab(#ob);
				}
			}

			// Token: 0x04000E69 RID: 3689
			public object #a;

			// Token: 0x04000E6A RID: 3690
			public DiagramPresenterViewModel #b;
		}

		// Token: 0x02000404 RID: 1028
		[CompilerGenerated]
		private sealed class #B0h
		{
			// Token: 0x060023EB RID: 9195 RVA: 0x000CF1F0 File Offset: 0x000CD3F0
			internal void #V5b()
			{
				this.#a.#B.#6bb(this.#b, this.#a.Diagram2DType, this.#a.#heb(), this.#a.#x, this.#c);
			}

			// Token: 0x04000E6B RID: 3691
			public DiagramPresenterViewModel #a;

			// Token: 0x04000E6C RID: 3692
			public #lte #b;

			// Token: 0x04000E6D RID: 3693
			public bool #c;
		}
	}
}
