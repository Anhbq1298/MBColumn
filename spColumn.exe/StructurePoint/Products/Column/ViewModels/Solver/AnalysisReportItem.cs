using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Telerik.Windows.Documents.Spreadsheet.Core;

namespace StructurePoint.Products.Column.ViewModels.Solver
{
	// Token: 0x02000114 RID: 276
	[DebuggerDisplay("{Prefix}{Text}")]
	internal sealed class AnalysisReportItem : NotifyPropertyChangedBase
	{
		// Token: 0x170003D5 RID: 981
		// (get) Token: 0x060008EC RID: 2284 RVA: 0x0000CDA7 File Offset: 0x0000AFA7
		// (set) Token: 0x060008ED RID: 2285 RVA: 0x0000CDB3 File Offset: 0x0000AFB3
		public string Text { get; set; }

		// Token: 0x170003D6 RID: 982
		// (get) Token: 0x060008EE RID: 2286 RVA: 0x0000CDC4 File Offset: 0x0000AFC4
		// (set) Token: 0x060008EF RID: 2287 RVA: 0x0000CDD0 File Offset: 0x0000AFD0
		public string Prefix { get; set; }

		// Token: 0x170003D7 RID: 983
		// (get) Token: 0x060008F0 RID: 2288 RVA: 0x0000CDE1 File Offset: 0x0000AFE1
		// (set) Token: 0x060008F1 RID: 2289 RVA: 0x0000CDED File Offset: 0x0000AFED
		public bool IsWarning { get; set; }

		// Token: 0x170003D8 RID: 984
		// (get) Token: 0x060008F2 RID: 2290 RVA: 0x0000CDFE File Offset: 0x0000AFFE
		// (set) Token: 0x060008F3 RID: 2291 RVA: 0x0000CE0A File Offset: 0x0000B00A
		public bool IsError { get; set; }

		// Token: 0x060008F4 RID: 2292 RVA: 0x0000CE1B File Offset: 0x0000B01B
		public static AnalysisReportItem #Tm()
		{
			return new AnalysisReportItem
			{
				Text = Environment.NewLine
			};
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x0009400C File Offset: 0x0009220C
		public static void #Um(IList<AnalysisReportItem> #8f)
		{
			for (int i = #8f.Count - 1; i >= 0; i--)
			{
				AnalysisReportItem analysisReportItem = #8f[i];
				string[] array;
				if (!string.Equals(analysisReportItem.Text, Environment.NewLine))
				{
					array = analysisReportItem.Text.Split(new string[]
					{
						Environment.NewLine
					}, StringSplitOptions.None);
				}
				else
				{
					(array = new string[1])[0] = string.Empty;
				}
				string[] array2 = array;
				#8f.RemoveAt(i);
				for (int j = 0; j < array2.Length; j++)
				{
					#8f.Insert(i, new AnalysisReportItem
					{
						Text = array2[j],
						IsError = analysisReportItem.IsError,
						Prefix = analysisReportItem.Prefix,
						IsWarning = analysisReportItem.IsWarning
					});
				}
			}
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x000940E4 File Offset: 0x000922E4
		public static void #Vm(IList<AnalysisReportItem> #8f)
		{
			for (int i = #8f.Count - 2; i >= 0; i--)
			{
				AnalysisReportItem analysisReportItem = #8f[i + 1];
				AnalysisReportItem analysisReportItem2 = #8f[i];
				if (string.IsNullOrWhiteSpace((analysisReportItem2 != null) ? analysisReportItem2.Text : null) && string.IsNullOrWhiteSpace((analysisReportItem != null) ? analysisReportItem.Text : null))
				{
					#8f.RemoveAt(i + 1);
				}
			}
		}

		// Token: 0x060008F7 RID: 2295 RVA: 0x00094154 File Offset: 0x00092354
		public static void #Wm(List<AnalysisReportItem> #8f)
		{
			int num = #8f.Count - 1;
			while (num >= 0 && string.IsNullOrWhiteSpace(#8f[num].Text))
			{
				#8f.RemoveAt(num);
				num--;
			}
			int num2 = 0;
			while (num2 < #8f.Count && string.IsNullOrWhiteSpace(#8f[num2].Text))
			{
				#8f.RemoveAt(num2);
				num2++;
			}
		}

		// Token: 0x040002EA RID: 746
		[CompilerGenerated]
		private string #a;

		// Token: 0x040002EB RID: 747
		[CompilerGenerated]
		private string #b;

		// Token: 0x040002EC RID: 748
		[CompilerGenerated]
		private bool #c;

		// Token: 0x040002ED RID: 749
		[CompilerGenerated]
		private bool #d;
	}
}
