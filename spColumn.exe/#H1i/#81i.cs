using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using #7hc;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Filter;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace #H1i
{
	// Token: 0x02000E6C RID: 3692
	internal sealed class #81i : #L1i
	{
		// Token: 0x06008403 RID: 33795 RVA: 0x0006B9EF File Offset: 0x00069BEF
		public #81i(string #41i, string #91i, string #51i, #a2i #61i, string #71i)
		{
			#81i.#QQc(#41i, #51i, #61i, #71i);
			if (string.IsNullOrWhiteSpace(#41i))
			{
				#41i = LogManager.GetRepository().Name;
			}
			this.#c = LogManager.GetLogger(#41i, #91i);
		}

		// Token: 0x06008404 RID: 33796 RVA: 0x001C6878 File Offset: 0x001C4A78
		public static string #U1i(string #V1i)
		{
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), #V1i);
			string result;
			try
			{
				#81i.#W1i(text);
				result = text;
			}
			catch (Exception)
			{
				text = Path.Combine(Path.GetTempPath(), #V1i);
				try
				{
					#81i.#W1i(text);
					result = text;
				}
				catch (Exception innerException)
				{
					throw new Exception(#Phc.#3hc(107268508), innerException);
				}
			}
			return result;
		}

		// Token: 0x06008405 RID: 33797 RVA: 0x001C68E4 File Offset: 0x001C4AE4
		private static void #W1i(string #nTg)
		{
			Directory.CreateDirectory(#nTg);
			string path = Path.Combine(#nTg, #Phc.#3hc(107268427));
			using (File.Open(path, FileMode.OpenOrCreate, FileAccess.Write))
			{
			}
			File.Delete(path);
		}

		// Token: 0x06008406 RID: 33798 RVA: 0x001C6934 File Offset: 0x001C4B34
		public void #nb(#K1i #5)
		{
			try
			{
				if (this.#c.IsErrorEnabled)
				{
					this.#c.Error(#5());
				}
			}
			catch (Exception ex)
			{
				string str = #Phc.#3hc(107268446);
				Exception ex2 = ex;
				Trace.WriteLine(str + ((ex2 != null) ? ex2.ToString() : null));
			}
		}

		// Token: 0x06008407 RID: 33799 RVA: 0x001C6998 File Offset: 0x001C4B98
		public void #nb(string #5, Exception #ob)
		{
			try
			{
				if (this.#c.IsErrorEnabled)
				{
					this.#c.Error(#5, #ob);
				}
			}
			catch (Exception ex)
			{
				string str = #Phc.#3hc(107268446);
				Exception ex2 = ex;
				Trace.WriteLine(str + ((ex2 != null) ? ex2.ToString() : null));
			}
		}

		// Token: 0x06008408 RID: 33800 RVA: 0x001C69F8 File Offset: 0x001C4BF8
		public void #pb(string #5)
		{
			try
			{
				if (this.#c.IsInfoEnabled)
				{
					this.#c.Info(#5);
				}
			}
			catch (Exception ex)
			{
				string str = #Phc.#3hc(107268446);
				Exception ex2 = ex;
				Trace.WriteLine(str + ((ex2 != null) ? ex2.ToString() : null));
			}
		}

		// Token: 0x06008409 RID: 33801 RVA: 0x001C6A54 File Offset: 0x001C4C54
		public void #Rjc(string #5)
		{
			try
			{
				if (this.#c.IsWarnEnabled)
				{
					this.#c.Warn(#5);
				}
			}
			catch (Exception ex)
			{
				string str = #Phc.#3hc(107268446);
				Exception ex2 = ex;
				Trace.WriteLine(str + ((ex2 != null) ? ex2.ToString() : null));
			}
		}

		// Token: 0x0600840A RID: 33802 RVA: 0x001C6AB0 File Offset: 0x001C4CB0
		public void #qb(string #5)
		{
			try
			{
				if (this.#c.IsDebugEnabled)
				{
					this.#c.Debug(#5);
				}
			}
			catch (Exception ex)
			{
				string str = #Phc.#3hc(107268446);
				Exception ex2 = ex;
				Trace.WriteLine(str + ((ex2 != null) ? ex2.ToString() : null));
			}
		}

		// Token: 0x0600840B RID: 33803 RVA: 0x001C6B0C File Offset: 0x001C4D0C
		public void #pb(#K1i #5)
		{
			try
			{
				if (this.#c.IsInfoEnabled)
				{
					this.#c.Info(#5());
				}
			}
			catch (Exception ex)
			{
				string str = #Phc.#3hc(107268446);
				Exception ex2 = ex;
				Trace.WriteLine(str + ((ex2 != null) ? ex2.ToString() : null));
			}
		}

		// Token: 0x0600840C RID: 33804 RVA: 0x001C6B70 File Offset: 0x001C4D70
		public void #nb(Exception #ob)
		{
			try
			{
				if (this.#c.IsErrorEnabled)
				{
					this.#c.Error(null, #ob);
				}
			}
			catch (Exception ex)
			{
				string str = #Phc.#3hc(107268446);
				Exception ex2 = ex;
				Trace.WriteLine(str + ((ex2 != null) ? ex2.ToString() : null));
			}
		}

		// Token: 0x0600840D RID: 33805 RVA: 0x001C6BD0 File Offset: 0x001C4DD0
		public void #Rjc(#K1i #5)
		{
			try
			{
				if (this.#c.IsWarnEnabled)
				{
					this.#c.Warn(#5());
				}
			}
			catch (Exception ex)
			{
				string str = #Phc.#3hc(107268446);
				Exception ex2 = ex;
				Trace.WriteLine(str + ((ex2 != null) ? ex2.ToString() : null));
			}
		}

		// Token: 0x0600840E RID: 33806 RVA: 0x001C6C34 File Offset: 0x001C4E34
		public void #Rjc(string #5, Exception #ob)
		{
			try
			{
				if (this.#c.IsWarnEnabled)
				{
					this.#c.Warn(#5, #ob);
				}
			}
			catch (Exception ex)
			{
				string str = #Phc.#3hc(107268446);
				Exception ex2 = ex;
				Trace.WriteLine(str + ((ex2 != null) ? ex2.ToString() : null));
			}
		}

		// Token: 0x0600840F RID: 33807 RVA: 0x001C6C94 File Offset: 0x001C4E94
		public void #qb(#K1i #5)
		{
			try
			{
				if (this.#c.IsDebugEnabled)
				{
					this.#c.Debug(#5());
				}
			}
			catch (Exception ex)
			{
				string str = #Phc.#3hc(107268446);
				Exception ex2 = ex;
				Trace.WriteLine(str + ((ex2 != null) ? ex2.ToString() : null));
			}
		}

		// Token: 0x06008410 RID: 33808 RVA: 0x001C6CF8 File Offset: 0x001C4EF8
		private static void #X1i(AppenderSkeleton #p5d, IFilter #c7c, bool #Y1i, PatternLayout #Z1i)
		{
			#p5d.Layout = #Z1i;
			#p5d.AddFilter(#c7c);
			if (#Y1i)
			{
				DenyAllFilter denyAllFilter = new DenyAllFilter();
				denyAllFilter.ActivateOptions();
				#p5d.AddFilter(denyAllFilter);
			}
			#p5d.ActivateOptions();
		}

		// Token: 0x06008411 RID: 33809 RVA: 0x001C6D30 File Offset: 0x001C4F30
		private static RollingFileAppender #01i(string #nTg, string #11i, FileAppender.LockingModelBase #21i, IFilter #c7c, PatternLayout #Z1i, bool #Y1i = false)
		{
			RollingFileAppender rollingFileAppender = new RollingFileAppender();
			rollingFileAppender.AppendToFile = true;
			rollingFileAppender.Encoding = Encoding.UTF8;
			rollingFileAppender.File = #nTg;
			rollingFileAppender.DatePattern = #Phc.#3hc(107348305) + #11i + #Phc.#3hc(107268405);
			rollingFileAppender.StaticLogFileName = false;
			rollingFileAppender.RollingStyle = RollingFileAppender.RollingMode.Date;
			rollingFileAppender.LockingModel = #21i;
			rollingFileAppender.ImmediateFlush = true;
			#81i.#X1i(rollingFileAppender, #c7c, #Y1i, #Z1i);
			return rollingFileAppender;
		}

		// Token: 0x06008412 RID: 33810 RVA: 0x0006BA23 File Offset: 0x00069C23
		private static #J1i #31i(#a2i #nd, IFilter #c7c, PatternLayout #Z1i, bool #Y1i = false)
		{
			#J1i #J1i = new #J1i(#nd);
			#81i.#X1i(#J1i, #c7c, #Y1i, #Z1i);
			return #J1i;
		}

		// Token: 0x06008413 RID: 33811 RVA: 0x001C6DA4 File Offset: 0x001C4FA4
		private static void #QQc(string #41i, string #51i, #a2i #61i, string #71i)
		{
			PatternLayout patternLayout = new PatternLayout(#Phc.#3hc(107268380));
			patternLayout.ActivateOptions();
			PatternLayout patternLayout2 = new PatternLayout(#Phc.#3hc(107267755));
			patternLayout2.ActivateOptions();
			LevelRangeFilter levelRangeFilter = new LevelRangeFilter
			{
				LevelMin = Level.All,
				LevelMax = Level.Warn
			};
			LevelRangeFilter #c7c = new LevelRangeFilter
			{
				LevelMin = Level.Error,
				LevelMax = Level.Off
			};
			levelRangeFilter.ActivateOptions();
			Hierarchy hierarchy = (Hierarchy)(string.IsNullOrWhiteSpace(#41i) ? LogManager.GetRepository() : LogManager.CreateRepository(#41i, typeof(Hierarchy)));
			hierarchy.Root.RemoveAllAppenders();
			if (!string.IsNullOrEmpty(#51i))
			{
				#81i.#i4i #21i = new #81i.#i4i();
				string #nTg = #51i.TrimEnd(new char[]
				{
					Path.DirectorySeparatorChar
				}) + Path.DirectorySeparatorChar.ToString();
				try
				{
					#81i.#W1i(#nTg);
				}
				catch
				{
					#nTg = #81i.#U1i(#Phc.#3hc(107267617));
				}
				hierarchy.Root.AddAppender(#81i.#01i(#nTg, #71i, #21i, levelRangeFilter, patternLayout, false));
				hierarchy.Root.AddAppender(#81i.#01i(#nTg, #71i, #21i, #c7c, patternLayout2, false));
			}
			if (#61i != null)
			{
				hierarchy.Root.AddAppender(#81i.#31i(#61i, levelRangeFilter, patternLayout, false));
				hierarchy.Root.AddAppender(#81i.#31i(#61i, #c7c, patternLayout2, false));
			}
			hierarchy.Root.Level = Level.All;
			hierarchy.Configured = true;
		}

		// Token: 0x0400366B RID: 13931
		private const string #a = "%date{yyyy-MM-dd HH:mm:ss.fff} %-5level - %message%newline";

		// Token: 0x0400366C RID: 13932
		private const string #b = "%date{yyyy-MM-dd HH:mm:ss.fff} %-5level - %message%newline\t%exception%newline\t%stacktrace{10}%newline";

		// Token: 0x0400366D RID: 13933
		private readonly ILog #c;

		// Token: 0x02000E6D RID: 3693
		private sealed class #i4i : FileAppender.MinimalLock
		{
			// Token: 0x06008414 RID: 33812 RVA: 0x0006BA34 File Offset: 0x00069C34
			public void #g4i()
			{
				if (!this.#a)
				{
					base.CloseFile();
					if (!this.#h4i(base.CurrentAppender.File))
					{
						File.Delete(base.CurrentAppender.File);
					}
					this.#a = true;
				}
			}

			// Token: 0x06008415 RID: 33813 RVA: 0x001C6F2C File Offset: 0x001C512C
			private bool #h4i(string #4Hc)
			{
				bool result = false;
				string input = File.ReadAllText(#4Hc);
				if (new Regex(#Phc.#3hc(107228593)).IsMatch(input))
				{
					result = true;
				}
				return result;
			}

			// Token: 0x0400366E RID: 13934
			private bool #a;
		}
	}
}
