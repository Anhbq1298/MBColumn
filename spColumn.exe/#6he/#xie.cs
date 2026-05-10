using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace #6he
{
	// Token: 0x020010A1 RID: 4257
	internal sealed class #xie
	{
		// Token: 0x0600914F RID: 37199 RVA: 0x000035C3 File Offset: 0x000017C3
		public #xie()
		{
		}

		// Token: 0x06009150 RID: 37200 RVA: 0x0007518F File Offset: 0x0007338F
		public #xie(bool #yie, bool #zie, bool #Aie, bool #Bie, bool #Cie)
		{
			this.MirrorVertical = #yie;
			this.MirrorHorizontal = #zie;
			this.RotateLeft = #Aie;
			this.RotateRight = #Bie;
			this.Rotate45Deg = #Cie;
		}

		// Token: 0x06009151 RID: 37201 RVA: 0x001EB450 File Offset: 0x001E9650
		public #xie(TemplateOptions #mA)
		{
			this.MirrorVertical = #mA.MirrorVertical;
			this.MirrorHorizontal = #mA.MirrorHorizontal;
			this.RotateLeft = #mA.RotateLeft;
			this.RotateRight = #mA.RotateRight;
			this.Rotate45Deg = #mA.Rotate45Deg;
		}

		// Token: 0x17002A4C RID: 10828
		// (get) Token: 0x06009152 RID: 37202 RVA: 0x000751BC File Offset: 0x000733BC
		// (set) Token: 0x06009153 RID: 37203 RVA: 0x000751C4 File Offset: 0x000733C4
		public bool MirrorVertical { get; set; }

		// Token: 0x17002A4D RID: 10829
		// (get) Token: 0x06009154 RID: 37204 RVA: 0x000751CD File Offset: 0x000733CD
		// (set) Token: 0x06009155 RID: 37205 RVA: 0x000751D5 File Offset: 0x000733D5
		public bool MirrorHorizontal { get; set; }

		// Token: 0x17002A4E RID: 10830
		// (get) Token: 0x06009156 RID: 37206 RVA: 0x000751DE File Offset: 0x000733DE
		// (set) Token: 0x06009157 RID: 37207 RVA: 0x000751E6 File Offset: 0x000733E6
		public bool RotateLeft { get; set; }

		// Token: 0x17002A4F RID: 10831
		// (get) Token: 0x06009158 RID: 37208 RVA: 0x000751EF File Offset: 0x000733EF
		// (set) Token: 0x06009159 RID: 37209 RVA: 0x000751F7 File Offset: 0x000733F7
		public bool RotateRight { get; set; }

		// Token: 0x17002A50 RID: 10832
		// (get) Token: 0x0600915A RID: 37210 RVA: 0x00075200 File Offset: 0x00073400
		// (set) Token: 0x0600915B RID: 37211 RVA: 0x00075208 File Offset: 0x00073408
		public bool Rotate45Deg { get; set; }

		// Token: 0x0600915C RID: 37212 RVA: 0x00075211 File Offset: 0x00073411
		public bool #wie()
		{
			return this.MirrorVertical || this.MirrorHorizontal || this.RotateLeft || this.RotateRight || this.Rotate45Deg;
		}

		// Token: 0x04003D19 RID: 15641
		[CompilerGenerated]
		private bool #a;

		// Token: 0x04003D1A RID: 15642
		[CompilerGenerated]
		private bool #b;

		// Token: 0x04003D1B RID: 15643
		[CompilerGenerated]
		private bool #c;

		// Token: 0x04003D1C RID: 15644
		[CompilerGenerated]
		private bool #d;

		// Token: 0x04003D1D RID: 15645
		[CompilerGenerated]
		private bool #e;
	}
}
