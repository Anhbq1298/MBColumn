using System;
using System.Runtime.CompilerServices;
using #7hc;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Navigation;

namespace #6Pd
{
	// Token: 0x02000E09 RID: 3593
	internal sealed class #rQd : EventArgs
	{
		// Token: 0x06008170 RID: 33136 RVA: 0x000696F3 File Offset: 0x000678F3
		public #rQd(ReportContentVisibilityOption #mA)
		{
			if (#mA == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107360163));
			}
			this.Options = #mA;
		}

		// Token: 0x17002695 RID: 9877
		// (get) Token: 0x06008171 RID: 33137 RVA: 0x00069715 File Offset: 0x00067915
		// (set) Token: 0x06008172 RID: 33138 RVA: 0x00069721 File Offset: 0x00067921
		public ReportContentVisibilityOption Options { get; private set; }

		// Token: 0x04003523 RID: 13603
		[CompilerGenerated]
		private ReportContentVisibilityOption #a;
	}
}
