using System;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;

namespace #3Rd
{
	// Token: 0x02000E1B RID: 3611
	internal sealed class #iSd : NotifyPropertyChangedObjectBase
	{
		// Token: 0x060081E2 RID: 33250 RVA: 0x001C3458 File Offset: 0x001C1658
		public #iSd()
		{
			this.#c = (this.#d = (this.#e = (this.#f = (this.#g = true))));
		}

		// Token: 0x170026C2 RID: 9922
		// (get) Token: 0x060081E3 RID: 33251 RVA: 0x00069B19 File Offset: 0x00067D19
		// (set) Token: 0x060081E4 RID: 33252 RVA: 0x00069B25 File Offset: 0x00067D25
		public bool IsWordFormatEnabled
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					this.#c = value;
					base.RaisePropertyChanged(#Phc.#3hc(107277586));
				}
			}
		}

		// Token: 0x170026C3 RID: 9923
		// (get) Token: 0x060081E5 RID: 33253 RVA: 0x00069B53 File Offset: 0x00067D53
		// (set) Token: 0x060081E6 RID: 33254 RVA: 0x00069B5F File Offset: 0x00067D5F
		public bool IsPdfFormatEnabled
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.#d != value)
				{
					this.#d = value;
					base.RaisePropertyChanged(#Phc.#3hc(107277045));
				}
			}
		}

		// Token: 0x170026C4 RID: 9924
		// (get) Token: 0x060081E7 RID: 33255 RVA: 0x00069B8D File Offset: 0x00067D8D
		// (set) Token: 0x060081E8 RID: 33256 RVA: 0x00069B99 File Offset: 0x00067D99
		public bool IsTextFormatEnabled
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (this.#e != value)
				{
					this.#e = value;
					base.RaisePropertyChanged(#Phc.#3hc(107277020));
				}
			}
		}

		// Token: 0x170026C5 RID: 9925
		// (get) Token: 0x060081E9 RID: 33257 RVA: 0x00069BC7 File Offset: 0x00067DC7
		// (set) Token: 0x060081EA RID: 33258 RVA: 0x00069BD3 File Offset: 0x00067DD3
		public bool IsExcelFormatEnabled
		{
			get
			{
				return this.#f;
			}
			set
			{
				if (this.#f != value)
				{
					this.#f = value;
					base.RaisePropertyChanged(#Phc.#3hc(107276991));
				}
			}
		}

		// Token: 0x170026C6 RID: 9926
		// (get) Token: 0x060081EB RID: 33259 RVA: 0x00069C01 File Offset: 0x00067E01
		// (set) Token: 0x060081EC RID: 33260 RVA: 0x00069C0D File Offset: 0x00067E0D
		public bool IsCsvFormatEnabled
		{
			get
			{
				return this.#g;
			}
			set
			{
				if (this.#g != value)
				{
					this.#g = value;
					base.RaisePropertyChanged(#Phc.#3hc(107276930));
				}
			}
		}

		// Token: 0x170026C7 RID: 9927
		// (get) Token: 0x060081ED RID: 33261 RVA: 0x00069C3B File Offset: 0x00067E3B
		// (set) Token: 0x060081EE RID: 33262 RVA: 0x00069C47 File Offset: 0x00067E47
		public bool IsReportFileFormatChangeAllowed
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					this.#b = value;
					base.RaisePropertyChanged(#Phc.#3hc(107276905));
				}
			}
		}

		// Token: 0x170026C8 RID: 9928
		// (get) Token: 0x060081EF RID: 33263 RVA: 0x00069C75 File Offset: 0x00067E75
		// (set) Token: 0x060081F0 RID: 33264 RVA: 0x00069C81 File Offset: 0x00067E81
		public ReportFileFormat SelectedFileFormat
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value)
				{
					this.#a = value;
					base.RaisePropertyChanged(#Phc.#3hc(107276892));
				}
			}
		}

		// Token: 0x0400353F RID: 13631
		private ReportFileFormat #a;

		// Token: 0x04003540 RID: 13632
		private bool #b = true;

		// Token: 0x04003541 RID: 13633
		private bool #c;

		// Token: 0x04003542 RID: 13634
		private bool #d;

		// Token: 0x04003543 RID: 13635
		private bool #e;

		// Token: 0x04003544 RID: 13636
		private bool #f;

		// Token: 0x04003545 RID: 13637
		private bool #g;
	}
}
