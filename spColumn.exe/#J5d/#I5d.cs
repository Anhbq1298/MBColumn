using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.Storage;

namespace #J5d
{
	// Token: 0x02000F2E RID: 3886
	internal sealed class #I5d
	{
		// Token: 0x060089BA RID: 35258 RVA: 0x000701D9 File Offset: 0x0006E3D9
		public #I5d(string #wy, string #K5d, DateTime #L5d, DateTime #M5d, EncryptionMethod #N5d)
		{
			this.Name = #wy;
			this.ApplicationVersion = #K5d;
			this.CreationTime = #L5d;
			this.ModificationTime = #M5d;
			this.EncryptionMethod = #N5d;
		}

		// Token: 0x1700288C RID: 10380
		// (get) Token: 0x060089BB RID: 35259 RVA: 0x00070206 File Offset: 0x0006E406
		// (set) Token: 0x060089BC RID: 35260 RVA: 0x00070212 File Offset: 0x0006E412
		public string Name { get; set; }

		// Token: 0x1700288D RID: 10381
		// (get) Token: 0x060089BD RID: 35261 RVA: 0x00070223 File Offset: 0x0006E423
		// (set) Token: 0x060089BE RID: 35262 RVA: 0x0007022F File Offset: 0x0006E42F
		public string ApplicationVersion { get; set; }

		// Token: 0x1700288E RID: 10382
		// (get) Token: 0x060089BF RID: 35263 RVA: 0x00070240 File Offset: 0x0006E440
		// (set) Token: 0x060089C0 RID: 35264 RVA: 0x0007024C File Offset: 0x0006E44C
		public DateTime CreationTime { get; set; }

		// Token: 0x1700288F RID: 10383
		// (get) Token: 0x060089C1 RID: 35265 RVA: 0x0007025D File Offset: 0x0006E45D
		// (set) Token: 0x060089C2 RID: 35266 RVA: 0x00070269 File Offset: 0x0006E469
		public DateTime ModificationTime { get; set; }

		// Token: 0x17002890 RID: 10384
		// (get) Token: 0x060089C3 RID: 35267 RVA: 0x0007027A File Offset: 0x0006E47A
		// (set) Token: 0x060089C4 RID: 35268 RVA: 0x00070286 File Offset: 0x0006E486
		public EncryptionMethod EncryptionMethod { get; set; }

		// Token: 0x040038B4 RID: 14516
		[CompilerGenerated]
		private string #a;

		// Token: 0x040038B5 RID: 14517
		[CompilerGenerated]
		private string #b;

		// Token: 0x040038B6 RID: 14518
		[CompilerGenerated]
		private DateTime #c;

		// Token: 0x040038B7 RID: 14519
		[CompilerGenerated]
		private DateTime #d;

		// Token: 0x040038B8 RID: 14520
		[CompilerGenerated]
		private EncryptionMethod #e;
	}
}
