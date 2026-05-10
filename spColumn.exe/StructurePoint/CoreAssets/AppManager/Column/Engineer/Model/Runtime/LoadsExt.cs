using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy.Entities;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime
{
	// Token: 0x0200132F RID: 4911
	public sealed class LoadsExt
	{
		// Token: 0x0600A404 RID: 41988 RVA: 0x000801A2 File Offset: 0x0007E3A2
		public LoadsExt(FactoredLoad load)
		{
			this.AxialLoad = load.AxialLoad;
			this.MomentX = load.MomentX;
			this.MomentY = load.MomentY;
		}

		// Token: 0x0600A405 RID: 41989 RVA: 0x000801CE File Offset: 0x0007E3CE
		public LoadsExt(AxialLoad load)
		{
			this.AxialLoad = load.InitialLoad;
			this.MomentX = load.FinalLoad;
			this.MomentY = load.Increment;
		}

		// Token: 0x0600A406 RID: 41990 RVA: 0x000801FA File Offset: 0x0007E3FA
		internal LoadsExt(float axialLoad, float momentX, float momentY)
		{
			this.AxialLoad = axialLoad;
			this.MomentX = momentX;
			this.MomentY = momentY;
		}

		// Token: 0x17002F0D RID: 12045
		// (get) Token: 0x0600A407 RID: 41991 RVA: 0x00080217 File Offset: 0x0007E417
		// (set) Token: 0x0600A408 RID: 41992 RVA: 0x0008021F File Offset: 0x0007E41F
		public int ServiceLoadIdx { get; private set; }

		// Token: 0x17002F0E RID: 12046
		// (get) Token: 0x0600A409 RID: 41993 RVA: 0x00080228 File Offset: 0x0007E428
		// (set) Token: 0x0600A40A RID: 41994 RVA: 0x00080230 File Offset: 0x0007E430
		public int LoadCombinationIndex { get; private set; }

		// Token: 0x17002F0F RID: 12047
		// (get) Token: 0x0600A40B RID: 41995 RVA: 0x00080239 File Offset: 0x0007E439
		// (set) Token: 0x0600A40C RID: 41996 RVA: 0x00080241 File Offset: 0x0007E441
		public float AxialLoad { get; set; }

		// Token: 0x17002F10 RID: 12048
		// (get) Token: 0x0600A40D RID: 41997 RVA: 0x0008024A File Offset: 0x0007E44A
		// (set) Token: 0x0600A40E RID: 41998 RVA: 0x00080252 File Offset: 0x0007E452
		public float MomentX { get; set; }

		// Token: 0x17002F11 RID: 12049
		// (get) Token: 0x0600A40F RID: 41999 RVA: 0x0008025B File Offset: 0x0007E45B
		// (set) Token: 0x0600A410 RID: 42000 RVA: 0x00080263 File Offset: 0x0007E463
		public float MomentY { get; set; }

		// Token: 0x0600A411 RID: 42001 RVA: 0x0008026C File Offset: 0x0007E46C
		public LoadsExt #EA()
		{
			return new LoadsExt(this.AxialLoad, this.MomentX, this.MomentY)
			{
				ServiceLoadIdx = this.ServiceLoadIdx,
				LoadCombinationIndex = this.LoadCombinationIndex
			};
		}

		// Token: 0x0600A412 RID: 42002 RVA: 0x0008029D File Offset: 0x0007E49D
		internal static LoadsExt #Dge(LOADS #Rf)
		{
			return new LoadsExt(#Rf.#a, #Rf.#b, #Rf.#c);
		}

		// Token: 0x0600A413 RID: 42003 RVA: 0x000802B6 File Offset: 0x0007E4B6
		public void #5Pe(int #E0e, int #F0e, float #Tdb, float #0jb, float #1jb)
		{
			this.ServiceLoadIdx = #E0e;
			this.LoadCombinationIndex = #F0e;
			this.AxialLoad = #Tdb;
			this.MomentX = #0jb;
			this.MomentY = #1jb;
		}

		// Token: 0x040047DC RID: 18396
		[CompilerGenerated]
		private int #a;

		// Token: 0x040047DD RID: 18397
		[CompilerGenerated]
		private int #b;

		// Token: 0x040047DE RID: 18398
		[CompilerGenerated]
		private float #c;

		// Token: 0x040047DF RID: 18399
		[CompilerGenerated]
		private float #d;

		// Token: 0x040047E0 RID: 18400
		[CompilerGenerated]
		private float #e;
	}
}
