using System;
using #7hc;
using #jCd;
using #owe;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Tabular;

namespace #8xe
{
	// Token: 0x0200119A RID: 4506
	internal sealed class #7xe : #BCd
	{
		// Token: 0x06009901 RID: 39169 RVA: 0x0020324C File Offset: 0x0020144C
		public #7xe(#uwe #mA, #lte #Od) : base(new #uCd(new #kCd()))
		{
			if (#mA == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107360163));
			}
			if (#Od == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399786));
			}
			ColumnTabularReportDefinition #xS = new ColumnTabularReportDefinition(#mA, #Od);
			base.#eb(#xS);
		}

		// Token: 0x06009902 RID: 39170 RVA: 0x00009E6A File Offset: 0x0000806A
		protected override void #Ged()
		{
		}
	}
}
