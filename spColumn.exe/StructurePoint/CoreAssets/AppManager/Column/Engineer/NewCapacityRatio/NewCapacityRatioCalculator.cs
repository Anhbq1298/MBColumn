using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #12e;
using #7hc;
using #9Ue;
using #gMe;
using #X7e;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.NewCapacityRatio
{
	// Token: 0x020012F0 RID: 4848
	internal sealed class NewCapacityRatioCalculator
	{
		// Token: 0x0600A20B RID: 41483 RVA: 0x0007ED1B File Offset: 0x0007CF1B
		public NewCapacityRatioCalculator(InputModel inputModel, RuntimeModel runtimeModel, #38e codeExpert, #3Qe momentCapacityEx)
		{
			this.#a = inputModel;
			this.#b = runtimeModel;
			this.#c = codeExpert;
			this.#d = momentCapacityEx;
		}

		// Token: 0x17002E94 RID: 11924
		// (get) Token: 0x0600A20C RID: 41484 RVA: 0x0007ED40 File Offset: 0x0007CF40
		private bool IsCriticalCapacity
		{
			get
			{
				return this.#a.Options.CapacityCalculationType == #x6e.#b;
			}
		}

		// Token: 0x0600A20D RID: 41485 RVA: 0x002290D0 File Offset: 0x002272D0
		public void #GVe(#l4e #Kwe)
		{
			for (int i = 0; i < #Kwe.CapacityData.LoadPoints.Count; i++)
			{
				LoadPointDrawingData loadPointDrawingData = #Kwe.CapacityData.LoadPoints[i];
				NewCapacityRatioCalculator.#Fhf #ib = new NewCapacityRatioCalculator.#Fhf
				{
					Parameters = loadPointDrawingData,
					Calculation = loadPointDrawingData.CapacityRatio,
					Angle = 0.0,
					OutputModel = #Kwe
				};
				bool #Ecb = this.#a.Options.ConsideredAxis == #C6e.#c;
				this.#KNe(#ib, #Ecb);
				loadPointDrawingData.IsInner = !loadPointDrawingData.CapacityRatio.IsExceeded;
			}
			CapacityRatioHelper.#nVe(this.#a, #Kwe);
		}

		// Token: 0x0600A20E RID: 41486 RVA: 0x0007ED55 File Offset: 0x0007CF55
		private void #KNe(NewCapacityRatioCalculator.#Fhf #ib, bool #Ecb)
		{
			this.#HVe(#ib, #Ecb);
			if (this.IsCriticalCapacity)
			{
				this.#IVe(#ib);
				return;
			}
			this.#JVe(#ib, #Ecb);
		}

		// Token: 0x0600A20F RID: 41487 RVA: 0x00229178 File Offset: 0x00227378
		private void #HVe(NewCapacityRatioCalculator.#Fhf #ib, bool #Ecb)
		{
			#ib.UniCurve = #ib.OutputModel.FactoredInteractionDiagram.UniCurve;
			if (#Ecb)
			{
				if (!this.IsCriticalCapacity)
				{
					#tPe #tPe = new #tPe(this.#a, this.#b, this.#c, this.#d);
					#ib.CustomUniCurve = #tPe.#3Oe(#ib.OutputModel.FactoredInteractionDiagram, #ib.Parameters.Angle, false);
					#ib.FilteredUniCurve = #MHe.#IH(#ib.CustomUniCurve);
				}
				#ib.Calculation.Mu = (float)Math.Sqrt(Math.Pow((double)#ib.Parameters.MomentX, 2.0) + Math.Pow((double)#ib.Parameters.MomentY, 2.0));
				return;
			}
			if (!this.IsCriticalCapacity)
			{
				#ib.FilteredUniCurve = #MHe.#IH(#ib.OutputModel.FactoredInteractionDiagram.UniCurve);
			}
			#ib.Calculation.Mu = (float)Math.Sqrt(Math.Pow((double)#ib.Parameters.MomentX, 2.0));
		}

		// Token: 0x0600A210 RID: 41488 RVA: 0x00229290 File Offset: 0x00227490
		private void #IVe(NewCapacityRatioCalculator.#Fhf #ib)
		{
			CapacityRatioCalculation capacityRatioCalculation = #ib.Calculation;
			LoadPointDrawingData loadPointDrawingData = #ib.OutputModel.CapacityData.#3hc(#ib.Parameters.Index);
			capacityRatioCalculation.PhiMnx = loadPointDrawingData.PhiMnx;
			capacityRatioCalculation.PhiMny = loadPointDrawingData.PhiMny;
			capacityRatioCalculation.#dNe(#ib.Parameters);
			double? num = capacityRatioCalculation.NumericValue;
			double num2 = 1.0;
			capacityRatioCalculation.IsExceeded = (num.GetValueOrDefault() >= num2 & num != null);
			capacityRatioCalculation.DisplayValue = capacityRatioCalculation.NumericValue.Value.ToString(#Phc.#3hc(107408811));
		}

		// Token: 0x0600A211 RID: 41489 RVA: 0x0007ED77 File Offset: 0x0007CF77
		private void #JVe(NewCapacityRatioCalculator.#Fhf #ib, bool #Ecb)
		{
			this.#QNe(#Ecb ? #ib.CustomUniCurve : #ib.UniCurve);
			this.#LVe(#ib);
		}

		// Token: 0x0600A212 RID: 41490 RVA: 0x00229338 File Offset: 0x00227538
		private void #QNe(UniCurve[] #UAe)
		{
			List<float> source = #UAe.Select(new Func<UniCurve, float>(NewCapacityRatioCalculator.<>c.<>9.#oXi)).Where(new Func<float, bool>(NewCapacityRatioCalculator.<>c.<>9.#pXi)).ToList<float>();
			this.#e = (source.Any<float>() ? Math.Abs(source.Min()) : 0f);
			this.#f = this.#b.ReductionFactors.#E1e(this.#a, this.#b, this.#c) * #UAe.Max(new Func<UniCurve, float>(NewCapacityRatioCalculator.<>c.<>9.#qXi));
		}

		// Token: 0x0600A213 RID: 41491 RVA: 0x00229404 File Offset: 0x00227604
		private bool #KVe(double #Tdb, UniCurve[] #UAe)
		{
			if (#Tdb < (double)this.#f)
			{
				if (#Tdb < (double)#UAe.Max(new Func<UniCurve, float>(NewCapacityRatioCalculator.<>c.<>9.#rXi)) && #Tdb > (double)(-(double)this.#e))
				{
					return #Tdb <= (double)#UAe.Min(new Func<UniCurve, float>(NewCapacityRatioCalculator.<>c.<>9.#sXi));
				}
			}
			return true;
		}

		// Token: 0x0600A214 RID: 41492 RVA: 0x00229480 File Offset: 0x00227680
		private void #LVe(NewCapacityRatioCalculator.#Fhf #ib)
		{
			UniCurve[] array = #ib.FilteredUniCurve;
			CapacityRatioCalculation capacityRatioCalculation = #ib.Calculation;
			LoadPointDrawingData loadPointDrawingData = #ib.Parameters;
			if (array == null || !array.Any<UniCurve>())
			{
				return;
			}
			if (this.#KVe((double)loadPointDrawingData.AxialLoad, array))
			{
				capacityRatioCalculation.#bNe();
				capacityRatioCalculation.Flags = ((loadPointDrawingData.AxialLoad >= 0f) ? (this.#a.DesignCode.IsCodeAci ? #YNe.#c : #YNe.#d) : (this.#a.DesignCode.IsCodeAci ? #YNe.#e : #YNe.#f));
				return;
			}
			LoadPointDrawingData loadPointDrawingData2 = #ib.OutputModel.CapacityData.#3hc(loadPointDrawingData.Index);
			if (loadPointDrawingData2 != null)
			{
				this.#OVe(loadPointDrawingData2, array, capacityRatioCalculation);
				return;
			}
			capacityRatioCalculation.#bNe();
			capacityRatioCalculation.Flags = #YNe.#b;
		}

		// Token: 0x0600A215 RID: 41493 RVA: 0x00229538 File Offset: 0x00227738
		private float #MVe(LoadPointDrawingData #NVe, CapacityRatioCalculation #sye)
		{
			if (this.#a.Options.ConsideredAxis.#hce())
			{
				return #sye.Mu;
			}
			if (#NVe.MomentX >= 0f && #NVe.MomentY >= 0f)
			{
				return #sye.Mu;
			}
			return -#sye.Mu;
		}

		// Token: 0x0600A216 RID: 41494 RVA: 0x0022958C File Offset: 0x0022778C
		private void #OVe(LoadPointDrawingData #NVe, UniCurve[] #UAe, CapacityRatioCalculation #sye)
		{
			NewCapacityRatioCalculator.#i9b #i9b = new NewCapacityRatioCalculator.#i9b();
			#i9b.#b = #NVe;
			float #XEe = this.#MVe(#i9b.#b, #sye);
			float[] array = new float[2];
			#i9b.#a = #UAe.Aggregate(new Func<UniCurve, UniCurve, UniCurve>(NewCapacityRatioCalculator.<>c.<>9.#tXi)).AxialLoad;
			if ((double)Math.Abs(#i9b.#b.AxialLoad - #i9b.#a) < 0.01)
			{
				array[0] = #UAe.Where(new Func<UniCurve, bool>(#i9b.#Shf)).Select(new Func<UniCurve, float>(NewCapacityRatioCalculator.<>c.<>9.#uXi)).First<float>();
				array[1] = #UAe.Where(new Func<UniCurve, bool>(#i9b.#Thf)).Select(new Func<UniCurve, float>(NewCapacityRatioCalculator.<>c.<>9.#vXi)).First<float>();
			}
			else
			{
				UniCurve #QVe = #UAe.Where(new Func<UniCurve, bool>(#i9b.#Uhf)).Aggregate(new Func<UniCurve, UniCurve, UniCurve>(NewCapacityRatioCalculator.<>c.<>9.#wXi));
				UniCurve #RVe = #UAe.Where(new Func<UniCurve, bool>(#i9b.#Vhf)).Aggregate(new Func<UniCurve, UniCurve, UniCurve>(NewCapacityRatioCalculator.<>c.<>9.#xXi));
				array = this.#PVe(#i9b.#b, #QVe, #RVe);
			}
			this.#SVe(array[0], array[1], #XEe, #i9b.#b, #sye);
		}

		// Token: 0x0600A217 RID: 41495 RVA: 0x00229720 File Offset: 0x00227920
		private float[] #PVe(LoadPointDrawingData #NVe, UniCurve #QVe, UniCurve #RVe)
		{
			float num = #QVe.NegativeSide.Moment + (float)Math.Abs((decimal)#QVe.AxialLoad - (decimal)#NVe.AxialLoad) / (float)Math.Abs((decimal)(#QVe.AxialLoad - #NVe.AxialLoad) - (decimal)(#RVe.AxialLoad - #NVe.AxialLoad)) * (#RVe.NegativeSide.Moment - #QVe.NegativeSide.Moment);
			float num2 = #QVe.PositiveSide.Moment + (float)Math.Abs((decimal)#QVe.AxialLoad - (decimal)#NVe.AxialLoad) / (float)Math.Abs((decimal)(#QVe.AxialLoad - #NVe.AxialLoad) - (decimal)(#RVe.AxialLoad - #NVe.AxialLoad)) * (#RVe.PositiveSide.Moment - #QVe.PositiveSide.Moment);
			return new float[]
			{
				num,
				num2
			};
		}

		// Token: 0x0600A218 RID: 41496 RVA: 0x0007ED97 File Offset: 0x0007CF97
		private void #SVe(float #TVe, float #UVe, float #XEe, LoadPointDrawingData #NVe, CapacityRatioCalculation #sye)
		{
			if (#TVe * #UVe >= 0f)
			{
				this.#VVe(#TVe, #UVe, #XEe, #sye);
			}
			else
			{
				this.#WVe(#XEe, #NVe, #sye);
			}
			#sye.PhiPn = new float?(#NVe.AxialLoad);
		}

		// Token: 0x0600A219 RID: 41497 RVA: 0x0022983C File Offset: 0x00227A3C
		private void #VVe(float #TVe, float #UVe, float #XEe, CapacityRatioCalculation #sye)
		{
			if (#XEe >= #TVe && #XEe <= #UVe)
			{
				#sye.#cNe();
			}
			else
			{
				#sye.#bNe();
			}
			#sye.NumericValue = null;
			#sye.Flags = (this.#a.DesignCode.IsCodeAci ? #YNe.#g : #YNe.#h);
		}

		// Token: 0x0600A21A RID: 41498 RVA: 0x00229890 File Offset: 0x00227A90
		private void #WVe(float #XEe, LoadPointDrawingData #NVe, CapacityRatioCalculation #sye)
		{
			float num = (float)Math.Sqrt(Math.Pow((double)#NVe.PhiMnx.GetValueOrDefault(), 2.0) + Math.Pow((double)#NVe.PhiMny.GetValueOrDefault(), 2.0));
			#sye.PhiMn = new float?((#XEe < 0f && this.#a.Options.ConsideredAxis.#Cpe()) ? (-num) : num);
			#sye.Phi = #NVe.Phi;
			#sye.EpsilonT = #NVe.Eps;
			#sye.NaDepth = #NVe.Nadepth;
			#sye.Flags = #YNe.#a;
			float? num2 = #XEe / #sye.PhiMn;
			#sye.NumericValue = new double?(((double)num2.Value > 999.999) ? 999.999 : ((double)num2.Value));
			#sye.DisplayValue = (((double)num2.Value > 999.999) ? #Phc.#3hc(107313621) : #sye.NumericValue.Value.ToString(#Phc.#3hc(107408811)));
			double? num3 = #sye.NumericValue;
			double num4 = 1.0;
			#sye.IsExceeded = (num3.GetValueOrDefault() >= num4 & num3 != null);
		}

		// Token: 0x040046E4 RID: 18148
		private readonly InputModel #a;

		// Token: 0x040046E5 RID: 18149
		private readonly RuntimeModel #b;

		// Token: 0x040046E6 RID: 18150
		private readonly #38e #c;

		// Token: 0x040046E7 RID: 18151
		private readonly #3Qe #d;

		// Token: 0x040046E8 RID: 18152
		private float #e;

		// Token: 0x040046E9 RID: 18153
		private float #f;

		// Token: 0x020012F1 RID: 4849
		private sealed class #Fhf
		{
			// Token: 0x17002E95 RID: 11925
			// (get) Token: 0x0600A21B RID: 41499 RVA: 0x0007EDCE File Offset: 0x0007CFCE
			// (set) Token: 0x0600A21C RID: 41500 RVA: 0x0007EDD6 File Offset: 0x0007CFD6
			public #l4e OutputModel { get; set; }

			// Token: 0x17002E96 RID: 11926
			// (get) Token: 0x0600A21D RID: 41501 RVA: 0x0007EDDF File Offset: 0x0007CFDF
			// (set) Token: 0x0600A21E RID: 41502 RVA: 0x0007EDE7 File Offset: 0x0007CFE7
			public LoadPointDrawingData Parameters { get; set; }

			// Token: 0x17002E97 RID: 11927
			// (get) Token: 0x0600A21F RID: 41503 RVA: 0x0007EDF0 File Offset: 0x0007CFF0
			// (set) Token: 0x0600A220 RID: 41504 RVA: 0x0007EDF8 File Offset: 0x0007CFF8
			public CapacityRatioCalculation Calculation { get; set; }

			// Token: 0x17002E98 RID: 11928
			// (get) Token: 0x0600A221 RID: 41505 RVA: 0x0007EE01 File Offset: 0x0007D001
			// (set) Token: 0x0600A222 RID: 41506 RVA: 0x0007EE09 File Offset: 0x0007D009
			public UniCurve[] UniCurve { get; set; }

			// Token: 0x17002E99 RID: 11929
			// (get) Token: 0x0600A223 RID: 41507 RVA: 0x0007EE12 File Offset: 0x0007D012
			// (set) Token: 0x0600A224 RID: 41508 RVA: 0x0007EE1A File Offset: 0x0007D01A
			public UniCurve[] CustomUniCurve { get; set; }

			// Token: 0x17002E9A RID: 11930
			// (get) Token: 0x0600A225 RID: 41509 RVA: 0x0007EE23 File Offset: 0x0007D023
			// (set) Token: 0x0600A226 RID: 41510 RVA: 0x0007EE2B File Offset: 0x0007D02B
			public UniCurve[] FilteredUniCurve { get; set; }

			// Token: 0x17002E9B RID: 11931
			// (get) Token: 0x0600A227 RID: 41511 RVA: 0x0007EE34 File Offset: 0x0007D034
			// (set) Token: 0x0600A228 RID: 41512 RVA: 0x0007EE3C File Offset: 0x0007D03C
			public double Angle { get; set; }

			// Token: 0x040046EA RID: 18154
			[CompilerGenerated]
			private #l4e #a;

			// Token: 0x040046EB RID: 18155
			[CompilerGenerated]
			private LoadPointDrawingData #b;

			// Token: 0x040046EC RID: 18156
			[CompilerGenerated]
			private CapacityRatioCalculation #c;

			// Token: 0x040046ED RID: 18157
			[CompilerGenerated]
			private UniCurve[] #d;

			// Token: 0x040046EE RID: 18158
			[CompilerGenerated]
			private UniCurve[] #e;

			// Token: 0x040046EF RID: 18159
			[CompilerGenerated]
			private UniCurve[] #f;

			// Token: 0x040046F0 RID: 18160
			[CompilerGenerated]
			private double #g;
		}

		// Token: 0x020012F3 RID: 4851
		[CompilerGenerated]
		private sealed class #i9b
		{
			// Token: 0x0600A237 RID: 41527 RVA: 0x0007EE94 File Offset: 0x0007D094
			internal bool #Shf(UniCurve #Rf)
			{
				return (double)Math.Abs(#Rf.AxialLoad - this.#a) < 0.01;
			}

			// Token: 0x0600A238 RID: 41528 RVA: 0x0007EE94 File Offset: 0x0007D094
			internal bool #Thf(UniCurve #Rf)
			{
				return (double)Math.Abs(#Rf.AxialLoad - this.#a) < 0.01;
			}

			// Token: 0x0600A239 RID: 41529 RVA: 0x0007EEB4 File Offset: 0x0007D0B4
			internal bool #Uhf(UniCurve #Rf)
			{
				return #Rf.AxialLoad < this.#b.AxialLoad;
			}

			// Token: 0x0600A23A RID: 41530 RVA: 0x0007EEC9 File Offset: 0x0007D0C9
			internal bool #Vhf(UniCurve #Rf)
			{
				return #Rf.AxialLoad > this.#b.AxialLoad;
			}

			// Token: 0x040046FC RID: 18172
			public float #a;

			// Token: 0x040046FD RID: 18173
			public LoadPointDrawingData #b;
		}
	}
}
