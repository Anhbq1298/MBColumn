using System;
using System.Runtime.CompilerServices;
using #A9d;
using #Aae;
using #N7d;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Units;
using StructurePoint.CoreAssets.Units.Formatters;
using StructurePoint.CoreAssets.Units.UnitSets;

namespace StructurePoint.Products.Column.Model.Entities.Units
{
	// Token: 0x020003B0 RID: 944
	internal sealed class ColumnUnit<TUnit> : NotifyPropertyChangedObjectBase where TUnit : struct, IComparable
	{
		// Token: 0x06001F79 RID: 8057 RVA: 0x000C3BB4 File Offset: 0x000C1DB4
		public ColumnUnit(UnitSystem unitSystem, Enum unitType, int precision, string defaultScientificFormat = null)
		{
			this.#b = unitSystem;
			this.#c = (!0)((object)unitType);
			this.#d = precision;
			this.#e = this.#d4(unitSystem, unitType, precision, defaultScientificFormat);
			this.#f = new #wae(unitType, this.UnitValueFormatter);
			this.#a = new UnitConverter<!0>();
		}

		// Token: 0x06001F7A RID: 8058 RVA: 0x0001EBF0 File Offset: 0x0001CDF0
		public ColumnUnit(UnitSystem unitSystem, Enum unitType) : this(unitSystem, unitType, 0, null)
		{
			this.#e = #R9h.#Q9h();
			this.#f = new #wae(unitType, this.UnitValueFormatter);
		}

		// Token: 0x17000B00 RID: 2816
		// (get) Token: 0x06001F7B RID: 8059 RVA: 0x0001EC19 File Offset: 0x0001CE19
		public UnitSystem UnitSystem { get; }

		// Token: 0x17000B01 RID: 2817
		// (get) Token: 0x06001F7C RID: 8060 RVA: 0x0001EC25 File Offset: 0x0001CE25
		public TUnit UnitType { get; }

		// Token: 0x17000B02 RID: 2818
		// (get) Token: 0x06001F7D RID: 8061 RVA: 0x0001EC31 File Offset: 0x0001CE31
		public int Precision { get; }

		// Token: 0x17000B03 RID: 2819
		// (get) Token: 0x06001F7E RID: 8062 RVA: 0x0001EC3D File Offset: 0x0001CE3D
		public IUnitValueFormatter UnitValueFormatter { get; }

		// Token: 0x17000B04 RID: 2820
		// (get) Token: 0x06001F7F RID: 8063 RVA: 0x0001EC49 File Offset: 0x0001CE49
		public IUnit Unit { get; }

		// Token: 0x17000B05 RID: 2821
		// (get) Token: 0x06001F80 RID: 8064 RVA: 0x0001EC55 File Offset: 0x0001CE55
		public string Symbol
		{
			get
			{
				IUnit unit = this.Unit;
				if (unit == null)
				{
					return null;
				}
				IUnitSymbol unitSymbol = unit.UnitSymbol;
				if (unitSymbol == null)
				{
					return null;
				}
				return unitSymbol.Symbol;
			}
		}

		// Token: 0x06001F81 RID: 8065 RVA: 0x0001EC7B File Offset: 0x0001CE7B
		public double #a4(ColumnUnit<TUnit> #b4, double #c4)
		{
			return this.#a.#Pb(this.UnitType, #b4.UnitType, #c4);
		}

		// Token: 0x06001F82 RID: 8066 RVA: 0x0001ECA1 File Offset: 0x0001CEA1
		private IUnitValueFormatter #d4(UnitSystem #Qg, Enum #e4, int #8W, string #vVh)
		{
			return new #zae(#8W, true, #vVh);
		}

		// Token: 0x04000C75 RID: 3189
		private readonly #L8d<TUnit> #a;

		// Token: 0x04000C76 RID: 3190
		[CompilerGenerated]
		private readonly UnitSystem #b;

		// Token: 0x04000C77 RID: 3191
		[CompilerGenerated]
		private readonly TUnit #c;

		// Token: 0x04000C78 RID: 3192
		[CompilerGenerated]
		private readonly int #d;

		// Token: 0x04000C79 RID: 3193
		[CompilerGenerated]
		private readonly IUnitValueFormatter #e;

		// Token: 0x04000C7A RID: 3194
		[CompilerGenerated]
		private readonly IUnit #f;
	}
}
