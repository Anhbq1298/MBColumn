using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using #UYd;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Data
{
	// Token: 0x02000E25 RID: 3621
	[DebuggerDisplay("{BookmarkName} - {Value}")]
	public class Option
	{
		// Token: 0x06008213 RID: 33299 RVA: 0x00069ED6 File Offset: 0x000680D6
		public Option(string bookmarkname = null) : this(null, bookmarkname)
		{
		}

		// Token: 0x06008214 RID: 33300 RVA: 0x00069EE0 File Offset: 0x000680E0
		public Option(Option parent, string bookmarkName = null)
		{
			this.#d = new List<Option>();
			this.Value = new bool?(true);
			this.Parent = parent;
			if (parent != null)
			{
				parent.Children.Add(this);
			}
			this.BookmarkName = bookmarkName;
		}

		// Token: 0x170026D3 RID: 9939
		// (get) Token: 0x06008215 RID: 33301 RVA: 0x00069F1C File Offset: 0x0006811C
		// (set) Token: 0x06008216 RID: 33302 RVA: 0x00069F28 File Offset: 0x00068128
		public bool? Value { get; set; }

		// Token: 0x170026D4 RID: 9940
		// (get) Token: 0x06008217 RID: 33303 RVA: 0x00069F39 File Offset: 0x00068139
		// (set) Token: 0x06008218 RID: 33304 RVA: 0x00069F45 File Offset: 0x00068145
		public string BookmarkName { get; set; }

		// Token: 0x170026D5 RID: 9941
		// (get) Token: 0x06008219 RID: 33305 RVA: 0x00069F56 File Offset: 0x00068156
		// (set) Token: 0x0600821A RID: 33306 RVA: 0x00069F62 File Offset: 0x00068162
		public Option Parent { get; set; }

		// Token: 0x170026D6 RID: 9942
		// (get) Token: 0x0600821B RID: 33307 RVA: 0x00069F73 File Offset: 0x00068173
		public List<Option> Children { get; }

		// Token: 0x170026D7 RID: 9943
		// (get) Token: 0x0600821C RID: 33308 RVA: 0x00069F7F File Offset: 0x0006817F
		// (set) Token: 0x0600821D RID: 33309 RVA: 0x00069F8B File Offset: 0x0006818B
		public bool IsEnabled { get; set; }

		// Token: 0x0600821E RID: 33310 RVA: 0x001C376C File Offset: 0x001C196C
		public bool #ISd()
		{
			return this.IsEnabled && (this.Value == null || this.Value.Value) && (this.Parent == null || this.Parent.#ISd());
		}

		// Token: 0x0600821F RID: 33311 RVA: 0x001C37C4 File Offset: 0x001C19C4
		public bool #JSd()
		{
			bool? flag = this.Value;
			return (flag == null || this.Value.Value) && (this.Parent == null || this.Parent.#JSd());
		}

		// Token: 0x06008220 RID: 33312 RVA: 0x001C3814 File Offset: 0x001C1A14
		public void #KSd(bool #f)
		{
			Option.#CTb #CTb = new Option.#CTb();
			#CTb.#a = #f;
			this.Value = new bool?(#CTb.#a);
			this.Children.ForEach(new Action<Option>(#CTb.#3Wd));
		}

		// Token: 0x06008221 RID: 33313 RVA: 0x001C3864 File Offset: 0x001C1A64
		public void #LSd(bool #MSd)
		{
			Option.#ETb #ETb = new Option.#ETb();
			#ETb.#a = #MSd;
			this.IsEnabled = #ETb.#a;
			#hZd.#mbb<Option>(this.Children, new Func<Option, IEnumerable<Option>>(Option.<>c.<>9.#6Wd), new Action<Option>(#ETb.#4Wd));
		}

		// Token: 0x06008222 RID: 33314 RVA: 0x001C38CC File Offset: 0x001C1ACC
		public void #NSd()
		{
			if (this.Children.Any<Option>())
			{
				this.IsEnabled = this.Children.Any(new Func<Option, bool>(Option.<>c.<>9.#7Wd));
			}
		}

		// Token: 0x0400355C RID: 13660
		[CompilerGenerated]
		private bool? #a;

		// Token: 0x0400355D RID: 13661
		[CompilerGenerated]
		private string #b;

		// Token: 0x0400355E RID: 13662
		[CompilerGenerated]
		private Option #c;

		// Token: 0x0400355F RID: 13663
		[CompilerGenerated]
		private readonly List<Option> #d;

		// Token: 0x04003560 RID: 13664
		[CompilerGenerated]
		private bool #e;

		// Token: 0x02000E27 RID: 3623
		[CompilerGenerated]
		private sealed class #CTb
		{
			// Token: 0x06008228 RID: 33320 RVA: 0x00069FBC File Offset: 0x000681BC
			internal void #3Wd(Option #Aad)
			{
				#Aad.#KSd(this.#a);
			}

			// Token: 0x04003564 RID: 13668
			public bool #a;
		}

		// Token: 0x02000E28 RID: 3624
		[CompilerGenerated]
		private sealed class #ETb
		{
			// Token: 0x0600822A RID: 33322 RVA: 0x00069FD6 File Offset: 0x000681D6
			internal void #4Wd(Option #5Wd)
			{
				#5Wd.IsEnabled = this.#a;
			}

			// Token: 0x04003565 RID: 13669
			public bool #a;
		}
	}
}
