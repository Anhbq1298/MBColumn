using System;
using #6s;
using #BZ;
using #eU;
using #LQc;
using #oKe;
using #qr;
using #vW;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.Slenderness.Helpers;
using StructurePoint.Products.Column.Views.API.Slenderness;

namespace StructurePoint.Products.Column.ViewModels.Slenderness.Modules
{
	// Token: 0x0200014E RID: 334
	internal sealed class DesignColumnPanelFactory : #ft
	{
		// Token: 0x06000A9F RID: 2719 RVA: 0x00098EE4 File Offset: 0x000970E4
		public DesignColumnPanelFactory(ICoreServices services, #8Sc dialogService, #oW projectContext, #AZ validator, #wW mirroredDesignColumns, #nKe localizationService, #uW mirroredBeams, #at columnsAboveBelow)
		{
			this.#c = dialogService;
			this.#a = services;
			this.#d = projectContext;
			this.#b = validator;
			this.#e = mirroredDesignColumns;
			this.#f = localizationService;
			this.#g = mirroredBeams;
			this.#h = columnsAboveBelow;
		}

		// Token: 0x06000AA0 RID: 2720 RVA: 0x00098F34 File Offset: 0x00097134
		public #bt #tr(ModelAxis #sr, #ht #ur)
		{
			Lazy<IDesignColumnPanelView> lazy = this.#vr();
			Lazy<IDesignColumnPanelView> #Ee;
			if (!false)
			{
				#Ee = lazy;
			}
			#ct #rr = this.#wr(#sr, #ur, #Ee);
			return new #xr(#Ee, this.#a, #rr, #sr);
		}

		// Token: 0x06000AA1 RID: 2721 RVA: 0x0000DF91 File Offset: 0x0000C191
		private Lazy<IDesignColumnPanelView> #vr()
		{
			return new Lazy<IDesignColumnPanelView>(new Func<IDesignColumnPanelView>(DesignColumnPanelFactory.<>c.<>9.#7Vb));
		}

		// Token: 0x06000AA2 RID: 2722 RVA: 0x00098F70 File Offset: 0x00097170
		private #ct #wr(ModelAxis #sr, #ht #ur, Lazy<IDesignColumnPanelView> #Ee)
		{
			return new #ks(this.#a, #sr, this.#c, this.#a.MessageBus, this.#d, this.#b, this.#e, this.#f, #ur, this.#g, this.#h, this.#a.WindowLocator, this.#a.MouseAndKeyboard, #Ee);
		}

		// Token: 0x040003D1 RID: 977
		private readonly ICoreServices #a;

		// Token: 0x040003D2 RID: 978
		private readonly #AZ #b;

		// Token: 0x040003D3 RID: 979
		private readonly #8Sc #c;

		// Token: 0x040003D4 RID: 980
		private readonly #oW #d;

		// Token: 0x040003D5 RID: 981
		private readonly #wW #e;

		// Token: 0x040003D6 RID: 982
		private readonly #nKe #f;

		// Token: 0x040003D7 RID: 983
		private readonly #uW #g;

		// Token: 0x040003D8 RID: 984
		private readonly #at #h;
	}
}
