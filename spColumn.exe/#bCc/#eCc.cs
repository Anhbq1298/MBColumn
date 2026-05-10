using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;

namespace #bCc
{
	// Token: 0x02000B56 RID: 2902
	internal sealed class #eCc : #aCc
	{
		// Token: 0x06005EAF RID: 24239 RVA: 0x0004EB64 File Offset: 0x0004CD64
		public void #6Bc(int #7Bc)
		{
			if (!false)
			{
				this.#dCc(#7Bc);
			}
		}

		// Token: 0x06005EB0 RID: 24240 RVA: 0x0004EB74 File Offset: 0x0004CD74
		public void #8Bc()
		{
			Process.Start(Assembly.GetEntryAssembly().Location);
			int #7Bc = 0;
			if (!false)
			{
				this.#dCc(#7Bc);
			}
		}

		// Token: 0x17001ADC RID: 6876
		// (get) Token: 0x06005EB1 RID: 24241 RVA: 0x0004EB94 File Offset: 0x0004CD94
		// (set) Token: 0x06005EB2 RID: 24242 RVA: 0x0004EB9C File Offset: 0x0004CD9C
		public bool IsExiting { get; private set; }

		// Token: 0x06005EB3 RID: 24243 RVA: 0x0004EBA5 File Offset: 0x0004CDA5
		private void #dCc(int #7Bc)
		{
			bool #f = true;
			if (7 != 0)
			{
				this.IsExiting = #f;
			}
			Application application = Application.Current;
			if (!false)
			{
				application.Shutdown(#7Bc);
			}
		}

		// Token: 0x04002730 RID: 10032
		[CompilerGenerated]
		private bool #a;
	}
}
