using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #7hc;
using #J5d;
using #J6d;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Storage;

namespace #A7d
{
	// Token: 0x02000F50 RID: 3920
	internal sealed class #z7d : #S5d
	{
		// Token: 0x06008A7A RID: 35450 RVA: 0x001D8650 File Offset: 0x001D6850
		public #z7d(#I5d #U5d)
		{
			#X0d.#V0d(#U5d, #Phc.#3hc(107219049), Component.StorageFile, #Phc.#3hc(107218605));
			this.CanWrite = true;
			this.CanRead = false;
			this.#a = new List<IStorageEntry>();
			this.Metadata = #U5d;
		}

		// Token: 0x06008A7B RID: 35451 RVA: 0x001D86A0 File Offset: 0x001D68A0
		public #z7d(#I5d #U5d, IEnumerable<IStorageEntry> #Bl)
		{
			#X0d.#V0d(#U5d, #Phc.#3hc(107219049), Component.StorageFile, #Phc.#3hc(107218584));
			#X0d.#V0d(#Bl, #Phc.#3hc(107218499), Component.StorageFile, #Phc.#3hc(107218518));
			this.CanWrite = false;
			this.CanRead = true;
			this.#a = new List<IStorageEntry>(#Bl);
			this.Metadata = #U5d;
		}

		// Token: 0x170028AB RID: 10411
		// (get) Token: 0x06008A7C RID: 35452 RVA: 0x00070AC0 File Offset: 0x0006ECC0
		// (set) Token: 0x06008A7D RID: 35453 RVA: 0x00070ACC File Offset: 0x0006ECCC
		public #I5d Metadata { get; set; }

		// Token: 0x170028AC RID: 10412
		// (get) Token: 0x06008A7E RID: 35454 RVA: 0x00070ADD File Offset: 0x0006ECDD
		public IEnumerable<IStorageEntry> Entries
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x170028AD RID: 10413
		// (get) Token: 0x06008A7F RID: 35455 RVA: 0x00070AE9 File Offset: 0x0006ECE9
		// (set) Token: 0x06008A80 RID: 35456 RVA: 0x00070AF5 File Offset: 0x0006ECF5
		public bool CanRead { get; private set; }

		// Token: 0x170028AE RID: 10414
		// (get) Token: 0x06008A81 RID: 35457 RVA: 0x00070B06 File Offset: 0x0006ED06
		// (set) Token: 0x06008A82 RID: 35458 RVA: 0x00070B12 File Offset: 0x0006ED12
		public bool CanWrite { get; private set; }

		// Token: 0x06008A83 RID: 35459 RVA: 0x001D870C File Offset: 0x001D690C
		public IStorageEntry #R5d(string #So, Version #Eec)
		{
			#X0d.#W0d(#So, #Phc.#3hc(107226730), Component.StorageFile, #Phc.#3hc(107218433));
			#X0d.#V0d(#Eec, #Phc.#3hc(107380513), Component.StorageFile, #Phc.#3hc(107218892));
			if (!this.CanWrite)
			{
				throw new InvalidOperationException(Strings.StringAnAttemptWasMadeToCreateANewEntryInTheReadOnlyStorageModel.#z2d());
			}
			#L6d #L6d = new #L6d(#So, #Eec);
			this.#a.Add(#L6d);
			return #L6d;
		}

		// Token: 0x04003900 RID: 14592
		private readonly List<IStorageEntry> #a;

		// Token: 0x04003901 RID: 14593
		[CompilerGenerated]
		private #I5d #b;

		// Token: 0x04003902 RID: 14594
		[CompilerGenerated]
		private bool #c;

		// Token: 0x04003903 RID: 14595
		[CompilerGenerated]
		private bool #d;
	}
}
