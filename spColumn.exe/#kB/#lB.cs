using System;
using System.Collections.Generic;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;

namespace #kB
{
	// Token: 0x020001D2 RID: 466
	internal interface #lB
	{
		// Token: 0x1700062B RID: 1579
		// (get) Token: 0x06001055 RID: 4181
		IList<ReporterImage> Screenshots { get; }

		// Token: 0x1700062C RID: 1580
		// (get) Token: 0x06001056 RID: 4182
		List<SolverMessage> SolverMessages { get; }

		// Token: 0x06001057 RID: 4183
		#lte #LA(ColumnStorageModel #Od, bool #MA);

		// Token: 0x06001058 RID: 4184
		#lte #LA(bool #NA, bool #MA = true);

		// Token: 0x06001059 RID: 4185
		GeneralInformation #OA();

		// Token: 0x0600105A RID: 4186
		#lte #1Th(ColumnStorageModel #Od, bool #MA);

		// Token: 0x0600105B RID: 4187
		#lte #1Th(bool #MA);
	}
}
