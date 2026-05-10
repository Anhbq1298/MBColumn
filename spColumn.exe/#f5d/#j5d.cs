using System;
using System.Collections.Generic;
using #54d;
using #7hc;
using log4net;
using log4net.Core;
using StructurePoint.CoreAssets.Logger;

namespace #f5d
{
	// Token: 0x02000F24 RID: 3876
	internal sealed class #j5d : StructurePoint.CoreAssets.Logger.ILogger
	{
		// Token: 0x06008996 RID: 35222 RVA: 0x0007004F File Offset: 0x0006E24F
		public #j5d()
		{
			#i5d.#h5d();
			this.#a = LogManager.GetLogger(string.Empty);
		}

		// Token: 0x06008997 RID: 35223 RVA: 0x001D61AC File Offset: 0x001D43AC
		public void Log(LoggingLevel level, Func<string> messageProvider, Exception exception)
		{
			Level level2 = #i5d.Instance.#g5d(level);
			if (this.#a.Logger.IsEnabledFor(level2))
			{
				string message = (messageProvider == null) ? string.Empty : messageProvider();
				using (List<#74d>.Enumerator enumerator = this.#b.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.#qQb(level, ref message, exception) != #84d.#a)
						{
							return;
						}
					}
				}
				this.#a.Logger.Log(typeof(#j5d), level2, message, exception);
			}
		}

		// Token: 0x06008998 RID: 35224 RVA: 0x00070077 File Offset: 0x0006E277
		public void Log(LoggingLevel level, Func<string> messageProvider)
		{
			this.Log(level, messageProvider, null);
		}

		// Token: 0x06008999 RID: 35225 RVA: 0x0007008E File Offset: 0x0006E28E
		public void Log(LoggingLevel level, Exception exception)
		{
			this.Log(level, null, exception);
		}

		// Token: 0x0600899A RID: 35226 RVA: 0x001D6270 File Offset: 0x001D4470
		public bool IsLoggingLevelEnabled(LoggingLevel level)
		{
			Level level2 = #i5d.Instance.#g5d(level);
			return this.#a.Logger.IsEnabledFor(level2);
		}

		// Token: 0x0600899B RID: 35227 RVA: 0x000700A5 File Offset: 0x0006E2A5
		public void InstallExtension(#74d extension)
		{
			if (extension == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107420068));
			}
			if (!this.#b.Contains(extension))
			{
				this.#b.Add(extension);
			}
		}

		// Token: 0x0600899C RID: 35228 RVA: 0x000700E0 File Offset: 0x0006E2E0
		public void UninstallExtension(#74d extension)
		{
			if (extension == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107420068));
			}
			this.#b.Remove(extension);
		}

		// Token: 0x0600899D RID: 35229 RVA: 0x0007010E File Offset: 0x0006E30E
		public void #lGd()
		{
			LogManager.Flush(2500);
		}

		// Token: 0x040038AE RID: 14510
		private readonly ILog #a;

		// Token: 0x040038AF RID: 14511
		private readonly List<#74d> #b = new List<#74d>();
	}
}
