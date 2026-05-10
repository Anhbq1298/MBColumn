using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Threading;
using #cYd;
using #LQc;
using #sUd;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Logger;

namespace #FTd
{
	// Token: 0x02000E33 RID: 3635
	internal sealed class #ETd : #tUd
	{
		// Token: 0x0600826F RID: 33391 RVA: 0x0006A3B4 File Offset: 0x000685B4
		public #ETd(#8Sc #ls, ILogger #3x)
		{
			this.#a = #ls;
			this.#b = #3x;
		}

		// Token: 0x170026F3 RID: 9971
		// (get) Token: 0x06008270 RID: 33392 RVA: 0x0006A3CA File Offset: 0x000685CA
		public ILogger Logger { get; }

		// Token: 0x170026F4 RID: 9972
		// (get) Token: 0x06008271 RID: 33393 RVA: 0x001C3C6C File Offset: 0x001C1E6C
		private Window ParentWindow
		{
			get
			{
				Window result;
				Ignore.#14d<Exception, Window>(new Func<Window>(this.#DTd), out result, null);
				return result;
			}
		}

		// Token: 0x06008272 RID: 33394 RVA: 0x001C3C9C File Offset: 0x001C1E9C
		public void #3Ab(string #5, Exception #ob)
		{
			#ETd.#92b #92b = new #ETd.#92b();
			#92b.#a = #5;
			#92b.#b = this;
			this.Logger.Log(LoggingLevel.Error, new Func<string>(#92b.#9Wd), #ob);
			if (\u0010\u0002.~\u0082\u0004(\u0084\u0005.~\u001E\u000F(\u0098\u0002.\u000F\u0006())))
			{
				this.#CTd(#92b.#a);
				return;
			}
			\u009E\u0006.~\u0001\u0011(\u0084\u0005.~\u001E\u000F(\u0098\u0002.\u000F\u0006()), new Action(#92b.#aXd), DispatcherPriority.Normal, \u009D\u0006.\u009F\u0010());
		}

		// Token: 0x06008273 RID: 33395 RVA: 0x001C3D58 File Offset: 0x001C1F58
		public void #3Ab(Exception #ob)
		{
			#ETd.#W9b #W9b = new #ETd.#W9b();
			#W9b.#a = this;
			this.Logger.Log(LoggingLevel.Error, #ob);
			#W9b.#b = \u0010.\u0092(\u008E.\u0006\u0003().#z2d(), \u008E.\u0099\u0002(), #sYd.#oYd(#ob));
			if (\u0010\u0002.~\u0083\u0004(\u0098\u0002.\u000F\u0006()))
			{
				this.#CTd(#W9b.#b);
				return;
			}
			\u009E\u0006.~\u0001\u0011(\u0084\u0005.~\u001E\u000F(\u0098\u0002.\u000F\u0006()), new Action(#W9b.#9Wd), DispatcherPriority.Normal, \u009D\u0006.\u009F\u0010());
		}

		// Token: 0x06008274 RID: 33396 RVA: 0x0006A3D6 File Offset: 0x000685D6
		private void #CTd(string #5)
		{
			this.#a.#qn(this.ParentWindow, #5);
		}

		// Token: 0x06008275 RID: 33397 RVA: 0x0006A3F6 File Offset: 0x000685F6
		[CompilerGenerated]
		private Window #DTd()
		{
			Window result;
			if ((result = this.#a.ActiveWindow) == null)
			{
				result = this.#a.MainWindow;
			}
			return result;
		}

		// Token: 0x04003588 RID: 13704
		private readonly #8Sc #a;

		// Token: 0x04003589 RID: 13705
		[CompilerGenerated]
		private readonly ILogger #b;

		// Token: 0x02000E34 RID: 3636
		[CompilerGenerated]
		private sealed class #92b
		{
			// Token: 0x06008277 RID: 33399 RVA: 0x0006A41E File Offset: 0x0006861E
			internal string #9Wd()
			{
				return this.#a;
			}

			// Token: 0x06008278 RID: 33400 RVA: 0x0006A42A File Offset: 0x0006862A
			internal void #aXd()
			{
				this.#b.#CTd(this.#a);
			}

			// Token: 0x0400358A RID: 13706
			public string #a;

			// Token: 0x0400358B RID: 13707
			public #ETd #b;
		}

		// Token: 0x02000E35 RID: 3637
		[CompilerGenerated]
		private sealed class #W9b
		{
			// Token: 0x0600827A RID: 33402 RVA: 0x0006A449 File Offset: 0x00068649
			internal void #9Wd()
			{
				this.#a.#CTd(this.#b);
			}

			// Token: 0x0400358C RID: 13708
			public #ETd #a;

			// Token: 0x0400358D RID: 13709
			public string #b;
		}
	}
}
