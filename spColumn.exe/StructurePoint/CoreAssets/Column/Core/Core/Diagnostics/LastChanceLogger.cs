using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using #54d;
using #7hc;
using #cYd;
using StructurePoint.CoreAssets.Logger;

namespace StructurePoint.CoreAssets.Column.Core.Core.Diagnostics
{
	// Token: 0x02000870 RID: 2160
	public sealed class LastChanceLogger : ILogger
	{
		// Token: 0x17001426 RID: 5158
		// (get) Token: 0x0600449F RID: 17567 RVA: 0x000393B4 File Offset: 0x000375B4
		public static ILogger Instance
		{
			get
			{
				return LastChanceLogger.MyInstance.Value;
			}
		}

		// Token: 0x17001427 RID: 5159
		// (get) Token: 0x060044A0 RID: 17568 RVA: 0x000393C0 File Offset: 0x000375C0
		public static string DefaultDateTimeFormat
		{
			get
			{
				return #Phc.#3hc(107455839);
			}
		}

		// Token: 0x17001428 RID: 5160
		// (get) Token: 0x060044A1 RID: 17569 RVA: 0x000393CC File Offset: 0x000375CC
		// (set) Token: 0x060044A2 RID: 17570 RVA: 0x000393D3 File Offset: 0x000375D3
		public static string LogsPath { get; set; }

		// Token: 0x060044A3 RID: 17571 RVA: 0x000393DB File Offset: 0x000375DB
		public void Log(LoggingLevel level, Func<string> messageProvider, Exception exception)
		{
			this.Write(level.ToString(), messageProvider, exception);
		}

		// Token: 0x060044A4 RID: 17572 RVA: 0x000393F2 File Offset: 0x000375F2
		public void Log(LoggingLevel level, Func<string> messageProvider)
		{
			this.Write(level.ToString(), messageProvider, null);
		}

		// Token: 0x060044A5 RID: 17573 RVA: 0x0013C030 File Offset: 0x0013A230
		public void Log(LoggingLevel level, Exception exception)
		{
			this.Write(level.ToString(), () => #sYd.#oYd(exception), exception);
		}

		// Token: 0x060044A6 RID: 17574 RVA: 0x00003375 File Offset: 0x00001575
		public bool IsLoggingLevelEnabled(LoggingLevel level)
		{
			return true;
		}

		// Token: 0x060044A7 RID: 17575 RVA: 0x00009E6A File Offset: 0x0000806A
		public void InstallExtension(#74d extension)
		{
		}

		// Token: 0x060044A8 RID: 17576 RVA: 0x00009E6A File Offset: 0x0000806A
		public void UninstallExtension(#74d extension)
		{
		}

		// Token: 0x060044A9 RID: 17577 RVA: 0x0013C070 File Offset: 0x0013A270
		private void Write(string level, Func<string> message, Exception exception)
		{
			try
			{
				string name = Assembly.GetEntryAssembly().GetName().Name;
				string text = DateTime.Now.ToString(LastChanceLogger.DefaultDateTimeFormat);
				string text2 = (exception != null) ? (#Phc.#3hc(107382888) + Environment.NewLine + ((exception != null) ? exception.ToString() : null)) : string.Empty;
				string text3 = (message != null) ? message() : string.Empty;
				string value = string.Concat(new string[]
				{
					text,
					#Phc.#3hc(107382888),
					name,
					#Phc.#3hc(107382888),
					level,
					#Phc.#3hc(107382888),
					text3,
					#Phc.#3hc(107382888),
					text2,
					Environment.NewLine
				});
				using (FileStream fileStream = new FileStream(Path.Combine(LastChanceLogger.LogsPath, #Phc.#3hc(107455778)), FileMode.Append, FileAccess.Write, FileShare.Read))
				{
					using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
					{
						streamWriter.WriteLine();
						streamWriter.WriteLine(value);
					}
				}
			}
			catch (Exception #ob)
			{
				Console.WriteLine(#Phc.#3hc(107455749) + Environment.NewLine + #sYd.#rYd(#ob));
			}
		}

		// Token: 0x04001F29 RID: 7977
		private static readonly Lazy<LastChanceLogger> MyInstance = new Lazy<LastChanceLogger>(() => new LastChanceLogger(), LazyThreadSafetyMode.ExecutionAndPublication);
	}
}
