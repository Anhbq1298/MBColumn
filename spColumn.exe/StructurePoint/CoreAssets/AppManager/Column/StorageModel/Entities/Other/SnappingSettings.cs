using System;
using System.Runtime.Serialization;
using #7hc;
using StructurePoint.CoreAssets.Units;

namespace StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities.Other
{
	// Token: 0x02001155 RID: 4437
	[DataContract(Name = "SnappingSettings", Namespace = "http://structurepoint.org/schemas/xml/spSPL/Column_1_0_0/")]
	public sealed class SnappingSettings
	{
		// Token: 0x06009620 RID: 38432 RVA: 0x000035C3 File Offset: 0x000017C3
		public SnappingSettings()
		{
		}

		// Token: 0x06009621 RID: 38433 RVA: 0x001FB09C File Offset: 0x001F929C
		public SnappingSettings(SnappingSettings other)
		{
			if (other == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399401));
			}
			this.SnapSpacingX = other.SnapSpacingX;
			this.SnapSpacingY = other.SnapSpacingY;
			this.EqualXAndYSpacing = other.EqualXAndYSpacing;
			this.SnapStructuralGrid = other.SnapStructuralGrid;
			this.SnapDrawingGrid = other.SnapDrawingGrid;
			this.SnapShapes = other.SnapShapes;
			this.SnapObjectsCentroid = other.SnapObjectsCentroid;
			this.SnapIntersection = other.SnapIntersection;
			this.SnappingGridEnabled = other.SnappingGridEnabled;
			this.ObjectSnappingEnabled = other.ObjectSnappingEnabled;
			this.SnapToCover = other.SnapToCover;
			this.SnapReinforcement = other.SnapReinforcement;
		}

		// Token: 0x17002B6F RID: 11119
		// (get) Token: 0x06009622 RID: 38434 RVA: 0x00077AF8 File Offset: 0x00075CF8
		// (set) Token: 0x06009623 RID: 38435 RVA: 0x00077B00 File Offset: 0x00075D00
		[DataMember(Order = 0)]
		public double SnapSpacingX { get; set; }

		// Token: 0x17002B70 RID: 11120
		// (get) Token: 0x06009624 RID: 38436 RVA: 0x00077B09 File Offset: 0x00075D09
		// (set) Token: 0x06009625 RID: 38437 RVA: 0x00077B11 File Offset: 0x00075D11
		[DataMember(Order = 1)]
		public double SnapSpacingY { get; set; }

		// Token: 0x17002B71 RID: 11121
		// (get) Token: 0x06009626 RID: 38438 RVA: 0x00077B1A File Offset: 0x00075D1A
		// (set) Token: 0x06009627 RID: 38439 RVA: 0x00077B22 File Offset: 0x00075D22
		[DataMember(Order = 2)]
		public bool EqualXAndYSpacing { get; set; }

		// Token: 0x17002B72 RID: 11122
		// (get) Token: 0x06009628 RID: 38440 RVA: 0x00077B2B File Offset: 0x00075D2B
		// (set) Token: 0x06009629 RID: 38441 RVA: 0x00077B33 File Offset: 0x00075D33
		[DataMember(Order = 3)]
		public bool SnapStructuralGrid { get; set; }

		// Token: 0x17002B73 RID: 11123
		// (get) Token: 0x0600962A RID: 38442 RVA: 0x00077B3C File Offset: 0x00075D3C
		// (set) Token: 0x0600962B RID: 38443 RVA: 0x00077B44 File Offset: 0x00075D44
		[DataMember(Order = 4)]
		public bool SnapDrawingGrid { get; set; }

		// Token: 0x17002B74 RID: 11124
		// (get) Token: 0x0600962C RID: 38444 RVA: 0x00077B4D File Offset: 0x00075D4D
		// (set) Token: 0x0600962D RID: 38445 RVA: 0x00077B55 File Offset: 0x00075D55
		[DataMember(Order = 5)]
		public bool SnapShapes { get; set; }

		// Token: 0x17002B75 RID: 11125
		// (get) Token: 0x0600962E RID: 38446 RVA: 0x00077B5E File Offset: 0x00075D5E
		// (set) Token: 0x0600962F RID: 38447 RVA: 0x00077B66 File Offset: 0x00075D66
		[DataMember(Order = 6)]
		public bool SnapReinforcement { get; set; }

		// Token: 0x17002B76 RID: 11126
		// (get) Token: 0x06009630 RID: 38448 RVA: 0x00077B6F File Offset: 0x00075D6F
		// (set) Token: 0x06009631 RID: 38449 RVA: 0x00077B77 File Offset: 0x00075D77
		[DataMember(Order = 7)]
		public bool SnapObjectsCentroid { get; set; }

		// Token: 0x17002B77 RID: 11127
		// (get) Token: 0x06009632 RID: 38450 RVA: 0x00077B80 File Offset: 0x00075D80
		// (set) Token: 0x06009633 RID: 38451 RVA: 0x00077B88 File Offset: 0x00075D88
		[DataMember(Order = 8)]
		public bool SnapIntersection { get; set; }

		// Token: 0x17002B78 RID: 11128
		// (get) Token: 0x06009634 RID: 38452 RVA: 0x00077B91 File Offset: 0x00075D91
		// (set) Token: 0x06009635 RID: 38453 RVA: 0x00077B99 File Offset: 0x00075D99
		[DataMember(Order = 9)]
		public bool SnapToCover { get; set; }

		// Token: 0x17002B79 RID: 11129
		// (get) Token: 0x06009636 RID: 38454 RVA: 0x00077BA2 File Offset: 0x00075DA2
		// (set) Token: 0x06009637 RID: 38455 RVA: 0x00077BAA File Offset: 0x00075DAA
		[DataMember(Order = 10)]
		public bool SnappingGridEnabled { get; set; }

		// Token: 0x17002B7A RID: 11130
		// (get) Token: 0x06009638 RID: 38456 RVA: 0x00077BB3 File Offset: 0x00075DB3
		// (set) Token: 0x06009639 RID: 38457 RVA: 0x00077BBB File Offset: 0x00075DBB
		[DataMember(Order = 11)]
		public bool ObjectSnappingEnabled { get; set; }

		// Token: 0x0600963A RID: 38458 RVA: 0x001FB154 File Offset: 0x001F9354
		public static SnappingSettings Default(UnitSystem unitSystem)
		{
			return new SnappingSettings
			{
				EqualXAndYSpacing = true,
				SnapDrawingGrid = true,
				SnapToCover = true,
				SnapReinforcement = true,
				ObjectSnappingEnabled = true,
				SnapObjectsCentroid = true,
				SnapShapes = true,
				SnapIntersection = true,
				SnapStructuralGrid = true,
				SnappingGridEnabled = false,
				SnapSpacingX = (double)((unitSystem == UnitSystem.SIMetric) ? 50 : 2),
				SnapSpacingY = (double)((unitSystem == UnitSystem.SIMetric) ? 50 : 2)
			};
		}
	}
}
