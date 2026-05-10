using System;
using #0I;
using #5Z;
using #9pe;
using #WI;
using StructurePoint.Products.Column.ViewModels.API.Core;
using Telerik.Windows.Controls;

namespace #BF
{
	// Token: 0x0200024D RID: 589
	internal interface #JUh : #VI, #5I, IChangesInfo, #Vai, #hqe
	{
		// Token: 0x17000713 RID: 1811
		// (get) Token: 0x060013B0 RID: 5040
		#K2 MaterialProperties { get; }

		// Token: 0x17000714 RID: 1812
		// (get) Token: 0x060013B1 RID: 5041
		bool IsCsaCode { get; }

		// Token: 0x17000715 RID: 1813
		// (get) Token: 0x060013B2 RID: 5042
		DelegateCommand StandardChangedCommand { get; }

		// Token: 0x060013B3 RID: 5043
		void #or();
	}
}
