using System;
using System.Runtime.Serialization;
using #7hc;
using StructurePoint.CoreAssets.Units;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Other
{
	// Token: 0x02001156 RID: 4438
	[DataContract(Name = "StatusBarSettings", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class StatusBarSettings
	{
		// Token: 0x0600963B RID: 38459 RVA: 0x000035C3 File Offset: 0x000017C3
		public StatusBarSettings()
		{
		}

		// Token: 0x0600963C RID: 38460 RVA: 0x00077BC4 File Offset: 0x00075DC4
		public StatusBarSettings(StatusBarSettings other)
		{
			if (other == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399401));
			}
			this.ShowCoordinates = other.ShowCoordinates;
			this.FloatingPointPrecision = other.FloatingPointPrecision;
			this.FootInchPrecision = other.FootInchPrecision;
		}

		// Token: 0x17002B7B RID: 11131
		// (get) Token: 0x0600963D RID: 38461 RVA: 0x00077C03 File Offset: 0x00075E03
		// (set) Token: 0x0600963E RID: 38462 RVA: 0x00077C0B File Offset: 0x00075E0B
		[DataMember(Order = 1)]
		public bool ShowCoordinates { get; set; }

		// Token: 0x17002B7C RID: 11132
		// (get) Token: 0x0600963F RID: 38463 RVA: 0x00077C14 File Offset: 0x00075E14
		// (set) Token: 0x06009640 RID: 38464 RVA: 0x00077C1C File Offset: 0x00075E1C
		[DataMember(Order = 2)]
		public int FloatingPointPrecision { get; set; }

		// Token: 0x17002B7D RID: 11133
		// (get) Token: 0x06009641 RID: 38465 RVA: 0x00077C25 File Offset: 0x00075E25
		// (set) Token: 0x06009642 RID: 38466 RVA: 0x00077C2D File Offset: 0x00075E2D
		[DataMember(Order = 3)]
		public int FootInchPrecision { get; set; }

		// Token: 0x06009643 RID: 38467 RVA: 0x00077C36 File Offset: 0x00075E36
		public static StatusBarSettings Default(UnitSystem unitSystem)
		{
			return new StatusBarSettings
			{
				ShowCoordinates = true,
				FloatingPointPrecision = 2,
				FootInchPrecision = 2
			};
		}
	}
}
