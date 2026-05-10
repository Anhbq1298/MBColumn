using System;
using StructurePoint.Products.Column.Editor.Core.Tools;
using StructurePoint.Products.Column.Resources;
using StructurePoint.Products.Column.Services.API;

namespace #cMb
{
	// Token: 0x020004D6 RID: 1238
	internal class #bMb : BaseToolWithCustomCursor
	{
		// Token: 0x06002D66 RID: 11622 RVA: 0x00028ADD File Offset: 0x00026CDD
		public #bMb(IExtendedServices #0c) : base(#0c)
		{
		}

		// Token: 0x06002D67 RID: 11623 RVA: 0x00028AE6 File Offset: 0x00026CE6
		protected override void #Zzb()
		{
			base.#vMb(ColumnResources.Cross_Add_CursorData);
		}
	}
}
