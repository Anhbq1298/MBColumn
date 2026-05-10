using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Media;
using #3Qb;
using #45d;
using #eU;
using #f7;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.Core.Application.Misc;

namespace StructurePoint.Products.Column.Services.API
{
	// Token: 0x020002B0 RID: 688
	internal interface ISettingsManager : INotifyPropertyChanged
	{
		// Token: 0x17000894 RID: 2196
		// (get) Token: 0x06001754 RID: 5972
		#tU RuntimeSettings { get; }

		// Token: 0x17000895 RID: 2197
		// (get) Token: 0x06001755 RID: 5973
		#55d UserSettingProvider { get; }

		// Token: 0x17000896 RID: 2198
		// (get) Token: 0x06001756 RID: 5974
		#55d ApplicationSettingProvider { get; }

		// Token: 0x17000897 RID: 2199
		// (get) Token: 0x06001757 RID: 5975
		// (set) Token: 0x06001758 RID: 5976
		List<string> RecentProjects { get; set; }

		// Token: 0x17000898 RID: 2200
		// (get) Token: 0x06001759 RID: 5977
		// (set) Token: 0x0600175A RID: 5978
		DesignCodes StartupDefaultDesignCode { get; set; }

		// Token: 0x17000899 RID: 2201
		// (get) Token: 0x0600175B RID: 5979
		// (set) Token: 0x0600175C RID: 5980
		UnitSystem StartupDefaultUnitSystem { get; set; }

		// Token: 0x1700089A RID: 2202
		// (get) Token: 0x0600175D RID: 5981
		// (set) Token: 0x0600175E RID: 5982
		BarGroupType StartupDefaultBarGroupType { get; set; }

		// Token: 0x1700089B RID: 2203
		// (get) Token: 0x0600175F RID: 5983
		// (set) Token: 0x06001760 RID: 5984
		SectionCapacityMethodType StartupDefaultSectionCapacity { get; set; }

		// Token: 0x1700089C RID: 2204
		// (get) Token: 0x06001761 RID: 5985
		// (set) Token: 0x06001762 RID: 5986
		bool IsLeftPanelOpened { get; set; }

		// Token: 0x1700089D RID: 2205
		// (get) Token: 0x06001763 RID: 5987
		// (set) Token: 0x06001764 RID: 5988
		ViewControlsSettings ViewControlSettings { get; set; }

		// Token: 0x1700089E RID: 2206
		// (get) Token: 0x06001765 RID: 5989
		// (set) Token: 0x06001766 RID: 5990
		Diagram2DCursorType Diagram2DCursorType { get; set; }

		// Token: 0x1700089F RID: 2207
		// (get) Token: 0x06001767 RID: 5991
		// (set) Token: 0x06001768 RID: 5992
		ToolsPanelPosition ViewControlsPanelPosition { get; set; }

		// Token: 0x170008A0 RID: 2208
		// (get) Token: 0x06001769 RID: 5993
		// (set) Token: 0x0600176A RID: 5994
		double CrossSectionInnerLoadPointRadius { get; set; }

		// Token: 0x170008A1 RID: 2209
		// (get) Token: 0x0600176B RID: 5995
		// (set) Token: 0x0600176C RID: 5996
		System.Windows.Media.Color FailureSurfaceNominalSurfaceColor { get; set; }

		// Token: 0x170008A2 RID: 2210
		// (get) Token: 0x0600176D RID: 5997
		// (set) Token: 0x0600176E RID: 5998
		System.Windows.Media.Color FailureSurfaceFactoredSurfaceColor { get; set; }

		// Token: 0x170008A3 RID: 2211
		// (get) Token: 0x0600176F RID: 5999
		// (set) Token: 0x06001770 RID: 6000
		double FailureSurfaceNominalWireframeLineThickness { get; set; }

		// Token: 0x170008A4 RID: 2212
		// (get) Token: 0x06001771 RID: 6001
		// (set) Token: 0x06001772 RID: 6002
		double FailureSurfaceFactoredWireframeLineThickness { get; set; }

