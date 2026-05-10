using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using #7hc;

namespace #hTb
{
	// Token: 0x02000E43 RID: 3651
	[CompilerGenerated]
	internal sealed class #63h<#73h, #83h, #93h>
	{
		// Token: 0x17002706 RID: 9990
		// (get) Token: 0x060082A6 RID: 33446 RVA: 0x0006A677 File Offset: 0x00068877
		public #73h tableName
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x17002707 RID: 9991
		// (get) Token: 0x060082A7 RID: 33447 RVA: 0x0006A67F File Offset: 0x0006887F
		public #83h mustExist
		{
			get
			{
				return this.#b;
			}
		}

		// Token: 0x17002708 RID: 9992
		// (get) Token: 0x060082A8 RID: 33448 RVA: 0x0006A687 File Offset: 0x00068887
		public #93h loadByLoad
		{
			get
			{
				return this.#c;
			}
		}

		// Token: 0x060082A9 RID: 33449 RVA: 0x0006A68F File Offset: 0x0006888F
		[DebuggerHidden]
		public #63h(#73h #rEd, #83h #a4h, #93h #b4h)
		{
			this.#a = #rEd;
			this.#b = #a4h;
			this.#c = #b4h;
		}

		// Token: 0x060082AA RID: 33450 RVA: 0x001C42EC File Offset: 0x001C24EC
		[DebuggerHidden]
		public bool #e(object #f)
		{
			#63h<#73h, #83h, #93h> #63h = #f as #63h<!0, !1, !2>;
			return this == #63h || (#63h != null && EqualityComparer<!0>.Default.Equals(this.#a, #63h.#a) && EqualityComparer<!1>.Default.Equals(this.#b, #63h.#b) && EqualityComparer<!2>.Default.Equals(this.#c, #63h.#c));
		}

		// Token: 0x060082AB RID: 33451 RVA: 0x001C4354 File Offset: 0x001C2554
		[DebuggerHidden]
		public int #g()
		{
			return ((1445220272 * -1521134295 + EqualityComparer<!0>.Default.GetHashCode(this.#a)) * -1521134295 + EqualityComparer<!1>.Default.GetHashCode(this.#b)) * -1521134295 + EqualityComparer<!2>.Default.GetHashCode(this.#c);
		}

		// Token: 0x060082AC RID: 33452 RVA: 0x001C43AC File Offset: 0x001C25AC
		[DebuggerHidden]
		public string #h()
		{
			IFormatProvider provider = null;
			string format = #Phc.#3hc(107275518);
			object[] array = new object[3];
			int num = 0;
			#73h #73h = this.#a;
			array[num] = ((#73h != null) ? #73h.ToString() : null);
			int num2 = 1;
			#83h #83h = this.#b;
			array[num2] = ((#83h != null) ? #83h.ToString() : null);
			int num3 = 2;
			#93h #93h = this.#c;
			array[num3] = ((#93h != null) ? #93h.ToString() : null);
			return string.Format(provider, format, array);
		}

		// Token: 0x040035AA RID: 13738
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly #73h #a;

		// Token: 0x040035AB RID: 13739
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly #83h #b;

		// Token: 0x040035AC RID: 13740
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly #93h #c;
	}
}
