using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #FCd;
using #wdd;
using Aspose.Words;
using ClosedXML.Excel;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #QBd
{
	// Token: 0x02000D4E RID: 3406
	internal sealed class #4Bd : #lEd
	{
		// Token: 0x06007BFE RID: 31742 RVA: 0x00064A78 File Offset: 0x00062C78
		public #4Bd(#VBd #ib, int #Jhd, params double[] #Zpb) : base(#Jhd, #Zpb)
		{
			this.#a = #ib;
			this.#b = #ib.Workbook;
			base.PreferredWidth = 100f;
		}

		// Token: 0x17002551 RID: 9553
		// (get) Token: 0x06007BFF RID: 31743 RVA: 0x00064AA0 File Offset: 0x00062CA0
		// (set) Token: 0x06007C00 RID: 31744 RVA: 0x00064AAC File Offset: 0x00062CAC
		internal int[] PixelWidths { get; set; }

		// Token: 0x17002552 RID: 9554
		// (get) Token: 0x06007C01 RID: 31745 RVA: 0x00064ABD File Offset: 0x00062CBD
		private bool RequiresDeformat
		{
			get
			{
				return base.CurrentRowIndex < this.#b || (this.#b == 0 && base.CurrentCellIndex == 0) || this.IsHtmlColumn;
			}
		}

		// Token: 0x17002553 RID: 9555
		// (get) Token: 0x06007C02 RID: 31746 RVA: 0x00059A33 File Offset: 0x00057C33
		private bool IsHtmlColumn
		{
			get
			{
				return base.HtmlColumns[base.CurrentCellIndex];
			}
		}

		// Token: 0x17002554 RID: 9556
		// (get) Token: 0x06007C03 RID: 31747 RVA: 0x00064AF1 File Offset: 0x00062CF1
		// (set) Token: 0x06007C04 RID: 31748 RVA: 0x00064AFD File Offset: 0x00062CFD
		public bool ForcePreferredWidth { get; set; }

		// Token: 0x06007C05 RID: 31749 RVA: 0x001B4634 File Offset: 0x001B2834
		public override void #Fhd(int #1f, ParagraphAlignment #rT, params string[] #Qb)
		{
			\u0019\u0003 ~_u007F_u = \u0019\u0003.~\u007F\u0007;
			\u0018\u0003 ~_u001F_u = \u0018\u0003.~\u001F\u0007;
			\u0017\u0003 ~_u001E_u = \u0017\u0003.~\u001E\u0007;
			IXLWorksheet ixlworksheet = \u0015\u0003.~\u001C\u0007(this.#b).Last<IXLWorksheet>();
			int num = base.CurrentCellIndex + 1;
			int num2 = base.CurrentRowIndex + 1;
			IXLCell #Vpb = ixlworksheet.Cell(num2, num);
			this.#3Bd(#Vpb, #Qb);
			this.#2Bd(#Vpb, new ParagraphAlignment?(#rT));
			~_u007F_u(~_u001F_u(~_u001E_u(ixlworksheet, num2, num, num2, num + #1f - 1), 1));
			this.#iEd(#1f);
		}

		// Token: 0x06007C06 RID: 31750 RVA: 0x001B46C4 File Offset: 0x001B28C4
		protected override void #1(bool #POb)
		{
			base.#1(#POb);
			base.#4Dd();
			IXLWorksheet ixlworksheet = \u0015\u0003.~\u001C\u0007(this.#b).Last<IXLWorksheet>();
			base.Borders.RowsCount = base.CurrentRowIndex;
			base.Borders.ApplyOuterBorder = true;
			int num = base.CurrentRowIndex;
			int num2 = base.ColumnCount;
			int num3 = this.#hEd();
			for (int i = 1; i <= num; i++)
			{
				for (int j = 1; j <= num2; j++)
				{
					int #uI = i - 1;
					int #Vpb = j - 1;
					double num4 = base.Borders.#aDd(#uI, #Vpb);
					double num5 = base.Borders.#dDd(#uI, #Vpb);
					double num6 = base.Borders.#cDd(#uI, #Vpb);
					double num7 = base.Borders.#bDd(#uI, #Vpb);
					IXLCell ixlcell = \u0016\u0003.~\u001D\u0007(ixlworksheet, i, j);
					this.#ZBd(ixlcell, num4 > 0.0, num6 > 0.0, num5 > 0.0, num7 > 0.0);
					\u0095.~\u001D\u0003(\u001B\u0003.~\u0082\u0007(\u001A\u0003.~\u0080\u0007(ixlcell)), false);
					if (i < num3 + 1)
					{
						\u0095.~\u001E\u0003(\u001C\u0003.~\u0083\u0007(\u001A\u0003.~\u0080\u0007(ixlcell)), true);
						if (\u0010\u0002.~\u001B\u0004(ixlcell))
						{
							\u001D\u0003.~\u0084\u0007(ixlcell).Bold = true;
						}
					}
					if (this.#b <= 0)
					{
						\u0081\u0003 ~_u008D_u = \u0081\u0003.~\u008D\u0007;
						IXLBorder ixlborder = \u001F\u0003.~\u0087\u0007(\u001A\u0003.~\u0081\u0007(\u001E\u0003.~\u0086\u0007(\u0017\u0003.~\u001E\u0007(ixlworksheet, i, 1, i, base.ColumnWidths.Length))));
						ixlborder.BottomBorder = XLBorderStyleValues.Thin;
						~_u008D_u(ixlborder, \u0080\u0003.\u008C\u0007(#2dd.#e));
					}
				}
			}
			this.#YBd();
		}

		// Token: 0x06007C07 RID: 31751 RVA: 0x001B48DC File Offset: 0x001B2ADC
		protected override void #Ghd(#lEd.#YUd #ri, params string[] #Qb)
		{
			\u0016\u0003 ~_u001D_u = \u0016\u0003.~\u001D\u0007;
			object obj = \u0015\u0003.~\u001C\u0007(this.#b).Last<IXLWorksheet>();
			int num = base.CurrentCellIndex + 1;
			int num2 = base.CurrentRowIndex + 1;
			IXLCell #Vpb = ~_u001D_u(obj, num2, num);
			this.#3Bd(#Vpb, #Qb);
			this.#2Bd(#Vpb, null);
			this.#iEd(1);
		}

		// Token: 0x06007C08 RID: 31752 RVA: 0x00064B0E File Offset: 0x00062D0E
		private double #WBd(double #XBd)
		{
			return \u0006\u0002.\u0013\u0004((#XBd / 7.0 * 256.0 - 18.285714285714285) / 256.0);
		}

		// Token: 0x06007C09 RID: 31753 RVA: 0x001B4948 File Offset: 0x001B2B48
		private void #YBd()
		{
			IXLWorksheet ixlworksheet = \u0015\u0003.~\u001C\u0007(this.#b).Last<IXLWorksheet>();
			if (this.PixelWidths == null)
			{
				#4Bd.#HUb #HUb = new #4Bd.#HUb();
				#HUb.#a = \u008B\u0002.\u0089\u0005(base.ColumnWidths);
				List<double> list = base.ColumnWidths.Select(new Func<double, double>(#HUb.#WUd)).ToList<double>();
				double num = ((this.#b > 0 || this.ForcePreferredWidth) ? ((double)base.PreferredWidth) : 50.0) / 100.0;
				for (int i = 0; i < base.ColumnWidths.Length; i++)
				{
					\u009F\u0002.~\u0019\u0006(\u0082\u0003.~\u0091\u0007(ixlworksheet, i + 1), \u0006\u0002.\u0014\u0004(list[i] * 140.0 * num));
				}
				return;
			}
			for (int j = 0; j < base.ColumnCount; j++)
			{
				\u009F\u0002.~\u0019\u0006(\u0082\u0003.~\u0091\u0007(ixlworksheet, j + 1), this.#WBd((double)this.PixelWidths[j]));
			}
		}

		// Token: 0x06007C0A RID: 31754 RVA: 0x001B4A88 File Offset: 0x001B2C88
		private void #ZBd(IXLCell #Vpb, bool #Sc, bool #ZW, bool #Tc, bool #0W)
		{
			IXLBorder ixlborder = \u001F\u0003.~\u0087\u0007(\u001A\u0003.~\u0080\u0007(#Vpb));
			if (#Sc)
			{
				\u007F\u0003.~\u0089\u0007(ixlborder, XLBorderStyleValues.Thin);
				\u0081\u0003.~\u008E\u0007(ixlborder, \u0080\u0003.\u008C\u0007(\u0083\u0003.\u0092\u0007()));
			}
			if (#ZW)
			{
				\u007F\u0003.~\u008A\u0007(ixlborder, XLBorderStyleValues.Thin);
				\u0081\u0003.~\u008F\u0007(ixlborder, \u0080\u0003.\u008C\u0007(\u0083\u0003.\u0092\u0007()));
			}
			if (#Tc)
			{
				\u007F\u0003.~\u008B\u0007(ixlborder, XLBorderStyleValues.Thin);
				\u0081\u0003.~\u0090\u0007(ixlborder, \u0080\u0003.\u008C\u0007(\u0083\u0003.\u0092\u0007()));
			}
			if (#0W)
			{
				\u007F\u0003.~\u0088\u0007(ixlborder, XLBorderStyleValues.Thin);
				\u0081\u0003.~\u008D\u0007(ixlborder, \u0080\u0003.\u008C\u0007(\u0083\u0003.\u0092\u0007()));
			}
		}

		// Token: 0x06007C0B RID: 31755 RVA: 0x001B4B88 File Offset: 0x001B2D88
		private XLAlignmentHorizontalValues #0Bd(ParagraphAlignment? #1Bd = null)
		{
			switch (#1Bd ?? base.CurrentStyle.HorizontalAlignment)
			{
			case ParagraphAlignment.Left:
				return XLAlignmentHorizontalValues.Left;
			case ParagraphAlignment.Center:
				return XLAlignmentHorizontalValues.Center;
			case ParagraphAlignment.Right:
				return XLAlignmentHorizontalValues.Right;
			case ParagraphAlignment.Justify:
				return XLAlignmentHorizontalValues.Justify;
			case ParagraphAlignment.Distributed:
				return XLAlignmentHorizontalValues.Distributed;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x06007C0C RID: 31756 RVA: 0x001B4BEC File Offset: 0x001B2DEC
		private void #2Bd(IXLCell #Vpb, ParagraphAlignment? #rT = null)
		{
			#Vpb.Style.Alignment.Horizontal = this.#0Bd(#rT);
			if (base.CurrentStyle.Background != null)
			{
				#Vpb.Style.Fill.BackgroundColor = XLColor.FromColor(base.CurrentStyle.Background.Value);
			}
			#Vpb.Style.Font.Bold = base.CurrentStyle.Bold;
			if (#Vpb.HasRichText)
			{
				#Vpb.RichText.Bold = base.CurrentStyle.Bold;
			}
		}

		// Token: 0x06007C0D RID: 31757 RVA: 0x001B4CA4 File Offset: 0x001B2EA4
		private void #3Bd(IXLCell #Vpb, params string[] #Qb)
		{
			string text = \u0011\u0003.\u0018\u0007(string.Empty, #Qb);
			string text2;
			if (true)
			{
				text2 = text;
			}
			if (!\u0003.\u0005(text2))
			{
				string text3 = text2;
				if (\u0080.~\u001F\u0002(text2, #Phc.#3hc(107408434)))
				{
					IEnumerable<char> source = text2;
					Func<char, bool> predicate;
					if ((predicate = #4Bd.#2Ui.#a) == null)
					{
						predicate = (#4Bd.#2Ui.#a = new Func<char, bool>(char.IsLetter));
					}
					if (source.Any(predicate))
					{
						text3 = \u0019.\u0002\u0002(string.Empty.#O2d(), text3);
					}
				}
				text2 = \u0012.~\u0095(text2, #Phc.#3hc(107408397), #Phc.#3hc(107356879));
				double num;
				if (\u0086\u0003.\u0096\u0007(text2, NumberStyles.Any, \u0097\u0002.\u0008\u0006(), ref num))
				{
					\u008A.~\u0090\u0002(#Vpb, num);
					\u0087\u0003.~\u0097\u0007(#Vpb, XLDataType.Number);
					int num2 = \u0011.~\u0094(text2, #Phc.#3hc(107356879), StringComparison.Ordinal);
					if (num2 >= 0 && num2 != \u008D\u0002.~\u008C\u0005(text2) - 1 && !text2.#7tc(#Phc.#3hc(107449693), StringComparison.OrdinalIgnoreCase))
					{
						int num3 = \u008D\u0002.~\u008C\u0005(text2) - num2 - 1;
						\u0007\u0003.~\u0006\u0007(\u0088\u0003.~\u0098\u0007(\u001A\u0003.~\u0080\u0007(#Vpb)), \u000F.\u0091(#Phc.#3hc(107251753), 2 + num3, '0'));
						return;
					}
				}
				else
				{
					if (this.RequiresDeformat)
					{
						this.#a.Deformatter.#NBd(\u001D\u0003.~\u0084\u0007(#Vpb), text3);
						return;
					}
					\u008A.~\u0090\u0002(#Vpb, text3);
				}
			}
		}

		// Token: 0x040032D5 RID: 13013
		private readonly #VBd #a;

		// Token: 0x040032D6 RID: 13014
		private new readonly XLWorkbook #b;

		// Token: 0x040032D7 RID: 13015
		[CompilerGenerated]
		private new int[] #c;

		// Token: 0x040032D8 RID: 13016
		[CompilerGenerated]
		private bool #d;

		// Token: 0x02000D4F RID: 3407
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x040032D9 RID: 13017
			public static Func<char, bool> #a;
		}

		// Token: 0x02000D50 RID: 3408
		[CompilerGenerated]
		private sealed class #HUb
		{
			// Token: 0x06007C0F RID: 31759 RVA: 0x00064B4B File Offset: 0x00062D4B
			internal double #WUd(double #Rf)
			{
				return #Rf / this.#a;
			}

			// Token: 0x040032DA RID: 13018
			public double #a;
		}
	}
}
