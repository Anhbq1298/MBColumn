using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel
{
	// Token: 0x0200112E RID: 4398
	[DataContract(Name = "ViewFlag", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	[Flags]
	public enum ViewFlag
	{
		// Token: 0x04003F8D RID: 16269
		[EnumMember]
		Info = 1,
		// Token: 0x04003F8E RID: 16270
		[EnumMember]
		Status = 2,
		// Token: 0x04003F8F RID: 16271
		[EnumMember]
		Toolbar = 4,
		// Token: 0x04003F90 RID: 16272
		[EnumMember]
		Grid = 8,
		// Token: 0x04003F91 RID: 16273
		[EnumMember]
		PositiveDiagram = 16,
		// Token: 0x04003F92 RID: 16274
		[EnumMember]
		NegativeDiagram = 32,
		// Token: 0x04003F93 RID: 16275
		[EnumMember]
		PointLabels = 64,
		// Token: 0x04003F94 RID: 16276
		[EnumMember]
		SpliceLines = 128,
		// Token: 0x04003F95 RID: 16277
		[EnumMember]
		NominalDiagram = 256,
		// Token: 0x04003F96 RID: 16278
		[EnumMember]
		Contour = 512
	}
}
