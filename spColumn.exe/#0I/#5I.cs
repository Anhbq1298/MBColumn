using System;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.Products.Column.Model;

namespace #0I
{
	// Token: 0x020000C8 RID: 200
	internal interface #5I
	{
		// Token: 0x170002EE RID: 750
		// (get) Token: 0x0600063F RID: 1599
		bool HasErrors { get; }

		// Token: 0x06000640 RID: 1600
		void #cD(IView #Ee);

		// Token: 0x06000641 RID: 1601
		void UpdateFromModel(ColumnModel model);

		// Token: 0x06000642 RID: 1602
		void UpdateModel(ColumnModel model);

		// Token: 0x06000643 RID: 1603
		bool #jG();

		// Token: 0x06000644 RID: 1604
		void #2I();

		// Token: 0x06000645 RID: 1605
		void AddError(string propertyName, string error);

		// Token: 0x06000646 RID: 1606
		void #4I(string #em);
	}
}
