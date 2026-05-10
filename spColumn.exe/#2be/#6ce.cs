using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.Units.Formatters;

namespace #2be
{
	// Token: 0x02001044 RID: 4164
	internal class #6ce
	{
		// Token: 0x06008E94 RID: 36500 RVA: 0x001E5BF8 File Offset: 0x001E3DF8
		public #6ce(double? #GT, double? #HT, bool #7ce = true, bool #8ce = true, int #8W = 2)
		{
			this.Min = #GT;
			this.Max = #HT;
			this.IncludeMin = (#7ce && #GT != null);
			this.IncludeMax = (#8ce && #HT != null);
			this.Precision = #8W;
		}

		// Token: 0x17002964 RID: 10596
		// (get) Token: 0x06008E95 RID: 36501 RVA: 0x0007387A File Offset: 0x00071A7A
		// (set) Token: 0x06008E96 RID: 36502 RVA: 0x00073882 File Offset: 0x00071A82
		public double? Min { get; set; }

		// Token: 0x17002965 RID: 10597
		// (get) Token: 0x06008E97 RID: 36503 RVA: 0x0007388B File Offset: 0x00071A8B
		// (set) Token: 0x06008E98 RID: 36504 RVA: 0x00073893 File Offset: 0x00071A93
		public double? Max { get; set; }

		// Token: 0x17002966 RID: 10598
		// (get) Token: 0x06008E99 RID: 36505 RVA: 0x0007389C File Offset: 0x00071A9C
		// (set) Token: 0x06008E9A RID: 36506 RVA: 0x000738A4 File Offset: 0x00071AA4
		public bool IncludeMin { get; set; }

		// Token: 0x17002967 RID: 10599
		// (get) Token: 0x06008E9B RID: 36507 RVA: 0x000738AD File Offset: 0x00071AAD
		// (set) Token: 0x06008E9C RID: 36508 RVA: 0x000738B5 File Offset: 0x00071AB5
		public bool IncludeMax { get; set; }

		// Token: 0x17002968 RID: 10600
		// (get) Token: 0x06008E9D RID: 36509 RVA: 0x000738BE File Offset: 0x00071ABE
		// (set) Token: 0x06008E9E RID: 36510 RVA: 0x000738CB File Offset: 0x00071ACB
		public int Precision
		{
			get
			{
				return this.Formatter.Precision;
			}
			set
			{
				this.Formatter.Precision = value;
			}
		}

		// Token: 0x17002969 RID: 10601
		// (get) Token: 0x06008E9F RID: 36511 RVA: 0x000738D9 File Offset: 0x00071AD9
		// (set) Token: 0x06008EA0 RID: 36512 RVA: 0x000738E1 File Offset: 0x00071AE1
		public double DisplayValueMultiplier { get; set; } = 1.0;

		// Token: 0x1700296A RID: 10602
		// (get) Token: 0x06008EA1 RID: 36513 RVA: 0x000738EA File Offset: 0x00071AEA
		public IUnitValueFormatter Formatter { get; } = new FloatingPointUnitValueFormatter(2);

		// Token: 0x06008EA2 RID: 36514 RVA: 0x001E5C64 File Offset: 0x001E3E64
		public #6ce #2ce()
		{
			if (this.Min != null)
			{
				this.Min = new double?(this.#3ce(this.Min.Value));
			}
			if (this.Max != null)
			{
				this.Max = new double?(this.#3ce(this.Max.Value));
			}
			return this;
		}

		// Token: 0x06008EA3 RID: 36515 RVA: 0x000738F2 File Offset: 0x00071AF2
		public double #3ce(double #f)
		{
			return Math.Round(#f, Math.Max(this.Precision * 2, 1));
		}

		// Token: 0x06008EA4 RID: 36516 RVA: 0x001E5CD0 File Offset: 0x001E3ED0
		public #6ce #83d(double #f)
		{
			return new #6ce(this.Min * #f, this.Max * #f, this.IncludeMin, this.IncludeMax, 2)
			{
				Precision = this.Precision,
				DisplayValueMultiplier = this.DisplayValueMultiplier
			};
		}

		// Token: 0x06008EA5 RID: 36517 RVA: 0x00073908 File Offset: 0x00071B08
		public virtual #6ce #4ce(double #5ce)
		{
			return new #6ce(this.Min, this.Max, this.IncludeMin, this.IncludeMax, this.Precision)
			{
				DisplayValueMultiplier = #5ce
			};
		}

		// Token: 0x04003BC4 RID: 15300
		[CompilerGenerated]
		private double? #a;

		// Token: 0x04003BC5 RID: 15301
		[CompilerGenerated]
		private double? #b;

		// Token: 0x04003BC6 RID: 15302
		[CompilerGenerated]
		private bool #c;

		// Token: 0x04003BC7 RID: 15303
		[CompilerGenerated]
		private bool #d;

		// Token: 0x04003BC8 RID: 15304
		[CompilerGenerated]
		private double #e;

		// Token: 0x04003BC9 RID: 15305
		[CompilerGenerated]
		private readonly IUnitValueFormatter #f;
	}
}
