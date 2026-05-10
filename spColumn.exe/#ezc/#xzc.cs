using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using #7hc;
using #o1d;
using #UYd;

namespace #ezc
{
	// Token: 0x02000B36 RID: 2870
	internal sealed class #xzc
	{
		// Token: 0x06005DD4 RID: 24020 RVA: 0x0004E32C File Offset: 0x0004C52C
		public void #vzc(#uzc #wzc)
		{
			if (!true || (!false && #wzc != null))
			{
				ConcurrentQueue<#uzc> concurrentQueue = this.#a;
				if (!false)
				{
					concurrentQueue.Enqueue(#wzc);
				}
				if (!false)
				{
					return;
				}
			}
			throw new ArgumentNullException(#Phc.#3hc(107420204));
		}

		// Token: 0x06005DD5 RID: 24021 RVA: 0x00176258 File Offset: 0x00174458
		public string #h()
		{
			#xzc.#wbc #wbc = new #xzc.#wbc();
			#xzc.#wbc #wbc2;
			if (4 != 0)
			{
				#wbc2 = #wbc;
			}
			#wbc2.#a = new StringBuilder();
			IEnumerable<#uzc> #H1d = this.#a;
			Action<#uzc> #nd = new Action<#uzc>(#wbc2.#q8c);
			if (4 != 0)
			{
				#H1d.#I1d(#nd);
			}
			return #wbc2.#a.ToString().Trim();
		}

		// Token: 0x06005DD6 RID: 24022 RVA: 0x001762AC File Offset: 0x001744AC
		public void #yJ()
		{
			if (!false)
			{
				goto IL_16;
			}
			IL_05:
			if (6 == 0)
			{
				goto IL_24;
			}
			#uzc #uzc;
			this.#a.TryDequeue(out #uzc);
			IL_16:
			if (this.#a.Count > 0)
			{
				goto IL_05;
			}
			IL_24:
			if (!false)
			{
				return;
			}
			goto IL_05;
		}

		// Token: 0x040026F8 RID: 9976
		private readonly ConcurrentQueue<#uzc> #a = new ConcurrentQueue<#uzc>();

		// Token: 0x02000B37 RID: 2871
		[CompilerGenerated]
		private sealed class #wbc
		{
			// Token: 0x06005DD9 RID: 24025 RVA: 0x0004E370 File Offset: 0x0004C570
			internal void #q8c(#uzc #Rf)
			{
				do
				{
					if (true && !false)
					{
						this.#a.AppendLine(#Rf.ToString());
					}
					this.#a.AppendLine();
				}
				while (false);
			}

			// Token: 0x040026F9 RID: 9977
			public StringBuilder #a;
		}
	}
}
