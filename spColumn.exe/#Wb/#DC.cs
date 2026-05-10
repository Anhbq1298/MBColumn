using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #9pe;
using #o1d;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.Kernel.CoreAssets.Importer.DataClasses;

namespace #WB
{
	// Token: 0x020001F3 RID: 499
	internal sealed class #DC
	{
		// Token: 0x0600111F RID: 4383 RVA: 0x000A7F24 File Offset: 0x000A6124
		public static bool #8B<#Fu>(IList<#Fu> #Ic, Func<#Fu, bool> #9B, Func<#Fu, #Fu, bool> #aC)
		{
			IEnumerable<#Fu> first = #DC.#cC<#Fu>(#Ic, #9B);
			IEnumerable<#Fu> second = #DC.#dC<#Fu>(#Ic, #aC);
			return first.Concat(second).Any<#Fu>();
		}

		// Token: 0x06001120 RID: 4384 RVA: 0x000A7F5C File Offset: 0x000A615C
		public static HashSet<#Fu> #bC<#Fu>(IList<#Fu> #Ic, Func<#Fu, bool> #9B, Func<#Fu, #Fu, bool> #aC)
		{
			HashSet<#Fu> hashSet = new HashSet<!!0>();
			IEnumerable<#Fu> #8f = #DC.#dC<#Fu>(#Ic, #aC);
			IEnumerable<#Fu> #8f2 = #DC.#cC<#Fu>(#Ic, #9B);
			hashSet.#pR(#8f2);
			hashSet.#pR(#8f);
			return hashSet;
		}

		// Token: 0x06001121 RID: 4385 RVA: 0x000132D4 File Offset: 0x000114D4
		public static IEnumerable<#Fu> #cC<#Fu>(IList<#Fu> #Ic, Func<#Fu, bool> #9B)
		{
			return #Ic.Where(#9B);
		}

		// Token: 0x06001122 RID: 4386 RVA: 0x000132E9 File Offset: 0x000114E9
		public static IEnumerable<#Fu> #dC<#Fu>(IList<#Fu> #Ic, Func<#Fu, #Fu, bool> #aC)
		{
			return #DC.#zC<#Fu>(#Ic, #aC);
		}

