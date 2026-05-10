using System;
using System.Collections.Generic;
using System.Linq;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.DataExchange.CSV
{
	// Token: 0x02000788 RID: 1928
	public sealed class CSVRow
	{
		// Token: 0x06003E07 RID: 15879 RVA: 0x00035002 File Offset: 0x00033202
		public CSVRow()
		{
			this.#a = new List<CSVCell>();
		}

		// Token: 0x06003E08 RID: 15880 RVA: 0x00035015 File Offset: 0x00033215
		public CSVRow(IEnumerable<CSVCell> cells) : this()
		{
			if (cells != null)
			{
				this.#a.AddRange(cells.ToArray<CSVCell>());
			}
		}

		// Token: 0x170012E3 RID: 4835
		// (get) Token: 0x06003E09 RID: 15881 RVA: 0x00035031 File Offset: 0x00033231
		public IList<CSVCell> Cells
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x06003E0A RID: 15882 RVA: 0x00035039 File Offset: 0x00033239
		public CSVRow #dlc(string #f)
		{
			ICollection<CSVCell> collection = this.Cells;
			CSVCell item = new CSVCell(#f);
			if (7 != 0)
			{
				collection.Add(item);
			}
			return this;
		}

		// Token: 0x06003E0B RID: 15883 RVA: 0x0011CFBC File Offset: 0x0011B1BC
		public void #elc(IEnumerable<string> #Qb)
		{
			if (7 != 0 && !false)
			{
				string #R0d = #Phc.#3hc(107377120);
				Component #x6c = Component.DataExchange;
				string #Qic = #Phc.#3hc(107377143);
				if (!false)
				{
					#X0d.#V0d(#Qb, #R0d, #x6c, #Qic);
				}
			}
			IEnumerator<string> enumerator = #Qb.GetEnumerator();
			IEnumerator<string> enumerator2;
			if (true)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					string text = enumerator2.Current;
					string #f;
					if (!false)
					{
						#f = text;
					}
					this.#dlc(#f);
				}
			}
			finally
			{
				while (enumerator2 != null)
				{
					if (4 != 0)
					{
						enumerator2.Dispose();
						break;
					}
				}
			}
		}

		// Token: 0x04001C2D RID: 7213
		private readonly List<CSVCell> #a;
	}
}
