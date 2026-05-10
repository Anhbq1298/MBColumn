using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #5Fd;
using #7hc;
using #FCd;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;

namespace #Ded
{
	// Token: 0x02000D19 RID: 3353
	internal sealed class #Red
	{
		// Token: 0x06006E67 RID: 28263 RVA: 0x00058E4E File Offset: 0x0005704E
		public #Red(#JGd #Ae, #uDd #Xpb, Func<IEnumerable<string>> #xed)
		{
			this.#d = #Ae;
			this.#f = #Xpb;
			this.#a = #xed;
		}

		// Token: 0x06006E68 RID: 28264 RVA: 0x00058E6B File Offset: 0x0005706B
		public #Red(#JGd #Ae, #uDd #Xpb, IEnumerable<string> #wed = null)
		{
			this.#d = #Ae;
			this.#f = #Xpb;
			this.#b = #wed;
		}

		// Token: 0x06006E69 RID: 28265 RVA: 0x00058E88 File Offset: 0x00057088
		public #Red(#JGd #Ae, IEnumerable<string> #wed)
		{
			this.#d = #Ae;
			if (#wed == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107253750));
			}
			this.#b = #wed;
			this.#c = true;
		}

		// Token: 0x17001EFD RID: 7933
		// (get) Token: 0x06006E6A RID: 28266 RVA: 0x00058EB9 File Offset: 0x000570B9
		public bool IsNoteOnly { get; }

		// Token: 0x17001EFE RID: 7934
		// (get) Token: 0x06006E6B RID: 28267 RVA: 0x00058EC5 File Offset: 0x000570C5
		public #JGd Header { get; }

		// Token: 0x17001EFF RID: 7935
		// (get) Token: 0x06006E6C RID: 28268 RVA: 0x00058ED1 File Offset: 0x000570D1
		// (set) Token: 0x06006E6D RID: 28269 RVA: 0x00058EDD File Offset: 0x000570DD
		public Option Option { get; set; }

		// Token: 0x17001F00 RID: 7936
		// (get) Token: 0x06006E6E RID: 28270 RVA: 0x00058EEE File Offset: 0x000570EE
		public #uDd Table { get; }

		// Token: 0x17001F01 RID: 7937
		// (get) Token: 0x06006E6F RID: 28271 RVA: 0x00058EFA File Offset: 0x000570FA
		public IEnumerable<string> Notes
		{
			get
			{
				if (this.#b != null)
				{
					return this.#b;
				}
				Func<IEnumerable<string>> func = this.#a;
				if (func == null)
				{
					return null;
				}
				return func();
			}
		}

		// Token: 0x04002C63 RID: 11363
		private readonly Func<IEnumerable<string>> #a;

		// Token: 0x04002C64 RID: 11364
		private readonly IEnumerable<string> #b;

		// Token: 0x04002C65 RID: 11365
		[CompilerGenerated]
		private readonly bool #c;

		// Token: 0x04002C66 RID: 11366
		[CompilerGenerated]
		private readonly #JGd #d;

		// Token: 0x04002C67 RID: 11367
		[CompilerGenerated]
		private Option #e;

		// Token: 0x04002C68 RID: 11368
		[CompilerGenerated]
		private readonly #uDd #f;
	}
}
