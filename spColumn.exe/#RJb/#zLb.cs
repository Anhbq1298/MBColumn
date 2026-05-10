using System;
using System.Windows;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.Products.Column.Viewports.API;

namespace #RJb
{
	// Token: 0x02000496 RID: 1174
	internal interface #zLb
	{
		// Token: 0x17000EC4 RID: 3780
		// (get) Token: 0x06002BB7 RID: 11191
		IView PanelView { get; }

		// Token: 0x17000EC5 RID: 3781
		// (get) Token: 0x06002BB8 RID: 11192
		IViewModel PanelViewModel { get; }

		// Token: 0x17000EC6 RID: 3782
		// (get) Token: 0x06002BB9 RID: 11193
		bool IsActive { get; }

		// Token: 0x17000EC7 RID: 3783
		// (get) Token: 0x06002BBA RID: 11194
		string BaseTitle { get; }

		// Token: 0x17000EC8 RID: 3784
		// (get) Token: 0x06002BBB RID: 11195
		Visibility ToolbarVisibility { get; }

		// Token: 0x17000EC9 RID: 3785
		// (get) Token: 0x06002BBC RID: 11196
		// (set) Token: 0x06002BBD RID: 11197
		bool AreLeftPanelPropertiesAvailable { get; set; }

		// Token: 0x06002BBE RID: 11198
		void #5b(#ALb #Pc);

		// Token: 0x06002BBF RID: 11199
		bool #LKb(#ALb #Pc);

		// Token: 0x06002BC0 RID: 11200
		string #7vb(IViewport #fe);

		// Token: 0x06002BC1 RID: 11201
		void #0kb();

		// Token: 0x06002BC2 RID: 11202
		void #OKb();

		// Token: 0x06002BC3 RID: 11203
		void #QKb();
	}
}
