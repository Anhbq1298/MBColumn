using System;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Model
{
	// Token: 0x02001172 RID: 4466
	[Serializable]
	public sealed class GeneralInformation
	{
		// Token: 0x17002BF0 RID: 11248
		// (get) Token: 0x0600974B RID: 38731 RVA: 0x00078622 File Offset: 0x00076822
		// (set) Token: 0x0600974C RID: 38732 RVA: 0x0007862A File Offset: 0x0007682A
		public string LicenseType { get; set; }

		// Token: 0x17002BF1 RID: 11249
		// (get) Token: 0x0600974D RID: 38733 RVA: 0x00078633 File Offset: 0x00076833
		// (set) Token: 0x0600974E RID: 38734 RVA: 0x0007863B File Offset: 0x0007683B
		public string FileName { get; set; }

		// Token: 0x17002BF2 RID: 11250
		// (get) Token: 0x0600974F RID: 38735 RVA: 0x00078644 File Offset: 0x00076844
		// (set) Token: 0x06009750 RID: 38736 RVA: 0x0007864C File Offset: 0x0007684C
		public string LicenseeName { get; set; }

		// Token: 0x17002BF3 RID: 11251
		// (get) Token: 0x06009751 RID: 38737 RVA: 0x00078655 File Offset: 0x00076855
		// (set) Token: 0x06009752 RID: 38738 RVA: 0x0007865D File Offset: 0x0007685D
		public string LicenseId { get; set; }

		// Token: 0x17002BF4 RID: 11252
		// (get) Token: 0x06009753 RID: 38739 RVA: 0x00078666 File Offset: 0x00076866
		// (set) Token: 0x06009754 RID: 38740 RVA: 0x0007866E File Offset: 0x0007686E
		public string LockingCode { get; set; }

		// Token: 0x17002BF5 RID: 11253
		// (get) Token: 0x06009755 RID: 38741 RVA: 0x00078677 File Offset: 0x00076877
		// (set) Token: 0x06009756 RID: 38742 RVA: 0x0007867F File Offset: 0x0007687F
		public string ProductAndVersion { get; set; }

		// Token: 0x17002BF6 RID: 11254
		// (get) Token: 0x06009757 RID: 38743 RVA: 0x00078688 File Offset: 0x00076888
		// (set) Token: 0x06009758 RID: 38744 RVA: 0x00078690 File Offset: 0x00076890
		public string LicenseExpiration { get; set; }

		// Token: 0x17002BF7 RID: 11255
		// (get) Token: 0x06009759 RID: 38745 RVA: 0x00078699 File Offset: 0x00076899
		// (set) Token: 0x0600975A RID: 38746 RVA: 0x000786A1 File Offset: 0x000768A1
		public string LicenseServer { get; set; }

		// Token: 0x17002BF8 RID: 11256
		// (get) Token: 0x0600975B RID: 38747 RVA: 0x000786AA File Offset: 0x000768AA
		// (set) Token: 0x0600975C RID: 38748 RVA: 0x000786B2 File Offset: 0x000768B2
		public bool IsTrial { get; set; }

		// Token: 0x17002BF9 RID: 11257
		// (get) Token: 0x0600975D RID: 38749 RVA: 0x000786BB File Offset: 0x000768BB
		// (set) Token: 0x0600975E RID: 38750 RVA: 0x000786D7 File Offset: 0x000768D7
		public string UnitStringD
		{
			get
			{
				if (this.unitStringD == null)
				{
					return this.unitStringD;
				}
				return this.unitStringD.Trim();
			}
			set
			{
				this.unitStringD = value;
			}
		}

		// Token: 0x17002BFA RID: 11258
		// (get) Token: 0x0600975F RID: 38751 RVA: 0x000786E0 File Offset: 0x000768E0
		// (set) Token: 0x06009760 RID: 38752 RVA: 0x000786FC File Offset: 0x000768FC
		public string UnitStringL
		{
			get
			{
				if (this.unitStringL == null)
				{
					return this.unitStringL;
				}
				return this.unitStringL.Trim();
			}
			set
			{
				this.unitStringL = value;
			}
		}

		// Token: 0x17002BFB RID: 11259
		// (get) Token: 0x06009761 RID: 38753 RVA: 0x00078705 File Offset: 0x00076905
		// (set) Token: 0x06009762 RID: 38754 RVA: 0x00078721 File Offset: 0x00076921
		public string UnitStringF
		{
			get
			{
				if (this.unitStringF == null)
				{
					return this.unitStringF;
				}
				return this.unitStringF.Trim();
			}
			set
			{
				this.unitStringF = value;
			}
		}

		// Token: 0x17002BFC RID: 11260
		// (get) Token: 0x06009763 RID: 38755 RVA: 0x0007872A File Offset: 0x0007692A
		// (set) Token: 0x06009764 RID: 38756 RVA: 0x00078746 File Offset: 0x00076946
		public string UnitStringM
		{
			get
			{
				if (this.unitStringM == null)
				{
					return this.unitStringM;
				}
				return this.unitStringM.Trim();
			}
			set
			{
				this.unitStringM = value;
			}
		}

		// Token: 0x17002BFD RID: 11261
		// (get) Token: 0x06009765 RID: 38757 RVA: 0x0007874F File Offset: 0x0007694F
		// (set) Token: 0x06009766 RID: 38758 RVA: 0x0007876B File Offset: 0x0007696B
		public string UnitStringS
		{
			get
			{
				if (this.unitStringS == null)
				{
					return this.unitStringS;
				}
				return this.unitStringS.Trim();
			}
			set
			{
				this.unitStringS = value;
			}
		}

		// Token: 0x17002BFE RID: 11262
		// (get) Token: 0x06009767 RID: 38759 RVA: 0x00078774 File Offset: 0x00076974
		// (set) Token: 0x06009768 RID: 38760 RVA: 0x00078790 File Offset: 0x00076990
		public string UnitStringW
		{
			get
			{
				if (this.unitStringW == null)
				{
					return this.unitStringW;
				}
				return this.unitStringW.Trim();
			}
			set
			{
				this.unitStringW = value;
			}
		}

		// Token: 0x040040FE RID: 16638
		private string unitStringD;

		// Token: 0x040040FF RID: 16639
		private string unitStringL;

		// Token: 0x04004100 RID: 16640
		private string unitStringF;

		// Token: 0x04004101 RID: 16641
		private string unitStringM;

		// Token: 0x04004102 RID: 16642
		private string unitStringS;

		// Token: 0x04004103 RID: 16643
		private string unitStringW;
	}
}
