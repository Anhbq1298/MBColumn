using System;
using #7hc;
using StructurePoint.CoreAssets.Logger;

namespace StructurePoint.CoreAssets.Column.Core.Core.Diagnostics
{
	// Token: 0x02000874 RID: 2164
	public static class Logger
	{
		// Token: 0x17001429 RID: 5161
		// (get) Token: 0x060044B7 RID: 17591 RVA: 0x00039446 File Offset: 0x00037646
		// (set) Token: 0x060044B8 RID: 17592 RVA: 0x0003944D File Offset: 0x0003764D
		public static ILogger Instance { get; private set; } = new LastChanceLogger();

		// Token: 0x060044B9 RID: 17593 RVA: 0x00039455 File Offset: 0x00037655
		public static void Configure(ILogger logProvider)
		{
			if (logProvider == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107455208));
			}
			Logger.Instance = logProvider;
		}

		// Token: 0x060044BA RID: 17594 RVA: 0x0013C208 File Offset: 0x0013A408
		public static void Warning(string message, Exception exception)
		{
			Logger.Instance.Log(LoggingLevel.Warning, () => message, exception);
		}

		// Token: 0x060044BB RID: 17595 RVA: 0x00039471 File Offset: 0x00037671
		public static void Error(Func<string> message)
		{
			Logger.Instance.Log(LoggingLevel.Error, message);
		}

		// Token: 0x060044BC RID: 17596 RVA: 0x0013C23C File Offset: 0x0013A43C
		public static void Error(string message, Exception exception)
		{
			Logger.Instance.Log(LoggingLevel.Error, () => message, exception);
		}

		// Token: 0x060044BD RID: 17597 RVA: 0x0003947F File Offset: 0x0003767F
		public static void Info(Func<string> message)
		{
			Logger.Instance.Log(LoggingLevel.ExtendedMessage, message);
		}

		// Token: 0x060044BE RID: 17598 RVA: 0x0003948D File Offset: 0x0003768D
		public static void Error(Exception exception)
		{
			Logger.Instance.Log(LoggingLevel.Error, exception);
		}

		// Token: 0x060044BF RID: 17599 RVA: 0x0003949B File Offset: 0x0003769B
		public static void Warning(Func<string> message)
		{
			Logger.Instance.Log(LoggingLevel.Warning, message);
		}

		// Token: 0x060044C0 RID: 17600 RVA: 0x000394A9 File Offset: 0x000376A9
		public static void Debug(Func<string> message)
		{
			Logger.Instance.Log(LoggingLevel.Debug, message);
		}

		// Token: 0x060044C1 RID: 17601 RVA: 0x000394B7 File Offset: 0x000376B7
		public static void Debug(Func<string> message, Exception exception)
		{
			Logger.Instance.Log(LoggingLevel.Debug, message, exception);
		}
	}
}
