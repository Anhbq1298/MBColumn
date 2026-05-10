using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using #7hc;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #UYd
{
	// Token: 0x02000ED5 RID: 3797
	internal static class #F0d
	{
		// Token: 0x060086D2 RID: 34514 RVA: 0x001CEA10 File Offset: 0x001CCC10
		public static string #y0d<#Fu>(#Fu #z0d, IEnumerable<Type> #A0d)
		{
			if (8 != 0)
			{
				object #Rf = #z0d;
				string #R0d = #Phc.#3hc(107226985);
				Component #x6c = Component.Infrastructure;
				string #Qic = #Phc.#3hc(107226992);
				if (!false)
				{
					#X0d.#V0d(#Rf, #R0d, #x6c, #Qic);
				}
			}
			DataContractSerializer dataContractSerializer;
			if (#A0d == null)
			{
				dataContractSerializer = new DataContractSerializer(typeof(!!0));
				goto IL_4C;
			}
			IL_3C:
			dataContractSerializer = new DataContractSerializer(typeof(!!0), #A0d);
			IL_4C:
			DataContractSerializer dataContractSerializer2;
			if (!false)
			{
				dataContractSerializer2 = dataContractSerializer;
			}
			if (8 != 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				StringBuilder stringBuilder2;
				if (!false)
				{
					stringBuilder2 = stringBuilder;
				}
				XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
				Encoding utf = Encoding.UTF8;
				if (true)
				{
					xmlWriterSettings.Encoding = utf;
				}
				XmlWriterSettings settings;
				if (7 != 0)
				{
					settings = xmlWriterSettings;
				}
				XmlWriter xmlWriter = XmlWriter.Create(stringBuilder2, settings);
				XmlWriter xmlWriter2;
				if (!false)
				{
					xmlWriter2 = xmlWriter;
				}
				string result;
				try
				{
					dataContractSerializer2.WriteObject(xmlWriter2, #z0d);
					xmlWriter2.Flush();
					result = stringBuilder2.ToString();
				}
				finally
				{
					for (;;)
					{
						if (xmlWriter2 == null)
						{
							goto IL_A4;
						}
						IL_9B:
						if (7 == 0)
						{
							continue;
						}
						((IDisposable)xmlWriter2).Dispose();
						IL_A4:
						if (!false)
						{
							break;
						}
						goto IL_9B;
					}
				}
				return result;
			}
			goto IL_3C;
		}

		// Token: 0x060086D3 RID: 34515 RVA: 0x001CEAF8 File Offset: 0x001CCCF8
		public static void #y0d<#Fu>(#Fu #Gfb, Stream #B0d) where #Fu : class
		{
			if (!false)
			{
				object #Rf = #Gfb;
				string #R0d = #Phc.#3hc(107376321);
				Component #x6c = Component.Infrastructure;
				string #Qic = #Phc.#3hc(107226939);
				if (!false)
				{
					#X0d.#V0d(#Rf, #R0d, #x6c, #Qic);
				}
				string #R0d2 = #Phc.#3hc(107226342);
				Component #x6c2 = Component.Infrastructure;
				string #Qic2 = #Phc.#3hc(107226357);
				if (!false)
				{
					#X0d.#V0d(#B0d, #R0d2, #x6c2, #Qic2);
				}
			}
			DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(!!0));
			DataContractSerializer dataContractSerializer2;
			if (!false)
			{
				dataContractSerializer2 = dataContractSerializer;
			}
			XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
			xmlWriterSettings.Encoding = Encoding.UTF8;
			bool closeOutput = false;
			if (!false)
			{
				xmlWriterSettings.CloseOutput = closeOutput;
			}
			XmlWriterSettings settings;
			if (5 != 0)
			{
				settings = xmlWriterSettings;
			}
			XmlWriter xmlWriter = XmlWriter.Create(#B0d, settings);
			XmlWriter xmlWriter2;
			if (!false)
			{
				xmlWriter2 = xmlWriter;
			}
			try
			{
				dataContractSerializer2.WriteObject(xmlWriter2, #Gfb);
				xmlWriter2.Flush();
			}
			finally
			{
				if (false || 5 == 0 || false || xmlWriter2 != null)
				{
					((IDisposable)xmlWriter2).Dispose();
				}
			}
		}

		// Token: 0x060086D4 RID: 34516 RVA: 0x001CEBE4 File Offset: 0x001CCDE4
		public static #Fu #C0d<#Fu>(Stream #D0d) where #Fu : class
		{
			string #R0d = #Phc.#3hc(107226272);
			Component #x6c = Component.Infrastructure;
			string #Qic = #Phc.#3hc(107226255);
			if (3 != 0)
			{
				#X0d.#V0d(#D0d, #R0d, #x6c, #Qic);
			}
			DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(!!0));
			DataContractSerializer dataContractSerializer2;
			if (!false)
			{
				dataContractSerializer2 = dataContractSerializer;
			}
			#Fu result;
			do
			{
				XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
				bool ignoreComments = true;
				if (5 != 0)
				{
					xmlReaderSettings.IgnoreComments = ignoreComments;
				}
				XmlReaderSettings settings;
				if (5 != 0)
				{
					settings = xmlReaderSettings;
				}
				XmlReader xmlReader = XmlReader.Create(#D0d, settings);
				XmlReader xmlReader2;
				if (!false)
				{
					xmlReader2 = xmlReader;
				}
				try
				{
					#Fu #Fu = (!!0)((object)dataContractSerializer2.ReadObject(xmlReader2));
					if (!false)
					{
						result = #Fu;
					}
				}
				finally
				{
					if (xmlReader2 != null)
					{
						((IDisposable)xmlReader2).Dispose();
					}
				}
			}
			while (5 == 0);
			return result;
		}

		// Token: 0x060086D5 RID: 34517 RVA: 0x001CEC88 File Offset: 0x001CCE88
		[SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times", Justification = "XML Reader simply closes the text reader.")]
		[SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "string")]
		public static #Fu #C0d<#Fu>(string #E0d, IEnumerable<Type> #A0d)
		{
			string #R0d = #Phc.#3hc(107226234);
			Component #x6c = Component.Infrastructure;
			string #Qic = #Phc.#3hc(107226189);
			if (!false)
			{
				#X0d.#V0d(#E0d, #R0d, #x6c, #Qic);
			}
			DataContractSerializer dataContractSerializer = (#A0d != null) ? new DataContractSerializer(typeof(!!0), #A0d) : new DataContractSerializer(typeof(!!0));
			DataContractSerializer dataContractSerializer2;
			if (!false)
			{
				dataContractSerializer2 = dataContractSerializer;
			}
			StringReader stringReader = new StringReader(#E0d);
			StringReader stringReader2;
			if (!false)
			{
				stringReader2 = stringReader;
			}
			#Fu result;
			try
			{
				XmlReaderSettings settings = new XmlReaderSettings
				{
					IgnoreComments = true
				};
				XmlReader xmlReader = XmlReader.Create(stringReader2, settings);
				try
				{
					#Fu #Fu = (!!0)((object)dataContractSerializer2.ReadObject(xmlReader));
					if (!false)
					{
						result = #Fu;
					}
				}
				finally
				{
					if (xmlReader != null && !false)
					{
						((IDisposable)xmlReader).Dispose();
					}
				}
			}
			finally
			{
				if (stringReader2 != null)
				{
					((IDisposable)stringReader2).Dispose();
				}
			}
			return result;
		}
	}
}
