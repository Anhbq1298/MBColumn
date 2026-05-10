using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace #01h
{
	// Token: 0x02000792 RID: 1938
	internal sealed class #Z1h
	{
		// Token: 0x06003E3E RID: 15934 RVA: 0x0003518D File Offset: 0x0003338D
		public #Z1h(int #3, string #11h)
		{
			this.GroupCode = #3;
			this.Value = new List<char>();
			this.Value.AddRange(#11h);
		}

		// Token: 0x06003E3F RID: 15935 RVA: 0x00120210 File Offset: 0x0011E410
		public string #W1h()
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2;
			if (4 != 0)
			{
				stringBuilder2 = stringBuilder;
			}
			int num4;
			int num3;
			int num2;
			int num = num2 = (num3 = (num4 = this.Value.Count));
			int num5;
			if (true)
			{
				if (7 != 0)
				{
					num5 = num;
				}
				goto IL_27;
			}
			IL_1E:
			int num7;
			int num6 = num7 = 1;
			if (num6 == 0)
			{
				goto IL_2C;
			}
			int num8 = num2 - num6;
			if (!false)
			{
				num5 = num8;
			}
			IL_27:
			if (!true)
			{
				goto IL_4A;
			}
			num4 = (num3 = num5);
			num7 = 0;
			IL_2C:
			int num10;
			int num9 = num10 = num7;
			if (num9 != 0)
			{
				goto IL_5F;
			}
			int num12;
			if (num3 <= num9 || this.Value[num5 - 1] >= '!')
			{
				int num11 = 0;
				if (-1 != 0)
				{
					num12 = num11;
				}
				goto IL_64;
			}
			num3 = (num2 = (num4 = num5));
			goto IL_1E;
			IL_4A:
			stringBuilder2.Append(this.Value[num12]);
			num4 = num12;
			num10 = 1;
			IL_5F:
			int num13 = num4 + num10;
			if (!false)
			{
				num12 = num13;
			}
			IL_64:
			if (num12 >= num5)
			{
				return stringBuilder2.ToString();
			}
			goto IL_4A;
		}

		// Token: 0x170012E4 RID: 4836
		// (get) Token: 0x06003E40 RID: 15936 RVA: 0x000351B3 File Offset: 0x000333B3
		// (set) Token: 0x06003E41 RID: 15937 RVA: 0x000351BB File Offset: 0x000333BB
		public int GroupCode { get; set; }

		// Token: 0x170012E5 RID: 4837
		// (get) Token: 0x06003E42 RID: 15938 RVA: 0x000351C4 File Offset: 0x000333C4
		// (set) Token: 0x06003E43 RID: 15939 RVA: 0x000351CC File Offset: 0x000333CC
		public List<char> Value { get; private set; }

		// Token: 0x04001C38 RID: 7224
		[CompilerGenerated]
		private int #a;

		// Token: 0x04001C39 RID: 7225
		[CompilerGenerated]
		private List<char> #b;
	}
}