		// Token: 0x170008A5 RID: 2213
		// (get) Token: 0x06001773 RID: 6003
		// (set) Token: 0x06001774 RID: 6004
		System.Windows.Media.Color FailureSurfaceNominalWireframeLineColor { get; set; }

		// Token: 0x170008A6 RID: 2214
		// (get) Token: 0x06001775 RID: 6005
		// (set) Token: 0x06001776 RID: 6006
		System.Windows.Media.Color FailureSurfaceFactoredWireframeLineColor { get; set; }

		// Token: 0x170008A7 RID: 2215
		// (get) Token: 0x06001777 RID: 6007
		// (set) Token: 0x06001778 RID: 6008
		double CrossSectionOuterLoadPointRadius { get; set; }

		// Token: 0x170008A8 RID: 2216
		// (get) Token: 0x06001779 RID: 6009
		// (set) Token: 0x0600177A RID: 6010
		double CrossSectionSelectedLoadPointRadius { get; set; }

		// Token: 0x170008A9 RID: 2217
		// (get) Token: 0x0600177B RID: 6011
		// (set) Token: 0x0600177C RID: 6012
		System.Windows.Media.Color CrossSectionInnerLoadPointColor { get; set; }

		// Token: 0x170008AA RID: 2218
		// (get) Token: 0x0600177D RID: 6013
		// (set) Token: 0x0600177E RID: 6014
		System.Windows.Media.Color CrossSectionOuterLoadPointColor { get; set; }

		// Token: 0x170008AB RID: 2219
		// (get) Token: 0x0600177F RID: 6015
		// (set) Token: 0x06001780 RID: 6016
		System.Windows.Media.Color CrossSectionSelectedLoadPointColor { get; set; }

		// Token: 0x170008AC RID: 2220
		// (get) Token: 0x06001781 RID: 6017
		// (set) Token: 0x06001782 RID: 6018
		System.Windows.Media.Color CrossSectionHoverLoadPointColor { get; set; }

		// Token: 0x170008AD RID: 2221
		// (get) Token: 0x06001783 RID: 6019
		// (set) Token: 0x06001784 RID: 6020
		System.Windows.Media.Color AxisValueTextColor { get; set; }

		// Token: 0x170008AE RID: 2222
		// (get) Token: 0x06001785 RID: 6021
		// (set) Token: 0x06001786 RID: 6022
		double AxisValueTextFontSize { get; set; }

		// Token: 0x170008AF RID: 2223
		// (get) Token: 0x06001787 RID: 6023
		// (set) Token: 0x06001788 RID: 6024
		double BoundingBoxLineThickness { get; set; }

		// Token: 0x170008B0 RID: 2224
		// (get) Token: 0x06001789 RID: 6025
		// (set) Token: 0x0600178A RID: 6026
		System.Windows.Media.Color BoundingBoxLineColor { get; set; }

		// Token: 0x170008B1 RID: 2225
		// (get) Token: 0x0600178B RID: 6027
		// (set) Token: 0x0600178C RID: 6028
		System.Windows.Media.Color CutPlaneColor { get; set; }

		// Token: 0x170008B2 RID: 2226
		// (get) Token: 0x0600178D RID: 6029
		// (set) Token: 0x0600178E RID: 6030
		double CutterBorderThickness { get; set; }

		// Token: 0x170008B3 RID: 2227
		// (get) Token: 0x0600178F RID: 6031
		// (set) Token: 0x06001790 RID: 6032
		double BoundingBoxSizeX { get; set; }

		// Token: 0x170008B4 RID: 2228
		// (get) Token: 0x06001791 RID: 6033
		// (set) Token: 0x06001792 RID: 6034
		double BoundingBoxSizeY { get; set; }

		// Token: 0x170008B5 RID: 2229
		// (get) Token: 0x06001793 RID: 6035
		// (set) Token: 0x06001794 RID: 6036
		double BoundingBoxSizeZ { get; set; }

