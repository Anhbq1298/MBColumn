using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #0I;
using #6re;
using #7hc;
using #Lx;
using #pc;
using #UYd;
using StructurePoint.CoreAssets.AppManager.Column.Helpers;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Units.Formatters;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;

namespace #Ot
{
	// Token: 0x0200018B RID: 395
	internal sealed class #Uw : #ex<#xc>, #5I, IPanel, IChangesInfo, #Sx
	{
		// Token: 0x06000CEE RID: 3310 RVA: 0x0001008A File Offset: 0x0000E28A
		public #Uw(Lazy<#xc> #Ee, ICoreServices #0c, #yse #iw) : base(#Ee, #0c)
		{
			this.#a = #iw;
			this.#q = new FloatingPointUnitValueFormatter(2);
		}

		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x06000CEF RID: 3311 RVA: 0x000100A7 File Offset: 0x0000E2A7
		public IUnitValueFormatter ThresholdFormatter { get; }

		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x06000CF0 RID: 3312 RVA: 0x00003375 File Offset: 0x00001575
		public bool AreAllCapacityRatiosNumeric
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700052C RID: 1324
		// (get) Token: 0x06000CF1 RID: 3313 RVA: 0x00003375 File Offset: 0x00001575
		public bool IsCapacityRatioCriticalCapacityMethod
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x06000CF2 RID: 3314 RVA: 0x000100B3 File Offset: 0x0000E2B3
		// (set) Token: 0x06000CF3 RID: 3315 RVA: 0x000100BF File Offset: 0x0000E2BF
		public bool PMIncludeAll
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<bool>(ref this.#b, value, #Phc.#3hc(107409929));
			}
		}

		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x06000CF4 RID: 3316 RVA: 0x000100E5 File Offset: 0x0000E2E5
		// (set) Token: 0x06000CF5 RID: 3317 RVA: 0x000100F1 File Offset: 0x0000E2F1
		public bool PMAutomaticallyIncludeLargestCapacityRatio
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.SetProperty<bool>(ref this.#c, value, #Phc.#3hc(107409944));
			}
		}

		// Token: 0x1700052F RID: 1327
		// (get) Token: 0x06000CF6 RID: 3318 RVA: 0x00010117 File Offset: 0x0000E317
		// (set) Token: 0x06000CF7 RID: 3319 RVA: 0x00010123 File Offset: 0x0000E323
		public bool PMAutomaticallyIncludeWithCapacityRatioGreaterThan
		{
			get
			{
				return this.#d;
			}
			set
			{
				this.SetProperty<bool>(ref this.#d, value, #Phc.#3hc(107410399));
			}
		}

		// Token: 0x17000530 RID: 1328
		// (get) Token: 0x06000CF8 RID: 3320 RVA: 0x00010149 File Offset: 0x0000E349
		// (set) Token: 0x06000CF9 RID: 3321 RVA: 0x00010155 File Offset: 0x0000E355
		public double PMAutomaticallyIncludeCapacityRatioThreshold
		{
			get
			{
				return this.#e;
			}
			set
			{
				this.SetProperty<double>(ref this.#e, value, #Phc.#3hc(107410330));
			}
		}

		// Token: 0x17000531 RID: 1329
		// (get) Token: 0x06000CFA RID: 3322 RVA: 0x0001017B File Offset: 0x0000E37B
		// (set) Token: 0x06000CFB RID: 3323 RVA: 0x00010187 File Offset: 0x0000E387
		public bool PMAutomaticallyIncludeAtAngles
		{
			get
			{
				return this.#f;
			}
			set
			{
				this.SetProperty<bool>(ref this.#f, value, #Phc.#3hc(107410269));
			}
		}

		// Token: 0x17000532 RID: 1330
		// (get) Token: 0x06000CFC RID: 3324 RVA: 0x000101AD File Offset: 0x0000E3AD
		// (set) Token: 0x06000CFD RID: 3325 RVA: 0x000101B9 File Offset: 0x0000E3B9
		public string ValidPMAutomaticallyIncludeAtSpecifiedAngles
		{
			get
			{
				return this.#h;
			}
			set
			{
				if (this.#h != value)
				{
					this.#h = value;
					base.RaisePropertyChanged(#Phc.#3hc(107410228));
				}
			}
		}

		// Token: 0x17000533 RID: 1331
		// (get) Token: 0x06000CFE RID: 3326 RVA: 0x000101EC File Offset: 0x0000E3EC
		// (set) Token: 0x06000CFF RID: 3327 RVA: 0x0009D070 File Offset: 0x0009B270
		public string PMAutomaticallyIncludeAtSpecifiedAngles
		{
			get
			{
				return this.#g;
			}
			set
			{
				if (this.#g != value)
				{
					List<double> list = this.#Tw(value, #Phc.#3hc(107409655));
					if (list == null)
					{
						this.#g = value;
						base.RaisePropertyChanged(#Phc.#3hc(107409655));
						return;
					}
					string text = SettingsHelper.#1Le(list);
					this.#g = text;
					base.RaisePropertyChanged(#Phc.#3hc(107409655));
					this.ValidPMAutomaticallyIncludeAtSpecifiedAngles = text;
				}
			}
		}

		// Token: 0x17000534 RID: 1332
		// (get) Token: 0x06000D00 RID: 3328 RVA: 0x000101F8 File Offset: 0x0000E3F8
		// (set) Token: 0x06000D01 RID: 3329 RVA: 0x00010204 File Offset: 0x0000E404
		public bool MMIncludeAll
		{
			get
			{
				return this.#i;
			}
			set
			{
				this.SetProperty<bool>(ref this.#i, value, #Phc.#3hc(107409570));
			}
		}

		// Token: 0x17000535 RID: 1333
		// (get) Token: 0x06000D02 RID: 3330 RVA: 0x0001022A File Offset: 0x0000E42A
		// (set) Token: 0x06000D03 RID: 3331 RVA: 0x00010236 File Offset: 0x0000E436
		public bool MMAutomaticallyIncludeLargestCapacityRatio
		{
			get
			{
				return this.#j;
			}
			set
			{
				this.SetProperty<bool>(ref this.#j, value, #Phc.#3hc(107409585));
			}
		}

		// Token: 0x17000536 RID: 1334
		// (get) Token: 0x06000D04 RID: 3332 RVA: 0x0001025C File Offset: 0x0000E45C
		// (set) Token: 0x06000D05 RID: 3333 RVA: 0x00010268 File Offset: 0x0000E468
		public bool MMAutomaticallyIncludeWithCapacityRatioGreaterThan
		{
			get
			{
				return this.#k;
			}
			set
			{
				this.SetProperty<bool>(ref this.#k, value, #Phc.#3hc(107409528));
			}
		}

		// Token: 0x17000537 RID: 1335
		// (get) Token: 0x06000D06 RID: 3334 RVA: 0x0001028E File Offset: 0x0000E48E
		// (set) Token: 0x06000D07 RID: 3335 RVA: 0x0001029A File Offset: 0x0000E49A
		public double MMAutomaticallyIncludeCapacityRatioThreshold
		{
			get
			{
				return this.#l;
			}
			set
			{
				this.SetProperty<double>(ref this.#l, value, #Phc.#3hc(107409459));
			}
		}

		// Token: 0x17000538 RID: 1336
		// (get) Token: 0x06000D08 RID: 3336 RVA: 0x000102C0 File Offset: 0x0000E4C0
		// (set) Token: 0x06000D09 RID: 3337 RVA: 0x000102CC File Offset: 0x0000E4CC
		public bool MMAutomaticallyIncludeAtAxialLoads
		{
			get
			{
				return this.#m;
			}
			set
			{
				this.SetProperty<bool>(ref this.#m, value, #Phc.#3hc(107409910));
			}
		}

		// Token: 0x17000539 RID: 1337
		// (get) Token: 0x06000D0A RID: 3338 RVA: 0x000102F2 File Offset: 0x0000E4F2
		// (set) Token: 0x06000D0B RID: 3339 RVA: 0x000102FE File Offset: 0x0000E4FE
		public string ValidMMAutomaticallyIncludeAtSpecifiedAxialLoads
		{
			get
			{
				return this.#o;
			}
			set
			{
				if (this.#o != value)
				{
					this.#o = value;
					base.RaisePropertyChanged(#Phc.#3hc(107409829));
				}
			}
		}

		// Token: 0x1700053A RID: 1338
		// (get) Token: 0x06000D0C RID: 3340 RVA: 0x00010331 File Offset: 0x0000E531
		// (set) Token: 0x06000D0D RID: 3341 RVA: 0x0009D0EC File Offset: 0x0009B2EC
		public string MMAutomaticallyIncludeAtSpecifiedAxialLoads
		{
			get
			{
				return this.#n;
			}
			set
			{
				if (this.#n != value)
				{
					List<double> list = this.#Tw(value, #Phc.#3hc(107409764));
					if (list == null)
					{
						this.#n = value;
						base.RaisePropertyChanged(#Phc.#3hc(107409764));
						return;
					}
					string text = SettingsHelper.#0Le(list);
					this.#n = text;
					base.RaisePropertyChanged(#Phc.#3hc(107409764));
					this.ValidMMAutomaticallyIncludeAtSpecifiedAxialLoads = text;
				}
			}
		}

		// Token: 0x1700053B RID: 1339
		// (get) Token: 0x06000D0E RID: 3342 RVA: 0x0001033D File Offset: 0x0000E53D
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06000D0F RID: 3343 RVA: 0x0009D168 File Offset: 0x0009B368
		public bool GetHasChanges()
		{
			List<double> list = this.#Tw(this.ValidPMAutomaticallyIncludeAtSpecifiedAngles, #Phc.#3hc(107409703));
			if (list == null)
			{
				return true;
			}
			string b = SettingsHelper.#1Le(list);
			list = this.#Tw(this.ValidMMAutomaticallyIncludeAtSpecifiedAxialLoads, #Phc.#3hc(107409703));
			if (list == null)
			{
				return true;
			}
			string b2 = SettingsHelper.#0Le(list);
			#xse #xse = this.#a.#hJ();
			List<double> list2 = this.#Tw(#xse.Diagram2DMMAutomaticallyIncludeAtSpecifiedAxialLoads, #Phc.#3hc(107409703));
			string a = (list2 != null) ? SettingsHelper.#0Le(list2) : null;
			list2 = this.#Tw(#xse.Diagram2DPMAutomaticallyIncludeAtSpecifiedAngles, #Phc.#3hc(107409703));
			string a2 = (list2 != null) ? SettingsHelper.#1Le(list2) : null;
			return #xse.Diagram2DPMIncludeAll != this.PMIncludeAll || #xse.Diagram2DPMAutomaticallyIncludeLargestCapacityRatio != this.PMAutomaticallyIncludeLargestCapacityRatio || #xse.Diagram2DPMAutomaticallyIncludeWithCapacityRatioGreaterThan != this.PMAutomaticallyIncludeWithCapacityRatioGreaterThan || !#xse.Diagram2DPMAutomaticallyIncludeCapacityRatioThreshold.Equals(this.PMAutomaticallyIncludeCapacityRatioThreshold) || #xse.Diagram2DPMAutomaticallyIncludeAtAngles != this.PMAutomaticallyIncludeAtAngles || !(a2 == b) || #xse.Diagram2DMMIncludeAll != this.MMIncludeAll || #xse.Diagram2DMMAutomaticallyIncludeLargestCapacityRatio != this.MMAutomaticallyIncludeLargestCapacityRatio || #xse.Diagram2DMMAutomaticallyIncludeWithCapacityRatioGreaterThan != this.MMAutomaticallyIncludeWithCapacityRatioGreaterThan || !#xse.Diagram2DMMAutomaticallyIncludeCapacityRatioThreshold.Equals(this.MMAutomaticallyIncludeCapacityRatioThreshold) || #xse.Diagram2DMMAutomaticallyIncludeAtAxialLoads != this.MMAutomaticallyIncludeAtAxialLoads || !(a == b2);
		}

		// Token: 0x06000D10 RID: 3344 RVA: 0x0009D2F4 File Offset: 0x0009B4F4
		public override void UpdateFromModel(ColumnModel model)
		{
			#xse #ng = this.#a.#hJ();
			this.#rt(#ng);
		}

		// Token: 0x06000D11 RID: 3345 RVA: 0x0009D320 File Offset: 0x0009B520
		public override void UpdateModel(ColumnModel model)
		{
			#xse #ng = new #xse
			{
				Diagram2DPMIncludeAll = this.PMIncludeAll,
				Diagram2DPMAutomaticallyIncludeLargestCapacityRatio = this.PMAutomaticallyIncludeLargestCapacityRatio,
				Diagram2DPMAutomaticallyIncludeWithCapacityRatioGreaterThan = this.PMAutomaticallyIncludeWithCapacityRatioGreaterThan,
				Diagram2DPMAutomaticallyIncludeCapacityRatioThreshold = this.PMAutomaticallyIncludeCapacityRatioThreshold,
				Diagram2DPMAutomaticallyIncludeAtAngles = this.PMAutomaticallyIncludeAtAngles,
				Diagram2DPMAutomaticallyIncludeAtSpecifiedAngles = this.ValidPMAutomaticallyIncludeAtSpecifiedAngles,
				Diagram2DMMIncludeAll = this.MMIncludeAll,
				Diagram2DMMAutomaticallyIncludeLargestCapacityRatio = this.MMAutomaticallyIncludeLargestCapacityRatio,
				Diagram2DMMAutomaticallyIncludeWithCapacityRatioGreaterThan = this.MMAutomaticallyIncludeWithCapacityRatioGreaterThan,
				Diagram2DMMAutomaticallyIncludeCapacityRatioThreshold = this.MMAutomaticallyIncludeCapacityRatioThreshold,
				Diagram2DMMAutomaticallyIncludeAtAxialLoads = this.MMAutomaticallyIncludeAtAxialLoads,
				Diagram2DMMAutomaticallyIncludeAtSpecifiedAxialLoads = this.ValidMMAutomaticallyIncludeAtSpecifiedAxialLoads
			};
			this.#a.#gJ(#ng);
		}

		// Token: 0x06000D12 RID: 3346 RVA: 0x0009D3F0 File Offset: 0x0009B5F0
		public override void #qt()
		{
			#xse #ng = #xse.Default;
			this.#rt(#ng);
		}

		// Token: 0x06000D13 RID: 3347 RVA: 0x0009D418 File Offset: 0x0009B618
		private List<double> #Tw(string #f, [CallerMemberName] string #em = null)
		{
			List<double> list = new List<double>();
			if ((string.IsNullOrWhiteSpace(#f) || !#f.#d0d(out list) || list.Count == 0) && !this.#p)
			{
				this.AddError(#em, Strings.StringValueHasInvalidFormat.#z2d(true) + Strings.StringExpectedCommaSeparatedListOfNumbers.#z2d());
				return null;
			}
			base.RemoveError(#em);
			return list;
		}

		// Token: 0x06000D14 RID: 3348 RVA: 0x0009D484 File Offset: 0x0009B684
		private void #rt(#xse #ng)
		{
			this.#p = true;
			this.PMIncludeAll = #ng.Diagram2DPMIncludeAll;
			this.PMAutomaticallyIncludeLargestCapacityRatio = #ng.Diagram2DPMAutomaticallyIncludeLargestCapacityRatio;
			this.PMAutomaticallyIncludeWithCapacityRatioGreaterThan = #ng.Diagram2DPMAutomaticallyIncludeWithCapacityRatioGreaterThan;
			this.PMAutomaticallyIncludeCapacityRatioThreshold = #ng.Diagram2DPMAutomaticallyIncludeCapacityRatioThreshold;
			this.PMAutomaticallyIncludeAtAngles = #ng.Diagram2DPMAutomaticallyIncludeAtAngles;
			this.PMAutomaticallyIncludeAtSpecifiedAngles = #ng.Diagram2DPMAutomaticallyIncludeAtSpecifiedAngles;
			this.MMIncludeAll = #ng.Diagram2DMMIncludeAll;
			this.MMAutomaticallyIncludeLargestCapacityRatio = #ng.Diagram2DMMAutomaticallyIncludeLargestCapacityRatio;
			this.MMAutomaticallyIncludeWithCapacityRatioGreaterThan = #ng.Diagram2DMMAutomaticallyIncludeWithCapacityRatioGreaterThan;
			this.MMAutomaticallyIncludeCapacityRatioThreshold = #ng.Diagram2DMMAutomaticallyIncludeCapacityRatioThreshold;
			this.MMAutomaticallyIncludeAtAxialLoads = #ng.Diagram2DMMAutomaticallyIncludeAtAxialLoads;
			this.MMAutomaticallyIncludeAtSpecifiedAxialLoads = #ng.Diagram2DMMAutomaticallyIncludeAtSpecifiedAxialLoads;
			this.#p = false;
		}

		// Token: 0x06000D15 RID: 3349 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.#Lr()
		{
			base.ClearErrors();
		}

		// Token: 0x06000D16 RID: 3350 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.#Or(string #em)
		{
			base.RemoveError(#em);
		}

		// Token: 0x040004C7 RID: 1223
		private readonly #yse #a;

		// Token: 0x040004C8 RID: 1224
		private bool #b;

		// Token: 0x040004C9 RID: 1225
		private bool #c;

		// Token: 0x040004CA RID: 1226
		private bool #d;

		// Token: 0x040004CB RID: 1227
		private double #e;

		// Token: 0x040004CC RID: 1228
		private bool #f;

		// Token: 0x040004CD RID: 1229
		private string #g;

		// Token: 0x040004CE RID: 1230
		private string #h;

		// Token: 0x040004CF RID: 1231
		private bool #i;

		// Token: 0x040004D0 RID: 1232
		private bool #j;

		// Token: 0x040004D1 RID: 1233
		private bool #k;

		// Token: 0x040004D2 RID: 1234
		private double #l;

		// Token: 0x040004D3 RID: 1235
		private bool #m;

		// Token: 0x040004D4 RID: 1236
		private string #n;

		// Token: 0x040004D5 RID: 1237
		private string #o;

		// Token: 0x040004D6 RID: 1238
		private bool #p;

		// Token: 0x040004D7 RID: 1239
		[CompilerGenerated]
		private readonly IUnitValueFormatter #q;
	}
}
