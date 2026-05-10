using System;
using System.Linq;
using System.Runtime.CompilerServices;
using #12e;
using #7Xe;
using #gMe;
using #hZe;
using #vYe;
using #X7e;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Geometry;

namespace #IWe
{
	// Token: 0x02001305 RID: 4869
	internal sealed class #JXe
	{
		// Token: 0x0600A2C3 RID: 41667 RVA: 0x0022C490 File Offset: 0x0022A690
		public #JXe(#l4e #Kwe, float #Udb, InputModel #hMe, RuntimeModel #iMe, #6Re #uye, #3Qe #IXe, CriticalCapacity #XMe, #fNe #xMe, #nUe #pge, #VPe #SMe, #fMe #wMe, #38e #jMe)
		{
			this.#a = #Kwe;
			this.#b = #jMe;
			this.ServiceResults = this.#HXe(#hMe, #iMe, #IXe, #XMe, #xMe);
			this.FactoredResults = new #wYe(#Kwe, #hMe, #iMe, #IXe, #XMe, #xMe, #jMe);
			this.ControlResults = new #aXe(#Kwe, #hMe, #iMe, #uye, #xMe, #pge, #SMe, #wMe, #jMe);
			this.AxialResults = new #HWe(#Kwe, #Udb, #hMe, #iMe, #uye, #pge, #SMe, #wMe, #jMe);
		}

		// Token: 0x17002EB0 RID: 11952
		// (get) Token: 0x0600A2C4 RID: 41668 RVA: 0x0007F440 File Offset: 0x0007D640
		public #iYe ServiceResults { get; }

		// Token: 0x17002EB1 RID: 11953
		// (get) Token: 0x0600A2C5 RID: 41669 RVA: 0x0007F448 File Offset: 0x0007D648
		public #wYe FactoredResults { get; }

		// Token: 0x17002EB2 RID: 11954
		// (get) Token: 0x0600A2C6 RID: 41670 RVA: 0x0007F450 File Offset: 0x0007D650
		public #aXe ControlResults { get; }

		// Token: 0x17002EB3 RID: 11955
		// (get) Token: 0x0600A2C7 RID: 41671 RVA: 0x0007F458 File Offset: 0x0007D658
		public #HWe AxialResults { get; }

		// Token: 0x0600A2C8 RID: 41672 RVA: 0x0022C514 File Offset: 0x0022A714
		public void #FXe(Figures #BAb, Figures #3Se)
		{
			foreach (Points points in #BAb.SectionFigures)
			{
				this.#a.#k4e(new #Z3e
				{
					Points = points.#y1e().ToList<Point>()
				});
			}
			foreach (Points points2 in #3Se.SectionFigures)
			{
				this.#a.#j4e(new #Z3e
				{
					Points = points2.#y1e().ToList<Point>()
				});
			}
		}

		// Token: 0x0600A2C9 RID: 41673 RVA: 0x0022C5D4 File Offset: 0x0022A7D4
		public void #GXe(#K1e #JQe)
		{
			ReinforcementBar[] array = #JQe.Bars;
			this.#a.#cbi();
			for (int i = 0; i < #JQe.NumberOfBars; i++)
			{
				this.#a.#vzc(new ReinforcementBar(array[i]));
			}
		}

		// Token: 0x0600A2CA RID: 41674 RVA: 0x0022C618 File Offset: 0x0022A818
		private #iYe #HXe(InputModel #hMe, RuntimeModel #iMe, #3Qe #IXe, CriticalCapacity #XMe, #fNe #xMe)
		{
			if (#hMe.Options.ConsideredAxis == #C6e.#c)
			{
				return new #6Xe(this.#a, #hMe, #iMe, #IXe, #XMe, #xMe, this.#b);
			}
			return new #qYe(this.#a, #hMe, #iMe, #IXe, #XMe, #xMe, this.#b);
		}

		// Token: 0x04004751 RID: 18257
		private readonly #l4e #a;

		// Token: 0x04004752 RID: 18258
		private readonly #38e #b;

		// Token: 0x04004753 RID: 18259
		[CompilerGenerated]
		private readonly #iYe #c;

		// Token: 0x04004754 RID: 18260
		[CompilerGenerated]
		private readonly #wYe #d;

		// Token: 0x04004755 RID: 18261
		[CompilerGenerated]
		private readonly #aXe #e;

		// Token: 0x04004756 RID: 18262
		[CompilerGenerated]
		private readonly #HWe #f;
	}
}
