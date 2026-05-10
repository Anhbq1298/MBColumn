using System;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #Ted;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;

namespace #Jrd
{
	// Token: 0x02000D48 RID: 3400
	internal sealed class #LBd : GridDataRowCore
	{
		// Token: 0x1700251C RID: 9500
		// (get) Token: 0x06007B7C RID: 31612 RVA: 0x00064404 File Offset: 0x00062604
		// (set) Token: 0x06007B7D RID: 31613 RVA: 0x00064410 File Offset: 0x00062610
		public string Column_00 { get; set; }

		// Token: 0x1700251D RID: 9501
		// (get) Token: 0x06007B7E RID: 31614 RVA: 0x00064421 File Offset: 0x00062621
		// (set) Token: 0x06007B7F RID: 31615 RVA: 0x0006442D File Offset: 0x0006262D
		public string Column_01 { get; set; }

		// Token: 0x1700251E RID: 9502
		// (get) Token: 0x06007B80 RID: 31616 RVA: 0x0006443E File Offset: 0x0006263E
		// (set) Token: 0x06007B81 RID: 31617 RVA: 0x0006444A File Offset: 0x0006264A
		public string Column_02 { get; set; }

		// Token: 0x1700251F RID: 9503
		// (get) Token: 0x06007B82 RID: 31618 RVA: 0x0006445B File Offset: 0x0006265B
		// (set) Token: 0x06007B83 RID: 31619 RVA: 0x00064467 File Offset: 0x00062667
		public string Column_03 { get; set; }

		// Token: 0x17002520 RID: 9504
		// (get) Token: 0x06007B84 RID: 31620 RVA: 0x00064478 File Offset: 0x00062678
		// (set) Token: 0x06007B85 RID: 31621 RVA: 0x00064484 File Offset: 0x00062684
		public string Column_04 { get; set; }

		// Token: 0x17002521 RID: 9505
		// (get) Token: 0x06007B86 RID: 31622 RVA: 0x00064495 File Offset: 0x00062695
		// (set) Token: 0x06007B87 RID: 31623 RVA: 0x000644A1 File Offset: 0x000626A1
		public string Column_05 { get; set; }

		// Token: 0x17002522 RID: 9506
		// (get) Token: 0x06007B88 RID: 31624 RVA: 0x000644B2 File Offset: 0x000626B2
		// (set) Token: 0x06007B89 RID: 31625 RVA: 0x000644BE File Offset: 0x000626BE
		public string Column_06 { get; set; }

		// Token: 0x17002523 RID: 9507
		// (get) Token: 0x06007B8A RID: 31626 RVA: 0x000644CF File Offset: 0x000626CF
		// (set) Token: 0x06007B8B RID: 31627 RVA: 0x000644DB File Offset: 0x000626DB
		public string Column_07 { get; set; }

		// Token: 0x17002524 RID: 9508
		// (get) Token: 0x06007B8C RID: 31628 RVA: 0x000644EC File Offset: 0x000626EC
		// (set) Token: 0x06007B8D RID: 31629 RVA: 0x000644F8 File Offset: 0x000626F8
		public #Rhd Column_00_Value { get; set; }

		// Token: 0x17002525 RID: 9509
		// (get) Token: 0x06007B8E RID: 31630 RVA: 0x00064509 File Offset: 0x00062709
		// (set) Token: 0x06007B8F RID: 31631 RVA: 0x00064515 File Offset: 0x00062715
		public #Rhd Column_01_Value { get; set; }

		// Token: 0x17002526 RID: 9510
		// (get) Token: 0x06007B90 RID: 31632 RVA: 0x00064526 File Offset: 0x00062726
		// (set) Token: 0x06007B91 RID: 31633 RVA: 0x00064532 File Offset: 0x00062732
		public #Rhd Column_02_Value { get; set; }

		// Token: 0x17002527 RID: 9511
		// (get) Token: 0x06007B92 RID: 31634 RVA: 0x00064543 File Offset: 0x00062743
		// (set) Token: 0x06007B93 RID: 31635 RVA: 0x0006454F File Offset: 0x0006274F
		public #Rhd Column_03_Value { get; set; }

