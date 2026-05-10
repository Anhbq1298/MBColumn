using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using #7hc;
using #u3d;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #PMc
{
	// Token: 0x02000BD8 RID: 3032
	internal sealed class #kNc
	{
		// Token: 0x060062D7 RID: 25303 RVA: 0x0018194C File Offset: 0x0017FB4C
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public #kNc(ShapeDataModel #rP, PolygonData #Auc, List<Point3D> #wsc, List<int> #lNc, int #mNc, int #Qxc, int #nNc, int #oNc)
		{
			if (#rP == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107371527));
			}
			if (#Auc == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107459220));
			}
			if (#wsc == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107461835));
			}
			if (#lNc == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107413617));
			}
			this.Shape = #rP;
			this.Points3D = new List<Point3D>();
			this.Points3D.AddRange(#wsc);
			this.ShapePolygon = #Auc;
			this.IndexesOfPointsToUpdate = new List<int>();
			this.IndexesOfPointsToUpdate.AddRange(#lNc);
			this.PolygonIndex = #mNc;
			this.PointIndex = #Qxc;
			this.Point3D = #wsc[#Qxc];
			this.StartPointIndex1 = #nNc;
			this.StartPointIndex2 = #oNc;
			this.StartPoint1 = #wsc[#nNc];
			this.StartPoint2 = #wsc[#oNc];
			this.LogicalCenterPoint = Point3D.#G3d(this.StartPoint1, #c4d.#33d(Point3D.#H3d(this.StartPoint2, this.StartPoint1), 0.5));
			this.VisualCenterPoint = this.LogicalCenterPoint;
			this.LineSegments = new List<SegmentData>();
			int num = 0;
			for (int i = 1; i < this.Points3D.Count; i++)
			{
				if (!#lNc.Contains(i) && !#lNc.Contains(num))
				{
					this.LineSegments.Add(new SegmentData(PointsConverter.#vsc(this.Points3D[num]), PointsConverter.#vsc(this.Points3D[i])));
				}
				num = i;
			}
		}

		// Token: 0x17001BF4 RID: 7156
		// (get) Token: 0x060062D8 RID: 25304 RVA: 0x00050949 File Offset: 0x0004EB49
		// (set) Token: 0x060062D9 RID: 25305 RVA: 0x00050951 File Offset: 0x0004EB51
		public Point3D LogicalCenterPoint { get; private set; }

		// Token: 0x17001BF5 RID: 7157
		// (get) Token: 0x060062DA RID: 25306 RVA: 0x0005095A File Offset: 0x0004EB5A
		// (set) Token: 0x060062DB RID: 25307 RVA: 0x00050962 File Offset: 0x0004EB62
		public Point3D VisualCenterPoint { get; private set; }

		// Token: 0x17001BF6 RID: 7158
		// (get) Token: 0x060062DC RID: 25308 RVA: 0x0005096B File Offset: 0x0004EB6B
		// (set) Token: 0x060062DD RID: 25309 RVA: 0x00050973 File Offset: 0x0004EB73
		public ShapeDataModel Shape { get; private set; }

		// Token: 0x17001BF7 RID: 7159
		// (get) Token: 0x060062DE RID: 25310 RVA: 0x0005097C File Offset: 0x0004EB7C
		// (set) Token: 0x060062DF RID: 25311 RVA: 0x00050984 File Offset: 0x0004EB84
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<Point3D> Points3D { get; private set; }

		// Token: 0x17001BF8 RID: 7160
		// (get) Token: 0x060062E0 RID: 25312 RVA: 0x0005098D File Offset: 0x0004EB8D
		// (set) Token: 0x060062E1 RID: 25313 RVA: 0x00050995 File Offset: 0x0004EB95
		public PolygonData ShapePolygon { get; private set; }

		// Token: 0x17001BF9 RID: 7161
		// (get) Token: 0x060062E2 RID: 25314 RVA: 0x0005099E File Offset: 0x0004EB9E
		// (set) Token: 0x060062E3 RID: 25315 RVA: 0x000509A6 File Offset: 0x0004EBA6
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<int> IndexesOfPointsToUpdate { get; private set; }

		// Token: 0x17001BFA RID: 7162
		// (get) Token: 0x060062E4 RID: 25316 RVA: 0x000509AF File Offset: 0x0004EBAF
		// (set) Token: 0x060062E5 RID: 25317 RVA: 0x000509B7 File Offset: 0x0004EBB7
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public List<SegmentData> LineSegments { get; private set; }

		// Token: 0x17001BFB RID: 7163
		// (get) Token: 0x060062E6 RID: 25318 RVA: 0x000509C0 File Offset: 0x0004EBC0
		// (set) Token: 0x060062E7 RID: 25319 RVA: 0x000509C8 File Offset: 0x0004EBC8
		public int PolygonIndex { get; private set; }

		// Token: 0x17001BFC RID: 7164
		// (get) Token: 0x060062E8 RID: 25320 RVA: 0x000509D1 File Offset: 0x0004EBD1
		// (set) Token: 0x060062E9 RID: 25321 RVA: 0x000509D9 File Offset: 0x0004EBD9
		public int PointIndex { get; private set; }

		// Token: 0x17001BFD RID: 7165
		// (get) Token: 0x060062EA RID: 25322 RVA: 0x000509E2 File Offset: 0x0004EBE2
		// (set) Token: 0x060062EB RID: 25323 RVA: 0x000509EA File Offset: 0x0004EBEA
		public Point3D Point3D { get; private set; }

		// Token: 0x17001BFE RID: 7166
		// (get) Token: 0x060062EC RID: 25324 RVA: 0x000509F3 File Offset: 0x0004EBF3
		// (set) Token: 0x060062ED RID: 25325 RVA: 0x000509FB File Offset: 0x0004EBFB
		public int StartPointIndex1 { get; private set; }

		// Token: 0x17001BFF RID: 7167
		// (get) Token: 0x060062EE RID: 25326 RVA: 0x00050A04 File Offset: 0x0004EC04
		// (set) Token: 0x060062EF RID: 25327 RVA: 0x00050A0C File Offset: 0x0004EC0C
		public int StartPointIndex2 { get; private set; }

		// Token: 0x17001C00 RID: 7168
		// (get) Token: 0x060062F0 RID: 25328 RVA: 0x00050A15 File Offset: 0x0004EC15
		// (set) Token: 0x060062F1 RID: 25329 RVA: 0x00050A1D File Offset: 0x0004EC1D
		public Point3D StartPoint1 { get; private set; }

		// Token: 0x17001C01 RID: 7169
		// (get) Token: 0x060062F2 RID: 25330 RVA: 0x00050A26 File Offset: 0x0004EC26
		// (set) Token: 0x060062F3 RID: 25331 RVA: 0x00050A2E File Offset: 0x0004EC2E
		public Point3D StartPoint2 { get; private set; }

		// Token: 0x04002890 RID: 10384
		[CompilerGenerated]
		private Point3D #a;

		// Token: 0x04002891 RID: 10385
		[CompilerGenerated]
		private Point3D #b;

		// Token: 0x04002892 RID: 10386
		[CompilerGenerated]
		private ShapeDataModel #c;

		// Token: 0x04002893 RID: 10387
		[CompilerGenerated]
		private List<Point3D> #d;

		// Token: 0x04002894 RID: 10388
		[CompilerGenerated]
		private PolygonData #e;

		// Token: 0x04002895 RID: 10389
		[CompilerGenerated]
		private List<int> #f;

		// Token: 0x04002896 RID: 10390
		[CompilerGenerated]
		private List<SegmentData> #g;

		// Token: 0x04002897 RID: 10391
		[CompilerGenerated]
		private int #h;

		// Token: 0x04002898 RID: 10392
		[CompilerGenerated]
		private int #i;

		// Token: 0x04002899 RID: 10393
		[CompilerGenerated]
		private Point3D #j;

		// Token: 0x0400289A RID: 10394
		[CompilerGenerated]
		private int #k;

		// Token: 0x0400289B RID: 10395
		[CompilerGenerated]
		private int #l;

		// Token: 0x0400289C RID: 10396
		[CompilerGenerated]
		private Point3D #m;

		// Token: 0x0400289D RID: 10397
		[CompilerGenerated]
		private Point3D #n;
	}
}
