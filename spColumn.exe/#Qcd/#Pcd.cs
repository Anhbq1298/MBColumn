using System;
using #5Fd;
using #FCd;
using #jCd;
using #QBd;
using #Ted;
using #VEd;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Paged.WordPdf;

namespace #Qcd
{
	// Token: 0x02000D08 RID: 3336
	internal static class #Pcd
	{
		// Token: 0x06006E06 RID: 28166 RVA: 0x00058A2C File Offset: 0x00056C2C
		public static bool #Icd(this #6Dd #opb)
		{
			return #opb is #6Bd;
		}

		// Token: 0x06006E07 RID: 28167 RVA: 0x00058A3B File Offset: 0x00056C3B
		public static bool #Jcd(this #6Dd #opb)
		{
			return #opb is #Khd;
		}

		// Token: 0x06006E08 RID: 28168 RVA: 0x00058A4A File Offset: 0x00056C4A
		public static bool #Kcd(this #6Dd #opb)
		{
			return #opb is #qFd;
		}

		// Token: 0x06006E09 RID: 28169 RVA: 0x00058A59 File Offset: 0x00056C59
		public static bool #Lcd(this #6Dd #opb)
		{
			return #opb is #RHd;
		}

		// Token: 0x06006E0A RID: 28170 RVA: 0x00058A68 File Offset: 0x00056C68
		public static bool #Mcd(this #6Dd #opb)
		{
			return #opb is #xCd;
		}

		// Token: 0x06006E0B RID: 28171 RVA: 0x00058A77 File Offset: 0x00056C77
		public static bool #Ncd(this #6Dd #opb)
		{
			return #opb.#Icd() || #opb.#Jcd();
		}

		// Token: 0x06006E0C RID: 28172 RVA: 0x001A420C File Offset: 0x001A240C
		public static string #Ocd(this #6Dd #opb)
		{
			if (!#opb.#Lcd())
			{
				return string.Empty;
			}
			return #QHd.MergedCellPadding.ToString();
		}

		// Token: 0x06006E0D RID: 28173 RVA: 0x00058A95 File Offset: 0x00056C95
		public static bool #Icd(this #5Dd #opb)
		{
			return #opb is #4Bd;
		}

		// Token: 0x06006E0E RID: 28174 RVA: 0x00058AA4 File Offset: 0x00056CA4
		public static bool #Jcd(this #5Dd #opb)
		{
			return #opb is #Ihd;
		}

		// Token: 0x06006E0F RID: 28175 RVA: 0x00058AB3 File Offset: 0x00056CB3
		public static bool #Kcd(this #5Dd #opb)
		{
			return #opb is AsposeTableWriter;
		}

		// Token: 0x06006E10 RID: 28176 RVA: 0x00058AC2 File Offset: 0x00056CC2
		public static bool #Lcd(this #5Dd #opb)
		{
			return #opb is #QHd;
		}

		// Token: 0x06006E11 RID: 28177 RVA: 0x00058AD1 File Offset: 0x00056CD1
		public static bool #Mcd(this #5Dd #opb)
		{
			return #opb is #wCd;
		}

		// Token: 0x06006E12 RID: 28178 RVA: 0x00058AE0 File Offset: 0x00056CE0
		public static bool #Ncd(this #5Dd #opb)
		{
			return #opb.#Icd() || #opb.#Jcd();
		}

		// Token: 0x06006E13 RID: 28179 RVA: 0x001A4240 File Offset: 0x001A2440
		public static string #Ocd(this #5Dd #opb)
		{
			if (!#opb.#Lcd())
			{
				return string.Empty;
			}
			return #QHd.MergedCellPadding.ToString();
		}
	}
}
