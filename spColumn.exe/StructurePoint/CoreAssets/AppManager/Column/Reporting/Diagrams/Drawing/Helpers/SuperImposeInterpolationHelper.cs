using System;
using System.Collections.Generic;
using System.Linq;
using #gMe;
using #hZe;
using #Oze;
using #P6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing.Helpers
{
	// Token: 0x02001261 RID: 4705
	public sealed class SuperImposeInterpolationHelper
	{
		// Token: 0x06009DF8 RID: 40440 RVA: 0x0007C5D6 File Offset: 0x0007A7D6
		public SuperImposeInterpolationHelper(ColumnStorageModel storageModel, #mAe superImposeContext)
		{
			this.#a = storageModel;
			this.#b = superImposeContext.InterpolatedCache.PmCache;
			this.#c = superImposeContext.InterpolatedCache.MmCache;
		}

		// Token: 0x06009DF9 RID: 40441 RVA: 0x00218B48 File Offset: 0x00216D48
		public void #PJe(IEnumerable<SuperImposeDiagram> #QJe, float #Udb)
		{
			foreach (SuperImposeDiagram superImposeDiagram in this.#WJe(#QJe))
			{
				superImposeDiagram.UniCurve = this.#SJe(superImposeDiagram, #Udb);
			}
		}

		// Token: 0x06009DFA RID: 40442 RVA: 0x00218BA0 File Offset: 0x00216DA0
		public void #RJe(IEnumerable<SuperImposeDiagram> #QJe, float #Tdb)
		{
			foreach (SuperImposeDiagram superImposeDiagram in this.#WJe(#QJe))
			{
				superImposeDiagram.BiCurve = this.#TJe(superImposeDiagram, #Tdb);
			}
		}

		// Token: 0x06009DFB RID: 40443 RVA: 0x00218BF8 File Offset: 0x00216DF8
		private UniCurve[] #SJe(SuperImposeDiagram #Jte, float #Udb)
		{
			#aAe #aAe;
			if (this.#b.TryGetValue(#Jte.FilePath, out #aAe) && this.#uC(#aAe.CacheKey, #Udb))
			{
				return #aAe.UniCurve;
			}
			UniCurve[] array = this.#UJe(#Jte, #Udb);
			#aAe value = new #aAe
			{
				CacheKey = #Udb,
				UniCurve = array
			};
			this.#b.Remove(#Jte.FilePath);
			this.#b.Add(#Jte.FilePath, value);
			return array;
		}

		// Token: 0x06009DFC RID: 40444 RVA: 0x00218C74 File Offset: 0x00216E74
		private BiCurve #TJe(SuperImposeDiagram #Jte, float #Tdb)
		{
			#aAe #aAe;
			if (this.#c.TryGetValue(#Jte.FilePath, out #aAe) && this.#uC(#aAe.CacheKey, #Tdb))
			{
				return #aAe.BiCurve;
			}
			BiCurve biCurve = this.#VJe(#Jte, #Tdb);
			#aAe value = new #aAe
			{
				CacheKey = #Tdb,
				BiCurve = biCurve
			};
			this.#c.Remove(#Jte.FilePath);
			this.#c.Add(#Jte.FilePath, value);
			return biCurve;
		}

		// Token: 0x06009DFD RID: 40445 RVA: 0x00218CF0 File Offset: 0x00216EF0
		private UniCurve[] #UJe(SuperImposeDiagram #Jte, float #Udb)
		{
			if (#Jte.BiCurves == null)
			{
				return null;
			}
			#tPe #tPe = this.#XJe();
			#y0e #4Oe = this.#YJe(#Jte);
			return #tPe.#3Oe(#4Oe, #Udb, true);
		}

		// Token: 0x06009DFE RID: 40446 RVA: 0x00218D20 File Offset: 0x00216F20
		private BiCurve #VJe(SuperImposeDiagram #Jte, float #Tdb)
		{
			if (#Jte.BiCurves == null)
			{
				return null;
			}
			#tPe #tPe = this.#XJe();
			#y0e #Jte2 = this.#YJe(#Jte);
			return #tPe.#2Oe(#Jte2, #Tdb);
		}

		// Token: 0x06009DFF RID: 40447 RVA: 0x0007C607 File Offset: 0x0007A807
		private bool #uC(float #5Gb, float #6Gb)
		{
			return Math.Abs(#5Gb - #6Gb) <= 0.01f;
		}

		// Token: 0x06009E00 RID: 40448 RVA: 0x0007C61B File Offset: 0x0007A81B
		private IEnumerable<SuperImposeDiagram> #WJe(IEnumerable<SuperImposeDiagram> #Ic)
		{
			return #Ic.Where(new Func<SuperImposeDiagram, bool>(SuperImposeInterpolationHelper.<>c.<>9.#Xff));
		}

		// Token: 0x06009E01 RID: 40449 RVA: 0x00218D4C File Offset: 0x00216F4C
		private #tPe #XJe()
		{
			DesignEngine designEngine = new DesignEngine(this.#a, new #O6e());
			return new #tPe(designEngine.InputModel, designEngine.RuntimeModel, designEngine.CodeExpert, designEngine.MomentCapacityEx);
		}

		// Token: 0x06009E02 RID: 40450 RVA: 0x0007C642 File Offset: 0x0007A842
		private #y0e #YJe(SuperImposeDiagram #Jte)
		{
			return new #y0e
			{
				BiCurve = #Jte.BiCurves
			};
		}

		// Token: 0x04004456 RID: 17494
		private readonly ColumnStorageModel #a;

		// Token: 0x04004457 RID: 17495
		private readonly Dictionary<string, #aAe> #b;

		// Token: 0x04004458 RID: 17496
		private readonly Dictionary<string, #aAe> #c;
	}
}
