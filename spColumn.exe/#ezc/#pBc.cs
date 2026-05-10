using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using #7hc;
using #cYd;
using #IDc;
using #LQc;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;

namespace #ezc
{
	// Token: 0x02000B4A RID: 2890
	internal sealed class #pBc : #rBc
	{
		// Token: 0x06005E5A RID: 24154 RVA: 0x00177744 File Offset: 0x00175944
		public #pBc(ILogger #3x, #5Ic #qBc, #8Sc #ls)
		{
			if (#3x == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107408919));
			}
			this.#a = #3x;
			if (#qBc == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107401797));
			}
			this.#b = #qBc;
			if (#ls == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107409397));
			}
			this.#c = #ls;
		}

		// Token: 0x17001AC6 RID: 6854
		// (get) Token: 0x06005E5B RID: 24155 RVA: 0x001777A8 File Offset: 0x001759A8
		private Window ParentWindow
		{
			get
			{
				Window result;
				Ignore.#14d<Exception, Window>(new Func<Window>(this.#oBc), out result, null);
				return result;
			}
		}

		// Token: 0x06005E5C RID: 24156 RVA: 0x0004E86C File Offset: 0x0004CA6C
		public bool #lBc(string #5, Exception #ob, #3Hc #mBc)
		{
			int result;
			while (false || #ob is UnauthorizedAccessException)
			{
				if (!false)
				{
					this.#1Pb(#5, #ob, #mBc);
				}
				if (7 != 0)
				{
					result = 1;
					return result != 0;
				}
			}
			int num = result = 0;
			if (num == 0)
			{
				return num != 0;
			}
			return result != 0;
		}

		// Token: 0x06005E5D RID: 24157 RVA: 0x0004E894 File Offset: 0x0004CA94
		public void #bzc(Exception #ob, string #5, string #Qic, #3Hc #mBc)
		{
			if (!false)
			{
				this.#1Pb(#5, #ob, #mBc);
			}
		}

		// Token: 0x06005E5E RID: 24158 RVA: 0x0004E8A9 File Offset: 0x0004CAA9
		public void #bzc(Exception #ob, #3Hc #Ic)
		{
			string # = Strings.StringAnUnknownErrorOccrued.#z2d();
			string #Qic = null;
			if (!false)
			{
				this.#bzc(#ob, #, #Qic, #Ic);
			}
		}

		// Token: 0x06005E5F RID: 24159 RVA: 0x0004E8C8 File Offset: 0x0004CAC8
		public void #bzc(Exception #ob, string #Qic, #3Hc #Ic)
		{
			string # = Strings.StringAnUnknownErrorOccrued.#z2d();
			if (!false)
			{
				this.#bzc(#ob, #, #Qic, #Ic);
			}
		}

		// Token: 0x06005E60 RID: 24160 RVA: 0x0004E8E7 File Offset: 0x0004CAE7
		public void #bzc(string #5, Exception #ob, #3Hc #Ic)
		{
			string empty = string.Empty;
			if (7 != 0)
			{
				this.#bzc(#ob, #5, empty, #Ic);
			}
		}

		// Token: 0x06005E61 RID: 24161 RVA: 0x0004E901 File Offset: 0x0004CB01
		public void #1Pb(string #5, Exception #ob)
		{
			string empty = string.Empty;
			#3Hc #mBc = #3Hc.#2Hc(string.Empty);
			if (!false)
			{
				this.#bzc(#ob, #5, empty, #mBc);
			}
		}

		// Token: 0x06005E62 RID: 24162 RVA: 0x001777CC File Offset: 0x001759CC
		private static string #nBc(string #5, #3Hc #mBc)
		{
			if (3 == 0 || #5 != null)
			{
				while (#mBc != null)
				{
					string text = #5.#O2d();
					string text2;
					if (!false)
					{
						text2 = text;
					}
					if (-1 == 0 || !string.IsNullOrWhiteSpace(#mBc.CallerInfo))
					{
						if (false)
						{
							return text2;
						}
						if (false)
						{
							continue;
						}
						string text3 = text2 + #Phc.#3hc(107417850) + #mBc.CallerInfo.#z2d(true);
						if (!false)
						{
							text2 = text3;
						}
					}
					if (!string.IsNullOrWhiteSpace(#mBc.FilePath))
					{
						string text4 = text2 + #Phc.#3hc(107417797) + #mBc.FilePath.#z2d();
						if (!false)
						{
							text2 = text4;
						}
					}
					return text2;
				}
			}
			return #5;
		}

		// Token: 0x06005E63 RID: 24163 RVA: 0x0017785C File Offset: 0x00175A5C
		private void #1Pb(string #5, Exception #ob, #3Hc #mBc)
		{
			#pBc.#BUb #BUb = new #pBc.#BUb();
			#pBc.#BUb #BUb2;
			if (!false)
			{
				#BUb2 = #BUb;
			}
			#BUb2.#b = this;
			#BUb2.#a = #pBc.#nBc(#5, #mBc);
			ILogger logger = this.#a;
			LoggingLevel level = LoggingLevel.Error;
			Func<string> messageProvider = new Func<string>(#BUb2.#A8c);
			if (5 != 0)
			{
				logger.Log(level, messageProvider, #ob);
			}
			#5Ic #5Ic = this.#b;
			if (3 != 0)
			{
				#5Ic.#2Ic(#mBc, #5, #ob);
			}
			if (!#jzc.#izc())
			{
				#pBc.#C8c #C8c = new #pBc.#C8c();
				#pBc.#C8c #C8c2;
				if (5 != 0)
				{
					#C8c2 = #C8c;
				}
				#C8c2.#b = #BUb2;
				string text = (#ob is #FYd) ? #sYd.#nYd(#ob) : #sYd.#oYd(#ob);
				string #f;
				if (7 != 0)
				{
					#f = text;
				}
				#C8c2.#a = #5 + Environment.NewLine + Environment.NewLine + #f.#A2d();
				if (Application.Current.CheckAccess())
				{
					#8Sc #8Sc = this.#c;
					Window #WSc = this.ParentWindow;
					string #SSc = #C8c2.#a;
					if (!false)
					{
						#8Sc.#qn(#WSc, #SSc);
					}
					return;
				}
				Application.Current.Dispatcher.Invoke(new Action(#C8c2.#B8c), DispatcherPriority.Normal, CancellationToken.None);
			}
		}

		// Token: 0x06005E64 RID: 24164 RVA: 0x0004E924 File Offset: 0x0004CB24
		[CompilerGenerated]
		private Window #oBc()
		{
			return this.#c.ActiveWindow ?? this.#c.MainWindow;
		}

		// Token: 0x0400271A RID: 10010
		private readonly ILogger #a;

		// Token: 0x0400271B RID: 10011
		private readonly #5Ic #b;

		// Token: 0x0400271C RID: 10012
		private readonly #8Sc #c;

		// Token: 0x02000B4B RID: 2891
		[CompilerGenerated]
		private sealed class #BUb
		{
			// Token: 0x06005E66 RID: 24166 RVA: 0x0004E940 File Offset: 0x0004CB40
			internal string #A8c()
			{
				return this.#a;
			}

			// Token: 0x0400271D RID: 10013
			public string #a;

			// Token: 0x0400271E RID: 10014
			public #pBc #b;
		}

		// Token: 0x02000B4C RID: 2892
		[CompilerGenerated]
		private sealed class #C8c
		{
			// Token: 0x06005E68 RID: 24168 RVA: 0x0004E948 File Offset: 0x0004CB48
			internal void #B8c()
			{
				do
				{
					if (!false)
					{
						#8Sc #c = this.#b.#b.#c;
						Window #WSc = this.#b.#b.ParentWindow;
						string #SSc = this.#a;
						if (!false)
						{
							#c.#qn(#WSc, #SSc);
						}
					}
				}
				while (false);
			}

			// Token: 0x0400271F RID: 10015
			public string #a;

			// Token: 0x04002720 RID: 10016
			public #pBc.#BUb #b;
		}
	}
}
