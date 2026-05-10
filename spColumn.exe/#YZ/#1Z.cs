using System;
using System.Collections.Generic;
using #EZ;
using FluentValidation.Results;
using StructurePoint.Products.Column.Model.Entities;

namespace #YZ
{
	// Token: 0x02000378 RID: 888
	internal interface #1Z : #FZ<StandardBar>, #HZ
	{
		// Token: 0x17000A42 RID: 2626
		// (get) Token: 0x06001D47 RID: 7495
		// (set) Token: 0x06001D48 RID: 7496
		IEnumerable<StandardBar> TotalBars { get; set; }

		// Token: 0x06001D49 RID: 7497
		ValidationResult #oZ(StandardBar #ty);
	}
}