		// Token: 0x170008B6 RID: 2230
		// (get) Token: 0x06001795 RID: 6037
		// (set) Token: 0x06001796 RID: 6038
		double BoundingBoxCenterX { get; set; }

		// Token: 0x170008B7 RID: 2231
		// (get) Token: 0x06001797 RID: 6039
		// (set) Token: 0x06001798 RID: 6040
		double BoundingBoxCenterY { get; set; }

		// Token: 0x170008B8 RID: 2232
		// (get) Token: 0x06001799 RID: 6041
		// (set) Token: 0x0600179A RID: 6042
		double BoundingBoxCenterZ { get; set; }

		// Token: 0x170008B9 RID: 2233
		// (get) Token: 0x0600179B RID: 6043
		// (set) Token: 0x0600179C RID: 6044
		double BoundingBoxSphereRadius { get; set; }

		// Token: 0x170008BA RID: 2234
		// (get) Token: 0x0600179D RID: 6045
		// (set) Token: 0x0600179E RID: 6046
		System.Windows.Media.Color MainAxisPlaneXYColor { get; set; }

		// Token: 0x170008BB RID: 2235
		// (get) Token: 0x0600179F RID: 6047
		// (set) Token: 0x060017A0 RID: 6048
		System.Windows.Media.Color MainAxisPlaneYZColor { get; set; }

		// Token: 0x170008BC RID: 2236
		// (get) Token: 0x060017A1 RID: 6049
		// (set) Token: 0x060017A2 RID: 6050
		System.Windows.Media.Color MainAxisPlaneZXColor { get; set; }

		// Token: 0x170008BD RID: 2237
		// (get) Token: 0x060017A3 RID: 6051
		// (set) Token: 0x060017A4 RID: 6052
		System.Windows.Media.Color MainAxisXColor { get; set; }

		// Token: 0x170008BE RID: 2238
		// (get) Token: 0x060017A5 RID: 6053
		// (set) Token: 0x060017A6 RID: 6054
		System.Windows.Media.Color MainAxisYColor { get; set; }

		// Token: 0x170008BF RID: 2239
		// (get) Token: 0x060017A7 RID: 6055
		// (set) Token: 0x060017A8 RID: 6056
		System.Windows.Media.Color MainAxisZColor { get; set; }

		// Token: 0x170008C0 RID: 2240
		// (get) Token: 0x060017A9 RID: 6057
		// (set) Token: 0x060017AA RID: 6058
		System.Windows.Media.Color CoordinateSystemColor { get; set; }

		// Token: 0x170008C1 RID: 2241
		// (get) Token: 0x060017AB RID: 6059
		// (set) Token: 0x060017AC RID: 6060
		double MainAxisXLength { get; set; }

		// Token: 0x170008C2 RID: 2242
		// (get) Token: 0x060017AD RID: 6061
		// (set) Token: 0x060017AE RID: 6062
		double MainAxisYLength { get; set; }

		// Token: 0x170008C3 RID: 2243
		// (get) Token: 0x060017AF RID: 6063
		// (set) Token: 0x060017B0 RID: 6064
		double MainAxisZLength { get; set; }

		// Token: 0x170008C4 RID: 2244
		// (get) Token: 0x060017B1 RID: 6065
		// (set) Token: 0x060017B2 RID: 6066
		double MainAxisArrowRadius { get; set; }

		// Token: 0x170008C5 RID: 2245
		// (get) Token: 0x060017B3 RID: 6067
		// (set) Token: 0x060017B4 RID: 6068
		double MainAxisRadius { get; set; }

		// Token: 0x170008C6 RID: 2246
		// (get) Token: 0x060017B5 RID: 6069
		// (set) Token: 0x060017B6 RID: 6070
		CameraType CameraType { get; set; }

		// Token: 0x170008C7 RID: 2247
		// (get) Token: 0x060017B7 RID: 6071
		// (set) Token: 0x060017B8 RID: 6072
		bool IsCoordinateSystemVisible { get; set; }

