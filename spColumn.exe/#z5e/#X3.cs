using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy.Entities;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace #z5e
{
	// Token: 0x0200136E RID: 4974
	internal sealed class #X3
	{
		// Token: 0x0600A72E RID: 42798 RVA: 0x0023275C File Offset: 0x0023095C
		public #X3(SlendernessOfDesignedColumn #9bd)
		{
			this.Height = #9bd.Height;
			this.Kbraced = #9bd.Kbraced;
			this.Ksway = #9bd.Ksway;
			this.IsBraced = #9bd.IsBraced;
			this.CheckSwayAtEndsOnly = #9bd.CheckSwayAtEndsOnly;
			this.Kmode = #9bd.Kmode;
			this.SumPc = #9bd.SumPc;
			this.SumPu = #9bd.SumPu;
		}

		// Token: 0x0600A72F RID: 42799 RVA: 0x002327D0 File Offset: 0x002309D0
		internal #X3(float #YW, float #oZe, float #nZe, bool #uQe, bool #o6e, int #p6e, float #EQe, float #DQe)
		{
			this.Height = #YW;
			this.Kbraced = #oZe;
			this.Ksway = #nZe;
			this.IsBraced = #uQe;
			this.CheckSwayAtEndsOnly = #o6e;
			this.Kmode = #p6e;
			this.SumPc = #EQe;
			this.SumPu = #DQe;
		}

		// Token: 0x1700307C RID: 12412
		// (get) Token: 0x0600A730 RID: 42800 RVA: 0x00081FD9 File Offset: 0x000801D9
		public float Height { get; }

		// Token: 0x1700307D RID: 12413
		// (get) Token: 0x0600A731 RID: 42801 RVA: 0x00081FE1 File Offset: 0x000801E1
		public bool IsBraced { get; }

		// Token: 0x1700307E RID: 12414
		// (get) Token: 0x0600A732 RID: 42802 RVA: 0x00081FE9 File Offset: 0x000801E9
		public bool CheckSwayAtEndsOnly { get; }

		// Token: 0x1700307F RID: 12415
		// (get) Token: 0x0600A733 RID: 42803 RVA: 0x00081FF1 File Offset: 0x000801F1
		public int Kmode { get; }

		// Token: 0x17003080 RID: 12416
		// (get) Token: 0x0600A734 RID: 42804 RVA: 0x00081FF9 File Offset: 0x000801F9
		public float SumPc { get; }

		// Token: 0x17003081 RID: 12417
		// (get) Token: 0x0600A735 RID: 42805 RVA: 0x00082001 File Offset: 0x00080201
		public float SumPu { get; }

		// Token: 0x17003082 RID: 12418
		// (get) Token: 0x0600A736 RID: 42806 RVA: 0x00082009 File Offset: 0x00080209
		// (set) Token: 0x0600A737 RID: 42807 RVA: 0x00082011 File Offset: 0x00080211
		public float Kbraced { get; set; }

		// Token: 0x17003083 RID: 12419
		// (get) Token: 0x0600A738 RID: 42808 RVA: 0x0008201A File Offset: 0x0008021A
		// (set) Token: 0x0600A739 RID: 42809 RVA: 0x00082022 File Offset: 0x00080222
		public float Ksway { get; set; }

		// Token: 0x0600A73A RID: 42810 RVA: 0x0008202B File Offset: 0x0008022B
		internal static #X3 #n6e(SLDDESCOL #Rf)
		{
			return new #X3(#Rf.#a, #Rf.#b, #Rf.#c, #Rf.#d == 1, #Rf.#e == 1, (int)#Rf.#f, #Rf.#g, #Rf.#h);
		}

		// Token: 0x040049A7 RID: 18855
		[CompilerGenerated]
		private readonly float #a;

		// Token: 0x040049A8 RID: 18856
		[CompilerGenerated]
		private readonly bool #b;

		// Token: 0x040049A9 RID: 18857
		[CompilerGenerated]
		private readonly bool #c;

		// Token: 0x040049AA RID: 18858
		[CompilerGenerated]
		private readonly int #d;

		// Token: 0x040049AB RID: 18859
		[CompilerGenerated]
		private readonly float #e;

		// Token: 0x040049AC RID: 18860
		[CompilerGenerated]
		private readonly float #f;

		// Token: 0x040049AD RID: 18861
		[CompilerGenerated]
		private float #g;

		// Token: 0x040049AE RID: 18862
		[CompilerGenerated]
		private float #h;
	}
}
