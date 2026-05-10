using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #Ded;
using #FCd;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;

namespace #Ted
{
	// Token: 0x02000D35 RID: 3381
	internal class #Lhd : #Led, #rgd
	{
		// Token: 0x06006F9F RID: 28575 RVA: 0x00059E15 File Offset: 0x00058015
		public #Lhd(TelerikGridRenderer #Mhd)
		{
			this.#b = new #Khd(#Mhd);
		}

		// Token: 0x17001F6A RID: 8042
		// (get) Token: 0x06006FA0 RID: 28576 RVA: 0x00059E34 File Offset: 0x00058034
		// (set) Token: 0x06006FA1 RID: 28577 RVA: 0x00059E40 File Offset: 0x00058040
		public string Header { get; private set; }

		// Token: 0x17001F6B RID: 8043
		// (get) Token: 0x06006FA2 RID: 28578 RVA: 0x00059E51 File Offset: 0x00058051
		public IReadOnlyList<string> Notes
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x17001F6C RID: 8044
		// (get) Token: 0x06006FA3 RID: 28579 RVA: 0x00059E5D File Offset: 0x0005805D
		// (set) Token: 0x06006FA4 RID: 28580 RVA: 0x00059E72 File Offset: 0x00058072
		public #0ed CriticalItemsOptions
		{
			get
			{
				return this.#b.CriticalItemsOptions;
			}
			set
			{
				this.#b.CriticalItemsOptions = value;
			}
		}

		// Token: 0x06006FA5 RID: 28581 RVA: 0x00059E8C File Offset: 0x0005808C
		public void #pgd()
		{
			this.#Jed();
		}

		// Token: 0x06006FA6 RID: 28582 RVA: 0x00059E9C File Offset: 0x0005809C
		public void #qgd()
		{
			this.#Ied();
		}

		// Token: 0x06006FA7 RID: 28583 RVA: 0x00059EAC File Offset: 0x000580AC
		protected override void #Jed()
		{
			this.#a.Clear();
			base.#Jed();
		}

		// Token: 0x06006FA8 RID: 28584 RVA: 0x00059ECB File Offset: 0x000580CB
		protected override void #Rcd(string #wy, #uDd #Xpb)
		{
			this.#b.PixelWidths = this.#Hed(#Xpb);
			#Xpb.#npb(this.#b);
		}

		// Token: 0x06006FA9 RID: 28585 RVA: 0x001A7534 File Offset: 0x001A5734
		protected override void #ved(#Red #bLb)
		{
			if (#bLb.IsNoteOnly)
			{
				return;
			}
			this.Header = #bLb.Header.HeaderPath;
			if (#bLb.Notes != null)
			{
				this.#a.AddRange(#bLb.Notes);
			}
			this.#Rcd(#bLb.Header.Header, #bLb.Table);
		}

		// Token: 0x04002CE9 RID: 11497
		private readonly List<string> #a = new List<string>();

		// Token: 0x04002CEA RID: 11498
		private readonly #Khd #b;

		// Token: 0x04002CEB RID: 11499
		[CompilerGenerated]
		private string #c;
	}
}
