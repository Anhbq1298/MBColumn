using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.Units;

namespace #coe
{
	// Token: 0x02001107 RID: 4359
	internal sealed class #Uoe
	{
		// Token: 0x060093B6 RID: 37814 RVA: 0x001F7D94 File Offset: 0x001F5F94
		public #Uoe()
		{
			this.LengthUnit = (LengthUnit)(-1);
			this.UnitSystem = (UnitSystem)(-1);
			this.Solids = new List<SectionPolygon>();
			this.Openings = new List<SectionPolygon>();
			this.ReinforcementBars = new List<ReinforcementBar>();
			this.LayerNames = new List<string>();
		}

		// Token: 0x17002A9A RID: 10906
		// (get) Token: 0x060093B7 RID: 37815 RVA: 0x00076324 File Offset: 0x00074524
		public static #Uoe UnsupportedVersion { get; } = new #Uoe();

		// Token: 0x17002A9B RID: 10907
		// (get) Token: 0x060093B8 RID: 37816 RVA: 0x0007632B File Offset: 0x0007452B
		public static #Uoe Null { get; } = new #Uoe();

		// Token: 0x17002A9C RID: 10908
		// (get) Token: 0x060093B9 RID: 37817 RVA: 0x00076332 File Offset: 0x00074532
		public bool IsNull
		{
			get
			{
				return this == #Uoe.Null;
			}
		}

		// Token: 0x17002A9D RID: 10909
		// (get) Token: 0x060093BA RID: 37818 RVA: 0x0007633C File Offset: 0x0007453C
		public bool IsSupported
		{
			get
			{
				return this != #Uoe.UnsupportedVersion;
			}
		}

		// Token: 0x17002A9E RID: 10910
		// (get) Token: 0x060093BB RID: 37819 RVA: 0x00076349 File Offset: 0x00074549
		public bool IsValid
		{
			get
			{
				return !this.IsNull && this.IsSupported;
			}
		}

		// Token: 0x17002A9F RID: 10911
		// (get) Token: 0x060093BC RID: 37820 RVA: 0x001F7DE4 File Offset: 0x001F5FE4
		public bool HasAnyObjects
		{
			get
			{
				return (this.Solids != null && this.Solids.Any<SectionPolygon>()) || (this.Openings != null && this.Openings.Any<SectionPolygon>()) || (this.ReinforcementBars != null && this.ReinforcementBars.Any<ReinforcementBar>());
			}
		}

		// Token: 0x17002AA0 RID: 10912
		// (get) Token: 0x060093BD RID: 37821 RVA: 0x0007635B File Offset: 0x0007455B
		// (set) Token: 0x060093BE RID: 37822 RVA: 0x00076363 File Offset: 0x00074563
		public bool Warnings { get; set; }

		// Token: 0x17002AA1 RID: 10913
		// (get) Token: 0x060093BF RID: 37823 RVA: 0x0007636C File Offset: 0x0007456C
		// (set) Token: 0x060093C0 RID: 37824 RVA: 0x00076374 File Offset: 0x00074574
		public LengthUnit LengthUnit { get; set; }

		// Token: 0x17002AA2 RID: 10914
		// (get) Token: 0x060093C1 RID: 37825 RVA: 0x0007637D File Offset: 0x0007457D
		// (set) Token: 0x060093C2 RID: 37826 RVA: 0x00076385 File Offset: 0x00074585
		public UnitSystem UnitSystem { get; set; }

		// Token: 0x17002AA3 RID: 10915
		// (get) Token: 0x060093C3 RID: 37827 RVA: 0x0007638E File Offset: 0x0007458E
		// (set) Token: 0x060093C4 RID: 37828 RVA: 0x00076396 File Offset: 0x00074596
		public bool IsUnitless { get; set; }

		// Token: 0x17002AA4 RID: 10916
		// (get) Token: 0x060093C5 RID: 37829 RVA: 0x0007639F File Offset: 0x0007459F
		public List<SectionPolygon> Solids { get; }

