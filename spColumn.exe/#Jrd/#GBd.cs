using System;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #Ted;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;

namespace #Jrd
{
	// Token: 0x02000D43 RID: 3395
	internal sealed class #GBd : GridDataRowCore
	{
		// Token: 0x170024D1 RID: 9425
		// (get) Token: 0x06007AC3 RID: 31427 RVA: 0x00063B85 File Offset: 0x00061D85
		// (set) Token: 0x06007AC4 RID: 31428 RVA: 0x00063B91 File Offset: 0x00061D91
		public string Column_00 { get; set; }

		// Token: 0x170024D2 RID: 9426
		// (get) Token: 0x06007AC5 RID: 31429 RVA: 0x00063BA2 File Offset: 0x00061DA2
		// (set) Token: 0x06007AC6 RID: 31430 RVA: 0x00063BAE File Offset: 0x00061DAE
		public string Column_01 { get; set; }

		// Token: 0x170024D3 RID: 9427
		// (get) Token: 0x06007AC7 RID: 31431 RVA: 0x00063BBF File Offset: 0x00061DBF
		// (set) Token: 0x06007AC8 RID: 31432 RVA: 0x00063BCB File Offset: 0x00061DCB
		public string Column_02 { get; set; }

		// Token: 0x170024D4 RID: 9428
		// (get) Token: 0x06007AC9 RID: 31433 RVA: 0x00063BDC File Offset: 0x00061DDC
		// (set) Token: 0x06007ACA RID: 31434 RVA: 0x00063BE8 File Offset: 0x00061DE8
		public #Rhd Column_00_Value { get; set; }

		// Token: 0x170024D5 RID: 9429
		// (get) Token: 0x06007ACB RID: 31435 RVA: 0x00063BF9 File Offset: 0x00061DF9
		// (set) Token: 0x06007ACC RID: 31436 RVA: 0x00063C05 File Offset: 0x00061E05
		public #Rhd Column_01_Value { get; set; }

		// Token: 0x170024D6 RID: 9430
		// (get) Token: 0x06007ACD RID: 31437 RVA: 0x00063C16 File Offset: 0x00061E16
		// (set) Token: 0x06007ACE RID: 31438 RVA: 0x00063C22 File Offset: 0x00061E22
		public #Rhd Column_02_Value { get; set; }

		// Token: 0x170024D7 RID: 9431
		// (get) Token: 0x06007ACF RID: 31439 RVA: 0x00063C33 File Offset: 0x00061E33
		// (set) Token: 0x06007AD0 RID: 31440 RVA: 0x00063C3F File Offset: 0x00061E3F
		public Brush Column_00_Background { get; set; }

		// Token: 0x170024D8 RID: 9432
		// (get) Token: 0x06007AD1 RID: 31441 RVA: 0x00063C50 File Offset: 0x00061E50
		// (set) Token: 0x06007AD2 RID: 31442 RVA: 0x00063C5C File Offset: 0x00061E5C
		public Brush Column_01_Background { get; set; }

		// Token: 0x170024D9 RID: 9433
		// (get) Token: 0x06007AD3 RID: 31443 RVA: 0x00063C6D File Offset: 0x00061E6D
		// (set) Token: 0x06007AD4 RID: 31444 RVA: 0x00063C79 File Offset: 0x00061E79
		public Brush Column_02_Background { get; set; }

		// Token: 0x06007AD5 RID: 31445 RVA: 0x001B2FBC File Offset: 0x001B11BC
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
			default:
				#f = null;
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x06007AD6 RID: 31446 RVA: 0x001B3010 File Offset: 0x001B1210
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
			default:
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x06007AD7 RID: 31447 RVA: 0x001B3060 File Offset: 0x001B1260
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
			default:
				#f = null;
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x06007AD8 RID: 31448 RVA: 0x001B30B4 File Offset: 0x001B12B4
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
			default:
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x06007AD9 RID: 31449 RVA: 0x001B3104 File Offset: 0x001B1304
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
			default:
				result = false;
				#f = null;
				break;
			}
			return result;
		}

		// Token: 0x06007ADA RID: 31450 RVA: 0x001B3158 File Offset: 0x001B1358
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
			default:
				result = false;
				break;
			}
			return result;
		}

		// Token: 0x04003253 RID: 12883
		[CompilerGenerated]
		private string #a;

		// Token: 0x04003254 RID: 12884
		[CompilerGenerated]
		private string #b;

		// Token: 0x04003255 RID: 12885
		[CompilerGenerated]
		private string #c;

		// Token: 0x04003256 RID: 12886
		[CompilerGenerated]
		private #Rhd #d;

		// Token: 0x04003257 RID: 12887
		[CompilerGenerated]
		private #Rhd #e;

		// Token: 0x04003258 RID: 12888
		[CompilerGenerated]
		private #Rhd #f;

		// Token: 0x04003259 RID: 12889
		[CompilerGenerated]
		private Brush #g;

		// Token: 0x0400325A RID: 12890
		[CompilerGenerated]
		private Brush #h;

		// Token: 0x0400325B RID: 12891
		[CompilerGenerated]
		private Brush #i;
	}
}
