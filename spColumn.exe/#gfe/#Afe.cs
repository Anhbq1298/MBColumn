using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Xml.Serialization;
using #7hc;
using Alphaleonis.Win32.Filesystem;
using StructurePoint.CoreAssets.AppManager.Column.Templates;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Storage;
using StructurePoint.CoreAssets.Logger;

namespace #gfe
{
	// Token: 0x0200105A RID: 4186
	internal static class #Afe
	{
		// Token: 0x170029C3 RID: 10691
		// (get) Token: 0x06008F72 RID: 36722 RVA: 0x00073FCC File Offset: 0x000721CC
		public static string TemplateDesignerProjectExtension { get; } = #Phc.#3hc(107245796);

		// Token: 0x170029C4 RID: 10692
		// (get) Token: 0x06008F73 RID: 36723 RVA: 0x00073FD3 File Offset: 0x000721D3
		public static string SectionTemplateExtension { get; } = #Phc.#3hc(107245819);

		// Token: 0x170029C5 RID: 10693
		// (get) Token: 0x06008F74 RID: 36724 RVA: 0x00073FDA File Offset: 0x000721DA
		public static string SectionTemplateExtensionPattern { get; } = #Phc.#3hc(107245810);

		// Token: 0x170029C6 RID: 10694
		// (get) Token: 0x06008F75 RID: 36725 RVA: 0x00073FE1 File Offset: 0x000721E1
		public static string SectionTemplatePackageExtensionPattern { get; } = #Phc.#3hc(107245769);

		// Token: 0x06008F76 RID: 36726 RVA: 0x001E746C File Offset: 0x001E566C
		public static string #ofe(this ICollection<LocalizableString> #Qb, string #pfe)
		{
			#Afe.#iZb #iZb = new #Afe.#iZb();
			#iZb.#a = #pfe;
			LocalizableString localizableString = #Qb.FirstOrDefault(new Func<LocalizableString, bool>(#iZb.#raf)) ?? #Qb.FirstOrDefault<LocalizableString>();
			if (localizableString == null)
			{
				return null;
			}
			return localizableString.Message;
		}

		// Token: 0x06008F77 RID: 36727 RVA: 0x00073FE8 File Offset: 0x000721E8
		public static string #ofe(this LocalizableProperty #z8c, string #pfe)
		{
			return #z8c.Values.#ofe(#pfe);
		}

		// Token: 0x06008F78 RID: 36728 RVA: 0x00073FF6 File Offset: 0x000721F6
		public static SectionTemplateDefinition #qfe(string #So)
		{
			return #Afe.#rfe(Alphaleonis.Win32.Filesystem.File.ReadAllText(#So));
		}

		// Token: 0x06008F79 RID: 36729 RVA: 0x00074003 File Offset: 0x00072203
		public static SectionTemplateDefinition #rfe(string #Ukc)
		{
			return #Afe.#sfe(#Ukc);
		}

		// Token: 0x06008F7A RID: 36730 RVA: 0x0007400B File Offset: 0x0007220B
		public static string #y0d(SectionTemplateDefinition #Q0)
		{
			return #Afe.#y0d<SectionTemplateDefinition>(#Q0);
		}

		// Token: 0x06008F7B RID: 36731 RVA: 0x00074013 File Offset: 0x00072213
		public static void #y0d(Stream #gp, SectionTemplateDefinition #Pwb)
		{
			#Afe.#y0d<SectionTemplateDefinition>(#Pwb, #gp);
		}

