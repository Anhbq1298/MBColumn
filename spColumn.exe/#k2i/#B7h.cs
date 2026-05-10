using System;
using System.Collections.Generic;
using StructurePoint.Kernel.CoreAssets.Importer.Business;
using StructurePoint.Kernel.CoreAssets.Importer.DataClasses;

namespace #k2i
{
	// Token: 0x02000E78 RID: 3704
	internal interface #B7h : IDisposable
	{
		// Token: 0x170027B0 RID: 10160
		// (get) Token: 0x06008480 RID: 33920
		ProjectType ProjectType { get; }

		// Token: 0x170027B1 RID: 10161
		// (get) Token: 0x06008481 RID: 33921
		UnitsSystem UnitsSystem { get; }

		// Token: 0x170027B2 RID: 10162
		// (get) Token: 0x06008482 RID: 33922
		Dictionary<string, ETABSLoadCase> LoadCases { get; }

		// Token: 0x170027B3 RID: 10163
		// (get) Token: 0x06008483 RID: 33923
		Dictionary<string, ETABSLoadCombination> LoadCombinations { get; }

		// Token: 0x170027B4 RID: 10164
		// (get) Token: 0x06008484 RID: 33924
		List<ETABSStory> Stories { get; }

		// Token: 0x170027B5 RID: 10165
		// (get) Token: 0x06008485 RID: 33925
		List<ETABSFrame> Columns { get; }

		// Token: 0x170027B6 RID: 10166
		// (get) Token: 0x06008486 RID: 33926
		List<ETABSPier> Piers { get; }

		// Token: 0x170027B7 RID: 10167
		// (get) Token: 0x06008487 RID: 33927
		bool SupportsEnvelopes { get; }

		// Token: 0x06008488 RID: 33928
		List<ETABSFactoredLoad> #d7h(string[] #e7h, string[] #wkh, bool #h6h);

		// Token: 0x170027B8 RID: 10168
		// (get) Token: 0x06008489 RID: 33929
		List<ETABSFactoredLoad> ColumnForces_AllSteps { get; }

		// Token: 0x170027B9 RID: 10169
		// (get) Token: 0x0600848A RID: 33930
		List<ETABSFactoredLoad> ColumnForces_Envelopes { get; }

		// Token: 0x0600848B RID: 33931
		List<ETABSFactoredLoad> #q7h(string[] #r7h, string[] #wkh, bool #h6h);

		// Token: 0x170027BA RID: 10170
		// (get) Token: 0x0600848C RID: 33932
		List<ETABSFactoredLoad> PierForces_AllSteps { get; }

		// Token: 0x170027BB RID: 10171
		// (get) Token: 0x0600848D RID: 33933
		List<ETABSFactoredLoad> PierForces_Envelopes { get; }
	}
}
