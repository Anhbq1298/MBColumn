using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #7hc;
using #eU;
using #hg;
using #Oze;
using #RJb;
using #S9;
using #Wse;
using #xBe;
using #Xc;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.DTO;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.Editor.Core;
using StructurePoint.Products.Column.FailureSurface;
using StructurePoint.Products.Column.FailureSurface.ViewModels;
using StructurePoint.Products.Column.FailureSurface.Views;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Services.Rendering;
using StructurePoint.Products.Column.Viewports.API;

namespace StructurePoint.Products.Column.Viewports
{
	// Token: 0x020000AB RID: 171
	internal sealed class ModelEditorViewport : #de, #Fd, IViewport, IModelEditorViewport
	{
		// Token: 0x06000587 RID: 1415 RVA: 0x0008A7BC File Offset: 0x000889BC
		public ModelEditorViewport(#oW projectContext, ICoreServices services, #qW designEngineService, #yBe diagramExporter, #tbb diagramsContext, #dU toolsContext, #mAe superImposeContext)
		{
			this.#a = services;
			this.#b = designEngineService;
			this.#c = diagramExporter;
			this.#d = diagramsContext;
			this.#e = superImposeContext;
			this.#f = new #3Jb(services.Settings, projectContext, services.UndoManager, services.SnappingCache, services.ReporterSettings, services.Logger, toolsContext);
			this.#g = new ModelRenderer(this.EditorContext, designEngineService, this);
			this.#j = new DrawingHelper(this.Editor);
		}

		// Token: 0x170002BC RID: 700
		// (get) Token: 0x06000588 RID: 1416 RVA: 0x0008A848 File Offset: 0x00088A48
		public override object View
		{
			get
			{
				#qg #qg = this.EditorContext.ViewportOptions.PresenterType;
				if (#qg == #qg.#a)
				{
					return this.Editor;
				}
				if (#qg - #qg.#b > 1)
				{
					throw new ArgumentOutOfRangeException();
				}
				IDiagramPresenterViewModel diagramPresenterViewModel = this.DiagramPresenter;
				if (diagramPresenterViewModel == null)
				{
					return null;
				}
				return diagramPresenterViewModel.View;
			}
		}

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x06000589 RID: 1417 RVA: 0x0000A069 File Offset: 0x00008269
		public ColumnEditor Editor
		{
			get
			{
				return (ColumnEditor)this.EditorContext.Editor;
			}
		}

		// Token: 0x170002BE RID: 702
		// (get) Token: 0x0600058A RID: 1418 RVA: 0x0000A087 File Offset: 0x00008287
		public #cLb EditorContext { get; }

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x0600058B RID: 1419 RVA: 0x0000A093 File Offset: 0x00008293
		public #WV Renderer { get; }

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x0600058C RID: 1420 RVA: 0x0000A09F File Offset: 0x0000829F
		// (set) Token: 0x0600058D RID: 1421 RVA: 0x0000A0AB File Offset: 0x000082AB
		public #lte ReportingModel { get; set; }

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x0600058E RID: 1422 RVA: 0x0000A0BC File Offset: 0x000082BC
		// (set) Token: 0x0600058F RID: 1423 RVA: 0x0000A0C8 File Offset: 0x000082C8
		public IDiagramPresenterViewModel DiagramPresenter { get; private set; }

		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x06000590 RID: 1424 RVA: 0x0000A0D9 File Offset: 0x000082D9
		public DrawingHelper DrawingHelper { get; }

		// Token: 0x06000591 RID: 1425 RVA: 0x0000A0E5 File Offset: 0x000082E5
		public void #Nd(#lte #Od)
		{
			this.ReportingModel = #Od;
			IDiagramPresenterViewModel diagramPresenterViewModel = this.DiagramPresenter;
			if (diagramPresenterViewModel == null)
			{
				return;
			}
			diagramPresenterViewModel.#hz(#Od);
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x0008A89C File Offset: 0x00088A9C
		public void #Pd(ActivateDiagramParameters #Qd, bool #Rd = false, IList<SelectedLoadData> #Sd = null)
		{
			ModelEditorViewport.#KTb #KTb = new ModelEditorViewport.#KTb();
			#KTb.#a = this;
			#KTb.#b = #Qd;
			DiagramPresenterType presenterType = #KTb.#b.PresenterType;
			Diagram2DType? diagram2DType = #KTb.#b.Diagram2DType;
			Diagram3DCutType? cutType = #KTb.#b.CutType;
			if (this.DiagramPresenter == null)
			{
				this.DiagramPresenter = new DiagramPresenterViewModel(new Lazy<IDiagramPresenterView>(new Func<IDiagramPresenterView>(ModelEditorViewport.<>c.<>9.#LTb)), this.#a, base.Host, this.#a.Settings, this.#a.ReporterSettings, this.#a.ExceptionHandler, this.#c, this.#b, this.#e, this.#d);
				this.DiagramPresenter.AxialLoad = this.#d.CurrentAxialLoad;
				this.DiagramPresenter.Angle = this.#d.CurrentAngle;
				if (presenterType == DiagramPresenterType.#b && diagram2DType != null)
				{
					this.DiagramPresenter.#Qdb(diagram2DType.Value);
				}
				this.DiagramPresenter.#Mdb(#Sd);
				this.DiagramPresenter.#Vdb(#KTb.#b.PresenterType);
				this.DiagramPresenter.IsReportSourceValid = this.#d.IsReportSourceValid;
				if (#Rd)
				{
					LayoutHelper.BeginInvokeOnApplicationThread(new Action(#KTb.#JTb));
				}
				else
				{
					this.#Vd(#KTb.#b);
				}
			}
			else
			{
				this.DiagramPresenter.IsReportSourceValid = this.#d.IsReportSourceValid;
				this.DiagramPresenter.#Pd(#KTb.#b);
			}
			this.EditorContext.ViewportOptions.PresenterType = ((#KTb.#b.PresenterType == DiagramPresenterType.#b) ? #qg.#b : #qg.#c);
			this.EditorContext.ViewportOptions.ActivateDiagramParameters = #KTb.#b;
			this.#Wd();
			this.DiagramPresenter.IsActive = true;
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x0000A10B File Offset: 0x0000830B
		public void #Td()
		{
			this.EditorContext.ViewportOptions.PresenterType = #qg.#a;
			this.#Wd();
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#Xd));
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x0008AA98 File Offset: 0x00088C98
		public void #Ed()
		{
			#zLb #zLb = base.ScopeSettings.ActiveScope;
			if (#zLb == null)
			{
				return;
			}
			if (this.EditorContext.ViewportOptions.PresenterType == #qg.#a)
			{
				string value = #zLb.#7vb(this);
				if (!string.IsNullOrWhiteSpace(value))
				{
					base.Host.Header = value;
					return;
				}
			}
			else
			{
				IDiagramPresenterViewModel diagramPresenterViewModel = this.DiagramPresenter;
				if (diagramPresenterViewModel == null)
				{
					return;
				}
				diagramPresenterViewModel.#6db();
			}
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x0000A142 File Offset: 0x00008342
		public override void #Ud()
		{
			Ignore.#14d<Exception>(new Action(this.#Zd), null);
			Ignore.#14d<Exception>(new Action(this.#0d), null);
			base.#Ud();
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x0008AB00 File Offset: 0x00088D00
		private void #Vd(ActivateDiagramParameters #Qd)
		{
			DiagramPresenterType presenterType = #Qd.PresenterType;
			Diagram3DCutType? cutType = #Qd.CutType;
			this.DiagramPresenter.#hz(this.ReportingModel);
			if (presenterType == DiagramPresenterType.#a && cutType != null)
			{
				IDiagramPresenterViewModel diagramPresenterViewModel = this.DiagramPresenter;
				diagramPresenterViewModel.DefinedDiagram3DCutType = cutType.Value;
				Diagram3DCutType? diagram3DCutType = cutType;
				Diagram3DCutType diagram3DCutType2 = Diagram3DCutType.#b;
				if (diagram3DCutType.GetValueOrDefault() == diagram3DCutType2 & diagram3DCutType != null)
				{
					diagramPresenterViewModel.Diagram3DIsHorizontalCutEnabled = true;
					diagramPresenterViewModel.Diagram3DIsVerticalCutEnabled = false;
				}
				else
				{
					diagram3DCutType = cutType;
					diagram3DCutType2 = Diagram3DCutType.#c;
					if (diagram3DCutType.GetValueOrDefault() == diagram3DCutType2 & diagram3DCutType != null)
					{
						diagramPresenterViewModel.Diagram3DIsHorizontalCutEnabled = false;
						diagramPresenterViewModel.Diagram3DIsVerticalCutEnabled = true;
					}
					else
					{
						diagramPresenterViewModel.Diagram3DIsHorizontalCutEnabled = false;
						diagramPresenterViewModel.Diagram3DIsVerticalCutEnabled = false;
					}
				}
			}
			this.DiagramPresenter.#Pd(#Qd);
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x0000A17C File Offset: 0x0000837C
		private void #Wd()
		{
			base.RaisePropertyChanged(#Phc.#3hc(107384706));
			base.Host.#xe();
			base.Host.#od(this.View);
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x0000A1B6 File Offset: 0x000083B6
		[CompilerGenerated]
		private void #Xd()
		{
			this.Renderer.#9f(false, false);
			Ignore.#14d<Exception>(new Action(this.#Yd), null);
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x0000A1E4 File Offset: 0x000083E4
		[CompilerGenerated]
		private void #Yd()
		{
			ColumnEditor columnEditor = this.Editor;
			if (columnEditor == null)
			{
				return;
			}
			columnEditor.ZoomFitExt(false);
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x0000A1FF File Offset: 0x000083FF
		[CompilerGenerated]
		private void #Zd()
		{
			#cLb #cLb = this.EditorContext;
			if (#cLb == null)
			{
				return;
			}
			#cLb.Dispose();
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x0000A219 File Offset: 0x00008419
		[CompilerGenerated]
		private void #0d()
		{
			IDiagramPresenterViewModel diagramPresenterViewModel = this.DiagramPresenter;
			if (diagramPresenterViewModel == null)
			{
				return;
			}
			diagramPresenterViewModel.Dispose();
		}

		// Token: 0x04000124 RID: 292
		private readonly ICoreServices #a;

		// Token: 0x04000125 RID: 293
		private readonly #qW #b;

		// Token: 0x04000126 RID: 294
		private readonly #yBe #c;

		// Token: 0x04000127 RID: 295
		private readonly #tbb #d;

		// Token: 0x04000128 RID: 296
		private readonly #mAe #e;

		// Token: 0x04000129 RID: 297
		[CompilerGenerated]
		private readonly #cLb #f;

		// Token: 0x0400012A RID: 298
		[CompilerGenerated]
		private readonly #WV #g;

		// Token: 0x0400012B RID: 299
		[CompilerGenerated]
		private #lte #h;

		// Token: 0x0400012C RID: 300
		[CompilerGenerated]
		private IDiagramPresenterViewModel #i;

		// Token: 0x0400012D RID: 301
		[CompilerGenerated]
		private readonly DrawingHelper #j;

		// Token: 0x020000AD RID: 173
		[CompilerGenerated]
		private sealed class #KTb
		{
			// Token: 0x060005A0 RID: 1440 RVA: 0x0000A24E File Offset: 0x0000844E
			internal void #JTb()
			{
				this.#a.#Vd(this.#b);
			}

			// Token: 0x04000130 RID: 304
			public ModelEditorViewport #a;

			// Token: 0x04000131 RID: 305
			public ActivateDiagramParameters #b;
		}
	}
}
