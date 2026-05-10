using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Storage;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x02001137 RID: 4407
	[DataContract(Name = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class TemplateData
	{
		// Token: 0x06009486 RID: 38022 RVA: 0x001FA648 File Offset: 0x001F8848
		public TemplateData(TemplateData other)
		{
			this.Definition = other.Definition;
			this.Options = new TemplateOptions(other.Options);
			this.ParameterValues.AddRange(from item in other.ParameterValues
			select new TemplateParameterValue(item));
		}

		// Token: 0x06009487 RID: 38023 RVA: 0x00076958 File Offset: 0x00074B58
		public TemplateData()
		{
		}

		// Token: 0x17002AD1 RID: 10961
		// (get) Token: 0x06009488 RID: 38024 RVA: 0x00076976 File Offset: 0x00074B76
		// (set) Token: 0x06009489 RID: 38025 RVA: 0x0007697E File Offset: 0x00074B7E
		[DataMember(Name = "Definition", Order = 0)]
		public SectionTemplateDefinition Definition { get; set; }

		// Token: 0x17002AD2 RID: 10962
		// (get) Token: 0x0600948A RID: 38026 RVA: 0x00076987 File Offset: 0x00074B87
		// (set) Token: 0x0600948B RID: 38027 RVA: 0x0007698F File Offset: 0x00074B8F
		[DataMember(Order = 20, Name = "ParameterValues")]
		public List<TemplateParameterValue> ParameterValues { get; set; } = new List<TemplateParameterValue>();

		// Token: 0x17002AD3 RID: 10963
		// (get) Token: 0x0600948C RID: 38028 RVA: 0x00076998 File Offset: 0x00074B98
		// (set) Token: 0x0600948D RID: 38029 RVA: 0x000769A0 File Offset: 0x00074BA0
		[DataMember(Name = "Options", Order = 30)]
		public TemplateOptions Options { get; set; } = new TemplateOptions();
	}
}
