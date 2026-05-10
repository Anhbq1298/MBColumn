using System;
using System.Collections.Generic;
using System.Windows.Input;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using Telerik.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Menu
{
	// Token: 0x0200098C RID: 2444
	public sealed class MenuItemExt : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06004F8F RID: 20367 RVA: 0x000423B2 File Offset: 0x000405B2
		public MenuItemExt()
		{
			this.<SubItems>k__BackingField = new RadObservableCollection<MenuItemExt>();
		}

		// Token: 0x170016E0 RID: 5856
		// (get) Token: 0x06004F90 RID: 20368 RVA: 0x000423C5 File Offset: 0x000405C5
		// (set) Token: 0x06004F91 RID: 20369 RVA: 0x000423D1 File Offset: 0x000405D1
		public HelpID HelpId
		{
			get
			{
				return this.helpId;
			}
			set
			{
				if (this.helpId != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107466474));
					this.helpId = value;
					base.RaisePropertyChanged(#Phc.#3hc(107466474));
				}
			}
		}

		// Token: 0x170016E1 RID: 5857
		// (get) Token: 0x06004F92 RID: 20370 RVA: 0x0004240F File Offset: 0x0004060F
		// (set) Token: 0x06004F93 RID: 20371 RVA: 0x0004241B File Offset: 0x0004061B
		public bool IsCheckable
		{
			get
			{
				return this.isCheckable;
			}
			set
			{
				if (this.isCheckable != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107466465));
					this.isCheckable = value;
					base.RaisePropertyChanged(#Phc.#3hc(107466465));
				}
			}
		}

		// Token: 0x170016E2 RID: 5858
		// (get) Token: 0x06004F94 RID: 20372 RVA: 0x00042459 File Offset: 0x00040659
		// (set) Token: 0x06004F95 RID: 20373 RVA: 0x00042465 File Offset: 0x00040665
		public bool IsChecked
		{
			get
			{
				return this.isChecked;
			}
			set
			{
				if (this.isChecked != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107407606));
					this.isChecked = value;
					base.RaisePropertyChanged(#Phc.#3hc(107407606));
				}
			}
		}

		// Token: 0x170016E3 RID: 5859
		// (get) Token: 0x06004F96 RID: 20374 RVA: 0x000424A3 File Offset: 0x000406A3
		// (set) Token: 0x06004F97 RID: 20375 RVA: 0x000424AF File Offset: 0x000406AF
		public bool IsSeparator
		{
			get
			{
				return this.isSeparator;
			}
			set
			{
				if (this.isSeparator != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107466480));
					this.isSeparator = value;
					base.RaisePropertyChanged(#Phc.#3hc(107466480));
				}
			}
		}

		// Token: 0x170016E4 RID: 5860
		// (get) Token: 0x06004F98 RID: 20376 RVA: 0x000424ED File Offset: 0x000406ED
		// (set) Token: 0x06004F99 RID: 20377 RVA: 0x000424F9 File Offset: 0x000406F9
		public object Icon
		{
			get
			{
				return this.icon;
			}
			set
			{
				if (this.icon != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107350937));
					this.icon = value;
					base.RaisePropertyChanged(#Phc.#3hc(107350937));
				}
			}
		}

		// Token: 0x170016E5 RID: 5861
		// (get) Token: 0x06004F9A RID: 20378 RVA: 0x00042537 File Offset: 0x00040737
		// (set) Token: 0x06004F9B RID: 20379 RVA: 0x0015C7F0 File Offset: 0x0015A9F0
		public string Text
		{
			get
			{
				return this.text;
			}
			set
			{
				if (this.text != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107350927));
					this.text = value;
					base.RaisePropertyChanged(#Phc.#3hc(107350927));
				}
			}
		}

		// Token: 0x170016E6 RID: 5862
		// (get) Token: 0x06004F9C RID: 20380 RVA: 0x00042543 File Offset: 0x00040743
		// (set) Token: 0x06004F9D RID: 20381 RVA: 0x0015C840 File Offset: 0x0015AA40
		public string Shortcut
		{
			get
			{
				return this.shortcut;
			}
			set
			{
				if (this.shortcut != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107466463));
					this.shortcut = value;
					base.RaisePropertyChanged(#Phc.#3hc(107466463));
				}
			}
		}

		// Token: 0x170016E7 RID: 5863
		// (get) Token: 0x06004F9E RID: 20382 RVA: 0x0004254F File Offset: 0x0004074F
		// (set) Token: 0x06004F9F RID: 20383 RVA: 0x0004255B File Offset: 0x0004075B
		public object Tooltip
		{
			get
			{
				return this.tooltip;
			}
			set
			{
				if (this.tooltip != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107466450));
					this.tooltip = value;
					base.RaisePropertyChanged(#Phc.#3hc(107466450));
				}
			}
		}

		// Token: 0x170016E8 RID: 5864
		// (get) Token: 0x06004FA0 RID: 20384 RVA: 0x00042599 File Offset: 0x00040799
		// (set) Token: 0x06004FA1 RID: 20385 RVA: 0x000425A5 File Offset: 0x000407A5
		public ICommand Command
		{
			get
			{
				return this.command;
			}
			set
			{
				if (this.command != value)
				{
					this.command = value;
				}
			}
		}

		// Token: 0x170016E9 RID: 5865
		// (get) Token: 0x06004FA2 RID: 20386 RVA: 0x000425C3 File Offset: 0x000407C3
		// (set) Token: 0x06004FA3 RID: 20387 RVA: 0x000425CF File Offset: 0x000407CF
		public object CommandParameter
		{
			get
			{
				return this.commandParameter;
			}
			set
			{
				if (this.commandParameter != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107350883));
					this.commandParameter = value;
					base.RaisePropertyChanged(#Phc.#3hc(107350883));
				}
			}
		}

		// Token: 0x170016EA RID: 5866
		// (get) Token: 0x06004FA4 RID: 20388 RVA: 0x0004260D File Offset: 0x0004080D
		public ICollection<MenuItemExt> SubItems { get; }

		// Token: 0x06004FA5 RID: 20389 RVA: 0x00042619 File Offset: 0x00040819
		public static MenuItemExt CreateSeparator()
		{
			return new MenuItemExt
			{
				IsSeparator = true
			};
		}

		// Token: 0x040022CC RID: 8908
		private object icon;

		// Token: 0x040022CD RID: 8909
		private string text;

		// Token: 0x040022CE RID: 8910
		private object tooltip;

		// Token: 0x040022CF RID: 8911
		private ICommand command;

		// Token: 0x040022D0 RID: 8912
		private object commandParameter;

		// Token: 0x040022D1 RID: 8913
		private HelpID helpId;

		// Token: 0x040022D2 RID: 8914
		private bool isSeparator;

		// Token: 0x040022D3 RID: 8915
		private bool isChecked;

		// Token: 0x040022D4 RID: 8916
		private bool isCheckable;

		// Token: 0x040022D5 RID: 8917
		private string shortcut;
	}
}
