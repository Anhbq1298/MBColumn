using System;
using #cMb;
using StructurePoint.Products.Column.Editor.Section.Irregular.Tools.API;
using Telerik.Windows.Data;

namespace #LFb
{
	// Token: 0x02000503 RID: 1283
	internal interface #RFb : #uNb
	{
		// Token: 0x17000F6E RID: 3950
		// (get) Token: 0x06002ECD RID: 11981
		// (set) Token: 0x06002ECE RID: 11982
		CircleToolViewModel SelectedTool { get; set; }

		// Token: 0x17000F6F RID: 3951
		// (get) Token: 0x06002ECF RID: 11983
		RadObservableCollection<CircleToolViewModel> Tools { get; }

		// Token: 0x06002ED0 RID: 11984
		void #cWh();
	}
}
