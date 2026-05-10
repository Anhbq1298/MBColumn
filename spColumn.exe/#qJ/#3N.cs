using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using #3Qb;
using #45d;
using #6re;
using #7hc;
using #eU;
using #ezc;
using #f7;
using #hR;
using #wQb;
using Alphaleonis.Win32.Filesystem;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Settings;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.DesktopControls.RibbonToolbar;
using StructurePoint.CoreAssets.GUI.Framework;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.Core.Application.Misc;
using StructurePoint.Products.Column.Services.API;

namespace #qJ
{
	// Token: 0x020002AF RID: 687
	internal sealed class #3N : SettingsManagerBase, INotifyPropertyChanged, ISettingsManager
	{
		// Token: 0x060016A2 RID: 5794 RVA: 0x000B4EEC File Offset: 0x000B30EC
		public #3N(ILogger #3x, #55d #rJ, #55d #sJ, #yse #Pt) : base(#3x, #rJ, #sJ)
		{
			this.#a = #Pt;
		}

		// Token: 0x17000839 RID: 2105
		// (get) Token: 0x060016A3 RID: 5795 RVA: 0x000172FE File Offset: 0x000154FE
		public #tU RuntimeSettings { get; }

		// Token: 0x1700083A RID: 2106
		// (get) Token: 0x060016A4 RID: 5796 RVA: 0x0001730A File Offset: 0x0001550A
		// (set) Token: 0x060016A5 RID: 5797 RVA: 0x0001732D File Offset: 0x0001552D
		public List<string> RecentProjects
		{
			get
			{
				return base.#dBc<string>(new List<string>(), #Phc.#3hc(107405206));
			}
			set
			{
				base.#cBc<string>(value, #Phc.#3hc(107405206));
			}
		}

		// Token: 0x1700083B RID: 2107
		// (get) Token: 0x060016A6 RID: 5798 RVA: 0x0001734C File Offset: 0x0001554C
		// (set) Token: 0x060016A7 RID: 5799 RVA: 0x0001736F File Offset: 0x0001556F
		public DesignCodes StartupDefaultDesignCode
		{
			get
			{
				return base.#YAc<DesignCodes>(#VQb.#b, #Phc.#3hc(107405153));
			}
			set
			{
				base.#XAc<DesignCodes>(value, #Phc.#3hc(107405153));
			}
		}

		// Token: 0x1700083C RID: 2108
		// (get) Token: 0x060016A8 RID: 5800 RVA: 0x0001738E File Offset: 0x0001558E
		// (set) Token: 0x060016A9 RID: 5801 RVA: 0x000173B1 File Offset: 0x000155B1
		public UnitSystem StartupDefaultUnitSystem
		{
			get
			{
				return base.#YAc<UnitSystem>(#VQb.#c, #Phc.#3hc(107405120));
			}
			set
			{
				base.#XAc<UnitSystem>(value, #Phc.#3hc(107405120));
			}
		}

		// Token: 0x1700083D RID: 2109
		// (get) Token: 0x060016AA RID: 5802 RVA: 0x000173D0 File Offset: 0x000155D0
		// (set) Token: 0x060016AB RID: 5803 RVA: 0x000173F3 File Offset: 0x000155F3
		public BarGroupType StartupDefaultBarGroupType
		{
			get
			{
				return base.#YAc<BarGroupType>(#VQb.#d, #Phc.#3hc(107405119));
			}
			set
			{
				base.#XAc<BarGroupType>(value, #Phc.#3hc(107405119));
			}
		}

		// Token: 0x1700083E RID: 2110
		// (get) Token: 0x060016AC RID: 5804 RVA: 0x00017412 File Offset: 0x00015612
		// (set) Token: 0x060016AD RID: 5805 RVA: 0x00017435 File Offset: 0x00015635
		public SectionCapacityMethodType StartupDefaultSectionCapacity
		{
			get
			{
				return base.#YAc<SectionCapacityMethodType>(#VQb.#e, #Phc.#3hc(107405082));
			}
			set
			{
				base.#XAc<SectionCapacityMethodType>(value, #Phc.#3hc(107405082));
			}
		}

		// Token: 0x1700083F RID: 2111
		// (get) Token: 0x060016AE RID: 5806 RVA: 0x00017454 File Offset: 0x00015654
		// (set) Token: 0x060016AF RID: 5807 RVA: 0x00017477 File Offset: 0x00015677
		public bool IsLeftPanelOpened
		{
			get
			{
				return base.#1Ac(#VQb.#f, #Phc.#3hc(107404529));
			}
			set
			{
				base.#0Ac(value, #Phc.#3hc(107404529));
			}
		}

		// Token: 0x17000840 RID: 2112
		// (get) Token: 0x060016B0 RID: 5808 RVA: 0x00017496 File Offset: 0x00015696
		// (set) Token: 0x060016B1 RID: 5809 RVA: 0x000174B9 File Offset: 0x000156B9
		public ViewControlsSettings ViewControlSettings
		{
			get
			{
				return base.#8Ac<ViewControlsSettings>(ViewControlsSettings.Default, #Phc.#3hc(107404504));
			}
			set
			{
				base.#7Ac<ViewControlsSettings>(value, #Phc.#3hc(107404504));
			}
		}

		// Token: 0x17000841 RID: 2113
		// (get) Token: 0x060016B2 RID: 5810 RVA: 0x000174D8 File Offset: 0x000156D8
		// (set) Token: 0x060016B3 RID: 5811 RVA: 0x000174F7 File Offset: 0x000156F7
		public RibbonToolbarType RibbonToolbarType
		{
			get
			{
				return base.#YAc<RibbonToolbarType>(RibbonToolbarType.LargeHorizontal, #Phc.#3hc(107404475));
			}
			set
			{
				base.#XAc<RibbonToolbarType>(value, #Phc.#3hc(107404475));
			}
		}

		// Token: 0x17000842 RID: 2114
		// (get) Token: 0x060016B4 RID: 5812 RVA: 0x00017516 File Offset: 0x00015716
		// (set) Token: 0x060016B5 RID: 5813 RVA: 0x0001753D File Offset: 0x0001573D
		public double CrossSectionInnerLoadPointRadius
		{
			get
			{
				return base.#4Ac(3.0, #Phc.#3hc(107404418));
			}
			set
			{
				base.#5Ac(value, #Phc.#3hc(107404418));
			}
		}

		// Token: 0x17000843 RID: 2115
		// (get) Token: 0x060016B6 RID: 5814 RVA: 0x0001755C File Offset: 0x0001575C
		// (set) Token: 0x060016B7 RID: 5815 RVA: 0x00017583 File Offset: 0x00015783
		public double CrossSectionOuterLoadPointRadius
		{
			get
			{
				return base.#4Ac(3.0, #Phc.#3hc(107404405));
			}
			set
			{
				base.#5Ac(value, #Phc.#3hc(107404405));
			}
		}

