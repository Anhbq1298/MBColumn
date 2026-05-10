using System;
using System.Runtime.CompilerServices;
using #7hc;
using #7Pb;
using #eU;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #bnb
{
	// Token: 0x02000446 RID: 1094
	internal sealed class #anb : #rnb
	{
		// Token: 0x06002826 RID: 10278 RVA: 0x000DA7A4 File Offset: 0x000D89A4
		public #anb(#oW #xn) : base(#xn, string.Format(#Phc.#3hc(107359969), 150, 150, 150))
		{
			base.Values.#pR(new #nQb[]
			{
				#nQb.Separator,
				this.MomentX,
				this.MomentY,
				this.Force
			});
			base.#fQb();
		}

		// Token: 0x17000D6D RID: 3437
		// (get) Token: 0x06002827 RID: 10279 RVA: 0x00025122 File Offset: 0x00023322
		public #nQb MomentX { get; }

		// Token: 0x17000D6E RID: 3438
		// (get) Token: 0x06002828 RID: 10280 RVA: 0x0002512E File Offset: 0x0002332E
		public #nQb MomentY { get; }

		// Token: 0x17000D6F RID: 3439
		// (get) Token: 0x06002829 RID: 10281 RVA: 0x0002513A File Offset: 0x0002333A
		public #nQb Force { get; }

		// Token: 0x0600282A RID: 10282 RVA: 0x000DA840 File Offset: 0x000D8A40
		public void #8mb(Point3D #9mb)
		{
			string #qnb = base.Project.Model.Units.Loads.ServiceLoadMxBot.Symbol;
			this.MomentX.Value = base.#onb(base.MomentFormatter, Strings.StringMx, new double?(#9mb.X), #qnb);
			this.MomentY.Value = base.#onb(base.MomentFormatter, Strings.StringMy, new double?(#9mb.Y), #qnb);
			#qnb = base.Project.Model.Units.Loads.AxialLoadFinal.Symbol;
			this.Force.Value = base.#onb(base.ForceFormatter, Strings.StringPz, new double?(#9mb.Z), #qnb);
		}

		// Token: 0x04000FD5 RID: 4053
		[CompilerGenerated]
		private new readonly #nQb #a = new #nQb();

		// Token: 0x04000FD6 RID: 4054
		[CompilerGenerated]
		private readonly #nQb #b = new #nQb();

		// Token: 0x04000FD7 RID: 4055
		[CompilerGenerated]
		private readonly #nQb #c = new #nQb();
	}
}
