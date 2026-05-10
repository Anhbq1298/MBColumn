using System;
using System.Runtime.CompilerServices;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.Framework.Tools;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Localizer;

namespace #IDc
{
	// Token: 0x02000B91 RID: 2961
	internal sealed class #XHc
	{
		// Token: 0x06006140 RID: 24896 RVA: 0x0017C834 File Offset: 0x0017AA34
		public #XHc(string #Ic, string #5, NotificationItemType #YHc)
		{
			#X0d.#V0d(#5, #Phc.#3hc(107415909), Component.GUIFramework, #Phc.#3hc(107415928));
			this.Source = #Ic;
			this.Message = #5;
			this.NotificationItemType = #YHc;
			this.Timestamp = DateTime.Now;
		}

		// Token: 0x17001BB3 RID: 7091
		// (get) Token: 0x06006141 RID: 24897 RVA: 0x0004FC33 File Offset: 0x0004DE33
		// (set) Token: 0x06006142 RID: 24898 RVA: 0x0004FC3B File Offset: 0x0004DE3B
		public DateTime Timestamp { get; private set; }

		// Token: 0x17001BB4 RID: 7092
		// (get) Token: 0x06006143 RID: 24899 RVA: 0x0004FC44 File Offset: 0x0004DE44
		// (set) Token: 0x06006144 RID: 24900 RVA: 0x0004FC4C File Offset: 0x0004DE4C
		public string Source { get; private set; }

		// Token: 0x17001BB5 RID: 7093
		// (get) Token: 0x06006145 RID: 24901 RVA: 0x0004FC55 File Offset: 0x0004DE55
		// (set) Token: 0x06006146 RID: 24902 RVA: 0x0004FC5D File Offset: 0x0004DE5D
		public string Message { get; private set; }

		// Token: 0x17001BB6 RID: 7094
		// (get) Token: 0x06006147 RID: 24903 RVA: 0x0004FC66 File Offset: 0x0004DE66
		// (set) Token: 0x06006148 RID: 24904 RVA: 0x0004FC6E File Offset: 0x0004DE6E
		public NotificationItemType NotificationItemType { get; private set; }

		// Token: 0x17001BB7 RID: 7095
		// (get) Token: 0x06006149 RID: 24905 RVA: 0x0017C884 File Offset: 0x0017AA84
		public string TypeString
		{
			get
			{
				NotificationItemType notificationItemType = this.NotificationItemType;
				NotificationItemType notificationItemType2;
				if (2 != 0)
				{
					notificationItemType2 = notificationItemType;
				}
				if (2 != 0)
				{
					switch (notificationItemType2)
					{
					case NotificationItemType.Info:
						break;
					case NotificationItemType.Warning:
						return Strings.StringWarning;
					case NotificationItemType.Error:
						return Strings.StringError;
					default:
						while (!false)
						{
							if (!false)
							{
								NotificationItemType notificationItemType3 = this.NotificationItemType;
								NotificationItemType notificationItemType4;
								if (!false)
								{
									notificationItemType4 = notificationItemType3;
								}
								return notificationItemType4.ToString();
							}
						}
						break;
					}
				}
				return Strings.StringInfo;
			}
		}

		// Token: 0x040027CE RID: 10190
		[CompilerGenerated]
		private DateTime #a;

		// Token: 0x040027CF RID: 10191
		[CompilerGenerated]
		private string #b;

		// Token: 0x040027D0 RID: 10192
		[CompilerGenerated]
		private string #c;

		// Token: 0x040027D1 RID: 10193
		[CompilerGenerated]
		private NotificationItemType #d;
	}
}
