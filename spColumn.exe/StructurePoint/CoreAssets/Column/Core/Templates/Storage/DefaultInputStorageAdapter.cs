using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using #7hc;
using #gfe;
using #J5d;
using #o1d;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Storage;
using StructurePoint.CoreAssets.Storage;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsx;
using Telerik.Windows.Documents.Spreadsheet.Model;

namespace StructurePoint.CoreAssets.Column.Core.Templates.Storage
{
	// Token: 0x02000841 RID: 2113
	internal sealed class DefaultInputStorageAdapter : ITemplatesStorageAdapter
	{
		// Token: 0x170013E3 RID: 5091
		// (get) Token: 0x06004376 RID: 17270 RVA: 0x00038834 File Offset: 0x00036A34
		public Version SupportedVersion { get; } = new Version(#Phc.#3hc(107455667));

		// Token: 0x06004377 RID: 17271 RVA: 0x00138A08 File Offset: 0x00136C08
		public void Write(#S5d inputStorage, TemplateDesignerProject model)
		{
			foreach (SectionTemplateDefinition sectionTemplateDefinition in model.SectionTemplates)
			{
				MemoryStream memoryStream = new MemoryStream();
				#Afe.#y0d(memoryStream, sectionTemplateDefinition);
				string path = #Phc.#3hc(107456284) + sectionTemplateDefinition.Id.ToString(#Phc.#3hc(107455739)) + #Phc.#3hc(107455730);
				this.WriteStream(inputStorage, path, memoryStream);
			}
			if (model.Workbook != null)
			{
				MemoryStream memoryStream2 = new MemoryStream();
				new XlsxFormatProvider().Export(model.Workbook, memoryStream2);
				this.WriteStream(inputStorage, #Phc.#3hc(107455689), memoryStream2);
			}
		}

		// Token: 0x06004378 RID: 17272 RVA: 0x00138AD4 File Offset: 0x00136CD4
		public TemplateDesignerProject Read(#S5d inputStorage)
		{
			if (inputStorage == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107455652));
			}
			List<IStorageEntry> list = (from item in inputStorage.Entries
			where item.Path.StartsWith(#Phc.#3hc(107456284), StringComparison.OrdinalIgnoreCase) && item.Version == this.SupportedVersion
			select item).ToList<IStorageEntry>();
			TemplateDesignerProject templateDesignerProject = new TemplateDesignerProject();
			foreach (IStorageEntry storageEntry in list)
			{
				SectionTemplateDefinition item2 = #Afe.#sfe(storageEntry.#A5d());
				templateDesignerProject.SectionTemplates.Add(item2);
			}
			IStorageEntry storageEntry2 = inputStorage.Entries.FirstOrDefault((IStorageEntry item) => string.Equals(item.Path, #Phc.#3hc(107455689), StringComparison.OrdinalIgnoreCase));
			if (storageEntry2 != null)
			{
				XlsxFormatProvider xlsxFormatProvider = new XlsxFormatProvider();
				Workbook workbook = templateDesignerProject.Workbook;
				if (workbook != null)
				{
					workbook.Dispose();
				}
				templateDesignerProject.Workbook = xlsxFormatProvider.Import(storageEntry2.#A5d());
				while (templateDesignerProject.Workbook.Sheets.Count > templateDesignerProject.SectionTemplates.Count)
				{
					templateDesignerProject.Workbook.Sheets.RemoveAt(templateDesignerProject.Workbook.Sheets.Count - 1);
				}
			}
			return templateDesignerProject;
		}

		// Token: 0x06004379 RID: 17273 RVA: 0x0003883C File Offset: 0x00036A3C
		private void WriteStream(#S5d inputStorage, string path, Stream stream)
		{
			IStorageEntry storageEntry = inputStorage.#R5d(path, this.SupportedVersion);
			stream.#i2d();
			storageEntry.#UVb(stream);
		}

		// Token: 0x04001E5F RID: 7775
		public const string WorkbookFullPath = "Version_1.0.0/Workbook.xlsx";

		// Token: 0x04001E60 RID: 7776
		private const string TemplateFilePrefix = "Version_1.0.0/Template_";

		// Token: 0x04001E61 RID: 7777
		private const string CnstMainStorageModelFileName = "Workbook.xlsx";

		// Token: 0x04001E62 RID: 7778
		private const string CnstSupportedVersion = "1.0.0";
	}
}
