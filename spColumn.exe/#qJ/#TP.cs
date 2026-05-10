using System;
using System.Runtime.CompilerServices;
using #3wb;
using #7hc;
using #eU;
using #LQc;
using #qPb;
using #tFb;
using #v1c;
using #Xc;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Model.Entities.Units;
using StructurePoint.Products.Column.Services.API;

namespace #qJ
{
	// Token: 0x020002C7 RID: 711
	internal sealed class #TP : #1V
	{
		// Token: 0x060018BB RID: 6331 RVA: 0x000B71A4 File Offset: 0x000B53A4
		public #TP(#oW #Yc, IEditorService #wj, #vd #mj, #UV #ms, #JFb #sj, ISettingsManager #ng, #R2c #gL, #2wb #UP, #AWh #eTh, #8Sc #ls, #zU #cL, #0V #bL)
		{
			if (#Yc == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107383985));
			}
			this.#a = #Yc;
			if (#wj == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107401352));
			}
			this.#b = #wj;
			this.#c = #mj;
			this.#d = #ms;
			this.#e = #sj;
			this.#f = #ng;
			this.#g = #UP;
			this.#h = #eTh;
			this.#i = #ls;
			this.#j = #cL;
			this.#k = #bL;
			this.#l = #gL;
		}

		// Token: 0x060018BC RID: 6332 RVA: 0x000B723C File Offset: 0x000B543C
		public bool #SP(UnitSystem #Qg)
		{
			#TP.#BUb #BUb = new #TP.#BUb();
			#BUb.#a = this;
			#BUb.#b = #Qg;
			if (this.#h.#wWh(false, true, true))
			{
				string #SSc = this.#i.#5Sc(#Phc.#3hc(107401363).#z2d(), Strings.StringPleaseFixTheErrorsInTheLeftPanel.#z2d());
				this.#i.#qn(this.#i.ActiveWindow, #SSc);
				this.#j.#sO();
				return false;
			}
			this.#l.#M2c();
			this.#b.#0Pb(new Action(#BUb.#r0b));
			this.#d.#yV();
			return true;
		}

		// Token: 0x04000978 RID: 2424
		private readonly #oW #a;

		// Token: 0x04000979 RID: 2425
		private readonly IEditorService #b;

		// Token: 0x0400097A RID: 2426
		private readonly #vd #c;

		// Token: 0x0400097B RID: 2427
		private readonly #UV #d;

		// Token: 0x0400097C RID: 2428
		private readonly #JFb #e;

		// Token: 0x0400097D RID: 2429
		private readonly ISettingsManager #f;

		// Token: 0x0400097E RID: 2430
		private readonly #2wb #g;

		// Token: 0x0400097F RID: 2431
		private readonly #AWh #h;

		// Token: 0x04000980 RID: 2432
		private readonly #8Sc #i;

		// Token: 0x04000981 RID: 2433
		private readonly #zU #j;

		// Token: 0x04000982 RID: 2434
		private readonly #0V #k;

		// Token: 0x04000983 RID: 2435
		private readonly #R2c #l;

		// Token: 0x020002C8 RID: 712
		[CompilerGenerated]
		private sealed class #BUb
		{
			// Token: 0x060018BE RID: 6334 RVA: 0x000B7304 File Offset: 0x000B5504
			internal void #r0b()
			{
				UnitSystemChangeHelper unitSystemChangeHelper = new UnitSystemChangeHelper(this.#a.#a, this.#a.#c, this.#a.#e, this.#a.#f, this.#a.#g, this.#a.#k);
				unitSystemChangeHelper.#DY(this.#b);
			}

			// Token: 0x04000984 RID: 2436
			public #TP #a;

			// Token: 0x04000985 RID: 2437
			public UnitSystem #b;
		}
	}
}
