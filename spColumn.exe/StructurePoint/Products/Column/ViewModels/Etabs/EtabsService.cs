using System;
using #7hc;
using #ID;
using #k2i;
using Alphaleonis.Win32.Filesystem;
using StructurePoint.CoreAssets.Column.Core.Core.Diagnostics;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Kernel.CoreAssets.Importer.Business;
using StructurePoint.Kernel.CoreAssets.Importer.Core;
using StructurePoint.Kernel.CoreAssets.Importer.DataClasses;

namespace StructurePoint.Products.Column.ViewModels.Etabs
{
	// Token: 0x02000231 RID: 561
	internal sealed class EtabsService : IDisposable, #pF
	{
		// Token: 0x060012F6 RID: 4854 RVA: 0x00014831 File Offset: 0x00012A31
		public EtabsService()
		{
			StructurePoint.Kernel.CoreAssets.Importer.Core.Logger.#QQc(new #l0i());
			this.#a = new #26h(ProjectType.SpColumn, string.Empty, null, null);
		}

		// Token: 0x060012F7 RID: 4855 RVA: 0x00014856 File Offset: 0x00012A56
		public bool #jF(string #So)
		{
			return this.#lF(#So) && this.#a.#I6h();
		}

		// Token: 0x060012F8 RID: 4856 RVA: 0x000AD090 File Offset: 0x000AB290
		public #iF #kF(string #So, UnitSystem #Qg)
		{
			bool flag = this.#lF(#So);
			UnitsSystem #Z6h = (#Qg == UnitSystem.USCustomary) ? UnitsSystem.English : UnitsSystem.Metric;
			if (flag)
			{
				this.#a.#Y6h(#So, #Z6h);
			}
			else
			{
				this.#a.#16h(#So, #Z6h);
			}
			return new #iF(this.#a.Project, flag);
		}

		// Token: 0x060012F9 RID: 4857 RVA: 0x000AD0EC File Offset: 0x000AB2EC
		public bool #lF(string #So)
		{
			string extension = Path.GetExtension(#So);
			string text;
			if (!false)
			{
				text = extension;
			}
			return string.Equals((text != null) ? text.Trim() : null, #Phc.#3hc(107408741), StringComparison.OrdinalIgnoreCase);
		}

		// Token: 0x060012FA RID: 4858 RVA: 0x0001487A File Offset: 0x00012A7A
		public void #1()
		{
			Func<string> message = new Func<string>(EtabsService.<>c.<>9.#j1i);
			if (!false)
			{
				StructurePoint.CoreAssets.Column.Core.Core.Diagnostics.Logger.Debug(message);
			}
			this.#a.#1();
		}

		// Token: 0x040007C4 RID: 1988
		private readonly #26h #a;
	}
}
