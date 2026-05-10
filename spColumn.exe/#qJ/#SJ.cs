using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using FluentValidation.Results;

namespace #qJ
{
	// Token: 0x0200029E RID: 670
	internal sealed class #SJ
	{
		// Token: 0x170007B8 RID: 1976
		// (get) Token: 0x060015DC RID: 5596 RVA: 0x00016D7A File Offset: 0x00014F7A
		public List<ValidationFailure> Errors { get; }

		// Token: 0x170007B9 RID: 1977
		// (get) Token: 0x060015DD RID: 5597 RVA: 0x00016D86 File Offset: 0x00014F86
		public List<ValidationFailure> Warnings { get; }

		// Token: 0x170007BA RID: 1978
		// (get) Token: 0x060015DE RID: 5598 RVA: 0x00016D92 File Offset: 0x00014F92
		public bool IsValid
		{
			get
			{
				return !this.Errors.Any<ValidationFailure>();
			}
		}

		// Token: 0x170007BB RID: 1979
		// (get) Token: 0x060015DF RID: 5599 RVA: 0x00016DAE File Offset: 0x00014FAE
		// (set) Token: 0x060015E0 RID: 5600 RVA: 0x00016DBA File Offset: 0x00014FBA
		public string FormattedErrors { get; set; }

		// Token: 0x170007BC RID: 1980
		// (get) Token: 0x060015E1 RID: 5601 RVA: 0x00016DCB File Offset: 0x00014FCB
		// (set) Token: 0x060015E2 RID: 5602 RVA: 0x00016DD7 File Offset: 0x00014FD7
		public string FormattedErrorsCompact { get; set; }

		// Token: 0x040008BC RID: 2236
		[CompilerGenerated]
		private readonly List<ValidationFailure> #a = new List<ValidationFailure>();

		// Token: 0x040008BD RID: 2237
		[CompilerGenerated]
		private readonly List<ValidationFailure> #b = new List<ValidationFailure>();

		// Token: 0x040008BE RID: 2238
		[CompilerGenerated]
		private string #c;

		// Token: 0x040008BF RID: 2239
		[CompilerGenerated]
		private string #d;
	}
}
