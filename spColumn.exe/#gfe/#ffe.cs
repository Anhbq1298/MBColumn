using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #Cfe;
using #vhe;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.Templates;
using StructurePoint.CoreAssets.Units;

namespace #gfe
{
	// Token: 0x02001051 RID: 4177
	internal static class #ffe
	{
		// Token: 0x06008F54 RID: 36692 RVA: 0x001E7134 File Offset: 0x001E5334
		public static #Fu #bfe<#Fu>(this ICollection<#Fu> #8f, UnitSystem #Qg, DesignCodes #is) where #Fu : #Bfe
		{
			#ffe<#Fu>.#EUd #EUd = new #ffe<!!0>.#EUd();
			if (#8f == null)
			{
				return default(!!0);
			}
			#EUd.#a = #yhe.#xhe(#Qg);
			#EUd.#b = #yhe.#xhe(#is);
			#Fu #Fu = #8f.FirstOrDefault(new Func<!!0, bool>(#EUd.#kaf));
			if (#Fu != null)
			{
				return #Fu;
			}
			#Fu = #8f.FirstOrDefault(new Func<!!0, bool>(#EUd.#laf));
			if (#Fu != null)
			{
				return #Fu;
			}
			return #8f.FirstOrDefault(new Func<!!0, bool>(#EUd.#maf));
		}

		// Token: 0x06008F55 RID: 36693 RVA: 0x001E71B8 File Offset: 0x001E53B8
		public static IList<#Fu> #zjb<#Fu>(this ICollection<#Fu> #8f, UnitSystem #Qg, DesignCodes #is) where #Fu : #Bfe
		{
			#ffe<#Fu>.#naf #naf = new #ffe<!!0>.#naf();
			#naf.#a = #Qg;
			#naf.#b = #is;
			return #8f.Where(new Func<!!0, bool>(#naf.#n6b)).ToList<#Fu>();
		}

		// Token: 0x06008F56 RID: 36694 RVA: 0x001E71F0 File Offset: 0x001E53F0
		public static bool #3gb(this #Bfe #Rf, UnitSystem #Qg, DesignCodes #is)
		{
			UnitSystemSpecs unitSystemSpecs = #yhe.#xhe(#Qg);
			DesignCodeSpecs designCodeSpecs = #yhe.#xhe(#is);
			return #Rf.DesignCodes.HasFlag(designCodeSpecs) && #Rf.UnitSystems.HasFlag(unitSystemSpecs);
		}

		// Token: 0x06008F57 RID: 36695 RVA: 0x00073EC5 File Offset: 0x000720C5
		public static IEnumerable<Enum> #cfe(Enum #1Lb)
		{
			foreach (object obj in Enum.GetValues(#1Lb.GetType()))
			{
				Enum @enum = (Enum)obj;
				if (#1Lb.HasFlag(@enum))
				{
					yield return @enum;
				}
			}
			IEnumerator enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06008F58 RID: 36696 RVA: 0x001E723C File Offset: 0x001E543C
		private static bool #dfe(DesignCodeSpecs #efe, DesignCodeSpecs #luc)
		{
			List<DesignCodeSpecs> list = #ffe.#cfe(#efe).OfType<DesignCodeSpecs>().ToList<DesignCodeSpecs>();
			return list.Count == 1 && list[0] == #luc;
		}

		// Token: 0x06008F59 RID: 36697 RVA: 0x001E7274 File Offset: 0x001E5474
		private static bool #dfe(UnitSystemSpecs #efe, UnitSystemSpecs #luc)
		{
			List<UnitSystemSpecs> list = #ffe.#cfe(#efe).OfType<UnitSystemSpecs>().ToList<UnitSystemSpecs>();
			return list.Count == 1 && list[0] == #luc;
		}

		// Token: 0x02001052 RID: 4178
		[CompilerGenerated]
		private sealed class #EUd<#Fu> where #Fu : #Bfe
		{
			// Token: 0x06008F5B RID: 36699 RVA: 0x00073ED5 File Offset: 0x000720D5
			internal bool #kaf(#Fu #Rf)
			{
				return #ffe.#dfe(#Rf.UnitSystems, this.#a) && #ffe.#dfe(#Rf.DesignCodes, this.#b);
			}

			// Token: 0x06008F5C RID: 36700 RVA: 0x00073F0B File Offset: 0x0007210B
			internal bool #laf(#Fu #Rf)
			{
				return #ffe.#dfe(#Rf.UnitSystems, this.#a) && #Rf.DesignCodes.HasFlag(this.#b);
			}

			// Token: 0x06008F5D RID: 36701 RVA: 0x001E72AC File Offset: 0x001E54AC
			internal bool #maf(#Fu #Rf)
			{
				return #Rf.UnitSystems.HasFlag(this.#a) && #Rf.DesignCodes.HasFlag(this.#b);
			}

			// Token: 0x04003C17 RID: 15383
			public UnitSystemSpecs #a;

			// Token: 0x04003C18 RID: 15384
			public DesignCodeSpecs #b;
		}

		// Token: 0x02001053 RID: 4179
		[CompilerGenerated]
		private sealed class #naf<#Fu> where #Fu : #Bfe
		{
			// Token: 0x06008F5F RID: 36703 RVA: 0x00073F4B File Offset: 0x0007214B
			internal bool #n6b(#Fu #Rf)
			{
				return #Rf.#3gb(this.#a, this.#b);
			}

			// Token: 0x04003C19 RID: 15385
			public UnitSystem #a;

			// Token: 0x04003C1A RID: 15386
			public DesignCodes #b;
		}
	}
}
