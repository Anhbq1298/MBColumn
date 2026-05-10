using System;
using System.Runtime.Serialization;
using #7hc;
using StructurePoint.CoreAssets.Units;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Other
{
	// Token: 0x02001152 RID: 4434
	[DataContract(Name = "DraftingSettings", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class DraftingSettings
	{
		// Token: 0x060095FF RID: 38399 RVA: 0x00077953 File Offset: 0x00075B53
		public DraftingSettings()
		{
			this.DrawingGridSettings = new DrawingGridSettings();
			this.DynamicInputSettings = new DynamicInputSettings();
			this.SnappingSettings = new SnappingSettings();
			this.StatusBarSettings = new StatusBarSettings();
		}

		// Token: 0x06009600 RID: 38400 RVA: 0x001FAF78 File Offset: 0x001F9178
		public DraftingSettings(DraftingSettings other)
		{
			if (other == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399401));
			}
			this.DrawingGridSettings = new DrawingGridSettings(other.DrawingGridSettings);
			this.DynamicInputSettings = new DynamicInputSettings(other.DynamicInputSettings);
			this.SnappingSettings = new SnappingSettings(other.SnappingSettings);
			this.StatusBarSettings = new StatusBarSettings(other.StatusBarSettings);
		}

		// Token: 0x17002B63 RID: 11107
		// (get) Token: 0x06009601 RID: 38401 RVA: 0x00077987 File Offset: 0x00075B87
		// (set) Token: 0x06009602 RID: 38402 RVA: 0x0007798F File Offset: 0x00075B8F
		[DataMember(Order = 1)]
		public DrawingGridSettings DrawingGridSettings { get; set; }

		// Token: 0x17002B64 RID: 11108
		// (get) Token: 0x06009603 RID: 38403 RVA: 0x00077998 File Offset: 0x00075B98
		// (set) Token: 0x06009604 RID: 38404 RVA: 0x000779A0 File Offset: 0x00075BA0
		[DataMember(Order = 2)]
		public DynamicInputSettings DynamicInputSettings { get; set; }

		// Token: 0x17002B65 RID: 11109
		// (get) Token: 0x06009605 RID: 38405 RVA: 0x000779A9 File Offset: 0x00075BA9
		// (set) Token: 0x06009606 RID: 38406 RVA: 0x000779B1 File Offset: 0x00075BB1
		[DataMember(Order = 3)]
		public SnappingSettings SnappingSettings { get; set; }

		// Token: 0x17002B66 RID: 11110
		// (get) Token: 0x06009607 RID: 38407 RVA: 0x000779BA File Offset: 0x00075BBA
		// (set) Token: 0x06009608 RID: 38408 RVA: 0x000779C2 File Offset: 0x00075BC2
		[DataMember(Order = 4)]
		public StatusBarSettings StatusBarSettings { get; set; }

		// Token: 0x06009609 RID: 38409 RVA: 0x000779CB File Offset: 0x00075BCB
		public static DraftingSettings Default(UnitSystem unitSystem)
		{
			return new DraftingSettings
			{
				SnappingSettings = SnappingSettings.Default(unitSystem),
				DynamicInputSettings = DynamicInputSettings.Default(unitSystem),
				StatusBarSettings = StatusBarSettings.Default(unitSystem),
				DrawingGridSettings = DrawingGridSettings.Default(unitSystem)
			};
		}
	}
}
