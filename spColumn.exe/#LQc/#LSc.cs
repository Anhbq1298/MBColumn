using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using #7hc;
using #cYd;
using #IDc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.GUI.Framework.Tools;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #LQc
{
	// Token: 0x02000C4A RID: 3146
	internal sealed class #LSc : #5Ic
	{
		// Token: 0x060065D7 RID: 26071 RVA: 0x0018F900 File Offset: 0x0018DB00
		public #LSc(ICommandFactory #iB, #fTc #MSc)
		{
			#X0d.#V0d(#iB, #Phc.#3hc(107409227), Component.GUIFramework, #Phc.#3hc(107441950));
			#X0d.#V0d(#MSc, #Phc.#3hc(107441353), Component.GUIFramework, #Phc.#3hc(107441364));
			this.#a = new ObservableCollection<#XHc>();
			this.#b = #MSc;
			Action<object> execute = new Action<object>(this.#KSc);
			Predicate<object> canExecute;
			if ((canExecute = #LSc.#2Ui.#a) == null)
			{
				canExecute = (#LSc.#2Ui.#a = new Predicate<object>(#LSc.#JSc));
			}
			this.ClearNotificationItemsCommand = #iB.Create(execute, canExecute);
		}

		// Token: 0x060065D8 RID: 26072 RVA: 0x00051FD1 File Offset: 0x000501D1
		public void #0Ic(#3Hc #Ic, string #5)
		{
			do
			{
				if (!string.IsNullOrWhiteSpace(#5))
				{
					if (6 == 0)
					{
						continue;
					}
					Collection<#XHc> collection = this.#a;
					#XHc item = this.#ISc(#Ic, #5, NotificationItemType.Info);
					if (-1 != 0)
					{
						collection.Add(item);
					}
					if (!false)
					{
						return;
					}
				}
			}
			while (false);
		}

		// Token: 0x060065D9 RID: 26073 RVA: 0x00052000 File Offset: 0x00050200
		public void #1Ic(#3Hc #Ic, string #5)
		{
			do
			{
				if (!string.IsNullOrWhiteSpace(#5))
				{
					if (6 == 0)
					{
						continue;
					}
					Collection<#XHc> collection = this.#a;
					#XHc item = this.#ISc(#Ic, #5, NotificationItemType.Warning);
					if (-1 != 0)
					{
						collection.Add(item);
					}
					if (!false)
					{
						return;
					}
				}
			}
			while (false);
		}

		// Token: 0x060065DA RID: 26074 RVA: 0x0005202F File Offset: 0x0005022F
		public void #2Ic(#3Hc #Ic, string #5)
		{
			do
			{
				if (!string.IsNullOrWhiteSpace(#5))
				{
					if (6 == 0)
					{
						continue;
					}
					Collection<#XHc> collection = this.#a;
					#XHc item = this.#ISc(#Ic, #5, NotificationItemType.Error);
					if (-1 != 0)
					{
						collection.Add(item);
					}
					if (!false)
					{
						return;
					}
				}
			}
			while (false);
		}

		// Token: 0x060065DB RID: 26075 RVA: 0x0018F990 File Offset: 0x0018DB90
		public void #2Ic(#3Hc #Ic, string #5, Exception #ob)
		{
			string text;
			if (6 != 0)
			{
				text = #5;
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				goto IL_16;
			}
			IL_0D:
			string empty = string.Empty;
			if (2 != 0)
			{
				text = empty;
			}
			IL_16:
			string text2 = text + #sYd.#nYd(#ob);
			if (5 != 0)
			{
				text = text2;
			}
			Collection<#XHc> collection = this.#a;
			#XHc item = this.#ISc(#Ic, text, NotificationItemType.Error);
			if (4 != 0)
			{
				collection.Add(item);
			}
			if (!false && !false)
			{
				return;
			}
			goto IL_0D;
		}

		// Token: 0x060065DC RID: 26076 RVA: 0x0018F9F0 File Offset: 0x0018DBF0
		public void #1Ic(#3Hc #Ic, string #5, Exception #ob)
		{
			string text;
			if (6 != 0)
			{
				text = #5;
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				goto IL_16;
			}
			IL_0D:
			string empty = string.Empty;
			if (2 != 0)
			{
				text = empty;
			}
			IL_16:
			string text2 = text + #sYd.#nYd(#ob);
			if (5 != 0)
			{
				text = text2;
			}
			Collection<#XHc> collection = this.#a;
			#XHc item = this.#ISc(#Ic, text, NotificationItemType.Warning);
			if (4 != 0)
			{
				collection.Add(item);
			}
			if (!false && !false)
			{
				return;
			}
			goto IL_0D;
		}

		// Token: 0x17001C64 RID: 7268
		// (get) Token: 0x060065DD RID: 26077 RVA: 0x0005205E File Offset: 0x0005025E
		public IEnumerable<#XHc> NotificationItems
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x17001C65 RID: 7269
		// (get) Token: 0x060065DE RID: 26078 RVA: 0x00052066 File Offset: 0x00050266
		// (set) Token: 0x060065DF RID: 26079 RVA: 0x0005206E File Offset: 0x0005026E
		public ICommand ClearNotificationItemsCommand { get; private set; }

		// Token: 0x060065E0 RID: 26080 RVA: 0x0018FA50 File Offset: 0x0018DC50
		private #XHc #ISc(#3Hc #IK, string #5, NotificationItemType #YHc)
		{
			if (!string.IsNullOrWhiteSpace(#IK.FilePath))
			{
				bool flag = string.IsNullOrWhiteSpace(#5);
				while (!flag)
				{
					bool flag2 = flag = #5.EndsWith(string.Empty.#z2d(), StringComparison.CurrentCultureIgnoreCase);
					if (!false)
					{
						string text = flag2 ? #5.#O2d() : #5.#z2d(true);
						if (true)
						{
							#5 = text;
						}
						string text2 = #5 + Strings.StringPath.#u2d(true) + this.#b.#cTc(#IK.FilePath, 35);
						if (false)
						{
							break;
						}
						#5 = text2;
						break;
					}
				}
			}
			return new #XHc(#IK.CallerInfo, #5, #YHc);
		}

		// Token: 0x060065E1 RID: 26081 RVA: 0x00003375 File Offset: 0x00001575
		private static bool #JSc(object #Sb)
		{
			return true;
		}

		// Token: 0x060065E2 RID: 26082 RVA: 0x00052077 File Offset: 0x00050277
		private void #KSc(object #Sb)
		{
			Collection<#XHc> collection = this.#a;
			if (!false)
			{
				collection.Clear();
			}
		}

		// Token: 0x040029C8 RID: 10696
		private readonly ObservableCollection<#XHc> #a;

		// Token: 0x040029C9 RID: 10697
		private readonly #fTc #b;

		// Token: 0x040029CA RID: 10698
		[CompilerGenerated]
		private ICommand #c;

		// Token: 0x02000C4B RID: 3147
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x040029CB RID: 10699
			public static Predicate<object> #a;
		}
	}
}
