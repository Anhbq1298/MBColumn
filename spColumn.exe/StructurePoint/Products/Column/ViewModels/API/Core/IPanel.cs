using System;
using System.Windows.Media;
using #0I;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace StructurePoint.Products.Column.ViewModels.API.Core
{
	// Token: 0x0200013F RID: 319
	internal interface IPanel
	{
		// Token: 0x17000437 RID: 1079
		// (get) Token: 0x06000A5E RID: 2654
		IView ViewObject { get; }

		// Token: 0x17000438 RID: 1080
		// (get) Token: 0x06000A5F RID: 2655
		#5I Form { get; }

		// Token: 0x17000439 RID: 1081
		// (get) Token: 0x06000A60 RID: 2656
		bool HasAnyErrors { get; }

		// Token: 0x1700043A RID: 1082
		// (get) Token: 0x06000A61 RID: 2657
		// (set) Token: 0x06000A62 RID: 2658
		ImageSource Icon { get; set; }

		// Token: 0x1700043B RID: 1083
		// (get) Token: 0x06000A63 RID: 2659
		// (set) Token: 0x06000A64 RID: 2660
		ImageSource Image { get; set; }

		// Token: 0x06000A65 RID: 2661
		void #or();

		// Token: 0x06000A66 RID: 2662
		void #dx();

		// Token: 0x06000A67 RID: 2663
		void #qt();
	}
}
