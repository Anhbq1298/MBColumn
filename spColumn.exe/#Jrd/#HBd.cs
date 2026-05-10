using System;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #Ted;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;

namespace #Jrd
{
	// Token: 0x02000D44 RID: 3396
	internal sealed class #HBd : GridDataRowCore
	{
		// Token: 0x170024DA RID: 9434
		// (get) Token: 0x06007ADC RID: 31452 RVA: 0x00063C8A File Offset: 0x00061E8A
		// (set) Token: 0x06007ADD RID: 31453 RVA: 0x00063C96 File Offset: 0x00061E96
		public string Column_00 { get; set; }

		// Token: 0x170024DB RID: 9435
		// (get) Token: 0x06007ADE RID: 31454 RVA: 0x00063CA7 File Offset: 0x00061EA7
		// (set) Token: 0x06007ADF RID: 31455 RVA: 0x00063CB3 File Offset: 0x00061EB3
		public string Column_01 { get; set; }

		// Token: 0x170024DC RID: 9436
		// (get) Token: 0x06007AE0 RID: 31456 RVA: 0x00063CC4 File Offset: 0x00061EC4
		// (set) Token: 0x06007AE1 RID: 31457 RVA: 0x00063CD0 File Offset: 0x00061ED0
		public string Column_02 { get; set; }

		// Token: 0x170024DD RID: 9437
		// (get) Token: 0x06007AE2 RID: 31458 RVA: 0x00063CE1 File Offset: 0x00061EE1
		// (set) Token: 0x06007AE3 RID: 31459 RVA: 0x00063CED File Offset: 0x00061EED
		public string Column_03 { get; set; }

		// Token: 0x170024DE RID: 9438
		// (get) Token: 0x06007AE4 RID: 31460 RVA: 0x00063CFE File Offset: 0x00061EFE
		// (set) Token: 0x06007AE5 RID: 31461 RVA: 0x00063D0A File Offset: 0x00061F0A
		public #Rhd Column_00_Value { get; set; }

		// Token: 0x170024DF RID: 9439
		// (get) Token: 0x06007AE6 RID: 31462 RVA: 0x00063D1B File Offset: 0x00061F1B
		// (set) Token: 0x06007AE7 RID: 31463 RVA: 0x00063D27 File Offset: 0x00061F27
		public #Rhd Column_01_Value { get; set; }

		// Token: 0x170024E0 RID: 9440
		// (get) Token: 0x06007AE8 RID: 31464 RVA: 0x00063D38 File Offset: 0x00061F38
		// (set) Token: 0x06007AE9 RID: 31465 RVA: 0x00063D44 File Offset: 0x00061F44
		public #Rhd Column_02_Value { get; set; }

		// Token: 0x170024E1 RID: 9441
		// (get) Token: 0x06007AEA RID: 31466 RVA: 0x00063D55 File Offset: 0x00061F55
		// (set) Token: 0x06007AEB RID: 31467 RVA: 0x00063D61 File Offset: 0x00061F61
		public #Rhd Column_03_Value { get; set; }

		// Token: 0x170024E2 RID: 9442
		// (get) Token: 0x06007AEC RID: 31468 RVA: 0x00063D72 File Offset: 0x00061F72
		// (set) Token: 0x06007AED RID: 31469 RVA: 0x00063D7E File Offset: 0x00061F7E
		public Brush Column_00_Background { get; set; }

		// Token: 0x170024E3 RID: 9443
		// (get) Token: 0x06007AEE RID: 31470 RVA: 0x00063D8F File Offset: 0x00061F8F
		// (set) Token: 0x06007AEF RID: 31471 RVA: 0x00063D9B File Offset: 0x00061F9B
		public Brush Column_01_Background { get; set; }

		// Token: 0x170024E4 RID: 9444
		// (get) Token: 0x06007AF0 RID: 31472 RVA: 0x00063DAC File Offset: 0x00061FAC
		// (set) Token: 0x06007AF1 RID: 31473 RVA: 0x00063DB8 File Offset: 0x00061FB8
		public Brush Column_02_Background { get; set; }

		// Token: 0x170024E5 RID: 9445
		// (get) Token: 0x06007AF2 RID: 31474 RVA: 0x00063DC9 File Offset: 0x00061FC9
		// (set) Token: 0x06007AF3 RID: 31475 RVA: 0x00063DD5 File Offset: 0x00061FD5
		public Brush Column_03_Background { get; set; }

		// Token: 0x06007AF4 RID: 31476 RVA: 0x001B31A8 File Offset: 0x001B13A8
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
			default:
				#f = null;
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x06007AF5 RID: 31477 RVA: 0x001B320C File Offset: 0x001B140C
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
			default:
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x06007AF6 RID: 31478 RVA: 0x001B3268 File Offset: 0x001B1468
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
			default:
				#f = null;
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x06007AF7 RID: 31479 RVA: 0x001B32CC File Offset: 0x001B14CC
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
			default:
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x06007AF8 RID: 31480 RVA: 0x001B3328 File Offset: 0x001B1528
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
			default:
				result = false;
				#f = null;
				break;
			}
			return result;
		}

		// Token: 0x06007AF9 RID: 31481 RVA: 0x001B338C File Offset: 0x001B158C
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
			default:
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x0400325C RID: 12892
		[CompilerGenerated]
		private string #a;

		// Token: 0x0400325D RID: 12893
		[CompilerGenerated]
		private string #b;

		// Token: 0x0400325E RID: 12894
		[CompilerGenerated]
		private string #c;

		// Token: 0x0400325F RID: 12895
		[CompilerGenerated]
		private string #d;

		// Token: 0x04003260 RID: 12896
		[CompilerGenerated]
		private #Rhd #e;

		// Token: 0x04003261 RID: 12897
		[CompilerGenerated]
		private #Rhd #f;

		// Token: 0x04003262 RID: 12898
		[CompilerGenerated]
		private #Rhd #g;

		// Token: 0x04003263 RID: 12899
		[CompilerGenerated]
		private #Rhd #h;

		// Token: 0x04003264 RID: 12900
		[CompilerGenerated]
		private Brush #i;

		// Token: 0x04003265 RID: 12901
		[CompilerGenerated]
		private Brush #j;

		// Token: 0x04003266 RID: 12902
		[CompilerGenerated]
		private Brush #k;

		// Token: 0x04003267 RID: 12903
		[CompilerGenerated]
		private Brush #l;
	}
}
