using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using #36d;
using #45d;
using #7hc;
using #cYd;
using #J6d;
using #UYd;
using #x5d;
using Alphaleonis.Win32.Filesystem;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.Storage.File.Settings
{
	// Token: 0x02000F46 RID: 3910
	public sealed class XMLSettingsProvider : #55d, #86d
	{
		// Token: 0x06008A3C RID: 35388 RVA: 0x001D7420 File Offset: 0x001D5620
		public XMLSettingsProvider(string settingFilePath, #35d cacheProvider)
		{
			#X0d.#W0d(settingFilePath, #Phc.#3hc(107221047), Component.StorageFile, #Phc.#3hc(107220994));
			#X0d.#V0d(cacheProvider, #Phc.#3hc(107221453), Component.StorageFile, #Phc.#3hc(107221464));
			this.#i = settingFilePath;
			this.#j = false;
			this.#h = cacheProvider;
			try
			{
				this.#l7d();
				this.#j7d(this.#k);
				XMLSettingsProvider.#a7d(this.#k);
			}
			catch (XmlException #Uic)
			{
				throw new #w5d(Strings.StringTheSettingsRaisedAnException.#z2d(), #Phc.#3hc(107221379), Component.StorageFile, #IYd.#b, #Uic);
			}
			catch (#KYd #Uic2)
			{
				throw new #w5d(Strings.StringTheSettingsRaisedAnException.#z2d(), #Phc.#3hc(107221326), Component.StorageFile, #IYd.#b, #Uic2);
			}
			catch (Exception #Uic3)
			{
				throw new #w5d(Strings.StringTheSettingsRaisedAnException.#z2d(), #Phc.#3hc(107221305), Component.StorageFile, #IYd.#a, #Uic3);
			}
		}

		// Token: 0x06008A3D RID: 35389 RVA: 0x001D7528 File Offset: 0x001D5728
		public XMLSettingsProvider(XDocument xmlData, #35d cacheProvider)
		{
			#X0d.#V0d(xmlData, #Phc.#3hc(107220708), Component.StorageFile, #Phc.#3hc(107220727));
			#X0d.#V0d(cacheProvider, #Phc.#3hc(107221453), Component.StorageFile, #Phc.#3hc(107220642));
			this.#k = xmlData;
			this.#j = true;
			this.#h = cacheProvider;
			try
			{
				this.#j7d(this.#k);
				XMLSettingsProvider.#a7d(this.#k);
			}
			catch (XmlException #Uic)
			{
				throw new #w5d(Strings.StringTheProvidedSettingsFileIsNotAValidXMLFile.#z2d(), #Phc.#3hc(107221379), Component.StorageFile, #IYd.#b, #Uic);
			}
			catch (#KYd #Uic2)
			{
				throw new #w5d(Strings.StringTheProvidedSettingsDoesNotContainValidSettingsData.#z2d(), #Phc.#3hc(107220589), Component.StorageFile, #IYd.#b, #Uic2);
			}
			catch (#w5d #Uic3)
			{
				throw new #w5d(Strings.StringTheProvidedSettingsDoesNotContainValidSettingsData.#z2d(), #Phc.#3hc(107220568), Component.StorageFile, #IYd.#b, #Uic3);
			}
			catch (Exception #Uic4)
			{
				throw new #w5d(Strings.StringAnUnexpectedErrorOccurredWhileReadingTheSettingsFile.#z2d(), #Phc.#3hc(107220483), Component.StorageFile, #IYd.#a, #Uic4);
			}
		}

		// Token: 0x170028A4 RID: 10404
		// (get) Token: 0x06008A3E RID: 35390 RVA: 0x00070763 File Offset: 0x0006E963
		// (set) Token: 0x06008A3F RID: 35391 RVA: 0x0007076F File Offset: 0x0006E96F
		public bool AutoFlush { get; set; }

		// Token: 0x06008A40 RID: 35392 RVA: 0x001D7658 File Offset: 0x001D5858
		public bool #5cc(string #6cc, string #7cc, out string #f)
		{
			#X0d.#W0d(#6cc, #Phc.#3hc(107221776), Component.StorageFile, #Phc.#3hc(107220942));
			if (string.IsNullOrEmpty(#7cc))
			{
				#7cc = string.Empty;
			}
			#f = string.Empty;
			bool result;
			try
			{
				bool flag;
				if (this.#h.#15d(#6cc))
				{
					#f = this.#h.#05d(#6cc);
					flag = true;
				}
				else
				{
					flag = this.#m7d(#6cc, #7cc, out #f);
					this.#h.#25d(#6cc, #f);
				}
				result = flag;
			}
			catch (#KYd #Uic)
			{
				throw new #w5d(Strings.StringTheSettingsRaisedAnException.#z2d(), #Phc.#3hc(107220921), Component.StorageFile, #IYd.#b, #Uic);
			}
			catch (Exception #Uic2)
			{
				throw new #w5d(Strings.StringTheSettingsRaisedAnException.#z2d(), #Phc.#3hc(107220836), Component.StorageFile, #IYd.#a, #Uic2);
			}
			return result;
		}

		// Token: 0x06008A41 RID: 35393 RVA: 0x001D774C File Offset: 0x001D594C
		public void #zl(string #6cc, string #8cc)
		{
			#X0d.#W0d(#6cc, #Phc.#3hc(107221776), Component.StorageFile, #Phc.#3hc(107220783));
			try
			{
				XElement xelement = XMLSettingsProvider.#c7d(this.#k.Root, #6cc);
				string a;
				if (xelement == null)
				{
					this.#n7d(this.#k.Root, #6cc, #8cc);
					this.#h.#25d(#6cc, #8cc);
				}
				else if (!XMLSettingsProvider.#g7d(xelement, out a) || !string.Equals(a, #8cc))
				{
					XMLSettingsProvider.#e7d(xelement, #6cc, #8cc);
					this.#h.#25d(#6cc, #8cc);
					this.#i7d();
				}
			}
			catch (#KYd #Uic)
			{
				throw new #w5d(Strings.StringTheSettingsRaisedAnException.#z2d(), #Phc.#3hc(107220762), Component.StorageFile, #IYd.#b, #Uic);
			}
			catch (Exception #Uic2)
			{
				throw new #w5d(Strings.StringTheSettingsRaisedAnException.#z2d(), #Phc.#3hc(107220165), Component.StorageFile, #IYd.#a, #Uic2);
			}
		}

		// Token: 0x06008A42 RID: 35394 RVA: 0x001D7854 File Offset: 0x001D5A54
		public bool #lGd()
		{
			if (this.#j)
			{
				return false;
			}
			bool result;
			try
			{
				string b = this.#k.ToString();
				this.#k.Save(this.#i);
				bool flag = this.#b != b;
				this.#b = b;
				result = flag;
			}
			catch (Exception #Uic)
			{
				throw new #w5d(Strings.StringFailedToSaveTheSettingsFIle.#z2d(), #Phc.#3hc(107220144), Component.StorageFile, #IYd.#a, #JYd.#r, #Uic);
			}
			return result;
		}

		// Token: 0x06008A43 RID: 35395 RVA: 0x00070780 File Offset: 0x0006E980
		private static void #96d(object #Ge, ValidationEventArgs #He)
		{
			throw new #KYd(Strings.StringAnErrorOccurredWhileReadingTheSettingsXsdSchema.#z2d() + #He.Message, #Phc.#3hc(107220091), Component.StorageFile, #IYd.#c, #JYd.#j);
		}

		// Token: 0x06008A44 RID: 35396 RVA: 0x001D78E4 File Offset: 0x001D5AE4
		private static void #a7d(XDocument #b7d)
		{
			if (#b7d.Root != null)
			{
				foreach (IGrouping<string, XElement> grouping in #b7d.Root.Descendants(#Phc.#3hc(107220006)).Where(new Func<XElement, bool>(XMLSettingsProvider.<>c.<>9.#C7d)).GroupBy(new Func<XElement, string>(XMLSettingsProvider.<>c.<>9.#D7d)))
				{
					if (grouping.Count<XElement>() > 1)
					{
						throw new #w5d(string.Format(CultureInfo.InvariantCulture, Strings.StringDuplicatedSettingKeysFoundId0Occurred1Times.#z2d(), new object[]
						{
							grouping.Key,
							grouping.Count<XElement>()
						}), #Phc.#3hc(107220025), Component.StorageFile, #IYd.#b, #JYd.#q);
					}
				}
			}
		}

		// Token: 0x06008A45 RID: 35397 RVA: 0x001D7A04 File Offset: 0x001D5C04
		private static XElement #c7d(XElement #d7d, string #6cc)
		{
			XMLSettingsProvider.#iZb #iZb = new XMLSettingsProvider.#iZb();
			XMLSettingsProvider.#iZb #iZb2;
			if (!false)
			{
				#iZb2 = #iZb;
			}
			#iZb2.#a = #6cc;
			return #d7d.Elements(#Phc.#3hc(107220006)).Where(new Func<XElement, bool>(#iZb2.#E7d)).FirstOrDefault<XElement>();
		}

		// Token: 0x06008A46 RID: 35398 RVA: 0x001D7A58 File Offset: 0x001D5C58
		private static void #e7d(XElement #8cc, string #6cc, string #f7d)
		{
			#8cc.SetAttributeValue(#Phc.#3hc(107220452), #6cc);
			XElement xelement = #8cc.Element(#Phc.#3hc(107399374));
			if (xelement != null)
			{
				xelement.ReplaceNodes(new XCData(#f7d));
			}
		}

		// Token: 0x06008A47 RID: 35399 RVA: 0x001D7AAC File Offset: 0x001D5CAC
		private static bool #g7d(XElement #8cc, out string #f)
		{
			#f = string.Empty;
			XElement xelement = #8cc.Element(#Phc.#3hc(107399374));
			if (xelement != null)
			{
				#f = xelement.Value;
				return true;
			}
			return false;
		}

		// Token: 0x06008A48 RID: 35400 RVA: 0x001D7AF0 File Offset: 0x001D5CF0
		private static bool #h7d(XElement #8cc, string #7cc, out string #f)
		{
			#f = string.Empty;
			XElement xelement = #8cc.Element(#Phc.#3hc(107399374));
			if (xelement != null)
			{
				#f = xelement.Value;
				return true;
			}
			#f = #7cc;
			return false;
		}

		// Token: 0x06008A49 RID: 35401 RVA: 0x000707BA File Offset: 0x0006E9BA
		private void #i7d()
		{
			if (this.AutoFlush)
			{
				this.#lGd();
			}
		}

		// Token: 0x06008A4A RID: 35402 RVA: 0x001D7B38 File Offset: 0x001D5D38
		private void #j7d(XDocument #b7d)
		{
			XmlSchema #O6d = this.#k7d();
			#Y6d #Y6d = new #Y6d();
			#Y6d.#IH(#O6d, #b7d.ToString());
			if (!string.IsNullOrWhiteSpace(#Y6d.ErrorMessage))
			{
				throw new #KYd(Strings.StringAnErrorOccurredWhileValidatingTheSettings.#z2d() + #Y6d.ErrorMessage, #Phc.#3hc(107220479), Component.StorageFile, #IYd.#b, #JYd.#p);
			}
		}

		// Token: 0x06008A4B RID: 35403 RVA: 0x001D7BA8 File Offset: 0x001D5DA8
		private XmlSchema #k7d()
		{
			Stream stream = null;
			XmlSchema result;
			try
			{
				stream = base.GetType().Assembly.GetManifestResourceStream(#Phc.#3hc(107220394));
				if (stream == null)
				{
					throw new InvalidOperationException(Strings.StringEmbeddedResourceXCouldNotHaveBeenFound.#D2d(new object[]
					{
						#Phc.#3hc(107220394)
					}).#z2d());
				}
				Stream stream2 = stream;
				ValidationEventHandler validationEventHandler;
				if ((validationEventHandler = XMLSettingsProvider.#2Ui.#a) == null)
				{
					validationEventHandler = (XMLSettingsProvider.#2Ui.#a = new ValidationEventHandler(XMLSettingsProvider.#96d));
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

		// Token: 0x06008A4C RID: 35404 RVA: 0x001D7C4C File Offset: 0x001D5E4C
		private void #l7d()
		{
			if (Alphaleonis.Win32.Filesystem.File.Exists(this.#i))
			{
				try
				{
					this.#k = XDocument.Load(this.#i);
					if (this.#k.Root == null || this.#k.Root.Name != #Phc.#3hc(107220313))
					{
						throw new #KYd(Strings.StringTheProvidedSettingsFileIsNotAValidXMLFile.#z2d(), #Phc.#3hc(107220268), Component.StorageFile, #IYd.#b, #JYd.#p);
					}
					return;
				}
				catch (Exception #Uic)
				{
					throw new #KYd(Strings.StringAnUnexpectedErrorOccurredWhileReadingTheSettingsFile.#z2d(), #Phc.#3hc(107220247), Component.StorageFile, #IYd.#b, #JYd.#p, #Uic);
				}
			}
			this.#k = new XDocument();
			this.#k.Add(new XElement(#Phc.#3hc(107220313)));
			this.#lGd();
		}

		// Token: 0x06008A4D RID: 35405 RVA: 0x001D7D50 File Offset: 0x001D5F50
		private bool #m7d(string #6cc, string #7cc, out string #f)
		{
			#f = string.Empty;
			XElement xelement = XMLSettingsProvider.#c7d(this.#k.Root, #6cc);
			bool result;
			if (xelement != null)
			{
				result = XMLSettingsProvider.#h7d(xelement, #7cc, out #f);
			}
			else
			{
				this.#n7d(this.#k.Root, #6cc, #7cc);
				#f = #7cc;
				result = false;
			}
			return result;
		}

		// Token: 0x06008A4E RID: 35406 RVA: 0x001D7DAC File Offset: 0x001D5FAC
		private XElement #n7d(XElement #jA, string #6cc, string #7cc)
		{
			XElement xelement = new XElement(#Phc.#3hc(107220006));
			xelement.Add(new XAttribute(#Phc.#3hc(107220452), #6cc));
			xelement.Add(new XElement(#Phc.#3hc(107399374), new XCData(#7cc)));
			#jA.Add(xelement);
			this.#i7d();
			return xelement;
		}

		// Token: 0x040038E1 RID: 14561
		[CompilerGenerated]
		private bool #a = true;

		// Token: 0x040038E2 RID: 14562
		private string #b;

		// Token: 0x040038E3 RID: 14563
		private const string #c = "StructurePoint.CoreAssets.Storage.File.Settings._XML_Schemes.SettingsXmlSchema.xsd";

		// Token: 0x040038E4 RID: 14564
		private const string #d = "Settings";

		// Token: 0x040038E5 RID: 14565
		private const string #e = "Setting";

		// Token: 0x040038E6 RID: 14566
		private const string #f = "Key";

		// Token: 0x040038E7 RID: 14567
		private const string #g = "Value";

		// Token: 0x040038E8 RID: 14568
		private readonly #35d #h;

		// Token: 0x040038E9 RID: 14569
		private readonly string #i;

		// Token: 0x040038EA RID: 14570
		private readonly bool #j;

		// Token: 0x040038EB RID: 14571
		private XDocument #k;

		// Token: 0x02000F47 RID: 3911
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x040038EC RID: 14572
			public static ValidationEventHandler #a;
		}

		// Token: 0x02000F49 RID: 3913
		[CompilerGenerated]
		private sealed class #iZb
		{
			// Token: 0x06008A54 RID: 35412 RVA: 0x001D7E24 File Offset: 0x001D6024
			internal bool #E7d(XElement #eub)
			{
				return #eub.Attribute(#Phc.#3hc(107220452)) != null && #eub.Attribute(#Phc.#3hc(107220452)).Value == this.#a;
			}

			// Token: 0x040038F0 RID: 14576
			public string #a;
		}
	}
}
