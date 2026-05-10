using System;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #Ted;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;

namespace #Jrd
{
	// Token: 0x02000D45 RID: 3397
	internal sealed class #IBd : GridDataRowCore
	{
		// Token: 0x170024E6 RID: 9446
		// (get) Token: 0x06007AFB RID: 31483 RVA: 0x00063DE6 File Offset: 0x00061FE6
		// (set) Token: 0x06007AFC RID: 31484 RVA: 0x00063DF2 File Offset: 0x00061FF2
		public string Column_00 { get; set; }

		// Token: 0x170024E7 RID: 9447
		// (get) Token: 0x06007AFD RID: 31485 RVA: 0x00063E03 File Offset: 0x00062003
		// (set) Token: 0x06007AFE RID: 31486 RVA: 0x00063E0F File Offset: 0x0006200F
		public string Column_01 { get; set; }

		// Token: 0x170024E8 RID: 9448
		// (get) Token: 0x06007AFF RID: 31487 RVA: 0x00063E20 File Offset: 0x00062020
		// (set) Token: 0x06007B00 RID: 31488 RVA: 0x00063E2C File Offset: 0x0006202C
		public string Column_02 { get; set; }

		// Token: 0x170024E9 RID: 9449
		// (get) Token: 0x06007B01 RID: 31489 RVA: 0x00063E3D File Offset: 0x0006203D
		// (set) Token: 0x06007B02 RID: 31490 RVA: 0x00063E49 File Offset: 0x00062049
		public string Column_03 { get; set; }

		// Token: 0x170024EA RID: 9450
		// (get) Token: 0x06007B03 RID: 31491 RVA: 0x00063E5A File Offset: 0x0006205A
		// (set) Token: 0x06007B04 RID: 31492 RVA: 0x00063E66 File Offset: 0x00062066
		public string Column_04 { get; set; }

		// Token: 0x170024EB RID: 9451
		// (get) Token: 0x06007B05 RID: 31493 RVA: 0x00063E77 File Offset: 0x00062077
		// (set) Token: 0x06007B06 RID: 31494 RVA: 0x00063E83 File Offset: 0x00062083
		public #Rhd Column_00_Value { get; set; }

		// Token: 0x170024EC RID: 9452
		// (get) Token: 0x06007B07 RID: 31495 RVA: 0x00063E94 File Offset: 0x00062094
		// (set) Token: 0x06007B08 RID: 31496 RVA: 0x00063EA0 File Offset: 0x000620A0
		public #Rhd Column_01_Value { get; set; }

		// Token: 0x170024ED RID: 9453
		// (get) Token: 0x06007B09 RID: 31497 RVA: 0x00063EB1 File Offset: 0x000620B1
		// (set) Token: 0x06007B0A RID: 31498 RVA: 0x00063EBD File Offset: 0x000620BD
		public #Rhd Column_02_Value { get; set; }

		// Token: 0x170024EE RID: 9454
		// (get) Token: 0x06007B0B RID: 31499 RVA: 0x00063ECE File Offset: 0x000620CE
		// (set) Token: 0x06007B0C RID: 31500 RVA: 0x00063EDA File Offset: 0x000620DA
		public #Rhd Column_03_Value { get; set; }

		// Token: 0x170024EF RID: 9455
		// (get) Token: 0x06007B0D RID: 31501 RVA: 0x00063EEB File Offset: 0x000620EB
		// (set) Token: 0x06007B0E RID: 31502 RVA: 0x00063EF7 File Offset: 0x000620F7
		public #Rhd Column_04_Value { get; set; }

		// Token: 0x170024F0 RID: 9456
		// (get) Token: 0x06007B0F RID: 31503 RVA: 0x00063F08 File Offset: 0x00062108
		// (set) Token: 0x06007B10 RID: 31504 RVA: 0x00063F14 File Offset: 0x00062114
		public Brush Column_00_Background { get; set; }

