using System;
using Aspose.Words;
using Aspose.Words.Tables;

namespace #VEd
{
	// Token: 0x02000D70 RID: 3440
	internal static class #zFd
	{
		// Token: 0x06007CD9 RID: 31961 RVA: 0x001B7BE8 File Offset: 0x001B5DE8
		public static Cell #rFd(this Cell #Vpb, double #sFd)
		{
			\u009F\u0002.~\u0084\u0006(\u0017\u0004.~\u009A\u0008(#Vpb), #sFd);
			\u009F\u0002.~\u0082\u0006(\u0017\u0004.~\u009A\u0008(#Vpb), #sFd);
			\u009F\u0002.~\u0083\u0006(\u0017\u0004.~\u009A\u0008(#Vpb), #sFd);
			\u009F\u0002.~\u0081\u0006(\u0017\u0004.~\u009A\u0008(#Vpb), #sFd);
			return #Vpb;
		}

		// Token: 0x06007CDA RID: 31962 RVA: 0x001B7C5C File Offset: 0x001B5E5C
		public static Cell #rFd(this Cell #Vpb, double #Sc, double #ZW, double #Tc, double #0W)
		{
			\u009F\u0002.~\u0084\u0006(\u0017\u0004.~\u009A\u0008(#Vpb), #0W);
			\u009F\u0002.~\u0082\u0006(\u0017\u0004.~\u009A\u0008(#Vpb), #Sc);
			\u009F\u0002.~\u0083\u0006(\u0017\u0004.~\u009A\u0008(#Vpb), #ZW);
			\u009F\u0002.~\u0081\u0006(\u0017\u0004.~\u009A\u0008(#Vpb), #Tc);
			return #Vpb;
		}

		// Token: 0x06007CDB RID: 31963 RVA: 0x001B7CD0 File Offset: 0x001B5ED0
		public static Cell #tFd(this Cell #Vpb, double #Sc, double #ZW, double #Tc, double #0W)
		{
			\u009F\u0002 ~_u001A_u = \u009F\u0002.~\u001A\u0006;
			\u0087\u0004 ~_u0018_u000E = \u0087\u0004.~\u0018\u000E;
			BorderCollection borderCollection = \u0086\u0004.~\u0015\u000E(\u0017\u0004.~\u009A\u0008(#Vpb));
			borderCollection.Left.LineWidth = #Sc;
			borderCollection.Right.LineWidth = #Tc;
			borderCollection.Top.LineWidth = #ZW;
			~_u001A_u(~_u0018_u000E(borderCollection), #0W);
			return #Vpb;
		}

		// Token: 0x06007CDC RID: 31964 RVA: 0x001B7D3C File Offset: 0x001B5F3C
		public static Cell #uFd(this DocumentBuilder #tCd, double? #vFd)
		{
			Cell cell = #tCd.InsertCell();
			#tCd.CellFormat.PreferredWidth = ((#vFd != null) ? PreferredWidth.FromPercent(#vFd.Value) : PreferredWidth.Auto);
			cell.CellFormat.HorizontalMerge = CellMerge.Previous;
			return cell;
		}

		// Token: 0x06007CDD RID: 31965 RVA: 0x001B7D90 File Offset: 0x001B5F90
		public static Cell #wFd(this DocumentBuilder #tCd, string #Ukc, double? #vFd = null, bool #xFd = false, bool #yFd = true, ParagraphAlignment #rT = ParagraphAlignment.Left)
		{
			Cell cell = #tCd.InsertCell();
			#tCd.ParagraphFormat.Alignment = #rT;
			cell.CellFormat.WrapText = #yFd;
			#tCd.CellFormat.WrapText = #yFd;
			#tCd.CellFormat.PreferredWidth = ((#vFd != null) ? PreferredWidth.FromPercent(#vFd.Value) : PreferredWidth.Auto);
			if (#xFd)
			{
				cell.CellFormat.HorizontalMerge = CellMerge.First;
			}
			if (!string.IsNullOrEmpty(#Ukc))
			{
				#tCd.Write(#Ukc);
			}
			return cell;
		}
	}
}
