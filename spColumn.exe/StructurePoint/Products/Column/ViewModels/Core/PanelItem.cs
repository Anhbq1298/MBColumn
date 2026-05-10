using System;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.Products.Column.ViewModels.API.Core;
using Telerik.Windows.Data;

namespace StructurePoint.Products.Column.ViewModels.Core
{
	// Token: 0x02000289 RID: 649
	internal sealed class PanelItem : NotifyPropertyChangedObjectBase
	{
		// Token: 0x060014E7 RID: 5351 RVA: 0x00015FAA File Offset: 0x000141AA
		public PanelItem(string header)
		{
			this.<Children>k__BackingField = new RadObservableCollection<PanelItem>();
			base..ctor();
			this.<PanelName>k__BackingField = header;
			this.<IsHeader>k__BackingField = true;
			this.IsEnabled = true;
		}

		// Token: 0x060014E8 RID: 5352 RVA: 0x00015FD9 File Offset: 0x000141D9
		public PanelItem(Enum panelIdentifier, string panelName, IPanel panel, bool isEnabled = true)
		{
			this.<Children>k__BackingField = new RadObservableCollection<PanelItem>();
			base..ctor();
			this.<PanelIdentifier>k__BackingField = panelIdentifier;
			this.<PanelName>k__BackingField = panelName;
			this.<Panel>k__BackingField = panel;
			this.IsEnabled = isEnabled;
		}

		// Token: 0x060014E9 RID: 5353 RVA: 0x00016010 File Offset: 0x00014210
		public PanelItem(Enum panelIdentifier, string panelName, IPanel panel, Func<bool> isEnabledLookup) : this(panelIdentifier, panelName, panel, false)
		{
			this.isEnabledLookup = isEnabledLookup;
		}

		// Token: 0x060014EA RID: 5354 RVA: 0x00016024 File Offset: 0x00014224
		private PanelItem()
		{
			this.<Children>k__BackingField = new RadObservableCollection<PanelItem>();
			base..ctor();
		}

		// Token: 0x1700077A RID: 1914
		// (get) Token: 0x060014EB RID: 5355 RVA: 0x0001603E File Offset: 0x0001423E
		public bool IsHeader { get; }

		// Token: 0x1700077B RID: 1915
		// (get) Token: 0x060014EC RID: 5356 RVA: 0x0001604A File Offset: 0x0001424A
		public Enum PanelIdentifier { get; }

		// Token: 0x1700077C RID: 1916
		// (get) Token: 0x060014ED RID: 5357 RVA: 0x00016056 File Offset: 0x00014256
		public string PanelName { get; }

		// Token: 0x1700077D RID: 1917
		// (get) Token: 0x060014EE RID: 5358 RVA: 0x00016062 File Offset: 0x00014262
		public IPanel Panel { get; }

		// Token: 0x1700077E RID: 1918
		// (get) Token: 0x060014EF RID: 5359 RVA: 0x0001606E File Offset: 0x0001426E
		// (set) Token: 0x060014F0 RID: 5360 RVA: 0x0001607A File Offset: 0x0001427A
		public bool IsSeparator { get; private set; }

		// Token: 0x1700077F RID: 1919
		// (get) Token: 0x060014F1 RID: 5361 RVA: 0x0001608B File Offset: 0x0001428B
		// (set) Token: 0x060014F2 RID: 5362 RVA: 0x00016097 File Offset: 0x00014297
		public bool IsExpanded
		{
			get
			{
				return this.isExpanded;
			}
			set
			{
				this.SetProperty<bool>(ref this.isExpanded, value, #Phc.#3hc(107408133));
			}
		}

		// Token: 0x17000780 RID: 1920
		// (get) Token: 0x060014F3 RID: 5363 RVA: 0x000160BD File Offset: 0x000142BD
		// (set) Token: 0x060014F4 RID: 5364 RVA: 0x000160C9 File Offset: 0x000142C9
		public bool IsEnabled
		{
			get
			{
				return this.isEnabled;
			}
			private set
			{
				this.SetProperty<bool>(ref this.isEnabled, value, #Phc.#3hc(107408148));
			}
		}

		// Token: 0x17000781 RID: 1921
		// (get) Token: 0x060014F5 RID: 5365 RVA: 0x000160EF File Offset: 0x000142EF
		// (set) Token: 0x060014F6 RID: 5366 RVA: 0x000160FB File Offset: 0x000142FB
		public bool IsSelected
		{
			get
			{
				return this.isSelected;
			}
			set
			{
				this.SetProperty<bool>(ref this.isSelected, value, #Phc.#3hc(107407591));
			}
		}

		// Token: 0x17000782 RID: 1922
		// (get) Token: 0x060014F7 RID: 5367 RVA: 0x00016121 File Offset: 0x00014321
		// (set) Token: 0x060014F8 RID: 5368 RVA: 0x0001612D File Offset: 0x0001432D
		public bool IsChecked
		{
			get
			{
				return this.isChecked;
			}
			set
			{
				this.SetProperty<bool>(ref this.isChecked, value, #Phc.#3hc(107407606));
			}
		}

		// Token: 0x17000783 RID: 1923
		// (get) Token: 0x060014F9 RID: 5369 RVA: 0x00016153 File Offset: 0x00014353
		public RadObservableCollection<PanelItem> Children { get; }

		// Token: 0x060014FA RID: 5370 RVA: 0x0001615F File Offset: 0x0001435F
		public static PanelItem Separator()
		{
			return new PanelItem
			{
				IsSeparator = true
			};
		}

		// Token: 0x060014FB RID: 5371 RVA: 0x00016171 File Offset: 0x00014371
		public void UpdateEnabledStatus()
		{
			if (this.isEnabledLookup == null)
			{
				return;
			}
			this.IsEnabled = this.isEnabledLookup();
		}

		// Token: 0x04000883 RID: 2179
		private bool isExpanded = true;

		// Token: 0x04000884 RID: 2180
		private bool isSelected;

		// Token: 0x04000885 RID: 2181
		private bool isEnabled;

		// Token: 0x04000886 RID: 2182
		private bool isChecked;

		// Token: 0x04000887 RID: 2183
		private readonly Func<bool> isEnabledLookup;
	}
}
