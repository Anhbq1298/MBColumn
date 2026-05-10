using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #Fmc
{
	// Token: 0x020007D5 RID: 2005
	internal interface #Qrc
	{
		// Token: 0x1700134B RID: 4939
		// (get) Token: 0x06004070 RID: 16496
		// (set) Token: 0x06004071 RID: 16497
		bool IsInOrthogonalMode { get; set; }

		// Token: 0x1700134C RID: 4940
		// (get) Token: 0x06004072 RID: 16498
		// (set) Token: 0x06004073 RID: 16499
		double MaxDistance { get; set; }

		// Token: 0x1700134D RID: 4941
		// (get) Token: 0x06004074 RID: 16500
		IEnumerable<Point> GridLinesIntersectionPoints { get; }

		// Token: 0x1700134E RID: 4942
		// (get) Token: 0x06004075 RID: 16501
		IEnumerable<SegmentData> GridLineSegments { get; }

		// Token: 0x06004076 RID: 16502
		[SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		Point? #bNb(List<Point> #BP, Point #Ng, double #WLb);

		// Token: 0x06004077 RID: 16503
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		[SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
		Point3D? #bNb(List<Point> #BP, Point3D #HAb, double #WLb);

		// Token: 0x06004078 RID: 16504
		#fuc #sqc(IList<SnappingSegmentData> #tqc, Point3D #HAb, double #WLb, #iuc #uqc);

		// Token: 0x06004079 RID: 16505
		void #yl(bool #zrc);

		// Token: 0x0600407A RID: 16506
		void #Arc(IEnumerable<SnappingPointData> #Brc);

		// Token: 0x0600407B RID: 16507
		void #Crc(IEnumerable<SnappingSegmentData> #IP);

		// Token: 0x0600407C RID: 16508
		void #Drc(IEnumerable<SnappingSegmentData> #IP);

		// Token: 0x0600407D RID: 16509
		void #Erc(IEnumerable<SnappingPointData> #Frc);

		// Token: 0x0600407E RID: 16510
		void #Grc(IEnumerable<SnappingPointData> #Hrc);

		// Token: 0x0600407F RID: 16511
		Point3D? #vqc(Point3D #HAb);

		// Token: 0x06004080 RID: 16512
		Point3D? #vqc(Point3D #HAb, double #WLb);

		// Token: 0x06004081 RID: 16513
		#fuc #sqc(IList<SnappingSegmentData> #tqc, Point3D #HAb, double #WLb);

		// Token: 0x06004082 RID: 16514
		#Atc #bNb(#hvc #Irc, Point3D #HAb);

		// Token: 0x06004083 RID: 16515
		#Atc #bNb(#hvc #Irc, Point3D #HAb, double #WLb);

		// Token: 0x06004084 RID: 16516
		#fuc #wqc(Point3D #HAb, double #WLb);

		// Token: 0x06004085 RID: 16517
		#fuc #wqc(Point3D #HAb);

		// Token: 0x06004086 RID: 16518
		#fuc #Jrc(Point3D #HAb);

		// Token: 0x06004087 RID: 16519
		#fuc #Jrc(Point3D #HAb, double #WLb);

		// Token: 0x06004088 RID: 16520
		Point3D? #Krc(Point3D #HAb, double #WLb);

		// Token: 0x06004089 RID: 16521
		Point3D? #Lrc(Point3D #HAb, double #WLb);

		// Token: 0x0600408A RID: 16522
		#Atc #Mrc(#hvc #Irc, Point3D #Nrc, Point3D #Orc, BoundingBoxData #Prc);

		// Token: 0x0600408B RID: 16523
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		Point3D? #Mrc(List<Point> #BP, Point3D #HAb, double #WLb, Point3D #Orc, BoundingBoxData #Prc);
	}
}
