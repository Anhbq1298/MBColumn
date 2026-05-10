using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #3Rd;
using #7hc;
using #o1d;
using #VEd;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Tables;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Paged.WordPdf
{
	// Token: 0x02000D74 RID: 3444
	public sealed class SvgInsertHelper
	{
		// Token: 0x06007D00 RID: 32000 RVA: 0x000659E7 File Offset: 0x00063BE7
		public SvgInsertHelper(DocumentBuilder builder, #UEd renderer)
		{
			this.#d = renderer;
			this.Builder = builder;
			this.#e = new Dictionary<string, int>();
		}

		// Token: 0x1700258C RID: 9612
		// (get) Token: 0x06007D01 RID: 32001 RVA: 0x00065A08 File Offset: 0x00063C08
		// (set) Token: 0x06007D02 RID: 32002 RVA: 0x00065A14 File Offset: 0x00063C14
		public DocumentBuilder Builder { get; private set; }

		// Token: 0x1700258D RID: 9613
		// (get) Token: 0x06007D03 RID: 32003 RVA: 0x001B87F8 File Offset: 0x001B69F8
		public int NumberOfDrawingsPerPage
		{
			get
			{
				if (\u001B\u0002.~\u0099\u0004(\u009F\u0003.~\u001B\u0008(this.Builder)) <= \u001B\u0002.~\u009D\u0004(\u009F\u0003.~\u001B\u0008(this.Builder)))
				{
					return 2;
				}
				return 1;
			}
		}

		// Token: 0x06007D04 RID: 32004 RVA: 0x001B884C File Offset: 0x001B6A4C
		public void #Scd(string #Tcd, string #Ukc = " ")
		{
			if (!\u0003.\u0004(#Tcd))
			{
				\u009C\u0003.~\u0018\u0008(this.Builder, #Tcd);
				\u0099\u0004.~\u008B\u000E(\u0007\u0004.~\u0089\u0008(this.Builder), StyleIdentifier.NoSpacing);
				\u0007\u0003.~\u0007\u0007(this.Builder, #Ukc);
				\u009D\u0003.~\u0019\u0008(this.Builder, #Tcd);
				\u0007.~\u001A(\u0007\u0004.~\u0089\u0008(this.Builder));
			}
		}

		// Token: 0x06007D05 RID: 32005 RVA: 0x001B88E8 File Offset: 0x001B6AE8
		public Size #WFd(double #jdd, bool #kdd = false)
		{
			PageSetup pageSetup = \u009F\u0003.~\u001B\u0008(this.Builder);
			double num = (\u009A\u0004.~\u008C\u000E(pageSetup) == Orientation.Portrait) ? \u001B\u0002.~\u0099\u0004(pageSetup) : \u001B\u0002.~\u009D\u0004(pageSetup);
			double num2 = (\u009A\u0004.~\u008C\u000E(pageSetup) == Orientation.Landscape) ? \u001B\u0002.~\u009D\u0004(pageSetup) : \u001B\u0002.~\u0099\u0004(pageSetup);
			double num3 = (num - \u001B\u0002.~\u009A\u0004(pageSetup) - \u001B\u0002.~\u009B\u0004(pageSetup)) * #jdd;
			double num4 = (num2 - \u001B\u0002.~\u009E\u0004(pageSetup) - \u001B\u0002.~\u009F\u0004(pageSetup)) * #jdd * 0.7;
			if (#kdd)
			{
				num4 = num3;
			}
			if (num3 <= 0.0 || num4 <= 0.0)
			{
				throw new Exception(Localization.StringNotEnoughSpaceToPrepareTheDrawing.#z2d());
			}
			return new Size(num3, num4);
		}

		// Token: 0x06007D06 RID: 32006 RVA: 0x001B89E8 File Offset: 0x001B6BE8
		public Size #idd(double #jdd, bool #kdd = false)
		{
			Size result = this.#WFd(#jdd, #kdd);
			double num = 20.0;
			if (result.Width < num || result.Height < num)
			{
				throw new Exception(Localization.StringNotEnoughSpaceToPrepareTheDrawing.#z2d());
			}
			result.Height -= num;
			result.Width -= num;
			return result;
		}

		// Token: 0x06007D07 RID: 32007 RVA: 0x001B8A58 File Offset: 0x001B6C58
		public void #Ucd(#sTd #Vcd, bool #Wcd = true, double #Xcd = 0.87, string #Ycd = null, string #MQc = null, string #Tcd = null, string #Zcd = null, string #0cd = null, double? #1cd = null)
		{
			if (#Vcd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107282228));
			}
			if (!string.IsNullOrWhiteSpace(#0cd))
			{
				int num = this.#e.#F1d(#0cd, 0);
				if (num > 0 && num % this.NumberOfDrawingsPerPage == 0)
				{
					this.#d.#fdd();
				}
				this.#e[#0cd] = num + 1;
			}
			Size size = #Wcd ? this.#WFd(#Xcd, false) : #Vcd.ActualSize;
			this.Builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
			this.#Scd(#Tcd, #Phc.#3hc(107399922));
			if (!string.IsNullOrWhiteSpace(#Tcd))
			{
				this.#d.ContextCore.Map.#vzc(new #zSd(#Tcd, #MQc, null, StyleIdentifier.Heading2)
				{
					IsScreenshoot = true
				});
			}
			Table #Xpb = this.Builder.StartTable();
			Cell cell = this.Builder.InsertCell();
			cell.CellFormat.HorizontalMerge = CellMerge.First;
			double num2 = Math.Ceiling(Math.Min(size.Width, size.Height));
			double num3 = string.IsNullOrWhiteSpace(#0cd) ? size.Width : num2;
			double num4 = string.IsNullOrWhiteSpace(#0cd) ? size.Height : num2;
			Shape shape = this.Builder.InsertImage(#Vcd.SvgData, num3, num4);
			double num5 = num3;
			double? num6 = #1cd;
			if (num5 < num6.GetValueOrDefault() & num6 != null)
			{
				num3 = #1cd.Value;
			}
			shape.WrapType = WrapType.TopBottom;
			shape.AspectRatioLocked = true;
			shape.AllowOverlap = false;
			shape.HorizontalAlignment = HorizontalAlignment.Center;
			shape.VerticalAlignment = VerticalAlignment.Center;
			cell = this.Builder.InsertCell();
			cell.CellFormat.HorizontalMerge = CellMerge.Previous;
			this.Builder.EndRow();
			if (!string.IsNullOrWhiteSpace(#Ycd) || !string.IsNullOrWhiteSpace(#Zcd))
			{
				cell = this.Builder.InsertCell();
				cell.CellFormat.PreferredWidth = PreferredWidth.FromPoints(0.6 * (num3 + 20.0));
				if (!string.IsNullOrWhiteSpace(#Ycd))
				{
					this.#1Fd(ParagraphAlignment.Left, #Ycd);
					this.#UAb(cell, ParagraphAlignment.Left);
				}
				cell = this.Builder.InsertCell();
				cell.CellFormat.PreferredWidth = PreferredWidth.FromPoints(0.4 * (num3 + 20.0));
				if (!string.IsNullOrWhiteSpace(#Zcd))
				{
					this.#1Fd(ParagraphAlignment.Right, #Zcd);
					this.#UAb(cell, ParagraphAlignment.Right);
				}
				this.Builder.EndRow();
			}
			if (!string.IsNullOrWhiteSpace(#MQc))
			{
				this.#2Fd(#MQc);
			}
			this.#XFd(#Xpb, !string.IsNullOrEmpty(#MQc), num3, num4);
			this.Builder.EndTable();
			this.Builder.ParagraphFormat.ClearFormatting();
		}

		// Token: 0x06007D08 RID: 32008 RVA: 0x001B8D24 File Offset: 0x001B6F24
		private void #UAb(Cell #Vpb, ParagraphAlignment #rT)
		{
			IEnumerator<Paragraph> enumerator = \u0084\u0004.~\u0014\u000E(#Vpb, NodeType.Paragraph, true).OfType<Paragraph>().GetEnumerator();
			try
			{
				while (\u0010\u0002.~\u0019\u0004(enumerator))
				{
					\u007F\u0004.~\u000F\u000E(\u0007\u0004.~\u008A\u0008(enumerator.Current), #rT);
				}
			}
			finally
			{
				if (enumerator != null)
				{
					\u0007.~\u000E(enumerator);
				}
			}
		}

		// Token: 0x06007D09 RID: 32009 RVA: 0x001B8DA0 File Offset: 0x001B6FA0
		private void #XFd(Table #Xpb, bool #YFd, double #ZFd, double #0Fd)
		{
			\u0007.~\u001B(#Xpb);
			\u0084\u0004.~\u0014\u000E(#Xpb, NodeType.Cell, true).OfType<Cell>().#I1d(new Action<Cell>(SvgInsertHelper.<>c.<>9.#1Ud));
			int num = #YFd ? (\u008D\u0002.~\u0091\u0005(\u0015\u0004.~\u0098\u0008(#Xpb)) - 1) : \u008D\u0002.~\u0091\u0005(\u0015\u0004.~\u0098\u0008(#Xpb));
			for (int i = 0; i < num; i++)
			{
				Row row = \u0019\u0004.~\u009E\u0008(\u0015\u0004.~\u0098\u0008(#Xpb), i);
				if (i == 0)
				{
					\u001A\u0004.~\u009F\u0008(row).Height = #0Fd + ((\u008D\u0002.~\u0091\u0005(\u0015\u0004.~\u0098\u0008(#Xpb)) == 2) ? 10.0 : 10.0);
					\u009B\u0004.~\u008D\u000E(\u001A\u0004.~\u009F\u0008(row), HeightRule.Exactly);
				}
				Cell #Vpb = \u001B\u0004.~\u0001\u000E(row);
				if (i == 0)
				{
					#Vpb.#tFd(0.3, 0.3, 0.0, 0.0);
				}
				if (i > 0)
				{
					#Vpb.#tFd(0.3, 0.0, 0.0, 0.0);
				}
				if (i == num - 1)
				{
					#Vpb.#tFd(0.3, 0.0, 0.0, 0.3);
				}
				#Vpb = \u001B\u0004.~\u0003\u000E(row);
				if (i == 0)
				{
					#Vpb.#tFd(0.0, 0.3, 0.3, 0.0);
				}
				if (i > 0)
				{
					#Vpb.#tFd(0.0, 0.0, 0.3, 0.0);
				}
				if (i == num - 1)
				{
					#Vpb.#tFd(0.0, 0.0, 0.3, 0.3);
				}
			}
			if (\u008D\u0002.~\u0091\u0005(\u0015\u0004.~\u0098\u0008(#Xpb)) == 1)
			{
				\u001B\u0004 ~_u0003_u000E = \u001B\u0004.~\u0003\u000E;
				Row row2 = \u0019\u0004.~\u009E\u0008(\u0015\u0004.~\u0098\u0008(#Xpb), 0);
				row2.FirstCell.#rFd(10.0, 10.0, 10.0, 10.0);
				~_u0003_u000E(row2).#rFd(10.0, 10.0, 10.0, 10.0);
			}
			if (\u008D\u0002.~\u0091\u0005(\u0015\u0004.~\u0098\u0008(#Xpb)) >= 2)
			{
				Row row3 = \u0019\u0004.~\u009E\u0008(\u0015\u0004.~\u0098\u0008(#Xpb), 0);
				row3.FirstCell.#rFd(10.0, 10.0, 10.0, (\u008D\u0002.~\u0091\u0005(\u0015\u0004.~\u0098\u0008(#Xpb)) == 2) ? 10.0 : 0.0);
				row3.LastCell.#rFd(10.0, 10.0, 10.0, (\u008D\u0002.~\u0091\u0005(\u0015\u0004.~\u0098\u0008(#Xpb)) == 2) ? 10.0 : 0.0);
				\u001B\u0004 ~_u0003_u000E2 = \u001B\u0004.~\u0003\u000E;
				Row row4 = \u0019\u0004.~\u009E\u0008(\u0015\u0004.~\u0098\u0008(#Xpb), 1);
				row4.FirstCell.#rFd(10.0, 4.0, 10.0, 4.0);
				~_u0003_u000E2(row4).#rFd(10.0, 4.0, 10.0, 4.0);
			}
			if (\u008D\u0002.~\u0091\u0005(\u0015\u0004.~\u0098\u0008(#Xpb)) > 2)
			{
				\u001B\u0004 ~_u0003_u000E3 = \u001B\u0004.~\u0003\u000E;
				Row row5 = \u0019\u0004.~\u009E\u0008(\u0015\u0004.~\u0098\u0008(#Xpb), 2);
				row5.FirstCell.#rFd(10.0, 4.0, 10.0, 4.0);
				~_u0003_u000E3(row5).#rFd(10.0, 4.0, 10.0, 4.0);
			}
			for (int j = 0; j < \u008D\u0002.~\u0091\u0005(\u0015\u0004.~\u0098\u0008(#Xpb)); j++)
			{
				\u0095.~\u0083\u0003(\u001A\u0004.~\u009F\u0008(\u0019\u0004.~\u009E\u0008(\u0015\u0004.~\u0098\u0008(#Xpb), j)), false);
			}
			\u0095.~\u0080\u0003(#Xpb, true);
			\u001E\u0004.~\u0007\u000E(#Xpb, \u001D\u0004.\u0005\u000E(#ZFd + 20.0));
			\u001F\u0004.~\u000E\u000E(#Xpb, TableAlignment.Left);
			\u009F\u0002.~\u0080\u0006(#Xpb, 10.0);
		}

		// Token: 0x06007D0A RID: 32010 RVA: 0x001B9304 File Offset: 0x001B7504
		private void #1Fd(ParagraphAlignment #rT, string #Ukc)
		{
			string[] array = \u009C\u0004.~\u008E\u000E(#Ukc, new string[]
			{
				\u008E.\u0099\u0002()
			}, StringSplitOptions.RemoveEmptyEntries);
			\u009F\u0002.~\u001D\u0006(\u0005\u0004.~\u0083\u0008(this.Builder), this.#d.ContextCore.PrintOptions.FontInfo.ContentFontSize);
			\u007F\u0004.~\u000F\u000E(\u0007\u0004.~\u0089\u0008(this.Builder), #rT);
			for (int i = 0; i < array.Length; i++)
			{
				if (i < array.Length - 1)
				{
					this.#d.#3cd(array[i], StyleIdentifier.BodyText, new ParagraphAlignment?(#rT), null, null);
				}
				else
				{
					this.#d.#npb(array[i], StyleIdentifier.BodyText, new ParagraphAlignment?(#rT));
				}
			}
			\u0007.~\u001A(\u0007\u0004.~\u0089\u0008(this.Builder));
		}

		// Token: 0x06007D0B RID: 32011 RVA: 0x001B9400 File Offset: 0x001B7600
		private void #2Fd(string #MQc)
		{
			\u0018\u0004 ~_u009C_u = \u0018\u0004.~\u009C\u0008;
			\u0017\u0004 ~_u009A_u = \u0017\u0004.~\u009A\u0008;
			Cell cell = \u001B\u0004.~\u0002\u000E(this.Builder);
			cell.CellFormat.PreferredWidth = \u001D\u0004.\u0006\u000E(100.0);
			~_u009C_u(~_u009A_u(cell), CellMerge.First);
			\u007F\u0004.~\u000F\u000E(\u0007\u0004.~\u0089\u0008(this.Builder), ParagraphAlignment.Left);
			\u0007\u0003.~\u0010\u0007(\u0007\u0004.~\u0089\u0008(this.Builder), #Phc.#3hc(107282258));
			\u0007\u0003.~\u0007\u0007(this.Builder, #Phc.#3hc(107282183));
			this.#d.Fields.Add(\u0006\u0004.~\u0088\u0008(this.Builder, #Phc.#3hc(107282202)));
			\u0007\u0003.~\u0007\u0007(this.Builder, \u0019.\u0002\u0002(#Phc.#3hc(107383615), #MQc));
			\u0018\u0004.~\u009C\u0008(\u0017\u0004.~\u009A\u0008(\u001B\u0004.~\u0002\u000E(this.Builder)), CellMerge.Previous);
			\u0011\u0004.~\u0091\u0008(this.Builder);
		}

		// Token: 0x04003331 RID: 13105
		private const double #a = 0.3;

		// Token: 0x04003332 RID: 13106
		private const double #b = 10.0;

		// Token: 0x04003333 RID: 13107
		private const double #c = 4.0;

		// Token: 0x04003334 RID: 13108
		private readonly #UEd #d;

		// Token: 0x04003335 RID: 13109
		private readonly Dictionary<string, int> #e;

		// Token: 0x04003336 RID: 13110
		[CompilerGenerated]
		private DocumentBuilder #f;
	}
}
