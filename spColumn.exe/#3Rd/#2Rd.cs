using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using #7hc;
using #N6c;
using #sUd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;

namespace #3Rd
{
	// Token: 0x020002D1 RID: 721
	internal class #2Rd : NotifyPropertyChangedObjectBase, #rUd
	{
		// Token: 0x0600191B RID: 6427 RVA: 0x000192C1 File Offset: 0x000174C1
		public #2Rd(#vUd #hB)
		{
			this.#j = #hB;
			this.#i = new #iSd();
			this.Options.PropertyChanged += this.#kz;
		}

		// Token: 0x1700094A RID: 2378
		// (get) Token: 0x0600191C RID: 6428 RVA: 0x000192FD File Offset: 0x000174FD
		public #iSd Options { get; }

		// Token: 0x1700094B RID: 2379
		// (get) Token: 0x0600191D RID: 6429 RVA: 0x00019309 File Offset: 0x00017509
		public #vUd Commands { get; }

		// Token: 0x1700094C RID: 2380
		// (get) Token: 0x0600191E RID: 6430 RVA: 0x00019315 File Offset: 0x00017515
		// (set) Token: 0x0600191F RID: 6431 RVA: 0x00019321 File Offset: 0x00017521
		public bool IsDirty
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
					this.#0Rd();
					base.RaisePropertyChanged(#Phc.#3hc(107277788));
				}
			}
		}

		// Token: 0x1700094D RID: 2381
		// (get) Token: 0x06001920 RID: 6432 RVA: 0x00019355 File Offset: 0x00017555
		// (set) Token: 0x06001921 RID: 6433 RVA: 0x00019361 File Offset: 0x00017561
		public bool IsCurrentlyReadingData
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
					this.#0Rd();
					base.RaisePropertyChanged(#Phc.#3hc(107277743));
				}
			}
		}

		// Token: 0x1700094E RID: 2382
		// (get) Token: 0x06001922 RID: 6434 RVA: 0x00019395 File Offset: 0x00017595
		// (set) Token: 0x06001923 RID: 6435 RVA: 0x000193A1 File Offset: 0x000175A1
		public bool IsCurrentlyGeneratingReport
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
					this.#0Rd();
					base.RaisePropertyChanged(#Phc.#3hc(107277710));
				}
			}
		}

		// Token: 0x1700094F RID: 2383
		// (get) Token: 0x06001924 RID: 6436 RVA: 0x000193D5 File Offset: 0x000175D5
		// (set) Token: 0x06001925 RID: 6437 RVA: 0x000193E1 File Offset: 0x000175E1
		public bool ShouldShowRegenerateButton
		{
			get
			{
				return this.#d;
			}
			private set
			{
				if (this.#d != value)
				{
					this.#d = value;
					base.RaisePropertyChanged(#Phc.#3hc(107277673));
				}
			}
		}

		// Token: 0x17000950 RID: 2384
		// (get) Token: 0x06001926 RID: 6438 RVA: 0x0001940F File Offset: 0x0001760F
		// (set) Token: 0x06001927 RID: 6439 RVA: 0x0001941B File Offset: 0x0001761B
		public bool ShowPleaseWaitProgramIsSolving
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
					this.#0Rd();
					base.RaisePropertyChanged(#Phc.#3hc(107278370));
				}
			}
		}

		// Token: 0x17000951 RID: 2385
		// (get) Token: 0x06001928 RID: 6440 RVA: 0x0001944F File Offset: 0x0001764F
		// (set) Token: 0x06001929 RID: 6441 RVA: 0x0001945B File Offset: 0x0001765B
		public bool ShowNoPreviewAvailableMessage
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
					base.RaisePropertyChanged(#Phc.#3hc(107277636));
				}
			}
		}

		// Token: 0x17000952 RID: 2386
		// (get) Token: 0x0600192A RID: 6442 RVA: 0x00019489 File Offset: 0x00017689
		public #Z7c<ReportFileFormat> CanceledFormats
		{
			get
			{
				return this.#f;
			}
		}

		// Token: 0x17000953 RID: 2387
		// (get) Token: 0x0600192B RID: 6443 RVA: 0x00019495 File Offset: 0x00017695
		// (set) Token: 0x0600192C RID: 6444 RVA: 0x000194A1 File Offset: 0x000176A1
		public string AdditionalBusyIndicatorMessage
		{
			get
			{
				return this.#h;
			}
			set
			{
				if (\u0093.\u0015\u0003(this.#h, value))
				{
					this.#h = value;
					base.RaisePropertyChanged(#Phc.#3hc(107277627));
				}
			}
		}

		// Token: 0x0600192D RID: 6445 RVA: 0x000B7ABC File Offset: 0x000B5CBC
		public void #XRd(ReportFileFormat #cA)
		{
			this.#f.Add(#cA);
			if (#cA == ReportFileFormat.Word || #cA == ReportFileFormat.Pdf)
			{
				this.#f.Add(ReportFileFormat.Word);
				this.#f.Add(ReportFileFormat.Pdf);
			}
			this.#0Rd();
		}

		// Token: 0x0600192E RID: 6446 RVA: 0x000194D9 File Offset: 0x000176D9
		public void #YRd()
		{
			this.#f.Clear();
			this.#0Rd();
		}

		// Token: 0x0600192F RID: 6447 RVA: 0x000B7B0C File Offset: 0x000B5D0C
		public void #ZRd(ReportFileFormat #cA)
		{
			this.#f.Remove(#cA);
			if (#cA == ReportFileFormat.Word || #cA == ReportFileFormat.Pdf)
			{
				this.#f.Remove(ReportFileFormat.Word);
				this.#f.Remove(ReportFileFormat.Pdf);
			}
			this.#0Rd();
		}

		// Token: 0x06001930 RID: 6448 RVA: 0x000194F8 File Offset: 0x000176F8
		private void #kz(object #Ge, PropertyChangedEventArgs #He)
		{
			this.#0Rd();
		}

		// Token: 0x06001931 RID: 6449 RVA: 0x00019508 File Offset: 0x00017708
		private void #0Rd()
		{
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#1Rd));
		}

		// Token: 0x06001932 RID: 6450 RVA: 0x000B7B5C File Offset: 0x000B5D5C
		[CompilerGenerated]
		private void #1Rd()
		{
			ReportFileFormat reportFileFormat = this.Options.SelectedFileFormat;
			this.ShouldShowRegenerateButton = ((this.IsDirty || this.CanceledFormats.Contains(reportFileFormat)) && (reportFileFormat.#OSd() || reportFileFormat.#Lcd()) && !this.IsCurrentlyReadingData && !this.IsCurrentlyGeneratingReport && !this.ShowPleaseWaitProgramIsSolving);
		}

		// Token: 0x0400099E RID: 2462
		private bool #a;

		// Token: 0x0400099F RID: 2463
		private bool #b;

		// Token: 0x040009A0 RID: 2464
		private bool #c;

		// Token: 0x040009A1 RID: 2465
		private bool #d;

		// Token: 0x040009A2 RID: 2466
		private bool #e;

		// Token: 0x040009A3 RID: 2467
		private readonly #g8c<ReportFileFormat> #f = new #g8c<ReportFileFormat>();

		// Token: 0x040009A4 RID: 2468
		private bool #g;

		// Token: 0x040009A5 RID: 2469
		private string #h;

		// Token: 0x040009A6 RID: 2470
		[CompilerGenerated]
		private readonly #iSd #i;

		// Token: 0x040009A7 RID: 2471
		[CompilerGenerated]
		private readonly #vUd #j;
	}
}
