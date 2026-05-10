using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #6re;
using #7hc;
using #9Ue;
using #o1d;
using #UYd;
using #Wse;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.NewCapacityRatio;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams
{
	// Token: 0x02001203 RID: 4611
	public sealed class LoadPointsHelper
	{
		// Token: 0x06009A7F RID: 39551 RVA: 0x0020D6F4 File Offset: 0x0020B8F4
		public LoadPointsHelper(#lte model, #xse inclusionSettings)
		{
			if (inclusionSettings == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107283082));
			}
			this.#a = inclusionSettings;
			if (model == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399786));
			}
			this.Model = model;
			this.LoadPoints = model.Output.CapacityData.LoadPoints.Where(new Func<LoadPointDrawingData, bool>(LoadPointsHelper.<>c.<>9.#8Zb)).OrderBy(new Func<LoadPointDrawingData, float>(LoadPointsHelper.<>c.<>9.#oK)).ThenBy(new Func<LoadPointDrawingData, float>(LoadPointsHelper.<>c.<>9.#7cf)).ThenBy(new Func<LoadPointDrawingData, float>(LoadPointsHelper.<>c.<>9.#8cf)).ToList<LoadPointDrawingData>();
		}

		// Token: 0x17002CD5 RID: 11477
		// (get) Token: 0x06009A80 RID: 39552 RVA: 0x0007A4FE File Offset: 0x000786FE
		public #lte Model { get; }

		// Token: 0x17002CD6 RID: 11478
		// (get) Token: 0x06009A81 RID: 39553 RVA: 0x0007A506 File Offset: 0x00078706
		public IReadOnlyList<LoadPointDrawingData> LoadPoints { get; }

		// Token: 0x06009A82 RID: 39554 RVA: 0x0007A50E File Offset: 0x0007870E
		public static bool #nAe(double #f, double #3r, double #4r)
		{
			#f = Math.Round(#f, 1);
			return #f >= #3r && #f <= #4r;
		}

		// Token: 0x06009A83 RID: 39555 RVA: 0x0020D7E8 File Offset: 0x0020B9E8
		public static double? #0Tc(double? #0jb, double? #1jb)
		{
			if (#1jb == null || #0jb == null)
			{
				return null;
			}
			float num = (float)Math.Atan2(#1jb.Value, #0jb.Value);
			num = (float)((num >= 0f) ? ((double)num) : (6.283185307179586 + (double)num));
			num = (float)((double)num * 360.0 / 6.283185307179586);
			num = (float)Math.Round((double)num, 0);
			return new double?((double)num);
		}

		// Token: 0x06009A84 RID: 39556 RVA: 0x0020D86C File Offset: 0x0020BA6C
		internal IEnumerable<double> #oAe()
		{
			HashSet<double> hashSet = new HashSet<double>();
			if (this.#a.Diagram2DPMIncludeAll)
			{
				hashSet.#pR(this.LoadPoints.Select(new Func<LoadPointDrawingData, double>(LoadPointsHelper.<>c.<>9.#9cf)));
			}
			else
			{
				if (this.#a.Diagram2DPMAutomaticallyIncludeLargestCapacityRatio)
				{
					if (this.LoadPoints.All(new Func<LoadPointDrawingData, bool>(LoadPointsHelper.<>c.<>9.#adf)))
					{
						LoadPointDrawingData loadPointDrawingData = this.LoadPoints.#q1d(new Func<LoadPointDrawingData, double>(LoadPointsHelper.<>c.<>9.#bdf));
						if (loadPointDrawingData != null)
						{
							hashSet.Add(#Emc.#pVe((double)loadPointDrawingData.Angle));
						}
					}
				}
				if (this.#a.Diagram2DPMAutomaticallyIncludeWithCapacityRatioGreaterThan)
				{
					hashSet.#pR(this.LoadPoints.Where(new Func<LoadPointDrawingData, bool>(this.#qAe)).Select(new Func<LoadPointDrawingData, double>(LoadPointsHelper.<>c.<>9.#cdf)));
				}
			}
			List<double> #8f;
			if (this.#a.Diagram2DPMAutomaticallyIncludeAtAngles && this.#a.Diagram2DPMAutomaticallyIncludeAtSpecifiedAngles.#d0d(out #8f))
			{
				hashSet.#pR(#8f);
			}
			foreach (ReporterImage reporterImage in this.Model.Images.Where(new Func<ReporterImage, bool>(LoadPointsHelper.<>c.<>9.#ddf)))
			{
				hashSet.Remove(reporterImage.Diagram2DParameter);
				hashSet.Remove(#Emc.#pVe(reporterImage.Diagram2DParameter));
			}
			return hashSet;
		}

		// Token: 0x06009A85 RID: 39557 RVA: 0x0020DA38 File Offset: 0x0020BC38
		internal IEnumerable<double> #Yne()
		{
			HashSet<double> hashSet = new HashSet<double>();
			if (this.#a.Diagram2DMMIncludeAll)
			{
				hashSet.#pR(this.LoadPoints.Select(new Func<LoadPointDrawingData, double>(LoadPointsHelper.<>c.<>9.#edf)));
			}
			else
			{
				if (this.#a.Diagram2DMMAutomaticallyIncludeLargestCapacityRatio)
				{
					if (this.LoadPoints.All(new Func<LoadPointDrawingData, bool>(LoadPointsHelper.<>c.<>9.#fdf)))
					{
						LoadPointDrawingData loadPointDrawingData = this.LoadPoints.#q1d(new Func<LoadPointDrawingData, double>(LoadPointsHelper.<>c.<>9.#gdf));
						if (loadPointDrawingData != null)
						{
							hashSet.Add(#Emc.#qVe((double)loadPointDrawingData.AxialLoad));
						}
					}
				}
				if (this.#a.Diagram2DMMAutomaticallyIncludeWithCapacityRatioGreaterThan)
				{
					hashSet.#pR(this.LoadPoints.Where(new Func<LoadPointDrawingData, bool>(this.#rAe)).Select(new Func<LoadPointDrawingData, double>(LoadPointsHelper.<>c.<>9.#hdf)));
				}
			}
			List<double> #8f;
			if (this.#a.Diagram2DMMAutomaticallyIncludeAtAxialLoads && this.#a.Diagram2DMMAutomaticallyIncludeAtSpecifiedAxialLoads.#d0d(out #8f))
			{
				hashSet.#pR(#8f);
			}
			foreach (ReporterImage reporterImage in this.Model.Images.Where(new Func<ReporterImage, bool>(LoadPointsHelper.<>c.<>9.#idf)))
			{
				hashSet.Remove(reporterImage.Diagram2DParameter);
				hashSet.Remove(#Emc.#pVe(reporterImage.Diagram2DParameter));
			}
			return hashSet;
		}

		// Token: 0x06009A86 RID: 39558 RVA: 0x0007A526 File Offset: 0x00078726
		private bool #pAe(CapacityRatioCalculation #xve, double #1Mb)
		{
			return CapacityRatioHelper.#pAe(#xve.DisplayValue, (#x6e)this.Model.Input.Options.SectionCapacityMethod, #1Mb, true);
		}

		// Token: 0x06009A87 RID: 39559 RVA: 0x0007A54A File Offset: 0x0007874A
		[CompilerGenerated]
		private bool #qAe(LoadPointDrawingData #Rf)
		{
			return this.#pAe(#Rf.CapacityRatio, this.#a.Diagram2DPMAutomaticallyIncludeCapacityRatioThreshold);
		}

		// Token: 0x06009A88 RID: 39560 RVA: 0x0007A563 File Offset: 0x00078763
		[CompilerGenerated]
		private bool #rAe(LoadPointDrawingData #Rf)
		{
			return this.#pAe(#Rf.CapacityRatio, this.#a.Diagram2DMMAutomaticallyIncludeCapacityRatioThreshold);
		}

		// Token: 0x0400426B RID: 17003
		private readonly #xse #a;

		// Token: 0x0400426C RID: 17004
		[CompilerGenerated]
		private readonly #lte #b;

		// Token: 0x0400426D RID: 17005
		[CompilerGenerated]
		private readonly IReadOnlyList<LoadPointDrawingData> #c;
	}
}
