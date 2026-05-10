using System;
using #hg;
using #Xc;

namespace StructurePoint.Products.Column.Viewports.API
{
	// Token: 0x020000A8 RID: 168
	internal interface IViewport
	{
		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x06000577 RID: 1399
		object View { get; }

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x06000578 RID: 1400
		// (set) Token: 0x06000579 RID: 1401
		bool IsActive { get; set; }

		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x0600057A RID: 1402
		// (set) Token: 0x0600057B RID: 1403
		#Ke Host { get; set; }

		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x0600057C RID: 1404
		#og ScopeSettings { get; }

		// Token: 0x170002BA RID: 698
		// (get) Token: 0x0600057D RID: 1405
		int AutoIdentifier { get; }

		// Token: 0x170002BB RID: 699
		// (get) Token: 0x0600057E RID: 1406
		// (set) Token: 0x0600057F RID: 1407
		bool MarkedForClosing { get; set; }

		// Token: 0x06000580 RID: 1408
		void #Ud();
	}
}
