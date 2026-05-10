using System;
using System.Runtime.CompilerServices;
using #12e;
using #7hc;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output
{
	// Token: 0x02001344 RID: 4932
	public sealed class BiaxialFactoredLoad : #u3e
	{
		// Token: 0x0600A527 RID: 42279 RVA: 0x002302F0 File Offset: 0x0022E4F0
		public BiaxialFactoredLoad(int? index, float? appLoad, float? factLoad1, float? factLoad2, float? ultimateMomentX, float? ultimateMomentY, float? usf, float? naDepth, float? dt, float? eps, float? phi, #u3e.#zif? success, #u3e.#yif? error) : base(index, appLoad, usf, naDepth, dt, eps, phi, success)
		{
			this.FactLoad1 = factLoad1;
			this.FactLoad2 = factLoad2;
			this.UltimateMomentX = ultimateMomentX;
			this.UltimateMomentY = ultimateMomentY;
			this.Error = error;
		}

		// Token: 0x0600A528 RID: 42280 RVA: 0x00230338 File Offset: 0x0022E538
		public BiaxialFactoredLoad(float? ultimateMomentX, float? ultimateMomentY, float? naDepth, float? dt, float? eps, float? phi) : base(null, null, null, naDepth, dt, eps, phi, null)
		{
			this.FactLoad1 = null;
			this.FactLoad2 = null;
			this.UltimateMomentX = ultimateMomentX;
			this.UltimateMomentY = ultimateMomentY;
			this.Error = null;
		}

		// Token: 0x0600A529 RID: 42281 RVA: 0x002303A8 File Offset: 0x0022E5A8
		public BiaxialFactoredLoad(int? index, float? appLoad, float? factLoad1, float? factLoad2, #u3e.#zif? success, #u3e.#yif? error) : base(index, appLoad, null, null, null, null, null, success)
		{
			this.FactLoad1 = factLoad1;
			this.FactLoad2 = factLoad2;
			this.UltimateMomentX = null;
			this.UltimateMomentY = null;
			this.Error = error;
		}

		// Token: 0x17002F8A RID: 12170
		// (get) Token: 0x0600A52A RID: 42282 RVA: 0x00080E7C File Offset: 0x0007F07C
		public float? FactLoad1 { get; }

		// Token: 0x17002F8B RID: 12171
		// (get) Token: 0x0600A52B RID: 42283 RVA: 0x00080E84 File Offset: 0x0007F084
		public float? FactLoad2 { get; }

		// Token: 0x17002F8C RID: 12172
		// (get) Token: 0x0600A52C RID: 42284 RVA: 0x00080E8C File Offset: 0x0007F08C
		public float? UltimateMomentX { get; }

		// Token: 0x17002F8D RID: 12173
		// (get) Token: 0x0600A52D RID: 42285 RVA: 0x00080E94 File Offset: 0x0007F094
		public float? UltimateMomentY { get; }

		// Token: 0x17002F8E RID: 12174
		// (get) Token: 0x0600A52E RID: 42286 RVA: 0x00080E9C File Offset: 0x0007F09C
		public #u3e.#yif? Error { get; }

		// Token: 0x0600A52F RID: 42287 RVA: 0x0023041C File Offset: 0x0022E61C
		public override string #62e()
		{
			if (this.Error != null)
			{
				if (this.Error.Value.HasFlag(#u3e.#yif.#b))
				{
					return #Phc.#3hc(107311678);
				}
				if (this.Error.Value.HasFlag(#u3e.#yif.#c))
				{
					return #Phc.#3hc(107311633);
				}
				if (this.Error.Value.HasFlag(#u3e.#yif.#d))
				{
					return #Phc.#3hc(107312068);
				}
				if (this.Error.Value.HasFlag(#u3e.#yif.#e))
				{
					return #Phc.#3hc(107312055);
				}
				if (this.Error.Value.HasFlag(#u3e.#yif.#f))
				{
					return #Phc.#3hc(107311978);
				}
				if (this.Error.Value.HasFlag(#u3e.#yif.#g))
				{
					return #Phc.#3hc(107311965);
				}
			}
			return null;
		}

		// Token: 0x04004869 RID: 18537
		[CompilerGenerated]
		private readonly float? #a;

		// Token: 0x0400486A RID: 18538
		[CompilerGenerated]
		private readonly float? #b;

		// Token: 0x0400486B RID: 18539
		[CompilerGenerated]
		private readonly float? #c;

		// Token: 0x0400486C RID: 18540
		[CompilerGenerated]
		private readonly float? #d;

		// Token: 0x0400486D RID: 18541
		[CompilerGenerated]
		private readonly #u3e.#yif? #e;
	}
}
