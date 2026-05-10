using System;
using #0I;
using #npe;
using #PI;
using StructurePoint.Products.Column.ViewModels.API.Core;

namespace #6s
{
	// Token: 0x0200016B RID: 363
	internal interface #dt : #5I, #OI, IChangesInfo, #Xpe
	{
		// Token: 0x170004A8 RID: 1192
		// (get) Token: 0x06000B87 RID: 2951
		// (set) Token: 0x06000B88 RID: 2952
		bool AreFactorsUserDefined { get; set; }

		// Token: 0x170004A9 RID: 1193
		// (get) Token: 0x06000B89 RID: 2953
		#Xpe LastValid { get; }

		// Token: 0x06000B8A RID: 2954
		void #or();
	}
}
