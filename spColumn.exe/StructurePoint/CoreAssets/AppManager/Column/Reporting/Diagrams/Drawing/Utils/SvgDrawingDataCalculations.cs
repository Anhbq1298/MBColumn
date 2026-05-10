using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #hZe;
using #NHe;
using #rCe;
using #UYd;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing.Helpers;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.Drawing.Utils
{
	// Token: 0x0200124A RID: 4682
	internal sealed class SvgDrawingDataCalculations
	{
		// Token: 0x06009CE6 RID: 40166 RVA: 0x00214C68 File Offset: 0x00212E68
		[MethodImpl(MethodImplOptions.NoOptimization)]
		public SvgDrawingDataCalculations(#ZIe drawingStyle, #LCe parameters)
		{
			if (parameters == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107395311));
			}
			this.#a = drawingStyle;
			double num = (parameters.Options.AspectRatio == Diagram2DAspectRatio.Auto) ? parameters.ViewportWidth : ((parameters.ViewportWidth < parameters.ViewportHeight) ? parameters.ViewportWidth : parameters.ViewportHeight);
			this.#b = ((double.IsNaN(num) || double.IsInfinity(num) || num <= 0.0) ? 1000f : ((float)num));
			num = ((parameters.Options.AspectRatio == Diagram2DAspectRatio.Auto) ? parameters.ViewportHeight : ((parameters.ViewportWidth < parameters.ViewportHeight) ? parameters.ViewportWidth : parameters.ViewportHeight));
			this.#c = ((double.IsNaN(num) || double.IsInfinity(num) || num <= 0.0) ? 1000f : ((float)num));
			this.#d = drawingStyle.LoadPointSize;
			this.#e = parameters.Options.AspectRatio;
			this.#f = new #CJe(drawingStyle);
		}

		// Token: 0x06009CE7 RID: 40167 RVA: 0x00214D7C File Offset: 0x00212F7C
		public #zDe #9Fe(#y0e #2Ge, #dEe #NAe, IEnumerable<LoadPointDrawingData> #yjb, bool #3Ge)
		{
			#X0d.#V0d(#NAe, #Phc.#3hc(107314270), Component.ColumnReporter, #Phc.#3hc(107314261));
			#zDe #zDe = new #zDe();
			this.#6Ge(#2Ge, #zDe, #NAe, #yjb, #3Ge);
			this.#mHe(#zDe, #NAe.DrawOptions.CurrentUniCurveDrawingMode);
			return #zDe;
		}

		// Token: 0x06009CE8 RID: 40168 RVA: 0x00214DCC File Offset: 0x00212FCC
		public #zDe #9Fe(#y0e #2Ge, BiCurve #NAe, IList<LoadPointDrawingData> #yjb, float #Udb, bool #3Ge)
		{
			#X0d.#V0d(#NAe, #Phc.#3hc(107314270), Component.ColumnReporter, #Phc.#3hc(107314176));
			#zDe #zDe = new #zDe();
			this.#6Ge(#2Ge, #zDe, #NAe, #yjb, #Udb, #3Ge);
			this.#tHe(#zDe);
			return #zDe;
		}

		// Token: 0x06009CE9 RID: 40169 RVA: 0x00214E14 File Offset: 0x00213014
		public #zDe #9Fe(#y0e #2Ge, BiCurve #NAe, IList<LoadPointDrawingData> #yjb, float #Udb, bool #3Ge, IList<BiCurve> #4Ge)
		{
			if (!#4Ge.Any<BiCurve>())
			{
				return this.#9Fe(#2Ge, #NAe, #yjb, #Udb, #3Ge);
			}
			#zDe #zDe = new #zDe();
			this.#6Ge(#2Ge, #zDe, #NAe, #yjb, #Udb, #3Ge);
			List<float> source = #4Ge.SelectMany(new Func<BiCurve, IEnumerable<float>>(SvgDrawingDataCalculations.<>c.<>9.#Bef)).ToList<float>();
			List<float> source2 = #4Ge.SelectMany(new Func<BiCurve, IEnumerable<float>>(SvgDrawingDataCalculations.<>c.<>9.#Cef)).ToList<float>();
			float #WTc = Math.Min(#zDe.InteractionDiagramMinX, source.Min());
			float #YTc = Math.Min(#zDe.InteractionDiagramMinY, source2.Min());
			float #XTc = Math.Max(#zDe.InteractionDiagramMaxX, source.Max());
			float #ZTc = Math.Max(#zDe.InteractionDiagramMaxY, source2.Max());
			this.#lHe(#zDe, #WTc, #YTc, #XTc, #ZTc);
			if (!#3Ge)
			{
				#zDe.InteractionDiagramMinX = ((Math.Abs(#zDe.InteractionDiagramMinX) > 1f) ? #zDe.InteractionDiagramMinX : -1f);
				#zDe.InteractionDiagramMaxX = ((Math.Abs(#zDe.InteractionDiagramMaxX) > 1f) ? #zDe.InteractionDiagramMaxX : 1f);
				#zDe.InteractionDiagramMinY = ((Math.Abs(#zDe.InteractionDiagramMinY) > 1f) ? #zDe.InteractionDiagramMinY : -1f);
				#zDe.InteractionDiagramMaxY = ((Math.Abs(#zDe.InteractionDiagramMaxY) > 1f) ? #zDe.InteractionDiagramMaxY : 1f);
			}
			this.#tHe(#zDe);
			return #zDe;
		}

		// Token: 0x06009CEA RID: 40170 RVA: 0x00214FA0 File Offset: 0x002131A0
		public #zDe #9Fe(#y0e #2Ge, #dEe #NAe, IEnumerable<LoadPointDrawingData> #yjb, bool #3Ge, IList<UniCurve> #5Ge)
		{
			if (!#5Ge.Any<UniCurve>())
			{
				return this.#9Fe(#2Ge, #NAe, #yjb, #3Ge);
			}
			#zDe #zDe = new #zDe();
			this.#6Ge(#2Ge, #zDe, #NAe, #yjb, #3Ge);
			#0Ie #0Ie = #NAe.DrawOptions.CurrentUniCurveDrawingMode;
			List<UniCurveData> list = #5Ge.Select(new Func<UniCurve, UniCurveData>(SvgDrawingDataCalculations.<>c.<>9.#Def)).Where(new Func<UniCurveData, bool>(SvgDrawingDataCalculations.<>c.<>9.#Eef)).ToList<UniCurveData>();
			List<UniCurveData> list2 = #5Ge.Select(new Func<UniCurve, UniCurveData>(SvgDrawingDataCalculations.<>c.<>9.#Fef)).Where(new Func<UniCurveData, bool>(SvgDrawingDataCalculations.<>c.<>9.#Gef)).ToList<UniCurveData>();
			List<UniCurveData> list3 = new List<UniCurveData>();
			if (list.Any<UniCurveData>())
			{
				list3.AddRange(list);
			}
			if (list2.Any<UniCurveData>())
			{
				list3.AddRange(list2);
			}
			switch (#0Ie)
			{
			case #0Ie.#a:
			{
				float val = Math.Max(Math.Abs(#zDe.InteractionDiagramMinX), Math.Abs(#zDe.InteractionDiagramMaxX));
				float val2 = list3.Max(new Func<UniCurveData, float>(SvgDrawingDataCalculations.<>c.<>9.#Hef));
				float num = Math.Max(val, val2);
				#zDe.InteractionDiagramMinX = -num;
				#zDe.InteractionDiagramMaxX = num;
				#zDe.InteractionDiagramMinY = Math.Min(#zDe.InteractionDiagramMinY, #5Ge.Min(new Func<UniCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#Ief)));
				#zDe.InteractionDiagramMaxY = Math.Max(#zDe.InteractionDiagramMaxY, #5Ge.Max(new Func<UniCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#Jef)));
				break;
			}
			case #0Ie.#b:
				#zDe.InteractionDiagramMinX = Math.Min(#zDe.InteractionDiagramMinX, list3.Min(new Func<UniCurveData, float>(SvgDrawingDataCalculations.<>c.<>9.#Kef)));
				#zDe.InteractionDiagramMaxX = Math.Max(#zDe.InteractionDiagramMaxX, list3.Max(new Func<UniCurveData, float>(SvgDrawingDataCalculations.<>c.<>9.#Lef)));
				#zDe.InteractionDiagramMinY = Math.Min(#zDe.InteractionDiagramMinY, #5Ge.Min(new Func<UniCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#Mef)));
				#zDe.InteractionDiagramMaxY = Math.Max(#zDe.InteractionDiagramMaxY, #5Ge.Max(new Func<UniCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#Nef)));
				break;
			case #0Ie.#c:
				#zDe.InteractionDiagramMinX = Math.Min(#zDe.InteractionDiagramMinX, list3.Min(new Func<UniCurveData, float>(SvgDrawingDataCalculations.<>c.<>9.#Oef)));
				#zDe.InteractionDiagramMaxX = Math.Max(#zDe.InteractionDiagramMaxX, list3.Max(new Func<UniCurveData, float>(SvgDrawingDataCalculations.<>c.<>9.#Pef)));
				#zDe.InteractionDiagramMinY = Math.Min(#zDe.InteractionDiagramMinY, #5Ge.Min(new Func<UniCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#Qef)));
				#zDe.InteractionDiagramMaxY = Math.Max(#zDe.InteractionDiagramMaxY, #5Ge.Max(new Func<UniCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#Ref)));
				break;
			}
			this.#mHe(#zDe, #NAe.DrawOptions.CurrentUniCurveDrawingMode);
			return #zDe;
		}

		// Token: 0x06009CEB RID: 40171 RVA: 0x00215360 File Offset: 0x00213560
		private void #6Ge(#y0e #2Ge, #zDe #Gfb, #dEe #7Ge, IEnumerable<LoadPointDrawingData> #yjb, bool #3Ge)
		{
			switch (#7Ge.DrawOptions.CurrentUniCurveDrawingMode)
			{
			case #0Ie.#a:
				this.#8Ge(#2Ge, #Gfb, #7Ge, #yjb, #3Ge);
				return;
			case #0Ie.#b:
				this.#9Ge(#2Ge, #Gfb, #7Ge, #yjb, #3Ge);
				return;
			case #0Ie.#c:
				this.#aHe(#2Ge, #Gfb, #7Ge, #yjb, #3Ge);
				return;
			default:
				return;
			}
		}

		// Token: 0x06009CEC RID: 40172 RVA: 0x002153B8 File Offset: 0x002135B8
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void #8Ge(#y0e #2Ge, #zDe #Gfb, #dEe #7Ge, IEnumerable<LoadPointDrawingData> #yjb, bool #3Ge)
		{
			SvgDrawingDataCalculations.#iZb #iZb = new SvgDrawingDataCalculations.#iZb();
			#iZb.#a = #3Ge;
			#iZb.#b = this;
			List<ValueTuple<float, float>> source = this.#bHe(#yjb, #iZb.#a, #7Ge);
			if (source.Any<ValueTuple<float, float>>())
			{
				#Gfb.InteractionDiagramMinX = Math.Min(SvgDrawingDataCalculations.#cHe(#2Ge, true, #7Ge, new Func<UniCurve[], float>(SvgDrawingDataCalculations.<>c.<>9.#Sef), #iZb.#a), source.Min(new Func<ValueTuple<float, float>, float>(#iZb.#nff)));
				#Gfb.InteractionDiagramMinY = Math.Min(#7Ge.UniCurve.Min(new Func<UniCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#Vef)), source.Min(new Func<ValueTuple<float, float>, float>(#iZb.#off)));
				#Gfb.InteractionDiagramMaxX = Math.Max(SvgDrawingDataCalculations.#cHe(#2Ge, false, #7Ge, new Func<UniCurve[], float>(SvgDrawingDataCalculations.<>c.<>9.#Wef), #iZb.#a), source.Max(new Func<ValueTuple<float, float>, float>(#iZb.#pff)));
				#Gfb.InteractionDiagramMaxY = Math.Max(#7Ge.UniCurve.Max(new Func<UniCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#Yef)), source.Max(new Func<ValueTuple<float, float>, float>(#iZb.#qff)));
				return;
			}
			SvgDrawingDataCalculations.#iHe(#2Ge, #Gfb, #7Ge, #iZb.#a);
		}

		// Token: 0x06009CED RID: 40173 RVA: 0x00215528 File Offset: 0x00213728
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void #9Ge(#y0e #2Ge, #zDe #Gfb, #dEe #7Ge, IEnumerable<LoadPointDrawingData> #yjb, bool #3Ge)
		{
			SvgDrawingDataCalculations.#BUb #BUb = new SvgDrawingDataCalculations.#BUb();
			#BUb.#a = #3Ge;
			#BUb.#b = this;
			List<ValueTuple<float, float>> source = this.#bHe(#yjb, #BUb.#a, #7Ge).Where(new Func<ValueTuple<float, float>, bool>(#BUb.#rff)).ToList<ValueTuple<float, float>>();
			if (source.Any<ValueTuple<float, float>>())
			{
				#Gfb.InteractionDiagramMinX = Math.Min(0f, source.Min(new Func<ValueTuple<float, float>, float>(#BUb.#sff)));
				#Gfb.InteractionDiagramMinY = Math.Min(#7Ge.UniCurve.Min(new Func<UniCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#Zef)), source.Min(new Func<ValueTuple<float, float>, float>(#BUb.#tff)));
				#Gfb.InteractionDiagramMaxX = Math.Max(SvgDrawingDataCalculations.#cHe(#2Ge, false, #7Ge, new Func<UniCurve[], float>(SvgDrawingDataCalculations.<>c.<>9.#0ef), #BUb.#a), source.Max(new Func<ValueTuple<float, float>, float>(#BUb.#uff)));
				#Gfb.InteractionDiagramMaxY = Math.Max(#7Ge.UniCurve.Max(new Func<UniCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#2ef)), source.Max(new Func<ValueTuple<float, float>, float>(#BUb.#vff)));
				return;
			}
			SvgDrawingDataCalculations.#iHe(#2Ge, #Gfb, #7Ge, #BUb.#a);
		}

		// Token: 0x06009CEE RID: 40174 RVA: 0x00215684 File Offset: 0x00213884
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void #aHe(#y0e #2Ge, #zDe #Gfb, #dEe #7Ge, IEnumerable<LoadPointDrawingData> #yjb, bool #3Ge)
		{
			SvgDrawingDataCalculations.#61b #61b = new SvgDrawingDataCalculations.#61b();
			#61b.#a = #3Ge;
			#61b.#b = this;
			List<ValueTuple<float, float>> source = this.#bHe(#yjb, #61b.#a, #7Ge).Where(new Func<ValueTuple<float, float>, bool>(#61b.#wff)).ToList<ValueTuple<float, float>>();
			if (source.Any<ValueTuple<float, float>>())
			{
				#Gfb.InteractionDiagramMinX = Math.Min(SvgDrawingDataCalculations.#cHe(#2Ge, true, #7Ge, new Func<UniCurve[], float>(SvgDrawingDataCalculations.<>c.<>9.#3ef), #61b.#a), source.Min(new Func<ValueTuple<float, float>, float>(#61b.#xff)));
				#Gfb.InteractionDiagramMinY = Math.Min(#7Ge.UniCurve.Min(new Func<UniCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#5ef)), source.Min(new Func<ValueTuple<float, float>, float>(#61b.#yff)));
				#Gfb.InteractionDiagramMaxX = Math.Max(0f, source.Max(new Func<ValueTuple<float, float>, float>(#61b.#zff)));
				#Gfb.InteractionDiagramMaxY = Math.Max(#7Ge.UniCurve.Max(new Func<UniCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#6ef)), source.Max(new Func<ValueTuple<float, float>, float>(#61b.#Aff)));
				return;
			}
			SvgDrawingDataCalculations.#iHe(#2Ge, #Gfb, #7Ge, #61b.#a);
		}

		// Token: 0x06009CEF RID: 40175 RVA: 0x002157E0 File Offset: 0x002139E0
		[MethodImpl(MethodImplOptions.NoOptimization)]
		[return: TupleElementNames(new string[]
		{
			"AxialLoad",
			"LoadLength"
		})]
		private List<ValueTuple<float, float>> #bHe(IEnumerable<LoadPointDrawingData> #yjb, bool #3Ge, #dEe #7Ge)
		{
			SvgDrawingDataCalculations.#8Ub #8Ub = new SvgDrawingDataCalculations.#8Ub();
			#8Ub.#a = #7Ge;
			#8Ub.#b = #3Ge;
			return #yjb.Where(new Func<LoadPointDrawingData, bool>(#8Ub.#Bff)).Select(new Func<LoadPointDrawingData, ValueTuple<float, float>>(#8Ub.#Cff)).ToList<ValueTuple<float, float>>();
		}

		// Token: 0x06009CF0 RID: 40176 RVA: 0x0021582C File Offset: 0x00213A2C
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private static float #cHe(#y0e #2Ge, bool #dHe, #dEe #7Ge, Func<UniCurve[], float> #eHe, bool #3Ge)
		{
			bool flag = #7Ge.DrawOptions.TypeOfDrawing != #uCe.#a && #7Ge.DrawOptions.TypeOfDrawing != #uCe.#b;
			if (#dHe)
			{
				if (!#3Ge || !flag)
				{
					return #eHe(#7Ge.UniCurve);
				}
				return -#2Ge.BiCurve.Max(new Func<BiCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#7ef));
			}
			else
			{
				if (!#3Ge || !flag)
				{
					return #eHe(#7Ge.UniCurve);
				}
				return #2Ge.BiCurve.Max(new Func<BiCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#8ef));
			}
		}

		// Token: 0x06009CF1 RID: 40177 RVA: 0x002158DC File Offset: 0x00213ADC
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private static float #fHe(float[] #gHe, float[] #hHe)
		{
			float num = 0f;
			for (int i = 0; i < #gHe.Length; i++)
			{
				float num2 = (float)Math.Sqrt(Math.Pow((double)#gHe[i], 2.0) + Math.Pow((double)#hHe[i], 2.0));
				num = ((num2 > num) ? num2 : num);
			}
			return num;
		}

		// Token: 0x06009CF2 RID: 40178 RVA: 0x00215934 File Offset: 0x00213B34
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private static void #iHe(#y0e #2Ge, #zDe #Gfb, #dEe #7Ge, bool #3Ge)
		{
			#0Ie #0Ie = #7Ge.DrawOptions.CurrentUniCurveDrawingMode;
			bool flag = #7Ge.DrawOptions.TypeOfDrawing != #uCe.#a && #7Ge.DrawOptions.TypeOfDrawing != #uCe.#b;
			float num;
			if (!#3Ge || !flag)
			{
				num = #7Ge.UniCurve.Min(new Func<UniCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#aff));
			}
			else
			{
				num = #2Ge.BiCurve.Min(new Func<BiCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#9ef));
			}
			float num2 = num;
			#Gfb.InteractionDiagramMinX = ((#0Ie == #0Ie.#b) ? 0f : num2);
			float num3;
			if (!#3Ge || !flag)
			{
				num3 = #7Ge.UniCurve.Max(new Func<UniCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#cff));
			}
			else
			{
				num3 = #2Ge.BiCurve.Max(new Func<BiCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#bff));
			}
			float num4 = num3;
			#Gfb.InteractionDiagramMinY = #7Ge.UniCurve.Min(new Func<UniCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#dff));
			#Gfb.InteractionDiagramMaxX = ((#0Ie == #0Ie.#c) ? 0f : num4);
			#Gfb.InteractionDiagramMaxY = #7Ge.UniCurve.Max(new Func<UniCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#eff));
		}

		// Token: 0x06009CF3 RID: 40179 RVA: 0x0007BB35 File Offset: 0x00079D35
		private void #6Ge(#y0e #2Ge, #zDe #Gfb, BiCurve #7Ge, IList<LoadPointDrawingData> #yjb, float #Udb, bool #3Ge)
		{
			if (#3Ge)
			{
				this.#jHe(#2Ge, #Gfb, #yjb);
				return;
			}
			this.#kHe(#Gfb, #7Ge, #yjb, #Udb);
		}

		// Token: 0x06009CF4 RID: 40180 RVA: 0x00215AAC File Offset: 0x00213CAC
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void #jHe(#y0e #2Ge, #zDe #Gfb, IList<LoadPointDrawingData> #yjb)
		{
			if (#yjb.Any<LoadPointDrawingData>())
			{
				float #WTc = Math.Min(#2Ge.BiCurve.Min(new Func<BiCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#fff)), #yjb.Min(new Func<LoadPointDrawingData, float>(this.#IHe)));
				float #YTc = Math.Min(#2Ge.BiCurve.Min(new Func<BiCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#gff)), #yjb.Min(new Func<LoadPointDrawingData, float>(this.#JHe)));
				float #XTc = Math.Max(#2Ge.BiCurve.Max(new Func<BiCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#hff)), #yjb.Max(new Func<LoadPointDrawingData, float>(this.#KHe)));
				float #ZTc = Math.Max(#2Ge.BiCurve.Max(new Func<BiCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#iff)), #yjb.Max(new Func<LoadPointDrawingData, float>(this.#LHe)));
				this.#lHe(#Gfb, #WTc, #YTc, #XTc, #ZTc);
				return;
			}
			float #WTc2 = #2Ge.BiCurve.Min(new Func<BiCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#jff));
			float #YTc2 = #2Ge.BiCurve.Min(new Func<BiCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#kff));
			float #XTc2 = #2Ge.BiCurve.Max(new Func<BiCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#lff));
			float #ZTc2 = #2Ge.BiCurve.Max(new Func<BiCurve, float>(SvgDrawingDataCalculations.<>c.<>9.#mff));
			this.#lHe(#Gfb, #WTc2, #YTc2, #XTc2, #ZTc2);
		}

		// Token: 0x06009CF5 RID: 40181 RVA: 0x00215C98 File Offset: 0x00213E98
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void #kHe(#zDe #Gfb, BiCurve #7Ge, IEnumerable<LoadPointDrawingData> #yjb, float #Udb)
		{
			SvgDrawingDataCalculations.#wWb #wWb = new SvgDrawingDataCalculations.#wWb();
			#wWb.#a = #Udb;
			#wWb.#b = this;
			List<LoadPointDrawingData> source = #yjb.Where(new Func<LoadPointDrawingData, bool>(#wWb.#Dff)).ToList<LoadPointDrawingData>();
			if (source.Any<LoadPointDrawingData>())
			{
				float #WTc = Math.Min(#7Ge.MomentX.Min(), source.Min(new Func<LoadPointDrawingData, float>(#wWb.#Eff)));
				float #YTc = Math.Min(#7Ge.MomentY.Min(), source.Min(new Func<LoadPointDrawingData, float>(#wWb.#Fff)));
				float #XTc = Math.Max(#7Ge.MomentX.Max(), source.Max(new Func<LoadPointDrawingData, float>(#wWb.#Gff)));
				float #ZTc = Math.Max(#7Ge.MomentY.Max(), source.Max(new Func<LoadPointDrawingData, float>(#wWb.#Hff)));
				this.#lHe(#Gfb, #WTc, #YTc, #XTc, #ZTc);
			}
			else
			{
				float #WTc2 = #7Ge.MomentX.Min();
				float #YTc2 = #7Ge.MomentY.Min();
				float #XTc2 = #7Ge.MomentX.Max();
				float #ZTc2 = #7Ge.MomentY.Max();
				this.#lHe(#Gfb, #WTc2, #YTc2, #XTc2, #ZTc2);
			}
			#Gfb.InteractionDiagramMinX = ((Math.Abs(#Gfb.InteractionDiagramMinX) > 1f) ? #Gfb.InteractionDiagramMinX : -1f);
			#Gfb.InteractionDiagramMaxX = ((Math.Abs(#Gfb.InteractionDiagramMaxX) > 1f) ? #Gfb.InteractionDiagramMaxX : 1f);
			#Gfb.InteractionDiagramMinY = ((Math.Abs(#Gfb.InteractionDiagramMinY) > 1f) ? #Gfb.InteractionDiagramMinY : -1f);
			#Gfb.InteractionDiagramMaxY = ((Math.Abs(#Gfb.InteractionDiagramMaxY) > 1f) ? #Gfb.InteractionDiagramMaxY : 1f);
		}

		// Token: 0x06009CF6 RID: 40182 RVA: 0x00215E54 File Offset: 0x00214054
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void #lHe(#zDe #Gfb, float #WTc, float #YTc, float #XTc, float #ZTc)
		{
			float num = Math.Max(Math.Max(Math.Abs(#WTc), Math.Abs(#XTc)), Math.Max(Math.Abs(#YTc), Math.Abs(#ZTc)));
			#Gfb.InteractionDiagramMinX = num;
			#Gfb.InteractionDiagramMinY = num;
			#Gfb.InteractionDiagramMaxX = num;
			#Gfb.InteractionDiagramMaxY = num;
		}

		// Token: 0x06009CF7 RID: 40183 RVA: 0x00215EA8 File Offset: 0x002140A8
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void #mHe(#zDe #Gfb, #0Ie #pNb)
		{
			#Gfb.BorderWithMarginsWidth = this.#b;
			#Gfb.BorderWithMarginsHeight = this.#c;
			float num = (float)this.#f.#zvb(#Phc.#3hc(107314427)).Width;
			#Gfb.DiagramBorderWidth = #Gfb.BorderWithMarginsWidth - num * 2f;
			#Gfb.DiagramBorderWidth = ((#Gfb.DiagramBorderWidth > 1f) ? #Gfb.DiagramBorderWidth : 1f);
			#Gfb.DiagramBorderHeight = #Gfb.BorderWithMarginsHeight - num * 2f;
			#Gfb.DiagramBorderHeight = ((#Gfb.DiagramBorderHeight > 1f) ? #Gfb.DiagramBorderHeight : 1f);
			this.#pHe(#Gfb, #pNb, num);
			this.#nHe(#Gfb, num);
		}

		// Token: 0x06009CF8 RID: 40184 RVA: 0x00215F68 File Offset: 0x00214168
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void #nHe(#zDe #Gfb, float #oHe)
		{
			#Gfb.AxialLoadScalingFactor = #Gfb.DiagramBorderHeight / this.#uHe((double)#Gfb.InteractionDiagramMinY, (double)#Gfb.InteractionDiagramMaxY, true, 0.0);
			#Gfb.AxialLoadScalingFactor = #Gfb.DiagramBorderHeight / this.#uHe((double)#Gfb.InteractionDiagramMinY, (double)#Gfb.InteractionDiagramMaxY, false, (double)#Gfb.AxialLoadScalingFactor);
			float num = this.#BHe((double)((#Gfb.InteractionDiagramMaxY - #Gfb.InteractionDiagramMinY) / 2f), true, (double)#Gfb.AxialLoadScalingFactor);
			#Gfb.AxialLoadScalingFactor = #Gfb.DiagramBorderHeight / SvgDrawingDataCalculations.#zHe((double)#Gfb.InteractionDiagramMinY, (double)#Gfb.InteractionDiagramMaxY, num);
			#Gfb.AxisIntervalY = num * #Gfb.AxialLoadScalingFactor;
			#Gfb.DiagramBorderMinY = -SvgDrawingDataCalculations.#HHe((double)(Math.Abs(#Gfb.InteractionDiagramMinY) * #Gfb.AxialLoadScalingFactor), #Gfb.AxisIntervalY);
			#Gfb.DiagramBorderMaxY = #Gfb.DiagramBorderMinY + #Gfb.DiagramBorderHeight;
			#Gfb.BorderWithMarginsMaxY = #Gfb.DiagramBorderMaxY + #oHe;
			#Gfb.BorderWithMarginsMinY = #Gfb.DiagramBorderMinY - #oHe;
		}

		// Token: 0x06009CF9 RID: 40185 RVA: 0x0007BB52 File Offset: 0x00079D52
		private void #pHe(#zDe #Gfb, #0Ie #pNb, float #oHe)
		{
			switch (#pNb)
			{
			case #0Ie.#a:
				this.#qHe(#Gfb, #oHe);
				return;
			case #0Ie.#b:
				this.#rHe(#Gfb, #oHe);
				return;
			case #0Ie.#c:
				this.#sHe(#Gfb, #oHe);
				return;
			default:
				return;
			}
		}

		// Token: 0x06009CFA RID: 40186 RVA: 0x00216070 File Offset: 0x00214270
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void #qHe(#zDe #Gfb, float #oHe)
		{
			#Gfb.MomentsScalingFactor = #Gfb.DiagramBorderWidth / this.#uHe((double)#Gfb.InteractionDiagramMinX, (double)#Gfb.InteractionDiagramMaxX, true, 0.0);
			#Gfb.MomentsScalingFactor = #Gfb.DiagramBorderWidth / this.#uHe((double)#Gfb.InteractionDiagramMinX, (double)#Gfb.InteractionDiagramMaxX, false, (double)#Gfb.MomentsScalingFactor);
			float num = this.#BHe((double)(Math.Abs(#Gfb.InteractionDiagramMaxX - #Gfb.InteractionDiagramMinX) / 2f), true, (double)#Gfb.MomentsScalingFactor);
			#Gfb.MomentsScalingFactor = #Gfb.DiagramBorderWidth / SvgDrawingDataCalculations.#zHe((double)#Gfb.InteractionDiagramMinX, (double)#Gfb.InteractionDiagramMaxX, num);
			#Gfb.AxisIntervalX = num * #Gfb.MomentsScalingFactor;
			#Gfb.DiagramBorderMinX = -SvgDrawingDataCalculations.#HHe((double)(Math.Abs(#Gfb.InteractionDiagramMinX) * #Gfb.MomentsScalingFactor), #Gfb.AxisIntervalX);
			#Gfb.DiagramBorderMaxX = #Gfb.DiagramBorderMinX + #Gfb.DiagramBorderWidth;
			#Gfb.BorderWithMarginsMaxX = #Gfb.DiagramBorderMaxX + #oHe;
			#Gfb.BorderWithMarginsMinX = #Gfb.DiagramBorderMinX - #oHe;
		}

		// Token: 0x06009CFB RID: 40187 RVA: 0x0021617C File Offset: 0x0021437C
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void #rHe(#zDe #Gfb, float #oHe)
		{
			#Gfb.DiagramBorderMinX = -this.#a.GridLineThickness / 2f;
			#Gfb.DiagramBorderMaxX = #Gfb.DiagramBorderWidth;
			#Gfb.BorderWithMarginsMinX = -this.#a.GridLineThickness / 2f - #oHe;
			#Gfb.BorderWithMarginsMaxX = #Gfb.BorderWithMarginsWidth + #oHe;
			#Gfb.MomentsScalingFactor = #Gfb.DiagramBorderWidth / this.#uHe((double)Math.Abs(#Gfb.InteractionDiagramMaxX), true, 0.0);
			#Gfb.MomentsScalingFactor = #Gfb.DiagramBorderWidth / this.#uHe((double)Math.Abs(#Gfb.InteractionDiagramMaxX), false, (double)#Gfb.MomentsScalingFactor);
			float num = this.#BHe((double)(#Gfb.InteractionDiagramMaxX / 2f), true, (double)#Gfb.MomentsScalingFactor);
			#Gfb.MomentsScalingFactor = #Gfb.DiagramBorderWidth / SvgDrawingDataCalculations.#zHe((double)#Gfb.InteractionDiagramMaxX, num);
			#Gfb.AxisIntervalX = num * #Gfb.MomentsScalingFactor;
		}

		// Token: 0x06009CFC RID: 40188 RVA: 0x0021626C File Offset: 0x0021446C
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void #sHe(#zDe #Gfb, float #oHe)
		{
			#Gfb.DiagramBorderMinX = -#Gfb.DiagramBorderWidth;
			#Gfb.DiagramBorderMaxX = this.#a.GridLineThickness / 2f;
			#Gfb.BorderWithMarginsMinX = -#Gfb.BorderWithMarginsWidth + #oHe;
			#Gfb.BorderWithMarginsMaxX = this.#a.GridLineThickness / 2f + #oHe;
			#Gfb.MomentsScalingFactor = #Gfb.DiagramBorderWidth / this.#uHe((double)Math.Abs(#Gfb.InteractionDiagramMinX), true, 0.0);
			#Gfb.MomentsScalingFactor = #Gfb.DiagramBorderWidth / this.#uHe((double)Math.Abs(#Gfb.InteractionDiagramMinX), false, (double)#Gfb.MomentsScalingFactor);
			float num = this.#BHe((double)(Math.Abs(#Gfb.InteractionDiagramMinX) / 2f), true, (double)#Gfb.MomentsScalingFactor);
			#Gfb.MomentsScalingFactor = #Gfb.DiagramBorderWidth / SvgDrawingDataCalculations.#zHe((double)Math.Abs(#Gfb.InteractionDiagramMinX), num);
			#Gfb.AxisIntervalX = num * #Gfb.MomentsScalingFactor;
		}

		// Token: 0x06009CFD RID: 40189 RVA: 0x00216364 File Offset: 0x00214564
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private void #tHe(#zDe #Gfb)
		{
			#Gfb.BorderWithMarginsWidth = this.#b;
			#Gfb.BorderWithMarginsHeight = this.#c;
			float num = (float)this.#f.#zvb(#Phc.#3hc(107314427)).Width;
			#Gfb.DiagramBorderWidth = #Gfb.BorderWithMarginsWidth - num * 2f;
			#Gfb.DiagramBorderWidth = ((#Gfb.DiagramBorderWidth > 1f) ? #Gfb.DiagramBorderWidth : 1f);
			#Gfb.DiagramBorderHeight = #Gfb.BorderWithMarginsHeight - num * 2f;
			#Gfb.DiagramBorderHeight = ((#Gfb.DiagramBorderHeight > 1f) ? #Gfb.DiagramBorderHeight : 1f);
			float num2 = Math.Max(Math.Abs(#Gfb.InteractionDiagramMinX), Math.Abs(#Gfb.InteractionDiagramMaxX));
			float num3 = Math.Max(Math.Abs(#Gfb.InteractionDiagramMinY), Math.Abs(#Gfb.InteractionDiagramMaxY));
			#Gfb.MomentsScalingFactor = #Gfb.DiagramBorderWidth / this.#uHe((double)(-(double)num2), (double)num2, true, 0.0);
			#Gfb.AxialLoadScalingFactor = #Gfb.DiagramBorderHeight / this.#uHe((double)(-(double)num3), (double)num3, true, 0.0);
			#Gfb.MomentsScalingFactor = #Gfb.DiagramBorderWidth / this.#uHe((double)(-(double)num2), (double)num2, false, (double)#Gfb.MomentsScalingFactor);
			#Gfb.AxialLoadScalingFactor = #Gfb.DiagramBorderHeight / this.#uHe((double)(-(double)num3), (double)num3, false, (double)#Gfb.AxialLoadScalingFactor);
			float num4 = this.#BHe((double)num2, true, (double)#Gfb.MomentsScalingFactor);
			float num5 = this.#BHe((double)num3, true, (double)#Gfb.AxialLoadScalingFactor);
			#Gfb.MomentsScalingFactor = #Gfb.DiagramBorderWidth / SvgDrawingDataCalculations.#zHe((double)(-(double)num2), (double)num2, num4);
			#Gfb.AxialLoadScalingFactor = #Gfb.DiagramBorderHeight / SvgDrawingDataCalculations.#zHe((double)(-(double)num3), (double)num3, num5);
			#Gfb.AxisIntervalX = num4 * #Gfb.MomentsScalingFactor;
			#Gfb.AxisIntervalY = num5 * #Gfb.AxialLoadScalingFactor;
			#Gfb.DiagramBorderMinX = -SvgDrawingDataCalculations.#HHe((double)(num2 * #Gfb.MomentsScalingFactor), #Gfb.AxisIntervalX);
			#Gfb.DiagramBorderMinY = -SvgDrawingDataCalculations.#HHe((double)(num3 * #Gfb.AxialLoadScalingFactor), #Gfb.AxisIntervalY);
			#Gfb.DiagramBorderMaxX = #Gfb.DiagramBorderMinX + #Gfb.DiagramBorderWidth;
			#Gfb.DiagramBorderMaxY = #Gfb.DiagramBorderMinY + #Gfb.DiagramBorderHeight;
			#Gfb.BorderWithMarginsMinX = #Gfb.DiagramBorderMinX - num;
			#Gfb.BorderWithMarginsMinY = #Gfb.DiagramBorderMinY - num;
			#Gfb.BorderWithMarginsMaxX = #Gfb.DiagramBorderMaxX + num;
			#Gfb.BorderWithMarginsMaxY = #Gfb.DiagramBorderMaxY + num;
		}

		// Token: 0x06009CFE RID: 40190 RVA: 0x002165D4 File Offset: 0x002147D4
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private float #uHe(double #vHe, bool #wHe = true, double #Jvc = 0.0)
		{
			if (#wHe)
			{
				float #AHe = this.#BHe(#vHe / 2.0, false, 0.0);
				return SvgDrawingDataCalculations.#HHe(#vHe, #AHe);
			}
			float #AHe2 = this.#BHe(#vHe / 2.0, true, #Jvc);
			return SvgDrawingDataCalculations.#HHe(#vHe, #AHe2);
		}

		// Token: 0x06009CFF RID: 40191 RVA: 0x00216624 File Offset: 0x00214824
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private float #uHe(double #xHe, double #yHe, bool #wHe = true, double #Jvc = 0.0)
		{
			if (#wHe)
			{
				float #AHe = this.#BHe(Math.Abs(#yHe - #xHe) / 2.0, false, 0.0);
				return SvgDrawingDataCalculations.#HHe(Math.Abs(#yHe), #AHe) + SvgDrawingDataCalculations.#HHe(Math.Abs(#xHe), #AHe);
			}
			float #AHe2 = this.#BHe(Math.Abs(#yHe - #xHe) / 2.0, true, #Jvc);
			return SvgDrawingDataCalculations.#HHe(Math.Abs(#yHe), #AHe2) + SvgDrawingDataCalculations.#HHe(Math.Abs(#xHe), #AHe2);
		}

		// Token: 0x06009D00 RID: 40192 RVA: 0x0007BB81 File Offset: 0x00079D81
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private static float #zHe(double #xHe, double #yHe, float #AHe)
		{
			return SvgDrawingDataCalculations.#HHe(Math.Abs(#yHe), #AHe) + SvgDrawingDataCalculations.#HHe(Math.Abs(#xHe), #AHe);
		}

		// Token: 0x06009D01 RID: 40193 RVA: 0x0007BB9C File Offset: 0x00079D9C
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private static float #zHe(double #yHe, float #AHe)
		{
			return SvgDrawingDataCalculations.#HHe(Math.Abs(#yHe), #AHe);
		}

		// Token: 0x06009D02 RID: 40194 RVA: 0x002166A8 File Offset: 0x002148A8
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private float #BHe(double #CHe, bool #DHe = false, double #Jvc = 0.0)
		{
			double #FHe = Math.Floor(Math.Log10(#CHe) + 1.0);
			float num = this.#EHe(2, #FHe);
			float num2 = this.#EHe(5, #FHe);
			float num3 = this.#EHe(10, #FHe);
			float num4 = this.#EHe(20, #FHe);
			float result = this.#EHe(50, #FHe);
			if (this.#GHe(#CHe, (double)num, #DHe, #Jvc))
			{
				return num;
			}
			if (this.#GHe(#CHe, (double)num2, #DHe, #Jvc))
			{
				return num2;
			}
			if (this.#GHe(#CHe, (double)num3, #DHe, #Jvc))
			{
				return num3;
			}
			if (!this.#GHe(#CHe, (double)num4, #DHe, #Jvc))
			{
				return result;
			}
			return num4;
		}

		// Token: 0x06009D03 RID: 40195 RVA: 0x0007BBAA File Offset: 0x00079DAA
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private float #EHe(int #5ce, double #FHe)
		{
			return (float)#5ce * (float)Math.Pow(10.0, #FHe - 2.0);
		}

		// Token: 0x06009D04 RID: 40196 RVA: 0x0007BBC9 File Offset: 0x00079DC9
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private bool #GHe(double #CHe, double #AHe, bool #DHe, double #Jvc)
		{
			if (!#DHe)
			{
				return #CHe < 10.0 * #AHe;
			}
			return this.#f.#xJe(#AHe, #Jvc);
		}

		// Token: 0x06009D05 RID: 40197 RVA: 0x00216740 File Offset: 0x00214940
		[MethodImpl(MethodImplOptions.NoOptimization)]
		private static float #HHe(double #vHe, float #AHe)
		{
			float num = #AHe;
			while ((double)num - #vHe <= 0.01 && (double)Math.Abs(#AHe) > 1E-05)
			{
				num += #AHe;
			}
			return num;
		}

		// Token: 0x06009D06 RID: 40198 RVA: 0x0007BBEB File Offset: 0x00079DEB
		[CompilerGenerated]
		private float #IHe(LoadPointDrawingData #Rf)
		{
			return #Rf.MomentX - this.#d;
		}

		// Token: 0x06009D07 RID: 40199 RVA: 0x0007BBFA File Offset: 0x00079DFA
		[CompilerGenerated]
		private float #JHe(LoadPointDrawingData #Rf)
		{
			return #Rf.MomentY - this.#d;
		}

		// Token: 0x06009D08 RID: 40200 RVA: 0x0007BC09 File Offset: 0x00079E09
		[CompilerGenerated]
		private float #KHe(LoadPointDrawingData #Rf)
		{
			return #Rf.MomentX + this.#d;
		}

		// Token: 0x06009D09 RID: 40201 RVA: 0x0007BC18 File Offset: 0x00079E18
		[CompilerGenerated]
		private float #LHe(LoadPointDrawingData #Rf)
		{
			return #Rf.MomentY + this.#d;
		}

		// Token: 0x040043C6 RID: 17350
		private readonly #ZIe #a;

		// Token: 0x040043C7 RID: 17351
		private readonly float #b;

		// Token: 0x040043C8 RID: 17352
		private readonly float #c;

		// Token: 0x040043C9 RID: 17353
		private readonly float #d;

		// Token: 0x040043CA RID: 17354
		private readonly Diagram2DAspectRatio #e;

		// Token: 0x040043CB RID: 17355
		private readonly #CJe #f;

		// Token: 0x0200124C RID: 4684
		[CompilerGenerated]
		private sealed class #iZb
		{
			// Token: 0x06009D3C RID: 40252 RVA: 0x0007BD8F File Offset: 0x00079F8F
			internal float #nff([TupleElementNames(new string[]
			{
				"AxialLoad",
				"LoadLength"
			})] ValueTuple<float, float> #Rf)
			{
				if (!this.#a)
				{
					return #Rf.Item2 - this.#b.#d;
				}
				return -Math.Abs(#Rf.Item2) - this.#b.#d;
			}

			// Token: 0x06009D3D RID: 40253 RVA: 0x0007BDC4 File Offset: 0x00079FC4
			internal float #off([TupleElementNames(new string[]
			{
				"AxialLoad",
				"LoadLength"
			})] ValueTuple<float, float> #Rf)
			{
				return #Rf.Item1 - this.#b.#d;
			}

			// Token: 0x06009D3E RID: 40254 RVA: 0x0007BDD8 File Offset: 0x00079FD8
			internal float #pff([TupleElementNames(new string[]
			{
				"AxialLoad",
				"LoadLength"
			})] ValueTuple<float, float> #Rf)
			{
				if (!this.#a)
				{
					return #Rf.Item2 + this.#b.#d;
				}
				return Math.Abs(#Rf.Item2) + this.#b.#d;
			}

			// Token: 0x06009D3F RID: 40255 RVA: 0x0007BDC4 File Offset: 0x00079FC4
			internal float #qff([TupleElementNames(new string[]
			{
				"AxialLoad",
				"LoadLength"
			})] ValueTuple<float, float> #Rf)
			{
				return #Rf.Item1 - this.#b.#d;
			}

			// Token: 0x040043FC RID: 17404
			public bool #a;

			// Token: 0x040043FD RID: 17405
			public SvgDrawingDataCalculations #b;
		}

		// Token: 0x0200124D RID: 4685
		[CompilerGenerated]
		private sealed class #BUb
		{
			// Token: 0x06009D41 RID: 40257 RVA: 0x0007BE0C File Offset: 0x0007A00C
			internal bool #rff([TupleElementNames(new string[]
			{
				"AxialLoad",
				"LoadLength"
			})] ValueTuple<float, float> #Rf)
			{
				return this.#a || #Rf.Item2 >= 0f;
			}

			// Token: 0x06009D42 RID: 40258 RVA: 0x0007BE28 File Offset: 0x0007A028
			internal float #sff([TupleElementNames(new string[]
			{
				"AxialLoad",
				"LoadLength"
			})] ValueTuple<float, float> #Rf)
			{
				return #Rf.Item2 - this.#b.#d;
			}

			// Token: 0x06009D43 RID: 40259 RVA: 0x0007BE3C File Offset: 0x0007A03C
			internal float #tff([TupleElementNames(new string[]
			{
				"AxialLoad",
				"LoadLength"
			})] ValueTuple<float, float> #Rf)
			{
				return #Rf.Item1 - this.#b.#d;
			}

			// Token: 0x06009D44 RID: 40260 RVA: 0x0007BE50 File Offset: 0x0007A050
			internal float #uff([TupleElementNames(new string[]
			{
				"AxialLoad",
				"LoadLength"
			})] ValueTuple<float, float> #Rf)
			{
				if (!this.#a)
				{
					return #Rf.Item2 + this.#b.#d;
				}
				return Math.Abs(#Rf.Item2) + this.#b.#d;
			}

			// Token: 0x06009D45 RID: 40261 RVA: 0x0007BE3C File Offset: 0x0007A03C
			internal float #vff([TupleElementNames(new string[]
			{
				"AxialLoad",
				"LoadLength"
			})] ValueTuple<float, float> #Rf)
			{
				return #Rf.Item1 - this.#b.#d;
			}

			// Token: 0x040043FE RID: 17406
			public bool #a;

			// Token: 0x040043FF RID: 17407
			public SvgDrawingDataCalculations #b;
		}

		// Token: 0x0200124E RID: 4686
		[CompilerGenerated]
		private sealed class #61b
		{
			// Token: 0x06009D47 RID: 40263 RVA: 0x0007BE84 File Offset: 0x0007A084
			internal bool #wff([TupleElementNames(new string[]
			{
				"AxialLoad",
				"LoadLength"
			})] ValueTuple<float, float> #Rf)
			{
				return this.#a || #Rf.Item2 <= 0f;
			}

			// Token: 0x06009D48 RID: 40264 RVA: 0x0007BEA0 File Offset: 0x0007A0A0
			internal float #xff([TupleElementNames(new string[]
			{
				"AxialLoad",
				"LoadLength"
			})] ValueTuple<float, float> #Rf)
			{
				if (!this.#a)
				{
					return #Rf.Item2 - this.#b.#d;
				}
				return -Math.Abs(#Rf.Item2) - this.#b.#d;
			}

			// Token: 0x06009D49 RID: 40265 RVA: 0x0007BED5 File Offset: 0x0007A0D5
			internal float #yff([TupleElementNames(new string[]
			{
				"AxialLoad",
				"LoadLength"
			})] ValueTuple<float, float> #Rf)
			{
				return #Rf.Item1 - this.#b.#d;
			}

			// Token: 0x06009D4A RID: 40266 RVA: 0x0007BEE9 File Offset: 0x0007A0E9
			internal float #zff([TupleElementNames(new string[]
			{
				"AxialLoad",
				"LoadLength"
			})] ValueTuple<float, float> #Rf)
			{
				return #Rf.Item2 + this.#b.#d;
			}

			// Token: 0x06009D4B RID: 40267 RVA: 0x0007BED5 File Offset: 0x0007A0D5
			internal float #Aff([TupleElementNames(new string[]
			{
				"AxialLoad",
				"LoadLength"
			})] ValueTuple<float, float> #Rf)
			{
				return #Rf.Item1 - this.#b.#d;
			}

			// Token: 0x04004400 RID: 17408
			public bool #a;

			// Token: 0x04004401 RID: 17409
			public SvgDrawingDataCalculations #b;
		}

		// Token: 0x0200124F RID: 4687
		[CompilerGenerated]
		private sealed class #8Ub
		{
			// Token: 0x06009D4D RID: 40269 RVA: 0x00216778 File Offset: 0x00214978
			internal bool #Bff(LoadPointDrawingData #Rf)
			{
				return ((this.#a.DrawOptions.TypeOfDrawing == #uCe.#a || this.#a.DrawOptions.TypeOfDrawing == #uCe.#b) | this.#b) || DiagramGeneratorHelper.#SHe(#Rf, this.#a.DrawOptions.Parameter);
			}

			// Token: 0x06009D4E RID: 40270 RVA: 0x0007BEFD File Offset: 0x0007A0FD
			[return: TupleElementNames(new string[]
			{
				"AxialLoad",
				null
			})]
			internal ValueTuple<float, float> #Cff(LoadPointDrawingData #Rf)
			{
				return new ValueTuple<float, float>(#Rf.AxialLoad, DiagramGeneratorHelper.#UHe(#Rf, this.#a.DrawOptions.Parameter, this.#a.DrawOptions.TypeOfDrawing));
			}

			// Token: 0x04004402 RID: 17410
			public #dEe #a;

			// Token: 0x04004403 RID: 17411
			public bool #b;
		}

		// Token: 0x02001250 RID: 4688
		[CompilerGenerated]
		private sealed class #wWb
		{
			// Token: 0x06009D50 RID: 40272 RVA: 0x0007BF30 File Offset: 0x0007A130
			internal bool #Dff(LoadPointDrawingData #Rf)
			{
				return DiagramGeneratorHelper.#THe(#Rf, this.#a);
			}

			// Token: 0x06009D51 RID: 40273 RVA: 0x0007BF3E File Offset: 0x0007A13E
			internal float #Eff(LoadPointDrawingData #Rf)
			{
				return #Rf.MomentX - this.#b.#d;
			}

			// Token: 0x06009D52 RID: 40274 RVA: 0x0007BF52 File Offset: 0x0007A152
			internal float #Fff(LoadPointDrawingData #Rf)
			{
				return #Rf.MomentY - this.#b.#d;
			}

			// Token: 0x06009D53 RID: 40275 RVA: 0x0007BF66 File Offset: 0x0007A166
			internal float #Gff(LoadPointDrawingData #Rf)
			{
				return #Rf.MomentX + this.#b.#d;
			}

			// Token: 0x06009D54 RID: 40276 RVA: 0x0007BF7A File Offset: 0x0007A17A
			internal float #Hff(LoadPointDrawingData #Rf)
			{
				return #Rf.MomentY + this.#b.#d;
			}

			// Token: 0x04004404 RID: 17412
			public float #a;

			// Token: 0x04004405 RID: 17413
			public SvgDrawingDataCalculations #b;
		}
	}
}
