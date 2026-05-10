using System;

namespace #pXd
{
	// Token: 0x02000E9E RID: 3742
	internal sealed class #oXd : IDisposable
	{
		// Token: 0x060085B5 RID: 34229 RVA: 0x0006CEBD File Offset: 0x0006B0BD
		private #oXd(Action #qXd, Action #rXd)
		{
			this.#a = #rXd;
			if (#qXd != null)
			{
				#qXd();
			}
		}

		// Token: 0x060085B6 RID: 34230 RVA: 0x0006CED5 File Offset: 0x0006B0D5
		public static IDisposable #jXd(Action #nd)
		{
			return new #oXd(null, #nd);
		}

		// Token: 0x060085B7 RID: 34231 RVA: 0x0006CEDE File Offset: 0x0006B0DE
		public static IDisposable #kXd(Action #nd)
		{
			return new #oXd(#nd, null);
		}

		// Token: 0x060085B8 RID: 34232 RVA: 0x0006CEE7 File Offset: 0x0006B0E7
		public static IDisposable #lXd(Action #mXd, Action #nXd)
		{
			return new #oXd(#mXd, #nXd);
		}

		// Token: 0x060085B9 RID: 34233 RVA: 0x0006CEF0 File Offset: 0x0006B0F0
		public void #1()
		{
			Action action = this.#a;
			if (action == null)
			{
				return;
			}
			if (!false)
			{
				action();
			}
		}

		// Token: 0x0400373E RID: 14142
		private readonly Action #a;
	}
}
