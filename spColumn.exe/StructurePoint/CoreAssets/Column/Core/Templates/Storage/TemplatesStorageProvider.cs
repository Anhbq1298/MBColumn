using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using #7hc;
using #J5d;
using #x5d;
using StructurePoint.CoreAssets.Storage;
using StructurePoint.CoreAssets.Storage.File.Input;

namespace StructurePoint.CoreAssets.Column.Core.Templates.Storage
{
	// Token: 0x02000846 RID: 2118
	public sealed class TemplatesStorageProvider : #z5d
	{
		// Token: 0x06004392 RID: 17298 RVA: 0x00038979 File Offset: 0x00036B79
		public TemplatesStorageProvider()
		{
			this.adapters.Add(new DefaultInputStorageAdapter());
		}

		// Token: 0x170013EB RID: 5099
		// (get) Token: 0x06004393 RID: 17299 RVA: 0x000389AA File Offset: 0x00036BAA
		// (set) Token: 0x06004394 RID: 17300 RVA: 0x000389B2 File Offset: 0x00036BB2
		public Version DefaultInputFileVersion { get; set; } = new Version(1, 0, 0);

		// Token: 0x06004395 RID: 17301 RVA: 0x00138C00 File Offset: 0x00136E00
		public void Save(Stream stream, TemplateDesignerProject project, bool leaveStreamOpen = false)
		{
			using (FileInputStorageProvider fileInputStorageProvider = new FileInputStorageProvider(stream, leaveStreamOpen))
			{
				FileInputStorageProvider fileInputStorageProvider2 = fileInputStorageProvider;
				string #wy = #Phc.#3hc(107455626);
				Assembly entryAssembly = Assembly.GetEntryAssembly();
				string text;
				if (entryAssembly == null)
				{
					text = null;
				}
				else
				{
					Version version = entryAssembly.GetName().Version;
					text = ((version != null) ? version.ToString(3) : null);
				}
				#S5d #S5d = fileInputStorageProvider2.#T5d(new #I5d(#wy, text ?? #Phc.#3hc(107455667), DateTime.Now, DateTime.Now, EncryptionMethod.None));
				foreach (ITemplatesStorageAdapter templatesStorageAdapter in this.adapters)
				{
					templatesStorageAdapter.Write(#S5d, project);
				}
				fileInputStorageProvider.#X5d(#S5d, this);
			}
		}

		// Token: 0x06004396 RID: 17302 RVA: 0x00138CCC File Offset: 0x00136ECC
		public ReadTemplateModelResult Read(Stream stream)
		{
			#S5d #S5d = new FileInputStorageProvider(stream).#V5d(this);
			IStorageEntry storageEntry = (from item in #S5d.Entries
			where item.Version <= this.DefaultInputFileVersion
			orderby item.Version descending
			select item).FirstOrDefault<IStorageEntry>();
			if (storageEntry == null)
			{
				if (#S5d.Entries.Any((IStorageEntry item) => item.Version > this.DefaultInputFileVersion))
				{
					this.OnUnsupportedInputProjectCreatedWithNewerApplication();
				}
				else
				{
					this.OnUnsupportedInputFileNoDataFound();
				}
				return ReadTemplateModelResult.Invalid();
			}
			if (#S5d.Entries.Any((IStorageEntry item) => item.Version > this.DefaultInputFileVersion))
			{
				this.OnOpenInputFileWithNewerFileVersions();
			}
			return new ReadTemplateModelResult(this.adapters.First((ITemplatesStorageAdapter item) => item.SupportedVersion == storageEntry.Version).Read(#S5d), true);
		}

		// Token: 0x06004397 RID: 17303 RVA: 0x00009E6A File Offset: 0x0000806A
		private void OnOpenInputFileWithNewerFileVersions()
		{
		}

		// Token: 0x06004398 RID: 17304 RVA: 0x00009E6A File Offset: 0x0000806A
		private void OnUnsupportedInputFileNoDataFound()
		{
		}

		// Token: 0x06004399 RID: 17305 RVA: 0x00009E6A File Offset: 0x0000806A
		private void OnUnsupportedInputProjectCreatedWithNewerApplication()
		{
		}

		// Token: 0x04001E6C RID: 7788
		private readonly List<ITemplatesStorageAdapter> adapters = new List<ITemplatesStorageAdapter>();
	}
}
