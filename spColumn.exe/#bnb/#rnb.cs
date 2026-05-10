using System;
using System.Runtime.CompilerServices;
using System.Windows;
using #7hc;
using #7Pb;
using #eU;
using StructurePoint.CoreAssets.Units.Formatters;

namespace #bnb
{
	// Token: 0x02000447 RID: 1095
	internal abstract class #rnb : #gQb
	{
		// Token: 0x0600282B RID: 10283 RVA: 0x000DA928 File Offset: 0x000D8B28
		protected #rnb(#oW #xn, string #snb) : base(#snb, Visibility.Visible)
		{
			this.#b = #xn;
		}

		// Token: 0x17000D70 RID: 3440
		// (get) Token: 0x0600282C RID: 10284 RVA: 0x00025146 File Offset: 0x00023346
		public #oW Project { get; }

		// Token: 0x17000D71 RID: 3441
		// (get) Token: 0x0600282D RID: 10285 RVA: 0x00025152 File Offset: 0x00023352
		public IUnitValueFormatter DimensionFormatter { get; }

		// Token: 0x17000D72 RID: 3442
		// (get) Token: 0x0600282E RID: 10286 RVA: 0x0002515E File Offset: 0x0002335E
		public IUnitValueFormatter EccentricyFormatter { get; }

		// Token: 0x17000D73 RID: 3443
		// (get) Token: 0x0600282F RID: 10287 RVA: 0x0002516A File Offset: 0x0002336A
		public IUnitValueFormatter MomentFormatter { get; }

		// Token: 0x17000D74 RID: 3444
		// (get) Token: 0x06002830 RID: 10288 RVA: 0x00025176 File Offset: 0x00023376
		public IUnitValueFormatter ForceFormatter { get; }

		// Token: 0x06002831 RID: 10289 RVA: 0x000DA974 File Offset: 0x000D8B74
		protected string #onb(IUnitValueFormatter #pnb, string #wy, double? #f, string #qnb)
		{
			if (#f == null)
			{
				return string.Empty;
			}
			return string.Concat(new string[]
			{
				#wy,
				#Phc.#3hc(107359847),
				#pnb.CreateDisplayValue(#f.Value),
				#Phc.#3hc(107399922),
				#qnb
			});
		}

		// Token: 0x04000FD8 RID: 4056
		protected const int #a = 150;

		// Token: 0x04000FD9 RID: 4057
		[CompilerGenerated]
		private readonly #oW #b;

		// Token: 0x04000FDA RID: 4058
		[CompilerGenerated]
		private readonly IUnitValueFormatter #c = new FloatingPointUnitValueFormatter(2);

		// Token: 0x04000FDB RID: 4059
		[CompilerGenerated]
		private readonly IUnitValueFormatter #d = new FloatingPointUnitValueFormatter(2);

		// Token: 0x04000FDC RID: 4060
		[CompilerGenerated]
		private readonly IUnitValueFormatter #e = new FloatingPointUnitValueFormatter(2);

		// Token: 0x04000FDD RID: 4061
		[CompilerGenerated]
		private readonly IUnitValueFormatter #f = new FloatingPointUnitValueFormatter(2);
	}
}
