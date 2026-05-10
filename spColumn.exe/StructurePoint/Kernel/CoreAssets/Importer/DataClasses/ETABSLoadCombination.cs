using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace StructurePoint.Kernel.CoreAssets.Importer.DataClasses
{
	// Token: 0x02000E52 RID: 3666
	public sealed class ETABSLoadCombination
	{
		// Token: 0x17002788 RID: 10120
		// (get) Token: 0x06008377 RID: 33655 RVA: 0x0006B389 File Offset: 0x00069589
		// (set) Token: 0x06008378 RID: 33656 RVA: 0x0006B391 File Offset: 0x00069591
		public string Name { get; private set; }

		// Token: 0x17002789 RID: 10121
		// (get) Token: 0x06008379 RID: 33657 RVA: 0x0006B39A File Offset: 0x0006959A
		// (set) Token: 0x0600837A RID: 33658 RVA: 0x0006B3A2 File Offset: 0x000695A2
		public List<string> LoadCases { get; private set; }

		// Token: 0x1700278A RID: 10122
		// (get) Token: 0x0600837B RID: 33659 RVA: 0x0006B3AB File Offset: 0x000695AB
		// (set) Token: 0x0600837C RID: 33660 RVA: 0x0006B3B3 File Offset: 0x000695B3
		public List<string> LoadCombinations { get; private set; }

		// Token: 0x0600837D RID: 33661 RVA: 0x001C4FC8 File Offset: 0x001C31C8
		public List<ETABSLoadCase> #V5h(Dictionary<string, ETABSLoadCase> #W5h, Dictionary<string, ETABSLoadCombination> #X5h)
		{
			List<ETABSLoadCase> list = #W5h.Where(new Func<KeyValuePair<string, ETABSLoadCase>, bool>(this.#05h)).Select(new Func<KeyValuePair<string, ETABSLoadCase>, ETABSLoadCase>(ETABSLoadCombination.<>c.<>9.#g8h)).ToList<ETABSLoadCase>();
			foreach (string key in this.LoadCombinations)
			{
				if (#X5h.ContainsKey(key))
				{
					list.AddRange(#X5h[key].#V5h(#W5h, #X5h));
				}
			}
			return list.Distinct<ETABSLoadCase>().ToList<ETABSLoadCase>();
		}

		// Token: 0x0600837E RID: 33662 RVA: 0x0006B3BC File Offset: 0x000695BC
		internal List<ETABSLoadCaseType> #Y5h(Dictionary<string, ETABSLoadCase> #W5h, Dictionary<string, ETABSLoadCombination> #X5h)
		{
			return this.#V5h(#W5h, #X5h).Select(new Func<ETABSLoadCase, ETABSLoadCaseType>(ETABSLoadCombination.<>c.<>9.#h8h)).Distinct<ETABSLoadCaseType>().ToList<ETABSLoadCaseType>();
		}

		// Token: 0x0600837F RID: 33663 RVA: 0x0006B3F4 File Offset: 0x000695F4
		internal bool #Z5h(Dictionary<string, ETABSLoadCase> #W5h, Dictionary<string, ETABSLoadCombination> #X5h)
		{
			return this.#V5h(#W5h, #X5h).All(new Func<ETABSLoadCase, bool>(ETABSLoadCombination.<>c.<>9.#i8h));
		}

		// Token: 0x06008380 RID: 33664 RVA: 0x0006B422 File Offset: 0x00069622
		internal ETABSLoadCombination(string name, List<string> loadCases, List<string> loadCombinations)
		{
			this.Name = name;
			this.LoadCases = (loadCases ?? new List<string>());
			this.LoadCombinations = (loadCombinations ?? new List<string>());
		}

		// Token: 0x06008381 RID: 33665 RVA: 0x0006B451 File Offset: 0x00069651
		[CompilerGenerated]
		private bool #05h(KeyValuePair<string, ETABSLoadCase> #uYb)
		{
			return this.LoadCases.Contains(#uYb.Key);
		}

		// Token: 0x04003609 RID: 13833
		[CompilerGenerated]
		private string #a;

		// Token: 0x0400360A RID: 13834
		[CompilerGenerated]
		private List<string> #b;

		// Token: 0x0400360B RID: 13835
		[CompilerGenerated]
		private List<string> #c;
	}
}
