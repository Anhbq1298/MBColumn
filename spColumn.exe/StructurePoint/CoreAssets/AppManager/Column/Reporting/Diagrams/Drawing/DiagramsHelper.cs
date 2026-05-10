using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #NHe;
using #rCe;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing.Helpers;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.DTO;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing
{
	// Token: 0x0200123A RID: 4666
	public sealed class DiagramsHelper
	{
		// Token: 0x06009C6C RID: 40044 RVA: 0x00212C24 File Offset: 0x00210E24
		public static List<LoadPointTempData> #LFe(IList<LoadPointDrawingData> #yjb, IList<SelectedLoadData> #AEe, int #MFe, float #Tdb, out int #NFe)
		{
			DiagramsHelper.#v0b #v0b = new DiagramsHelper.#v0b();
			#v0b.#a = #AEe;
			#v0b.#c = #Tdb + 0.5f;
			#v0b.#b = #Tdb - 0.5f;
			List<LoadPointTempData> list = #yjb.Select(new Func<LoadPointDrawingData, LoadPointTempData>(#v0b.#aef)).OrderBy(new Func<LoadPointTempData, int>(DiagramsHelper.<>c.<>9.#cef)).ToList<LoadPointTempData>().Where(new Func<LoadPointTempData, bool>(#v0b.#bef)).OrderByDescending(new Func<LoadPointTempData, bool>(DiagramsHelper.<>c.<>9.#def)).ThenBy(new Func<LoadPointTempData, int>(DiagramsHelper.<>c.<>9.#eef)).ToList<LoadPointTempData>();
			#NFe = list.Count;
			return LoadPointTempData.#Qrb(list, #MFe);
		}

		// Token: 0x06009C6D RID: 40045 RVA: 0x00212D04 File Offset: 0x00210F04
		public static List<LoadPointTempData> #OFe(IList<LoadPointDrawingData> #yjb, IList<SelectedLoadData> #AEe, ConsideredAxis #6gb, int #FEe, float #PFe, #0Ie #pNb, out int #QFe)
		{
			DiagramsHelper.#wbc #wbc = new DiagramsHelper.#wbc();
			#wbc.#a = #AEe;
			#wbc.#b = #6gb;
			#wbc.#c = #PFe;
			#wbc.#d = #pNb;
			List<LoadPointTempData> list = #yjb.Select(new Func<LoadPointDrawingData, LoadPointTempData>(#wbc.#jef)).Where(new Func<LoadPointTempData, bool>(#wbc.#kef)).OrderBy(new Func<LoadPointTempData, bool>(DiagramsHelper.<>c.<>9.#fef)).ThenByDescending(new Func<LoadPointTempData, int>(DiagramsHelper.<>c.<>9.#gef)).ToList<LoadPointTempData>();
			#QFe = list.Count;
			return LoadPointTempData.#Qrb(list, #FEe);
		}

		// Token: 0x06009C6E RID: 40046 RVA: 0x00212DB8 File Offset: 0x00210FB8
		public static List<LoadPointTempData> #RFe(IList<LoadPointDrawingData> #yjb, IList<SelectedLoadData> #AEe, ConsideredAxis #Tye, int #FEe, out int #GEe)
		{
			DiagramsHelper.#dZb #dZb = new DiagramsHelper.#dZb();
			#dZb.#a = #AEe;
			#dZb.#b = #Tye;
			List<LoadPointTempData> list = #yjb.Select(new Func<LoadPointDrawingData, LoadPointTempData>(#dZb.#lef)).OrderByDescending(new Func<LoadPointTempData, bool>(DiagramsHelper.<>c.<>9.#hef)).ThenByDescending(new Func<LoadPointTempData, int>(DiagramsHelper.<>c.<>9.#ief)).ToList<LoadPointTempData>();
			#GEe = list.Count;
			return LoadPointTempData.#Qrb(list, #FEe);
		}

		// Token: 0x06009C6F RID: 40047 RVA: 0x0007B794 File Offset: 0x00079994
		public static #uCe #SFe(double #Udb, ConsideredAxis #Tye)
		{
			if (#Tye == ConsideredAxis.X)
			{
				return #uCe.#a;
			}
			if (#Tye == ConsideredAxis.Y)
			{
				return #uCe.#b;
			}
			if (Math.Abs(#Udb) < 0.001)
			{
				return #uCe.#c;
			}
			if (Math.Abs(#Udb - 90.0) < 0.001)
			{
				return #uCe.#d;
			}
			return #uCe.#f;
		}

		// Token: 0x06009C70 RID: 40048 RVA: 0x0007B7D2 File Offset: 0x000799D2
		public static #0Ie #TFe(Diagram2DType #2bb)
		{
			if (#2bb == Diagram2DType.DiagramPMPlus)
			{
				return #0Ie.#b;
			}
			if (#2bb == Diagram2DType.DiagramPMMinus)
			{
				return #0Ie.#c;
			}
			return #0Ie.#a;
		}

		// Token: 0x04004387 RID: 17287
		private const float #a = 0.01f;

		// Token: 0x0200123C RID: 4668
		[CompilerGenerated]
		private sealed class #v0b
		{
			// Token: 0x06009C7C RID: 40060 RVA: 0x0007B7ED File Offset: 0x000799ED
			internal LoadPointTempData #aef(LoadPointDrawingData #Rf)
			{
				return new LoadPointTempData
				{
					Load = #Rf,
					IsSelected = DiagramGeneratorHelper.#WHe(this.#a, #Rf, ConsideredAxis.Both),
					IsInner = #Rf.IsInner,
					IsExactlySelected = DiagramGeneratorHelper.#VHe(this.#a, #Rf)
				};
			}

			// Token: 0x06009C7D RID: 40061 RVA: 0x0007B82C File Offset: 0x00079A2C
			internal bool #bef(LoadPointTempData #Rf)
			{
				return LoadPointsHelper.#nAe((double)#Rf.Load.AxialLoad, (double)this.#b, (double)this.#c);
			}

			// Token: 0x04004390 RID: 17296
			public IList<SelectedLoadData> #a;

			// Token: 0x04004391 RID: 17297
			public float #b;

			// Token: 0x04004392 RID: 17298
			public float #c;
		}

		// Token: 0x0200123D RID: 4669
		[CompilerGenerated]
		private sealed class #wbc
		{
			// Token: 0x06009C7F RID: 40063 RVA: 0x00212E4C File Offset: 0x0021104C
			internal LoadPointTempData #jef(LoadPointDrawingData #ivb)
			{
				return new LoadPointTempData
				{
					Load = #ivb,
					IsSelected = DiagramGeneratorHelper.#WHe(this.#a, #ivb, this.#b),
					IsInner = #ivb.IsInner,
					IsExactlySelected = DiagramGeneratorHelper.#VHe(this.#a, #ivb),
					IsInMiddleOfDiagram = (Math.Abs(#ivb.MomentX) < 0.01f && Math.Abs(#ivb.MomentY) < 0.01f),
					LoadLength = (float)Math.Sqrt(Math.Pow((double)#ivb.MomentX, 2.0) + Math.Pow((double)#ivb.MomentY, 2.0)),
					ValidationData = new #OJe(#ivb, this.#c)
				};
			}

			// Token: 0x06009C80 RID: 40064 RVA: 0x0007B84D File Offset: 0x00079A4D
			internal bool #kef(LoadPointTempData #Rf)
			{
				return #Rf.IsInMiddleOfDiagram || (this.#d != #0Ie.#c && #Rf.ValidationData.#MJe()) || (this.#d != #0Ie.#b && #Rf.ValidationData.#NJe());
			}

			// Token: 0x04004393 RID: 17299
			public IList<SelectedLoadData> #a;

			// Token: 0x04004394 RID: 17300
			public ConsideredAxis #b;

			// Token: 0x04004395 RID: 17301
			public float #c;

			// Token: 0x04004396 RID: 17302
			public #0Ie #d;
		}

		// Token: 0x0200123E RID: 4670
		[CompilerGenerated]
		private sealed class #dZb
		{
			// Token: 0x06009C82 RID: 40066 RVA: 0x00212F14 File Offset: 0x00211114
			internal LoadPointTempData #lef(LoadPointDrawingData #Rf)
			{
				return new LoadPointTempData
				{
					Load = #Rf,
					IsSelected = DiagramGeneratorHelper.#WHe(this.#a, #Rf, this.#b),
					IsInner = #Rf.IsInner,
					IsExactlySelected = DiagramGeneratorHelper.#VHe(this.#a, #Rf)
				};
			}

			// Token: 0x04004397 RID: 17303
			public IList<SelectedLoadData> #a;

			// Token: 0x04004398 RID: 17304
			public ConsideredAxis #b;
		}
	}
}
