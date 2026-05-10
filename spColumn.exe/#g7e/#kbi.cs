using System;
using System.Runtime.CompilerServices;
using System.Text;
using #7hc;

namespace #g7e
{
	// Token: 0x0200138A RID: 5002
	internal sealed class #kbi
	{
		// Token: 0x1700308B RID: 12427
		// (get) Token: 0x0600A75D RID: 42845 RVA: 0x000821DE File Offset: 0x000803DE
		// (set) Token: 0x0600A75E RID: 42846 RVA: 0x000821E6 File Offset: 0x000803E6
		public bool IsNominal { get; set; }

		// Token: 0x1700308C RID: 12428
		// (get) Token: 0x0600A75F RID: 42847 RVA: 0x000821EF File Offset: 0x000803EF
		// (set) Token: 0x0600A760 RID: 42848 RVA: 0x000821F7 File Offset: 0x000803F7
		public float? Angle { get; set; }

		// Token: 0x1700308D RID: 12429
		// (get) Token: 0x0600A761 RID: 42849 RVA: 0x00082200 File Offset: 0x00080400
		// (set) Token: 0x0600A762 RID: 42850 RVA: 0x00082208 File Offset: 0x00080408
		public int? CurvePoint { get; set; }

		// Token: 0x1700308E RID: 12430
		// (get) Token: 0x0600A763 RID: 42851 RVA: 0x00082211 File Offset: 0x00080411
		// (set) Token: 0x0600A764 RID: 42852 RVA: 0x00082219 File Offset: 0x00080419
		public bool Interpolation2D { get; set; }

		// Token: 0x0600A765 RID: 42853 RVA: 0x00232920 File Offset: 0x00230B20
		public void #yJ()
		{
			this.IsNominal = false;
			this.Angle = null;
			this.CurvePoint = null;
			this.Interpolation2D = false;
		}

		// Token: 0x0600A766 RID: 42854 RVA: 0x0023295C File Offset: 0x00230B5C
		public string #jbi()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(this.IsNominal ? #Phc.#3hc(107311573) : #Phc.#3hc(107311554));
			if (this.CurvePoint != null)
			{
				stringBuilder.AppendLine(string.Format(#Phc.#3hc(107311528), this.CurvePoint + 1));
			}
			stringBuilder.AppendLine(#Phc.#3hc(107311551));
			if (this.Angle != null)
			{
				stringBuilder.Append(string.Format(#Phc.#3hc(107311546), this.Angle));
			}
			if (this.Interpolation2D)
			{
				stringBuilder.Append(#Phc.#3hc(107311493));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x04004A1C RID: 18972
		[CompilerGenerated]
		private bool #a;

		// Token: 0x04004A1D RID: 18973
		[CompilerGenerated]
		private float? #b;

		// Token: 0x04004A1E RID: 18974
		[CompilerGenerated]
		private int? #c;

		// Token: 0x04004A1F RID: 18975
		[CompilerGenerated]
		private bool #d;
	}
}
