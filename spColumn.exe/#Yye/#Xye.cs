using System;
using #owe;

namespace #Yye
{
	// Token: 0x020011C0 RID: 4544
	internal sealed class #Xye : #nwe
	{
		// Token: 0x0600996B RID: 39275 RVA: 0x00079E04 File Offset: 0x00078004
		public #Xye(#pwe #ib) : base(#ib)
		{
		}

		// Token: 0x0600996C RID: 39276 RVA: 0x00079E0D File Offset: 0x0007800D
		public override void #pEd()
		{
			if (base.Options.Cover.#ISd())
			{
				base.Renderer.#bdd();
			}
			if (base.Options.TableOfContents.#ISd())
			{
				base.Renderer.#9cd(true);
			}
		}
	}
}
