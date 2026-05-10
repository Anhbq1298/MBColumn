using System;
using System.Windows.Media;
using #hLc;
using #YKc;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;

namespace #IDc
{
	// Token: 0x02000B8B RID: 2955
	internal interface #6Gc : #GLc
	{
		// Token: 0x17001B34 RID: 6964
		// (get) Token: 0x06006042 RID: 24642
		// (set) Token: 0x06006043 RID: 24643
		#fLc ExtendedSelectionKey { get; set; }

		// Token: 0x17001B35 RID: 6965
		// (get) Token: 0x06006044 RID: 24644
		// (set) Token: 0x06006045 RID: 24645
		bool IsOrthogonalModeEnabled { get; set; }

		// Token: 0x17001B36 RID: 6966
		// (get) Token: 0x06006046 RID: 24646
		// (set) Token: 0x06006047 RID: 24647
		Color VisualizationAdditionalFigureFillColor { get; set; }

		// Token: 0x17001B37 RID: 6967
		// (get) Token: 0x06006048 RID: 24648
		// (set) Token: 0x06006049 RID: 24649
		double VisualizationAdditionalFigureEdgeThickness { get; set; }

		// Token: 0x17001B38 RID: 6968
		// (get) Token: 0x0600604A RID: 24650
		// (set) Token: 0x0600604B RID: 24651
		Color VisualizationAdditionalFigureVertexColor { get; set; }

		// Token: 0x17001B39 RID: 6969
		// (get) Token: 0x0600604C RID: 24652
		// (set) Token: 0x0600604D RID: 24653
		double VisualizationAdditionalFigureVertexSize { get; set; }

		// Token: 0x17001B3A RID: 6970
		// (get) Token: 0x0600604E RID: 24654
		// (set) Token: 0x0600604F RID: 24655
		Color VisualizationAdditionalFigureEdgeColor { get; set; }

		// Token: 0x17001B3B RID: 6971
		// (get) Token: 0x06006050 RID: 24656
		// (set) Token: 0x06006051 RID: 24657
		Color VisualizationNewDefinitionColor { get; set; }

		// Token: 0x17001B3C RID: 6972
		// (get) Token: 0x06006052 RID: 24658
		// (set) Token: 0x06006053 RID: 24659
		Color VisualizationShapeFillColor { get; set; }

		// Token: 0x17001B3D RID: 6973
		// (get) Token: 0x06006054 RID: 24660
		// (set) Token: 0x06006055 RID: 24661
		double VisualizationShapeEdgeThickness { get; set; }

		// Token: 0x17001B3E RID: 6974
		// (get) Token: 0x06006056 RID: 24662
		// (set) Token: 0x06006057 RID: 24663
		Color VisualizationShapeVertexColor { get; set; }

		// Token: 0x17001B3F RID: 6975
		// (get) Token: 0x06006058 RID: 24664
		// (set) Token: 0x06006059 RID: 24665
		double VisualizationShapeVertexSize { get; set; }

		// Token: 0x17001B40 RID: 6976
		// (get) Token: 0x0600605A RID: 24666
		// (set) Token: 0x0600605B RID: 24667
		Color VisualizationShapeEdgeColor { get; set; }

		// Token: 0x17001B41 RID: 6977
		// (get) Token: 0x0600605C RID: 24668
		// (set) Token: 0x0600605D RID: 24669
		Color VisualizationGridLineColor { get; set; }

		// Token: 0x17001B42 RID: 6978
		// (get) Token: 0x0600605E RID: 24670
		// (set) Token: 0x0600605F RID: 24671
		Color VisualizationDarkerGridLineColor { get; set; }

		// Token: 0x17001B43 RID: 6979
		// (get) Token: 0x06006060 RID: 24672
		// (set) Token: 0x06006061 RID: 24673
		double VisualizationGridLineThickness { get; set; }

		// Token: 0x17001B44 RID: 6980
		// (get) Token: 0x06006062 RID: 24674
		// (set) Token: 0x06006063 RID: 24675
		double VisualizationDarkerGridLineThickness { get; set; }

		// Token: 0x17001B45 RID: 6981
		// (get) Token: 0x06006064 RID: 24676
		// (set) Token: 0x06006065 RID: 24677
		Color VisualizationDrawingToolNewFigureFillColor { get; set; }

		// Token: 0x17001B46 RID: 6982
		// (get) Token: 0x06006066 RID: 24678
		// (set) Token: 0x06006067 RID: 24679
		Color VisualizationDrawingToolNewFigureEdgeColor { get; set; }

		// Token: 0x17001B47 RID: 6983
		// (get) Token: 0x06006068 RID: 24680
		// (set) Token: 0x06006069 RID: 24681
		double VisualizationDrawingToolNewFigureEdgeThickness { get; set; }

		// Token: 0x17001B48 RID: 6984
		// (get) Token: 0x0600606A RID: 24682
		// (set) Token: 0x0600606B RID: 24683
		Color VisualizationSelectionRectangleFillColor { get; set; }

