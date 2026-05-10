using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using #7hc;
using #Aae;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Units.Formatters;

namespace #u9d
{
	// Token: 0x02000F90 RID: 3984
	internal sealed class #t9d : #x9d
	{
		// Token: 0x06008B1A RID: 35610 RVA: 0x00071390 File Offset: 0x0006F590
		public #t9d(double? #S0d, double? #T0d, bool #v9d, bool #w9d)
		{
			this.#a = #S0d;
			this.#b = #T0d;
			this.InclusiveMinValue = #v9d;
			this.InclusiveMaxValue = #w9d;
		}

		// Token: 0x06008B1B RID: 35611 RVA: 0x000713C4 File Offset: 0x0006F5C4
		public #t9d(double? #S0d, double? #T0d) : this(#S0d, #T0d, true, true)
		{
		}

		// Token: 0x170028AF RID: 10415
		// (get) Token: 0x06008B1C RID: 35612 RVA: 0x000713D0 File Offset: 0x0006F5D0
		public double? MinValue { get; }

		// Token: 0x170028B0 RID: 10416
		// (get) Token: 0x06008B1D RID: 35613 RVA: 0x000713DC File Offset: 0x0006F5DC
		public double? MaxValue { get; }

		// Token: 0x170028B1 RID: 10417
		// (get) Token: 0x06008B1E RID: 35614 RVA: 0x000713E8 File Offset: 0x0006F5E8
		// (set) Token: 0x06008B1F RID: 35615 RVA: 0x000713F4 File Offset: 0x0006F5F4
		public bool InclusiveMinValue { get; set; }

		// Token: 0x170028B2 RID: 10418
		// (get) Token: 0x06008B20 RID: 35616 RVA: 0x00071405 File Offset: 0x0006F605
		// (set) Token: 0x06008B21 RID: 35617 RVA: 0x00071411 File Offset: 0x0006F611
		public bool InclusiveMaxValue { get; set; }

		// Token: 0x170028B3 RID: 10419
		// (get) Token: 0x06008B22 RID: 35618 RVA: 0x00071422 File Offset: 0x0006F622
		// (set) Token: 0x06008B23 RID: 35619 RVA: 0x0007142E File Offset: 0x0006F62E
		public bool ForceFormatter { get; set; }

		// Token: 0x170028B4 RID: 10420
		// (get) Token: 0x06008B24 RID: 35620 RVA: 0x0007143F File Offset: 0x0006F63F
		// (set) Token: 0x06008B25 RID: 35621 RVA: 0x0007144B File Offset: 0x0006F64B
		public bool TrimTrailingZeroes { get; set; }

		// Token: 0x170028B5 RID: 10421
		// (get) Token: 0x06008B26 RID: 35622 RVA: 0x0007145C File Offset: 0x0006F65C
		// (set) Token: 0x06008B27 RID: 35623 RVA: 0x00071468 File Offset: 0x0006F668
		public double DisplayValueMultiplier { get; set; }

		// Token: 0x170028B6 RID: 10422
		// (get) Token: 0x06008B28 RID: 35624 RVA: 0x001DBBD8 File Offset: 0x001D9DD8
		private double? MinDisplayValue
		{
			get
			{
				double? num = this.MinValue;
				double num2 = this.DisplayValueMultiplier;
				if (num == null)
				{
					return null;
				}
				return new double?(num.GetValueOrDefault() * num2);
			}
		}

		// Token: 0x170028B7 RID: 10423
		// (get) Token: 0x06008B29 RID: 35625 RVA: 0x001DBC20 File Offset: 0x001D9E20
		private double? MaxDisplayValue
		{
			get
			{
				double? num = this.MaxValue;
				double num2 = this.DisplayValueMultiplier;
				if (num == null)
				{
					return null;
				}
				return new double?(num.GetValueOrDefault() * num2);
			}
		}

		// Token: 0x06008B2A RID: 35626 RVA: 0x001DBC68 File Offset: 0x001D9E68
		public #IWc #IH(IUnitValueFormatter #70c, double #f, string #80c)
		{
			bool flag = this.#bYi(#f);
			bool flag2 = this.#cYi(#f);
			if (this.MinValue != null && this.MaxValue != null && (flag2 || flag))
			{
				return new #IWc(this.#p9d(#70c));
			}
			if (this.MinValue != null && flag)
			{
				return new #IWc(this.#n9d(#70c));
			}
			if (this.MaxValue != null && flag2)
			{
				return new #IWc(this.#o9d(#70c));
			}
			return new #IWc(true);
		}

		// Token: 0x06008B2B RID: 35627 RVA: 0x001DBD1C File Offset: 0x001D9F1C
		public double #m9d(double #f)
		{
			double? num = this.MinValue;
			if (num != null)
			{
				#f = Math.Max(this.MinValue.Value, #f);
			}
			if (this.MaxValue != null)
			{
				#f = Math.Min(this.MaxValue.Value, #f);
			}
			return #f;
		}

