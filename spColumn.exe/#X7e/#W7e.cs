using System;
using #12e;
using #7hc;
using #hZe;
using #IWe;
using #wUe;
using #y6e;
using #z5e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;

namespace #X7e
{
	// Token: 0x02001393 RID: 5011
	internal sealed class #W7e : #W8e, #38e
	{
		// Token: 0x0600A792 RID: 42898 RVA: 0x00082365 File Offset: 0x00080565
		public #W7e(#N5e #is) : base(#is)
		{
			if (!#is.IsCodeAci08Plus)
			{
				throw new ArgumentException(#Phc.#3hc(107309774));
			}
			this.#a = #is;
		}

		// Token: 0x0600A793 RID: 42899 RVA: 0x0000C78B File Offset: 0x0000A98B
		public override bool #y7e(bool #uQe, float[] #0Ne)
		{
			return false;
		}

		// Token: 0x0600A794 RID: 42900 RVA: 0x0008238D File Offset: 0x0008058D
		protected override float #z7e(float #2je)
		{
			if (this.#a.Code == #A5e.#i)
			{
				return #2je + 0.003f;
			}
			return base.#z7e(#2je);
		}

		// Token: 0x0600A795 RID: 42901 RVA: 0x000823AC File Offset: 0x000805AC
		public override int #A7e(float #TRe)
		{
			if (#xke.#hke(#TRe) - 1.4f > 0.00049999997f)
			{
				return 8192;
			}
			return 0;
		}

		// Token: 0x0600A796 RID: 42902 RVA: 0x000823C8 File Offset: 0x000805C8
		public override #L6e #B7e(#L6e #PE)
		{
			#PE &= ~#L6e.#f;
			#PE &= ~#L6e.#i;
			return #PE;
		}

		// Token: 0x0600A797 RID: 42903 RVA: 0x000823DA File Offset: 0x000805DA
		public override bool #C7e(float #Tdb, float #IPe, #X3 #Nwb, InputModel #hMe, ref float #D7e, ref int #ri)
		{
			return !#Nwb.CheckSwayAtEndsOnly;
		}

		// Token: 0x0600A798 RID: 42904 RVA: 0x00038482 File Offset: 0x00036682
		public override float #E7e(float #mRe, float[] #eRe, float #gRe)
		{
			return #mRe;
		}

		// Token: 0x0600A799 RID: 42905 RVA: 0x0000C78B File Offset: 0x0000A98B
		public override bool #F7e()
		{
			return false;
		}

		// Token: 0x0600A79A RID: 42906 RVA: 0x00054A40 File Offset: 0x00052C40
		public override bool #G7e(bool #H7e, int #I7e)
		{
			return !#H7e;
		}

		// Token: 0x0600A79B RID: 42907 RVA: 0x000823E5 File Offset: 0x000805E5
		public override #rXe #J7e(#l4e #Kwe, RuntimeModel #iMe)
		{
			return new #LXe(#Kwe, #iMe);
		}

		// Token: 0x0600A79C RID: 42908 RVA: 0x000823EE File Offset: 0x000805EE
		public override NaNullableFloat #K7e(float #L7e, ref FactoredMoment.#wif #M7e)
		{
			if (this.#V7e(#L7e))
			{
				#M7e |= FactoredMoment.#wif.#b;
			}
			return new NaNullableFloat(new float?(#L7e), #Phc.#3hc(107383600));
		}

		// Token: 0x0600A79D RID: 42909 RVA: 0x0000C78B File Offset: 0x0000A98B
		public override bool #N7e(int #O7e, int #P7e, int #Q7e, #Lce[][] #R7e, int #S7e)
		{
			return false;
		}

		// Token: 0x0600A79E RID: 42910 RVA: 0x00082414 File Offset: 0x00080614
		public override NaNullableFloat #T7e(int #Lpb, #Lce #jdd, bool #U7e)
		{
			return NaNullableFloat.#FSd();
		}

		// Token: 0x0600A79F RID: 42911 RVA: 0x0008241B File Offset: 0x0008061B
		public override float #G2(#K2 #Nwb)
		{
			if (this.#a.Code == #A5e.#i)
			{
				return (#Nwb.Eyt + 0.003f) / #Nwb.Eps;
			}
			return base.#G2(#Nwb);
		}

		// Token: 0x0600A7A0 RID: 42912 RVA: 0x00082446 File Offset: 0x00080646
		private bool #V7e(float #TRe)
		{
			return this.#A7e(#TRe) == 8192;
		}

		// Token: 0x04004A39 RID: 19001
		private new readonly #N5e #a;
	}
}