		// Token: 0x17001B49 RID: 6985
		// (get) Token: 0x0600606C RID: 24684
		// (set) Token: 0x0600606D RID: 24685
		double VisualizationSelectionRectangleBorderThickness { get; set; }

		// Token: 0x17001B4A RID: 6986
		// (get) Token: 0x0600606E RID: 24686
		// (set) Token: 0x0600606F RID: 24687
		Color VisualizationSelectedShapeEdgeColor { get; set; }

		// Token: 0x17001B4B RID: 6987
		// (get) Token: 0x06006070 RID: 24688
		// (set) Token: 0x06006071 RID: 24689
		Color VisualizationSelectedShapeFillColor { get; set; }

		// Token: 0x17001B4C RID: 6988
		// (get) Token: 0x06006072 RID: 24690
		// (set) Token: 0x06006073 RID: 24691
		Color VisualizationSelectedShapePointsColor { get; set; }

		// Token: 0x17001B4D RID: 6989
		// (get) Token: 0x06006074 RID: 24692
		// (set) Token: 0x06006075 RID: 24693
		double VisualizationSelectedShapeEdgeThickness { get; set; }

		// Token: 0x17001B4E RID: 6990
		// (get) Token: 0x06006076 RID: 24694
		// (set) Token: 0x06006077 RID: 24695
		Color VisualizationSelectedCustomNodeColor { get; set; }

		// Token: 0x17001B4F RID: 6991
		// (get) Token: 0x06006078 RID: 24696
		// (set) Token: 0x06006079 RID: 24697
		Color VisualizationSelectionRectangleBorderColor { get; set; }

		// Token: 0x17001B50 RID: 6992
		// (get) Token: 0x0600607A RID: 24698
		// (set) Token: 0x0600607B RID: 24699
		int VisualizationCircleByRadiusToolNumberOfSides { get; set; }

		// Token: 0x17001B51 RID: 6993
		// (get) Token: 0x0600607C RID: 24700
		// (set) Token: 0x0600607D RID: 24701
		double VisualizationSelectionRectangleDashLength { get; set; }

		// Token: 0x17001B52 RID: 6994
		// (get) Token: 0x0600607E RID: 24702
		// (set) Token: 0x0600607F RID: 24703
		double SnapPointsMarkerDefaultVertexSize { get; set; }

		// Token: 0x17001B53 RID: 6995
		// (get) Token: 0x06006080 RID: 24704
		// (set) Token: 0x06006081 RID: 24705
		Color SnapPointsMarkerDefaultVertexColor { get; set; }

		// Token: 0x17001B54 RID: 6996
		// (get) Token: 0x06006082 RID: 24706
		// (set) Token: 0x06006083 RID: 24707
		Color SnapPointsMarkerKeyPointsVertexColor { get; set; }

		// Token: 0x17001B55 RID: 6997
		// (get) Token: 0x06006084 RID: 24708
		// (set) Token: 0x06006085 RID: 24709
		double SnapPointsMarkerKeyPointsVertexSize { get; set; }

		// Token: 0x17001B56 RID: 6998
		// (get) Token: 0x06006086 RID: 24710
		// (set) Token: 0x06006087 RID: 24711
		Color VisualizationDrawCircleUsingTangentPointsPointColor { get; set; }

		// Token: 0x17001B57 RID: 6999
		// (get) Token: 0x06006088 RID: 24712
		// (set) Token: 0x06006089 RID: 24713
		double VisualizationDrawCircleUsingTangentPointsPointSize { get; set; }

		// Token: 0x17001B58 RID: 7000
		// (get) Token: 0x0600608A RID: 24714
		// (set) Token: 0x0600608B RID: 24715
		Color VisualizationNewGridLineColor { get; set; }

		// Token: 0x17001B59 RID: 7001
		// (get) Token: 0x0600608C RID: 24716
		// (set) Token: 0x0600608D RID: 24717
		double VisualizationNewGridLineThickness { get; set; }

		// Token: 0x17001B5A RID: 7002
		// (get) Token: 0x0600608E RID: 24718
		// (set) Token: 0x0600608F RID: 24719
		Color VisualizationHighlightedGridLineColor { get; set; }

		// Token: 0x17001B5B RID: 7003
		// (get) Token: 0x06006090 RID: 24720
		// (set) Token: 0x06006091 RID: 24721
		double VisualizationHighlightedGridLineThickness { get; set; }

		// Token: 0x17001B5C RID: 7004
		// (get) Token: 0x06006092 RID: 24722
		// (set) Token: 0x06006093 RID: 24723
		Color VisualizationEditedGridLineLocationPointColor { get; set; }

		// Token: 0x17001B5D RID: 7005
		// (get) Token: 0x06006094 RID: 24724
		// (set) Token: 0x06006095 RID: 24725
		double VisualizationEditedGridLineLocationPointSize { get; set; }

		// Token: 0x17001B5E RID: 7006
		// (get) Token: 0x06006096 RID: 24726
		// (set) Token: 0x06006097 RID: 24727
		Color VisualizationEditedGridLineRotationPointColor { get; set; }

