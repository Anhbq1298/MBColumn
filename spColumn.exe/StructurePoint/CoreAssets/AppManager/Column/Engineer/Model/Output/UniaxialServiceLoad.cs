using System;
using System.Runtime.CompilerServices;
using #12e;
using #7hc;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output
{
	// Token: 0x0200135C RID: 4956
	public sealed class UniaxialServiceLoad : #u3e
	{
		// Token: 0x0600A5E9 RID: 42473 RVA: 0x00231018 File Offset: 0x0022F218
		public UniaxialServiceLoad(int? index, int? serviceLoadIndex, int? loadCombinationIndex, float? appLoad, float? appMoment, float? ultimateMoment, float? usf, float? nadepth, float? dt, float? eps, float? phi, #u3e.#zif? success, #u3e.#Aif? error) : base(index, appLoad, usf, nadepth, dt, eps, phi, success)
		{
			this.ServiceLoadIndex = serviceLoadIndex;
			this.LoadCombinationIndex = loadCombinationIndex;
			this.AppMoment = appMoment;
			this.UltimateMoment = ultimateMoment;
			this.Error = error;
		}

		// Token: 0x17002FF1 RID: 12273
		// (get) Token: 0x0600A5EA RID: 42474 RVA: 0x000814F4 File Offset: 0x0007F6F4
		public int? ServiceLoadIndex { get; }

		// Token: 0x17002FF2 RID: 12274
		// (get) Token: 0x0600A5EB RID: 42475 RVA: 0x000814FC File Offset: 0x0007F6FC
		public int? LoadCombinationIndex { get; }

		// Token: 0x17002FF3 RID: 12275
		// (get) Token: 0x0600A5EC RID: 42476 RVA: 0x00081504 File Offset: 0x0007F704
		public float? AppMoment { get; }

		// Token: 0x17002FF4 RID: 12276
		// (get) Token: 0x0600A5ED RID: 42477 RVA: 0x0008150C File Offset: 0x0007F70C
		public float? UltimateMoment { get; }

		// Token: 0x17002FF5 RID: 12277
		// (get) Token: 0x0600A5EE RID: 42478 RVA: 0x00081514 File Offset: 0x0007F714
		public #u3e.#Aif? Error { get; }

		// Token: 0x0600A5EF RID: 42479 RVA: 0x00231060 File Offset: 0x0022F260
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

		// Token: 0x040048FF RID: 18687
		[CompilerGenerated]
		private readonly int? #a;

		// Token: 0x04004900 RID: 18688
		[CompilerGenerated]
		private readonly int? #b;

		// Token: 0x04004901 RID: 18689
		[CompilerGenerated]
		private readonly float? #c;

		// Token: 0x04004902 RID: 18690
		[CompilerGenerated]
		private readonly float? #d;

		// Token: 0x04004903 RID: 18691
		[CompilerGenerated]
		private readonly #u3e.#Aif? #e;
	}
}
