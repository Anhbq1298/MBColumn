using System;
using System.Runtime.CompilerServices;
using #Gke;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace #z5e
{
	// Token: 0x02001362 RID: 4962
	internal sealed class #y5e
	{
		// Token: 0x0600A674 RID: 42612 RVA: 0x00231CBC File Offset: 0x0022FEBC
		public #y5e(Beam #Rf)
		{
			this.NoBeam = (#Rf.BeamType == BeamType.None);
			this.Depth = #Rf.Depth;
			this.Length = #Rf.Length;
			this.MofI = #Rf.MofI;
			this.Ec = #Rf.Ec;
		}

		// Token: 0x0600A675 RID: 42613 RVA: 0x00231D10 File Offset: 0x0022FF10
		internal #y5e(#Fke #Rf)
		{
			this.NoBeam = (#Rf.#a == 1);
			this.Length = #Rf.#b;
			this.Depth = #Rf.#d;
			this.MofI = #Rf.#e;
			this.Ec = #Rf.#g;
		}

		// Token: 0x17003032 RID: 12338
		// (get) Token: 0x0600A676 RID: 42614 RVA: 0x00081925 File Offset: 0x0007FB25
		// (set) Token: 0x0600A677 RID: 42615 RVA: 0x0008192D File Offset: 0x0007FB2D
		public bool NoBeam { get; private set; }

		// Token: 0x17003033 RID: 12339
		// (get) Token: 0x0600A678 RID: 42616 RVA: 0x00081936 File Offset: 0x0007FB36
		// (set) Token: 0x0600A679 RID: 42617 RVA: 0x0008193E File Offset: 0x0007FB3E
		public float Length { get; private set; }

		// Token: 0x17003034 RID: 12340
		// (get) Token: 0x0600A67A RID: 42618 RVA: 0x00081947 File Offset: 0x0007FB47
		// (set) Token: 0x0600A67B RID: 42619 RVA: 0x0008194F File Offset: 0x0007FB4F
		public float Depth { get; private set; }

		// Token: 0x17003035 RID: 12341
		// (get) Token: 0x0600A67C RID: 42620 RVA: 0x00081958 File Offset: 0x0007FB58
		// (set) Token: 0x0600A67D RID: 42621 RVA: 0x00081960 File Offset: 0x0007FB60
		public float MofI { get; private set; }

		// Token: 0x17003036 RID: 12342
		// (get) Token: 0x0600A67E RID: 42622 RVA: 0x00081969 File Offset: 0x0007FB69
		// (set) Token: 0x0600A67F RID: 42623 RVA: 0x00081971 File Offset: 0x0007FB71
		public float Ec { get; private set; }

		// Token: 0x04004946 RID: 18758
		[CompilerGenerated]
		private bool #a;

		// Token: 0x04004947 RID: 18759
		[CompilerGenerated]
		private float #b;

		// Token: 0x04004948 RID: 18760
		[CompilerGenerated]
		private float #c;

		// Token: 0x04004949 RID: 18761
		[CompilerGenerated]
		private float #d;

		// Token: 0x0400494A RID: 18762
		[CompilerGenerated]
		private float #e;
	}
}
