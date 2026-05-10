using System;
using #5Fd;
using #7hc;
using #hye;
using #qpb;
using #Wse;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents.Tabular;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #ipb
{
	// Token: 0x02000457 RID: 1111
	internal sealed class #hpb : ColumnTabularReportDefinition
	{
		// Token: 0x060028CE RID: 10446 RVA: 0x0002580C File Offset: 0x00023A0C
		public #hpb(#mpb #mA, #lte #Od) : base(#mA, #Od)
		{
			if (#mA == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107360163));
			}
			this.#a = #mA;
			if (#Od == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107399786));
			}
			this.#b = #Od;
		}

		// Token: 0x060028CF RID: 10447 RVA: 0x000DC894 File Offset: 0x000DAA94
		protected override void #gpb()
		{
			double[] #Zpb = new double[]
			{
				85.0,
				75.0,
				50.0
			};
			if (base.Options.SectionShapeAndProperties.#ISd())
			{
				#JGd #Ae = base.#zed(StyleIdentifier.Heading2, Localization.StringShapeAndProperties, base.Options.SectionShapeAndProperties);
				base.#ved(#Ae, new #Rye(this.#b, #Zpb), null);
				return;
			}
			if (this.#a.MaterialPropertiesSteel.#ISd())
			{
				#JGd #Ae = base.#zed(StyleIdentifier.Heading2, Localization.StringSteel, base.Options.MaterialPropertiesSteel);
				base.#ved(#Ae, new #Bye(this.#b, #Zpb), null);
				return;
			}
			if (this.#a.MaterialPropertiesConcrete.#ISd())
			{
				#JGd #Ae = base.#zed(StyleIdentifier.Heading2, Localization.StringConcrete, base.Options.MaterialPropertiesConcrete);
				base.#ved(#Ae, new #Aye(this.#b, #Zpb), null);
				return;
			}
			if (this.#a.ReinforcementProperties.#ISd())
			{
				#JGd #Ae = base.#zed(StyleIdentifier.Heading2, Localization.Arrangement, base.Options.ReinforcementProperties);
				base.#ved(#Ae, new #Nye(this.#b, #Zpb, true), null);
				return;
			}
			base.#gpb();
			if (base.Options.GeneralInformationSubtable.#JSd())
			{
				#JGd #Ae = base.#zed(StyleIdentifier.Heading1, this.#a.GeneralInformationSubtable.BookmarkName, base.Options.GeneralInformationSubtable);
				base.#ved(#Ae, new #ppb(this.#b), null);
			}
			if (this.#a.SlendernessPropertiesSpecialTable.#JSd())
			{
				#JGd #Ae = base.#zed(StyleIdentifier.Heading1, this.#a.SlendernessPropertiesSpecialTable.BookmarkName, this.#a.SlendernessPropertiesSpecialTable);
				base.#ved(#Ae, new #Ypb(this.#b, null), null);
			}
			if (this.#a.SummarySpecialTable.#JSd())
			{
				#JGd #Ae = base.#zed(StyleIdentifier.Heading1, this.#a.SummarySpecialTable.BookmarkName, this.#a.SummarySpecialTable);
				base.#ved(#Ae, new #0pb(this.#b, #Zpb), null);
			}
			if (this.#a.NavigationSpecialTable.#JSd())
			{
				#JGd #Ae = base.#zed(StyleIdentifier.Heading1, this.#a.NavigationSpecialTable.BookmarkName, this.#a.NavigationSpecialTable);
				base.#ved(#Ae, new #Qpb(this.#b), null);
			}
		}

		// Token: 0x04001034 RID: 4148
		private readonly #mpb #a;

		// Token: 0x04001035 RID: 4149
		private readonly #lte #b;
	}
}
