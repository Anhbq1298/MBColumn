using System;
using System.Collections.Generic;
using System.Windows;
using #6re;
using #9Ue;
using #gMe;
using #NHe;
using #rCe;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;

namespace #oFe
{
	// Token: 0x02001235 RID: 4661
	internal static class #pFe
	{
		// Token: 0x06009C4F RID: 40015 RVA: 0x0021229C File Offset: 0x0021049C
		public static void #6bb(#lte #Od, #XGe #tCd, ICollection<LoadPointDrawingData> #yjb, #5re #ng, #zDe #Gfb, #7De #mA, #ZIe #Lte)
		{
			if (!#ng.ShowLoadPoints || !#ng.ShowCapacityRatioPoints)
			{
				return;
			}
			bool flag = #mA.TypeOfDrawing == #uCe.#c || #mA.TypeOfDrawing == #uCe.#d || #mA.TypeOfDrawing == #uCe.#f;
			if (#mA.TypeOfDrawing == #uCe.#e || #mA.TypeOfDrawing == #uCe.#g)
			{
				return;
			}
			bool flag2 = #Od.Input.Options.SectionCapacityMethod == SectionCapacityMethodType.MomentCapacity;
			foreach (LoadPointDrawingData loadPointDrawingData in #yjb)
			{
				if (!flag2 || loadPointDrawingData.Flags == #FVe.#a)
				{
					float num = (float)Math.Sqrt(Math.Pow((double)loadPointDrawingData.MomentX, 2.0) + Math.Pow((double)loadPointDrawingData.MomentY, 2.0));
					Point #Akb = new Point((double)(flag ? num : loadPointDrawingData.MomentX), (double)loadPointDrawingData.AxialLoad);
					CapacityRatioCalculation capacityRatioCalculation = loadPointDrawingData.CapacityRatio;
					if (capacityRatioCalculation != null && capacityRatioCalculation.PhiMn != null && capacityRatioCalculation.PhiPn != null && (!flag2 || capacityRatioCalculation.Flags == #YNe.#a))
					{
						Point point = new Point((double)capacityRatioCalculation.PhiMn.Value, (double)capacityRatioCalculation.PhiPn.Value);
						if (flag && new #OJe(loadPointDrawingData, (float)Math.Round((double)#mA.Parameter, 0)).#NJe())
						{
							#Akb.X *= -1.0;
							point.X *= -1.0;
						}
						#Akb.X *= (double)#Gfb.MomentsScalingFactor;
						point.X *= (double)#Gfb.MomentsScalingFactor;
						#Akb.Y *= (double)#Gfb.AxialLoadScalingFactor;
						point.Y *= (double)#Gfb.AxialLoadScalingFactor;
						if (#Akb.X >= (double)#Gfb.DiagramBorderMinX && #Akb.X <= (double)#Gfb.DiagramBorderMaxX && point.X >= (double)#Gfb.DiagramBorderMinX && point.X <= (double)#Gfb.DiagramBorderMaxX)
						{
							#tCd.#0Ab(#Akb, point, loadPointDrawingData.IsInner ? #Lte.InnerLoadPointStroke : #Lte.OuterLoadPointStroke, #Lte.CapacityPointLineThickness, #nFe.#lFe(loadPointDrawingData.Index));
							#tCd.#zGe(point, loadPointDrawingData.IsInner ? #Lte.InnerLoadPointStroke : #Lte.OuterLoadPointStroke, #Lte.CapacityPointRadius, #nFe.#mFe(loadPointDrawingData.Index));
						}
					}
				}
			}
		}
	}
}
