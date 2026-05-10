using System;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #Ted;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;

namespace #Jrd
{
	// Token: 0x02000D47 RID: 3399
	internal sealed class #KBd : GridDataRowCore
	{
		// Token: 0x17002507 RID: 9479
		// (get) Token: 0x06007B4B RID: 31563 RVA: 0x000641A3 File Offset: 0x000623A3
		// (set) Token: 0x06007B4C RID: 31564 RVA: 0x000641AF File Offset: 0x000623AF
		public string Column_00 { get; set; }

		// Token: 0x17002508 RID: 9480
		// (get) Token: 0x06007B4D RID: 31565 RVA: 0x000641C0 File Offset: 0x000623C0
		// (set) Token: 0x06007B4E RID: 31566 RVA: 0x000641CC File Offset: 0x000623CC
		public string Column_01 { get; set; }

		// Token: 0x17002509 RID: 9481
		// (get) Token: 0x06007B4F RID: 31567 RVA: 0x000641DD File Offset: 0x000623DD
		// (set) Token: 0x06007B50 RID: 31568 RVA: 0x000641E9 File Offset: 0x000623E9
		public string Column_02 { get; set; }

		// Token: 0x1700250A RID: 9482
		// (get) Token: 0x06007B51 RID: 31569 RVA: 0x000641FA File Offset: 0x000623FA
		// (set) Token: 0x06007B52 RID: 31570 RVA: 0x00064206 File Offset: 0x00062406
		public string Column_03 { get; set; }

		// Token: 0x1700250B RID: 9483
		// (get) Token: 0x06007B53 RID: 31571 RVA: 0x00064217 File Offset: 0x00062417
		// (set) Token: 0x06007B54 RID: 31572 RVA: 0x00064223 File Offset: 0x00062423
		public string Column_04 { get; set; }

		// Token: 0x1700250C RID: 9484
		// (get) Token: 0x06007B55 RID: 31573 RVA: 0x00064234 File Offset: 0x00062434
		// (set) Token: 0x06007B56 RID: 31574 RVA: 0x00064240 File Offset: 0x00062440
		public string Column_05 { get; set; }

		// Token: 0x1700250D RID: 9485
		// (get) Token: 0x06007B57 RID: 31575 RVA: 0x00064251 File Offset: 0x00062451
		// (set) Token: 0x06007B58 RID: 31576 RVA: 0x0006425D File Offset: 0x0006245D
		public string Column_06 { get; set; }

		// Token: 0x1700250E RID: 9486
		// (get) Token: 0x06007B59 RID: 31577 RVA: 0x0006426E File Offset: 0x0006246E
		// (set) Token: 0x06007B5A RID: 31578 RVA: 0x0006427A File Offset: 0x0006247A
		public #Rhd Column_00_Value { get; set; }

		// Token: 0x1700250F RID: 9487
		// (get) Token: 0x06007B5B RID: 31579 RVA: 0x0006428B File Offset: 0x0006248B
		// (set) Token: 0x06007B5C RID: 31580 RVA: 0x00064297 File Offset: 0x00062497
		public #Rhd Column_01_Value { get; set; }

		// Token: 0x17002510 RID: 9488
		// (get) Token: 0x06007B5D RID: 31581 RVA: 0x000642A8 File Offset: 0x000624A8
		// (set) Token: 0x06007B5E RID: 31582 RVA: 0x000642B4 File Offset: 0x000624B4
		public #Rhd Column_02_Value { get; set; }

		// Token: 0x17002511 RID: 9489
		// (get) Token: 0x06007B5F RID: 31583 RVA: 0x000642C5 File Offset: 0x000624C5
		// (set) Token: 0x06007B60 RID: 31584 RVA: 0x000642D1 File Offset: 0x000624D1
		public #Rhd Column_03_Value { get; set; }

		// Token: 0x17002512 RID: 9490
		// (get) Token: 0x06007B61 RID: 31585 RVA: 0x000642E2 File Offset: 0x000624E2
		// (set) Token: 0x06007B62 RID: 31586 RVA: 0x000642EE File Offset: 0x000624EE
		public #Rhd Column_04_Value { get; set; }

		// Token: 0x17002513 RID: 9491
		// (get) Token: 0x06007B63 RID: 31587 RVA: 0x000642FF File Offset: 0x000624FF
		// (set) Token: 0x06007B64 RID: 31588 RVA: 0x0006430B File Offset: 0x0006250B
		public #Rhd Column_05_Value { get; set; }

