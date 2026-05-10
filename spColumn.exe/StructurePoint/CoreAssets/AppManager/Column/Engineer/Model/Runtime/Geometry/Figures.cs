using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime.Geometry
{
	// Token: 0x02001341 RID: 4929
	public sealed class Figures
	{
		// Token: 0x0600A50F RID: 42255 RVA: 0x002301F0 File Offset: 0x0022E3F0
		public Figures(IList<SectionPolygon> polygons)
		{
			foreach (SectionPolygon sectionPolygon in polygons)
			{
				Point[] array = sectionPolygon.Points.Select(new Func<Point, Point>(Figures.<>c.<>9.#22b)).ToArray<Point>();
				this.SectionFigures.Add(new Points(array, array.Length));
			}
			if (!this.SectionFigures.Any<Points>())
			{
				this.SectionFigures.Add(new Points());
			}
		}

		// Token: 0x0600A510 RID: 42256 RVA: 0x00080D65 File Offset: 0x0007EF65
		public Figures(Point[] initialPoints, int numberOfPoints)
		{
			this.SectionFigures.Add(new Points(initialPoints, numberOfPoints));
		}

		// Token: 0x17002F82 RID: 12162
		// (get) Token: 0x0600A511 RID: 42257 RVA: 0x00080D8A File Offset: 0x0007EF8A
		public IList<Points> SectionFigures { get; } = new List<Points>();

		// Token: 0x0600A512 RID: 42258 RVA: 0x00080D92 File Offset: 0x0007EF92
		public bool #X2e()
		{
			return this.SectionFigures.Any<Points>();
		}

		// Token: 0x0600A513 RID: 42259 RVA: 0x00080D9F File Offset: 0x0007EF9F
		public void #yl()
		{
			this.SectionFigures.Clear();
			this.SectionFigures.Add(new Points());
		}

		// Token: 0x0600A514 RID: 42260 RVA: 0x002302A4 File Offset: 0x0022E4A4
		public void #x1e(float #Udb)
		{
			foreach (Points points in this.SectionFigures)
			{
				points.#x1e(#Udb);
			}
		}

		// Token: 0x0400485F RID: 18527
		[CompilerGenerated]
		private readonly IList<Points> #a;
	}
}