		// Token: 0x170008C8 RID: 2248
		// (get) Token: 0x060017B9 RID: 6073
		// (set) Token: 0x060017BA RID: 6074
		bool Show3dRotationCube { get; set; }

		// Token: 0x170008C9 RID: 2249
		// (get) Token: 0x060017BB RID: 6075
		// (set) Token: 0x060017BC RID: 6076
		bool AreMainAxesVisible { get; set; }

		// Token: 0x170008CA RID: 2250
		// (get) Token: 0x060017BD RID: 6077
		// (set) Token: 0x060017BE RID: 6078
		bool Diagram3DIsMxMyPlaneVisible { get; set; }

		// Token: 0x170008CB RID: 2251
		// (get) Token: 0x060017BF RID: 6079
		// (set) Token: 0x060017C0 RID: 6080
		bool Diagram3DIsMyPPlaneVisible { get; set; }

		// Token: 0x170008CC RID: 2252
		// (get) Token: 0x060017C1 RID: 6081
		// (set) Token: 0x060017C2 RID: 6082
		bool Diagram3DIsPMxPlaneVisible { get; set; }

		// Token: 0x170008CD RID: 2253
		// (get) Token: 0x060017C3 RID: 6083
		// (set) Token: 0x060017C4 RID: 6084
		bool Diagram3DAreLoadPointsVisible { get; set; }

		// Token: 0x170008CE RID: 2254
		// (get) Token: 0x060017C5 RID: 6085
		// (set) Token: 0x060017C6 RID: 6086
		bool IsPointerVisible { get; set; }

		// Token: 0x170008CF RID: 2255
		// (get) Token: 0x060017C7 RID: 6087
		// (set) Token: 0x060017C8 RID: 6088
		bool ViewControlsPanelVisible { get; set; }

		// Token: 0x170008D0 RID: 2256
		// (get) Token: 0x060017C9 RID: 6089
		// (set) Token: 0x060017CA RID: 6090
		string ManualFileName { get; set; }

		// Token: 0x170008D1 RID: 2257
		// (get) Token: 0x060017CB RID: 6091
		// (set) Token: 0x060017CC RID: 6092
		string ManualSubdirectory { get; set; }

		// Token: 0x170008D2 RID: 2258
		// (get) Token: 0x060017CD RID: 6093
		// (set) Token: 0x060017CE RID: 6094
		string ManualWebUrlBaseAddress { get; set; }

		// Token: 0x170008D3 RID: 2259
		// (get) Token: 0x060017CF RID: 6095
		// (set) Token: 0x060017D0 RID: 6096
		bool ShowNominal { get; set; }

		// Token: 0x170008D4 RID: 2260
		// (get) Token: 0x060017D1 RID: 6097
		// (set) Token: 0x060017D2 RID: 6098
		bool ShowFactored { get; set; }

		// Token: 0x170008D5 RID: 2261
		// (get) Token: 0x060017D3 RID: 6099
		bool ShowNominalOrFactored { get; }

		// Token: 0x170008D6 RID: 2262
		// (get) Token: 0x060017D4 RID: 6100
		// (set) Token: 0x060017D5 RID: 6101
		bool ShowCoordinateSystemSign { get; set; }

		// Token: 0x170008D7 RID: 2263
		// (get) Token: 0x060017D6 RID: 6102
		// (set) Token: 0x060017D7 RID: 6103
		bool ObjectCentroid { get; set; }

		// Token: 0x170008D8 RID: 2264
		// (get) Token: 0x060017D8 RID: 6104
		// (set) Token: 0x060017D9 RID: 6105
		double MergingZone { get; set; }

		// Token: 0x170008D9 RID: 2265
		// (get) Token: 0x060017DA RID: 6106
		// (set) Token: 0x060017DB RID: 6107
		System.Drawing.Color ToolHelperColor { get; set; }

		// Token: 0x170008DA RID: 2266
		// (get) Token: 0x060017DC RID: 6108
		// (set) Token: 0x060017DD RID: 6109
		System.Drawing.Color ToolIdleColor { get; set; }

