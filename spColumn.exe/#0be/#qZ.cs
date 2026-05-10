using System;
using #2be;
using #9pe;
using StructurePoint.CoreAssets.AppManager.Column.Validation;

namespace #0be
{
	// Token: 0x02001008 RID: 4104
	internal sealed class #qZ : #tce<#jqe>
	{
		// Token: 0x06008DAC RID: 36268 RVA: 0x00072EDC File Offset: 0x000710DC
		public #qZ(#ice #ib) : base(#ib)
		{
			base.Include(new ConcreteMaterialValidator(#ib));
			base.Include(new ReinforcingSteelMaterialValidator(#ib));
		}
	}
}
