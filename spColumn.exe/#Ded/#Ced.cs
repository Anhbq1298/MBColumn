using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #3Rd;
using #5Fd;
using #7hc;
using #FCd;
using Aspose.Words;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Paged.Text;

namespace #Ded
{
	// Token: 0x0200045A RID: 1114
	internal abstract class #Ced
	{
		// Token: 0x060028E3 RID: 10467 RVA: 0x000258DD File Offset: 0x00023ADD
		protected #Ced()
		{
			this.DocumentMap = new #qSd();
		}

		// Token: 0x17000DB9 RID: 3513
		// (get) Token: 0x060028E4 RID: 10468 RVA: 0x00025911 File Offset: 0x00023B11
		// (set) Token: 0x060028E5 RID: 10469 RVA: 0x0002591D File Offset: 0x00023B1D
		public #qSd DocumentMap { get; private set; }

		// Token: 0x17000DBA RID: 3514
		// (get) Token: 0x060028E6 RID: 10470 RVA: 0x0002592E File Offset: 0x00023B2E
		public IReadOnlyList<#Red> Sections
		{
			get
			{
				return this.#c;
			}
		}

		// Token: 0x17000DBB RID: 3515
		// (get) Token: 0x060028E7 RID: 10471 RVA: 0x0002593A File Offset: 0x00023B3A
		public SectionHeaderHandler HeaderHandler
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x17000DBC RID: 3516
		// (get) Token: 0x060028E8 RID: 10472 RVA: 0x00025946 File Offset: 0x00023B46
		public IReadOnlyList<#JGd> CollectedHeaders
		{
			get
			{
				return this.#b;
			}
		}

		// Token: 0x060028E9 RID: 10473 RVA: 0x00025952 File Offset: 0x00023B52
		public void #ued()
		{
			if (!this.#d)
			{
				this.#yl();
				this.#gpb();
				this.#d = true;
			}
		}

		// Token: 0x060028EA RID: 10474
		protected abstract void #gpb();

		// Token: 0x060028EB RID: 10475 RVA: 0x0002597B File Offset: 0x00023B7B
		protected void #vzc(#Red #bLb)
		{
			if (#bLb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107352063));
			}
			this.#c.Add(#bLb);
		}

		// Token: 0x060028EC RID: 10476 RVA: 0x000DDBF8 File Offset: 0x000DBDF8
		protected #Red #ved(#JGd #Ae, #uDd #Xpb, IEnumerable<string> #wed = null)
		{
			#Red #Red = new #Red(#Ae, #Xpb, #wed);
			this.#c.Add(#Red);
			return #Red;
		}

		// Token: 0x060028ED RID: 10477 RVA: 0x000DDC28 File Offset: 0x000DBE28
		protected #Red #ved(#JGd #Ae, #uDd #Xpb, Func<IEnumerable<string>> #xed)
		{
			#Red #Red = new #Red(#Ae, #Xpb, #xed);
			this.#c.Add(#Red);
			return #Red;
		}

		// Token: 0x060028EE RID: 10478 RVA: 0x000259A8 File Offset: 0x00023BA8
		protected void #yed(#JGd #Ae, IEnumerable<string> #wed)
		{
			this.#c.Add(new #Red(#Ae, #wed));
		}

		// Token: 0x060028EF RID: 10479 RVA: 0x000DDC58 File Offset: 0x000DBE58
		protected #JGd #zed(StyleIdentifier #t6c, string #Ukc, Option #bA)
		{
			#JGd #JGd = this.HeaderHandler.#KGd(#t6c, #Ukc);
			#JGd.Option = #bA;
			this.#b.Add(#JGd);
			this.DocumentMap.#vzc(#bA.BookmarkName, #JGd.Number, #t6c, #Ukc);
			return #JGd;
		}

		// Token: 0x060028F0 RID: 10480 RVA: 0x000259C8 File Offset: 0x00023BC8
		protected #JGd #Aed(Option #bA, StyleIdentifier #t6c, string #Ukc)
		{
			if (#bA.#JSd())
			{
				return this.#zed(#t6c, #Ukc, #bA);
			}
			return null;
		}

		// Token: 0x060028F1 RID: 10481 RVA: 0x000259E9 File Offset: 0x00023BE9
		protected virtual #JGd #Bed(Option #bA, StyleIdentifier #t6c, string #Ukc)
		{
			if (#bA.#ISd())
			{
				return this.#zed(#t6c, #Ukc, #bA);
			}
			return null;
		}

		// Token: 0x060028F2 RID: 10482 RVA: 0x00025A0A File Offset: 0x00023C0A
		private void #yl()
		{
			this.#c.Clear();
			this.#a.#yJ();
			this.#b.Clear();
		}

		// Token: 0x04001045 RID: 4165
		private readonly SectionHeaderHandler #a = new SectionHeaderHandler();

		// Token: 0x04001046 RID: 4166
		private readonly List<#JGd> #b = new List<#JGd>();

		// Token: 0x04001047 RID: 4167
		private readonly List<#Red> #c = new List<#Red>();

		// Token: 0x04001048 RID: 4168
		private bool #d;

		// Token: 0x04001049 RID: 4169
		[CompilerGenerated]
		private #qSd #e;
	}
}
