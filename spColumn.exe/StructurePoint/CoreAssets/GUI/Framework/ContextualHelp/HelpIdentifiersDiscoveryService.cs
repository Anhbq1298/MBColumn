using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using #7hc;
using #cYd;
using #ezc;
using #LQc;
using #m6c;
using #pXd;
using #UYd;
using #v1c;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.CoreAssets.GUI.Framework.ContextualHelp
{
	// Token: 0x02000CE9 RID: 3305
	public sealed class HelpIdentifiersDiscoveryService : #J6c
	{
		// Token: 0x06006C0A RID: 27658 RVA: 0x00054CEB File Offset: 0x00052EEB
		public HelpIdentifiersDiscoveryService(#8Sc dialogService, #v2c fileSystemService)
		{
			this.#a = dialogService;
			this.#b = fileSystemService;
		}

		// Token: 0x06006C0B RID: 27659 RVA: 0x001A170C File Offset: 0x0019F90C
		public IList<HelpID> #y6c()
		{
			#mzc.#kzc(Assembly.GetExecutingAssembly());
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			Assembly[] #S;
			if (!false)
			{
				#S = assemblies;
			}
			return this.#z6c(#S);
		}

		// Token: 0x06006C0C RID: 27660 RVA: 0x001A173C File Offset: 0x0019F93C
		public IList<HelpID> #z6c(IEnumerable<Assembly> #S)
		{
			string #R0d = #Phc.#3hc(107264534);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107264997);
			if (!false)
			{
				#X0d.#V0d(#S, #R0d, #x6c, #Qic);
			}
			return #S.SelectMany(new Func<Assembly, IEnumerable<Type>>(HelpIdentifiersDiscoveryService.<>c.<>9.#qcd)).Select(new Func<Type, <>f__AnonymousType0<Type, Type>>(HelpIdentifiersDiscoveryService.<>c.<>9.#rcd)).Where(new Func<<>f__AnonymousType0<Type, Type>, bool>(HelpIdentifiersDiscoveryService.<>c.<>9.#scd)).Select(new Func<<>f__AnonymousType0<Type, Type>, Type>(HelpIdentifiersDiscoveryService.<>c.<>9.#tcd)).ToList<Type>().SelectMany(new Func<Type, IEnumerable<PropertyInfo>>(HelpIdentifiersDiscoveryService.<>c.<>9.#ucd)).Select(new Func<PropertyInfo, object>(HelpIdentifiersDiscoveryService.<>c.<>9.#wcd)).OfType<HelpID>().ToList<HelpID>();
		}

		// Token: 0x06006C0D RID: 27661 RVA: 0x001A185C File Offset: 0x0019FA5C
		public static string #A6c(IList<HelpID> #B6c, string #C6c)
		{
			while (#B6c != null && #B6c.Any<HelpID>())
			{
				if (7 != 0)
				{
					IEnumerable<HelpID> source = #B6c.OrderBy(new Func<HelpID, string>(HelpIdentifiersDiscoveryService.<>c.<>9.#xcd));
					Func<HelpID, string> selector;
					if ((selector = HelpIdentifiersDiscoveryService.#2Ui.#a) == null)
					{
						selector = (HelpIdentifiersDiscoveryService.#2Ui.#a = new Func<HelpID, string>(HelpIdentifiersDiscoveryService.#I6c));
					}
					return string.Join(#C6c, source.Select(selector));
				}
			}
			return string.Empty;
		}

		// Token: 0x06006C0E RID: 27662 RVA: 0x001A18C8 File Offset: 0x0019FAC8
		public string #D6c()
		{
			string result;
			try
			{
				if (-1 != 0)
				{
					HelpIdentifiersDiscoveryService.#92b #92b = new HelpIdentifiersDiscoveryService.#92b();
					IList<HelpID> #B6c = this.#y6c();
					#92b.#a = HelpIdentifiersDiscoveryService.#A6c(#B6c, Environment.NewLine);
					Action #nd = new Action(#92b.#ycd);
					int #5Xd = 5;
					if (8 != 0)
					{
						#8Xd.#3Xd<Exception>(#nd, #5Xd);
					}
					string text = #92b.#a;
					if (5 != 0)
					{
						result = text;
					}
				}
				return result;
			}
			catch (Exception #ob)
			{
				do
				{
					this.#a.#od(Strings.StringAnUnknownErrorOccrued.#z2d(true) + #sYd.#oYd(#ob), #Phc.#3hc(107264976), MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK, MessageBoxOptions.None);
				}
				while (3 == 0);
			}
			if (2 != 0)
			{
				return null;
			}
			return result;
		}

		// Token: 0x06006C0F RID: 27663 RVA: 0x001A196C File Offset: 0x0019FB6C
		public IList<HelpID> #E6c(string #F6c, IEnumerable<HelpID> #G6c)
		{
			List<HelpID> list2;
			for (;;)
			{
				string #R0d = #Phc.#3hc(107264899);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107264914);
				if (!false)
				{
					#X0d.#V0d(#F6c, #R0d, #x6c, #Qic);
				}
				if (7 != 0)
				{
					string #R0d2 = #Phc.#3hc(107264861);
					Component #x6c2 = Component.GUIFramework;
					string #Qic2 = #Phc.#3hc(107264812);
					if (6 != 0)
					{
						#X0d.#V0d(#G6c, #R0d2, #x6c2, #Qic2);
					}
					List<HelpID> list = new List<HelpID>();
					if (7 != 0)
					{
						list2 = list;
					}
					if (string.IsNullOrWhiteSpace(#F6c))
					{
						break;
					}
					IEnumerator<HelpID> enumerator = #G6c.GetEnumerator();
					IEnumerator<HelpID> enumerator2;
					if (!false)
					{
						enumerator2 = enumerator;
					}
					try
					{
						while (enumerator2.MoveNext())
						{
							HelpID helpID = enumerator2.Current;
							HelpID helpID2;
							if (!false)
							{
								helpID2 = helpID;
							}
							if (3 != 0 && !#F6c.Contains(helpID2.Identifier))
							{
								List<HelpID> list3 = list2;
								HelpID item = helpID2;
								if (true)
								{
									list3.Add(item);
								}
							}
						}
					}
					finally
					{
						if (enumerator2 == null)
						{
							goto IL_A9;
						}
						IL_A3:
						enumerator2.Dispose();
						IL_A9:
						if (false)
						{
							goto IL_A3;
						}
					}
				}
				if (5 != 0)
				{
					return list2;
				}
			}
			return list2;
		}

		// Token: 0x06006C10 RID: 27664 RVA: 0x001A1A60 File Offset: 0x0019FC60
		public void #H6c()
		{
			try
			{
				string text = this.#b.#S1c(new #12c(new #L1c[]
				{
					new #L1c(#Phc.#3hc(107264791), #Phc.#3hc(107425009))
				}, #Phc.#3hc(107425009), null));
				string text2;
				if (!false)
				{
					text2 = text;
				}
				if (string.IsNullOrWhiteSpace(text2) || !this.#b.#V1c(text2))
				{
					goto IL_13A;
				}
				string text3 = File.ReadAllText(text2);
				string #F6c;
				if (2 != 0)
				{
					#F6c = text3;
				}
				IL_6D:
				IList<HelpID> list = this.#E6c(#F6c, this.#y6c());
				IList<HelpID> list2;
				if (6 != 0)
				{
					list2 = list;
				}
				if (list2.Any<HelpID>())
				{
					HelpIdentifiersDiscoveryService.#s0b #s0b = new HelpIdentifiersDiscoveryService.#s0b();
					string text4 = #Phc.#3hc(107264234) + Environment.NewLine;
					string str;
					if (!false)
					{
						str = text4;
					}
					string str2 = HelpIdentifiersDiscoveryService.#A6c(list2, Environment.NewLine);
					#s0b.#a = str + str2;
					Action #nd = new Action(#s0b.#zcd);
					int #5Xd = 5;
					if (!false)
					{
						#8Xd.#3Xd<Exception>(#nd, #5Xd);
					}
					string text5 = HelpIdentifiersDiscoveryService.#A6c(list2, string.Empty.#v2d(true));
					if (!false)
					{
						str2 = text5;
					}
					this.#a.#od(str + str2, #Phc.#3hc(107264976), MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK, MessageBoxOptions.None);
				}
				else
				{
					this.#a.#od(#Phc.#3hc(107264205), #Phc.#3hc(107264976), MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK, MessageBoxOptions.None);
				}
				IL_13A:
				if (6 == 0)
				{
					goto IL_6D;
				}
			}
			catch (Exception #ob)
			{
				this.#a.#od(Strings.StringAnUnknownErrorOccrued.#z2d(true) + #sYd.#oYd(#ob), #Phc.#3hc(107264976), MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK, MessageBoxOptions.None);
			}
		}

		// Token: 0x06006C11 RID: 27665 RVA: 0x00054D01 File Offset: 0x00052F01
		public static string #I6c(HelpID #PRc)
		{
			string #R0d = #Phc.#3hc(107443034);
			Component #x6c = Component.GUIFramework;
			string #Qic = #Phc.#3hc(107264132);
			if (!false)
			{
				#X0d.#V0d(#PRc, #R0d, #x6c, #Qic);
			}
			return #PRc.Identifier;
		}

		// Token: 0x04002C05 RID: 11269
		private readonly #8Sc #a;

		// Token: 0x04002C06 RID: 11270
		private readonly #v2c #b;

		// Token: 0x04002C07 RID: 11271
		private const string #c = "[SP Internal] Help Verification";

		// Token: 0x02000CEA RID: 3306
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x04002C08 RID: 11272
			public static Func<HelpID, string> #a;
		}

		// Token: 0x02000CEC RID: 3308
		[CompilerGenerated]
		private sealed class #92b
		{
			// Token: 0x06006C1D RID: 27677 RVA: 0x00054DAF File Offset: 0x00052FAF
			internal void #ycd()
			{
				string text = this.#a;
				if (!false)
				{
					Clipboard.SetText(text);
				}
			}

			// Token: 0x04002C12 RID: 11282
			public string #a;
		}

		// Token: 0x02000CED RID: 3309
		[CompilerGenerated]
		private sealed class #s0b
		{
			// Token: 0x06006C1F RID: 27679 RVA: 0x00054DC2 File Offset: 0x00052FC2
			internal void #zcd()
			{
				string text = this.#a;
				if (!false)
				{
					Clipboard.SetText(text);
				}
			}

			// Token: 0x04002C13 RID: 11283
			public string #a;
		}
	}
}