		// Token: 0x170024F1 RID: 9457
		// (get) Token: 0x06007B11 RID: 31505 RVA: 0x00063F25 File Offset: 0x00062125
		// (set) Token: 0x06007B12 RID: 31506 RVA: 0x00063F31 File Offset: 0x00062131
		public Brush Column_01_Background { get; set; }

		// Token: 0x170024F2 RID: 9458
		// (get) Token: 0x06007B13 RID: 31507 RVA: 0x00063F42 File Offset: 0x00062142
		// (set) Token: 0x06007B14 RID: 31508 RVA: 0x00063F4E File Offset: 0x0006214E
		public Brush Column_02_Background { get; set; }

		// Token: 0x170024F3 RID: 9459
		// (get) Token: 0x06007B15 RID: 31509 RVA: 0x00063F5F File Offset: 0x0006215F
		// (set) Token: 0x06007B16 RID: 31510 RVA: 0x00063F6B File Offset: 0x0006216B
		public Brush Column_03_Background { get; set; }

		// Token: 0x170024F4 RID: 9460
		// (get) Token: 0x06007B17 RID: 31511 RVA: 0x00063F7C File Offset: 0x0006217C
		// (set) Token: 0x06007B18 RID: 31512 RVA: 0x00063F88 File Offset: 0x00062188
		public Brush Column_04_Background { get; set; }

		// Token: 0x06007B19 RID: 31513 RVA: 0x001B33E8 File Offset: 0x001B15E8
		protected override bool #rfd(int #4jb, out #Rhd #f)
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
			default:
				#f = null;
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x06007B1A RID: 31514 RVA: 0x001B345C File Offset: 0x001B165C
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
			default:
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x06007B1B RID: 31515 RVA: 0x001B34C4 File Offset: 0x001B16C4
		protected override bool #tfd(int #4jb, out string #f)
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
			default:
				#f = null;
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x06007B1C RID: 31516 RVA: 0x001B3538 File Offset: 0x001B1738
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
			default:
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x06007B1D RID: 31517 RVA: 0x001B35A0 File Offset: 0x001B17A0
		protected override bool #vfd(int #4jb, out Brush #f)
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
			default:
				result = false;
				#f = null;
				break;
			}
			return result;
		}

		// Token: 0x06007B1E RID: 31518 RVA: 0x001B3614 File Offset: 0x001B1814
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
			default:
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x04003268 RID: 12904
		[CompilerGenerated]
		private string #a;

		// Token: 0x04003269 RID: 12905
		[CompilerGenerated]
		private string #b;

		// Token: 0x0400326A RID: 12906
		[CompilerGenerated]
		private string #c;

		// Token: 0x0400326B RID: 12907
		[CompilerGenerated]
		private string #d;

		// Token: 0x0400326C RID: 12908
		[CompilerGenerated]
		private string #e;

		// Token: 0x0400326D RID: 12909
		[CompilerGenerated]
		private #Rhd #f;

		// Token: 0x0400326E RID: 12910
		[CompilerGenerated]
		private #Rhd #g;

		// Token: 0x0400326F RID: 12911
		[CompilerGenerated]
		private #Rhd #h;

		// Token: 0x04003270 RID: 12912
		[CompilerGenerated]
		private #Rhd #i;

		// Token: 0x04003271 RID: 12913
		[CompilerGenerated]
		private #Rhd #j;

		// Token: 0x04003272 RID: 12914
		[CompilerGenerated]
		private Brush #k;

		// Token: 0x04003273 RID: 12915
		[CompilerGenerated]
		private Brush #l;

		// Token: 0x04003274 RID: 12916
		[CompilerGenerated]
		private Brush #m;

		// Token: 0x04003275 RID: 12917
		[CompilerGenerated]
		private Brush #n;

		// Token: 0x04003276 RID: 12918
		[CompilerGenerated]
		private Brush #o;
	}
}
