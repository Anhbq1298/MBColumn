using System;
using System.Runtime.CompilerServices;
using #6re;
using #8Cc;
using #bCc;
using #coe;
using #eU;
using #ezc;
using #hg;
using #IDc;
using #LQc;
using #oKe;
using #qPb;
using #RJb;
using #sUd;
using #v1c;
using #Xc;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.Services.API;

namespace #qJ
{
	// Token: 0x020002AB RID: 683
	internal sealed class #aL : #AL, ICoreServices, IExtendedServices
	{
		// Token: 0x0600166A RID: 5738 RVA: 0x000B4C4C File Offset: 0x000B2E4C
		public #aL(#bDc #DJ, #v2c #4x, #8Sc #ls, ILogger #3x, #oW #xn, #9V #RA, ISettingsManager #ng, #0V #bL, #zU #cL, #wU #hB, #nKe #JF, #xAc #Aq, #rBc #dL, #UV #ms, #iW #ss, #5Ic #eL, #Ioe #fL, #yse #tA, #tUd #5x, #R2c #gL, #Gd #hL, #jg #iL, #ud #lj, #dLb #Zc, #dU #5c, #aCc #jL, #AWh #eTh) : base(#DJ, #4x, #ls, #3x, #xn, #RA, #ng, #bL, #cL, #hB, #JF, #Aq, #dL, #ms, #ss, #eL, #fL, #tA, #5x, #gL, #5c, #jL)
		{
			this.#a = #hL;
			this.#b = #iL;
			this.#c = #lj;
			this.#d = #Zc;
			this.#e = #eTh;
		}

		// Token: 0x17000803 RID: 2051
		// (get) Token: 0x0600166B RID: 5739 RVA: 0x000171BA File Offset: 0x000153BA
		public #Gd Renderer { get; }

		// Token: 0x17000804 RID: 2052
		// (get) Token: 0x0600166C RID: 5740 RVA: 0x000171C6 File Offset: 0x000153C6
		public #jg ViewportsManager { get; }

		// Token: 0x17000805 RID: 2053
		// (get) Token: 0x0600166D RID: 5741 RVA: 0x000171D2 File Offset: 0x000153D2
		public #ud DiagramsViewportsManager { get; }

		// Token: 0x17000806 RID: 2054
		// (get) Token: 0x0600166E RID: 5742 RVA: 0x000171DE File Offset: 0x000153DE
		public #dLb EditorContextMenu { get; }

		// Token: 0x17000807 RID: 2055
		// (get) Token: 0x0600166F RID: 5743 RVA: 0x000171EA File Offset: 0x000153EA
		public #AWh LeftPanelErrorsChecker { get; }

		// Token: 0x040008FD RID: 2301
		[CompilerGenerated]
		private readonly #Gd #a;

		// Token: 0x040008FE RID: 2302
		[CompilerGenerated]
		private readonly #jg #b;

		// Token: 0x040008FF RID: 2303
		[CompilerGenerated]
		private readonly #ud #c;

		// Token: 0x04000900 RID: 2304
		[CompilerGenerated]
		private readonly #dLb #d;

		// Token: 0x04000901 RID: 2305
		[CompilerGenerated]
		private readonly #AWh #e;
	}
}
