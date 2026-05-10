using System;
using System.Collections.Generic;

namespace #45d
{
	// Token: 0x02000F33 RID: 3891
	internal sealed class #75d : #35d
	{
		// Token: 0x060089D7 RID: 35287 RVA: 0x00070297 File Offset: 0x0006E497
		public #75d()
		{
			this.#a = new Dictionary<string, string>();
		}

		// Token: 0x060089D8 RID: 35288 RVA: 0x000702AA File Offset: 0x0006E4AA
		public void #I2c()
		{
			this.#a = new Dictionary<string, string>();
		}

		// Token: 0x060089D9 RID: 35289 RVA: 0x000702BF File Offset: 0x0006E4BF
		public string #05d(string #6cc)
		{
			if (this.#a.ContainsKey(#6cc))
			{
				return this.#a[#6cc];
			}
			return null;
		}

		// Token: 0x060089DA RID: 35290 RVA: 0x000702E9 File Offset: 0x0006E4E9
		public bool #15d(string #6cc)
		{
			return this.#a.ContainsKey(#6cc);
		}

		// Token: 0x060089DB RID: 35291 RVA: 0x00070303 File Offset: 0x0006E503
		public void #25d(string #6cc, string #8cc)
		{
			if (this.#a.ContainsKey(#6cc))
			{
				this.#a[#6cc] = #8cc;
				return;
			}
			this.#a.Add(#6cc, #8cc);
		}

		// Token: 0x040038B9 RID: 14521
		private Dictionary<string, string> #a;
	}
}
