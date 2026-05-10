using System;
using System.Runtime.CompilerServices;
using #7hc;
using Aspose.Words;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Paged.Text;

namespace #yze
{
	// Token: 0x020011F4 RID: 4596
	internal sealed class #Aze : TextContentRenderer
	{
		// Token: 0x06009A38 RID: 39480 RVA: 0x0007A278 File Offset: 0x00078478
		public #Aze(#Bze #ib) : base(#ib)
		{
			this.Context = #ib;
		}

		// Token: 0x17002CBA RID: 11450
		// (get) Token: 0x06009A39 RID: 39481 RVA: 0x0007A288 File Offset: 0x00078488
		public #Bze Context { get; }

		// Token: 0x06009A3A RID: 39482 RVA: 0x0020CC28 File Offset: 0x0020AE28
		public override void #bdd()
		{
			this.Context.Paginator.AddHeaderToFirstPage = false;
			string text = this.Context.ProgramNameAndVersion;
			if (!string.IsNullOrWhiteSpace(text))
			{
				int totalWidth = 47 + text.Length / 2 + 1;
				text = text.PadLeft(totalWidth);
			}
			base.#Scd(this.Context.Options.CoverAndContents.BookmarkName, #Phc.#3hc(107399922));
			base.#Scd(this.Context.Options.Cover.BookmarkName, #Phc.#3hc(107399922));
			this.Context.DocumentMap.#vzc(this.Context.Options.CoverAndContents.BookmarkName, #Phc.#3hc(107286036), StyleIdentifier.Heading1, #Phc.#3hc(107409021));
			this.Context.DocumentMap.#vzc(this.Context.Options.Cover.BookmarkName, #Phc.#3hc(107286515), StyleIdentifier.Heading2, #Phc.#3hc(107354216));
			string text2 = string.Format(#Phc.#3hc(107286482), text, ColumnGlobalInfo.CopyrightYear);
			bool #f = this.Context.Paginator.AutoSplitLongLines;
			try
			{
				this.Context.Paginator.AutoSplitLongLines = false;
				text2 = base.#RGd(text2);
				this.Context.Paginator.#cGd(text2, false);
				this.Context.Paginator.#fdd();
			}
			finally
			{
				this.Context.Paginator.AutoSplitLongLines = #f;
			}
		}

		// Token: 0x04004238 RID: 16952
		[CompilerGenerated]
		private readonly #Bze #a;
	}
}
