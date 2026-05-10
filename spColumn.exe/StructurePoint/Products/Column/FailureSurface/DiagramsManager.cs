using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using #12e;
using #5Ve;
using #6re;
using #7hc;
using #APb;
using #bnb;
using #eU;
using #hg;
using #hZe;
using #Mbb;
using #nib;
using #npe;
using #o1d;
using #qJ;
using #RJb;
using #S9;
using #Wse;
using #Xc;
using #Zjb;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.DTO;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;
using StructurePoint.Products.Column.Editor.Diagrams;
using StructurePoint.Products.Column.FailureSurface.ViewModels;
using StructurePoint.Products.Column.FailureSurface.ViewModels.DTO;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Viewports.API;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.FailureSurface
{
	// Token: 0x020003CA RID: 970
	internal sealed class DiagramsManager : NotifyPropertyChangedObjectBase, #vbb
	{
		// Token: 0x060021A8 RID: 8616 RVA: 0x000C80C8 File Offset: 0x000C62C8
		public DiagramsManager(IExtendedServices services, #tbb context, #mib leftPanel, #0gb loadPointDetails, #zJ availabilityChecker, #qW designEngineService)
		{
			this.#k = leftPanel;
			this.#l = context;
			this.#a = services;
			this.#b = loadPointDetails;
			this.#c = availabilityChecker;
			this.#d = designEngineService;
			this.#e = services.DiagramsViewportsManager;
			#wU #wU = services.Commands;
			#wU.ActivateDiagramWithParameters.SetCommand(new Action<object>(this.#Sab));
			this.#e.ActiveViewportChanged += this.#nab;
			this.#e.ViewportClosed += this.#kab;
			this.#e.ViewportCreated += this.#bbb;
			this.#a.MessageBus.SettingsChanged += this.#Ah;
			this.#a.MessageBus.DisplayOptionsChanged += this.#Bh;
			this.#m = new DelegateCommand(new Action<object>(this.#Oab), new Predicate<object>(this.#Pab));
			this.#o = new DelegateCommand(new Action<object>(this.#Mab), new Predicate<object>(this.#Nab));
			this.#n = new DelegateCommand(new Action<object>(this.#Kab), new Predicate<object>(this.#Lab));
			this.#s = new DelegateCommand(new Action<object>(this.#Eab), new Predicate<object>(this.#Fab));
			this.#r = new DelegateCommand(new Action<object>(this.#Cab), new Predicate<object>(this.#Dab));
			this.#q = new DelegateCommand(new Action<object>(this.#Aab), new Predicate<object>(this.#Bab));
			this.#p = new DelegateCommand(new Action<object>(this.#yab), new Predicate<object>(this.#zab));
			this.#u = new DelegateCommand(new Action<object>(this.#Iab), new Predicate<object>(this.#Jab));
			this.#t = new DelegateCommand(new Action<object>(this.#Gab), new Predicate<object>(this.#Hab));
			availabilityChecker.StateChanged += this.#iab;
			services.MessageBus.DesignTraceStateChanged += this.#hab;
			services.Project.ModelChanged += this.#cl;
			this.#kbb();
		}

		// Token: 0x17000BCC RID: 3020
		// (get) Token: 0x060021A9 RID: 8617 RVA: 0x00020D7A File Offset: 0x0001EF7A
		// (set) Token: 0x060021AA RID: 8618 RVA: 0x00020D86 File Offset: 0x0001EF86
		public #BLb ScopesManager
		{
			get
			{
				return this.#j;
			}
			set
			{
				this.#j = value;
				if (value != null)
				{
					value.ActiveScopeChanged += this.#mab;
				}
			}
		}

		// Token: 0x17000BCD RID: 3021
		// (get) Token: 0x060021AB RID: 8619 RVA: 0x00020DB0 File Offset: 0x0001EFB0
		public #mib LeftPanel { get; }

		// Token: 0x17000BCE RID: 3022
		// (get) Token: 0x060021AC RID: 8620 RVA: 0x000C8348 File Offset: 0x000C6548
		// (set) Token: 0x060021AD RID: 8621 RVA: 0x000C839C File Offset: 0x000C659C
		public bool IsDiagram3DHorizontalCutActive
		{
			get
			{
				IModelEditorViewport modelEditorViewport = this.ActivePresenter;
				bool? flag;
				if (modelEditorViewport == null)
				{
					flag = null;
				}
				else
				{
					IDiagramPresenterViewModel diagramPresenterViewModel = modelEditorViewport.DiagramPresenter;
					flag = ((diagramPresenterViewModel != null) ? new bool?(diagramPresenterViewModel.Diagram3DIsHorizontalCutEnabled) : null);
				}
				bool? flag2 = flag;
				return flag2.GetValueOrDefault();
			}
			set
			{
				IModelEditorViewport modelEditorViewport = this.ActivePresenter;
				IDiagramPresenterViewModel diagramPresenterViewModel = (modelEditorViewport != null) ? modelEditorViewport.DiagramPresenter : null;
				if (diagramPresenterViewModel != null)
				{
					diagramPresenterViewModel.Diagram3DIsHorizontalCutEnabled = value;
				}
				this.#gab();
				base.RaisePropertyChanged(#Phc.#3hc(107363516));
			}
		}

		// Token: 0x17000BCF RID: 3023
		// (get) Token: 0x060021AE RID: 8622 RVA: 0x000C83E8 File Offset: 0x000C65E8
		// (set) Token: 0x060021AF RID: 8623 RVA: 0x000C843C File Offset: 0x000C663C
		public bool Diagram3DIsVerticalCutActive
		{
			get
			{
				IModelEditorViewport modelEditorViewport = this.ActivePresenter;
				bool? flag;
				if (modelEditorViewport == null)
				{
					flag = null;
				}
				else
				{
					IDiagramPresenterViewModel diagramPresenterViewModel = modelEditorViewport.DiagramPresenter;
					flag = ((diagramPresenterViewModel != null) ? new bool?(diagramPresenterViewModel.Diagram3DIsVerticalCutEnabled) : null);
				}
				bool? flag2 = flag;
				return flag2.GetValueOrDefault();
			}
			set
			{
				IModelEditorViewport modelEditorViewport = this.ActivePresenter;
				IDiagramPresenterViewModel diagramPresenterViewModel = (modelEditorViewport != null) ? modelEditorViewport.DiagramPresenter : null;
				if (diagramPresenterViewModel != null)
				{
					diagramPresenterViewModel.Diagram3DIsVerticalCutEnabled = value;
				}
				this.#gab();
				base.RaisePropertyChanged(#Phc.#3hc(107363475));
			}
		}

		// Token: 0x17000BD0 RID: 3024
		// (get) Token: 0x060021B0 RID: 8624 RVA: 0x000C8488 File Offset: 0x000C6688
		public bool Diagram3DEnableCutOnValueChange
		{
			get
			{
				IModelEditorViewport modelEditorViewport = this.ActivePresenter;
				bool? flag;
				if (modelEditorViewport == null)
				{
					flag = null;
				}
				else
				{
					IDiagramPresenterViewModel diagramPresenterViewModel = modelEditorViewport.DiagramPresenter;
					flag = ((diagramPresenterViewModel != null) ? new bool?(diagramPresenterViewModel.Diagram3DEnableCutOnValueChange) : null);
				}
				bool? flag2 = flag;
				return flag2.GetValueOrDefault();
			}
		}

		// Token: 0x17000BD1 RID: 3025
		// (get) Token: 0x060021B1 RID: 8625 RVA: 0x00020DBC File Offset: 0x0001EFBC
		public #tbb Context { get; }

		// Token: 0x17000BD2 RID: 3026
		// (get) Token: 0x060021B2 RID: 8626 RVA: 0x00020DC8 File Offset: 0x0001EFC8
		public DelegateCommand Diagram3DFlipCommand { get; }

		// Token: 0x17000BD3 RID: 3027
		// (get) Token: 0x060021B3 RID: 8627 RVA: 0x00020DD4 File Offset: 0x0001EFD4
		public DelegateCommand ChangeCutTypeCommand { get; }

		// Token: 0x17000BD4 RID: 3028
		// (get) Token: 0x060021B4 RID: 8628 RVA: 0x00020DE0 File Offset: 0x0001EFE0
		public DelegateCommand ExportDiagramCommand { get; }

		// Token: 0x17000BD5 RID: 3029
		// (get) Token: 0x060021B5 RID: 8629 RVA: 0x00020DEC File Offset: 0x0001EFEC
		public DelegateCommand ChangeViewControlsVisibilityCommand { get; }

		// Token: 0x17000BD6 RID: 3030
		// (get) Token: 0x060021B6 RID: 8630 RVA: 0x00020DF8 File Offset: 0x0001EFF8
		public DelegateCommand ChangePresenterTypeCommand { get; }

		// Token: 0x17000BD7 RID: 3031
		// (get) Token: 0x060021B7 RID: 8631 RVA: 0x00020E04 File Offset: 0x0001F004
		public DelegateCommand CutCommand { get; }

		// Token: 0x17000BD8 RID: 3032
		// (get) Token: 0x060021B8 RID: 8632 RVA: 0x00020E10 File Offset: 0x0001F010
		public DelegateCommand ChangeDiagram2DTypeCommand { get; }

		// Token: 0x17000BD9 RID: 3033
		// (get) Token: 0x060021B9 RID: 8633 RVA: 0x00020E1C File Offset: 0x0001F01C
		public DelegateCommand ActivateDiagramCommand { get; }

		// Token: 0x17000BDA RID: 3034
		// (get) Token: 0x060021BA RID: 8634 RVA: 0x00020E28 File Offset: 0x0001F028
		public DelegateCommand ShowPlaneCommand { get; }

		// Token: 0x17000BDB RID: 3035
		// (get) Token: 0x060021BB RID: 8635 RVA: 0x000C84DC File Offset: 0x000C66DC
		private IModelEditorViewport ActivePresenter
		{
			get
			{
				IModelEditorViewport modelEditorViewport = this.#e.ActiveViewport as IModelEditorViewport;
				if (modelEditorViewport == null)
				{
					return null;
				}
				if (modelEditorViewport.EditorContext.ViewportOptions.PresenterType == #qg.#a)
				{
					return null;
				}
				return modelEditorViewport;
			}
		}

		// Token: 0x17000BDC RID: 3036
		// (get) Token: 0x060021BC RID: 8636 RVA: 0x00020E34 File Offset: 0x0001F034
		private bool IsDiagramsScopeActive
		{
			get
			{
				return this.ScopesManager.ActiveScope is #BPb;
			}
		}

		// Token: 0x060021BD RID: 8637 RVA: 0x00020E55 File Offset: 0x0001F055
		public void #Kc()
		{
			this.#pab();
			this.#e.#Kc();
		}

		// Token: 0x060021BE RID: 8638 RVA: 0x00020E74 File Offset: 0x0001F074
		public void #Lc()
		{
			this.#pab();
			this.#e.#Lc();
		}

		// Token: 0x060021BF RID: 8639 RVA: 0x00020E93 File Offset: 0x0001F093
		public void #Mc()
		{
			this.#pab();
			this.#e.#Mc();
		}

		// Token: 0x060021C0 RID: 8640 RVA: 0x00020EB2 File Offset: 0x0001F0B2
		public void #Nc()
		{
			this.#pab();
			this.#e.#Nc();
		}

		// Token: 0x060021C1 RID: 8641 RVA: 0x000C8520 File Offset: 0x000C6720
		public void #xf()
		{
			DiagramsManager.#K5b #K5b = new DiagramsManager.#K5b();
			#K5b.#b = this;
			#K5b.#a = null;
			#K5b.#a = this.#e.#xf(new Action(#K5b.#S4b));
		}

		// Token: 0x060021C2 RID: 8642 RVA: 0x000C856C File Offset: 0x000C676C
		public bool #bab()
		{
			IModelEditorViewport modelEditorViewport = this.ActivePresenter;
			if (modelEditorViewport != null)
			{
				IDiagramPresenterViewModel diagramPresenterViewModel = modelEditorViewport.DiagramPresenter;
				return diagramPresenterViewModel != null && diagramPresenterViewModel.PresenterType == DiagramPresenterType.#b;
			}
			return false;
		}

		// Token: 0x060021C3 RID: 8643 RVA: 0x000C85A8 File Offset: 0x000C67A8
		public void #cab()
		{
			if (this.Context.IsReportSourceValid)
			{
				this.Context.IsReportSourceValid = false;
				this.#mbb(new Action<IDiagramPresenterViewModel>(DiagramsManager.<>c.<>9.#7Zh));
				this.#f = null;
				this.#gab();
				this.LeftPanel.#cab();
			}
		}

		// Token: 0x060021C4 RID: 8644 RVA: 0x000C8618 File Offset: 0x000C6818
		public void #dab(bool #eab = false)
		{
			this.LeftPanel.#jib();
			IModelEditorViewport modelEditorViewport = this.ActivePresenter;
			if (((modelEditorViewport != null) ? modelEditorViewport.DiagramPresenter : null) != null)
			{
				#mib #mib = this.LeftPanel;
				IModelEditorViewport modelEditorViewport2 = this.ActivePresenter;
				#mib.#aib((modelEditorViewport2 != null) ? modelEditorViewport2.DiagramPresenter : null, #eab, true);
			}
			foreach (IDiagramPresenterViewModel diagramPresenterViewModel in this.#0ab())
			{
				diagramPresenterViewModel.#Xdb();
			}
			this.#Ybb();
		}

		// Token: 0x060021C5 RID: 8645 RVA: 0x000C86C4 File Offset: 0x000C68C4
		public void #fab(#lte #Od, #7z #bA)
		{
			this.#f = #Od;
			#tbb #tbb = this.Context;
			bool? flag;
			if (#Od == null)
			{
				flag = null;
			}
			else
			{
				#l4e #l4e = #Od.Output;
				flag = ((#l4e != null) ? new bool?(#l4e.SolveCompleted) : null);
			}
			bool? flag2 = flag;
			#tbb.IsReportSourceValid = flag2.GetValueOrDefault();
			this.Context.IsBiaxialActive = (#Od != null && #Od.Input.Options.ConsideredAxis == ConsideredAxis.Both);
			if (#Od != null && #bA != #7z.#b)
			{
				this.#Uab(#Od, #bA);
			}
			this.#gab();
			this.#sab();
		}

		// Token: 0x060021C6 RID: 8646 RVA: 0x000C8778 File Offset: 0x000C6978
		public void #vh()
		{
			this.Diagram3DFlipCommand.InvalidateCanExecute();
			this.ExportDiagramCommand.InvalidateCanExecute();
			this.ChangeCutTypeCommand.InvalidateCanExecute();
			this.ChangeDiagram2DTypeCommand.InvalidateCanExecute();
			this.CutCommand.InvalidateCanExecute();
			this.ChangePresenterTypeCommand.InvalidateCanExecute();
			this.ChangeViewControlsVisibilityCommand.InvalidateCanExecute();
			this.ShowPlaneCommand.InvalidateCanExecute();
			this.ActivateDiagramCommand.InvalidateCanExecute();
		}

		// Token: 0x060021C7 RID: 8647 RVA: 0x000C87F4 File Offset: 0x000C69F4
		public void #gab()
		{
			IModelEditorViewport modelEditorViewport = this.#a.ViewportsManager.ActiveViewport as IModelEditorViewport;
			#cLb #cLb = (modelEditorViewport != null) ? modelEditorViewport.EditorContext : null;
			IModelEditorViewport modelEditorViewport2 = this.ActivePresenter;
			#aMb #aMb = (modelEditorViewport2 != null) ? modelEditorViewport2.EditorContext.ViewportOptions : null;
			bool flag = this.Context.IsReportSourceValid;
			bool flag2 = this.Context.IsBiaxialActive;
			bool flag3 = this.#e.Viewports.Any<IViewport>() && this.#e.ActiveViewport is IModelEditorViewport;
			bool flag4 = this.ActivePresenter != null && this.IsDiagramsScopeActive;
			IModelEditorViewport modelEditorViewport3 = this.ActivePresenter;
			IDiagramPresenterViewModel diagramPresenterViewModel = (modelEditorViewport3 != null) ? modelEditorViewport3.DiagramPresenter : null;
			DiagramsManager.#R4b #R4b = this.#qab();
			bool flag5 = true;
			if (this.#a.Project.Model.Options.ProblemType == ProblemType.Design && #cLb != null)
			{
				bool flag8;
				if (this.#c.State == #tJ.#b && this.#d.CurrentTraceStep != null && this.#d.CurrentTraceStep == this.#d.TraceResults.LastOrDefault<#4Ve>())
				{
					DesignEngine designEngine = this.#d.DesignEngine;
					bool? flag6;
					if (designEngine == null)
					{
						flag6 = null;
					}
					else
					{
						#l4e #l4e = designEngine.OutputModel;
						flag6 = ((#l4e != null) ? new bool?(#l4e.SolveCompleted) : null);
					}
					bool? flag7 = flag6;
					flag8 = flag7.GetValueOrDefault();
				}
				else
				{
					flag8 = false;
				}
				bool flag9 = flag8;
				flag5 = flag9;
			}
			this.Context.IsDiagramMMEnabled = ((flag4 || #R4b.Any2DMM || #R4b.NoViewportsCreated) && flag5 && flag && flag2 && DiagramPresenterViewModel.#Hdb(this.#f, ActivateDiagramParameters.Diagram2DMM));
			this.Context.IsDiagramMMChecked = (flag && flag4 && #aMb != null && #aMb.IsDiagramMMChecked);
			this.Context.IsDiagramPMEnabled = (flag && flag5 && (flag4 || #R4b.Any2DPM || #R4b.NoViewportsCreated));
			this.Context.IsDiagramPMChecked = (flag && flag4 && #aMb != null && #aMb.IsDiagramPMChecked);
			this.Context.IsDiagramPMPlusChecked = (flag && flag4 && #aMb != null && #aMb.IsDiagramPMPlusChecked);
			this.Context.IsDiagramPMMinusChecked = (flag && flag4 && #aMb != null && #aMb.IsDiagramPMMinusChecked);
			this.Context.IsDiagramPMGroupChecked = (this.Context.IsDiagramPMChecked || this.Context.IsDiagramPMMinusChecked || this.Context.IsDiagramPMPlusChecked);
			this.Context.IsCutCommandEnabled = true;
			this.Context.IsChangeCutTypeCommandEnabled = true;
			this.Context.IsDiagram3DFlipCommandEnabled = true;
			this.Context.IsDiagram3DVerticalEnabled = (flag && flag2 && (flag4 || #R4b.Any3DPM || #R4b.NoViewportsCreated) && flag5);
			this.Context.IsDiagram3DVerticalChecked = (flag4 && #aMb != null && #aMb.IsDiagram3DVerticalChecked);
			this.Context.IsDiagram3DIsVerticalShowPlaneEnabled = (flag && flag4 && diagramPresenterViewModel != null && diagramPresenterViewModel.PresenterType == DiagramPresenterType.#a && diagramPresenterViewModel.DefinedDiagram3DCutType == Diagram3DCutType.#c);
			this.Context.IsDiagram3DIsVerticalCutEnabled = (flag && flag4 && diagramPresenterViewModel != null && diagramPresenterViewModel.PresenterType == DiagramPresenterType.#a && this.Context.IsDiagram3DIsVerticalShowPlaneEnabled && this.Diagram3DIsVerticalCutActive);
			this.Context.IsDiagram3DIsVerticalFlipEnabled = (flag && flag4 && this.Diagram3DIsVerticalCutActive && diagramPresenterViewModel != null && diagramPresenterViewModel.PresenterType == DiagramPresenterType.#a && this.Context.IsDiagram3DIsVerticalShowPlaneEnabled);
			this.Context.IsDiagram3DHorizontalEnabled = (flag && flag2 && (flag4 || #R4b.Any3DMM || #R4b.NoViewportsCreated) && flag5);
			this.Context.IsDiagram3DHorizontalChecked = (flag4 && #aMb != null && #aMb.IsDiagram3DHorizontalChecked);
			this.Context.IsDiagram3DIsHorizontalShowPlaneEnabled = (flag && flag4 && diagramPresenterViewModel != null && diagramPresenterViewModel.PresenterType == DiagramPresenterType.#a && diagramPresenterViewModel.DefinedDiagram3DCutType == Diagram3DCutType.#b);
			this.Context.IsDiagram3DIsHorizontalCutEnabled = (flag && flag4 && diagramPresenterViewModel != null && diagramPresenterViewModel.PresenterType == DiagramPresenterType.#a && this.Context.IsDiagram3DIsHorizontalShowPlaneEnabled && this.IsDiagram3DHorizontalCutActive);
			this.Context.IsDiagram3DIsHorizontalFlipEnabled = (flag && flag4 && this.IsDiagram3DHorizontalCutActive && diagramPresenterViewModel != null && diagramPresenterViewModel.PresenterType == DiagramPresenterType.#a && this.Context.IsDiagram3DIsHorizontalShowPlaneEnabled);
			this.Context.#Q9();
			base.RaisePropertyChanged(#Phc.#3hc(107363475));
			base.RaisePropertyChanged(#Phc.#3hc(107363516));
			base.RaisePropertyChanged(#Phc.#3hc(107363402));
			this.#vh();
		}

		// Token: 0x060021C8 RID: 8648 RVA: 0x000C8CB4 File Offset: 0x000C6EB4
		public void #Pd(IModelEditorViewport #fe, ActivateDiagramParameters #Pc, #7z #mA = #7z.#a)
		{
			DiagramsManager.#K9c #K9c = new DiagramsManager.#K9c();
			#K9c.#b = #fe;
			#K9c.#c = this;
			if (!this.IsDiagramsScopeActive && #mA == #7z.#a)
			{
				this.#pab();
				this.#rab(#Pc);
				if (this.#Tab(this.#f))
				{
					this.#Uab(this.#f, #mA);
				}
				this.#gab();
				this.#sab();
				this.#Gf();
				return;
			}
			#K9c.#b.ReportingModel = this.#f;
			DiagramsManager.#K9c #K9c2 = #K9c;
			bool flag;
			if (#K9c.#b.DiagramPresenter != null || #Pc.PresenterType != DiagramPresenterType.#b)
			{
				IDiagramPresenterViewModel diagramPresenterViewModel = #K9c.#b.DiagramPresenter;
				DiagramPresenterType? diagramPresenterType = (diagramPresenterViewModel != null) ? new DiagramPresenterType?(diagramPresenterViewModel.PresenterType) : null;
				DiagramPresenterType presenterType = #Pc.PresenterType;
				flag = (diagramPresenterType.GetValueOrDefault() == presenterType & diagramPresenterType != null);
			}
			else
			{
				flag = true;
			}
			#K9c2.#a = flag;
			this.#lbb();
			#K9c.#b.#Pd(#Pc, false, this.Context.SelectedLoads);
			this.#lbb();
			this.#Qab(#K9c.#b.DiagramPresenter);
			#K9c.#b.Host.#od(#K9c.#b.View);
			#K9c.#b.Host.#xe();
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(#K9c.#g5b));
		}

		// Token: 0x060021C9 RID: 8649 RVA: 0x00020ED1 File Offset: 0x0001F0D1
		private void #cl(object #Ge, #7V #He)
		{
			this.#i = !#He.IsUndoRedo;
		}

		// Token: 0x060021CA RID: 8650 RVA: 0x00020EEE File Offset: 0x0001F0EE
		private void #hab(object #Ge, #jW #He)
		{
			this.#gab();
		}

		// Token: 0x060021CB RID: 8651 RVA: 0x00020EFE File Offset: 0x0001F0FE
		private void #iab(object #Ge, EventArgs #He)
		{
			if (this.#c.State != #tJ.#b)
			{
				this.#cab();
			}
		}

		// Token: 0x060021CC RID: 8652 RVA: 0x00020F20 File Offset: 0x0001F120
		private void #Bh(object #Ge, EventArgs #He)
		{
			this.#hbb(true);
		}

		// Token: 0x060021CD RID: 8653 RVA: 0x000C8E1C File Offset: 0x000C701C
		private void #Ah(object #Ge, EventArgs #He)
		{
			this.#hbb(false);
			this.#mbb(new Action<IDiagramPresenterViewModel>(DiagramsManager.<>c.<>9.#8Zh));
			this.LeftPanel.#iib(this.#f);
		}

		// Token: 0x060021CE RID: 8654 RVA: 0x00020F31 File Offset: 0x0001F131
		private void #jab(object #Ge, EventArgs #He)
		{
			this.#gbb();
			this.#gab();
		}

		// Token: 0x060021CF RID: 8655 RVA: 0x000C8E74 File Offset: 0x000C7074
		private void #kab(object #Ge, #he #He)
		{
			this.#U9();
			IModelEditorViewport modelEditorViewport = #He.EditorViewport;
			this.#Rab((modelEditorViewport != null) ? modelEditorViewport.DiagramPresenter : null);
			this.#xab(#He.Viewport);
			this.LeftPanel.#8hb(this.#0ab());
			this.#gab();
			this.#lab();
		}

		// Token: 0x060021D0 RID: 8656 RVA: 0x00020EEE File Offset: 0x0001F0EE
		private void #mab(object #Ge, #QJb #He)
		{
			this.#gab();
		}

		// Token: 0x060021D1 RID: 8657 RVA: 0x000C8ED4 File Offset: 0x000C70D4
		private void #nab(object #Ge, #yd #He)
		{
			this.#U9();
			IModelEditorViewport modelEditorViewport = this.ActivePresenter;
			this.#Qab((modelEditorViewport != null) ? modelEditorViewport.DiagramPresenter : null);
			this.#sab();
			this.#e.#Gf();
			#mib #mib = this.LeftPanel;
			IModelEditorViewport modelEditorViewport2 = this.ActivePresenter;
			#mib.#lib((modelEditorViewport2 != null) ? modelEditorViewport2.DiagramPresenter : null);
			this.#vab(this.ActivePresenter, true);
			this.#Ybb();
			this.#gab();
			this.#mbb(new Action<IDiagramPresenterViewModel>(DiagramsManager.<>c.<>9.#9Zh));
		}

		// Token: 0x060021D2 RID: 8658 RVA: 0x000C8F8C File Offset: 0x000C718C
		private void #oab(object #Ge, #Yjb #Lg)
		{
			try
			{
				if (#Lg.MouseButton == MouseButton.Right)
				{
					object owner = this.#a.WindowLocator.#VP();
					this.#b.View.SetOwner(owner);
					this.#b.#Ygb(this.#f, this.LeftPanel.NavigationTable.#kjb(), #Lg);
				}
				else if (#Lg.MouseButton == MouseButton.Left)
				{
					GridDataRowCore gridDataRowCore = LoadPointDetailsViewModel.#5W(this.#f, this.LeftPanel.NavigationTable.#kjb(), #Lg);
					if (gridDataRowCore != null)
					{
						this.LeftPanel.NavigationTable.#ljb(gridDataRowCore);
					}
				}
			}
			catch (Exception #ob)
			{
				this.#a.ExceptionHandler.#3Ab(#ob);
			}
		}

		// Token: 0x060021D3 RID: 8659 RVA: 0x00020F4B File Offset: 0x0001F14B
		private void #Gf()
		{
			this.#e.#Gf();
		}

		// Token: 0x060021D4 RID: 8660 RVA: 0x00020F60 File Offset: 0x0001F160
		private void #U9()
		{
			this.Context.OpenedDiagramTypes.Clear();
			this.#mbb(new Action<IDiagramPresenterViewModel>(this.#AVh));
			this.#Gf();
		}

		// Token: 0x060021D5 RID: 8661 RVA: 0x00020F96 File Offset: 0x0001F196
		private void #lab()
		{
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#BVh));
		}

		// Token: 0x060021D6 RID: 8662 RVA: 0x00020FB2 File Offset: 0x0001F1B2
		private void #Ybb()
		{
			this.#0ab().#I1d(new Action<IDiagramPresenterViewModel>(DiagramsManager.<>c.<>9.#b0h));
		}

		// Token: 0x060021D7 RID: 8663 RVA: 0x00020FEA File Offset: 0x0001F1EA
		private void #pab()
		{
			if (!this.IsDiagramsScopeActive)
			{
				this.ScopesManager.#YKb(new DiagramsScopeActivationParameters());
			}
		}

		// Token: 0x060021D8 RID: 8664 RVA: 0x000C9068 File Offset: 0x000C7268
		private DiagramsManager.#R4b #qab()
		{
			IList<IDiagramPresenterViewModel> list = this.#0ab();
			DiagramsManager.#R4b result = default(DiagramsManager.#R4b);
			result.NoViewportsCreated = (list.Count <= 0);
			foreach (IDiagramPresenterViewModel diagramPresenterViewModel in list)
			{
				if (diagramPresenterViewModel.PresenterType == DiagramPresenterType.#b)
				{
					if (diagramPresenterViewModel.Diagram2DType == Diagram2DType.DiagramMM)
					{
						result.Any2DMM = true;
					}
					else
					{
						result.Any2DPM = true;
					}
				}
				else if (diagramPresenterViewModel.PresenterType == DiagramPresenterType.#a)
				{
					if (diagramPresenterViewModel.Diagram3DCutType == Diagram3DCutType.#c)
					{
						result.Any3DPM = true;
					}
					else if (diagramPresenterViewModel.Diagram3DCutType == Diagram3DCutType.#b)
					{
						result.Any3DMM = true;
					}
				}
			}
			return result;
		}

		// Token: 0x060021D9 RID: 8665 RVA: 0x000C913C File Offset: 0x000C733C
		private void #rab(ActivateDiagramParameters #Pc)
		{
			DiagramsManager.#VTb #VTb = new DiagramsManager.#VTb();
			#VTb.#a = #Pc;
			IDiagramPresenterViewModel diagramPresenterViewModel = this.#0ab().FirstOrDefault(new Func<IDiagramPresenterViewModel, bool>(#VTb.#i5b));
			if (diagramPresenterViewModel != null)
			{
				diagramPresenterViewModel.PresenterHost.Pane.IsActive = true;
			}
		}

		// Token: 0x060021DA RID: 8666 RVA: 0x000C9190 File Offset: 0x000C7390
		private void #sab()
		{
			IModelEditorViewport modelEditorViewport = this.ActivePresenter;
			IDiagramPresenterViewModel diagramPresenterViewModel = (modelEditorViewport != null) ? modelEditorViewport.DiagramPresenter : null;
			DiagramPresenterType? diagramPresenterType = (diagramPresenterViewModel != null) ? new DiagramPresenterType?(diagramPresenterViewModel.PresenterType) : null;
			if (diagramPresenterType != null)
			{
				DiagramPresenterType valueOrDefault = diagramPresenterType.GetValueOrDefault();
				if (valueOrDefault == DiagramPresenterType.#a)
				{
					this.#a.GuiController.EditorStatusBar.#5b(#Fnb.#b);
					return;
				}
				if (valueOrDefault == DiagramPresenterType.#b)
				{
					Diagram2DType diagram2DType = diagramPresenterViewModel.Diagram2DType;
					if (diagram2DType == Diagram2DType.DiagramMM)
					{
						this.#a.GuiController.EditorStatusBar.#5b(#Fnb.#d);
						return;
					}
					if (diagram2DType - Diagram2DType.DiagramPM > 2)
					{
						throw new ArgumentOutOfRangeException();
					}
					this.#a.GuiController.EditorStatusBar.#5b(#Fnb.#c);
					return;
				}
			}
			this.#a.GuiController.EditorStatusBar.#5b(#Fnb.#a);
		}

		// Token: 0x060021DB RID: 8667 RVA: 0x000C9278 File Offset: 0x000C7478
		private bool #tab(IViewport #fe)
		{
			IModelEditorViewport modelEditorViewport = #fe as IModelEditorViewport;
			return this.#tab((modelEditorViewport != null) ? modelEditorViewport.DiagramPresenter : null);
		}

		// Token: 0x060021DC RID: 8668 RVA: 0x000C92AC File Offset: 0x000C74AC
		private bool #tab(object #Rf)
		{
			IViewport viewport = #Rf as IViewport;
			if (viewport != null)
			{
				return this.#tab(viewport);
			}
			IDiagramPresenterViewModel diagramPresenterViewModel = #Rf as IDiagramPresenterViewModel;
			return diagramPresenterViewModel != null && this.#tab(diagramPresenterViewModel);
		}

		// Token: 0x060021DD RID: 8669 RVA: 0x00021010 File Offset: 0x0001F210
		private bool #tab(IDiagramPresenterViewModel #uab)
		{
			return #uab != null && #uab.IsActive;
		}

		// Token: 0x060021DE RID: 8670 RVA: 0x000C92EC File Offset: 0x000C74EC
		private void #vab(IModelEditorViewport #fe, bool #wab = true)
		{
			if (#wab)
			{
				this.#mbb(new Action<IDiagramPresenterViewModel>(DiagramsManager.<>c.<>9.#c0h));
			}
			IDiagramPresenterViewModel diagramPresenterViewModel = (#fe != null) ? #fe.DiagramPresenter : null;
			if (diagramPresenterViewModel != null)
			{
				if (#wab)
				{
					diagramPresenterViewModel.IsActive = true;
				}
				this.LeftPanel.#aib(diagramPresenterViewModel, false, false);
				this.LeftPanel.#8hb(this.#0ab());
			}
			this.#gab();
		}

		// Token: 0x060021DF RID: 8671 RVA: 0x000C9370 File Offset: 0x000C7570
		private void #xab(IViewport #fe)
		{
			IModelEditorViewport modelEditorViewport = #fe as IModelEditorViewport;
			if (modelEditorViewport != null && modelEditorViewport.DiagramPresenter != null)
			{
				modelEditorViewport.DiagramPresenter.IsActive = false;
			}
		}

		// Token: 0x060021E0 RID: 8672 RVA: 0x00009E6A File Offset: 0x0000806A
		private void #yab(object #Sb)
		{
		}

		// Token: 0x060021E1 RID: 8673 RVA: 0x00021029 File Offset: 0x0001F229
		private bool #zab(object #Sb)
		{
			return this.Context.IsChangeViewControlsVisibilityCommandEnabled;
		}

		// Token: 0x060021E2 RID: 8674 RVA: 0x00009E6A File Offset: 0x0000806A
		private void #Aab(object #Sb)
		{
		}

		// Token: 0x060021E3 RID: 8675 RVA: 0x00021042 File Offset: 0x0001F242
		private bool #Bab(object #Sb)
		{
			return this.Context.IsChangePresenterTypeCommandEnabled;
		}

		// Token: 0x060021E4 RID: 8676 RVA: 0x0002105B File Offset: 0x0001F25B
		private void #Cab(object #Sb)
		{
			IModelEditorViewport modelEditorViewport = this.ActivePresenter;
			if (modelEditorViewport != null)
			{
				IDiagramPresenterViewModel diagramPresenterViewModel = modelEditorViewport.DiagramPresenter;
				if (diagramPresenterViewModel != null)
				{
					diagramPresenterViewModel.CutCommand.Execute(#Sb);
				}
			}
			base.RaisePropertyChanged(#Phc.#3hc(107363402));
		}

		// Token: 0x060021E5 RID: 8677 RVA: 0x0002109B File Offset: 0x0001F29B
		private bool #Dab(object #Sb)
		{
			return this.Context.IsCutCommandEnabled;
		}

		// Token: 0x060021E6 RID: 8678 RVA: 0x00009E6A File Offset: 0x0000806A
		private void #Eab(object #Sb)
		{
		}

		// Token: 0x060021E7 RID: 8679 RVA: 0x00003375 File Offset: 0x00001575
		private bool #Fab(object #Sb)
		{
			return true;
		}

		// Token: 0x060021E8 RID: 8680 RVA: 0x00009E6A File Offset: 0x0000806A
		private void #Gab(object #Sb)
		{
		}

		// Token: 0x060021E9 RID: 8681 RVA: 0x000210B4 File Offset: 0x0001F2B4
		private bool #Hab(object #Sb)
		{
			return this.Context.IsActivateDiagramCommandEnabled;
		}

		// Token: 0x060021EA RID: 8682 RVA: 0x00009E6A File Offset: 0x0000806A
		private void #Iab(object #Sb)
		{
		}

		// Token: 0x060021EB RID: 8683 RVA: 0x000210CD File Offset: 0x0001F2CD
		private bool #Jab(object #Sb)
		{
			return this.Context.IsShowPlaneCommandEnabled;
		}

		// Token: 0x060021EC RID: 8684 RVA: 0x00009E6A File Offset: 0x0000806A
		private void #Kab(object #Sb)
		{
		}

		// Token: 0x060021ED RID: 8685 RVA: 0x000210E6 File Offset: 0x0001F2E6
		private bool #Lab(object #Sb)
		{
			return this.Context.IsChangeCutTypeCommandEnabled;
		}

		// Token: 0x060021EE RID: 8686 RVA: 0x00009E6A File Offset: 0x0000806A
		private void #Mab(object #Sb)
		{
		}

		// Token: 0x060021EF RID: 8687 RVA: 0x000210FF File Offset: 0x0001F2FF
		private bool #Nab(object #Sb)
		{
			return this.Context.IsExportDiagramCommandEnabled;
		}

		// Token: 0x060021F0 RID: 8688 RVA: 0x00021118 File Offset: 0x0001F318
		private void #Oab(object #Sb)
		{
			IModelEditorViewport modelEditorViewport = this.ActivePresenter;
			if (modelEditorViewport == null)
			{
				return;
			}
			IDiagramPresenterViewModel diagramPresenterViewModel = modelEditorViewport.DiagramPresenter;
			if (diagramPresenterViewModel == null)
			{
				return;
			}
			diagramPresenterViewModel.Diagram3DFlipCommand.Execute(#Sb);
		}

		// Token: 0x060021F1 RID: 8689 RVA: 0x00021146 File Offset: 0x0001F346
		private bool #Pab(object #Sb)
		{
			return this.Context.IsDiagram3DFlipCommandEnabled;
		}

		// Token: 0x060021F2 RID: 8690 RVA: 0x000C93A8 File Offset: 0x000C75A8
		private void #Qab(IDiagramPresenterViewModel #uab)
		{
			if (#uab == null)
			{
				return;
			}
			this.#Rab(#uab);
			#uab.AxialLoadChanging += this.#abb;
			#uab.AxialLoadChanged += this.#8ab;
			#uab.AngleChanging += this.#9ab;
			#uab.AngleChanged += this.#7ab;
			#uab.PresenterTypeChanged += this.#6ab;
			#uab.DiagramParameterChanged += this.#5ab;
			#uab.ButtonStatesInvalidated += this.#jab;
			#uab.LoadPointClickedEventArgs += this.#oab;
		}

		// Token: 0x060021F3 RID: 8691 RVA: 0x000C9470 File Offset: 0x000C7670
		private void #Rab(IDiagramPresenterViewModel #uab)
		{
			if (#uab == null)
			{
				return;
			}
			#uab.AxialLoadChanging -= this.#abb;
			#uab.AxialLoadChanged -= this.#8ab;
			#uab.AngleChanging -= this.#9ab;
			#uab.AngleChanged -= this.#7ab;
			#uab.PresenterTypeChanged -= this.#6ab;
			#uab.DiagramParameterChanged -= this.#5ab;
			#uab.ButtonStatesInvalidated -= this.#jab;
			#uab.LoadPointClickedEventArgs -= this.#oab;
		}

		// Token: 0x060021F4 RID: 8692 RVA: 0x000C9530 File Offset: 0x000C7730
		private void #Sab(object #Vg)
		{
			ActivateDiagramParameters activateDiagramParameters = #Vg as ActivateDiagramParameters;
			if (activateDiagramParameters == null)
			{
				return;
			}
			IModelEditorViewport modelEditorViewport = this.#e.ActiveViewport as IModelEditorViewport;
			if (modelEditorViewport == null)
			{
				this.#e.#zf();
				modelEditorViewport = (this.#e.ActiveViewport as IModelEditorViewport);
				if (modelEditorViewport != null)
				{
					RadPane radPane = modelEditorViewport.Host.Pane;
					#lte #lte = this.#f;
					bool canUserClose;
					if (#lte == null)
					{
						canUserClose = false;
					}
					else
					{
						ColumnStorageModel columnStorageModel = #lte.Input;
						ConsideredAxis? consideredAxis = (columnStorageModel != null) ? new ConsideredAxis?(columnStorageModel.Options.ConsideredAxis) : null;
						ConsideredAxis consideredAxis2 = ConsideredAxis.Both;
						canUserClose = (consideredAxis.GetValueOrDefault() == consideredAxis2 & consideredAxis != null);
					}
					radPane.CanUserClose = canUserClose;
				}
			}
			if (modelEditorViewport == null)
			{
				return;
			}
			DateTime now = DateTime.Now;
			if (this.#g == null || now - this.#g.Value > this.#h)
			{
				if (this.#g != null)
				{
					TimeSpan timeSpan = now - this.#g.Value;
				}
				this.#g = new DateTime?(now);
				this.#Pd(modelEditorViewport, activateDiagramParameters, #7z.#a);
			}
		}

		// Token: 0x060021F5 RID: 8693 RVA: 0x0002115F File Offset: 0x0001F35F
		private bool #Tab(#lte #Od)
		{
			return this.#z == null || this.#z != #Od;
		}

		// Token: 0x060021F6 RID: 8694 RVA: 0x000C965C File Offset: 0x000C785C
		private void #Uab(#lte #Od, #7z #bA)
		{
			DiagramsManager.#3Dg #3Dg = new DiagramsManager.#3Dg();
			#3Dg.#a = this;
			#3Dg.#b = #Od;
			#3Dg.#c = #bA;
			#lte #lte = #3Dg.#b;
			if (#lte == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399786));
			}
			this.#z = #lte;
			this.Context.IsLoadingData = true;
			try
			{
				this.#v = true;
				this.#Vab(#3Dg.#b);
				this.#sab();
				this.LeftPanel.#iib(#3Dg.#b);
			}
			catch (Exception #ob)
			{
				this.#v = false;
				this.#a.ExceptionHandler.#3Ab(#ob);
			}
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(#3Dg.#j5b));
		}

		// Token: 0x060021F7 RID: 8695 RVA: 0x000C9738 File Offset: 0x000C7938
		private void #Vab(#lte #Od)
		{
			if (this.#w != #Od.GeneralInfo.FileName)
			{
				#Gse #Gse = this.#a.ReporterSettings.#Hse(null);
				#Gse.IsCapacityRatioFilterActive = false;
				#Gse.IsVisibilityFilterActive = false;
				#Gse.IsLocationFilterActive = false;
				this.#a.ReporterSettings.#lJ(#Gse);
				this.#w = #Od.GeneralInfo.FileName;
			}
		}

		// Token: 0x060021F8 RID: 8696 RVA: 0x000C97B4 File Offset: 0x000C79B4
		private void #Wab(#7z #bA, bool #Xab)
		{
			#lte #lte = this.#f;
			if (#lte == null)
			{
				return;
			}
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#CVh));
			ConsideredAxis consideredAxis = #lte.Input.Options.ConsideredAxis;
			LoadType activeLoad = #lte.Input.Options.ActiveLoad;
			bool flag = this.#y == null || this.#x == null || this.#y.Value.#Cpe() != consideredAxis.#Cpe() || this.#x.Value != activeLoad || !this.#0ab().Any<IDiagramPresenterViewModel>() || #Xab;
			if (consideredAxis.#Cpe())
			{
				this.LeftPanel.AreNavigationBoxesEnabled = false;
				this.LeftPanel.Diagram3DEnabled = false;
				this.LeftPanel.DiagramMMEnabled = false;
				this.LeftPanel.IsViewportsSelectionEnabled = false;
				if (activeLoad == LoadType.Axial || activeLoad == LoadType.NoLoads)
				{
					this.LeftPanel.IsNavigationTableEnabled = false;
				}
				else if (activeLoad == LoadType.Factored || activeLoad == LoadType.Service)
				{
					this.LeftPanel.IsNavigationTableEnabled = true;
					this.LeftPanel.NavigationTable.#mjb();
				}
				this.Context.IsLoadingData = false;
				if (flag)
				{
					this.#Yab(#bA);
				}
				else
				{
					this.#hbb(true);
				}
			}
			else if (consideredAxis == ConsideredAxis.Both)
			{
				this.LeftPanel.AreNavigationBoxesEnabled = true;
				this.LeftPanel.IsViewportsSelectionEnabled = true;
				this.LeftPanel.Diagram3DEnabled = true;
				this.LeftPanel.DiagramMMEnabled = true;
				this.LeftPanel.IsNavigationTableEnabled = true;
				if (activeLoad == LoadType.NoLoads)
				{
					this.LeftPanel.IsNavigationTableEnabled = false;
					this.Context.IsLoadingData = false;
					if (flag)
					{
						this.LeftPanel.#dib(0.0);
						this.LeftPanel.#cib(0.0);
						this.#Zab(#bA);
					}
					else
					{
						this.#hbb(true);
					}
				}
				else if (activeLoad == LoadType.Factored || activeLoad == LoadType.Service)
				{
					this.LeftPanel.IsNavigationTableEnabled = true;
					GridDataRowCore #uI;
					LoadPointRowMetadata loadPointRowMetadata;
					this.#1ab(out #uI, out loadPointRowMetadata);
					this.LeftPanel.NavigationTable.#ljb(#uI);
					if (loadPointRowMetadata != null && loadPointRowMetadata.AxialLoad != null && loadPointRowMetadata.Angle != null)
					{
						this.LeftPanel.#cib(loadPointRowMetadata.AxialLoad.Value);
						this.LeftPanel.#dib(loadPointRowMetadata.Angle.Value);
					}
					this.Context.IsLoadingData = false;
					if (flag)
					{
						this.#Zab(#bA);
					}
					else
					{
						this.#hbb(true);
					}
				}
				else
				{
					this.Context.IsLoadingData = false;
					this.#hbb(true);
				}
			}
			this.LeftPanel.NavigationTableVisibility = ((this.LeftPanel.IsNavigationTableEnabled && this.LeftPanel.NavigationTable.#kjb().Any<GridDataRowCore>()) ? Visibility.Visible : Visibility.Collapsed);
			this.#y = new ConsideredAxis?(consideredAxis);
			this.#x = new LoadType?(activeLoad);
			this.LeftPanel.#8hb(this.#0ab());
			bool flag2 = this.LeftPanel.CanExpandNavigation;
			bool flag3 = this.LeftPanel.IsNavigationTableEnabled || (this.LeftPanel.AreNavigationBoxesEnabled && (this.LeftPanel.IsAngleComboBoxEnabled || this.LeftPanel.IsAxialLoadComboBoxEnabled));
			if (!flag3)
			{
				this.LeftPanel.IsNavigationExpanded = false;
			}
			else if (!flag2)
			{
				this.LeftPanel.IsNavigationExpanded = true;
			}
			this.LeftPanel.CanExpandNavigation = flag3;
			this.#gab();
			this.#sab();
		}

		// Token: 0x060021F9 RID: 8697 RVA: 0x000C9B54 File Offset: 0x000C7D54
		private void #Yab(#7z #bA)
		{
			this.#e.#Df(null);
			this.#e.#zf();
			if (#bA == #7z.#a)
			{
				this.ScopesManager.#YKb(new DiagramsScopeActivationParameters());
			}
			IModelEditorViewport modelEditorViewport = (IModelEditorViewport)this.#e.Viewports[0];
			modelEditorViewport.ScopeSettings.ActiveScope = this.ScopesManager.Diagrams;
			this.#Pd(modelEditorViewport, ActivateDiagramParameters.Diagram2DPM, #bA);
		}

		// Token: 0x060021FA RID: 8698 RVA: 0x000C9BD4 File Offset: 0x000C7DD4
		private void #Zab(#7z #bA)
		{
			this.#e.#Df(null);
			this.#e.#Af(Orientation.Horizontal, null);
			if (#bA == #7z.#a)
			{
				this.ScopesManager.#YKb(new DiagramsScopeActivationParameters());
			}
			IModelEditorViewport modelEditorViewport = (IModelEditorViewport)this.#e.Viewports[0];
			modelEditorViewport.ScopeSettings.ActiveScope = this.ScopesManager.Diagrams;
			this.#Pd(modelEditorViewport, ActivateDiagramParameters.Diagram2DPM, #bA);
			modelEditorViewport = (IModelEditorViewport)this.#e.Viewports[1];
			modelEditorViewport.ScopeSettings.ActiveScope = this.ScopesManager.Diagrams;
			this.#Pd(modelEditorViewport, ActivateDiagramParameters.Diagram2DMM, #bA);
		}

		// Token: 0x060021FB RID: 8699 RVA: 0x000C9CA8 File Offset: 0x000C7EA8
		private IList<IDiagramPresenterViewModel> #0ab()
		{
			IEnumerable<IModelEditorViewport> source = this.#e.Viewports.Select(new Func<IViewport, IModelEditorViewport>(DiagramsManager.<>c.<>9.#d0h)).Where(new Func<IModelEditorViewport, bool>(DiagramsManager.<>c.<>9.#e0h)).Where(new Func<IModelEditorViewport, bool>(DiagramsManager.<>c.<>9.#f0h));
			return source.Select(new Func<IModelEditorViewport, IDiagramPresenterViewModel>(DiagramsManager.<>c.<>9.#g0h)).Where(new Func<IDiagramPresenterViewModel, bool>(DiagramsManager.<>c.<>9.#h0h)).ToList<IDiagramPresenterViewModel>();
		}

		// Token: 0x060021FC RID: 8700 RVA: 0x000C9D9C File Offset: 0x000C7F9C
		private void #1ab(out GridDataRowCore #2ab, out LoadPointRowMetadata #3ab)
		{
			#2ab = null;
			#3ab = null;
			var <>f__AnonymousType = this.LeftPanel.NavigationTable.#kjb().Select(new Func<GridDataRowCore, <>f__AnonymousType2<GridDataRowCore, LoadPointRowMetadata>>(DiagramsManager.<>c.<>9.#i0h)).Where(new Func<<>f__AnonymousType2<GridDataRowCore, LoadPointRowMetadata>, bool>(DiagramsManager.<>c.<>9.#j0h)).Select(new Func<<>f__AnonymousType2<GridDataRowCore, LoadPointRowMetadata>, <>f__AnonymousType3<GridDataRowCore, LoadPointRowMetadata, double>>(DiagramsManager.<>c.<>9.#k0h)).OrderByDescending(new Func<<>f__AnonymousType3<GridDataRowCore, LoadPointRowMetadata, double>, double>(DiagramsManager.<>c.<>9.#l0h)).FirstOrDefault();
			if (<>f__AnonymousType != null)
			{
				#2ab = <>f__AnonymousType.Item;
				#3ab = <>f__AnonymousType.LoadPoint;
			}
		}

		// Token: 0x17000BDD RID: 3037
		// (get) Token: 0x060021FD RID: 8701 RVA: 0x00021183 File Offset: 0x0001F383
		private bool AreSolveResultsAvailable
		{
			get
			{
				#lte #lte = this.#f;
				return ((#lte != null) ? #lte.Output : null) != null && this.#f.Output.SolveCompleted;
			}
		}

		// Token: 0x060021FE RID: 8702 RVA: 0x000211B7 File Offset: 0x0001F3B7
		private void #5ab(object #Ge, EventArgs #He)
		{
			this.#U9();
			this.LeftPanel.#8hb(this.#0ab());
			this.#gab();
		}

		// Token: 0x060021FF RID: 8703 RVA: 0x000C9E88 File Offset: 0x000C8088
		private void #6ab(object #Ge, EventArgs #He)
		{
			this.#U9();
			this.#gbb();
			this.#sab();
			#mib #mib = this.LeftPanel;
			IModelEditorViewport modelEditorViewport = this.ActivePresenter;
			#mib.#aib((modelEditorViewport != null) ? modelEditorViewport.DiagramPresenter : null, false, false);
			this.LeftPanel.#8hb(this.#0ab());
			this.#vh();
			this.#gab();
			IModelEditorViewport modelEditorViewport2 = this.ActivePresenter;
			if (modelEditorViewport2 == null)
			{
				return;
			}
			modelEditorViewport2.#Ed();
		}

		// Token: 0x06002200 RID: 8704 RVA: 0x000C9F00 File Offset: 0x000C8100
		private void #7ab(object #Ge, #pkb #He)
		{
			DiagramsManager.#v0h #v0h = new DiagramsManager.#v0h();
			#v0h.#a = this;
			#v0h.#b = #He;
			if (!this.#tab(#Ge))
			{
				return;
			}
			try
			{
				this.LeftPanel.#dib(#v0h.#b.Value);
				this.#gbb();
				this.#lbb();
				if (!this.#v)
				{
					this.#mbb(new Action<IDiagramPresenterViewModel>(#v0h.#m5b));
					#mib #mib = this.LeftPanel;
					IModelEditorViewport modelEditorViewport = this.ActivePresenter;
					#mib.#aib((modelEditorViewport != null) ? modelEditorViewport.DiagramPresenter : null, false, false);
				}
			}
			catch (Exception #ob)
			{
				this.#a.ExceptionHandler.#3Ab(#ob);
			}
		}

		// Token: 0x06002201 RID: 8705 RVA: 0x000C9FD0 File Offset: 0x000C81D0
		private void #8ab(object #Ge, #pkb #He)
		{
			DiagramsManager.#5Dg #5Dg = new DiagramsManager.#5Dg();
			#5Dg.#a = this;
			#5Dg.#b = #He;
			if (!this.#tab(#Ge))
			{
				return;
			}
			try
			{
				this.#lbb();
				this.LeftPanel.#cib(#5Dg.#b.Value);
				this.#gbb();
				if (!this.#v)
				{
					this.#mbb(new Action<IDiagramPresenterViewModel>(#5Dg.#o5b));
					#mib #mib = this.LeftPanel;
					IModelEditorViewport modelEditorViewport = this.ActivePresenter;
					#mib.#aib((modelEditorViewport != null) ? modelEditorViewport.DiagramPresenter : null, false, false);
				}
			}
			catch (Exception #ob)
			{
				this.#a.ExceptionHandler.#3Ab(#ob);
			}
		}

		// Token: 0x06002202 RID: 8706 RVA: 0x000211E2 File Offset: 0x0001F3E2
		private void #9ab(object #Ge, #pkb #He)
		{
			if (!this.#tab(#Ge))
			{
				return;
			}
			if (this.#v)
			{
				return;
			}
			this.LeftPanel.#dib(#He.Value);
			this.#gab();
		}

		// Token: 0x06002203 RID: 8707 RVA: 0x0002121A File Offset: 0x0001F41A
		private void #abb(object #Ge, #pkb #He)
		{
			if (!this.#tab(#Ge))
			{
				return;
			}
			if (this.#v)
			{
				return;
			}
			this.LeftPanel.#cib(#He.Value);
			this.#gab();
		}

		// Token: 0x06002204 RID: 8708 RVA: 0x00021252 File Offset: 0x0001F452
		private void #bbb(object #Ge, #ie #He)
		{
			this.#U9();
			this.#lab();
			this.#gab();
		}

		// Token: 0x06002205 RID: 8709 RVA: 0x000CA0A0 File Offset: 0x000C82A0
		private void #cbb(object #Ge, #lkb #He)
		{
			if (this.Context.IsLoadingData)
			{
				this.#mbb(new Action<IDiagramPresenterViewModel>(this.#EVh));
				return;
			}
			try
			{
				this.#lbb();
				this.#mbb(new Action<IDiagramPresenterViewModel>(this.#FVh));
				#mib #mib = this.LeftPanel;
				IModelEditorViewport modelEditorViewport = this.ActivePresenter;
				#mib.#aib((modelEditorViewport != null) ? modelEditorViewport.DiagramPresenter : null, false, false);
			}
			catch (Exception #ob)
			{
				this.#a.ExceptionHandler.#3Ab(#ob);
			}
		}

		// Token: 0x06002206 RID: 8710 RVA: 0x000CA144 File Offset: 0x000C8344
		private void #dbb(object #Ge, #pkb #He)
		{
			DiagramsManager.#v5b #v5b = new DiagramsManager.#v5b();
			#v5b.#a = this;
			#v5b.#b = #He;
			if (this.Context.IsLoadingData)
			{
				this.#mbb(new Action<IDiagramPresenterViewModel>(#v5b.#q5b));
				return;
			}
			try
			{
				this.#lbb();
				if (!this.#v)
				{
					this.#mbb(new Action<IDiagramPresenterViewModel>(#v5b.#r5b));
					this.#gbb();
					#mib #mib = this.LeftPanel;
					IModelEditorViewport modelEditorViewport = this.ActivePresenter;
					#mib.#aib((modelEditorViewport != null) ? modelEditorViewport.DiagramPresenter : null, false, false);
				}
			}
			catch (Exception #ob)
			{
				this.#a.ExceptionHandler.#3Ab(#ob);
			}
		}

		// Token: 0x06002207 RID: 8711 RVA: 0x000CA214 File Offset: 0x000C8414
		private void #ebb(object #Ge, #pkb #He)
		{
			DiagramsManager.#w0h #w0h = new DiagramsManager.#w0h();
			#w0h.#a = #He;
			try
			{
				this.#lbb();
				if (!this.#v)
				{
					this.#mbb(new Action<IDiagramPresenterViewModel>(#w0h.#s5b));
					this.#gbb();
					#mib #mib = this.LeftPanel;
					IModelEditorViewport modelEditorViewport = this.ActivePresenter;
					#mib.#aib((modelEditorViewport != null) ? modelEditorViewport.DiagramPresenter : null, false, false);
				}
			}
			catch (Exception #ob)
			{
				this.#a.ExceptionHandler.#3Ab(#ob);
			}
		}

		// Token: 0x06002208 RID: 8712 RVA: 0x000CA2B8 File Offset: 0x000C84B8
		private void #fbb(object #Ge, EventArgs #He)
		{
			try
			{
				this.#hbb(true);
			}
			catch (Exception #ob)
			{
				this.#a.ExceptionHandler.#3Ab(#ob);
			}
		}

		// Token: 0x06002209 RID: 8713 RVA: 0x000CA2FC File Offset: 0x000C84FC
		private void #gbb()
		{
			foreach (IModelEditorViewport modelEditorViewport in this.#e.Viewports.OfType<IModelEditorViewport>().Where(new Func<IModelEditorViewport, bool>(DiagramsManager.<>c.<>9.#m0h)))
			{
				IDiagramPresenterViewModel diagramPresenterViewModel = modelEditorViewport.DiagramPresenter;
				if (diagramPresenterViewModel != null)
				{
					#aMb #aMb = modelEditorViewport.EditorContext.ViewportOptions;
					#aMb.DefinedDiagram3DCutType = diagramPresenterViewModel.DefinedDiagram3DCutType;
					#aMb.Diagram2DType = diagramPresenterViewModel.Diagram2DType;
					#aMb.DiagramPresenterType = diagramPresenterViewModel.PresenterType;
					if (diagramPresenterViewModel.PresenterType == DiagramPresenterType.#b)
					{
						#aMb.DiagramParameter = ((diagramPresenterViewModel.Diagram2DType == Diagram2DType.DiagramMM) ? diagramPresenterViewModel.AxialLoad : diagramPresenterViewModel.Angle);
					}
					else
					{
						Diagram3DCutType diagram3DCutType = diagramPresenterViewModel.Diagram3DCutType;
						if (diagram3DCutType != Diagram3DCutType.#b)
						{
							if (diagram3DCutType == Diagram3DCutType.#c)
							{
								#aMb.DiagramParameter = diagramPresenterViewModel.Angle;
							}
						}
						else
						{
							#aMb.DiagramParameter = diagramPresenterViewModel.AxialLoad;
						}
					}
				}
			}
		}

		// Token: 0x0600220A RID: 8714 RVA: 0x000CA428 File Offset: 0x000C8628
		private void #hbb(bool #ibb = true)
		{
			DiagramsManager.#x0h #x0h = new DiagramsManager.#x0h();
			if (!this.AreSolveResultsAvailable)
			{
				return;
			}
			#x0h.#a = this.#f;
			if (#x0h.#a == null)
			{
				return;
			}
			IList<IDiagramPresenterViewModel> list = this.#0ab();
			if (!list.Any<IDiagramPresenterViewModel>())
			{
				return;
			}
			this.#jbb();
			this.#lbb();
			this.#mbb(new Action<IDiagramPresenterViewModel>(#x0h.#u5b));
			if (#ibb)
			{
				#mib #mib = this.LeftPanel;
				IModelEditorViewport modelEditorViewport = this.ActivePresenter;
				#mib.#aib((modelEditorViewport != null) ? modelEditorViewport.DiagramPresenter : null, false, false);
				this.LeftPanel.#8hb(list);
			}
		}

		// Token: 0x0600220B RID: 8715 RVA: 0x000CA4D4 File Offset: 0x000C86D4
		private void #jbb()
		{
			if (!this.AreSolveResultsAvailable)
			{
				return;
			}
			#lte #lte = this.#f;
			if (#lte == null)
			{
				return;
			}
			List<double> list = new List<double>();
			if (#lte.Output.BiaxialFactoredLoads.Count > 0)
			{
				list.AddRange(#lte.Output.BiaxialFactoredLoads.Select(new Func<BiaxialFactoredLoad, double>(DiagramsManager.<>c.<>9.#n0h)));
			}
			if (#lte.Output.BiaxialServiceLoads.Count > 0)
			{
				list.AddRange(#lte.Output.BiaxialServiceLoads.Select(new Func<BiaxialServiceLoad, double>(DiagramsManager.<>c.<>9.#o0h)));
			}
			if (#lte.Output.UniaxialFactoredLoads.Count > 0)
			{
				list.AddRange(#lte.Output.UniaxialFactoredLoads.Select(new Func<UniaxialFactoredLoad, double>(DiagramsManager.<>c.<>9.#p0h)));
			}
			if (#lte.Output.UniaxialServiceLoads.Count > 0)
			{
				list.AddRange(#lte.Output.UniaxialServiceLoads.Select(new Func<UniaxialServiceLoad, double>(DiagramsManager.<>c.<>9.#q0h)));
			}
			#y0e #y0e = #lte.Output.NominalInteractionDiagram;
			float? num;
			if (#y0e == null)
			{
				num = null;
			}
			else
			{
				BiCurve[] array = #y0e.BiCurve;
				if (array == null)
				{
					num = null;
				}
				else
				{
					num = new float?(array.Min(new Func<BiCurve, float>(DiagramsManager.<>c.<>9.#r0h)));
				}
			}
			float? num2 = num;
			float? num3;
			if (num2 == null)
			{
				#y0e #y0e2 = #lte.Output.NominalInteractionDiagram;
				if (#y0e2 == null)
				{
					num3 = null;
				}
				else
				{
					UniCurve[] array2 = #y0e2.UniCurve;
					if (array2 == null)
					{
						num3 = null;
					}
					else
					{
						num3 = new float?(array2.Min(new Func<UniCurve, float>(DiagramsManager.<>c.<>9.#s0h)));
					}
				}
			}
			else
			{
				num3 = num2;
			}
			float? num4 = num3;
			double num5 = (list.Count > 0) ? list.Min() : 0.0;
			double num6 = (num4 != null) ? Math.Min((double)num4.Value, num5) : num5;
			#y0e #y0e3 = #lte.Output.NominalInteractionDiagram;
			float? num7;
			if (#y0e3 == null)
			{
				num7 = null;
			}
			else
			{
				BiCurve[] array3 = #y0e3.BiCurve;
				if (array3 == null)
				{
					num7 = null;
				}
				else
				{
					num7 = new float?(array3.Max(new Func<BiCurve, float>(DiagramsManager.<>c.<>9.#t0h)));
				}
			}
			num2 = num7;
			float? num8;
			if (num2 == null)
			{
				#y0e #y0e4 = #lte.Output.NominalInteractionDiagram;
				if (#y0e4 == null)
				{
					num8 = null;
				}
				else
				{
					UniCurve[] array4 = #y0e4.UniCurve;
					if (array4 == null)
					{
						num8 = null;
					}
					else
					{
						num8 = new float?(array4.Max(new Func<UniCurve, float>(DiagramsManager.<>c.<>9.#u0h)));
					}
				}
			}
			else
			{
				num8 = num2;
			}
			float? num9 = num8;
			double num10 = (list.Count > 0) ? list.Max() : 0.0;
			double num11 = (num9 != null) ? Math.Max((double)num9.Value, num10) : num10;
			if (this.LeftPanel.SelectedAxialLoadText < num6 || this.LeftPanel.SelectedAxialLoadText > num11)
			{
				this.LeftPanel.#cib(0.0);
			}
		}

		// Token: 0x0600220C RID: 8716 RVA: 0x000CA864 File Offset: 0x000C8A64
		private void #kbb()
		{
			this.LeftPanel.AxialLoadChanged += this.#ebb;
			this.LeftPanel.AngleChanged += this.#dbb;
			this.LeftPanel.LoadSelectionChanged += this.#cbb;
			this.LeftPanel.FiltersChanged += this.#fbb;
		}

		// Token: 0x0600220D RID: 8717 RVA: 0x000CA8DC File Offset: 0x000C8ADC
		private void #lbb()
		{
			try
			{
				DiagramsManager.#y0h #y0h = new DiagramsManager.#y0h();
				this.Context.SelectedLoads.Clear();
				#y0h.#a = new List<SelectedLoadData>();
				GridDataRowCore gridDataRowCore = this.LeftPanel.NavigationTable.Renderer.RadGridView.SelectedItem as GridDataRowCore;
				gridDataRowCore = (gridDataRowCore ?? (this.LeftPanel.NavigationTable.Renderer.RadGridView.SelectedItems.FirstOrDefault<object>() as GridDataRowCore));
				LoadPointRowMetadata loadPointRowMetadata = (gridDataRowCore != null) ? (gridDataRowCore.Metadata as LoadPointRowMetadata) : null;
				if (loadPointRowMetadata != null)
				{
					#y0h.#a.Add(new SelectedLoadData
					{
						MomentY = loadPointRowMetadata.MomentY,
						AxialForce = loadPointRowMetadata.AxialLoad,
						MomentX = loadPointRowMetadata.MomentX,
						Number = loadPointRowMetadata.Number
					});
				}
				this.Context.SelectedLoads.AddRange(#y0h.#a);
				this.#mbb(new Action<IDiagramPresenterViewModel>(#y0h.#w5b));
			}
			catch (Exception #ob)
			{
				this.#a.ExceptionHandler.#3Ab(#ob);
			}
		}

		// Token: 0x0600220E RID: 8718 RVA: 0x000CAA24 File Offset: 0x000C8C24
		private void #mbb(Action<IDiagramPresenterViewModel> #yf)
		{
			IList<IDiagramPresenterViewModel> list = this.#0ab();
			foreach (IDiagramPresenterViewModel obj in list)
			{
				#yf(obj);
			}
		}

		// Token: 0x0600220F RID: 8719 RVA: 0x00021272 File Offset: 0x0001F472
		[CompilerGenerated]
		private void #AVh(IDiagramPresenterViewModel #uab)
		{
			if (#uab.PresenterType == DiagramPresenterType.#b)
			{
				this.Context.OpenedDiagramTypes.Add(#uab.Diagram2DType);
			}
		}

		// Token: 0x06002210 RID: 8720 RVA: 0x0002129F File Offset: 0x0001F49F
		[CompilerGenerated]
		private void #BVh()
		{
			this.#mbb(new Action<IDiagramPresenterViewModel>(DiagramsManager.<>c.<>9.#a0h));
		}

		// Token: 0x06002211 RID: 8721 RVA: 0x000212CE File Offset: 0x0001F4CE
		[CompilerGenerated]
		private void #CVh()
		{
			this.#mbb(new Action<IDiagramPresenterViewModel>(this.#DVh));
		}

		// Token: 0x06002212 RID: 8722 RVA: 0x000CAA80 File Offset: 0x000C8C80
		[CompilerGenerated]
		private void #DVh(IDiagramPresenterViewModel #uab)
		{
			if (#uab.PresenterHost.Pane.IsHidden)
			{
				#uab.PresenterHost.Pane.IsHidden = false;
			}
			#uab.IsReportSourceValid = this.Context.IsReportSourceValid;
		}

		// Token: 0x06002213 RID: 8723 RVA: 0x000212EE File Offset: 0x0001F4EE
		[CompilerGenerated]
		private void #EVh(IDiagramPresenterViewModel #uab)
		{
			#uab.#Sdb(this.LeftPanel.SelectedAxialLoadText, this.LeftPanel.SelectedAngleText);
		}

		// Token: 0x06002214 RID: 8724 RVA: 0x00021318 File Offset: 0x0001F518
		[CompilerGenerated]
		private void #FVh(IDiagramPresenterViewModel #uab)
		{
			#uab.#Pdb(this.LeftPanel.SelectedAngleText);
			#uab.#Rdb(this.LeftPanel.SelectedAxialLoadText);
		}

		// Token: 0x04000D6C RID: 3436
		private readonly IExtendedServices #a;

		// Token: 0x04000D6D RID: 3437
		private readonly #0gb #b;

		// Token: 0x04000D6E RID: 3438
		private readonly #zJ #c;

		// Token: 0x04000D6F RID: 3439
		private readonly #qW #d;

		// Token: 0x04000D70 RID: 3440
		private readonly #ud #e;

		// Token: 0x04000D71 RID: 3441
		private #lte #f;

		// Token: 0x04000D72 RID: 3442
		private DateTime? #g;

		// Token: 0x04000D73 RID: 3443
		private readonly TimeSpan #h = TimeSpan.FromMilliseconds(300.0);

		// Token: 0x04000D74 RID: 3444
		private bool #i;

		// Token: 0x04000D75 RID: 3445
		private #BLb #j;

		// Token: 0x04000D76 RID: 3446
		[CompilerGenerated]
		private readonly #mib #k;

		// Token: 0x04000D77 RID: 3447
		[CompilerGenerated]
		private readonly #tbb #l;

		// Token: 0x04000D78 RID: 3448
		[CompilerGenerated]
		private readonly DelegateCommand #m;

		// Token: 0x04000D79 RID: 3449
		[CompilerGenerated]
		private readonly DelegateCommand #n;

		// Token: 0x04000D7A RID: 3450
		[CompilerGenerated]
		private readonly DelegateCommand #o;

		// Token: 0x04000D7B RID: 3451
		[CompilerGenerated]
		private readonly DelegateCommand #p;

		// Token: 0x04000D7C RID: 3452
		[CompilerGenerated]
		private readonly DelegateCommand #q;

		// Token: 0x04000D7D RID: 3453
		[CompilerGenerated]
		private readonly DelegateCommand #r;

		// Token: 0x04000D7E RID: 3454
		[CompilerGenerated]
		private readonly DelegateCommand #s;

		// Token: 0x04000D7F RID: 3455
		[CompilerGenerated]
		private readonly DelegateCommand #t;

		// Token: 0x04000D80 RID: 3456
		[CompilerGenerated]
		private readonly DelegateCommand #u;

		// Token: 0x04000D81 RID: 3457
		private bool #v;

		// Token: 0x04000D82 RID: 3458
		private string #w;

		// Token: 0x04000D83 RID: 3459
		private LoadType? #x;

		// Token: 0x04000D84 RID: 3460
		private ConsideredAxis? #y;

		// Token: 0x04000D85 RID: 3461
		private #lte #z;

		// Token: 0x020003CB RID: 971
		private struct #R4b
		{
			// Token: 0x17000BDE RID: 3038
			// (get) Token: 0x06002215 RID: 8725 RVA: 0x00021348 File Offset: 0x0001F548
			// (set) Token: 0x06002216 RID: 8726 RVA: 0x00021354 File Offset: 0x0001F554
			public bool Any2DPM { readonly get; set; }

			// Token: 0x17000BDF RID: 3039
			// (get) Token: 0x06002217 RID: 8727 RVA: 0x00021365 File Offset: 0x0001F565
			// (set) Token: 0x06002218 RID: 8728 RVA: 0x00021371 File Offset: 0x0001F571
			public bool Any2DMM { readonly get; set; }

			// Token: 0x17000BE0 RID: 3040
			// (get) Token: 0x06002219 RID: 8729 RVA: 0x00021382 File Offset: 0x0001F582
			// (set) Token: 0x0600221A RID: 8730 RVA: 0x0002138E File Offset: 0x0001F58E
			public bool Any3DPM { readonly get; set; }

			// Token: 0x17000BE1 RID: 3041
			// (get) Token: 0x0600221B RID: 8731 RVA: 0x0002139F File Offset: 0x0001F59F
			// (set) Token: 0x0600221C RID: 8732 RVA: 0x000213AB File Offset: 0x0001F5AB
			public bool Any3DMM { readonly get; set; }

			// Token: 0x17000BE2 RID: 3042
			// (get) Token: 0x0600221D RID: 8733 RVA: 0x000213BC File Offset: 0x0001F5BC
			// (set) Token: 0x0600221E RID: 8734 RVA: 0x000213C8 File Offset: 0x0001F5C8
			public bool NoViewportsCreated { readonly get; set; }

			// Token: 0x04000D86 RID: 3462
			[CompilerGenerated]
			private bool #a;

			// Token: 0x04000D87 RID: 3463
			[CompilerGenerated]
			private bool #b;

			// Token: 0x04000D88 RID: 3464
			[CompilerGenerated]
			private bool #c;

			// Token: 0x04000D89 RID: 3465
			[CompilerGenerated]
			private bool #d;

			// Token: 0x04000D8A RID: 3466
			[CompilerGenerated]
			private bool #e;
		}

		// Token: 0x020003CD RID: 973
		[CompilerGenerated]
		private sealed class #3Dg
		{
			// Token: 0x0600223A RID: 8762 RVA: 0x000CAB14 File Offset: 0x000C8D14
			internal void #j5b()
			{
				this.#a.LeftPanel.DoNotRaiseSelectionEvents = true;
				try
				{
					this.#a.LeftPanel.#hz(this.#b, this.#b.FailureSurface);
					double num = this.#a.LeftPanel.View.ActualWidth;
					if (double.IsNaN(num) || num < 10.0)
					{
						num = 390.0;
					}
					this.#a.LeftPanel.#eib(num);
					Action action;
					if ((action = this.#d) == null)
					{
						action = (this.#d = new Action(this.#k5b));
					}
					LayoutHelper.BeginInvokeOnApplicationThread(action);
				}
				catch (Exception #ob)
				{
					this.#a.Context.IsLoadingData = false;
					this.#a.#a.ExceptionHandler.#3Ab(#ob);
				}
				finally
				{
					this.#a.#v = false;
					this.#a.LeftPanel.DoNotRaiseSelectionEvents = false;
					this.#a.#vh();
				}
			}

			// Token: 0x0600223B RID: 8763 RVA: 0x000CAC4C File Offset: 0x000C8E4C
			internal void #k5b()
			{
				try
				{
					this.#a.#Wab(this.#c, this.#a.#i);
					this.#a.#i = false;
				}
				catch (Exception #ob)
				{
					this.#a.Context.IsLoadingData = false;
					this.#a.#a.ExceptionHandler.#3Ab(#ob);
				}
				this.#a.#vh();
			}

			// Token: 0x04000DA4 RID: 3492
			public DiagramsManager #a;

			// Token: 0x04000DA5 RID: 3493
			public #lte #b;

			// Token: 0x04000DA6 RID: 3494
			public #7z #c;

			// Token: 0x04000DA7 RID: 3495
			public Action #d;
		}

		// Token: 0x020003CE RID: 974
		[CompilerGenerated]
		private sealed class #v0h
		{
			// Token: 0x0600223D RID: 8765 RVA: 0x000CACD4 File Offset: 0x000C8ED4
			internal void #m5b(IDiagramPresenterViewModel #uab)
			{
				IModelEditorViewport modelEditorViewport = this.#a.ActivePresenter;
				if (((modelEditorViewport != null) ? modelEditorViewport.DiagramPresenter : null) == #uab)
				{
					#uab.Angle = this.#b.Value;
					return;
				}
				#uab.#Pdb(this.#b.Value);
			}

			// Token: 0x04000DA8 RID: 3496
			public DiagramsManager #a;

			// Token: 0x04000DA9 RID: 3497
			public #pkb #b;
		}

		// Token: 0x020003CF RID: 975
		[CompilerGenerated]
		private sealed class #5Dg
		{
			// Token: 0x0600223F RID: 8767 RVA: 0x000CAD2C File Offset: 0x000C8F2C
			internal void #o5b(IDiagramPresenterViewModel #uab)
			{
				IModelEditorViewport modelEditorViewport = this.#a.ActivePresenter;
				if (((modelEditorViewport != null) ? modelEditorViewport.DiagramPresenter : null) == #uab)
				{
					#uab.AxialLoad = this.#b.Value;
					return;
				}
				#uab.#Rdb(this.#b.Value);
			}

			// Token: 0x04000DAA RID: 3498
			public DiagramsManager #a;

			// Token: 0x04000DAB RID: 3499
			public #pkb #b;
		}

		// Token: 0x020003D0 RID: 976
		[CompilerGenerated]
		private sealed class #v5b
		{
			// Token: 0x06002241 RID: 8769 RVA: 0x00021519 File Offset: 0x0001F719
			internal void #q5b(IDiagramPresenterViewModel #uab)
			{
				#uab.#Sdb(this.#a.LeftPanel.SelectedAxialLoadText, this.#a.LeftPanel.SelectedAngleText);
			}

			// Token: 0x06002242 RID: 8770 RVA: 0x0002154D File Offset: 0x0001F74D
			internal void #r5b(IDiagramPresenterViewModel #uab)
			{
				#uab.#Pdb(this.#b.Value);
			}

			// Token: 0x04000DAC RID: 3500
			public DiagramsManager #a;

			// Token: 0x04000DAD RID: 3501
			public #pkb #b;
		}

		// Token: 0x020003D1 RID: 977
		[CompilerGenerated]
		private sealed class #w0h
		{
			// Token: 0x06002244 RID: 8772 RVA: 0x0002156C File Offset: 0x0001F76C
			internal void #s5b(IDiagramPresenterViewModel #Rf)
			{
				#Rf.#Rdb(this.#a.Value);
			}

			// Token: 0x04000DAE RID: 3502
			public #pkb #a;
		}

		// Token: 0x020003D2 RID: 978
		[CompilerGenerated]
		private sealed class #x0h
		{
			// Token: 0x06002246 RID: 8774 RVA: 0x0002158B File Offset: 0x0001F78B
			internal void #u5b(IDiagramPresenterViewModel #uab)
			{
				#uab.#hz(this.#a);
			}

			// Token: 0x04000DAF RID: 3503
			public #lte #a;
		}

		// Token: 0x020003D3 RID: 979
		[CompilerGenerated]
		private sealed class #y0h
		{
			// Token: 0x06002248 RID: 8776 RVA: 0x000215A5 File Offset: 0x0001F7A5
			internal void #w5b(IDiagramPresenterViewModel #uab)
			{
				#uab.#Mdb(this.#a);
			}

			// Token: 0x04000DB0 RID: 3504
			public List<SelectedLoadData> #a;
		}

		// Token: 0x020003D4 RID: 980
		[CompilerGenerated]
		private sealed class #K5b
		{
			// Token: 0x0600224A RID: 8778 RVA: 0x000CAD84 File Offset: 0x000C8F84
			internal void #S4b()
			{
				IModelEditorViewport modelEditorViewport = this.#a as IModelEditorViewport;
				if (modelEditorViewport != null)
				{
					this.#b.#vab(modelEditorViewport, true);
					this.#b.#Qab(modelEditorViewport.DiagramPresenter);
					this.#b.#sab();
				}
			}

			// Token: 0x04000DB1 RID: 3505
			public IViewport #a;

			// Token: 0x04000DB2 RID: 3506
			public DiagramsManager #b;
		}

		// Token: 0x020003D5 RID: 981
		[CompilerGenerated]
		private sealed class #K9c
		{
			// Token: 0x0600224C RID: 8780 RVA: 0x000CADD8 File Offset: 0x000C8FD8
			internal void #g5b()
			{
				if (this.#a)
				{
					this.#b.#Nd(this.#c.#f);
				}
				this.#c.#vab(this.#b, false);
				this.#c.#gab();
			}

			// Token: 0x04000DB3 RID: 3507
			public bool #a;

			// Token: 0x04000DB4 RID: 3508
			public IModelEditorViewport #b;

			// Token: 0x04000DB5 RID: 3509
			public DiagramsManager #c;
		}

		// Token: 0x020003D6 RID: 982
		[CompilerGenerated]
		private sealed class #VTb
		{
			// Token: 0x0600224E RID: 8782 RVA: 0x000CAE2C File Offset: 0x000C902C
			internal bool #i5b(IDiagramPresenterViewModel #Rf)
			{
				if (#Rf.PresenterType != this.#a.PresenterType)
				{
					return false;
				}
				if (#Rf.PresenterType == DiagramPresenterType.#a)
				{
					Diagram3DCutType diagram3DCutType = #Rf.Diagram3DCutType;
					Diagram3DCutType? cutType = this.#a.CutType;
					if (diagram3DCutType == cutType.GetValueOrDefault() & cutType != null)
					{
						return true;
					}
				}
				if (#Rf.PresenterType == DiagramPresenterType.#b)
				{
					Diagram2DType diagram2DType = #Rf.Diagram2DType;
					Diagram2DType? diagram2DType2 = this.#a.Diagram2DType;
					return diagram2DType == diagram2DType2.GetValueOrDefault() & diagram2DType2 != null;
				}
				return false;
			}

			// Token: 0x04000DB6 RID: 3510
			public ActivateDiagramParameters #a;
		}
	}
}
