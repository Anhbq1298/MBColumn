using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using #3Qb;
using #7hc;
using #8Cc;
using #eU;
using #ezc;
using #hg;
using #IDc;
using #LQc;
using #Oze;
using #RJb;
using #S9;
using #UYd;
using #xBe;
using #Xc;
using Ab3d.Utilities;
using devDept.Eyeshot;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Docking;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.Editor.Core;
using StructurePoint.Products.Column.FailureSurface.ViewModels;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Viewports.API;
using Telerik.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Docking;

namespace StructurePoint.Products.Column.Viewports
{
	// Token: 0x02000096 RID: 150
	internal class ViewportsManager : NotifyPropertyChangedObjectBase, INotifyPropertyChanged, #jg
	{
		// Token: 0x060004C3 RID: 1219 RVA: 0x00088A04 File Offset: 0x00086C04
		public ViewportsManager(#oW projectContext, #dLb editorContextMenu, ICoreServices services, #qW designEngineService, #yBe diagramExporter, #rW reportingApplicationContext, #tbb diagramsContext, #dU toolsContext, #mAe superImposeContext)
		{
			this.#w = services.UndoManager;
			if (projectContext == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107383985));
			}
			this.#x = projectContext;
			this.#y = services.Settings;
			this.#b = services.ErrorsHandler;
			if (editorContextMenu == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107383964));
			}
			this.#z = editorContextMenu;
			this.#c = services.DialogService;
			this.#d = services.Logger;
			this.#e = services;
			this.#f = designEngineService;
			this.#g = diagramExporter;
			this.#t = reportingApplicationContext;
			this.#h = diagramsContext;
			this.#i = toolsContext;
			this.#j = superImposeContext;
			this.#v = new ViewportsRenderer(this);
		}

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x060004C4 RID: 1220 RVA: 0x00088AD8 File Offset: 0x00086CD8
		// (remove) Token: 0x060004C5 RID: 1221 RVA: 0x00088B1C File Offset: 0x00086D1C
		public event EventHandler<#yd> ActiveViewportChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#yd> eventHandler = this.#o;
				EventHandler<#yd> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#yd> value2 = (EventHandler<#yd>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#yd>>(ref this.#o, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#yd> eventHandler = this.#o;
				EventHandler<#yd> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#yd> value2 = (EventHandler<#yd>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#yd>>(ref this.#o, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x060004C6 RID: 1222 RVA: 0x00088B60 File Offset: 0x00086D60
		// (remove) Token: 0x060004C7 RID: 1223 RVA: 0x00088BA4 File Offset: 0x00086DA4
		public event EventHandler<#yd> ActiveViewportChanging
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#yd> eventHandler = this.#p;
				EventHandler<#yd> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#yd> value2 = (EventHandler<#yd>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#yd>>(ref this.#p, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#yd> eventHandler = this.#p;
				EventHandler<#yd> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#yd> value2 = (EventHandler<#yd>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#yd>>(ref this.#p, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x060004C8 RID: 1224 RVA: 0x00088BE8 File Offset: 0x00086DE8
		// (remove) Token: 0x060004C9 RID: 1225 RVA: 0x00088C2C File Offset: 0x00086E2C
		public event EventHandler<#he> ViewportClosed
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#he> eventHandler = this.#q;
				EventHandler<#he> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#he> value2 = (EventHandler<#he>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#he>>(ref this.#q, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#he> eventHandler = this.#q;
				EventHandler<#he> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#he> value2 = (EventHandler<#he>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#he>>(ref this.#q, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x060004CA RID: 1226 RVA: 0x00088C70 File Offset: 0x00086E70
		// (remove) Token: 0x060004CB RID: 1227 RVA: 0x00088CB4 File Offset: 0x00086EB4
		public event EventHandler<#ie> ViewportCreated
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#ie> eventHandler = this.#r;
				EventHandler<#ie> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#ie> value2 = (EventHandler<#ie>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#ie>>(ref this.#r, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#ie> eventHandler = this.#r;
				EventHandler<#ie> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#ie> value2 = (EventHandler<#ie>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#ie>>(ref this.#r, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x060004CC RID: 1228 RVA: 0x00088CF8 File Offset: 0x00086EF8
		// (remove) Token: 0x060004CD RID: 1229 RVA: 0x00088D3C File Offset: 0x00086F3C
		public event EventHandler<#Me> ViewportOverlayCommandExecuted
		{
			[CompilerGenerated]
			add
			{
				EventHandler<#Me> eventHandler = this.#s;
				EventHandler<#Me> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#Me> value2 = (EventHandler<#Me>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#Me>>(ref this.#s, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<#Me> eventHandler = this.#s;
				EventHandler<#Me> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<#Me> value2 = (EventHandler<#Me>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<#Me>>(ref this.#s, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x060004CE RID: 1230 RVA: 0x00009A59 File Offset: 0x00007C59
		public #rW ReportingApplicationContext { get; }

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x060004CF RID: 1231 RVA: 0x00009A65 File Offset: 0x00007C65
		// (set) Token: 0x060004D0 RID: 1232 RVA: 0x00009A71 File Offset: 0x00007C71
		public #gg OverlayFactory { get; set; }

		// Token: 0x17000295 RID: 661
		// (get) Token: 0x060004D1 RID: 1233 RVA: 0x00009A82 File Offset: 0x00007C82
		public IReadOnlyList<IViewport> Viewports
		{
			get
			{
				return this.#k;
			}
		}

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x060004D2 RID: 1234 RVA: 0x00009A8E File Offset: 0x00007C8E
		public #Gd Renderer { get; }

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x060004D3 RID: 1235 RVA: 0x00009A9A File Offset: 0x00007C9A
		public #bDc UndoManager { get; }

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x060004D4 RID: 1236 RVA: 0x00009AA6 File Offset: 0x00007CA6
		public #oW ProjectContext { get; }

		// Token: 0x17000299 RID: 665
		// (get) Token: 0x060004D5 RID: 1237 RVA: 0x00009AB2 File Offset: 0x00007CB2
		public ISettingsManager SettingsManager { get; }

		// Token: 0x1700029A RID: 666
		// (get) Token: 0x060004D6 RID: 1238 RVA: 0x00009ABE File Offset: 0x00007CBE
		public #dLb EditorContextMenu { get; }

		// Token: 0x1700029B RID: 667
		// (get) Token: 0x060004D7 RID: 1239 RVA: 0x00009ACA File Offset: 0x00007CCA
		// (set) Token: 0x060004D8 RID: 1240 RVA: 0x00088D80 File Offset: 0x00086F80
		public RadDocking Docking
		{
			get
			{
				return this.#n;
			}
			set
			{
				if (this.#n != value)
				{
					this.#n = value;
					this.#n.ActivePaneChanged -= this.#Uf;
					this.#n.ActivePaneChanged += this.#Uf;
					this.#n.PaneStateChange -= this.#Sf;
					this.#n.PaneStateChange += this.#Sf;
				}
			}
		}

		// Token: 0x1700029C RID: 668
		// (get) Token: 0x060004D9 RID: 1241 RVA: 0x00009AD6 File Offset: 0x00007CD6
		public IModelEditorViewport ActiveEditor
		{
			get
			{
				return this.ActiveViewport as IModelEditorViewport;
			}
		}

		// Token: 0x1700029D RID: 669
		// (get) Token: 0x060004DA RID: 1242 RVA: 0x00009AEB File Offset: 0x00007CEB
		// (set) Token: 0x060004DB RID: 1243 RVA: 0x00088E08 File Offset: 0x00087008
		public IViewport ActiveViewport
		{
			get
			{
				return this.#l;
			}
			private set
			{
				if (this.#l != value)
				{
					IViewport #zd = this.#l;
					this.#If(new #yd(#zd, value));
					this.#l = value;
					this.#Zf(value);
					this.AnyPresenterIsActivated = (value != null);
					this.EditorContextMenu.DisableContextMenu();
					IModelEditorViewport modelEditorViewport = this.#l as IModelEditorViewport;
					if (modelEditorViewport != null)
					{
						this.EditorContextMenu.SetupContextMenu(modelEditorViewport.Editor);
					}
					this.#Hf(new #yd(#zd, value));
					base.RaisePropertyChanged(#Phc.#3hc(107383907));
				}
			}
		}

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x060004DC RID: 1244 RVA: 0x00009AF7 File Offset: 0x00007CF7
		// (set) Token: 0x060004DD RID: 1245 RVA: 0x00009B03 File Offset: 0x00007D03
		public bool AnyPresenterIsActivated
		{
			get
			{
				return this.#m;
			}
			private set
			{
				if (this.#m != value)
				{
					this.#m = value;
					base.RaisePropertyChanged(#Phc.#3hc(107383886));
				}
			}
		}

		// Token: 0x1700029F RID: 671
		// (get) Token: 0x060004DE RID: 1246 RVA: 0x00009B31 File Offset: 0x00007D31
		internal IEnumerable<IModelEditorViewport> EditorViewports
		{
			get
			{
				return this.#k.OfType<IModelEditorViewport>();
			}
		}

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x060004DF RID: 1247 RVA: 0x00009AD6 File Offset: 0x00007CD6
		internal IModelEditorViewport ActiveEditorViewport
		{
			get
			{
				return this.ActiveViewport as IModelEditorViewport;
			}
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x00009B46 File Offset: 0x00007D46
		public void #tf(RadPane #Le)
		{
			this.ActiveViewport = this.#Pf(#Le);
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x00088EB0 File Offset: 0x000870B0
		public void #uf(RadPane #Le)
		{
			IViewport viewport = this.#Pf(#Le);
			if (viewport != null)
			{
				this.#uf(viewport, true, null);
			}
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x00009B61 File Offset: 0x00007D61
		public void #vf()
		{
			IModelEditorViewport modelEditorViewport = this.ActiveEditor;
			if (modelEditorViewport == null)
			{
				return;
			}
			modelEditorViewport.Renderer.#cg();
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x00088EE0 File Offset: 0x000870E0
		public void #wf()
		{
			#qRb #qRb = this.#e.Settings.#ZN();
			foreach (IModelEditorViewport modelEditorViewport in this.EditorViewports)
			{
				modelEditorViewport.EditorContext.RenderOptions.ShowCover = #qRb.CoverVisibility;
			}
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x00088F5C File Offset: 0x0008715C
		public IViewport #xf(Action #yf)
		{
			ViewportsManager.#QTb #QTb = new ViewportsManager.#QTb();
			#QTb.#a = this;
			#QTb.#b = #yf;
			IViewport result;
			try
			{
				double num = 6.0;
				if ((double)this.#k.Count >= num)
				{
					Window #jA = this.#e.WindowLocator.#6();
					string #MQc = this.#e.ApplicationInfo.ApplicationName;
					string # = Strings.StringCannotAddMoreViewports.#z2d(true) + Strings.StringTheMaximalNumberOfViewportsIsX.#D2d(new object[]
					{
						num
					}).#z2d();
					this.#c.#2Sc(#jA, #MQc, #, MessageBoxButton.OK, MessageBoxImage.Asterisk);
					result = null;
				}
				else
				{
					#QTb.#c = (IModelEditorViewport)this.#Of(#pg.#a, null, null);
					IModelEditorViewport #Ic = this.ActiveEditor;
					this.#Hc(#Ic, #QTb.#c, null);
					if (this.#k.Count > 0)
					{
						#QTb.#c.Host.Container.InitialPosition = DockState.FloatingDockable;
						DockingHelper.SetFloatingSize(#QTb.#c.Host.Pane, ViewportsManager.#a);
						Window window = this.Docking.ParentOfType<Window>();
						DockingHelper.PositionFloatingInCenter(window, #QTb.#c.Host.Pane, ViewportsManager.#a);
					}
					this.#Qf(#QTb.#c.Host.Container);
					LayoutHelper.BeginInvokeOnApplicationThread(new Action(#QTb.#PTb));
					result = #QTb.#c;
				}
			}
			catch (Exception #ob)
			{
				this.#b.#bzc(Strings.StringAnUnknownErrorOccrued.#z2d(), #ob, new #3Hc(Strings.StringViewports));
				result = null;
			}
			return result;
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x0008913C File Offset: 0x0008733C
		public void #zf()
		{
			try
			{
				this.#Df(null);
				IViewport viewport = this.#Of(#pg.#a, null, null);
				viewport.Host.Pane.CanUserClose = false;
				viewport.Host.Pane.CanFloat = false;
				viewport.Host.Pane.CanUserPin = false;
				this.#Qf(viewport.Host.Container);
				this.#Zf(viewport);
				this.#Ef();
			}
			catch (Exception #ob)
			{
				this.#b.#bzc(Strings.StringAnUnknownErrorOccrued.#z2d(), #ob, new #3Hc(Strings.StringViewports));
			}
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x000891F4 File Offset: 0x000873F4
		public void #Af(Orientation #De, #qg? #Bf = null)
		{
			try
			{
				this.#0f(2, #De, #Bf);
			}
			catch (Exception #ob)
			{
				this.#b.#bzc(Strings.StringAnUnknownErrorOccrued.#z2d(), #ob, new #3Hc(Strings.StringViewports));
			}
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x0008924C File Offset: 0x0008744C
		public void #Cf()
		{
			try
			{
				this.#0f(4, Orientation.Horizontal, null);
			}
			catch (Exception #ob)
			{
				this.#b.#bzc(Strings.StringAnUnknownErrorOccrued.#z2d(), #ob, new #3Hc(Strings.StringViewports));
			}
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x000892AC File Offset: 0x000874AC
		public void #Df(#uzc #wzc = null)
		{
			this.#k.ForEach(new Action<IViewport>(ViewportsManager.<>c.<>9.#EWh));
			for (int i = this.Viewports.Count - 1; i >= 0; i--)
			{
				this.#uf(this.Viewports[i], false, #wzc);
			}
			LinesUpdater.Instance.Reset();
			if (#wzc != null)
			{
				#wzc.#szc(#Phc.#3hc(107383853));
			}
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x00009B84 File Offset: 0x00007D84
		public void #Ef()
		{
			this.#7f(this.Viewports);
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x0008933C File Offset: 0x0008753C
		public bool #Ff()
		{
			IModelEditorViewport modelEditorViewport = this.ActiveEditor;
			if (modelEditorViewport == null)
			{
				return false;
			}
			DynamicInputProvider dynamicInput = modelEditorViewport.Editor.DynamicInput;
			if (dynamicInput.Config.EnabledAndActive && !dynamicInput.Config.EnableDisplayOnly && modelEditorViewport.Editor.ActionMode == actionType.None)
			{
				dynamicInput.OpenInput();
				return true;
			}
			return false;
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x000893A0 File Offset: 0x000875A0
		public void #Gf()
		{
			foreach (IViewport viewport in this.Viewports.Where(new Func<IViewport, bool>(ViewportsManager.<>c.<>9.#RTb)))
			{
				IModelEditorViewport modelEditorViewport = viewport as IModelEditorViewport;
				if (modelEditorViewport != null)
				{
					modelEditorViewport.#Ed();
				}
				else
				{
					string value = viewport.ScopeSettings.ActiveScope.#7vb(viewport);
					if (!string.IsNullOrWhiteSpace(value))
					{
						viewport.Host.Header = value;
					}
				}
			}
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x00089460 File Offset: 0x00087660
		protected virtual void #Hf(#yd #He)
		{
			EventHandler<#yd> eventHandler = this.#o;
			if (eventHandler != null)
			{
				eventHandler(this, #He);
			}
			if (#He.NewViewport != null && #He.OldViewport != null)
			{
				this.#7f(new List<IViewport>
				{
					#He.OldViewport,
					#He.NewViewport
				});
			}
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x00009B9E File Offset: 0x00007D9E
		protected virtual void #If(#yd #He)
		{
			EventHandler<#yd> eventHandler = this.#p;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, #He);
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x00009BBE File Offset: 0x00007DBE
		protected virtual void #Jf(#he #He)
		{
			EventHandler<#he> eventHandler = this.#q;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, #He);
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x00009BDE File Offset: 0x00007DDE
		protected virtual void #Kf(#ie #He)
		{
			EventHandler<#ie> eventHandler = this.#r;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, #He);
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x00009BFE File Offset: 0x00007DFE
		protected virtual void #Lf(#Me #He)
		{
			EventHandler<#Me> eventHandler = this.#s;
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(this, #He);
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x000894C0 File Offset: 0x000876C0
		protected virtual void #Hc(#Fd #Ic, #Fd #G, #qg? #Jc = null)
		{
			if (#Ic != null && #G != null)
			{
				#G.ScopeSettings.#mg(#Ic.ScopeSettings);
				#G.EditorContext.RenderOptions.#mg(#Ic.EditorContext.RenderOptions);
				#G.EditorContext.ViewportOptions.#mg(#Ic.EditorContext.ViewportOptions);
				if (#Ic.ScopeSettings.ActiveScope != null)
				{
					#G.#Ed();
				}
			}
			if (#G != null && #Jc != null)
			{
				#qg? #qg = #Jc;
				#qg #qg2 = #qg.#a;
				if (!(#qg.GetValueOrDefault() == #qg2 & #qg != null) && #G.EditorContext.ViewportOptions.ActivateDiagramParameters == null)
				{
					#G.EditorContext.ViewportOptions.ActivateDiagramParameters = ActivateDiagramParameters.Diagram2DPM;
				}
			}
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x00089598 File Offset: 0x00087798
		protected void #uf(IViewport #fe, bool #Mf = true, #uzc #wzc = null)
		{
			ViewportsManager.#VTb #VTb = new ViewportsManager.#VTb();
			#VTb.#a = this;
			#VTb.#b = #fe;
			if (#VTb.#b == null)
			{
				return;
			}
			#VTb.#b.MarkedForClosing = true;
			Ignore.#14d<Exception>(new Action(#VTb.#b.#Ud), null);
			if (#wzc != null)
			{
				#wzc.#szc(#Phc.#3hc(107383816));
			}
			Ignore.#14d<Exception>(new Action(#VTb.#TTb), null);
			if (#wzc != null)
			{
				#wzc.#szc(#Phc.#3hc(107384311));
			}
			Ignore.#14d<Exception>(new Action(#VTb.#UTb), null);
			if (#wzc != null)
			{
				#wzc.#szc(#Phc.#3hc(107384238));
			}
			this.#k.Remove(#VTb.#b);
			#Ke #Ke = #VTb.#b.Host;
			if (((#Ke != null) ? #Ke.Overlay : null) != null)
			{
				#VTb.#b.Host.Overlay.CommandExecuted -= this.#Tf;
			}
			this.#Jf(new #he(#VTb.#b));
			if (#wzc != null)
			{
				#wzc.#szc(#Phc.#3hc(107384197));
			}
			if (this.ActiveViewport != null && !this.#k.Contains(this.ActiveViewport) && #Mf)
			{
				this.ActiveViewport = this.#k.FirstOrDefault<IViewport>();
				if (#wzc != null)
				{
					#wzc.#szc(#Phc.#3hc(107384188));
				}
			}
			this.#3f(false);
			if (#wzc != null)
			{
				#wzc.#szc(#Phc.#3hc(107384111));
			}
			if (this.#k.Count <= 0)
			{
				LinesUpdater.Instance.Reset();
				if (#wzc != null)
				{
					#wzc.#szc(#Phc.#3hc(107384066));
				}
			}
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x00089760 File Offset: 0x00087960
		protected void #Nf(#pg #C, IViewport #fe)
		{
			if (#C == #pg.#a)
			{
				return;
			}
			if (#C == #pg.#b)
			{
				#fe.Host.Pane.CanUserClose = false;
				#fe.Host.Pane.CanFloat = false;
				#fe.Host.Pane.CanUserPin = false;
				#fe.Host.Pane.ContextMenuTemplate = null;
				return;
			}
			throw new ArgumentOutOfRangeException(#Phc.#3hc(107383497), #C, null);
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x000897DC File Offset: 0x000879DC
		protected IViewport #Of(#pg #C, #Ke #Qc = null, #qg? #Jc = null)
		{
			CustomRadPaneGroup customRadPaneGroup = new CustomRadPaneGroup();
			CustomRadPaneGroup #Ce;
			if (!false)
			{
				#Ce = customRadPaneGroup;
			}
			RadSplitContainer #5d = (#Qc != null) ? #Qc.Container : new RadSplitContainer();
			#Ke #Ke = #Ke.#ye(this.OverlayFactory, Strings.StringSection);
			#Ke.#Be(#5d, #Ce, Orientation.Horizontal);
			IViewport viewport = this.#6f(#C, #Jc);
			viewport.Host = #Ke;
			this.#k.Add(viewport);
			#Ke.#od(viewport.View);
			if (#Ke.Overlay != null)
			{
				#Ke.Overlay.CommandExecuted += this.#Tf;
			}
			#Ke.Header = Strings.StringSection.#O2d();
			this.#Nf(#C, viewport);
			this.#Kf(new #ie(viewport));
			return viewport;
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x000898A8 File Offset: 0x00087AA8
		protected IViewport #Pf(RadPane #Le)
		{
			ViewportsManager.#XTb #XTb = new ViewportsManager.#XTb();
			#XTb.#a = #Le;
			return this.#k.FirstOrDefault(new Func<IViewport, bool>(#XTb.#WTb));
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x00009C1E File Offset: 0x00007E1E
		protected void #Qf(object #Rf)
		{
			if (!this.Docking.Items.Contains(#Rf))
			{
				this.Docking.Items.Add(#Rf);
			}
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x00009C51 File Offset: 0x00007E51
		private void #Sf(object #Ge, RadRoutedEventArgs #He)
		{
			this.#3f(true);
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x000898E8 File Offset: 0x00087AE8
		private void #Tf(object #Ge, EventArgs #He)
		{
			ViewportsManager.#ZTb #ZTb = new ViewportsManager.#ZTb();
			#ZTb.#a = #Ge;
			IModelEditorViewport modelEditorViewport = this.EditorViewports.FirstOrDefault(new Func<IModelEditorViewport, bool>(#ZTb.#YTb));
			if (modelEditorViewport != null)
			{
				this.#Lf(new #Me(modelEditorViewport));
			}
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x00089938 File Offset: 0x00087B38
		private void #Uf(object #Ge, ActivePangeChangedEventArgs #He)
		{
			if (#He.NewPane == null)
			{
				return;
			}
			IViewport viewport = this.#Pf(#He.NewPane);
			IModelEditorViewport modelEditorViewport = viewport as IModelEditorViewport;
			if (modelEditorViewport != null && #He.NewPane.IsFloating)
			{
				modelEditorViewport.Editor.IgnoreNextMouseDown = true;
				modelEditorViewport.Editor.IgnoreNextMouseDownTimestamp = DateTime.UtcNow;
			}
			if (viewport != this.ActiveViewport)
			{
				this.#tf(#He.NewPane);
				return;
			}
			this.#Yf(viewport);
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x000899BC File Offset: 0x00087BBC
		private void #Vf(IList<IViewport> #Wf = null, Action #yf = null, bool #Xf = false)
		{
			ViewportsManager.#1Tb #1Tb = new ViewportsManager.#1Tb();
			#1Tb.#a = #Wf;
			#1Tb.#b = this;
			#1Tb.#c = #Xf;
			#1Tb.#d = #yf;
			#1Tb.#a = (#1Tb.#a ?? this.#k);
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(#1Tb.#0Tb));
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x00089A20 File Offset: 0x00087C20
		private void #Yf(IViewport #fe)
		{
			ViewportsManager.#3Tb #3Tb = new ViewportsManager.#3Tb();
			ViewportsManager.#3Tb #3Tb2 = #3Tb;
			RadPane activePane = this.Docking.ActivePane;
			#3Tb2.#b = (((activePane != null) ? new bool?(activePane.IsFloating) : null).GetValueOrDefault() && ((#fe != null) ? new bool?(#fe.Host.Pane.IsFloating) : null).GetValueOrDefault());
			#3Tb.#a = (#fe as #Fd);
			if (#3Tb.#a != null && #3Tb.#a.EditorContext.ViewportOptions.PresenterType == #qg.#a)
			{
				#3Tb.#a.Editor.SetFocus(null);
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(#3Tb.#2Tb));
			}
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x00089B04 File Offset: 0x00087D04
		private void #Zf(IViewport #fe)
		{
			foreach (IViewport viewport in this.#k)
			{
				viewport.IsActive = false;
			}
			if (#fe != null)
			{
				#fe.IsActive = true;
				#fe.Host.Pane.IsActive = true;
			}
			this.#Yf(#fe);
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x00089B88 File Offset: 0x00087D88
		private void #0f(int #1f, Orientation #2f, #qg? #Jc)
		{
			ViewportsManager.#6Tb #6Tb = new ViewportsManager.#6Tb();
			#6Tb.#b = this;
			#6Tb.#c = this.ActiveViewport;
			List<IViewport> list = this.#k.OrderByDescending(new Func<IViewport, bool>(ViewportsManager.<>c.<>9.#STb)).ToList<IViewport>();
			while (list.Count > #1f)
			{
				IViewport viewport = list.Last<IViewport>();
				this.#uf(viewport, true, null);
				list.Remove(viewport);
			}
			List<IViewport> list2 = new List<IViewport>();
			while (this.#k.Count < #1f)
			{
				IModelEditorViewport modelEditorViewport = (IModelEditorViewport)this.#Of(#pg.#a, null, #Jc);
				this.#Hc(this.ActiveEditor, modelEditorViewport, #Jc);
				if (#Jc != null)
				{
					modelEditorViewport.EditorContext.ViewportOptions.PresenterType = #Jc.Value;
				}
				list2.Add(modelEditorViewport);
			}
			foreach (IViewport #fe in this.#k)
			{
				this.#5f(#fe);
			}
			List<RadSplitContainer> list3 = new List<RadSplitContainer>();
			for (int i = 0; i < #1f / 2; i++)
			{
				RadSplitContainer radSplitContainer = new RadSplitContainer();
				list3.Add(radSplitContainer);
				for (int j = 0; j < 2; j++)
				{
					int index = i * 2 + j;
					IViewport viewport2 = this.#k[index];
					viewport2.Host.#Be(radSplitContainer, new CustomRadPaneGroup(), #2f);
				}
			}
			#6Tb.#a = new RadSplitContainer
			{
				Orientation = Orientation.Vertical
			};
			list3.ForEach(new Action<RadSplitContainer>(#6Tb.#4Tb));
			this.#Qf(#6Tb.#a);
			this.#Vf(list2, null, false);
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(#6Tb.#5Tb));
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x00089D78 File Offset: 0x00087F78
		private void #3f(bool #4f = false)
		{
			foreach (IModelEditorViewport modelEditorViewport in this.EditorViewports)
			{
				modelEditorViewport.Editor.EmptyTextureCache();
				if (#4f)
				{
					modelEditorViewport.Editor.Invalidate();
				}
			}
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x00089DE4 File Offset: 0x00087FE4
		private void #5f(IViewport #fe)
		{
			#Ke #Ke = #fe.Host;
			#Ke #Ke2;
			if (!false)
			{
				#Ke2 = #Ke;
			}
			FrameworkElement frameworkElement = #Ke2.Pane;
			RadPaneGroup radPaneGroup = frameworkElement.ParentOfType<RadPaneGroup>();
			RadSplitContainer radSplitContainer = (radPaneGroup != null) ? null : frameworkElement.ParentOfType<RadSplitContainer>();
			#Ke2.Pane.RemoveFromParent();
			while (radPaneGroup != null || radSplitContainer != null)
			{
				if (radPaneGroup != null)
				{
					radPaneGroup.Items.Remove(frameworkElement);
					frameworkElement = radPaneGroup;
				}
				if (radSplitContainer != null)
				{
					radSplitContainer.Items.Remove(frameworkElement);
					frameworkElement = radSplitContainer;
				}
				radPaneGroup = frameworkElement.ParentOfType<RadPaneGroup>();
				radSplitContainer = ((radPaneGroup != null) ? null : frameworkElement.ParentOfType<RadSplitContainer>());
			}
			#Ke2.PaneGroup.Items.Remove(#Ke2.Pane);
			if (#Ke2.PaneGroup.Items.Count <= 0)
			{
				#Ke2.Container.Items.Remove(#Ke2.PaneGroup);
			}
			if (#Ke2.Container.Items.Count <= 0)
			{
				this.Docking.Items.Remove(#Ke2.Container);
			}
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x00089EE4 File Offset: 0x000880E4
		private IViewport #6f(#pg #C, #qg? #Jc)
		{
			if (#C == #pg.#a)
			{
				ModelEditorViewport modelEditorViewport = new ModelEditorViewport(this.ProjectContext, this.#e, this.#f, this.#g, this.#h, this.#i, this.#j);
				if (#Jc != null)
				{
					modelEditorViewport.EditorContext.ViewportOptions.PresenterType = #Jc.Value;
				}
				return modelEditorViewport;
			}
			throw new ArgumentOutOfRangeException(#Phc.#3hc(107383497), #C, null);
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x00089F68 File Offset: 0x00088168
		private void #7f(IEnumerable<IViewport> #8f)
		{
			ViewControlsSettings viewControlsSettings = this.SettingsManager.ViewControlSettings;
			using (IEnumerator<IViewport> enumerator = #8f.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ViewportsManager.#aUb #aUb = new ViewportsManager.#aUb();
					#aUb.#a = enumerator.Current;
					#aUb.#b = (#aUb.#a as #Fd);
					if (#aUb.#b != null && #aUb.#b.Editor != null && #aUb.#b.Editor.IsVisible)
					{
						ViewportsManager.#eUb #eUb = new ViewportsManager.#eUb();
						#eUb.#f = #aUb;
						#eUb.#d = (#eUb.#f.#a.IsActive && viewControlsSettings.IsViewCubeVisible);
						#eUb.#b = viewControlsSettings.IsCoordinateSignVisible;
						bool flag = false;
						#eUb.#a = #eUb.#f.#b.Editor.ActiveViewport.CoordinateSystemIcon;
						if (#eUb.#a != null && #eUb.#a.Visible != #eUb.#b)
						{
							flag = true;
							Ignore.#14d<Exception>(new Action(#eUb.#bUb), null);
						}
						#eUb.#c = #eUb.#f.#b.Editor.DefaultViewport.ViewCubeIcon;
						if (#eUb.#c != null && #eUb.#c.Visible != #eUb.#d)
						{
							flag = true;
							Ignore.#14d<Exception>(new Action(#eUb.#cUb), null);
						}
						ViewportsManager.#eUb #eUb2 = #eUb;
						ColumnEditor columnEditor = #eUb.#f.#b.Editor;
						devDept.Eyeshot.ToolBar toolBar;
						if (columnEditor == null)
						{
							toolBar = null;
						}
						else
						{
							Viewport defaultViewport = columnEditor.DefaultViewport;
							toolBar = ((defaultViewport != null) ? defaultViewport.ToolBar : null);
						}
						#eUb2.#e = toolBar;
						if (#eUb.#e != null && #eUb.#e.Visible != #eUb.#f.#a.IsActive)
						{
							flag = true;
							Ignore.#14d<Exception>(new Action(#eUb.#dUb), this.#d);
						}
						if (flag)
						{
							Ignore.#14d<Exception>(new Action(#eUb.#f.#7Tb), null);
							Ignore.#14d<Exception>(new Action(#eUb.#f.#8Tb), null);
						}
						Ignore.#14d<Exception>(new Action(#eUb.#f.#9Tb), null);
					}
				}
			}
		}

		// Token: 0x040000E4 RID: 228
		public static readonly Size #a = new Size(800.0, 600.0);

		// Token: 0x040000E5 RID: 229
		private readonly #rBc #b;

		// Token: 0x040000E6 RID: 230
		private readonly #8Sc #c;

		// Token: 0x040000E7 RID: 231
		private readonly ILogger #d;

		// Token: 0x040000E8 RID: 232
		private readonly ICoreServices #e;

		// Token: 0x040000E9 RID: 233
		private readonly #qW #f;

		// Token: 0x040000EA RID: 234
		private readonly #yBe #g;

		// Token: 0x040000EB RID: 235
		private readonly #tbb #h;

		// Token: 0x040000EC RID: 236
		private readonly #dU #i;

		// Token: 0x040000ED RID: 237
		private readonly #mAe #j;

		// Token: 0x040000EE RID: 238
		private readonly List<IViewport> #k = new List<IViewport>();

		// Token: 0x040000EF RID: 239
		private IViewport #l;

		// Token: 0x040000F0 RID: 240
		private bool #m;

		// Token: 0x040000F1 RID: 241
		private RadDocking #n;

		// Token: 0x040000F2 RID: 242
		[CompilerGenerated]
		private EventHandler<#yd> #o;

		// Token: 0x040000F3 RID: 243
		[CompilerGenerated]
		private EventHandler<#yd> #p;

		// Token: 0x040000F4 RID: 244
		[CompilerGenerated]
		private EventHandler<#he> #q;

		// Token: 0x040000F5 RID: 245
		[CompilerGenerated]
		private EventHandler<#ie> #r;

		// Token: 0x040000F6 RID: 246
		[CompilerGenerated]
		private EventHandler<#Me> #s;

		// Token: 0x040000F7 RID: 247
		[CompilerGenerated]
		private readonly #rW #t;

		// Token: 0x040000F8 RID: 248
		[CompilerGenerated]
		private #gg #u;

		// Token: 0x040000F9 RID: 249
		[CompilerGenerated]
		private readonly #Gd #v;

		// Token: 0x040000FA RID: 250
		[CompilerGenerated]
		private readonly #bDc #w;

		// Token: 0x040000FB RID: 251
		[CompilerGenerated]
		private readonly #oW #x;

		// Token: 0x040000FC RID: 252
		[CompilerGenerated]
		private readonly ISettingsManager #y;

		// Token: 0x040000FD RID: 253
		[CompilerGenerated]
		private readonly #dLb #z;

		// Token: 0x02000098 RID: 152
		[CompilerGenerated]
		private sealed class #aUb
		{
			// Token: 0x06000509 RID: 1289 RVA: 0x00009CD4 File Offset: 0x00007ED4
			internal void #7Tb()
			{
				this.#b.Editor.CompileUserInterfaceElements();
			}

			// Token: 0x0600050A RID: 1290 RVA: 0x00009CF2 File Offset: 0x00007EF2
			internal void #8Tb()
			{
				this.#b.Editor.Invalidate();
			}

			// Token: 0x0600050B RID: 1291 RVA: 0x00009D10 File Offset: 0x00007F10
			internal void #9Tb()
			{
				this.#b.Editor.InvalidateCursor();
			}

			// Token: 0x04000102 RID: 258
			public IViewport #a;

			// Token: 0x04000103 RID: 259
			public #Fd #b;
		}

		// Token: 0x02000099 RID: 153
		[CompilerGenerated]
		private sealed class #eUb
		{
			// Token: 0x0600050D RID: 1293 RVA: 0x00009D2E File Offset: 0x00007F2E
			internal void #bUb()
			{
				this.#a.Visible = this.#b;
			}

			// Token: 0x0600050E RID: 1294 RVA: 0x00009D4D File Offset: 0x00007F4D
			internal void #cUb()
			{
				this.#c.Visible = this.#d;
			}

			// Token: 0x0600050F RID: 1295 RVA: 0x00009D6C File Offset: 0x00007F6C
			internal void #dUb()
			{
				this.#e.Visible = this.#f.#a.IsActive;
			}

			// Token: 0x04000104 RID: 260
			public CoordinateSystemIcon #a;

			// Token: 0x04000105 RID: 261
			public bool #b;

			// Token: 0x04000106 RID: 262
			public ViewCubeIcon #c;

			// Token: 0x04000107 RID: 263
			public bool #d;

			// Token: 0x04000108 RID: 264
			public devDept.Eyeshot.ToolBar #e;

			// Token: 0x04000109 RID: 265
			public ViewportsManager.#aUb #f;
		}

		// Token: 0x0200009A RID: 154
		[CompilerGenerated]
		private sealed class #QTb
		{
			// Token: 0x06000511 RID: 1297 RVA: 0x0008A1CC File Offset: 0x000883CC
			internal void #PTb()
			{
				this.#a.#Vf(new List<IViewport>
				{
					this.#c
				}, this.#b, true);
				this.#a.#Zf(this.#c);
				this.#a.#7f(this.#a.Viewports);
				Action action = this.#b;
				if (action == null)
				{
					return;
				}
				action();
			}

			// Token: 0x0400010A RID: 266
			public ViewportsManager #a;

			// Token: 0x0400010B RID: 267
			public Action #b;

			// Token: 0x0400010C RID: 268
			public IModelEditorViewport #c;
		}

		// Token: 0x0200009B RID: 155
		[CompilerGenerated]
		private sealed class #VTb
		{
			// Token: 0x06000513 RID: 1299 RVA: 0x00009D95 File Offset: 0x00007F95
			internal void #TTb()
			{
				this.#a.#5f(this.#b);
			}

			// Token: 0x06000514 RID: 1300 RVA: 0x00009DB4 File Offset: 0x00007FB4
			internal void #UTb()
			{
				this.#b.Host.Pane.Content = null;
			}

			// Token: 0x0400010D RID: 269
			public ViewportsManager #a;

			// Token: 0x0400010E RID: 270
			public IViewport #b;
		}

		// Token: 0x0200009C RID: 156
		[CompilerGenerated]
		private sealed class #XTb
		{
			// Token: 0x06000516 RID: 1302 RVA: 0x00009DD8 File Offset: 0x00007FD8
			internal bool #WTb(IViewport #Rf)
			{
				return object.Equals(#Rf.Host.Pane, this.#a);
			}

			// Token: 0x0400010F RID: 271
			public RadPane #a;
		}

		// Token: 0x0200009D RID: 157
		[CompilerGenerated]
		private sealed class #ZTb
		{
			// Token: 0x06000518 RID: 1304 RVA: 0x00009DFC File Offset: 0x00007FFC
			internal bool #YTb(IModelEditorViewport #Rf)
			{
				return #Rf.Host.Overlay == this.#a;
			}

			// Token: 0x04000110 RID: 272
			public object #a;
		}

		// Token: 0x0200009E RID: 158
		[CompilerGenerated]
		private sealed class #1Tb
		{
			// Token: 0x0600051A RID: 1306 RVA: 0x0008A240 File Offset: 0x00088440
			internal void #0Tb()
			{
				foreach (IModelEditorViewport modelEditorViewport in this.#a.OfType<IModelEditorViewport>())
				{
					if (modelEditorViewport.EditorContext.ViewportOptions.PresenterType == #qg.#a)
					{
						modelEditorViewport.Renderer.#9f(false, false);
					}
					else
					{
						modelEditorViewport.#Nd(this.#b.ReportingApplicationContext.Model);
						modelEditorViewport.#Pd(modelEditorViewport.EditorContext.ViewportOptions.ActivateDiagramParameters, this.#c, this.#b.#h.SelectedLoads);
					}
					Action action = this.#d;
					if (action != null)
					{
						action();
					}
				}
			}

			// Token: 0x04000111 RID: 273
			public IList<IViewport> #a;

			// Token: 0x04000112 RID: 274
			public ViewportsManager #b;

			// Token: 0x04000113 RID: 275
			public bool #c;

			// Token: 0x04000114 RID: 276
			public Action #d;
		}

		// Token: 0x0200009F RID: 159
		[CompilerGenerated]
		private sealed class #3Tb
		{
			// Token: 0x0600051C RID: 1308 RVA: 0x0008A320 File Offset: 0x00088520
			internal void #2Tb()
			{
				ColumnEditor columnEditor = this.#a.Editor;
				actionType actionMode = columnEditor.ActionMode;
				if (actionMode != actionType.None)
				{
					columnEditor.ActionMode = actionType.None;
					columnEditor.ActionMode = actionMode;
				}
				if (!this.#b)
				{
					columnEditor.SetFocusExt();
				}
			}

			// Token: 0x04000115 RID: 277
			public #Fd #a;

			// Token: 0x04000116 RID: 278
			public bool #b;
		}

		// Token: 0x020000A0 RID: 160
		[CompilerGenerated]
		private sealed class #6Tb
		{
			// Token: 0x0600051E RID: 1310 RVA: 0x00009E1D File Offset: 0x0000801D
			internal void #4Tb(RadSplitContainer #Rf)
			{
				this.#a.Items.Add(#Rf);
			}

			// Token: 0x0600051F RID: 1311 RVA: 0x0008A36C File Offset: 0x0008856C
			internal void #5Tb()
			{
				IViewport viewport = this.#b.#k.Contains(this.#c) ? this.#c : this.#b.#k.First<IViewport>();
				this.#b.#3f(false);
				if (viewport != this.#b.ActiveViewport)
				{
					this.#b.#Zf(viewport);
				}
				this.#b.#7f(this.#b.#k);
			}

			// Token: 0x04000117 RID: 279
			public RadSplitContainer #a;

			// Token: 0x04000118 RID: 280
			public ViewportsManager #b;

			// Token: 0x04000119 RID: 281
			public IViewport #c;
		}
	}
}
