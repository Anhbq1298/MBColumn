using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.Storage.File.Input
{
	// Token: 0x02000F4A RID: 3914
	[XmlRoot(ElementName = "Project", Namespace = "http://structurepoint.org/spSPL")]
	[Serializable]
	public sealed class InputManifest
	{
		// Token: 0x06008A55 RID: 35413 RVA: 0x001D7E7C File Offset: 0x001D607C
		public InputManifest(string name, EncryptionMethod encryptionMethod, string applicationVersion, DateTime creationTime, DateTime modificationTime)
		{
			#X0d.#W0d(applicationVersion, #Phc.#3hc(107219650), Component.StorageFile, #Phc.#3hc(107219625));
			this.Entries = new List<ManifestEntry>();
			this.Name = name;
			this.EncryptionMethod = encryptionMethod;
			this.ApplicationVersion = applicationVersion;
			this.CreationTime = creationTime;
			this.ModificationTime = modificationTime;
		}

		// Token: 0x06008A56 RID: 35414 RVA: 0x000035C3 File Offset: 0x000017C3
		private InputManifest()
		{
		}

		// Token: 0x170028A5 RID: 10405
		// (get) Token: 0x06008A57 RID: 35415 RVA: 0x00070835 File Offset: 0x0006EA35
		// (set) Token: 0x06008A58 RID: 35416 RVA: 0x00070841 File Offset: 0x0006EA41
		public string Name { get; set; }

		// Token: 0x170028A6 RID: 10406
		// (get) Token: 0x06008A59 RID: 35417 RVA: 0x00070852 File Offset: 0x0006EA52
		// (set) Token: 0x06008A5A RID: 35418 RVA: 0x0007085E File Offset: 0x0006EA5E
		public EncryptionMethod EncryptionMethod { get; set; }

		// Token: 0x170028A7 RID: 10407
		// (get) Token: 0x06008A5B RID: 35419 RVA: 0x0007086F File Offset: 0x0006EA6F
		// (set) Token: 0x06008A5C RID: 35420 RVA: 0x0007087B File Offset: 0x0006EA7B
		public string ApplicationVersion { get; set; }

		// Token: 0x170028A8 RID: 10408
		// (get) Token: 0x06008A5D RID: 35421 RVA: 0x0007088C File Offset: 0x0006EA8C
		// (set) Token: 0x06008A5E RID: 35422 RVA: 0x00070898 File Offset: 0x0006EA98
		public DateTime CreationTime { get; set; }

		// Token: 0x170028A9 RID: 10409
		// (get) Token: 0x06008A5F RID: 35423 RVA: 0x000708A9 File Offset: 0x0006EAA9
		// (set) Token: 0x06008A60 RID: 35424 RVA: 0x000708B5 File Offset: 0x0006EAB5
		public DateTime ModificationTime { get; set; }

		// Token: 0x170028AA RID: 10410
		// (get) Token: 0x06008A61 RID: 35425 RVA: 0x000708C6 File Offset: 0x0006EAC6
		// (set) Token: 0x06008A62 RID: 35426 RVA: 0x000708D2 File Offset: 0x0006EAD2
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Better for XML serializer.")]
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "XmlSerializer requires public setters")]
		[XmlArray("Entries")]
		[XmlArrayItem("Entry")]
		public List<ManifestEntry> Entries { get; set; }
	}
}
