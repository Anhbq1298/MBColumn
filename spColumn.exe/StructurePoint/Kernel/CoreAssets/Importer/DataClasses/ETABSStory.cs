using System;
using System.Runtime.CompilerServices;
using #7hc;

namespace StructurePoint.Kernel.CoreAssets.Importer.DataClasses
{
	// Token: 0x02000E5F RID: 3679
	public sealed class ETABSStory
	{
		// Token: 0x060083D3 RID: 33747 RVA: 0x0006B78A File Offset: 0x0006998A
		internal ETABSStory(string name, double elevation, string towerName)
		{
			this.#a = name;
			this.Elevation = elevation;
			this.TowerName = towerName;
		}

		// Token: 0x17002796 RID: 10134
		// (get) Token: 0x060083D4 RID: 33748 RVA: 0x0006B7A7 File Offset: 0x000699A7
		public string Name
		{
			get
			{
				if (!string.IsNullOrEmpty(this.TowerName))
				{
					return this.TowerName + #Phc.#3hc(107408434) + this.#a;
				}
				return this.#a;
			}
		}

		// Token: 0x17002797 RID: 10135
		// (get) Token: 0x060083D5 RID: 33749 RVA: 0x0006B7D8 File Offset: 0x000699D8
		public string TowerName { get; }

		// Token: 0x17002798 RID: 10136
		// (get) Token: 0x060083D6 RID: 33750 RVA: 0x0006B7E0 File Offset: 0x000699E0
		public double Elevation { get; }

		// Token: 0x04003641 RID: 13889
		private readonly string #a;

		// Token: 0x04003642 RID: 13890
		[CompilerGenerated]
		private readonly string #b;

		// Token: 0x04003643 RID: 13891
		[CompilerGenerated]
		private readonly double #c;
	}
}
