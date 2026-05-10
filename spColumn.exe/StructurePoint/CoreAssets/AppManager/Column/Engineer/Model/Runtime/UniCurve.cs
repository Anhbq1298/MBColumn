using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime
{
	// Token: 0x0200133F RID: 4927
	[DebuggerDisplay("P= {AxialLoad}, MomentPositive= {PositiveSide.Moment}, MomentNegative={NegativeSide.Moment}")]
	public sealed class UniCurve
	{
		// Token: 0x17002F79 RID: 12153
		// (get) Token: 0x0600A4F5 RID: 42229 RVA: 0x00080C36 File Offset: 0x0007EE36
		// (set) Token: 0x0600A4F6 RID: 42230 RVA: 0x00080C3E File Offset: 0x0007EE3E
		public float AxialLoad { get; set; }

		// Token: 0x17002F7A RID: 12154
		// (get) Token: 0x0600A4F7 RID: 42231 RVA: 0x00080C47 File Offset: 0x0007EE47
		// (set) Token: 0x0600A4F8 RID: 42232 RVA: 0x00080C4F File Offset: 0x0007EE4F
		public bool PlotPoint { get; set; }

		// Token: 0x17002F7B RID: 12155
		// (get) Token: 0x0600A4F9 RID: 42233 RVA: 0x00080C58 File Offset: 0x0007EE58
		// (set) Token: 0x0600A4FA RID: 42234 RVA: 0x00080C60 File Offset: 0x0007EE60
		public UniCurveData PositiveSide { get; set; }

		// Token: 0x17002F7C RID: 12156
		// (get) Token: 0x0600A4FB RID: 42235 RVA: 0x00080C69 File Offset: 0x0007EE69
		// (set) Token: 0x0600A4FC RID: 42236 RVA: 0x00080C71 File Offset: 0x0007EE71
		public UniCurveData NegativeSide { get; set; }

		// Token: 0x0600A4FD RID: 42237 RVA: 0x00080C7A File Offset: 0x0007EE7A
		public static UniCurve #ul()
		{
			return new UniCurve
			{
				PositiveSide = new UniCurveData(),
				NegativeSide = new UniCurveData()
			};
		}

		// Token: 0x0600A4FE RID: 42238 RVA: 0x00230178 File Offset: 0x0022E378
		public static UniCurve[] #ul(int #1f)
		{
			UniCurve[] array = new UniCurve[#1f];
			for (int i = 0; i < #1f; i++)
			{
				array[i] = new UniCurve();
			}
			return array;
		}

		// Token: 0x0600A4FF RID: 42239 RVA: 0x002301A4 File Offset: 0x0022E3A4
		public UniCurve #L2e()
		{
			return new UniCurve
			{
				AxialLoad = this.AxialLoad,
				PlotPoint = this.PlotPoint,
				NegativeSide = this.NegativeSide.#L2e(),
				PositiveSide = this.PositiveSide.#L2e()
			};
		}

		// Token: 0x04004856 RID: 18518
		[CompilerGenerated]
		private float #a;

		// Token: 0x04004857 RID: 18519
		[CompilerGenerated]
		private bool #b;

		// Token: 0x04004858 RID: 18520
		[CompilerGenerated]
		private UniCurveData #c;

		// Token: 0x04004859 RID: 18521
		[CompilerGenerated]
		private UniCurveData #d;
	}
}
