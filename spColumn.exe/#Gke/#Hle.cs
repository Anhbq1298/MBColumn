using System;
using System.Runtime.CompilerServices;
using #wje;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy.Entities;

namespace #Gke
{
	// Token: 0x020010C5 RID: 4293
	internal sealed class #Hle
	{
		// Token: 0x06009229 RID: 37417 RVA: 0x001F073C File Offset: 0x001EE93C
		public #Hle()
		{
			this.InvDim = new float[2];
			this.DesDim = new float[6];
			this.DesCrit = new float[4];
			this.InteriorPoints = new FPOINT[10001];
			this.ExteriorPoints = new FPOINT[10001];
			this.RfBars = new IRREG[10000];
			this.FactLoads = new LOADS[10000];
			this.SldDesCol = new SLDDESCOL[2];
			this.SldAbvBlwCol = new SLDABVBLWCOL[2];
			this.EI = new float[2];
			this.SldBeam = new SLDBEAM[2];
			this.CrackedI = new float[2];
			this.ServLoads = #vje.#sje<float>(#Nle.ServLoadsSize.Dimension1, #Nle.ServLoadsSize.Dimension2);
			this.LoadFact = #vje.#sje<float>(#Nle.LoadFactSize.Dimension1, #Nle.LoadFactSize.Dimension2);
			this.Bar = new STNDBAR[16];
			this.SustFact = new float[5];
		}

		// Token: 0x17002A61 RID: 10849
		// (get) Token: 0x0600922A RID: 37418 RVA: 0x00075848 File Offset: 0x00073A48
		// (set) Token: 0x0600922B RID: 37419 RVA: 0x00075850 File Offset: 0x00073A50
		public short EditFlag { get; set; }

		// Token: 0x17002A62 RID: 10850
		// (get) Token: 0x0600922C RID: 37420 RVA: 0x00075859 File Offset: 0x00073A59
		// (set) Token: 0x0600922D RID: 37421 RVA: 0x00075861 File Offset: 0x00073A61
		public float FileVersion { get; set; }

		// Token: 0x17002A63 RID: 10851
		// (get) Token: 0x0600922E RID: 37422 RVA: 0x0007586A File Offset: 0x00073A6A
		// (set) Token: 0x0600922F RID: 37423 RVA: 0x00075872 File Offset: 0x00073A72
		public string Project { get; set; }

		// Token: 0x17002A64 RID: 10852
		// (get) Token: 0x06009230 RID: 37424 RVA: 0x0007587B File Offset: 0x00073A7B
		// (set) Token: 0x06009231 RID: 37425 RVA: 0x00075883 File Offset: 0x00073A83
		public string ColumnId { get; set; }

		// Token: 0x17002A65 RID: 10853
		// (get) Token: 0x06009232 RID: 37426 RVA: 0x0007588C File Offset: 0x00073A8C
		// (set) Token: 0x06009233 RID: 37427 RVA: 0x00075894 File Offset: 0x00073A94
		public string Engineer { get; set; }

		// Token: 0x17002A66 RID: 10854
		// (get) Token: 0x06009234 RID: 37428 RVA: 0x0007589D File Offset: 0x00073A9D
		// (set) Token: 0x06009235 RID: 37429 RVA: 0x000758A5 File Offset: 0x00073AA5
		public short InvInputFlag { get; set; }

		// Token: 0x17002A67 RID: 10855
		// (get) Token: 0x06009236 RID: 37430 RVA: 0x000758AE File Offset: 0x00073AAE
		// (set) Token: 0x06009237 RID: 37431 RVA: 0x000758B6 File Offset: 0x00073AB6
		public short DesInputFlag { get; set; }

		// Token: 0x17002A68 RID: 10856
		// (get) Token: 0x06009238 RID: 37432 RVA: 0x000758BF File Offset: 0x00073ABF
		// (set) Token: 0x06009239 RID: 37433 RVA: 0x000758C7 File Offset: 0x00073AC7
		public short SldInputFlag { get; set; }

		// Token: 0x17002A69 RID: 10857
		// (get) Token: 0x0600923A RID: 37434 RVA: 0x000758D0 File Offset: 0x00073AD0
		// (set) Token: 0x0600923B RID: 37435 RVA: 0x000758D8 File Offset: 0x00073AD8
		public #Ole Options { get; set; }

