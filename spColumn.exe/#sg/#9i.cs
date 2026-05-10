using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using #1b;
using #3Qb;
using #3wb;
using #5Ve;
using #6re;
using #7hc;
using #8Cc;
using #9I;
using #APb;
using #c1d;
using #eU;
using #fX;
using #gCc;
using #hg;
using #HI;
using #hPd;
using #Hte;
using #hUh;
using #IDc;
using #IW;
using #kB;
using #lH;
using #OT;
using #pQb;
using #qJ;
using #qPb;
using #rCe;
using #RJb;
using #S9;
using #tFb;
using #UYd;
using #v1c;
using #Wse;
using #xBe;
using #Xc;
using #zW;
using Alphaleonis.Win32.Filesystem;
using devDept.Eyeshot;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.DTO;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.AppManager.Column.Storage.ImportExport;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.GUI.Framework.Services;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Application.API;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Units;
using StructurePoint.CoreAssets.Units.UnitSets;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Editor.Core;
using StructurePoint.Products.Column.Editor.Diagrams;
using StructurePoint.Products.Column.Editor.Project;
using StructurePoint.Products.Column.FailureSurface;
using StructurePoint.Products.Column.FailureSurface.ViewModels;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Model.Entities.Units;
using StructurePoint.Products.Column.Services;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Viewports.API;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Docking;

