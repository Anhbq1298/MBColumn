using System;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;

namespace StructurePoint.Products.Column.FailureSurface.ViewModels
{
	// Token: 0x020003F3 RID: 1011
	internal sealed class ActivateDiagramParameters
	{
		// Token: 0x060022DC RID: 8924 RVA: 0x000CB574 File Offset: 0x000C9774
		static ActivateDiagramParameters()
		{
			ActivateDiagramParameters.Diagram2DPMPlus = new ActivateDiagramParameters(StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings.Diagram2DType.DiagramPMPlus);
			ActivateDiagramParameters.Diagram2DPMMinus = new ActivateDiagramParameters(StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings.Diagram2DType.DiagramPMMinus);
			ActivateDiagramParameters.Diagram3DVertical = new ActivateDiagramParameters(Diagram3DCutType.#c);
			ActivateDiagramParameters.Diagram3DHorizontal = new ActivateDiagramParameters(Diagram3DCutType.#b);
		}

		// Token: 0x060022DD RID: 8925 RVA: 0x000219E4 File Offset: 0x0001FBE4
		public ActivateDiagramParameters(Diagram3DCutType cutType)
		{
			this.<CutType>k__BackingField = new Diagram3DCutType?(cutType);
			this.<PresenterType>k__BackingField = DiagramPresenterType.#a;
		}

		// Token: 0x060022DE RID: 8926 RVA: 0x000219FF File Offset: 0x0001FBFF
		public ActivateDiagramParameters(Diagram2DType diagram2DType)
		{
			this.<Diagram2DType>k__BackingField = new Diagram2DType?(diagram2DType);
			this.<PresenterType>k__BackingField = DiagramPresenterType.#b;
		}

		// Token: 0x060022DF RID: 8927 RVA: 0x00021A1A File Offset: 0x0001FC1A
		private ActivateDiagramParameters(ActivateDiagramParameters parameters)
		{
			this.Parameter = parameters.Parameter;
			this.<PresenterType>k__BackingField = parameters.PresenterType;
			this.<Diagram2DType>k__BackingField = parameters.Diagram2DType;
			this.<CutType>k__BackingField = parameters.CutType;
		}

		// Token: 0x17000C0A RID: 3082
		// (get) Token: 0x060022E0 RID: 8928 RVA: 0x00021A52 File Offset: 0x0001FC52
		public static ActivateDiagramParameters Diagram2DPM { get; } = new ActivateDiagramParameters(StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings.Diagram2DType.DiagramPM);

		// Token: 0x17000C0B RID: 3083
		// (get) Token: 0x060022E1 RID: 8929 RVA: 0x00021A59 File Offset: 0x0001FC59
		public static ActivateDiagramParameters Diagram2DPMPlus { get; }

		// Token: 0x17000C0C RID: 3084
		// (get) Token: 0x060022E2 RID: 8930 RVA: 0x00021A60 File Offset: 0x0001FC60
		public static ActivateDiagramParameters Diagram2DPMMinus { get; }

		// Token: 0x17000C0D RID: 3085
		// (get) Token: 0x060022E3 RID: 8931 RVA: 0x00021A67 File Offset: 0x0001FC67
		public static ActivateDiagramParameters Diagram2DMM { get; } = new ActivateDiagramParameters(StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings.Diagram2DType.DiagramMM);

		// Token: 0x17000C0E RID: 3086
		// (get) Token: 0x060022E4 RID: 8932 RVA: 0x00021A6E File Offset: 0x0001FC6E
		public static ActivateDiagramParameters Diagram3DHorizontal { get; }

		// Token: 0x17000C0F RID: 3087
		// (get) Token: 0x060022E5 RID: 8933 RVA: 0x00021A75 File Offset: 0x0001FC75
		public static ActivateDiagramParameters Diagram3DVertical { get; }

		// Token: 0x17000C10 RID: 3088
		// (get) Token: 0x060022E6 RID: 8934 RVA: 0x00021A7C File Offset: 0x0001FC7C
		public DiagramPresenterType PresenterType { get; }

		// Token: 0x17000C11 RID: 3089
		// (get) Token: 0x060022E7 RID: 8935 RVA: 0x00021A88 File Offset: 0x0001FC88
		public Diagram2DType? Diagram2DType { get; }

		// Token: 0x17000C12 RID: 3090
		// (get) Token: 0x060022E8 RID: 8936 RVA: 0x00021A94 File Offset: 0x0001FC94
		public Diagram3DCutType? CutType { get; }

		// Token: 0x17000C13 RID: 3091
		// (get) Token: 0x060022E9 RID: 8937 RVA: 0x00021AA0 File Offset: 0x0001FCA0
		// (set) Token: 0x060022EA RID: 8938 RVA: 0x00021AAC File Offset: 0x0001FCAC
		public double? Parameter { get; set; }

		// Token: 0x060022EB RID: 8939 RVA: 0x000CB5D0 File Offset: 0x000C97D0
		public ActivateDiagramParameters WithParameter(double value)
		{
			return new ActivateDiagramParameters(this)
			{
				Parameter = new double?(value)
			};
		}
	}
}
