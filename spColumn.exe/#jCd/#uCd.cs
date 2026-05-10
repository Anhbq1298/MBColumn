using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using #5Fd;
using #7hc;

namespace #jCd
{
	// Token: 0x020006E9 RID: 1769
	internal class #uCd
	{
		// Token: 0x06003AC2 RID: 15042 RVA: 0x00115B9C File Offset: 0x00113D9C
		public #uCd(#iCd #odd, #gGd #En)
		{
			if (#odd == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107254045));
			}
			this.#b = #odd;
			this.#c = #En;
			this.ValueSeparator = #uCd.#a.ToString(CultureInfo.InvariantCulture);
			this.PadMergedColumns = true;
		}

		// Token: 0x06003AC3 RID: 15043 RVA: 0x00032F5C File Offset: 0x0003115C
		public #uCd(#iCd #odd) : this(#odd, new #iGd(Encoding.UTF8))
		{
		}

		// Token: 0x170011FD RID: 4605
		// (get) Token: 0x06003AC4 RID: 15044 RVA: 0x00032F6F File Offset: 0x0003116F
		public #iCd Deformatter { get; }

		// Token: 0x170011FE RID: 4606
		// (get) Token: 0x06003AC5 RID: 15045 RVA: 0x00032F7B File Offset: 0x0003117B
		public #gGd Sink { get; }

		// Token: 0x170011FF RID: 4607
		// (get) Token: 0x06003AC6 RID: 15046 RVA: 0x00032F87 File Offset: 0x00031187
		// (set) Token: 0x06003AC7 RID: 15047 RVA: 0x00032F93 File Offset: 0x00031193
		public string ValueSeparator { get; set; }

		// Token: 0x17001200 RID: 4608
		// (get) Token: 0x06003AC8 RID: 15048 RVA: 0x00032FA4 File Offset: 0x000311A4
		// (set) Token: 0x06003AC9 RID: 15049 RVA: 0x00032FB0 File Offset: 0x000311B0
		public bool PadMergedColumns { get; set; }

		// Token: 0x06003ACA RID: 15050 RVA: 0x00115BF0 File Offset: 0x00113DF0
		public void #sCd(StringBuilder #tCd)
		{
			bool flag = false;
			for (int i = 0; i < \u008D\u0002.~\u0090\u0005(#tCd); i++)
			{
				if (\u008C\u0002.~\u008B\u0005(#tCd, i) == #uCd.#a)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				\u0098\u0003.~\u0013\u0008(#tCd, 0, #Phc.#3hc(107350811));
				\u0097\u0003.~\u0011\u0008(#tCd, #Phc.#3hc(107350811));
			}
		}

		// Token: 0x06003ACB RID: 15051 RVA: 0x00115C68 File Offset: 0x00113E68
		public string #sCd(string #f)
		{
			if (\u0003.\u0004(#f))
			{
				return #f;
			}
			if (\u0080.~\u0080\u0002(#f, this.ValueSeparator))
			{
				return \u0010.\u0092(#Phc.#3hc(107350811), #f, #Phc.#3hc(107350811));
			}
			return #f;
		}

		// Token: 0x04001904 RID: 6404
		private static readonly char #a = ',';

		// Token: 0x04001905 RID: 6405
		[CompilerGenerated]
		private readonly #iCd #b;

		// Token: 0x04001906 RID: 6406
		[CompilerGenerated]
		private readonly #gGd #c;

		// Token: 0x04001907 RID: 6407
		[CompilerGenerated]
		private string #d;

		// Token: 0x04001908 RID: 6408
		[CompilerGenerated]
		private bool #e;
	}
}
