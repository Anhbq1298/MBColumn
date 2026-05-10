using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using #7hc;

namespace #UYd
{
	// Token: 0x02000EC2 RID: 3778
	internal sealed class #uzc
	{
		// Token: 0x06008635 RID: 34357 RVA: 0x0006D489 File Offset: 0x0006B689
		public #uzc() : this(#Phc.#3hc(107227259))
		{
		}

		// Token: 0x06008636 RID: 34358 RVA: 0x0006D49B File Offset: 0x0006B69B
		public #uzc(string #wy)
		{
			this.Name = #wy;
			this.StartUpTime = DateTime.Now;
			this.FinishTime = this.StartUpTime;
		}

		// Token: 0x17002814 RID: 10260
		// (get) Token: 0x06008637 RID: 34359 RVA: 0x0006D4D7 File Offset: 0x0006B6D7
		// (set) Token: 0x06008638 RID: 34360 RVA: 0x0006D4DF File Offset: 0x0006B6DF
		public string Name { get; private set; }

		// Token: 0x17002815 RID: 10261
		// (get) Token: 0x06008639 RID: 34361 RVA: 0x0006D4E8 File Offset: 0x0006B6E8
		// (set) Token: 0x0600863A RID: 34362 RVA: 0x0006D4F0 File Offset: 0x0006B6F0
		public DateTime StartUpTime { get; private set; }

		// Token: 0x17002816 RID: 10262
		// (get) Token: 0x0600863B RID: 34363 RVA: 0x0006D4F9 File Offset: 0x0006B6F9
		// (set) Token: 0x0600863C RID: 34364 RVA: 0x0006D501 File Offset: 0x0006B701
		public DateTime FinishTime { get; private set; }

		// Token: 0x17002817 RID: 10263
		// (get) Token: 0x0600863D RID: 34365 RVA: 0x0006D50A File Offset: 0x0006B70A
		public TimeSpan Duration
		{
			get
			{
				return this.FinishTime - this.StartUpTime;
			}
		}