		// Token: 0x17002528 RID: 9512
		// (get) Token: 0x06007B94 RID: 31636 RVA: 0x00064560 File Offset: 0x00062760
		// (set) Token: 0x06007B95 RID: 31637 RVA: 0x0006456C File Offset: 0x0006276C
		public #Rhd Column_04_Value { get; set; }

		// Token: 0x17002529 RID: 9513
		// (get) Token: 0x06007B96 RID: 31638 RVA: 0x0006457D File Offset: 0x0006277D
		// (set) Token: 0x06007B97 RID: 31639 RVA: 0x00064589 File Offset: 0x00062789
		public #Rhd Column_05_Value { get; set; }

		// Token: 0x1700252A RID: 9514
		// (get) Token: 0x06007B98 RID: 31640 RVA: 0x0006459A File Offset: 0x0006279A
		// (set) Token: 0x06007B99 RID: 31641 RVA: 0x000645A6 File Offset: 0x000627A6
		public #Rhd Column_06_Value { get; set; }

		// Token: 0x1700252B RID: 9515
		// (get) Token: 0x06007B9A RID: 31642 RVA: 0x000645B7 File Offset: 0x000627B7
		// (set) Token: 0x06007B9B RID: 31643 RVA: 0x000645C3 File Offset: 0x000627C3
		public #Rhd Column_07_Value { get; set; }

		// Token: 0x1700252C RID: 9516
		// (get) Token: 0x06007B9C RID: 31644 RVA: 0x000645D4 File Offset: 0x000627D4
		// (set) Token: 0x06007B9D RID: 31645 RVA: 0x000645E0 File Offset: 0x000627E0
		public Brush Column_00_Background { get; set; }

		// Token: 0x1700252D RID: 9517
		// (get) Token: 0x06007B9E RID: 31646 RVA: 0x000645F1 File Offset: 0x000627F1
		// (set) Token: 0x06007B9F RID: 31647 RVA: 0x000645FD File Offset: 0x000627FD
		public Brush Column_01_Background { get; set; }

		// Token: 0x1700252E RID: 9518
		// (get) Token: 0x06007BA0 RID: 31648 RVA: 0x0006460E File Offset: 0x0006280E
		// (set) Token: 0x06007BA1 RID: 31649 RVA: 0x0006461A File Offset: 0x0006281A
		public Brush Column_02_Background { get; set; }

		// Token: 0x1700252F RID: 9519
		// (get) Token: 0x06007BA2 RID: 31650 RVA: 0x0006462B File Offset: 0x0006282B
		// (set) Token: 0x06007BA3 RID: 31651 RVA: 0x00064637 File Offset: 0x00062837
		public Brush Column_03_Background { get; set; }

		// Token: 0x17002530 RID: 9520
		// (get) Token: 0x06007BA4 RID: 31652 RVA: 0x00064648 File Offset: 0x00062848
		// (set) Token: 0x06007BA5 RID: 31653 RVA: 0x00064654 File Offset: 0x00062854
		public Brush Column_04_Background { get; set; }

		// Token: 0x17002531 RID: 9521
		// (get) Token: 0x06007BA6 RID: 31654 RVA: 0x00064665 File Offset: 0x00062865
		// (set) Token: 0x06007BA7 RID: 31655 RVA: 0x00064671 File Offset: 0x00062871
		public Brush Column_05_Background { get; set; }

		// Token: 0x17002532 RID: 9522
		// (get) Token: 0x06007BA8 RID: 31656 RVA: 0x00064682 File Offset: 0x00062882
		// (set) Token: 0x06007BA9 RID: 31657 RVA: 0x0006468E File Offset: 0x0006288E
		public Brush Column_06_Background { get; set; }

		// Token: 0x17002533 RID: 9523
		// (get) Token: 0x06007BAA RID: 31658 RVA: 0x0006469F File Offset: 0x0006289F
		// (set) Token: 0x06007BAB RID: 31659 RVA: 0x000646AB File Offset: 0x000628AB
		public Brush Column_07_Background { get; set; }