		// Token: 0x17002A6A RID: 10858
		// (get) Token: 0x0600923C RID: 37436 RVA: 0x000758E1 File Offset: 0x00073AE1
		// (set) Token: 0x0600923D RID: 37437 RVA: 0x000758E9 File Offset: 0x00073AE9
		public #Oke IrreggularOptions { get; set; }

		// Token: 0x17002A6B RID: 10859
		// (get) Token: 0x0600923E RID: 37438 RVA: 0x000758F2 File Offset: 0x00073AF2
		// (set) Token: 0x0600923F RID: 37439 RVA: 0x000758FA File Offset: 0x00073AFA
		public #Sle Ties { get; set; }

		// Token: 0x17002A6C RID: 10860
		// (get) Token: 0x06009240 RID: 37440 RVA: 0x00075903 File Offset: 0x00073B03
		// (set) Token: 0x06009241 RID: 37441 RVA: 0x0007590B File Offset: 0x00073B0B
		public #Rle InvRein { get; set; }

		// Token: 0x17002A6D RID: 10861
		// (get) Token: 0x06009242 RID: 37442 RVA: 0x00075914 File Offset: 0x00073B14
		// (set) Token: 0x06009243 RID: 37443 RVA: 0x0007591C File Offset: 0x00073B1C
		public #Rle DesRein { get; set; }

		// Token: 0x17002A6E RID: 10862
		// (get) Token: 0x06009244 RID: 37444 RVA: 0x00075925 File Offset: 0x00073B25
		// (set) Token: 0x06009245 RID: 37445 RVA: 0x0007592D File Offset: 0x00073B2D
		public float[] InvDim { get; set; }

		// Token: 0x17002A6F RID: 10863
		// (get) Token: 0x06009246 RID: 37446 RVA: 0x00075936 File Offset: 0x00073B36
		// (set) Token: 0x06009247 RID: 37447 RVA: 0x0007593E File Offset: 0x00073B3E
		public float[] DesDim { get; set; }

		// Token: 0x17002A70 RID: 10864
		// (get) Token: 0x06009248 RID: 37448 RVA: 0x00075947 File Offset: 0x00073B47
		// (set) Token: 0x06009249 RID: 37449 RVA: 0x0007594F File Offset: 0x00073B4F
		public #Jle MatProp { get; set; }

		// Token: 0x17002A71 RID: 10865
		// (get) Token: 0x0600924A RID: 37450 RVA: 0x00075958 File Offset: 0x00073B58
		// (set) Token: 0x0600924B RID: 37451 RVA: 0x00075960 File Offset: 0x00073B60
		public #Qle RedFactors { get; set; }

		// Token: 0x17002A72 RID: 10866
		// (get) Token: 0x0600924C RID: 37452 RVA: 0x00075969 File Offset: 0x00073B69
		// (set) Token: 0x0600924D RID: 37453 RVA: 0x00075971 File Offset: 0x00073B71
		public float[] DesCrit { get; set; }

		// Token: 0x17002A73 RID: 10867
		// (get) Token: 0x0600924E RID: 37454 RVA: 0x0007597A File Offset: 0x00073B7A
		// (set) Token: 0x0600924F RID: 37455 RVA: 0x00075982 File Offset: 0x00073B82
		public FPOINT[] ExteriorPoints { get; set; }

		// Token: 0x17002A74 RID: 10868
		// (get) Token: 0x06009250 RID: 37456 RVA: 0x0007598B File Offset: 0x00073B8B
		// (set) Token: 0x06009251 RID: 37457 RVA: 0x00075993 File Offset: 0x00073B93
		public FPOINT[] InteriorPoints { get; set; }

		// Token: 0x17002A75 RID: 10869
		// (get) Token: 0x06009252 RID: 37458 RVA: 0x0007599C File Offset: 0x00073B9C
		// (set) Token: 0x06009253 RID: 37459 RVA: 0x000759A4 File Offset: 0x00073BA4
		public IRREG[] RfBars { get; set; }

