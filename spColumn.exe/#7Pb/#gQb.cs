using System;
using System.Runtime.CompilerServices;
using System.Windows;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using Telerik.Windows.Data;

namespace #7Pb
{
	// Token: 0x02000448 RID: 1096
	internal abstract class #gQb : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06002832 RID: 10290 RVA: 0x00025182 File Offset: 0x00023382
		protected #gQb(string #snb, Visibility #hQb = Visibility.Visible)
		{
			this.#b = #snb;
			this.#a = #hQb;
		}

		// Token: 0x17000D75 RID: 3445
		// (get) Token: 0x06002833 RID: 10291 RVA: 0x000251A3 File Offset: 0x000233A3
		public string ColumnDefinitions { get; }

		// Token: 0x17000D76 RID: 3446
		// (get) Token: 0x06002834 RID: 10292 RVA: 0x000251AF File Offset: 0x000233AF
		// (set) Token: 0x06002835 RID: 10293 RVA: 0x000251BB File Offset: 0x000233BB
		public Visibility Visibility
		{
			get
			{
				return this.#a;
			}
			set
			{
				if (this.#a != value)
				{
					base.RaisePropertyChanging(#Phc.#3hc(107384000));
					this.#a = value;
					base.RaisePropertyChanged(#Phc.#3hc(107384000));
				}
			}
		}

		// Token: 0x17000D77 RID: 3447
		// (get) Token: 0x06002836 RID: 10294 RVA: 0x000251F9 File Offset: 0x000233F9
		public RadObservableCollection<#nQb> Values { get; }

		// Token: 0x06002837 RID: 10295 RVA: 0x000DA9DC File Offset: 0x000D8BDC
		public void #yl()
		{
			foreach (#nQb #nQb in this.Values)
			{
				if (#nQb != #nQb.Separator)
				{
					#nQb.Value = string.Empty;
				}
			}
		}

		// Token: 0x06002838 RID: 10296 RVA: 0x000DAA44 File Offset: 0x000D8C44
		protected void #fQb()
		{
			for (int i = 0; i < this.Values.Count; i++)
			{
				this.Values[i].Index = i;
			}
		}

		// Token: 0x04000FDE RID: 4062
		private Visibility #a;

		// Token: 0x04000FDF RID: 4063
		[CompilerGenerated]
		private readonly string #b;

		// Token: 0x04000FE0 RID: 4064
		[CompilerGenerated]
		private readonly RadObservableCollection<#nQb> #c = new RadObservableCollection<#nQb>();
	}
}
