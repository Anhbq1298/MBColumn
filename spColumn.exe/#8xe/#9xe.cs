using System;
using #7hc;
using #FCd;
using #owe;
using #QBd;
using #Qcd;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Tabular;

namespace #8xe
{
	// Token: 0x0200119B RID: 4507
	internal sealed class #9xe : #fCd
	{
		// Token: 0x06009903 RID: 39171 RVA: 0x002032A0 File Offset: 0x002014A0
		public #9xe(#uwe #mA, #lte #Od, bool #gCd) : base(new #VBd(new #PBd()), #gCd)
		{
			if (#mA == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107360163));
			}
			if (#Od == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399786));
			}
			this.#a = #mA;
			this.#b = new #eye(#Od);
			ColumnTabularReportDefinition #xS = new ColumnTabularReportDefinition(#mA, #Od);
			base.#eb(#xS);
		}

		// Token: 0x06009904 RID: 39172 RVA: 0x00079BD1 File Offset: 0x00077DD1
		protected override int[] #Hed(#uDd #Xpb)
		{
			return this.#b.#3hc(#Xpb);
		}

		// Token: 0x06009905 RID: 39173 RVA: 0x00079BDF File Offset: 0x00077DDF
		protected override void #Ged()
		{
			if (this.#a.TableOfContents.#ISd())
			{
				base.TableOfContentsBookmarkName = this.#a.TableOfContents.BookmarkName;
				base.#Ged();
			}
		}

		// Token: 0x040041AD RID: 16813
		private readonly #uwe #a;

		// Token: 0x040041AE RID: 16814
		private readonly #mdd #b;
	}
}
