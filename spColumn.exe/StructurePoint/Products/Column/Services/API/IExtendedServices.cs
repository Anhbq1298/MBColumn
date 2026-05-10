using System;
using #hg;
using #qPb;
using #RJb;
using #Xc;

namespace StructurePoint.Products.Column.Services.API
{
	// Token: 0x020002AE RID: 686
	internal interface IExtendedServices : ICoreServices
	{
		// Token: 0x17000834 RID: 2100
		// (get) Token: 0x0600169D RID: 5789
		#Gd Renderer { get; }

		// Token: 0x17000835 RID: 2101
		// (get) Token: 0x0600169E RID: 5790
		#jg ViewportsManager { get; }

		// Token: 0x17000836 RID: 2102
		// (get) Token: 0x0600169F RID: 5791
		#ud DiagramsViewportsManager { get; }

		// Token: 0x17000837 RID: 2103
		// (get) Token: 0x060016A0 RID: 5792
		#dLb EditorContextMenu { get; }

		// Token: 0x17000838 RID: 2104
		// (get) Token: 0x060016A1 RID: 5793
		#AWh LeftPanelErrorsChecker { get; }
	}
}