		// Token: 0x0600863E RID: 34366 RVA: 0x001CC4EC File Offset: 0x001CA6EC
		public void #szc(string #tzc)
		{
			object obj = this.#b;
			object obj2;
			if (2 != 0)
			{
				obj2 = obj;
			}
			bool flag = false;
			bool flag2;
			if (6 != 0)
			{
				flag2 = flag;
			}
			try
			{
				object obj3 = obj2;
				if (5 != 0)
				{
					Monitor.Enter(obj3, ref flag2);
				}
				DateTime now = DateTime.Now;
				DateTime dateTime;
				if (!false)
				{
					dateTime = now;
				}
				List<#uzc.#p8c> list = this.#c;
				#uzc.#p8c #p8c = new #uzc.#p8c();
				#p8c.Name = #tzc;
				#p8c.Start = this.FinishTime;
				#p8c.End = dateTime;
				DateTime dateTime2 = this.StartUpTime;
				if (!false)
				{
					#p8c.BenchmarkStart = dateTime2;
				}
				if (7 != 0)
				{
					list.Add(#p8c);
				}
				this.FinishTime = dateTime;
			}
			finally
			{
				do
				{
					if (flag2)
					{
						Monitor.Exit(obj2);
					}
				}
				while (3 == 0);
			}
		}

		// Token: 0x0600863F RID: 34367 RVA: 0x001CC59C File Offset: 0x001CA79C
		public string #h()
		{
			#uzc.#uZb #uZb = new #uzc.#uZb();
			#uzc.#uZb #uZb2;
			if (!false)
			{
				#uZb2 = #uZb;
			}
			#uZb2.#a = new StringBuilder();
			#uZb2.#a.AppendLine(string.Format(#Phc.#3hc(107227214), this.Name));
			object obj = this.#b;
			object obj2;
			if (!false)
			{
				obj2 = obj;
			}
			do
			{
				bool flag = false;
				bool flag2;
				if (!false)
				{
					flag2 = flag;
				}
				try
				{
					if (2 != 0)
					{
						object obj3 = obj2;
						if (true)
						{
							Monitor.Enter(obj3, ref flag2);
						}
						List<#uzc.#p8c> list = this.#c;
						Action<#uzc.#p8c> action = new Action<#uzc.#p8c>(#uZb2.#q8c);
						if (7 != 0)
						{
							list.ForEach(action);
						}
					}
				}
				finally
				{
					while (flag2)
					{
						if (!false)
						{
							if (!false)
							{
								Monitor.Exit(obj2);
								break;
							}
							break;
						}
					}
				}
			}
			while (false);
			StringBuilder stringBuilder = #uZb2.#a;
			string format = #Phc.#3hc(107227225);
			TimeSpan timeSpan = this.Duration;
			TimeSpan timeSpan2;
			if (-1 != 0)
			{
				timeSpan2 = timeSpan;
			}
			stringBuilder.AppendLine(string.Format(format, timeSpan2.ToString(#Phc.#3hc(107227196))));
			return #uZb2.#a.ToString();
		}

		// Token: 0x04003795 RID: 14229
		private const string #a = "hh\\:mm\\:ss\\.fff";

		// Token: 0x04003796 RID: 14230
		private readonly object #b = new object();

		// Token: 0x04003797 RID: 14231
		private readonly List<#uzc.#p8c> #c = new List<#uzc.#p8c>();

		// Token: 0x04003798 RID: 14232
		[CompilerGenerated]
		private string #d;

		// Token: 0x04003799 RID: 14233
		[CompilerGenerated]
		private DateTime #e;

		// Token: 0x0400379A RID: 14234
		[CompilerGenerated]
		private DateTime #f;

		// Token: 0x02000EC3 RID: 3779
		private sealed class #p8c
		{
			// Token: 0x17002818 RID: 10264
			// (get) Token: 0x06008640 RID: 34368 RVA: 0x0006D51D File Offset: 0x0006B71D
			// (set) Token: 0x06008641 RID: 34369 RVA: 0x0006D525 File Offset: 0x0006B725
			public DateTime BenchmarkStart { get; set; }

			// Token: 0x17002819 RID: 10265
			// (get) Token: 0x06008642 RID: 34370 RVA: 0x0006D52E File Offset: 0x0006B72E
			// (set) Token: 0x06008643 RID: 34371 RVA: 0x0006D536 File Offset: 0x0006B736
			public DateTime Start { get; set; }

			// Token: 0x1700281A RID: 10266
			// (get) Token: 0x06008644 RID: 34372 RVA: 0x0006D53F File Offset: 0x0006B73F
			// (set) Token: 0x06008645 RID: 34373 RVA: 0x0006D547 File Offset: 0x0006B747
			public DateTime End { get; set; }

			// Token: 0x1700281B RID: 10267
			// (get) Token: 0x06008646 RID: 34374 RVA: 0x0006D550 File Offset: 0x0006B750
			// (set) Token: 0x06008647 RID: 34375 RVA: 0x0006D558 File Offset: 0x0006B758
			public string Name { get; set; }

			// Token: 0x1700281C RID: 10268
			// (get) Token: 0x06008648 RID: 34376 RVA: 0x0006D561 File Offset: 0x0006B761
			private TimeSpan Duration
			{
				get
				{
					return this.End - this.Start;
				}
			}

			// Token: 0x06008649 RID: 34377 RVA: 0x001CC6A4 File Offset: 0x001CA8A4
			public string #h()
			{
				string format = #Phc.#3hc(107223582);
				TimeSpan timeSpan = this.End - this.BenchmarkStart;
				TimeSpan timeSpan2;
				if (!false)
				{
					timeSpan2 = timeSpan;
				}
				object arg = timeSpan2.ToString(#Phc.#3hc(107227196));
				TimeSpan timeSpan3 = this.Duration;
				if (8 != 0)
				{
					timeSpan2 = timeSpan3;
				}
				return string.Format(format, arg, timeSpan2.ToString(#Phc.#3hc(107227196)), this.Name);
			}

			// Token: 0x0400379B RID: 14235
			[CompilerGenerated]
			private DateTime #a;

			// Token: 0x0400379C RID: 14236
			[CompilerGenerated]
			private DateTime #b;

			// Token: 0x0400379D RID: 14237
			[CompilerGenerated]
			private DateTime #c;

			// Token: 0x0400379E RID: 14238
			[CompilerGenerated]
			private string #d;
		}

		// Token: 0x02000EC4 RID: 3780
		[CompilerGenerated]
		private sealed class #uZb
		{
			// Token: 0x0600864C RID: 34380 RVA: 0x0006D574 File Offset: 0x0006B774
			internal void #q8c(#uzc.#p8c #Rf)
			{
				this.#a.AppendLine(#Rf.ToString());
			}

			// Token: 0x0400379F RID: 14239
			public StringBuilder #a;
		}
	}
}
