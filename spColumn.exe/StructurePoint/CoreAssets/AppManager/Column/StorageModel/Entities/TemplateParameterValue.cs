using System;
using System.Runtime.Serialization;
using #9pe;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x02001135 RID: 4405
	[DataContract(Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/", Name = "TemplateParameterValue")]
	public sealed class TemplateParameterValue : #cqe
	{
		// Token: 0x0600946E RID: 37998 RVA: 0x0007684D File Offset: 0x00074A4D
		public TemplateParameterValue(string key, string value)
		{
			this.Key = key;
			this.Value = value;
		}

		// Token: 0x0600946F RID: 37999 RVA: 0x00076863 File Offset: 0x00074A63
		public TemplateParameterValue(TemplateParameterValue other)
		{
			this.Key = other.Key;
			this.Value = other.Value;
		}

		// Token: 0x06009470 RID: 38000 RVA: 0x000035C3 File Offset: 0x000017C3
		public TemplateParameterValue()
		{
		}

		// Token: 0x17002AC8 RID: 10952
		// (get) Token: 0x06009471 RID: 38001 RVA: 0x00076883 File Offset: 0x00074A83
		// (set) Token: 0x06009472 RID: 38002 RVA: 0x0007688B File Offset: 0x00074A8B
		[DataMember(Order = 0)]
		public string Key { get; set; }

		// Token: 0x17002AC9 RID: 10953
		// (get) Token: 0x06009473 RID: 38003 RVA: 0x00076894 File Offset: 0x00074A94
		// (set) Token: 0x06009474 RID: 38004 RVA: 0x0007689C File Offset: 0x00074A9C
		[DataMember(Order = 10)]
		public string Value { get; set; }
	}
}
