using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using #3Rd;
using #6Pd;
using #ERd;
using #o1d;
using #VEd;
using Aspose.Words;
using Aspose.Words.Layout;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Generation.API;

namespace #VQd
{
	// Token: 0x02000E16 RID: 3606
	internal sealed class #BRd : #zRd, #CFd, IReportData, #0Qd, #HRd
	{
		// Token: 0x170026B5 RID: 9909
		// (get) Token: 0x060081CC RID: 33228 RVA: 0x000699A2 File Offset: 0x00067BA2
		// (set) Token: 0x060081CD RID: 33229 RVA: 0x000699AE File Offset: 0x00067BAE
		public #qSd DocumentMap { get; set; }

		// Token: 0x170026B6 RID: 9910
		// (get) Token: 0x060081CE RID: 33230 RVA: 0x000699BF File Offset: 0x00067BBF
		public Document Document
		{
			get
			{
				return \u0001\u0004.~\u001C\u0008(this.Builder);
			}
		}

		// Token: 0x170026B7 RID: 9911
		// (get) Token: 0x060081CF RID: 33231 RVA: 0x001C3378 File Offset: 0x001C1578
		public LayoutCollector LayoutCollector
		{
			get
			{
				LayoutCollector result;
				if ((result = this.#b) == null)
				{
					result = (this.#b = new LayoutCollector(this.Document));
				}
				return result;
			}
		}

		// Token: 0x170026B8 RID: 9912
		// (get) Token: 0x060081D0 RID: 33232 RVA: 0x001C33B0 File Offset: 0x001C15B0
		public LayoutEnumerator LayoutEnumerator
		{
			get
			{
				LayoutEnumerator result;
				if ((result = this.#c) == null)
				{
					result = (this.#c = new LayoutEnumerator(this.Document));
				}
				return result;
			}
		}

		// Token: 0x170026B9 RID: 9913
		// (get) Token: 0x060081D1 RID: 33233 RVA: 0x000699DD File Offset: 0x00067BDD
		// (set) Token: 0x060081D2 RID: 33234 RVA: 0x000699E9 File Offset: 0x00067BE9
		public DocumentBuilder Builder
		{
			get
			{
				return this.#d;
			}
			set
			{
				this.#b = null;
				this.#c = null;
				this.#d = value;
			}
		}

		// Token: 0x170026BA RID: 9914
		// (get) Token: 0x060081D3 RID: 33235 RVA: 0x00069A0C File Offset: 0x00067C0C
		public override Stream DisplayContent
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x170026BB RID: 9915
		// (get) Token: 0x060081D4 RID: 33236 RVA: 0x00069A18 File Offset: 0x00067C18
		public IList<#dQd> Outlines { get; }

		// Token: 0x060081D5 RID: 33237 RVA: 0x00069A24 File Offset: 0x00067C24
		public void #ARd(Stream #gp)
		{
			this.#a = #gp;
			#gp.#i2d();
		}

		// Token: 0x060081D6 RID: 33238 RVA: 0x00069A40 File Offset: 0x00067C40
		public override void #yJ()
		{
			base.#yJ();
			this.Outlines.Clear();
			this.#a = null;
			this.DocumentMap = null;
			this.Builder = null;
		}

		// Token: 0x04003535 RID: 13621
		private Stream #a;

		// Token: 0x04003536 RID: 13622
		private LayoutCollector #b;

		// Token: 0x04003537 RID: 13623
		private LayoutEnumerator #c;

		// Token: 0x04003538 RID: 13624
		private DocumentBuilder #d;

		// Token: 0x04003539 RID: 13625
		[CompilerGenerated]
		private #qSd #e;

		// Token: 0x0400353A RID: 13626
		[CompilerGenerated]
		private readonly IList<#dQd> #f = new List<#dQd>();
	}
}
