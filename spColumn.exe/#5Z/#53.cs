using System;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace #5Z
{
	// Token: 0x020003AF RID: 943
	internal sealed class #53 : #20
	{
		// Token: 0x06001F70 RID: 8048 RVA: 0x0001CC2D File Offset: 0x0001AE2D
		public #53()
		{
		}

		// Token: 0x06001F71 RID: 8049 RVA: 0x0001EAF7 File Offset: 0x0001CCF7
		public #53(Ties #63)
		{
			this.LargeTie = #63.LargeTie;
			this.SmallTie = #63.SmallTie;
			this.LongitudinalBar = #63.LongitudinalBar;
		}

		// Token: 0x17000AFD RID: 2813
		// (get) Token: 0x06001F72 RID: 8050 RVA: 0x0001EB23 File Offset: 0x0001CD23
		// (set) Token: 0x06001F73 RID: 8051 RVA: 0x0001EB2F File Offset: 0x0001CD2F
		public int SmallTie
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.SetProperty<int>(ref this.#a, value, #Phc.#3hc(107397739));
			}
		}

		// Token: 0x17000AFE RID: 2814
		// (get) Token: 0x06001F74 RID: 8052 RVA: 0x0001EB55 File Offset: 0x0001CD55
		// (set) Token: 0x06001F75 RID: 8053 RVA: 0x0001EB61 File Offset: 0x0001CD61
		public int LargeTie
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<int>(ref this.#b, value, #Phc.#3hc(107397758));
			}
		}

		// Token: 0x17000AFF RID: 2815
		// (get) Token: 0x06001F76 RID: 8054 RVA: 0x0001EB87 File Offset: 0x0001CD87
		// (set) Token: 0x06001F77 RID: 8055 RVA: 0x0001EB93 File Offset: 0x0001CD93
		public int LongitudinalBar
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.SetProperty<int>(ref this.#c, value, #Phc.#3hc(107397745));
			}
		}

		// Token: 0x06001F78 RID: 8056 RVA: 0x0001EBB9 File Offset: 0x0001CDB9
		public Ties #CY()
		{
			return new Ties
			{
				SmallTie = this.SmallTie,
				LongitudinalBar = this.LongitudinalBar,
				LargeTie = this.LargeTie
			};
		}

		// Token: 0x04000C72 RID: 3186
		private int #a;

		// Token: 0x04000C73 RID: 3187
		private int #b;

		// Token: 0x04000C74 RID: 3188
		private int #c;
	}
}
