using System;
using System.IO;

namespace StructurePoint.CoreAssets.Storage
{
	// Token: 0x02000F2D RID: 3885
	public interface IStorageEntry
	{
		// Token: 0x1700288A RID: 10378
		// (get) Token: 0x060089B6 RID: 35254
		string Path { get; }

		// Token: 0x1700288B RID: 10379
		// (get) Token: 0x060089B7 RID: 35255
		Version Version { get; }

		// Token: 0x060089B8 RID: 35256
		Stream #A5d();

		// Token: 0x060089B9 RID: 35257
		void #UVb(Stream #gp);
	}
}
