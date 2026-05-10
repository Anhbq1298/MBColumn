using System;
using #0I;
using #5Z;
using #9pe;
using #WI;
using StructurePoint.Products.Column.ViewModels.API.Core;
using Telerik.Windows.Controls;

namespace #BF
{
	// Token: 0x0200026F RID: 623
	internal interface #MUh : #VI, #5I, IChangesInfo, #Uai, #iqe
	{
		// Token: 0x1700073F RID: 1855
		// (get) Token: 0x06001455 RID: 5205
		#K2 MaterialProperties { get; }

		// Token: 0x17000740 RID: 1856
		// (get) Token: 0x06001456 RID: 5206
		bool IsCsaCode { get; }

		// Token: 0x17000741 RID: 1857
		// (get) Token: 0x06001457 RID: 5207
		bool IsPrecastVisible { get; }

		// Token: 0x17000742 RID: 1858
		// (get) Token: 0x06001458 RID: 5208
		DelegateCommand StandardChangedCommand { get; }

		// Token: 0x06001459 RID: 5209
		void #or();
	}
}
