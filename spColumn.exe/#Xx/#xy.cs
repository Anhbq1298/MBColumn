using System;
using #ezc;
using StructurePoint.CoreAssets.Column.Core.Core.App;

namespace #Xx
{
	// Token: 0x020001B8 RID: 440
	internal sealed class #xy : DependencyResolverBase, #GBc
	{
		// Token: 0x06000F04 RID: 3844 RVA: 0x00011895 File Offset: 0x0000FA95
		public void #sy<#uy>(#uy #ty) where #uy : class
		{
			base.Container.RegisterInstance(typeof(!!0), #ty);
		}

		// Token: 0x06000F05 RID: 3845 RVA: 0x000118BE File Offset: 0x0000FABE
		public #Fu #vy<#Fu>()
		{
			return (!!0)((object)base.Container.GetInstance(typeof(!!0)));
		}

		// Token: 0x06000F06 RID: 3846 RVA: 0x000118E6 File Offset: 0x0000FAE6
		public #Fu #vy<#Fu>(string #wy)
		{
			return this.#vy<#Fu>();
		}
	}
}
