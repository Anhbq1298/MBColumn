using System;
using #54d;

namespace StructurePoint.CoreAssets.Logger
{
	// Token: 0x02000873 RID: 2163
	public interface ILogger
	{
		// Token: 0x060044B1 RID: 17585
		void Log(LoggingLevel level, Func<string> messageProvider, Exception exception);

		// Token: 0x060044B2 RID: 17586
		void Log(LoggingLevel level, Func<string> messageProvider);

		// Token: 0x060044B3 RID: 17587
		void Log(LoggingLevel level, Exception exception);

		// Token: 0x060044B4 RID: 17588
		bool IsLoggingLevelEnabled(LoggingLevel level);

		// Token: 0x060044B5 RID: 17589
		void InstallExtension(#74d extension);

		// Token: 0x060044B6 RID: 17590
		void UninstallExtension(#74d extension);
	}
}
