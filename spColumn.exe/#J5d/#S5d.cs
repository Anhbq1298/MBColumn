using System;
using System.Collections.Generic;
using StructurePoint.CoreAssets.Storage;

namespace #J5d
{
	// Token: 0x02000F2F RID: 3887
	internal interface #S5d
	{
		// Token: 0x17002891 RID: 10385
		// (get) Token: 0x060089C5 RID: 35269
		bool CanRead { get; }

		// Token: 0x17002892 RID: 10386
		// (get) Token: 0x060089C6 RID: 35270
		bool CanWrite { get; }

		// Token: 0x17002893 RID: 10387
		// (get) Token: 0x060089C7 RID: 35271
		IEnumerable<IStorageEntry> Entries { get; }

		// Token: 0x17002894 RID: 10388
		// (get) Token: 0x060089C8 RID: 35272
		// (set) Token: 0x060089C9 RID: 35273
		#I5d Metadata { get; set; }

		// Token: 0x060089CA RID: 35274
		IStorageEntry #R5d(string #4Hc, Version #Eec);
	}
}
