using System;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using Telerik.Windows.Controls;

namespace #Eb
{
	// Token: 0x02000029 RID: 41
	internal interface #Db : IColumnWindow, IView
	{
		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000337 RID: 823
		RadTabItem PreviewTab { get; }

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000338 RID: 824
		RadTabItem ElementsTab { get; }

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000339 RID: 825
		RadTabItem OptionsTab { get; }

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x0600033A RID: 826
		RadTabControl TabControl { get; }
	}
}
