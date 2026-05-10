using System;
using System.Runtime.CompilerServices;
using System.Windows;
using #ede;
using #eU;
using #LFb;
using #LQc;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #aAb
{
	// Token: 0x02000511 RID: 1297
	internal sealed class #xAb : #1Fb
	{
		// Token: 0x06002F10 RID: 12048 RVA: 0x0002A19A File Offset: 0x0002839A
		public #xAb(#oW #Yc, #iW #ss, #8Sc #ls)
		{
			this.#a = #Yc;
			this.#d = new #dde();
			this.#b = #ss;
			this.#c = #ls;
		}

		// Token: 0x17000F7B RID: 3963
		// (get) Token: 0x06002F11 RID: 12049 RVA: 0x0002A1C2 File Offset: 0x000283C2
		public #dde Limits { get; }

		// Token: 0x06002F12 RID: 12050 RVA: 0x000F30D4 File Offset: 0x000F12D4
		public bool #wAb(int #1f)
		{
			#xAb.#92b #92b = new #xAb.#92b();
			#92b.#a = this;
			int num = this.#a.Model.ReinforcementBars.Count + #1f;
			if (num <= this.Limits.TotalBars)
			{
				return true;
			}
			#92b.#b = Strings.StringCannotAddMoreThanXNodes.#D2d(new object[]
			{
				this.Limits.TotalBars
			}).#z2d();
			LayoutHelper.BeginInvokeOnApplicationThread(new Action(#92b.#B8b));
			return false;
		}

		// Token: 0x040012E2 RID: 4834
		private readonly #oW #a;

		// Token: 0x040012E3 RID: 4835
		private readonly #iW #b;

		// Token: 0x040012E4 RID: 4836
		private readonly #8Sc #c;

		// Token: 0x040012E5 RID: 4837
		[CompilerGenerated]
		private readonly #dde #d;

		// Token: 0x02000512 RID: 1298
		[CompilerGenerated]
		private sealed class #92b
		{
			// Token: 0x06002F14 RID: 12052 RVA: 0x0002A1CE File Offset: 0x000283CE
			internal void #B8b()
			{
				this.#a.#c.#od(this.#a.#b.#6(), this.#b, ColumnGlobalInfo.ShortName, MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK, MessageBoxOptions.None);
			}

			// Token: 0x040012E6 RID: 4838
			public #xAb #a;

			// Token: 0x040012E7 RID: 4839
			public string #b;
		}
	}
}
