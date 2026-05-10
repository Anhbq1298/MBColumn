using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using #7hc;
using #FCd;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #jCd
{
	// Token: 0x02000D57 RID: 3415
	internal sealed class #wCd : #lEd
	{
		// Token: 0x06007C31 RID: 31793 RVA: 0x00064D1A File Offset: 0x00062F1A
		public #wCd(#uCd #ib, int #Jhd, params double[] #Zpb) : base(#Jhd, #Zpb)
		{
			this.Context = #ib;
		}

		// Token: 0x17002559 RID: 9561
		// (get) Token: 0x06007C32 RID: 31794 RVA: 0x00064D2B File Offset: 0x00062F2B
		// (set) Token: 0x06007C33 RID: 31795 RVA: 0x00064D37 File Offset: 0x00062F37
		public #uCd Context { get; private set; }

		// Token: 0x1700255A RID: 9562
		// (get) Token: 0x06007C34 RID: 31796 RVA: 0x00064D48 File Offset: 0x00062F48
		private bool RequiresDeformat
		{
			get
			{
				return base.CurrentRowIndex < this.#b || (this.#b == 0 && base.CurrentCellIndex == 0) || this.IsHtmlColumn;
			}
		}

		// Token: 0x1700255B RID: 9563
		// (get) Token: 0x06007C35 RID: 31797 RVA: 0x00059A33 File Offset: 0x00057C33
		private bool IsHtmlColumn
		{
			get
			{
				return base.HtmlColumns[base.CurrentCellIndex];
			}
		}

		// Token: 0x06007C36 RID: 31798 RVA: 0x001B58A8 File Offset: 0x001B3AA8
		public override void #Fhd(int #1f, params string[] #Qb)
		{
			string #f = this.#vCd(#Qb);
			this.Context.Sink.#dGd(#f);
			if (this.Context.PadMergedColumns)
			{
				this.#iEd(1);
				for (int i = 1; i < #1f; i++)
				{
					this.#Ghd(#lEd.#YUd.#b, new string[]
					{
						string.Empty
					});
				}
				return;
			}
			this.#iEd(#1f);
		}

		// Token: 0x06007C37 RID: 31799 RVA: 0x00064D7C File Offset: 0x00062F7C
		protected override void #Ghd(#lEd.#YUd #ri, params string[] #Qb)
		{
			this.#Fhd(1, #Qb);
		}

		// Token: 0x06007C38 RID: 31800 RVA: 0x00064D92 File Offset: 0x00062F92
		protected override void #Hhd()
		{
			if (this.#c > 0 && base.CurrentCellIndex == 0)
			{
				this.Context.Sink.#cGd();
			}
		}

		// Token: 0x06007C39 RID: 31801 RVA: 0x001B5918 File Offset: 0x001B3B18
		private string #vCd(params string[] #Qb)
		{
			bool flag = base.CurrentCellIndex == base.ColumnWidths.Length - 1;
			StringBuilder stringBuilder = new StringBuilder();
			string text = \u0011\u0003.\u0018\u0007(string.Empty, #Qb);
			if (\u0080.~\u001F\u0002(text, #Phc.#3hc(107408434)))
			{
				IEnumerable<char> source = text;
				Func<char, bool> predicate;
				if ((predicate = #wCd.#2Ui.#a) == null)
				{
					predicate = (#wCd.#2Ui.#a = new Func<char, bool>(char.IsLetter));
				}
				if (source.Any(predicate))
				{
					text = \u0019.\u0002\u0002(string.Empty.#O2d(), text);
				}
			}
			if (this.RequiresDeformat)
			{
				text = this.Context.Deformatter.#NBd(text);
			}
			\u0097\u0003.~\u0011\u0008(stringBuilder, text);
			this.Context.#sCd(stringBuilder);
			if (!flag)
			{
				\u0097\u0003.~\u0011\u0008(stringBuilder, this.Context.ValueSeparator);
			}
			return \u007F.~\u0011\u0002(stringBuilder);
		}

		// Token: 0x040032E9 RID: 13033
		[CompilerGenerated]
		private #uCd #a;

		// Token: 0x02000D58 RID: 3416
		[CompilerGenerated]
		private static class #2Ui
		{
			// Token: 0x040032EA RID: 13034
			public static Func<char, bool> #a;
		}
	}
}
