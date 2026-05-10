using System;
using #5Z;
using #npe;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;

namespace #M7
{
	// Token: 0x020003C3 RID: 963
	internal static class #d8
	{
		// Token: 0x060020F2 RID: 8434 RVA: 0x0002042B File Offset: 0x0001E62B
		public static Beam #77()
		{
			return new Beam
			{
				BeamType = BeamType.None
			};
		}

		// Token: 0x060020F3 RID: 8435 RVA: 0x000C7E40 File Offset: 0x000C6040
		public static Beam #87(ColumnModel #Od)
		{
			bool flag = #Od.Options.Unit == UnitSystem.USCustomary;
			float length = flag ? 18f : 5.5f;
			float width = flag ? 20f : 500f;
			float depth = flag ? 24f : 600f;
			return new Beam
			{
				Depth = depth,
				Ec = 0f,
				Length = length,
				MofI = 0f,
				Fcp = #Od.MaterialProperties.Fcp,
				Width = width,
				BeamType = BeamType.Rectangular,
				IsConcreteStandard = true,
				IsInertiaStandard = true
			};
		}

		// Token: 0x060020F4 RID: 8436 RVA: 0x0002043D File Offset: 0x0001E63D
		public static Beam #97()
		{
			return new Beam(#Tai.#Sai());
		}

		// Token: 0x060020F5 RID: 8437 RVA: 0x000C7F00 File Offset: 0x000C6100
		public static #X3 #a8()
		{
			return new #X3
			{
				CheckSwayAtEndsOnly = true,
				Height = 0f,
				IsBraced = true,
				Kbraced = 0f,
				Kmode = Kmode.Compute,
				Ksway = 0f,
				SumPc = 1f,
				SumPu = 1f
			};
		}

		// Token: 0x060020F6 RID: 8438 RVA: 0x000C7F64 File Offset: 0x000C6164
		public static SlendernessOfColumn #b8(ColumnModel #Od, SlendernessColumnType #c8 = SlendernessColumnType.None)
		{
			float fcp = (#c8 != SlendernessColumnType.None) ? #Od.MaterialProperties.Fcp : 0f;
			bool isConcreteStandard = #c8 > SlendernessColumnType.None;
			bool flag = #Od.Options.Unit == UnitSystem.USCustomary;
			bool flag2 = #c8 == SlendernessColumnType.Rectangular;
			bool flag3 = flag2 || #c8 == SlendernessColumnType.Circular;
			float height = flag ? 12f : 3.6f;
			float num = flag ? 24f : 600f;
			float num2 = flag ? 24f : 600f;
			return new SlendernessOfColumn
			{
				SlendernessColumnType = #c8,
				Height = height,
				Width = (flag2 ? num : 0f),
				Depth = (flag3 ? num2 : 0f),
				Ec = 0f,
				Fcp = fcp,
				IsConcreteStandard = isConcreteStandard
			};
		}
	}
}
