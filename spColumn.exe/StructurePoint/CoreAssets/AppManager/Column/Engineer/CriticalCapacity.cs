using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #gMe;
using #hZe;
using #X7e;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer
{
	// Token: 0x020012A2 RID: 4770
	internal sealed class CriticalCapacity
	{
		// Token: 0x06009FC6 RID: 40902 RVA: 0x0021EA70 File Offset: 0x0021CC70
		public CriticalCapacity(InputModel inputModel, RuntimeModel runtimeModel, #6Re moments, #nUe transformations, #fMe axialLoadAndMoment, #VPe loadMomentPairs, #fNe compressionAndTension, #3Qe momentCapacity, #38e codeExpert)
		{
			if (inputModel == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107313201));
			}
			this.#a = inputModel;
			if (runtimeModel == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107313152));
			}
			this.#b = runtimeModel;
			this.#c = momentCapacity;
			if (codeExpert == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107313647));
			}
			this.#d = codeExpert;
			this.#e = new #1Oe(inputModel, runtimeModel, moments, axialLoadAndMoment, transformations, loadMomentPairs, compressionAndTension, codeExpert);
		}

		// Token: 0x06009FC7 RID: 40903 RVA: 0x0007D897 File Offset: 0x0007BA97
		public #y0e #YJe()
		{
			return this.#e.#5ai();
		}

		// Token: 0x06009FC8 RID: 40904 RVA: 0x0021EAF8 File Offset: 0x0021CCF8
		public UniCurve[] #MWi(#y0e #Jte, double #0jb, double #1jb)
		{
			if (this.#a.Options.ConsideredAxis != #C6e.#c || this.#a.Options.CapacityCalculationType != #x6e.#a)
			{
				return null;
			}
			double num = Math.Atan2(#1jb, #0jb);
			num = (num * 180.0 / 3.141592653589793 + 360.0) % 360.0;
			UniCurve[] result;
			if (this.#b.DiagramsCache.#8ai(#Jte, (float)num, out result))
			{
				return result;
			}
			#tPe #tPe = new #tPe(this.#a, this.#b, this.#d, this.#c);
			#Jte.UniCurve = Enumerable.Range(0, 70).Select(new Func<int, UniCurve>(CriticalCapacity.<>c.<>9.#8Wi)).ToArray<UniCurve>();
			return #tPe.#3Oe(#Jte, (float)num, false);
		}

		// Token: 0x06009FC9 RID: 40905 RVA: 0x0021EBD4 File Offset: 0x0021CDD4
		public CapacityRatioCalculation #KNe(#y0e #Jte, double #0jb, double #1jb, double #Tdb)
		{
			CapacityRatioCalculation capacityRatioCalculation = new CapacityRatioCalculation();
			double num = Math.Atan2(#1jb, #0jb);
			num = (num * 180.0 / 3.141592653589793 + 360.0) % 360.0;
			UniCurve[] array = #Jte.UniCurve;
			if (this.#a.Options.ConsideredAxis == #C6e.#c)
			{
				#tPe #tPe = new #tPe(this.#a, this.#b, this.#d, this.#c);
				#Jte.UniCurve = UniCurve.#ul(70);
				array = #tPe.#3Oe(#Jte, (float)num, false);
			}
			capacityRatioCalculation.Mu = ((this.#a.Options.ConsideredAxis == #C6e.#c) ? ((float)Math.Sqrt(Math.Pow(#0jb, 2.0) + Math.Pow(#1jb, 2.0))) : ((this.#a.Options.ConsideredAxis == #C6e.#a) ? ((float)Math.Sqrt(Math.Pow(#0jb, 2.0))) : ((float)Math.Sqrt(Math.Pow(#1jb, 2.0)))));
			this.#QNe(array);
			IEnumerable<UniCurve> #UAe = this.#RNe(array);
			IList<UniCurve> #UAe2 = this.#TNe(#UAe);
			StructurePoint.CoreAssets.Infrastructure.Data.Point #ycb = this.#UNe(new StructurePoint.CoreAssets.Infrastructure.Data.Point((this.#a.Options.ConsideredAxis == #C6e.#c) ? ((double)capacityRatioCalculation.Mu) : ((this.#a.Options.ConsideredAxis == #C6e.#a) ? #0jb : #1jb), #Tdb));
			capacityRatioCalculation = this.#VNe(#UAe2, #ycb, capacityRatioCalculation);
			capacityRatioCalculation.NumericValue = CriticalCapacity.#PNe(capacityRatioCalculation.NumericValue);
			CapacityRatioCalculation capacityRatioCalculation2 = capacityRatioCalculation;
			double? num2 = capacityRatioCalculation.NumericValue;
			double num3 = 1.0;
			capacityRatioCalculation2.IsExceeded = !(num2.GetValueOrDefault() < num3 & num2 != null);
			CapacityRatioCalculation capacityRatioCalculation3 = capacityRatioCalculation;
			num2 = capacityRatioCalculation.NumericValue;
			capacityRatioCalculation3.DisplayValue = ((num2 != null) ? num2.GetValueOrDefault().ToString(#Phc.#3hc(107408811)) : null);
			if (this.#a.Options.ConsideredAxis == #C6e.#c)
			{
				capacityRatioCalculation = this.#WNe(capacityRatioCalculation, num);
			}
			else if (this.#a.Options.ConsideredAxis == #C6e.#a)
			{
				capacityRatioCalculation.PhiMnx = capacityRatioCalculation.PhiMn;
				capacityRatioCalculation.PhiMny = new float?(0f);
			}
			else if (this.#a.Options.ConsideredAxis == #C6e.#b)
			{
				capacityRatioCalculation.PhiMny = capacityRatioCalculation.PhiMn;
				capacityRatioCalculation.PhiMnx = new float?(0f);
			}
			return capacityRatioCalculation;
		}

		// Token: 0x06009FCA RID: 40906 RVA: 0x0021EE3C File Offset: 0x0021D03C
		private static CriticalCapacity.#Tgf #LNe(StructurePoint.CoreAssets.Infrastructure.Data.Point #ivb, StructurePoint.CoreAssets.Infrastructure.Data.Point #Xrb, StructurePoint.CoreAssets.Infrastructure.Data.Point #Yrb, CriticalCapacity.#Tgf #MNe)
		{
			if (#ivb.Y * #Xrb.Y >= 0.0 && #ivb.Y * #Yrb.Y >= 0.0 && #Xrb.X > 0.0 && #Yrb.X < 0.0)
			{
				if (#ivb.X * #Xrb.X > 0.0)
				{
					#Yrb.Y = #Xrb.Y + Math.Abs(#Xrb.X) / Math.Abs(#Xrb.X - #Yrb.X) * (#Yrb.Y - #Xrb.Y);
					#Yrb.X = 0.0;
				}
				else
				{
					#Xrb.Y += Math.Abs(#Xrb.X) / Math.Abs(#Xrb.X - #Yrb.X) * (#Yrb.Y - #Xrb.Y);
					#Xrb.X = 0.0;
				}
				return CriticalCapacity.#ONe(#ivb, #Xrb, #Yrb, #MNe);
			}
			if (#ivb.Y * #Xrb.Y >= 0.0 && #ivb.Y * #Yrb.Y >= 0.0 && #Xrb.X < 0.0 && #Yrb.X > 0.0)
			{
				if (#ivb.X * #Xrb.X > 0.0)
				{
					#Yrb.Y += Math.Abs(#Yrb.X) / Math.Abs(#Yrb.X - #Xrb.X) * (#Xrb.Y - #Yrb.Y);
					#Yrb.X = 0.0;
				}
				else
				{
					#Xrb.Y = #Yrb.Y + Math.Abs(#Yrb.X) / Math.Abs(#Yrb.X - #Xrb.X) * (#Xrb.Y - #Yrb.Y);
					#Xrb.X = 0.0;
				}
				return CriticalCapacity.#ONe(#ivb, #Xrb, #Yrb, #MNe);
			}
			if (#ivb.X == 0.0 && #ivb.Y == 0.0 && #Xrb.X >= 0.0 && #Xrb.Y >= 0.0 && #Yrb.X >= 0.0 && #Yrb.Y >= 0.0)
			{
				return CriticalCapacity.#ONe(#ivb, #Xrb, #Yrb, #MNe);
			}
			if ((#ivb.X == 0.0 && #ivb.Y * #Xrb.Y > 0.0 && #ivb.Y * #Yrb.Y > 0.0 && #Xrb.X >= 0.0 && #Yrb.X >= 0.0) || (#ivb.Y == 0.0 && #ivb.X * #Xrb.X > 0.0 && #ivb.X * #Yrb.X > 0.0 && #Xrb.Y >= 0.0 && #Yrb.Y >= 0.0))
			{
				return CriticalCapacity.#ONe(#ivb, #Xrb, #Yrb, #MNe);
			}
			if (#ivb.Y * #Xrb.Y >= 0.0 && #ivb.Y * #Yrb.Y >= 0.0 && #ivb.X * #Xrb.X > 0.0 && #ivb.X * #Yrb.X > 0.0 && ((#Yrb.Y == 0.0 && #ivb.Y >= 0.0) || (#Xrb.Y == 0.0 && #ivb.Y < 0.0)))
			{
				return CriticalCapacity.#ONe(#ivb, #Xrb, #Yrb, #MNe);
			}
			if (#ivb.Y * #Xrb.Y > 0.0 && #ivb.Y * #Yrb.Y > 0.0 && #ivb.X * #Xrb.X > 0.0 && #ivb.X * #Yrb.X > 0.0)
			{
				return CriticalCapacity.#ONe(#ivb, #Xrb, #Yrb, #MNe);
			}
			#MNe.Distance = double.MaxValue;
			return #MNe;
		}

		// Token: 0x06009FCB RID: 40907 RVA: 0x0021F334 File Offset: 0x0021D534
		private static int #NNe(StructurePoint.CoreAssets.Infrastructure.Data.Point #ivb, IList<UniCurve> #UAe)
		{
			List<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point> list = #UAe.Select(new Func<UniCurve, StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>(CriticalCapacity.<>c.<>9.#9Wi)).Union(#UAe.Select(new Func<UniCurve, StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>(CriticalCapacity.<>c.<>9.#aXi)).Reverse<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>()).Distinct(new CriticalCapacity.#Rgf()).ToList<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>();
			list.Add(list.First<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>());
			if (!GeometryHelper.#eoc(list.Select(new Func<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point, StructurePoint.CoreAssets.Infrastructure.Data.Point>(CriticalCapacity.<>c.<>9.#bXi)).ToList<StructurePoint.CoreAssets.Infrastructure.Data.Point>(), list.Count<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>(), #ivb))
			{
				return -1;
			}
			return 1;
		}

		// Token: 0x06009FCC RID: 40908 RVA: 0x0021F3EC File Offset: 0x0021D5EC
		private static CriticalCapacity.#Tgf #ONe(StructurePoint.CoreAssets.Infrastructure.Data.Point #ivb, StructurePoint.CoreAssets.Infrastructure.Data.Point #Xrb, StructurePoint.CoreAssets.Infrastructure.Data.Point #Yrb, CriticalCapacity.#Tgf #MNe)
		{
			StructurePoint.CoreAssets.Infrastructure.Data.Point? point = GeometryHelper.#Kmc(#Xrb, #Yrb, #ivb);
			#MNe.Distance = ((point != null) ? Math.Sqrt(Math.Pow(point.Value.X - #ivb.X, 2.0) + Math.Pow(point.Value.Y - #ivb.Y, 2.0)) : double.MaxValue);
			#MNe.X = ((point != null) ? point.GetValueOrDefault().X : 0.0);
			#MNe.Y = ((point != null) ? point.GetValueOrDefault().Y : 0.0);
			return #MNe;
		}

		// Token: 0x06009FCD RID: 40909 RVA: 0x0021F4C0 File Offset: 0x0021D6C0
		private static double? #PNe(double? #8Bb)
		{
			double? num = (double)1 - #8Bb;
			double? num2 = num;
			double num3 = (double)999;
			if (!(num2.GetValueOrDefault() > num3 & num2 != null))
			{
				return num;
			}
			return new double?((double)999);
		}

		// Token: 0x06009FCE RID: 40910 RVA: 0x0021F520 File Offset: 0x0021D720
		private void #QNe(UniCurve[] #UAe)
		{
			List<float> source = #UAe.Select(new Func<UniCurve, float>(CriticalCapacity.<>c.<>9.#cXi)).Where(new Func<float, bool>(CriticalCapacity.<>c.<>9.#dXi)).ToList<float>();
			this.#g = (source.Any<float>() ? Math.Abs(source.Min()) : 0f);
			this.#h = this.#b.ReductionFactors.#E1e(this.#a, this.#b, this.#d) * #UAe.Max(new Func<UniCurve, float>(CriticalCapacity.<>c.<>9.#eXi));
			this.#f = #UAe.Select(new Func<UniCurve, float>(CriticalCapacity.<>c.<>9.#fXi)).Union(#UAe.Select(new Func<UniCurve, float>(CriticalCapacity.<>c.<>9.#gXi))).Max();
		}

		// Token: 0x06009FCF RID: 40911 RVA: 0x0021F644 File Offset: 0x0021D844
		private IEnumerable<UniCurve> #RNe(IEnumerable<UniCurve> #SNe)
		{
			return #SNe.Select(new Func<UniCurve, UniCurve>(CriticalCapacity.<>c.<>9.#hXi)).Where(new Func<UniCurve, bool>(CriticalCapacity.<>c.<>9.#iXi));
		}

		// Token: 0x06009FD0 RID: 40912 RVA: 0x0021F69C File Offset: 0x0021D89C
		private IList<UniCurve> #TNe(IEnumerable<UniCurve> #UAe)
		{
			List<UniCurve> list = #UAe.Select(new Func<UniCurve, UniCurve>(CriticalCapacity.<>c.<>9.#jXi)).Where(new Func<UniCurve, bool>(this.#OWi)).ToList<UniCurve>();
			for (int i = 0; i < list.Count; i++)
			{
				UniCurve uniCurve = list[i];
				if (uniCurve.AxialLoad > 0f)
				{
					uniCurve.AxialLoad /= this.#h;
				}
				else
				{
					uniCurve.AxialLoad /= this.#g;
				}
				uniCurve.NegativeSide.Moment /= this.#f;
				uniCurve.PositiveSide.Moment /= this.#f;
			}
			return list;
		}

		// Token: 0x06009FD1 RID: 40913 RVA: 0x0021F768 File Offset: 0x0021D968
		private StructurePoint.CoreAssets.Infrastructure.Data.Point #UNe(StructurePoint.CoreAssets.Infrastructure.Data.Point #ycb)
		{
			if (#ycb.Y > 0.0)
			{
				#ycb.Y /= (double)this.#h;
			}
			else
			{
				#ycb.Y /= (double)this.#g;
			}
			#ycb.X /= (double)this.#f;
			return #ycb;
		}

		// Token: 0x06009FD2 RID: 40914 RVA: 0x0021F7CC File Offset: 0x0021D9CC
		private CapacityRatioCalculation #VNe(IList<UniCurve> #UAe, StructurePoint.CoreAssets.Infrastructure.Data.Point #ycb, CapacityRatioCalculation #sye)
		{
			double num = double.MaxValue;
			for (int i = 0; i < #UAe.Count; i++)
			{
				CriticalCapacity.#Tgf #Tgf = new CriticalCapacity.#Tgf();
				CriticalCapacity.#Tgf #Tgf2 = new CriticalCapacity.#Tgf();
				StructurePoint.CoreAssets.Infrastructure.Data.Point #Xrb;
				StructurePoint.CoreAssets.Infrastructure.Data.Point #Yrb;
				StructurePoint.CoreAssets.Infrastructure.Data.Point #Xrb2;
				StructurePoint.CoreAssets.Infrastructure.Data.Point #Yrb2;
				if (i == 0)
				{
					#Xrb = new StructurePoint.CoreAssets.Infrastructure.Data.Point((double)#UAe[i].PositiveSide.Moment, (double)#UAe[i].AxialLoad);
					#Yrb = new StructurePoint.CoreAssets.Infrastructure.Data.Point((double)#UAe[i].NegativeSide.Moment, (double)#UAe[i].AxialLoad);
					#Xrb2 = new StructurePoint.CoreAssets.Infrastructure.Data.Point((double)#UAe[i].NegativeSide.Moment, (double)#UAe[i].AxialLoad);
					#Yrb2 = new StructurePoint.CoreAssets.Infrastructure.Data.Point((double)#UAe[i].PositiveSide.Moment, (double)#UAe[i].AxialLoad);
				}
				else
				{
					#Xrb = new StructurePoint.CoreAssets.Infrastructure.Data.Point((double)#UAe[i - 1].NegativeSide.Moment, (double)#UAe[i - 1].AxialLoad);
					#Yrb = new StructurePoint.CoreAssets.Infrastructure.Data.Point((double)#UAe[i].NegativeSide.Moment, (double)#UAe[i].AxialLoad);
					#Xrb2 = new StructurePoint.CoreAssets.Infrastructure.Data.Point((double)#UAe[i - 1].PositiveSide.Moment, (double)#UAe[i - 1].AxialLoad);
					#Yrb2 = new StructurePoint.CoreAssets.Infrastructure.Data.Point((double)#UAe[i].PositiveSide.Moment, (double)#UAe[i].AxialLoad);
				}
				CriticalCapacity.#Tgf #Tgf3 = CriticalCapacity.#LNe(#ycb, #Xrb, #Yrb, #Tgf);
				CriticalCapacity.#Tgf #Tgf4 = CriticalCapacity.#LNe(#ycb, #Xrb2, #Yrb2, #Tgf2);
				if (#Tgf3.Distance < num)
				{
					num = #Tgf3.Distance;
					#sye.PhiMn = new float?((float)((double)this.#f * #Tgf.X));
					if (#ycb.Y >= 0.0)
					{
						#sye.PhiPn = new float?((float)((double)this.#h * #Tgf.Y));
					}
					else
					{
						#sye.PhiPn = new float?((float)((double)this.#g * #Tgf.Y));
					}
				}
				if (#Tgf4.Distance < num)
				{
					num = #Tgf4.Distance;
					#sye.PhiMn = new float?((float)((double)this.#f * #Tgf2.X));
					if (#ycb.Y >= 0.0)
					{
						#sye.PhiPn = new float?((float)((double)this.#h * #Tgf2.Y));
					}
					else
					{
						#sye.PhiPn = new float?((float)((double)this.#g * #Tgf2.Y));
					}
				}
			}
			int num2 = CriticalCapacity.#NNe(#ycb, #UAe);
			#sye.NumericValue = new double?(num * (double)num2);
			return #sye;
		}

		// Token: 0x06009FD3 RID: 40915 RVA: 0x0021FA68 File Offset: 0x0021DC68
		private CapacityRatioCalculation #WNe(CapacityRatioCalculation #sye, double #Udb)
		{
			if (#Udb == 0.0 || #Udb == 360.0)
			{
				#sye.PhiMny = new float?(0f);
				#sye.PhiMnx = #sye.PhiMn;
			}
			else if (#Udb > 0.0 && #Udb < 90.0)
			{
				#sye.PhiMnx = #sye.PhiMn * (float)Math.Cos(#Udb * 0.017453292519943295);
				#sye.PhiMny = #sye.PhiMn * (float)Math.Sin(#Udb * 0.017453292519943295);
			}
			else if (#Udb == 90.0)
			{
				#sye.PhiMnx = new float?(0f);
				#sye.PhiMny = #sye.PhiMn;
			}
			else if (#Udb > 90.0 && #Udb < 180.0)
			{
				#sye.PhiMny = #sye.PhiMn * (float)Math.Cos((#Udb - 90.0) * 0.017453292519943295);
				float? num = #sye.PhiMn;
				float num2 = (float)Math.Sin((#Udb - 90.0) * 0.017453292519943295);
				#sye.PhiMnx = ((num != null) ? new float?(-(num.GetValueOrDefault() * num2)) : null);
			}
			else if (#Udb == 180.0)
			{
				#sye.PhiMny = new float?(0f);
				#sye.PhiMnx = -#sye.PhiMn;
			}
			else if (#Udb > 180.0 && #Udb < 270.0)
			{
				float? num = #sye.PhiMn;
				float num2 = (float)Math.Cos((#Udb - 180.0) * 0.017453292519943295);
				#sye.PhiMnx = ((num != null) ? new float?(-(num.GetValueOrDefault() * num2)) : null);
				num = #sye.PhiMn;
				num2 = (float)Math.Sin((#Udb - 180.0) * 0.017453292519943295);
				#sye.PhiMny = ((num != null) ? new float?(-(num.GetValueOrDefault() * num2)) : null);
			}
			else if (#Udb == 270.0)
			{
				#sye.PhiMnx = new float?(0f);
				#sye.PhiMny = -#sye.PhiMn;
			}
			else if (#Udb > 270.0 && #Udb < 360.0)
			{
				float? num = #sye.PhiMn;
				float num2 = (float)Math.Cos((#Udb - 270.0) * 0.017453292519943295);
				#sye.PhiMny = ((num != null) ? new float?(-(num.GetValueOrDefault() * num2)) : null);
				#sye.PhiMnx = #sye.PhiMn * (float)Math.Sin((#Udb - 270.0) * 0.017453292519943295);
			}
			return #sye;
		}

		// Token: 0x06009FD4 RID: 40916 RVA: 0x0007D8A4 File Offset: 0x0007BAA4
		[CompilerGenerated]
		private bool #OWi(UniCurve #Rf)
		{
			return #Rf.AxialLoad <= this.#h;
		}

		// Token: 0x040045C7 RID: 17863
		private readonly InputModel #a;

		// Token: 0x040045C8 RID: 17864
		private readonly RuntimeModel #b;

		// Token: 0x040045C9 RID: 17865
		private readonly #3Qe #c;

		// Token: 0x040045CA RID: 17866
		private readonly #38e #d;

		// Token: 0x040045CB RID: 17867
		private readonly #1Oe #e;

		// Token: 0x040045CC RID: 17868
		private float #f;

		// Token: 0x040045CD RID: 17869
		private float #g;

		// Token: 0x040045CE RID: 17870
		private float #h;

		// Token: 0x020012A3 RID: 4771
		public sealed class #Rgf : IEqualityComparer<StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point>
		{
			// Token: 0x06009FD5 RID: 40917 RVA: 0x0021FE4C File Offset: 0x0021E04C
			public bool #e(StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point #Yxc, StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point #z9c)
			{
				return (double)Math.Abs(#Yxc.X - #z9c.X) < 0.001 && (double)Math.Abs(#Yxc.Y - #z9c.Y) < 0.001;
			}

			// Token: 0x06009FD6 RID: 40918 RVA: 0x0007D8B7 File Offset: 0x0007BAB7
			public int #g(StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Point #Vg)
			{
				return #Vg.GetHashCode();
			}
		}

		// Token: 0x020012A4 RID: 4772
		public sealed class #Tgf
		{
			// Token: 0x17002DFE RID: 11774
			// (get) Token: 0x06009FD8 RID: 40920 RVA: 0x0007D8C6 File Offset: 0x0007BAC6
			// (set) Token: 0x06009FD9 RID: 40921 RVA: 0x0007D8CE File Offset: 0x0007BACE
			public double Distance { get; set; }

			// Token: 0x17002DFF RID: 11775
			// (get) Token: 0x06009FDA RID: 40922 RVA: 0x0007D8D7 File Offset: 0x0007BAD7
			// (set) Token: 0x06009FDB RID: 40923 RVA: 0x0007D8DF File Offset: 0x0007BADF
			public double X { get; set; }

			// Token: 0x17002E00 RID: 11776
			// (get) Token: 0x06009FDC RID: 40924 RVA: 0x0007D8E8 File Offset: 0x0007BAE8
			// (set) Token: 0x06009FDD RID: 40925 RVA: 0x0007D8F0 File Offset: 0x0007BAF0
			public double Y { get; set; }

			// Token: 0x040045CF RID: 17871
			[CompilerGenerated]
			private double #a;

			// Token: 0x040045D0 RID: 17872
			[CompilerGenerated]
			private double #b;

			// Token: 0x040045D1 RID: 17873
			[CompilerGenerated]
			private double #c;
		}
	}
}
