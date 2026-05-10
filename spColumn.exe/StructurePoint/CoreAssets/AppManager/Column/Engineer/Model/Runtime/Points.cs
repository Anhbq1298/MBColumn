using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #wUe;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime
{
	// Token: 0x02001334 RID: 4916
	public sealed class Points
	{
		// Token: 0x0600A43E RID: 42046 RVA: 0x0008044F File Offset: 0x0007E64F
		public Points()
		{
			this.InitialPoints = new Point[10001];
			this.TransformedPoints = new Point[10001];
		}

		// Token: 0x0600A43F RID: 42047 RVA: 0x0022F900 File Offset: 0x0022DB00
		public Points(Point[] initialPoints, int numberOfPoints)
		{
			if (initialPoints.Length != 10001)
			{
				Point[] array = initialPoints;
				initialPoints = new Point[10001];
				Array.Copy(array, 0, initialPoints, 0, array.Length);
				for (int i = array.Length; i < 10001; i++)
				{
					initialPoints[i] = new Point(0f, 0f);
				}
			}
			this.InitialPoints = initialPoints;
			this.NumberOfPoints = numberOfPoints;
			this.TransformedPoints = new Point[10001];
			this.#A1e();
		}

		// Token: 0x17002F2E RID: 12078
		// (get) Token: 0x0600A440 RID: 42048 RVA: 0x00080477 File Offset: 0x0007E677
		public Point[] InitialPoints { get; }

		// Token: 0x17002F2F RID: 12079
		// (get) Token: 0x0600A441 RID: 42049 RVA: 0x0008047F File Offset: 0x0007E67F
		public Point[] TransformedPoints { get; }

		// Token: 0x17002F30 RID: 12080
		// (get) Token: 0x0600A442 RID: 42050 RVA: 0x00080487 File Offset: 0x0007E687
		// (set) Token: 0x0600A443 RID: 42051 RVA: 0x0008048F File Offset: 0x0007E68F
		public int NumberOfPoints { get; set; }

		// Token: 0x17002F31 RID: 12081
		// (get) Token: 0x0600A444 RID: 42052 RVA: 0x00080498 File Offset: 0x0007E698
		public bool IsEmpty
		{
			get
			{
				return this.NumberOfPoints <= 0;
			}
		}

		// Token: 0x0600A445 RID: 42053 RVA: 0x000804A6 File Offset: 0x0007E6A6
		public bool #Lnc(float #9o, float #7W)
		{
			if (this.#b == null)
			{
				throw new InvalidOperationException(#Phc.#3hc(107311711));
			}
			return this.#b.#Lnc(new Point((double)#9o, (double)#7W));
		}

		// Token: 0x0600A446 RID: 42054 RVA: 0x000804D4 File Offset: 0x0007E6D4
		public bool #Lnc(Point #Ng)
		{
			if (this.#b == null)
			{
				throw new InvalidOperationException(#Phc.#3hc(107311711));
			}
			return this.#b.#Lnc(new Point((double)#Ng.X, (double)#Ng.Y));
		}

		// Token: 0x0600A447 RID: 42055 RVA: 0x0022F984 File Offset: 0x0022DB84
		public void #x1e(float #Udb)
		{
			#Udb = #Udb * 3.1415927f / 180f;
			float num = #xke.#oke(#Udb);
			float num2 = #xke.#qke(#Udb);
			for (int i = 0; i < this.NumberOfPoints; i++)
			{
				Point point = this.InitialPoints[i];
				float num3 = point.X;
				float num4 = point.Y;
				float x = num3 * num + num4 * num2;
				float y = -num3 * num2 + num4 * num;
				this.TransformedPoints[i] = new Point(x, y);
			}
		}

		// Token: 0x0600A448 RID: 42056 RVA: 0x0008050E File Offset: 0x0007E70E
		public IEnumerable<Point> #y1e()
		{
			return this.InitialPoints.Take(this.NumberOfPoints);
		}

		// Token: 0x0600A449 RID: 42057 RVA: 0x00080521 File Offset: 0x0007E721
		public IEnumerable<Point> #z1e()
		{
			return this.TransformedPoints.Take(this.NumberOfPoints);
		}

		// Token: 0x0600A44A RID: 42058 RVA: 0x00080534 File Offset: 0x0007E734
		private void #A1e()
		{
			if (this.NumberOfPoints > 0)
			{
				this.#b = new PolygonData(this.#y1e().Select(new Func<Point, Point3D>(Points.<>c.<>9.#nif)));
			}
		}

		// Token: 0x040047FD RID: 18429
		private const int #a = 10001;

		// Token: 0x040047FE RID: 18430
		private PolygonData #b;

		// Token: 0x040047FF RID: 18431
		[CompilerGenerated]
		private readonly Point[] #c;

		// Token: 0x04004800 RID: 18432
		[CompilerGenerated]
		private readonly Point[] #d;

		// Token: 0x04004801 RID: 18433
		[CompilerGenerated]
		private int #e;
	}
}
