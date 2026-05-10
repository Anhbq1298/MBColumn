using System;
using #7hc;
using #m6c;
using StructurePoint.CoreAssets.GUI.DesktopControls;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #Cqb
{
	// Token: 0x0200046D RID: 1133
	internal sealed class #arb : #w6c<#arb>
	{
		// Token: 0x060029B2 RID: 10674 RVA: 0x000260BC File Offset: 0x000242BC
		private #arb() : base(Component.FailureSurfaceVisualization)
		{
		}

		// Token: 0x17000E3B RID: 3643
		// (get) Token: 0x060029B3 RID: 10675 RVA: 0x000260C6 File Offset: 0x000242C6
		public static HelpID ToolPointer
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107360064));
			}
		}

		// Token: 0x17000E3C RID: 3644
		// (get) Token: 0x060029B4 RID: 10676 RVA: 0x000260DF File Offset: 0x000242DF
		public static HelpID ToolCreateVerticalCrossSection
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107360047));
			}
		}

		// Token: 0x17000E3D RID: 3645
		// (get) Token: 0x060029B5 RID: 10677 RVA: 0x000260F8 File Offset: 0x000242F8
		public static HelpID ToolCreateHorizontalCrossSection
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107360006));
			}
		}

		// Token: 0x17000E3E RID: 3646
		// (get) Token: 0x060029B6 RID: 10678 RVA: 0x00026111 File Offset: 0x00024311
		public static HelpID Toolbox
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107359481));
			}
		}

		// Token: 0x17000E3F RID: 3647
		// (get) Token: 0x060029B7 RID: 10679 RVA: 0x0002612A File Offset: 0x0002432A
		public static HelpID MainMenu
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107359436));
			}
		}

		// Token: 0x17000E40 RID: 3648
		// (get) Token: 0x060029B8 RID: 10680 RVA: 0x00026143 File Offset: 0x00024343
		public static HelpID MainVisualization
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107359455));
			}
		}

		// Token: 0x17000E41 RID: 3649
		// (get) Token: 0x060029B9 RID: 10681 RVA: 0x0002615C File Offset: 0x0002435C
		public static HelpID OptionsWindow
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107359398));
			}
		}

		// Token: 0x17000E42 RID: 3650
		// (get) Token: 0x060029BA RID: 10682 RVA: 0x00026175 File Offset: 0x00024375
		public static HelpID OptionsSurfaces
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107359409));
			}
		}

		// Token: 0x17000E43 RID: 3651
		// (get) Token: 0x060029BB RID: 10683 RVA: 0x0002618E File Offset: 0x0002438E
		public static HelpID OptionsAxes
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107359388));
			}
		}

		// Token: 0x17000E44 RID: 3652
		// (get) Token: 0x060029BC RID: 10684 RVA: 0x000261A7 File Offset: 0x000243A7
		public static HelpID CoordinateSystem
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107359339));
			}
		}

		// Token: 0x17000E45 RID: 3653
		// (get) Token: 0x060029BD RID: 10685 RVA: 0x000261C0 File Offset: 0x000243C0
		public static HelpID OptionsMainAxesPlanes
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107359346));
			}
		}

		// Token: 0x17000E46 RID: 3654
		// (get) Token: 0x060029BE RID: 10686 RVA: 0x000261D9 File Offset: 0x000243D9
		public static HelpID CutterPlane
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107359317));
			}
		}

		// Token: 0x17000E47 RID: 3655
		// (get) Token: 0x060029BF RID: 10687 RVA: 0x000261F2 File Offset: 0x000243F2
		public static HelpID OptionsLoadPoints
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107359268));
			}
		}

		// Token: 0x17000E48 RID: 3656
		// (get) Token: 0x060029C0 RID: 10688 RVA: 0x0002620B File Offset: 0x0002440B
		public static HelpID OptionsCamera
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107359243));
			}
		}

		// Token: 0x17000E49 RID: 3657
		// (get) Token: 0x060029C1 RID: 10689 RVA: 0x00026224 File Offset: 0x00024424
		public static HelpID OptionsReset
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107359254));
			}
		}

		// Token: 0x17000E4A RID: 3658
		// (get) Token: 0x060029C2 RID: 10690 RVA: 0x0002623D File Offset: 0x0002443D
		public static HelpID MenuFile
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107359717));
			}
		}

		// Token: 0x17000E4B RID: 3659
		// (get) Token: 0x060029C3 RID: 10691 RVA: 0x00026256 File Offset: 0x00024456
		public static HelpID MenuView
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107359736));
			}
		}

		// Token: 0x17000E4C RID: 3660
		// (get) Token: 0x060029C4 RID: 10692 RVA: 0x0002626F File Offset: 0x0002446F
		public static HelpID MenuHelp
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107359691));
			}
		}

		// Token: 0x17000E4D RID: 3661
		// (get) Token: 0x060029C5 RID: 10693 RVA: 0x00026288 File Offset: 0x00024488
		public static HelpID MenuFileOptions
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107359710));
			}
		}

		// Token: 0x17000E4E RID: 3662
		// (get) Token: 0x060029C6 RID: 10694 RVA: 0x000262A1 File Offset: 0x000244A1
		public static HelpID MenuFileExportAsImage
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107359657));
			}
		}

		// Token: 0x17000E4F RID: 3663
		// (get) Token: 0x060029C7 RID: 10695 RVA: 0x000262BA File Offset: 0x000244BA
		public static HelpID MenuFileExit
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107359628));
			}
		}

		// Token: 0x17000E50 RID: 3664
		// (get) Token: 0x060029C8 RID: 10696 RVA: 0x000262D3 File Offset: 0x000244D3
		public static HelpID MenuViewFactoredSurface
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107359643));
			}
		}

		// Token: 0x17000E51 RID: 3665
		// (get) Token: 0x060029C9 RID: 10697 RVA: 0x000262EC File Offset: 0x000244EC
		public static HelpID MenuViewNominalSurface
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107359610));
			}
		}

		// Token: 0x17000E52 RID: 3666
		// (get) Token: 0x060029CA RID: 10698 RVA: 0x00026305 File Offset: 0x00024505
		public static HelpID MenuViewMxMyPlane
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107359577));
			}
		}

		// Token: 0x17000E53 RID: 3667
		// (get) Token: 0x060029CB RID: 10699 RVA: 0x0002631E File Offset: 0x0002451E
		public static HelpID MenuViewMyPPlane
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107359520));
			}
		}

		// Token: 0x17000E54 RID: 3668
		// (get) Token: 0x060029CC RID: 10700 RVA: 0x00026337 File Offset: 0x00024537
		public static HelpID MenuViewPMxPlane
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107359495));
			}
		}

		// Token: 0x17000E55 RID: 3669
		// (get) Token: 0x060029CD RID: 10701 RVA: 0x00026350 File Offset: 0x00024550
		public static HelpID MenuViewMainAxes
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107358958));
			}
		}

		// Token: 0x17000E56 RID: 3670
		// (get) Token: 0x060029CE RID: 10702 RVA: 0x00026369 File Offset: 0x00024569
		public static HelpID MenuViewCoordinateSystem
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107358965));
			}
		}

		// Token: 0x17000E57 RID: 3671
		// (get) Token: 0x060029CF RID: 10703 RVA: 0x00026382 File Offset: 0x00024582
		public static HelpID MenuViewLoadPoints
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107358932));
			}
		}

		// Token: 0x17000E58 RID: 3672
		// (get) Token: 0x060029D0 RID: 10704 RVA: 0x0002639B File Offset: 0x0002459B
		public static HelpID MenuHelpFailureSurfaceVisualizationHelp
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107358907));
			}
		}

		// Token: 0x17000E59 RID: 3673
		// (get) Token: 0x060029D1 RID: 10705 RVA: 0x000263B4 File Offset: 0x000245B4
		public static HelpID MenuHelpColumnManual
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107358822));
			}
		}

		// Token: 0x17000E5A RID: 3674
		// (get) Token: 0x060029D2 RID: 10706 RVA: 0x000263CD File Offset: 0x000245CD
		public static HelpID MenuHelpAbout
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107358793));
			}
		}

		// Token: 0x17000E5B RID: 3675
		// (get) Token: 0x060029D3 RID: 10707 RVA: 0x000263E6 File Offset: 0x000245E6
		public static HelpID MenuViewEditorTools
		{
			get
			{
				return #w6c<#arb>.#s6c(#Phc.#3hc(107358804));
			}
		}
	}
}
