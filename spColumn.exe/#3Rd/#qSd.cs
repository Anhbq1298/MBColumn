using System;
using System.Collections.Generic;
using #7hc;
using Aspose.Words;

namespace #3Rd
{
	// Token: 0x02000E1F RID: 3615
	internal sealed class #qSd
	{
		// Token: 0x170026CB RID: 9931
		// (get) Token: 0x060081F7 RID: 33271 RVA: 0x00069CE9 File Offset: 0x00067EE9
		public IReadOnlyList<#zSd> Map
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x060081F8 RID: 33272 RVA: 0x00069CF5 File Offset: 0x00067EF5
		public void #vzc(string #UGd, string #Ae, StyleIdentifier #4cd, string #pSd = null)
		{
			this.#a.Add(new #zSd(#UGd, #Ae, #pSd, #4cd));
		}

		// Token: 0x060081F9 RID: 33273 RVA: 0x00069D18 File Offset: 0x00067F18
		public void #vzc(#zSd #Rf)
		{
			if (#Rf == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107398878));
			}
			this.#a.Add(#Rf);
		}

		// Token: 0x0400354E RID: 13646
		private readonly List<#zSd> #a = new List<#zSd>();
	}
}
