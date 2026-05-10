using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using #7hc;
using #c1d;
using #Eb;
using #ede;
using #eU;
using #ID;
using #lH;
using #pXd;
using #v1c;
using #WB;
using #xKe;
using Alphaleonis.Win32.Filesystem;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.CoreAssets.Units;
using StructurePoint.CoreAssets.Units.UnitSets;
using StructurePoint.Kernel.CoreAssets.Importer.DataClasses;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;
using Telerik.Windows.Controls;

namespace StructurePoint.Products.Column.ViewModels.Etabs
{
	// Token: 0x02000217 RID: 535
	internal sealed class EtabsImportWindowViewModel : #HH<#Db>, INotifyPropertyChanged, IViewModel<#Db>, IViewModel, #oF
	{
		// Token: 0x060011FC RID: 4604 RVA: 0x000AA1CC File Offset: 0x000A83CC
		public EtabsImportWindowViewModel(Lazy<#Db> view, ICoreServices services, #pF etabsService) : base(view, services)
		{
			this.#a = etabsService;
			this.#A = new DelegateCommand(new Action<object>(this.#Wg), new Predicate<object>(this.#2E));
			this.#B = new DelegateCommand(new Action<object>(this.#SE), new Predicate<object>(this.#UE));
			this.#C = new DelegateCommand(new Action<object>(this.#QE), new Predicate<object>(this.#RE));
			this.#D = new DelegateCommand(new Action<object>(this.#4E), new Predicate<object>(this.#3E));
			this.#E = new DelegateCommand(new Action<object>(this.#Ug), new Predicate<object>(this.#Zo));
			this.#F = new DelegateCommand(new Action<object>(this.#JE), new Predicate<object>(this.#IE));
			this.#G = new DelegateCommand(new Action<object>(this.#KE), new Predicate<object>(this.#IE));
			this.#R = new DelegateCommand(new Action<object>(this.#HE));
			this.#S = new DelegateCommand(new Action<object>(this.#GE));
			this.#T = new DelegateCommand(new Action<object>(this.#EE), new Predicate<object>(this.#FE));
			this.StationTypesItems.Add(new ComboItem<StationTypes>(StationTypes.OnlyTopAndBottom, Strings.StringTopAndBot));
			this.StationTypesItems.Add(new ComboItem<StationTypes>(StationTypes.All, Strings.StringAll));
			this.StationTypesItems.Add(new ComboItem<StationTypes>(StationTypes.OnlyTop, Strings.StringTop));
			this.StationTypesItems.Add(new ComboItem<StationTypes>(StationTypes.OnlyBottom, Strings.StringBotDot));
			this.#v = this.StationTypesItems[1];
			base.Services.MessageBus.ProjectLoaded += this.#Gh;
			this.#p = false;
			this.#o = null;
			this.IsModelLoaded = false;
			this.IsWorking = false;
			this.ProjectPath = null;
		}

		// Token: 0x1700069E RID: 1694
		// (get) Token: 0x060011FD RID: 4605 RVA: 0x00013CD3 File Offset: 0x00011ED3
		// (set) Token: 0x060011FE RID: 4606 RVA: 0x00013CDF File Offset: 0x00011EDF
		public UnitSystem CurrentUnit
		{
			get
			{
				return this.#y;
			}
			private set
			{
				if (this.SetProperty<UnitSystem>(ref this.#y, value, null))
				{
					base.RaisePropertyChanged(#Phc.#3hc(107408629));
				}
			}
		}

		// Token: 0x1700069F RID: 1695
		// (get) Token: 0x060011FF RID: 4607 RVA: 0x00013D0D File Offset: 0x00011F0D
		public DelegateCommand ImportCommand { get; }

		// Token: 0x170006A0 RID: 1696
		// (get) Token: 0x06001200 RID: 4608 RVA: 0x00013D19 File Offset: 0x00011F19
		public DelegateCommand BrowseCommand { get; }

		// Token: 0x170006A1 RID: 1697
		// (get) Token: 0x06001201 RID: 4609 RVA: 0x00013D25 File Offset: 0x00011F25
		public DelegateCommand LoadModelCommand { get; }

		// Token: 0x170006A2 RID: 1698
		// (get) Token: 0x06001202 RID: 4610 RVA: 0x00013D31 File Offset: 0x00011F31
		public DelegateCommand SaveAsXmlCommand { get; }

		// Token: 0x170006A3 RID: 1699
		// (get) Token: 0x06001203 RID: 4611 RVA: 0x00013D3D File Offset: 0x00011F3D
		public DelegateCommand CloseCommand { get; }

		// Token: 0x170006A4 RID: 1700
		// (get) Token: 0x06001204 RID: 4612 RVA: 0x00013D49 File Offset: 0x00011F49
		public DelegateCommand ButtonAddCommand { get; }

		// Token: 0x170006A5 RID: 1701
		// (get) Token: 0x06001205 RID: 4613 RVA: 0x00013D55 File Offset: 0x00011F55
		public DelegateCommand ButtonRemoveCommand { get; }

		// Token: 0x170006A6 RID: 1702
		// (get) Token: 0x06001206 RID: 4614 RVA: 0x00013D61 File Offset: 0x00011F61
		public CustomObservableCollection<ComboItem<string>> ColumnLabelComboItems { get; }

		// Token: 0x170006A7 RID: 1703
		// (get) Token: 0x06001207 RID: 4615 RVA: 0x00013D6D File Offset: 0x00011F6D
		public CustomObservableCollection<ComboItem<string>> ColumnSectionComboItems { get; }

		// Token: 0x170006A8 RID: 1704
		// (get) Token: 0x06001208 RID: 4616 RVA: 0x00013D79 File Offset: 0x00011F79
		public CustomObservableCollection<LoadCombinationItem> CombinationsItems { get; }

		// Token: 0x170006A9 RID: 1705
		// (get) Token: 0x06001209 RID: 4617 RVA: 0x00013D85 File Offset: 0x00011F85
		public CustomObservableCollection<LoadCombinationItem> CombinationsItemsChosen { get; }

		// Token: 0x170006AA RID: 1706
		// (get) Token: 0x0600120A RID: 4618 RVA: 0x00013D91 File Offset: 0x00011F91
		public CustomObservableCollection<ComboItem<string>> PierLabelComboItems { get; }

		// Token: 0x170006AB RID: 1707
		// (get) Token: 0x0600120B RID: 4619 RVA: 0x00013D9D File Offset: 0x00011F9D
		public CustomObservableCollection<ComboItem<string>> SingleStoryComboItems { get; }

		// Token: 0x170006AC RID: 1708
		// (get) Token: 0x0600120C RID: 4620 RVA: 0x00013DA9 File Offset: 0x00011FA9
		public CustomObservableCollection<ComboItem<string>> FromStoryComboItems { get; }

		// Token: 0x170006AD RID: 1709
		// (get) Token: 0x0600120D RID: 4621 RVA: 0x00013DB5 File Offset: 0x00011FB5
		public CustomObservableCollection<ComboItem<string>> ToStoryComboItems { get; }

		// Token: 0x170006AE RID: 1710
		// (get) Token: 0x0600120E RID: 4622 RVA: 0x00013DC1 File Offset: 0x00011FC1
		public CustomObservableCollection<ComboItem<StationTypes>> StationTypesItems { get; }

		// Token: 0x170006AF RID: 1711
		// (get) Token: 0x0600120F RID: 4623 RVA: 0x00013DCD File Offset: 0x00011FCD
		public CustomObservableCollection<PreviewItem> PreviewItems { get; }

		// Token: 0x170006B0 RID: 1712
		// (get) Token: 0x06001210 RID: 4624 RVA: 0x00013DD9 File Offset: 0x00011FD9
		public DelegateCommand HandleCombinationSelectionChangedCommand { get; }

		// Token: 0x170006B1 RID: 1713
		// (get) Token: 0x06001211 RID: 4625 RVA: 0x00013DE5 File Offset: 0x00011FE5
		public DelegateCommand HandlePreviewTabPreviewLeftMouseButtonDownCommand { get; }

		// Token: 0x170006B2 RID: 1714
		// (get) Token: 0x06001212 RID: 4626 RVA: 0x00013DF1 File Offset: 0x00011FF1
		public DelegateCommand ExportToCsvCommand { get; }

		// Token: 0x170006B3 RID: 1715
		// (get) Token: 0x06001213 RID: 4627 RVA: 0x00013DFD File Offset: 0x00011FFD
		// (set) Token: 0x06001214 RID: 4628 RVA: 0x000AA450 File Offset: 0x000A8650
		public string ProjectPath
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107408580));
					this.#b = value;
					this.#vh();
					base.RaisePropertyChanged(#Phc.#3hc(107408580));
				}
			}
		}

