using System;
using System.IO;
using System.Runtime.CompilerServices;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Storage;

namespace #J6d
{
	// Token: 0x02000F40 RID: 3904
	internal sealed class #L6d : IStorageEntry
	{
		// Token: 0x06008A1B RID: 35355 RVA: 0x001D6D48 File Offset: 0x001D4F48
		public #L6d(string #So, Version #Eec)
		{
			#X0d.#W0d(#So, #Phc.#3hc(107226730), Component.StorageFile, #Phc.#3hc(107222464));
			#X0d.#V0d(#Eec, #Phc.#3hc(107380513), Component.StorageFile, #Phc.#3hc(107222411));
			this.Path = #So;
			this.Version = #Eec;
		}

		// Token: 0x1700289D RID: 10397
		// (get) Token: 0x06008A1C RID: 35356 RVA: 0x000705E6 File Offset: 0x0006E7E6
		// (set) Token: 0x06008A1D RID: 35357 RVA: 0x000705F2 File Offset: 0x0006E7F2
		public string Path { get; private set; }

		// Token: 0x1700289E RID: 10398
		// (get) Token: 0x06008A1E RID: 35358 RVA: 0x00070603 File Offset: 0x0006E803
		// (set) Token: 0x06008A1F RID: 35359 RVA: 0x0007060F File Offset: 0x0006E80F
		public Version Version { get; private set; }

		// Token: 0x06008A20 RID: 35360 RVA: 0x00070620 File Offset: 0x0006E820
		public Stream #A5d()
		{
			return this.#a;
		}

		// Token: 0x06008A21 RID: 35361 RVA: 0x0007062C File Offset: 0x0006E82C
		public void #UVb(Stream #gp)
		{
			#X0d.#V0d(#gp, #Phc.#3hc(107377314), Component.StorageFile, #Phc.#3hc(107222390));
			this.#a = #gp;
		}

		// Token: 0x040038D7 RID: 14551
		private Stream #a;

		// Token: 0x040038D8 RID: 14552
		[CompilerGenerated]
		private string #b;

		// Token: 0x040038D9 RID: 14553
		[CompilerGenerated]
		private Version #c;
	}
}
