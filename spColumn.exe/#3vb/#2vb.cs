using System;
using #iTc;
using StructurePoint.CoreAssets.GUI.DesktopControls;

namespace #3vb
{
	// Token: 0x0200046B RID: 1131
	internal interface #2vb : #hTc
	{
		// Token: 0x17000E17 RID: 3607
		// (get) Token: 0x0600298E RID: 10638
		ICommandFactory CommandFactory { get; }

		// Token: 0x17000E18 RID: 3608
		// (get) Token: 0x0600298F RID: 10639
		IDelegateCommandProxy ShowOptionsEditorCommand { get; }

		// Token: 0x17000E19 RID: 3609
		// (get) Token: 0x06002990 RID: 10640
		IDelegateCommandProxy ShowHideFactoredSurfaceCommand { get; }

		// Token: 0x17000E1A RID: 3610
		// (get) Token: 0x06002991 RID: 10641
		IDelegateCommandProxy HideFactoredSurfaceCommand { get; }

		// Token: 0x17000E1B RID: 3611
		// (get) Token: 0x06002992 RID: 10642
		IDelegateCommandProxy ShowHideNominalSurfaceCommand { get; }

		// Token: 0x17000E1C RID: 3612
		// (get) Token: 0x06002993 RID: 10643
		IDelegateCommandProxy HideNominalSurfaceCommand { get; }

		// Token: 0x17000E1D RID: 3613
		// (get) Token: 0x06002994 RID: 10644
		IDelegateCommandProxy ShowHideMxMyPlaneCommand { get; }

		// Token: 0x17000E1E RID: 3614
		// (get) Token: 0x06002995 RID: 10645
		IDelegateCommandProxy ShowHideMyPPlaneCommand { get; }

		// Token: 0x17000E1F RID: 3615
		// (get) Token: 0x06002996 RID: 10646
		IDelegateCommandProxy ShowHidePMxPlaneCommand { get; }

		// Token: 0x17000E20 RID: 3616
		// (get) Token: 0x06002997 RID: 10647
		IDelegateCommandProxy ShowHideMainAxesCommand { get; }

		// Token: 0x17000E21 RID: 3617
		// (get) Token: 0x06002998 RID: 10648
		IDelegateCommandProxy ShowHideCoordinateSystemCommand { get; }

		// Token: 0x17000E22 RID: 3618
		// (get) Token: 0x06002999 RID: 10649
		IDelegateCommandProxy CloseCommand { get; }

		// Token: 0x17000E23 RID: 3619
		// (get) Token: 0x0600299A RID: 10650
		IDelegateCommandProxy ShowCrossSectionCommand { get; }

		// Token: 0x17000E24 RID: 3620
		// (get) Token: 0x0600299B RID: 10651
		IDelegateCommandProxy ShowBaseVisualizationCommand { get; }

		// Token: 0x17000E25 RID: 3621
		// (get) Token: 0x0600299C RID: 10652
		IDelegateCommandProxy RemoveSurfacesFromVisualizationCommand { get; }

		// Token: 0x17000E26 RID: 3622
		// (get) Token: 0x0600299D RID: 10653
		IDelegateCommandProxy ExportAsImageCommand { get; }

		// Token: 0x17000E27 RID: 3623
		// (get) Token: 0x0600299E RID: 10654
		IDelegateCommandProxy ResetSelectedToolToDefaultCommand { get; }

		// Token: 0x17000E28 RID: 3624
		// (get) Token: 0x0600299F RID: 10655
		IDelegateCommandProxy ShowHideLoadPointsCommand { get; }

		// Token: 0x17000E29 RID: 3625
		// (get) Token: 0x060029A0 RID: 10656
		IDelegateCommandProxy OpenSectionHelpCommand { get; }

		// Token: 0x17000E2A RID: 3626
		// (get) Token: 0x060029A1 RID: 10657
		IDelegateCommandProxy OpenColumnManualCommand { get; }

		// Token: 0x17000E2B RID: 3627
		// (get) Token: 0x060029A2 RID: 10658
		IDelegateCommandProxy OpenAboutCommand { get; }

		// Token: 0x17000E2C RID: 3628
		// (get) Token: 0x060029A3 RID: 10659
		IDelegateCommandProxy ShowHideEditorToolsCommand { get; }

		// Token: 0x17000E2D RID: 3629
		// (get) Token: 0x060029A4 RID: 10660
		IDelegateCommandProxy RefreshVisibilityCommand { get; }

		// Token: 0x17000E2E RID: 3630
		// (get) Token: 0x060029A5 RID: 10661
		IDelegateCommandProxy UpdateHorizontalCutterColorCommand { get; }

		// Token: 0x17000E2F RID: 3631
		// (get) Token: 0x060029A6 RID: 10662
		IDelegateCommandProxy UpdateVerticalCutterColorCommand { get; }

		// Token: 0x17000E30 RID: 3632
		// (get) Token: 0x060029A7 RID: 10663
		IDelegateCommandProxy ShowHideStatusBarCommand { get; }

		// Token: 0x17000E31 RID: 3633
		// (get) Token: 0x060029A8 RID: 10664
		IDelegateCommandProxy CancelCurrentToolCommand { get; }

		// Token: 0x17000E32 RID: 3634
		// (get) Token: 0x060029A9 RID: 10665
		IDelegateCommandProxy DeactivateCurrentToolCommand { get; }

		// Token: 0x17000E33 RID: 3635
		// (get) Token: 0x060029AA RID: 10666
		IDelegateCommandProxy LoadPointerTool { get; }

		// Token: 0x17000E34 RID: 3636
		// (get) Token: 0x060029AB RID: 10667
		IDelegateCommandProxy RefreshRibbonToolbar { get; }

		// Token: 0x17000E35 RID: 3637
		// (get) Token: 0x060029AC RID: 10668
		IDelegateCommandProxy ShowHidePointerCommand { get; }

		// Token: 0x17000E36 RID: 3638
		// (get) Token: 0x060029AD RID: 10669
		IDelegateCommandProxy EnablePointerTool { get; }

		// Token: 0x17000E37 RID: 3639
		// (get) Token: 0x060029AE RID: 10670
		IDelegateCommandProxy DisablePointerTool { get; }
	}
}
