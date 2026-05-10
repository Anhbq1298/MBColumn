using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using #6re;
using #7hc;
using #lH;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Units.Formatters;
using StructurePoint.Products.Column.FailureSurface.Views;
using StructurePoint.Products.Column.Services.API;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace #Mbb
{
	// Token: 0x0200040E RID: 1038
	internal sealed class #Igb : #HH<IFilterOptionsView>, INotifyPropertyChanged, IViewModel<IFilterOptionsView>, IViewModel, #Xgb
	{
		// Token: 0x060024F1 RID: 9457 RVA: 0x000D2670 File Offset: 0x000D0870
		public #Igb(ICoreServices #0c, Lazy<IFilterOptionsView> #Ee) : base(#Ee, #0c)
		{
			this.#l = new DelegateCommand(new Action<object>(this.#5H));
			this.#k = new DelegateCommand(new Action<object>(this.#6H));
			this.#m = new RadObservableCollection<ComboItem<string>>
			{
				new ComboItem<string>(#Phc.#3hc(107361434), Strings.StringTop),
				new ComboItem<string>(#Phc.#3hc(107361429), Strings.StringBottom)
			};
			this.#j = new FloatingPointUnitValueFormatter(2);
		}

		// Token: 0x17000C80 RID: 3200
		// (get) Token: 0x060024F2 RID: 9458 RVA: 0x000230E6 File Offset: 0x000212E6
		// (set) Token: 0x060024F3 RID: 9459 RVA: 0x000230F2 File Offset: 0x000212F2
		public bool? DialogResult { get; private set; }

		// Token: 0x17000C81 RID: 3201
		// (get) Token: 0x060024F4 RID: 9460 RVA: 0x00023103 File Offset: 0x00021303
		public IUnitValueFormatter ThresholdFormatter { get; }

		// Token: 0x17000C82 RID: 3202
		// (get) Token: 0x060024F5 RID: 9461 RVA: 0x0002310F File Offset: 0x0002130F
		public DelegateCommand CancelCommand { get; }

		// Token: 0x17000C83 RID: 3203
		// (get) Token: 0x060024F6 RID: 9462 RVA: 0x0002311B File Offset: 0x0002131B
		public DelegateCommand OkCommand { get; }

		// Token: 0x17000C84 RID: 3204
		// (get) Token: 0x060024F7 RID: 9463 RVA: 0x00023127 File Offset: 0x00021327
		public RadObservableCollection<ComboItem<string>> Locations { get; }

		// Token: 0x17000C85 RID: 3205
		// (get) Token: 0x060024F8 RID: 9464 RVA: 0x00023133 File Offset: 0x00021333
		// (set) Token: 0x060024F9 RID: 9465 RVA: 0x000D2700 File Offset: 0x000D0900
		public double CapacityRatioFilterValue
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value && this.#XVh(value, #Phc.#3hc(107406134)))
				{
					this.#a = value;
					base.RaisePropertyChanged(#Phc.#3hc(107406134));
				}
			}
		}

		// Token: 0x17000C86 RID: 3206
		// (get) Token: 0x060024FA RID: 9466 RVA: 0x0002313F File Offset: 0x0002133F
		// (set) Token: 0x060024FB RID: 9467 RVA: 0x0002314B File Offset: 0x0002134B
		public bool IsCapacityRatioFilterActive
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					this.#b = value;
					this.#WVh();
					base.RaisePropertyChanged(#Phc.#3hc(107406101));
				}
			}
		}

		// Token: 0x17000C87 RID: 3207
		// (get) Token: 0x060024FC RID: 9468 RVA: 0x0002317F File Offset: 0x0002137F
		// (set) Token: 0x060024FD RID: 9469 RVA: 0x0002318B File Offset: 0x0002138B
		public ComboItem<string> LocationFilter
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					this.#c = value;
					base.RaisePropertyChanged(#Phc.#3hc(107405552));
				}
			}
		}

		// Token: 0x17000C88 RID: 3208
		// (get) Token: 0x060024FE RID: 9470 RVA: 0x000231B9 File Offset: 0x000213B9
		// (set) Token: 0x060024FF RID: 9471 RVA: 0x000231C5 File Offset: 0x000213C5
		public bool IsLocationFilterActive
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.#d != value)
				{
					this.#d = value;
					base.RaisePropertyChanged(#Phc.#3hc(107405531));
				}
			}
		}

		// Token: 0x17000C89 RID: 3209
		// (get) Token: 0x06002500 RID: 9472 RVA: 0x000231F3 File Offset: 0x000213F3
		// (set) Token: 0x06002501 RID: 9473 RVA: 0x000231FF File Offset: 0x000213FF
		public bool IsVisibilityFilterActive
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (this.#e != value)
				{
					this.#e = value;
					base.RaisePropertyChanged(#Phc.#3hc(107405371));
				}
			}
		}

		// Token: 0x17000C8A RID: 3210
		// (get) Token: 0x06002502 RID: 9474 RVA: 0x0002322D File Offset: 0x0002142D
		// (set) Token: 0x06002503 RID: 9475 RVA: 0x00023239 File Offset: 0x00021439
		public bool IsVisibilityFilterAllowed
		{
			get
			{
				return this.#h;
			}
			set
			{
				this.SetProperty<bool>(ref this.#h, value, #Phc.#3hc(107361424));
			}
		}

		// Token: 0x17000C8B RID: 3211
		// (get) Token: 0x06002504 RID: 9476 RVA: 0x0002325F File Offset: 0x0002145F
		// (set) Token: 0x06002505 RID: 9477 RVA: 0x000D274C File Offset: 0x000D094C
		public bool IsLocationFilterAllowed
		{
			get
			{
				return this.#f;
			}
			private set
			{
				if (this.#f != value)
				{
					this.#f = value;
					this.#XVh(this.CapacityRatioFilterValue, #Phc.#3hc(107406134));
					base.RaisePropertyChanged(#Phc.#3hc(107361355));
				}
			}
		}

		// Token: 0x17000C8C RID: 3212
		// (get) Token: 0x06002506 RID: 9478 RVA: 0x0002326B File Offset: 0x0002146B
		// (set) Token: 0x06002507 RID: 9479 RVA: 0x00023277 File Offset: 0x00021477
		public bool IsFilterValueEnabled
		{
			get
			{
				return this.#g;
			}
			set
			{
				if (this.#g != value)
				{
					this.#g = value;
					base.RaisePropertyChanged(#Phc.#3hc(107361322));
				}
			}
		}

		// Token: 0x17000C8D RID: 3213
		// (get) Token: 0x06002508 RID: 9480 RVA: 0x000232A5 File Offset: 0x000214A5
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06002509 RID: 9481 RVA: 0x000D279C File Offset: 0x000D099C
		public void #od(#lte #Od)
		{
			#Igb.#l0b #l0b = new #Igb.#l0b();
			this.DialogResult = null;
			#l0b.#a = base.Services.ReporterSettings.#Hse(#Od);
			this.IsLocationFilterAllowed = (#Od.Input.Options.ActiveLoad == LoadType.Service);
			this.IsVisibilityFilterAllowed = (#Od.Input.Options.ConsideredAxis == ConsideredAxis.Both);
			this.IsFilterValueEnabled = (#Od.Input.Options.SectionCapacityMethod == SectionCapacityMethodType.CriticalCapacity);
			this.CapacityRatioFilterValue = #l0b.#a.CapacityRatioFilterValue;
			this.IsCapacityRatioFilterActive = #l0b.#a.IsCapacityRatioFilterActive;
			this.LocationFilter = (this.Locations.FirstOrDefault(new Func<ComboItem<string>, bool>(#l0b.#15b)) ?? this.Locations.First<ComboItem<string>>());
			this.IsLocationFilterActive = #l0b.#a.IsLocationFilterActive;
			this.IsVisibilityFilterActive = #l0b.#a.IsVisibilityFilterActive;
			this.#WVh();
			base.View.ShowDialog();
		}

		// Token: 0x0600250A RID: 9482 RVA: 0x000D28C0 File Offset: 0x000D0AC0
		private void #WVh()
		{
			if (this.IsCapacityRatioFilterActive && this.IsFilterValueEnabled)
			{
				this.#XVh(this.CapacityRatioFilterValue, #Phc.#3hc(107406134));
				return;
			}
			base.RemoveError(#Phc.#3hc(107406134));
		}

		// Token: 0x0600250B RID: 9483 RVA: 0x000232B5 File Offset: 0x000214B5
		private bool #XVh(double #f, [CallerMemberName] string #em = null)
		{
			if (base.CheckIfPropertyHasErrors(#em))
			{
				base.RemoveError(#em);
			}
			if (#f > 0.0)
			{
				return true;
			}
			this.AddError(#em, Strings.StringValuesMustBeGreaterThanZero.#z2d());
			return false;
		}

		// Token: 0x0600250C RID: 9484 RVA: 0x000232F3 File Offset: 0x000214F3
		private void #6H(object #Sb)
		{
			this.DialogResult = new bool?(false);
			base.View.Close();
		}

		// Token: 0x0600250D RID: 9485 RVA: 0x000D2914 File Offset: 0x000D0B14
		private void #5H(object #Sb)
		{
			if (this.HasErrors)
			{
				string #SSc = base.DialogService.#5Sc(Strings.StringInvalidDataSpecified.#z2d(), Localization.StringPleaseFixValidationErrors.#z2d());
				base.Services.DialogService.#qn(base.ActiveWindow, #SSc);
				return;
			}
			if (this.LocationFilter == null)
			{
				return;
			}
			#Gse #Gse = base.Services.ReporterSettings.#Hse(null);
			this.DialogResult = new bool?(this.IsLocationFilterActive != #Gse.IsLocationFilterActive || this.LocationFilter.Value != #Gse.LocationFilter || this.IsCapacityRatioFilterActive != #Gse.IsCapacityRatioFilterActive || this.IsVisibilityFilterActive != #Gse.IsVisibilityFilterActive);
			if (this.IsFilterValueEnabled)
			{
				this.DialogResult = new bool?(this.DialogResult.GetValueOrDefault() || this.CapacityRatioFilterValue != #Gse.CapacityRatioFilterValue);
			}
			if (this.DialogResult.GetValueOrDefault())
			{
				if (this.IsFilterValueEnabled)
				{
					#Gse.CapacityRatioFilterValue = this.CapacityRatioFilterValue;
				}
				#Gse.IsCapacityRatioFilterActive = this.IsCapacityRatioFilterActive;
				#Gse.LocationFilter = this.LocationFilter.Value;
				#Gse.IsLocationFilterActive = this.IsLocationFilterActive;
				#Gse.IsVisibilityFilterActive = this.IsVisibilityFilterActive;
				base.Services.ReporterSettings.#lJ(#Gse);
			}
			base.View.Close();
		}

		// Token: 0x04000EB0 RID: 3760
		private double #a;

		// Token: 0x04000EB1 RID: 3761
		private bool #b;

		// Token: 0x04000EB2 RID: 3762
		private ComboItem<string> #c;

		// Token: 0x04000EB3 RID: 3763
		private bool #d;

		// Token: 0x04000EB4 RID: 3764
		private bool #e;

		// Token: 0x04000EB5 RID: 3765
		private bool #f;

		// Token: 0x04000EB6 RID: 3766
		private bool #g;

		// Token: 0x04000EB7 RID: 3767
		private bool #h;

		// Token: 0x04000EB8 RID: 3768
		[CompilerGenerated]
		private bool? #i;

		// Token: 0x04000EB9 RID: 3769
		[CompilerGenerated]
		private readonly IUnitValueFormatter #j;

		// Token: 0x04000EBA RID: 3770
		[CompilerGenerated]
		private readonly DelegateCommand #k;

		// Token: 0x04000EBB RID: 3771
		[CompilerGenerated]
		private readonly DelegateCommand #l;

		// Token: 0x04000EBC RID: 3772
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<string>> #m;

		// Token: 0x0200040F RID: 1039
		[CompilerGenerated]
		private sealed class #l0b
		{
			// Token: 0x0600250F RID: 9487 RVA: 0x00023318 File Offset: 0x00021518
			internal bool #15b(ComboItem<string> #Rf)
			{
				return #Rf.Value == this.#a.LocationFilter;
			}

			// Token: 0x04000EBD RID: 3773
			public #Gse #a;
		}
	}
}
