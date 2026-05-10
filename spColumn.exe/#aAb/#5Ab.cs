using System;
using System.Collections.Generic;
using System.Linq;
using #7hc;
using #eU;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;

namespace #aAb
{
	// Token: 0x0200052A RID: 1322
	internal sealed class #5Ab
	{
		// Token: 0x06002F92 RID: 12178 RVA: 0x0002A607 File Offset: 0x00028807
		public #5Ab(#oW #xn)
		{
			if (#xn == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107404877));
			}
			this.#a = #xn;
		}

		// Token: 0x17000F83 RID: 3971
		// (get) Token: 0x06002F93 RID: 12179 RVA: 0x0002A62A File Offset: 0x0002882A
		private ColumnModel Model
		{
			get
			{
				return this.#a.Model;
			}
		}

		// Token: 0x06002F94 RID: 12180 RVA: 0x000F5B34 File Offset: 0x000F3D34
		public void #3Ab(IList<ReinforcementBar> #4Ab)
		{
			HashSet<ReinforcementBar> hashSet = this.Model.ReinforcementBars.ToHashSet<ReinforcementBar>();
			hashSet.ExceptWith(#4Ab);
			foreach (ReinforcementBar reinforcementBar in #4Ab)
			{
				IList<ReinforcementBar> list = ColumnModelHelper.#4W(hashSet, reinforcementBar.Point);
				hashSet.Add(reinforcementBar);
				foreach (ReinforcementBar item in list)
				{
					this.Model.ReinforcementBars.Remove(item);
				}
			}
		}

		// Token: 0x04001334 RID: 4916
		private readonly #oW #a;
	}
}
