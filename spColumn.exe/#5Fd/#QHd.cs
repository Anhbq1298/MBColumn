using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using #7hc;
using #FCd;
using Aspose.Words;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #5Fd
{
	// Token: 0x02000D96 RID: 3478
	internal sealed class #QHd : #lEd
	{
		// Token: 0x06007DE6 RID: 32230 RVA: 0x001BB258 File Offset: 0x001B9458
		public #QHd(#ZGd #ib, int #Jhd, params double[] #Zpb) : base(#Jhd, #Zpb)
		{
			this.#a = #ib;
			this.#b = new int[#Zpb.Length];
			this.#c.Add(new #EGd());
		}

		// Token: 0x170025BE RID: 9662
		// (get) Token: 0x06007DE7 RID: 32231 RVA: 0x000666AE File Offset: 0x000648AE
		public static char MergedCellPadding
		{
			get
			{
				return '-';
			}
		}

		// Token: 0x170025BF RID: 9663
		// (get) Token: 0x06007DE8 RID: 32232 RVA: 0x000666B2 File Offset: 0x000648B2
		private bool RequiresDeformat
		{
			get
			{
				return base.CurrentRowIndex < this.#b || (this.#b == 0 && base.CurrentCellIndex == 0) || this.IsHtmlColumn;
			}
		}

		// Token: 0x170025C0 RID: 9664
		// (get) Token: 0x06007DE9 RID: 32233 RVA: 0x00059A33 File Offset: 0x00057C33
		private bool IsHtmlColumn
		{
			get
			{
				return base.HtmlColumns[base.CurrentCellIndex];
			}
		}

		// Token: 0x06007DEA RID: 32234 RVA: 0x000666E6 File Offset: 0x000648E6
		public override void #Fhd(int #1f, ParagraphAlignment #rT, params string[] #Qb)
		{
			this.#FHd(#1f, true, #rT, #Qb);
		}

		// Token: 0x06007DEB RID: 32235 RVA: 0x001BB2B0 File Offset: 0x001B94B0
		protected override void #1(bool #POb)
		{
			List<string> source = this.#IHd();
			int count = (this.#a.SplitLongTables && this.#b > 0) ? (this.#b + 1) : 0;
			#QGd #QGd = new #QGd();
			#QGd.Lines.AddRange(source.Take(count));
			bool #f = this.#a.Paginator.AutoSplitLongLines;
			try
			{
				this.#a.Paginator.AutoSplitLongLines = false;
				if (#QGd.Lines.Any<string>())
				{
					this.#a.Paginator.#cGd(#QGd.#PGd(#Phc.#3hc(107281469)), true);
				}
				this.#a.Paginator.NewPageStartContents.Add(#QGd);
				List<string> list = source.Skip(count).ToList<string>();
				for (int i = 0; i < list.Count; i++)
				{
					string #f2 = list[i];
					if (i == list.Count - 1)
					{
						this.#a.Paginator.#dGd(#f2, false);
					}
					else
					{
						this.#a.Paginator.#cGd(#f2, false);
					}
				}
			}
			finally
			{
				this.#a.Paginator.AutoSplitLongLines = #f;
				this.#a.Paginator.NewPageStartContents.Remove(#QGd);
			}
			if (source.Any<string>())
			{
				this.#a.Paginator.#cGd();
			}
		}

		// Token: 0x06007DEC RID: 32236 RVA: 0x000666FE File Offset: 0x000648FE
		protected override void #Ghd(#lEd.#YUd #ri, params string[] #Qb)
		{
			this.#FHd(1, false, base.CurrentStyle.HorizontalAlignment, #Qb);
		}

		// Token: 0x06007DED RID: 32237 RVA: 0x00066720 File Offset: 0x00064920
		protected override void #Hhd()
		{
			if (this.#c > 0 && base.CurrentCellIndex == 0)
			{
				this.#c.Add(new #EGd());
			}
		}

		// Token: 0x06007DEE RID: 32238 RVA: 0x001BB43C File Offset: 0x001B963C
		private static string #DHd(#BGd #Vpb, int #jhd)
		{
			string text = #Vpb.Value;
			if (\u008D\u0002.~\u008C\u0005(#Vpb.Value) == #jhd)
			{
				return text;
			}
			char c = (#Vpb.Alignment == ParagraphAlignment.Center && #Vpb.IsMerged) ? #QHd.MergedCellPadding : ' ';
			if (#Vpb.Alignment == ParagraphAlignment.Right)
			{
				return \u000F.~\u0090(text, #jhd, c);
			}
			if (#Vpb.Alignment == ParagraphAlignment.Center)
			{
				int num = (#jhd - \u008D\u0002.~\u008C\u0005(text)) / 2;
				text = \u000F.~\u0091(text, num + \u008D\u0002.~\u008C\u0005(text), c);
				text = \u000F.~\u0090(text, #jhd - 1, c);
				return \u000F.~\u0090(text, #jhd, ' ');
			}
			if (#Vpb.Alignment == ParagraphAlignment.Left && #Vpb.CellIndex > 0 && \u008D\u0002.~\u008C\u0005(text) < #jhd)
			{
				text = \u0007\u0005.~\u009A\u000E(text, 0, c.ToString());
			}
			return \u000F.~\u0091(text, #jhd, c);
		}

		// Token: 0x06007DEF RID: 32239 RVA: 0x0006674F File Offset: 0x0006494F
		private string #EHd(int #9bd)
		{
			if (base.NoSpacingColumns[#9bd])
			{
				return string.Empty;
			}
			return #Phc.#3hc(107399922);
		}

		// Token: 0x06007DF0 RID: 32240 RVA: 0x001BB54C File Offset: 0x001B974C
		private void #FHd(int #GHd, bool #HHd, ParagraphAlignment #rT, params string[] #Qb)
		{
			#EGd #EGd = this.#c.Last<#EGd>();
			string #f = \u0011\u0003.\u0018\u0007(string.Empty, #Qb);
			if (this.RequiresDeformat)
			{
				#f = this.#a.Deformatter.#NBd(#f);
			}
			#EGd.Cells.Add(new #BGd
			{
				Alignment = #rT,
				CellIndex = base.CurrentCellIndex,
				Merge = #GHd,
				Value = #f,
				ForceIsMerged = #HHd
			});
			this.#iEd(#GHd);
		}

		// Token: 0x06007DF1 RID: 32241 RVA: 0x001BB5E0 File Offset: 0x001B97E0
		private List<string> #IHd()
		{
			this.#LHd(false);
			List<string> list = this.#JHd();
			if (list.Any(new Func<string, bool>(this.#PHd)))
			{
				this.#LHd(true);
				list = this.#JHd();
			}
			return list;
		}

		// Token: 0x06007DF2 RID: 32242 RVA: 0x001BB62C File Offset: 0x001B982C
		private List<string> #JHd()
		{
			List<string> list = new List<string>(this.#c.Count + 1);
			StringBuilder stringBuilder = new StringBuilder(150);
			for (int i = 0; i < this.#c.Count; i++)
			{
				#EGd #EGd = this.#c[i];
				stringBuilder.Clear();
				for (int j = 0; j < #EGd.Cells.Count; j++)
				{
					#BGd #BGd = #EGd.Cells[j];
					int #jhd = this.#OHd(#BGd.CellIndex, #BGd.Merge);
					string value = this.#NHd(#BGd, #jhd);
					stringBuilder.Append(value);
					if (base.RightCellBorders[#BGd.CellIndex] > 0.0 || base.RightCellBorders[#BGd.CellIndex + #BGd.Merge - 1] > 0.0)
					{
						stringBuilder.Append(this.#d);
					}
				}
				list.Add(stringBuilder.ToString().TrimEnd(new char[0]));
				if (i == this.#b - 1)
				{
					list.Add(this.#KHd().TrimEnd(new char[0]));
				}
				if (i != this.#c.Count - 1 && base.BottomCellMargins.Contains(i))
				{
					list.Add(string.Empty);
				}
			}
			if (list.Any<string>() && string.IsNullOrWhiteSpace(list.Last<string>()))
			{
				list.RemoveAt(list.Count - 1);
			}
			return list;
		}

		// Token: 0x06007DF3 RID: 32243 RVA: 0x001BB7D0 File Offset: 0x001B99D0
		private string #KHd()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < base.ColumnCount; i++)
			{
				if (i > 0)
				{
					if (this.#b[i] > 0)
					{
						\u0097\u0003.~\u0011\u0008(stringBuilder, this.#EHd(i));
						int num = base.NoSpacingColumns[i] ? this.#b[i] : (this.#b[i] - 1);
						\u0097\u0003.~\u0011\u0008(stringBuilder, \u000F.~\u0091(string.Empty, num, #QHd.MergedCellPadding));
					}
				}
				else
				{
					\u0097\u0003.~\u0011\u0008(stringBuilder, \u000F.~\u0091(string.Empty, this.#b[i], #QHd.MergedCellPadding));
				}
				if (base.RightCellBorders[i] > 0.0)
				{
					\u0097\u0003.~\u0011\u0008(stringBuilder, \u0014.~\u0099(string.Empty, \u008D\u0002.~\u008C\u0005(this.#d)));
				}
			}
			return \u007F.~\u0011\u0002(stringBuilder);
		}

		// Token: 0x06007DF4 RID: 32244 RVA: 0x001BB8F0 File Offset: 0x001B9AF0
		private void #LHd(bool #MHd)
		{
			#QHd.#wWb #wWb = new #QHd.#wWb();
			\u0008\u0005.\u009B\u000E(this.#b, 0, this.#b.Length);
			#wWb.#a = \u008B\u0002.\u0089\u0005(base.ColumnWidths);
			List<double> list = base.ColumnWidths.Select(new Func<double, double>(#wWb.#cVd)).ToList<double>();
			int num = (this.#b > 0) ? 100 : 60;
			int[] array = new int[base.ColumnCount];
			for (int i = 0; i < base.ColumnCount; i++)
			{
				array[i] = (int)\u0006\u0002.\u0013\u0004(list[i] * (double)num);
			}
			bool[] array2 = new bool[base.ColumnCount];
			for (int j = this.#c.Count - 1; j >= 0; j--)
			{
				foreach (#BGd #BGd in this.#c[j].Cells)
				{
					if (!#BGd.IsMerged)
					{
						array2[#BGd.CellIndex] = true;
						if (!\u0003.\u0004(#BGd.Value))
						{
							bool flag = #BGd.CellIndex > 0 && base.NoSpacingColumns[#BGd.CellIndex];
							int num2 = (#BGd.CellIndex == 0) ? 0 : (flag ? 0 : 2);
							if (#MHd && #BGd.CellIndex > 0)
							{
								num2 = (flag ? 0 : 1);
							}
							this.#b[#BGd.CellIndex] = \u009A\u0003.\u0016\u0008(\u008D\u0002.~\u008C\u0005(#BGd.Value) + num2, this.#b[#BGd.CellIndex]);
						}
					}
				}
			}
			for (int k = 0; k < base.ColumnCount; k++)
			{
				if (this.#b[k] <= 0 && !array2[k])
				{
					this.#b[k] = array[k];
				}
			}
			for (int l = this.#c.Count - 1; l >= 0; l--)
			{
				foreach (#BGd #BGd2 in this.#c[l].Cells)
				{
					if (#BGd2.IsMerged)
					{
						int num3 = this.#OHd(#BGd2.CellIndex, #BGd2.Merge);
						int num4 = \u008D\u0002.~\u008C\u0005(#BGd2.Value) + 2;
						if (num3 < num4)
						{
							int m = num4 - num3;
							int num5 = 0;
							while (m > 0)
							{
								this.#b[#BGd2.CellIndex + num5]++;
								num5 = (num5 + 1) % #BGd2.Merge;
								m--;
							}
						}
					}
				}
			}
		}

		// Token: 0x06007DF5 RID: 32245 RVA: 0x001BBC0C File Offset: 0x001B9E0C
		private string #NHd(#BGd #Vpb, int #jhd)
		{
			string text = #QHd.#DHd(#Vpb, #jhd);
			if (#Vpb.CellIndex > 0 && #Vpb.Alignment == ParagraphAlignment.Left && this.#b <= 0)
			{
				return \u0019.\u0002\u0002(string.Empty.#O2d(), text);
			}
			return text;
		}

		// Token: 0x06007DF6 RID: 32246 RVA: 0x001BBC60 File Offset: 0x001B9E60
		private int #OHd(int #NHb, int #8r)
		{
			int num = 0;
			int num2 = #NHb + #8r - 1;
			for (int i = #NHb; i <= num2; i++)
			{
				num += this.#b[i];
				if (base.RightCellBorders[i] > 0.0 && i < num2)
				{
					num += \u008D\u0002.~\u008C\u0005(this.#d);
				}
			}
			return num;
		}

		// Token: 0x06007DF7 RID: 32247 RVA: 0x00066777 File Offset: 0x00064977
		[CompilerGenerated]
		private bool #PHd(string #Rf)
		{
			return \u008D\u0002.~\u008C\u0005(#Rf) > this.#a.Paginator.LineWidth;
		}

		// Token: 0x0400338C RID: 13196
		private readonly #ZGd #a;

		// Token: 0x0400338D RID: 13197
		private new readonly int[] #b;

		// Token: 0x0400338E RID: 13198
		private new readonly List<#EGd> #c = new List<#EGd>();

		// Token: 0x0400338F RID: 13199
		private readonly string #d = #Phc.#3hc(107399922);

		// Token: 0x02000D97 RID: 3479
		[CompilerGenerated]
		private sealed class #wWb
		{
			// Token: 0x06007DF9 RID: 32249 RVA: 0x000667A2 File Offset: 0x000649A2
			internal double #cVd(double #Rf)
			{
				return #Rf / this.#a;
			}

			// Token: 0x04003390 RID: 13200
			public double #a;
		}
	}
}