		// Token: 0x06008B2C RID: 35628 RVA: 0x001DBD84 File Offset: 0x001D9F84
		public bool #bYi(double #f)
		{
			double? num = this.MinValue;
			if (num != null)
			{
				if (this.InclusiveMinValue)
				{
					num = this.MinValue;
					if (#f < num.GetValueOrDefault() & num != null)
					{
						return true;
					}
				}
				if (!this.InclusiveMinValue)
				{
					num = this.MinValue;
					if (#f <= num.GetValueOrDefault() & num != null)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06008B2D RID: 35629 RVA: 0x001DBDFC File Offset: 0x001D9FFC
		public bool #cYi(double #f)
		{
			double? num = this.MaxValue;
			if (num != null)
			{
				if (this.InclusiveMaxValue)
				{
					num = this.MaxValue;
					if (#f > num.GetValueOrDefault() & num != null)
					{
						return true;
					}
				}
				if (!this.InclusiveMaxValue)
				{
					num = this.MaxValue;
					if (#f >= num.GetValueOrDefault() & num != null)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06008B2E RID: 35630 RVA: 0x001DBE74 File Offset: 0x001DA074
		private string #n9d(IUnitValueFormatter #70c)
		{
			return (this.InclusiveMinValue ? Strings.StringTheValueShallBeGreaterOrEqualToX : Strings.StringTheValueShallBeGreaterThanX).#D2d(new object[]
			{
				this.#q9d(#70c, this.MinDisplayValue.GetValueOrDefault())
			}).#z2d();
		}

		// Token: 0x06008B2F RID: 35631 RVA: 0x001DBECC File Offset: 0x001DA0CC
		private string #o9d(IUnitValueFormatter #70c)
		{
			return (this.InclusiveMaxValue ? Strings.StringTheValueShouldBeLessThanOrEqualTo0 : Strings.StringTheValueShouldBeLessThanX).#D2d(new object[]
			{
				this.#q9d(#70c, this.MaxDisplayValue.GetValueOrDefault())
			}).#z2d();
		}

		// Token: 0x06008B30 RID: 35632 RVA: 0x001DBF24 File Offset: 0x001DA124
		private string #p9d(IUnitValueFormatter #70c)
		{
			string text;
			if (this.InclusiveMaxValue && this.InclusiveMinValue)
			{
				text = Strings.StringValueShallBeBetweenAAndB;
			}
			else if (this.InclusiveMinValue)
			{
				text = Strings.StringTheValueShallBeGreaterOrEqualToXAndSmallerThanY;
			}
			else if (this.InclusiveMaxValue)
			{
				text = Strings.StringTheValueShallBeGreaterThanXAndSmallerOrEqualToY;
			}
			else
			{
				text = Strings.StringTheValueShallBeGreaterThanXAndSmallerThanY;
			}
			return text.#D2d(new object[]
			{
				this.#q9d(#70c, this.MinDisplayValue.GetValueOrDefault()),
				this.#q9d(#70c, this.MaxDisplayValue.GetValueOrDefault())
			}).#z2d();
		}

		// Token: 0x06008B31 RID: 35633 RVA: 0x001DBFD0 File Offset: 0x001DA1D0
		private string #q9d(IUnitValueFormatter #70c, double #f)
		{
			string text = #f.ToString(CultureInfo.CurrentCulture);
			if (!this.ForceFormatter && #70c is FloatingPointUnitValueFormatter)
			{
				#70c = new FloatingPointUnitValueFormatter(3);
			}
			else if (!this.ForceFormatter && #70c is #Eae)
			{
				#70c = new #Eae(64);
			}
			string text2 = (#70c != null) ? #70c.CreateDisplayValue(text) : text;
			if (this.TrimTrailingZeroes)
			{
				text2 = ((#f == 0.0) ? #Phc.#3hc(107249275) : text2.TrimEnd(new char[]
				{
					'0'
				}).TrimEnd(new char[]
				{
					'.'
				}).TrimEnd(new char[]
				{
					','
				}));
			}
			return text2;
		}

		// Token: 0x04003991 RID: 14737
		[CompilerGenerated]
		private readonly double? #a;

		// Token: 0x04003992 RID: 14738
		[CompilerGenerated]
		private readonly double? #b;

		// Token: 0x04003993 RID: 14739
		[CompilerGenerated]
		private bool #c;

		// Token: 0x04003994 RID: 14740
		[CompilerGenerated]
		private bool #d;

		// Token: 0x04003995 RID: 14741
		[CompilerGenerated]
		private bool #e;

		// Token: 0x04003996 RID: 14742
		[CompilerGenerated]
		private bool #f;

		// Token: 0x04003997 RID: 14743
		[CompilerGenerated]
		private double #g = 1.0;
	}
}
