using System;
using System.Runtime.CompilerServices;
using #6re;
using #7hc;
using #8Cc;
using #bCc;
using #coe;
using #eU;
using #ezc;
using #IDc;
using #LQc;
using #oKe;
using #sUd;
using #v1c;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.Services.API;

namespace #qJ
{
	// Token: 0x020002AC RID: 684
	internal class #AL : NotifyPropertyChangedObjectBase, ICoreServices
	{
		// Token: 0x06001670 RID: 5744 RVA: 0x000B4CB0 File Offset: 0x000B2EB0
		public #AL(#bDc #DJ, #v2c #4x, #8Sc #ls, ILogger #3x, #oW #xn, #9V #RA, ISettingsManager #ng, #0V #bL, #zU #cL, #wU #hB, #nKe #JF, #xAc #Aq, #rBc #dL, #UV #ms, #iW #ss, #5Ic #eL, #Ioe #fL, #yse #tA, #tUd #5x, #R2c #gL, #dU #5c, #aCc #jL)
		{
			if (#DJ == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107404911));
			}
			this.#g = #DJ;
			if (#4x == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107404926));
			}
			this.#f = #4x;
			if (#ls == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107409397));
			}
			this.#h = #ls;
			if (#3x == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107408919));
			}
			this.#i = #3x;
			if (#xn == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107404877));
			}
			this.#j = #xn;
			if (#RA == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107404864));
			}
			this.#k = #RA;
			if (#ng == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107382678));
			}
			this.#l = #ng;
			if (#bL == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107404835));
			}
			this.#m = #bL;
			if (#cL == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107404814));
			}
			this.#n = #cL;
			if (#hB == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107409319));
			}
			this.#o = #hB;
			if (#JF == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107404825));
			}
			this.#p = #JF;
			if (#Aq == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107405288));
			}
			this.#q = #Aq;
			if (#dL == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107405299));
			}
			this.#r = #dL;
			if (#ms == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107405278));
			}
			this.#s = #ms;
			if (#ss == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107405229));
			}
			this.#t = #ss;
			if (#eL == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107405240));
			}
			this.#u = #eL;
			if (#fL == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107405187));
			}
			this.#v = #fL;
			if (#tA == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107409344));
			}
			this.#e = #tA;
			if (#5x == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107409281));
			}
			this.#d = #5x;
			this.#c = #gL;
			this.#a = #5c;
			this.#b = #jL;
		}

		// Token: 0x17000808 RID: 2056
		// (get) Token: 0x06001671 RID: 5745 RVA: 0x000171F6 File Offset: 0x000153F6
		public #dU ToolsContext { get; }

		// Token: 0x17000809 RID: 2057
		// (get) Token: 0x06001672 RID: 5746 RVA: 0x00017202 File Offset: 0x00015402
		public #aCc SystemCommands { get; }

		// Token: 0x1700080A RID: 2058
		// (get) Token: 0x06001673 RID: 5747 RVA: 0x0001720E File Offset: 0x0001540E
		public #R2c MouseAndKeyboard { get; }

		// Token: 0x1700080B RID: 2059
		// (get) Token: 0x06001674 RID: 5748 RVA: 0x0001721A File Offset: 0x0001541A
		public #tUd ExceptionHandler { get; }

		// Token: 0x1700080C RID: 2060
		// (get) Token: 0x06001675 RID: 5749 RVA: 0x00017226 File Offset: 0x00015426
		public #yse ReporterSettings { get; }

		// Token: 0x1700080D RID: 2061
		// (get) Token: 0x06001676 RID: 5750 RVA: 0x00017232 File Offset: 0x00015432
		public #v2c FileSystem { get; }

		// Token: 0x1700080E RID: 2062
		// (get) Token: 0x06001677 RID: 5751 RVA: 0x0001723E File Offset: 0x0001543E
		public #bDc UndoManager { get; }

		// Token: 0x1700080F RID: 2063
		// (get) Token: 0x06001678 RID: 5752 RVA: 0x0001724A File Offset: 0x0001544A
		public #8Sc DialogService { get; }

		// Token: 0x17000810 RID: 2064
		// (get) Token: 0x06001679 RID: 5753 RVA: 0x00017256 File Offset: 0x00015456
		public ILogger Logger { get; }

		// Token: 0x17000811 RID: 2065
		// (get) Token: 0x0600167A RID: 5754 RVA: 0x00017262 File Offset: 0x00015462
		public #oW Project { get; }

		// Token: 0x17000812 RID: 2066
		// (get) Token: 0x0600167B RID: 5755 RVA: 0x0001726E File Offset: 0x0001546E
		public #9V StorageModelConverter { get; }

