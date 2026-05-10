using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy.Entities;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime
{
	// Token: 0x02001337 RID: 4919
	[DebuggerDisplay("X={X}, Y={Y}, Z={Z}")]
	public sealed class ReinforcementBar
	{
		// Token: 0x0600A45D RID: 42077 RVA: 0x000806CB File Offset: 0x0007E8CB
		public ReinforcementBar(ReinforcementBar bar)
		{
			this.X = bar.X;
			this.Y = bar.Y;
			this.Z = bar.Z;
			this.Area = bar.Area;
		}

		// Token: 0x0600A45E RID: 42078 RVA: 0x0022FA58 File Offset: 0x0022DC58
		public ReinforcementBar(ReinforcementBar oldBar)
		{
			this.X = oldBar.X;
			this.Y = oldBar.Y;
			this.Z = oldBar.Z;
			this.Area = oldBar.Area;
			this.Location = oldBar.Location;
		}

		// Token: 0x0600A45F RID: 42079 RVA: 0x000035C3 File Offset: 0x000017C3
		internal ReinforcementBar()
		{
		}

		// Token: 0x0600A460 RID: 42080 RVA: 0x00080703 File Offset: 0x0007E903
		public ReinforcementBar(float area, float x, float y, float z)
		{
			this.Area = area;
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		// Token: 0x17002F36 RID: 12086
		// (get) Token: 0x0600A461 RID: 42081 RVA: 0x00080728 File Offset: 0x0007E928
		// (set) Token: 0x0600A462 RID: 42082 RVA: 0x00080730 File Offset: 0x0007E930
		public float Area { get; set; }

		// Token: 0x17002F37 RID: 12087
		// (get) Token: 0x0600A463 RID: 42083 RVA: 0x00080739 File Offset: 0x0007E939
		// (set) Token: 0x0600A464 RID: 42084 RVA: 0x00080741 File Offset: 0x0007E941
		public float X { get; set; }

		// Token: 0x17002F38 RID: 12088
		// (get) Token: 0x0600A465 RID: 42085 RVA: 0x0008074A File Offset: 0x0007E94A
		// (set) Token: 0x0600A466 RID: 42086 RVA: 0x00080752 File Offset: 0x0007E952
		public float Y { get; set; }

		// Token: 0x17002F39 RID: 12089
		// (get) Token: 0x0600A467 RID: 42087 RVA: 0x0008075B File Offset: 0x0007E95B
		// (set) Token: 0x0600A468 RID: 42088 RVA: 0x00080763 File Offset: 0x0007E963
		public float Z { get; set; }

		// Token: 0x17002F3A RID: 12090
		// (get) Token: 0x0600A469 RID: 42089 RVA: 0x0008076C File Offset: 0x0007E96C
		// (set) Token: 0x0600A46A RID: 42090 RVA: 0x00080774 File Offset: 0x0007E974
		public #I6e Location { get; private set; }

		// Token: 0x17002F3B RID: 12091
		// (get) Token: 0x0600A46B RID: 42091 RVA: 0x0008077D File Offset: 0x0007E97D
		// (set) Token: 0x0600A46C RID: 42092 RVA: 0x00080785 File Offset: 0x0007E985
		public bool IsWithinSection { get; private set; }

		// Token: 0x0600A46D RID: 42093 RVA: 0x0008078E File Offset: 0x0007E98E
		public void #VWi(#I6e #tEb)
		{
			this.Location = #tEb;
			this.IsWithinSection = (#tEb == #I6e.#a || #tEb == #I6e.#d);
		}

		// Token: 0x0600A46E RID: 42094 RVA: 0x000807A7 File Offset: 0x0007E9A7
		internal static ReinforcementBar #Dge(IRREG #Rf)
		{
			return new ReinforcementBar(#Rf.#a, #Rf.#b, #Rf.#c, #Rf.#d);
		}

		// Token: 0x04004809 RID: 18441
		[CompilerGenerated]
		private float #a;

		// Token: 0x0400480A RID: 18442
		[CompilerGenerated]
		private float #b;

		// Token: 0x0400480B RID: 18443
		[CompilerGenerated]
		private float #c;

		// Token: 0x0400480C RID: 18444
		[CompilerGenerated]
		private float #d;

		// Token: 0x0400480D RID: 18445
		[CompilerGenerated]
		private #I6e #e;

		// Token: 0x0400480E RID: 18446
		[CompilerGenerated]
		private bool #f;
	}
}
