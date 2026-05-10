using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.Logger
{
	// Token: 0x02000F1C RID: 3868
	[DataContract]
	public sealed class FileAppenderConfiguration : AppenderConfigurationBase
	{
		// Token: 0x06008987 RID: 35207 RVA: 0x0006FF3E File Offset: 0x0006E13E
		public FileAppenderConfiguration()
		{
		}

		// Token: 0x06008988 RID: 35208 RVA: 0x0006FF7B File Offset: 0x0006E17B
		public FileAppenderConfiguration(string fileName, IEnumerable<LoggingLevel> loggingLevels) : base(loggingLevels)
		{
			#X0d.#W0d(fileName, #Phc.#3hc(107223157), Component.Logger, #Phc.#3hc(107223112));
			this.FileName = fileName;
		}

		// Token: 0x06008989 RID: 35209 RVA: 0x0006FFA6 File Offset: 0x0006E1A6
		public FileAppenderConfiguration(string fileName, params LoggingLevel[] loggingLevels) : base(loggingLevels)
		{
			#X0d.#W0d(fileName, #Phc.#3hc(107223157), Component.Logger, #Phc.#3hc(107223091));
			this.FileName = fileName;
		}

		// Token: 0x17002888 RID: 10376
		// (get) Token: 0x0600898A RID: 35210 RVA: 0x0006FFD1 File Offset: 0x0006E1D1
		// (set) Token: 0x0600898B RID: 35211 RVA: 0x0006FFDD File Offset: 0x0006E1DD
		[DataMember]
		public string FileName { get; private set; }
	}
}
