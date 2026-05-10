using System;
using System.Diagnostics.CodeAnalysis;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace #00c
{
	// Token: 0x02000CB2 RID: 3250
	[SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "DataBase", Justification = "It is not database")]
	internal class #Z0c : NotifyPropertyChangedObjectBase, IContextMenuItemBase
	{
		// Token: 0x17001D30 RID: 7472
		// (get) Token: 0x060069F7 RID: 27127 RVA: 0x00053D92 File Offset: 0x00051F92
		// (set) Token: 0x060069F8 RID: 27128 RVA: 0x0019B950 File Offset: 0x00199B50
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

		// Token: 0x17001D31 RID: 7473
		// (get) Token: 0x060069F9 RID: 27129 RVA: 0x00053D9A File Offset: 0x00051F9A
		// (set) Token: 0x060069FA RID: 27130 RVA: 0x0019B9A0 File Offset: 0x00199BA0
		public object CommandParameter
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
						this.#c = value;
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

		// Token: 0x17001D32 RID: 7474
		// (get) Token: 0x060069FB RID: 27131 RVA: 0x00053DA2 File Offset: 0x00051FA2
		// (set) Token: 0x060069FC RID: 27132 RVA: 0x0019B9F4 File Offset: 0x00199BF4
		public object Icon
		{
			get
			{
				return this.#b;
			}
			set
			{
				for (;;)
				{
					if (this.#b == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107350937);
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
						this.#b = value;
						string propertyName2 = #Phc.#3hc(107350937);
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

		// Token: 0x04002B5E RID: 11102
		private string #a;

		// Token: 0x04002B5F RID: 11103
		private object #b;

		// Token: 0x04002B60 RID: 11104
		private object #c;
	}
}
