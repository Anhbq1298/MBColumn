using System;
using System.Runtime.CompilerServices;
using System.Windows;
using #7hc;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #7Pb
{
	// Token: 0x020006B4 RID: 1716
	internal sealed class #6Pb : #gQb
	{
		// Token: 0x06003917 RID: 14615 RVA: 0x001111DC File Offset: 0x0010F3DC
		public #6Pb() : base(#Phc.#3hc(107351303), Visibility.Collapsed)
		{
			base.Values.#pR(new #nQb[]
			{
				#nQb.Separator,
				this.Message
			});
			base.#fQb();
		}

		// Token: 0x1700118C RID: 4492
		// (get) Token: 0x06003918 RID: 14616 RVA: 0x000319D7 File Offset: 0x0002FBD7
		public #nQb Message { get; }

		// Token: 0x06003919 RID: 14617 RVA: 0x00111230 File Offset: 0x0010F430
		public void #uP(string #5)
		{
			this.Message.Value = ((#5 != null) ? #5.Trim() : null);
			base.Visibility = (!string.IsNullOrWhiteSpace(this.Message.Value)).ToVisibility();
		}

		// Token: 0x040017FE RID: 6142
		[CompilerGenerated]
		private readonly #nQb #a = new #nQb();
	}
}