		// Token: 0x06007BAC RID: 31660 RVA: 0x001B3CD0 File Offset: 0x001B1ED0
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
			case 7:
				#f = this.Column_07_Value;
				break;
			default:
				#f = null;
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x06007BAD RID: 31661 RVA: 0x001B3D78 File Offset: 0x001B1F78
		protected override bool #sfd(int #4jb, #Rhd #f)
		{
			bool result = true;
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
			case 7:
				this.Column_07_Value = #f;
				break;
			default:
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x06007BAE RID: 31662 RVA: 0x001B3E10 File Offset: 0x001B2010
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
			case 7:
				#f = this.Column_07;
				break;
			default:
				#f = null;
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x06007BAF RID: 31663 RVA: 0x001B3EB8 File Offset: 0x001B20B8
		protected override bool #ufd(int #4jb, string #f)
		{
			bool result = true;
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
			case 7:
				this.Column_07 = #f;
				break;
			default:
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x06007BB0 RID: 31664 RVA: 0x001B3F50 File Offset: 0x001B2150
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
			case 7:
				#f = this.Column_07_Background;
				break;
			default:
				result = false;
				#f = null;
				break;
			}
			return result;
		}

		// Token: 0x06007BB1 RID: 31665 RVA: 0x001B3FF8 File Offset: 0x001B21F8
		protected override bool #wfd(int #4jb, Brush #f)
		{
			bool result = true;
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
			case 7:
				this.Column_07_Background = #f;
				break;
			default:
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x0400329E RID: 12958
		[CompilerGenerated]
		private string #a;

		// Token: 0x0400329F RID: 12959
		[CompilerGenerated]
		private string #b;

		// Token: 0x040032A0 RID: 12960
		[CompilerGenerated]
		private string #c;

		// Token: 0x040032A1 RID: 12961
		[CompilerGenerated]
		private string #d;

		// Token: 0x040032A2 RID: 12962
		[CompilerGenerated]
		private string #e;

		// Token: 0x040032A3 RID: 12963
		[CompilerGenerated]
		private string #f;

		// Token: 0x040032A4 RID: 12964
		[CompilerGenerated]
		private string #g;

		// Token: 0x040032A5 RID: 12965
		[CompilerGenerated]
		private string #h;

		// Token: 0x040032A6 RID: 12966
		[CompilerGenerated]
		private #Rhd #i;

		// Token: 0x040032A7 RID: 12967
		[CompilerGenerated]
		private #Rhd #j;

		// Token: 0x040032A8 RID: 12968
		[CompilerGenerated]
		private #Rhd #k;

		// Token: 0x040032A9 RID: 12969
		[CompilerGenerated]
		private #Rhd #l;

		// Token: 0x040032AA RID: 12970
		[CompilerGenerated]
		private #Rhd #m;

		// Token: 0x040032AB RID: 12971
		[CompilerGenerated]
		private #Rhd #n;

		// Token: 0x040032AC RID: 12972
		[CompilerGenerated]
		private #Rhd #o;

		// Token: 0x040032AD RID: 12973
		[CompilerGenerated]
		private #Rhd #p;

		// Token: 0x040032AE RID: 12974
		[CompilerGenerated]
		private Brush #q;

		// Token: 0x040032AF RID: 12975
		[CompilerGenerated]
		private Brush #r;

		// Token: 0x040032B0 RID: 12976
		[CompilerGenerated]
		private Brush #s;

		// Token: 0x040032B1 RID: 12977
		[CompilerGenerated]
		private Brush #t;

		// Token: 0x040032B2 RID: 12978
		[CompilerGenerated]
		private Brush #u;

		// Token: 0x040032B3 RID: 12979
		[CompilerGenerated]
		private Brush #v;

		// Token: 0x040032B4 RID: 12980
		[CompilerGenerated]
		private Brush #w;

		// Token: 0x040032B5 RID: 12981
		[CompilerGenerated]
		private Brush #x;
	}
}
