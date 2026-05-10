using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace #5Z
{
	// Token: 0x02000394 RID: 916
	internal sealed class #K0 : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06001DBF RID: 7615 RVA: 0x0000C5B9 File Offset: 0x0000A7B9
		public #K0()
		{
		}

		// Token: 0x06001DC0 RID: 7616 RVA: 0x000C1E2C File Offset: 0x000C002C
		public #K0(TemplateOptions #L0)
		{
			this.MirrorHorizontal = #L0.MirrorHorizontal;
			this.MirrorVertical = #L0.MirrorVertical;
			this.Rotate45Deg = #L0.Rotate45Deg;
			this.RotateLeft = #L0.RotateLeft;
			this.RotateRight = #L0.RotateRight;
			this.ShowColoredZones = #L0.ShowColoredZones;
			this.ShowParameters = #L0.ShowParameters;
		}

		// Token: 0x17000A5A RID: 2650
		// (get) Token: 0x06001DC1 RID: 7617 RVA: 0x0001C8E3 File Offset: 0x0001AAE3
		// (set) Token: 0x06001DC2 RID: 7618 RVA: 0x0001C8EF File Offset: 0x0001AAEF
		public bool MirrorVertical { get; set; }

		// Token: 0x17000A5B RID: 2651
		// (get) Token: 0x06001DC3 RID: 7619 RVA: 0x0001C900 File Offset: 0x0001AB00
		// (set) Token: 0x06001DC4 RID: 7620 RVA: 0x0001C90C File Offset: 0x0001AB0C
		public bool MirrorHorizontal { get; set; }

		// Token: 0x17000A5C RID: 2652
		// (get) Token: 0x06001DC5 RID: 7621 RVA: 0x0001C91D File Offset: 0x0001AB1D
		// (set) Token: 0x06001DC6 RID: 7622 RVA: 0x0001C929 File Offset: 0x0001AB29
		public bool RotateLeft { get; set; }

		// Token: 0x17000A5D RID: 2653
		// (get) Token: 0x06001DC7 RID: 7623 RVA: 0x0001C93A File Offset: 0x0001AB3A
		// (set) Token: 0x06001DC8 RID: 7624 RVA: 0x0001C946 File Offset: 0x0001AB46
		public bool RotateRight { get; set; }

		// Token: 0x17000A5E RID: 2654
		// (get) Token: 0x06001DC9 RID: 7625 RVA: 0x0001C957 File Offset: 0x0001AB57
		// (set) Token: 0x06001DCA RID: 7626 RVA: 0x0001C963 File Offset: 0x0001AB63
		public bool Rotate45Deg { get; set; }

		// Token: 0x17000A5F RID: 2655
		// (get) Token: 0x06001DCB RID: 7627 RVA: 0x0001C974 File Offset: 0x0001AB74
		// (set) Token: 0x06001DCC RID: 7628 RVA: 0x0001C980 File Offset: 0x0001AB80
		public bool ShowColoredZones { get; set; }

		// Token: 0x17000A60 RID: 2656
		// (get) Token: 0x06001DCD RID: 7629 RVA: 0x0001C991 File Offset: 0x0001AB91
		// (set) Token: 0x06001DCE RID: 7630 RVA: 0x0001C99D File Offset: 0x0001AB9D
		public bool ShowParameters { get; set; }

		// Token: 0x06001DCF RID: 7631 RVA: 0x000C1E94 File Offset: 0x000C0094
		public void #yJ()
		{
			this.MirrorHorizontal = (this.MirrorVertical = (this.Rotate45Deg = (this.RotateLeft = (this.RotateRight = false))));
		}

		// Token: 0x06001DD0 RID: 7632 RVA: 0x000C1ED8 File Offset: 0x000C00D8
		public TemplateOptions #CY()
		{
			return new TemplateOptions
			{
				MirrorHorizontal = this.MirrorHorizontal,
				MirrorVertical = this.MirrorVertical,
				Rotate45Deg = this.Rotate45Deg,
				RotateLeft = this.RotateLeft,
				RotateRight = this.RotateRight,
				ShowColoredZones = this.ShowColoredZones,
				ShowParameters = this.ShowParameters
			};
		}

		// Token: 0x04000BD8 RID: 3032
		[CompilerGenerated]
		private bool #a;

		// Token: 0x04000BD9 RID: 3033
		[CompilerGenerated]
		private bool #b;

		// Token: 0x04000BDA RID: 3034
		[CompilerGenerated]
		private bool #c;

		// Token: 0x04000BDB RID: 3035
		[CompilerGenerated]
		private bool #d;

		// Token: 0x04000BDC RID: 3036
		[CompilerGenerated]
		private bool #e;

		// Token: 0x04000BDD RID: 3037
		[CompilerGenerated]
		private bool #f;

		// Token: 0x04000BDE RID: 3038
		[CompilerGenerated]
		private bool #g;
	}
}
