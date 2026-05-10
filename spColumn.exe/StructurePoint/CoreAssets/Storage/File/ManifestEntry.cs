using System;
using System.Xml.Serialization;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.Storage.File
{
	// Token: 0x02000F3E RID: 3902
	[Serializable]
	public sealed class ManifestEntry
	{
		// Token: 0x06008A13 RID: 35347 RVA: 0x000035C3 File Offset: 0x000017C3
		private ManifestEntry()
		{
		}

		// Token: 0x06008A14 RID: 35348 RVA: 0x001D6CF0 File Offset: 0x001D4EF0
		public ManifestEntry(string path, string version)
		{
			#X0d.#W0d(path, #Phc.#3hc(107226730), Component.StorageFile, #Phc.#3hc(107222058));
			#X0d.#W0d(version, #Phc.#3hc(107380513), Component.StorageFile, #Phc.#3hc(107222037));
			this.Path = path;
			this.Version = version;
		}

		// Token: 0x1700289B RID: 10395
		// (get) Token: 0x06008A15 RID: 35349 RVA: 0x0007059C File Offset: 0x0006E79C
		// (set) Token: 0x06008A16 RID: 35350 RVA: 0x000705A8 File Offset: 0x0006E7A8
		[XmlText]
		public string Path { get; set; }

		// Token: 0x1700289C RID: 10396
		// (get) Token: 0x06008A17 RID: 35351 RVA: 0x000705B9 File Offset: 0x0006E7B9
		// (set) Token: 0x06008A18 RID: 35352 RVA: 0x000705C5 File Offset: 0x0006E7C5
		[XmlAttribute("Version")]
		public string Version { get; set; }
	}
}
