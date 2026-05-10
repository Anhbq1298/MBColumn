using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Storage
{
	// Token: 0x0200106F RID: 4207
	[XmlRoot("Validator", Namespace = "http://structurepoint.org/spSPL/Column/Templates")]
	[DataContract(Namespace = "http://structurepoint.org/spSPL/Column/Templates")]
	public sealed class ValidatorDefinition : DependentModelBase
	{
		// Token: 0x06008FC2 RID: 36802 RVA: 0x000742DA File Offset: 0x000724DA
		public ValidatorDefinition()
		{
		}

		// Token: 0x06008FC3 RID: 36803 RVA: 0x000742F8 File Offset: 0x000724F8
		public ValidatorDefinition(string code, params LocalizableString[] validationMessages)
		{
			this.Code.Code = code;
			this.Message.Values.AddRange(validationMessages);
		}

		// Token: 0x170029D2 RID: 10706
		// (get) Token: 0x06008FC4 RID: 36804 RVA: 0x00074333 File Offset: 0x00072533
		// (set) Token: 0x06008FC5 RID: 36805 RVA: 0x0007433B File Offset: 0x0007253B
		[XmlElement("Code")]
		[DataMember(Order = 10)]
		public CodeItem Code { get; set; } = new CodeItem();

		// Token: 0x170029D3 RID: 10707
		// (get) Token: 0x06008FC6 RID: 36806 RVA: 0x00074344 File Offset: 0x00072544
		// (set) Token: 0x06008FC7 RID: 36807 RVA: 0x0007434C File Offset: 0x0007254C
		[XmlElement("Message")]
		[DataMember(Order = 20)]
		public LocalizableProperty Message { get; set; } = new LocalizableProperty();
	}
}