		// Token: 0x17000844 RID: 2116
		// (get) Token: 0x060016B8 RID: 5816 RVA: 0x000175A2 File Offset: 0x000157A2
		// (set) Token: 0x060016B9 RID: 5817 RVA: 0x000175C9 File Offset: 0x000157C9
		public double CrossSectionSelectedLoadPointRadius
		{
			get
			{
				return base.#4Ac(3.0, #Phc.#3hc(107404328));
			}
			set
			{
				base.#5Ac(value, #Phc.#3hc(107404328));
			}
		}

		// Token: 0x17000845 RID: 2117
		// (get) Token: 0x060016BA RID: 5818 RVA: 0x000175E8 File Offset: 0x000157E8
		// (set) Token: 0x060016BB RID: 5819 RVA: 0x0001760B File Offset: 0x0001580B
		public System.Windows.Media.Color CrossSectionInnerLoadPointColor
		{
			get
			{
				return base.#aBc(#VQb.#p, #Phc.#3hc(107404311));
			}
			set
			{
				base.#bBc(value, #Phc.#3hc(107404311));
			}
		}

		// Token: 0x17000846 RID: 2118
		// (get) Token: 0x060016BC RID: 5820 RVA: 0x0001762A File Offset: 0x0001582A
		// (set) Token: 0x060016BD RID: 5821 RVA: 0x0001764D File Offset: 0x0001584D
		public System.Windows.Media.Color CrossSectionOuterLoadPointColor
		{
			get
			{
				return base.#aBc(#VQb.#q, #Phc.#3hc(107404746));
			}
			set
			{
				base.#bBc(value, #Phc.#3hc(107404746));
			}
		}

		// Token: 0x17000847 RID: 2119
		// (get) Token: 0x060016BE RID: 5822 RVA: 0x0001766C File Offset: 0x0001586C
		// (set) Token: 0x060016BF RID: 5823 RVA: 0x0001768F File Offset: 0x0001588F
		public System.Windows.Media.Color CrossSectionSelectedLoadPointColor
		{
			get
			{
				return base.#aBc(#VQb.#r, #Phc.#3hc(107404733));
			}
			set
			{
				base.#bBc(value, #Phc.#3hc(107404733));
			}
		}

		// Token: 0x17000848 RID: 2120
		// (get) Token: 0x060016C0 RID: 5824 RVA: 0x000176AE File Offset: 0x000158AE
		// (set) Token: 0x060016C1 RID: 5825 RVA: 0x000176D1 File Offset: 0x000158D1
		public System.Windows.Media.Color CrossSectionHoverLoadPointColor
		{
			get
			{
				return base.#aBc(#VQb.#s, #Phc.#3hc(107404652));
			}
			set
			{
				base.#bBc(value, #Phc.#3hc(107404652));
			}
		}

		// Token: 0x17000849 RID: 2121
		// (get) Token: 0x060016C2 RID: 5826 RVA: 0x000176F0 File Offset: 0x000158F0
		// (set) Token: 0x060016C3 RID: 5827 RVA: 0x00017717 File Offset: 0x00015917
		public double FailureSurfaceNominalWireframeLineThickness
		{
			get
			{
				return base.#4Ac(0.5, #Phc.#3hc(107404639));
			}
			set
			{
				base.#5Ac(value, #Phc.#3hc(107404639));
			}
		}

		// Token: 0x1700084A RID: 2122
		// (get) Token: 0x060016C4 RID: 5828 RVA: 0x00017736 File Offset: 0x00015936
		// (set) Token: 0x060016C5 RID: 5829 RVA: 0x00017759 File Offset: 0x00015959
		public double FailureSurfaceFactoredWireframeLineThickness
		{
			get
			{
				return base.#4Ac(#VQb.#j, #Phc.#3hc(107404546));
			}
			set
			{
				base.#5Ac(value, #Phc.#3hc(107404546));
			}
		}

		// Token: 0x1700084B RID: 2123
		// (get) Token: 0x060016C6 RID: 5830 RVA: 0x00017778 File Offset: 0x00015978
		// (set) Token: 0x060016C7 RID: 5831 RVA: 0x0001779B File Offset: 0x0001599B
		public System.Windows.Media.Color FailureSurfaceNominalWireframeLineColor
		{
			get
			{
				return base.#aBc(#VQb.#k, #Phc.#3hc(107403973));
			}
			set
			{
				base.#bBc(value, #Phc.#3hc(107403973));
			}
		}

		// Token: 0x1700084C RID: 2124
		// (get) Token: 0x060016C8 RID: 5832 RVA: 0x000177BA File Offset: 0x000159BA
		// (set) Token: 0x060016C9 RID: 5833 RVA: 0x000177DD File Offset: 0x000159DD
		public System.Windows.Media.Color FailureSurfaceFactoredWireframeLineColor
		{
			get
			{
				return base.#aBc(#VQb.#l, #Phc.#3hc(107403952));
			}
			set
			{
				base.#bBc(value, #Phc.#3hc(107403952));
			}
		}

		// Token: 0x1700084D RID: 2125
		// (get) Token: 0x060016CA RID: 5834 RVA: 0x000177FC File Offset: 0x000159FC
		// (set) Token: 0x060016CB RID: 5835 RVA: 0x0001781F File Offset: 0x00015A1F
		public System.Windows.Media.Color FailureSurfaceNominalSurfaceColor
		{
			get
			{
				return base.#aBc(#VQb.#h, #Phc.#3hc(107403895));
			}
			set
			{
				base.#bBc(value, #Phc.#3hc(107403895));
			}
		}

		// Token: 0x1700084E RID: 2126
		// (get) Token: 0x060016CC RID: 5836 RVA: 0x0001783E File Offset: 0x00015A3E
		// (set) Token: 0x060016CD RID: 5837 RVA: 0x00017861 File Offset: 0x00015A61
		public System.Windows.Media.Color FailureSurfaceFactoredSurfaceColor
		{
			get
			{
				return base.#aBc(#VQb.#g, #Phc.#3hc(107403818));
			}
			set
			{
				base.#bBc(value, #Phc.#3hc(107403818));
			}
		}

		// Token: 0x1700084F RID: 2127
		// (get) Token: 0x060016CE RID: 5838 RVA: 0x00017880 File Offset: 0x00015A80
		// (set) Token: 0x060016CF RID: 5839 RVA: 0x000178A3 File Offset: 0x00015AA3
		public System.Windows.Media.Color AxisValueTextColor
		{
			get
			{
				return base.#aBc(#VQb.#t, #Phc.#3hc(107403801));
			}
			set
			{
				base.#bBc(value, #Phc.#3hc(107403801));
			}
		}

