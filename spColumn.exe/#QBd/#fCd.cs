using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using #5Fd;
using #7hc;
using #Ded;
using #FCd;
using Aspose.Words;
using ClosedXML.Excel;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Resources;

namespace #QBd
{
	// Token: 0x02000D52 RID: 3410
	internal abstract class #fCd : #Led
	{
		// Token: 0x06007C16 RID: 31766 RVA: 0x001B4EC8 File Offset: 0x001B30C8
		protected #fCd(#VBd #ib, bool #gCd)
		{
			if (#ib == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107400797));
			}
			this.#a = #ib;
			this.#b = #gCd;
			this.#c = new #6Bd(#ib);
			this.#d = #ib.Workbook;
			this.UseHyperlinks = true;
		}

		// Token: 0x17002557 RID: 9559
		// (get) Token: 0x06007C17 RID: 31767 RVA: 0x00064BA6 File Offset: 0x00062DA6
		// (set) Token: 0x06007C18 RID: 31768 RVA: 0x00064BB2 File Offset: 0x00062DB2
		protected string TableOfContentsBookmarkName { get; set; }

		// Token: 0x17002558 RID: 9560
		// (get) Token: 0x06007C19 RID: 31769 RVA: 0x00064BC3 File Offset: 0x00062DC3
		// (set) Token: 0x06007C1A RID: 31770 RVA: 0x00064BCF File Offset: 0x00062DCF
		protected bool UseHyperlinks { get; set; }

		// Token: 0x06007C1B RID: 31771 RVA: 0x00064BE0 File Offset: 0x00062DE0
		public void #bCd(Stream #En)
		{
			if (#En == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107367090));
			}
			this.#bCd();
			this.#zl(#En);
		}

		// Token: 0x06007C1C RID: 31772 RVA: 0x00064C0E File Offset: 0x00062E0E
		public void #bCd(Func<Stream> #En)
		{
			if (#En == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107367090));
			}
			this.#bCd();
			this.#zl(#En);
		}

