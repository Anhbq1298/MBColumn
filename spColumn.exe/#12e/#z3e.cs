using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #7hc;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #12e
{
	// Token: 0x02001352 RID: 4946
	internal sealed class #z3e
	{
		// Token: 0x17002FBA RID: 12218
		// (get) Token: 0x0600A578 RID: 42360 RVA: 0x0008107A File Offset: 0x0007F27A
		public IReadOnlyList<LoadPointDrawingData> LoadPoints
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x17002FBB RID: 12219
		// (get) Token: 0x0600A579 RID: 42361 RVA: 0x00081082 File Offset: 0x0007F282
		// (set) Token: 0x0600A57A RID: 42362 RVA: 0x0008108A File Offset: 0x0007F28A
		public string OverallCapacity { get; set; }

		// Token: 0x0600A57B RID: 42363 RVA: 0x00230B2C File Offset: 0x0022ED2C
		internal void #y3e()
		{
			this.#b.Clear();
			foreach (LoadPointDrawingData loadPointDrawingData in this.#a)
			{
				this.#b[loadPointDrawingData.Index] = loadPointDrawingData;
			}
		}

		// Token: 0x0600A57C RID: 42364 RVA: 0x00081093 File Offset: 0x0007F293
		public LoadPointDrawingData #3hc(int #4jb)
		{
			return this.#b.#F1d(#4jb);
		}

		// Token: 0x0600A57D RID: 42365 RVA: 0x000810A1 File Offset: 0x0007F2A1
		public void #vzc(LoadPointDrawingData #Rf)
		{
			if (#Rf == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107398878));
			}
			this.#a.Add(#Rf);
		}

		// Token: 0x0600A57E RID: 42366 RVA: 0x000810C2 File Offset: 0x0007F2C2
		public void #pR(IEnumerable<LoadPointDrawingData> #8f)
		{
			if (#8f == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107264273));
			}
			this.#a.AddRange(#8f);
		}

		// Token: 0x040048C4 RID: 18628
		private readonly List<LoadPointDrawingData> #a = new List<LoadPointDrawingData>();

		// Token: 0x040048C5 RID: 18629
		private readonly Dictionary<int, LoadPointDrawingData> #b = new Dictionary<int, LoadPointDrawingData>();

		// Token: 0x040048C6 RID: 18630
		[CompilerGenerated]
		private string #c;
	}
}