		// Token: 0x17002514 RID: 9492
		// (get) Token: 0x06007B65 RID: 31589 RVA: 0x0006431C File Offset: 0x0006251C
		// (set) Token: 0x06007B66 RID: 31590 RVA: 0x00064328 File Offset: 0x00062528
		public #Rhd Column_06_Value { get; set; }

		// Token: 0x17002515 RID: 9493
		// (get) Token: 0x06007B67 RID: 31591 RVA: 0x00064339 File Offset: 0x00062539
		// (set) Token: 0x06007B68 RID: 31592 RVA: 0x00064345 File Offset: 0x00062545
		public Brush Column_00_Background { get; set; }

		// Token: 0x17002516 RID: 9494
		// (get) Token: 0x06007B69 RID: 31593 RVA: 0x00064356 File Offset: 0x00062556
		// (set) Token: 0x06007B6A RID: 31594 RVA: 0x00064362 File Offset: 0x00062562
		public Brush Column_01_Background { get; set; }

		// Token: 0x17002517 RID: 9495
		// (get) Token: 0x06007B6B RID: 31595 RVA: 0x00064373 File Offset: 0x00062573
		// (set) Token: 0x06007B6C RID: 31596 RVA: 0x0006437F File Offset: 0x0006257F
		public Brush Column_02_Background { get; set; }

		// Token: 0x17002518 RID: 9496
		// (get) Token: 0x06007B6D RID: 31597 RVA: 0x00064390 File Offset: 0x00062590
		// (set) Token: 0x06007B6E RID: 31598 RVA: 0x0006439C File Offset: 0x0006259C
		public Brush Column_03_Background { get; set; }

		// Token: 0x17002519 RID: 9497
		// (get) Token: 0x06007B6F RID: 31599 RVA: 0x000643AD File Offset: 0x000625AD
		// (set) Token: 0x06007B70 RID: 31600 RVA: 0x000643B9 File Offset: 0x000625B9
		public Brush Column_04_Background { get; set; }

		// Token: 0x1700251A RID: 9498
		// (get) Token: 0x06007B71 RID: 31601 RVA: 0x000643CA File Offset: 0x000625CA
		// (set) Token: 0x06007B72 RID: 31602 RVA: 0x000643D6 File Offset: 0x000625D6
		public Brush Column_05_Background { get; set; }

		// Token: 0x1700251B RID: 9499
		// (get) Token: 0x06007B73 RID: 31603 RVA: 0x000643E7 File Offset: 0x000625E7
		// (set) Token: 0x06007B74 RID: 31604 RVA: 0x000643F3 File Offset: 0x000625F3
		public Brush Column_06_Background { get; set; }

