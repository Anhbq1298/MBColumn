using System;
using System.Collections.Generic;
using StructurePoint.CoreAssets.AppManager.Column.Templates;

namespace StructurePoint.CoreAssets.Column.Core.Templates
{
	// Token: 0x02000840 RID: 2112
	public sealed class WorksheetParseResult
	{
		// Token: 0x170013E2 RID: 5090
		// (get) Token: 0x06004374 RID: 17268 RVA: 0x00038819 File Offset: 0x00036A19
		public List<TemplateError> Errors { get; } = new List<TemplateError>();
	}
}
