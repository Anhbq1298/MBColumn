using System;
using System.Linq;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #NBe
{
	// Token: 0x02001218 RID: 4632
	internal static class #RBe
	{
		// Token: 0x06009B3A RID: 39738 RVA: 0x0007AC5A File Offset: 0x00078E5A
		public static UniCurve[] #Pb(#dCe[] #OBe)
		{
			Func<#dCe, UniCurve> selector;
			if ((selector = #RBe.#2Ui.#a) == null)
			{
				selector = (#RBe.#2Ui.#a = new Func<#dCe, UniCurve>(#RBe.#Pb));
			}
			return #OBe.Select(selector).ToArray<UniCurve>();
		}

		// Token: 0x06009B3B RID: 39739 RVA: 0x0020FAC0 File Offset: 0x0020DCC0
		public static UniCurve #Pb(#dCe #UAe)
		{
			UniCurveData uniCurveData = new UniCurveData();
			UniCurveData uniCurveData2 = new UniCurveData();
			uniCurveData.Moment = #UAe.#b;
			uniCurveData.DepthOfNeutralAxisC = #UAe.#e;
			uniCurveData.AngleOfNeutralAxisCAngle = #UAe.#g;
			uniCurveData.BarMaximumStrainEps = #UAe.#i;
			uniCurveData.ReductionFactorPhi = #UAe.#k;
			uniCurveData2.Moment = #UAe.#c;
			uniCurveData2.DepthOfNeutralAxisC = #UAe.#f;
			uniCurveData2.AngleOfNeutralAxisCAngle = #UAe.#h;
			uniCurveData2.BarMaximumStrainEps = #UAe.#j;
			uniCurveData2.ReductionFactorPhi = #UAe.#l;
			return new UniCurve
			{
				PositiveSide = uniCurveData,
				NegativeSide = uniCurveData2,
				AxialLoad = #UAe.#a,
				PlotPoint = (#UAe.#d == 1)
			};
		}

		// Token: 0x06009B3C RID: 39740 RVA: 0x0007AC82 File Offset: 0x00078E82
		public static #dCe[] #Pb(UniCurve[] #OBe)
		{
			Func<UniCurve, #dCe> selector;
			if ((selector = #RBe.#2Ui.#b) == null)
			{
				selector = (#RBe.#2Ui.#b = new Func<UniCurve, #dCe>(#RBe.#Pb));
			}
			return #OBe.Select(selector).ToArray<#dCe>();
		}

		// Token: 0x06009B3D RID: 39741 RVA: 0x0020FB80 File Offset: 0x0020DD80
		public static #dCe #Pb(UniCurve #UAe)
		{
			return new #dCe
			{
				#a = #UAe.AxialLoad,
				#b = #UAe.PositiveSide.Moment,
				#c = #UAe.NegativeSide.Moment,
				#e = #UAe.PositiveSide.DepthOfNeutralAxisC,
				#f = #UAe.NegativeSide.DepthOfNeutralAxisC,
				#g = #UAe.PositiveSide.AngleOfNeutralAxisCAngle,
				#h = #UAe.NegativeSide.AngleOfNeutralAxisCAngle,
				#i = #UAe.PositiveSide.BarMaximumStrainEps,
				#j = #UAe.NegativeSide.BarMaximumStrainEps,
				#k = #UAe.PositiveSide.ReductionFactorPhi,
				#l = #UAe.NegativeSide.ReductionFactorPhi,
				#d = (#UAe.PlotPoint ? 1 : 0)
			};
		}

		// Token: 0x06009B3E RID: 39742 RVA: 0x0007ACAA File Offset: 0x00078EAA
		public static BiCurve[] #Pb(#MBe[] #PBe)
		{
			Func<#MBe, BiCurve> selector;
			if ((selector = #RBe.#2Ui.#c) == null)
			{
				selector = (#RBe.#2Ui.#c = new Func<#MBe, BiCurve>(#RBe.#Pb));
			}
			return #PBe.Select(selector).ToArray<BiCurve>();
		}

		// Token: 0x06009B3F RID: 39743 RVA: 0x0020FC6C File Offset: 0x0020DE6C
		public static BiCurve #Pb(#MBe #QBe)
		{
			BiCurve biCurve = new BiCurve();
			biCurve.AxialLoad = #QBe.#a;
			for (int i = 0; i < 36; i++)
			{
				biCurve.MomentX[i] = #QBe.#b[i];
				biCurve.MomentY[i] = #QBe.#c[i];
				biCurve.AngleOfNeutralAxisC[i] = #QBe.#e[i];
				biCurve.DepthOfNeutralAxisC[i] = #QBe.#d[i];
				biCurve.BarMaximumStrainEps[i] = #QBe.#f[i];
				biCurve.Dt[i] = #QBe.#h[i];
				biCurve.PhiFactor[i] = #QBe.#g[i];
			}
			return biCurve;
		}

		// Token: 0x06009B40 RID: 39744 RVA: 0x0007ACD2 File Offset: 0x00078ED2
		public static #MBe[] #Pb(BiCurve[] #PBe)
		{
			Func<BiCurve, #MBe> selector;
			if ((selector = #RBe.#2Ui.#d) == null)
			{
				selector = (#RBe.#2Ui.#d = new Func<BiCurve, #MBe>(#RBe.#Pb));
			}
			return #PBe.Select(selector).ToArray<#MBe>();
		}

		// Token: 0x06009B41 RID: 39745 RVA: 0x0020FD0C File Offset: 0x0020DF0C
		public static #MBe #Pb(BiCurve #QBe)
		{
			#MBe #MBe = default(#MBe);
			#MBe.#b = new float[36];
			#MBe.#c = new float[36];
			#MBe.#e = new float[36];
			#MBe.#d = new float[36];
			#MBe.#f = new float[36];
			#MBe.#h = new float[36];
			#MBe.#g = new float[36];
			#MBe.#a = #QBe.AxialLoad;
			for (int i = 0; i < 36; i++)
			{
				#MBe.#b[i] = #QBe.MomentX[i];
				#MBe.#c[i] = #QBe.MomentY[i];
				#MBe.#e[i] = #QBe.AngleOfNeutralAxisC[i];
				#MBe.#d[i] = #QBe.DepthOfNeutralAxisC[i];
				#MBe.#f[i] = #QBe.BarMaximumStrainEps[i];
				#MBe.#h[i] = #QBe.Dt[i];
				#MBe.#g[i] = #QBe.PhiFactor[i];
			}
			return #MBe;
		}

		// Token: 0x02001219 RID: 4633
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x040042DC RID: 17116
			public static Func<#dCe, UniCurve> #a;

			// Token: 0x040042DD RID: 17117
			public static Func<UniCurve, #dCe> #b;

			// Token: 0x040042DE RID: 17118
			public static Func<#MBe, BiCurve> #c;

			// Token: 0x040042DF RID: 17119
			public static Func<BiCurve, #MBe> #d;
		}
	}
}
