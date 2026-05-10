using System;
using #6s;
using #LQc;
using #qr;
using #vW;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.Slenderness.Helpers;
using StructurePoint.Products.Column.Views.API.Slenderness;

namespace StructurePoint.Products.Column.ViewModels.Slenderness.Modules
{
	// Token: 0x02000146 RID: 326
	internal sealed class BeamsPanelFactory : #et
	{
		// Token: 0x06000A7B RID: 2683 RVA: 0x0000DE7A File Offset: 0x0000C07A
		public BeamsPanelFactory(ICoreServices services, #8Sc dialogService, #uW mirroredBeams, #5s beamFactory)
		{
			this.#a = services;
			this.#b = dialogService;
			this.#c = mirroredBeams;
			this.#d = beamFactory;
		}

		// Token: 0x06000A7C RID: 2684 RVA: 0x00098EAC File Offset: 0x000970AC
		public #8s #tr(ModelAxis #sr, #ht #ur)
		{
			Lazy<IBeamsPanelView> #Ee = this.#vr();
			#9s #rr = this.#wr(#sr, #ur);
			return new #pr(#Ee, this.#a, #rr, #sr);
		}

		// Token: 0x06000A7D RID: 2685 RVA: 0x0000DE9F File Offset: 0x0000C09F
		private Lazy<IBeamsPanelView> #vr()
		{
			return new Lazy<IBeamsPanelView>(new Func<IBeamsPanelView>(BeamsPanelFactory.<>c.<>9.#6Vb));
		}

		// Token: 0x06000A7E RID: 2686 RVA: 0x0000DEC9 File Offset: 0x0000C0C9
		private #9s #wr(ModelAxis #sr, #ht #ur)
		{
			return new #3s(this.#a, #sr, this.#b, this.#c, #ur, this.#d, this.#a.WindowLocator);
		}

		// Token: 0x040003C9 RID: 969
		private readonly ICoreServices #a;

		// Token: 0x040003CA RID: 970
		private readonly #8Sc #b;

		// Token: 0x040003CB RID: 971
		private readonly #uW #c;

		// Token: 0x040003CC RID: 972
		private readonly #5s #d;
	}
}
