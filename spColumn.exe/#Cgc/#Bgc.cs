using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using #7hc;
using #Yfc;

namespace #Cgc
{
	// Token: 0x02000725 RID: 1829
	internal sealed class #Bgc : INotifyPropertyChanged
	{
		// Token: 0x140000D9 RID: 217
		// (add) Token: 0x06003C36 RID: 15414 RVA: 0x00119304 File Offset: 0x00117504
		// (remove) Token: 0x06003C37 RID: 15415 RVA: 0x0011936C File Offset: 0x0011756C
		public event PropertyChangedEventHandler PropertyChanged
		{
			[CompilerGenerated]
			add
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.#a;
				for (;;)
				{
					PropertyChangedEventHandler propertyChangedEventHandler2 = propertyChangedEventHandler;
					for (;;)
					{
						PropertyChangedEventHandler propertyChangedEventHandler3 = (PropertyChangedEventHandler)\u008D.\u0097\u0002(propertyChangedEventHandler2, value);
						PropertyChangedEventHandler value2;
						if (4 != 0)
						{
							value2 = propertyChangedEventHandler3;
						}
						propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.#a, value2, propertyChangedEventHandler2);
						if (propertyChangedEventHandler != propertyChangedEventHandler2)
						{
							break;
						}
						if (!false && !false)
						{
							return;
						}
					}
				}
			}
			[CompilerGenerated]
			remove
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.#a;
				for (;;)
				{
					PropertyChangedEventHandler propertyChangedEventHandler2 = propertyChangedEventHandler;
					for (;;)
					{
						PropertyChangedEventHandler propertyChangedEventHandler3 = (PropertyChangedEventHandler)\u008D.\u0098\u0002(propertyChangedEventHandler2, value);
						PropertyChangedEventHandler value2;
						if (4 != 0)
						{
							value2 = propertyChangedEventHandler3;
						}
						propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.#a, value2, propertyChangedEventHandler2);
						if (propertyChangedEventHandler != propertyChangedEventHandler2)
						{
							break;
						}
						if (!false && !false)
						{
							return;
						}
					}
				}
			}
		}

		// Token: 0x17001241 RID: 4673
		// (get) Token: 0x06003C38 RID: 15416 RVA: 0x00034061 File Offset: 0x00032261
		// (set) Token: 0x06003C39 RID: 15417 RVA: 0x0003406D File Offset: 0x0003226D
		public string TrialButtonMessage { get; private set; }

		// Token: 0x17001242 RID: 4674
		// (get) Token: 0x06003C3A RID: 15418 RVA: 0x0003407E File Offset: 0x0003227E
		// (set) Token: 0x06003C3B RID: 15419 RVA: 0x0003408A File Offset: 0x0003228A
		public string RequestLicenseButtonMessage { get; private set; }

		// Token: 0x17001243 RID: 4675
		// (get) Token: 0x06003C3C RID: 15420 RVA: 0x0003409B File Offset: 0x0003229B
		// (set) Token: 0x06003C3D RID: 15421 RVA: 0x000340A7 File Offset: 0x000322A7
		public string ActivateLicenseButtonMessage { get; private set; }

		// Token: 0x17001244 RID: 4676
		// (get) Token: 0x06003C3E RID: 15422 RVA: 0x000340B8 File Offset: 0x000322B8
		// (set) Token: 0x06003C3F RID: 15423 RVA: 0x000340C4 File Offset: 0x000322C4
		public string ButtonBarMessage { get; private set; }

		// Token: 0x17001245 RID: 4677
		// (get) Token: 0x06003C40 RID: 15424 RVA: 0x000340D5 File Offset: 0x000322D5
		// (set) Token: 0x06003C41 RID: 15425 RVA: 0x000340E1 File Offset: 0x000322E1
		public string RequestFormMessage { get; private set; }

		// Token: 0x17001246 RID: 4678
		// (get) Token: 0x06003C42 RID: 15426 RVA: 0x000340F2 File Offset: 0x000322F2
		// (set) Token: 0x06003C43 RID: 15427 RVA: 0x000340FE File Offset: 0x000322FE
		public string WindowTitle { get; private set; }

		// Token: 0x17001247 RID: 4679
		// (get) Token: 0x06003C44 RID: 15428 RVA: 0x0003410F File Offset: 0x0003230F
		// (set) Token: 0x06003C45 RID: 15429 RVA: 0x0003411B File Offset: 0x0003231B
		public string LockingCodeProgramVersion { get; private set; }

		// Token: 0x17001248 RID: 4680
		// (get) Token: 0x06003C46 RID: 15430 RVA: 0x0003412C File Offset: 0x0003232C
		// (set) Token: 0x06003C47 RID: 15431 RVA: 0x00034138 File Offset: 0x00032338
		public string LockingCode { get; private set; }

		// Token: 0x17001249 RID: 4681
		// (get) Token: 0x06003C48 RID: 15432 RVA: 0x00034149 File Offset: 0x00032349
		// (set) Token: 0x06003C49 RID: 15433 RVA: 0x00034155 File Offset: 0x00032355
		public string StandaloneLicenseTypeDescription { get; private set; }

		// Token: 0x1700124A RID: 4682
		// (get) Token: 0x06003C4A RID: 15434 RVA: 0x00034166 File Offset: 0x00032366
		// (set) Token: 0x06003C4B RID: 15435 RVA: 0x00034172 File Offset: 0x00032372
		public string NetworkLicenseTypeDescription { get; private set; }

		// Token: 0x06003C4C RID: 15436 RVA: 0x001193D4 File Offset: 0x001175D4
		public void #Agc(#dgc #AQ)
		{
			this.WindowTitle = \u0010.\u0092(#Phc.#3hc(107378408), #AQ.ProductData.Name, #Phc.#3hc(107378383));
			this.TrialButtonMessage = \u0010.\u0092(\u0015.\u009A(#Phc.#3hc(107378364), #AQ.ProductData.TrialTotalDays), \u008E.\u0099\u0002(), #Phc.#3hc(107378275));
			if (#AQ.ProductData.IsTrialStarted && !#AQ.ProductData.IsTrialExhausted)
			{
				if (7 == 0)
				{
					goto IL_173;
				}
				this.TrialButtonMessage = \u0010.\u0092(\u0015.\u009A(#Phc.#3hc(107378214), #AQ.ProductData.TrialTotalDays), \u008E.\u0099\u0002(), #Phc.#3hc(107378275));
			}
			this.RequestLicenseButtonMessage = \u0010.\u0092(#Phc.#3hc(107378665), \u008E.\u0099\u0002(), #Phc.#3hc(107378624));
			this.ActivateLicenseButtonMessage = \u0010.\u0092(#Phc.#3hc(107378623), \u008E.\u0099\u0002(), #Phc.#3hc(107378534));
			if (#AQ.ProductData.IsTrialExhausted)
			{
				this.ButtonBarMessage = #Phc.#3hc(107378505);
				goto IL_19D;
			}
			if (!#AQ.ProductData.IsTrialStarted)
			{
				goto IL_19D;
			}
			IL_173:
			this.ButtonBarMessage = \u0015.\u009A(#Phc.#3hc(107378468), #AQ.ProductData.TrialRemainingDays);
			IL_19D:
			this.RequestFormMessage = \u0010.\u0092(#Phc.#3hc(107378451), \u008E.\u0099\u0002(), #Phc.#3hc(107377854));
			this.StandaloneLicenseTypeDescription = \u0010.\u0092(#Phc.#3hc(107377801), \u008E.\u0099\u0002(), #Phc.#3hc(107377756));
			this.NetworkLicenseTypeDescription = \u008F.\u000F\u0003(new string[]
			{
				#Phc.#3hc(107377671),
				\u008E.\u0099\u0002(),
				#Phc.#3hc(107378134),
				\u008E.\u0099\u0002(),
				#Phc.#3hc(107378017)
			});
			this.LockingCodeProgramVersion = #AQ.ProductData.LockingCodeProgramVersion;
			this.LockingCode = #AQ.ProductData.LockingCode;
		}

		// Token: 0x06003C4D RID: 15437 RVA: 0x00034183 File Offset: 0x00032383
		protected void #Fkb([CallerMemberName] string #em = null)
		{
			for (;;)
			{
				if (!false)
				{
					PropertyChangedEventHandler propertyChangedEventHandler = this.#a;
					if (propertyChangedEventHandler != null)
					{
						propertyChangedEventHandler(this, new PropertyChangedEventArgs(#em));
						goto IL_1D;
					}
				}
				if (false)
				{
					continue;
				}
				if (5 != 0)
				{
					break;
				}
				IL_1D:
				if (!false)
				{
					return;
				}
			}
		}

		// Token: 0x04001B3D RID: 6973
		[CompilerGenerated]
		private PropertyChangedEventHandler #a;

		// Token: 0x04001B3E RID: 6974
		[CompilerGenerated]
		private string #b;

		// Token: 0x04001B3F RID: 6975
		[CompilerGenerated]
		private string #c;

		// Token: 0x04001B40 RID: 6976
		[CompilerGenerated]
		private string #d;

		// Token: 0x04001B41 RID: 6977
		[CompilerGenerated]
		private string #e;

		// Token: 0x04001B42 RID: 6978
		[CompilerGenerated]
		private string #f;

		// Token: 0x04001B43 RID: 6979
		[CompilerGenerated]
		private string #g;

		// Token: 0x04001B44 RID: 6980
		[CompilerGenerated]
		private string #h;

		// Token: 0x04001B45 RID: 6981
		[CompilerGenerated]
		private string #i;

		// Token: 0x04001B46 RID: 6982
		[CompilerGenerated]
		private string #j;

		// Token: 0x04001B47 RID: 6983
		[CompilerGenerated]
		private string #k;
	}
}
