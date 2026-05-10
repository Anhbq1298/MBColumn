using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using #eU;
using #hg;
using #Oze;
using #RJb;
using #S9;
using #UYd;
using #xBe;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.Products.Column.FailureSurface;
using StructurePoint.Products.Column.FailureSurface.ViewModels;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Viewports;
using StructurePoint.Products.Column.Viewports.API;
using Telerik.Windows.Controls;

namespace #Xc
{
	// Token: 0x02000094 RID: 148
	internal sealed class #Wc : ViewportsManager, INotifyPropertyChanged, #jg, #ud
	{
		// Token: 0x060004B9 RID: 1209 RVA: 0x000887E4 File Offset: 0x000869E4
		public #Wc(#oW #Yc, #dLb #Zc, ICoreServices #0c, #qW #1c, #yBe #2c, #rW #3c, #tbb #4c, #dU #5c, #mAe #6c) : base(#Yc, #Zc, #0c, #1c, #2c, #3c, #4c, #5c, #6c)
		{
			this.#a = #4c;
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x00088810 File Offset: 0x00086A10
		protected override void #Hc(#Fd #Ic, #Fd #G, #qg? #Jc = null)
		{
			base.#Hc(#Ic, #G, #Jc);
			if (#G != null && #G.EditorContext.ViewportOptions.ActivateDiagramParameters == null)
			{
				#G.EditorContext.ViewportOptions.PresenterType = #qg.#b;
				#G.EditorContext.ViewportOptions.ActivateDiagramParameters = ActivateDiagramParameters.Diagram2DPM;
			}
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x000099C8 File Offset: 0x00007BC8
		public void #Kc()
		{
			this.#Rc(ActivateDiagramParameters.Diagram2DPM, ActivateDiagramParameters.Diagram2DMM, true, true);
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x000099E9 File Offset: 0x00007BE9
		public void #Lc()
		{
			this.#Rc(ActivateDiagramParameters.Diagram2DPM, ActivateDiagramParameters.Diagram3DVertical, true, true);
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x00009A0A File Offset: 0x00007C0A
		public void #Mc()
		{
			this.#Rc(ActivateDiagramParameters.Diagram2DMM, ActivateDiagramParameters.Diagram3DHorizontal, true, true);
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x00088870 File Offset: 0x00086A70
		public void #Nc()
		{
			#Wc.#ITb #ITb = new #Wc.#ITb();
			#ITb.#a = this;
			base.#Df(null);
			#4d #4d = this.#Rc(ActivateDiagramParameters.Diagram2DMM, ActivateDiagramParameters.Diagram3DHorizontal, false, false);
			#ITb.#b = this.#Rc(ActivateDiagramParameters.Diagram2DPM, ActivateDiagramParameters.Diagram3DVertical, false, false);
			RadSplitContainer radSplitContainer = new RadSplitContainer
			{
				Orientation = Orientation.Vertical
			};
			radSplitContainer.Items.Add(#4d.Container);
			radSplitContainer.Items.Add(#ITb.#b.Container);
			base.#Qf(radSplitContainer);
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(#ITb.#HTb));
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x0008892C File Offset: 0x00086B2C
		private IModelEditorViewport #Oc(ActivateDiagramParameters #Pc, #Ke #Qc = null)
		{
			#qg value = (#Pc.PresenterType == DiagramPresenterType.#b) ? #qg.#b : #qg.#c;
			IModelEditorViewport modelEditorViewport = (IModelEditorViewport)base.#Of(#pg.#a, #Qc, new #qg?(value));
			modelEditorViewport.#Nd(base.ReportingApplicationContext.Model);
			modelEditorViewport.#Pd(#Pc, true, this.#a.SelectedLoads);
			return modelEditorViewport;
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x0008898C File Offset: 0x00086B8C
		private #4d #Rc(ActivateDiagramParameters #Sc, ActivateDiagramParameters #Tc, bool #Uc = true, bool #Vc = true)
		{
			if (#Uc)
			{
				#uzc #wzc = null;
				if (2 != 0)
				{
					base.#Df(#wzc);
				}
			}
			IModelEditorViewport modelEditorViewport = this.#Oc(#Sc, null);
			IModelEditorViewport modelEditorViewport2 = this.#Oc(#Tc, modelEditorViewport.Host);
			if (#Vc)
			{
				base.#Qf(modelEditorViewport2.Host.Container);
				base.#tf(modelEditorViewport2.Host.Pane);
			}
			return new #4d(modelEditorViewport.Host.Container, modelEditorViewport2, modelEditorViewport);
		}

		// Token: 0x040000E1 RID: 225
		private new readonly #tbb #a;

		// Token: 0x02000095 RID: 149
		[CompilerGenerated]
		private sealed class #ITb
		{
			// Token: 0x060004C2 RID: 1218 RVA: 0x00009A2B File Offset: 0x00007C2B
			internal void #HTb()
			{
				this.#a.#tf(this.#b.Viewport2.Host.Pane);
			}

			// Token: 0x040000E2 RID: 226
			public #Wc #a;

			// Token: 0x040000E3 RID: 227
			public #4d #b;
		}
	}
}
