using System;
using System.Runtime.CompilerServices;
using #owe;
using #yEd;
using #Yye;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Pages;

namespace #yze
{
	// Token: 0x020011F3 RID: 4595
	internal sealed class #xze : #AEd
	{
		// Token: 0x06009A36 RID: 39478 RVA: 0x0020CB0C File Offset: 0x0020AD0C
		public #xze(#pwe #zze)
		{
			this.PageContext = #zze;
			base.#vzc(new #Xye(this.PageContext));
			base.#vzc(new #Zye(this.PageContext));
			base.#vzc(new #0ye(this.PageContext));
			base.#vzc(new #3ye(this.PageContext));
			base.#vzc(new #7ye(this.PageContext));
			base.#vzc(new #cze(this.PageContext));
			base.#vzc(new #hze(this.PageContext));
			if (#zze.Options.SolverMessages.#ISd())
			{
				base.#vzc(new #vze(this.PageContext));
			}
			base.#vzc(new #lze(this.PageContext));
			base.#vzc(new ResultsFactoredMomentsPage(this.PageContext));
			base.#vzc(new ControlPointsPage(this.PageContext));
			base.#vzc(new #rze(this.PageContext));
			base.#vzc(new FactoredLoadsAndMomentsWithCorrespondingCapacityRatiosPage(this.PageContext));
			base.#vzc(new ScreenshootsPage(this.PageContext));
		}

		// Token: 0x17002CB9 RID: 11449
		// (get) Token: 0x06009A37 RID: 39479 RVA: 0x0007A270 File Offset: 0x00078470
		public #pwe PageContext { get; }

		// Token: 0x04004237 RID: 16951
		[CompilerGenerated]
		private readonly #pwe #a;
	}
}
