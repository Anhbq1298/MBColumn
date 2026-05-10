using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #01h;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.DataExchange.DXF.Legacy;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #t2h
{
	// Token: 0x0200079E RID: 1950
	internal sealed class #8mg
	{
		// Token: 0x06003E97 RID: 16023 RVA: 0x001218D4 File Offset: 0x0011FAD4
		public #8mg(List<List<#Z1h>> #6h)
		{
			#X0d.#V0d(#6h, #Phc.#3hc(107372654), Component.DataExchange, #Phc.#3hc(107372624));
			this.Variables = new List<#k3h>(#6h.Count);
			foreach (List<#Z1h> #6h2 in #6h)
			{
				this.Variables.Add(new #k3h(#6h2));
			}
		}

		// Token: 0x06003E98 RID: 16024 RVA: 0x00121960 File Offset: 0x0011FB60
		public #k3h #z2h(string #wy)
		{
			#8mg.#v0b #v0b = new #8mg.#v0b();
			#8mg.#v0b #v0b2;
			if (!false)
			{
				#v0b2 = #v0b;
			}
			#v0b2.#a = #wy;
			return this.Variables.FirstOrDefault(new Func<#k3h, bool>(#v0b2.#s3h));
		}

		// Token: 0x170012FA RID: 4858
		// (get) Token: 0x06003E99 RID: 16025 RVA: 0x00035557 File Offset: 0x00033757
		// (set) Token: 0x06003E9A RID: 16026 RVA: 0x0003555F File Offset: 0x0003375F
		public List<#k3h> Variables { get; private set; }

		// Token: 0x04001C86 RID: 7302
		[CompilerGenerated]
		private List<#k3h> #a;

		// Token: 0x0200079F RID: 1951
		[CompilerGenerated]
		private sealed class #v0b
		{
			// Token: 0x06003E9C RID: 16028 RVA: 0x00035568 File Offset: 0x00033768
			internal bool #s3h(#k3h #Rf)
			{
				return DxfHelper.#ntb(#Rf.VariableName, this.#a) == 0;
			}

			// Token: 0x04001C87 RID: 7303
			public string #a;
		}
	}
}
