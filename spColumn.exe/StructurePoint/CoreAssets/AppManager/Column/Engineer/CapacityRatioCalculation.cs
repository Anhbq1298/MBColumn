using System;
using System.Runtime.CompilerServices;
using #9Ue;
using #gMe;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.NewCapacityRatio;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer
{
	// Token: 0x0200129A RID: 4762
	public sealed class CapacityRatioCalculation
	{
		// Token: 0x17002DE4 RID: 11748
		// (get) Token: 0x06009F86 RID: 40838 RVA: 0x0007D644 File Offset: 0x0007B844
		// (set) Token: 0x06009F87 RID: 40839 RVA: 0x0007D64C File Offset: 0x0007B84C
		public float Mu { get; set; }

		// Token: 0x17002DE5 RID: 11749
		// (get) Token: 0x06009F88 RID: 40840 RVA: 0x0007D655 File Offset: 0x0007B855
		// (set) Token: 0x06009F89 RID: 40841 RVA: 0x0007D65D File Offset: 0x0007B85D
		public float? PhiPn { get; set; }

		// Token: 0x17002DE6 RID: 11750
		// (get) Token: 0x06009F8A RID: 40842 RVA: 0x0007D666 File Offset: 0x0007B866
		// (set) Token: 0x06009F8B RID: 40843 RVA: 0x0007D66E File Offset: 0x0007B86E
		public float? PhiMn { get; set; }

		// Token: 0x17002DE7 RID: 11751
		// (get) Token: 0x06009F8C RID: 40844 RVA: 0x0007D677 File Offset: 0x0007B877
		// (set) Token: 0x06009F8D RID: 40845 RVA: 0x0007D67F File Offset: 0x0007B87F
		public float? PhiMnx { get; set; }

		// Token: 0x17002DE8 RID: 11752
		// (get) Token: 0x06009F8E RID: 40846 RVA: 0x0007D688 File Offset: 0x0007B888
		// (set) Token: 0x06009F8F RID: 40847 RVA: 0x0007D690 File Offset: 0x0007B890
		public float? PhiMny { get; set; }

		// Token: 0x17002DE9 RID: 11753
		// (get) Token: 0x06009F90 RID: 40848 RVA: 0x0007D699 File Offset: 0x0007B899
		// (set) Token: 0x06009F91 RID: 40849 RVA: 0x0007D6A1 File Offset: 0x0007B8A1
		public float? NaDepth { get; set; }

		// Token: 0x17002DEA RID: 11754
		// (get) Token: 0x06009F92 RID: 40850 RVA: 0x0007D6AA File Offset: 0x0007B8AA
		// (set) Token: 0x06009F93 RID: 40851 RVA: 0x0007D6B2 File Offset: 0x0007B8B2
		public float? EpsilonT { get; set; }

		// Token: 0x17002DEB RID: 11755
		// (get) Token: 0x06009F94 RID: 40852 RVA: 0x0007D6BB File Offset: 0x0007B8BB
		// (set) Token: 0x06009F95 RID: 40853 RVA: 0x0007D6C3 File Offset: 0x0007B8C3
		public float? Phi { get; set; }

		// Token: 0x17002DEC RID: 11756
		// (get) Token: 0x06009F96 RID: 40854 RVA: 0x0007D6CC File Offset: 0x0007B8CC
		// (set) Token: 0x06009F97 RID: 40855 RVA: 0x0007D6D4 File Offset: 0x0007B8D4
		public string DisplayValue { get; set; }

		// Token: 0x17002DED RID: 11757
		// (get) Token: 0x06009F98 RID: 40856 RVA: 0x0007D6DD File Offset: 0x0007B8DD
		// (set) Token: 0x06009F99 RID: 40857 RVA: 0x0007D6E5 File Offset: 0x0007B8E5
		public double? NumericValue { get; set; }

		// Token: 0x17002DEE RID: 11758
		// (get) Token: 0x06009F9A RID: 40858 RVA: 0x0007D6EE File Offset: 0x0007B8EE
		// (set) Token: 0x06009F9B RID: 40859 RVA: 0x0007D6F6 File Offset: 0x0007B8F6
		public bool IsExceeded { get; set; }

		// Token: 0x17002DEF RID: 11759
		// (get) Token: 0x06009F9C RID: 40860 RVA: 0x0007D6FF File Offset: 0x0007B8FF
		// (set) Token: 0x06009F9D RID: 40861 RVA: 0x0007D707 File Offset: 0x0007B907
		public #YNe Flags { get; set; }

		// Token: 0x06009F9E RID: 40862 RVA: 0x0007D710 File Offset: 0x0007B910
		public void #bNe()
		{
			this.DisplayValue = CapacityRatioHelper.GreaterThanOne;
			this.IsExceeded = true;
			this.#eNe();
		}

		// Token: 0x06009F9F RID: 40863 RVA: 0x0007D72A File Offset: 0x0007B92A
		public void #cNe()
		{
			this.DisplayValue = CapacityRatioHelper.SmallerThanOne;
			this.IsExceeded = false;
			this.#eNe();
		}

		// Token: 0x06009FA0 RID: 40864 RVA: 0x0021DE9C File Offset: 0x0021C09C
		public void #dNe(#xVe #Pc)
		{
			this.PhiPn = #Pc.PhiPn;
			this.PhiMn = #Pc.PhiMn;
			this.EpsilonT = #Pc.Eps;
			this.NaDepth = #Pc.Nadepth;
			this.Phi = #Pc.Phi;
			float? num = #Pc.Usf;
			this.NumericValue = ((num != null) ? new double?((double)num.GetValueOrDefault()) : null);
		}

		// Token: 0x06009FA1 RID: 40865 RVA: 0x0021DF14 File Offset: 0x0021C114
		private void #eNe()
		{
			this.EpsilonT = null;
			this.NaDepth = null;
			this.Phi = null;
			this.PhiMn = null;
			this.PhiPn = null;
		}

		// Token: 0x040045A5 RID: 17829
		[CompilerGenerated]
		private float #a;

		// Token: 0x040045A6 RID: 17830
		[CompilerGenerated]
		private float? #b;

		// Token: 0x040045A7 RID: 17831
		[CompilerGenerated]
		private float? #c;

		// Token: 0x040045A8 RID: 17832
		[CompilerGenerated]
		private float? #d;

		// Token: 0x040045A9 RID: 17833
		[CompilerGenerated]
		private float? #e;

		// Token: 0x040045AA RID: 17834
		[CompilerGenerated]
		private float? #f;

		// Token: 0x040045AB RID: 17835
		[CompilerGenerated]
		private float? #g;

		// Token: 0x040045AC RID: 17836
		[CompilerGenerated]
		private float? #h;

		// Token: 0x040045AD RID: 17837
		[CompilerGenerated]
		private string #i;

		// Token: 0x040045AE RID: 17838
		[CompilerGenerated]
		private double? #j;

		// Token: 0x040045AF RID: 17839
		[CompilerGenerated]
		private bool #k;

		// Token: 0x040045B0 RID: 17840
		[CompilerGenerated]
		private #YNe #l;
	}
}