		// Token: 0x06001123 RID: 4387 RVA: 0x000A7F9C File Offset: 0x000A619C
		internal static bool #eC(ETABSFactoredLoad #fC)
		{
			double num = Math.Abs(#fC.P) + Math.Abs(#fC.Mx) + Math.Abs(#fC.My);
			return num <= 0.0010000000474974513;
		}

		// Token: 0x06001124 RID: 4388 RVA: 0x000A7FE8 File Offset: 0x000A61E8
		public static bool #eC(#dqe #fC)
		{
			float num = Math.Abs(#fC.AxialLoad) + Math.Abs(#fC.MomentX) + Math.Abs(#fC.MomentY);
			return num <= 0.001f;
		}

		// Token: 0x06001125 RID: 4389 RVA: 0x000A8030 File Offset: 0x000A6230
		public static bool #gC(#8pe #fC)
		{
			float num = Math.Abs(#fC.InitialLoad) + Math.Abs(#fC.FinalLoad) + Math.Abs(#fC.Increment);
			return num <= 0.001f;
		}

		// Token: 0x06001126 RID: 4390 RVA: 0x000A8078 File Offset: 0x000A6278
		public static bool #hC(#pqe #iC)
		{
			return #DC.#sC(#iC.Dead) && #DC.#sC(#iC.Live) && #DC.#sC(#iC.Snow) && #DC.#sC(#iC.Wind) && #DC.#sC(#iC.Earthquake);
		}

		// Token: 0x06001127 RID: 4391 RVA: 0x000A80D4 File Offset: 0x000A62D4
		internal static bool #jC(ETABSFactoredLoad #kC, ETABSFactoredLoad #lC)
		{
			return Math.Abs(#kC.P - #lC.P) <= 0.0010000000474974513 && Math.Abs(#kC.Mx - #lC.Mx) <= 0.0010000000474974513 && Math.Abs(#kC.My - #lC.My) <= 0.0010000000474974513;
		}

		// Token: 0x06001128 RID: 4392 RVA: 0x000A814C File Offset: 0x000A634C
		public static bool #jC(#dqe #kC, #dqe #lC)
		{
			return Math.Abs(#kC.AxialLoad - #lC.AxialLoad) <= 0.001f && Math.Abs(#kC.MomentX - #lC.MomentX) <= 0.001f && Math.Abs(#kC.MomentY - #lC.MomentY) <= 0.001f;
		}

		// Token: 0x06001129 RID: 4393 RVA: 0x000A81B8 File Offset: 0x000A63B8
		public static bool #mC(#8pe #nC, #8pe #oC)
		{
			return Math.Abs(#nC.InitialLoad - #oC.InitialLoad) <= 0.001f && Math.Abs(#nC.FinalLoad - #oC.FinalLoad) <= 0.001f && Math.Abs(#nC.Increment - #oC.Increment) <= 0.001f;
		}

		// Token: 0x0600112A RID: 4394 RVA: 0x000132FE File Offset: 0x000114FE
		public static bool #pC(#pqe #qC, #pqe #rC)
		{
			return #DC.#uC(#qC, #rC);
		}

		// Token: 0x0600112B RID: 4395 RVA: 0x000A8224 File Offset: 0x000A6424
		public static int #UTi(ColumnStorageModel #Od)
		{
			if (#Od.Options.ActiveLoad == LoadType.Factored)
			{
				IList<FactoredLoad> factoredLoads = #Od.FactoredLoads;
				Func<FactoredLoad, bool> #9B;
				if ((#9B = #DC.#2Ui.#a) == null)
				{
					#9B = (#DC.#2Ui.#a = new Func<FactoredLoad, bool>(#DC.#eC));
				}
				Func<FactoredLoad, FactoredLoad, bool> #aC;
				if ((#aC = #DC.#2Ui.#b) == null)
				{
					#aC = (#DC.#2Ui.#b = new Func<FactoredLoad, FactoredLoad, bool>(#DC.#jC));
				}
				HashSet<FactoredLoad> hashSet = #DC.#bC<FactoredLoad>(factoredLoads, #9B, #aC);
				#Od.FactoredLoads.#71d(hashSet);
				return hashSet.Count;
			}
			if (#Od.Options.ActiveLoad == LoadType.Axial)
			{
				IList<AxialLoad> axialLoads = #Od.AxialLoads;
				Func<AxialLoad, bool> #9B2;
				if ((#9B2 = #DC.#2Ui.#c) == null)
				{
					#9B2 = (#DC.#2Ui.#c = new Func<AxialLoad, bool>(#DC.#gC));
				}
				Func<AxialLoad, AxialLoad, bool> #aC2;
				if ((#aC2 = #DC.#2Ui.#d) == null)
				{
					#aC2 = (#DC.#2Ui.#d = new Func<AxialLoad, AxialLoad, bool>(#DC.#mC));
				}
				HashSet<AxialLoad> hashSet2 = #DC.#bC<AxialLoad>(axialLoads, #9B2, #aC2);
				#Od.AxialLoads.#71d(hashSet2);
				return hashSet2.Count;
			}
			if (#Od.Options.ActiveLoad == LoadType.Service)
			{
				IList<ServiceLoad> serviceLoads = #Od.ServiceLoads;
				Func<ServiceLoad, bool> #9B3;
				if ((#9B3 = #DC.#2Ui.#e) == null)
				{
					#9B3 = (#DC.#2Ui.#e = new Func<ServiceLoad, bool>(#DC.#hC));
				}
				Func<ServiceLoad, ServiceLoad, bool> #aC3;
				if ((#aC3 = #DC.#2Ui.#f) == null)
				{
					#aC3 = (#DC.#2Ui.#f = new Func<ServiceLoad, ServiceLoad, bool>(#DC.#pC));
				}
				HashSet<ServiceLoad> hashSet3 = #DC.#bC<ServiceLoad>(serviceLoads, #9B3, #aC3);
				#Od.ServiceLoads.#F7c(hashSet3);
				return hashSet3.Count;
			}
			return 0;
		}

		// Token: 0x0600112C RID: 4396 RVA: 0x000A8378 File Offset: 0x000A6578
		private static bool #sC(#qqe #tC)
		{
			float num = Math.Abs(#tC.MomentYTop) + Math.Abs(#tC.MomentXTop) + Math.Abs(#tC.MomentYBottom) + Math.Abs(#tC.MomentXBottom) + Math.Abs(#tC.AxialLoad);
			return num <= 0.001f;
		}

		// Token: 0x0600112D RID: 4397 RVA: 0x000A83D8 File Offset: 0x000A65D8
		private static bool #uC(#pqe #vC, #pqe #wC)
		{
			return #DC.#uC(#vC.Dead, #wC.Dead) && #DC.#uC(#vC.Live, #wC.Live) && #DC.#uC(#vC.Snow, #wC.Snow) && #DC.#uC(#vC.Wind, #wC.Wind) && #DC.#uC(#vC.Earthquake, #wC.Earthquake);
		}

		// Token: 0x0600112E RID: 4398 RVA: 0x000A8450 File Offset: 0x000A6650
		private static bool #uC(#qqe #xC, #qqe #yC)
		{
			return Math.Abs(#xC.AxialLoad - #yC.AxialLoad) <= 0.001f && Math.Abs(#xC.MomentXTop - #yC.MomentXTop) <= 0.001f && Math.Abs(#xC.MomentXBottom - #yC.MomentXBottom) <= 0.001f && Math.Abs(#xC.MomentYTop - #yC.MomentYTop) <= 0.001f && Math.Abs(#xC.MomentYBottom - #yC.MomentYBottom) <= 0.001f;
		}

		// Token: 0x0600112F RID: 4399 RVA: 0x00013313 File Offset: 0x00011513
		private static IEnumerable<#Fu> #zC<#Fu>(IList<#Fu> #Ic, Func<#Fu, #Fu, bool> #AC)
		{
			#DC<!!0>.#uVi #uVi = new #DC<!!0>.#uVi(-2);
			#uVi.#e = #Ic;
			#uVi.#g = #AC;
			return #uVi;
		}

		// Token: 0x06001130 RID: 4400 RVA: 0x000A8500 File Offset: 0x000A6700
		private static bool #BC<#Fu>(IEnumerable<#Fu> #Ic, #Fu #CC, Func<#Fu, #Fu, bool> #AC)
		{
			#DC<#Fu>.#tVi #tVi = new #DC<!!0>.#tVi();
			#DC<#Fu>.#tVi #tVi2;
			if (!false)
			{
				#tVi2 = #tVi;
			}
			#tVi2.#a = #AC;
			#tVi2.#b = #CC;
			return !#Ic.Any(new Func<!!0, bool>(#tVi2.#QXb));
		}

		// Token: 0x040006BC RID: 1724
		public const float #a = 0.001f;

		// Token: 0x040006BD RID: 1725
		public const int #b = 3;

		// Token: 0x020001F4 RID: 500
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x040006BE RID: 1726
			public static Func<FactoredLoad, bool> #a;

			// Token: 0x040006BF RID: 1727
			public static Func<FactoredLoad, FactoredLoad, bool> #b;

			// Token: 0x040006C0 RID: 1728
			public static Func<AxialLoad, bool> #c;

			// Token: 0x040006C1 RID: 1729
			public static Func<AxialLoad, AxialLoad, bool> #d;

			// Token: 0x040006C2 RID: 1730
			public static Func<ServiceLoad, bool> #e;

			// Token: 0x040006C3 RID: 1731
			public static Func<ServiceLoad, ServiceLoad, bool> #f;
		}

		// Token: 0x020001F5 RID: 501
		[CompilerGenerated]
		private sealed class #tVi<#Fu>
		{
			// Token: 0x06001133 RID: 4403 RVA: 0x0001332A File Offset: 0x0001152A
			internal bool #QXb(#Fu #Rf)
			{
				return this.#a(#Rf, this.#b);
			}

			// Token: 0x040006C4 RID: 1732
			public Func<#Fu, #Fu, bool> #a;

			// Token: 0x040006C5 RID: 1733
			public #Fu #b;
		}
	}
}
