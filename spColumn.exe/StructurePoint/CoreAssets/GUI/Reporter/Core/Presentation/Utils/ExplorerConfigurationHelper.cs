using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #o1d;
using #UYd;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Navigation;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation.Utils
{
	// Token: 0x02000DEA RID: 3562
	public static class ExplorerConfigurationHelper
	{
		// Token: 0x060080BB RID: 32955 RVA: 0x001C1128 File Offset: 0x001BF328
		public static void #yPd(string #AQ, IEnumerable<ReportContentVisibilityOption> #zPd)
		{
			ExplorerConfigurationHelper.#v0b #v0b = new ExplorerConfigurationHelper.#v0b();
			if (string.IsNullOrWhiteSpace(#AQ))
			{
				return;
			}
			#v0b.#a = ExplorerConfigurationHelper.#CPd(#AQ);
			#hZd.#mbb<ReportContentVisibilityOption>(#zPd, new Func<ReportContentVisibilityOption, IEnumerable<ReportContentVisibilityOption>>(ExplorerConfigurationHelper.<>c.<>9.#mWd), new Action<ReportContentVisibilityOption>(#v0b.#kWd));
		}

		// Token: 0x060080BC RID: 32956 RVA: 0x001C1190 File Offset: 0x001BF390
		public static void #APd(string #AQ, ReportContentVisibilityOption[] #zPd)
		{
			ExplorerConfigurationHelper.#wbc #wbc = new ExplorerConfigurationHelper.#wbc();
			if (\u0003.\u0004(#AQ))
			{
				return;
			}
			#wbc.#a = ExplorerConfigurationHelper.#CPd(#AQ);
			#hZd.#mbb<ReportContentVisibilityOption>(#zPd, new Func<ReportContentVisibilityOption, IEnumerable<ReportContentVisibilityOption>>(ExplorerConfigurationHelper.<>c.<>9.#oWd), new Action<ReportContentVisibilityOption>(#wbc.#rWd));
		}

		// Token: 0x060080BD RID: 32957 RVA: 0x001C11FC File Offset: 0x001BF3FC
		public static string #RLd(ReportContentVisibilityOption[] #zPd)
		{
			ExplorerConfigurationHelper.#dZb #dZb = new ExplorerConfigurationHelper.#dZb();
			#dZb.#a = new List<string>();
			#hZd.#mbb<ReportContentVisibilityOption>(#zPd, new Func<ReportContentVisibilityOption, IEnumerable<ReportContentVisibilityOption>>(ExplorerConfigurationHelper.<>c.<>9.#pWd), new Action<ReportContentVisibilityOption>(#dZb.#tWd));
			return \u0003\u0005.\u0096\u000E(#Phc.#3hc(107378801), #dZb.#a);
		}

		// Token: 0x060080BE RID: 32958 RVA: 0x001C1274 File Offset: 0x001BF474
		private static ExplorerConfigurationHelper.ConfigurationItem #1vb(string #BPd)
		{
			string[] array = \u008C\u0006.~\u008D\u0010(#BPd, new char[]
			{
				';'
			}, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length != 3)
			{
				return null;
			}
			return new ExplorerConfigurationHelper.ConfigurationItem
			{
				BookmarkName = array[0],
				IsChecked = ExplorerConfigurationHelper.#EPd(array[1]),
				IsExpanded = ExplorerConfigurationHelper.#EPd(array[2]).GetValueOrDefault()
			};
		}

		// Token: 0x060080BF RID: 32959 RVA: 0x001C12E0 File Offset: 0x001BF4E0
		private static ICollection<ExplorerConfigurationHelper.ConfigurationItem> #CPd(string #AQ)
		{
			IEnumerable<string> source = #AQ.Split(new string[]
			{
				#Phc.#3hc(107378801)
			}, StringSplitOptions.RemoveEmptyEntries);
			Func<string, ExplorerConfigurationHelper.ConfigurationItem> selector;
			if ((selector = ExplorerConfigurationHelper.#2Ui.#a) == null)
			{
				selector = (ExplorerConfigurationHelper.#2Ui.#a = new Func<string, ExplorerConfigurationHelper.ConfigurationItem>(ExplorerConfigurationHelper.#1vb));
			}
			return source.Select(selector).Where(new Func<ExplorerConfigurationHelper.ConfigurationItem, bool>(ExplorerConfigurationHelper.<>c.<>9.#qWd)).ToList<ExplorerConfigurationHelper.ConfigurationItem>();
		}

		// Token: 0x060080C0 RID: 32960 RVA: 0x00068DC8 File Offset: 0x00066FC8
		private static void #DPd(ReportContentVisibilityOption #bA, ExplorerConfigurationHelper.ConfigurationItem #Rf)
		{
			#bA.#LQd(#Rf.IsChecked);
			#bA.IsExpanded = #Rf.IsExpanded;
		}

		// Token: 0x060080C1 RID: 32961 RVA: 0x001C135C File Offset: 0x001BF55C
		private static bool? #EPd(string #f)
		{
			if (#f == #Phc.#3hc(107408434))
			{
				return null;
			}
			return new bool?(#f == #Phc.#3hc(107421527));
		}

		// Token: 0x060080C2 RID: 32962 RVA: 0x00068DEE File Offset: 0x00066FEE
		private static string #FPd(bool? #f)
		{
			if (#f == null)
			{
				return #Phc.#3hc(107408434);
			}
			if (!#f.GetValueOrDefault())
			{
				return #Phc.#3hc(107426661);
			}
			return #Phc.#3hc(107421527);
		}

		// Token: 0x060080C3 RID: 32963 RVA: 0x001C13A8 File Offset: 0x001BF5A8
		private static string #GPd(string #Tcd, bool? #Vcb, bool #HPd)
		{
			return string.Format(CultureInfo.InvariantCulture, #Phc.#3hc(107278235), new object[]
			{
				#Tcd,
				ExplorerConfigurationHelper.#FPd(#Vcb),
				ExplorerConfigurationHelper.#FPd(new bool?(#HPd))
			});
		}

		// Token: 0x060080C4 RID: 32964 RVA: 0x00068E2E File Offset: 0x0006702E
		private static string #GPd(ReportContentVisibilityOption #bA)
		{
			return ExplorerConfigurationHelper.#GPd(#bA.DocumentOption.BookmarkName, #bA.IsChecked, #bA.IsExpanded);
		}

		// Token: 0x040034CA RID: 13514
		private const string #a = "#";

		// Token: 0x02000DEB RID: 3563
		private sealed class ConfigurationItem
		{
			// Token: 0x17002673 RID: 9843
			// (get) Token: 0x060080C5 RID: 32965 RVA: 0x00068E58 File Offset: 0x00067058
			// (set) Token: 0x060080C6 RID: 32966 RVA: 0x00068E64 File Offset: 0x00067064
			public string BookmarkName { get; set; }

			// Token: 0x17002674 RID: 9844
			// (get) Token: 0x060080C7 RID: 32967 RVA: 0x00068E75 File Offset: 0x00067075
			// (set) Token: 0x060080C8 RID: 32968 RVA: 0x00068E81 File Offset: 0x00067081
			public bool? IsChecked { get; set; }

			// Token: 0x17002675 RID: 9845
			// (get) Token: 0x060080C9 RID: 32969 RVA: 0x00068E92 File Offset: 0x00067092
			// (set) Token: 0x060080CA RID: 32970 RVA: 0x00068E9E File Offset: 0x0006709E
			public bool IsExpanded { get; set; }

			// Token: 0x040034CB RID: 13515
			[CompilerGenerated]
			private string #a;

			// Token: 0x040034CC RID: 13516
			[CompilerGenerated]
			private bool? #b;

			// Token: 0x040034CD RID: 13517
			[CompilerGenerated]
			private bool #c;
		}

		// Token: 0x02000DEC RID: 3564
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x040034CE RID: 13518
			public static Func<string, ExplorerConfigurationHelper.ConfigurationItem> #a;
		}

		// Token: 0x02000DEE RID: 3566
		[CompilerGenerated]
		private sealed class #v0b
		{
			// Token: 0x060080D4 RID: 32980 RVA: 0x001C13F8 File Offset: 0x001BF5F8
			internal void #kWd(ReportContentVisibilityOption #uXb)
			{
				ExplorerConfigurationHelper.#A9c #A9c = new ExplorerConfigurationHelper.#A9c();
				ExplorerConfigurationHelper.#A9c #A9c2;
				if (!false)
				{
					#A9c2 = #A9c;
				}
				#A9c2.#a = #uXb;
				ExplorerConfigurationHelper.ConfigurationItem configurationItem = this.#a.FirstOrDefault(new Func<ExplorerConfigurationHelper.ConfigurationItem, bool>(#A9c2.#lWd));
				if (configurationItem != null)
				{
					bool? flag = configurationItem.IsChecked;
					if (flag != null && flag.GetValueOrDefault())
					{
						#A9c2.#a.Children.#I1d(new Action<ReportContentVisibilityOption>(ExplorerConfigurationHelper.<>c.<>9.#nWd));
					}
				}
			}

			// Token: 0x040034D5 RID: 13525
			public ICollection<ExplorerConfigurationHelper.ConfigurationItem> #a;
		}

		// Token: 0x02000DEF RID: 3567
		[CompilerGenerated]
		private sealed class #A9c
		{
			// Token: 0x060080D6 RID: 32982 RVA: 0x00068ED9 File Offset: 0x000670D9
			internal bool #lWd(ExplorerConfigurationHelper.ConfigurationItem #Rf)
			{
				return \u0006.\u0008(this.#a.DocumentOption.BookmarkName, #Rf.BookmarkName, StringComparison.Ordinal);
			}

			// Token: 0x040034D6 RID: 13526
			public ReportContentVisibilityOption #a;
		}

		// Token: 0x02000DF0 RID: 3568
		[CompilerGenerated]
		private sealed class #wbc
		{
			// Token: 0x060080D8 RID: 32984 RVA: 0x001C1494 File Offset: 0x001BF694
			internal void #rWd(ReportContentVisibilityOption #uXb)
			{
				ExplorerConfigurationHelper.#ldc #ldc = new ExplorerConfigurationHelper.#ldc();
				#ldc.#a = #uXb;
				ExplorerConfigurationHelper.ConfigurationItem configurationItem = this.#a.FirstOrDefault(new Func<ExplorerConfigurationHelper.ConfigurationItem, bool>(#ldc.#sWd));
				if (configurationItem != null)
				{
					ExplorerConfigurationHelper.#DPd(#ldc.#a, configurationItem);
				}
			}

			// Token: 0x040034D7 RID: 13527
			public ICollection<ExplorerConfigurationHelper.ConfigurationItem> #a;
		}

		// Token: 0x02000DF1 RID: 3569
		[CompilerGenerated]
		private sealed class #ldc
		{
			// Token: 0x060080DA RID: 32986 RVA: 0x00068F08 File Offset: 0x00067108
			internal bool #sWd(ExplorerConfigurationHelper.ConfigurationItem #Rf)
			{
				return \u0006.\u0008(this.#a.DocumentOption.BookmarkName, #Rf.BookmarkName, StringComparison.Ordinal);
			}

			// Token: 0x040034D8 RID: 13528
			public ReportContentVisibilityOption #a;
		}

		// Token: 0x02000DF2 RID: 3570
		[CompilerGenerated]
		private sealed class #dZb
		{
			// Token: 0x060080DC RID: 32988 RVA: 0x00068F37 File Offset: 0x00067137
			internal void #tWd(ReportContentVisibilityOption #uXb)
			{
				this.#a.Add(ExplorerConfigurationHelper.#GPd(#uXb));
			}

			// Token: 0x040034D9 RID: 13529
			public List<string> #a;
		}
	}
}
