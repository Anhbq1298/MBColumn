using System;
using log4net.Appender;
using log4net.Core;
using log4net.Repository;

namespace #H1i
{
	// Token: 0x02000E68 RID: 3688
	internal sealed class #J1i : AppenderSkeleton
	{
		// Token: 0x060083F1 RID: 33777 RVA: 0x0006B8E8 File Offset: 0x00069AE8
		public #J1i(#a2i #nd)
		{
			this.#a = #nd;
		}

		// Token: 0x060083F2 RID: 33778 RVA: 0x0006B8F7 File Offset: 0x00069AF7
		protected void #dGd(LoggingEvent #I1i)
		{
			#a2i #a2i = this.#a;
			if (#a2i == null)
			{
				return;
			}
			ILoggerRepository repository = #I1i.Repository;
			#a2i((repository != null) ? repository.Name : null, #I1i.LoggerName, #I1i.Level.DisplayName, base.RenderLoggingEvent(#I1i));
		}

		// Token: 0x04003667 RID: 13927
		private readonly #a2i #a;
	}
}
