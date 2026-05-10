using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #0I;
using #7hc;
using #Lx;
using #oKe;
using #Ot;
using #pc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.ViewModels.Settings
{
	// Token: 0x0200018D RID: 397
	internal sealed class GeneralStartupDefaultsViewModel : #ex<#yc>, #5I, IPanel, IChangesInfo, #Ux
	{
		// Token: 0x06000D17 RID: 3351 RVA: 0x0009D550 File Offset: 0x0009B750
		public GeneralStartupDefaultsViewModel(Lazy<#yc> view, ICoreServices services, #nKe localization, ISettingsManager settingsManager) : base(view, services)
		{
			this.#a = settingsManager;
			this.#5w(localization);
		}

		// Token: 0x1700053C RID: 1340
		// (get) Token: 0x06000D18 RID: 3352 RVA: 0x0001034D File Offset: 0x0000E54D
		public RadObservableCollection<ComboItem<DesignCodes>> DesignCodesComboItems { get; }

		// Token: 0x1700053D RID: 1341
		// (get) Token: 0x06000D19 RID: 3353 RVA: 0x00010359 File Offset: 0x0000E559
		public RadObservableCollection<ComboItem<UnitSystem>> UnitSystemsComboItems { get; }

		// Token: 0x1700053E RID: 1342
		// (get) Token: 0x06000D1A RID: 3354 RVA: 0x00010365 File Offset: 0x0000E565
		public RadObservableCollection<ComboItem<BarGroupType>> BarGroupTypeComboItems { get; }

		// Token: 0x1700053F RID: 1343
		// (get) Token: 0x06000D1B RID: 3355 RVA: 0x00010371 File Offset: 0x0000E571
		public RadObservableCollection<ComboItem<SectionCapacityMethodType>> SectionCapacityComboItems { get; }

		// Token: 0x17000540 RID: 1344
		// (get) Token: 0x06000D1C RID: 3356 RVA: 0x0001037D File Offset: 0x0000E57D
		// (set) Token: 0x06000D1D RID: 3357 RVA: 0x00010389 File Offset: 0x0000E589
		public ComboItem<DesignCodes> SelectedDesignCode
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107409714));
					this.#b = value;
					base.RaisePropertyChanged(#Phc.#3hc(107409714));
				}
			}
		}

		// Token: 0x17000541 RID: 1345
		// (get) Token: 0x06000D1E RID: 3358 RVA: 0x000103C7 File Offset: 0x0000E5C7
		// (set) Token: 0x06000D1F RID: 3359 RVA: 0x000103D3 File Offset: 0x0000E5D3
		public ComboItem<UnitSystem> SelectedUnitSystem
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107409689));
					this.#c = value;
					base.RaisePropertyChanged(#Phc.#3hc(107409689));
				}
			}
		}

		// Token: 0x17000542 RID: 1346
		// (get) Token: 0x06000D20 RID: 3360 RVA: 0x00010411 File Offset: 0x0000E611
		// (set) Token: 0x06000D21 RID: 3361 RVA: 0x0001041D File Offset: 0x0000E61D
		public ComboItem<BarGroupType> SelectedBarGroupType
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.#d != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107409120));
					this.#d = value;
					base.RaisePropertyChanged(#Phc.#3hc(107409120));
				}
			}
		}

		// Token: 0x17000543 RID: 1347
		// (get) Token: 0x06000D22 RID: 3362 RVA: 0x0001045B File Offset: 0x0000E65B
		// (set) Token: 0x06000D23 RID: 3363 RVA: 0x00010467 File Offset: 0x0000E667
		public ComboItem<SectionCapacityMethodType> SelectedSectionCapacity
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (this.#e != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107409091));
					this.#e = value;
					base.RaisePropertyChanged(#Phc.#3hc(107409091));
				}
			}
		}

		// Token: 0x17000544 RID: 1348
		// (get) Token: 0x06000D24 RID: 3364 RVA: 0x000104A5 File Offset: 0x0000E6A5
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06000D25 RID: 3365 RVA: 0x0009D5A0 File Offset: 0x0009B7A0
		public bool GetHasChanges()
		{
			return this.SelectedDesignCode != this.DesignCodesComboItems.Single(new Func<ComboItem<DesignCodes>, bool>(this.#OTh)) || this.SelectedUnitSystem != this.UnitSystemsComboItems.Single(new Func<ComboItem<UnitSystem>, bool>(this.#PTh)) || this.SelectedBarGroupType != this.BarGroupTypeComboItems.Single(new Func<ComboItem<BarGroupType>, bool>(this.#QTh)) || this.SelectedSectionCapacity != this.SectionCapacityComboItems.Single(new Func<ComboItem<SectionCapacityMethodType>, bool>(this.#RTh));
		}

		// Token: 0x06000D26 RID: 3366 RVA: 0x0009D64C File Offset: 0x0009B84C
		public override void UpdateFromModel(ColumnModel model)
		{
			this.SelectedDesignCode = this.DesignCodesComboItems.Single(new Func<ComboItem<DesignCodes>, bool>(this.#STh));
			this.SelectedUnitSystem = this.UnitSystemsComboItems.Single(new Func<ComboItem<UnitSystem>, bool>(this.#TTh));
			this.SelectedBarGroupType = (this.BarGroupTypeComboItems.FirstOrDefault(new Func<ComboItem<BarGroupType>, bool>(this.#UTh)) ?? this.BarGroupTypeComboItems.First<ComboItem<BarGroupType>>());
			this.SelectedSectionCapacity = this.SectionCapacityComboItems.Single(new Func<ComboItem<SectionCapacityMethodType>, bool>(this.#VTh));
		}

		// Token: 0x06000D27 RID: 3367 RVA: 0x0009D6FC File Offset: 0x0009B8FC
		public override void UpdateModel(ColumnModel model)
		{
			this.#a.StartupDefaultDesignCode = this.SelectedDesignCode.Value;
			this.#a.StartupDefaultUnitSystem = this.SelectedUnitSystem.Value;
			this.#a.StartupDefaultBarGroupType = this.SelectedBarGroupType.Value;
			this.#a.StartupDefaultSectionCapacity = this.SelectedSectionCapacity.Value;
		}

		// Token: 0x06000D28 RID: 3368 RVA: 0x0009D770 File Offset: 0x0009B970
		public override void #qt()
		{
			this.SelectedDesignCode = this.DesignCodesComboItems.Single(new Func<ComboItem<DesignCodes>, bool>(GeneralStartupDefaultsViewModel.<>c.<>9.#oXh));
			this.SelectedUnitSystem = this.UnitSystemsComboItems.Single(new Func<ComboItem<UnitSystem>, bool>(GeneralStartupDefaultsViewModel.<>c.<>9.#pXh));
			this.SelectedBarGroupType = this.BarGroupTypeComboItems.Single(new Func<ComboItem<BarGroupType>, bool>(GeneralStartupDefaultsViewModel.<>c.<>9.#qXh));
			this.SelectedSectionCapacity = this.SectionCapacityComboItems.Single(new Func<ComboItem<SectionCapacityMethodType>, bool>(GeneralStartupDefaultsViewModel.<>c.<>9.#rXh));
		}

		// Token: 0x06000D29 RID: 3369 RVA: 0x0009D85C File Offset: 0x0009BA5C
		private void #5w(#nKe #ps)
		{
			this.DesignCodesComboItems.AddRange(#ps.AvailableDesignCodes.Select(new Func<KeyValuePair<DesignCodes, string>, ComboItem<DesignCodes>>(GeneralStartupDefaultsViewModel.<>c.<>9.#sXh)));
			this.UnitSystemsComboItems.AddRange(#ps.AvailableUnitSystems.Select(new Func<KeyValuePair<UnitSystem, string>, ComboItem<UnitSystem>>(GeneralStartupDefaultsViewModel.<>c.<>9.#tXh)));
			this.BarGroupTypeComboItems.AddRange(#ps.AvailableBarGroupTypes.Where(new Func<KeyValuePair<BarGroupType, string>, bool>(GeneralStartupDefaultsViewModel.<>c.<>9.#uXh)).Select(new Func<KeyValuePair<BarGroupType, string>, ComboItem<BarGroupType>>(GeneralStartupDefaultsViewModel.<>c.<>9.#vXh)));
			this.SectionCapacityComboItems.AddRange(#ps.AvailableSectionCapacity.Select(new Func<KeyValuePair<SectionCapacityMethodType, string>, ComboItem<SectionCapacityMethodType>>(GeneralStartupDefaultsViewModel.<>c.<>9.#wXh)));
		}

		// Token: 0x06000D2A RID: 3370 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.#Lr()
		{
			base.ClearErrors();
		}

		// Token: 0x06000D2B RID: 3371 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.#Or(string #em)
		{
			base.RemoveError(#em);
		}

		// Token: 0x06000D2C RID: 3372 RVA: 0x0009D980 File Offset: 0x0009BB80
		[CompilerGenerated]
		private bool #OTh(ComboItem<DesignCodes> #9o)
		{
			return #9o.Value.Equals(this.#a.StartupDefaultDesignCode);
		}

		// Token: 0x06000D2D RID: 3373 RVA: 0x0009D9C0 File Offset: 0x0009BBC0
		[CompilerGenerated]
		private bool #PTh(ComboItem<UnitSystem> #9o)
		{
			return #9o.Value.Equals(this.#a.StartupDefaultUnitSystem);
		}

		// Token: 0x06000D2E RID: 3374 RVA: 0x0009DA00 File Offset: 0x0009BC00
		[CompilerGenerated]
		private bool #QTh(ComboItem<BarGroupType> #9o)
		{
			return #9o.Value.Equals(this.#a.StartupDefaultBarGroupType);
		}

		// Token: 0x06000D2F RID: 3375 RVA: 0x0009DA40 File Offset: 0x0009BC40
		[CompilerGenerated]
		private bool #RTh(ComboItem<SectionCapacityMethodType> #9o)
		{
			return #9o.Value.Equals(this.#a.StartupDefaultSectionCapacity);
		}

		// Token: 0x06000D30 RID: 3376 RVA: 0x0009D980 File Offset: 0x0009BB80
		[CompilerGenerated]
		private bool #STh(ComboItem<DesignCodes> #9o)
		{
			return #9o.Value.Equals(this.#a.StartupDefaultDesignCode);
		}

		// Token: 0x06000D31 RID: 3377 RVA: 0x0009D9C0 File Offset: 0x0009BBC0
		[CompilerGenerated]
		private bool #TTh(ComboItem<UnitSystem> #9o)
		{
			return #9o.Value.Equals(this.#a.StartupDefaultUnitSystem);
		}

		// Token: 0x06000D32 RID: 3378 RVA: 0x0009DA00 File Offset: 0x0009BC00
		[CompilerGenerated]
		private bool #UTh(ComboItem<BarGroupType> #9o)
		{
			return #9o.Value.Equals(this.#a.StartupDefaultBarGroupType);
		}

		// Token: 0x06000D33 RID: 3379 RVA: 0x0009DA40 File Offset: 0x0009BC40
		[CompilerGenerated]
		private bool #VTh(ComboItem<SectionCapacityMethodType> #9o)
		{
			return #9o.Value.Equals(this.#a.StartupDefaultSectionCapacity);
		}

		// Token: 0x040004D8 RID: 1240
		private readonly ISettingsManager #a;

		// Token: 0x040004D9 RID: 1241
		private ComboItem<DesignCodes> #b;

		// Token: 0x040004DA RID: 1242
		private ComboItem<UnitSystem> #c;

		// Token: 0x040004DB RID: 1243
		private ComboItem<BarGroupType> #d;

		// Token: 0x040004DC RID: 1244
		private ComboItem<SectionCapacityMethodType> #e;

		// Token: 0x040004DD RID: 1245
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<DesignCodes>> #f = new RadObservableCollection<ComboItem<DesignCodes>>();

		// Token: 0x040004DE RID: 1246
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<UnitSystem>> #g = new RadObservableCollection<ComboItem<UnitSystem>>();

		// Token: 0x040004DF RID: 1247
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<BarGroupType>> #h = new RadObservableCollection<ComboItem<BarGroupType>>();

		// Token: 0x040004E0 RID: 1248
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<SectionCapacityMethodType>> #i = new RadObservableCollection<ComboItem<SectionCapacityMethodType>>();
	}
}
