using System;
using System.Runtime.CompilerServices;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace #qJ
{
	// Token: 0x020002CD RID: 717
	internal sealed class #dQ : NotifyPropertyChangedObjectBase
	{
		// Token: 0x060018C7 RID: 6343 RVA: 0x000B73EC File Offset: 0x000B55EC
		public #dQ()
		{
			this.#g = ColumnGlobalInfo.Copyright;
			this.#h = ColumnGlobalInfo.LongName;
		}

		// Token: 0x1700092C RID: 2348
		// (get) Token: 0x060018C8 RID: 6344 RVA: 0x00018F39 File Offset: 0x00017139
		public string Copyright { get; }

		// Token: 0x1700092D RID: 2349
		// (get) Token: 0x060018C9 RID: 6345 RVA: 0x00018F45 File Offset: 0x00017145
		public string ApplicationVersion { get; }

		// Token: 0x1700092E RID: 2350
		// (get) Token: 0x060018CA RID: 6346 RVA: 0x00018F51 File Offset: 0x00017151
		// (set) Token: 0x060018CB RID: 6347 RVA: 0x000B7468 File Offset: 0x000B5668
		public string LicenseType
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107401726));
					this.#a = value;
					base.RaisePropertyChanged(#Phc.#3hc(107401726));
				}
			}
		}

		// Token: 0x1700092F RID: 2351
		// (get) Token: 0x060018CC RID: 6348 RVA: 0x00018F5D File Offset: 0x0001715D
		// (set) Token: 0x060018CD RID: 6349 RVA: 0x000B74B8 File Offset: 0x000B56B8
		public string LicenseExpiration
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107401677));
					this.#b = value;
					base.RaisePropertyChanged(#Phc.#3hc(107401677));
				}
			}
		}

		// Token: 0x17000930 RID: 2352
		// (get) Token: 0x060018CE RID: 6350 RVA: 0x00018F69 File Offset: 0x00017169
		// (set) Token: 0x060018CF RID: 6351 RVA: 0x000B7508 File Offset: 0x000B5708
		public string LicenseServer
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107401684));
					this.#c = value;
					base.RaisePropertyChanged(#Phc.#3hc(107401684));
				}
			}
		}

		// Token: 0x17000931 RID: 2353
		// (get) Token: 0x060018D0 RID: 6352 RVA: 0x00018F75 File Offset: 0x00017175
		// (set) Token: 0x060018D1 RID: 6353 RVA: 0x000B7558 File Offset: 0x000B5758
		public string LicensedTo
		{
			get
			{
				return "Cracked by MADARA";
			}
			set
			{
				if (this.#d != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107401663));
					this.#d = value;
					base.RaisePropertyChanged(#Phc.#3hc(107401663));
				}
			}
		}

		// Token: 0x17000932 RID: 2354
		// (get) Token: 0x060018D2 RID: 6354 RVA: 0x00018F7C File Offset: 0x0001717C
		// (set) Token: 0x060018D3 RID: 6355 RVA: 0x000B75A8 File Offset: 0x000B57A8
		public string LicenseId
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (this.#e != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107401614));
					this.#e = value;
					base.RaisePropertyChanged(#Phc.#3hc(107401614));
				}
			}
		}

		// Token: 0x17000933 RID: 2355
		// (get) Token: 0x060018D4 RID: 6356 RVA: 0x00018F88 File Offset: 0x00017188
		// (set) Token: 0x060018D5 RID: 6357 RVA: 0x000B75F8 File Offset: 0x000B57F8
		public string LockingCode
		{
			get
			{
				return this.#f;
			}
			set
			{
				if (this.#f != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107401601));
					this.#f = value;
					base.RaisePropertyChanged(#Phc.#3hc(107401601));
				}
			}
		}

		// Token: 0x17000934 RID: 2356
		// (get) Token: 0x060018D6 RID: 6358 RVA: 0x00018F94 File Offset: 0x00017194
		// (set) Token: 0x060018D7 RID: 6359 RVA: 0x00018FA0 File Offset: 0x000171A0
		public bool IsTrial { get; set; }

		// Token: 0x04000987 RID: 2439
		private string #a = #Phc.#3hc(107401334);

		// Token: 0x04000988 RID: 2440
		private string #b = #Phc.#3hc(107401301);

		// Token: 0x04000989 RID: 2441
		private string #c = #Phc.#3hc(107401260);

		// Token: 0x0400098A RID: 2442
		private string #d = #Phc.#3hc(107403126);

		// Token: 0x0400098B RID: 2443
		private string #e = #Phc.#3hc(107401219);

		// Token: 0x0400098C RID: 2444
		private string #f;

		// Token: 0x0400098D RID: 2445
		[CompilerGenerated]
		private readonly string #g;

		// Token: 0x0400098E RID: 2446
		[CompilerGenerated]
		private readonly string #h;

		// Token: 0x0400098F RID: 2447
		[CompilerGenerated]
		private bool #i;
	}
}
