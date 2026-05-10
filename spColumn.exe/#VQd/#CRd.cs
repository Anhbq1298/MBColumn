using System;
using System.Collections.Generic;
using #6Pd;
using #ERd;
using #VEd;
using Aspose.Words;
using Aspose.Words.Layout;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Generation.API;

namespace #VQd
{
	// Token: 0x02000E18 RID: 3608
	internal sealed class #CRd : #zRd, #CFd, IReportData, #0Qd, #IRd
	{
		// Token: 0x170026BD RID: 9917
		// (get) Token: 0x060081D9 RID: 33241 RVA: 0x00069A87 File Offset: 0x00067C87
		public Document Document
		{
			get
			{
				return \u0001\u0004.~\u001C\u0008(this.Builder);
			}
		}

		// Token: 0x170026BE RID: 9918
		// (get) Token: 0x060081DA RID: 33242 RVA: 0x001C33E8 File Offset: 0x001C15E8
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

		// Token: 0x170026BF RID: 9919
		// (get) Token: 0x060081DB RID: 33243 RVA: 0x001C3420 File Offset: 0x001C1620
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

		// Token: 0x170026C0 RID: 9920
		// (get) Token: 0x060081DC RID: 33244 RVA: 0x00069AA5 File Offset: 0x00067CA5
		// (set) Token: 0x060081DD RID: 33245 RVA: 0x00069AB1 File Offset: 0x00067CB1
		public DocumentBuilder Builder
		{
			get
			{
				return this.#d;
			}
			set
			{
				this.#c = null;
				this.#b = null;
				this.#d = value;
			}
		}

		// Token: 0x170026C1 RID: 9921
		// (get) Token: 0x060081DE RID: 33246 RVA: 0x00069AD4 File Offset: 0x00067CD4
		public IList<#dQd> Outlines
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x060081DF RID: 33247 RVA: 0x00069AE0 File Offset: 0x00067CE0
		public override void #yJ()
		{
			base.#yJ();
			this.Builder = null;
			this.#a.Clear();
		}

		// Token: 0x0400353B RID: 13627
		private readonly IList<#dQd> #a = new List<#dQd>();

		// Token: 0x0400353C RID: 13628
		private LayoutCollector #b;

		// Token: 0x0400353D RID: 13629
		private LayoutEnumerator #c;

		// Token: 0x0400353E RID: 13630
		private DocumentBuilder #d;
	}
}
