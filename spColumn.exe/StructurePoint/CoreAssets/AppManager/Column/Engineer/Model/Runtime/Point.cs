using System;
using StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime
{
	// Token: 0x020012A6 RID: 4774
	public struct Point
	{
		// Token: 0x06009FED RID: 40941 RVA: 0x0007D968 File Offset: 0x0007BB68
		public Point(float x, float y)
		{
			this = default(Point);
			this.#a = x;
			this.#b = y;
		}

		// Token: 0x06009FEE RID: 40942 RVA: 0x0007D97F File Offset: 0x0007BB7F
		public Point(Point oldPoint)
		{
			this.#a = oldPoint.#a;
			this.#b = oldPoint.#b;
		}

		// Token: 0x17002E01 RID: 11777
		// (get) Token: 0x06009FEF RID: 40943 RVA: 0x0007D999 File Offset: 0x0007BB99
		public float X
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x17002E02 RID: 11778
		// (get) Token: 0x06009FF0 RID: 40944 RVA: 0x0007D9A1 File Offset: 0x0007BBA1
		public float Y
		{
			get
			{
				return this.#b;
			}
		}

		// Token: 0x06009FF1 RID: 40945 RVA: 0x0007D9A9 File Offset: 0x0007BBA9
		internal static Point #Dge(FPOINT #Ng)
		{
			return new Point(#Ng.#a, #Ng.#b);
		}

		// Token: 0x040045DF RID: 17887
		private readonly float #a;

		// Token: 0x040045E0 RID: 17888
		private readonly float #b;
	}
}
