using System;
using System.Runtime.CompilerServices;
using #12e;
using #7hc;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output
{
	// Token: 0x0200134A RID: 4938
	public sealed class BiaxialServiceLoad : #u3e
	{
		// Token: 0x0600A548 RID: 42312 RVA: 0x00230608 File Offset: 0x0022E808
		public BiaxialServiceLoad(int? index, int? serviceLoadIndex, int? loadCombinationIndex, float? appLoad, float? factLoad2, float? factLoad3, float? ultimateMomentX, float? ultimateMomentY, float? usf, float? nadepth, float? dt, float? eps, float? phi, #u3e.#zif? success, #u3e.#yif? error) : base(index, appLoad, usf, nadepth, dt, eps, phi, success)
		{
			this.ServiceLoadIndex = serviceLoadIndex;
			this.LoadCombinationIndex = loadCombinationIndex;
			this.FactLoad2 = factLoad2;
			this.FactLoad3 = factLoad3;
			this.UltimateMomentX = ultimateMomentX;
			this.UltimateMomentY = ultimateMomentY;
			this.Error = error;
		}

		// Token: 0x0600A549 RID: 42313 RVA: 0x00230660 File Offset: 0x0022E860
		public BiaxialServiceLoad(int? index, float? ultimateMomentX, float? ultimateMomentY, float? nadepth, float? dt, float? eps, float? phi) : base(index, null, null, nadepth, dt, eps, phi, new #u3e.#zif?(#u3e.#zif.#a))
		{
			this.UltimateMomentX = ultimateMomentX;
			this.UltimateMomentY = ultimateMomentY;
		}

		// Token: 0x17002F9A RID: 12186
		// (get) Token: 0x0600A54A RID: 42314 RVA: 0x00080F56 File Offset: 0x0007F156
		public int? ServiceLoadIndex { get; }

		// Token: 0x17002F9B RID: 12187
		// (get) Token: 0x0600A54B RID: 42315 RVA: 0x00080F5E File Offset: 0x0007F15E
		public int? LoadCombinationIndex { get; }

		// Token: 0x17002F9C RID: 12188
		// (get) Token: 0x0600A54C RID: 42316 RVA: 0x00080F66 File Offset: 0x0007F166
		public float? FactLoad2 { get; }

		// Token: 0x17002F9D RID: 12189
		// (get) Token: 0x0600A54D RID: 42317 RVA: 0x00080F6E File Offset: 0x0007F16E
		public float? FactLoad3 { get; }

		// Token: 0x17002F9E RID: 12190
		// (get) Token: 0x0600A54E RID: 42318 RVA: 0x00080F76 File Offset: 0x0007F176
		public float? UltimateMomentX { get; }

		// Token: 0x17002F9F RID: 12191
		// (get) Token: 0x0600A54F RID: 42319 RVA: 0x00080F7E File Offset: 0x0007F17E
		public float? UltimateMomentY { get; }

		// Token: 0x17002FA0 RID: 12192
		// (get) Token: 0x0600A550 RID: 42320 RVA: 0x00080F86 File Offset: 0x0007F186
		public #u3e.#yif? Error { get; }

		// Token: 0x0600A551 RID: 42321 RVA: 0x002306A4 File Offset: 0x0022E8A4
		public override string #62e()
		{
			if (this.Error != null)
			{
				if (this.Error.Value.HasFlag(#u3e.#yif.#b))
				{
					return #Phc.#3hc(107311920);
				}
				if (this.Error.Value.HasFlag(#u3e.#yif.#c))
				{
					return #Phc.#3hc(107311633);
				}
				if (this.Error.Value.HasFlag(#u3e.#yif.#d))
				{
					return #Phc.#3hc(107311335);
				}
				if (this.Error.Value.HasFlag(#u3e.#yif.#e))
				{
					return #Phc.#3hc(107312055);
				}
				if (this.Error.Value.HasFlag(#u3e.#yif.#f))
				{
					return #Phc.#3hc(107311326);
				}
				if (this.Error.Value.HasFlag(#u3e.#yif.#g))
				{
					return #Phc.#3hc(107311965);
				}
			}
			return null;
		}

		// Token: 0x0400488E RID: 18574
		[CompilerGenerated]
		private readonly int? #a;

		// Token: 0x0400488F RID: 18575
		[CompilerGenerated]
		private readonly int? #b;

		// Token: 0x04004890 RID: 18576
		[CompilerGenerated]
		private readonly float? #c;

		// Token: 0x04004891 RID: 18577
		[CompilerGenerated]
		private readonly float? #d;

		// Token: 0x04004892 RID: 18578
		[CompilerGenerated]
		private readonly float? #e;

		// Token: 0x04004893 RID: 18579
		[CompilerGenerated]
		private readonly float? #f;

		// Token: 0x04004894 RID: 18580
		[CompilerGenerated]
		private readonly #u3e.#yif? #g;
	}
}