		// Token: 0x17002A76 RID: 10870
		// (get) Token: 0x06009254 RID: 37460 RVA: 0x000759AD File Offset: 0x00073BAD
		// (set) Token: 0x06009255 RID: 37461 RVA: 0x000759B5 File Offset: 0x00073BB5
		public LOADS[] FactLoads { get; set; }

		// Token: 0x17002A77 RID: 10871
		// (get) Token: 0x06009256 RID: 37462 RVA: 0x000759BE File Offset: 0x00073BBE
		// (set) Token: 0x06009257 RID: 37463 RVA: 0x000759C6 File Offset: 0x00073BC6
		public SLDDESCOL[] SldDesCol { get; set; }

		// Token: 0x17002A78 RID: 10872
		// (get) Token: 0x06009258 RID: 37464 RVA: 0x000759CF File Offset: 0x00073BCF
		// (set) Token: 0x06009259 RID: 37465 RVA: 0x000759D7 File Offset: 0x00073BD7
		public SLDABVBLWCOL[] SldAbvBlwCol { get; set; }

		// Token: 0x17002A79 RID: 10873
		// (get) Token: 0x0600925A RID: 37466 RVA: 0x000759E0 File Offset: 0x00073BE0
		// (set) Token: 0x0600925B RID: 37467 RVA: 0x000759E8 File Offset: 0x00073BE8
		public float[] EI { get; set; }

		// Token: 0x17002A7A RID: 10874
		// (get) Token: 0x0600925C RID: 37468 RVA: 0x000759F1 File Offset: 0x00073BF1
		// (set) Token: 0x0600925D RID: 37469 RVA: 0x000759F9 File Offset: 0x00073BF9
		public SLDBEAM[] SldBeam { get; set; }

		// Token: 0x17002A7B RID: 10875
		// (get) Token: 0x0600925E RID: 37470 RVA: 0x00075A02 File Offset: 0x00073C02
		// (set) Token: 0x0600925F RID: 37471 RVA: 0x00075A0A File Offset: 0x00073C0A
		public float Phi_Delta { get; set; }

		// Token: 0x17002A7C RID: 10876
		// (get) Token: 0x06009260 RID: 37472 RVA: 0x00075A13 File Offset: 0x00073C13
		// (set) Token: 0x06009261 RID: 37473 RVA: 0x00075A1B File Offset: 0x00073C1B
		public short SldOptFact { get; set; }

		// Token: 0x17002A7D RID: 10877
		// (get) Token: 0x06009262 RID: 37474 RVA: 0x00075A24 File Offset: 0x00073C24
		// (set) Token: 0x06009263 RID: 37475 RVA: 0x00075A2C File Offset: 0x00073C2C
		public float[] CrackedI { get; set; }

		// Token: 0x17002A7E RID: 10878
		// (get) Token: 0x06009264 RID: 37476 RVA: 0x00075A35 File Offset: 0x00073C35
		// (set) Token: 0x06009265 RID: 37477 RVA: 0x00075A3D File Offset: 0x00073C3D
		public float[][] ServLoads { get; set; }

		// Token: 0x17002A7F RID: 10879
		// (get) Token: 0x06009266 RID: 37478 RVA: 0x00075A46 File Offset: 0x00073C46
		// (set) Token: 0x06009267 RID: 37479 RVA: 0x00075A4E File Offset: 0x00073C4E
		public float[][] LoadFact { get; set; }

		// Token: 0x17002A80 RID: 10880
		// (get) Token: 0x06009268 RID: 37480 RVA: 0x00075A57 File Offset: 0x00073C57
		// (set) Token: 0x06009269 RID: 37481 RVA: 0x00075A5F File Offset: 0x00073C5F
		public short BarGroupType { get; set; }

		// Token: 0x17002A81 RID: 10881
		// (get) Token: 0x0600926A RID: 37482 RVA: 0x00075A68 File Offset: 0x00073C68
		// (set) Token: 0x0600926B RID: 37483 RVA: 0x00075A70 File Offset: 0x00073C70
		public short NumOfBars { get; set; }

		// Token: 0x17002A82 RID: 10882
		// (get) Token: 0x0600926C RID: 37484 RVA: 0x00075A79 File Offset: 0x00073C79
		// (set) Token: 0x0600926D RID: 37485 RVA: 0x00075A81 File Offset: 0x00073C81
		public STNDBAR[] Bar { get; set; }