		// Token: 0x06007B75 RID: 31605 RVA: 0x001B3970 File Offset: 0x001B1B70
		protected override bool #rfd(int #4jb, out #Rhd #f)
		{
			bool result = true;
			switch (#4jb)
			{
			case 0:
				#f = this.Column_00_Value;
				break;
			case 1:
				#f = this.Column_01_Value;
				break;
			case 2:
				#f = this.Column_02_Value;
				break;
			case 3:
				#f = this.Column_03_Value;
				break;
			case 4:
				#f = this.Column_04_Value;
				break;
			case 5:
				#f = this.Column_05_Value;
				break;
			case 6:
				#f = this.Column_06_Value;
				break;
			default:
				#f = null;
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x06007B76 RID: 31606 RVA: 0x001B3A04 File Offset: 0x001B1C04
		protected override bool #sfd(int #4jb, #Rhd #f)
		{
			bool flag = true;
			bool result;
			if (!false)
			{
				result = flag;
			}
			switch (#4jb)
			{
			case 0:
				this.Column_00_Value = #f;
				break;
			case 1:
				this.Column_01_Value = #f;
				break;
			case 2:
				this.Column_02_Value = #f;
				break;
			case 3:
				this.Column_03_Value = #f;
				break;
			case 4:
				this.Column_04_Value = #f;
				break;
			case 5:
				this.Column_05_Value = #f;
				break;
			case 6:
				this.Column_06_Value = #f;
				break;
			default:
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x06007B77 RID: 31607 RVA: 0x001B3A90 File Offset: 0x001B1C90
		protected override bool #tfd(int #4jb, out string #f)
		{
			bool result = true;
			switch (#4jb)
			{
			case 0:
				#f = this.Column_00;
				break;
			case 1:
				#f = this.Column_01;
				break;
			case 2:
				#f = this.Column_02;
				break;
			case 3:
				#f = this.Column_03;
				break;
			case 4:
				#f = this.Column_04;
				break;
			case 5:
				#f = this.Column_05;
				break;
			case 6:
				#f = this.Column_06;
				break;
			default:
				#f = null;
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x06007B78 RID: 31608 RVA: 0x001B3B24 File Offset: 0x001B1D24
		protected override bool #ufd(int #4jb, string #f)
		{
			bool flag = true;
			bool result;
			if (!false)
			{
				result = flag;
			}
			switch (#4jb)
			{
			case 0:
				this.Column_00 = #f;
				break;
			case 1:
				this.Column_01 = #f;
				break;
			case 2:
				this.Column_02 = #f;
				break;
			case 3:
				this.Column_03 = #f;
				break;
			case 4:
				this.Column_04 = #f;
				break;
			case 5:
				this.Column_05 = #f;
				break;
			case 6:
				this.Column_06 = #f;
				break;
			default:
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x06007B79 RID: 31609 RVA: 0x001B3BB0 File Offset: 0x001B1DB0
		protected override bool #vfd(int #4jb, out Brush #f)
		{
			bool result = true;
			switch (#4jb)
			{
			case 0:
				#f = this.Column_00_Background;
				break;
			case 1:
				#f = this.Column_01_Background;
				break;
			case 2:
				#f = this.Column_02_Background;
				break;
			case 3:
				#f = this.Column_03_Background;
				break;
			case 4:
				#f = this.Column_04_Background;
				break;
			case 5:
				#f = this.Column_05_Background;
				break;
			case 6:
				#f = this.Column_06_Background;
				break;
			default:
				result = false;
				#f = null;
				break;
			}
			return result;
		}

		// Token: 0x06007B7A RID: 31610 RVA: 0x001B3C44 File Offset: 0x001B1E44
		protected override bool #wfd(int #4jb, Brush #f)
		{
			bool flag = true;
			bool result;
			if (!false)
			{
				result = flag;
			}
			switch (#4jb)
			{
			case 0:
				this.Column_00_Background = #f;
				break;
			case 1:
				this.Column_01_Background = #f;
				break;
			case 2:
				this.Column_02_Background = #f;
				break;
			case 3:
				this.Column_03_Background = #f;
				break;
			case 4:
				this.Column_04_Background = #f;
				break;
			case 5:
				this.Column_05_Background = #f;
				break;
			case 6:
				this.Column_06_Background = #f;
				break;
			default:
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x04003289 RID: 12937
		[CompilerGenerated]
		private string #a;

		// Token: 0x0400328A RID: 12938
		[CompilerGenerated]
		private string #b;

		// Token: 0x0400328B RID: 12939
		[CompilerGenerated]
		private string #c;

		// Token: 0x0400328C RID: 12940
		[CompilerGenerated]
		private string #d;

		// Token: 0x0400328D RID: 12941
		[CompilerGenerated]
		private string #e;

		// Token: 0x0400328E RID: 12942
		[CompilerGenerated]
		private string #f;

		// Token: 0x0400328F RID: 12943
		[CompilerGenerated]
		private string #g;

		// Token: 0x04003290 RID: 12944
		[CompilerGenerated]
		private #Rhd #h;

		// Token: 0x04003291 RID: 12945
		[CompilerGenerated]
		private #Rhd #i;

		// Token: 0x04003292 RID: 12946
		[CompilerGenerated]
		private #Rhd #j;

		// Token: 0x04003293 RID: 12947
		[CompilerGenerated]
		private #Rhd #k;

		// Token: 0x04003294 RID: 12948
		[CompilerGenerated]
		private #Rhd #l;

		// Token: 0x04003295 RID: 12949
		[CompilerGenerated]
		private #Rhd #m;

		// Token: 0x04003296 RID: 12950
		[CompilerGenerated]
		private #Rhd #n;

		// Token: 0x04003297 RID: 12951
		[CompilerGenerated]
		private Brush #o;

		// Token: 0x04003298 RID: 12952
		[CompilerGenerated]
		private Brush #p;

		// Token: 0x04003299 RID: 12953
		[CompilerGenerated]
		private Brush #q;

		// Token: 0x0400329A RID: 12954
		[CompilerGenerated]
		private Brush #r;

		// Token: 0x0400329B RID: 12955
		[CompilerGenerated]
		private Brush #s;

		// Token: 0x0400329C RID: 12956
		[CompilerGenerated]
		private Brush #t;

		// Token: 0x0400329D RID: 12957
		[CompilerGenerated]
		private Brush #u;
	}
}