		// Token: 0x17000850 RID: 2128
		// (get) Token: 0x060016D0 RID: 5840 RVA: 0x000178C2 File Offset: 0x00015AC2
		// (set) Token: 0x060016D1 RID: 5841 RVA: 0x000178E9 File Offset: 0x00015AE9
		public double AxisValueTextFontSize
		{
			get
			{
				return base.#4Ac(2.0, #Phc.#3hc(107404256));
			}
			set
			{
				base.#5Ac(value, #Phc.#3hc(107404256));
			}
		}

		// Token: 0x17000851 RID: 2129
		// (get) Token: 0x060016D2 RID: 5842 RVA: 0x00017908 File Offset: 0x00015B08
		// (set) Token: 0x060016D3 RID: 5843 RVA: 0x0001792F File Offset: 0x00015B2F
		public double BoundingBoxLineThickness
		{
			get
			{
				return base.#4Ac(1.0, #Phc.#3hc(107404227));
			}
			set
			{
				base.#5Ac(value, #Phc.#3hc(107404227));
			}
		}

		// Token: 0x17000852 RID: 2130
		// (get) Token: 0x060016D4 RID: 5844 RVA: 0x0001794E File Offset: 0x00015B4E
		// (set) Token: 0x060016D5 RID: 5845 RVA: 0x00017971 File Offset: 0x00015B71
		public System.Windows.Media.Color BoundingBoxLineColor
		{
			get
			{
				return base.#aBc(#VQb.#w, #Phc.#3hc(107404194));
			}
			set
			{
				base.#bBc(value, #Phc.#3hc(107404194));
			}
		}

		// Token: 0x17000853 RID: 2131
		// (get) Token: 0x060016D6 RID: 5846 RVA: 0x00017990 File Offset: 0x00015B90
		// (set) Token: 0x060016D7 RID: 5847 RVA: 0x000179B3 File Offset: 0x00015BB3
		public System.Windows.Media.Color CutPlaneColor
		{
			get
			{
				return base.#aBc(#VQb.#x, #Phc.#3hc(107404165));
			}
			set
			{
				base.#bBc(value, #Phc.#3hc(107404165));
			}
		}

		// Token: 0x17000854 RID: 2132
		// (get) Token: 0x060016D8 RID: 5848 RVA: 0x000179D2 File Offset: 0x00015BD2
		// (set) Token: 0x060016D9 RID: 5849 RVA: 0x000179F9 File Offset: 0x00015BF9
		public double CutterBorderThickness
		{
			get
			{
				return base.#4Ac(1.0, #Phc.#3hc(107404176));
			}
			set
			{
				base.#5Ac(value, #Phc.#3hc(107404176));
			}
		}

		// Token: 0x17000855 RID: 2133
		// (get) Token: 0x060016DA RID: 5850 RVA: 0x00017A18 File Offset: 0x00015C18
		// (set) Token: 0x060016DB RID: 5851 RVA: 0x00017A3F File Offset: 0x00015C3F
		public double BoundingBoxSizeX
		{
			get
			{
				return base.#4Ac(50.0, #Phc.#3hc(107404147));
			}
			set
			{
				base.#5Ac(value, #Phc.#3hc(107404147));
			}
		}

		// Token: 0x17000856 RID: 2134
		// (get) Token: 0x060016DC RID: 5852 RVA: 0x00017A5E File Offset: 0x00015C5E
		// (set) Token: 0x060016DD RID: 5853 RVA: 0x00017A85 File Offset: 0x00015C85
		public double BoundingBoxSizeY
		{
			get
			{
				return base.#4Ac(50.0, #Phc.#3hc(107404122));
			}
			set
			{
				base.#5Ac(value, #Phc.#3hc(107404122));
			}
		}

		// Token: 0x17000857 RID: 2135
		// (get) Token: 0x060016DE RID: 5854 RVA: 0x00017AA4 File Offset: 0x00015CA4
		// (set) Token: 0x060016DF RID: 5855 RVA: 0x00017ACB File Offset: 0x00015CCB
		public double BoundingBoxSizeZ
		{
			get
			{
				return base.#4Ac(100.0, #Phc.#3hc(107404065));
			}
			set
			{
				base.#5Ac(value, #Phc.#3hc(107404065));
			}
		}

		// Token: 0x17000858 RID: 2136
		// (get) Token: 0x060016E0 RID: 5856 RVA: 0x00017AEA File Offset: 0x00015CEA
		// (set) Token: 0x060016E1 RID: 5857 RVA: 0x00017B11 File Offset: 0x00015D11
		public double BoundingBoxCenterX
		{
			get
			{
				return base.#4Ac(0.0, #Phc.#3hc(107404040));
			}
			set
			{
				base.#5Ac(value, #Phc.#3hc(107404040));
			}
		}

		// Token: 0x17000859 RID: 2137
		// (get) Token: 0x060016E2 RID: 5858 RVA: 0x00017B30 File Offset: 0x00015D30
		// (set) Token: 0x060016E3 RID: 5859 RVA: 0x00017B57 File Offset: 0x00015D57
		public double BoundingBoxCenterY
		{
			get
			{
				return base.#4Ac(0.0, #Phc.#3hc(107403503));
			}
			set
			{
				base.#5Ac(value, #Phc.#3hc(107403503));
			}
		}

		// Token: 0x1700085A RID: 2138
		// (get) Token: 0x060016E4 RID: 5860 RVA: 0x00017B76 File Offset: 0x00015D76
		// (set) Token: 0x060016E5 RID: 5861 RVA: 0x00017B9D File Offset: 0x00015D9D
		public double BoundingBoxCenterZ
		{
			get
			{
				return base.#4Ac(0.0, #Phc.#3hc(107403510));
			}
			set
			{
				base.#5Ac(value, #Phc.#3hc(107403510));
			}
		}

		// Token: 0x1700085B RID: 2139
		// (get) Token: 0x060016E6 RID: 5862 RVA: 0x00017BBC File Offset: 0x00015DBC
		// (set) Token: 0x060016E7 RID: 5863 RVA: 0x00017BE3 File Offset: 0x00015DE3
		public double BoundingBoxSphereRadius
		{
			get
			{
				return base.#4Ac(50.0, #Phc.#3hc(107403485));
			}
			set
			{
				base.#5Ac(value, #Phc.#3hc(107403485));
			}
		}

