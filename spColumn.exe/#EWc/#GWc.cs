using System;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace #EWc
{
	// Token: 0x02000C88 RID: 3208
	internal sealed class #GWc : NotifyPropertyChangedObjectBase, #DWc
	{
		// Token: 0x17001CCD RID: 7373
		// (get) Token: 0x06006803 RID: 26627 RVA: 0x00052FDE File Offset: 0x000511DE
		// (set) Token: 0x06006804 RID: 26628 RVA: 0x001952AC File Offset: 0x001934AC
		public string Name
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value)
				{
					string propertyName = #Phc.#3hc(107409209);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					this.#a = value;
					string propertyName2 = #Phc.#3hc(107409209);
					if (!false)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x17001CCE RID: 7374
		// (get) Token: 0x06006805 RID: 26629 RVA: 0x00052FE6 File Offset: 0x000511E6
		// (set) Token: 0x06006806 RID: 26630 RVA: 0x001952FC File Offset: 0x001934FC
		public double RealValue
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
					string propertyName = #Phc.#3hc(107439561);
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
						string propertyName2 = #Phc.#3hc(107439561);
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

		// Token: 0x17001CCF RID: 7375
		// (get) Token: 0x06006807 RID: 26631 RVA: 0x00052FEE File Offset: 0x000511EE
		// (set) Token: 0x06006808 RID: 26632 RVA: 0x00195350 File Offset: 0x00193550
		public string DisplayValue
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					string propertyName = #Phc.#3hc(107462980);
					if (!false)
					{
						base.RaisePropertyChanging(propertyName);
					}
					this.#c = value;
					string propertyName2 = #Phc.#3hc(107462980);
					if (!false)
					{
						base.RaisePropertyChanged(propertyName2);
					}
				}
			}
		}

		// Token: 0x04002ACD RID: 10957
		private string #a;

		// Token: 0x04002ACE RID: 10958
		private double #b;

		// Token: 0x04002ACF RID: 10959
		private string #c;
	}
}
