using System;
using System.Collections.Generic;
using System.ComponentModel;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Diagrams.DTO;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;

namespace #S9
{
	// Token: 0x020003C9 RID: 969
	internal interface #tbb : INotifyPropertyChanged
	{
		// Token: 0x17000BAB RID: 2987
		// (get) Token: 0x06002167 RID: 8551
		// (set) Token: 0x06002168 RID: 8552
		bool IsDiagram3DIsVerticalShowPlaneEnabled { get; set; }

		// Token: 0x17000BAC RID: 2988
		// (get) Token: 0x06002169 RID: 8553
		// (set) Token: 0x0600216A RID: 8554
		bool IsDiagram3DIsVerticalCutEnabled { get; set; }

		// Token: 0x17000BAD RID: 2989
		// (get) Token: 0x0600216B RID: 8555
		// (set) Token: 0x0600216C RID: 8556
		bool IsDiagram3DIsVerticalFlipEnabled { get; set; }

		// Token: 0x17000BAE RID: 2990
		// (get) Token: 0x0600216D RID: 8557
		// (set) Token: 0x0600216E RID: 8558
		bool IsDiagram3DIsHorizontalShowPlaneEnabled { get; set; }

		// Token: 0x17000BAF RID: 2991
		// (get) Token: 0x0600216F RID: 8559
		// (set) Token: 0x06002170 RID: 8560
		bool IsDiagram3DIsHorizontalCutEnabled { get; set; }

		// Token: 0x17000BB0 RID: 2992
		// (get) Token: 0x06002171 RID: 8561
		// (set) Token: 0x06002172 RID: 8562
		bool IsDiagram3DIsHorizontalFlipEnabled { get; set; }

		// Token: 0x17000BB1 RID: 2993
		// (get) Token: 0x06002173 RID: 8563
		// (set) Token: 0x06002174 RID: 8564
		bool IsBiaxialActive { get; set; }

		// Token: 0x17000BB2 RID: 2994
		// (get) Token: 0x06002175 RID: 8565
		// (set) Token: 0x06002176 RID: 8566
		bool IsReportSourceValid { get; set; }

		// Token: 0x17000BB3 RID: 2995
		// (get) Token: 0x06002177 RID: 8567
		// (set) Token: 0x06002178 RID: 8568
		bool IsDiagramMMChecked { get; set; }

		// Token: 0x17000BB4 RID: 2996
		// (get) Token: 0x06002179 RID: 8569
		// (set) Token: 0x0600217A RID: 8570
		bool IsDiagramMMEnabled { get; set; }

		// Token: 0x17000BB5 RID: 2997
		// (get) Token: 0x0600217B RID: 8571
		// (set) Token: 0x0600217C RID: 8572
		bool IsDiagramPMChecked { get; set; }

		// Token: 0x17000BB6 RID: 2998
		// (get) Token: 0x0600217D RID: 8573
		// (set) Token: 0x0600217E RID: 8574
		bool IsDiagramPMEnabled { get; set; }

		// Token: 0x17000BB7 RID: 2999
		// (get) Token: 0x0600217F RID: 8575
		// (set) Token: 0x06002180 RID: 8576
		bool IsDiagramPMPlusChecked { get; set; }

		// Token: 0x17000BB8 RID: 3000
		// (get) Token: 0x06002181 RID: 8577
		// (set) Token: 0x06002182 RID: 8578
		bool IsDiagramPMMinusChecked { get; set; }

		// Token: 0x17000BB9 RID: 3001
		// (get) Token: 0x06002183 RID: 8579
		// (set) Token: 0x06002184 RID: 8580
		bool IsDiagramPMGroupChecked { get; set; }

		// Token: 0x17000BBA RID: 3002
		// (get) Token: 0x06002185 RID: 8581
		// (set) Token: 0x06002186 RID: 8582
		bool IsDiagram3DHorizontalChecked { get; set; }

		// Token: 0x17000BBB RID: 3003
		// (get) Token: 0x06002187 RID: 8583
		// (set) Token: 0x06002188 RID: 8584
		bool IsDiagram3DHorizontalEnabled { get; set; }

		// Token: 0x17000BBC RID: 3004
		// (get) Token: 0x06002189 RID: 8585
		// (set) Token: 0x0600218A RID: 8586
		bool IsDiagram3DVerticalEnabled { get; set; }

		// Token: 0x17000BBD RID: 3005
		// (get) Token: 0x0600218B RID: 8587
		// (set) Token: 0x0600218C RID: 8588
		bool IsDiagram3DVerticalChecked { get; set; }

		// Token: 0x17000BBE RID: 3006
		// (get) Token: 0x0600218D RID: 8589
		// (set) Token: 0x0600218E RID: 8590
		bool IsDiagram3DFlipCommandEnabled { get; set; }

		// Token: 0x17000BBF RID: 3007
		// (get) Token: 0x0600218F RID: 8591
		// (set) Token: 0x06002190 RID: 8592
		bool IsExportDiagramCommandEnabled { get; set; }

		// Token: 0x17000BC0 RID: 3008
		// (get) Token: 0x06002191 RID: 8593
		// (set) Token: 0x06002192 RID: 8594
		bool IsChangeCutTypeCommandEnabled { get; set; }

		// Token: 0x17000BC1 RID: 3009
		// (get) Token: 0x06002193 RID: 8595
		// (set) Token: 0x06002194 RID: 8596
		bool IsChangeDiagram2DTypeCommandEnabled { get; set; }

		// Token: 0x17000BC2 RID: 3010
		// (get) Token: 0x06002195 RID: 8597
		// (set) Token: 0x06002196 RID: 8598
		bool IsCutCommandEnabled { get; set; }

		// Token: 0x17000BC3 RID: 3011
		// (get) Token: 0x06002197 RID: 8599
		// (set) Token: 0x06002198 RID: 8600
		bool IsChangePresenterTypeCommandEnabled { get; set; }

		// Token: 0x17000BC4 RID: 3012
		// (get) Token: 0x06002199 RID: 8601
		// (set) Token: 0x0600219A RID: 8602
		bool IsChangeViewControlsVisibilityCommandEnabled { get; set; }

		// Token: 0x17000BC5 RID: 3013
		// (get) Token: 0x0600219B RID: 8603
		// (set) Token: 0x0600219C RID: 8604
		bool IsShowPlaneCommandEnabled { get; set; }

		// Token: 0x17000BC6 RID: 3014
		// (get) Token: 0x0600219D RID: 8605
		// (set) Token: 0x0600219E RID: 8606
		bool IsActivateDiagramCommandEnabled { get; set; }

		// Token: 0x17000BC7 RID: 3015
		// (get) Token: 0x0600219F RID: 8607
		// (set) Token: 0x060021A0 RID: 8608
		double CurrentAxialLoad { get; set; }

		// Token: 0x17000BC8 RID: 3016
		// (get) Token: 0x060021A1 RID: 8609
		// (set) Token: 0x060021A2 RID: 8610
		double CurrentAngle { get; set; }

		// Token: 0x17000BC9 RID: 3017
		// (get) Token: 0x060021A3 RID: 8611
		// (set) Token: 0x060021A4 RID: 8612
		bool IsLoadingData { get; set; }

		// Token: 0x17000BCA RID: 3018
		// (get) Token: 0x060021A5 RID: 8613
		List<SelectedLoadData> SelectedLoads { get; }

		// Token: 0x17000BCB RID: 3019
		// (get) Token: 0x060021A6 RID: 8614
		List<Diagram2DType> OpenedDiagramTypes { get; }

		// Token: 0x060021A7 RID: 8615
		void #Q9();
	}
}