		// Token: 0x06008F7C RID: 36732 RVA: 0x001E74B0 File Offset: 0x001E56B0
		public static SectionTemplateDefinition #sfe(Stream #gp)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(SectionTemplateDefinition));
			SectionTemplateDefinition result;
			using (XmlReader xmlReader = XmlReader.Create(#gp))
			{
				result = (SectionTemplateDefinition)xmlSerializer.Deserialize(xmlReader);
			}
			return result;
		}

		// Token: 0x06008F7D RID: 36733 RVA: 0x001E7500 File Offset: 0x001E5700
		public static SectionTemplatesPackageFile #tfe(this IList<SectionTemplatesPackageFile> #ki, string #So)
		{
			#Afe.#HUb #HUb = new #Afe.#HUb();
			#HUb.#a = System.IO.Path.GetFileName(#So);
			return #ki.FirstOrDefault(new Func<SectionTemplatesPackageFile, bool>(#HUb.#saf));
		}

		// Token: 0x06008F7E RID: 36734 RVA: 0x001E7534 File Offset: 0x001E5734
		public static SectionTemplatesPackageDefinition #ufe(Stream #gp)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(SectionTemplatesPackageDefinition));
			SectionTemplatesPackageDefinition result;
			using (XmlReader xmlReader = XmlReader.Create(#gp))
			{
				result = (SectionTemplatesPackageDefinition)xmlSerializer.Deserialize(xmlReader);
			}
			return result;
		}

		// Token: 0x06008F7F RID: 36735 RVA: 0x0007401C File Offset: 0x0007221C
		public static void #vfe(Stream #gp, SectionTemplatesPackageDefinition #wfe)
		{
			#Afe.#y0d<SectionTemplatesPackageDefinition>(#wfe, #gp);
		}

		// Token: 0x06008F80 RID: 36736 RVA: 0x001E7584 File Offset: 0x001E5784
		public static SectionTemplateDefinition #sfe(string #Ukc)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(SectionTemplateDefinition));
			SectionTemplateDefinition result;
			using (XmlReader xmlReader = XmlReader.Create(new StringReader(#Ukc)))
			{
				result = (SectionTemplateDefinition)xmlSerializer.Deserialize(xmlReader);
			}
			return result;
		}

		// Token: 0x06008F81 RID: 36737 RVA: 0x001E75D8 File Offset: 0x001E57D8
		public static ImageSource #xfe(SectionTemplateDefinition #xS, TemplateFileType #yfe)
		{
			#Afe.#CTb #CTb = new #Afe.#CTb();
			#CTb.#a = #yfe;
			TemplateImageDefinition templateImageDefinition = #xS.Images.FirstOrDefault(new Func<TemplateImageDefinition, bool>(#CTb.#taf));
			if (templateImageDefinition != null && templateImageDefinition.Data != null)
			{
				using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(templateImageDefinition.Data)))
				{
					BitmapImage bitmapImage = new BitmapImage();
					bitmapImage.BeginInit();
					bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
					bitmapImage.StreamSource = memoryStream;
					bitmapImage.EndInit();
					return bitmapImage;
				}
			}
			return null;
		}

		// Token: 0x06008F82 RID: 36738 RVA: 0x001E7668 File Offset: 0x001E5868
		public static ImageSource #zfe(SectionTemplateDefinition #xS, TemplateFileType #yfe)
		{
			#Afe.#ETb #ETb = new #Afe.#ETb();
			#ETb.#a = #xS;
			#ETb.#b = #yfe;
			ImageSource result;
			Ignore.#14d<Exception, ImageSource>(new Func<ImageSource>(#ETb.#uaf), out result, null);
			return result;
		}

		// Token: 0x06008F83 RID: 36739 RVA: 0x001E76A0 File Offset: 0x001E58A0
		private static void #y0d<#Fu>(#Fu #Rf, Stream #gp)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(!!0));
			XmlWriterSettings settings = new XmlWriterSettings
			{
				Indent = true,
				Encoding = Encoding.UTF8
			};
			using (XmlWriter xmlWriter = XmlWriter.Create(#gp, settings))
			{
				xmlSerializer.Serialize(xmlWriter, #Rf);
			}
		}

		// Token: 0x06008F84 RID: 36740 RVA: 0x001E7708 File Offset: 0x001E5908
		private static string #y0d<#Fu>(#Fu #Rf)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(!!0));
			string result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				XmlWriterSettings settings = new XmlWriterSettings
				{
					Indent = true,
					Encoding = Encoding.UTF8
				};
				using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream, settings))
				{
					xmlSerializer.Serialize(xmlWriter, #Rf);
				}
				memoryStream.Seek(0L, SeekOrigin.Begin);
				using (StreamReader streamReader = new StreamReader(memoryStream))
				{
					result = streamReader.ReadToEnd();
				}
			}
			return result;
		}

		// Token: 0x04003C24 RID: 15396
		[CompilerGenerated]
		private static readonly string #a;

		// Token: 0x04003C25 RID: 15397
		[CompilerGenerated]
		private static readonly string #b;

		// Token: 0x04003C26 RID: 15398
		[CompilerGenerated]
		private static readonly string #c;

		// Token: 0x04003C27 RID: 15399
		[CompilerGenerated]
		private static readonly string #d;

		// Token: 0x0200105B RID: 4187
		[CompilerGenerated]
		private sealed class #iZb
		{
			// Token: 0x06008F87 RID: 36743 RVA: 0x00074063 File Offset: 0x00072263
			internal bool #raf(LocalizableString #Rf)
			{
				return string.Equals(#Rf.LanguageCode, this.#a, StringComparison.Ordinal);
			}

			// Token: 0x04003C28 RID: 15400
			public string #a;
		}

		// Token: 0x0200105C RID: 4188
		[CompilerGenerated]
		private sealed class #HUb
		{
			// Token: 0x06008F89 RID: 36745 RVA: 0x00074077 File Offset: 0x00072277
			internal bool #saf(SectionTemplatesPackageFile #Rf)
			{
				string fileName = #Rf.FileName;
				return string.Equals((fileName != null) ? fileName.Trim() : null, this.#a, StringComparison.OrdinalIgnoreCase);
			}

			// Token: 0x04003C29 RID: 15401
			public string #a;
		}

		// Token: 0x0200105D RID: 4189
		[CompilerGenerated]
		private sealed class #CTb
		{
			// Token: 0x06008F8B RID: 36747 RVA: 0x00074097 File Offset: 0x00072297
			internal bool #taf(TemplateImageDefinition #Rf)
			{
				return #Rf.Type == this.#a;
			}

			// Token: 0x04003C2A RID: 15402
			public TemplateFileType #a;
		}

		// Token: 0x0200105E RID: 4190
		[CompilerGenerated]
		private sealed class #ETb
		{
			// Token: 0x06008F8D RID: 36749 RVA: 0x000740A7 File Offset: 0x000722A7
			internal ImageSource #uaf()
			{
				return #Afe.#xfe(this.#a, this.#b);
			}

			// Token: 0x04003C2B RID: 15403
			public SectionTemplateDefinition #a;

			// Token: 0x04003C2C RID: 15404
			public TemplateFileType #b;
		}
	}
}
