using System;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #Ted;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;

namespace #Jrd
{
	// Token: 0x02000D42 RID: 3394
	internal sealed class #FBd : GridDataRowCore
	{
		// Token: 0x170024CB RID: 9419
		// (get) Token: 0x06007AB0 RID: 31408 RVA: 0x00063AD7 File Offset: 0x00061CD7
		// (set) Token: 0x06007AB1 RID: 31409 RVA: 0x00063AE3 File Offset: 0x00061CE3
		public string Column_00 { get; set; }

		// Token: 0x170024CC RID: 9420
		// (get) Token: 0x06007AB2 RID: 31410 RVA: 0x00063AF4 File Offset: 0x00061CF4
		// (set) Token: 0x06007AB3 RID: 31411 RVA: 0x00063B00 File Offset: 0x00061D00
		public string Column_01 { get; set; }

		// Token: 0x170024CD RID: 9421
		// (get) Token: 0x06007AB4 RID: 31412 RVA: 0x00063B11 File Offset: 0x00061D11
		// (set) Token: 0x06007AB5 RID: 31413 RVA: 0x00063B1D File Offset: 0x00061D1D
		public #Rhd Column_00_Value { get; set; }

		// Token: 0x170024CE RID: 9422
		// (get) Token: 0x06007AB6 RID: 31414 RVA: 0x00063B2E File Offset: 0x00061D2E
		// (set) Token: 0x06007AB7 RID: 31415 RVA: 0x00063B3A File Offset: 0x00061D3A
		public #Rhd Column_01_Value { get; set; }

		// Token: 0x170024CF RID: 9423
		// (get) Token: 0x06007AB8 RID: 31416 RVA: 0x00063B4B File Offset: 0x00061D4B
		// (set) Token: 0x06007AB9 RID: 31417 RVA: 0x00063B57 File Offset: 0x00061D57
		public Brush Column_00_Background { get; set; }

		// Token: 0x170024D0 RID: 9424
		// (get) Token: 0x06007ABA RID: 31418 RVA: 0x00063B68 File Offset: 0x00061D68
		// (set) Token: 0x06007ABB RID: 31419 RVA: 0x00063B74 File Offset: 0x00061D74
		public Brush Column_01_Background { get; set; }

		// Token: 0x06007ABC RID: 31420 RVA: 0x001B2E48 File Offset: 0x001B1048
		protected override bool #rfd(int #4jb, out #Rhd #f)
		{
			bool result = true;
			if (#4jb != 0)
			{
				if (#4jb != 1)
				{
					#f = null;
					result = false;
				}
				else
				{
					#f = this.Column_01_Value;
				}
			}
			else
			{
				#f = this.Column_00_Value;
			}
			return result;
		}

		// Token: 0x06007ABD RID: 31421 RVA: 0x001B2E88 File Offset: 0x001B1088
		protected override bool #sfd(int #4jb, #Rhd #f)
		{
			bool result = true;
			if (#4jb != 0)
			{
				if (#4jb != 1)
				{
					result = false;
				}
				else
				{
					this.Column_01_Value = #f;
				}
			}
			else
			{
				this.Column_00_Value = #f;
			}
			return result;
		}

		// Token: 0x06007ABE RID: 31422 RVA: 0x001B2EC4 File Offset: 0x001B10C4
		protected override bool #tfd(int #4jb, out string #f)
		{
			bool result = true;
			if (#4jb != 0)
			{
				if (#4jb != 1)
				{
					#f = null;
					result = false;
				}
				else
				{
					#f = this.Column_01;
				}
			}
			else
			{
				#f = this.Column_00;
			}
			return result;
		}

		// Token: 0x06007ABF RID: 31423 RVA: 0x001B2F04 File Offset: 0x001B1104
		protected override bool #ufd(int #4jb, string #f)
		{
			bool result = true;
			if (#4jb != 0)
			{
				if (#4jb != 1)
				{
					result = false;
				}
				else
				{
					this.Column_01 = #f;
				}
			}
			else
			{
				this.Column_00 = #f;
			}
			return result;
		}

		// Token: 0x06007AC0 RID: 31424 RVA: 0x001B2F40 File Offset: 0x001B1140
		protected override bool #vfd(int #4jb, out Brush #f)
		{
			bool result = true;
			if (#4jb != 0)
			{
				if (#4jb != 1)
				{
					result = false;
					#f = null;
				}
				else
				{
					#f = this.Column_01_Background;
				}
			}
			else
			{
				#f = this.Column_00_Background;
			}
			return result;
		}

		// Token: 0x06007AC1 RID: 31425 RVA: 0x001B2F80 File Offset: 0x001B1180
		protected override bool #wfd(int #4jb, Brush #f)
		{
			bool result = true;
			if (#4jb != 0)
			{
				if (#4jb != 1)
				{
					result = false;
				}
				else
				{
					this.Column_01_Background = #f;
				}
			}
			else
			{
				this.Column_00_Background = #f;
			}
			return result;
		}

		// Token: 0x0400324D RID: 12877
		[CompilerGenerated]
		private string #a;

		// Token: 0x0400324E RID: 12878
		[CompilerGenerated]
		private string #b;

		// Token: 0x0400324F RID: 12879
		[CompilerGenerated]
		private #Rhd #c;

		// Token: 0x04003250 RID: 12880
		[CompilerGenerated]
		private #Rhd #d;

		// Token: 0x04003251 RID: 12881
		[CompilerGenerated]
		private Brush #e;

		// Token: 0x04003252 RID: 12882
		[CompilerGenerated]
		private Brush #f;
	}
}
