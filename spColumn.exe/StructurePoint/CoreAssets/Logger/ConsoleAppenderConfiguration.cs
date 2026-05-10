using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace StructurePoint.CoreAssets.Logger
{
	// Token: 0x02000F19 RID: 3865
	[DataContract]
	public sealed class ConsoleAppenderConfiguration : AppenderConfigurationBase
	{
		// Token: 0x06008983 RID: 35203 RVA: 0x0006FF3E File Offset: 0x0006E13E
		public ConsoleAppenderConfiguration()
		{
		}

		// Token: 0x06008984 RID: 35204 RVA: 0x0006FF46 File Offset: 0x0006E146
		public ConsoleAppenderConfiguration(IEnumerable<LoggingLevel> loggingLevels) : base(loggingLevels)
		{
		}

		// Token: 0x06008985 RID: 35205 RVA: 0x0006FF46 File Offset: 0x0006E146
		public ConsoleAppenderConfiguration(params LoggingLevel[] loggingLevels) : base(loggingLevels)
		{
		}
	}
}
