using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.PanelBar;

namespace #00c
{
	// Token: 0x02000CB9 RID: 3257
	internal sealed class #k1c : NotifyPropertyChangedObjectBase, IPanelBarControlItem
	{
		// Token: 0x06006A4B RID: 27211 RVA: 0x00053F1A File Offset: 0x0005211A
		public #k1c()
		{
			this.#b = new ObservableCollection<IPanelBarControlItem>();
		}

		// Token: 0x17001D52 RID: 7506
		// (get) Token: 0x06006A4C RID: 27212 RVA: 0x00053F2D File Offset: 0x0005212D
		// (set) Token: 0x06006A4D RID: 27213 RVA: 0x0019C6D0 File Offset: 0x0019A8D0
		public string Header
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value)
				{
					string propertyName = #Phc.#3hc(107450197);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					this.#a = value;
					string propertyName2 = #Phc.#3hc(107450197);
					if (!false)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001D53 RID: 7507
		// (get) Token: 0x06006A4E RID: 27214 RVA: 0x00053F35 File Offset: 0x00052135
		// (set) Token: 0x06006A4F RID: 27215 RVA: 0x0019C720 File Offset: 0x0019A920
		public ICommand Command
		{
			get
			{
				return this.#c;
			}
			set
			{
				for (;;)
				{
					if (this.#c == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107350928);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#c = value;
						string propertyName2 = #Phc.#3hc(107350928);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x17001D54 RID: 7508
		// (get) Token: 0x06006A50 RID: 27216 RVA: 0x00053F3D File Offset: 0x0005213D
		// (set) Token: 0x06006A51 RID: 27217 RVA: 0x0019C774 File Offset: 0x0019A974
		public object CommandParameter
		{
			get
			{
				return this.#d;
			}
			set
			{
				for (;;)
				{
					if (this.#d == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107350883);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#d = value;
						string propertyName2 = #Phc.#3hc(107350883);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x17001D55 RID: 7509
		// (get) Token: 0x06006A52 RID: 27218 RVA: 0x00053F45 File Offset: 0x00052145
		public ICollection<IPanelBarControlItem> Items
		{
			get
			{
				return this.#b;
			}
		}

		// Token: 0x17001D56 RID: 7510
		// (get) Token: 0x06006A53 RID: 27219 RVA: 0x00053F4D File Offset: 0x0005214D
		// (set) Token: 0x06006A54 RID: 27220 RVA: 0x0019C7C8 File Offset: 0x0019A9C8
		public bool IsExpanded
		{
			get
			{
				return this.#f;
			}
			set
			{
				for (;;)
				{
					if (this.#f == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107408133);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#f = value;
						string propertyName2 = #Phc.#3hc(107408133);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x17001D57 RID: 7511
		// (get) Token: 0x06006A55 RID: 27221 RVA: 0x00053F55 File Offset: 0x00052155
		// (set) Token: 0x06006A56 RID: 27222 RVA: 0x0019C81C File Offset: 0x0019AA1C
		public bool IsSelected
		{
			get
			{
				return this.#e;
			}
			set
			{
				for (;;)
				{
					if (this.#e == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107407591);
					if (5 != 0)
					{
						base.RaisePropertyChanging(propertyName);
					}
					IL_19:
					if (3 != 0)
					{
						if (false)
						{
							continue;
						}
						this.#e = value;
						string propertyName2 = #Phc.#3hc(107407591);
						if (!false)
						{
							base.RaisePropertyChanged(propertyName2);
						}
					}
					IL_36:
					if (true)
					{
						break;
					}
					goto IL_19;
				}
			}
		}

		// Token: 0x04002B82 RID: 11138
		private string #a;

		// Token: 0x04002B83 RID: 11139
		private readonly ObservableCollection<IPanelBarControlItem> #b;

		// Token: 0x04002B84 RID: 11140
		private ICommand #c;

		// Token: 0x04002B85 RID: 11141
		private object #d;

		// Token: 0x04002B86 RID: 11142
		private bool #e;

		// Token: 0x04002B87 RID: 11143
		private bool #f;
	}
}
