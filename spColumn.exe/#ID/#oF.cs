using System;
using System.Collections.Generic;
using System.ComponentModel;
using #Eb;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.Products.Column.Model.Entities;

namespace #ID
{
	// Token: 0x02000223 RID: 547
	internal interface #oF : INotifyPropertyChanged, IViewModel<#Db>, IViewModel
	{
		// Token: 0x170006CB RID: 1739
		// (get) Token: 0x060012B2 RID: 4786
		// (set) Token: 0x060012B3 RID: 4787
		bool IsWorking { get; set; }

		// Token: 0x170006CC RID: 1740
		// (get) Token: 0x060012B4 RID: 4788
		List<FactoredLoad> ImportedFactoryLoads { get; }

		// Token: 0x060012B5 RID: 4789
		bool #od();
	}
}
