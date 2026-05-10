using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #5Kd;
using #7hc;
using #ezc;
using #qPd;
using #sUd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Framework;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Logger;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace #uLd
{
	// Token: 0x02000DE4 RID: 3556
	internal sealed class #xOd : #CBc<#7Kd>, INotifyPropertyChanged, #RBc<#7Kd>, IViewModel, #wPd
	{
		// Token: 0x06008088 RID: 32904 RVA: 0x001C0F10 File Offset: 0x001BF110
		public #xOd(#GBc #2x, #uUd #qy, #7Kd #Ee, ILogger #3x, #wUd #iw) : base(#2x, #Ee, #3x)
		{
			this.FeaturesDescriptor = #qy;
			this.#a = #iw;
			this.ExplorerPositions = new RadObservableCollection<ComboItem<ExplorerPosition>>
			{
				new ComboItem<ExplorerPosition>(ExplorerPosition.Right, Localization.StringRight),
				new ComboItem<ExplorerPosition>(ExplorerPosition.Left, Localization.StringLeft)
			};
			this.OkCommand = new DelegateCommand(new Action<object>(this.#5H), new Predicate<object>(this.#chb));
			this.CancelCommand = new DelegateCommand(new Action<object>(this.#6H));
			base.View.SetViewModel(this);
		}

		// Token: 0x1700265F RID: 9823
		// (get) Token: 0x06008089 RID: 32905 RVA: 0x00068AAF File Offset: 0x00066CAF
		// (set) Token: 0x0600808A RID: 32906 RVA: 0x00068ABB File Offset: 0x00066CBB
		public #uUd FeaturesDescriptor { get; private set; }

		// Token: 0x17002660 RID: 9824
		// (get) Token: 0x0600808B RID: 32907 RVA: 0x00068ACC File Offset: 0x00066CCC
		// (set) Token: 0x0600808C RID: 32908 RVA: 0x00068AD8 File Offset: 0x00066CD8
		public RadObservableCollection<ComboItem<ExplorerPosition>> ExplorerPositions { get; private set; }

		// Token: 0x17002661 RID: 9825
		// (get) Token: 0x0600808D RID: 32909 RVA: 0x00068AE9 File Offset: 0x00066CE9
		// (set) Token: 0x0600808E RID: 32910 RVA: 0x00068AF5 File Offset: 0x00066CF5
		public DelegateCommand OkCommand { get; private set; }

		// Token: 0x17002662 RID: 9826
		// (get) Token: 0x0600808F RID: 32911 RVA: 0x00068B06 File Offset: 0x00066D06
		// (set) Token: 0x06008090 RID: 32912 RVA: 0x00068B12 File Offset: 0x00066D12
		public DelegateCommand CancelCommand { get; private set; }

		// Token: 0x17002663 RID: 9827
		// (get) Token: 0x06008091 RID: 32913 RVA: 0x00068B23 File Offset: 0x00066D23
		// (set) Token: 0x06008092 RID: 32914 RVA: 0x00068B2F File Offset: 0x00066D2F
		public bool HighlightCriticalItems
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
					base.RaisePropertyChanged(#Phc.#3hc(107278075));
				}
			}
		}

		// Token: 0x17002664 RID: 9828
		// (get) Token: 0x06008093 RID: 32915 RVA: 0x00068B5D File Offset: 0x00066D5D
		// (set) Token: 0x06008094 RID: 32916 RVA: 0x00068B69 File Offset: 0x00066D69
		public Color CriticalItemsHighlightColor
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (\u008A\u0006.\u008B\u0010(this.#e, value))
				{
					this.#e = value;
					base.RaisePropertyChanged(#Phc.#3hc(107278042));
				}
			}
		}

		// Token: 0x17002665 RID: 9829
		// (get) Token: 0x06008095 RID: 32917 RVA: 0x00068BA1 File Offset: 0x00066DA1
		// (set) Token: 0x06008096 RID: 32918 RVA: 0x00068BAD File Offset: 0x00066DAD
		public bool HideInactiveItems
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
					base.RaisePropertyChanged(#Phc.#3hc(107278836));
				}
			}
		}

		// Token: 0x17002666 RID: 9830
		// (get) Token: 0x06008097 RID: 32919 RVA: 0x00068BDB File Offset: 0x00066DDB
		// (set) Token: 0x06008098 RID: 32920 RVA: 0x00068BE7 File Offset: 0x00066DE7
		public ComboItem<ExplorerPosition> SelectedExplorerPosition
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
					base.RaisePropertyChanged(#Phc.#3hc(107278749));
				}
			}
		}

		// Token: 0x17002667 RID: 9831
		// (get) Token: 0x06008099 RID: 32921 RVA: 0x00068C15 File Offset: 0x00066E15
		// (set) Token: 0x0600809A RID: 32922 RVA: 0x00068C21 File Offset: 0x00066E21
		public bool KeepExplorerConfiguration
		{
			get
			{
				return this.#j;
			}
			set
			{
				if (this.#j != value)
				{
					this.#j = value;
					base.RaisePropertyChanged(#Phc.#3hc(107278361));
				}
			}
		}

		// Token: 0x0600809B RID: 32923 RVA: 0x001C0FAC File Offset: 0x001BF1AC
		public void #jH(object #WSc)
		{
			this.SelectedExplorerPosition = (this.ExplorerPositions.FirstOrDefault(new Func<ComboItem<ExplorerPosition>, bool>(this.#wOd)) ?? this.ExplorerPositions.First<ComboItem<ExplorerPosition>>());
			this.HideInactiveItems = this.#a.ResultsExplorerHideInactiveItems;
			if (this.FeaturesDescriptor.SupportsHighlightingCriticalItems)
			{
				this.HighlightCriticalItems = this.#a.HighlightCriticalItems;
				this.CriticalItemsHighlightColor = this.#a.CriticalItemsHighlightingColor;
			}
			if (this.FeaturesDescriptor.SupportsKeepReporterConfiguration)
			{
				this.KeepExplorerConfiguration = this.#a.KeepResultsExplorerConfiguration;
			}
			base.View.SetOwner(#WSc);
			base.View.#TBc();
		}

		// Token: 0x0600809C RID: 32924 RVA: 0x00068C4F File Offset: 0x00066E4F
		private void #6H(object #Sb)
		{
			base.View.#Fgc();
		}

		// Token: 0x0600809D RID: 32925 RVA: 0x00003375 File Offset: 0x00001575
		private bool #chb(object #Sb)
		{
			return true;
		}

		// Token: 0x0600809E RID: 32926 RVA: 0x001C107C File Offset: 0x001BF27C
		private void #5H(object #Sb)
		{
			this.#a.ResultsExplorerPosition = this.SelectedExplorerPosition.Value;
			this.#a.ResultsExplorerHideInactiveItems = this.HideInactiveItems;
			if (this.FeaturesDescriptor.SupportsHighlightingCriticalItems)
			{
				this.#a.CriticalItemsHighlightingColor = this.CriticalItemsHighlightColor;
				this.#a.HighlightCriticalItems = this.HighlightCriticalItems;
			}
			if (this.FeaturesDescriptor.SupportsKeepReporterConfiguration)
			{
				this.#a.KeepResultsExplorerConfiguration = this.KeepExplorerConfiguration;
			}
			base.View.#Fgc();
		}

		// Token: 0x0600809F RID: 32927 RVA: 0x00068C68 File Offset: 0x00066E68
		[CompilerGenerated]
		private bool #wOd(ComboItem<ExplorerPosition> #Rf)
		{
			return #Rf.Value == this.#a.ResultsExplorerPosition;
		}

		// Token: 0x040034B5 RID: 13493
		private readonly #wUd #a;

		// Token: 0x040034B6 RID: 13494
		private ComboItem<ExplorerPosition> #b;

		// Token: 0x040034B7 RID: 13495
		private bool #c;

		// Token: 0x040034B8 RID: 13496
		private bool #d;

		// Token: 0x040034B9 RID: 13497
		private Color #e;

		// Token: 0x040034BA RID: 13498
		[CompilerGenerated]
		private #uUd #f;

		// Token: 0x040034BB RID: 13499
		[CompilerGenerated]
		private RadObservableCollection<ComboItem<ExplorerPosition>> #g;

		// Token: 0x040034BC RID: 13500
		[CompilerGenerated]
		private DelegateCommand #h;

		// Token: 0x040034BD RID: 13501
		[CompilerGenerated]
		private DelegateCommand #i;

		// Token: 0x040034BE RID: 13502
		private bool #j;
	}
}
