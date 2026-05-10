using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #FCd;
using #o1d;
using #Qcd;
using #VEd;
using #wdd;
using Aspose.Words;
using Aspose.Words.Tables;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Paged.WordPdf
{
	// Token: 0x02000D6D RID: 3437
	public class AsposeTableWriter : #lEd
	{
		// Token: 0x06007CC5 RID: 31941 RVA: 0x001B6DE8 File Offset: 0x001B4FE8
		public AsposeTableWriter(#4Ed context, int headerRowsCount, params double[] columnWidths) : base(headerRowsCount, columnWidths)
		{
			base.SupportsTextWrapping = true;
			this.#a = context;
			this.#b = context.Builder;
			this.#b.Font.Size = ((context.PrintOptions != null) ? context.PrintOptions.FontInfo.ContentFontSize : 8.0);
			this.#b.Font.NoProofing = true;
			this.#d = this.#b.StartTable();
			base.PreferredWidth = 100f;
		}

		// Token: 0x1700257E RID: 9598
		// (get) Token: 0x06007CC6 RID: 31942 RVA: 0x000656A4 File Offset: 0x000638A4
		protected Table Table { get; }

		// Token: 0x1700257F RID: 9599
		// (get) Token: 0x06007CC7 RID: 31943 RVA: 0x000656B0 File Offset: 0x000638B0
		// (set) Token: 0x06007CC8 RID: 31944 RVA: 0x000656BC File Offset: 0x000638BC
		public bool AllowAutoFit { get; set; }

		// Token: 0x17002580 RID: 9600
		// (get) Token: 0x06007CC9 RID: 31945 RVA: 0x000656CD File Offset: 0x000638CD
		// (set) Token: 0x06007CCA RID: 31946 RVA: 0x000656D9 File Offset: 0x000638D9
		public bool FixColumnWidths { get; set; }

		// Token: 0x06007CCB RID: 31947 RVA: 0x001B6E80 File Offset: 0x001B5080
		public static void #jFd(Cell #kFd, Cell #lFd)
		{
			Table table = \u0012\u0004.~\u0092\u0008(\u0011\u0004.~\u0090\u0008(#kFd));
			Point point = new Point(\u0013\u0004.~\u0094\u0008(\u0011\u0004.~\u0090\u0008(#kFd), #kFd), \u0013\u0004.~\u0094\u0008(table, \u0011\u0004.~\u0090\u0008(#kFd)));
			Point point2 = new Point(\u0013\u0004.~\u0094\u0008(\u0011\u0004.~\u0090\u0008(#lFd), #lFd), \u0013\u0004.~\u0094\u0008(table, \u0011\u0004.~\u0090\u0008(#lFd)));
			Rectangle rectangle = new Rectangle(\u009A\u0003.\u0015\u0008(point.X, point2.X), \u009A\u0003.\u0015\u0008(point.Y, point2.Y), \u0014\u0004.\u0096\u0008(point2.X - point.X) + 1, \u0014\u0004.\u0096\u0008(point2.Y - point.Y) + 1);
			IEnumerator enumerator = \u0091\u0002.~\u009E\u0005(\u0015\u0004.~\u0098\u0008(table));
			try
			{
				while (\u0010\u0002.~\u0019\u0004(enumerator))
				{
					Row row = (Row)\u0092\u0002.~\u009F\u0005(enumerator);
					IEnumerator enumerator2 = \u0091\u0002.~\u009E\u0005(\u0016\u0004.~\u0099\u0008(row));
					try
					{
						while (\u0010\u0002.~\u0019\u0004(enumerator2))
						{
							Cell cell = (Cell)\u0092\u0002.~\u009F\u0005(enumerator2);
							Point pt = new Point(\u0013\u0004.~\u0094\u0008(row, cell), \u0013\u0004.~\u0094\u0008(table, row));
							if (rectangle.Contains(pt))
							{
								\u0017\u0004.~\u009A\u0008(cell).HorizontalMerge = ((pt.X == rectangle.X) ? CellMerge.First : CellMerge.Previous);
								\u0017\u0004.~\u009A\u0008(cell).VerticalMerge = ((pt.Y == rectangle.Y) ? CellMerge.First : CellMerge.Previous);
							}
						}
					}
					finally
					{
						IDisposable disposable = enumerator2 as IDisposable;
						if (disposable != null)
						{
							\u0007.~\u000E(disposable);
						}
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					\u0007.~\u000E(disposable);
				}
			}
		}

		// Token: 0x06007CCC RID: 31948 RVA: 0x001B70E0 File Offset: 0x001B52E0
		protected override void #1(bool #POb)
		{
			base.#4Dd();
			int num = 0;
			while (num < this.#b && this.#a.SplitLongTables)
			{
				\u0095.~\u007F\u0003(\u001A\u0004.~\u009F\u0008(\u0019\u0004.~\u009E\u0008(\u0015\u0004.~\u0098\u0008(this.Table), num)), true);
				num++;
			}
			this.#pFd();
			if (\u008D\u0002.~\u0091\u0005(\u0015\u0004.~\u0098\u0008(this.Table)) > 0 && \u008D\u0002.~\u0091\u0005(\u0016\u0004.~\u0099\u0008(\u0019\u0004.~\u009E\u0008(\u0015\u0004.~\u0098\u0008(this.Table), 0))) > 0)
			{
				if (base.TableLeftIndent != null)
				{
					\u009F\u0002.~\u0080\u0006(this.Table, base.TableLeftIndent.Value);
				}
				else
				{
					Cell cell = \u001B\u0004.~\u0001\u000E(\u0019\u0004.~\u009E\u0008(\u0015\u0004.~\u0098\u0008(this.Table), 0));
					\u009F\u0002.~\u0080\u0006(this.Table, \u001B\u0002.~\u009C\u0004(\u0017\u0004.~\u009A\u0008(cell)));
				}
			}
			\u0012\u0004.~\u0093\u0008(this.#b);
			if (base.AutoSizeMode == #sdd.#a)
			{
				if (base.TableWidthType == #rdd.#a)
				{
					int? num2 = this.#c;
					int num3 = #2dd.CellAutoFitDigitsThreshold;
					if (num2.GetValueOrDefault() > num3 & num2 != null)
					{
						\u001C\u0004.~\u0004\u000E(this.Table, AutoFitBehavior.AutoFitToWindow);
					}
					\u0095.~\u0080\u0003(this.Table, this.AllowAutoFit);
					PageSetup pageSetup = \u009F\u0003.~\u001B\u0008(this.#b);
					double num4 = this.#nFd() - \u001B\u0002.~\u009A\u0004(pageSetup) - \u001B\u0002.~\u009B\u0004(pageSetup);
					\u001E\u0004.~\u0007\u000E(this.Table, \u001D\u0004.\u0005\u000E(num4 * (double)base.PreferredWidth / 100.0));
					\u001F\u0004.~\u000E\u000E(this.Table, TableAlignment.Center);
				}
				else
				{
					\u001E\u0004.~\u0007\u000E(this.Table, this.#oFd(base.TableWidthType, (double)base.PreferredWidth));
					this.Table.AllowAutoFit = (base.TableWidthType == #rdd.#c || base.TableWidthType == #rdd.#a);
				}
			}
			else if (base.AutoSizeMode == #sdd.#b)
			{
				\u001C\u0004.~\u0004\u000E(this.Table, AutoFitBehavior.AutoFitToWindow);
			}
			else if (base.AutoSizeMode == #sdd.#c)
			{
				\u001C\u0004.~\u0004\u000E(this.Table, AutoFitBehavior.AutoFitToContents);
			}
			if (this.#b > 0 || base.EnforceTableAlignment)
			{
				\u001F\u0004.~\u000E\u000E(this.Table, base.TableAlignment);
			}
			\u0007.~\u0019(\u0005\u0004.~\u0083\u0008(this.#b));
			\u0095.~\u0081\u0003(\u0005\u0004.~\u0083\u0008(this.#b), true);
		}

		// Token: 0x06007CCD RID: 31949 RVA: 0x001B73F0 File Offset: 0x001B55F0
		protected override void #kEd()
		{
			\u007F\u0004.~\u000F\u000E(\u0007\u0004.~\u0089\u0008(this.#b), base.CurrentStyle.HorizontalAlignment);
			if (base.CurrentStyle.Background != null)
			{
				\u0002\u0004.~\u001F\u0008(\u0080\u0004.~\u0010\u000E(\u0017\u0004.~\u009B\u0008(this.#b)), base.CurrentStyle.Background.Value);
			}
			\u0095.~\u0082\u0003(this.#b, base.CurrentStyle.Bold);
		}

		// Token: 0x06007CCE RID: 31950 RVA: 0x000656EA File Offset: 0x000638EA
		protected override void #Hhd()
		{
			if (this.#c > 0 && base.CurrentCellIndex == 0)
			{
				\u0011\u0004.~\u0091\u0008(this.#b);
			}
		}

		// Token: 0x06007CCF RID: 31951 RVA: 0x001B74A8 File Offset: 0x001B56A8
		protected PreferredWidth #mFd()
		{
			#rdd #rdd = base.ColumnWidthTypes[base.CurrentCellIndex];
			double num = base.ColumnWidths[base.CurrentCellIndex];
			if (this.FixColumnWidths && base.TableWidthType == #rdd.#a && base.AutoSizeMode == #sdd.#a && #rdd == #rdd.#a)
			{
				PageSetup pageSetup = \u009F\u0003.~\u001B\u0008(this.#b);
				double num2 = (this.#nFd() - \u001B\u0002.~\u009A\u0004(pageSetup) - \u001B\u0002.~\u009B\u0004(pageSetup)) * (double)base.PreferredWidth / 100.0;
				return \u001D\u0004.\u0005\u000E(num * num2);
			}
			return this.#oFd(#rdd, num);
		}

		// Token: 0x06007CD0 RID: 31952 RVA: 0x001B7564 File Offset: 0x001B5764
		protected override void #Ghd(#lEd.#YUd #ri, params string[] #Qb)
		{
			Cell cell = \u001B\u0004.~\u0002\u000E(this.#b);
			\u0017\u0004.~\u009A\u0008(cell).HorizontalMerge = (#ri.HasFlag(#lEd.#YUd.#c) ? CellMerge.First : CellMerge.None);
			\u0017\u0004.~\u009A\u0008(cell).HorizontalMerge = (#ri.HasFlag(#lEd.#YUd.#d) ? CellMerge.Previous : \u0081\u0004.~\u0011\u000E(\u0017\u0004.~\u009A\u0008(cell)));
			\u001E\u0004.~\u0008\u000E(\u0017\u0004.~\u009A\u0008(cell), this.#mFd());
			this.#kEd();
			if (#ri.HasFlag(#lEd.#YUd.#b))
			{
				string text = \u0011\u0003.\u0018\u0007(string.Empty, #Qb);
				int? num = #2dd.#Tdd(text);
				this.#c = new int?(\u009A\u0003.\u0016\u0008(num.GetValueOrDefault(), this.#c.GetValueOrDefault()));
				if (#2dd.#Ydd(text))
				{
					\u0082\u0004.~\u0012\u000E(this.#b, text, true);
				}
				else
				{
					\u0007\u0003.~\u0007\u0007(this.#b, text);
				}
			}
			this.#iEd(1);
		}

		// Token: 0x06007CD1 RID: 31953 RVA: 0x0006571A File Offset: 0x0006391A
		private double #nFd()
		{
			return \u001B\u0002.~\u0099\u0004(\u009F\u0003.~\u001B\u0008(this.#b));
		}

		// Token: 0x06007CD2 RID: 31954 RVA: 0x001B76AC File Offset: 0x001B58AC
		private PreferredWidth #oFd(#rdd #YDd, double #f)
		{
			switch (#YDd)
			{
			case #rdd.#a:
				return \u001D\u0004.\u0006\u000E(#f);
			case #rdd.#b:
				return \u001D\u0004.\u0005\u000E(#f);
			case #rdd.#c:
				return Aspose.Words.Tables.PreferredWidth.Auto;
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107282317), #YDd, null);
			}
		}

		// Token: 0x06007CD3 RID: 31955 RVA: 0x001B7710 File Offset: 0x001B5910
		private void #pFd()
		{
			int num = \u008D\u0002.~\u0091\u0005(\u0015\u0004.~\u0098\u0008(this.Table)) - 1;
			base.Borders.ApplyOuterBorder = false;
			base.Borders.RowsCount = \u008D\u0002.~\u0091\u0005(\u0015\u0004.~\u0098\u0008(this.Table));
			\u0007.~\u001B(this.Table);
			int num2 = this.#hEd();
			for (int i = 0; i <= num; i++)
			{
				Row row = \u0019\u0004.~\u009E\u0008(\u0015\u0004.~\u0098\u0008(this.Table), i);
				\u0095.~\u0083\u0003(\u001A\u0004.~\u009F\u0008(row), false);
				bool flag = i == num;
				int num3 = \u008D\u0002.~\u0091\u0005(\u0016\u0004.~\u0099\u0008(row)) - 1;
				for (int j = 0; j <= num3; j++)
				{
					Cell cell = \u0083\u0004.~\u0013\u000E(\u0016\u0004.~\u0099\u0008(row), j);
					bool flag2 = j == 0;
					bool flag3 = j == num3;
					\u0084\u0004.~\u0014\u000E(cell, NodeType.Paragraph, true).OfType<Paragraph>().#I1d(new Action<Paragraph>(AsposeTableWriter.<>c.<>9.#ZUd));
					CellFormat cellFormat = \u0017\u0004.~\u009A\u0008(cell);
					BorderCollection borderCollection = \u0086\u0004.~\u0015\u000E(cellFormat);
					double num4 = base.Borders.#aDd(i, j);
					double num5 = base.Borders.#dDd(i, j);
					double num6 = base.Borders.#cDd(i, j);
					double num7 = base.Borders.#bDd(i, j);
					\u0087\u0004.~\u0016\u000E(borderCollection).#CCd(num4);
					\u0087\u0004.~\u0017\u000E(borderCollection).#CCd(num6);
					\u0087\u0004.~\u0018\u000E(borderCollection).#CCd(num7);
					\u0087\u0004.~\u0019\u000E(borderCollection).#CCd(num5);
					if (this.#b <= 0)
					{
						if (!flag)
						{
							\u0002\u0004.~\u007F\u0008(\u0087\u0004.~\u0018\u000E(borderCollection), #2dd.#e);
						}
						cell.#rFd(2.0);
					}
					else
					{
						if (base.AutoSizeMode == #sdd.#c)
						{
							cellFormat.LeftPadding = (cellFormat.RightPadding = ((flag2 || flag3) ? 2.5 : 3.0));
						}
						else
						{
							cellFormat.LeftPadding = (cellFormat.RightPadding = ((flag2 || flag3) ? 2.5 : 1.5));
						}
						\u009F\u0002 ~_u0084_u = \u009F\u0002.~\u0084\u0006;
						object obj = cellFormat;
						double num8;
						\u009F\u0002.~\u0083\u0006(cellFormat, num8 = 1.0);
						~_u0084_u(obj, num8);
						if (i < this.#b)
						{
							IEnumerator enumerator = \u0091\u0002.~\u009E\u0005(\u0088\u0004.~\u001A\u000E(cell));
							try
							{
								while (\u0010\u0002.~\u0019\u0004(enumerator))
								{
									\u0095.~\u0084\u0003(\u0007\u0004.~\u008A\u0008((Paragraph)\u0092\u0002.~\u009F\u0005(enumerator)), true);
								}
							}
							finally
							{
								IDisposable disposable = enumerator as IDisposable;
								if (disposable != null)
								{
									\u0007.~\u000E(disposable);
								}
							}
							\u009F\u0002.~\u0084\u0006(cellFormat, 2.0);
							\u0095.~\u0086\u0003(cellFormat, true);
						}
						if (i < num2)
						{
							IEnumerator enumerator = \u0091\u0002.~\u009E\u0005(\u0084\u0004.~\u0014\u000E(cell, NodeType.Run, true));
							try
							{
								while (\u0010\u0002.~\u0019\u0004(enumerator))
								{
									\u0095.~\u001F\u0003(\u0005\u0004.~\u0084\u0008((Run)\u0092\u0002.~\u009F\u0005(enumerator)), true);
								}
							}
							finally
							{
								IDisposable disposable = enumerator as IDisposable;
								if (disposable != null)
								{
									\u0007.~\u000E(disposable);
								}
							}
						}
						if (num5 > 0.0)
						{
							Cell cell2 = null;
							for (int k = j; k >= 0; k--)
							{
								cell2 = \u0083\u0004.~\u0013\u000E(\u0016\u0004.~\u0099\u0008(row), k);
								if (\u0081\u0004.~\u0011\u000E(\u0017\u0004.~\u009A\u0008(cell2)) != CellMerge.Previous)
								{
									break;
								}
							}
							if (cell2 != null)
							{
								\u0087\u0004.~\u0019\u000E(\u0086\u0004.~\u0015\u000E(\u0017\u0004.~\u009A\u0008(cell2))).#CCd(num5);
							}
						}
					}
				}
			}
		}

		// Token: 0x0400331F RID: 13087
		private readonly #4Ed #a;

		// Token: 0x04003320 RID: 13088
		private new readonly DocumentBuilder #b;

		// Token: 0x04003321 RID: 13089
		private new int? #c;

		// Token: 0x04003322 RID: 13090
		[CompilerGenerated]
		private readonly Table #d;

		// Token: 0x04003323 RID: 13091
		[CompilerGenerated]
		private bool #e = true;

		// Token: 0x04003324 RID: 13092
		[CompilerGenerated]
		private bool #f;
	}
}
