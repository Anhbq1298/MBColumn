using System;
using System.Runtime.CompilerServices;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime
{
	// Token: 0x02001340 RID: 4928
	public sealed class UniCurveData
	{
		// Token: 0x0600A501 RID: 42241 RVA: 0x00080C97 File Offset: 0x0007EE97
		public UniCurveData(float moment, float depthOfNeutralAxisC, float angleOfNeutralAxisCAngle, float barMaximumStrainEps, float reductionFactorPhi)
		{
			this.Moment = moment;
			this.DepthOfNeutralAxisC = depthOfNeutralAxisC;
			this.AngleOfNeutralAxisCAngle = angleOfNeutralAxisCAngle;
			this.BarMaximumStrainEps = barMaximumStrainEps;
			this.ReductionFactorPhi = reductionFactorPhi;
		}

		// Token: 0x0600A502 RID: 42242 RVA: 0x000035C3 File Offset: 0x000017C3
		public UniCurveData()
		{
		}

		// Token: 0x17002F7D RID: 12157
		// (get) Token: 0x0600A503 RID: 42243 RVA: 0x00080CC4 File Offset: 0x0007EEC4
		// (set) Token: 0x0600A504 RID: 42244 RVA: 0x00080CCC File Offset: 0x0007EECC
		public float Moment { get; set; }

		// Token: 0x17002F7E RID: 12158
		// (get) Token: 0x0600A505 RID: 42245 RVA: 0x00080CD5 File Offset: 0x0007EED5
		// (set) Token: 0x0600A506 RID: 42246 RVA: 0x00080CDD File Offset: 0x0007EEDD
		public float DepthOfNeutralAxisC { get; set; }

		// Token: 0x17002F7F RID: 12159
		// (get) Token: 0x0600A507 RID: 42247 RVA: 0x00080CE6 File Offset: 0x0007EEE6
		// (set) Token: 0x0600A508 RID: 42248 RVA: 0x00080CEE File Offset: 0x0007EEEE
		public float AngleOfNeutralAxisCAngle { get; set; }

		// Token: 0x17002F80 RID: 12160
		// (get) Token: 0x0600A509 RID: 42249 RVA: 0x00080CF7 File Offset: 0x0007EEF7
		// (set) Token: 0x0600A50A RID: 42250 RVA: 0x00080CFF File Offset: 0x0007EEFF
		public float BarMaximumStrainEps { get; set; }

		// Token: 0x17002F81 RID: 12161
		// (get) Token: 0x0600A50B RID: 42251 RVA: 0x00080D08 File Offset: 0x0007EF08
		// (set) Token: 0x0600A50C RID: 42252 RVA: 0x00080D10 File Offset: 0x0007EF10
		public float ReductionFactorPhi { get; set; }

		// Token: 0x0600A50D RID: 42253 RVA: 0x00080D19 File Offset: 0x0007EF19
		internal void #R2e(float #cpb, float #S2e, float #T2e, float #U2e, float #V2e)
		{
			this.Moment = #cpb;
			this.DepthOfNeutralAxisC = #S2e;
			this.AngleOfNeutralAxisCAngle = #T2e;
			this.BarMaximumStrainEps = #U2e;
			this.ReductionFactorPhi = #V2e;
		}

		// Token: 0x0600A50E RID: 42254 RVA: 0x00080D40 File Offset: 0x0007EF40
		public UniCurveData #L2e()
		{
			return new UniCurveData(this.Moment, this.DepthOfNeutralAxisC, this.AngleOfNeutralAxisCAngle, this.BarMaximumStrainEps, this.ReductionFactorPhi);
		}

		// Token: 0x0400485A RID: 18522
		[CompilerGenerated]
		private float #a;

		// Token: 0x0400485B RID: 18523
		[CompilerGenerated]
		private float #b;

		// Token: 0x0400485C RID: 18524
		[CompilerGenerated]
		private float #c;

		// Token: 0x0400485D RID: 18525
		[CompilerGenerated]
		private float #d;

		// Token: 0x0400485E RID: 18526
		[CompilerGenerated]
		private float #e;
	}
}
