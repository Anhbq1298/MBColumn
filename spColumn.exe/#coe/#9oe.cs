using System;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;

namespace #coe
{
	// Token: 0x0200110A RID: 4362
	internal sealed class #9oe
	{
		// Token: 0x060093DD RID: 37853 RVA: 0x00076484 File Offset: 0x00074684
		public #9oe(ColumnStorageModel #Od, bool #DCb = true)
		{
			this.Model = #Od;
			this.IsValid = #DCb;
		}

		// Token: 0x060093DE RID: 37854 RVA: 0x0007649A File Offset: 0x0007469A
		public static #9oe #4oe()
		{
			return new #9oe(null, false);
		}

		// Token: 0x060093DF RID: 37855 RVA: 0x000764A3 File Offset: 0x000746A3
		public static #9oe #4oe(string #nzb)
		{
			return new #9oe(null, false)
			{
				ErrorMessage = #nzb
			};
		}

		// Token: 0x17002AB0 RID: 10928
		// (get) Token: 0x060093E0 RID: 37856 RVA: 0x000764B3 File Offset: 0x000746B3
		// (set) Token: 0x060093E1 RID: 37857 RVA: 0x000764BB File Offset: 0x000746BB
		public ColumnStorageModel Model { get; set; }

		// Token: 0x17002AB1 RID: 10929
		// (get) Token: 0x060093E2 RID: 37858 RVA: 0x000764C4 File Offset: 0x000746C4
		// (set) Token: 0x060093E3 RID: 37859 RVA: 0x000764CC File Offset: 0x000746CC
		public bool Canceled { get; set; }

		// Token: 0x17002AB2 RID: 10930
		// (get) Token: 0x060093E4 RID: 37860 RVA: 0x000764D5 File Offset: 0x000746D5
		// (set) Token: 0x060093E5 RID: 37861 RVA: 0x000764DD File Offset: 0x000746DD
		public bool IsValid { get; set; }

		// Token: 0x17002AB3 RID: 10931
		// (get) Token: 0x060093E6 RID: 37862 RVA: 0x000764E6 File Offset: 0x000746E6
		// (set) Token: 0x060093E7 RID: 37863 RVA: 0x000764EE File Offset: 0x000746EE
		public string ErrorMessage { get; set; }

		// Token: 0x17002AB4 RID: 10932
		// (get) Token: 0x060093E8 RID: 37864 RVA: 0x000764F7 File Offset: 0x000746F7
		// (set) Token: 0x060093E9 RID: 37865 RVA: 0x000764FF File Offset: 0x000746FF
		public LoadType OriginalLoadType { get; set; }

		// Token: 0x04003F08 RID: 16136
		[CompilerGenerated]
		private ColumnStorageModel #a;

		// Token: 0x04003F09 RID: 16137
		[CompilerGenerated]
		private bool #b;

		// Token: 0x04003F0A RID: 16138
		[CompilerGenerated]
		private bool #c;

		// Token: 0x04003F0B RID: 16139
		[CompilerGenerated]
		private string #d;

		// Token: 0x04003F0C RID: 16140
		[CompilerGenerated]
		private LoadType #e;
	}
}
