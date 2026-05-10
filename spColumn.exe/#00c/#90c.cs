using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Tree;

namespace #00c
{
	// Token: 0x02000CB4 RID: 3252
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Hideable")]
	internal sealed class #90c : #o1c, INotifyPropertyChanged, IHideableTreeItemData, ITreeItemData
	{
		// Token: 0x17001D37 RID: 7479
		// (get) Token: 0x06006A0D RID: 27149 RVA: 0x00053DEE File Offset: 0x00051FEE
		// (set) Token: 0x06006A0E RID: 27150 RVA: 0x0019BE1C File Offset: 0x0019A01C
		public bool IsVisible
		{
			get
			{
				return this.#a;
			}
			set
			{
				for (;;)
				{
					if (this.#a == value)
					{
						goto IL_36;
					}
					string propertyName = #Phc.#3hc(107351275);
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
						this.#a = value;
						string propertyName2 = #Phc.#3hc(107351275);
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

		// Token: 0x17001D38 RID: 7480
		// (get) Token: 0x06006A0F RID: 27151 RVA: 0x00053DF6 File Offset: 0x00051FF6
		// (set) Token: 0x06006A10 RID: 27152 RVA: 0x0019BE70 File Offset: 0x0019A070
		public bool IsEnabled
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
					string propertyName = #Phc.#3hc(107408148);
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
						string propertyName2 = #Phc.#3hc(107408148);
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

		// Token: 0x06006A11 RID: 27153 RVA: 0x00053DFE File Offset: 0x00051FFE
		public #90c(string #Ae) : base(#Ae)
		{
		}

		// Token: 0x04002B66 RID: 11110
		private bool #a;

		// Token: 0x04002B67 RID: 11111
		private bool #b;
	}
}
