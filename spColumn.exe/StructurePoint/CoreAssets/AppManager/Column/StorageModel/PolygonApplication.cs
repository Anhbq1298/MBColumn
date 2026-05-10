using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel
{
	// Token: 0x0200111F RID: 4383
	[DataContract(Name = "PolygonApplication", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public enum PolygonApplication
	{
		// Token: 0x04003F4B RID: 16203
		[EnumMember]
		Solid,
		// Token: 0x04003F4C RID: 16204
		[EnumMember]
		Opening
	}
}
