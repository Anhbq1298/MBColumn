using System;
using System.Runtime.CompilerServices;
using #7hc;
using #H1i;
using #w1i;
using #x1i;
using StructurePoint.Kernel.CoreAssets.Importer.Business;
using StructurePoint.Kernel.CoreAssets.Importer.Business.Xml_Files;
using StructurePoint.Kernel.CoreAssets.Importer.Core;
using StructurePoint.Kernel.CoreAssets.Importer.DataClasses;

namespace #k2i
{
	// Token: 0x02000E72 RID: 3698
	internal sealed class #26h : IDisposable
	{
		// Token: 0x170027A0 RID: 10144
		// (get) Token: 0x06008431 RID: 33841 RVA: 0x0006BB62 File Offset: 0x00069D62
		internal EtabsConnection Connection { get; } = new EtabsConnection();

		// Token: 0x06008432 RID: 33842 RVA: 0x001C79B8 File Offset: 0x001C5BB8
		public #26h(ProjectType #36h, string #N6h, string #51i, #a2i #61i = null)
		{
			if (!Logger.Configured)
			{
				Logger.#QQc(new #81i(#Phc.#3hc(107232901), #Phc.#3hc(107232868), #51i, #61i, #Phc.#3hc(107232843)));
			}
			this.ProjectType = #36h;
			this.EtabsProgramPath = #N6h;
			Logger.#pn(string.Format(#Phc.#3hc(107232834), new object[]
			{
				Environment.NewLine,
				#36h,
				Environment.NewLine,
				#N6h
			}).#Q1i(#Phc.#3hc(107464305), 1, true));
			string text = EtabsPathFinder.#j7i();
			if (text != null)
			{
				this.EtabsProgramPath = text;
				Logger.#ZSc(string.Concat(new string[]
				{
					#Phc.#3hc(107232781),
					Environment.NewLine,
					#Phc.#3hc(107350811),
					this.EtabsProgramPath,
					#Phc.#3hc(107350811)
				}).#Q1i(#Phc.#3hc(107464305), 1, true));
			}
		}

		// Token: 0x06008433 RID: 33843 RVA: 0x0006BB6A File Offset: 0x00069D6A
		public void #1()
		{
			this.#1(true);
		}

		// Token: 0x06008434 RID: 33844 RVA: 0x001C7AC8 File Offset: 0x001C5CC8
		protected void #1(bool #POb)
		{
			Logger.#DSi(string.Format(#Phc.#3hc(107233256), #POb, this.#c));
			try
			{
				if (!this.#c)
				{
					if (#POb)
					{
						this.#X6h();
						this.Connection.#1();
						Logger.#DSi(#Phc.#3hc(107233239));
					}
					this.#c = true;
				}
			}
			catch (Exception #N1i)
			{
				Logger.#qn(#Phc.#3hc(107233158), #N1i);
				throw;
			}
		}

		// Token: 0x170027A1 RID: 10145
		// (get) Token: 0x06008435 RID: 33845 RVA: 0x0006BB73 File Offset: 0x00069D73
		public ProjectType ProjectType { get; }

		// Token: 0x170027A2 RID: 10146
		// (get) Token: 0x06008436 RID: 33846 RVA: 0x0006BB7B File Offset: 0x00069D7B
		public string EtabsProgramPath { get; }

		// Token: 0x170027A3 RID: 10147
		// (get) Token: 0x06008437 RID: 33847 RVA: 0x0006BB83 File Offset: 0x00069D83
		// (set) Token: 0x06008438 RID: 33848 RVA: 0x0006BB8B File Offset: 0x00069D8B
		public ETABSProject Project { get; private set; }

		// Token: 0x06008439 RID: 33849 RVA: 0x001C7B54 File Offset: 0x001C5D54
		public bool #I6h()
		{
			bool result;
			try
			{
				result = this.Connection.#I6h();
			}
			catch (Exception #N1i)
			{
				Logger.#qn(#Phc.#3hc(107233145), #N1i);
				throw;
			}
			return result;
		}

		// Token: 0x0600843A RID: 33850 RVA: 0x0006BB94 File Offset: 0x00069D94
		private void #J6h()
		{
			Logger.#DSi(#Phc.#3hc(107233056));
			if (!this.Connection.Connected)
			{
				this.Connection.#M6h(this.EtabsProgramPath, true);
			}
		}

		// Token: 0x0600843B RID: 33851 RVA: 0x001C7B94 File Offset: 0x001C5D94
		public void #Y6h(string #Rtf, UnitsSystem #Z6h)
		{
			Logger.#DSi(#Phc.#3hc(107233035));
			try
			{
				try
				{
					this.#X6h();
					this.#J6h();
					EtabsProjectCore_API etabsProjectCore_API = new EtabsProjectCore_API(this.Connection);
					etabsProjectCore_API.#v7h(#Rtf, this.ProjectType, #Z6h);
					this.Project = new ETABSProject(etabsProjectCore_API);
				}
				catch (#C6h)
				{
					throw;
				}
				catch (Exception #Uic)
				{
					throw new #C6h(#Ab.SpImporterExceptionLoadFromEDBFailed_Unknown, #z6h.#c, #Uic);
				}
			}
			catch (Exception #N1i)
			{
				Logger.#qn(string.Concat(new string[]
				{
					#Phc.#3hc(107232506),
					Environment.NewLine,
					#Phc.#3hc(107232425),
					#Rtf,
					Environment.NewLine,
					string.Format(#Phc.#3hc(107232436), #Z6h)
				}).#Q1i(#Phc.#3hc(107464305), 1, true), #N1i);
				throw;
			}
		}

		// Token: 0x0600843C RID: 33852 RVA: 0x001C7C8C File Offset: 0x001C5E8C
		public void #06h(string #Rtf, UnitsSystem #Z6h)
		{
			Logger.#DSi(#Phc.#3hc(107232411));
			try
			{
				try
				{
					this.#X6h();
					this.#Y6h(#Rtf, #Z6h);
					ETABSProject etabsproject = new ETABSProject(new ETABSProjectCore_Ram(this.Project.Core));
					this.Project.#1();
					this.Project = etabsproject;
				}
				catch (#C6h)
				{
					throw;
				}
				catch (Exception #Uic)
				{
					throw new #C6h(#Ab.SpImporterExceptionLoadFromEDBFailed_Unknown, #z6h.#c, #Uic);
				}
			}
			catch (Exception #N1i)
			{
				Logger.#qn(string.Concat(new string[]
				{
					#Phc.#3hc(107232326),
					Environment.NewLine,
					#Phc.#3hc(107232425),
					#Rtf,
					Environment.NewLine,
					string.Format(#Phc.#3hc(107232436), #Z6h)
				}).#Q1i(#Phc.#3hc(107464305), 1, true), #N1i);
				throw;
			}
		}

		// Token: 0x0600843D RID: 33853 RVA: 0x001C7D88 File Offset: 0x001C5F88
		public void #16h(string #4Hc, UnitsSystem #Z6h)
		{
			Logger.#DSi(string.Concat(new string[]
			{
				#Phc.#3hc(107232309),
				Environment.NewLine,
				#Phc.#3hc(107232744),
				#4Hc,
				Environment.NewLine,
				string.Format(#Phc.#3hc(107232436), #Z6h)
			}).#Q1i(#Phc.#3hc(107464305), 1, true));
			try
			{
				try
				{
					this.#X6h();
					ETABSProjectCore_Ram core = EtabsProjectCoreXmlImporter.#GD(#4Hc, this.ProjectType, #Z6h);
					this.Project = new ETABSProject(core);
				}
				catch (#C6h)
				{
					throw;
				}
				catch (Exception #Uic)
				{
					throw new #C6h(#Ab.SpImporterExceptionLoadFromXMLFailed_Unknown, #z6h.#j, #Uic);
				}
			}
			catch (Exception #N1i)
			{
				Logger.#qn(#Phc.#3hc(107232759), #N1i);
				throw;
			}
			Logger.#DSi(#Phc.#3hc(107232726));
		}

		// Token: 0x0600843E RID: 33854 RVA: 0x0006BBC4 File Offset: 0x00069DC4
		private void #X6h()
		{
			if (this.Project != null)
			{
				Logger.#DSi(#Phc.#3hc(107232649));
				this.Project.#1();
				this.Project = null;
			}
		}

		// Token: 0x04003677 RID: 13943
		private const string #a = "spImporterLogRepository";

		// Token: 0x04003678 RID: 13944
		private const string #b = "spImporterLogger";

		// Token: 0x04003679 RID: 13945
		private bool #c;

		// Token: 0x0400367A RID: 13946
		[CompilerGenerated]
		private readonly EtabsConnection #d;

		// Token: 0x0400367B RID: 13947
		[CompilerGenerated]
		private readonly ProjectType #e;

		// Token: 0x0400367C RID: 13948
		[CompilerGenerated]
		private readonly string #f;

		// Token: 0x0400367D RID: 13949
		[CompilerGenerated]
		private ETABSProject #g;
	}
}
