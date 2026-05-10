using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #12e;
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
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using Svg;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing
{
	// Token: 0x02001230 RID: 4656
	internal sealed class AxialLoadMomentDrawingEngine
	{
		// Token: 0x06009C1A RID: 39962 RVA: 0x0007B4B3 File Offset: 0x000796B3
		public AxialLoadMomentDrawingEngine(#zDe data, #XGe builder)
		{
			#X0d.#V0d(data, #Phc.#3hc(107376321), Component.ColumnReporter, #Phc.#3hc(107283252));
			this.DrawnLoadPoints = new List<LoadPointDrawingData>();
			this.#c = data;
			this.#b = builder;
		}

		// Token: 0x17002D4C RID: 11596
		// (get) Token: 0x06009C1B RID: 39963 RVA: 0x0007B4F0 File Offset: 0x000796F0
		// (set) Token: 0x06009C1C RID: 39964 RVA: 0x0007B4F8 File Offset: 0x000796F8
		public List<LoadPointDrawingData> DrawnLoadPoints { get; private set; }

		// Token: 0x06009C1D RID: 39965 RVA: 0x00210AB8 File Offset: 0x0020ECB8
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void #oEe(#dEe #pEe, #dEe #gEe, float #qEe)
		{
			#X0d.#V0d(#pEe, #Phc.#3hc(107282687), Component.ColumnReporter, #Phc.#3hc(107282638));
			#X0d.#V0d(#gEe, #Phc.#3hc(107282617), Component.ColumnReporter, #Phc.#3hc(107282564));
			float num = #gEe.UniCurve.Max(new Func<UniCurve, float>(AxialLoadMomentDrawingEngine.<>c.<>9.#Mdf));
			float #QEe = #qEe * num;
			#0Ie #pNb = #gEe.DrawOptions.CurrentUniCurveDrawingMode;
			if (#gEe.DrawOptions.IsFactoredDiagramDrawn)
			{
				SvgPointCollection svgPointCollection = new SvgPointCollection();
				SvgPointCollection svgPointCollection2 = new SvgPointCollection();
				SvgPointCollection svgPointCollection3 = new SvgPointCollection();
				SvgPointCollection svgPointCollection4 = new SvgPointCollection();
				this.#NEe(#gEe.UniCurve, svgPointCollection, svgPointCollection3, #QEe, true, #pNb);
				this.#NEe(#gEe.UniCurve, svgPointCollection2, svgPointCollection4, #QEe, false, #pNb);
				this.#5Ee(svgPointCollection, svgPointCollection2, svgPointCollection3, svgPointCollection4, #gEe.DrawOptions.IsDiagramTopDrawn);
			}
			if (#gEe.DrawOptions.IsNominalDiagramDrawn)
			{
				SvgPointCollection svgPointCollection5 = new SvgPointCollection();
				SvgPointCollection svgPointCollection6 = new SvgPointCollection();
				this.#KEe(#pEe.UniCurve, svgPointCollection5, true, #pNb);
				this.#KEe(#pEe.UniCurve, svgPointCollection6, false, #pNb);
				this.#2Ee(svgPointCollection5, svgPointCollection6);
			}
		}

		// Token: 0x06009C1E RID: 39966 RVA: 0x00210BE4 File Offset: 0x0020EDE4
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void #rEe(UniCurve[] #NAe, Diagram2DType #2bb, Color #BR, SvgUnitCollection #GAe)
		{
			bool flag = #2bb == Diagram2DType.DiagramPM || #2bb == Diagram2DType.DiagramPMPlus;
			bool flag2 = #2bb == Diagram2DType.DiagramPM || #2bb == Diagram2DType.DiagramPMMinus;
			bool flag3;
			if (flag)
			{
				flag3 = #NAe.Any(new Func<UniCurve, bool>(AxialLoadMomentDrawingEngine.<>c.<>9.#Ndf));
			}
			else
			{
				flag3 = false;
			}
			bool flag4 = flag3;
			bool flag5;
			if (flag2)
			{
				flag5 = #NAe.Any(new Func<UniCurve, bool>(AxialLoadMomentDrawingEngine.<>c.<>9.#Odf));
			}
			else
			{
				flag5 = false;
			}
			bool flag6 = flag5;
			if (!flag4 && !flag6)
			{
				return;
			}
			#0Ie #pNb;
			if (flag4 && flag6)
			{
				#pNb = #0Ie.#a;
			}
			else if (flag4)
			{
				#pNb = #0Ie.#b;
			}
			else
			{
				#pNb = #0Ie.#c;
			}
			SvgPointCollection svgPointCollection = new SvgPointCollection();
			SvgPointCollection svgPointCollection2 = new SvgPointCollection();
			if (flag4)
			{
				this.#KEe(#NAe, svgPointCollection, true, #pNb);
			}
			if (flag6)
			{
				this.#KEe(#NAe, svgPointCollection2, false, #pNb);
			}
			this.#b.#rEe(svgPointCollection, #BR, #GAe);
			this.#b.#rEe(svgPointCollection2, #BR, #GAe);
		}

		// Token: 0x06009C1F RID: 39967 RVA: 0x00210CC4 File Offset: 0x0020EEC4
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void #sEe(UniCurve[] #gEe, float #qEe, #0Ie #pNb, bool #tEe, bool #uEe)
		{
			#X0d.#V0d(#gEe, #Phc.#3hc(107282617), Component.ColumnReporter, #Phc.#3hc(107282511));
			string #bFe = string.Empty.#t2d() + Strings.StringAxialLoadSymbol + Strings.StringMax.#s2d();
			string #bFe2 = string.Empty.#t2d() + Strings.StringAxialLoadSymbol + Strings.StringMin.#s2d();
			float num = #gEe.Max(new Func<UniCurve, float>(AxialLoadMomentDrawingEngine.<>c.<>9.#Pdf));
			float #aFe = #gEe.Min(new Func<UniCurve, float>(AxialLoadMomentDrawingEngine.<>c.<>9.#Qdf));
			if (#tEe)
			{
				this.#9Ee(num, #bFe, #pNb, #uEe, true);
			}
			this.#9Ee(#aFe, #bFe2, #pNb, #uEe, false);
			this.#cFe(#gEe, #qEe, num, #pNb);
		}

		// Token: 0x06009C20 RID: 39968 RVA: 0x00210DA0 File Offset: 0x0020EFA0
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public void #vEe(#J3e #wEe, #J3e #xEe, #0Ie #pNb, bool #yEe, bool #zEe)
		{
			#X0d.#V0d(#wEe, #Phc.#3hc(107282490), Component.ColumnReporter, #Phc.#3hc(107282433));
			string #oT = Strings.StringTensileStressInReinforcementSymbol.#C2d() + #Phc.#3hc(107286907) + Strings.StringSteelStrengthSymbol;
			string #oT2 = Strings.StringTensileStressInReinforcementSymbol.#C2d() + #Phc.#3hc(107426661);
			if (#pNb != #0Ie.#c)
			{
				if (#yEe)
				{
					if (#pNb == #0Ie.#a || (#pNb == #0Ie.#b && #wEe.PosHalfFy.Moment > 0f))
					{
						this.#jFe(#oT, #wEe.PosHalfFy, true, true);
					}
					if (#pNb == #0Ie.#a || (#pNb == #0Ie.#b && #wEe.PosZeroFy.Moment > 0f))
					{
						this.#jFe(#oT2, #wEe.PosZeroFy, true, true);
					}
				}
				if (#zEe)
				{
					if (#pNb == #0Ie.#a || (#pNb == #0Ie.#b && #xEe.PosHalfFy.Moment > 0f))
					{
						this.#jFe(#oT, #xEe.PosHalfFy, true, false);
					}
					if (#pNb == #0Ie.#a || (#pNb == #0Ie.#b && #xEe.PosZeroFy.Moment > 0f))
					{
						this.#jFe(#oT2, #xEe.PosZeroFy, true, false);
					}
				}
			}
			if (#pNb != #0Ie.#b)
			{
				if (#yEe)
				{
					if (#pNb == #0Ie.#a || (#pNb == #0Ie.#c && #wEe.NegHalfFy.Moment > 0f))
					{
						this.#jFe(#oT, #wEe.NegHalfFy, false, true);
					}
					if (#pNb == #0Ie.#a || (#pNb == #0Ie.#c && #wEe.NegZeroFy.Moment > 0f))
					{
						this.#jFe(#oT2, #wEe.NegZeroFy, false, true);
					}
				}
				if (#zEe)
				{
					if (#pNb == #0Ie.#a || (#pNb == #0Ie.#c && #xEe.NegHalfFy.Moment > 0f))
					{
						this.#jFe(#oT, #xEe.NegHalfFy, false, false);
					}
					if (#pNb == #0Ie.#a || (#pNb == #0Ie.#c && #xEe.NegZeroFy.Moment > 0f))
					{
						this.#jFe(#oT2, #xEe.NegZeroFy, false, false);
					}
				}
			}
		}

		// Token: 0x06009C21 RID: 39969 RVA: 0x00210FA0 File Offset: 0x0020F1A0
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public #YFe #8fb(LoadType #GB, #lte #Od, #7De #lEe, IList<SelectedLoadData> #AEe, #5re #ng, #8re #mJ, #ZIe #Lte)
		{
			List<LoadPointDrawingData> list = DiagramGeneratorHelper.#QHe(#Od, #lEe.TypeOfDrawing, #mJ, #GB, true);
			switch (#lEe.TypeOfDrawing)
			{
			case #uCe.#a:
			case #uCe.#b:
			{
				int #GEe;
				this.#BEe(#GB, #AEe, list, #lEe.Parameter, #Od.Input.Options.ConsideredAxis, #lEe.CurrentUniCurveDrawingMode, #lEe.AreLoadLabelsDrawn, #ng.MaxDisplayedLoadPoints, out #GEe);
				#pFe.#6bb(#Od, this.#b, this.DrawnLoadPoints, #ng, this.#c, #lEe, #Lte);
				return new #YFe(this.DrawnLoadPoints, #GEe);
			}
			case #uCe.#c:
			case #uCe.#d:
			case #uCe.#f:
			{
				int #GEe;
				this.#BEe(#GB, #Od.Input.Options.ConsideredAxis, #lEe.CurrentUniCurveDrawingMode, #AEe, list, #lEe, #ng.MaxDisplayedLoadPoints, out #GEe);
				#pFe.#6bb(#Od, this.#b, this.DrawnLoadPoints, #ng, this.#c, #lEe, #Lte);
				return new #YFe(this.DrawnLoadPoints, #GEe);
			}
			}
			return new #YFe();
		}

		// Token: 0x06009C22 RID: 39970 RVA: 0x002110A0 File Offset: 0x0020F2A0
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void #BEe(LoadType #CEe, IList<SelectedLoadData> #AEe, List<LoadPointDrawingData> #DEe, float #Udb, ConsideredAxis #Tye, #0Ie #C, bool #EEe, int #FEe, out int #GEe)
		{
			AxialLoadMomentDrawingEngine.#BUb #BUb = new AxialLoadMomentDrawingEngine.#BUb();
			#BUb.#a = #Udb;
			#BUb.#b = #Tye;
			#BUb.#c = #C;
			#X0d.#V0d(#CEe, #Phc.#3hc(107282892), Component.ColumnReporter, #Phc.#3hc(107282907));
			#X0d.#V0d(#DEe, #Phc.#3hc(107282822), Component.ColumnReporter, #Phc.#3hc(107282793));
			#GEe = 0;
			List<LoadPointDrawingData> #yjb = #DEe.Where(new Func<LoadPointDrawingData, bool>(#BUb.#3df)).ToList<LoadPointDrawingData>();
			if (#CEe == LoadType.Factored || #CEe == LoadType.Service)
			{
				List<LoadPointTempData> list = DiagramsHelper.#RFe(#yjb, #AEe, #BUb.#b, #FEe, out #GEe);
				this.DrawnLoadPoints.AddRange(list.OrderByDescending(new Func<LoadPointTempData, bool>(AxialLoadMomentDrawingEngine.<>c.<>9.#Rdf)).ThenBy(new Func<LoadPointTempData, int>(AxialLoadMomentDrawingEngine.<>c.<>9.#Sdf)).Select(new Func<LoadPointTempData, LoadPointDrawingData>(AxialLoadMomentDrawingEngine.<>c.<>9.#Tdf)));
				list = list.OrderByDescending(new Func<LoadPointTempData, bool>(AxialLoadMomentDrawingEngine.<>c.<>9.#Udf)).ThenByDescending(new Func<LoadPointTempData, bool>(AxialLoadMomentDrawingEngine.<>c.<>9.#Vdf)).ThenByDescending(new Func<LoadPointTempData, int>(AxialLoadMomentDrawingEngine.<>c.<>9.#Wdf)).ToList<LoadPointTempData>();
				list.Reverse();
				foreach (LoadPointTempData loadPointTempData in list)
				{
					this.#b.#QGe(loadPointTempData.Load.Index, loadPointTempData.Load.MomentX * this.#c.MomentsScalingFactor, loadPointTempData.Load.AxialLoad * this.#c.AxialLoadScalingFactor, loadPointTempData.IsSelected, loadPointTempData.IsInner);
				}
				if (#EEe)
				{
					foreach (LoadPointTempData loadPointTempData2 in list)
					{
						LoadPointDrawingData loadPointDrawingData = loadPointTempData2.Load;
						this.#b.#UGe(loadPointDrawingData.Index.ToString(CultureInfo.CurrentCulture), loadPointDrawingData.MomentX * this.#c.MomentsScalingFactor, loadPointDrawingData.AxialLoad * this.#c.AxialLoadScalingFactor, SvgLabelPosition.TopRight, loadPointTempData2.IsExactlySelected);
					}
				}
			}
		}

		// Token: 0x06009C23 RID: 39971 RVA: 0x00211358 File Offset: 0x0020F558
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void #BEe(LoadType #CEe, ConsideredAxis #6gb, #0Ie #pNb, IList<SelectedLoadData> #AEe, List<LoadPointDrawingData> #HEe, #7De #lEe, int #FEe, out int #IEe)
		{
			#X0d.#V0d(#CEe, #Phc.#3hc(107282892), Component.ColumnReporter, #Phc.#3hc(107282772));
			#X0d.#V0d(#HEe, #Phc.#3hc(107282719), Component.ColumnReporter, #Phc.#3hc(107314914));
			float #PFe = (float)Math.Round((double)#lEe.Parameter, 0);
			#IEe = 0;
			if (#CEe == LoadType.Factored || #CEe == LoadType.Service)
			{
				List<LoadPointTempData> list = DiagramsHelper.#OFe(#HEe, #AEe, #6gb, #FEe, #PFe, #pNb, out #IEe);
				this.DrawnLoadPoints.AddRange(list.OrderByDescending(new Func<LoadPointTempData, bool>(AxialLoadMomentDrawingEngine.<>c.<>9.#Xdf)).ThenBy(new Func<LoadPointTempData, int>(AxialLoadMomentDrawingEngine.<>c.<>9.#Ydf)).Select(new Func<LoadPointTempData, LoadPointDrawingData>(AxialLoadMomentDrawingEngine.<>c.<>9.#Zdf)));
				list = list.OrderByDescending(new Func<LoadPointTempData, bool>(AxialLoadMomentDrawingEngine.<>c.<>9.#0df)).ThenByDescending(new Func<LoadPointTempData, bool>(AxialLoadMomentDrawingEngine.<>c.<>9.#1df)).ThenByDescending(new Func<LoadPointTempData, int>(AxialLoadMomentDrawingEngine.<>c.<>9.#2df)).ToList<LoadPointTempData>();
				list.Reverse();
				foreach (LoadPointTempData loadPointTempData in list)
				{
					float num = loadPointTempData.ValidationData.#NJe() ? (loadPointTempData.LoadLength * -1f) : loadPointTempData.LoadLength;
					loadPointTempData.Load.AlternatePMMoment = new float?(num);
					this.#b.#QGe(loadPointTempData.Load.Index, num * this.#c.MomentsScalingFactor, loadPointTempData.Load.AxialLoad * this.#c.AxialLoadScalingFactor, loadPointTempData.IsSelected, loadPointTempData.IsInner);
				}
				if (#lEe.AreLoadLabelsDrawn)
				{
					foreach (LoadPointTempData loadPointTempData2 in list)
					{
						float num2 = loadPointTempData2.ValidationData.#NJe() ? (loadPointTempData2.LoadLength * -1f) : loadPointTempData2.LoadLength;
						this.#b.#UGe(loadPointTempData2.Load.Index.ToString(CultureInfo.CurrentCulture), num2 * this.#c.MomentsScalingFactor, loadPointTempData2.Load.AxialLoad * this.#c.AxialLoadScalingFactor, SvgLabelPosition.TopRight, loadPointTempData2.IsExactlySelected);
					}
				}
			}
		}

		// Token: 0x06009C24 RID: 39972 RVA: 0x00211644 File Offset: 0x0020F844
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private static bool #JEe(LoadPointDrawingData #ivb, float #Udb, ConsideredAxis #Tye, #0Ie #C)
		{
			if ((double)Math.Abs(#ivb.MomentX) <= 1E-05 && (double)Math.Abs(#ivb.MomentY) <= 1E-05)
			{
				return true;
			}
			#OJe #OJe = new #OJe(#ivb, #Udb);
			return (#Tye == ConsideredAxis.Both && #C != #0Ie.#c && #OJe.#MJe()) || (#Tye == ConsideredAxis.Both && #C != #0Ie.#b && #OJe.#NJe()) || (#Tye != ConsideredAxis.Both && #C != #0Ie.#c && #ivb.MomentX > 0f) || (#Tye != ConsideredAxis.Both && #C != #0Ie.#b && #ivb.MomentX < 0f);
		}

		// Token: 0x06009C25 RID: 39973 RVA: 0x002116D8 File Offset: 0x0020F8D8
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void #KEe(UniCurve[] #pEe, SvgPointCollection #LEe, bool #MEe, #0Ie #pNb)
		{
			foreach (#2Je #2Je in (#MEe ? AxialLoadMomentDrawingEngine.#REe(#pEe, #pNb, #MEe) : AxialLoadMomentDrawingEngine.#SEe(#pEe, #pNb, #MEe)))
			{
				this.#1Ee(#LEe, #2Je.Moment, #2Je.AxialLoad);
			}
		}

		// Token: 0x06009C26 RID: 39974 RVA: 0x00211748 File Offset: 0x0020F948
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void #NEe(UniCurve[] #gEe, SvgPointCollection #OEe, SvgPointCollection #PEe, float #QEe, bool #MEe, #0Ie #pNb)
		{
			bool flag = true;
			List<#2Je> list = #MEe ? AxialLoadMomentDrawingEngine.#REe(#gEe, #pNb, #MEe) : AxialLoadMomentDrawingEngine.#SEe(#gEe, #pNb, #MEe);
			for (int i = 0; i < list.Count; i++)
			{
				float num = list[i].AxialLoad;
				if (num > #QEe)
				{
					this.#1Ee(#PEe, list[i].Moment, num);
				}
				else
				{
					if (flag && i > 0)
					{
						float num2 = list[i - 1].AxialLoad;
						float num3 = list[i].AxialLoad;
						float #WEe = list[i - 1].Moment;
						float #YEe = list[i].Moment;
						if (#QEe < num2 && #QEe > num3)
						{
							this.#0Ee(#PEe, num2, #QEe, num3, #WEe, #YEe);
						}
						flag = false;
					}
					this.#1Ee(#OEe, list[i].Moment, num);
				}
			}
		}

		// Token: 0x06009C27 RID: 39975 RVA: 0x00211828 File Offset: 0x0020FA28
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private static List<#2Je> #REe(UniCurve[] #NAe, #0Ie #pNb, bool #MEe)
		{
			bool flag = false;
			#2Je #2Je = new #2Je();
			List<#2Je> list = new List<#2Je>();
			for (int i = 0; i < #NAe.Length; i++)
			{
				float num = #MEe ? #NAe[i].PositiveSide.Moment : #NAe[i].NegativeSide.Moment;
				float num2 = #NAe[i].AxialLoad;
				float num3 = 0f;
				float #UEe = 0f;
				if (i > 0)
				{
					num3 = (#MEe ? #NAe[i - 1].PositiveSide.Moment : #NAe[i - 1].NegativeSide.Moment);
					#UEe = #NAe[i - 1].AxialLoad;
				}
				if (#MHe.#IH(#NAe[i]))
				{
					if (#pNb == #0Ie.#b)
					{
						if (num3 < 0f && num > 0f)
						{
							float #f = AxialLoadMomentDrawingEngine.#TEe(#UEe, num2, num3, 0f, num);
							#2Je.AxialLoad = #f;
							#2Je.Moment = 0f;
							flag = false;
						}
						else if (num3 > 0f && num <= 0f)
						{
							float #f2 = AxialLoadMomentDrawingEngine.#TEe(#UEe, num2, num3, 0f, num);
							list.Add(new #2Je
							{
								AxialLoad = #f2,
								Moment = 0f
							});
							flag = true;
						}
						else if (num > 0f)
						{
							if (!flag && num3 >= 0f && i > 0 && #MHe.#IH(#NAe[i - 1]))
							{
								list.Add(new #2Je
								{
									AxialLoad = #2Je.AxialLoad,
									Moment = #2Je.Moment
								});
							}
							list.Add(new #2Je
							{
								AxialLoad = num2,
								Moment = num
							});
							flag = true;
						}
						else
						{
							#2Je.AxialLoad = num2;
							#2Je.Moment = num;
							flag = false;
						}
					}
					else if (#pNb == #0Ie.#c)
					{
						if (num3 < 0f && num >= 0f)
						{
							float #f3 = AxialLoadMomentDrawingEngine.#TEe(#UEe, num2, num3, 0f, num);
							list.Add(new #2Je
							{
								AxialLoad = #f3,
								Moment = 0f
							});
							flag = true;
						}
						else if (num3 > 0f && num < 0f)
						{
							float #f4 = AxialLoadMomentDrawingEngine.#TEe(#UEe, num2, num3, 0f, num);
							#2Je.AxialLoad = #f4;
							#2Je.Moment = 0f;
							flag = false;
						}
						else if (num < 0f)
						{
							if (!flag && num3 <= 0f && i > 0 && #MHe.#IH(#NAe[i - 1]))
							{
								list.Add(new #2Je
								{
									AxialLoad = #2Je.AxialLoad,
									Moment = #2Je.Moment
								});
							}
							list.Add(new #2Je
							{
								AxialLoad = num2,
								Moment = num
							});
							flag = true;
						}
						else
						{
							#2Je.AxialLoad = num2;
							#2Je.Moment = num;
							flag = false;
						}
					}
					else
					{
						list.Add(new #2Je
						{
							AxialLoad = num2,
							Moment = num
						});
						flag = true;
					}
				}
			}
			return list;
		}

		// Token: 0x06009C28 RID: 39976 RVA: 0x00211B10 File Offset: 0x0020FD10
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private static List<#2Je> #SEe(UniCurve[] #NAe, #0Ie #pNb, bool #MEe)
		{
			bool flag = false;
			#2Je #2Je = new #2Je();
			List<#2Je> list = new List<#2Je>();
			for (int i = 0; i < #NAe.Length; i++)
			{
				float num = #MEe ? #NAe[i].PositiveSide.Moment : #NAe[i].NegativeSide.Moment;
				float num2 = #NAe[i].AxialLoad;
				float num3 = 0f;
				float #UEe = 0f;
				if (i > 0)
				{
					num3 = (#MEe ? #NAe[i - 1].PositiveSide.Moment : #NAe[i - 1].NegativeSide.Moment);
					#UEe = #NAe[i - 1].AxialLoad;
				}
				if (#MHe.#IH(#NAe[i]))
				{
					if (#pNb == #0Ie.#b)
					{
						if (num3 > 0f && num <= 0f)
						{
							float #f = AxialLoadMomentDrawingEngine.#TEe(#UEe, num2, num3, 0f, num);
							list.Add(new #2Je
							{
								AxialLoad = #f,
								Moment = 0f
							});
							flag = true;
						}
						else if (num3 < 0f && num > 0f)
						{
							float #f2 = AxialLoadMomentDrawingEngine.#TEe(#UEe, num2, num3, 0f, num);
							#2Je.AxialLoad = #f2;
							#2Je.Moment = 0f;
							flag = false;
						}
						else if (num > 0f)
						{
							if (!flag && num3 >= 0f && i > 0 && #MHe.#IH(#NAe[i - 1]))
							{
								list.Add(new #2Je
								{
									AxialLoad = #2Je.AxialLoad,
									Moment = #2Je.Moment
								});
							}
							list.Add(new #2Je
							{
								AxialLoad = num2,
								Moment = num
							});
							flag = true;
						}
						else
						{
							#2Je.AxialLoad = num2;
							#2Je.Moment = num;
							flag = false;
						}
					}
					else if (#pNb == #0Ie.#c)
					{
						if (num3 > 0f && num < 0f)
						{
							float #f3 = AxialLoadMomentDrawingEngine.#TEe(#UEe, num2, num3, 0f, num);
							#2Je.AxialLoad = #f3;
							#2Je.Moment = 0f;
							flag = false;
						}
						else if (num3 < 0f && num >= 0f)
						{
							float #f4 = AxialLoadMomentDrawingEngine.#TEe(#UEe, num2, num3, 0f, num);
							list.Add(new #2Je
							{
								AxialLoad = #f4,
								Moment = 0f
							});
							flag = true;
						}
						else if (num < 0f)
						{
							if (!flag && num3 <= 0f && i > 0 && #MHe.#IH(#NAe[i - 1]))
							{
								list.Add(new #2Je
								{
									AxialLoad = #2Je.AxialLoad,
									Moment = #2Je.Moment
								});
							}
							list.Add(new #2Je
							{
								AxialLoad = num2,
								Moment = num
							});
							flag = true;
						}
						else
						{
							#2Je.AxialLoad = num2;
							#2Je.Moment = num;
							flag = false;
						}
					}
					else
					{
						list.Add(new #2Je
						{
							AxialLoad = num2,
							Moment = num
						});
						flag = true;
					}
				}
			}
			return list;
		}

		// Token: 0x06009C29 RID: 39977 RVA: 0x0007B501 File Offset: 0x00079701
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private static float #TEe(float #UEe, float #VEe, float #WEe, float #XEe, float #YEe)
		{
			if (Math.Abs(#YEe - #WEe) > 0.01f)
			{
				return #UEe + (#VEe - #UEe) * (#XEe - #WEe) / (#YEe - #WEe);
			}
			return #UEe + (#VEe - #UEe) * 0.5f;
		}

		// Token: 0x06009C2A RID: 39978 RVA: 0x0007B52D File Offset: 0x0007972D
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private static float #ZEe(float #UEe, float #QEe, float #VEe, float #WEe, float #YEe)
		{
			if (Math.Abs(#VEe - #UEe) > 0.01f)
			{
				return #WEe + (#YEe - #WEe) * (#QEe - #UEe) / (#VEe - #UEe);
			}
			return #WEe + (#YEe - #WEe) * 0.5f;
		}

		// Token: 0x06009C2B RID: 39979 RVA: 0x00211DF8 File Offset: 0x0020FFF8
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void #0Ee(SvgPointCollection #BP, float #UEe, float #QEe, float #VEe, float #WEe, float #YEe)
		{
			float num = AxialLoadMomentDrawingEngine.#ZEe(#UEe, #QEe, #VEe, #WEe, #YEe);
			#BP.Add(this.#c.MomentsScalingFactor * num);
			#BP.Add(#ZIe.#UIe(#QEe * this.#c.AxialLoadScalingFactor, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY));
		}

		// Token: 0x06009C2C RID: 39980 RVA: 0x00211E60 File Offset: 0x00210060
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void #1Ee(SvgPointCollection #BP, float #pvb, float #qvb)
		{
			#BP.Add(#pvb * this.#c.MomentsScalingFactor);
			#BP.Add(#ZIe.#UIe(#qvb * this.#c.AxialLoadScalingFactor, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY));
		}

		// Token: 0x06009C2D RID: 39981 RVA: 0x0007B559 File Offset: 0x00079759
		private void #2Ee(SvgPointCollection #3Ee, SvgPointCollection #4Ee)
		{
			this.#b.#BGe(#3Ee);
			this.#b.#BGe(#4Ee);
		}

		// Token: 0x06009C2E RID: 39982 RVA: 0x0007B573 File Offset: 0x00079773
		private void #5Ee(SvgPointCollection #3Ee, SvgPointCollection #4Ee, SvgPointCollection #6Ee, SvgPointCollection #7Ee, bool #tEe)
		{
			this.#b.#AGe(#3Ee);
			this.#b.#AGe(#4Ee);
			if (#tEe)
			{
				this.#8Ee(#6Ee, #7Ee);
			}
		}

		// Token: 0x06009C2F RID: 39983 RVA: 0x0007B59A File Offset: 0x0007979A
		private void #8Ee(SvgPointCollection #6Ee, SvgPointCollection #7Ee)
		{
			this.#b.#CGe(#6Ee);
			this.#b.#CGe(#7Ee);
		}

		// Token: 0x06009C30 RID: 39984 RVA: 0x00211EB8 File Offset: 0x002100B8
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void #9Ee(float #aFe, string #bFe, #0Ie #pNb, bool #uEe, bool #4Jc)
		{
			int num = 2;
			if (((#pNb == #0Ie.#b || #pNb == #0Ie.#c) && Math.Abs(Math.Round((double)(this.#c.DiagramBorderWidth / this.#c.AxisIntervalX)) - 1.0) < 0.001) || (#pNb == #0Ie.#a && Math.Abs(Math.Round((double)(this.#c.DiagramBorderWidth / this.#c.AxisIntervalX)) - 2.0) < 0.001))
			{
				num = 1;
			}
			float #Xrb = (#pNb != #0Ie.#b) ? ((float)(-(float)num) * this.#c.AxisIntervalX) : 0f;
			float #Yrb = (#pNb != #0Ie.#c) ? ((float)num * this.#c.AxisIntervalX) : 0f;
			this.#b.#JGe(#aFe * this.#c.AxialLoadScalingFactor, #Xrb, #Yrb);
			if (#pNb != #0Ie.#c && #uEe)
			{
				this.#b.#TGe(#bFe, (float)num * this.#c.AxisIntervalX, #aFe * this.#c.AxialLoadScalingFactor, #4Jc ? SvgLabelPosition.TopAlignedRightAligned : SvgLabelPosition.BotAlignedRightAligned, LabelType.Regular);
			}
			if (#pNb != #0Ie.#b && #uEe)
			{
				this.#b.#TGe(#bFe, (float)(-(float)num) * this.#c.AxisIntervalX, #aFe * this.#c.AxialLoadScalingFactor, #4Jc ? SvgLabelPosition.TopAlignedLeftAligned : SvgLabelPosition.BotAlignedLeftAligned, LabelType.Regular);
			}
		}

		// Token: 0x06009C31 RID: 39985 RVA: 0x00212010 File Offset: 0x00210210
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void #cFe(UniCurve[] #dFe, float #qEe, float #eFe, #0Ie #pNb)
		{
			float num = #qEe * #eFe;
			UniCurve #gFe = AxialLoadMomentDrawingEngine.#iFe(#dFe, num);
			float #MGe = this.#fFe(#gFe, #pNb);
			float #NGe = this.#hFe(#gFe, #pNb);
			float #QEe = #ZIe.#UIe(num * this.#c.AxialLoadScalingFactor, this.#c.DiagramBorderMinY, this.#c.DiagramBorderMaxY);
			this.#b.#LGe(#QEe, #MGe, #NGe);
		}

		// Token: 0x06009C32 RID: 39986 RVA: 0x00212078 File Offset: 0x00210278
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private float #fFe(UniCurve #gFe, #0Ie #pNb)
		{
			if (#pNb == #0Ie.#c && #gFe.NegativeSide.Moment > 0f)
			{
				return 0f;
			}
			if (#pNb != #0Ie.#b)
			{
				return -#gFe.NegativeSide.Moment * this.#c.MomentsScalingFactor;
			}
			if (#gFe.NegativeSide.Moment > 0f)
			{
				return -#gFe.NegativeSide.Moment * this.#c.MomentsScalingFactor;
			}
			return 0f;
		}

		// Token: 0x06009C33 RID: 39987 RVA: 0x002120F0 File Offset: 0x002102F0
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private float #hFe(UniCurve #gFe, #0Ie #pNb)
		{
			if (#pNb == #0Ie.#b && #gFe.PositiveSide.Moment < 0f)
			{
				return 0f;
			}
			if (#pNb != #0Ie.#c)
			{
				return #gFe.PositiveSide.Moment * this.#c.MomentsScalingFactor;
			}
			if (#gFe.PositiveSide.Moment < 0f)
			{
				return #gFe.PositiveSide.Moment * this.#c.MomentsScalingFactor;
			}
			return 0f;
		}

		// Token: 0x06009C34 RID: 39988 RVA: 0x00212164 File Offset: 0x00210364
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private static UniCurve #iFe(UniCurve[] #dFe, float #QEe)
		{
			AxialLoadMomentDrawingEngine.#cWb #cWb = new AxialLoadMomentDrawingEngine.#cWb();
			#cWb.#a = #QEe;
			return #dFe.Aggregate(new Func<UniCurve, UniCurve, UniCurve>(#cWb.#4df));
		}

		// Token: 0x06009C35 RID: 39989 RVA: 0x00212190 File Offset: 0x00210390
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void #jFe(string #oT, #A3e #ivb, bool #MEe, bool #kFe)
		{
			float num = (float)(#MEe ? 1 : -1) * (this.#c.MomentsScalingFactor * #ivb.Moment);
			float num2 = (Math.Abs(num) < 0.01f) ? 0f : (num * 1.1f);
			float num3 = (Math.Abs(num2) < 0.01f) ? 0f : (1.1f * (#ivb.AxialLoad * this.#c.AxialLoadScalingFactor));
			num2 = Math.Max(num2, this.#c.DiagramBorderMinX);
			num2 = Math.Min(num2, this.#c.DiagramBorderMaxX);
			num3 = Math.Max(num3, this.#c.DiagramBorderMinY);
			num3 = Math.Min(num3, this.#c.DiagramBorderMaxY);
			if (#kFe)
			{
				this.#b.#PGe(num2, num3);
			}
			else
			{
				this.#b.#OGe(num2, num3);
			}
			SvgLabelPosition #0bb = #MEe ? SvgLabelPosition.TopRight : SvgLabelPosition.TopLeft;
			if (Math.Abs(num2) > 0.01f && Math.Abs(num3) > 0.01f)
			{
				this.#b.#TGe(#oT, num2, num3, #0bb, LabelType.SpliceLine);
			}
		}

		// Token: 0x04004364 RID: 17252
		private const float #a = 0.01f;

		// Token: 0x04004365 RID: 17253
		private readonly #XGe #b;

		// Token: 0x04004366 RID: 17254
		private readonly #zDe #c;

		// Token: 0x04004367 RID: 17255
		[CompilerGenerated]
		private List<LoadPointDrawingData> #d;

		// Token: 0x02001232 RID: 4658
		[CompilerGenerated]
		private sealed class #BUb
		{
			// Token: 0x06009C4A RID: 40010 RVA: 0x0007B5ED File Offset: 0x000797ED
			internal bool #3df(LoadPointDrawingData #Rf)
			{
				return AxialLoadMomentDrawingEngine.#JEe(#Rf, this.#a, this.#b, this.#c);
			}

			// Token: 0x0400437A RID: 17274
			public float #a;

			// Token: 0x0400437B RID: 17275
			public ConsideredAxis #b;

			// Token: 0x0400437C RID: 17276
			public #0Ie #c;
		}

		// Token: 0x02001233 RID: 4659
		[CompilerGenerated]
		private sealed class #cWb
		{
			// Token: 0x06009C4C RID: 40012 RVA: 0x0007B607 File Offset: 0x00079807
			internal UniCurve #4df(UniCurve #5df, UniCurve #Rf)
			{
				if (#5df != null && Math.Abs(#Rf.AxialLoad - this.#a) >= Math.Abs(#5df.AxialLoad - this.#a))
				{
					return #5df;
				}
				return #Rf;
			}

			// Token: 0x0400437D RID: 17277
			public float #a;
		}
	}
}