		// Token: 0x170008DB RID: 2267
		// (get) Token: 0x060017DE RID: 6110
		double MoveIndicatorSize { get; }

		// Token: 0x170008DC RID: 2268
		// (get) Token: 0x060017DF RID: 6111
		double MoveIndicatorStroke { get; }

		// Token: 0x170008DD RID: 2269
		// (get) Token: 0x060017E0 RID: 6112
		// (set) Token: 0x060017E1 RID: 6113
		bool OrthoEnabled { get; set; }

		// Token: 0x170008DE RID: 2270
		// (get) Token: 0x060017E2 RID: 6114
		// (set) Token: 0x060017E3 RID: 6115
		#z7 SnappingSettings { get; set; }

		// Token: 0x170008DF RID: 2271
		// (get) Token: 0x060017E4 RID: 6116
		// (set) Token: 0x060017E5 RID: 6117
		#j7 DrawingGrid { get; set; }

		// Token: 0x170008E0 RID: 2272
		// (get) Token: 0x060017E6 RID: 6118
		// (set) Token: 0x060017E7 RID: 6119
		#n7 DynamicInput { get; set; }

		// Token: 0x170008E1 RID: 2273
		// (get) Token: 0x060017E8 RID: 6120
		// (set) Token: 0x060017E9 RID: 6121
		#H7 StatusBar { get; set; }

		// Token: 0x170008E2 RID: 2274
		// (get) Token: 0x060017EA RID: 6122
		#qRb CurrentColorSettings { get; }

		// Token: 0x170008E3 RID: 2275
		// (get) Token: 0x060017EB RID: 6123
		#2Qb CurrentGeneralOptions { get; }

		// Token: 0x170008E4 RID: 2276
		// (get) Token: 0x060017EC RID: 6124
		// (set) Token: 0x060017ED RID: 6125
		double LeftPanelWidth { get; set; }

		// Token: 0x170008E5 RID: 2277
		// (get) Token: 0x060017EE RID: 6126
		// (set) Token: 0x060017EF RID: 6127
		BatchProcessorSettings BatchProcessorSettings { get; set; }

		// Token: 0x170008E6 RID: 2278
		// (get) Token: 0x060017F0 RID: 6128
		// (set) Token: 0x060017F1 RID: 6129
		string InitialPathForDiagramImportExport { get; set; }

		// Token: 0x170008E7 RID: 2279
		// (get) Token: 0x060017F2 RID: 6130
		string StandardTemplatesPath { get; }

		// Token: 0x170008E8 RID: 2280
		// (get) Token: 0x060017F3 RID: 6131
		string UserDefinedTemplatesPath { get; }

		// Token: 0x170008E9 RID: 2281
		// (get) Token: 0x060017F4 RID: 6132
		// (set) Token: 0x060017F5 RID: 6133
		string LastEtabsImportPath { get; set; }

		// Token: 0x170008EA RID: 2282
		// (get) Token: 0x060017F6 RID: 6134
		EdgeMode RenderOptionsEdgeMode { get; }

		// Token: 0x170008EB RID: 2283
		// (get) Token: 0x060017F7 RID: 6135
		// (set) Token: 0x060017F8 RID: 6136
		int MinNoOfCircleSegments { get; set; }

		// Token: 0x170008EC RID: 2284
		// (get) Token: 0x060017F9 RID: 6137
		int CmdBatchNumberOfThreads { get; }

		// Token: 0x170008ED RID: 2285
		// (get) Token: 0x060017FA RID: 6138
		float DiagramInterpolationConvergenceEpsilonPercentage { get; }

		// Token: 0x060017FB RID: 6139
		#2Qb #XN();

		// Token: 0x060017FC RID: 6140
		void #YN(#2Qb #ng);

		// Token: 0x060017FD RID: 6141
		#qRb #ZN();

		// Token: 0x060017FE RID: 6142
		void #0N(#qRb #ng);
	}
}
