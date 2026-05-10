using System;
using System.Runtime.CompilerServices;
using #hg;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.Products.Column.FailureSurface;
using StructurePoint.Products.Column.FailureSurface.ViewModels;

namespace #RJb
{
	// Token: 0x0200067F RID: 1663
	internal sealed class #aMb
	{
		// Token: 0x1700114A RID: 4426
		// (get) Token: 0x060037EE RID: 14318 RVA: 0x00030877 File Offset: 0x0002EA77
		// (set) Token: 0x060037EF RID: 14319 RVA: 0x00030883 File Offset: 0x0002EA83
		public #qg PresenterType { get; set; }

		// Token: 0x1700114B RID: 4427
		// (get) Token: 0x060037F0 RID: 14320 RVA: 0x00030894 File Offset: 0x0002EA94
		// (set) Token: 0x060037F1 RID: 14321 RVA: 0x000308A0 File Offset: 0x0002EAA0
		public DiagramPresenterType DiagramPresenterType { get; set; }

		// Token: 0x1700114C RID: 4428
		// (get) Token: 0x060037F2 RID: 14322 RVA: 0x000308B1 File Offset: 0x0002EAB1
		// (set) Token: 0x060037F3 RID: 14323 RVA: 0x0010F044 File Offset: 0x0010D244
		public ActivateDiagramParameters ActivateDiagramParameters
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.#a = value;
				if (value != null)
				{
					if (value.Diagram2DType != null)
					{
						this.Diagram2DType = value.Diagram2DType.Value;
					}
					if (value.CutType != null)
					{
						this.DefinedDiagram3DCutType = value.CutType.Value;
					}
					this.DiagramPresenterType = value.PresenterType;
				}
			}
		}

		// Token: 0x1700114D RID: 4429
		// (get) Token: 0x060037F4 RID: 14324 RVA: 0x000308BD File Offset: 0x0002EABD
		// (set) Token: 0x060037F5 RID: 14325 RVA: 0x000308C9 File Offset: 0x0002EAC9
		public Diagram2DType Diagram2DType { get; set; }

		// Token: 0x1700114E RID: 4430
		// (get) Token: 0x060037F6 RID: 14326 RVA: 0x000308DA File Offset: 0x0002EADA
		// (set) Token: 0x060037F7 RID: 14327 RVA: 0x000308E6 File Offset: 0x0002EAE6
		public double DiagramParameter { get; set; }

		// Token: 0x1700114F RID: 4431
		// (get) Token: 0x060037F8 RID: 14328 RVA: 0x000308F7 File Offset: 0x0002EAF7
		// (set) Token: 0x060037F9 RID: 14329 RVA: 0x00030903 File Offset: 0x0002EB03
		public Diagram3DCutType DefinedDiagram3DCutType { get; set; }

		// Token: 0x17001150 RID: 4432
		// (get) Token: 0x060037FA RID: 14330 RVA: 0x00030914 File Offset: 0x0002EB14
		public bool IsDiagramMMChecked
		{
			get
			{
				return this.DiagramPresenterType == DiagramPresenterType.#b && this.Diagram2DType == Diagram2DType.DiagramMM;
			}
		}

		// Token: 0x17001151 RID: 4433
		// (get) Token: 0x060037FB RID: 14331 RVA: 0x00030936 File Offset: 0x0002EB36
		public bool IsDiagramPMChecked
		{
			get
			{
				return this.DiagramPresenterType == DiagramPresenterType.#b && this.Diagram2DType == Diagram2DType.DiagramPM;
			}
		}

		// Token: 0x17001152 RID: 4434
		// (get) Token: 0x060037FC RID: 14332 RVA: 0x00030958 File Offset: 0x0002EB58
		public bool IsDiagramPMPlusChecked
		{
			get
			{
				return this.DiagramPresenterType == DiagramPresenterType.#b && this.Diagram2DType == Diagram2DType.DiagramPMPlus;
			}
		}

		// Token: 0x17001153 RID: 4435
		// (get) Token: 0x060037FD RID: 14333 RVA: 0x0003097A File Offset: 0x0002EB7A
		public bool IsDiagramPMMinusChecked
		{
			get
			{
				return this.DiagramPresenterType == DiagramPresenterType.#b && this.Diagram2DType == Diagram2DType.DiagramPMMinus;
			}
		}

		// Token: 0x17001154 RID: 4436
		// (get) Token: 0x060037FE RID: 14334 RVA: 0x0003099C File Offset: 0x0002EB9C
		public bool IsDiagramPMGroupChecked
		{
			get
			{
				return this.IsDiagramPMChecked || this.IsDiagramPMMinusChecked || this.IsDiagramPMPlusChecked;
			}
		}

		// Token: 0x17001155 RID: 4437
		// (get) Token: 0x060037FF RID: 14335 RVA: 0x000309C2 File Offset: 0x0002EBC2
		public bool IsDiagram3DHorizontalChecked
		{
			get
			{
				return this.DiagramPresenterType == DiagramPresenterType.#a && this.DefinedDiagram3DCutType == Diagram3DCutType.#b;
			}
		}

		// Token: 0x17001156 RID: 4438
		// (get) Token: 0x06003800 RID: 14336 RVA: 0x000309E3 File Offset: 0x0002EBE3
		public bool IsDiagram3DVerticalChecked
		{
			get
			{
				return this.DiagramPresenterType == DiagramPresenterType.#a && this.DefinedDiagram3DCutType == Diagram3DCutType.#c;
			}
		}

		// Token: 0x06003801 RID: 14337 RVA: 0x0010F0BC File Offset: 0x0010D2BC
		public void #mg(#aMb #mA)
		{
			this.PresenterType = #mA.PresenterType;
			this.ActivateDiagramParameters = #mA.ActivateDiagramParameters;
			this.DiagramParameter = #mA.DiagramParameter;
			this.DiagramPresenterType = #mA.DiagramPresenterType;
			this.Diagram2DType = #mA.Diagram2DType;
			this.DefinedDiagram3DCutType = #mA.DefinedDiagram3DCutType;
		}

		// Token: 0x04001770 RID: 6000
		private ActivateDiagramParameters #a;

		// Token: 0x04001771 RID: 6001
		[CompilerGenerated]
		private #qg #b;

		// Token: 0x04001772 RID: 6002
		[CompilerGenerated]
		private DiagramPresenterType #c;

		// Token: 0x04001773 RID: 6003
		[CompilerGenerated]
		private Diagram2DType #d;

		// Token: 0x04001774 RID: 6004
		[CompilerGenerated]
		private double #e;

		// Token: 0x04001775 RID: 6005
		[CompilerGenerated]
		private Diagram3DCutType #f;
	}
}