		// Token: 0x17002A83 RID: 10883
		// (get) Token: 0x0600926E RID: 37486 RVA: 0x00075A8A File Offset: 0x00073C8A
		// (set) Token: 0x0600926F RID: 37487 RVA: 0x00075A92 File Offset: 0x00073C92
		public float[] SustFact { get; set; }

		// Token: 0x04003D8B RID: 15755
		[CompilerGenerated]
		private short #a;

		// Token: 0x04003D8C RID: 15756
		[CompilerGenerated]
		private float #b;

		// Token: 0x04003D8D RID: 15757
		[CompilerGenerated]
		private string #c;

		// Token: 0x04003D8E RID: 15758
		[CompilerGenerated]
		private string #d;

		// Token: 0x04003D8F RID: 15759
		[CompilerGenerated]
		private string #e;

		// Token: 0x04003D90 RID: 15760
		[CompilerGenerated]
		private short #f;

		// Token: 0x04003D91 RID: 15761
		[CompilerGenerated]
		private short #g;

		// Token: 0x04003D92 RID: 15762
		[CompilerGenerated]
		private short #h;

		// Token: 0x04003D93 RID: 15763
		[CompilerGenerated]
		private #Ole #i;

		// Token: 0x04003D94 RID: 15764
		[CompilerGenerated]
		private #Oke #j;

		// Token: 0x04003D95 RID: 15765
		[CompilerGenerated]
		private #Sle #k;

		// Token: 0x04003D96 RID: 15766
		[CompilerGenerated]
		private #Rle #l;

		// Token: 0x04003D97 RID: 15767
		[CompilerGenerated]
		private #Rle #m;

		// Token: 0x04003D98 RID: 15768
		[CompilerGenerated]
		private float[] #n;

		// Token: 0x04003D99 RID: 15769
		[CompilerGenerated]
		private float[] #o;

		// Token: 0x04003D9A RID: 15770
		[CompilerGenerated]
		private #Jle #p;

		// Token: 0x04003D9B RID: 15771
		[CompilerGenerated]
		private #Qle #q;

		// Token: 0x04003D9C RID: 15772
		[CompilerGenerated]
		private float[] #r;

		// Token: 0x04003D9D RID: 15773
		[CompilerGenerated]
		private FPOINT[] #s;

		// Token: 0x04003D9E RID: 15774
		[CompilerGenerated]
		private FPOINT[] #t;

		// Token: 0x04003D9F RID: 15775
		[CompilerGenerated]
		private IRREG[] #u;

		// Token: 0x04003DA0 RID: 15776
		[CompilerGenerated]
		private LOADS[] #v;

		// Token: 0x04003DA1 RID: 15777
		[CompilerGenerated]
		private SLDDESCOL[] #w;

		// Token: 0x04003DA2 RID: 15778
		[CompilerGenerated]
		private SLDABVBLWCOL[] #x;

		// Token: 0x04003DA3 RID: 15779
		[CompilerGenerated]
		private float[] #y;

		// Token: 0x04003DA4 RID: 15780
		[CompilerGenerated]
		private SLDBEAM[] #z;

		// Token: 0x04003DA5 RID: 15781
		[CompilerGenerated]
		private float #A;

		// Token: 0x04003DA6 RID: 15782
		[CompilerGenerated]
		private short #B;

		// Token: 0x04003DA7 RID: 15783
		[CompilerGenerated]
		private float[] #C;

		// Token: 0x04003DA8 RID: 15784
		[CompilerGenerated]
		private float[][] #D;

		// Token: 0x04003DA9 RID: 15785
		[CompilerGenerated]
		private float[][] #E;

		// Token: 0x04003DAA RID: 15786
		[CompilerGenerated]
		private short #F;

		// Token: 0x04003DAB RID: 15787
		[CompilerGenerated]
		private short #G;

		// Token: 0x04003DAC RID: 15788
		[CompilerGenerated]
		private STNDBAR[] #H;

		// Token: 0x04003DAD RID: 15789
		[CompilerGenerated]
		private float[] #I;
	}
}
