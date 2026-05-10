using System;
using System.Runtime.CompilerServices;
using #12e;
using #gMe;
using #hZe;
using #X7e;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Communication;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #vYe
{
	// Token: 0x02001310 RID: 4880
	internal abstract class #EYe
	{
		// Token: 0x0600A321 RID: 41761 RVA: 0x0022DA44 File Offset: 0x0022BC44
		protected #EYe(InputModel #hMe, #l4e #Kwe, RuntimeModel #iMe, #3Qe #IXe, CriticalCapacity #XMe, #fNe #xMe, #38e #jMe)
		{
			this.#b = #hMe;
			this.#e = #Kwe;
			this.#f = #iMe;
			this.#c = #IXe;
			this.#a = #xMe;
			this.#g = #jMe;
			this.#d = #XMe;
			this.#h = false;
			this.ShouldOutputPmax = false;
			this.ShouldOutputPmin = false;
		}

		// Token: 0x17002EC6 RID: 11974
		// (get) Token: 0x0600A322 RID: 41762 RVA: 0x0007F7BF File Offset: 0x0007D9BF
		protected #Fce ReductionFactors
		{
			get
			{
				return this.#f.ReductionFactors;
			}
		}

		// Token: 0x17002EC7 RID: 11975
		// (get) Token: 0x0600A323 RID: 41763 RVA: 0x0007F7CC File Offset: 0x0007D9CC
		// (set) Token: 0x0600A324 RID: 41764 RVA: 0x0007F7D4 File Offset: 0x0007D9D4
		private protected bool ShouldOutputPmax { private get; protected set; }

		// Token: 0x17002EC8 RID: 11976
		// (get) Token: 0x0600A325 RID: 41765 RVA: 0x0007F7DD File Offset: 0x0007D9DD
		// (set) Token: 0x0600A326 RID: 41766 RVA: 0x0007F7E5 File Offset: 0x0007D9E5
		private protected bool ShouldOutputPmin { private get; protected set; }

		// Token: 0x17002EC9 RID: 11977
		// (get) Token: 0x0600A327 RID: 41767 RVA: 0x0007F7EE File Offset: 0x0007D9EE
		protected float MaterialPropertiesEyt
		{
			get
			{
				return this.#b.MaterialProperties.Eyt;
			}
		}

		// Token: 0x0600A328 RID: 41768
		public abstract void #sWe();

		// Token: 0x0600A329 RID: 41769 RVA: 0x0007F800 File Offset: 0x0007DA00
		protected #u3e.#zif #CYe(#S0e #WXe)
		{
			if (!#ZLe.#qTe(#WXe.Success, #WXe.UltimateSafeFactor, this.#b.Options.ProblemType, this.#b.DesignToRequiredRatio))
			{
				return #u3e.#zif.#a;
			}
			this.#h = true;
			return #u3e.#zif.#b;
		}

		// Token: 0x0600A32A RID: 41770 RVA: 0x0022DAA4 File Offset: 0x0022BCA4
		protected void #cYe()
		{
			if (this.#h)
			{
				Message # = Message.#qn(#M6e.#h, Array.Empty<object>());
				this.#e.#vzc(#);
				this.#f.MessageBus.#rne(#, null);
			}
		}

		// Token: 0x0600A32B RID: 41771 RVA: 0x0022DAE4 File Offset: 0x0022BCE4
		protected void #DYe()
		{
			if (this.ShouldOutputPmax)
			{
				float value = this.ReductionFactors.#E1e(this.#b, this.#f, this.#g) * this.#f.AxialLoads.Maximum;
				this.#e.Variables.Pmax = new float?(value);
			}
			if (this.ShouldOutputPmin)
			{
				this.#e.Variables.Pmin = new float?(this.#f.AxialLoads.Minimum);
			}
		}

		// Token: 0x04004771 RID: 18289
		protected readonly #fNe #a;

		// Token: 0x04004772 RID: 18290
		protected readonly InputModel #b;

		// Token: 0x04004773 RID: 18291
		protected readonly #3Qe #c;

		// Token: 0x04004774 RID: 18292
		protected readonly CriticalCapacity #d;

		// Token: 0x04004775 RID: 18293
		protected readonly #l4e #e;

		// Token: 0x04004776 RID: 18294
		protected readonly RuntimeModel #f;

		// Token: 0x04004777 RID: 18295
		protected readonly #38e #g;

		// Token: 0x04004778 RID: 18296
		private bool #h;

		// Token: 0x04004779 RID: 18297
		[CompilerGenerated]
		private bool #i;

		// Token: 0x0400477A RID: 18298
		[CompilerGenerated]
		private bool #j;
	}
}
