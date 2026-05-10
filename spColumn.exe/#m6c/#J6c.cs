using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using StructurePoint.CoreAssets.GUI.DesktopControls;

namespace #m6c
{
	// Token: 0x02000CEE RID: 3310
	internal interface #J6c
	{
		// Token: 0x06006C20 RID: 27680
		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
		IList<HelpID> #y6c();

		// Token: 0x06006C21 RID: 27681
		IList<HelpID> #z6c(IEnumerable<Assembly> #S);

		// Token: 0x06006C22 RID: 27682
		string #D6c();

		// Token: 0x06006C23 RID: 27683
		IList<HelpID> #E6c(string #F6c, IEnumerable<HelpID> #G6c);

		// Token: 0x06006C24 RID: 27684
		void #H6c();
	}
}