		// Token: 0x1700085C RID: 2140
		// (get) Token: 0x060016E8 RID: 5864 RVA: 0x00017C02 File Offset: 0x00015E02
		// (set) Token: 0x060016E9 RID: 5865 RVA: 0x00017C25 File Offset: 0x00015E25
		public System.Windows.Media.Color MainAxisPlaneXYColor
		{
			get
			{
				return base.#aBc(#VQb.#H, #Phc.#3hc(107403452));
			}
			set
			{
				base.#bBc(value, #Phc.#3hc(107403452));
				base.RaisePropertyChanged(#Phc.#3hc(107403452));
			}
		}

		// Token: 0x1700085D RID: 2141
		// (get) Token: 0x060016EA RID: 5866 RVA: 0x00017C54 File Offset: 0x00015E54
		// (set) Token: 0x060016EB RID: 5867 RVA: 0x00017C77 File Offset: 0x00015E77
		public System.Windows.Media.Color MainAxisPlaneYZColor
		{
			get
			{
				return base.#aBc(#VQb.#I, #Phc.#3hc(107403423));
			}
			set
			{
				base.#bBc(value, #Phc.#3hc(107403423));
				base.RaisePropertyChanged(#Phc.#3hc(107403423));
			}
		}

		// Token: 0x1700085E RID: 2142
		// (get) Token: 0x060016EC RID: 5868 RVA: 0x00017CA6 File Offset: 0x00015EA6
		// (set) Token: 0x060016ED RID: 5869 RVA: 0x00017CC9 File Offset: 0x00015EC9
		public System.Windows.Media.Color MainAxisPlaneZXColor
		{
			get
			{
				return base.#aBc(#VQb.#J, #Phc.#3hc(107403362));
			}
			set
			{
				base.#bBc(value, #Phc.#3hc(107403362));
				base.RaisePropertyChanged(#Phc.#3hc(107403362));
			}
		}

		// Token: 0x1700085F RID: 2143
		// (get) Token: 0x060016EE RID: 5870 RVA: 0x00017CF8 File Offset: 0x00015EF8
		// (set) Token: 0x060016EF RID: 5871 RVA: 0x00017D1B File Offset: 0x00015F1B
		public System.Windows.Media.Color MainAxisXColor
		{
			get
			{
				return base.#aBc(#VQb.#K, #Phc.#3hc(107403333));
			}
			set
			{
				base.#bBc(value, #Phc.#3hc(107403333));
			}
		}

		// Token: 0x17000860 RID: 2144
		// (get) Token: 0x060016F0 RID: 5872 RVA: 0x00017D3A File Offset: 0x00015F3A
		// (set) Token: 0x060016F1 RID: 5873 RVA: 0x00017D5D File Offset: 0x00015F5D
		public System.Windows.Media.Color MainAxisYColor
		{
			get
			{
				return base.#aBc(#VQb.#L, #Phc.#3hc(107403344));
			}
			set
			{
				base.#bBc(value, #Phc.#3hc(107403344));
			}
		}

		// Token: 0x17000861 RID: 2145
		// (get) Token: 0x060016F2 RID: 5874 RVA: 0x00017D7C File Offset: 0x00015F7C
		// (set) Token: 0x060016F3 RID: 5875 RVA: 0x00017D9F File Offset: 0x00015F9F
		public System.Windows.Media.Color MainAxisZColor
		{
			get
			{
				return base.#aBc(#VQb.#M, #Phc.#3hc(107403323));
			}
			set
			{
				base.#bBc(value, #Phc.#3hc(107403323));
			}
		}

		// Token: 0x17000862 RID: 2146
		// (get) Token: 0x060016F4 RID: 5876 RVA: 0x00017DBE File Offset: 0x00015FBE
		// (set) Token: 0x060016F5 RID: 5877 RVA: 0x00017DE1 File Offset: 0x00015FE1
		public System.Windows.Media.Color CoordinateSystemColor
		{
			get
			{
				return base.#aBc(#VQb.#N, #Phc.#3hc(107403270));
			}
			set
			{
				base.#bBc(value, #Phc.#3hc(107403270));
			}
		}

		// Token: 0x17000863 RID: 2147
		// (get) Token: 0x060016F6 RID: 5878 RVA: 0x00017E00 File Offset: 0x00016000
		// (set) Token: 0x060016F7 RID: 5879 RVA: 0x00017E27 File Offset: 0x00016027
		public double MainAxisXLength
		{
			get
			{
				return base.#4Ac(70.0, #Phc.#3hc(107403753));
			}
			set
			{
				base.#5Ac(value, #Phc.#3hc(107403753));
			}
		}

		// Token: 0x17000864 RID: 2148
		// (get) Token: 0x060016F8 RID: 5880 RVA: 0x00017E46 File Offset: 0x00016046
		// (set) Token: 0x060016F9 RID: 5881 RVA: 0x00017E6D File Offset: 0x0001606D
		public double MainAxisYLength
		{
			get
			{
				return base.#4Ac(70.0, #Phc.#3hc(107403764));
			}
			set
			{
				base.#5Ac(value, #Phc.#3hc(107403764));
			}
		}

		// Token: 0x17000865 RID: 2149
		// (get) Token: 0x060016FA RID: 5882 RVA: 0x00017E8C File Offset: 0x0001608C
		// (set) Token: 0x060016FB RID: 5883 RVA: 0x00017EB3 File Offset: 0x000160B3
		public double MainAxisZLength
		{
			get
			{
				return base.#4Ac(120.0, #Phc.#3hc(107403743));
			}
			set
			{
				base.#5Ac(value, #Phc.#3hc(107403743));
			}
		}

		// Token: 0x17000866 RID: 2150
		// (get) Token: 0x060016FC RID: 5884 RVA: 0x00017ED2 File Offset: 0x000160D2
		// (set) Token: 0x060016FD RID: 5885 RVA: 0x00017EF9 File Offset: 0x000160F9
		public double MainAxisArrowRadius
		{
			get
			{
				return base.#4Ac(0.5, #Phc.#3hc(107403690));
			}
			set
			{
				base.#5Ac(value, #Phc.#3hc(107403690));
			}
		}

		// Token: 0x17000867 RID: 2151
		// (get) Token: 0x060016FE RID: 5886 RVA: 0x00017F18 File Offset: 0x00016118
		// (set) Token: 0x060016FF RID: 5887 RVA: 0x00017F3F File Offset: 0x0001613F
		public double MainAxisRadius
		{
			get
			{
				return base.#4Ac(0.25, #Phc.#3hc(107403661));
			}
			set
			{
				base.#5Ac(value, #Phc.#3hc(107403661));
			}
		}

		// Token: 0x17000868 RID: 2152
		// (get) Token: 0x06001700 RID: 5888 RVA: 0x00017F5E File Offset: 0x0001615E
		// (set) Token: 0x06001701 RID: 5889 RVA: 0x00017F81 File Offset: 0x00016181
		public System.Windows.Media.Color PointerToolColor
		{
			get
			{
				return base.#aBc(#VQb.#T, #Phc.#3hc(107403672));
			}
			set
			{
				base.#bBc(value, #Phc.#3hc(107403672));
			}
		}

		// Token: 0x17000869 RID: 2153
		// (get) Token: 0x06001702 RID: 5890 RVA: 0x00017FA0 File Offset: 0x000161A0
		// (set) Token: 0x06001703 RID: 5891 RVA: 0x00017FC7 File Offset: 0x000161C7
		public double SnapPointDistanceRadiusScaleFactor
		{
			get
			{
				return base.#4Ac(2.5, #Phc.#3hc(107403647));
			}
			set
			{
				base.#5Ac(value, #Phc.#3hc(107403647));
			}
		}

		// Token: 0x1700086A RID: 2154
		// (get) Token: 0x06001704 RID: 5892 RVA: 0x00017FE6 File Offset: 0x000161E6
		// (set) Token: 0x06001705 RID: 5893 RVA: 0x00018009 File Offset: 0x00016209
		public CameraType CameraType
		{
			get
			{
				return base.#YAc<CameraType>(#VQb.#V, #Phc.#3hc(107403566));
			}
			set
			{
				base.#XAc<CameraType>(value, #Phc.#3hc(107403566));
			}
		}

		// Token: 0x1700086B RID: 2155
		// (get) Token: 0x06001706 RID: 5894 RVA: 0x00018028 File Offset: 0x00016228
		// (set) Token: 0x06001707 RID: 5895 RVA: 0x00018047 File Offset: 0x00016247
		public bool IsCoordinateSystemVisible
		{
			get
			{
				return base.#1Ac(false, #Phc.#3hc(107403581));
			}
			set
			{
				base.#0Ac(value, #Phc.#3hc(107403581));
			}
		}

		// Token: 0x1700086C RID: 2156
		// (get) Token: 0x06001708 RID: 5896 RVA: 0x00018066 File Offset: 0x00016266
		// (set) Token: 0x06001709 RID: 5897 RVA: 0x00018085 File Offset: 0x00016285
		public bool Show3dRotationCube
		{
			get
			{
				return base.#1Ac(true, #Phc.#3hc(107411207));
			}
			set
			{
				base.#0Ac(value, #Phc.#3hc(107411207));
			}
		}

		// Token: 0x1700086D RID: 2157
		// (get) Token: 0x0600170A RID: 5898 RVA: 0x000180A4 File Offset: 0x000162A4
		// (set) Token: 0x0600170B RID: 5899 RVA: 0x000180C3 File Offset: 0x000162C3
		public bool AreMainAxesVisible
		{
			get
			{
				return base.#1Ac(true, #Phc.#3hc(107411289));
			}
			set
			{
				base.#0Ac(value, #Phc.#3hc(107411289));
			}
		}

		// Token: 0x1700086E RID: 2158
		// (get) Token: 0x0600170C RID: 5900 RVA: 0x000180E2 File Offset: 0x000162E2
		// (set) Token: 0x0600170D RID: 5901 RVA: 0x00018101 File Offset: 0x00016301
		public bool Diagram3DIsMxMyPlaneVisible
		{
			get
			{
				return base.#1Ac(false, #Phc.#3hc(107410670));
			}
			set
			{
				base.#0Ac(value, #Phc.#3hc(107410670));
			}
		}

		// Token: 0x1700086F RID: 2159
		// (get) Token: 0x0600170E RID: 5902 RVA: 0x00018120 File Offset: 0x00016320
		// (set) Token: 0x0600170F RID: 5903 RVA: 0x0001813F File Offset: 0x0001633F
		public bool Diagram3DIsMyPPlaneVisible
		{
			get
			{
				return base.#1Ac(false, #Phc.#3hc(107410596));
			}
			set
			{
				base.#0Ac(value, #Phc.#3hc(107410596));
			}
		}

		// Token: 0x17000870 RID: 2160
		// (get) Token: 0x06001710 RID: 5904 RVA: 0x0001815E File Offset: 0x0001635E
		// (set) Token: 0x06001711 RID: 5905 RVA: 0x0001817D File Offset: 0x0001637D
		public bool Diagram3DIsPMxPlaneVisible
		{
			get
			{
				return base.#1Ac(false, #Phc.#3hc(107410633));
			}
			set
			{
				base.#0Ac(value, #Phc.#3hc(107410633));
			}
		}

		// Token: 0x17000871 RID: 2161
		// (get) Token: 0x06001712 RID: 5906 RVA: 0x0001819C File Offset: 0x0001639C
		// (set) Token: 0x06001713 RID: 5907 RVA: 0x000181BB File Offset: 0x000163BB
		public bool Diagram3DAreLoadPointsVisible
		{
			get
			{
				return base.#1Ac(true, #Phc.#3hc(107403544));
			}
			set
			{
				base.#0Ac(value, #Phc.#3hc(107403544));
			}
		}

		// Token: 0x17000872 RID: 2162
		// (get) Token: 0x06001714 RID: 5908 RVA: 0x000181DA File Offset: 0x000163DA
		// (set) Token: 0x06001715 RID: 5909 RVA: 0x000181F9 File Offset: 0x000163F9
		public bool IsPointerVisible
		{
			get
			{
				return base.#1Ac(true, #Phc.#3hc(107402959));
			}
			set
			{
				base.#0Ac(value, #Phc.#3hc(107402959));
			}
		}

		// Token: 0x17000873 RID: 2163
		// (get) Token: 0x06001716 RID: 5910 RVA: 0x00018218 File Offset: 0x00016418
		// (set) Token: 0x06001717 RID: 5911 RVA: 0x00018237 File Offset: 0x00016437
		public bool ViewControlsPanelVisible
		{
			get
			{
				return base.#1Ac(true, #Phc.#3hc(107402966));
			}
			set
			{
				if (this.ViewControlsPanelVisible != value)
				{
					base.#0Ac(value, #Phc.#3hc(107402966));
					base.RaisePropertyChanged(#Phc.#3hc(107402966));
				}
			}
		}

		// Token: 0x17000874 RID: 2164
		// (get) Token: 0x06001718 RID: 5912 RVA: 0x00003375 File Offset: 0x00001575
		// (set) Token: 0x06001719 RID: 5913 RVA: 0x0001826F File Offset: 0x0001646F
		public ToolsPanelPosition ViewControlsPanelPosition
		{
			get
			{
				return ToolsPanelPosition.TopRight;
			}
			set
			{
				if (this.ViewControlsPanelPosition != value)
				{
					base.#XAc<ToolsPanelPosition>(value, #Phc.#3hc(107402933));
					base.RaisePropertyChanged(#Phc.#3hc(107402933));
				}
			}
		}

		// Token: 0x17000875 RID: 2165
		// (get) Token: 0x0600171A RID: 5914 RVA: 0x000182A7 File Offset: 0x000164A7
		// (set) Token: 0x0600171B RID: 5915 RVA: 0x000182D5 File Offset: 0x000164D5
		public string ManualFileName
		{
			get
			{
				return base.#IAc(base.UserSettingProvider, #Phc.#3hc(107402896), #Phc.#3hc(107402867));
			}
			set
			{
				base.#LAc(base.UserSettingProvider, value, #Phc.#3hc(107402867));
			}
		}

		// Token: 0x17000876 RID: 2166
		// (get) Token: 0x0600171C RID: 5916 RVA: 0x000182FA File Offset: 0x000164FA
		// (set) Token: 0x0600171D RID: 5917 RVA: 0x00018328 File Offset: 0x00016528
		public string ManualSubdirectory
		{
			get
			{
				return base.#IAc(base.UserSettingProvider, #Phc.#3hc(107402846), #Phc.#3hc(107402841));
			}
			set
			{
				base.#LAc(base.UserSettingProvider, value, #Phc.#3hc(107402841));
			}
		}

		// Token: 0x17000877 RID: 2167
		// (get) Token: 0x0600171E RID: 5918 RVA: 0x0001834D File Offset: 0x0001654D
		// (set) Token: 0x0600171F RID: 5919 RVA: 0x0001837B File Offset: 0x0001657B
		public string ManualWebUrlBaseAddress
		{
			get
			{
				return base.#IAc(base.UserSettingProvider, #Phc.#3hc(107402784), #Phc.#3hc(107403239));
			}
			set
			{
				base.#LAc(base.UserSettingProvider, value, #Phc.#3hc(107403239));
			}
		}

		// Token: 0x17000878 RID: 2168
		// (get) Token: 0x06001720 RID: 5920 RVA: 0x000183A0 File Offset: 0x000165A0
		// (set) Token: 0x06001721 RID: 5921 RVA: 0x000183B5 File Offset: 0x000165B5
		public bool ShowNominal
		{
			get
			{
				return this.#a.ShowNominal;
			}
			set
			{
				this.#a.ShowNominal = value;
			}
		}

		// Token: 0x17000879 RID: 2169
		// (get) Token: 0x06001722 RID: 5922 RVA: 0x000183CF File Offset: 0x000165CF
		// (set) Token: 0x06001723 RID: 5923 RVA: 0x000183E4 File Offset: 0x000165E4
		public bool ShowFactored
		{
			get
			{
				return this.#a.ShowFactored;
			}
			set
			{
				this.#a.ShowFactored = value;
			}
		}

		// Token: 0x1700087A RID: 2170
		// (get) Token: 0x06001724 RID: 5924 RVA: 0x000183FE File Offset: 0x000165FE
		public bool ShowNominalOrFactored
		{
			get
			{
				return this.ShowNominal || this.ShowFactored;
			}
		}

		// Token: 0x1700087B RID: 2171
		// (get) Token: 0x06001725 RID: 5925 RVA: 0x0001841C File Offset: 0x0001661C
		// (set) Token: 0x06001726 RID: 5926 RVA: 0x0001843F File Offset: 0x0001663F
		public bool ShowCoordinateSystemSign
		{
			get
			{
				return base.#1Ac(#VQb.#W, #Phc.#3hc(107410134));
			}
			set
			{
				base.#0Ac(value, #Phc.#3hc(107410134));
			}
		}

		// Token: 0x1700087C RID: 2172
		// (get) Token: 0x06001727 RID: 5927 RVA: 0x0001845E File Offset: 0x0001665E
		// (set) Token: 0x06001728 RID: 5928 RVA: 0x00018481 File Offset: 0x00016681
		public bool ObjectCentroid
		{
			get
			{
				return base.#1Ac(#VQb.#X, #Phc.#3hc(107410101));
			}
			set
			{
				base.#0Ac(value, #Phc.#3hc(107410101));
			}
		}

		// Token: 0x1700087D RID: 2173
		// (get) Token: 0x06001729 RID: 5929 RVA: 0x000184A0 File Offset: 0x000166A0
		// (set) Token: 0x0600172A RID: 5930 RVA: 0x000184AC File Offset: 0x000166AC
		public #H7 StatusBar { get; set; }

		// Token: 0x1700087E RID: 2174
		// (get) Token: 0x0600172B RID: 5931 RVA: 0x000B4F44 File Offset: 0x000B3144
		public #qRb CurrentColorSettings
		{
			get
			{
				#qRb result;
				if ((result = this.#b) == null)
				{
					result = (this.#b = this.#ZN());
				}
				return result;
			}
		}

		// Token: 0x1700087F RID: 2175
		// (get) Token: 0x0600172C RID: 5932 RVA: 0x000B4F78 File Offset: 0x000B3178
		public #2Qb CurrentGeneralOptions
		{
			get
			{
				#2Qb result;
				if ((result = this.#c) == null)
				{
					result = (this.#c = this.#XN());
				}
				return result;
			}
		}

		// Token: 0x17000880 RID: 2176
		// (get) Token: 0x0600172D RID: 5933 RVA: 0x000184BD File Offset: 0x000166BD
		// (set) Token: 0x0600172E RID: 5934 RVA: 0x000184C9 File Offset: 0x000166C9
		public double MergingZone { get; set; }

		// Token: 0x17000881 RID: 2177
		// (get) Token: 0x0600172F RID: 5935 RVA: 0x000B4FAC File Offset: 0x000B31AC
		// (set) Token: 0x06001730 RID: 5936 RVA: 0x000184DA File Offset: 0x000166DA
		public System.Drawing.Color ToolHelperColor
		{
			get
			{
				System.Drawing.Color color = #KT.#f;
				System.Windows.Media.Color color2 = base.#aBc(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B), #Phc.#3hc(107403206));
				return System.Drawing.Color.FromArgb((int)color2.A, (int)color2.R, (int)color2.G, (int)color2.B);
			}
			set
			{
				base.#bBc(System.Windows.Media.Color.FromArgb(value.A, value.R, value.G, value.B), #Phc.#3hc(107403206));
			}
		}

		// Token: 0x17000882 RID: 2178
		// (get) Token: 0x06001731 RID: 5937 RVA: 0x000B5020 File Offset: 0x000B3220
		// (set) Token: 0x06001732 RID: 5938 RVA: 0x00018519 File Offset: 0x00016719
		public System.Drawing.Color ToolIdleColor
		{
			get
			{
				System.Drawing.Color color = #KT.#g;
				System.Windows.Media.Color color2 = base.#aBc(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B), #Phc.#3hc(107403217));
				return System.Drawing.Color.FromArgb((int)color2.A, (int)color2.R, (int)color2.G, (int)color2.B);
			}
			set
			{
				base.#bBc(System.Windows.Media.Color.FromArgb(value.A, value.R, value.G, value.B), #Phc.#3hc(107403217));
			}
		}

		// Token: 0x17000883 RID: 2179
		// (get) Token: 0x06001733 RID: 5939 RVA: 0x00018558 File Offset: 0x00016758
		// (set) Token: 0x06001734 RID: 5940 RVA: 0x0001857C File Offset: 0x0001677C
		public string InitialPathForDiagramImportExport
		{
			get
			{
				return base.#9Ac(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), #Phc.#3hc(107403196));
			}
			set
			{
				base.#6Ac(value, #Phc.#3hc(107403196));
			}
		}

		// Token: 0x17000884 RID: 2180
		// (get) Token: 0x06001735 RID: 5941 RVA: 0x0001859B File Offset: 0x0001679B
		public string StandardTemplatesPath
		{
			get
			{
				return Path.Combine(new string[]
				{
					#jzc.#hzc(),
					#Phc.#3hc(107403119)
				});
			}
		}

		// Token: 0x17000885 RID: 2181
		// (get) Token: 0x06001736 RID: 5942 RVA: 0x000B5094 File Offset: 0x000B3294
		public string UserDefinedTemplatesPath
		{
			get
			{
				return Path.Combine(new string[]
				{
					Environment.GetFolderPath(Environment.SpecialFolder.Personal),
					#Phc.#3hc(107403126),
					#Phc.#3hc(107405338),
					#Phc.#3hc(107403073)
				});
			}
		}

		// Token: 0x17000886 RID: 2182
		// (get) Token: 0x06001737 RID: 5943 RVA: 0x000185C9 File Offset: 0x000167C9
		// (set) Token: 0x06001738 RID: 5944 RVA: 0x000185ED File Offset: 0x000167ED
		public string LastEtabsImportPath
		{
			get
			{
				return base.#9Ac(Environment.GetFolderPath(Environment.SpecialFolder.Personal), #Phc.#3hc(107403092));
			}
			set
			{
				base.#6Ac(value, #Phc.#3hc(107403092));
			}
		}

		// Token: 0x17000887 RID: 2183
		// (get) Token: 0x06001739 RID: 5945 RVA: 0x0001860C File Offset: 0x0001680C
		public double MoveIndicatorSize { get; }

		// Token: 0x17000888 RID: 2184
		// (get) Token: 0x0600173A RID: 5946 RVA: 0x00018618 File Offset: 0x00016818
		public double MoveIndicatorStroke { get; }

		// Token: 0x17000889 RID: 2185
		// (get) Token: 0x0600173B RID: 5947 RVA: 0x00018624 File Offset: 0x00016824
		// (set) Token: 0x0600173C RID: 5948 RVA: 0x00018630 File Offset: 0x00016830
		public bool OrthoEnabled { get; set; }

		// Token: 0x1700088A RID: 2186
		// (get) Token: 0x0600173D RID: 5949 RVA: 0x00018641 File Offset: 0x00016841
		// (set) Token: 0x0600173E RID: 5950 RVA: 0x0001864D File Offset: 0x0001684D
		public #z7 SnappingSettings { get; set; }

		// Token: 0x1700088B RID: 2187
		// (get) Token: 0x0600173F RID: 5951 RVA: 0x0001865E File Offset: 0x0001685E
		// (set) Token: 0x06001740 RID: 5952 RVA: 0x0001866A File Offset: 0x0001686A
		public #j7 DrawingGrid { get; set; }

		// Token: 0x1700088C RID: 2188
		// (get) Token: 0x06001741 RID: 5953 RVA: 0x0001867B File Offset: 0x0001687B
		// (set) Token: 0x06001742 RID: 5954 RVA: 0x00018687 File Offset: 0x00016887
		public #n7 DynamicInput { get; set; }

		// Token: 0x1700088D RID: 2189
		// (get) Token: 0x06001743 RID: 5955 RVA: 0x00018698 File Offset: 0x00016898
		// (set) Token: 0x06001744 RID: 5956 RVA: 0x000186BB File Offset: 0x000168BB
		public Diagram2DCursorType Diagram2DCursorType
		{
			get
			{
				return base.#YAc<Diagram2DCursorType>(#VQb.#db, #Phc.#3hc(107403063));
			}
			set
			{
				base.#XAc<Diagram2DCursorType>(value, #Phc.#3hc(107403063));
			}
		}

		// Token: 0x1700088E RID: 2190
		// (get) Token: 0x06001745 RID: 5957 RVA: 0x000186DA File Offset: 0x000168DA
		// (set) Token: 0x06001746 RID: 5958 RVA: 0x00018701 File Offset: 0x00016901
		public double LeftPanelWidth
		{
			get
			{
				return base.#4Ac(370.0, #Phc.#3hc(107403034));
			}
			set
			{
				base.#5Ac(value, #Phc.#3hc(107403034));
			}
		}

		// Token: 0x1700088F RID: 2191
		// (get) Token: 0x06001747 RID: 5959 RVA: 0x000B50E8 File Offset: 0x000B32E8
		// (set) Token: 0x06001748 RID: 5960 RVA: 0x00018720 File Offset: 0x00016920
		public BatchProcessorSettings BatchProcessorSettings
		{
			get
			{
				BatchProcessorSettings result;
				if ((result = this.#d) == null)
				{
					result = (this.#d = (base.#8Ac<BatchProcessorSettings>(BatchProcessorSettings.Default, #Phc.#3hc(107402469)) ?? BatchProcessorSettings.Default));
				}
				return result;
			}
			set
			{
				if (value != null)
				{
					base.#7Ac<BatchProcessorSettings>(value, #Phc.#3hc(107402469));
					this.#d = value;
				}
			}
		}

		// Token: 0x17000890 RID: 2192
		// (get) Token: 0x06001749 RID: 5961 RVA: 0x00018749 File Offset: 0x00016949
		public EdgeMode RenderOptionsEdgeMode
		{
			get
			{
				return base.#YAc<EdgeMode>(EdgeMode.Unspecified, #Phc.#3hc(107402436));
			}
		}

		// Token: 0x17000891 RID: 2193
		// (get) Token: 0x0600174A RID: 5962 RVA: 0x00018768 File Offset: 0x00016968
		// (set) Token: 0x0600174B RID: 5963 RVA: 0x00018788 File Offset: 0x00016988
		public int MinNoOfCircleSegments
		{
			get
			{
				return base.#2Ac(40, #Phc.#3hc(107402407));
			}
			set
			{
				base.#3Ac(value, #Phc.#3hc(107402407));
			}
		}

		// Token: 0x17000892 RID: 2194
		// (get) Token: 0x0600174C RID: 5964 RVA: 0x000187A7 File Offset: 0x000169A7
		public int CmdBatchNumberOfThreads
		{
			get
			{
				return Math.Max(base.#2Ac(Environment.ProcessorCount / 2, #Phc.#3hc(107402378)), 1);
			}
		}

		// Token: 0x17000893 RID: 2195
		// (get) Token: 0x0600174D RID: 5965 RVA: 0x000187D2 File Offset: 0x000169D2
		public float DiagramInterpolationConvergenceEpsilonPercentage
		{
			get
			{
				return (float)Math.Max(base.#4Ac(1.0, #Phc.#3hc(107402345)), 1E-05);
			}
		}

		// Token: 0x0600174E RID: 5966 RVA: 0x000B5134 File Offset: 0x000B3334
		public #2Qb #XN()
		{
			#2Qb #2Qb = #2Qb.Default;
			#2Qb #2Qb2 = new #2Qb
			{
				AutomaticallyGenerateTextResultsFile = base.#1Ac(#2Qb.AutomaticallyGenerateTextResultsFile, #Phc.#3hc(107402280)),
				HighlightCriticalLoadPoints = base.#1Ac(#2Qb.HighlightCriticalLoadPoints, #Phc.#3hc(107402263)),
				HighlightingColor = base.#aBc(#2Qb.HighlightingColor, #Phc.#3hc(107402738)),
				ReorderSolidAndOpeningLabelsBeforeSolve = base.#1Ac(#2Qb.ReorderSolidAndOpeningLabelsBeforeSolve, #Phc.#3hc(107402713))
			};
			this.#c = new #2Qb();
			this.#c.#mg(#2Qb2);
			return #2Qb2;
		}

		// Token: 0x0600174F RID: 5967 RVA: 0x000B51F4 File Offset: 0x000B33F4
		public void #YN(#2Qb #ng)
		{
			base.#0Ac(#ng.AutomaticallyGenerateTextResultsFile, #Phc.#3hc(107402280));
			base.#0Ac(#ng.HighlightCriticalLoadPoints, #Phc.#3hc(107402263));
			base.#bBc(#ng.HighlightingColor, #Phc.#3hc(107402738));
			base.#0Ac(#ng.ReorderSolidAndOpeningLabelsBeforeSolve, #Phc.#3hc(107402713));
			this.#c = new #2Qb();
			this.#c.#mg(#ng);
		}

		// Token: 0x06001750 RID: 5968 RVA: 0x000B527C File Offset: 0x000B347C
		public #qRb #ZN()
		{
			#qRb #qRb = #qRb.Default;
			#qRb #qRb2 = new #qRb
			{
				TextColor = base.#aBc(#qRb.TextColor, #Phc.#3hc(107402628)),
				LabelSize = base.#2Ac(#qRb.LabelSize, #Phc.#3hc(107402647)),
				DimensionsColor = base.#aBc(#qRb.DimensionsColor, #Phc.#3hc(107402602)),
				SolidColor = base.#aBc(#qRb.SolidColor, #Phc.#3hc(107402613)),
				OpeningColor = base.#aBc(#qRb.OpeningColor, #Phc.#3hc(107402564)),
				BarPointColor = base.#aBc(#qRb.BarPointColor, #Phc.#3hc(107402579)),
				BarAreaColor = base.#aBc(#qRb.BarAreaColor, #Phc.#3hc(107402558)),
				BarLrPointColor = base.#aBc(#qRb.BarLrPointColor, #Phc.#3hc(107402509)),
				BarLrAreaColor = base.#aBc(#qRb.BarLrAreaColor, #Phc.#3hc(107402520)),
				SectionAnnotationsVisibility = base.#1Ac(#qRb.SectionAnnotationsVisibility, #Phc.#3hc(107401955)),
				CoverVisibility = base.#1Ac(#qRb.CoverVisibility, #Phc.#3hc(107401946)),
				MainGridLineColor = base.#aBc(#qRb.MainGridLineColor, #Phc.#3hc(107401893)),
				GridLineColor = base.#aBc(#qRb.GridLineColor, #Phc.#3hc(107401868)),
				CoverLineColor = base.#aBc(#qRb.CoverLineColor, #Phc.#3hc(107410742)),
				CoverLineType = base.#YAc<LineType>(#qRb.CoverLineType, #Phc.#3hc(107410689))
			};
			this.#b = new #qRb();
			this.#b.#mg(#qRb2);
			return #qRb2;
		}

		// Token: 0x06001751 RID: 5969 RVA: 0x000B5470 File Offset: 0x000B3670
		public void #0N(#qRb #ng)
		{
			this.#b = new #qRb();
			this.#b.#mg(#ng);
			base.#bBc(#ng.TextColor, #Phc.#3hc(107402628));
			base.#3Ac(#ng.LabelSize, #Phc.#3hc(107402647));
			base.#bBc(#ng.DimensionsColor, #Phc.#3hc(107402602));
			base.#bBc(#ng.SolidColor, #Phc.#3hc(107402613));
			base.#bBc(#ng.OpeningColor, #Phc.#3hc(107402564));
			base.#bBc(#ng.BarPointColor, #Phc.#3hc(107402579));
			base.#bBc(#ng.BarAreaColor, #Phc.#3hc(107402558));
			base.#bBc(#ng.BarLrPointColor, #Phc.#3hc(107402509));
			base.#bBc(#ng.BarLrAreaColor, #Phc.#3hc(107402520));
			base.#0Ac(#ng.SectionAnnotationsVisibility, #Phc.#3hc(107401955));
			base.#0Ac(#ng.CoverVisibility, #Phc.#3hc(107401946));
			base.#bBc(#ng.MainGridLineColor, #Phc.#3hc(107401893));
			base.#bBc(#ng.GridLineColor, #Phc.#3hc(107401868));
			base.#bBc(#ng.CoverLineColor, #Phc.#3hc(107410742));
			base.#XAc<LineType>(#ng.CoverLineType, #Phc.#3hc(107410689));
		}

		// Token: 0x06001752 RID: 5970 RVA: 0x00016305 File Offset: 0x00014505
		#55d ISettingsManager.#1N()
		{
			return base.UserSettingProvider;
		}

		// Token: 0x06001753 RID: 5971 RVA: 0x00016315 File Offset: 0x00014515
		#55d ISettingsManager.#2N()
		{
			return base.ApplicationSettingProvider;
		}

		// Token: 0x04000918 RID: 2328
		private readonly #yse #a;

		// Token: 0x04000919 RID: 2329
		private #qRb #b;

		// Token: 0x0400091A RID: 2330
		private #2Qb #c;

		// Token: 0x0400091B RID: 2331
		private BatchProcessorSettings #d;

		// Token: 0x0400091C RID: 2332
		[CompilerGenerated]
		private readonly #tU #e = new #tU();

		// Token: 0x0400091D RID: 2333
		[CompilerGenerated]
		private #H7 #f;

		// Token: 0x0400091E RID: 2334
		[CompilerGenerated]
		private double #g = 0.05;

		// Token: 0x0400091F RID: 2335
		[CompilerGenerated]
		private readonly double #h = 6.0;

		// Token: 0x04000920 RID: 2336
		[CompilerGenerated]
		private readonly double #i = 1.0;

		// Token: 0x04000921 RID: 2337
		[CompilerGenerated]
		private bool #j;

		// Token: 0x04000922 RID: 2338
		[CompilerGenerated]
		private #z7 #k;

		// Token: 0x04000923 RID: 2339
		[CompilerGenerated]
		private #j7 #l;

		// Token: 0x04000924 RID: 2340
		[CompilerGenerated]
		private #n7 #m;
	}
}
