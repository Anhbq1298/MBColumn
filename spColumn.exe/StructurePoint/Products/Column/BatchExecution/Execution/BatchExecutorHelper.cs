using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using #7hc;
using #o1d;
using #v1c;
using Alphaleonis.Win32.Filesystem;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.Localizer;

namespace StructurePoint.Products.Column.BatchExecution.Execution
{
	// Token: 0x020006EE RID: 1774
	internal static class BatchExecutorHelper
	{
		// Token: 0x06003ADE RID: 15070 RVA: 0x001162F8 File Offset: 0x001144F8
		public static IList<string> #GUi(#v2c #4x, string #So)
		{
			SearchOption #b2c = SearchOption.TopDirectoryOnly;
			HashSet<string> hashSet = #4x.#Ro(#So, #Phc.#3hc(107348382), #b2c).ToHashSet(StringComparer.OrdinalIgnoreCase);
			hashSet.#pR(#4x.#Ro(#So, #Phc.#3hc(107348373), #b2c));
			hashSet.#pR(#4x.#Ro(#So, #Phc.#3hc(107348332), #b2c));
			return hashSet.ToList<string>();
		}

		// Token: 0x06003ADF RID: 15071 RVA: 0x00116368 File Offset: 0x00114568
		public static string #HUi(IList<BatchItemViewModel> #vUi, string #CXi, string #IUi, string #JUi)
		{
			int num = #vUi.Count<BatchItemViewModel>();
			int num2 = #vUi.Count(new Func<BatchItemViewModel, bool>(BatchExecutorHelper.<>c.<>9.#YVi));
			int num3 = #vUi.Count(new Func<BatchItemViewModel, bool>(BatchExecutorHelper.<>c.<>9.#ZVi));
			int num4 = #vUi.Count(new Func<BatchItemViewModel, bool>(BatchExecutorHelper.<>c.<>9.#0Vi));
			TextColumnsAligner textColumnsAligner = TextColumnsAligner.MessageBoxAligner(#Phc.#3hc(107383615));
			textColumnsAligner.Add(Strings.StringProcessingComplete_DOTS);
			textColumnsAligner.AddEmptyLine();
			textColumnsAligner.Add(Strings.StringNoOfFilesProcessed, num.ToString(CultureInfo.InvariantCulture));
			textColumnsAligner.Add(Strings.StringNoOfFilesAccepted, num2.ToString(CultureInfo.InvariantCulture));
			textColumnsAligner.Add(Strings.StringNoOfFilesWithWarnings, num3.ToString(CultureInfo.InvariantCulture));
			textColumnsAligner.Add(Strings.StringNoOfFilesWithErrors, num4.ToString(CultureInfo.InvariantCulture));
			textColumnsAligner.AddEmptyLine();
			textColumnsAligner.Add(Strings.StringOutputFolder, BatchExecutorHelper.#DXi(#CXi, #IUi));
			textColumnsAligner.Add(Strings.StringSummaryFile, BatchExecutorHelper.#DXi(#CXi, #JUi));
			return textColumnsAligner.GetFinalMessage();
		}

		// Token: 0x06003AE0 RID: 15072 RVA: 0x001164C4 File Offset: 0x001146C4
		public static string #DXi(string #CXi, string #IUi)
		{
			string text = #IUi ?? string.Empty;
			#IUi = (string.IsNullOrWhiteSpace(#IUi) ? (#IUi ?? string.Empty) : (string.Equals(#CXi, #IUi, StringComparison.OrdinalIgnoreCase) ? #Phc.#3hc(107348323) : Alphaleonis.Win32.Filesystem.Path.GetRelativePath(#CXi, #IUi)));
			if (text.EndsWith(#IUi, StringComparison.OrdinalIgnoreCase) && !Alphaleonis.Win32.Filesystem.Path.IsPathRooted(#IUi))
			{
				#IUi = #Phc.#3hc(107348323) + #IUi;
			}
			return #IUi;
		}
	}
}