		// Token: 0x17001B5F RID: 7007
		// (get) Token: 0x06006098 RID: 24728
		// (set) Token: 0x06006099 RID: 24729
		double VisualizationEditedGridLineRotationPointSize { get; set; }

		// Token: 0x17001B60 RID: 7008
		// (get) Token: 0x0600609A RID: 24730
		// (set) Token: 0x0600609B RID: 24731
		Color VisualizationSelectedGridLineColor { get; set; }

		// Token: 0x17001B61 RID: 7009
		// (get) Token: 0x0600609C RID: 24732
		// (set) Token: 0x0600609D RID: 24733
		double VisualizationSelectedGridLineThickness { get; set; }

		// Token: 0x17001B62 RID: 7010
		// (get) Token: 0x0600609E RID: 24734
		// (set) Token: 0x0600609F RID: 24735
		double VisualizationDefaultCustomNodeSize { get; set; }

		// Token: 0x17001B63 RID: 7011
		// (get) Token: 0x060060A0 RID: 24736
		// (set) Token: 0x060060A1 RID: 24737
		Color VisualizationDefaultCustomNodeColor { get; set; }

		// Token: 0x17001B64 RID: 7012
		// (get) Token: 0x060060A2 RID: 24738
		// (set) Token: 0x060060A3 RID: 24739
		Color VisualizationDefaultHighlightedNodeColor { get; set; }

		// Token: 0x17001B65 RID: 7013
		// (get) Token: 0x060060A4 RID: 24740
		// (set) Token: 0x060060A5 RID: 24741
		Color VisualizationEditorWorkspaceBackgroundColor { get; set; }

		// Token: 0x17001B66 RID: 7014
		// (get) Token: 0x060060A6 RID: 24742
		// (set) Token: 0x060060A7 RID: 24743
		Color VisualizationEditorBackgroundColor { get; set; }

		// Token: 0x17001B67 RID: 7015
		// (get) Token: 0x060060A8 RID: 24744
		// (set) Token: 0x060060A9 RID: 24745
		Color VisualizationGridLineAnnotationBackgroundColor { get; set; }

		// Token: 0x17001B68 RID: 7016
		// (get) Token: 0x060060AA RID: 24746
		// (set) Token: 0x060060AB RID: 24747
		Color VisualizationGridLineAnnotationForegroundColor { get; set; }

		// Token: 0x17001B69 RID: 7017
		// (get) Token: 0x060060AC RID: 24748
		// (set) Token: 0x060060AD RID: 24749
		Color VisualizationGridLineAnnotationBorderColor { get; set; }

		// Token: 0x17001B6A RID: 7018
		// (get) Token: 0x060060AE RID: 24750
		// (set) Token: 0x060060AF RID: 24751
		Color VisualizationSelectedGridLineAnnotationBackgroundColor { get; set; }

		// Token: 0x17001B6B RID: 7019
		// (get) Token: 0x060060B0 RID: 24752
		// (set) Token: 0x060060B1 RID: 24753
		Color VisualizationSelectedGridLineAnnotationForegroundColor { get; set; }

		// Token: 0x17001B6C RID: 7020
		// (get) Token: 0x060060B2 RID: 24754
		// (set) Token: 0x060060B3 RID: 24755
		Color VisualizationSelectedGridLineAnnotationBorderColor { get; set; }

		// Token: 0x17001B6D RID: 7021
		// (get) Token: 0x060060B4 RID: 24756
		// (set) Token: 0x060060B5 RID: 24757
		Color VisualizationDefaultLinearObjectColor { get; set; }

		// Token: 0x17001B6E RID: 7022
		// (get) Token: 0x060060B6 RID: 24758
		// (set) Token: 0x060060B7 RID: 24759
		double VisualizationDefaultLinearObjectThickness { get; set; }

		// Token: 0x17001B6F RID: 7023
		// (get) Token: 0x060060B8 RID: 24760
		// (set) Token: 0x060060B9 RID: 24761
		int VisualizationCircleByDiameterToolNumberOfSides { get; set; }

		// Token: 0x17001B70 RID: 7024
		// (get) Token: 0x060060BA RID: 24762
		// (set) Token: 0x060060BB RID: 24763
		int VisualizationCircleByTangentPointsToolNumberOfSides { get; set; }

		// Token: 0x17001B71 RID: 7025
		// (get) Token: 0x060060BC RID: 24764
		// (set) Token: 0x060060BD RID: 24765
		bool ViewControlsPanelVisible { get; set; }

		// Token: 0x17001B72 RID: 7026
		// (get) Token: 0x060060BE RID: 24766
		// (set) Token: 0x060060BF RID: 24767
		ToolsPanelPosition ViewControlsPanelPosition { get; set; }

		// Token: 0x17001B73 RID: 7027
		// (get) Token: 0x060060C0 RID: 24768
		// (set) Token: 0x060060C1 RID: 24769
		bool ViewControlsPanelCollapsed { get; set; }

		// Token: 0x1400017B RID: 379
		// (add) Token: 0x060060C2 RID: 24770
		// (remove) Token: 0x060060C3 RID: 24771
		event EventHandler OrthogonalModeEnabledChanged;
	}
}
