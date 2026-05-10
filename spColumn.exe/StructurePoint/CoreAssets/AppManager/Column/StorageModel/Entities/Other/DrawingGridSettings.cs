using System;
using System.Runtime.Serialization;
using #7hc;
using StructurePoint.CoreAssets.Units;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Other
{
	// Token: 0x02001153 RID: 4435
	[DataContract(Name = "DrawingGridSettings", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class DrawingGridSettings
	{
		// Token: 0x0600960A RID: 38410 RVA: 0x000035C3 File Offset: 0x000017C3
		public DrawingGridSettings()
		{
		}

		// Token: 0x0600960B RID: 38411 RVA: 0x001FAFE4 File Offset: 0x001F91E4
		public DrawingGridSettings(DrawingGridSettings other)
		{
			if (other == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399401));
			}
			this.SpacingX = other.SpacingX;
			this.SpacingY = other.SpacingY;
			this.GridEnabled = other.GridEnabled;
			this.EqualXAndYSpacing = other.EqualXAndYSpacing;
		}

		// Token: 0x17002B67 RID: 11111
		// (get) Token: 0x0600960C RID: 38412 RVA: 0x00077A02 File Offset: 0x00075C02
		// (set) Token: 0x0600960D RID: 38413 RVA: 0x00077A0A File Offset: 0x00075C0A
		[DataMember(Order = 1)]
		public double SpacingX { get; set; }

		// Token: 0x17002B68 RID: 11112
		// (get) Token: 0x0600960E RID: 38414 RVA: 0x00077A13 File Offset: 0x00075C13
		// (set) Token: 0x0600960F RID: 38415 RVA: 0x00077A1B File Offset: 0x00075C1B
		[DataMember(Order = 2)]
		public double SpacingY { get; set; }

		// Token: 0x17002B69 RID: 11113
		// (get) Token: 0x06009610 RID: 38416 RVA: 0x00077A24 File Offset: 0x00075C24
		// (set) Token: 0x06009611 RID: 38417 RVA: 0x00077A2C File Offset: 0x00075C2C
		[DataMember(Order = 3)]
		public bool GridEnabled { get; set; }

		// Token: 0x17002B6A RID: 11114
		// (get) Token: 0x06009612 RID: 38418 RVA: 0x00077A35 File Offset: 0x00075C35
		// (set) Token: 0x06009613 RID: 38419 RVA: 0x00077A3D File Offset: 0x00075C3D
		[DataMember(Order = 3)]
		public bool EqualXAndYSpacing { get; set; }

		// Token: 0x06009614 RID: 38420 RVA: 0x00077A46 File Offset: 0x00075C46
		public static DrawingGridSettings Default(UnitSystem unitSystem)
		{
			return new DrawingGridSettings
			{
				EqualXAndYSpacing = true,
				GridEnabled = false,
				SpacingX = (double)((unitSystem == UnitSystem.SIMetric) ? 10 : 1),
				SpacingY = (double)((unitSystem == UnitSystem.SIMetric) ? 10 : 1)
			};
		}
	}
}
