using System;
using System.Runtime.CompilerServices;

namespace StructurePoint.CoreAssets.AppManager.Column.Reporting.Model
{
	// Token: 0x02001174 RID: 4468
	public sealed class SolverMessage
	{
		// Token: 0x06009771 RID: 38769 RVA: 0x000787EF File Offset: 0x000769EF
		public SolverMessage(string prefix, string message)
		{
			this.Prefix = prefix;
			this.Message = message;
		}

		// Token: 0x06009772 RID: 38770 RVA: 0x000035C3 File Offset: 0x000017C3
		public SolverMessage()
		{
		}

		// Token: 0x17002C03 RID: 11267
		// (get) Token: 0x06009773 RID: 38771 RVA: 0x00078805 File Offset: 0x00076A05
		// (set) Token: 0x06009774 RID: 38772 RVA: 0x0007880D File Offset: 0x00076A0D
		public string Prefix { get; set; }

		// Token: 0x17002C04 RID: 11268
		// (get) Token: 0x06009775 RID: 38773 RVA: 0x00078816 File Offset: 0x00076A16
		// (set) Token: 0x06009776 RID: 38774 RVA: 0x0007881E File Offset: 0x00076A1E
		public string Message { get; set; }

		// Token: 0x04004110 RID: 16656
		[CompilerGenerated]
		private string #a;

		// Token: 0x04004111 RID: 16657
		[CompilerGenerated]
		private string #b;
	}
}