namespace #sg
{
	// Token: 0x020000DB RID: 219
	internal sealed class #9i : #HH<#6b>, IViewModel<#6b>, INotifyPropertyChanged, IViewModel, #II, #dDc
	{
		// Token: 0x060006BF RID: 1727 RVA: 0x0000B118 File Offset: 0x00009318
		private void #0g(object #Ge, EventArgs #He)
		{
			this.#vh();
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x0000B118 File Offset: 0x00009318
		private void #1g(object #Ge, #JCc #He)
		{
			this.#vh();
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x0000B118 File Offset: 0x00009318
		private void #2g(object #Ge, #yd #He)
		{
			this.#vh();
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x0008DEE8 File Offset: 0x0008C0E8
		private void #3g()
		{
			this.#m.StateChanged += this.#0g;
			base.UndoManager.UndoStackChanged += this.#1g;
			this.#i.ActiveViewportChanged += this.#2g;
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x0008DF48 File Offset: 0x0008C148
		private #qCe #4g()
		{
			#lte #lte = this.#h.Model;
			return new #qCe
			{
				Model = #lte,
				Diagram3D = #lte.FailureSurface
			};
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x0008DF88 File Offset: 0x0008C188
		private bool #5g(object #Vg)
		{
			ExportDiagramType #2bb = (ExportDiagramType)#Vg;
			return this.#m.State == #tJ.#b && base.Project.Model.Options.ConsideredAxis == ConsideredAxis.Both && FailureSurfaceViewModel.#Ffb(#2bb, this.#4g());
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x0008DFDC File Offset: 0x0008C1DC
		private void #6g(object #Vg)
		{
			#9i.#ITb #ITb = new #9i.#ITb();
			#ITb.#a = this;
			#ITb.#b = #Vg;
			if (!base.DialogService.#ABf())
			{
				return;
			}
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(#ITb.#zUb));
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x0008E02C File Offset: 0x0008C22C
		private void #7g(object #Vg)
		{
			try
			{
				ExportDiagramType #2bb = (ExportDiagramType)#Vg;
				#qCe #qCe = this.#4g();
				bool flag = this.#k.#LAe(#qCe.Model, #qCe, #2bb);
				if (flag)
				{
					base.DialogService.#od(Strings.StringDiagramExportedSuccesfully.#z2d(), MessageBoxButton.OK, MessageBoxImage.Asterisk);
				}
			}
			catch (Exception #ob)
			{
				this.#a.ExceptionHandler.#3Ab(#ob);
			}
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x0008E0AC File Offset: 0x0008C2AC
		private bool #8g(object #Vg)
		{
			bool flag = this.ScopesManager.Diagrams.IsActive && this.#j.DiagramsViewports.Docking.Visibility == Visibility.Visible;
			IModelEditorViewport modelEditorViewport = this.#i.ActiveViewport as IModelEditorViewport;
			return flag && this.#m.State == #tJ.#b && ((modelEditorViewport != null) ? modelEditorViewport.DiagramPresenter : null) != null && modelEditorViewport.DiagramPresenter.PresenterType == DiagramPresenterType.#b;
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x0008E144 File Offset: 0x0008C344
		private void #9g(object #Vg)
		{
			if (!base.DialogService.#ABf())
			{
				return;
			}
			IModelEditorViewport modelEditorViewport = this.#i.ActiveViewport as IModelEditorViewport;
			if (modelEditorViewport != null)
			{
				IDiagramPresenterViewModel diagramPresenterViewModel = modelEditorViewport.DiagramPresenter;
				if (diagramPresenterViewModel == null)
				{
					return;
				}
				DelegateCommandAdapter delegateCommandAdapter = diagramPresenterViewModel.ExportDiagramCommand;
				if (delegateCommandAdapter == null)
				{
					return;
				}
				delegateCommandAdapter.Execute(#Vg);
			}
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x0008E19C File Offset: 0x0008C39C
		private bool #ah(object #Vg)
		{
			bool flag = this.#a.Project.Model.Shapes.Any<ShapeModel>();
			SectionType sectionType = this.#a.Project.Model.Options.SectionType;
			return sectionType == SectionType.Rectangle || sectionType == SectionType.Circle || (sectionType == SectionType.Irregular && flag);
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x0008E1FC File Offset: 0x0008C3FC
		private void #bh(object #Vg)
		{
			if (!base.DialogService.#ABf())
			{
				return;
			}
			if (this.#B.#wWh(false, false, true))
			{
				string #SSc = base.DialogService.#5Sc(#Phc.#3hc(107383563).#z2d(), Strings.StringPleaseFixTheErrorsInTheLeftPanel.#z2d());
				base.DialogService.#qn(base.DialogService.ActiveWindow, #SSc);
				return;
			}
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#Ci));
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x00003375 File Offset: 0x00001575
		private bool #ch(object #Vg)
		{
			return true;
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x0008E288 File Offset: 0x0008C488
		private void #dh(object #Vg)
		{
			#9i.#BUb #BUb = new #9i.#BUb();
			#BUb.#a = this;
			if (!base.DialogService.#ABf())
			{
				return;
			}
			if (#Vg is SectionImportExportType)
			{
				#BUb.#b = (SectionImportExportType)#Vg;
				if (this.#B.#wWh(false, true, true))
				{
					string text;
					switch (#BUb.#b)
					{
					case SectionImportExportType.Section:
						text = Strings.StringCannotExportSection.#z2d();
						break;
					case SectionImportExportType.OnlyGeometry:
						text = Strings.StringCannotExportGeometry.#z2d();
						break;
					case SectionImportExportType.OnlyReinforcement:
						text = Strings.StringCannotExportReinforcement.#z2d();
						break;
					default:
						throw new ArgumentOutOfRangeException();
					}
					text = base.DialogService.#5Sc(text, Strings.StringPleaseFixTheErrorsInTheLeftPanel.#z2d());
					base.DialogService.#qn(base.DialogService.ActiveWindow, text);
					return;
				}
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(#BUb.#AUb));
			}
		}

		// Token: 0x060006CD RID: 1741 RVA: 0x0008E380 File Offset: 0x0008C580
		private bool #eh(object #Vg)
		{
			LoadType loadType = base.Project.Model.Options.ActiveLoad;
			return this.#y.#LT(loadType) && ((loadType == LoadType.Factored && base.Project.Model.FactoredLoads.Any<FactoredLoad>()) || (loadType == LoadType.Service && base.Project.Model.ServiceLoads.Any<ServiceLoad>()));
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x0000B128 File Offset: 0x00009328
		private void #fh(object #Vg)
		{
			if (!base.DialogService.#ABf())
			{
				return;
			}
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#Di));
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x0000B156 File Offset: 0x00009356
		private bool #gh(object #Vg)
		{
			return this.#a.Project.Model.Options.ProblemType == ProblemType.Investigation;
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x0008E3F8 File Offset: 0x0008C5F8
		private void #hh(object #Vg)
		{
			#9i.#DUb #DUb = new #9i.#DUb();
			#DUb.#a = this;
			if (!base.DialogService.#ABf())
			{
				return;
			}
			if (#Vg is SectionImportExportType)
			{
				#DUb.#b = (SectionImportExportType)#Vg;
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(#DUb.#CUb));
			}
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x0008E454 File Offset: 0x0008C654
		private bool #ih(object #Vg)
		{
			if (#Vg is LoadsImportType)
			{
				LoadsImportType #8Q = (LoadsImportType)#Vg;
				return this.#z.#UT(#8Q);
			}
			return false;
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x0008E48C File Offset: 0x0008C68C
		private void #jh(object #Vg)
		{
			#9i.#HUb #HUb = new #9i.#HUb();
			#HUb.#a = #Vg;
			#HUb.#b = this;
			if (!base.DialogService.#ABf())
			{
				return;
			}
			#HUb.#c = this.#a.WindowLocator.#6();
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(#HUb.#EUb));
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x0000B181 File Offset: 0x00009381
		private bool #kh(object #Vg)
		{
			return base.Project.Model.Options.ProblemType == ProblemType.Investigation;
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x0000B1A7 File Offset: 0x000093A7
		private void #lh(object #Vg)
		{
			if (!base.DialogService.#ABf())
			{
				return;
			}
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#Ei));
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x0008E4F0 File Offset: 0x0008C6F0
		private void #mh()
		{
			this.#a.GuiController.IsBackstageOpen = false;
			this.#a.MessageBus.#QV();
			this.#a.Renderer.#9f(false, false);
			this.#a.Renderer.#bg();
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x0008E54C File Offset: 0x0008C74C
		public #9i(Lazy<#6b> #Ee, IExtendedServices #0c, #KI #aj, #MI #bj, #LI #cj, #vU #dj, #XV #ej, #BLb #fj, #nB #gj, #hLb #hj, #jg #ij, #gg #ze, #8I #jj, #vbb #kj, #rW #3c, #ud #lj, #vd #mj, #yBe #2c, #aJ #nj, #lB #oj, #zJ #pj, #oQb #qj, #qW #rj, #dLb #Zc, #JFb #sj, #yW #tj, #AW #uj, #GI #vj, IEditorService #wj, #DW #xj, #2wb #yj, #1V #zj, #HW #Aj, #JW #Bj, #KW #Cj, #AWh #eTh) : base(#Ee, #0c)
		{
			this.#a = #0c;
			if (#dj == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107383010));
			}
			this.#b = #dj;
			if (#ej == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107382981));
			}
			this.#c = #ej;
			this.#d = #gj;
			this.#e = #ij;
			this.#f = #ze;
			this.#g = #kj;
			this.#h = #3c;
			this.#i = #lj;
			this.#j = #mj;
			this.#k = #2c;
			this.#l = #oj;
			this.#m = #pj;
			this.#n = #qj;
			this.#o = #rj;
			this.#p = #Zc;
			this.#q = #sj;
			this.#r = #tj;
			this.#s = #uj;
			this.#t = #vj;
			this.#u = #wj;
			this.#v = #xj;
			this.#w = #yj;
			this.#x = #zj;
			this.#y = #Aj;
			this.#z = #Bj;
			this.#A = #Cj;
			this.#B = #eTh;
			this.#C = #jj;
			this.#D = #nj;
			if (#fj == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107382952));
			}
			this.#G = #fj;
			this.#H = #hj;
			if (#aj == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107382923));
			}
			this.#I = #aj;
			if (#bj == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107382914));
			}
			this.#J = #bj;
			if (#cj == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107382933));
			}
			this.#K = #cj;
			base.UndoManager.Owner = this;
			this.#g.ScopesManager = #fj;
			this.#L = new DelegateCommand(new Action<object>(this.#Rh));
			this.#b.LoadingProject += this.#Hh;
			base.Services.MessageBus.ProjectLoaded += this.#Gh;
			base.Services.MessageBus.SolveCompleted += this.#Ch;
			base.Services.UndoManager.CompositeActionCompleted += this.#Lh;
			this.#a.MessageBus.DisplayOptionsChanged += this.#Bh;
			this.#a.MessageBus.SettingsChanged += this.#Ah;
			this.EditorLeftPanel.PropertyChanged += this.#zh;
		}

		// Token: 0x1700030C RID: 780
		// (get) Token: 0x060006D7 RID: 1751 RVA: 0x0000B1D5 File Offset: 0x000093D5
		public #BLb ScopesManager { get; }

		// Token: 0x1700030D RID: 781
		// (get) Token: 0x060006D8 RID: 1752 RVA: 0x0000B1E1 File Offset: 0x000093E1
		public #hLb EditorLeftPanel { get; }

		// Token: 0x1700030E RID: 782
		// (get) Token: 0x060006D9 RID: 1753 RVA: 0x0000B1ED File Offset: 0x000093ED
		public #KI Ribbon { get; }

		// Token: 0x1700030F RID: 783
		// (get) Token: 0x060006DA RID: 1754 RVA: 0x0000B1F9 File Offset: 0x000093F9
		public #MI StatusBar { get; }

		// Token: 0x17000310 RID: 784
		// (get) Token: 0x060006DB RID: 1755 RVA: 0x0000B205 File Offset: 0x00009405
		public #LI StartPage { get; }

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x060006DC RID: 1756 RVA: 0x0000B211 File Offset: 0x00009411
		public DelegateCommand HandlePreviewShowDiagramsDockingCompassCommand { get; }

		// Token: 0x17000312 RID: 786
		// (get) Token: 0x060006DD RID: 1757 RVA: 0x0000B21D File Offset: 0x0000941D
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x060006DE RID: 1758 RVA: 0x0000B22D File Offset: 0x0000942D
		public void #od(IGenericLoaderWindow #th)
		{
			base.Logger.InstallExtension(this.#n);
			this.#Ed();
			this.#E = #th;
			base.View.Show();
		}

		// Token: 0x060006DF RID: 1759 RVA: 0x0008E7EC File Offset: 0x0008C9EC
		protected override void #uh(#6b #Ee)
		{
			base.#uh(#Ee);
			#Ee.Activated += this.#Jh;
			#Ee.DropOccurred += this.#Kh;
			#Ee.Loaded += this.#Ih;
			this.#e.Docking = base.View.EditorDocking;
			this.#e.OverlayFactory = this.#f;
			this.#i.Docking = base.View.DiagramsDocking;
			this.#i.OverlayFactory = this.#f;
			this.#j.EditorViewports = this.#e;
			this.#j.DiagramsViewports = this.#i;
			base.View.EditorDocking.Close += this.#Fh;
			base.View.DiagramsDocking.Close += this.#Eh;
			this.#e.ActiveViewportChanged += this.#xh;
			this.#i.ActiveViewportChanged += this.#xh;
			this.#j.ActiveDockingChanged += this.#wh;
			base.View.Closing += this.#Dh;
			base.View.PreviewKeyDown += this.#yh;
			this.#Yh();
			this.#Xh();
			this.#Nh();
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x0000B264 File Offset: 0x00009464
		protected override void #vh()
		{
			this.#a.Commands.#cg();
			base.#vh();
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x0000B118 File Offset: 0x00009318
		private void #wh(object #Ge, EventArgs #He)
		{
			this.#vh();
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x0000B118 File Offset: 0x00009318
		private void #xh(object #Ge, #yd #He)
		{
			this.#vh();
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x0008E984 File Offset: 0x0008CB84
		private void #yh(object #Ge, KeyEventArgs #He)
		{
			if (this.#a.GuiController.IsBackstageOpen && #He.Key == Key.Escape && base.View.IsActive)
			{
				this.#a.GuiController.IsBackstageOpen = false;
			}
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x0000B288 File Offset: 0x00009488
		private void #zh(object #Ge, PropertyChangedEventArgs #He)
		{
			base.View.UpdateLeftColumn(this.EditorLeftPanel.IsContentVisible);
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x0008E9D8 File Offset: 0x0008CBD8
		private void #Ah(object #Ge, EventArgs #He)
		{
			this.#j.EditorViewports.#wf();
			if (this.#j.EditorViewports.Docking.Visibility == Visibility.Visible)
			{
				this.#a.Renderer.#9f(true, false);
			}
			this.#g.#dab(true);
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x0008EA38 File Offset: 0x0008CC38
		private void #Bh(object #Ge, EventArgs #He)
		{
			this.#j.EditorViewports.#wf();
			if (this.#j.EditorViewports.Docking.Visibility == Visibility.Visible)
			{
				this.#a.Renderer.#9f(false, false);
			}
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x0008EA8C File Offset: 0x0008CC8C
		private void #Ch(object #Ge, #fW #He)
		{
			try
			{
				if (!#He.Success)
				{
					this.#g.#cab();
					this.#d.#3A();
				}
				else
				{
					bool flag = base.Project.Model.Options.ProblemType == ProblemType.Design && #He.Success;
					if (!#He.SilentNotification)
					{
						this.ScopesManager.#YKb(new DiagramsScopeActivationParameters());
						this.#j.#kd();
					}
					if (flag)
					{
						this.#o.#zQ();
						this.#a.Renderer.#9f(false, false);
					}
					#7z #ubb = #7z.#a;
					if (#He.SilentNotification)
					{
						#ubb = #7z.#c;
					}
					this.#g.#fab(this.#h.Model, #ubb);
					this.#d.#XA(false);
				}
			}
			catch (Exception #ob)
			{
				base.Services.ExceptionHandler.#3Ab(#ob);
			}
			finally
			{
				this.#vh();
			}
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x0008EBA8 File Offset: 0x0008CDA8
		private void #Dh(object #Ge, CancelEventArgs #He)
		{
			if (!base.Services.SystemCommands.IsExiting)
			{
				#He.Cancel = !this.#b.#FK().GetValueOrDefault();
			}
			if (!#He.Cancel)
			{
				this.#F = true;
			}
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x0008EC00 File Offset: 0x0008CE00
		private void #Eh(object #Ge, StateChangeEventArgs #He)
		{
			if (this.#F || this.#j.IsChangingArrangement)
			{
				return;
			}
			foreach (RadPane #Le in #He.Panes)
			{
				this.#i.#uf(#Le);
			}
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x0008EC74 File Offset: 0x0008CE74
		private void #Fh(object #Ge, StateChangeEventArgs #He)
		{
			if (this.#F)
			{
				return;
			}
			foreach (RadPane #Le in #He.Panes)
			{
				this.#e.#uf(#Le);
			}
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x0000B2AC File Offset: 0x000094AC
		private void #Gh(object #Ge, #cW #He)
		{
			if (#He.Model != null)
			{
				this.#wi(#He.Model, #He.IsInternalChange);
			}
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x0008ECDC File Offset: 0x0008CEDC
		private void #Hh(object #Ge, EventArgs #He)
		{
			base.Services.GuiController.IsBackstageOpen = false;
			bool flag = base.Services.GuiController.IsStartupPageOpen;
			base.Services.GuiController.IsStartupPageOpen = false;
			if (flag)
			{
				base.View.WindowState = WindowState.Maximized;
			}
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x0000B2D4 File Offset: 0x000094D4
		private void #Ih(object #Ge, RoutedEventArgs #He)
		{
			this.ScopesManager.#XKb(ProjectScopeActivationParameters.Default);
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x0008ED38 File Offset: 0x0008CF38
		private void #Jh(object #Ge, EventArgs #He)
		{
			IGenericLoaderWindow genericLoaderWindow = this.#E;
			this.#E = null;
			if (genericLoaderWindow != null)
			{
				genericLoaderWindow.#Fgc();
			}
			if (this.#a.GuiController.IsBackstageOpen)
			{
				LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#LSh));
			}
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x0008ED8C File Offset: 0x0008CF8C
		private void #Kh(object #Ge, DragEventArgs #He)
		{
			if (this.#ii())
			{
				return;
			}
			if (#He.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] array = (string[])#He.Data.GetData(DataFormats.FileDrop);
				if (array == null || !this.#ji(array))
				{
					return;
				}
				this.#b.#kF(array[0], true);
			}
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x0000B2F2 File Offset: 0x000094F2
		private void #Lh(object #Ge, EventArgs #He)
		{
			this.#vh();
			this.#Ed();
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x0000B30C File Offset: 0x0000950C
		private void #Mh()
		{
			this.#q.#eb(false);
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x0008EDF4 File Offset: 0x0008CFF4
		private void #Nh()
		{
			this.#p.SetupCommand(EditorContextMenuCommands.#a, new Action<object>(this.#MSh), new Predicate<object>(this.#NSh));
			this.#p.SetupCommand(EditorContextMenuCommands.#b, new Action<object>(this.#Bi), new Predicate<object>(this.#zi));
			this.#p.SetupCommand(EditorContextMenuCommands.#c, new Action<object>(this.#Ai), new Predicate<object>(this.#yi));
			this.#p.SetupCommand(EditorContextMenuCommands.#s, new Action<object>(this.#OSh), new Predicate<object>(this.#PSh));
			this.#p.SetupCommand(EditorContextMenuCommands.#j, new Action<object>(this.#QSh), new Predicate<object>(this.#RSh));
			this.#p.SetupCommand(EditorContextMenuCommands.#k, new Action<object>(this.#SSh), new Predicate<object>(this.#TSh));
			this.#p.SetupCommand(EditorContextMenuCommands.#l, new Action<object>(this.#USh), new Predicate<object>(this.#VSh));
			this.#p.SetupCommand(EditorContextMenuCommands.#m, new Action<object>(this.#WSh), new Predicate<object>(this.#XSh));
			this.#p.SetupCommand(EditorContextMenuCommands.#n, new Action<object>(this.#YSh), new Predicate<object>(this.#ZSh));
			this.#p.SetupCommand(EditorContextMenuCommands.#o, new Action<object>(this.#0Sh), new Predicate<object>(this.#1Sh));
			this.#p.SetupCommand(EditorContextMenuCommands.#p, new Action<object>(this.#2Sh), new Predicate<object>(this.#3Sh));
			this.#p.SetupCommand(EditorContextMenuCommands.#r, new Action<object>(this.#4Sh), new Predicate<object>(this.#5Sh));
			this.#p.SetupCommand(EditorContextMenuCommands.#q, new Action<object>(this.#6Sh), new Predicate<object>(this.#7Sh));
			this.#p.SetupCommand(EditorContextMenuCommands.#u, new Action<object>(this.#8Sh), new Predicate<object>(this.#9Sh));
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x0000B322 File Offset: 0x00009522
		private void #Oh(#RPb #Ph)
		{
			this.ScopesManager.Section.#8vb(#Ph);
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x0000B341 File Offset: 0x00009541
		private bool #Qh(#RPb #Ph)
		{
			return this.ScopesManager.Section.#9vb(#Ph);
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x0008F024 File Offset: 0x0008D224
		private void #Rh(object #Sb)
		{
			PreviewShowCompassEventArgs previewShowCompassEventArgs = #Sb as PreviewShowCompassEventArgs;
			if (previewShowCompassEventArgs != null)
			{
				previewShowCompassEventArgs.Canceled = (this.#a.GuiController.IsBackstageOpen || this.#a.GuiController.IsStartupPageOpen);
			}
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x0008F074 File Offset: 0x0008D274
		private void #Sh(ICommand #Th, Action<object> #Uh, Func<object, bool> #Vh = null)
		{
			#9i.#uAf #uAf = new #9i.#uAf();
			#uAf.#a = #Uh;
			#uAf.#b = #Vh;
			CommandBinding binding = new CommandBinding(#Th, new ExecutedRoutedEventHandler(#uAf.#LUb), new CanExecuteRoutedEventHandler(#uAf.#MUb));
			base.View.RegisterGlobalCommand(binding);
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x0000B360 File Offset: 0x00009560
		private void #Wh(object #Vg)
		{
			base.Services.MouseAndKeyboard.#D2c();
			if (this.#e.Docking.IsVisible)
			{
				this.#e.#Ff();
			}
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x0008F0CC File Offset: 0x0008D2CC
		private void #Xh()
		{
			this.#Sh(ApplicationCommands.Undo, new Action<object>(this.#Bi), new Func<object, bool>(this.#zi));
			this.#Sh(ApplicationCommands.Redo, new Action<object>(this.#Ai), new Func<object, bool>(this.#yi));
			this.#Sh(ApplicationCommands.Save, new Action<object>(this.#ci), null);
			this.#Sh(ApplicationCommands.SaveAs, new Action<object>(this.#ei), null);
			this.#Sh(ApplicationCommands.New, new Action<object>(this.#di), null);
			this.#Sh(ApplicationCommands.Open, new Action<object>(this.#fi), null);
			this.#Sh(ApplicationCommands.Close, new Action<object>(this.#Ug), null);
			this.#Sh(ApplicationCommands.Print, new Action<object>(this.#2h), new Func<object, bool>(this.#0h));
			this.#Sh(#rg.#a, new Action<object>(this.#Wh), null);
			this.#Sh(#rg.#b, new Action<object>(this.#7h), new Func<object, bool>(this.#0h));
			this.#Sh(#rg.#c, new Action<object>(this.#aTh), null);
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x0008F22C File Offset: 0x0008D42C
		private void #Yh()
		{
			base.Services.Commands.Undo.SetCommand(new Action<object>(this.#Bi), new Predicate<object>(this.#zi));
			base.Services.Commands.Redo.SetCommand(new Action<object>(this.#Ai), new Predicate<object>(this.#yi));
			base.Services.Commands.Save.SetCommand(new Action<object>(this.#ci));
			base.Services.Commands.Open.SetCommand(new Action<object>(this.#fi));
			base.Services.Commands.OpenExamples.SetCommand(new Action<object>(this.#gi));
			base.Services.Commands.New.SetCommand(new Action<object>(this.#di));
			base.Services.Commands.SaveAs.SetCommand(new Action<object>(this.#ei));
			base.Services.Commands.Close.SetCommand(new Action<object>(this.#Ug));
			this.#a.Commands.AddToReport.SetCommand(new Action<object>(this.#7h), new Predicate<object>(this.#0h));
			this.#a.Commands.PrintExport.SetCommand(new Action<object>(this.#2h), new Predicate<object>(this.#0h));
			base.Services.Commands.OpenSolver.SetCommand(new Action<object>(this.#bi));
			base.Services.Commands.OpenSuperImpose.SetCommand(new Action<object>(this.#li), new Predicate<object>(this.#Zh));
			base.Services.Commands.OpenReporter.SetCommand(new Action<object>(this.#9h), new Predicate<object>(this.#hi));
			base.Services.Commands.OpenResults.SetCommand(new Action<object>(this.#ai), new Predicate<object>(this.#8h));
			this.#a.Commands.CleanReport.SetCommand(new Action<object>(this.#1h));
			this.#a.Commands.ExportDxf.SetCommand(new Action<object>(this.#bh), new Predicate<object>(this.#ah));
			this.#a.Commands.ExportDiagram2D.SetCommand(new Action<object>(this.#9g), new Predicate<object>(this.#8g));
			this.#a.Commands.ExportDiagram3D.SetCommand(new Action<object>(this.#6g), new Predicate<object>(this.#5g));
			this.#a.Commands.ExportLoads.SetCommand(new Action<object>(this.#fh), new Predicate<object>(this.#eh));
			this.#a.Commands.ExportSection.SetCommand(new Action<object>(this.#dh), new Predicate<object>(this.#ch));
			this.#a.Commands.ImportDxf.SetCommand(new Action<object>(this.#lh), new Predicate<object>(this.#kh));
			this.#a.Commands.ImportLoads.SetCommand(new Action<object>(this.#jh), new Predicate<object>(this.#ih));
			this.#a.Commands.ImportSection.SetCommand(new Action<object>(this.#hh), new Predicate<object>(this.#gh));
			this.#a.Commands.ChangeUnitSystem.SetCommand(new Action<object>(this.#bTh));
			this.#3g();
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x0008F62C File Offset: 0x0008D82C
		private bool #Zh(object #Vg)
		{
			#4Ve #4Ve = this.#o.CurrentTraceStep;
			bool flag = base.Project.Model.Options.ProblemType == ProblemType.Design && #4Ve != null && this.#o.DesignEngine != null && this.#o.TraceResults.LastOrDefault<#4Ve>() != #4Ve;
			return !flag;
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x0008F698 File Offset: 0x0008D898
		private bool #0h(object #Vg)
		{
			return this.#i.ActiveViewport is IModelEditorViewport && this.#j.DiagramsViewports.Docking.IsVisible && this.#g.#bab();
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x0008F6EC File Offset: 0x0008D8EC
		private void #1h(object #Vg)
		{
			try
			{
				this.#l.Screenshots.Clear();
				this.#d.#ZA();
			}
			catch (Exception #ob)
			{
				base.Services.ErrorsHandler.#bzc(Strings.StringAnUnknownErrorOccrued.#z2d(), #ob, new #3Hc(base.Services.ApplicationInfo.ApplicationName));
			}
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x0008F768 File Offset: 0x0008D968
		private void #2h(object #Vg)
		{
			#9i.#Fzf #Fzf = new #9i.#Fzf();
			#Fzf.#a = this;
			if (!base.DialogService.#ABf())
			{
				return;
			}
			try
			{
				CommandExecutionMode valueOrDefault = ((CommandExecutionMode?)#Vg).GetValueOrDefault();
				IViewport viewport = this.#i.ActiveViewport;
				#Fzf.#b = (viewport as IModelEditorViewport);
				if (#Fzf.#b != null)
				{
					if (valueOrDefault == CommandExecutionMode.Regular)
					{
						this.#3h(#Fzf.#b);
					}
					else
					{
						LayoutHelper.BeginInvokeOnApplicationThread(new Action(#Fzf.#OUb));
					}
				}
			}
			catch (Exception #ob)
			{
				this.#a.ExceptionHandler.#3Ab(#ob);
			}
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x0008F82C File Offset: 0x0008DA2C
		private void #3h(IModelEditorViewport #fe)
		{
			Diagram2DData diagram2DData = #fe.DiagramPresenter.#Ldb(false);
			if (diagram2DData == null)
			{
				return;
			}
			if (this.#h.Model == null)
			{
				this.#l.#LA(true, false);
			}
			this.#4h(new #Due
			{
				Image = new ReporterImage(diagram2DData),
				Model = this.#h.Model
			}, this.#l.#OA());
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x0008F8A4 File Offset: 0x0008DAA4
		private void #4h(#Due #5h, GeneralInformation #6h)
		{
			#kPd #kPd = this.#d.#4h(new #gPd
			{
				FilePath = base.Project.LoadedFilePath,
				WindowOwner = base.View,
				ImageData = #5h,
				UnitSystem = (ReporterUnitsSystem)base.Project.Model.Options.Unit,
				ProductInfo = Strings.StringStructurePoint_UPPER + #Phc.#3hc(107382888) + #6h.ProductAndVersion,
				LicenseInfo = string.Format(StructurePoint.CoreAssets.GUI.Reporter.Core.Resources.Localization.StringLicensedTo0LicenseID1, #6h.LicenseeName, #6h.LicenseId)
			});
			if (#kPd != null && #kPd.ResultAction == GraphicalReporterResultActionType.AddToReport)
			{
				#5h.Image.PrintOptions = #kPd.PrintOptions;
				Diagram2DData diagram2DData = #5h.Image.Diagram;
				diagram2DData.Description += #Phc.#3hc(107382883);
				this.#l.Screenshots.Add(#5h.Image);
				this.#d.#ZA();
			}
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x0008F9C0 File Offset: 0x0008DBC0
		private void #7h(object #Vg)
		{
			try
			{
				IModelEditorViewport modelEditorViewport = this.#i.ActiveViewport as IModelEditorViewport;
				if (modelEditorViewport != null)
				{
					Diagram2DData diagram2DData = modelEditorViewport.DiagramPresenter.#Ldb(true);
					if (diagram2DData != null)
					{
						this.#l.Screenshots.Add(new ReporterImage(diagram2DData));
						this.#d.#ZA();
						Window #jA = base.View as Window;
						base.DialogService.#od(TimeSpan.FromSeconds(1.0), #jA, Strings.StringDiagramAddedToReport.#z2d(), base.Services.ApplicationInfo.ApplicationName, MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK, MessageBoxOptions.None);
					}
				}
			}
			catch (Exception #ob)
			{
				this.#a.ExceptionHandler.#3Ab(#ob);
			}
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x00003375 File Offset: 0x00001575
		private bool #8h(object #Vg)
		{
			return true;
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x0008FAA8 File Offset: 0x0008DCA8
		private void #9h(object #Sb)
		{
			try
			{
				if (base.DialogService.#ABf())
				{
					this.#a.MouseAndKeyboard.#M2c();
					this.#d.#VA();
				}
			}
			catch (Exception #ob)
			{
				base.Services.ErrorsHandler.#bzc(Strings.StringCouldNotOpenTheReporter.#z2d(), #ob, new #3Hc(base.Services.ApplicationInfo.ApplicationName));
			}
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x0008FB30 File Offset: 0x0008DD30
		private void #ai(object #Vg)
		{
			try
			{
				if (base.DialogService.#ABf())
				{
					this.#a.MouseAndKeyboard.#M2c();
					this.#d.#WA();
				}
			}
			catch (Exception #ob)
			{
				base.Services.ErrorsHandler.#bzc(Strings.StringCouldNotOpenTheTables.#z2d(), #ob, new #3Hc(base.Services.ApplicationInfo.ApplicationName));
			}
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x0008FBB8 File Offset: 0x0008DDB8
		private void #bi(object #Vg)
		{
			if (!base.DialogService.#ABf())
			{
				return;
			}
			this.#a.MouseAndKeyboard.#L2c(Application.Current.MainWindow, true);
			if (!this.#D.Context.KeepDiagramsAfterExecution)
			{
				this.#D.Context.#yl();
			}
			this.#D.Context.InterpolatedCache.#yl();
			this.#C.#od(false);
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x0000B39D File Offset: 0x0000959D
		private void #Ug(object #Vg)
		{
			base.View.Close();
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x0000B3B6 File Offset: 0x000095B6
		private void #ci(object #Sb)
		{
			this.#b.#AK();
			this.#Ed();
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x0008FC44 File Offset: 0x0008DE44
		private void #di(object #Sb)
		{
			if (!base.DialogService.#ABf())
			{
				return;
			}
			this.#b.#DK(null);
			this.#p.ChangeSectionType(base.Project.Model.Options.SectionType);
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x0000B3D6 File Offset: 0x000095D6
		private void #ei(object #Sb)
		{
			if (!base.DialogService.#ABf())
			{
				return;
			}
			this.#b.#BK();
			this.#Ed();
		}

		// Token: 0x06000709 RID: 1801 RVA: 0x0008FC98 File Offset: 0x0008DE98
		private void #fi(object #Sb)
		{
			if (!base.DialogService.#ABf())
			{
				return;
			}
			this.#b.#yK(null);
			this.#p.ChangeSectionType(base.Project.Model.Options.SectionType);
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x0008FCEC File Offset: 0x0008DEEC
		private void #gi(object #Sb)
		{
			string currentDirectory = Alphaleonis.Win32.Filesystem.Directory.GetCurrentDirectory();
			this.#b.#yK(Alphaleonis.Win32.Filesystem.Path.Combine(new string[]
			{
				currentDirectory,
				#Phc.#3hc(107382902)
			}));
			this.#p.ChangeSectionType(base.Project.Model.Options.SectionType);
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x00003375 File Offset: 0x00001575
		private bool #hi(object #Sb)
		{
			return true;
		}

		// Token: 0x0600070C RID: 1804 RVA: 0x0000B404 File Offset: 0x00009604
		private bool #ii()
		{
			return WindowHelper.IsAnyModalWindowOpen() || base.DialogService.IsAnyMessageBoxOpen;
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x0008FD54 File Offset: 0x0008DF54
		private bool #ji(string[] #ki)
		{
			if (#ki.Length > 1)
			{
				base.DialogService.#od(base.MainWindow, Strings.StringMultipleFileDropUnsupported.#z2d(), MessageBoxButton.OK, MessageBoxImage.Exclamation);
				return false;
			}
			string a = Alphaleonis.Win32.Filesystem.Path.GetExtension(#ki[0]).Substring(1);
			if (!string.Equals(a, #b1d.CurrentExtension, StringComparison.OrdinalIgnoreCase) && !string.Equals(a, #b1d.LegacyExtension, StringComparison.OrdinalIgnoreCase) && !string.Equals(a, #b1d.LegacyTextExtension, StringComparison.OrdinalIgnoreCase))
			{
				base.DialogService.#od(base.MainWindow, Strings.StringUnsupportedFileFormat.#z2d(), MessageBoxButton.OK, MessageBoxImage.Exclamation);
				return false;
			}
			return true;
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x0000B429 File Offset: 0x00009629
		private void #li(object #Sb)
		{
			this.#a.MouseAndKeyboard.#M2c();
			this.#D.#oq();
		}

		// Token: 0x17000313 RID: 787
		// (get) Token: 0x0600070F RID: 1807 RVA: 0x0000B452 File Offset: 0x00009652
		// (set) Token: 0x06000710 RID: 1808 RVA: 0x0000B45E File Offset: 0x0000965E
		public bool IsLoading
		{
			get
			{
				return this.#N;
			}
			private set
			{
				if (this.#N != value)
				{
					this.#N = value;
					if (!value)
					{
						base.View.StopInitAnimation();
					}
					base.RaisePropertyChanged(#Phc.#3hc(107382857));
				}
			}
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x0008FE04 File Offset: 0x0008E004
		public #cDc #oi()
		{
			ColumnStorageModel #Od = base.Services.StorageModelConverter.#Pb(base.Project.Model);
			return new #eX(#Od);
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x0000B49A File Offset: 0x0000969A
		public void #pi(#cDc #qi, #aDc #ri)
		{
			this.#pi(#qi);
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x0008FE40 File Offset: 0x0008E040
		public void #pi(#cDc #qi)
		{
			#eX #eX = #qi as #eX;
			if (#eX == null)
			{
				return;
			}
			this.#wi(#eX.Model, true);
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x0008FE74 File Offset: 0x0008E074
		private void #si()
		{
			this.#a.Settings.Diagram3DAreLoadPointsVisible = true;
			#5re #5re = base.Services.ReporterSettings.#jJ();
			#5re #5re2 = #5re.Default;
			#5re.ShowLoadPoints = #5re2.ShowLoadPoints;
			#5re.ShowLoadPointsLabels = #5re2.ShowLoadPointsLabels;
			#5re.ShowAxialLoadLabels = #5re2.ShowAxialLoadLabels;
			#5re.ShowSpliceLines = #5re2.ShowSpliceLines;
			#5re.ShowFactoredDiagramTop = #5re2.ShowFactoredDiagramTop;
			#5re.ShowCapacityRatioPoints = false;
			base.Services.ReporterSettings.#iJ(#5re);
			this.#a.Settings.ShowNominal = true;
			this.#a.Settings.ShowFactored = true;
			#qRb #qRb = base.Services.Settings.#ZN();
			#qRb.SectionAnnotationsVisibility = true;
			#qRb.CoverVisibility = true;
			base.Services.Settings.#0N(#qRb);
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x0008FF70 File Offset: 0x0008E170
		private void #ti(ColumnStorageModel #ui, bool #vi)
		{
			#uzc #uzc = new #uzc(#Phc.#3hc(107382876));
			EyeshotInitializer.Instance.WaitForInitializers();
			#uzc.#szc(#Phc.#3hc(107382827));
			base.Services.Project.IsChangingModelExtended = true;
			IUnit #A = base.Project.Model.Units.Section.Width.Unit;
			this.#D.Context.#yl();
			this.#q.#eb(false);
			this.#q.ActiveUnitSystem = base.Project.Model.Options.Unit;
			this.#q.#gFb(#ui.Options.Unit);
			#uzc.#szc(#Phc.#3hc(107382806));
			if (!base.Services.Project.#6O(#ui, #vi))
			{
				base.Services.Project.IsChangingModelExtended = false;
				return;
			}
			#uzc.#szc(#Phc.#3hc(107383245));
			try
			{
				this.#w.#0wb(false);
				this.#g.#cab();
				this.#o.#DQ();
				ColumnModelHelper.#VW(base.Services.Project);
				ColumnModel columnModel = base.Project.Model;
				base.Services.Settings.DrawingGrid = columnModel.DraftingSettings.DrawingGridSettings;
				base.Services.Settings.DynamicInput = columnModel.DraftingSettings.DynamicInputSettings;
				base.Services.Settings.SnappingSettings = columnModel.DraftingSettings.SnappingSettings;
				base.Services.Settings.StatusBar = columnModel.DraftingSettings.StatusBarSettings;
				base.Services.MouseAndKeyboard.#I2c();
				if (!#vi)
				{
					try
					{
						ColumnModelHelper.#2W(this.#a.StorageModelConverter, base.Project.Model);
						#uzc.#szc(#Phc.#3hc(107383232));
					}
					catch (Exception)
					{
					}
					this.#l.Screenshots.Clear();
				}
				base.Services.SnappingCache.#uP(base.Project);
				bool flag = false;
				if (!#vi)
				{
					this.#si();
					#uzc.#szc(#Phc.#3hc(107383171));
					this.#j.#jd();
					#uzc.#szc(#Phc.#3hc(107383106));
					if (this.#e.Viewports.Count != 1)
					{
						flag = true;
						this.#e.#Df(#uzc);
						#uzc.#szc(#Phc.#3hc(107383053));
						this.#e.#zf();
						#uzc.#szc(#Phc.#3hc(107382512));
					}
					this.#e.ActiveViewport.ScopeSettings.ActiveScope = this.ScopesManager.Project;
					this.#e.#Gf();
					#uzc.#szc(#Phc.#3hc(107382411));
				}
				else
				{
					this.ScopesManager.#WKb();
				}
				this.#e.#wf();
				foreach (IModelEditorViewport modelEditorViewport in this.#a.ViewportsManager.Viewports.OfType<IModelEditorViewport>())
				{
					modelEditorViewport.EditorContext.Selection.#sOb();
					modelEditorViewport.EditorContext.Selection.State.#cg();
					if (!#vi && modelEditorViewport.Editor.ActionMode != actionType.None)
					{
						modelEditorViewport.Editor.ViewPortConfigurator.DisableToggleButton(modelEditorViewport.Editor.ActionMode);
						modelEditorViewport.Editor.ActionMode = actionType.None;
						modelEditorViewport.Editor.CompileUserInterfaceElements();
						modelEditorViewport.Editor.Invalidate();
						#uzc.#szc(#Phc.#3hc(107382346));
					}
				}
				if (!#vi)
				{
					if (flag)
					{
						LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#cTh));
					}
					else
					{
						this.#a.Renderer.#9f(false, true);
						this.#a.Renderer.#bg();
					}
				}
				else
				{
					this.#a.Renderer.#9f(true, false);
					#uzc.#szc(#Phc.#3hc(107382325));
					UnitSystemChangeHelper unitSystemChangeHelper = new UnitSystemChangeHelper(this.#a.Project, this.#j, this.#q, this.#a.Settings, this.#w, null);
					unitSystemChangeHelper.#z6(#A, base.Project.Model.Units.Section.Width.Unit);
				}
				this.#Ed();
				if (!#vi)
				{
					this.#Mh();
					base.UndoManager.#yl();
					this.#d.#2A();
					LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#dTh));
				}
				this.#g.#cab();
				this.#o.#DQ();
				this.#m.#yJ();
				#uzc.#szc(#Phc.#3hc(107382760));
				this.IsLoading = false;
			}
			catch (Exception #ob)
			{
				this.#a.ExceptionHandler.#3Ab(Strings.StringFailedToLoadModel.#z2d(), #ob);
			}
			finally
			{
				base.Services.Project.IsChangingModelExtended = false;
			}
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x0009050C File Offset: 0x0008E70C
		private void #Ed()
		{
			base.Services.GuiController.ApplicationTitle = #Phc.#3hc(107382743).#D2d(new object[]
			{
				base.Services.ApplicationInfo.ApplicationName,
				this.#b.CurrentProject,
				this.#c.HasChanges ? (#Phc.#3hc(107395499) + Strings.StringModified + #Phc.#3hc(107382694)) : string.Empty
			});
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x0000B4AF File Offset: 0x000096AF
		private void #wi(ColumnStorageModel #Od, bool #xi)
		{
			this.#ti(#Od, #xi);
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x0000B4C5 File Offset: 0x000096C5
		private bool #yi(object #Sb)
		{
			return base.UndoManager.IsEnabled && base.UndoManager.CanRedo;
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x0000B4ED File Offset: 0x000096ED
		private bool #zi(object #Sb)
		{
			return base.UndoManager.IsEnabled && base.UndoManager.CanUndo;
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x000905B0 File Offset: 0x0008E7B0
		private void #Ai(object #Sb)
		{
			if (this.#M.#YXd())
			{
				try
				{
					base.Services.Commands.Redo.InvalidateCanExecute();
					if (base.Services.Commands.Redo.CanExecute(#Sb))
					{
						base.Services.UndoManager.#zCc();
					}
				}
				catch (Exception #ob)
				{
					base.Services.ErrorsHandler.#bzc(Strings.StringAnErrorOccurredWhileExecutingRedo.#z2d(), #ob, #3Hc.#2Hc(Strings.StringUndoManager));
				}
				finally
				{
					this.#M.#ZXd();
				}
			}
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x00090674 File Offset: 0x0008E874
		private void #Bi(object #Sb)
		{
			if (this.#M.#YXd())
			{
				try
				{
					base.Services.Commands.Undo.InvalidateCanExecute();
					if (base.Services.Commands.Undo.CanExecute(#Sb))
					{
						base.Services.UndoManager.#yCc(#aDc.#b);
					}
				}
				catch (Exception #ob)
				{
					base.Services.ErrorsHandler.#bzc(Strings.StringAnErrorOccurredWhileExecutingUndo.#z2d(), #ob, #3Hc.#2Hc(Strings.StringUndoManager));
				}
				finally
				{
					this.#M.#ZXd();
				}
			}
		}

		// Token: 0x0600071C RID: 1820 RVA: 0x00090738 File Offset: 0x0008E938
		[CompilerGenerated]
		private void #Ci()
		{
			try
			{
				List<#L1c> list = new List<#L1c>();
				#L1c item = new #L1c(Strings.StringDataExchangeFormat, #b1d.DxfExtension);
				if (7 != 0)
				{
					list.Add(item);
				}
				List<#L1c> #m2c = list;
				#62c #21c = new #62c(#m2c, #b1d.DxfExtension, null)
				{
					InitialFileName = (string.IsNullOrWhiteSpace(base.Project.LoadedFilePath) ? Strings.StringUntitled : Alphaleonis.Win32.Filesystem.Path.GetFileNameWithoutExtension(base.Project.LoadedFilePath))
				};
				string text = this.#a.FileSystem.#11c(#21c);
				if (!string.IsNullOrWhiteSpace(text))
				{
					using (Stream stream = base.FileSystem.#T1c(text))
					{
						ColumnStorageModel #Od = ExportModelHelper.#bJ(base.Project.Model.#CY(), this.#o.DesignEngine);
						this.#a.Storage.#5ie(#Od, stream);
					}
					base.DialogService.#pn(base.DialogService.ActiveWindow, Strings.StringSpColumn, Strings.StringExportOperationWasSuccessful.#z2d());
					this.#a.GuiController.IsBackstageOpen = false;
				}
			}
			catch (Exception #ob)
			{
				this.#a.ExceptionHandler.#3Ab(#ob);
			}
		}

		// Token: 0x0600071D RID: 1821 RVA: 0x000908AC File Offset: 0x0008EAAC
		[CompilerGenerated]
		private void #Di()
		{
			ColumnStorageModel #X = base.Project.Model.#CY();
			this.#y.#MT(#X, base.Project.Model.Options.ActiveLoad);
		}

		// Token: 0x0600071E RID: 1822 RVA: 0x000908F8 File Offset: 0x0008EAF8
		[CompilerGenerated]
		private void #Ei()
		{
			try
			{
				if (this.#t.#od())
				{
					this.#mh();
				}
			}
			catch (Exception #ob)
			{
				this.#a.ExceptionHandler.#3Ab(#ob);
			}
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x0000B515 File Offset: 0x00009715
		[CompilerGenerated]
		private void #LSh()
		{
			base.View.FocusRibbon();
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x0000B52E File Offset: 0x0000972E
		[CompilerGenerated]
		private void #MSh(object #Hi)
		{
			this.#Oh(#RPb.#a);
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x0000B53F File Offset: 0x0000973F
		[CompilerGenerated]
		private bool #NSh(object #Hi)
		{
			return this.#Qh(#RPb.#a);
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x0000B550 File Offset: 0x00009750
		[CompilerGenerated]
		private void #OSh(object #Hi)
		{
			this.#Oh(#RPb.#c);
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x0000B561 File Offset: 0x00009761
		[CompilerGenerated]
		private bool #PSh(object #Hi)
		{
			return this.#Qh(#RPb.#c);
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x0000B572 File Offset: 0x00009772
		[CompilerGenerated]
		private void #QSh(object #Hi)
		{
			this.#Oh(#RPb.#d);
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x0000B583 File Offset: 0x00009783
		[CompilerGenerated]
		private bool #RSh(object #Hi)
		{
			return this.#Qh(#RPb.#d);
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x0000B594 File Offset: 0x00009794
		[CompilerGenerated]
		private void #SSh(object #Hi)
		{
			this.#Oh(#RPb.#e);
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x0000B5A5 File Offset: 0x000097A5
		[CompilerGenerated]
		private bool #TSh(object #Hi)
		{
			return this.#Qh(#RPb.#e);
		}

		// Token: 0x06000728 RID: 1832 RVA: 0x0000B5B6 File Offset: 0x000097B6
		[CompilerGenerated]
		private void #USh(object #Hi)
		{
			this.#Oh(#RPb.#f);
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x0000B5C7 File Offset: 0x000097C7
		[CompilerGenerated]
		private bool #VSh(object #Hi)
		{
			return this.#Qh(#RPb.#f);
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x0000B5D8 File Offset: 0x000097D8
		[CompilerGenerated]
		private void #WSh(object #Hi)
		{
			this.#Oh(#RPb.#g);
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x0000B5E9 File Offset: 0x000097E9
		[CompilerGenerated]
		private bool #XSh(object #Hi)
		{
			return this.#Qh(#RPb.#g);
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x0000B5FA File Offset: 0x000097FA
		[CompilerGenerated]
		private void #YSh(object #Hi)
		{
			this.#Oh(#RPb.#h);
		}

		// Token: 0x0600072D RID: 1837 RVA: 0x0000B60B File Offset: 0x0000980B
		[CompilerGenerated]
		private bool #ZSh(object #Hi)
		{
			return this.#Qh(#RPb.#h);
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x0000B61C File Offset: 0x0000981C
		[CompilerGenerated]
		private void #0Sh(object #Hi)
		{
			this.#Oh(#RPb.#i);
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x0000B62D File Offset: 0x0000982D
		[CompilerGenerated]
		private bool #1Sh(object #Hi)
		{
			return this.#Qh(#RPb.#i);
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x0000B63E File Offset: 0x0000983E
		[CompilerGenerated]
		private void #2Sh(object #Hi)
		{
			this.#Oh(#RPb.#j);
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x0000B650 File Offset: 0x00009850
		[CompilerGenerated]
		private bool #3Sh(object #Hi)
		{
			return this.#Qh(#RPb.#j);
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x0000B662 File Offset: 0x00009862
		[CompilerGenerated]
		private void #4Sh(object #Hi)
		{
			this.#Oh(#RPb.#l);
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x0000B674 File Offset: 0x00009874
		[CompilerGenerated]
		private bool #5Sh(object #Hi)
		{
			return this.#Qh(#RPb.#l);
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x0000B686 File Offset: 0x00009886
		[CompilerGenerated]
		private void #6Sh(object #Hi)
		{
			this.#Oh(#RPb.#k);
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x0000B698 File Offset: 0x00009898
		[CompilerGenerated]
		private bool #7Sh(object #Hi)
		{
			return this.#Qh(#RPb.#k);
		}

		// Token: 0x06000736 RID: 1846 RVA: 0x0000B6AA File Offset: 0x000098AA
		[CompilerGenerated]
		private void #8Sh(object #Hi)
		{
			this.#v.#BW(null);
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x0000B6C0 File Offset: 0x000098C0
		[CompilerGenerated]
		private bool #9Sh(object #Hi)
		{
			return this.#v.#CW();
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x0000B6D5 File Offset: 0x000098D5
		[CompilerGenerated]
		private void #aTh(object #Hi)
		{
			if (this.#a.GuiController.IsBackstageOpen && base.View.IsActive)
			{
				this.#a.GuiController.IsBackstageOpen = false;
			}
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x0000B713 File Offset: 0x00009913
		[CompilerGenerated]
		private void #bTh(object #Sb)
		{
			this.#x.#SP((UnitSystem)#Sb);
		}

		// Token: 0x0600073A RID: 1850 RVA: 0x0000B733 File Offset: 0x00009933
		[CompilerGenerated]
		private void #cTh()
		{
			this.#a.Renderer.#9f(false, true);
			this.#a.Renderer.#bg();
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x0000B763 File Offset: 0x00009963
		[CompilerGenerated]
		private void #dTh()
		{
			this.ScopesManager.#XKb(new ProjectScopeActivationParameters());
			CommandManager.InvalidateRequerySuggested();
		}

		// Token: 0x040001A8 RID: 424
		private readonly IExtendedServices #a;

		// Token: 0x040001A9 RID: 425
		private readonly #vU #b;

		// Token: 0x040001AA RID: 426
		private readonly #XV #c;

		// Token: 0x040001AB RID: 427
		private readonly #nB #d;

		// Token: 0x040001AC RID: 428
		private readonly #jg #e;

		// Token: 0x040001AD RID: 429
		private readonly #gg #f;

		// Token: 0x040001AE RID: 430
		private readonly #vbb #g;

		// Token: 0x040001AF RID: 431
		private readonly #rW #h;

		// Token: 0x040001B0 RID: 432
		private readonly #ud #i;

		// Token: 0x040001B1 RID: 433
		private readonly #vd #j;

		// Token: 0x040001B2 RID: 434
		private readonly #yBe #k;

		// Token: 0x040001B3 RID: 435
		private readonly #lB #l;

		// Token: 0x040001B4 RID: 436
		private readonly #zJ #m;

		// Token: 0x040001B5 RID: 437
		private readonly #oQb #n;

		// Token: 0x040001B6 RID: 438
		private readonly #qW #o;

		// Token: 0x040001B7 RID: 439
		private readonly #dLb #p;

		// Token: 0x040001B8 RID: 440
		private readonly #JFb #q;

		// Token: 0x040001B9 RID: 441
		private readonly #yW #r;

		// Token: 0x040001BA RID: 442
		private readonly #AW #s;

		// Token: 0x040001BB RID: 443
		private readonly #GI #t;

		// Token: 0x040001BC RID: 444
		private readonly IEditorService #u;

		// Token: 0x040001BD RID: 445
		private readonly #DW #v;

		// Token: 0x040001BE RID: 446
		private readonly #2wb #w;

		// Token: 0x040001BF RID: 447
		private readonly #1V #x;

		// Token: 0x040001C0 RID: 448
		private readonly #HW #y;

		// Token: 0x040001C1 RID: 449
		private readonly #JW #z;

		// Token: 0x040001C2 RID: 450
		private readonly #KW #A;

		// Token: 0x040001C3 RID: 451
		private readonly #AWh #B;

		// Token: 0x040001C4 RID: 452
		private readonly #8I #C;

		// Token: 0x040001C5 RID: 453
		private readonly #aJ #D;

		// Token: 0x040001C6 RID: 454
		private IGenericLoaderWindow #E;

		// Token: 0x040001C7 RID: 455
		private bool #F;

		// Token: 0x040001C8 RID: 456
		[CompilerGenerated]
		private readonly #BLb #G;

		// Token: 0x040001C9 RID: 457
		[CompilerGenerated]
		private readonly #hLb #H;

		// Token: 0x040001CA RID: 458
		[CompilerGenerated]
		private readonly #KI #I;

		// Token: 0x040001CB RID: 459
		[CompilerGenerated]
		private readonly #MI #J;

		// Token: 0x040001CC RID: 460
		[CompilerGenerated]
		private readonly #LI #K;

		// Token: 0x040001CD RID: 461
		[CompilerGenerated]
		private readonly DelegateCommand #L;

		// Token: 0x040001CE RID: 462
		private readonly NonBlockingLock #M = new NonBlockingLock();

		// Token: 0x040001CF RID: 463
		private bool #N = true;

		// Token: 0x020000DC RID: 220
		[CompilerGenerated]
		private sealed class #uAf
		{
			// Token: 0x0600073D RID: 1853 RVA: 0x0000B786 File Offset: 0x00009986
			internal void #LUb(object #Hi, ExecutedRoutedEventArgs #Lg)
			{
				this.#a(#Lg.Parameter);
			}

			// Token: 0x0600073E RID: 1854 RVA: 0x0000B7A5 File Offset: 0x000099A5
			internal void #MUb(object #Hi, CanExecuteRoutedEventArgs #Lg)
			{
				#Lg.CanExecute = (this.#b == null || this.#b(#Lg.Parameter));
			}

			// Token: 0x040001D0 RID: 464
			public Action<object> #a;

			// Token: 0x040001D1 RID: 465
			public Func<object, bool> #b;
		}

		// Token: 0x020000DD RID: 221
		[CompilerGenerated]
		private sealed class #Fzf
		{
			// Token: 0x06000740 RID: 1856 RVA: 0x0000B7D5 File Offset: 0x000099D5
			internal void #OUb()
			{
				this.#a.#3h(this.#b);
			}

			// Token: 0x040001D2 RID: 466
			public #9i #a;

			// Token: 0x040001D3 RID: 467
			public IModelEditorViewport #b;
		}

		// Token: 0x020000DE RID: 222
		[CompilerGenerated]
		private sealed class #BUb
		{
			// Token: 0x06000742 RID: 1858 RVA: 0x0000B7F4 File Offset: 0x000099F4
			internal void #AUb()
			{
				this.#a.#r.#0(this.#b);
			}

			// Token: 0x040001D4 RID: 468
			public #9i #a;

			// Token: 0x040001D5 RID: 469
			public SectionImportExportType #b;
		}

		// Token: 0x020000DF RID: 223
		[CompilerGenerated]
		private sealed class #DUb
		{
			// Token: 0x06000744 RID: 1860 RVA: 0x0000B818 File Offset: 0x00009A18
			internal void #CUb()
			{
				if (this.#a.#s.#0(this.#b))
				{
					this.#a.#mh();
				}
			}

			// Token: 0x040001D6 RID: 470
			public #9i #a;

			// Token: 0x040001D7 RID: 471
			public SectionImportExportType #b;
		}

		// Token: 0x020000E0 RID: 224
		[CompilerGenerated]
		private sealed class #HUb
		{
			// Token: 0x06000746 RID: 1862 RVA: 0x0009094C File Offset: 0x0008EB4C
			internal void #EUb()
			{
				if (this.#a is LoadsImportType)
				{
					LoadsImportType loadsImportType = (LoadsImportType)this.#a;
					#9i.#KUb #KUb = new #9i.#KUb();
					#KUb.#b = this;
					if (!#gUh.#eUh(this.#b.DialogService, this.#b.Project.Model, loadsImportType, this.#c))
					{
						return;
					}
					#KUb.#a = this.#b.#z.#VT(loadsImportType);
					if (!#KUb.#a.IsSuccess)
					{
						return;
					}
					if (loadsImportType == LoadsImportType.ServiceLoads && #KUb.#a.ImportedServiceLoads.Any<ServiceLoad>())
					{
						this.#b.#u.#0Pb(new Action(#KUb.#IUb));
						if (#KUb.#a.ImportedServiceLoads.Count > 0)
						{
							Action action;
							if ((action = this.#d) == null)
							{
								action = (this.#d = new Action(this.#FUb));
							}
							LayoutHelper.BeginInvokeOnApplicationThread(action);
						}
					}
					else if ((loadsImportType == LoadsImportType.ETABS || loadsImportType == LoadsImportType.FactoredLoads) && #KUb.#a.ImportedFactoredLoads.Any<FactoredLoad>())
					{
						this.#b.#u.#0Pb(new Action(#KUb.#JUb));
						if (#KUb.#a.ImportedFactoredLoads.Count > 0)
						{
							Action action2;
							if ((action2 = this.#e) == null)
							{
								action2 = (this.#e = new Action(this.#GUb));
							}
							LayoutHelper.BeginInvokeOnApplicationThread(action2);
						}
					}
					this.#b.#a.GuiController.IsBackstageOpen = false;
				}
			}

			// Token: 0x06000747 RID: 1863 RVA: 0x0000B849 File Offset: 0x00009A49
			internal void #FUb()
			{
				this.#b.Ribbon.OpenLoadsCommand.Execute(null);
			}

			// Token: 0x06000748 RID: 1864 RVA: 0x0000B849 File Offset: 0x00009A49
			internal void #GUb()
			{
				this.#b.Ribbon.OpenLoadsCommand.Execute(null);
			}

			// Token: 0x040001D8 RID: 472
			public object #a;

			// Token: 0x040001D9 RID: 473
			public #9i #b;

			// Token: 0x040001DA RID: 474
			public Window #c;

			// Token: 0x040001DB RID: 475
			public Action #d;

			// Token: 0x040001DC RID: 476
			public Action #e;
		}

		// Token: 0x020000E1 RID: 225
		[CompilerGenerated]
		private sealed class #KUb
		{
			// Token: 0x0600074A RID: 1866 RVA: 0x00090AE4 File Offset: 0x0008ECE4
			internal void #IUb()
			{
				this.#b.#b.Project.Model.ServiceLoads.Clear();
				this.#b.#b.Project.Model.ServiceLoads.AddRange(this.#a.ImportedServiceLoads);
				this.#b.#b.#A.#3T(LoadType.Service);
			}

			// Token: 0x0600074B RID: 1867 RVA: 0x00090B5C File Offset: 0x0008ED5C
			internal void #JUb()
			{
				this.#b.#b.Project.Model.FactoredLoads.Clear();
				this.#b.#b.Project.Model.FactoredLoads.AddRange(this.#a.ImportedFactoredLoads);
				this.#b.#b.#A.#3T(LoadType.Factored);
			}

			// Token: 0x040001DD RID: 477
			public #TT #a;

			// Token: 0x040001DE RID: 478
			public #9i.#HUb #b;
		}

		// Token: 0x020000E2 RID: 226
		[CompilerGenerated]
		private sealed class #ITb
		{
			// Token: 0x0600074D RID: 1869 RVA: 0x0000B86D File Offset: 0x00009A6D
			internal void #zUb()
			{
				this.#a.#7g(this.#b);
			}

			// Token: 0x040001DF RID: 479
			public #9i #a;

			// Token: 0x040001E0 RID: 480
			public object #b;
		}
	}
}