		// Token: 0x17002AA5 RID: 10917
		// (get) Token: 0x060093C6 RID: 37830 RVA: 0x000763A7 File Offset: 0x000745A7
		public List<SectionPolygon> Openings { get; }

		// Token: 0x17002AA6 RID: 10918
		// (get) Token: 0x060093C7 RID: 37831 RVA: 0x000763AF File Offset: 0x000745AF
		public List<ReinforcementBar> ReinforcementBars { get; }

		// Token: 0x17002AA7 RID: 10919
		// (get) Token: 0x060093C8 RID: 37832 RVA: 0x000763B7 File Offset: 0x000745B7
		// (set) Token: 0x060093C9 RID: 37833 RVA: 0x000763BF File Offset: 0x000745BF
		public List<string> LayerNames { get; set; }

		// Token: 0x17002AA8 RID: 10920
		// (get) Token: 0x060093CA RID: 37834 RVA: 0x000763C8 File Offset: 0x000745C8
		// (set) Token: 0x060093CB RID: 37835 RVA: 0x000763D0 File Offset: 0x000745D0
		public bool NotClosedSolidsFound { get; set; }

		// Token: 0x17002AA9 RID: 10921
		// (get) Token: 0x060093CC RID: 37836 RVA: 0x000763D9 File Offset: 0x000745D9
		// (set) Token: 0x060093CD RID: 37837 RVA: 0x000763E1 File Offset: 0x000745E1
		public bool TooBigSolidsFound { get; set; }

		// Token: 0x17002AAA RID: 10922
		// (get) Token: 0x060093CE RID: 37838 RVA: 0x000763EA File Offset: 0x000745EA
		// (set) Token: 0x060093CF RID: 37839 RVA: 0x000763F2 File Offset: 0x000745F2
		public bool NotClosedOpeningsFound { get; set; }

		// Token: 0x17002AAB RID: 10923
		// (get) Token: 0x060093D0 RID: 37840 RVA: 0x000763FB File Offset: 0x000745FB
		// (set) Token: 0x060093D1 RID: 37841 RVA: 0x00076403 File Offset: 0x00074603
		public bool ToBigOpeningsFound { get; set; }

		// Token: 0x17002AAC RID: 10924
		// (get) Token: 0x060093D2 RID: 37842 RVA: 0x0007640C File Offset: 0x0007460C
		// (set) Token: 0x060093D3 RID: 37843 RVA: 0x00076414 File Offset: 0x00074614
		public bool TooManyBarsFound { get; set; }

		// Token: 0x04003EF6 RID: 16118
		[CompilerGenerated]
		private static readonly #Uoe #a;

		// Token: 0x04003EF7 RID: 16119
		[CompilerGenerated]
		private static readonly #Uoe #b;

		// Token: 0x04003EF8 RID: 16120
		[CompilerGenerated]
		private bool #c;

		// Token: 0x04003EF9 RID: 16121
		[CompilerGenerated]
		private LengthUnit #d;

		// Token: 0x04003EFA RID: 16122
		[CompilerGenerated]
		private UnitSystem #e;

		// Token: 0x04003EFB RID: 16123
		[CompilerGenerated]
		private bool #f;

		// Token: 0x04003EFC RID: 16124
		[CompilerGenerated]
		private readonly List<SectionPolygon> #g;

		// Token: 0x04003EFD RID: 16125
		[CompilerGenerated]
		private readonly List<SectionPolygon> #h;

		// Token: 0x04003EFE RID: 16126
		[CompilerGenerated]
		private readonly List<ReinforcementBar> #i;

		// Token: 0x04003EFF RID: 16127
		[CompilerGenerated]
		private List<string> #j;

		// Token: 0x04003F00 RID: 16128
		[CompilerGenerated]
		private bool #k;

		// Token: 0x04003F01 RID: 16129
		[CompilerGenerated]
		private bool #l;

		// Token: 0x04003F02 RID: 16130
		[CompilerGenerated]
		private bool #m;

		// Token: 0x04003F03 RID: 16131
		[CompilerGenerated]
		private bool #n;

		// Token: 0x04003F04 RID: 16132
		[CompilerGenerated]
		private bool #o;
	}
}
