using System;
using #wUe;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #gMe
{
	// Token: 0x0200129C RID: 4764
	internal sealed class #mNe
	{
		// Token: 0x06009FA9 RID: 40873 RVA: 0x0021E008 File Offset: 0x0021C208
		public static #NWi #bpb(Point[] #BP, int #kNe, float #lNe)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			for (int i = 0; i < #kNe - 1; i++)
			{
				Point point = #BP[i];
				float num4 = point.X;
				float num5 = point.Y;
				Point point2 = #BP[i + 1];
				float num6 = point2.X;
				float num7 = point2.Y;
				if (num5 > #lNe || num7 > #lNe)
				{
					if (num5 < #lNe && num7 > #lNe)
					{
						num4 -= (num5 - #lNe) * (num6 - num4) / (num7 - num5);
						num5 = #lNe;
					}
					else if (num5 > #lNe && num7 < #lNe)
					{
						num6 -= (num7 - #lNe) * (num6 - num4) / (num7 - num5);
						num7 = #lNe;
					}
					float num8 = num6 - num4;
					float num9 = num7 - num5;
					float num10 = num6 + num4;
					float num11 = num7 + num5;
					float num12 = 4f * #lNe * #lNe;
					num3 += num8 * (num11 / 2f - #lNe);
					num2 += num8 * (num11 * num11 + num9 * num9 / 3f - num12) / 8f;
					num += num9 * (num10 * num10 + num8 * num8 / 3f) / 8f;
				}
			}
			if (#xke.#dke(num3))
			{
				num = -num / num3;
				num2 /= num3;
				num3 = #xke.#hke(num3);
			}
			else
			{
				num = 0f;
				num2 = 0f;
			}
			return new #NWi(num3, num, num2);
		}
	}
}
