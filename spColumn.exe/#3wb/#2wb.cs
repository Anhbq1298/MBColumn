using System;
using #9pe;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Storage;
using StructurePoint.CoreAssets.Column.Core.ViewModels.Templates;
using StructurePoint.CoreAssets.Units;

namespace #3wb
{
	// Token: 0x020004B0 RID: 1200
	internal interface #2wb
	{
		// Token: 0x17000ED6 RID: 3798
		// (get) Token: 0x06002C22 RID: 11298
		TemplateRuntimeViewModel RuntimeViewModel { get; }

		// Token: 0x06002C23 RID: 11299
		void #DY(UnitSystem #3r, UnitSystem #4r);

		// Token: 0x06002C24 RID: 11300
		void #Ywb(UnitSystem #3r, UnitSystem #4r, SectionTemplateDefinition #xS, #cqe #Zwb);

		// Token: 0x06002C25 RID: 11301
		void #0wb(bool #8Vh = true);

		// Token: 0x06002C26 RID: 11302
		void #1wb(bool #ag, bool #8Vh = true);
	}
}
