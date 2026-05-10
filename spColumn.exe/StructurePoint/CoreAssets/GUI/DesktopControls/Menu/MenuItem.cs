using System;
using System.Collections.Generic;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using Telerik.Windows.Data;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Menu
{
	// Token: 0x0200098D RID: 2445
	public sealed class MenuItem : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06004FA6 RID: 20390 RVA: 0x0004262B File Offset: 0x0004082B
		public MenuItem()
		{
			this.<SubItems>k__BackingField = new RadObservableCollection<MenuItem>();
		}

		// Token: 0x170016EB RID: 5867
		// (get) Token: 0x06004FA7 RID: 20391 RVA: 0x0004263E File Offset: 0x0004083E
		// (set) Token: 0x06004FA8 RID: 20392 RVA: 0x0004264A File Offset: 0x0004084A
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

		// Token: 0x170016EC RID: 5868
		// (get) Token: 0x06004FA9 RID: 20393 RVA: 0x00042688 File Offset: 0x00040888
		// (set) Token: 0x06004FAA RID: 20394 RVA: 0x00042694 File Offset: 0x00040894
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

		// Token: 0x170016ED RID: 5869
		// (get) Token: 0x06004FAB RID: 20395 RVA: 0x000426D2 File Offset: 0x000408D2
		// (set) Token: 0x06004FAC RID: 20396 RVA: 0x000426DE File Offset: 0x000408DE
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

		// Token: 0x170016EE RID: 5870
		// (get) Token: 0x06004FAD RID: 20397 RVA: 0x0004271C File Offset: 0x0004091C
		// (set) Token: 0x06004FAE RID: 20398 RVA: 0x00042728 File Offset: 0x00040928
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

		// Token: 0x170016EF RID: 5871
		// (get) Token: 0x06004FAF RID: 20399 RVA: 0x00042766 File Offset: 0x00040966
		// (set) Token: 0x06004FB0 RID: 20400 RVA: 0x00042772 File Offset: 0x00040972
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

		// Token: 0x170016F0 RID: 5872
		// (get) Token: 0x06004FB1 RID: 20401 RVA: 0x000427B0 File Offset: 0x000409B0
		// (set) Token: 0x06004FB2 RID: 20402 RVA: 0x0015C890 File Offset: 0x0015AA90
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

		// Token: 0x170016F1 RID: 5873
		// (get) Token: 0x06004FB3 RID: 20403 RVA: 0x000427BC File Offset: 0x000409BC
		// (set) Token: 0x06004FB4 RID: 20404 RVA: 0x000427C8 File Offset: 0x000409C8
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

		// Token: 0x170016F2 RID: 5874
		// (get) Token: 0x06004FB5 RID: 20405 RVA: 0x00042806 File Offset: 0x00040A06
		// (set) Token: 0x06004FB6 RID: 20406 RVA: 0x00042812 File Offset: 0x00040A12
		public IDelegateCommand Command
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

		// Token: 0x170016F3 RID: 5875
		// (get) Token: 0x06004FB7 RID: 20407 RVA: 0x00042830 File Offset: 0x00040A30
		// (set) Token: 0x06004FB8 RID: 20408 RVA: 0x0004283C File Offset: 0x00040A3C
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

		// Token: 0x170016F4 RID: 5876
		// (get) Token: 0x06004FB9 RID: 20409 RVA: 0x0004287A File Offset: 0x00040A7A
		public ICollection<MenuItem> SubItems { get; }

		// Token: 0x06004FBA RID: 20410 RVA: 0x00042886 File Offset: 0x00040A86
		public static MenuItem CreateSeparator()
		{
			return new MenuItem
			{
				IsSeparator = true
			};
		}

		// Token: 0x040022D7 RID: 8919
		private object icon;

		// Token: 0x040022D8 RID: 8920
		private string text;

		// Token: 0x040022D9 RID: 8921
		private object tooltip;

		// Token: 0x040022DA RID: 8922
		private IDelegateCommand command;

		// Token: 0x040022DB RID: 8923
		private object commandParameter;

		// Token: 0x040022DC RID: 8924
		private HelpID helpId;

		// Token: 0x040022DD RID: 8925
		private bool isSeparator;

		// Token: 0x040022DE RID: 8926
		private bool isChecked;

		// Token: 0x040022DF RID: 8927
		private bool isCheckable;
	}
}
