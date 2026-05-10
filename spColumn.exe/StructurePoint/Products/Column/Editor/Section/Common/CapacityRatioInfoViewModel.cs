using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #7hc;
using #aHb;
using #lH;
using #oKe;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Resources.Images;
using StructurePoint.Products.Column.Services.API;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.Editor.Section.Common
{
	// Token: 0x020005FC RID: 1532
	internal sealed class CapacityRatioInfoViewModel : #rH<#9Gb>, INotifyPropertyChanged, IViewModel, #kH<#9Gb>, IViewModel<#9Gb>, #bHb
	{
		// Token: 0x06003471 RID: 13425 RVA: 0x00104D38 File Offset: 0x00102F38
		public CapacityRatioInfoViewModel(Lazy<#9Gb> view, IExtendedServices services, #nKe localization) : base(view, services, Strings.StringCapacityRatio_SENTENCE)
		{
			this.#b = services;
			this.SectionCapacity.AddRange(localization.AvailableSectionCapacity.Select(new Func<KeyValuePair<SectionCapacityMethodType, string>, ComboItem<SectionCapacityMethodType>>(CapacityRatioInfoViewModel.<>c.<>9.#mbc)));
			this.#e = new DelegateCommand(new Action<object>(this.#iHb));
		}

		// Token: 0x17001075 RID: 4213
		// (get) Token: 0x06003472 RID: 13426 RVA: 0x0002E2A2 File Offset: 0x0002C4A2
		// (set) Token: 0x06003473 RID: 13427 RVA: 0x0002E2AE File Offset: 0x0002C4AE
		public bool IsEnabledMomentCapacity
		{
			get
			{
				return this.#d;
			}
			set
			{
				this.SetProperty<bool>(ref this.#d, value, #Phc.#3hc(107353403));
			}
		}

		// Token: 0x17001076 RID: 4214
		// (get) Token: 0x06003474 RID: 13428 RVA: 0x0002E2D4 File Offset: 0x0002C4D4
		public DelegateCommand ChangeCapacityTypeCommand { get; }

		// Token: 0x17001077 RID: 4215
		// (get) Token: 0x06003475 RID: 13429 RVA: 0x0002E2E0 File Offset: 0x0002C4E0
		public RadObservableCollection<ComboItem<SectionCapacityMethodType>> SectionCapacity { get; }

		// Token: 0x17001078 RID: 4216
		// (get) Token: 0x06003476 RID: 13430 RVA: 0x0002E2EC File Offset: 0x0002C4EC
		// (set) Token: 0x06003477 RID: 13431 RVA: 0x0002E2F8 File Offset: 0x0002C4F8
		public ComboItem<SectionCapacityMethodType> SelectedSectionCapacity
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.SetProperty<ComboItem<SectionCapacityMethodType>>(ref this.#c, value, #Phc.#3hc(107409091));
				this.#jHb(value.Value);
			}
		}

		// Token: 0x17001079 RID: 4217
		// (get) Token: 0x06003478 RID: 13432 RVA: 0x0002E32A File Offset: 0x0002C52A
		// (set) Token: 0x06003479 RID: 13433 RVA: 0x0002E336 File Offset: 0x0002C536
		public ImageSource DisplayImage
		{
			get
			{
				return this.#a;
			}
			private set
			{
				if (this.#a != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107353370));
					this.#a = value;
					base.RaisePropertyChanged(#Phc.#3hc(107353370));
				}
			}
		}

		// Token: 0x1700107A RID: 4218
		// (get) Token: 0x0600347A RID: 13434 RVA: 0x0002E374 File Offset: 0x0002C574
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x0600347B RID: 13435 RVA: 0x00104DB0 File Offset: 0x00102FB0
		protected override void #0l()
		{
			this.#jHb(base.Project.Model.Options.SectionCapacityMethod);
			this.SelectedSectionCapacity = this.SectionCapacity.FirstOrDefault(new Func<ComboItem<SectionCapacityMethodType>, bool>(this.#Qwf));
			base.#0l();
		}

		// Token: 0x0600347C RID: 13436 RVA: 0x00104E08 File Offset: 0x00103008
		private void #iHb(object #Vg)
		{
			CapacityRatioInfoViewModel.#CTb #CTb = new CapacityRatioInfoViewModel.#CTb();
			#CTb.#a = ((this.SelectedSectionCapacity.Value == SectionCapacityMethodType.CriticalCapacity) ? SectionCapacityMethodType.MomentCapacity : SectionCapacityMethodType.CriticalCapacity);
			this.#jHb(#CTb.#a);
			this.SelectedSectionCapacity = this.SectionCapacity.FirstOrDefault(new Func<ComboItem<SectionCapacityMethodType>, bool>(#CTb.#nbc));
		}

		// Token: 0x0600347D RID: 13437 RVA: 0x00104E68 File Offset: 0x00103068
		private void #jHb(SectionCapacityMethodType #kHb)
		{
			if (#kHb == SectionCapacityMethodType.MomentCapacity)
			{
				this.IsEnabledMomentCapacity = false;
				base.Title = Strings.StringMomentCapacity;
				this.DisplayImage = ColumnImages.MomentCapacity_275X300;
				return;
			}
			if (#kHb != SectionCapacityMethodType.CriticalCapacity)
			{
				return;
			}
			this.IsEnabledMomentCapacity = true;
			base.Title = Strings.StringCriticalCapacity;
			this.DisplayImage = ColumnImages.CriticalCapacity_275X300;
		}

		// Token: 0x0600347E RID: 13438 RVA: 0x0000C67D File Offset: 0x0000A87D
		bool #kH<#9Gb>.#lHb()
		{
			return base.IsValid;
		}

		// Token: 0x0600347F RID: 13439 RVA: 0x00104EC4 File Offset: 0x001030C4
		[CompilerGenerated]
		private bool #Qwf(ComboItem<SectionCapacityMethodType> #9o)
		{
			return #9o.Value.Equals(base.Project.Model.Options.SectionCapacityMethod);
		}

		// Token: 0x040015AE RID: 5550
		private ImageSource #a;

		// Token: 0x040015AF RID: 5551
		private readonly IExtendedServices #b;

		// Token: 0x040015B0 RID: 5552
		private ComboItem<SectionCapacityMethodType> #c;

		// Token: 0x040015B1 RID: 5553
		private bool #d;

		// Token: 0x040015B2 RID: 5554
		[CompilerGenerated]
		private readonly DelegateCommand #e;

		// Token: 0x040015B3 RID: 5555
		[CompilerGenerated]
		private readonly RadObservableCollection<ComboItem<SectionCapacityMethodType>> #f = new RadObservableCollection<ComboItem<SectionCapacityMethodType>>();

		// Token: 0x020005FE RID: 1534
		[CompilerGenerated]
		private sealed class #CTb
		{
			// Token: 0x06003484 RID: 13444 RVA: 0x00104F0C File Offset: 0x0010310C
			internal bool #nbc(ComboItem<SectionCapacityMethodType> #9o)
			{
				return #9o.Value.Equals(this.#a);
			}

			// Token: 0x040015B6 RID: 5558
			public SectionCapacityMethodType #a;
		}
	}
}