		// Token: 0x170006B4 RID: 1716
		// (get) Token: 0x06001215 RID: 4629 RVA: 0x00013E09 File Offset: 0x00012009
		// (set) Token: 0x06001216 RID: 4630 RVA: 0x000AA4A4 File Offset: 0x000A86A4
		public bool IsWorking
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107412993));
					this.#c = value;
					this.#vh();
					base.RaisePropertyChanged(#Phc.#3hc(107412993));
				}
			}
		}

		// Token: 0x170006B5 RID: 1717
		// (get) Token: 0x06001217 RID: 4631 RVA: 0x00013E15 File Offset: 0x00012015
		// (set) Token: 0x06001218 RID: 4632 RVA: 0x000AA4F4 File Offset: 0x000A86F4
		public bool IsModelLoaded
		{
			get
			{
				return this.#d;
			}
			private set
			{
				if (this.#d != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107408595));
					this.#d = value;
					this.#vh();
					base.RaisePropertyChanged(#Phc.#3hc(107408595));
				}
			}
		}

		// Token: 0x170006B6 RID: 1718
		// (get) Token: 0x06001219 RID: 4633 RVA: 0x00013E21 File Offset: 0x00012021
		// (set) Token: 0x0600121A RID: 4634 RVA: 0x000AA544 File Offset: 0x000A8744
		public LabelSectionType LabelSectionType
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (this.SetProperty<LabelSectionType>(ref this.#e, value, null))
				{
					bool flag = this.SelectedStationType == StationTypes.All;
					if (value == LabelSectionType.PierLabel)
					{
						this.StationTypesItems.Remove(this.#v);
					}
					else if (!this.StationTypesItems.Contains(this.#v))
					{
						this.StationTypesItems.Insert(1, this.#v);
					}
					if (flag)
					{
						this.SelectedStationType = StationTypes.OnlyTopAndBottom;
					}
				}
			}
		}

		// Token: 0x170006B7 RID: 1719
		// (get) Token: 0x0600121B RID: 4635 RVA: 0x00013E2D File Offset: 0x0001202D
		// (set) Token: 0x0600121C RID: 4636 RVA: 0x00013E39 File Offset: 0x00012039
		public StoryMode StoryMode
		{
			get
			{
				return this.#f;
			}
			set
			{
				this.SetProperty<StoryMode>(ref this.#f, value, null);
			}
		}

		// Token: 0x170006B8 RID: 1720
		// (get) Token: 0x0600121D RID: 4637 RVA: 0x00013E56 File Offset: 0x00012056
		// (set) Token: 0x0600121E RID: 4638 RVA: 0x00013E62 File Offset: 0x00012062
		public CombinationsMode CombinationsMode
		{
			get
			{
				return this.#g;
			}
			set
			{
				this.SetProperty<CombinationsMode>(ref this.#g, value, null);
			}
		}

		// Token: 0x170006B9 RID: 1721
		// (get) Token: 0x0600121F RID: 4639 RVA: 0x00013E7F File Offset: 0x0001207F
		// (set) Token: 0x06001220 RID: 4640 RVA: 0x00013E8B File Offset: 0x0001208B
		public MultistepCase MultistepCase
		{
			get
			{
				return this.#h;
			}
			set
			{
				this.SetProperty<MultistepCase>(ref this.#h, value, null);
			}
		}

		// Token: 0x170006BA RID: 1722
		// (get) Token: 0x06001221 RID: 4641 RVA: 0x00013EA8 File Offset: 0x000120A8
		// (set) Token: 0x06001222 RID: 4642 RVA: 0x00013EB4 File Offset: 0x000120B4
		public string SelectedColumnLabel
		{
			get
			{
				return this.#i;
			}
			set
			{
				this.SetProperty<string>(ref this.#i, value, null);
			}
		}

		// Token: 0x170006BB RID: 1723
		// (get) Token: 0x06001223 RID: 4643 RVA: 0x00013ED1 File Offset: 0x000120D1
		// (set) Token: 0x06001224 RID: 4644 RVA: 0x00013EDD File Offset: 0x000120DD
		public string SelectedColumnSection
		{
			get
			{
				return this.#j;
			}
			set
			{
				this.SetProperty<string>(ref this.#j, value, null);
			}
		}

		// Token: 0x170006BC RID: 1724
		// (get) Token: 0x06001225 RID: 4645 RVA: 0x00013EFA File Offset: 0x000120FA
		// (set) Token: 0x06001226 RID: 4646 RVA: 0x00013F06 File Offset: 0x00012106
		public string SelectedPierLabel
		{
			get
			{
				return this.#k;
			}
			set
			{
				this.SetProperty<string>(ref this.#k, value, null);
			}
		}

		// Token: 0x170006BD RID: 1725
		// (get) Token: 0x06001227 RID: 4647 RVA: 0x00013F23 File Offset: 0x00012123
		// (set) Token: 0x06001228 RID: 4648 RVA: 0x00013F2F File Offset: 0x0001212F
		public string SelectedSingleStory
		{
			get
			{
				return this.#l;
			}
			set
			{
				this.SetProperty<string>(ref this.#l, value, null);
			}
		}

		// Token: 0x170006BE RID: 1726
		// (get) Token: 0x06001229 RID: 4649 RVA: 0x00013F4C File Offset: 0x0001214C
		// (set) Token: 0x0600122A RID: 4650 RVA: 0x00013F58 File Offset: 0x00012158
		public bool EnableStoryRange
		{
			get
			{
				return this.#t;
			}
			set
			{
				this.SetProperty<bool>(ref this.#t, value, null);
			}
		}

		// Token: 0x170006BF RID: 1727
		// (get) Token: 0x0600122B RID: 4651 RVA: 0x00013F75 File Offset: 0x00012175
		// (set) Token: 0x0600122C RID: 4652 RVA: 0x00013F81 File Offset: 0x00012181
		public bool EliminateDuplicateLoads
		{
			get
			{
				return this.#u;
			}
			set
			{
				this.SetProperty<bool>(ref this.#u, value, null);
			}
		}

		// Token: 0x170006C0 RID: 1728
		// (get) Token: 0x0600122D RID: 4653 RVA: 0x00013F9E File Offset: 0x0001219E
		// (set) Token: 0x0600122E RID: 4654 RVA: 0x000AA5C0 File Offset: 0x000A87C0
		public string SelectedFromStory
		{
			get
			{
				return this.#m;
			}
			set
			{
				EtabsImportWindowViewModel.#RVd #RVd = new EtabsImportWindowViewModel.#RVd();
				#RVd.#a = this;
				#RVd.#b = value;
				if (this.#m != #RVd.#b)
				{
					this.#m = #RVd.#b;
					int num = this.ToStoryComboItems.#B7c(new Func<ComboItem<string>, bool>(#RVd.#6Xb));
					int num2 = this.FromStoryComboItems.#B7c(new Func<ComboItem<string>, bool>(#RVd.#7Xb));
					if (num >= 0 && num2 >= 0 && num2 > num)
					{
						this.SelectedToStory = this.ToStoryComboItems[Math.Min(num2, this.ToStoryComboItems.Count - 1)].Value;
					}
					base.RaisePropertyChanged(#Phc.#3hc(107408574));
				}
			}
		}

		// Token: 0x170006C1 RID: 1729
		// (get) Token: 0x0600122F RID: 4655 RVA: 0x00013FAA File Offset: 0x000121AA
		// (set) Token: 0x06001230 RID: 4656 RVA: 0x000AA698 File Offset: 0x000A8898
		public string SelectedToStory
		{
			get
			{
				return this.#n;
			}
			set
			{
				EtabsImportWindowViewModel.#5Dg #5Dg = new EtabsImportWindowViewModel.#5Dg();
				#5Dg.#a = value;
				#5Dg.#b = this;
				if (this.#n != #5Dg.#a)
				{
					this.#n = #5Dg.#a;
					int num = this.ToStoryComboItems.#B7c(new Func<ComboItem<string>, bool>(#5Dg.#9Xb));
					int num2 = this.FromStoryComboItems.#B7c(new Func<ComboItem<string>, bool>(#5Dg.#aYb));
					if (num >= 0 && num2 >= 0 && num2 > num)
					{
						this.SelectedFromStory = this.FromStoryComboItems[Math.Max(num, 0)].Value;
					}
					base.RaisePropertyChanged(#Phc.#3hc(107408517));
				}
			}
		}

		// Token: 0x170006C2 RID: 1730
		// (get) Token: 0x06001231 RID: 4657 RVA: 0x00013FB6 File Offset: 0x000121B6
		// (set) Token: 0x06001232 RID: 4658 RVA: 0x00013FC2 File Offset: 0x000121C2
		public StationTypes SelectedStationType
		{
			get
			{
				return this.#q;
			}
			set
			{
				this.SetProperty<StationTypes>(ref this.#q, value, null);
			}
		}

		// Token: 0x170006C3 RID: 1731
		// (get) Token: 0x06001233 RID: 4659 RVA: 0x00013FDF File Offset: 0x000121DF
		// (set) Token: 0x06001234 RID: 4660 RVA: 0x00013FEB File Offset: 0x000121EB
		public bool SupportsEnvelopes
		{
			get
			{
				return this.#r;
			}
			set
			{
				this.SetProperty<bool>(ref this.#r, value, null);
			}
		}

		// Token: 0x170006C4 RID: 1732
		// (get) Token: 0x06001235 RID: 4661 RVA: 0x00014008 File Offset: 0x00012208
		// (set) Token: 0x06001236 RID: 4662 RVA: 0x00014014 File Offset: 0x00012214
		public string IsWorkingMessage
		{
			get
			{
				return this.#s;
			}
			set
			{
				this.SetProperty<string>(ref this.#s, value, null);
			}
		}

		// Token: 0x170006C5 RID: 1733
		// (get) Token: 0x06001237 RID: 4663 RVA: 0x00014031 File Offset: 0x00012231
		public List<FactoredLoad> ImportedFactoryLoads { get; }

		// Token: 0x170006C6 RID: 1734
		// (get) Token: 0x06001238 RID: 4664 RVA: 0x0001403D File Offset: 0x0001223D
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x170006C7 RID: 1735
		// (get) Token: 0x06001239 RID: 4665 RVA: 0x0001404D File Offset: 0x0001224D
		// (set) Token: 0x0600123A RID: 4666 RVA: 0x00014059 File Offset: 0x00012259
		public bool AreColumnsAvailable
		{
			get
			{
				return this.#w;
			}
			set
			{
				this.SetProperty<bool>(ref this.#w, value, null);
			}
		}

		// Token: 0x170006C8 RID: 1736
		// (get) Token: 0x0600123B RID: 4667 RVA: 0x00014076 File Offset: 0x00012276
		// (set) Token: 0x0600123C RID: 4668 RVA: 0x00014082 File Offset: 0x00012282
		public bool AreStoriesAvailable
		{
			get
			{
				return this.#x;
			}
			set
			{
				this.SetProperty<bool>(ref this.#x, value, null);
			}
		}

		// Token: 0x170006C9 RID: 1737
		// (get) Token: 0x0600123D RID: 4669 RVA: 0x0001409F File Offset: 0x0001229F
		// (set) Token: 0x0600123E RID: 4670 RVA: 0x000140AB File Offset: 0x000122AB
		public bool ArePiersAvailable
		{
			get
			{
				return this.#z;
			}
			set
			{
				this.SetProperty<bool>(ref this.#z, value, null);
			}
		}

		// Token: 0x170006CA RID: 1738
		// (get) Token: 0x0600123F RID: 4671 RVA: 0x000140C8 File Offset: 0x000122C8
		public string StationUnit
		{
			get
			{
				return UnitSymbolProvider.#29d((this.CurrentUnit == UnitSystem.USCustomary) ? LengthUnit.Foot : LengthUnit.Meter).Symbol;
			}
		}

		// Token: 0x06001240 RID: 4672 RVA: 0x000AA760 File Offset: 0x000A8960
		protected override bool SetProperty<T>(ref T field, T value, string propertyName = null)
		{
			bool result = base.SetProperty<T>(ref field, value, propertyName);
			this.#vh();
			return result;
		}

		// Token: 0x06001241 RID: 4673 RVA: 0x000AA78C File Offset: 0x000A898C
		protected override void #vh()
		{
			base.#vh();
			this.ImportCommand.InvalidateCanExecute();
			this.BrowseCommand.InvalidateCanExecute();
			this.LoadModelCommand.InvalidateCanExecute();
			this.CloseCommand.InvalidateCanExecute();
			this.SaveAsXmlCommand.InvalidateCanExecute();
			this.ButtonAddCommand.InvalidateCanExecute();
			this.ButtonRemoveCommand.InvalidateCanExecute();
			this.ExportToCsvCommand.InvalidateCanExecute();
		}

		// Token: 0x06001242 RID: 4674 RVA: 0x000AA804 File Offset: 0x000A8A04
		public bool #od()
		{
			this.#p = false;
			base.View.ElementsTab.IsSelected = true;
			if (this.CurrentUnit != base.Services.Project.Model.Options.Unit)
			{
				this.CurrentUnit = base.Services.Project.Model.Options.Unit;
				if (!string.IsNullOrWhiteSpace(this.ProjectPath) && this.IsModelLoaded)
				{
					this.#QE(null);
				}
			}
			base.View.SetOwner(base.MainWindow);
			base.View.ShowDialog();
			return this.#p;
		}

		// Token: 0x06001243 RID: 4675 RVA: 0x000AA8C8 File Offset: 0x000A8AC8
		protected override void #uh(#Db #Ee)
		{
			base.#uh(#Ee);
			this.CurrentUnit = base.Services.Project.Model.Options.Unit;
			base.View.TabControl.SelectionChanged += this.#CE;
		}

		// Token: 0x06001244 RID: 4676 RVA: 0x000AA924 File Offset: 0x000A8B24
		private void #Gh(object #Ge, #cW #He)
		{
			if ((#He.IsNewProject || !#He.IsInternalChange) && this.IsModelLoaded)
			{
				base.Logger.Log(LoggingLevel.Debug, new Func<string>(EtabsImportWindowViewModel.<>c.<>9.#n0i));
				this.#mUh();
				this.IsModelLoaded = false;
				this.ProjectPath = null;
			}
		}

		// Token: 0x06001245 RID: 4677 RVA: 0x000140F1 File Offset: 0x000122F1
		private void #CE(object #Ge, RadSelectionChangedEventArgs #He)
		{
			this.#vh();
		}

		// Token: 0x06001246 RID: 4678 RVA: 0x000AA994 File Offset: 0x000A8B94
		private static IEnumerable<PreviewItem> #DE(IEnumerable<PreviewItem> #tk)
		{
			return #tk.OrderBy(new Func<PreviewItem, string>(EtabsImportWindowViewModel.<>c.<>9.#o0i)).ThenBy(new Func<PreviewItem, string>(EtabsImportWindowViewModel.<>c.<>9.#p0i)).ThenBy(new Func<PreviewItem, string>(EtabsImportWindowViewModel.<>c.<>9.#q0i)).ThenBy(new Func<PreviewItem, double>(EtabsImportWindowViewModel.<>c.<>9.#r0i)).ThenBy(new Func<PreviewItem, string>(EtabsImportWindowViewModel.<>c.<>9.#s0i)).ThenBy(new Func<PreviewItem, double>(EtabsImportWindowViewModel.<>c.<>9.#t0i)).ThenBy(new Func<PreviewItem, string>(EtabsImportWindowViewModel.<>c.<>9.#u0i)).ToList<PreviewItem>();
		}

		// Token: 0x06001247 RID: 4679 RVA: 0x00014101 File Offset: 0x00012301
		private void #mUh()
		{
			#iF #iF = this.#o;
			if (((#iF != null) ? #iF.Project : null) != null)
			{
				this.#o.Project.#DXd();
				this.#o = null;
			}
		}

		// Token: 0x06001248 RID: 4680 RVA: 0x000AAAC4 File Offset: 0x000A8CC4
		private void #EE(object #Sb)
		{
			try
			{
				string directoryName = Alphaleonis.Win32.Filesystem.Path.GetDirectoryName(this.ProjectPath);
				string text = base.FileSystem.#11c(new #62c(new #L1c[]
				{
					new #L1c(#Phc.#3hc(107408528), #Phc.#3hc(107408483))
				}, #Phc.#3hc(107408483), directoryName)
				{
					InitialFileName = Alphaleonis.Win32.Filesystem.Path.GetFileNameWithoutExtension(this.ProjectPath)
				});
				if (!string.IsNullOrWhiteSpace(text))
				{
					#eF #eF = new #eF();
					using (Stream stream = base.FileSystem.#T1c(text))
					{
						#eF.#zl(stream, base.Project, this.PreviewItems);
					}
				}
			}
			catch (Exception #ob)
			{
				base.Services.ErrorsHandler.#1Pb(#Phc.#3hc(107408510).#z2d(), #ob);
			}
		}

		// Token: 0x06001249 RID: 4681 RVA: 0x0001413A File Offset: 0x0001233A
		private bool #FE(object #Sb)
		{
			return this.#o != null && base.View.PreviewTab.IsSelected && this.PreviewItems.Any<PreviewItem>() && this.IsModelLoaded;
		}

		// Token: 0x0600124A RID: 4682 RVA: 0x000AABC8 File Offset: 0x000A8DC8
		private void #GE(object #Sb)
		{
			EtabsImportWindowViewModel.#d1i #d1i;
			#d1i.#b = AsyncVoidMethodBuilder.Create();
			#d1i.#d = this;
			#d1i.#c = #Sb;
			#d1i.#a = -1;
			#d1i.#b.Start<EtabsImportWindowViewModel.#d1i>(ref #d1i);
		}

		// Token: 0x0600124B RID: 4683 RVA: 0x000140F1 File Offset: 0x000122F1
		private void #HE(object #Sb)
		{
			this.#vh();
		}

		// Token: 0x0600124C RID: 4684 RVA: 0x000AAC14 File Offset: 0x000A8E14
		private bool #IE(object #Vg)
		{
			IEnumerable enumerable = #Vg as IEnumerable;
			return enumerable != null && enumerable.OfType<LoadCombinationItem>().Any<LoadCombinationItem>();
		}

		// Token: 0x0600124D RID: 4685 RVA: 0x000AAC44 File Offset: 0x000A8E44
		private void #JE(object #Vg)
		{
			IEnumerable enumerable = #Vg as IEnumerable;
			IEnumerable enumerable2;
			if (2 != 0)
			{
				enumerable2 = enumerable;
			}
			if (enumerable2 == null)
			{
				return;
			}
			List<LoadCombinationItem> list = enumerable2.OfType<LoadCombinationItem>().ToList<LoadCombinationItem>();
			foreach (LoadCombinationItem item in list)
			{
				this.CombinationsItems.Remove(item);
				this.CombinationsItemsChosen.Add(item);
			}
		}

		// Token: 0x0600124E RID: 4686 RVA: 0x000AACCC File Offset: 0x000A8ECC
		private void #KE(object #Vg)
		{
			IEnumerable enumerable = #Vg as IEnumerable;
			IEnumerable enumerable2;
			if (2 != 0)
			{
				enumerable2 = enumerable;
			}
			if (enumerable2 == null)
			{
				return;
			}
			List<LoadCombinationItem> list = enumerable2.OfType<LoadCombinationItem>().ToList<LoadCombinationItem>();
			foreach (LoadCombinationItem item in list)
			{
				this.CombinationsItemsChosen.Remove(item);
				this.CombinationsItems.Add(item);
			}
		}

		// Token: 0x0600124F RID: 4687 RVA: 0x00014177 File Offset: 0x00012377
		private void #Ug(object #Sb)
		{
			base.View.Close();
		}

		// Token: 0x06001250 RID: 4688 RVA: 0x00014190 File Offset: 0x00012390
		private bool #Zo(object #Sb)
		{
			return !this.IsWorking;
		}

		// Token: 0x06001251 RID: 4689 RVA: 0x000AAD54 File Offset: 0x000A8F54
		private void #nUh(List<string> #oUh)
		{
			int count = #oUh.Count;
			string str = (count > 10) ? (Environment.NewLine + #Phc.#3hc(107408449) + Environment.NewLine + string.Format(#Phc.#3hc(107408476), count - 10)) : string.Empty;
			base.DialogService.#pn(base.DialogService.ActiveWindow, Strings.StringThereAreNoResultsForTheFollowingLoadCombinations.#u2d().#Tm() + string.Join(Environment.NewLine, #oUh.Take(10)) + str);
		}

		// Token: 0x06001252 RID: 4690 RVA: 0x000AAE04 File Offset: 0x000A9004
		private void #Wg(object #Sb)
		{
			EtabsImportWindowViewModel.#e1i #e1i;
			#e1i.#b = AsyncVoidMethodBuilder.Create();
			#e1i.#c = this;
			#e1i.#a = -1;
			if (!false)
			{
				#e1i.#b.Start<EtabsImportWindowViewModel.#e1i>(ref #e1i);
			}
		}

		// Token: 0x06001253 RID: 4691 RVA: 0x000AAE4C File Offset: 0x000A904C
		private ValueTuple<List<PreviewItem>, List<string>, List<ETABSFactoredLoad>> #LE()
		{
			string[] #1E = this.#NE();
			string[] #0E = this.#VE();
			List<PreviewItem> list = new List<PreviewItem>();
			ValueTuple<List<ETABSFactoredLoad>, List<string>> valueTuple = this.#ZE(#0E, #1E);
			List<ETABSFactoredLoad> list2 = valueTuple.Item1;
			List<string> item = valueTuple.Item2;
			List<ETABSFrame> inner = this.#o.Project.Columns;
			if (this.LabelSectionType != LabelSectionType.PierLabel)
			{
				list2 = list2.Join(inner, new Func<ETABSFactoredLoad, string>(EtabsImportWindowViewModel.<>c.<>9.#D0i), new Func<ETABSFrame, string>(EtabsImportWindowViewModel.<>c.<>9.#E0i), new Func<ETABSFactoredLoad, ETABSFrame, ETABSFactoredLoad>(EtabsImportWindowViewModel.<>c.<>9.#F0i)).ToList<ETABSFactoredLoad>();
			}
			if (this.EliminateDuplicateLoads)
			{
				IList<ETABSFactoredLoad> #Ic = list2;
				Func<ETABSFactoredLoad, bool> #9B;
				if ((#9B = EtabsImportWindowViewModel.#2Ui.#c) == null)
				{
					#9B = (EtabsImportWindowViewModel.#2Ui.#c = new Func<ETABSFactoredLoad, bool>(#DC.#eC));
				}
				Func<ETABSFactoredLoad, ETABSFactoredLoad, bool> #aC;
				if ((#aC = EtabsImportWindowViewModel.#2Ui.#d) == null)
				{
					#aC = (EtabsImportWindowViewModel.#2Ui.#d = new Func<ETABSFactoredLoad, ETABSFactoredLoad, bool>(#DC.#jC));
				}
				HashSet<ETABSFactoredLoad> #8f = #DC.#bC<ETABSFactoredLoad>(#Ic, #9B, #aC);
				list2.#71d(#8f);
			}
			if (list2.Count > #dde.Instance.MaxNoOfFactoredLoads)
			{
				return new ValueTuple<List<PreviewItem>, List<string>, List<ETABSFactoredLoad>>(list, item, list2);
			}
			list = new List<PreviewItem>(list2.Count);
			if (this.LabelSectionType == LabelSectionType.PierLabel)
			{
				list.AddRange(EtabsImportWindowViewModel.#DE(list2.Select(new Func<ETABSFactoredLoad, PreviewItem>(this.#d0i))));
			}
			else
			{
				IEnumerable<PreviewItem> #tk = list2.Join(inner, new Func<ETABSFactoredLoad, string>(EtabsImportWindowViewModel.<>c.<>9.#G0i), new Func<ETABSFrame, string>(EtabsImportWindowViewModel.<>c.<>9.#H0i), new Func<ETABSFactoredLoad, ETABSFrame, <>f__AnonymousType8<ETABSFactoredLoad, string>>(EtabsImportWindowViewModel.<>c.<>9.#I0i)).Select(new Func<<>f__AnonymousType8<ETABSFactoredLoad, string>, PreviewItem>(this.#e0i));
				list.AddRange(EtabsImportWindowViewModel.#DE(#tk));
			}
			return new ValueTuple<List<PreviewItem>, List<string>, List<ETABSFactoredLoad>>(list, item, list2);
		}

		// Token: 0x06001254 RID: 4692 RVA: 0x000AB058 File Offset: 0x000A9258
		private Task<bool> #ME()
		{
			EtabsImportWindowViewModel.#g1i #g1i;
			#g1i.#b = AsyncTaskMethodBuilder<bool>.Create();
			#g1i.#c = this;
			#g1i.#a = -1;
			#g1i.#b.Start<EtabsImportWindowViewModel.#g1i>(ref #g1i);
			return #g1i.#b.Task;
		}

		// Token: 0x06001255 RID: 4693 RVA: 0x000AB0A8 File Offset: 0x000A92A8
		private string[] #NE()
		{
			CombinationsMode combinationsMode = this.CombinationsMode;
			if (combinationsMode == CombinationsMode.AllCombinations)
			{
				return this.#o.Project.LoadCombinations.Values.Select(new Func<ETABSLoadCombination, string>(EtabsImportWindowViewModel.<>c.<>9.#J0i)).ToArray<string>();
			}
			if (combinationsMode != CombinationsMode.SelectedCombinations)
			{
				return new string[0];
			}
			return this.CombinationsItemsChosen.Select(new Func<LoadCombinationItem, string>(EtabsImportWindowViewModel.<>c.<>9.#K0i)).ToArray<string>();
		}

		// Token: 0x06001256 RID: 4694 RVA: 0x000AB158 File Offset: 0x000A9358
		private void #OE(#iF #PE)
		{
			if (((#PE != null) ? #PE.Project : null) == null)
			{
				this.SelectedColumnLabel = null;
				this.ColumnLabelComboItems.Clear();
				this.ColumnSectionComboItems.Clear();
				return;
			}
			this.SupportsEnvelopes = #PE.Project.SupportsEnvelopes;
			if (!this.SupportsEnvelopes)
			{
				this.MultistepCase = MultistepCase.ConsiderAllSteps;
			}
			List<ETABSFrame> source = #PE.Project.Columns;
			List<string> source2 = source.Select(new Func<ETABSFrame, string>(EtabsImportWindowViewModel.<>c.<>9.#L0i)).Where(new Func<string, bool>(EtabsImportWindowViewModel.<>c.<>9.#M0i)).Distinct<string>().ToList<string>();
			if (source2.All(new Func<string, bool>(EtabsImportWindowViewModel.<>c.<>9.#N0i)))
			{
				source2 = source2.OrderBy(new Func<string, int>(EtabsImportWindowViewModel.<>c.<>9.#O0i)).ToList<string>();
			}
			else
			{
				source2 = source.Select(new Func<ETABSFrame, string>(EtabsImportWindowViewModel.<>c.<>9.#P0i)).Distinct<string>().OrderBy(new Func<string, string>(EtabsImportWindowViewModel.<>c.<>9.#Q0i)).ToList<string>();
			}
			this.AreColumnsAvailable = source2.Any<string>();
			if (!source2.Any<string>())
			{
				this.ColumnLabelComboItems.Clear();
				this.SelectedColumnLabel = null;
				this.ColumnSectionComboItems.Clear();
				this.SelectedColumnSection = null;
				this.LabelSectionType = LabelSectionType.PierLabel;
			}
			else
			{
				this.ColumnLabelComboItems.#pR(source2.Select(new Func<string, ComboItem<string>>(EtabsImportWindowViewModel.<>c.<>9.#R0i)));
				ComboItem<string> comboItem = this.ColumnLabelComboItems.FirstOrDefault<ComboItem<string>>();
				this.SelectedColumnLabel = ((comboItem != null) ? comboItem.Value : null);
				IOrderedEnumerable<string> source3 = source.Select(new Func<ETABSFrame, string>(EtabsImportWindowViewModel.<>c.<>9.#S0i)).Distinct<string>().OrderBy(new Func<string, string>(EtabsImportWindowViewModel.<>c.<>9.#T0i));
				this.ColumnSectionComboItems.#pR(source3.Select(new Func<string, ComboItem<string>>(EtabsImportWindowViewModel.<>c.<>9.#U0i)));
				ComboItem<string> comboItem2 = this.ColumnSectionComboItems.FirstOrDefault<ComboItem<string>>();
				this.SelectedColumnSection = ((comboItem2 != null) ? comboItem2.Value : null);
			}
			List<ETABSPier> source4 = #PE.Project.Piers;
			List<string> source5 = source4.Select(new Func<ETABSPier, string>(EtabsImportWindowViewModel.<>c.<>9.#V0i)).Distinct<string>().ToList<string>();
			if (!source5.Any<string>())
			{
				this.LabelSectionType = LabelSectionType.ColumnLabel;
				this.PierLabelComboItems.Clear();
			}
			else
			{
				this.PierLabelComboItems.#pR(source5.Select(new Func<string, ComboItem<string>>(EtabsImportWindowViewModel.<>c.<>9.#W0i)));
				ComboItem<string> comboItem3 = this.PierLabelComboItems.FirstOrDefault<ComboItem<string>>();
				this.SelectedPierLabel = ((comboItem3 != null) ? comboItem3.Value : null);
			}
			this.ArePiersAvailable = this.PierLabelComboItems.Any<ComboItem<string>>();
			List<ETABSStory> list = source4.Select(new Func<ETABSPier, string>(EtabsImportWindowViewModel.<>c.<>9.#X0i)).Distinct<string>().Union(source.Select(new Func<ETABSFrame, string>(EtabsImportWindowViewModel.<>c.<>9.#Y0i)).Distinct<string>()).Distinct<string>().Join(#PE.Project.Stories, new Func<string, string>(EtabsImportWindowViewModel.<>c.<>9.#Z0i), new Func<ETABSStory, string>(EtabsImportWindowViewModel.<>c.<>9.#00i), new Func<string, ETABSStory, ETABSStory>(EtabsImportWindowViewModel.<>c.<>9.#10i)).OrderBy(new Func<ETABSStory, string>(EtabsImportWindowViewModel.<>c.<>9.#20i)).ThenBy(new Func<ETABSStory, double>(EtabsImportWindowViewModel.<>c.<>9.#30i)).ToList<ETABSStory>();
			this.EnableStoryRange = (list.Count > 1);
			this.AreStoriesAvailable = list.Any<ETABSStory>();
			if (!list.Any<ETABSStory>())
			{
				this.SingleStoryComboItems.Clear();
				this.SelectedSingleStory = null;
				this.FromStoryComboItems.Clear();
				this.SelectedFromStory = null;
				this.ToStoryComboItems.Clear();
				this.SelectedToStory = null;
			}
			else
			{
				List<ComboItem<string>> #8f = list.Select(new Func<ETABSStory, string>(EtabsImportWindowViewModel.<>c.<>9.#40i)).Select(new Func<string, ComboItem<string>>(EtabsImportWindowViewModel.<>c.<>9.#50i)).ToList<ComboItem<string>>();
				this.SingleStoryComboItems.#pR(#8f);
				ComboItem<string> comboItem4 = this.SingleStoryComboItems.FirstOrDefault<ComboItem<string>>();
				this.SelectedSingleStory = ((comboItem4 != null) ? comboItem4.Value : null);
				this.FromStoryComboItems.#pR(#8f);
				ComboItem<string> comboItem5 = this.FromStoryComboItems.FirstOrDefault<ComboItem<string>>();
				this.SelectedFromStory = ((comboItem5 != null) ? comboItem5.Value : null);
				this.ToStoryComboItems.#pR(#8f);
				ComboItem<string> comboItem6 = this.ToStoryComboItems.FirstOrDefault<ComboItem<string>>();
				this.SelectedToStory = ((comboItem6 != null) ? comboItem6.Value : null);
			}
			IEnumerable<LoadCombinationItem> #8f2 = #PE.Project.LoadCombinations.Values.OrderBy(new Func<ETABSLoadCombination, string>(EtabsImportWindowViewModel.<>c.<>9.#60i)).Select(new Func<ETABSLoadCombination, LoadCombinationItem>(EtabsImportWindowViewModel.<>c.<>9.#70i));
			this.CombinationsItems.#pR(#8f2);
		}

		// Token: 0x06001257 RID: 4695 RVA: 0x000AB770 File Offset: 0x000A9970
		private void #QE(object #Sb)
		{
			EtabsImportWindowViewModel.#f1i #f1i;
			#f1i.#b = AsyncVoidMethodBuilder.Create();
			#f1i.#c = this;
			#f1i.#a = -1;
			if (!false)
			{
				#f1i.#b.Start<EtabsImportWindowViewModel.#f1i>(ref #f1i);
			}
		}

		// Token: 0x06001258 RID: 4696 RVA: 0x000AB7B8 File Offset: 0x000A99B8
		private bool #RE(object #Sb)
		{
			bool flag;
			return !this.IsWorking && Ignore.#14d<Exception, bool>(new Func<bool>(this.#h0i), out flag, null) && flag;
		}

		// Token: 0x06001259 RID: 4697 RVA: 0x000AB7F4 File Offset: 0x000A99F4
		private void #SE(object #Sb)
		{
			string #Ao = base.FileSystem.#O1c(base.Services.Settings.LastEtabsImportPath, Environment.GetFolderPath(Environment.SpecialFolder.Personal));
			#12c #R1c = new #12c(new #L1c[]
			{
				new #L1c(Strings.StringAllEtabsFiles, #b1d.EdbExtension + #Phc.#3hc(107408443) + #b1d.XmlExtension),
				new #L1c(Strings.StringETABSProjectFile, #b1d.EdbExtension),
				new #L1c(Strings.StringXmlFile, #b1d.XmlExtension)
			}, #b1d.EdbExtension, #Ao);
			string text = base.FileSystem.#S1c(#R1c);
			if (!string.IsNullOrWhiteSpace(text))
			{
				base.Services.Settings.LastEtabsImportPath = Alphaleonis.Win32.Filesystem.Path.GetDirectoryName(text);
				this.ProjectPath = text;
				this.IsModelLoaded = false;
				this.#p = false;
				this.#TE();
			}
		}

		// Token: 0x0600125A RID: 4698 RVA: 0x000AB8E4 File Offset: 0x000A9AE4
		private void #TE()
		{
			base.View.ElementsTab.IsSelected = true;
			this.EnableStoryRange = false;
			this.ColumnLabelComboItems.Clear();
			this.ColumnSectionComboItems.Clear();
			this.PierLabelComboItems.Clear();
			this.SingleStoryComboItems.Clear();
			this.FromStoryComboItems.Clear();
			this.ToStoryComboItems.Clear();
			this.LabelSectionType = LabelSectionType.ColumnLabel;
			this.StoryMode = StoryMode.SingleStory;
			this.CombinationsMode = CombinationsMode.AllCombinations;
			this.MultistepCase = MultistepCase.ConsiderAllSteps;
			this.SelectedColumnLabel = null;
			this.SelectedColumnSection = null;
			this.SelectedPierLabel = null;
			this.SelectedSingleStory = null;
			this.SelectedFromStory = null;
			this.SelectedToStory = null;
			this.LabelSectionType = LabelSectionType.ColumnLabel;
			this.StoryMode = StoryMode.SingleStory;
			this.CombinationsMode = CombinationsMode.AllCombinations;
			this.MultistepCase = MultistepCase.ConsiderAllSteps;
			this.CombinationsItems.Clear();
			this.CombinationsItemsChosen.Clear();
			this.SelectedStationType = StationTypes.All;
			this.SupportsEnvelopes = false;
			this.#vh();
		}

		// Token: 0x0600125B RID: 4699 RVA: 0x00014190 File Offset: 0x00012390
		private bool #UE(object #Sb)
		{
			return !this.IsWorking;
		}

		// Token: 0x0600125C RID: 4700 RVA: 0x000AB9F8 File Offset: 0x000A9BF8
		private string[] #VE()
		{
			EtabsImportWindowViewModel.#c1i #c1i = new EtabsImportWindowViewModel.#c1i();
			StoryMode storyMode = this.StoryMode;
			if (storyMode == StoryMode.SingleStory)
			{
				return new string[]
				{
					this.SelectedSingleStory
				};
			}
			if (storyMode != StoryMode.StoryRange)
			{
				return new string[0];
			}
			List<string> list = new List<string>();
			var source = this.#o.Project.Stories.Select(new Func<ETABSStory, int, <>f__AnonymousType9<string, int>>(EtabsImportWindowViewModel.<>c.<>9.#80i)).ToList();
			#c1i.#a = source.Single(new Func<<>f__AnonymousType9<string, int>, bool>(this.#i0i)).Index;
			#c1i.#b = source.Single(new Func<<>f__AnonymousType9<string, int>, bool>(this.#j0i)).Index;
			IEnumerable<string> collection = source.Where(new Func<<>f__AnonymousType9<string, int>, bool>(#c1i.#8Yb)).Select(new Func<<>f__AnonymousType9<string, int>, string>(EtabsImportWindowViewModel.<>c.<>9.#90i));
			list.AddRange(collection);
			return list.ToArray();
		}

		// Token: 0x0600125D RID: 4701 RVA: 0x000ABB14 File Offset: 0x000A9D14
		private string #WE()
		{
			#iF #iF = this.#o;
			if (((#iF != null) ? #iF.Project : null) == null)
			{
				return Strings.StringProjectIsNotImported.#z2d();
			}
			if (((this.LabelSectionType == LabelSectionType.ColumnLabel || this.LabelSectionType == LabelSectionType.ColumnSection) && !this.AreColumnsAvailable) || (this.LabelSectionType == LabelSectionType.PierLabel && !this.ArePiersAvailable))
			{
				return Strings.StringThereAreNoColumnsOrPiersInTheModel.#z2d();
			}
			if (((this.CombinationsMode == CombinationsMode.AllCombinations) ? this.CombinationsItems.Count : this.CombinationsItemsChosen.Count) == 0)
			{
				return Strings.StringAtLeastOneCombinationMustBeSelected.#z2d();
			}
			if (this.SingleStoryComboItems.Count == 0)
			{
				return Strings.StringThereAreNoStoriesInTheModel.#z2d();
			}
			LabelSectionType labelSectionType = this.LabelSectionType;
			if (labelSectionType != LabelSectionType.ColumnLabel)
			{
				if (labelSectionType == LabelSectionType.ColumnSection)
				{
					if (string.IsNullOrEmpty(this.SelectedColumnSection))
					{
						return Strings.StringThereAreNoColumnsInTheModel.#z2d();
					}
				}
			}
			else if (string.IsNullOrEmpty(this.SelectedColumnLabel))
			{
				return Strings.StringThereAreNoColumnsInTheModel.#z2d();
			}
			return string.Empty;
		}

		// Token: 0x0600125E RID: 4702 RVA: 0x000ABC20 File Offset: 0x000A9E20
		private bool #XE(string #YE)
		{
			string text = this.#WE();
			if (!string.IsNullOrEmpty(text))
			{
				string #SSc = base.DialogService.#5Sc(#YE, text);
				base.DialogService.#qn(base.DialogService.ActiveWindow, #SSc);
				return false;
			}
			return true;
		}

		// Token: 0x0600125F RID: 4703 RVA: 0x000ABC70 File Offset: 0x000A9E70
		private ValueTuple<List<ETABSFactoredLoad>, List<string>> #ZE(string[] #0E, string[] #1E)
		{
			List<ETABSFactoredLoad> item = new List<ETABSFactoredLoad>();
			List<string> item2 = new List<string>();
			bool #h6h = this.MultistepCase == MultistepCase.ConsiderEnveloped;
			switch (this.LabelSectionType)
			{
			case LabelSectionType.ColumnLabel:
			{
				string[] #p6h = new string[]
				{
					this.SelectedColumnLabel
				};
				item = this.#o.Project.#l6h(#p6h, #0E, #1E, this.SelectedStationType, #h6h, out item2);
				break;
			}
			case LabelSectionType.ColumnSection:
				item = this.#o.Project.#r6h(this.SelectedColumnSection, #0E, #1E, this.SelectedStationType, #h6h, out item2);
				break;
			case LabelSectionType.PierLabel:
			{
				string[] #u6h = new string[]
				{
					this.SelectedPierLabel
				};
				item = this.#o.Project.#s6h(#u6h, #0E, #1E, this.SelectedStationType, #h6h, out item2);
				break;
			}
			}
			return new ValueTuple<List<ETABSFactoredLoad>, List<string>>(item, item2);
		}

		// Token: 0x06001260 RID: 4704 RVA: 0x000141A3 File Offset: 0x000123A3
		private bool #2E(object #Sb)
		{
			return !this.IsWorking && this.IsModelLoaded;
		}

		// Token: 0x06001261 RID: 4705 RVA: 0x000141C1 File Offset: 0x000123C1
		private bool #3E(object #Vg)
		{
			return this.IsModelLoaded && this.#o != null && this.#o.IsNativeProject;
		}

		// Token: 0x06001262 RID: 4706 RVA: 0x000ABD5C File Offset: 0x000A9F5C
		private void #4E(object #Vg)
		{
			if (this.#o.Project == null)
			{
				base.DialogService.#qn(base.DialogService.ActiveWindow, Strings.StringProjectIsNotImported.#z2d());
				return;
			}
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#k0i));
		}

		// Token: 0x06001263 RID: 4707 RVA: 0x000141EC File Offset: 0x000123EC
		[CompilerGenerated]
		private PreviewItem #d0i(ETABSFactoredLoad #9o)
		{
			return new PreviewItem(#9o, this.LabelSectionType, #Phc.#3hc(107408434));
		}

		// Token: 0x06001264 RID: 4708 RVA: 0x00014210 File Offset: 0x00012410
		[CompilerGenerated]
		private PreviewItem #e0i(<>f__AnonymousType8<ETABSFactoredLoad, string> #Rf)
		{
			return new PreviewItem(#Rf.Load, this.LabelSectionType, #Rf.Section);
		}

		// Token: 0x06001265 RID: 4709 RVA: 0x000ABDB8 File Offset: 0x000A9FB8
		[CompilerGenerated]
		private void #f0i()
		{
			this.#o = null;
			this.#o = this.#a.#kF(this.#b, this.CurrentUnit);
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(this.#g0i));
		}

		// Token: 0x06001266 RID: 4710 RVA: 0x000ABE08 File Offset: 0x000AA008
		[CompilerGenerated]
		private void #g0i()
		{
			try
			{
				#iF #iF = this.#o;
				if (((#iF != null) ? #iF.Project : null) != null)
				{
					this.IsModelLoaded = true;
				}
				this.#TE();
				this.#OE(this.#o);
			}
			catch (Exception #ob)
			{
				this.IsModelLoaded = false;
				base.Services.ExceptionHandler.#3Ab(#ob);
			}
			finally
			{
				this.IsWorking = false;
				this.#vh();
			}
		}

		// Token: 0x06001267 RID: 4711 RVA: 0x00014235 File Offset: 0x00012435
		[CompilerGenerated]
		private bool #h0i()
		{
			return base.FileSystem.#V1c(this.ProjectPath);
		}

		// Token: 0x06001268 RID: 4712 RVA: 0x00014254 File Offset: 0x00012454
		[CompilerGenerated]
		private bool #i0i(<>f__AnonymousType9<string, int> #bF)
		{
			return #bF.Name == this.SelectedFromStory;
		}

		// Token: 0x06001269 RID: 4713 RVA: 0x00014273 File Offset: 0x00012473
		[CompilerGenerated]
		private bool #j0i(<>f__AnonymousType9<string, int> #bF)
		{
			return #bF.Name == this.SelectedToStory;
		}

		// Token: 0x0600126A RID: 4714 RVA: 0x000ABE98 File Offset: 0x000AA098
		[CompilerGenerated]
		private void #k0i()
		{
			try
			{
				List<#L1c> list = new List<#L1c>();
				#L1c item = new #L1c(Strings.StringDataExchangeFormat, #b1d.XmlExtension);
				if (!false)
				{
					list.Add(item);
				}
				List<#L1c> #m2c = list;
				#62c #21c = new #62c(#m2c, #b1d.DxfExtension, null)
				{
					InitialFileName = #CSd.#dy(base.Project.LoadedFilePath)
				};
				string text = base.Services.FileSystem.#11c(#21c);
				if (!string.IsNullOrWhiteSpace(text))
				{
					this.#o.Project.#v6h(text, this.MultistepCase == MultistepCase.ConsiderEnveloped);
					base.DialogService.#pn(base.DialogService.ActiveWindow, Strings.StringExportOperationWasSuccessful.#z2d());
				}
				base.Services.GuiController.IsBackstageOpen = false;
			}
			catch (Exception #ob)
			{
				base.Services.ExceptionHandler.#3Ab(#ob);
			}
		}

		// Token: 0x04000726 RID: 1830
		private readonly #pF #a;

		// Token: 0x04000727 RID: 1831
		private string #b;

		// Token: 0x04000728 RID: 1832
		private bool #c;

		// Token: 0x04000729 RID: 1833
		private bool #d;

		// Token: 0x0400072A RID: 1834
		private LabelSectionType #e;

		// Token: 0x0400072B RID: 1835
		private StoryMode #f;

		// Token: 0x0400072C RID: 1836
		private CombinationsMode #g;

		// Token: 0x0400072D RID: 1837
		private MultistepCase #h;

		// Token: 0x0400072E RID: 1838
		private string #i;

		// Token: 0x0400072F RID: 1839
		private string #j;

		// Token: 0x04000730 RID: 1840
		private string #k;

		// Token: 0x04000731 RID: 1841
		private string #l;

		// Token: 0x04000732 RID: 1842
		private string #m;

		// Token: 0x04000733 RID: 1843
		private string #n;

		// Token: 0x04000734 RID: 1844
		private #iF #o;

		// Token: 0x04000735 RID: 1845
		private bool #p;

		// Token: 0x04000736 RID: 1846
		private StationTypes #q;

		// Token: 0x04000737 RID: 1847
		private bool #r;

		// Token: 0x04000738 RID: 1848
		private string #s;

		// Token: 0x04000739 RID: 1849
		private bool #t;

		// Token: 0x0400073A RID: 1850
		private bool #u;

		// Token: 0x0400073B RID: 1851
		private readonly ComboItem<StationTypes> #v;

		// Token: 0x0400073C RID: 1852
		private bool #w;

		// Token: 0x0400073D RID: 1853
		private bool #x;

		// Token: 0x0400073E RID: 1854
		private UnitSystem #y;

		// Token: 0x0400073F RID: 1855
		private bool #z;

		// Token: 0x04000740 RID: 1856
		[CompilerGenerated]
		private readonly DelegateCommand #A;

		// Token: 0x04000741 RID: 1857
		[CompilerGenerated]
		private readonly DelegateCommand #B;

		// Token: 0x04000742 RID: 1858
		[CompilerGenerated]
		private readonly DelegateCommand #C;

		// Token: 0x04000743 RID: 1859
		[CompilerGenerated]
		private readonly DelegateCommand #D;

		// Token: 0x04000744 RID: 1860
		[CompilerGenerated]
		private readonly DelegateCommand #E;

		// Token: 0x04000745 RID: 1861
		[CompilerGenerated]
		private readonly DelegateCommand #F;

		// Token: 0x04000746 RID: 1862
		[CompilerGenerated]
		private readonly DelegateCommand #G;

		// Token: 0x04000747 RID: 1863
		[CompilerGenerated]
		private readonly CustomObservableCollection<ComboItem<string>> #H = new CustomObservableCollection<ComboItem<string>>();

		// Token: 0x04000748 RID: 1864
		[CompilerGenerated]
		private readonly CustomObservableCollection<ComboItem<string>> #I = new CustomObservableCollection<ComboItem<string>>();

		// Token: 0x04000749 RID: 1865
		[CompilerGenerated]
		private readonly CustomObservableCollection<LoadCombinationItem> #J = new CustomObservableCollection<LoadCombinationItem>();

		// Token: 0x0400074A RID: 1866
		[CompilerGenerated]
		private readonly CustomObservableCollection<LoadCombinationItem> #K = new CustomObservableCollection<LoadCombinationItem>();

		// Token: 0x0400074B RID: 1867
		[CompilerGenerated]
		private readonly CustomObservableCollection<ComboItem<string>> #L = new CustomObservableCollection<ComboItem<string>>();

		// Token: 0x0400074C RID: 1868
		[CompilerGenerated]
		private readonly CustomObservableCollection<ComboItem<string>> #M = new CustomObservableCollection<ComboItem<string>>();

		// Token: 0x0400074D RID: 1869
		[CompilerGenerated]
		private readonly CustomObservableCollection<ComboItem<string>> #N = new CustomObservableCollection<ComboItem<string>>();

		// Token: 0x0400074E RID: 1870
		[CompilerGenerated]
		private readonly CustomObservableCollection<ComboItem<string>> #O = new CustomObservableCollection<ComboItem<string>>();

		// Token: 0x0400074F RID: 1871
		[CompilerGenerated]
		private readonly CustomObservableCollection<ComboItem<StationTypes>> #P = new CustomObservableCollection<ComboItem<StationTypes>>();

		// Token: 0x04000750 RID: 1872
		[CompilerGenerated]
		private readonly CustomObservableCollection<PreviewItem> #Q = new CustomObservableCollection<PreviewItem>();

		// Token: 0x04000751 RID: 1873
		[CompilerGenerated]
		private readonly DelegateCommand #R;

		// Token: 0x04000752 RID: 1874
		[CompilerGenerated]
		private readonly DelegateCommand #S;

		// Token: 0x04000753 RID: 1875
		[CompilerGenerated]
		private readonly DelegateCommand #T;

		// Token: 0x04000754 RID: 1876
		[CompilerGenerated]
		private readonly List<FactoredLoad> #U = new List<FactoredLoad>();

		// Token: 0x02000218 RID: 536
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x04000755 RID: 1877
			public static Func<FactoredLoad, bool> #a;

			// Token: 0x04000756 RID: 1878
			public static Func<FactoredLoad, FactoredLoad, bool> #b;

			// Token: 0x04000757 RID: 1879
			public static Func<ETABSFactoredLoad, bool> #c;

			// Token: 0x04000758 RID: 1880
			public static Func<ETABSFactoredLoad, ETABSFactoredLoad, bool> #d;
		}

		// Token: 0x0200021A RID: 538
		[CompilerGenerated]
		private sealed class #RVd
		{
			// Token: 0x0600129F RID: 4767 RVA: 0x00014528 File Offset: 0x00012728
			internal bool #6Xb(ComboItem<string> #Rf)
			{
				return #Rf.Value == this.#a.SelectedToStory;
			}

			// Token: 0x060012A0 RID: 4768 RVA: 0x0001454C File Offset: 0x0001274C
			internal bool #7Xb(ComboItem<string> #Rf)
			{
				return #Rf.Value == this.#b;
			}

			// Token: 0x0400078B RID: 1931
			public EtabsImportWindowViewModel #a;

			// Token: 0x0400078C RID: 1932
			public string #b;
		}

		// Token: 0x0200021B RID: 539
		[CompilerGenerated]
		private sealed class #5Dg
		{
			// Token: 0x060012A2 RID: 4770 RVA: 0x0001456B File Offset: 0x0001276B
			internal bool #9Xb(ComboItem<string> #Rf)
			{
				return #Rf.Value == this.#a;
			}

			// Token: 0x060012A3 RID: 4771 RVA: 0x0001458A File Offset: 0x0001278A
			internal bool #aYb(ComboItem<string> #Rf)
			{
				return #Rf.Value == this.#b.SelectedFromStory;
			}

			// Token: 0x0400078D RID: 1933
			public string #a;

			// Token: 0x0400078E RID: 1934
			public EtabsImportWindowViewModel #b;
		}

		// Token: 0x0200021C RID: 540
		[CompilerGenerated]
		private sealed class #a1i
		{
			// Token: 0x060012A5 RID: 4773 RVA: 0x000145AE File Offset: 0x000127AE
			internal void #1Yb()
			{
				this.#a.IsSelected = true;
			}

			// Token: 0x0400078F RID: 1935
			public RadTabItem #a;
		}

		// Token: 0x0200021D RID: 541
		[CompilerGenerated]
		private sealed class #b1i
		{
			// Token: 0x060012A7 RID: 4775 RVA: 0x000145C4 File Offset: 0x000127C4
			internal ValueTuple<List<ETABSFactoredLoad>, List<string>> #3Yb()
			{
				return this.#a.#ZE(this.#b, this.#c);
			}

			// Token: 0x04000790 RID: 1936
			public EtabsImportWindowViewModel #a;

			// Token: 0x04000791 RID: 1937
			public string[] #b;

			// Token: 0x04000792 RID: 1938
			public string[] #c;
		}

		// Token: 0x0200021E RID: 542
		[CompilerGenerated]
		private sealed class #c1i
		{
			// Token: 0x060012A9 RID: 4777 RVA: 0x000145E9 File Offset: 0x000127E9
			internal bool #8Yb(<>f__AnonymousType9<string, int> #bF)
			{
				return #bF.Index >= this.#a && #bF.Index <= this.#b;
			}

			// Token: 0x04000793 RID: 1939
			public int #a;

			// Token: 0x04000794 RID: 1940
			public int #b;
		}
	}
}