		// Token: 0x17000813 RID: 2067
		// (get) Token: 0x0600167C RID: 5756 RVA: 0x0001727A File Offset: 0x0001547A
		public ISettingsManager Settings { get; }

		// Token: 0x17000814 RID: 2068
		// (get) Token: 0x0600167D RID: 5757 RVA: 0x00017286 File Offset: 0x00015486
		public #0V SnappingCache { get; }

		// Token: 0x17000815 RID: 2069
		// (get) Token: 0x0600167E RID: 5758 RVA: 0x00017292 File Offset: 0x00015492
		public #zU GuiController { get; }

		// Token: 0x17000816 RID: 2070
		// (get) Token: 0x0600167F RID: 5759 RVA: 0x0001729E File Offset: 0x0001549E
		public #wU Commands { get; }

		// Token: 0x17000817 RID: 2071
		// (get) Token: 0x06001680 RID: 5760 RVA: 0x000172AA File Offset: 0x000154AA
		public #nKe Localization { get; }

		// Token: 0x17000818 RID: 2072
		// (get) Token: 0x06001681 RID: 5761 RVA: 0x000172B6 File Offset: 0x000154B6
		public #xAc ApplicationInfo { get; }

		// Token: 0x17000819 RID: 2073
		// (get) Token: 0x06001682 RID: 5762 RVA: 0x000172C2 File Offset: 0x000154C2
		public #rBc ErrorsHandler { get; }

		// Token: 0x1700081A RID: 2074
		// (get) Token: 0x06001683 RID: 5763 RVA: 0x000172CE File Offset: 0x000154CE
		public #UV MessageBus { get; }

		// Token: 0x1700081B RID: 2075
		// (get) Token: 0x06001684 RID: 5764 RVA: 0x000172DA File Offset: 0x000154DA
		public #iW WindowLocator { get; }

		// Token: 0x1700081C RID: 2076
		// (get) Token: 0x06001685 RID: 5765 RVA: 0x000172E6 File Offset: 0x000154E6
		public #5Ic Notifications { get; }

		// Token: 0x1700081D RID: 2077
		// (get) Token: 0x06001686 RID: 5766 RVA: 0x000172F2 File Offset: 0x000154F2
		public #Ioe Storage { get; }

		// Token: 0x04000902 RID: 2306
		[CompilerGenerated]
		private readonly #dU #a;

		// Token: 0x04000903 RID: 2307
		[CompilerGenerated]
		private readonly #aCc #b;

		// Token: 0x04000904 RID: 2308
		[CompilerGenerated]
		private readonly #R2c #c;

		// Token: 0x04000905 RID: 2309
		[CompilerGenerated]
		private readonly #tUd #d;

		// Token: 0x04000906 RID: 2310
		[CompilerGenerated]
		private readonly #yse #e;

		// Token: 0x04000907 RID: 2311
		[CompilerGenerated]
		private readonly #v2c #f;

		// Token: 0x04000908 RID: 2312
		[CompilerGenerated]
		private readonly #bDc #g;

		// Token: 0x04000909 RID: 2313
		[CompilerGenerated]
		private readonly #8Sc #h;

		// Token: 0x0400090A RID: 2314
		[CompilerGenerated]
		private readonly ILogger #i;

		// Token: 0x0400090B RID: 2315
		[CompilerGenerated]
		private readonly #oW #j;

		// Token: 0x0400090C RID: 2316
		[CompilerGenerated]
		private readonly #9V #k;

		// Token: 0x0400090D RID: 2317
		[CompilerGenerated]
		private readonly ISettingsManager #l;

		// Token: 0x0400090E RID: 2318
		[CompilerGenerated]
		private readonly #0V #m;

		// Token: 0x0400090F RID: 2319
		[CompilerGenerated]
		private readonly #zU #n;

		// Token: 0x04000910 RID: 2320
		[CompilerGenerated]
		private readonly #wU #o;

		// Token: 0x04000911 RID: 2321
		[CompilerGenerated]
		private readonly #nKe #p;

		// Token: 0x04000912 RID: 2322
		[CompilerGenerated]
		private readonly #xAc #q;

		// Token: 0x04000913 RID: 2323
		[CompilerGenerated]
		private readonly #rBc #r;

		// Token: 0x04000914 RID: 2324
		[CompilerGenerated]
		private readonly #UV #s;

		// Token: 0x04000915 RID: 2325
		[CompilerGenerated]
		private readonly #iW #t;

		// Token: 0x04000916 RID: 2326
		[CompilerGenerated]
		private readonly #5Ic #u;

		// Token: 0x04000917 RID: 2327
		[CompilerGenerated]
		private readonly #Ioe #v;
	}
}
