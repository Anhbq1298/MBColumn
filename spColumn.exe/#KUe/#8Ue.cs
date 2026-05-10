using System;
using #gMe;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Enums;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #KUe
{
	// Token: 0x020012E7 RID: 4839
	internal sealed class #8Ue
	{
		// Token: 0x0600A1B0 RID: 41392 RVA: 0x0007EA9B File Offset: 0x0007CC9B
		public #8Ue(InputModel #hMe, RuntimeModel #iMe, #BNe #YTe, DepthComputation #ZTe, Section #bLb, #ISe #0Te)
		{
			this.#c = #hMe;
			this.#e = #iMe;
			this.#a = #YTe;
			this.#f = #bLb;
			this.#b = #ZTe;
			this.#d = #0Te;
		}

		// Token: 0x17002E72 RID: 11890
		// (get) Token: 0x0600A1B1 RID: 41393 RVA: 0x0007EAD0 File Offset: 0x0007CCD0
		private #UUe EqualTypeTypeDesigner
		{
			get
			{
				if (this.#h == null)
				{
					this.#h = new #SUe(this.#c, this.#e, this.#f);
				}
				return this.#h;
			}
		}

		// Token: 0x17002E73 RID: 11891
		// (get) Token: 0x0600A1B2 RID: 41394 RVA: 0x0007EAFD File Offset: 0x0007CCFD
		private #UUe DifferentTypeTypeDesigner
		{
			get
			{
				if (this.#g == null)
				{
					this.#g = new #JUe(this.#c, this.#e, this.#f);
				}
				return this.#g;
			}
		}

		// Token: 0x17002E74 RID: 11892
		// (get) Token: 0x0600A1B3 RID: 41395 RVA: 0x0007EB2A File Offset: 0x0007CD2A
		private float[] DesignDimensions
		{
			get
			{
				return this.#c.DesignDimensions;
			}
		}

		// Token: 0x0600A1B4 RID: 41396 RVA: 0x002287A4 File Offset: 0x002269A4
		public int #TUe(float #Udb)
		{
			this.#e.InvestigateReinforcement.#mg(this.#c.DesignReinforcement);
			this.#4Ue();
			this.#e.SectionDimensionsForInvestigate[0] = this.DesignDimensions[0] - this.DesignDimensions[4];
			this.#e.SectionDimensionsForInvestigate[1] = this.DesignDimensions[1] - this.DesignDimensions[5];
			int num = 0;
			float num2 = 0f;
			int num3;
			for (;;)
			{
				this.#3Ue();
				this.#a.#bpb(this.#c.Options.SectionType);
				num3 = this.#5Ue(this.#c.Options.ReinforcementType[1]).#TUe(#Udb, ref num2, ref num);
				if (num3 == 1)
				{
					break;
				}
				if (!this.#7Ue())
				{
					goto Block_2;
				}
			}
			return num3;
			Block_2:
			if (#8Ue.#1Ue((#L6e)num))
			{
				this.#d.#tOe();
				this.#b.#fOe();
			}
			return num;
		}

		// Token: 0x0600A1B5 RID: 41397 RVA: 0x00228888 File Offset: 0x00226A88
		private static bool #1Ue(#L6e #2Ue)
		{
			return #2Ue.HasFlag(#L6e.#d) || #2Ue.HasFlag(#L6e.#b) || #2Ue.HasFlag(#L6e.#c) || #2Ue.HasFlag(#L6e.#f) || #2Ue.HasFlag(#L6e.#h) || #2Ue.HasFlag(#L6e.#i);
		}

		// Token: 0x0600A1B6 RID: 41398 RVA: 0x00228910 File Offset: 0x00226B10
		private void #3Ue()
		{
			float[] array = this.#e.SectionDimensionsForInvestigate;
			array[0] += this.DesignDimensions[4];
			array[0] = ((array[0] < this.DesignDimensions[2]) ? array[0] : this.DesignDimensions[2]);
			array[1] += this.DesignDimensions[5];
			array[1] = ((array[1] < this.DesignDimensions[3]) ? array[1] : this.DesignDimensions[3]);
		}

		// Token: 0x0600A1B7 RID: 41399 RVA: 0x0022898C File Offset: 0x00226B8C
		private void #4Ue()
		{
			Options options = this.#c.Options;
			options.ReinforcementType[0] = options.ReinforcementType[1];
			options.ClearCover[0] = options.ClearCover[1];
		}

		// Token: 0x0600A1B8 RID: 41400 RVA: 0x0007EB37 File Offset: 0x0007CD37
		private #UUe #5Ue(ReinforcementType #6Ue)
		{
			if (#6Ue == ReinforcementType.Different)
			{
				return this.DifferentTypeTypeDesigner;
			}
			return this.EqualTypeTypeDesigner;
		}

		// Token: 0x0600A1B9 RID: 41401 RVA: 0x002289C8 File Offset: 0x00226BC8
		private bool #7Ue()
		{
			float[] array = this.#e.SectionDimensionsForInvestigate;
			return array[0] < this.DesignDimensions[2] || (this.#c.Options.SectionType == #G6e.#a && array[1] < this.DesignDimensions[3]);
		}

		// Token: 0x040046B8 RID: 18104
		private readonly #BNe #a;

		// Token: 0x040046B9 RID: 18105
		private readonly DepthComputation #b;

		// Token: 0x040046BA RID: 18106
		private readonly InputModel #c;

		// Token: 0x040046BB RID: 18107
		private readonly #ISe #d;

		// Token: 0x040046BC RID: 18108
		private readonly RuntimeModel #e;

		// Token: 0x040046BD RID: 18109
		private readonly Section #f;

		// Token: 0x040046BE RID: 18110
		private #UUe #g;

		// Token: 0x040046BF RID: 18111
		private #UUe #h;
	}
}
