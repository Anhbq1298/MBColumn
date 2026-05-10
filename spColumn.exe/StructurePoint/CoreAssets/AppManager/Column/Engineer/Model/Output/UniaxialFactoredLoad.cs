using System;
using System.Runtime.CompilerServices;
using #12e;
using #7hc;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output
{
	// Token: 0x0200135B RID: 4955
	public sealed class UniaxialFactoredLoad : #u3e
	{
		// Token: 0x0600A5DF RID: 42463 RVA: 0x00230E48 File Offset: 0x0022F048
		public UniaxialFactoredLoad(int? index, float? appLoad, float? appMoment, float? ultimateMoment, float? usf, float? nadepth, float? dt, float? eps, float? phi, #u3e.#zif? success, #u3e.#Aif? error) : base(index, appLoad, usf, nadepth, dt, eps, phi, success)
		{
			this.AppMoment = appMoment;
			this.UltimateMoment = ultimateMoment;
			this.Error = error;
		}

		// Token: 0x0600A5E0 RID: 42464 RVA: 0x00230E80 File Offset: 0x0022F080
		public UniaxialFactoredLoad(float? ultimateMoment, float? nadepth, float? dt, float? eps, float? phi) : base(null, null, null, nadepth, dt, eps, phi, null)
		{
			this.AppMoment = null;
			this.UltimateMoment = ultimateMoment;
			this.Error = null;
		}

		// Token: 0x0600A5E1 RID: 42465 RVA: 0x00230EE4 File Offset: 0x0022F0E4
		public UniaxialFactoredLoad(int? index, float? appLoad, float? appMoment, #u3e.#zif? success, #u3e.#Aif? error) : base(index, appLoad, null, null, null, null, null, success)
		{
			this.AppMoment = appMoment;
			this.UltimateMoment = null;
			this.Error = error;
		}

		// Token: 0x17002FEE RID: 12270
		// (get) Token: 0x0600A5E2 RID: 42466 RVA: 0x000814C1 File Offset: 0x0007F6C1
		// (set) Token: 0x0600A5E3 RID: 42467 RVA: 0x000814C9 File Offset: 0x0007F6C9
		public float? AppMoment { get; private set; }

		// Token: 0x17002FEF RID: 12271
		// (get) Token: 0x0600A5E4 RID: 42468 RVA: 0x000814D2 File Offset: 0x0007F6D2
		// (set) Token: 0x0600A5E5 RID: 42469 RVA: 0x000814DA File Offset: 0x0007F6DA
		public float? UltimateMoment { get; private set; }

		// Token: 0x17002FF0 RID: 12272
		// (get) Token: 0x0600A5E6 RID: 42470 RVA: 0x000814E3 File Offset: 0x0007F6E3
		// (set) Token: 0x0600A5E7 RID: 42471 RVA: 0x000814EB File Offset: 0x0007F6EB
		public #u3e.#Aif? Error { get; set; }

		// Token: 0x0600A5E8 RID: 42472 RVA: 0x00230F48 File Offset: 0x0022F148
		public override string #62e()
		{
			if (this.Error != null)
			{
				if (this.Error.Value.HasFlag(#u3e.#Aif.#b))
				{
					return #Phc.#3hc(107311180);
				}
				if (this.Error.Value.HasFlag(#u3e.#Aif.#c))
				{
					return #Phc.#3hc(107311151);
				}
				if (this.Error.Value.HasFlag(#u3e.#Aif.#d))
				{
					return #Phc.#3hc(107311154);
				}
				if (this.Error.Value.HasFlag(#u3e.#Aif.#e))
				{
					return #Phc.#3hc(107311125);
				}
			}
			return null;
		}

		// Token: 0x040048FC RID: 18684
		[CompilerGenerated]
		private float? #a;

		// Token: 0x040048FD RID: 18685
		[CompilerGenerated]
		private float? #b;

		// Token: 0x040048FE RID: 18686
		[CompilerGenerated]
		private #u3e.#Aif? #c;
	}
}
