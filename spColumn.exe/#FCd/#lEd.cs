using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using #3Rd;
using #Qcd;
using #wdd;
using Aspose.Words;
using Aspose.Words.Tables;

namespace #FCd
{
	// Token: 0x02000D30 RID: 3376
	internal abstract class #lEd : IDisposable, #5Dd
	{
		// Token: 0x06006F2E RID: 28462 RVA: 0x001A6F3C File Offset: 0x001A513C
		protected #lEd(int #Jhd, params double[] #Zpb)
		{
			this.ColumnWidths = #Zpb;
			this.ColumnWidthTypes = new #rdd[#Zpb.Length];
			this.NoSpacingColumns = new bool[#Zpb.Length];
			this.#b = #Jhd;
			this.HtmlColumns = new bool[#Zpb.Length];
			for (int i = 0; i < #Zpb.Length; i++)
			{
				this.#a.Add(new #zTd
				{
					HorizontalAlignment = ParagraphAlignment.Left,
					Background = new Color?(Color.Transparent)
				});
			}
			if (this.#b > 0)
			{
				this.#TDd(-1);
			}
			this.CurrentStyle = this.#a.First<#zTd>();
			this.TableWidthType = #rdd.#a;
			this.TableAlignment = TableAlignment.Center;
			this.#XDd(#rdd.#a, new int[0]);
			this.Borders = new #eDd(#Zpb.Length, #Jhd);
		}

		// Token: 0x17001F41 RID: 8001
		// (get) Token: 0x06006F2F RID: 28463 RVA: 0x00059ABB File Offset: 0x00057CBB
		public double[] RightCellBorders
		{
			get
			{
				return this.Borders.RightCellBorders;
			}
		}

		// Token: 0x17001F42 RID: 8002
		// (get) Token: 0x06006F30 RID: 28464 RVA: 0x00059AD4 File Offset: 0x00057CD4
		// (set) Token: 0x06006F31 RID: 28465 RVA: 0x00059AE0 File Offset: 0x00057CE0
		public #eDd Borders { get; private set; }

		// Token: 0x17001F43 RID: 8003
		// (get) Token: 0x06006F32 RID: 28466 RVA: 0x00059AF1 File Offset: 0x00057CF1
		// (set) Token: 0x06006F33 RID: 28467 RVA: 0x00059AFD File Offset: 0x00057CFD
		public double? TableLeftIndent { get; set; }

		// Token: 0x17001F44 RID: 8004
		// (get) Token: 0x06006F34 RID: 28468 RVA: 0x00059B0E File Offset: 0x00057D0E
		// (set) Token: 0x06006F35 RID: 28469 RVA: 0x00059B1A File Offset: 0x00057D1A
		public #sdd AutoSizeMode { get; set; }

		// Token: 0x17001F45 RID: 8005
		// (get) Token: 0x06006F36 RID: 28470 RVA: 0x00059B2B File Offset: 0x00057D2B
		// (set) Token: 0x06006F37 RID: 28471 RVA: 0x00059B37 File Offset: 0x00057D37
		public int? NumberOfBoldHeaderRows { get; set; }

		// Token: 0x17001F46 RID: 8006
		// (get) Token: 0x06006F38 RID: 28472 RVA: 0x00059B48 File Offset: 0x00057D48
		// (set) Token: 0x06006F39 RID: 28473 RVA: 0x00059B54 File Offset: 0x00057D54
		public double[] ColumnWidths { get; private set; }

		// Token: 0x17001F47 RID: 8007
		// (get) Token: 0x06006F3A RID: 28474 RVA: 0x00059B65 File Offset: 0x00057D65
		// (set) Token: 0x06006F3B RID: 28475 RVA: 0x00059B71 File Offset: 0x00057D71
		public #rdd[] ColumnWidthTypes { get; private set; }

		// Token: 0x17001F48 RID: 8008
		// (get) Token: 0x06006F3C RID: 28476 RVA: 0x00059B82 File Offset: 0x00057D82
		// (set) Token: 0x06006F3D RID: 28477 RVA: 0x00059B8E File Offset: 0x00057D8E
		public TableAlignment TableAlignment { get; set; }

		// Token: 0x17001F49 RID: 8009
		// (get) Token: 0x06006F3E RID: 28478 RVA: 0x00059B9F File Offset: 0x00057D9F
		// (set) Token: 0x06006F3F RID: 28479 RVA: 0x00059BAB File Offset: 0x00057DAB
		public bool EnforceTableAlignment { get; set; }

		// Token: 0x17001F4A RID: 8010
		// (get) Token: 0x06006F40 RID: 28480 RVA: 0x00059BBC File Offset: 0x00057DBC
		// (set) Token: 0x06006F41 RID: 28481 RVA: 0x00059BC8 File Offset: 0x00057DC8
		public float PreferredWidth { get; set; }

		// Token: 0x17001F4B RID: 8011
		// (get) Token: 0x06006F42 RID: 28482 RVA: 0x00059BD9 File Offset: 0x00057DD9
		// (set) Token: 0x06006F43 RID: 28483 RVA: 0x00059BE5 File Offset: 0x00057DE5
		public #rdd TableWidthType { get; set; }

		// Token: 0x17001F4C RID: 8012
		// (get) Token: 0x06006F44 RID: 28484 RVA: 0x00059BF6 File Offset: 0x00057DF6
		// (set) Token: 0x06006F45 RID: 28485 RVA: 0x00059C02 File Offset: 0x00057E02
		public bool[] NoSpacingColumns { get; private set; }

		// Token: 0x17001F4D RID: 8013
		// (get) Token: 0x06006F46 RID: 28486 RVA: 0x00059C13 File Offset: 0x00057E13
		// (set) Token: 0x06006F47 RID: 28487 RVA: 0x00059C1F File Offset: 0x00057E1F
		public bool[] HtmlColumns { get; private set; }

		// Token: 0x17001F4E RID: 8014
		// (get) Token: 0x06006F48 RID: 28488 RVA: 0x00059C30 File Offset: 0x00057E30
		public ISet<int> BottomCellMargins
		{
			get
			{
				return this.Borders.BottomCellBorders;
			}
		}

		// Token: 0x17001F4F RID: 8015
		// (get) Token: 0x06006F49 RID: 28489 RVA: 0x00059C49 File Offset: 0x00057E49
		// (set) Token: 0x06006F4A RID: 28490 RVA: 0x00059C55 File Offset: 0x00057E55
		public #zTd CurrentStyle { get; private set; }

		// Token: 0x17001F50 RID: 8016
		// (get) Token: 0x06006F4B RID: 28491 RVA: 0x00059C66 File Offset: 0x00057E66
		public int ColumnCount
		{
			get
			{
				return this.ColumnWidths.Length;
			}
		}

		// Token: 0x17001F51 RID: 8017
		// (get) Token: 0x06006F4C RID: 28492 RVA: 0x00059C78 File Offset: 0x00057E78
		public IReadOnlyList<#zTd> Styles
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x17001F52 RID: 8018
		// (get) Token: 0x06006F4D RID: 28493 RVA: 0x00059C78 File Offset: 0x00057E78
		public IReadOnlyList<#zTd> ColunmStyles
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x17001F53 RID: 8019
		// (get) Token: 0x06006F4E RID: 28494 RVA: 0x00059C84 File Offset: 0x00057E84
		// (set) Token: 0x06006F4F RID: 28495 RVA: 0x00059C90 File Offset: 0x00057E90
		public bool SupportsTextWrapping { get; protected set; }

		// Token: 0x17001F54 RID: 8020
		// (get) Token: 0x06006F50 RID: 28496 RVA: 0x00059CA1 File Offset: 0x00057EA1
		public int CurrentCellIndex
		{
			get
			{
				return this.#c % this.ColumnWidths.Length;
			}
		}

		// Token: 0x17001F55 RID: 8021
		// (get) Token: 0x06006F51 RID: 28497 RVA: 0x00059CBE File Offset: 0x00057EBE
		public int CurrentRowIndex
		{
			get
			{
				return this.#c / this.ColumnWidths.Length;
			}
		}

		// Token: 0x17001F56 RID: 8022
		// (get) Token: 0x06006F52 RID: 28498 RVA: 0x00059CDB File Offset: 0x00057EDB
		protected bool IsInHeader
		{
			get
			{
				return this.#b > 0 && this.CurrentRowIndex < this.#b;
			}
		}

		// Token: 0x06006F53 RID: 28499 RVA: 0x001A7014 File Offset: 0x001A5214
		public void #ZDd(params string[] #Qb)
		{
			int num = this.CurrentCellIndex;
			int num2 = this.ColumnWidths.Length - num;
			if (num2 > 0)
			{
				this.#Fhd(num2, #Qb);
			}
		}

		// Token: 0x06006F54 RID: 28500 RVA: 0x001A704C File Offset: 0x001A524C
		public void #ZDd(ParagraphAlignment #rT, params string[] #Qb)
		{
			int num = this.CurrentCellIndex;
			int num2 = this.ColumnWidths.Length - num;
			if (num2 > 0)
			{
				this.#Fhd(num2, #rT, #Qb);
			}
		}

		// Token: 0x06006F55 RID: 28501 RVA: 0x001A7084 File Offset: 0x001A5284
		public virtual void #ODd(params string[] #Qb)
		{
			foreach (string text in #Qb)
			{
				this.#QDd(new string[]
				{
					text
				});
			}
		}

		// Token: 0x06006F56 RID: 28502 RVA: 0x001A70C4 File Offset: 0x001A52C4
		public virtual void #PDd()
		{
			for (int i = 0; i < this.ColumnWidths.Length; i++)
			{
				this.#QDd(new string[]
				{
					string.Empty
				});
			}
		}

		// Token: 0x06006F57 RID: 28503 RVA: 0x00059D02 File Offset: 0x00057F02
		public virtual void #Fhd(int #1f, params string[] #Qb)
		{
			this.#Fhd(#1f, ParagraphAlignment.Left, #Qb);
		}

		// Token: 0x06006F58 RID: 28504 RVA: 0x00059D19 File Offset: 0x00057F19
		public virtual void #QDd(params string[] #Qb)
		{
			this.#Ghd(#lEd.#YUd.#b, #Qb);
		}

		// Token: 0x06006F59 RID: 28505 RVA: 0x001A7104 File Offset: 0x001A5304
		public virtual void #Fhd(int #1f, ParagraphAlignment #rT, params string[] #Qb)
		{
			this.CurrentStyle.HorizontalAlignment = #rT;
			this.#Ghd(#lEd.#YUd.#b | #lEd.#YUd.#c, #Qb);
			for (int i = 0; i < #1f - 1; i++)
			{
				this.#Ghd(#lEd.#YUd.#d, new string[0]);
			}
		}

		// Token: 0x06006F5A RID: 28506 RVA: 0x00059D2F File Offset: 0x00057F2F
		public void #1()
		{
			this.#1(true);
			\u0017.\u009F(this);
		}

		// Token: 0x06006F5B RID: 28507 RVA: 0x001A714C File Offset: 0x001A534C
		public virtual void ResetCurrentStyle()
		{
			int index = this.CurrentCellIndex;
			this.CurrentStyle = this.#a[index].#EA();
		}

		// Token: 0x06006F5C RID: 28508 RVA: 0x00059D4F File Offset: 0x00057F4F
		public void #QDd(int? #f)
		{
			this.#QDd(new string[]
			{
				#f.#Cu()
			});
		}

		// Token: 0x06006F5D RID: 28509 RVA: 0x001A7184 File Offset: 0x001A5384
		public void #3Dd(bool #f, params int[] #SDd)
		{
			if (#SDd == null || #SDd.Length == 0)
			{
				#SDd = \u008E\u0002.\u009A\u0005(0, this.Styles.Count).ToArray<int>();
			}
			foreach (int num in #SDd)
			{
				this.NoSpacingColumns[num] = #f;
			}
		}

		// Token: 0x06006F5E RID: 28510 RVA: 0x001A71E0 File Offset: 0x001A53E0
		public void #RDd(bool #f, params int[] #SDd)
		{
			if (#SDd == null || #SDd.Length == 0)
			{
				#SDd = \u008E\u0002.\u009A\u0005(0, this.Styles.Count).ToArray<int>();
			}
			foreach (int num in #SDd)
			{
				this.HtmlColumns[num] = #f;
			}
		}

		// Token: 0x06006F5F RID: 28511 RVA: 0x001A723C File Offset: 0x001A543C
		public void #TDd(int #8r = -1)
		{
			if (#8r < 0)
			{
				#8r = this.Styles.Count;
			}
			for (int i = 0; i < #8r; i++)
			{
				this.Styles[i].Background = new Color?(#2dd.#c);
			}
			this.ResetCurrentStyle();
		}

		// Token: 0x06006F60 RID: 28512 RVA: 0x001A7294 File Offset: 0x001A5494
		public void #UDd(int #8r = -1)
		{
			if (#8r < 0)
			{
				#8r = this.Styles.Count;
			}
			for (int i = 0; i < #8r; i++)
			{
				this.Styles[i].Background = new Color?(\u0083\u0003.\u0093\u0007());
			}
			this.ResetCurrentStyle();
		}

		// Token: 0x06006F61 RID: 28513 RVA: 0x001A72F0 File Offset: 0x001A54F0
		public void #VDd(ParagraphAlignment #rT, params int[] #SDd)
		{
			if (#SDd == null || #SDd.Length == 0)
			{
				#SDd = \u008E\u0002.\u009A\u0005(0, this.Styles.Count).ToArray<int>();
			}
			foreach (int index in #SDd)
			{
				this.Styles[index].HorizontalAlignment = #rT;
			}
			this.ResetCurrentStyle();
		}

		// Token: 0x06006F62 RID: 28514 RVA: 0x001A735C File Offset: 0x001A555C
		public void #WDd(double #f, params int[] #Dob)
		{
			foreach (int num in #Dob)
			{
				this.Borders.RightCellBorders[num] = #f;
			}
		}

		// Token: 0x06006F63 RID: 28515 RVA: 0x00059D72 File Offset: 0x00057F72
		public void #0Dd(#SCd #C, double #f)
		{
			this.Borders.#4l(this.CurrentRowIndex, this.CurrentCellIndex, #C, #f);
		}

		// Token: 0x06006F64 RID: 28516 RVA: 0x001A7398 File Offset: 0x001A5598
		public void #1Dd(int #2Dd, #SCd #C, double #f)
		{
			for (int i = 0; i < #2Dd; i++)
			{
				this.Borders.#4l(this.CurrentRowIndex, this.CurrentCellIndex + i, #C, #f);
			}
		}

		// Token: 0x06006F65 RID: 28517 RVA: 0x001A73D8 File Offset: 0x001A55D8
		public void #XDd(#rdd #YDd, params int[] #SDd)
		{
			if (#SDd == null || #SDd.Length == 0)
			{
				#SDd = \u008E\u0002.\u009A\u0005(0, this.Styles.Count).ToArray<int>();
			}
			foreach (int num in #SDd)
			{
				this.ColumnWidthTypes[num] = #YDd;
			}
		}

		// Token: 0x06006F66 RID: 28518 RVA: 0x001A7434 File Offset: 0x001A5634
		public void #4Dd()
		{
			int num = this.CurrentCellIndex;
			if (num != 0)
			{
				for (int i = 0; i < this.ColumnWidths.Length - num; i++)
				{
					this.#QDd(new string[]
					{
						string.Empty
					});
				}
			}
		}

		// Token: 0x06006F67 RID: 28519 RVA: 0x001A7480 File Offset: 0x001A5680
		protected virtual int #hEd()
		{
			int result = (this.#b == 1) ? 1 : (this.#b - 1);
			if (this.NumberOfBoldHeaderRows != null)
			{
				int? num = this.NumberOfBoldHeaderRows;
				result = \u009A\u0003.\u0015\u0008(num.Value, this.#b);
			}
			return result;
		}

		// Token: 0x06006F68 RID: 28520
		protected abstract void #Ghd(#lEd.#YUd #ri, params string[] #Qb);

		// Token: 0x06006F69 RID: 28521 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #1(bool #POb)
		{
		}

		// Token: 0x06006F6A RID: 28522 RVA: 0x001A74E0 File Offset: 0x001A56E0
		protected virtual void #iEd(int #jEd)
		{
			this.#c += #jEd;
			this.ResetCurrentStyle();
			this.#Hhd();
			if (this.#b > 0 && this.CurrentRowIndex == this.#b)
			{
				this.#UDd(-1);
			}
		}

		// Token: 0x06006F6B RID: 28523 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #Hhd()
		{
		}

		// Token: 0x06006F6C RID: 28524 RVA: 0x00009E6A File Offset: 0x0000806A
		protected virtual void #kEd()
		{
		}

		// Token: 0x04002CCF RID: 11471
		private readonly List<#zTd> #a = new List<#zTd>();

		// Token: 0x04002CD0 RID: 11472
		protected readonly int #b;

		// Token: 0x04002CD1 RID: 11473
		protected int #c;

		// Token: 0x04002CD2 RID: 11474
		[CompilerGenerated]
		private #eDd #d;

		// Token: 0x04002CD3 RID: 11475
		[CompilerGenerated]
		private double? #e;

		// Token: 0x04002CD4 RID: 11476
		[CompilerGenerated]
		private #sdd #f;

		// Token: 0x04002CD5 RID: 11477
		[CompilerGenerated]
		private int? #g;

		// Token: 0x04002CD6 RID: 11478
		[CompilerGenerated]
		private double[] #h;

		// Token: 0x04002CD7 RID: 11479
		[CompilerGenerated]
		private #rdd[] #i;

		// Token: 0x04002CD8 RID: 11480
		[CompilerGenerated]
		private TableAlignment #j;

		// Token: 0x04002CD9 RID: 11481
		[CompilerGenerated]
		private bool #k;

		// Token: 0x04002CDA RID: 11482
		[CompilerGenerated]
		private float #l;

		// Token: 0x04002CDB RID: 11483
		[CompilerGenerated]
		private #rdd #m;

		// Token: 0x04002CDC RID: 11484
		[CompilerGenerated]
		private bool[] #n;

		// Token: 0x04002CDD RID: 11485
		[CompilerGenerated]
		private bool[] #o;

		// Token: 0x04002CDE RID: 11486
		[CompilerGenerated]
		private #zTd #p;

		// Token: 0x04002CDF RID: 11487
		[CompilerGenerated]
		private bool #q;

		// Token: 0x02000D31 RID: 3377
		[Flags]
		protected enum #YUd
		{
			// Token: 0x04002CE1 RID: 11489
			#a = 0,
			// Token: 0x04002CE2 RID: 11490
			#b = 1,
			// Token: 0x04002CE3 RID: 11491
			#c = 2,
			// Token: 0x04002CE4 RID: 11492
			#d = 4,
			// Token: 0x04002CE5 RID: 11493
			#e = 1
		}
	}
}
