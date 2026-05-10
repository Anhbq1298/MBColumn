using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates
{
	// Token: 0x02001063 RID: 4195
	[Flags]
	[XmlRoot(Namespace = "http://structurepoint.org/spSPL/Column/Templates", ElementName = "Code")]
	[DataContract(Namespace = "http://structurepoint.org/spSPL/Column/Templates", Name = "Code")]
	public enum DesignCodeSpecs
	{
		// Token: 0x04003C33 RID: 15411
		[EnumMember]
		[XmlEnum]
		ACI02 = 1,
		// Token: 0x04003C34 RID: 15412
		[EnumMember]
		[XmlEnum]
		CSA94 = 2,
		// Token: 0x04003C35 RID: 15413
		[EnumMember]
		[XmlEnum]
		ACI05 = 4,
		// Token: 0x04003C36 RID: 15414
		[EnumMember]
		[XmlEnum]
		CSA04 = 8,
		// Token: 0x04003C37 RID: 15415
		[EnumMember]
		[XmlEnum]
		ACI08 = 16,
		// Token: 0x04003C38 RID: 15416
		[EnumMember]
		[XmlEnum]
		ACI11 = 32,
		// Token: 0x04003C39 RID: 15417
		[EnumMember]
		[XmlEnum]
		ACI14 = 64,
		// Token: 0x04003C3A RID: 15418
		[EnumMember]
		[XmlEnum]
		CSA14 = 128,
		// Token: 0x04003C3B RID: 15419
		[EnumMember]
		[XmlEnum]
		ACI19 = 256,
		// Token: 0x04003C3C RID: 15420
		[EnumMember]
		[XmlEnum]
		CSA19 = 512,
		// Token: 0x04003C3D RID: 15421
		[EnumMember]
		[XmlEnum]
		AllCsa = 650,
		// Token: 0x04003C3E RID: 15422
		[EnumMember]
		[XmlEnum]
		AllAci = 373,
		// Token: 0x04003C3F RID: 15423
		[EnumMember]
		[XmlEnum]
		All = 1023
	}
}
