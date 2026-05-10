using System;
using System.Runtime.CompilerServices;
using #04;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Units;

namespace StructurePoint.Products.Column.Model.Entities.Units
{
	// Token: 0x020003BB RID: 955
	internal sealed class UnitValueGroups : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06002090 RID: 8336 RVA: 0x0001FA26 File Offset: 0x0001DC26
		public UnitValueGroups(UnitSystem unitSystem)
		{
			this.#a = this.#26(unitSystem);
			this.#b = this.#36(unitSystem);
			this.#c = this.#46(unitSystem);
			this.#d = this.#56(unitSystem);
		}

		// Token: 0x17000B4A RID: 2890
		// (get) Token: 0x06002091 RID: 8337 RVA: 0x0001FA62 File Offset: 0x0001DC62
		public #Z4 Definitions { get; }

		// Token: 0x17000B4B RID: 2891
		// (get) Token: 0x06002092 RID: 8338 RVA: 0x0001FA6E File Offset: 0x0001DC6E
		public #p6 Slenderness { get; }

		// Token: 0x17000B4C RID: 2892
		// (get) Token: 0x06002093 RID: 8339 RVA: 0x0001FA7A File Offset: 0x0001DC7A
		public #r5 Loads { get; }

		// Token: 0x17000B4D RID: 2893
		// (get) Token: 0x06002094 RID: 8340 RVA: 0x0001FA86 File Offset: 0x0001DC86
		public #M5 Section { get; }

		// Token: 0x06002095 RID: 8341 RVA: 0x0001FA92 File Offset: 0x0001DC92
		private #Z4 #26(UnitSystem #Qg)
		{
			if (#Qg != UnitSystem.SIMetric)
			{
				return #y6.#q6();
			}
			return #y6.#r6();
		}

		// Token: 0x06002096 RID: 8342 RVA: 0x0001FAAF File Offset: 0x0001DCAF
		private #p6 #36(UnitSystem #Qg)
		{
			if (#Qg != UnitSystem.SIMetric)
			{
				return #y6.#s6();
			}
			return #y6.#t6();
		}

		// Token: 0x06002097 RID: 8343 RVA: 0x0001FACC File Offset: 0x0001DCCC
		private #r5 #46(UnitSystem #Qg)
		{
			if (#Qg != UnitSystem.SIMetric)
			{
				return #y6.#u6();
			}
			return #y6.#v6();
		}

		// Token: 0x06002098 RID: 8344 RVA: 0x0001FAE9 File Offset: 0x0001DCE9
		private #M5 #56(UnitSystem #Qg)
		{
			if (#Qg != UnitSystem.SIMetric)
			{
				return #y6.#w6();
			}
			return #y6.#x6();
		}

		// Token: 0x04000D29 RID: 3369
		[CompilerGenerated]
		private readonly #Z4 #a;

		// Token: 0x04000D2A RID: 3370
		[CompilerGenerated]
		private readonly #p6 #b;

		// Token: 0x04000D2B RID: 3371
		[CompilerGenerated]
		private readonly #r5 #c;

		// Token: 0x04000D2C RID: 3372
		[CompilerGenerated]
		private readonly #M5 #d;
	}
}
