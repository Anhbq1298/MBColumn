using System;
using System.Diagnostics.CodeAnalysis;
using StructurePoint.CoreAssets.GUI.Framework.Tools.Selection;

namespace #hLc
{
	// Token: 0x02000BC0 RID: 3008
	[SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces")]
	internal interface #pLc : IEntitiesSelector
	{
		// Token: 0x17001BEA RID: 7146
		// (get) Token: 0x06006270 RID: 25200
		// (set) Token: 0x06006271 RID: 25201
		bool SelectOnlyExistingShapes { get; set; }
	}
}
