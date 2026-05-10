using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Documentation;

namespace #Eie
{
	// Token: 0x020010A4 RID: 4260
	internal static class #l6c
	{
		// Token: 0x0600916A RID: 37226 RVA: 0x001EB4A0 File Offset: 0x001E96A0
		public static Documentation #C0d(Stream #gp)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Documentation));
			Documentation result;
			using (XmlReader xmlReader = XmlReader.Create(#gp))
			{
				result = (Documentation)xmlSerializer.Deserialize(xmlReader);
			}
			return result;
		}

		// Token: 0x0600916B RID: 37227 RVA: 0x000752B4 File Offset: 0x000734B4
		public static void #y0d(Stream #gp, Documentation #Die)
		{
			#l6c.#y0d<Documentation>(#Die, #gp);
		}

		// Token: 0x0600916C RID: 37228 RVA: 0x001E76A0 File Offset: 0x001E58A0
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

		// Token: 0x04003D21 RID: 15649
		public const string #a = "http://structurepoint.org/spSPL/Column/Templates/Documentation";
	}
}
