using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using #ezc;
using #N6c;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #NWc
{
	// Token: 0x02000C84 RID: 3204
	internal interface #WWc : #PBc
	{
		// Token: 0x14000190 RID: 400
		// (add) Token: 0x060067CD RID: 26573
		// (remove) Token: 0x060067CE RID: 26574
		event EventHandler ShapesChanged;

		// Token: 0x17001CC4 RID: 7364
		// (get) Token: 0x060067CF RID: 26575
		#k8c<ShapeDataModel> Shapes { get; }

		// Token: 0x17001CC5 RID: 7365
		// (get) Token: 0x060067D0 RID: 26576
		#k8c<NodeModel> Nodes { get; }

		// Token: 0x17001CC6 RID: 7366
		// (get) Token: 0x060067D1 RID: 26577
		#k8c<LinearObject> LinearObjects { get; }

		// Token: 0x17001CC7 RID: 7367
		// (get) Token: 0x060067D2 RID: 26578
		#k8c<GridLineDefinitionModel> GridLines { get; }

		// Token: 0x17001CC8 RID: 7368
		// (get) Token: 0x060067D3 RID: 26579
		BoundingBoxData WorkspaceBoundingBoxData { get; }

		// Token: 0x060067D4 RID: 26580
		[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
		void #KVc();

		// Token: 0x060067D5 RID: 26581
		void #yl();

		// Token: 0x060067D6 RID: 26582
		void #OVc();

		// Token: 0x060067D7 RID: 26583
		void #PVc();

		// Token: 0x060067D8 RID: 26584
		void #QVc();

		// Token: 0x060067D9 RID: 26585
		void #9Vc(LinearObject #NNc);

		// Token: 0x060067DA RID: 26586
		void #aWc(LinearObject #NNc);

		// Token: 0x060067DB RID: 26587
		void #bWc(IEnumerable<LinearObject> #iEc);

		// Token: 0x060067DC RID: 26588
		bool #cWc(Point #mcb, Point #ncb);

		// Token: 0x060067DD RID: 26589
		void #RVc();

		// Token: 0x060067DE RID: 26590
		void #SVc(NodeModel #uXb);

		// Token: 0x060067DF RID: 26591
		void #TVc(IEnumerable<NodeModel> #UVc);

		// Token: 0x060067E0 RID: 26592
		void #VVc(NodeModel #SNc);

		// Token: 0x060067E1 RID: 26593
		void #jEc(IEnumerable<NodeModel> #WVc);

		// Token: 0x060067E2 RID: 26594
		bool #XVc(Point #Ng);

		// Token: 0x060067E3 RID: 26595
		void #dWc(ShapeDataModel #eWc);

		// Token: 0x060067E4 RID: 26596
		void #fWc(IEnumerable<ShapeDataModel> #gWc);

		// Token: 0x060067E5 RID: 26597
		void #hWc(ShapeDataModel #6lc);

		// Token: 0x060067E6 RID: 26598
		int #iWc(Point #doc);

		// Token: 0x060067E7 RID: 26599
		IList<SegmentData> #jWc(Point #Ng);

		// Token: 0x060067E8 RID: 26600
		BoundingBoxData #kWc();

		// Token: 0x060067E9 RID: 26601
		IList<SnappingPointData> #lWc();

		// Token: 0x060067EA RID: 26602
		IList<SnappingPointData> #oWc();

		// Token: 0x060067EB RID: 26603
		IList<SnappingSegmentData> #mWc();

		// Token: 0x060067EC RID: 26604
		IList<SnappingPointData> #nWc();

		// Token: 0x060067ED RID: 26605
		void #YVc(GridLineDefinitionModel #bsc);

		// Token: 0x060067EE RID: 26606
		void #ZVc(GridLineDefinitionModel #bsc, int #4jb);

		// Token: 0x060067EF RID: 26607
		void #0Vc(IEnumerable<GridLineDefinitionModel> #ooc);

		// Token: 0x060067F0 RID: 26608
		void #1Vc(GridLineDefinitionModel #bsc);

		// Token: 0x060067F1 RID: 26609
		bool #2Vc(GridLineDefinitionModel #bsc);

		// Token: 0x060067F2 RID: 26610
		GridLineDefinitionModel #3Vc(SegmentData #PP);

		// Token: 0x060067F3 RID: 26611
		void #4Vc(GridLineDefinitionModel #bsc, int #4jb);

		// Token: 0x060067F4 RID: 26612
		void #5Vc(GridLineDefinitionModel #6Vc, GridLineDefinitionModel #7Vc);
	}
}
