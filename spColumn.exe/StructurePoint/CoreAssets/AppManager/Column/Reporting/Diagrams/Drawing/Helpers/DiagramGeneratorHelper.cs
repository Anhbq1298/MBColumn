using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #6re;
using #7hc;
using #NHe;
using #o1d;
using #oFe;
using #rCe;
using #Wse;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.NewCapacityRatio;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.DTO;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Infrastructure.Data;
using Svg;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing.Helpers
{
	// Token: 0x02001253 RID: 4691
	public static class DiagramGeneratorHelper
	{
		// Token: 0x06009D57 RID: 40279 RVA: 0x002167D0 File Offset: 0x002149D0
		internal static void #OHe(#ZIe #Lte, #XGe #tCd, #zDe #Gfb, #LCe #Pc)
		{
			if (#tCd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107251540));
			}
			if (#Gfb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107376321));
			}
			if (#Pc == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107395311));
			}
			SvgViewBox viewBox;
			DiagramGeneratorHelper.#PHe(#Gfb, #Pc, out viewBox);
			#tCd.Document.Width = #1Ge.#wae(viewBox.Width);
			#tCd.Document.Height = #1Ge.#wae(viewBox.Height);
			#tCd.Document.AspectRatio = new SvgAspectRatio(SvgPreserveAspectRatio.xMaxYMax);
			#tCd.Document.ViewBox = viewBox;
			#tCd.DocumentRoot.Children.Add(new SvgRectangle
			{
				X = #1Ge.#wae(viewBox.MinX),
				Y = #1Ge.#wae(viewBox.MinY),
				Width = #1Ge.#wae(viewBox.Width),
				Height = #1Ge.#wae(viewBox.Height),
				Fill = #Lte.ScreenBackground
			});
		}

		// Token: 0x06009D58 RID: 40280 RVA: 0x002168F4 File Offset: 0x00214AF4
		public static void #PHe(#zDe #Gfb, #LCe #Pc, out SvgViewBox #iue)
		{
			float num = (float)(-(float)(#Pc.ViewportWidth / 2.0 - (double)(#Gfb.BorderWithMarginsWidth / 2f) + (double)Math.Abs(#Gfb.BorderWithMarginsMinX)));
			float num2 = (float)(-(float)(#Pc.ViewportHeight / 2.0 - (double)(#Gfb.BorderWithMarginsHeight / 2f) + (double)Math.Abs(#Gfb.BorderWithMarginsMinY)));
			float num3 = (float)#Pc.ViewportWidth;
			float num4 = (float)#Pc.ViewportHeight;
			if (#Pc.ViewWindow != null)
			{
				Rect value = #Pc.ViewWindow.Value;
				if ((value.Left >= 0.0 || value.Right >= 0.0 || value.Top >= 0.0 || value.Bottom >= 0.0) && value.Location.X < 1.0 && value.Location.Y < 1.0)
				{
					if (value.Location.X < 0.0)
					{
						double value2 = value.Location.X;
						value.Location = new Point(0.0, value.Location.Y);
						value.Width -= Math.Abs(value2);
					}
					if (value.Location.Y < 0.0)
					{
						double value3 = value.Location.Y;
						value.Location = new Point(value.Location.X, 0.0);
						value.Height -= Math.Abs(value3);
					}
					num = (float)((double)num + (double)num3 * value.Location.X);
					num2 = (float)((double)num2 + (double)num4 * value.Location.Y);
					float val = (float)((1.0 - value.Location.X) * (double)num3);
					float val2 = (float)((1.0 - value.Location.Y) * (double)num4);
					num3 = Math.Min((float)((double)num3 * value.Width), val);
					num4 = Math.Min((float)((double)num4 * value.Height), val2);
				}
			}
			#iue = new SvgViewBox(#1Ge.#wae(num), #1Ge.#wae(num2), #1Ge.#wae(num3), #1Ge.#wae(num4));
		}

		// Token: 0x06009D59 RID: 40281 RVA: 0x00216BA4 File Offset: 0x00214DA4
		public static List<LoadPointDrawingData> #Orb(#lte #Od, #5re #st, #8re #mA, Diagram2DType #2bb, float #Sb, IList<SelectedLoadData> #Sd, out int #Prb)
		{
			List<LoadPointDrawingData> list = DiagramGeneratorHelper.#QHe(#Od, #uCe.#g, #mA, #Od.Input.Options.ActiveLoad, false);
			#Prb = list.Count;
			if (list.Count > #st.MaxDisplayedLoadPoints)
			{
				HashSet<LoadPointDrawingData> hashSet = new HashSet<LoadPointDrawingData>();
				if (#2bb == Diagram2DType.DiagramMM)
				{
					int num;
					IEnumerable<LoadPointDrawingData> #8f = DiagramsHelper.#LFe(DiagramGeneratorHelper.#QHe(#Od, #uCe.#g, #mA, #Od.Input.Options.ActiveLoad, false), #Sd, #st.MaxDisplayedLoadPoints, #Sb, out num).Select(new Func<LoadPointTempData, LoadPointDrawingData>(DiagramGeneratorHelper.<>c.<>9.#Iff));
					hashSet.#pR(#8f);
				}
				else
				{
					#uCe #uCe = DiagramsHelper.#SFe((double)#Sb, #Od.Input.Options.ConsideredAxis);
					List<LoadPointDrawingData> #yjb = DiagramGeneratorHelper.#QHe(#Od, #uCe, #mA, #Od.Input.Options.ActiveLoad, false);
					if (#uCe > #uCe.#b)
					{
						if (#uCe - #uCe.#c <= 3)
						{
							#0Ie #pNb = DiagramsHelper.#TFe(#2bb);
							int num;
							List<LoadPointTempData> source = DiagramsHelper.#OFe(#yjb, #Sd, #Od.Input.Options.ConsideredAxis, #st.MaxDisplayedLoadPoints, #Sb, #pNb, out num);
							hashSet.#pR(source.Select(new Func<LoadPointTempData, LoadPointDrawingData>(DiagramGeneratorHelper.<>c.<>9.#Kff)));
						}
					}
					else
					{
						int num;
						List<LoadPointTempData> source2 = DiagramsHelper.#RFe(#yjb, #Sd, #Od.Input.Options.ConsideredAxis, #st.MaxDisplayedLoadPoints, out num);
						hashSet.#pR(source2.Select(new Func<LoadPointTempData, LoadPointDrawingData>(DiagramGeneratorHelper.<>c.<>9.#Jff)));
					}
				}
				return hashSet.ToList<LoadPointDrawingData>();
			}
			return DiagramGeneratorHelper.#Qrb(list, #Sd, #st.MaxDisplayedLoadPoints);
		}

		// Token: 0x06009D5A RID: 40282 RVA: 0x00216D54 File Offset: 0x00214F54
		public static bool #3gb(double? #4gb, double? #5gb)
		{
			double? num = #4gb;
			double? num2 = #5gb;
			return (num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null)) || (#4gb != null && #5gb != null && Math.Abs(#4gb.Value - #5gb.Value) <= 0.1);
		}

		// Token: 0x06009D5B RID: 40283 RVA: 0x00216DC0 File Offset: 0x00214FC0
		public static List<LoadPointDrawingData> #QHe(#lte #Od, #uCe #SCe, #8re #mJ, LoadType #GB, bool #RHe = false)
		{
			DiagramGeneratorHelper.#MZb #MZb = new DiagramGeneratorHelper.#MZb();
			#MZb.#a = #Od;
			#MZb.#b = #mJ;
			return #MZb.#a.Output.CapacityData.LoadPoints.Where(new Func<LoadPointDrawingData, bool>(#MZb.#Nff)).ToList<LoadPointDrawingData>();
		}

		// Token: 0x06009D5C RID: 40284 RVA: 0x00216E0C File Offset: 0x0021500C
		internal static bool #SHe(LoadPointDrawingData #ivb, float #Udb)
		{
			if ((double)Math.Abs(#ivb.MomentX) < 0.001 && (double)Math.Abs(#ivb.MomentY) < 0.001)
			{
				return true;
			}
			#OJe #OJe = new #OJe(#ivb, #Udb);
			return #OJe.#MJe() || #OJe.#NJe();
		}

		// Token: 0x06009D5D RID: 40285 RVA: 0x00216E64 File Offset: 0x00215064
		internal static bool #THe(LoadPointDrawingData #ivb, float #Tdb)
		{
			double num = Math.Round((double)#Tdb);
			return (double)#ivb.AxialLoad > num - 0.5 && (double)#ivb.AxialLoad < num + 0.5;
		}

		// Token: 0x06009D5E RID: 40286 RVA: 0x00216EA4 File Offset: 0x002150A4
		internal static float #UHe(LoadPointDrawingData #ivb, float #Udb, #uCe #SCe)
		{
			float num;
			if (#SCe == #uCe.#a)
			{
				num = #ivb.MomentX;
			}
			else if (#SCe == #uCe.#b)
			{
				num = #ivb.MomentY;
			}
			else
			{
				#OJe #OJe = new #OJe(#ivb, #Udb);
				num = (float)Math.Sqrt(Math.Pow((double)#ivb.MomentX, 2.0) + Math.Pow((double)#ivb.MomentY, 2.0));
				if (#OJe.LoadAngle <= #OJe.OppositeUpperBound && #OJe.LoadAngle >= #OJe.OppositeLowerBound)
				{
					num = -num;
				}
			}
			return num;
		}

		// Token: 0x06009D5F RID: 40287 RVA: 0x00216F24 File Offset: 0x00215124
		internal static bool #VHe(IList<SelectedLoadData> #AEe, LoadPointDrawingData #ivb)
		{
			DiagramGeneratorHelper.#s0b #s0b = new DiagramGeneratorHelper.#s0b();
			#s0b.#a = #ivb;
			return #AEe.Any<SelectedLoadData>() && #AEe.Any(new Func<SelectedLoadData, bool>(#s0b.#Off));
		}

		// Token: 0x06009D60 RID: 40288 RVA: 0x00216F5C File Offset: 0x0021515C
		internal static bool #WHe(IList<SelectedLoadData> #AEe, LoadPointDrawingData #ivb, ConsideredAxis #6gb)
		{
			if (!#AEe.Any<SelectedLoadData>())
			{
				return false;
			}
			foreach (SelectedLoadData selectedLoadData in #AEe)
			{
				if (selectedLoadData.AxialForce != null && Math.Abs(selectedLoadData.AxialForce.Value - (double)#ivb.AxialLoad) < 0.1)
				{
					bool flag = selectedLoadData.MomentX != null && Math.Abs(selectedLoadData.MomentX.Value - (double)#ivb.MomentX) < 0.1;
					bool flag2 = selectedLoadData.MomentY != null && Math.Abs(selectedLoadData.MomentY.Value - (double)#ivb.MomentY) < 0.1;
					if (#6gb == ConsideredAxis.Both && flag && flag2)
					{
						return true;
					}
					if (#6gb == ConsideredAxis.X && flag)
					{
						return true;
					}
					if (#6gb == ConsideredAxis.Y && flag2)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06009D61 RID: 40289 RVA: 0x0007BFBE File Offset: 0x0007A1BE
		internal static bool #zjb(#lte #Od, LoadPointDrawingData #Gfb, #8re #mJ)
		{
			return #mJ == null || !#mJ.IsCapacityRatioFilterActive || CapacityRatioHelper.#pAe(#Gfb.CapacityRatio.DisplayValue, (#x6e)#Od.Input.Options.SectionCapacityMethod, #mJ.CapacityRatioFilterValue, false);
		}

		// Token: 0x06009D62 RID: 40290 RVA: 0x00217094 File Offset: 0x00215294
		private static List<LoadPointDrawingData> #Qrb(IList<LoadPointDrawingData> #yjb, IList<SelectedLoadData> #Sd, int #Rrb)
		{
			DiagramGeneratorHelper.#iZb #iZb = new DiagramGeneratorHelper.#iZb();
			#iZb.#a = #Sd;
			List<LoadPointDrawingData> list = #yjb.Where(new Func<LoadPointDrawingData, bool>(#iZb.#Pff)).ToList<LoadPointDrawingData>();
			IOrderedEnumerable<LoadPointDrawingData> source = #yjb.Except(list).OrderByDescending(new Func<LoadPointDrawingData, double?>(DiagramGeneratorHelper.<>c.<>9.#Lff));
			return list.Union(source.OrderByDescending(new Func<LoadPointDrawingData, double?>(DiagramGeneratorHelper.<>c.<>9.#Mff)).Take(Math.Max(#Rrb - list.Count, 0))).ToList<LoadPointDrawingData>();
		}

		// Token: 0x06009D63 RID: 40291 RVA: 0x00217138 File Offset: 0x00215338
		private static bool #3gb(SelectedLoadData #Au, LoadPointDrawingData #Nrb)
		{
			return DiagramGeneratorHelper.#3gb(#Au.MomentX, new double?((double)#Nrb.MomentX)) && DiagramGeneratorHelper.#3gb(#Au.MomentY, new double?((double)#Nrb.MomentY)) && DiagramGeneratorHelper.#3gb(#Au.AxialForce, new double?((double)#Nrb.AxialLoad));
		}

		// Token: 0x06009D64 RID: 40292 RVA: 0x00217190 File Offset: 0x00215390
		private static bool #XHe(#lte #Od, LoadPointDrawingData #Gfb, #8re #mJ)
		{
			if (#mJ == null)
			{
				return true;
			}
			if (#mJ.IsLocationFilterActive && !string.IsNullOrWhiteSpace(#mJ.LocationFilter))
			{
				string text = #Gfb.TopBottom;
				if (!string.IsNullOrWhiteSpace(text) && !string.Equals(#mJ.LocationFilter.Trim(), text, StringComparison.OrdinalIgnoreCase))
				{
					return false;
				}
			}
			return DiagramGeneratorHelper.#zjb(#Od, #Gfb, #mJ);
		}

		// Token: 0x04004407 RID: 17415
		private const double #a = 0.001;

		// Token: 0x02001255 RID: 4693
		[CompilerGenerated]
		private sealed class #iZb
		{
			// Token: 0x06009D6D RID: 40301 RVA: 0x002171E4 File Offset: 0x002153E4
			internal bool #Pff(LoadPointDrawingData #gsb)
			{
				DiagramGeneratorHelper.#Qff #Qff = new DiagramGeneratorHelper.#Qff();
				#Qff.#a = #gsb;
				return this.#a.Any(new Func<SelectedLoadData, bool>(#Qff.#66b));
			}

			// Token: 0x0400440E RID: 17422
			public IList<SelectedLoadData> #a;
		}

		// Token: 0x02001256 RID: 4694
		[CompilerGenerated]
		private sealed class #Qff
		{
			// Token: 0x06009D6F RID: 40303 RVA: 0x0007C00F File Offset: 0x0007A20F
			internal bool #66b(SelectedLoadData #76b)
			{
				return DiagramGeneratorHelper.#3gb(#76b, this.#a);
			}

			// Token: 0x0400440F RID: 17423
			public LoadPointDrawingData #a;
		}

		// Token: 0x02001257 RID: 4695
		[CompilerGenerated]
		private sealed class #MZb
		{
			// Token: 0x06009D71 RID: 40305 RVA: 0x0007C01D File Offset: 0x0007A21D
			internal bool #Nff(LoadPointDrawingData #Rf)
			{
				return DiagramGeneratorHelper.#XHe(this.#a, #Rf, this.#b);
			}

			// Token: 0x04004410 RID: 17424
			public #lte #a;

			// Token: 0x04004411 RID: 17425
			public #8re #b;
		}

		// Token: 0x02001258 RID: 4696
		[CompilerGenerated]
		private sealed class #s0b
		{
			// Token: 0x06009D73 RID: 40307 RVA: 0x00217218 File Offset: 0x00215418
			internal bool #Off(SelectedLoadData #Rf)
			{
				int? num = #Rf.Number;
				int num2 = this.#a.Index;
				return num.GetValueOrDefault() == num2 & num != null;
			}

			// Token: 0x04004412 RID: 17426
			public LoadPointDrawingData #a;
		}
	}
}
