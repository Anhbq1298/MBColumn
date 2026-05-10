using System;
using #7hc;
using #FCd;
using #Qcd;
using #Ted;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Tabular;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;

namespace #8xe
{
	// Token: 0x0200119C RID: 4508
	internal sealed class #dye : #Lhd
	{
		// Token: 0x06009906 RID: 39174 RVA: 0x00203308 File Offset: 0x00201508
		public #dye(TelerikGridRenderer #Mhd, ColumnTabularReportDefinition #xS) : base(#Mhd)
		{
			if (#Mhd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107286825));
			}
			if (#xS == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107253735));
			}
			base.#eb(#xS);
			this.#a = new #eye(#xS.Model);
		}

		// Token: 0x06009907 RID: 39175 RVA: 0x00079C0F File Offset: 0x00077E0F
		protected override int[] #Hed(#uDd #Xpb)
		{
			return this.#a.#3hc(#Xpb);
		}

		// Token: 0x040041AF RID: 16815
		private readonly #mdd #a;
	}
}
