using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using #7hc;
using #A7d;
using #cYd;
using #J5d;
using #J6d;
using #UYd;
using #x5d;
using Alphaleonis.Win32.Filesystem;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.Storage.File.Input
{
	// Token: 0x02000F4B RID: 3915
	public sealed class FileInputStorageProvider : IDisposable, #Z5d
	{
		// Token: 0x06008A63 RID: 35427 RVA: 0x000708E3 File Offset: 0x0006EAE3
		public FileInputStorageProvider(string filePath)
		{
			#X0d.#W0d(filePath, #Phc.#3hc(107377058), Component.StorageFile, #Phc.#3hc(107219604));
			this.#c = Alphaleonis.Win32.Filesystem.File.Open(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
		}

		// Token: 0x06008A64 RID: 35428 RVA: 0x00070915 File Offset: 0x0006EB15
		public FileInputStorageProvider(Stream data)
		{
			#X0d.#V0d(data, #Phc.#3hc(107376321), Component.StorageFile, #Phc.#3hc(107219551));
			this.#c = data;
			this.#c.Seek(0L, SeekOrigin.Begin);
		}

		// Token: 0x06008A65 RID: 35429 RVA: 0x0007094E File Offset: 0x0006EB4E
		public FileInputStorageProvider(Stream data, bool leaveOpen)
		{
			#X0d.#V0d(data, #Phc.#3hc(107376321), Component.StorageFile, #Phc.#3hc(107219551));
			this.#c = data;
			this.#d = leaveOpen;
			this.#c.Seek(0L, SeekOrigin.Begin);
		}

		// Token: 0x06008A66 RID: 35430 RVA: 0x001D7EDC File Offset: 0x001D60DC
		protected void #o7d()
		{
			try
			{
				this.#1(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		// Token: 0x06008A67 RID: 35431 RVA: 0x001D7F14 File Offset: 0x001D6114
		public void #X5d(#S5d #Y5d, #z5d #W5d)
		{
			#X0d.#V0d(#Y5d, #Phc.#3hc(107455652), Component.StorageFile, #Phc.#3hc(107219466));
			#X0d.#V0d(#Y5d.Metadata, #Phc.#3hc(107219957), Component.StorageFile, #Phc.#3hc(107219928));
			try
			{
				this.#p7d();
				#I5d #I5d = #Y5d.Metadata;
				InputManifest inputManifest = new InputManifest(#I5d.Name, #I5d.EncryptionMethod, #I5d.ApplicationVersion, #I5d.CreationTime, #I5d.ModificationTime);
				using (ZipArchive zipArchive = new ZipArchive(this.#c, ZipArchiveMode.Update, true))
				{
					foreach (IStorageEntry storageEntry in #Y5d.Entries)
					{
						inputManifest.Entries.Add(new ManifestEntry(storageEntry.Path, storageEntry.Version.ToString()));
						ZipArchiveEntry zipArchiveEntry = zipArchive.CreateEntry(storageEntry.Path, CompressionLevel.Optimal);
						storageEntry.#A5d().CopyTo(zipArchiveEntry.Open());
					}
					ZipArchiveEntry zipArchiveEntry2 = zipArchive.CreateEntry(#Phc.#3hc(107219843));
					new XmlSerializer(typeof(InputManifest)).Serialize(zipArchiveEntry2.Open(), inputManifest);
				}
			}
			catch (Exception #Uic)
			{
				throw new #y5d(Strings.StringAnUnexpectedErrorOccurredWhileSavingTheDataToStorage.#z2d(), #Phc.#3hc(107219858), Component.StorageFile, #IYd.#a, #Uic);
			}
		}

		// Token: 0x06008A68 RID: 35432 RVA: 0x001D80B0 File Offset: 0x001D62B0
		public #S5d #V5d(#z5d #W5d)
		{
			#S5d result;
			try
			{
				ZipArchive zipArchive = new ZipArchive(this.#c);
				InputManifest inputManifest = this.#q7d(zipArchive);
				FileInputStorageProvider.#u7d(zipArchive, inputManifest);
				#I5d #U5d = new #I5d(inputManifest.Name, inputManifest.ApplicationVersion, inputManifest.CreationTime, inputManifest.ModificationTime, inputManifest.EncryptionMethod);
				List<#L6d> list = new List<#L6d>();
				using (List<ManifestEntry>.Enumerator enumerator = inputManifest.Entries.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						FileInputStorageProvider.#s0b #s0b = new FileInputStorageProvider.#s0b();
						#s0b.#a = enumerator.Current;
						#L6d #L6d = new #L6d(#s0b.#a.Path, new Version(#s0b.#a.Version));
						#L6d.#UVb(zipArchive.Entries.First(new Func<ZipArchiveEntry, bool>(#s0b.#F7d)).Open());
						list.Add(#L6d);
					}
				}
				result = new #z7d(#U5d, list);
			}
			catch (XmlException #Uic)
			{
				throw new #y5d(Strings.StringCouldNotReadTheManifest.#z2d(), #Phc.#3hc(107219805), Component.StorageFile, #IYd.#b, #Uic);
			}
			catch (#K6d #Uic2)
			{
				throw new #y5d(Strings.StringCouldNotReadTheManifest.#z2d(), #Phc.#3hc(107219720), Component.StorageFile, #IYd.#b, #Uic2);
			}
			catch (InvalidDataException #Uic3)
			{
				throw new #y5d(Strings.StringTheDataIsInvalid.#z2d(), #Phc.#3hc(107219187), Component.StorageFile, #IYd.#b, #JYd.#m, #Uic3);
			}
			catch (Exception #Uic4)
			{
				throw new #y5d(Strings.StringAnUnexpectedErrorOccurredWhileReadingTheInputData.#z2d(), #Phc.#3hc(107219134), Component.StorageFile, #IYd.#a, #Uic4);
			}
			return result;
		}

		// Token: 0x06008A69 RID: 35433 RVA: 0x0007098E File Offset: 0x0006EB8E
		public #S5d #T5d(#I5d #U5d)
		{
			#X0d.#V0d(#U5d, #Phc.#3hc(107219049), Component.StorageFile, #Phc.#3hc(107219020));
			return new #z7d(#U5d);
		}

		// Token: 0x06008A6A RID: 35434 RVA: 0x001D8288 File Offset: 0x001D6488
		public void #p7d()
		{
			try
			{
				using (ZipArchive zipArchive = new ZipArchive(this.#c, ZipArchiveMode.Update, true))
				{
					foreach (ZipArchiveEntry zipArchiveEntry in zipArchive.Entries.ToList<ZipArchiveEntry>())
					{
						ZipArchiveEntry entry = zipArchive.GetEntry(zipArchiveEntry.FullName);
						if (entry != null)
						{
							entry.Delete();
						}
					}
				}
			}
			catch (Exception #Uic)
			{
				throw new #y5d(Strings.StringAnUnexpectedErrorOccurredWhileEmptyingTheStorage.#z2d(), #Phc.#3hc(107218999), Component.StorageFile, #IYd.#a, #Uic);
			}
		}

		// Token: 0x06008A6B RID: 35435 RVA: 0x000709BD File Offset: 0x0006EBBD
		public void #1()
		{
			this.#1(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06008A6C RID: 35436 RVA: 0x000709D8 File Offset: 0x0006EBD8
		protected void #1(bool #POb)
		{
			if (#POb && !this.#d && this.#c != null)
			{
				this.#c.Dispose();
				this.#c = null;
			}
		}

		// Token: 0x06008A6D RID: 35437 RVA: 0x001D8358 File Offset: 0x001D6558
		private InputManifest #q7d(ZipArchive #s6d)
		{
			ZipArchiveEntry zipArchiveEntry = #s6d.Entries.FirstOrDefault(new Func<ZipArchiveEntry, bool>(FileInputStorageProvider.<>c.<>9.#H7d));
			if (zipArchiveEntry == null)
			{
				throw new #K6d(Strings.StringTheProjectManifestHasNotBeenFound.#z2d(), #Phc.#3hc(107219426), Component.StorageFile, #IYd.#b, #JYd.#i);
			}
			this.#r7d(zipArchiveEntry);
			Stream stream = zipArchiveEntry.Open();
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(InputManifest));
			InputManifest result;
			try
			{
				result = (InputManifest)xmlSerializer.Deserialize(stream);
			}
			finally
			{
				stream.Close();
			}
			return result;
		}

		// Token: 0x06008A6E RID: 35438 RVA: 0x001D8414 File Offset: 0x001D6614
		private void #r7d(ZipArchiveEntry #s7d)
		{
			XmlSchema #O6d = this.#w7d();
			XmlDocument #Q6d = FileInputStorageProvider.#t7d(#s7d);
			#Y6d #Y6d = new #Y6d();
			#Y6d.#IH(#O6d, #Q6d);
			if (!string.IsNullOrWhiteSpace(#Y6d.ErrorMessage))
			{
				throw new #K6d(Strings.StringAnErrorOccurredWhileValidatingTheManifest.#z2d() + #Y6d.ErrorMessage, #Phc.#3hc(107220479), Component.StorageFile, #IYd.#b, #JYd.#k);
			}
		}

		// Token: 0x06008A6F RID: 35439 RVA: 0x001D8484 File Offset: 0x001D6684
		private static XmlDocument #t7d(ZipArchiveEntry #s7d)
		{
			Stream stream = #s7d.Open();
			XmlDocument xmlDocument = new XmlDocument();
			try
			{
				xmlDocument.Load(stream);
			}
			catch (XmlException #Uic)
			{
				throw new #K6d(Strings.StringAnErrorOccurredWhileValidatingTheManifest.#z2d(), #Phc.#3hc(107219373), Component.StorageFile, #IYd.#b, #JYd.#k, #Uic);
			}
			finally
			{
				stream.Close();
			}
			return xmlDocument;
		}

		// Token: 0x06008A70 RID: 35440 RVA: 0x001D84FC File Offset: 0x001D66FC
		private static void #u7d(ZipArchive #s6d, InputManifest #v7d)
		{
			using (List<ManifestEntry>.Enumerator enumerator = #v7d.Entries.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					FileInputStorageProvider.#DUb #DUb = new FileInputStorageProvider.#DUb();
					#DUb.#a = enumerator.Current;
					if (#s6d.Entries.All(new Func<ZipArchiveEntry, bool>(#DUb.#I7d)))
					{
						throw new #K6d(Strings.StringNotAllFilesDefinedInTheManifestHaveBeenFound.#z2d(), #Phc.#3hc(107219352), Component.StorageFile, #IYd.#b, #JYd.#l);
					}
				}
			}
		}

		// Token: 0x06008A71 RID: 35441 RVA: 0x001D85AC File Offset: 0x001D67AC
		private XmlSchema #w7d()
		{
			Stream stream = null;
			XmlSchema result;
			try
			{
				stream = base.GetType().Assembly.GetManifestResourceStream(#Phc.#3hc(107219267));
				if (stream == null)
				{
					throw new InvalidOperationException(Strings.StringEmbeddedResourceXCouldNotHaveBeenFound.#D2d(new object[]
					{
						#Phc.#3hc(107219267)
					}).#z2d());
				}
				Stream stream2 = stream;
				ValidationEventHandler validationEventHandler;
				if ((validationEventHandler = FileInputStorageProvider.#2Ui.#a) == null)
				{
					validationEventHandler = (FileInputStorageProvider.#2Ui.#a = new ValidationEventHandler(FileInputStorageProvider.#96d));
				}
				result = XmlSchema.Read(stream2, validationEventHandler);
			}
			finally
			{
				if (stream != null)
				{
					stream.Close();
				}
			}
			return result;
		}

		// Token: 0x06008A72 RID: 35442 RVA: 0x00070A0B File Offset: 0x0006EC0B
		private static void #96d(object #Ge, ValidationEventArgs #He)
		{
			throw new #K6d(Strings.StringAnErrorOccurredWhileReadingTheManifestXsdSchema.#z2d() + #He.Message, #Phc.#3hc(107218658), Component.StorageFile, #IYd.#c, #JYd.#j);
		}

		// Token: 0x040038F7 RID: 14583
		private const string #a = "Manifest.xml";

		// Token: 0x040038F8 RID: 14584
		private const string #b = "StructurePoint.CoreAssets.Storage.File.Input._XML_Schemes.Manifest.xsd";

		// Token: 0x040038F9 RID: 14585
		private Stream #c;

		// Token: 0x040038FA RID: 14586
		private readonly bool #d;

		// Token: 0x02000F4C RID: 3916
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x040038FB RID: 14587
			public static ValidationEventHandler #a;
		}

		// Token: 0x02000F4E RID: 3918
		[CompilerGenerated]
		private sealed class #DUb
		{
			// Token: 0x06008A77 RID: 35447 RVA: 0x00070A78 File Offset: 0x0006EC78
			internal bool #I7d(ZipArchiveEntry #G7d)
			{
				return #G7d.FullName != this.#a.Path;
			}

			// Token: 0x040038FE RID: 14590
			public ManifestEntry #a;
		}

		// Token: 0x02000F4F RID: 3919
		[CompilerGenerated]
		private sealed class #s0b
		{
			// Token: 0x06008A79 RID: 35449 RVA: 0x00070A9C File Offset: 0x0006EC9C
			internal bool #F7d(ZipArchiveEntry #G7d)
			{
				return #G7d.FullName.Equals(this.#a.Path);
			}

			// Token: 0x040038FF RID: 14591
			public ManifestEntry #a;
		}
	}
}
