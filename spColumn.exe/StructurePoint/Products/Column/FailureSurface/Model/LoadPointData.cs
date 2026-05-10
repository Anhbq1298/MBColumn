using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.Products.Column.FailureSurface.Model
{
	// Token: 0x02000452 RID: 1106
	internal sealed class LoadPointData
	{
		// Token: 0x060028AD RID: 10413 RVA: 0x00025670 File Offset: 0x00023870
		public LoadPointData(LoadPointDrawingData data)
		{
			this.MomentY = (double)data.MomentY;
			this.MomentX = (double)data.MomentX;
			this.AxialForce = (double)data.AxialLoad;
			this.IsInner = data.IsInner;
		}

		// Token: 0x17000DAD RID: 3501
		// (get) Token: 0x060028AE RID: 10414 RVA: 0x000256AB File Offset: 0x000238AB
		// (set) Token: 0x060028AF RID: 10415 RVA: 0x000256B7 File Offset: 0x000238B7
		public Point3D Center { get; set; }

		// Token: 0x17000DAE RID: 3502
		// (get) Token: 0x060028B0 RID: 10416 RVA: 0x000256C8 File Offset: 0x000238C8
		// (set) Token: 0x060028B1 RID: 10417 RVA: 0x000256D4 File Offset: 0x000238D4
		public bool IsInner { get; set; }

		// Token: 0x17000DAF RID: 3503
		// (get) Token: 0x060028B2 RID: 10418 RVA: 0x000256E5 File Offset: 0x000238E5
		// (set) Token: 0x060028B3 RID: 10419 RVA: 0x000256F1 File Offset: 0x000238F1
		public double MomentX { get; set; }

		// Token: 0x17000DB0 RID: 3504
		// (get) Token: 0x060028B4 RID: 10420 RVA: 0x00025702 File Offset: 0x00023902
		// (set) Token: 0x060028B5 RID: 10421 RVA: 0x0002570E File Offset: 0x0002390E
		public double MomentY { get; set; }

		// Token: 0x17000DB1 RID: 3505
		// (get) Token: 0x060028B6 RID: 10422 RVA: 0x0002571F File Offset: 0x0002391F
		// (set) Token: 0x060028B7 RID: 10423 RVA: 0x0002572B File Offset: 0x0002392B
		public double AxialForce { get; set; }

		// Token: 0x060028B8 RID: 10424 RVA: 0x000DC2E0 File Offset: 0x000DA4E0
		public bool #uC(double #2jb, double #0jb, double #1jb)
		{
			return Math.Abs(this.AxialForce - #2jb) < 0.01 && Math.Abs(this.MomentX - #0jb) < 0.01 && Math.Abs(this.MomentY - #1jb) < 0.01;
		}

		// Token: 0x04001023 RID: 4131
		[CompilerGenerated]
		private Point3D #a;

		// Token: 0x04001024 RID: 4132
		[CompilerGenerated]
		private bool #b;

		// Token: 0x04001025 RID: 4133
		[CompilerGenerated]
		private double #c;

		// Token: 0x04001026 RID: 4134
		[CompilerGenerated]
		private double #d;

		// Token: 0x04001027 RID: 4135
		[CompilerGenerated]
		private double #e;
	}
}
