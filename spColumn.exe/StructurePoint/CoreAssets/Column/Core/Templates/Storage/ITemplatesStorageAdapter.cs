using System;
using #J5d;

namespace StructurePoint.CoreAssets.Column.Core.Templates.Storage
{
	// Token: 0x02000843 RID: 2115
	internal interface ITemplatesStorageAdapter
	{
		// Token: 0x170013E4 RID: 5092
		// (get) Token: 0x0600437F RID: 17279
		Version SupportedVersion { get; }

		// Token: 0x06004380 RID: 17280
		void Write(#S5d inputStorage, TemplateDesignerProject model);

		// Token: 0x06004381 RID: 17281
		TemplateDesignerProject Read(#S5d inputStorage);
	}
}
