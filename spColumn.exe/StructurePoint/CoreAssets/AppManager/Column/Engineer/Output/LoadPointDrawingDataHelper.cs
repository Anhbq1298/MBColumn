using System;
using System.Linq;
using System.Runtime.CompilerServices;
using #12e;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Enums;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.Output
{
	// Token: 0x020012F5 RID: 4853
	internal static class LoadPointDrawingDataHelper
	{
		// Token: 0x0600A250 RID: 41552 RVA: 0x00229A10 File Offset: 0x00227C10
		public static void #6Ve(InputModel #hMe, #l4e #Kwe)
		{
			LoadPointDrawingDataHelper.#GTb #GTb = new LoadPointDrawingDataHelper.#GTb();
			#GTb.#a = #hMe;
			Load load = #GTb.#a.Options.ActiveLoad;
			if (load != Load.Factored)
			{
				if (load == Load.Service)
				{
					if (#GTb.#a.Options.ConsideredAxis.#hce())
					{
						#Kwe.CapacityData.#pR(#Kwe.BiaxialServiceLoads.Where(new Func<BiaxialServiceLoad, bool>(LoadPointDrawingDataHelper.<>c.<>9.#0hf)).Select(new Func<BiaxialServiceLoad, LoadPointDrawingData>(LoadPointDrawingDataHelper.<>c.<>9.#1hf)));
						goto IL_1BF;
					}
				}
			}
			else
			{
				if (#GTb.#a.Options.ConsideredAxis.#hce())
				{
					#Kwe.CapacityData.#pR(#Kwe.BiaxialFactoredLoads.Where(new Func<BiaxialFactoredLoad, bool>(LoadPointDrawingDataHelper.<>c.<>9.#Yhf)).Select(new Func<BiaxialFactoredLoad, LoadPointDrawingData>(LoadPointDrawingDataHelper.<>c.<>9.#Zhf)));
					goto IL_1BF;
				}
				if (#GTb.#a.Options.ConsideredAxis.#Cpe())
				{
					#Kwe.CapacityData.#pR(#Kwe.UniaxialFactoredLoads.Where(new Func<UniaxialFactoredLoad, bool>(LoadPointDrawingDataHelper.<>c.<>9.#2hf)).Select(new Func<UniaxialFactoredLoad, LoadPointDrawingData>(#GTb.#Whf)));
					goto IL_1BF;
				}
			}
			#Kwe.CapacityData.#pR(#Kwe.UniaxialServiceLoads.Where(new Func<UniaxialServiceLoad, bool>(LoadPointDrawingDataHelper.<>c.<>9.#3hf)).Select(new Func<UniaxialServiceLoad, LoadPointDrawingData>(#GTb.#Xhf)));
			IL_1BF:
			#Kwe.CapacityData.#y3e();
		}

		// Token: 0x020012F7 RID: 4855
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x0600A25A RID: 41562 RVA: 0x0007EFC1 File Offset: 0x0007D1C1
			internal LoadPointDrawingData #Whf(UniaxialFactoredLoad #Rf)
			{
				return new LoadPointDrawingData(#Rf, this.#a.Options.ConsideredAxis);
			}

			// Token: 0x0600A25B RID: 41563 RVA: 0x0007EFD9 File Offset: 0x0007D1D9
			internal LoadPointDrawingData #Xhf(UniaxialServiceLoad #Rf)
			{
				return new LoadPointDrawingData(#Rf, this.#a.Options.ConsideredAxis);
			}

			// Token: 0x04004710 RID: 18192
			public InputModel #a;
		}
	}
}
