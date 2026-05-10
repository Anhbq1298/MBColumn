using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using #0Kd;
using #7hc;
using #ezc;
using #qPd;
using #sUd;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Framework;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Logger;
using Telerik.Windows.Data;

namespace #uLd
{
	// Token: 0x02000DDD RID: 3549
	internal sealed class #ANd : #CBc<#1Kd>, INotifyPropertyChanged, #RBc<#1Kd>, IViewModel, #uPd
	{
		// Token: 0x0600804A RID: 32842 RVA: 0x001C0978 File Offset: 0x001BEB78
		public #ANd(#GBc #2x, #1Kd #Ee, ILogger #3x, #wUd #iw, #uUd #qy, ICommandFactory #iB) : base(#2x, #Ee, #3x)
		{
			this.#a = #iw;
			this.FeaturesDescriptor = #qy;
			this.OkCommand = #iB.Create(new Action(this.#5H), new Func<bool>(this.#chb));
			this.CancelCommand = #iB.Create(new Action(this.#6H));
			this.ExplorerPositions = new RadObservableCollection<ComboItem<ExplorerPosition>>
			{
				new ComboItem<ExplorerPosition>(ExplorerPosition.Right, Localization.StringRight),
				new ComboItem<ExplorerPosition>(ExplorerPosition.Left, Localization.StringLeft)
			};
			this.FontSizes = new RadObservableCollection<ComboItem<ReportFontSizes>>
			{
				new ComboItem<ReportFontSizes>(ReportFontSizes.Small, Localization.StringSmall),
				new ComboItem<ReportFontSizes>(ReportFontSizes.Medium, Localization.StringMedium),
				new ComboItem<ReportFontSizes>(ReportFontSizes.Large, Localization.StringLarge)
			};
			base.View.SetViewModel(this);
		}

		// Token: 0x1700264E RID: 9806
		// (get) Token: 0x0600804B RID: 32843 RVA: 0x0006866D File Offset: 0x0006686D
		// (set) Token: 0x0600804C RID: 32844 RVA: 0x00068679 File Offset: 0x00066879
		public #uUd FeaturesDescriptor { get; private set; }

		// Token: 0x1700264F RID: 9807
		// (get) Token: 0x0600804D RID: 32845 RVA: 0x0006868A File Offset: 0x0006688A
		// (set) Token: 0x0600804E RID: 32846 RVA: 0x00068696 File Offset: 0x00066896
		public IDelegateCommand OkCommand { get; private set; }

		// Token: 0x17002650 RID: 9808
		// (get) Token: 0x0600804F RID: 32847 RVA: 0x000686A7 File Offset: 0x000668A7
		// (set) Token: 0x06008050 RID: 32848 RVA: 0x000686B3 File Offset: 0x000668B3
		public IDelegateCommand CancelCommand { get; private set; }

		// Token: 0x17002651 RID: 9809
		// (get) Token: 0x06008051 RID: 32849 RVA: 0x000686C4 File Offset: 0x000668C4
		// (set) Token: 0x06008052 RID: 32850 RVA: 0x000686D0 File Offset: 0x000668D0
		public bool KeepExplorerConfiguration
		{
			get
			{
				return this.#f;
			}
			set
			{
				if (this.#f != value)
				{
					this.#f = value;
					base.RaisePropertyChanged(#Phc.#3hc(107278361));
				}
			}
		}

		// Token: 0x17002652 RID: 9810
		// (get) Token: 0x06008053 RID: 32851 RVA: 0x000686FE File Offset: 0x000668FE
		// (set) Token: 0x06008054 RID: 32852 RVA: 0x0006870A File Offset: 0x0006690A
		public bool HideInactiveItems
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
					base.RaisePropertyChanged(#Phc.#3hc(107278836));
				}
			}
		}

