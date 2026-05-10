using System;
using #wUe;

namespace #gMe
{
	// Token: 0x020012C3 RID: 4803
	internal static class #5Qe
	{
		// Token: 0x0600A0D8 RID: 41176 RVA: 0x00223E1C File Offset: 0x0022201C
		public static float #4Qe(float #0jb, float #1jb)
		{
			if (#xke.#hke(#1jb) < 0.001f)
			{
				if (#0jb < 0f)
				{
					return 180f;
				}
				return 0f;
			}
			else if (#xke.#hke(#0jb) < 0.001f)
			{
				if (#1jb < 0f)
				{
					return 270f;
				}
				return 90f;
			}
			else
			{
				float num = (float)(#xke.#tke(#xke.#hke(#0jb / #1jb)) * 180.0 / 3.1415927410125732);
				if (#0jb > 0f && #1jb > 0f)
				{
					return 90f - num;
				}
				if (#0jb > 0f && #1jb < 0f)
				{
					return 270f + num;
				}
				if (#0jb < 0f && #1jb > 0f)
				{
					return 90f + num;
				}
				if (#0jb < 0f && #1jb < 0f)
				{
					return 270f - num;
				}
				return num;
			}
		}
	}
}