		// Token: 0x06007C1D RID: 31773 RVA: 0x00064C3C File Offset: 0x00062E3C
		public void #bCd()
		{
			if (!this.#f)
			{
				this.#Jed();
				this.#Ged();
				this.#f = true;
			}
		}

		// Token: 0x06007C1E RID: 31774 RVA: 0x001B4F24 File Offset: 0x001B3124
		public void #zl(Func<Stream> #En)
		{
			if (#En == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107367090));
			}
			using (Stream stream = #En())
			{
				this.#zl(stream);
			}
		}

		// Token: 0x06007C1F RID: 31775 RVA: 0x00064C65 File Offset: 0x00062E65
		public void #zl(Stream #En)
		{
			if (#En == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107367090));
			}
			\u0089\u0003.~\u0099\u0007(this.#d, #En);
		}

		// Token: 0x06007C20 RID: 31776 RVA: 0x001B4F7C File Offset: 0x001B317C
		protected override void #ved(#Red #bLb)
		{
			if (#bLb.IsNoteOnly)
			{
				return;
			}
			this.#Rcd(#bLb.Header.Number, #bLb.Table);
			\u008C\u0003 ~_u009F_u = \u008C\u0003.~\u009F\u0007;
			IXLWorksheet ixlworksheet = \u0015\u0003.~\u001C\u0007(this.#d).Last<IXLWorksheet>();
			ixlworksheet.Cell(1, 1).WorksheetRow().InsertRowsAbove(1);
			ixlworksheet.Cell(1, 1).RichText.AddText(#bLb.Header.HeaderPath).Bold = true;
			~_u009F_u(ixlworksheet, null);
			this.#eCd(#bLb.Notes);
		}

		// Token: 0x06007C21 RID: 31777 RVA: 0x001B502C File Offset: 0x001B322C
		protected override void #Rcd(string #wy, #uDd #Xpb)
		{
			if (this.#b)
			{
				\u008D\u0003 ~_u0001_u = \u008D\u0003.~\u0001\u0008;
				object obj = this.#d;
				\u0015 u009A = \u0015.\u009A;
				string text = #Phc.#3hc(107252139);
				int num = this.#e;
				this.#e = num + 1;
				~_u0001_u(obj, u009A(text, num));
			}
			else
			{
				\u008D\u0003.~\u0001\u0008(this.#d, \u008E\u0003.~\u0002\u0008(#wy, new char[]
				{
					'.',
					' '
				}));
			}
			this.#c.PixelWidths = this.#Hed(#Xpb);
			#Xpb.#npb(this.#c);
		}

		// Token: 0x06007C22 RID: 31778 RVA: 0x001B50E4 File Offset: 0x001B32E4
		protected override void #Ged()
		{
			IXLWorksheet ixlworksheet = \u008F\u0003.~\u0003\u0008(\u0015\u0003.~\u001C\u0007(this.#d), Localization.StringContents, 1);
			\u0090\u0003.~\u0004\u0008(ixlworksheet, true);
			base.Definition.DocumentMap.#vzc(this.TableOfContentsBookmarkName, Localization.StringContents, StyleIdentifier.Heading1, null);
			IXLCell ixlcell = \u0016\u0003.~\u001D\u0007(ixlworksheet, 1, 1);
			\u0092\u0003.~\u0006\u0008(\u0091\u0003.~\u0005\u0008(\u0013\u0003.~\u001A\u0007(\u001D\u0003.~\u0084\u0007(ixlcell), Localization.StringContents), true), 16.0);
			int num = 2;
			IEnumerator<#JGd> enumerator = base.Definition.CollectedHeaders.GetEnumerator();
			try
			{
				while (\u0010\u0002.~\u0019\u0004(enumerator))
				{
					#JGd #JGd = enumerator.Current;
					ixlcell = \u0016\u0003.~\u001D\u0007(ixlworksheet, num, #JGd.Level);
					string text = \u008E\u0003.~\u0002\u0008(#JGd.Number, new char[]
					{
						'.',
						' '
					});
					ixlcell.SetValue<string>(text);
					IXLWorksheet ixlworksheet2;
					if (this.UseHyperlinks && \u0093\u0003.~\u0007\u0008(this.#d, text, ref ixlworksheet2))
					{
						\u0094\u0003.~\u0008\u0008(ixlcell, new XLHyperlink(\u0015.\u009A(#Phc.#3hc(107252158), text)));
					}
					\u0095\u0003.~\u000E\u0008(ixlcell).SetValue<string>(#JGd.Header);
					num = this.#cCd(#JGd, \u0095\u0003.~\u000E\u0008(ixlcell), num);
					num++;
				}
			}
			finally
			{
				if (enumerator != null)
				{
					\u0007.~\u000E(enumerator);
				}
			}
			\u009F\u0002.~\u0019\u0006(\u0096\u0003.~\u0010\u0008(ixlworksheet, #Phc.#3hc(107408119)), 7.0);
			\u009F\u0002.~\u0019\u0006(\u0096\u0003.~\u0010\u0008(ixlworksheet, #Phc.#3hc(107408114)), 7.0);
			\u009F\u0002.~\u0019\u0006(\u0096\u0003.~\u0010\u0008(ixlworksheet, #Phc.#3hc(107408077)), 7.0);
		}

		// Token: 0x06007C23 RID: 31779 RVA: 0x001B5320 File Offset: 0x001B3520
		private int #cCd(#JGd #Ae, IXLCell #Vpb, int #dCd)
		{
			#fCd.#CTb #CTb = new #fCd.#CTb();
			#CTb.#a = #Ae;
			#Red #Red = base.Definition.Sections.FirstOrDefault(new Func<#Red, bool>(#CTb.#XUd));
			if (#Red != null)
			{
				List<string> list = #Red.Notes.ToList<string>();
				if (list.Any<string>())
				{
					for (int i = list.Count - 1; i >= 0; i--)
					{
						if (\u0003.\u0004(list[i]))
						{
							list.RemoveAt(i);
						}
					}
					foreach (string value in list)
					{
						#Vpb = \u0095\u0003.~\u000F\u0008(#Vpb);
						#Vpb.SetValue<string>(value);
						#dCd++;
					}
				}
			}
			return #dCd;
		}

		// Token: 0x06007C24 RID: 31780 RVA: 0x001B5414 File Offset: 0x001B3614
		private void #eCd(IEnumerable<string> #wed)
		{
			List<string> list = (#wed != null) ? #wed.ToList<string>() : new List<string>();
			if (!list.Any<string>())
			{
				return;
			}
			IXLWorksheet ixlworksheet = this.#d.Worksheets.Last<IXLWorksheet>();
			for (int i = 0; i < list.Count; i++)
			{
				IXLCell ixlcell = ixlworksheet.Cell(i + 1, 1);
				ixlcell.WorksheetRow().InsertRowsBelow(1);
				ixlcell = ixlworksheet.Cell(i + 2, 1);
				string value = list[i];
				if (!string.IsNullOrWhiteSpace(value))
				{
					this.#a.Deformatter.#NBd(ixlcell.RichText, value);
				}
			}
		}

		// Token: 0x040032DD RID: 13021
		private readonly #VBd #a;

		// Token: 0x040032DE RID: 13022
		private readonly bool #b;

		// Token: 0x040032DF RID: 13023
		private readonly #6Bd #c;

		// Token: 0x040032E0 RID: 13024
		private readonly XLWorkbook #d;

		// Token: 0x040032E1 RID: 13025
		private int #e = 1;

		// Token: 0x040032E2 RID: 13026
		private bool #f;

		// Token: 0x040032E3 RID: 13027
		[CompilerGenerated]
		private string #g;

		// Token: 0x040032E4 RID: 13028
		[CompilerGenerated]
		private bool #h;

		// Token: 0x02000D53 RID: 3411
		[CompilerGenerated]
		private sealed class #CTb
		{
			// Token: 0x06007C26 RID: 31782 RVA: 0x00064C97 File Offset: 0x00062E97
			internal bool #XUd(#Red #Rf)
			{
				return #Rf.Header == this.#a && #Rf.IsNoteOnly && #Rf.Notes != null;
			}

			// Token: 0x040032E5 RID: 13029
			public #JGd #a;
		}
	}
}
