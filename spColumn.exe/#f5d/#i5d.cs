using System;
using System.Collections.Generic;
using #7hc;
using log4net;
using log4net.Core;
using StructurePoint.CoreAssets.Logger;

namespace #f5d
{
	// Token: 0x02000F23 RID: 3875
	internal sealed class #i5d
	{
		// Token: 0x06008991 RID: 35217 RVA: 0x001D6038 File Offset: 0x001D4238
		public #i5d()
		{
			LevelMap levelMap = LogManager.GetRepository().LevelMap;
			levelMap.Add(this.#b);
			levelMap.Add(this.#c);
			levelMap.Add(this.#a);
			this.#d.Add(LoggingLevel.Debug, Level.Debug);
			this.#d.Add(LoggingLevel.Notification, this.#b);
			this.#d.Add(LoggingLevel.Error, Level.Error);
			this.#d.Add(LoggingLevel.Fatal, Level.Fatal);
			this.#d.Add(LoggingLevel.Warning, Level.Warn);
			this.#d.Add(LoggingLevel.ExtendedMessage, this.#c);
			this.#d.Add(LoggingLevel.BasicMessage, this.#a);
		}

		// Token: 0x17002889 RID: 10377
		// (get) Token: 0x06008992 RID: 35218 RVA: 0x0007000F File Offset: 0x0006E20F
		public static #i5d Instance
		{
			get
			{
				#i5d.#h5d();
				return #i5d.#e;
			}
		}

		// Token: 0x06008993 RID: 35219 RVA: 0x0007001F File Offset: 0x0006E21F
		public Level #g5d(LoggingLevel #rQb)
		{
			return this.#d[#rQb];
		}

		// Token: 0x06008994 RID: 35220 RVA: 0x001D614C File Offset: 0x001D434C
		public static void #h5d()
		{
			if (#i5d.#e == null)
			{
				object obj = #i5d.#f;
				lock (obj)
				{
					if (#i5d.#e == null)
					{
						#i5d.#e = new #i5d();
					}
				}
			}
		}

		// Token: 0x040038A8 RID: 14504
		private readonly Level #a = new Level(100000, #Phc.#3hc(107223493));

		// Token: 0x040038A9 RID: 14505
		private readonly Level #b = new Level(50000, #Phc.#3hc(107223504));

		// Token: 0x040038AA RID: 14506
		private readonly Level #c = new Level(40000, #Phc.#3hc(107223463));

		// Token: 0x040038AB RID: 14507
		private readonly Dictionary<LoggingLevel, Level> #d = new Dictionary<LoggingLevel, Level>();

		// Token: 0x040038AC RID: 14508
		private static #i5d #e = null;

		// Token: 0x040038AD RID: 14509
		private static readonly object #f = new object();
	}
}
