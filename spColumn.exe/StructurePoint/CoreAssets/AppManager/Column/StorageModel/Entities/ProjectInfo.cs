using System;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities
{
	// Token: 0x02001145 RID: 4421
	[DataContract(Name = "ProjectInfo", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class ProjectInfo
	{
		// Token: 0x17002B23 RID: 11043
		// (get) Token: 0x06009556 RID: 38230 RVA: 0x000771B5 File Offset: 0x000753B5
		// (set) Token: 0x06009557 RID: 38231 RVA: 0x000771BD File Offset: 0x000753BD
		[DataMember(Name = "FileVersion", Order = 10)]
		public float FileVersion { get; set; }

		// Token: 0x17002B24 RID: 11044
		// (get) Token: 0x06009558 RID: 38232 RVA: 0x000771C6 File Offset: 0x000753C6
		// (set) Token: 0x06009559 RID: 38233 RVA: 0x000771CE File Offset: 0x000753CE
		[DataMember(Name = "Project", Order = 20)]
		public string Project { get; set; }

		// Token: 0x17002B25 RID: 11045
		// (get) Token: 0x0600955A RID: 38234 RVA: 0x000771D7 File Offset: 0x000753D7
		// (set) Token: 0x0600955B RID: 38235 RVA: 0x000771DF File Offset: 0x000753DF
		[DataMember(Name = "ColumnId", Order = 30)]
		public string ColumnId { get; set; }

		// Token: 0x17002B26 RID: 11046
		// (get) Token: 0x0600955C RID: 38236 RVA: 0x000771E8 File Offset: 0x000753E8
		// (set) Token: 0x0600955D RID: 38237 RVA: 0x000771F0 File Offset: 0x000753F0
		[DataMember(Name = "Engineer", Order = 40)]
		public string Engineer { get; set; }
	}
}
