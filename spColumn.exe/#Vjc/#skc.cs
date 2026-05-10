using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #2ic;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.DataExchange.ExternFormat;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #Vjc
{
	// Token: 0x0200077E RID: 1918
	internal sealed class #skc : #ijc, #pjc
	{
		// Token: 0x170012C9 RID: 4809
		// (get) Token: 0x06003DBA RID: 15802 RVA: 0x00034CCE File Offset: 0x00032ECE
		// (set) Token: 0x06003DBB RID: 15803 RVA: 0x00034CD6 File Offset: 0x00032ED6
		public bool IsClosed { get; set; }

		// Token: 0x170012CA RID: 4810
		// (get) Token: 0x06003DBC RID: 15804 RVA: 0x00034CDF File Offset: 0x00032EDF
		public List<IVertex> Vertexes
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x170012CB RID: 4811
		// (get) Token: 0x06003DBD RID: 15805 RVA: 0x00034CE7 File Offset: 0x00032EE7
		// (set) Token: 0x06003DBE RID: 15806 RVA: 0x00034CEF File Offset: 0x00032EEF
		public #jjc Layer { get; set; }

		// Token: 0x06003DBF RID: 15807 RVA: 0x0011C77C File Offset: 0x0011A97C
		public #skc(List<#Jkc> #pkc, bool #qkc, #jjc #rR)
		{
			#X0d.#V0d(#pkc, #Phc.#3hc(107377252), Component.DataExchange, #Phc.#3hc(107377271));
			this.#a = new List<IVertex>();
			foreach (#Jkc item in #pkc)
			{
				this.Vertexes.Add(item);
			}
			this.IsClosed = #qkc;
			this.Layer = #rR;
		}

		// Token: 0x04001C0E RID: 7182
		private readonly List<IVertex> #a;

		// Token: 0x04001C0F RID: 7183
		[CompilerGenerated]
		private bool #b;

		// Token: 0x04001C10 RID: 7184
		[CompilerGenerated]
		private #jjc #c;
	}
}
