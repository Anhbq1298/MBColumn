using System;
using System.Runtime.CompilerServices;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.DTO
{
	// Token: 0x02001229 RID: 4649
	public sealed class SelectedLoadData
	{
		// Token: 0x06009BAA RID: 39850 RVA: 0x000035C3 File Offset: 0x000017C3
		public SelectedLoadData()
		{
		}

		// Token: 0x06009BAB RID: 39851 RVA: 0x0007B06A File Offset: 0x0007926A
		public SelectedLoadData(SelectedLoadData other)
		{
			this.MomentX = other.MomentX;
			this.MomentY = other.MomentY;
			this.AxialForce = other.AxialForce;
			this.Number = other.Number;
		}

		// Token: 0x17002D1B RID: 11547
		// (get) Token: 0x06009BAC RID: 39852 RVA: 0x0007B0A2 File Offset: 0x000792A2
		// (set) Token: 0x06009BAD RID: 39853 RVA: 0x0007B0AA File Offset: 0x000792AA
		public double? MomentX { get; set; }

		// Token: 0x17002D1C RID: 11548
		// (get) Token: 0x06009BAE RID: 39854 RVA: 0x0007B0B3 File Offset: 0x000792B3
		// (set) Token: 0x06009BAF RID: 39855 RVA: 0x0007B0BB File Offset: 0x000792BB
		public double? MomentY { get; set; }

		// Token: 0x17002D1D RID: 11549
		// (get) Token: 0x06009BB0 RID: 39856 RVA: 0x0007B0C4 File Offset: 0x000792C4
		// (set) Token: 0x06009BB1 RID: 39857 RVA: 0x0007B0CC File Offset: 0x000792CC
		public double? AxialForce { get; set; }

		// Token: 0x17002D1E RID: 11550
		// (get) Token: 0x06009BB2 RID: 39858 RVA: 0x0007B0D5 File Offset: 0x000792D5
		// (set) Token: 0x06009BB3 RID: 39859 RVA: 0x0007B0DD File Offset: 0x000792DD
		public int? Number { get; set; }

		// Token: 0x06009BB4 RID: 39860 RVA: 0x00210504 File Offset: 0x0020E704
		public bool #e(SelectedLoadData #Gfb)
		{
			double? num = this.MomentX;
			double? num2 = #Gfb.MomentX;
			if (num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null))
			{
				num2 = this.MomentY;
				num = #Gfb.MomentY;
				if (num2.GetValueOrDefault() == num.GetValueOrDefault() & num2 != null == (num != null))
				{
					num = this.AxialForce;
					num2 = #Gfb.AxialForce;
					if (num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null))
					{
						int? num3 = this.Number;
						int? num4 = #Gfb.Number;
						return num3.GetValueOrDefault() == num4.GetValueOrDefault() & num3 != null == (num4 != null);
					}
				}
			}
			return false;
		}

		// Token: 0x04004332 RID: 17202
		[CompilerGenerated]
		private double? #a;

		// Token: 0x04004333 RID: 17203
		[CompilerGenerated]
		private double? #b;

		// Token: 0x04004334 RID: 17204
		[CompilerGenerated]
		private double? #c;

		// Token: 0x04004335 RID: 17205
		[CompilerGenerated]
		private int? #d;
	}
}
