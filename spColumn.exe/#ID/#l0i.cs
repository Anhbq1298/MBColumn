using System;
using System.Runtime.CompilerServices;
using #H1i;
using StructurePoint.CoreAssets.Column.Core.Core.Diagnostics;

namespace #ID
{
	// Token: 0x02000224 RID: 548
	internal sealed class #l0i : #L1i
	{
		// Token: 0x060012B6 RID: 4790 RVA: 0x00014680 File Offset: 0x00012880
		public void #nb(Exception #ob)
		{
			Logger.Error(#ob);
		}

		// Token: 0x060012B7 RID: 4791 RVA: 0x000ACA6C File Offset: 0x000AAC6C
		public void #nb(#K1i #5)
		{
			#l0i.#v0b #v0b = new #l0i.#v0b();
			#l0i.#v0b #v0b2;
			if (!false)
			{
				#v0b2 = #v0b;
			}
			#v0b2.#a = #5;
			if (#v0b2.#a == null)
			{
				return;
			}
			Logger.Error(new Func<string>(#v0b2.#h1i));
		}

		// Token: 0x060012B8 RID: 4792 RVA: 0x00003446 File Offset: 0x00001646
		public void #nb(string #5, Exception #ob)
		{
			Logger.Error(#5, #ob);
		}

		// Token: 0x060012B9 RID: 4793 RVA: 0x000ACAB0 File Offset: 0x000AACB0
		public void #Rjc(string #5)
		{
			#l0i.#dZb #dZb = new #l0i.#dZb();
			#dZb.#a = #5;
			Logger.Warning(new Func<string>(#dZb.#i1i));
		}

		// Token: 0x060012BA RID: 4794 RVA: 0x000ACAE8 File Offset: 0x000AACE8
		public void #Rjc(#K1i #5)
		{
			#l0i.#xTb #xTb = new #l0i.#xTb();
			#l0i.#xTb #xTb2;
			if (!false)
			{
				#xTb2 = #xTb;
			}
			#xTb2.#a = #5;
			if (#xTb2.#a == null)
			{
				return;
			}
			Logger.Warning(new Func<string>(#xTb2.#i1i));
		}

		// Token: 0x060012BB RID: 4795 RVA: 0x00014690 File Offset: 0x00012890
		public void #Rjc(string #5, Exception #ob)
		{
			Logger.Warning(#5, #ob);
		}

		// Token: 0x060012BC RID: 4796 RVA: 0x000ACB2C File Offset: 0x000AAD2C
		public void #pb(string #5)
		{
			#l0i.#ITb #ITb = new #l0i.#ITb();
			#ITb.#a = #5;
			Logger.Info(new Func<string>(#ITb.#BTb));
		}

		// Token: 0x060012BD RID: 4797 RVA: 0x000ACB64 File Offset: 0x000AAD64
		public void #pb(#K1i #5)
		{
			#l0i.#92b #92b = new #l0i.#92b();
			#l0i.#92b #92b2;
			if (!false)
			{
				#92b2 = #92b;
			}
			#92b2.#a = #5;
			if (#92b2.#a == null)
			{
				return;
			}
			Logger.Info(new Func<string>(#92b2.#BTb));
		}

		// Token: 0x060012BE RID: 4798 RVA: 0x000ACBA8 File Offset: 0x000AADA8
		public void #qb(string #5)
		{
			#l0i.#W9b #W9b = new #l0i.#W9b();
			#W9b.#a = #5;
			Logger.Debug(new Func<string>(#W9b.#DTb));
		}

		// Token: 0x060012BF RID: 4799 RVA: 0x000ACBE0 File Offset: 0x000AADE0
		public void #qb(#K1i #5)
		{
			#l0i.#s0b #s0b = new #l0i.#s0b();
			#l0i.#s0b #s0b2;
			if (!false)
			{
				#s0b2 = #s0b;
			}
			#s0b2.#a = #5;
			if (#s0b2.#a == null)
			{
				return;
			}
			Logger.Debug(new Func<string>(#s0b2.#DTb));
		}

		// Token: 0x02000225 RID: 549
		[CompilerGenerated]
		private sealed class #v0b
		{
			// Token: 0x060012C2 RID: 4802 RVA: 0x000146A5 File Offset: 0x000128A5
			internal string #h1i()
			{
				return this.#a();
			}

			// Token: 0x040007A7 RID: 1959
			public #K1i #a;
		}

		// Token: 0x02000226 RID: 550
		[CompilerGenerated]
		private sealed class #dZb
		{
			// Token: 0x060012C4 RID: 4804 RVA: 0x000146BA File Offset: 0x000128BA
			internal string #i1i()
			{
				return this.#a;
			}

			// Token: 0x040007A8 RID: 1960
			public string #a;
		}

		// Token: 0x02000227 RID: 551
		[CompilerGenerated]
		private sealed class #xTb
		{
			// Token: 0x060012C6 RID: 4806 RVA: 0x000146C6 File Offset: 0x000128C6
			internal string #i1i()
			{
				return this.#a();
			}

			// Token: 0x040007A9 RID: 1961
			public #K1i #a;
		}

		// Token: 0x02000228 RID: 552
		[CompilerGenerated]
		private sealed class #ITb
		{
			// Token: 0x060012C8 RID: 4808 RVA: 0x000146DB File Offset: 0x000128DB
			internal string #BTb()
			{
				return this.#a;
			}

			// Token: 0x040007AA RID: 1962
			public string #a;
		}

		// Token: 0x02000229 RID: 553
		[CompilerGenerated]
		private sealed class #92b
		{
			// Token: 0x060012CA RID: 4810 RVA: 0x000146E7 File Offset: 0x000128E7
			internal string #BTb()
			{
				return this.#a();
			}

			// Token: 0x040007AB RID: 1963
			public #K1i #a;
		}

		// Token: 0x0200022A RID: 554
		[CompilerGenerated]
		private sealed class #W9b
		{
			// Token: 0x060012CC RID: 4812 RVA: 0x000146FC File Offset: 0x000128FC
			internal string #DTb()
			{
				return this.#a;
			}

			// Token: 0x040007AC RID: 1964
			public string #a;
		}

		// Token: 0x0200022B RID: 555
		[CompilerGenerated]
		private sealed class #s0b
		{
			// Token: 0x060012CE RID: 4814 RVA: 0x00014708 File Offset: 0x00012908
			internal string #DTb()
			{
				return this.#a();
			}

			// Token: 0x040007AD RID: 1965
			public #K1i #a;
		}
	}
}
