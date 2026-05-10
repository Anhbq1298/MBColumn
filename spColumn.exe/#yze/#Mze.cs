using System;
using System.Runtime.CompilerServices;
using #7hc;
using #owe;
using #Wse;
using #yEd;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Paged.WordPdf;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #yze
{
	// Token: 0x020011FA RID: 4602
	internal sealed class #Mze : WordPdfReportGeneratorCore
	{
		// Token: 0x06009A4B RID: 39499 RVA: 0x0020D338 File Offset: 0x0020B538
		public #Mze(#uwe #mA, #lte #Od)
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
			this.Model = #Od;
			this.#b = new #Jze(#Od, #mA)
			{
				IncludeCover = #mA.Cover.#ISd(),
				IncludeTableOfContents = #mA.TableOfContents.#ISd(),
				SplitLongTables = #mA.SplitLongTables,
				TableOfContentsBookmarkName = #mA.TableOfContents.BookmarkName
			};
			#xze #xS = new #xze(new #pwe(new #Ize(this.#b), #mA, #Od));
			base.#eb(this.#b, #xS);
		}

		// Token: 0x17002CC0 RID: 11456
		// (get) Token: 0x06009A4C RID: 39500 RVA: 0x0007A3A8 File Offset: 0x000785A8
		private #lte Model { get; }

		// Token: 0x06009A4D RID: 39501 RVA: 0x0007A3B0 File Offset: 0x000785B0
		protected override void #Jed(#AEd #xS)
		{
			this.#Kze();
			this.#Lze();
			base.#Jed(#xS);
		}

		// Token: 0x06009A4E RID: 39502 RVA: 0x0020D3F0 File Offset: 0x0020B5F0
		private void #Kze()
		{
			if (!string.IsNullOrWhiteSpace(this.Model.Input.ProjectInfo.Engineer))
			{
				this.#b.Document.BuiltInDocumentProperties.Author = this.Model.Input.ProjectInfo.Engineer;
			}
			if (!string.IsNullOrWhiteSpace(this.Model.Input.ProjectInfo.Project))
			{
				this.#b.Document.BuiltInDocumentProperties.Title = this.Model.Input.ProjectInfo.Project;
			}
			if (!string.IsNullOrWhiteSpace(this.Model.GeneralInfo.ProductAndVersion))
			{
				this.#b.Document.BuiltInDocumentProperties.NameOfApplication = this.Model.GeneralInfo.ProductAndVersion;
			}
		}

		// Token: 0x06009A4F RID: 39503 RVA: 0x0020D4C8 File Offset: 0x0020B6C8
		private void #Lze()
		{
			DocumentBuilder documentBuilder = this.#b.Builder;
			GeneralInformation generalInformation = this.#b.Model.GeneralInfo;
			documentBuilder.CurrentSection.PageSetup.DifferentFirstPageHeaderFooter = this.#a.Cover.#ISd();
			string #vwe = #Phc.#3hc(107378408) + generalInformation.ProductAndVersion;
			string #wwe = string.Format(Localization.StringLicensedTo0LicenseID1, generalInformation.LicenseeName, generalInformation.LicenseId);
			if (generalInformation.IsTrial)
			{
				#wwe = #Phc.#3hc(107283182) + generalInformation.LockingCode + #Phc.#3hc(107283185) + generalInformation.LicenseeName;
			}
			string #4Hc = generalInformation.FileName;
			#xwe.#Ppb(documentBuilder, base.PrintOptions, #vwe, #wwe, #4Hc);
		}

		// Token: 0x0400423F RID: 16959
		private readonly #uwe #a;

		// Token: 0x04004240 RID: 16960
		private readonly #Jze #b;

		// Token: 0x04004241 RID: 16961
		[CompilerGenerated]
		private readonly #lte #c;
	}
}
