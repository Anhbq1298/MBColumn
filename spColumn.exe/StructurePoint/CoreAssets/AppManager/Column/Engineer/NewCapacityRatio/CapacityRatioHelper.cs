using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using #12e;
using #7hc;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.NewCapacityRatio
{
	// Token: 0x020012EA RID: 4842
	public static class CapacityRatioHelper
	{
		// Token: 0x17002E75 RID: 11893
		// (get) Token: 0x0600A1BD RID: 41405 RVA: 0x0007EB72 File Offset: 0x0007CD72
		public static string GreaterThanOne { get; } = #Phc.#3hc(107313662);

		// Token: 0x17002E76 RID: 11894
		// (get) Token: 0x0600A1BE RID: 41406 RVA: 0x0007EB79 File Offset: 0x0007CD79
		public static string GreaterThanOneShort { get; } = #Phc.#3hc(107313653);

		// Token: 0x17002E77 RID: 11895
		// (get) Token: 0x0600A1BF RID: 41407 RVA: 0x0007EB80 File Offset: 0x0007CD80
		public static string SmallerThanOne { get; } = #Phc.#3hc(107313648);

		// Token: 0x17002E78 RID: 11896
		// (get) Token: 0x0600A1C0 RID: 41408 RVA: 0x0007EB87 File Offset: 0x0007CD87
		public static string SmallerThanOneShort { get; } = #Phc.#3hc(107313607);

		// Token: 0x17002E79 RID: 11897
		// (get) Token: 0x0600A1C1 RID: 41409 RVA: 0x0007EB8E File Offset: 0x0007CD8E
		public static string GreaterThanNineNineNineShort { get; } = #Phc.#3hc(107313602);

		// Token: 0x17002E7A RID: 11898
		// (get) Token: 0x0600A1C2 RID: 41410 RVA: 0x0007EB95 File Offset: 0x0007CD95
		public static string GreaterThanNineNineNine { get; } = #Phc.#3hc(107313621);

		// Token: 0x17002E7B RID: 11899
		// (get) Token: 0x0600A1C3 RID: 41411 RVA: 0x0007EB9C File Offset: 0x0007CD9C
		public static double GoodBadThreshold
		{
			get
			{
				return 1.0;
			}
		}

		// Token: 0x0600A1C4 RID: 41412 RVA: 0x00228A7C File Offset: 0x00226C7C
		public static double #hVe(string #xve)
		{
			if (string.IsNullOrWhiteSpace(#xve))
			{
				return 0.0;
			}
			if (CapacityRatioHelper.#kVe(#xve))
			{
				return 1.0000001;
			}
			if (CapacityRatioHelper.#jVe(#xve))
			{
				return 999.999;
			}
			if (CapacityRatioHelper.#lVe(#xve))
			{
				return -9999999.0;
			}
			double result;
			double.TryParse(#xve, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
			return result;
		}

		// Token: 0x0600A1C5 RID: 41413 RVA: 0x00228AE8 File Offset: 0x00226CE8
		public static bool #iVe(string #xve)
		{
			double num;
			return double.TryParse(#xve, NumberStyles.Float, CultureInfo.CurrentCulture, out num);
		}

		// Token: 0x0600A1C6 RID: 41414 RVA: 0x0007EBA7 File Offset: 0x0007CDA7
		public static bool #jVe(string #f)
		{
			return string.Equals(#f, CapacityRatioHelper.GreaterThanNineNineNineShort, StringComparison.OrdinalIgnoreCase) || string.Equals(#f, CapacityRatioHelper.GreaterThanNineNineNine, StringComparison.OrdinalIgnoreCase);
		}

		// Token: 0x0600A1C7 RID: 41415 RVA: 0x0007EBC5 File Offset: 0x0007CDC5
		public static bool #kVe(string #f)
		{
			return string.Equals(CapacityRatioHelper.GreaterThanOne, #f, StringComparison.OrdinalIgnoreCase) || string.Equals(CapacityRatioHelper.GreaterThanOneShort, #f, StringComparison.OrdinalIgnoreCase);
		}

		// Token: 0x0600A1C8 RID: 41416 RVA: 0x0007EBE3 File Offset: 0x0007CDE3
		public static bool #lVe(string #f)
		{
			return string.Equals(CapacityRatioHelper.SmallerThanOne, #f, StringComparison.OrdinalIgnoreCase) || string.Equals(CapacityRatioHelper.SmallerThanOneShort, #f, StringComparison.OrdinalIgnoreCase);
		}

		// Token: 0x0600A1C9 RID: 41417 RVA: 0x00228B08 File Offset: 0x00226D08
		public static bool #pAe(string #Il, #x6e #mVe, bool #2pb, float #3pb)
		{
			double num;
			if (double.TryParse(#Il, NumberStyles.Float, CultureInfo.CurrentCulture, out num))
			{
				return num > (#2pb ? ((double)#3pb) : CapacityRatioHelper.GoodBadThreshold);
			}
			return #mVe == #x6e.#a && (CapacityRatioHelper.#kVe(#Il) || CapacityRatioHelper.#jVe(#Il));
		}

		// Token: 0x0600A1CA RID: 41418 RVA: 0x00228B50 File Offset: 0x00226D50
		public static bool #pAe(string #Il, #x6e #mVe, double #1Mb, bool #6ai = false)
		{
			double num;
			if (double.TryParse(#Il, NumberStyles.Float, CultureInfo.CurrentCulture, out num))
			{
				#1Mb = ((#mVe == #x6e.#a && !#6ai) ? CapacityRatioHelper.GoodBadThreshold : #1Mb);
				return num > #1Mb;
			}
			return #mVe == #x6e.#a && (CapacityRatioHelper.#kVe(#Il) || CapacityRatioHelper.#jVe(#Il));
		}

		// Token: 0x0600A1CB RID: 41419 RVA: 0x0007EC01 File Offset: 0x0007CE01
		public static void #nVe(InputModel #hMe, #l4e #Kwe)
		{
			#Kwe.CapacityData.OverallCapacity = CapacityRatioHelper.#oVe(#hMe, #Kwe);
		}

		// Token: 0x0600A1CC RID: 41420 RVA: 0x00228B9C File Offset: 0x00226D9C
		private static string #oVe(InputModel #hMe, #l4e #Kwe)
		{
			List<CapacityRatioCalculation> source = #Kwe.CapacityData.LoadPoints.Select(new Func<LoadPointDrawingData, CapacityRatioCalculation>(CapacityRatioHelper.<>c.<>9.#uhf)).ToList<CapacityRatioCalculation>();
			if (!source.Any<CapacityRatioCalculation>())
			{
				return null;
			}
			#x6e #x6e = #hMe.Options.CapacityCalculationType;
			bool flag = source.Any(new Func<CapacityRatioCalculation, bool>(CapacityRatioHelper.<>c.<>9.#vhf));
			bool flag2 = source.Any(new Func<CapacityRatioCalculation, bool>(CapacityRatioHelper.<>c.<>9.#whf));
			bool flag3 = source.Any(new Func<CapacityRatioCalculation, bool>(CapacityRatioHelper.<>c.<>9.#xhf));
			if (#x6e != #x6e.#b && (flag2 || flag || flag3))
			{
				if (#x6e == #x6e.#a)
				{
					if (flag3)
					{
						return CapacityRatioHelper.GreaterThanNineNineNineShort;
					}
					if (flag)
					{
						return CapacityRatioHelper.GreaterThanOne;
					}
					CapacityRatioCalculation capacityRatioCalculation = source.Where(new Func<CapacityRatioCalculation, bool>(CapacityRatioHelper.<>c.<>9.#zhf)).OrderByDescending(new Func<CapacityRatioCalculation, double?>(CapacityRatioHelper.<>c.<>9.#mXi)).FirstOrDefault<CapacityRatioCalculation>();
					if (capacityRatioCalculation != null)
					{
						return capacityRatioCalculation.DisplayValue;
					}
					if (source.Any(new Func<CapacityRatioCalculation, bool>(CapacityRatioHelper.<>c.<>9.#nXi)))
					{
						return CapacityRatioHelper.SmallerThanOne;
					}
				}
				return null;
			}
			List<CapacityRatioCalculation> source2 = source.Where(new Func<CapacityRatioCalculation, bool>(CapacityRatioHelper.<>c.<>9.#Ahf)).ToList<CapacityRatioCalculation>();
			if (!source2.Any<CapacityRatioCalculation>())
			{
				return null;
			}
			return ((float)source2.Max(new Func<CapacityRatioCalculation, double>(CapacityRatioHelper.<>c.<>9.#yhf))).ToString(#Phc.#3hc(107408811));
		}

		// Token: 0x040046C1 RID: 18113
		[CompilerGenerated]
		private static readonly string #a;

		// Token: 0x040046C2 RID: 18114
		[CompilerGenerated]
		private static readonly string #b;

		// Token: 0x040046C3 RID: 18115
		[CompilerGenerated]
		private static readonly string #c;

		// Token: 0x040046C4 RID: 18116
		[CompilerGenerated]
		private static readonly string #d;

		// Token: 0x040046C5 RID: 18117
		[CompilerGenerated]
		private static readonly string #e;

		// Token: 0x040046C6 RID: 18118
		[CompilerGenerated]
		private static readonly string #f;
	}
}
