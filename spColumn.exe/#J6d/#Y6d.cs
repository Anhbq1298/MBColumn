using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using #7hc;
using #cYd;
using #UYd;
using Alphaleonis.Win32.Filesystem;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #J6d
{
	// Token: 0x02000F41 RID: 3905
	internal sealed class #Y6d
	{
		// Token: 0x06008A22 RID: 35362 RVA: 0x0007065C File Offset: 0x0006E85C
		public #Y6d()
		{
			this.ErrorsCount = 0;
			this.#a = new StringBuilder();
		}

		// Token: 0x06008A23 RID: 35363 RVA: 0x001D6DA0 File Offset: 0x001D4FA0
		private void #M6d(object #Ge, ValidationEventArgs #N6d)
		{
			this.#a.AppendLine(#N6d.Message);
			int num = this.ErrorsCount;
			this.ErrorsCount = num + 1;
		}

		// Token: 0x06008A24 RID: 35364 RVA: 0x001D6DDC File Offset: 0x001D4FDC
		public bool #IH(XmlSchema #O6d, string #P6d)
		{
			#X0d.#V0d(#O6d, #Phc.#3hc(107222305), Component.StorageFile, #Phc.#3hc(107222324));
			#X0d.#W0d(#P6d, #Phc.#3hc(107225761), Component.StorageFile, #Phc.#3hc(107221759));
			this.#V6d();
			return this.#X6d(#O6d, #P6d);
		}

		// Token: 0x06008A25 RID: 35365 RVA: 0x001D6E3C File Offset: 0x001D503C
		[SuppressMessage("Microsoft.Design", "CA1059:MembersShouldNotExposeCertainConcreteTypes", MessageId = "System.Xml.XmlNode", Justification = "Revieved. It is necessary.")]
		public bool #IH(XmlSchema #O6d, XmlDocument #Q6d)
		{
			#X0d.#V0d(#O6d, #Phc.#3hc(107222305), Component.StorageFile, #Phc.#3hc(107221674));
			#X0d.#V0d(#Q6d, #Phc.#3hc(107221653), Component.StorageFile, #Phc.#3hc(107221604));
			#X0d.#W0d(#Q6d.InnerXml, #Phc.#3hc(107221551), Component.StorageFile, #Phc.#3hc(107221554));
			this.#V6d();
			return this.#X6d(#O6d, #Q6d.InnerXml);
		}

		// Token: 0x06008A26 RID: 35366 RVA: 0x001D6EC0 File Offset: 0x001D50C0
		public bool #IH(string #So, XmlSchema #O6d)
		{
			#X0d.#V0d(#O6d, #Phc.#3hc(107222305), Component.StorageFile, #Phc.#3hc(107222013));
			#X0d.#W0d(#So, #Phc.#3hc(107226730), Component.StorageFile, #Phc.#3hc(107221928));
			if (!Alphaleonis.Win32.Filesystem.File.Exists(#So))
			{
				throw new #GYd(#So, #Phc.#3hc(107221907), Component.StorageFile, #IYd.#c);
			}
			this.#V6d();
			return this.#W6d(#So) && this.#X6d(#O6d, this.XmlDocument.InnerXml);
		}

		// Token: 0x1700289F RID: 10399
		// (get) Token: 0x06008A27 RID: 35367 RVA: 0x00070676 File Offset: 0x0006E876
		// (set) Token: 0x06008A28 RID: 35368 RVA: 0x00070682 File Offset: 0x0006E882
		public int ErrorsCount { get; private set; }

		// Token: 0x170028A0 RID: 10400
		// (get) Token: 0x06008A29 RID: 35369 RVA: 0x00070693 File Offset: 0x0006E893
		public string ErrorMessage
		{
			get
			{
				return this.#a.ToString();
			}
		}

		// Token: 0x170028A1 RID: 10401
		// (get) Token: 0x06008A2A RID: 35370 RVA: 0x000706A8 File Offset: 0x0006E8A8
		// (set) Token: 0x06008A2B RID: 35371 RVA: 0x000706B4 File Offset: 0x0006E8B4
		[SuppressMessage("Microsoft.Design", "CA1059:MembersShouldNotExposeCertainConcreteTypes", MessageId = "System.Xml.XmlNode", Justification = "Revieved. It is necessary.")]
		public XmlDocument XmlDocument { get; private set; }

		// Token: 0x06008A2C RID: 35372 RVA: 0x000706C5 File Offset: 0x0006E8C5
		private void #V6d()
		{
			this.XmlDocument = null;
			this.ErrorsCount = 0;
			this.#a = new StringBuilder();
		}

		// Token: 0x06008A2D RID: 35373 RVA: 0x001D6F54 File Offset: 0x001D5154
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Error messages are gathered in order to create a collective message.")]
		private bool #W6d(string #So)
		{
			bool result = true;
			try
			{
				using (FileStream fileStream = new FileStream(#So, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					XmlReader reader = XmlReader.Create(fileStream);
					this.XmlDocument = new XmlDocument();
					this.XmlDocument.Load(reader);
				}
				if (this.ErrorsCount > 0)
				{
					result = false;
				}
			}
			catch (Exception ex)
			{
				this.#a.AppendLine(Strings.StringAnErrorOccurredWhileReadingTheXmlFile.#z2d() + ex.Message);
				int num = this.ErrorsCount;
				this.ErrorsCount = num + 1;
				result = false;
			}
			return result;
		}

		// Token: 0x06008A2E RID: 35374 RVA: 0x001D700C File Offset: 0x001D520C
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Error messages are gathered in order to create a collective message.")]
		private bool #X6d(XmlSchema #O6d, string #P6d)
		{
			bool result = true;
			try
			{
				XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
				xmlReaderSettings.Schemas.Add(#O6d);
				xmlReaderSettings.ValidationType = ValidationType.Schema;
				xmlReaderSettings.ValidationEventHandler += this.#M6d;
				using (StringReader stringReader = new StringReader(#P6d))
				{
					XmlReader xmlReader = XmlReader.Create(stringReader, xmlReaderSettings);
					while (xmlReader.Read())
					{
					}
				}
				if (this.ErrorsCount > 0)
				{
					result = false;
				}
			}
			catch (Exception ex)
			{
				this.#a.AppendLine(Strings.StringAnErrorOccurredWhileValidatingTheXmlData.#z2d() + ex.Message);
				int num = this.ErrorsCount;
				this.ErrorsCount = num + 1;
				result = false;
			}
			return result;
		}

		// Token: 0x040038DA RID: 14554
		private StringBuilder #a;

		// Token: 0x040038DB RID: 14555
		[CompilerGenerated]
		private int #b;

		// Token: 0x040038DC RID: 14556
		[CompilerGenerated]
		private XmlDocument #c;
	}
}
