using System;
using System.Runtime.CompilerServices;
using #hZe;
using #y6e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Communication;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #KUe
{
	// Token: 0x020012E4 RID: 4836
	internal abstract class #YUe : #UUe
	{
		// Token: 0x0600A19F RID: 41375 RVA: 0x0007EA4C File Offset: 0x0007CC4C
		protected #YUe(InputModel #hMe, RuntimeModel #iMe, Section #bLb)
		{
			this.InputModel = #hMe;
			this.RuntimeModel = #iMe;
			this.Section = #bLb;
		}

		// Token: 0x17002E6D RID: 11885
		// (get) Token: 0x0600A1A0 RID: 41376 RVA: 0x0007EA69 File Offset: 0x0007CC69
		protected Section Section { get; }

		// Token: 0x17002E6E RID: 11886
		// (get) Token: 0x0600A1A1 RID: 41377 RVA: 0x0007EA71 File Offset: 0x0007CC71
		protected InputModel InputModel { get; }

		// Token: 0x17002E6F RID: 11887
		// (get) Token: 0x0600A1A2 RID: 41378 RVA: 0x0007EA79 File Offset: 0x0007CC79
		protected #c6e DesignReinforcement
		{
			get
			{
				return this.InputModel.DesignReinforcement;
			}
		}

		// Token: 0x17002E70 RID: 11888
		// (get) Token: 0x0600A1A3 RID: 41379 RVA: 0x0007EA86 File Offset: 0x0007CC86
		protected #A0e InvestigateReinforcement
		{
			get
			{
				return this.RuntimeModel.InvestigateReinforcement;
			}
		}

		// Token: 0x17002E71 RID: 11889
		// (get) Token: 0x0600A1A4 RID: 41380 RVA: 0x0007EA93 File Offset: 0x0007CC93
		protected RuntimeModel RuntimeModel { get; }

		// Token: 0x0600A1A5 RID: 41381
		protected abstract int #zUe(float #Udb, ref float #lTe, ref int #PE);

		// Token: 0x0600A1A6 RID: 41382
		protected abstract int #yUe(float #Udb, ref float #lTe, ref int #PE);

		// Token: 0x0600A1A7 RID: 41383 RVA: 0x00228370 File Offset: 0x00226570
		protected static bool #XUe(#C2e #EUe, #C2e #BUe)
		{
			return #EUe.TotalBarArea < #BUe.TotalBarArea || (#EUe.TotalBarArea < #BUe.TotalBarArea + 0.0001f && (#EUe.TotalBarCount < #BUe.TotalBarCount || (#EUe.TotalBarCount == #BUe.TotalBarCount && #EUe.Usf > #BUe.Usf)));
		}

		// Token: 0x0600A1A8 RID: 41384 RVA: 0x002283D4 File Offset: 0x002265D4
		public int #TUe(float #Udb, ref float #lTe, ref int #PE)
		{
			#E6e #E6e = this.InputModel.Options.DesignTarget;
			if (#E6e == #E6e.#b)
			{
				return this.#zUe(#Udb, ref #lTe, ref #PE);
			}
			if (#E6e == #E6e.#a)
			{
				return this.#yUe(#Udb, ref #lTe, ref #PE);
			}
			this.RuntimeModel.MessageBus.#rne(Message.#qn(#M6e.#x, Array.Empty<object>()), null);
			return 0;
		}

		// Token: 0x040046B5 RID: 18101
		[CompilerGenerated]
		private readonly Section #a;

		// Token: 0x040046B6 RID: 18102
		[CompilerGenerated]
		private readonly InputModel #b;

		// Token: 0x040046B7 RID: 18103
		[CompilerGenerated]
		private readonly RuntimeModel #c;
	}
}
