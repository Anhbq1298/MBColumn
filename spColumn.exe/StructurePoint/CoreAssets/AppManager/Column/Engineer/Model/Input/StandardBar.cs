using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Input
{
	// Token: 0x0200136F RID: 4975
	public sealed class StandardBar
	{
		// Token: 0x0600A73B RID: 42811 RVA: 0x00082068 File Offset: 0x00080268
		internal StandardBar(int size, float diameter, float area)
		{
			this.Size = size;
			this.Diameter = diameter;
			this.Area = area;
		}

		// Token: 0x17003084 RID: 12420
		// (get) Token: 0x0600A73C RID: 42812 RVA: 0x00082085 File Offset: 0x00080285
		public int Size { get; }

		// Token: 0x17003085 RID: 12421
		// (get) Token: 0x0600A73D RID: 42813 RVA: 0x0008208D File Offset: 0x0008028D
		public float Diameter { get; }

		// Token: 0x17003086 RID: 12422
		// (get) Token: 0x0600A73E RID: 42814 RVA: 0x00082095 File Offset: 0x00080295
		public float Area { get; }

		// Token: 0x0600A73F RID: 42815 RVA: 0x0008209D File Offset: 0x0008029D
		internal static StandardBar #Dge(STNDBAR #Rf)
		{
			return new StandardBar((int)#Rf.#a, #Rf.#b, #Rf.#c);
		}

		// Token: 0x040049AF RID: 18863
		[CompilerGenerated]
		private readonly int #a;

		// Token: 0x040049B0 RID: 18864
		[CompilerGenerated]
		private readonly float #b;

		// Token: 0x040049B1 RID: 18865
		[CompilerGenerated]
		private readonly float #c;
	}
}
