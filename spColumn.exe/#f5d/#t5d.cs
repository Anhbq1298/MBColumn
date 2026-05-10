using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using #54d;
using #7hc;
using #cYd;
using #UYd;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Filter;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using log4net.Util;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Logger;

namespace #f5d
{
	// Token: 0x02000F25 RID: 3877
	internal sealed class #t5d : #b5d
	{
		// Token: 0x0600899E RID: 35230 RVA: 0x0007011F File Offset: 0x0006E31F
		public #t5d()
		{
			#i5d.#h5d();
			GlobalContext.Properties[#Phc.#3hc(107223438)] = Process.GetCurrentProcess().Id;
			this.#a = (Hierarchy)LogManager.GetRepository();
		}

		// Token: 0x0600899F RID: 35231 RVA: 0x001D62A8 File Offset: 0x001D44A8
		public void #94d(IEnumerable<AppenderConfigurationBase> #a5d)
		{
			#X0d.#V0d(#a5d, #Phc.#3hc(107223433), Component.LoggerLog4Net, #Phc.#3hc(107223400));
			this.#a.Configured = false;
			this.#k5d();
			this.#a.Root.Level = #i5d.Instance.#g5d(LoggingLevel.BasicMessage);
			foreach (AppenderConfigurationBase #m5d in #a5d)
			{
				this.#l5d(#m5d);
			}
			this.#a.Configured = true;
		}

		// Token: 0x060089A0 RID: 35232 RVA: 0x0007015F File Offset: 0x0006E35F
		private void #k5d()
		{
			this.#a.Root.RemoveAllAppenders();
		}

		// Token: 0x060089A1 RID: 35233 RVA: 0x001D6360 File Offset: 0x001D4560
		private void #l5d(AppenderConfigurationBase #m5d)
		{
			AppenderSkeleton appenderSkeleton = #t5d.#n5d(#m5d);
			this.#o5d(#m5d, appenderSkeleton);
			appenderSkeleton.Layout = #t5d.#q5d();
			appenderSkeleton.ActivateOptions();
			this.#a.Root.AddAppender(appenderSkeleton);
		}

		// Token: 0x060089A2 RID: 35234 RVA: 0x001D63AC File Offset: 0x001D45AC
		private static AppenderSkeleton #n5d(AppenderConfigurationBase #m5d)
		{
			AppenderSkeleton appenderSkeleton = null;
			FileAppenderConfiguration fileAppenderConfiguration = #m5d as FileAppenderConfiguration;
			FileAppenderConfiguration fileAppenderConfiguration2;
			if (4 != 0)
			{
				fileAppenderConfiguration2 = fileAppenderConfiguration;
			}
			if (fileAppenderConfiguration2 != null)
			{
				appenderSkeleton = #t5d.#s5d(fileAppenderConfiguration2);
			}
			if (#m5d is ConsoleAppenderConfiguration)
			{
				appenderSkeleton = #t5d.#r5d();
			}
			if (appenderSkeleton == null)
			{
				throw new #64d(#m5d.GetType().Name, #Phc.#3hc(107223379), Component.LoggerLog4Net, #IYd.#e);
			}
			return appenderSkeleton;
		}

		// Token: 0x060089A3 RID: 35235 RVA: 0x001D640C File Offset: 0x001D460C
		private void #o5d(AppenderConfigurationBase #m5d, AppenderSkeleton #p5d)
		{
			foreach (LoggingLevel #rQb in #m5d.Levels)
			{
				Level level = #i5d.Instance.#g5d(#rQb);
				#p5d.AddFilter(new LevelMatchFilter
				{
					LevelToMatch = level,
					AcceptOnMatch = true
				});
				if (this.#a.Root.Level.Value > level.Value)
				{
					this.#a.Root.Level = level;
				}
			}
			#p5d.AddFilter(new DenyAllFilter());
		}

		// Token: 0x060089A4 RID: 35236 RVA: 0x001D64D0 File Offset: 0x001D46D0
		private static PatternLayout #q5d()
		{
			PatternLayout patternLayout = new PatternLayout();
			patternLayout.ConversionPattern = #Phc.#3hc(107223326);
			patternLayout.IgnoresException = false;
			patternLayout.AddConverter(new ConverterInfo
			{
				Name = #Phc.#3hc(107222669),
				Type = typeof(#v5d)
			});
			patternLayout.ActivateOptions();
			return patternLayout;
		}

		// Token: 0x060089A5 RID: 35237 RVA: 0x0007017D File Offset: 0x0006E37D
		private static AppenderSkeleton #r5d()
		{
			return new ConsoleAppender();
		}

		// Token: 0x060089A6 RID: 35238 RVA: 0x001D6538 File Offset: 0x001D4738
		private static AppenderSkeleton #s5d(FileAppenderConfiguration #m5d)
		{
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(#m5d.FileName);
			string extension = Path.GetExtension(#m5d.FileName);
			string file = Path.Combine(Path.GetDirectoryName(#m5d.FileName), fileNameWithoutExtension);
			return new RollingFileAppender
			{
				AppendToFile = true,
				StaticLogFileName = false,
				File = file,
				RollingStyle = RollingFileAppender.RollingMode.Date,
				DatePattern = #Phc.#3hc(107222680) + extension + #Phc.#3hc(107348305),
				LockingModel = new FileAppender.MinimalLock(),
				MaxSizeRollBackups = 12,
				Encoding = Encoding.UTF8,
				ImmediateFlush = true
			};
		}

		// Token: 0x040038B0 RID: 14512
		private readonly Hierarchy #a;
	}
}
