using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using #6re;
using #7hc;
using #eU;
using #fpb;
using #Iub;
using #lH;
using #Mbb;
using #NHe;
using #o1d;
using #oFe;
using #Oze;
using #rCe;
using #sUd;
using #Wse;
using #xBe;
using #Zjb;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.DTO;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.FailureSurface.Controls;
using StructurePoint.Products.Column.FailureSurface.Views;
using StructurePoint.Products.Column.Services.API;
using Svg;
using Telerik.Windows;

namespace StructurePoint.Products.Column.FailureSurface.ViewModels
{
	// Token: 0x020003F5 RID: 1013
	internal sealed class Diagram2DViewModel : #HH<IDiagram2DView>, INotifyPropertyChanged, IViewModel<IDiagram2DView>, IViewModel, #Jgb, #Kgb
	{
		// Token: 0x060022ED RID: 8941 RVA: 0x000CB654 File Offset: 0x000C9854
		public Diagram2DViewModel(ICoreServices services, Lazy<IDiagram2DView> view, #yse settingsManager, #yBe diagramExporter, ISettingsManager applicationSettings, #tUd exceptionHandler, #zU guiController, #qW designEngineService, #mAe superImposeContext) : base(view, services)
		{
			this.#a = settingsManager;
			this.#b = diagramExporter;
			this.#c = applicationSettings;
			this.#d = exceptionHandler;
			this.#e = guiController;
			this.#f = designEngineService;
			this.#s = superImposeContext;
			base.View.DiagramMouseMove += this.#gcb;
			base.View.DiagramMouseButtonDown += this.#ecb;
			base.View.ViewControls.ViewControlsChanged += this.#dcb;
			base.View.ViewControls.CloseMenuItemClicked += this.#ccb;
			base.View.KeyDown += this.#yh;
			base.View.ShowGridChanged += this.#bcb;
			base.Services.MessageBus.DiagramImposed += this.#qcb;
			this.#rcb();
			#5re #5re = this.#a.#jJ();
			this.#l = new SolidColorBrush(#5re.ScreenBackgroundColor);
			base.View.IsShowGridChecked = #5re.ShowGrid;
			this.#l.Freeze();
		}

		// Token: 0x1400007F RID: 127
		// (add) Token: 0x060022EE RID: 8942 RVA: 0x000CB7C0 File Offset: 0x000C99C0
		// (remove) Token: 0x060022EF RID: 8943 RVA: 0x000CB804 File Offset: 0x000C9A04
		public event EventHandler<#Yjb> LoadPointClicked
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#Yjb> eventHandler = this.#q;
				EventHandler<#Yjb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#Yjb> value2 = (EventHandler<#Yjb>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#Yjb>>(ref this.#q, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#Yjb> eventHandler = this.#q;
				EventHandler<#Yjb> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#Yjb> value2 = (EventHandler<#Yjb>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#Yjb>>(ref this.#q, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000080 RID: 128
		// (add) Token: 0x060022F0 RID: 8944 RVA: 0x000CB848 File Offset: 0x000C9A48
		// (remove) Token: 0x060022F1 RID: 8945 RVA: 0x000CB88C File Offset: 0x000C9A8C
		public event EventHandler ViewControlsClosed
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.#r;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
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
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.#r, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x17000C14 RID: 3092
		// (get) Token: 0x060022F2 RID: 8946 RVA: 0x00021ABD File Offset: 0x0001FCBD
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x17000C15 RID: 3093
		// (get) Token: 0x060022F3 RID: 8947 RVA: 0x00021ACD File Offset: 0x0001FCCD
		public IReadOnlyList<LoadPointDrawingData> VisibleLoadPoints
		{
			get
			{
				return this.#h;
			}
		}

		// Token: 0x17000C16 RID: 3094
		// (get) Token: 0x060022F4 RID: 8948 RVA: 0x00021AD9 File Offset: 0x0001FCD9
		public #mAe SuperImposeContext { get; }

		// Token: 0x17000C17 RID: 3095
		// (get) Token: 0x060022F5 RID: 8949 RVA: 0x00021AE5 File Offset: 0x0001FCE5
		// (set) Token: 0x060022F6 RID: 8950 RVA: 0x00021AF1 File Offset: 0x0001FCF1
		public SolidColorBrush Background
		{
			get
			{
				return this.#l;
			}
			set
			{
				if (!object.Equals(this.#l, value))
				{
					this.#l = value;
					base.RaisePropertyChanged(#Phc.#3hc(107363120));
				}
			}
		}

		// Token: 0x17000C18 RID: 3096
		// (get) Token: 0x060022F7 RID: 8951 RVA: 0x00021B24 File Offset: 0x0001FD24
		private bool IsUserManupulatingDiagram
		{
			get
			{
				return base.View.IsZoomRectangleEnabled || base.View.IsPanEnabled;
			}
		}

		// Token: 0x060022F8 RID: 8952 RVA: 0x00021B4C File Offset: 0x0001FD4C
		public void #Vbb()
		{
			base.Services.MessageBus.DiagramImposed -= this.#qcb;
			IDisposable disposable = this.#m;
			if (disposable == null)
			{
				return;
			}
			disposable.Dispose();
		}

		// Token: 0x060022F9 RID: 8953 RVA: 0x00021B86 File Offset: 0x0001FD86
		public bool #Wbb()
		{
			return base.View.CancelAllTools();
		}

		// Token: 0x060022FA RID: 8954 RVA: 0x00021B9F File Offset: 0x0001FD9F
		public void #Xbb()
		{
			base.View.ResetZoomAndTranslation();
		}

		// Token: 0x060022FB RID: 8955 RVA: 0x00021BB8 File Offset: 0x0001FDB8
		public void #Ybb(bool #Zbb, ToolsPanelPosition #0bb)
		{
			base.View.ViewControls.Visibility = (#Zbb ? Visibility.Visible : Visibility.Collapsed);
			base.View.ViewControls.SelectedPosition = #0bb;
		}

		// Token: 0x060022FC RID: 8956 RVA: 0x000CB8D0 File Offset: 0x000C9AD0
		public void #1bb(#lte #Od, ExportDiagramType #2bb)
		{
			try
			{
				bool flag = this.#b.#KAe(#Od, this.#g, #2bb);
				if (flag)
				{
					base.DialogService.#od(Strings.StringDiagramExportedSuccesfully.#z2d(), MessageBoxButton.OK, MessageBoxImage.Asterisk);
				}
			}
			catch (Exception #ob)
			{
				this.#d.#3Ab(#ob);
			}
		}

		// Token: 0x060022FD RID: 8957 RVA: 0x000CB93C File Offset: 0x000C9B3C
		public bool #3bb(ExportDiagramType #2bb)
		{
			Diagram2DType? diagram2DType = this.#g.Diagram2DType;
			if (diagram2DType == null)
			{
				return false;
			}
			if (#2bb != ExportDiagramType.Nominal)
			{
				return #2bb == ExportDiagramType.Factored && (this.#g.Diagram2DMMFactored != null || this.#g.Diagram2DPMFactored != null);
			}
			return this.#g.Diagram2DMMNominal != null || this.#g.Diagram2DPMNominal != null;
		}

		// Token: 0x060022FE RID: 8958 RVA: 0x000CB9B4 File Offset: 0x000C9BB4
		public Diagram2DData #4bb(bool #5bb = false)
		{
			Diagram2DType? diagram2DType = this.#g.Diagram2DType;
			if (diagram2DType == null || this.#g.Parameter == null)
			{
				return null;
			}
			#lte #lte = this.#g.Model;
			#5re #5re = this.#a.#jJ();
			#5re.ScreenBackgroundColor = Colors.White;
			System.Windows.Rect currentViewBox = base.View.CurrentViewBox;
			StructurePoint.CoreAssets.Infrastructure.Data.Rect? rect = null;
			double num = 1000.0;
			double num2 = 1000.0;
			if (base.View.ZoomFactor > 1.0)
			{
				double num3 = 0.01;
				rect = new StructurePoint.CoreAssets.Infrastructure.Data.Rect?(new StructurePoint.CoreAssets.Infrastructure.Data.Rect(new StructurePoint.CoreAssets.Infrastructure.Data.Point(currentViewBox.Location.X - num3 * currentViewBox.Location.X, currentViewBox.Location.Y), new StructurePoint.CoreAssets.Infrastructure.Data.Size(currentViewBox.Width + currentViewBox.Width * num3 * 2.0, currentViewBox.Height + currentViewBox.Height * num3 * 2.0)));
				num2 = base.View.DiagramActualHeight;
				num = base.View.DiagramActualWidth;
			}
			#LCe #LCe = new #LCe(#lte, #5re, this.#g.Diagram2DType.Value, this.#g.Parameter.Value)
			{
				ViewportWidth = num,
				ViewportHeight = num2,
				ViewWindow = rect,
				ElementScale = (float)(1.0 / Math.Max(base.View.ZoomFactor, 1.0)),
				FactoredDiagram = 
				{
					UniCurve = this.#g.Diagram2DPMFactored,
					BiCurve = this.#g.Diagram2DMMFactored
				},
				NominalDiagram = 
				{
					UniCurve = this.#g.Diagram2DPMNominal,
					BiCurve = this.#g.Diagram2DMMNominal
				},
				Filters = this.#pcb(#lte)
			};
			string text = #Qze.#Pze(#lte, this.#g.Diagram2DType.Value, this.#g.Parameter.Value, this.SuperImposeContext, #5bb);
			Diagram2DData diagram2DData = new Diagram2DData
			{
				DiagramType = this.#g.Diagram2DType.Value,
				Parameters = #LCe,
				IsCustom = (#lte.Input.Options.ConsideredAxis == ConsideredAxis.Both),
				Description = text,
				SuperImposeContextDump = this.SuperImposeContext.#Yfd(),
				FactoredIncluded = #5re.ShowFactored,
				NominalIncluded = #5re.ShowNominal
			};
			diagram2DData.DrawnLoadPoints.AddRange(this.#k.VisibleLoadPoints);
			diagram2DData.PredefinedDrawnLoadPoints = true;
			return diagram2DData;
		}

		// Token: 0x060022FF RID: 8959 RVA: 0x000CBCBC File Offset: 0x000C9EBC
		public void #6bb(#lte #Od, Diagram2DType #2bb, double #Sb, IList<SelectedLoadData> #Sd, bool #7bb)
		{
			Diagram2DViewModel.#3yf #3yf;
			#3yf.#b = AsyncVoidMethodBuilder.Create();
			#3yf.#c = this;
			#3yf.#d = #Od;
			#3yf.#e = #2bb;
			#3yf.#f = #Sb;
			#3yf.#g = #Sd;
			#3yf.#h = #7bb;
			#3yf.#a = -1;
			#3yf.#b.Start<Diagram2DViewModel.#3yf>(ref #3yf);
		}

		// Token: 0x06002300 RID: 8960 RVA: 0x000CBD2C File Offset: 0x000C9F2C
		public LoadPointDrawingData #8bb(System.Windows.Point #0bb)
		{
			Diagram2DViewModel.#SUb #SUb = new Diagram2DViewModel.#SUb();
			Diagram2DViewModel.#SUb #SUb2;
			if (!false)
			{
				#SUb2 = #SUb;
			}
			#SUb2.#a = this;
			#SUb2.#b = #0bb;
			var source = base.View.DiagramPostprocessor.LoadPointLines.Select(new Func<PathMetadata, <>f__AnonymousType4<PathMetadata, double>>(#SUb2.#y5b)).ToList();
			#SUb2.#c = source.OrderBy(new Func<<>f__AnonymousType4<PathMetadata, double>, double>(Diagram2DViewModel.<>c.<>9.#4yf)).ThenBy(new Func<<>f__AnonymousType4<PathMetadata, double>, int>(#SUb2.#z5b)).FirstOrDefault();
			if (#SUb2.#c == null || #SUb2.#c.Distance > #SUb2.#c.Item.ActualLength / 2.0)
			{
				return null;
			}
			return this.VisibleLoadPoints.FirstOrDefault(new Func<LoadPointDrawingData, bool>(#SUb2.#A5b));
		}

		// Token: 0x06002301 RID: 8961 RVA: 0x000CBE20 File Offset: 0x000CA020
		protected void #9bb(#Yjb #He)
		{
			EventHandler<#Yjb> eventHandler = this.#q;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x06002302 RID: 8962 RVA: 0x000CBE4C File Offset: 0x000CA04C
		protected void #acb()
		{
			EventHandler eventHandler = this.#r;
			if (eventHandler != null)
			{
				eventHandler(this, EventArgs.Empty);
			}
		}

		// Token: 0x06002303 RID: 8963 RVA: 0x000CBE7C File Offset: 0x000CA07C
		private void #bcb(object #Ge, SelectedValueChangedEventArgs<bool> #He)
		{
			try
			{
				#5re #5re = this.#a.#jJ();
				#5re.ShowGrid = #He.SelectedValue;
				this.#a.#iJ(#5re);
				this.#tcb();
			}
			catch (Exception #ob)
			{
				this.#d.#3Ab(#ob);
			}
		}

		// Token: 0x06002304 RID: 8964 RVA: 0x00021BEE File Offset: 0x0001FDEE
		private void #yh(object #Ge, KeyEventArgs #He)
		{
			if (#He.Key == Key.Escape)
			{
				this.#Wbb();
			}
		}

		// Token: 0x06002305 RID: 8965 RVA: 0x00021C0D File Offset: 0x0001FE0D
		private void #ccb(object #Ge, RadRoutedEventArgs #He)
		{
			this.#acb();
		}

		// Token: 0x06002306 RID: 8966 RVA: 0x00021C1D File Offset: 0x0001FE1D
		private void #dcb(object #Ge, EventArgs #He)
		{
			this.#c.ViewControlsPanelPosition = base.View.ViewControls.SelectedPosition;
		}

		// Token: 0x06002307 RID: 8967 RVA: 0x000CBEE0 File Offset: 0x000CA0E0
		private void #ecb(object #Ge, MouseButtonEventArgs #He)
		{
			if (this.#k == null || this.IsUserManupulatingDiagram)
			{
				return;
			}
			LoadPointDrawingData loadPointDrawingData = this.#8bb(#He);
			if (loadPointDrawingData != null)
			{
				this.#9bb(new #Yjb((double)loadPointDrawingData.MomentX, (double)loadPointDrawingData.MomentY, (double)loadPointDrawingData.AxialLoad, #He.ChangedButton, new int?(loadPointDrawingData.Index)));
			}
		}

		// Token: 0x06002308 RID: 8968 RVA: 0x000CBF48 File Offset: 0x000CA148
		private StructurePoint.CoreAssets.Infrastructure.Data.Point? #fcb(object #Ge, MouseEventArgs #He)
		{
			#QCe #QCe = this.#k;
			if (#QCe == null)
			{
				return null;
			}
			if (this.#g == null || this.#g.Model == null || this.#g.Parameter == null)
			{
				return null;
			}
			IInputElement inputElement = #Ge as IInputElement;
			if (inputElement == null)
			{
				return null;
			}
			System.Windows.Point position = #He.GetPosition(inputElement);
			StructurePoint.CoreAssets.Infrastructure.Data.Point #7qc = new StructurePoint.CoreAssets.Infrastructure.Data.Point(position.X, position.Y);
			return new StructurePoint.CoreAssets.Infrastructure.Data.Point?(#QCe.#PCe(#7qc));
		}

		// Token: 0x06002309 RID: 8969 RVA: 0x000CBFFC File Offset: 0x000CA1FC
		private void #gcb(object #Ge, MouseEventArgs #He)
		{
			try
			{
				if (!this.IsUserManupulatingDiagram)
				{
					this.#Bcb(this.#ocb(#He));
					StructurePoint.CoreAssets.Infrastructure.Data.Point? point = this.#fcb(#Ge, #He);
					if (point != null)
					{
						this.#sO(point.Value);
					}
				}
			}
			catch (Exception exception)
			{
				base.Logger.Log(LoggingLevel.Error, exception);
			}
		}

		// Token: 0x0600230A RID: 8970 RVA: 0x00021C46 File Offset: 0x0001FE46
		private void #hcb()
		{
			this.#g.#yl();
			this.#h.Clear();
			this.#i.Clear();
		}

		// Token: 0x0600230B RID: 8971 RVA: 0x000CC070 File Offset: 0x000CA270
		private bool #icb(#lte #Od, Diagram2DType #2bb, double #Sb, IList<SelectedLoadData> #Sd, bool #7bb)
		{
			Diagram2DViewModel.#yUb #yUb = new Diagram2DViewModel.#yUb();
			#yUb.#b = this;
			bool flag;
			if (this.#g.Diagram2DType != null)
			{
				Diagram2DType? diagram2DType = this.#g.Diagram2DType;
				flag = !(diagram2DType.GetValueOrDefault() == #2bb & diagram2DType != null);
			}
			else
			{
				flag = false;
			}
			bool flag2 = flag;
			if (#Od == null || !#Od.IsReportSourceValid || base.View.ActualWidth <= 0.0 || base.View.DiagramActualWidth <= 0.0)
			{
				this.#hcb();
				return true;
			}
			#5re #5re = this.#a.#jJ();
			#5re.ShowGrid = base.View.IsShowGridChecked;
			#8re filters = this.#pcb(#Od);
			#yUb.#a = new DrawnDiagramMetadata(#Od, #2bb, #Sb, #Sd, #5re, base.View.DiagramActualWidth, base.View.DiagramActualHeight, filters, this.SuperImposeContext.#Yfd());
			if (this.#o != null && this.#o.#e(#yUb.#a))
			{
				return true;
			}
			bool flag3 = this.#o != null && this.#o.#afb(#yUb.#a) && this.#p != null && (this.#jcb(this.#p.FactoredDiagram) || this.#jcb(this.#p.NominalDiagram));
			if (!flag3)
			{
				this.#hcb();
				this.#g.Diagram2DType = new Diagram2DType?(#2bb);
				this.#g.Parameter = new double?(#Sb);
				this.#g.Model = #Od;
				this.#g.LoadsToDraw.AddRange(#Sd);
				this.#g.Settings = #5re;
			}
			this.#o = #yUb.#a;
			base.Logger.Log(LoggingLevel.Debug, new Func<string>(#yUb.#H5b));
			bool flag4 = true;
			if (!flag3)
			{
				this.#p = new #LCe(#Od, #5re, #2bb, #Sb)
				{
					Filters = filters,
					ViewportWidth = base.View.DiagramActualWidth,
					ViewportHeight = base.View.DiagramActualHeight
				};
				this.#p.SelectedLoads.#pR(new ICollection<SelectedLoadData>[]
				{
					#Sd
				});
				if (#2bb == Diagram2DType.DiagramPM || #2bb == Diagram2DType.DiagramPMPlus || #2bb == Diagram2DType.DiagramPMMinus)
				{
					flag4 = this.#Dcb(this.#p, #Od.Input.Options.ConsideredAxis == ConsideredAxis.Both);
				}
				else
				{
					flag4 = this.#Fcb(this.#p);
				}
			}
			if (flag4)
			{
				#ZIe drawingStyle = new #ZIe(this.#p);
				#LCe #LCe = this.#p;
				#LCe #LCe2 = (#LCe != null) ? #LCe.#EA() : null;
				if (#LCe2 == null || #LCe2.FactoredDiagram == null || #LCe2.NominalDiagram == null)
				{
					return true;
				}
				if (#LCe2.FactoredDiagram.#ohe() && #LCe2.NominalDiagram.#ohe())
				{
					return true;
				}
				#UFe #UFe = new ColumnDiagramGenerator(this.SuperImposeContext, drawingStyle);
				this.#k = ((#Od.Input.Options.ConsideredAxis == ConsideredAxis.Both) ? #UFe.#rFe(#LCe2) : #UFe.#sFe(#LCe2));
			}
			if (flag4 && this.#k != null && this.#k.DrawingContent != null)
			{
				this.#h.AddRange(this.#k.VisibleLoadPoints);
				this.#h.Select(new Func<LoadPointDrawingData, int, <>f__AnonymousType5<int, int>>(Diagram2DViewModel.<>c.<>9.#5yf)).#I1d(new Action<<>f__AnonymousType5<int, int>>(#yUb.#I5b));
			}
			#QCe #Hvb = (!flag4 || this.#k == null || this.#k.DrawingContent == null) ? this.#Ccb() : this.#k;
			#Gvb parameters = new #Gvb(#Hvb, #5re, !flag2, #7bb);
			base.View.ShowDiagram(parameters, this.#c.Diagram2DCursorType);
			SolidColorBrush solidColorBrush = new SolidColorBrush(#5re.ScreenBackgroundColor);
			solidColorBrush.Freeze();
			this.Background = solidColorBrush;
			return false;
		}

		// Token: 0x0600230C RID: 8972 RVA: 0x00021C75 File Offset: 0x0001FE75
		private bool #jcb(#vCe #kcb)
		{
			return #kcb.UniCurve != null || #kcb.BiCurve != null;
		}

		// Token: 0x0600230D RID: 8973 RVA: 0x000CC474 File Offset: 0x000CA674
		private double #lcb(System.Windows.Point #mcb, System.Windows.Point #ncb)
		{
			double num = #ncb.Y - #mcb.Y;
			double num2 = #ncb.X - #mcb.X;
			return Math.Sqrt(num2 * num2 + num * num);
		}

		// Token: 0x0600230E RID: 8974 RVA: 0x000CC4BC File Offset: 0x000CA6BC
		private System.Windows.Point #ocb(MouseEventArgs #He)
		{
			Diagram2DView diagram2DView = (Diagram2DView)base.View;
			return #He.GetPosition(diagram2DView.Diagram2DControl.SvgViewBox.Child);
		}

		// Token: 0x0600230F RID: 8975 RVA: 0x000CC4F8 File Offset: 0x000CA6F8
		private LoadPointDrawingData #8bb(MouseEventArgs #He)
		{
			System.Windows.Point #0bb = this.#ocb(#He);
			return this.#8bb(#0bb);
		}

		// Token: 0x06002310 RID: 8976 RVA: 0x00021C96 File Offset: 0x0001FE96
		private #8re #pcb(#lte #Od)
		{
			return this.#a.#Hse(#Od);
		}

		// Token: 0x06002311 RID: 8977 RVA: 0x00021CB0 File Offset: 0x0001FEB0
		private void #qcb(object #Ge, EventArgs #He)
		{
			this.#tcb();
		}

		// Token: 0x06002312 RID: 8978 RVA: 0x000CC520 File Offset: 0x000CA720
		private void #rcb()
		{
			IObservable<SizeChangedEventArgs> source = Observable.FromEventPattern<SizeChangedEventArgs>(base.View, #Phc.#3hc(107363103)).Select(new Func<EventPattern<SizeChangedEventArgs>, SizeChangedEventArgs>(Diagram2DViewModel.<>c.<>9.#6yf)).Throttle(TimeSpan.FromMilliseconds(100.0));
			this.#m = source.ObserveOn(SynchronizationContext.Current).Subscribe(new Action<SizeChangedEventArgs>(this.#fwf));
		}

		// Token: 0x06002313 RID: 8979 RVA: 0x00021CB0 File Offset: 0x0001FEB0
		private void #scb()
		{
			this.#tcb();
		}

		// Token: 0x06002314 RID: 8980 RVA: 0x000CC5A8 File Offset: 0x000CA7A8
		private void #tcb()
		{
			Diagram2DType? diagram2DType = this.#g.Diagram2DType;
			double? num = this.#g.Parameter;
			if (diagram2DType != null && num != null && base.View.ActualWidth > 0.0)
			{
				List<SelectedLoadData> list = new List<SelectedLoadData>();
				list.AddRange(this.#g.LoadsToDraw);
				this.#6bb(this.#g.Model, diagram2DType.Value, num.Value, list, false);
			}
		}

		// Token: 0x06002315 RID: 8981 RVA: 0x000CC648 File Offset: 0x000CA848
		private void #sO(StructurePoint.CoreAssets.Infrastructure.Data.Point #ucb)
		{
			double valueOrDefault = this.#g.Parameter.GetValueOrDefault();
			UnitSystem unit = this.#g.Model.Input.Options.Unit;
			Diagram2DType? diagram2DType = this.#g.Diagram2DType;
			Diagram2DType diagram2DType2 = Diagram2DType.DiagramMM;
			double #7W;
			if (diagram2DType.GetValueOrDefault() == diagram2DType2 & diagram2DType != null)
			{
				#epb.#bpb(#ucb.X, valueOrDefault, unit, out #7W);
				double #9o;
				#epb.#bpb(#ucb.Y, valueOrDefault, unit, out #9o);
				this.#e.EditorStatusBar.DiagramMM.#enb(#ucb);
				this.#e.EditorStatusBar.DiagramMM.#fnb(#9o, #7W);
				return;
			}
			#epb.#bpb(#ucb.X, #ucb.Y, unit, out #7W);
			this.#e.EditorStatusBar.DiagramPM.#fnb(#7W);
			this.#e.EditorStatusBar.DiagramPM.#enb(#ucb);
		}

		// Token: 0x06002316 RID: 8982 RVA: 0x000CC75C File Offset: 0x000CA95C
		private List<Path> #vcb(LoadPointDrawingData #wcb)
		{
			Diagram2DViewModel.#Q5b #Q5b = new Diagram2DViewModel.#Q5b();
			#Q5b.#a = #wcb;
			List<Path> list = new List<Path>();
			if (#Q5b.#a == null)
			{
				return list;
			}
			List<LoadPointDrawingData> list2 = this.VisibleLoadPoints.Where(new Func<LoadPointDrawingData, bool>(#Q5b.#J5b)).ToList<LoadPointDrawingData>();
			foreach (LoadPointDrawingData loadPointDrawingData in list2)
			{
				Diagram2DViewModel.#azf #azf = new Diagram2DViewModel.#azf();
				#azf.#a = string.Format(CultureInfo.InvariantCulture, #Phc.#3hc(107362542), loadPointDrawingData.Index);
				list.AddRange(base.View.GetDrawnVisuals(#azf.#a).Select(new Func<KeyValuePair<string, object>, object>(Diagram2DViewModel.<>c.<>9.#7yf)).OfType<Path>());
				#azf.#a = #nFe.#lFe(loadPointDrawingData.Index);
				list.AddRange(base.View.GetDrawnVisuals(#azf.#a).Where(new Func<KeyValuePair<string, object>, bool>(#azf.#L5b)).Select(new Func<KeyValuePair<string, object>, object>(Diagram2DViewModel.<>c.<>9.#8yf)).OfType<Path>());
			}
			return list;
		}

		// Token: 0x06002317 RID: 8983 RVA: 0x000CC8D8 File Offset: 0x000CAAD8
		private void #xcb(LoadPointDrawingData #ycb, Color #zcb)
		{
			Diagram2DViewModel.#3Vb #3Vb = new Diagram2DViewModel.#3Vb();
			#3Vb.#a = #ycb;
			TextBlockMetadata #lub = (#3Vb.#a != null) ? base.View.DiagramPostprocessor.TextBlocks.FirstOrDefault(new Func<TextBlockMetadata, bool>(#3Vb.#N5b)) : null;
			base.View.DiagramPostprocessor.#xcb(#lub, #zcb);
		}

		// Token: 0x06002318 RID: 8984 RVA: 0x000CC940 File Offset: 0x000CAB40
		private IList<Ellipse> #Acb(LoadPointDrawingData #ycb)
		{
			Diagram2DViewModel.#kVb #kVb = new Diagram2DViewModel.#kVb();
			Diagram2DViewModel.#kVb #kVb2;
			if (2 != 0)
			{
				#kVb2 = #kVb;
			}
			List<Ellipse> list = new List<Ellipse>();
			if (#ycb == null)
			{
				return list;
			}
			#kVb2.#a = #nFe.#mFe(#ycb.Index);
			list.AddRange(base.View.DiagramPostprocessor.Ellipses.Where(new Func<EllipseMetadata, bool>(#kVb2.#P5b)).Select(new Func<EllipseMetadata, Ellipse>(Diagram2DViewModel.<>c.<>9.#9yf)));
			return list;
		}

		// Token: 0x06002319 RID: 8985 RVA: 0x000CC9CC File Offset: 0x000CABCC
		private void #Bcb(System.Windows.Point #ucb)
		{
			LoadPointDrawingData loadPointDrawingData = this.#8bb(#ucb);
			List<Path> #iub = this.#vcb(loadPointDrawingData);
			#5re #5re = this.#a.#jJ();
			base.View.DiagramPostprocessor.#hub(#iub, 2.0, 1.25, base.View.ZoomFactor, #5re.HoverLoadPointsColor);
			this.#xcb(loadPointDrawingData, #5re.HoverLoadPointsColor);
			IList<Ellipse> #nub = this.#Acb(loadPointDrawingData);
			base.View.DiagramPostprocessor.#mub(#nub, #5re.HoverLoadPointsColor);
		}

		// Token: 0x0600231A RID: 8986 RVA: 0x000CCA74 File Offset: 0x000CAC74
		private #QCe #Ccb()
		{
			SvgDocument #bFd = new SvgDocument
			{
				Width = 100f,
				Height = 100f
			};
			return new #QCe(new #tCe(#bFd, null), #uCe.#f, #Phc.#3hc(107362549));
		}

		// Token: 0x0600231B RID: 8987 RVA: 0x000CCACC File Offset: 0x000CACCC
		private bool #Dcb(#LCe #Pc, bool #Ecb)
		{
			DesignEngine designEngine = this.#f.DesignEngine;
			if (designEngine == null)
			{
				return false;
			}
			ReportDiagramsHandler reportDiagramsHandler = new ReportDiagramsHandler();
			if (!reportDiagramsHandler.#Dcb(designEngine, #Pc, #Ecb) || #Pc.NominalDiagram == null || #Pc.FactoredDiagram == null)
			{
				return false;
			}
			this.#g.Diagram2DPMNominal = #Pc.NominalDiagram.UniCurve;
			this.#g.Diagram2DPMFactored = #Pc.FactoredDiagram.UniCurve;
			return true;
		}

		// Token: 0x0600231C RID: 8988 RVA: 0x000CCB48 File Offset: 0x000CAD48
		private bool #Fcb(#LCe #Pc)
		{
			DesignEngine designEngine = this.#f.DesignEngine;
			DesignEngine designEngine2;
			if (!false)
			{
				designEngine2 = designEngine;
			}
			if (designEngine2 == null)
			{
				return false;
			}
			ReportDiagramsHandler reportDiagramsHandler = new ReportDiagramsHandler();
			if (!reportDiagramsHandler.#Fcb(designEngine2, #Pc) || #Pc.NominalDiagram == null || #Pc.FactoredDiagram == null)
			{
				return false;
			}
			this.#g.Diagram2DMMNominal = #Pc.NominalDiagram.BiCurve;
			this.#g.Diagram2DMMFactored = #Pc.FactoredDiagram.BiCurve;
			return true;
		}

		// Token: 0x0600231D RID: 8989 RVA: 0x00021CC0 File Offset: 0x0001FEC0
		[CompilerGenerated]
		private void #fwf(SizeChangedEventArgs #9o)
		{
			this.#scb();
		}

		// Token: 0x04000DFC RID: 3580
		private readonly #yse #a;

		// Token: 0x04000DFD RID: 3581
		private readonly #yBe #b;

		// Token: 0x04000DFE RID: 3582
		private readonly ISettingsManager #c;

		// Token: 0x04000DFF RID: 3583
		private readonly #tUd #d;

		// Token: 0x04000E00 RID: 3584
		private readonly #zU #e;

		// Token: 0x04000E01 RID: 3585
		private readonly #qW #f;

		// Token: 0x04000E02 RID: 3586
		private readonly #qCe #g = new #qCe();

		// Token: 0x04000E03 RID: 3587
		private readonly List<LoadPointDrawingData> #h = new List<LoadPointDrawingData>();

		// Token: 0x04000E04 RID: 3588
		private readonly Dictionary<int, int> #i = new Dictionary<int, int>();

		// Token: 0x04000E05 RID: 3589
		private readonly SemaphoreSlim #j = new SemaphoreSlim(1, 1);

		// Token: 0x04000E06 RID: 3590
		private #QCe #k;

		// Token: 0x04000E07 RID: 3591
		private SolidColorBrush #l;

		// Token: 0x04000E08 RID: 3592
		private IDisposable #m;

		// Token: 0x04000E09 RID: 3593
		private int #n;

		// Token: 0x04000E0A RID: 3594
		private DrawnDiagramMetadata #o;

		// Token: 0x04000E0B RID: 3595
		private #LCe #p;

		// Token: 0x04000E0C RID: 3596
		[CompilerGenerated]
		private EventHandler<#Yjb> #q;

		// Token: 0x04000E0D RID: 3597
		[CompilerGenerated]
		private EventHandler #r;

		// Token: 0x04000E0E RID: 3598
		[CompilerGenerated]
		private readonly #mAe #s;

		// Token: 0x020003F7 RID: 1015
		[CompilerGenerated]
		private sealed class #SUb
		{
			// Token: 0x06002327 RID: 8999 RVA: 0x00021D37 File Offset: 0x0001FF37
			internal <>f__AnonymousType4<PathMetadata, double> #y5b(PathMetadata #Rf)
			{
				return new
				{
					Item = #Rf,
					Distance = this.#a.#lcb(this.#b, #Rf.#Zub(#Rf.Center))
				};
			}

			// Token: 0x06002328 RID: 9000 RVA: 0x00021D68 File Offset: 0x0001FF68
			internal int #z5b(<>f__AnonymousType4<PathMetadata, double> #Rf)
			{
				return this.#a.#i.#F1d(#Rf.Item.LoadPointIndex);
			}

			// Token: 0x06002329 RID: 9001 RVA: 0x00021D91 File Offset: 0x0001FF91
			internal bool #A5b(LoadPointDrawingData #Rf)
			{
				return #Rf.Index == this.#c.Item.LoadPointIndex;
			}

			// Token: 0x04000E16 RID: 3606
			public Diagram2DViewModel #a;

			// Token: 0x04000E17 RID: 3607
			public System.Windows.Point #b;

			// Token: 0x04000E18 RID: 3608
			public <>f__AnonymousType4<PathMetadata, double> #c;
		}

		// Token: 0x020003F8 RID: 1016
		[CompilerGenerated]
		private sealed class #yUb
		{
			// Token: 0x0600232B RID: 9003 RVA: 0x00021DB7 File Offset: 0x0001FFB7
			internal string #H5b()
			{
				return #Phc.#3hc(107380641) + this.#a.ToString();
			}

			// Token: 0x0600232C RID: 9004 RVA: 0x00021DDF File Offset: 0x0001FFDF
			internal void #I5b(<>f__AnonymousType5<int, int> #Rf)
			{
				this.#b.#i[#Rf.LoadIndex] = #Rf.DrawnIndex;
			}

			// Token: 0x04000E19 RID: 3609
			public DrawnDiagramMetadata #a;

			// Token: 0x04000E1A RID: 3610
			public Diagram2DViewModel #b;
		}

		// Token: 0x020003F9 RID: 1017
		[CompilerGenerated]
		private sealed class #Q5b
		{
			// Token: 0x0600232E RID: 9006 RVA: 0x00021E09 File Offset: 0x00020009
			internal bool #J5b(LoadPointDrawingData #Rf)
			{
				return #Rf.#Bjb(this.#a);
			}

			// Token: 0x04000E1B RID: 3611
			public LoadPointDrawingData #a;
		}

		// Token: 0x020003FA RID: 1018
		[CompilerGenerated]
		private sealed class #azf
		{
			// Token: 0x06002330 RID: 9008 RVA: 0x00021E23 File Offset: 0x00020023
			internal bool #L5b(KeyValuePair<string, object> #Rf)
			{
				return string.Equals(#Rf.Key, this.#a, StringComparison.Ordinal);
			}

			// Token: 0x04000E1C RID: 3612
			public string #a;
		}

		// Token: 0x020003FB RID: 1019
		[CompilerGenerated]
		private sealed class #3Vb
		{
			// Token: 0x06002332 RID: 9010 RVA: 0x00021E44 File Offset: 0x00020044
			internal bool #N5b(TextBlockMetadata #Rf)
			{
				return #Rf.LabelType == LabelType.LoadPoint && #Rf.TextAsInteger == this.#a.Index;
			}

			// Token: 0x04000E1D RID: 3613
			public LoadPointDrawingData #a;
		}

		// Token: 0x020003FC RID: 1020
		[CompilerGenerated]
		private sealed class #kVb
		{
			// Token: 0x06002334 RID: 9012 RVA: 0x00021E70 File Offset: 0x00020070
			internal bool #P5b(EllipseMetadata #Rf)
			{
				return string.Equals(#Rf.Name, this.#a, StringComparison.Ordinal);
			}

			// Token: 0x04000E1E RID: 3614
			public string #a;
		}
	}
}
