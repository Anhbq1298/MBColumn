using System;
using System.Runtime.Serialization;
using #7hc;
using StructurePoint.CoreAssets.Units;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Other
{
	// Token: 0x02001154 RID: 4436
	[DataContract(Name = "DynamicInputSettings", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class DynamicInputSettings
	{
		// Token: 0x06009615 RID: 38421 RVA: 0x001FB03C File Offset: 0x001F923C
		public DynamicInputSettings(DynamicInputSettings other)
		{
			if (other == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399401));
			}
			this.ShowPrompt = other.ShowPrompt;
			this.ShowInputBoxes = other.ShowInputBoxes;
			this.Enabled = other.Enabled;
			this.Precision = other.Precision;
		}

		// Token: 0x06009616 RID: 38422 RVA: 0x00077A7B File Offset: 0x00075C7B
		public DynamicInputSettings()
		{
		}

		// Token: 0x17002B6B RID: 11115
		// (get) Token: 0x06009617 RID: 38423 RVA: 0x00077A8A File Offset: 0x00075C8A
		// (set) Token: 0x06009618 RID: 38424 RVA: 0x00077A92 File Offset: 0x00075C92
		[DataMember(Order = 1)]
		public bool ShowPrompt { get; set; }

		// Token: 0x17002B6C RID: 11116
		// (get) Token: 0x06009619 RID: 38425 RVA: 0x00077A9B File Offset: 0x00075C9B
		// (set) Token: 0x0600961A RID: 38426 RVA: 0x00077AA3 File Offset: 0x00075CA3
		[DataMember(Order = 2)]
		public bool ShowInputBoxes { get; set; }

		// Token: 0x17002B6D RID: 11117
		// (get) Token: 0x0600961B RID: 38427 RVA: 0x00077AAC File Offset: 0x00075CAC
		// (set) Token: 0x0600961C RID: 38428 RVA: 0x00077AB4 File Offset: 0x00075CB4
		[DataMember(Order = 3)]
		public bool Enabled { get; set; }

		// Token: 0x17002B6E RID: 11118
		// (get) Token: 0x0600961D RID: 38429 RVA: 0x00077ABD File Offset: 0x00075CBD
		// (set) Token: 0x0600961E RID: 38430 RVA: 0x00077AC5 File Offset: 0x00075CC5
		[DataMember(Order = 4)]
		public int Precision { get; set; } = 2;

		// Token: 0x0600961F RID: 38431 RVA: 0x00077ACE File Offset: 0x00075CCE
		public static DynamicInputSettings Default(UnitSystem unitSystem)
		{
			return new DynamicInputSettings
			{
				Enabled = true,
				Precision = ((unitSystem == UnitSystem.SIMetric) ? 0 : 2),
				ShowInputBoxes = true,
				ShowPrompt = true
			};
		}
	}
}
