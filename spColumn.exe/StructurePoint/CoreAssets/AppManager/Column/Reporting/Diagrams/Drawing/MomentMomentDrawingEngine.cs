using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #6re;
using #7hc;
using #NHe;
using #oFe;
using #rCe;
using #UYd;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing.Helpers;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.DTO;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using Svg;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing
{
	// Token: 0x02001244 RID: 4676
	internal sealed class MomentMomentDrawingEngine
	{
		// Token: 0x06009CAA RID: 40106 RVA: 0x00213450 File Offset: 0x00211650
		public MomentMomentDrawingEngine(#zDe data, #XGe builder)
		{
			if (data == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107376321));
			}
			if (builder == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107251540));
			}
			this.#b = data;
			this.#a = builder;
			this.DrawnLoadPoints = new List<LoadPointDrawingData>();
		}

		// Token: 0x17002D57 RID: 11607
		// (get) Token: 0x06009CAB RID: 40107 RVA: 0x0007B9F5 File Offset: 0x00079BF5
		// (set) Token: 0x06009CAC RID: 40108 RVA: 0x0007B9FD File Offset: 0x00079BFD
		public List<LoadPointDrawingData> DrawnLoadPoints { get; private set; }

		// Token: 0x06009CAD RID: 40109 RVA: 0x002134A4 File Offset: 0x002116A4
		public #YFe #8fb(LoadType #GB, #lte #Od, #7De #lEe, IList<SelectedLoadData> #AEe, #5re #ng, #8re #mJ, #ZIe #Lte)
		{
			#X0d.#V0d(#lEe, #Phc.#3hc(107315083), Component.ColumnReporter, #Phc.#3hc(107315098));
			#X0d.#V0d(#GB, #Phc.#3hc(107289954), Component.ColumnReporter, #Phc.#3hc(107315013));
			#X0d.#V0d(#Od, #Phc.#3hc(107399786), Component.ColumnReporter, #Phc.#3hc(107314992));
			List<LoadPointDrawingData> #HEe = DiagramGeneratorHelper.#QHe(#Od, #lEe.TypeOfDrawing, #mJ, #GB, true);
			int #GEe;
			this.#hGe(#GB, #AEe, #HEe, #lEe, #0Ie.#a, #ng, out #GEe);
			#pFe.#6bb(#Od, this.#a, this.DrawnLoadPoints, #ng, this.#b, #lEe, #Lte);
			return new #YFe(this.DrawnLoadPoints, #GEe);
		}

		// Token: 0x06009CAE RID: 40110 RVA: 0x00213554 File Offset: 0x00211754
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void #fGe(#aEe #pEe, #aEe #gEe, bool #gGe)
		{
			if (#pEe == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107282687));
			}
			if (#gEe == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107282617));
			}
			SvgPointCollection #BP = new SvgPointCollection();
			SvgPointCollection #BP2 = new SvgPointCollection();
			if (#gEe.DrawOptions.IsFactoredDiagramDrawn && #gGe)
			{
				this.#iGe(#gEe.BiCurve, #BP2);
				this.#a.#AGe(#BP2);
			}
			if (#gEe.DrawOptions.IsNominalDiagramDrawn)
			{
				this.#iGe(#pEe.BiCurve, #BP);
				this.#a.#BGe(#BP);
			}
		}

		// Token: 0x06009CAF RID: 40111 RVA: 0x002135E4 File Offset: 0x002117E4
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void #rEe(BiCurve #NAe, Color #BR, SvgUnitCollection #GAe)
		{
			SvgPointCollection #BP = new SvgPointCollection();
			this.#iGe(#NAe, #BP);
			this.#a.#rEe(#BP, #BR, #GAe);
		}

		// Token: 0x06009CB0 RID: 40112 RVA: 0x00213610 File Offset: 0x00211810
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void #hGe(LoadType #CEe, IList<SelectedLoadData> #AEe, List<LoadPointDrawingData> #HEe, #7De #lEe, #0Ie #pNb, #5re #ng, out int #NFe)
		{
			float num = (float)Math.Round((double)#lEe.Parameter, 0);
			float num2 = num + 0.5f;
			float num3 = num - 0.5f;
			#NFe = 0;
			if (#CEe == LoadType.Factored || #CEe == LoadType.Service)
			{
				List<LoadPointTempData> list = DiagramsHelper.#LFe(#HEe, #AEe, #ng.MaxDisplayedLoadPoints, num, out #NFe);
				this.DrawnLoadPoints.AddRange(list.Select(new Func<LoadPointTempData, LoadPointDrawingData>(MomentMomentDrawingEngine.<>c.<>9.#vef)));
				list = list.OrderByDescending(new Func<LoadPointTempData, bool>(MomentMomentDrawingEngine.<>c.<>9.#wef)).ThenByDescending(new Func<LoadPointTempData, bool>(MomentMomentDrawingEngine.<>c.<>9.#xef)).ThenByDescending(new Func<LoadPointTempData, int>(MomentMomentDrawingEngine.<>c.<>9.#yef)).ToList<LoadPointTempData>();
				list.Reverse();
				foreach (LoadPointTempData loadPointTempData in list)
				{
					if (LoadPointsHelper.#nAe((double)loadPointTempData.Load.AxialLoad, (double)num3, (double)num2))
					{
						this.#a.#QGe(loadPointTempData.Load.Index, loadPointTempData.Load.MomentX * this.#b.MomentsScalingFactor, loadPointTempData.Load.MomentY * this.#b.AxialLoadScalingFactor, loadPointTempData.IsSelected, loadPointTempData.IsInner);
					}
				}
				foreach (LoadPointTempData loadPointTempData2 in list)
				{
					if (LoadPointsHelper.#nAe((double)loadPointTempData2.Load.AxialLoad, (double)num3, (double)num2) && #lEe.AreLoadLabelsDrawn)
					{
						this.#a.#UGe(loadPointTempData2.Load.Index.ToString(CultureInfo.CurrentCulture), loadPointTempData2.Load.MomentX * this.#b.MomentsScalingFactor, loadPointTempData2.Load.MomentY * this.#b.AxialLoadScalingFactor, SvgLabelPosition.TopRight, loadPointTempData2.IsExactlySelected);
					}
				}
			}
		}

		// Token: 0x06009CB1 RID: 40113 RVA: 0x00213870 File Offset: 0x00211A70
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void #iGe(BiCurve #NAe, SvgPointCollection #BP)
		{
			for (int i = 0; i < #NAe.MomentX.Count<float>(); i++)
			{
				#BP.Add(#NAe.MomentX[i] * this.#b.MomentsScalingFactor);
				#BP.Add(#ZIe.#UIe(#NAe.MomentY[i] * this.#b.AxialLoadScalingFactor, this.#b.DiagramBorderMinY, this.#b.DiagramBorderMaxY));
			}
			#BP.Add(#BP[0]);
			#BP.Add(#BP[1]);
		}

		// Token: 0x040043AD RID: 17325
		private readonly #XGe #a;

		// Token: 0x040043AE RID: 17326
		private readonly #zDe #b;

		// Token: 0x040043AF RID: 17327
		[CompilerGenerated]
		private List<LoadPointDrawingData> #c;
	}
}
