using System;
using System.Collections.Generic;
using StructurePoint.CoreAssets.Units;
using StructurePoint.CoreAssets.Units.UnitSets;

namespace #A9d
{
	// Token: 0x02000F98 RID: 3992
	internal interface #H9d : #X9d
	{
		// Token: 0x06008B4E RID: 35662
		#H9d #D9d(IUnit #6jb);

		// Token: 0x06008B4F RID: 35663
		void #E9d(params IUnit[] #F9d);

		// Token: 0x06008B50 RID: 35664
		IUnit #G9d(string #pJd);

		// Token: 0x06008B51 RID: 35665
		IUnit #G9d(Enum #Y7d);

		// Token: 0x170028BE RID: 10430
		// (get) Token: 0x06008B52 RID: 35666
		Type UnitType { get; }

		// Token: 0x170028BF RID: 10431
		// (get) Token: 0x06008B53 RID: 35667
		UnitSystem UnitSystem { get; }

		// Token: 0x170028C0 RID: 10432
		// (get) Token: 0x06008B54 RID: 35668
		IEnumerable<IUnit> Units { get; }
	}
}
