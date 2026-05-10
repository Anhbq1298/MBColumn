using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #coe;
using #J5d;
using #o1d;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Storage;

namespace #Lme
{
	// Token: 0x020010D9 RID: 4313
	internal sealed class #Kme : #0oe
	{
		// Token: 0x17002A87 RID: 10887
		// (get) Token: 0x060092A7 RID: 37543 RVA: 0x00075BC3 File Offset: 0x00073DC3
		public override Version SupportedVersion { get; } = new Version(#Phc.#3hc(107455667));

		// Token: 0x060092A8 RID: 37544 RVA: 0x001F2320 File Offset: 0x001F0520
		public override void #npb(#S5d #Y5d, ColumnStorageModel #Od)
		{
			if (#Od == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399786));
			}
			IStorageEntry storageEntry = #Y5d.#R5d(#Phc.#3hc(107290105), this.SupportedVersion);
			MemoryStream memoryStream = new MemoryStream();
			#0oe.#y0d<ColumnStorageModel>(#Od, memoryStream);
			memoryStream.#i2d();
			storageEntry.#UVb(memoryStream);
		}

		// Token: 0x060092A9 RID: 37545 RVA: 0x001F2370 File Offset: 0x001F0570
		public override ColumnStorageModel #Cjc(#S5d #Y5d)
		{
			if (#Y5d == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107455652));
			}
			List<IStorageEntry> list = #Y5d.Entries.Where(new Func<IStorageEntry, bool>(this.#Jme)).ToList<IStorageEntry>();
			if (list.Count != 1)
			{
				throw new InvalidOperationException();
			}
			return #0oe.#C0d<ColumnStorageModel>(list[0].#A5d());
		}

		// Token: 0x060092AB RID: 37547 RVA: 0x00075BE8 File Offset: 0x00073DE8
		[CompilerGenerated]
		private bool #Jme(IStorageEntry #Rf)
		{
			return string.Equals(#Rf.Path, #Phc.#3hc(107290105), StringComparison.OrdinalIgnoreCase) && #Rf.Version == this.SupportedVersion;
		}

		// Token: 0x04003E60 RID: 15968
		public new const string #a = "Version_1.0.0/Model.xml";

		// Token: 0x04003E61 RID: 15969
		private const string #b = "Model.xml";

		// Token: 0x04003E62 RID: 15970
		private const string #c = "1.0.0";

		// Token: 0x04003E63 RID: 15971
		[CompilerGenerated]
		private readonly Version #d;
	}
}
