using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #n6d
{
	// Token: 0x02000F38 RID: 3896
	[CLSCompliant(false)]
	internal sealed class #A6d<#Fu> : #t6d, IEnumerable, IEnumerable<!0>, ICollection<!0>, IList<!0> where #Fu : #E6d, new()
	{
		// Token: 0x17002898 RID: 10392
		// (get) Token: 0x060089FB RID: 35323 RVA: 0x000704C3 File Offset: 0x0006E6C3
		// (set) Token: 0x060089FC RID: 35324 RVA: 0x000704CF File Offset: 0x0006E6CF
		public int Count { get; private set; }

		// Token: 0x17002899 RID: 10393
		// (get) Token: 0x060089FD RID: 35325 RVA: 0x00003375 File Offset: 0x00001575
		public bool IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700289A RID: 10394
		public #Fu this[int #4jb]
		{
			get
			{
				return this.#a[#4jb];
			}
			set
			{
				this.#a[#4jb] = value;
			}
		}

		// Token: 0x06008A00 RID: 35328 RVA: 0x001D6ACC File Offset: 0x001D4CCC
		public override void #C0d(#m6d #s6d)
		{
			#X0d.#V0d(#s6d, #Phc.#3hc(107222840), Component.AppManager, #Phc.#3hc(107222795));
			base.#C0d(#s6d);
			uint num = #s6d.#b6d();
			this.#a = new !0[num];
			this.Count = this.#a.Length;
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				#Fu #Fu = Activator.CreateInstance<#Fu>();
				#s6d.#KAc(#Fu);
				this.#a[num2] = #Fu;
				num2++;
			}
		}

		// Token: 0x06008A01 RID: 35329 RVA: 0x00070511 File Offset: 0x0006E711
		public IEnumerator<#Fu> #67c()
		{
			return this.#a.GetEnumerator();
		}

		// Token: 0x06008A02 RID: 35330 RVA: 0x00070526 File Offset: 0x0006E726
		public bool #7tc(#Fu #Rf)
		{
			return this.#a.Contains(#Rf);
		}

		// Token: 0x06008A03 RID: 35331 RVA: 0x00070540 File Offset: 0x0006E740
		public void #77c(#Fu[] #87c, int #97c)
		{
			this.#a.CopyTo(#87c, #97c);
		}

		// Token: 0x06008A04 RID: 35332 RVA: 0x0007055B File Offset: 0x0006E75B
		public int #C7c(#Fu #Rf)
		{
			return Array.IndexOf<#Fu>(this.#a, #Rf);
		}

		// Token: 0x06008A05 RID: 35333 RVA: 0x00070575 File Offset: 0x0006E775
		IEnumerator IEnumerable.#NXb()
		{
			return this.#67c();
		}

		// Token: 0x06008A06 RID: 35334 RVA: 0x00008FC0 File Offset: 0x000071C0
		void ICollection<!0>.#e8c(#Fu #Rf)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06008A07 RID: 35335 RVA: 0x00008FC0 File Offset: 0x000071C0
		void ICollection<!0>.#w6d()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06008A08 RID: 35336 RVA: 0x00008FC0 File Offset: 0x000071C0
		bool ICollection<!0>.#x6d(#Fu #Rf)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06008A09 RID: 35337 RVA: 0x00008FC0 File Offset: 0x000071C0
		void IList<!0>.#y6d(int #4jb, #Fu #Rf)
		{
			throw new NotSupportedException();
		}

		// Token: 0x06008A0A RID: 35338 RVA: 0x00008FC0 File Offset: 0x000071C0
		void IList<!0>.#z6d(int #4jb)
		{
			throw new NotSupportedException();
		}

		// Token: 0x040038BF RID: 14527
		private #Fu[] #a;

		// Token: 0x040038C0 RID: 14528
		[CompilerGenerated]
		private int #b;
	}
}