		// Token: 0x17002653 RID: 9811
		// (get) Token: 0x06008055 RID: 32853 RVA: 0x00068738 File Offset: 0x00066938
		// (set) Token: 0x06008056 RID: 32854 RVA: 0x00068744 File Offset: 0x00066944
		public bool SplitLongTables
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
					base.RaisePropertyChanged(#Phc.#3hc(107278811));
				}
			}
		}

		// Token: 0x17002654 RID: 9812
		// (get) Token: 0x06008057 RID: 32855 RVA: 0x00068772 File Offset: 0x00066972
		// (set) Token: 0x06008058 RID: 32856 RVA: 0x0006877E File Offset: 0x0006697E
		public bool RegenerateReportAutomatically
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
					base.RaisePropertyChanged(#Phc.#3hc(107278758));
				}
			}
		}

		// Token: 0x17002655 RID: 9813
		// (get) Token: 0x06008059 RID: 32857 RVA: 0x000687AC File Offset: 0x000669AC
		// (set) Token: 0x0600805A RID: 32858 RVA: 0x000687B8 File Offset: 0x000669B8
		public RadObservableCollection<ComboItem<ReportFontSizes>> FontSizes { get; private set; }

		// Token: 0x17002656 RID: 9814
		// (get) Token: 0x0600805B RID: 32859 RVA: 0x000687C9 File Offset: 0x000669C9
		// (set) Token: 0x0600805C RID: 32860 RVA: 0x000687D5 File Offset: 0x000669D5
		public RadObservableCollection<ComboItem<ExplorerPosition>> ExplorerPositions { get; private set; }

		// Token: 0x17002657 RID: 9815
		// (get) Token: 0x0600805D RID: 32861 RVA: 0x000687E6 File Offset: 0x000669E6
		// (set) Token: 0x0600805E RID: 32862 RVA: 0x000687F2 File Offset: 0x000669F2
		public ComboItem<ExplorerPosition> SelectedExplorerPosition
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
					base.RaisePropertyChanged(#Phc.#3hc(107278749));
				}
			}
		}

		// Token: 0x17002658 RID: 9816
		// (get) Token: 0x0600805F RID: 32863 RVA: 0x00068820 File Offset: 0x00066A20
		// (set) Token: 0x06008060 RID: 32864 RVA: 0x0006882C File Offset: 0x00066A2C
		public ComboItem<ReportFontSizes> SelectedFontSize
		{
			get
			{
				return this.#l;
			}
			set
			{
				if (this.#l != value)
				{
					this.#l = value;
					base.RaisePropertyChanged(#Phc.#3hc(107278716));
				}
			}
		}

		// Token: 0x06008061 RID: 32865 RVA: 0x001C0A54 File Offset: 0x001BEC54
		public void #jH(object #WSc)
		{
			this.SplitLongTables = this.#a.ReporterSplitLongTables;
			this.RegenerateReportAutomatically = this.#a.ReporterRegenerateReportAutomatically;
			this.SelectedExplorerPosition = (this.ExplorerPositions.FirstOrDefault(new Func<ComboItem<ExplorerPosition>, bool>(this.#yNd)) ?? this.ExplorerPositions.First<ComboItem<ExplorerPosition>>());
			this.HideInactiveItems = this.#a.ReporterExplorerHideInactiveItems;
			this.SelectedFontSize = (this.FontSizes.FirstOrDefault(new Func<ComboItem<ReportFontSizes>, bool>(this.#zNd)) ?? this.FontSizes.Last<ComboItem<ReportFontSizes>>());
			if (this.FeaturesDescriptor.SupportsKeepReporterConfiguration)
			{
				this.KeepExplorerConfiguration = this.#a.KeepReporterExplorerConfiguration;
			}
			base.View.SetOwner(#WSc);
			base.View.#TBc();
		}

		// Token: 0x06008062 RID: 32866 RVA: 0x0006885A File Offset: 0x00066A5A
		private void #6H()
		{
			base.View.#Fgc();
		}

		// Token: 0x06008063 RID: 32867 RVA: 0x00003375 File Offset: 0x00001575
		private bool #chb()
		{
			return true;
		}

		// Token: 0x06008064 RID: 32868 RVA: 0x001C0B40 File Offset: 0x001BED40
		private void #5H()
		{
			this.#a.ReporterSplitLongTables = this.SplitLongTables;
			this.#a.ReporterRegenerateReportAutomatically = this.RegenerateReportAutomatically;
			this.#a.ReporterExplorerPosition = this.SelectedExplorerPosition.Value;
			this.#a.ReporterExplorerHideInactiveItems = this.HideInactiveItems;
			this.#a.ReportFontSize = this.SelectedFontSize.Value;
			if (this.FeaturesDescriptor.SupportsKeepReporterConfiguration)
			{
				this.#a.KeepReporterExplorerConfiguration = this.KeepExplorerConfiguration;
			}
			base.View.#Fgc();
		}

		// Token: 0x06008065 RID: 32869 RVA: 0x00068873 File Offset: 0x00066A73
		[CompilerGenerated]
		private bool #yNd(ComboItem<ExplorerPosition> #Rf)
		{
			return #Rf.Value == this.#a.ReporterExplorerPosition;
		}

		// Token: 0x06008066 RID: 32870 RVA: 0x00068894 File Offset: 0x00066A94
		[CompilerGenerated]
		private bool #zNd(ComboItem<ReportFontSizes> #Rf)
		{
			return #Rf.Value == this.#a.ReportFontSize;
		}

		// Token: 0x0400349E RID: 13470
		private readonly #wUd #a;

		// Token: 0x0400349F RID: 13471
		private bool #b;

		// Token: 0x040034A0 RID: 13472
		private bool #c;

		// Token: 0x040034A1 RID: 13473
		private ComboItem<ExplorerPosition> #d;

		// Token: 0x040034A2 RID: 13474
		private bool #e;

		// Token: 0x040034A3 RID: 13475
		private bool #f;

		// Token: 0x040034A4 RID: 13476
		[CompilerGenerated]
		private #uUd #g;

		// Token: 0x040034A5 RID: 13477
		[CompilerGenerated]
		private IDelegateCommand #h;

		// Token: 0x040034A6 RID: 13478
		[CompilerGenerated]
		private IDelegateCommand #i;

		// Token: 0x040034A7 RID: 13479
		[CompilerGenerated]
		private RadObservableCollection<ComboItem<ReportFontSizes>> #j;

		// Token: 0x040034A8 RID: 13480
		[CompilerGenerated]
		private RadObservableCollection<ComboItem<ExplorerPosition>> #k;

		// Token: 0x040034A9 RID: 13481
		private ComboItem<ReportFontSizes> #l;
	}
}
