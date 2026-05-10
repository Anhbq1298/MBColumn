using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using #7hc;
using #u3d;
using #UYd;
using Ab3d.Cameras;
using Ab3d.Common.Cameras;
using Ab3d.Utilities;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.API;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.CameraPositionSetters;
using StructurePoint.CoreAssets.GUI.DesktopControls.Ribbon;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors;
using StructurePoint.CoreAssets.Infrastructure;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Localizer;
using Telerik.Windows;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000923 RID: 2339
	[SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Doesn't perform any complex business logic, mostly UI operations.")]
	public sealed class ModelEditorControl : UserControl, IDisposable, IComponentConnector, IModelEditorControl
	{
		// Token: 0x170015A7 RID: 5543
		// (get) Token: 0x06004A3E RID: 19006 RVA: 0x0003E45A File Offset: 0x0003C65A
		// (set) Token: 0x06004A3F RID: 19007 RVA: 0x0003E474 File Offset: 0x0003C674
		public Visibility ViewControlsTitleBarVisibility
		{
			get
			{
				return (Visibility)base.GetValue(ModelEditorControl.ViewControlsTitleBarVisibilityProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.ViewControlsTitleBarVisibilityProperty, value);
			}
		}

		// Token: 0x170015A8 RID: 5544
		// (get) Token: 0x06004A40 RID: 19008 RVA: 0x0003E493 File Offset: 0x0003C693
		// (set) Token: 0x06004A41 RID: 19009 RVA: 0x0003E4AD File Offset: 0x0003C6AD
		public bool BindViewCubeVisibilityWithViewControlsVisibility
		{
			get
			{
				return (bool)base.GetValue(ModelEditorControl.BindViewCubeVisibilityWithViewControlsVisibilityProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.BindViewCubeVisibilityWithViewControlsVisibilityProperty, value);
			}
		}

		// Token: 0x170015A9 RID: 5545
		// (get) Token: 0x06004A42 RID: 19010 RVA: 0x0003E4CC File Offset: 0x0003C6CC
		// (set) Token: 0x06004A43 RID: 19011 RVA: 0x0003E4E1 File Offset: 0x0003C6E1
		public double CameraAttitude
		{
			get
			{
				return this.TargetPositionCamera.Attitude;
			}
			set
			{
				this.TargetPositionCamera.Attitude = value;
			}
		}

		// Token: 0x170015AA RID: 5546
		// (get) Token: 0x06004A44 RID: 19012 RVA: 0x0003E4FB File Offset: 0x0003C6FB
		// (set) Token: 0x06004A45 RID: 19013 RVA: 0x0003E510 File Offset: 0x0003C710
		public double CameraHeading
		{
			get
			{
				return this.TargetPositionCamera.Heading;
			}
			set
			{
				this.TargetPositionCamera.Heading = value;
			}
		}

		// Token: 0x170015AB RID: 5547
		// (get) Token: 0x06004A46 RID: 19014 RVA: 0x0003E52A File Offset: 0x0003C72A
		// (set) Token: 0x06004A47 RID: 19015 RVA: 0x0003E53F File Offset: 0x0003C73F
		public double CameraBank
		{
			get
			{
				return this.TargetPositionCamera.Bank;
			}
			set
			{
				this.TargetPositionCamera.Bank = value;
			}
		}

		// Token: 0x170015AC RID: 5548
		// (get) Token: 0x06004A48 RID: 19016 RVA: 0x0003E559 File Offset: 0x0003C759
		public StructurePoint.CoreAssets.Infrastructure.Data.Size ViewportSize
		{
			get
			{
				return new StructurePoint.CoreAssets.Infrastructure.Data.Size(this.MainViewport.ActualWidth, this.MainViewport.ActualHeight);
			}
		}

		// Token: 0x170015AD RID: 5549
		// (get) Token: 0x06004A49 RID: 19017 RVA: 0x0003E582 File Offset: 0x0003C782
		// (set) Token: 0x06004A4A RID: 19018 RVA: 0x0003E59C File Offset: 0x0003C79C
		public BoundingBoxData EditorWorkspaceSize
		{
			get
			{
				return (BoundingBoxData)base.GetValue(ModelEditorControl.EditorWorkspaceSizeProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.EditorWorkspaceSizeProperty, value);
			}
		}

		// Token: 0x170015AE RID: 5550
		// (get) Token: 0x06004A4B RID: 19019 RVA: 0x0003E5B6 File Offset: 0x0003C7B6
		// (set) Token: 0x06004A4C RID: 19020 RVA: 0x0003E5D0 File Offset: 0x0003C7D0
		public Color EditorWorkspaceBackgroundColor
		{
			get
			{
				return (Color)base.GetValue(ModelEditorControl.EditorWorkspaceBackgroundColorProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.EditorWorkspaceBackgroundColorProperty, value);
			}
		}

		// Token: 0x170015AF RID: 5551
		// (get) Token: 0x06004A4D RID: 19021 RVA: 0x0003E5EF File Offset: 0x0003C7EF
		// (set) Token: 0x06004A4E RID: 19022 RVA: 0x0003E609 File Offset: 0x0003C809
		public BoundingBoxData EditorWorkspaceWithAnnotationsSize
		{
			get
			{
				return (BoundingBoxData)base.GetValue(ModelEditorControl.EditorWorkspaceWithAnnotationsSizeProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.EditorWorkspaceWithAnnotationsSizeProperty, value);
			}
		}

		// Token: 0x170015B0 RID: 5552
		// (get) Token: 0x06004A4F RID: 19023 RVA: 0x0003E623 File Offset: 0x0003C823
		// (set) Token: 0x06004A50 RID: 19024 RVA: 0x0003E63D File Offset: 0x0003C83D
		public Color ScreenBackgroundColor
		{
			get
			{
				return (Color)base.GetValue(ModelEditorControl.ScreenBackgroundColorProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.ScreenBackgroundColorProperty, value);
			}
		}

		// Token: 0x170015B1 RID: 5553
		// (get) Token: 0x06004A51 RID: 19025 RVA: 0x0003E65C File Offset: 0x0003C85C
		// (set) Token: 0x06004A52 RID: 19026 RVA: 0x0003E676 File Offset: 0x0003C876
		public double MinCameraDistance
		{
			get
			{
				return (double)base.GetValue(ModelEditorControl.MinCameraDistanceProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.MinCameraDistanceProperty, value);
			}
		}

		// Token: 0x170015B2 RID: 5554
		// (get) Token: 0x06004A53 RID: 19027 RVA: 0x0003E695 File Offset: 0x0003C895
		// (set) Token: 0x06004A54 RID: 19028 RVA: 0x0003E6AF File Offset: 0x0003C8AF
		public double MaxCameraDistance
		{
			get
			{
				return (double)base.GetValue(ModelEditorControl.MaxCameraDistanceProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.MaxCameraDistanceProperty, value);
			}
		}

		// Token: 0x170015B3 RID: 5555
		// (get) Token: 0x06004A55 RID: 19029 RVA: 0x0003E6CE File Offset: 0x0003C8CE
		// (set) Token: 0x06004A56 RID: 19030 RVA: 0x0003E6E8 File Offset: 0x0003C8E8
		public double CameraDistance
		{
			get
			{
				return (double)base.GetValue(ModelEditorControl.CameraDistanceProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.CameraDistanceProperty, value);
			}
		}

		// Token: 0x170015B4 RID: 5556
		// (get) Token: 0x06004A57 RID: 19031 RVA: 0x0003E707 File Offset: 0x0003C907
		// (set) Token: 0x06004A58 RID: 19032 RVA: 0x0003E721 File Offset: 0x0003C921
		public double MinCameraWidth
		{
			get
			{
				return (double)base.GetValue(ModelEditorControl.MinCameraWidthProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.MinCameraWidthProperty, value);
			}
		}

		// Token: 0x170015B5 RID: 5557
		// (get) Token: 0x06004A59 RID: 19033 RVA: 0x0003E740 File Offset: 0x0003C940
		// (set) Token: 0x06004A5A RID: 19034 RVA: 0x0003E75A File Offset: 0x0003C95A
		public double MaxCameraWidth
		{
			get
			{
				return (double)base.GetValue(ModelEditorControl.MaxCameraWidthProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.MaxCameraWidthProperty, value);
			}
		}

		// Token: 0x170015B6 RID: 5558
		// (get) Token: 0x06004A5B RID: 19035 RVA: 0x0003E779 File Offset: 0x0003C979
		// (set) Token: 0x06004A5C RID: 19036 RVA: 0x0003E793 File Offset: 0x0003C993
		public double CameraWidth
		{
			get
			{
				return (double)base.GetValue(ModelEditorControl.CameraWidthProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.CameraWidthProperty, value);
			}
		}

		// Token: 0x170015B7 RID: 5559
		// (get) Token: 0x06004A5D RID: 19037 RVA: 0x0003E7B2 File Offset: 0x0003C9B2
		// (set) Token: 0x06004A5E RID: 19038 RVA: 0x0003E7CC File Offset: 0x0003C9CC
		public MouseAndKeyboardCondition TranslateViewCondition
		{
			get
			{
				return (MouseAndKeyboardCondition)base.GetValue(ModelEditorControl.TranslateViewConditionProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.TranslateViewConditionProperty, value);
			}
		}

		// Token: 0x170015B8 RID: 5560
		// (get) Token: 0x06004A5F RID: 19039 RVA: 0x0003E7EB File Offset: 0x0003C9EB
		// (set) Token: 0x06004A60 RID: 19040 RVA: 0x0003E805 File Offset: 0x0003CA05
		public MouseAndKeyboardCondition RotateViewCondition
		{
			get
			{
				return (MouseAndKeyboardCondition)base.GetValue(ModelEditorControl.RotateViewConditionProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.RotateViewConditionProperty, value);
			}
		}

		// Token: 0x170015B9 RID: 5561
		// (get) Token: 0x06004A61 RID: 19041 RVA: 0x0003E824 File Offset: 0x0003CA24
		// (set) Token: 0x06004A62 RID: 19042 RVA: 0x0003E83E File Offset: 0x0003CA3E
		public bool IsMouseWheelZoomEnabled
		{
			get
			{
				return (bool)base.GetValue(ModelEditorControl.IsMouseWheelZoomEnabledProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.IsMouseWheelZoomEnabledProperty, value);
			}
		}

		// Token: 0x170015BA RID: 5562
		// (get) Token: 0x06004A63 RID: 19043 RVA: 0x0003E85D File Offset: 0x0003CA5D
		// (set) Token: 0x06004A64 RID: 19044 RVA: 0x0003E877 File Offset: 0x0003CA77
		public Visibility CubePanelVisibility
		{
			get
			{
				return (Visibility)base.GetValue(ModelEditorControl.CubePanelVisibilityProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.CubePanelVisibilityProperty, value);
			}
		}

		// Token: 0x170015BB RID: 5563
		// (get) Token: 0x06004A65 RID: 19045 RVA: 0x0003E896 File Offset: 0x0003CA96
		// (set) Token: 0x06004A66 RID: 19046 RVA: 0x0003E8B0 File Offset: 0x0003CAB0
		public Visibility ZoomPanelVisibility
		{
			get
			{
				return (Visibility)base.GetValue(ModelEditorControl.ZoomPanelVisibilityProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.ZoomPanelVisibilityProperty, value);
			}
		}

		// Token: 0x170015BC RID: 5564
		// (get) Token: 0x06004A67 RID: 19047 RVA: 0x0003E8CF File Offset: 0x0003CACF
		// (set) Token: 0x06004A68 RID: 19048 RVA: 0x0003E8E9 File Offset: 0x0003CAE9
		public Visibility NavigationPanelVisibility
		{
			get
			{
				return (Visibility)base.GetValue(ModelEditorControl.NavigationPanelVisibilityProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.NavigationPanelVisibilityProperty, value);
			}
		}

		// Token: 0x170015BD RID: 5565
		// (get) Token: 0x06004A69 RID: 19049 RVA: 0x0003E908 File Offset: 0x0003CB08
		// (set) Token: 0x06004A6A RID: 19050 RVA: 0x0003E922 File Offset: 0x0003CB22
		public Visibility PanelControls2DVisibility
		{
			get
			{
				return (Visibility)base.GetValue(ModelEditorControl.PanelControls2DVisibilityProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.PanelControls2DVisibilityProperty, value);
			}
		}

		// Token: 0x170015BE RID: 5566
		// (get) Token: 0x06004A6B RID: 19051 RVA: 0x0003E941 File Offset: 0x0003CB41
		// (set) Token: 0x06004A6C RID: 19052 RVA: 0x0003E95B File Offset: 0x0003CB5B
		public Visibility PanelControls3DVisibility
		{
			get
			{
				return (Visibility)base.GetValue(ModelEditorControl.PanelControls3DVisibilityProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.PanelControls3DVisibilityProperty, value);
			}
		}

		// Token: 0x170015BF RID: 5567
		// (get) Token: 0x06004A6D RID: 19053 RVA: 0x0003E97A File Offset: 0x0003CB7A
		// (set) Token: 0x06004A6E RID: 19054 RVA: 0x0003E994 File Offset: 0x0003CB94
		public Visibility VisibilityToolBarControlVisibility
		{
			get
			{
				return (Visibility)base.GetValue(ModelEditorControl.VisibilityToolBarControlVisibilityProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.VisibilityToolBarControlVisibilityProperty, value);
			}
		}

		// Token: 0x170015C0 RID: 5568
		// (get) Token: 0x06004A6F RID: 19055 RVA: 0x0003E9B3 File Offset: 0x0003CBB3
		// (set) Token: 0x06004A70 RID: 19056 RVA: 0x0003E9CD File Offset: 0x0003CBCD
		public IEnumerable<ICheckBoxData> VisibilityToolBarCheckBoxes
		{
			get
			{
				return (IEnumerable<ICheckBoxData>)base.GetValue(ModelEditorControl.VisibilityToolBarCheckBoxesProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.VisibilityToolBarCheckBoxesProperty, value);
			}
		}

		// Token: 0x170015C1 RID: 5569
		// (get) Token: 0x06004A71 RID: 19057 RVA: 0x0003E9E7 File Offset: 0x0003CBE7
		// (set) Token: 0x06004A72 RID: 19058 RVA: 0x0003EA01 File Offset: 0x0003CC01
		public Visibility QuickOptionsPanelVisibility
		{
			get
			{
				return (Visibility)base.GetValue(ModelEditorControl.QuickOptionsPanelVisibilityProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.QuickOptionsPanelVisibilityProperty, value);
			}
		}

		// Token: 0x170015C2 RID: 5570
		// (get) Token: 0x06004A73 RID: 19059 RVA: 0x0003EA20 File Offset: 0x0003CC20
		// (set) Token: 0x06004A74 RID: 19060 RVA: 0x0003EA35 File Offset: 0x0003CC35
		public object QuickOptionsPanelContent
		{
			get
			{
				return base.GetValue(ModelEditorControl.QuickOptionsPanelContentProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.QuickOptionsPanelContentProperty, value);
			}
		}

		// Token: 0x170015C3 RID: 5571
		// (get) Token: 0x06004A75 RID: 19061 RVA: 0x0003EA4F File Offset: 0x0003CC4F
		// (set) Token: 0x06004A76 RID: 19062 RVA: 0x0003EA69 File Offset: 0x0003CC69
		public string VisibilityToolBarTitle
		{
			get
			{
				return (string)base.GetValue(ModelEditorControl.VisibilityToolBarTitleProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.VisibilityToolBarTitleProperty, value);
			}
		}

		// Token: 0x170015C4 RID: 5572
		// (get) Token: 0x06004A77 RID: 19063 RVA: 0x0003EA83 File Offset: 0x0003CC83
		// (set) Token: 0x06004A78 RID: 19064 RVA: 0x0003EA9D File Offset: 0x0003CC9D
		public PredefinedPositionsOfCamera DefaultPositionOfCamera
		{
			get
			{
				return (PredefinedPositionsOfCamera)base.GetValue(ModelEditorControl.DefaultPositionOfCameraProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.DefaultPositionOfCameraProperty, value);
			}
		}

		// Token: 0x170015C5 RID: 5573
		// (get) Token: 0x06004A79 RID: 19065 RVA: 0x0003EABC File Offset: 0x0003CCBC
		// (set) Token: 0x06004A7A RID: 19066 RVA: 0x0003EAD6 File Offset: 0x0003CCD6
		public string AxisXLabel
		{
			get
			{
				return (string)base.GetValue(ModelEditorControl.AxisXLabelProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.AxisXLabelProperty, value);
			}
		}

		// Token: 0x170015C6 RID: 5574
		// (get) Token: 0x06004A7B RID: 19067 RVA: 0x0003EAF0 File Offset: 0x0003CCF0
		// (set) Token: 0x06004A7C RID: 19068 RVA: 0x0003EB0A File Offset: 0x0003CD0A
		public string AxisYLabel
		{
			get
			{
				return (string)base.GetValue(ModelEditorControl.AxisYLabelProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.AxisYLabelProperty, value);
			}
		}

		// Token: 0x170015C7 RID: 5575
		// (get) Token: 0x06004A7D RID: 19069 RVA: 0x0003EB24 File Offset: 0x0003CD24
		// (set) Token: 0x06004A7E RID: 19070 RVA: 0x0003EB3E File Offset: 0x0003CD3E
		public string AxisZLabel
		{
			get
			{
				return (string)base.GetValue(ModelEditorControl.AxisZLabelProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.AxisZLabelProperty, value);
			}
		}

		// Token: 0x170015C8 RID: 5576
		// (get) Token: 0x06004A7F RID: 19071 RVA: 0x0003EB58 File Offset: 0x0003CD58
		// (set) Token: 0x06004A80 RID: 19072 RVA: 0x0003EB72 File Offset: 0x0003CD72
		public TimeSpan FitCameraToWorkspaceAnimationDuration
		{
			get
			{
				return (TimeSpan)base.GetValue(ModelEditorControl.FitCameraToWorkspaceAnimationDurationProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.FitCameraToWorkspaceAnimationDurationProperty, value);
			}
		}

		// Token: 0x170015C9 RID: 5577
		// (get) Token: 0x06004A81 RID: 19073 RVA: 0x0003EB91 File Offset: 0x0003CD91
		// (set) Token: 0x06004A82 RID: 19074 RVA: 0x0003EBAB File Offset: 0x0003CDAB
		public IEnumerable<IPanelItem> ViewControlsPanelAdditionalTools
		{
			get
			{
				return (IEnumerable<IPanelItem>)base.GetValue(ModelEditorControl.ViewControlsPanelAdditionalToolsProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.ViewControlsPanelAdditionalToolsProperty, value);
			}
		}

		// Token: 0x170015CA RID: 5578
		// (get) Token: 0x06004A83 RID: 19075 RVA: 0x0003EBC5 File Offset: 0x0003CDC5
		// (set) Token: 0x06004A84 RID: 19076 RVA: 0x0003EBDF File Offset: 0x0003CDDF
		public ToolsPanelPosition ViewControlsPanelPosition
		{
			get
			{
				return (ToolsPanelPosition)base.GetValue(ModelEditorControl.ViewControlsPanelPositionProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.ViewControlsPanelPositionProperty, value);
			}
		}

		// Token: 0x170015CB RID: 5579
		// (get) Token: 0x06004A85 RID: 19077 RVA: 0x0003EBFE File Offset: 0x0003CDFE
		// (set) Token: 0x06004A86 RID: 19078 RVA: 0x0003EC18 File Offset: 0x0003CE18
		public Visibility ViewControlsPanelVisibility
		{
			get
			{
				return (Visibility)base.GetValue(ModelEditorControl.ViewControlsPanelVisibilityProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.ViewControlsPanelVisibilityProperty, value);
			}
		}

		// Token: 0x170015CC RID: 5580
		// (get) Token: 0x06004A87 RID: 19079 RVA: 0x0003EC37 File Offset: 0x0003CE37
		// (set) Token: 0x06004A88 RID: 19080 RVA: 0x0003EC51 File Offset: 0x0003CE51
		public bool ViewControlsPanelCollapsed
		{
			get
			{
				return (bool)base.GetValue(ModelEditorControl.ViewControlsPanelCollapsedProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.ViewControlsPanelCollapsedProperty, value);
			}
		}

		// Token: 0x170015CD RID: 5581
		// (get) Token: 0x06004A89 RID: 19081 RVA: 0x0003EC70 File Offset: 0x0003CE70
		// (set) Token: 0x06004A8A RID: 19082 RVA: 0x0003EC8A File Offset: 0x0003CE8A
		public string ViewControlsPanelTitle
		{
			get
			{
				return (string)base.GetValue(ModelEditorControl.ViewControlsPanelTitleProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.ViewControlsPanelTitleProperty, value);
			}
		}

		// Token: 0x170015CE RID: 5582
		// (get) Token: 0x06004A8B RID: 19083 RVA: 0x0003ECA4 File Offset: 0x0003CEA4
		// (set) Token: 0x06004A8C RID: 19084 RVA: 0x0003ECBE File Offset: 0x0003CEBE
		public Visibility AdjustZoomToModelButtonVisibility
		{
			get
			{
				return (Visibility)base.GetValue(ModelEditorControl.AdjustZoomToModelButtonVisibilityProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.AdjustZoomToModelButtonVisibilityProperty, value);
			}
		}

		// Token: 0x170015CF RID: 5583
		// (get) Token: 0x06004A8D RID: 19085 RVA: 0x0003ECDD File Offset: 0x0003CEDD
		// (set) Token: 0x06004A8E RID: 19086 RVA: 0x0003ECF7 File Offset: 0x0003CEF7
		public Visibility ZoomToWindowButtonVisibility
		{
			get
			{
				return (Visibility)base.GetValue(ModelEditorControl.ZoomToWindowButtonVisibilityProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.ZoomToWindowButtonVisibilityProperty, value);
			}
		}

		// Token: 0x170015D0 RID: 5584
		// (get) Token: 0x06004A8F RID: 19087 RVA: 0x0003ED16 File Offset: 0x0003CF16
		// (set) Token: 0x06004A90 RID: 19088 RVA: 0x0003ED30 File Offset: 0x0003CF30
		public Visibility Rotate3DButtonVisibility
		{
			get
			{
				return (Visibility)base.GetValue(ModelEditorControl.Rotate3DButtonVisibilityProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.Rotate3DButtonVisibilityProperty, value);
			}
		}

		// Token: 0x170015D1 RID: 5585
		// (get) Token: 0x06004A91 RID: 19089 RVA: 0x0003ED4F File Offset: 0x0003CF4F
		// (set) Token: 0x06004A92 RID: 19090 RVA: 0x0003ED69 File Offset: 0x0003CF69
		public string ViewControlsResetButtonToolTip
		{
			get
			{
				return (string)base.GetValue(ModelEditorControl.ViewControlsResetButtonToolTipProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.ViewControlsResetButtonToolTipProperty, value);
			}
		}

		// Token: 0x170015D2 RID: 5586
		// (get) Token: 0x06004A93 RID: 19091 RVA: 0x0003ED83 File Offset: 0x0003CF83
		// (set) Token: 0x06004A94 RID: 19092 RVA: 0x0003ED9D File Offset: 0x0003CF9D
		public ViewCubeSize ViewCubeSize
		{
			get
			{
				return (ViewCubeSize)base.GetValue(ModelEditorControl.ViewCubeSizeProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.ViewCubeSizeProperty, value);
			}
		}

		// Token: 0x170015D3 RID: 5587
		// (get) Token: 0x06004A95 RID: 19093 RVA: 0x0003EDBC File Offset: 0x0003CFBC
		// (set) Token: 0x06004A96 RID: 19094 RVA: 0x0003EDD6 File Offset: 0x0003CFD6
		public double EditorMinWidth
		{
			get
			{
				return (double)base.GetValue(ModelEditorControl.EditorMinWidthProperty);
			}
			set
			{
				base.SetValue(ModelEditorControl.EditorMinWidthProperty, value);
			}
		}

		// Token: 0x06004A97 RID: 19095 RVA: 0x0003EDF5 File Offset: 0x0003CFF5
		private static void OnViewControlsTitleBarVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((ModelEditorControl)d).ViewControlsPanel.TitleBarVisibility = (Visibility)e.NewValue;
		}

		// Token: 0x06004A98 RID: 19096 RVA: 0x0003EE1F File Offset: 0x0003D01F
		private static void MyOnEditorWorkspaceBackgroundColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			((ModelEditorControl)sender).MyUpdateEditorWorkspaceBackgroundColor();
		}

		// Token: 0x06004A99 RID: 19097 RVA: 0x00149BAC File Offset: 0x00147DAC
		private static void MyOnScreenBackgroundColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			ModelEditorControl modelEditorControl = (ModelEditorControl)sender;
			modelEditorControl.MainViewportBorder.Background = new SolidColorBrush(modelEditorControl.ScreenBackgroundColor);
		}

		// Token: 0x06004A9A RID: 19098 RVA: 0x00149BE4 File Offset: 0x00147DE4
		private static void OnEditorWorkspaceSizePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			ModelEditorControl modelEditorControl = (ModelEditorControl)dependencyObject;
			BoundingBoxData size = (BoundingBoxData)dependencyPropertyChangedEventArgs.NewValue;
			modelEditorControl.MyUpdateVisibleArea(size);
			modelEditorControl.MyUpdateEditorWorkspaceBackgroundColor();
			modelEditorControl.SetCameraZoomParameters();
		}

		// Token: 0x06004A9B RID: 19099 RVA: 0x00149C24 File Offset: 0x00147E24
		private static void OnEditorWorkspaceWithAnnotationsSizePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			ModelEditorControl modelEditorControl = (ModelEditorControl)dependencyObject;
			BoundingBoxData boundingBoxData = (BoundingBoxData)dependencyPropertyChangedEventArgs.NewValue;
			modelEditorControl.fitToRectTemp = new StructurePoint.CoreAssets.Infrastructure.Data.Rect3D?(boundingBoxData.#Hvc());
		}

		// Token: 0x06004A9C RID: 19100 RVA: 0x00149C60 File Offset: 0x00147E60
		private static void OnCameraDistancePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
		{
			ModelEditorControl modelEditorControl = dependencyObject as ModelEditorControl;
			if (modelEditorControl != null)
			{
				double distance = Convert.ToDouble(args.NewValue, CultureInfo.InvariantCulture);
				modelEditorControl.OnCameraDistanceChanged(new CameraDistanceChangedEventArgs(distance, modelEditorControl.ModelScale));
			}
		}

		// Token: 0x06004A9D RID: 19101 RVA: 0x00149CA8 File Offset: 0x00147EA8
		private static void OnCameraWidthPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
		{
			ModelEditorControl modelEditorControl = dependencyObject as ModelEditorControl;
			if (modelEditorControl != null)
			{
				double width = Convert.ToDouble(args.NewValue, CultureInfo.InvariantCulture);
				modelEditorControl.OnCameraWidthChanged(new CameraWidthChangedEventArgs(width, modelEditorControl.ModelScale));
			}
		}

		// Token: 0x06004A9E RID: 19102 RVA: 0x00149CF0 File Offset: 0x00147EF0
		private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			ModelEditorControl modelEditorControl = (ModelEditorControl)d;
			double num = (double)e.NewValue;
			if (num > 0.0)
			{
				modelEditorControl.MainViewport.MinWidth = num;
			}
		}

		// Token: 0x140000FA RID: 250
		// (add) Token: 0x06004A9F RID: 19103 RVA: 0x00149D38 File Offset: 0x00147F38
		// (remove) Token: 0x06004AA0 RID: 19104 RVA: 0x00149D7C File Offset: 0x00147F7C
		public event EventHandler<CameraDistanceChangedEventArgs> CameraDistanceChanged;

		// Token: 0x140000FB RID: 251
		// (add) Token: 0x06004AA1 RID: 19105 RVA: 0x00149DC0 File Offset: 0x00147FC0
		// (remove) Token: 0x06004AA2 RID: 19106 RVA: 0x00149E04 File Offset: 0x00148004
		public event EventHandler<CameraWidthChangedEventArgs> CameraWidthChanged;

		// Token: 0x140000FC RID: 252
		// (add) Token: 0x06004AA3 RID: 19107 RVA: 0x00149E48 File Offset: 0x00148048
		// (remove) Token: 0x06004AA4 RID: 19108 RVA: 0x00149E8C File Offset: 0x0014808C
		public event EventHandler CameraDistanceOrAttitudeOrHeadingChanged;

		// Token: 0x140000FD RID: 253
		// (add) Token: 0x06004AA5 RID: 19109 RVA: 0x00149ED0 File Offset: 0x001480D0
		// (remove) Token: 0x06004AA6 RID: 19110 RVA: 0x00149F14 File Offset: 0x00148114
		public event EventHandler CameraChanged;

		// Token: 0x140000FE RID: 254
		// (add) Token: 0x06004AA7 RID: 19111 RVA: 0x00149F58 File Offset: 0x00148158
		// (remove) Token: 0x06004AA8 RID: 19112 RVA: 0x00149F9C File Offset: 0x0014819C
		public event EventHandler<MouseEventArgs> EditorMouseMove;

		// Token: 0x140000FF RID: 255
		// (add) Token: 0x06004AA9 RID: 19113 RVA: 0x00149FE0 File Offset: 0x001481E0
		// (remove) Token: 0x06004AAA RID: 19114 RVA: 0x0014A024 File Offset: 0x00148224
		public event EventHandler<MouseEventArgs> EditorMouseLeave;

		// Token: 0x14000100 RID: 256
		// (add) Token: 0x06004AAB RID: 19115 RVA: 0x0014A068 File Offset: 0x00148268
		// (remove) Token: 0x06004AAC RID: 19116 RVA: 0x0014A0AC File Offset: 0x001482AC
		public event EventHandler<MouseButtonEventArgs> EditorMouseLeftButtonDown;

		// Token: 0x14000101 RID: 257
		// (add) Token: 0x06004AAD RID: 19117 RVA: 0x0014A0F0 File Offset: 0x001482F0
		// (remove) Token: 0x06004AAE RID: 19118 RVA: 0x0014A134 File Offset: 0x00148334
		public event EventHandler<MouseButtonEventArgs> EditorMouseLeftButtonUp;

		// Token: 0x14000102 RID: 258
		// (add) Token: 0x06004AAF RID: 19119 RVA: 0x0014A178 File Offset: 0x00148378
		// (remove) Token: 0x06004AB0 RID: 19120 RVA: 0x0014A1BC File Offset: 0x001483BC
		public event EventHandler<MouseButtonEventArgs> PreviewEditorMouseLeftButtonDown;

		// Token: 0x14000103 RID: 259
		// (add) Token: 0x06004AB1 RID: 19121 RVA: 0x0014A200 File Offset: 0x00148400
		// (remove) Token: 0x06004AB2 RID: 19122 RVA: 0x0014A244 File Offset: 0x00148444
		public event EventHandler<MouseButtonEventArgs> EditorMouseRightButtonDown;

		// Token: 0x14000104 RID: 260
		// (add) Token: 0x06004AB3 RID: 19123 RVA: 0x0014A288 File Offset: 0x00148488
		// (remove) Token: 0x06004AB4 RID: 19124 RVA: 0x0014A2CC File Offset: 0x001484CC
		public event EventHandler<MouseButtonEventArgs> EditorMouseRightButtonUp;

		// Token: 0x14000105 RID: 261
		// (add) Token: 0x06004AB5 RID: 19125 RVA: 0x0014A310 File Offset: 0x00148510
		// (remove) Token: 0x06004AB6 RID: 19126 RVA: 0x0014A354 File Offset: 0x00148554
		public event EventHandler<KeyEventArgs> EditorKeyDown;

		// Token: 0x14000106 RID: 262
		// (add) Token: 0x06004AB7 RID: 19127 RVA: 0x0014A398 File Offset: 0x00148598
		// (remove) Token: 0x06004AB8 RID: 19128 RVA: 0x0014A3DC File Offset: 0x001485DC
		public event EventHandler<KeyEventArgs> EditorKeyUp;

		// Token: 0x14000107 RID: 263
		// (add) Token: 0x06004AB9 RID: 19129 RVA: 0x0014A420 File Offset: 0x00148620
		// (remove) Token: 0x06004ABA RID: 19130 RVA: 0x0014A464 File Offset: 0x00148664
		public event EventHandler<SelectedItemChangedEventArgs<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>> EditorMousePositionChanged;

		// Token: 0x14000108 RID: 264
		// (add) Token: 0x06004ABB RID: 19131 RVA: 0x0014A4A8 File Offset: 0x001486A8
		// (remove) Token: 0x06004ABC RID: 19132 RVA: 0x0014A4EC File Offset: 0x001486EC
		public event EventHandler<SelectedValueChangedEventArgs<double>> ModelScaleChanged;

		// Token: 0x06004ABD RID: 19133 RVA: 0x0014A530 File Offset: 0x00148730
		protected void OnModelScaleChanged(SelectedValueChangedEventArgs<double> e)
		{
			EventHandler<SelectedValueChangedEventArgs<double>> modelScaleChanged = this.ModelScaleChanged;
			if (modelScaleChanged != null)
			{
				modelScaleChanged(this, e);
			}
		}

		// Token: 0x06004ABE RID: 19134 RVA: 0x0003EE34 File Offset: 0x0003D034
		protected void ExecuteHandler<T>(EventHandler<T> eventHandler, T eventArgs)
		{
			if (!this.TargetPositionCamera.IsRotating && !this.SuspendEvents && eventHandler != null)
			{
				eventHandler(this, eventArgs);
			}
		}

		// Token: 0x06004ABF RID: 19135 RVA: 0x0003EE62 File Offset: 0x0003D062
		protected void ExecuteCameraHandler<T>(EventHandler<T> eventHandler, T eventArgs)
		{
			if (!this.TargetPositionCamera.IsRotating && !this.SuspendCameraEvents && eventHandler != null)
			{
				eventHandler(this, eventArgs);
			}
		}

		// Token: 0x06004AC0 RID: 19136 RVA: 0x0003EE90 File Offset: 0x0003D090
		protected void OnEditorMousePositionChanged(StructurePoint.CoreAssets.Infrastructure.Data.Point3D previousPosition, StructurePoint.CoreAssets.Infrastructure.Data.Point3D currentPosition)
		{
			this.ExecuteHandler<SelectedItemChangedEventArgs<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>>(this.EditorMousePositionChanged, new SelectedItemChangedEventArgs<StructurePoint.CoreAssets.Infrastructure.Data.Point3D>(previousPosition, currentPosition));
		}

		// Token: 0x06004AC1 RID: 19137 RVA: 0x0003EEB1 File Offset: 0x0003D0B1
		protected void OnEditorKeyDown(KeyEventArgs eventArgs)
		{
			this.ExecuteHandler<KeyEventArgs>(this.EditorKeyDown, eventArgs);
		}

		// Token: 0x06004AC2 RID: 19138 RVA: 0x0003EECC File Offset: 0x0003D0CC
		protected void OnEditorKeyUp(KeyEventArgs eventArgs)
		{
			this.ExecuteHandler<KeyEventArgs>(this.EditorKeyUp, eventArgs);
		}

		// Token: 0x06004AC3 RID: 19139 RVA: 0x0003EEE7 File Offset: 0x0003D0E7
		protected void OnEditorMouseRightButtonDown(MouseButtonEventArgs mouseButtonEventArgs)
		{
			this.ExecuteHandler<MouseButtonEventArgs>(this.EditorMouseRightButtonDown, mouseButtonEventArgs);
		}

		// Token: 0x06004AC4 RID: 19140 RVA: 0x0003EF02 File Offset: 0x0003D102
		protected void OnEditorMouseRightButtonUp(MouseButtonEventArgs mouseButtonEventArgs)
		{
			this.ExecuteHandler<MouseButtonEventArgs>(this.EditorMouseRightButtonUp, mouseButtonEventArgs);
		}

		// Token: 0x06004AC5 RID: 19141 RVA: 0x0014A55C File Offset: 0x0014875C
		protected void OnEditorMouseMove(MouseEventArgs mouseEventArgs3D)
		{
			if (this.areMouseMoveEventsEnabled)
			{
				this.ExecuteHandler<MouseEventArgs>(this.EditorMouseMove, mouseEventArgs3D);
			}
			StructurePoint.CoreAssets.Infrastructure.Data.Point editorPosition = this.GetEditorPosition(mouseEventArgs3D);
			StructurePoint.CoreAssets.Infrastructure.Data.Point3D point3D;
			if (this.GetMousePositionOnXYPlane(editorPosition, out point3D))
			{
				if (this.areMouseMoveEventsEnabled)
				{
					this.OnEditorMousePositionChanged(point3D, point3D);
				}
				this.MyUpdatePosition(point3D);
			}
		}

		// Token: 0x06004AC6 RID: 19142 RVA: 0x0003EF1D File Offset: 0x0003D11D
		private void OnEditorMouseLeave(MouseEventArgs mouseEventArgs)
		{
			this.ExecuteHandler<MouseEventArgs>(this.EditorMouseLeave, mouseEventArgs);
		}

		// Token: 0x06004AC7 RID: 19143 RVA: 0x0003EF38 File Offset: 0x0003D138
		protected void OnPreviewEditorMouseLeftButtonDown(MouseButtonEventArgs mouseButtonEventArgs)
		{
			this.ExecuteHandler<MouseButtonEventArgs>(this.PreviewEditorMouseLeftButtonDown, mouseButtonEventArgs);
		}

		// Token: 0x06004AC8 RID: 19144 RVA: 0x0003EF53 File Offset: 0x0003D153
		protected void OnEditorMouseLeftButtonDown(MouseButtonEventArgs mouseButtonEventArgs)
		{
			this.ExecuteHandler<MouseButtonEventArgs>(this.EditorMouseLeftButtonDown, mouseButtonEventArgs);
		}

		// Token: 0x06004AC9 RID: 19145 RVA: 0x0003EF6E File Offset: 0x0003D16E
		protected void OnEditorMouseLeftButtonUp(MouseButtonEventArgs mouseButtonEventArgs)
		{
			this.ExecuteHandler<MouseButtonEventArgs>(this.EditorMouseLeftButtonUp, mouseButtonEventArgs);
		}

		// Token: 0x06004ACA RID: 19146 RVA: 0x0003EF89 File Offset: 0x0003D189
		protected void OnCameraDistanceChanged(CameraDistanceChangedEventArgs cameraDistanceChangedEventArgs)
		{
			this.ExecuteCameraHandler<CameraDistanceChangedEventArgs>(this.CameraDistanceChanged, cameraDistanceChangedEventArgs);
		}

		// Token: 0x06004ACB RID: 19147 RVA: 0x0003EFA4 File Offset: 0x0003D1A4
		protected void OnCameraWidthChanged(CameraWidthChangedEventArgs cameraWidthChangedEventArgs)
		{
			this.ExecuteCameraHandler<CameraWidthChangedEventArgs>(this.CameraWidthChanged, cameraWidthChangedEventArgs);
		}

		// Token: 0x06004ACC RID: 19148 RVA: 0x0014A5B4 File Offset: 0x001487B4
		protected void OnCameraDistanceOrAttitudeOrHeadingChanged(EventArgs eventArgs)
		{
			EventHandler cameraDistanceOrAttitudeOrHeadingChanged = this.CameraDistanceOrAttitudeOrHeadingChanged;
			if (!this.SuspendCameraEvents && cameraDistanceOrAttitudeOrHeadingChanged != null)
			{
				cameraDistanceOrAttitudeOrHeadingChanged(this, EventArgs.Empty);
			}
		}

		// Token: 0x06004ACD RID: 19149 RVA: 0x0014A5EC File Offset: 0x001487EC
		[SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
		public void RaiseCameraChanged()
		{
			EventHandler cameraChanged = this.CameraChanged;
			if (!this.SuspendCameraEvents && cameraChanged != null)
			{
				cameraChanged(this, EventArgs.Empty);
			}
		}

		// Token: 0x06004ACE RID: 19150 RVA: 0x0014A624 File Offset: 0x00148824
		public void RegisterEvents(IEnumerable<ModelEditorControlEventType> modelEditorControlEventTypes)
		{
			ModelEditorPartialClass.RegisterEvents(modelEditorControlEventTypes, this.OverlayBorder, ref this.areMouseMoveEventsEnabled, new MouseButtonEventHandler(this.OverlayBorder_MouseLeftButtonDown), new MouseButtonEventHandler(this.OverlayBorder_PreviewMouseLeftButtonDown), new MouseButtonEventHandler(this.OverlayBorder_MouseLeftButtonUp), new MouseButtonEventHandler(this.OverlayBorder_MouseRightButtonDown), new MouseButtonEventHandler(this.OverlayBorder_MouseRightButtonUp));
		}

		// Token: 0x06004ACF RID: 19151 RVA: 0x0014A68C File Offset: 0x0014888C
		public void UnregisterEvents(IEnumerable<ModelEditorControlEventType> modelEditorControlEventTypes)
		{
			ModelEditorPartialClass.UnregisterEvents(modelEditorControlEventTypes, this.OverlayBorder, ref this.areMouseMoveEventsEnabled, new MouseButtonEventHandler(this.OverlayBorder_MouseLeftButtonDown), new MouseButtonEventHandler(this.OverlayBorder_PreviewMouseLeftButtonDown), new MouseButtonEventHandler(this.OverlayBorder_MouseLeftButtonUp), new MouseButtonEventHandler(this.OverlayBorder_MouseRightButtonDown), new MouseButtonEventHandler(this.OverlayBorder_MouseRightButtonUp));
		}

		// Token: 0x06004AD0 RID: 19152 RVA: 0x0014A6F4 File Offset: 0x001488F4
		private void Window_KeyUp(object sender, KeyEventArgs e)
		{
			if (!((Window)sender).IsActive)
			{
				return;
			}
			if (this.handleKeyUp)
			{
				if (e != null && e.Key == Key.Escape && this.MyTurnOffPanAndRotateTools())
				{
					return;
				}
				this.handleKeyUp = false;
				this.ExecuteHandler<KeyEventArgs>(this.EditorKeyUp, e);
			}
		}

		// Token: 0x06004AD1 RID: 19153 RVA: 0x0003EFBF File Offset: 0x0003D1BF
		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			if (!((Window)sender).IsActive)
			{
				return;
			}
			this.handleKeyUp = true;
			this.ExecuteHandler<KeyEventArgs>(this.EditorKeyDown, e);
		}

		// Token: 0x06004AD2 RID: 19154 RVA: 0x0003EFEF File Offset: 0x0003D1EF
		private void OverlayBorder_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			this.OnPreviewEditorMouseLeftButtonDown(e);
		}

		// Token: 0x06004AD3 RID: 19155 RVA: 0x0003F004 File Offset: 0x0003D204
		private void MyMouseRightButtonUp(object sender, RoutedEventArgs e)
		{
			if (this.state.PaneModeEnabled || this.state.RotateModeEnabled)
			{
				this.MyTurnOffPanAndRotateTools();
				e.Handled = true;
			}
		}

		// Token: 0x06004AD4 RID: 19156 RVA: 0x0003F03A File Offset: 0x0003D23A
		private void OverlayBorder_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (this.state.PaneModeEnabled || this.state.RotateModeEnabled)
			{
				this.MyTurnOffPanAndRotateTools();
				return;
			}
			this.OnEditorMouseRightButtonUp(e);
		}

		// Token: 0x06004AD5 RID: 19157 RVA: 0x0003F071 File Offset: 0x0003D271
		private void OverlayBorder_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			this.OnEditorMouseRightButtonDown(e);
		}

		// Token: 0x06004AD6 RID: 19158 RVA: 0x0003F086 File Offset: 0x0003D286
		private void OverlayBorder_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			this.OnEditorMouseLeftButtonUp(e);
		}

		// Token: 0x06004AD7 RID: 19159 RVA: 0x0003F09B File Offset: 0x0003D29B
		private void OverlayBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			this.OnEditorMouseLeftButtonDown(e);
		}

		// Token: 0x06004AD8 RID: 19160 RVA: 0x0003F0B0 File Offset: 0x0003D2B0
		private void OverlayBorder_MouseMove(object sender, MouseEventArgs e)
		{
			this.OnEditorMouseMove(e);
		}

		// Token: 0x06004AD9 RID: 19161 RVA: 0x0003F0C5 File Offset: 0x0003D2C5
		private void OverlayBorder_MouseLeave(object sender, MouseEventArgs e)
		{
			this.OnEditorMouseLeave(e);
		}

		// Token: 0x14000109 RID: 265
		// (add) Token: 0x06004ADA RID: 19162 RVA: 0x0014A750 File Offset: 0x00148950
		// (remove) Token: 0x06004ADB RID: 19163 RVA: 0x0014A794 File Offset: 0x00148994
		public event EventHandler<AdjustZoomToModelEventArgs> AdjustZoomToModelRequested;

		// Token: 0x06004ADC RID: 19164 RVA: 0x0014A7D8 File Offset: 0x001489D8
		protected void OnAdjustZoomToModelRequested(AdjustZoomToModelEventArgs e)
		{
			EventHandler<AdjustZoomToModelEventArgs> adjustZoomToModelRequested = this.AdjustZoomToModelRequested;
			if (adjustZoomToModelRequested != null)
			{
				adjustZoomToModelRequested(this, e);
			}
		}

		// Token: 0x170015D4 RID: 5588
		// (get) Token: 0x06004ADD RID: 19165 RVA: 0x0003F0DA File Offset: 0x0003D2DA
		// (set) Token: 0x06004ADE RID: 19166 RVA: 0x0003F0E6 File Offset: 0x0003D2E6
		internal ZoomPanel ZoomPanel { get; set; }

		// Token: 0x170015D5 RID: 5589
		// (get) Token: 0x06004ADF RID: 19167 RVA: 0x0003F0F7 File Offset: 0x0003D2F7
		// (set) Token: 0x06004AE0 RID: 19168 RVA: 0x0003F103 File Offset: 0x0003D303
		internal IPanelItem ZoomPanelItem { get; set; }

		// Token: 0x170015D6 RID: 5590
		// (get) Token: 0x06004AE1 RID: 19169 RVA: 0x0003F114 File Offset: 0x0003D314
		// (set) Token: 0x06004AE2 RID: 19170 RVA: 0x0003F120 File Offset: 0x0003D320
		internal NewViewCubeControl ViewCube { get; set; }

		// Token: 0x170015D7 RID: 5591
		// (get) Token: 0x06004AE3 RID: 19171 RVA: 0x0003F131 File Offset: 0x0003D331
		// (set) Token: 0x06004AE4 RID: 19172 RVA: 0x0003F13D File Offset: 0x0003D33D
		internal IPanelItem ViewCubePanelItem { get; set; }

		// Token: 0x170015D8 RID: 5592
		// (get) Token: 0x06004AE5 RID: 19173 RVA: 0x0003F14E File Offset: 0x0003D34E
		// (set) Token: 0x06004AE6 RID: 19174 RVA: 0x0003F15A File Offset: 0x0003D35A
		internal CheckBoxSeriesControl VisibilityItemsControl { get; set; }

		// Token: 0x170015D9 RID: 5593
		// (get) Token: 0x06004AE7 RID: 19175 RVA: 0x0003F16B File Offset: 0x0003D36B
		// (set) Token: 0x06004AE8 RID: 19176 RVA: 0x0003F177 File Offset: 0x0003D377
		internal IPanelItem VisibilityPanelItem { get; set; }

		// Token: 0x170015DA RID: 5594
		// (get) Token: 0x06004AE9 RID: 19177 RVA: 0x0003F188 File Offset: 0x0003D388
		// (set) Token: 0x06004AEA RID: 19178 RVA: 0x0003F194 File Offset: 0x0003D394
		internal NavigationPanel NavigationPanel { get; set; }

		// Token: 0x170015DB RID: 5595
		// (get) Token: 0x06004AEB RID: 19179 RVA: 0x0003F1A5 File Offset: 0x0003D3A5
		// (set) Token: 0x06004AEC RID: 19180 RVA: 0x0003F1B1 File Offset: 0x0003D3B1
		internal IPanelItem NavigationPanelItem { get; set; }

		// Token: 0x170015DC RID: 5596
		// (get) Token: 0x06004AED RID: 19181 RVA: 0x0003F1C2 File Offset: 0x0003D3C2
		// (set) Token: 0x06004AEE RID: 19182 RVA: 0x0003F1CE File Offset: 0x0003D3CE
		internal PanelControls2D PanelControls2D { get; set; }

		// Token: 0x170015DD RID: 5597
		// (get) Token: 0x06004AEF RID: 19183 RVA: 0x0003F1DF File Offset: 0x0003D3DF
		// (set) Token: 0x06004AF0 RID: 19184 RVA: 0x0003F1EB File Offset: 0x0003D3EB
		internal IPanelItem PanelItemControls2D { get; set; }

		// Token: 0x170015DE RID: 5598
		// (get) Token: 0x06004AF1 RID: 19185 RVA: 0x0003F1FC File Offset: 0x0003D3FC
		// (set) Token: 0x06004AF2 RID: 19186 RVA: 0x0003F208 File Offset: 0x0003D408
		internal PanelControls3D PanelControls3D { get; set; }

		// Token: 0x170015DF RID: 5599
		// (get) Token: 0x06004AF3 RID: 19187 RVA: 0x0003F219 File Offset: 0x0003D419
		// (set) Token: 0x06004AF4 RID: 19188 RVA: 0x0003F225 File Offset: 0x0003D425
		internal IPanelItem PanelItemControls3D { get; set; }

		// Token: 0x170015E0 RID: 5600
		// (get) Token: 0x06004AF5 RID: 19189 RVA: 0x0003F236 File Offset: 0x0003D436
		// (set) Token: 0x06004AF6 RID: 19190 RVA: 0x0003F242 File Offset: 0x0003D442
		internal UserControl QuickOptionsPanel { get; set; }

		// Token: 0x170015E1 RID: 5601
		// (get) Token: 0x06004AF7 RID: 19191 RVA: 0x0003F253 File Offset: 0x0003D453
		// (set) Token: 0x06004AF8 RID: 19192 RVA: 0x0003F25F File Offset: 0x0003D45F
		internal IPanelItem QuickOptionsPanelItem { get; set; }

		// Token: 0x170015E2 RID: 5602
		// (get) Token: 0x06004AF9 RID: 19193 RVA: 0x0003F270 File Offset: 0x0003D470
		// (set) Token: 0x06004AFA RID: 19194 RVA: 0x0003F27C File Offset: 0x0003D47C
		internal ZoomToWindowTool ZoomToWindowTool { get; set; }

		// Token: 0x170015E3 RID: 5603
		// (get) Token: 0x06004AFB RID: 19195 RVA: 0x0003F28D File Offset: 0x0003D48D
		// (set) Token: 0x06004AFC RID: 19196 RVA: 0x0003F299 File Offset: 0x0003D499
		internal RadToggleButton PanCommandButton { get; set; }

		// Token: 0x170015E4 RID: 5604
		// (get) Token: 0x06004AFD RID: 19197 RVA: 0x0003F2AA File Offset: 0x0003D4AA
		// (set) Token: 0x06004AFE RID: 19198 RVA: 0x0003F2B6 File Offset: 0x0003D4B6
		public RadToggleButton ZoomToWindowButton { get; set; }

		// Token: 0x170015E5 RID: 5605
		// (get) Token: 0x06004AFF RID: 19199 RVA: 0x0003F2C7 File Offset: 0x0003D4C7
		// (set) Token: 0x06004B00 RID: 19200 RVA: 0x0003F2D3 File Offset: 0x0003D4D3
		public RadToggleButton Rotate3DButton { get; set; }

		// Token: 0x170015E6 RID: 5606
		// (get) Token: 0x06004B01 RID: 19201 RVA: 0x0003F2E4 File Offset: 0x0003D4E4
		// (set) Token: 0x06004B02 RID: 19202 RVA: 0x0003F2F0 File Offset: 0x0003D4F0
		public RadToggleButton TranslateButton { get; set; }

		// Token: 0x170015E7 RID: 5607
		// (get) Token: 0x06004B03 RID: 19203 RVA: 0x0003F301 File Offset: 0x0003D501
		// (set) Token: 0x06004B04 RID: 19204 RVA: 0x0003F30D File Offset: 0x0003D50D
		public RadToggleButton Panel3DCustomButton1 { get; set; }

		// Token: 0x170015E8 RID: 5608
		// (get) Token: 0x06004B05 RID: 19205 RVA: 0x0003F31E File Offset: 0x0003D51E
		// (set) Token: 0x06004B06 RID: 19206 RVA: 0x0003F32A File Offset: 0x0003D52A
		public RadToggleButton Panel3DShowHideViewCubeButton { get; set; }

		// Token: 0x170015E9 RID: 5609
		// (get) Token: 0x06004B07 RID: 19207 RVA: 0x0003F33B File Offset: 0x0003D53B
		// (set) Token: 0x06004B08 RID: 19208 RVA: 0x0003F347 File Offset: 0x0003D547
		internal MouseAndKeyboardCondition CurrentTranslateViewCondition { get; set; }

		// Token: 0x170015EA RID: 5610
		// (get) Token: 0x06004B09 RID: 19209 RVA: 0x0003F358 File Offset: 0x0003D558
		// (set) Token: 0x06004B0A RID: 19210 RVA: 0x0003F364 File Offset: 0x0003D564
		internal MouseAndKeyboardCondition CurrentRotateViewCondition { get; set; }

		// Token: 0x170015EB RID: 5611
		// (get) Token: 0x06004B0B RID: 19211 RVA: 0x0003F375 File Offset: 0x0003D575
		// (set) Token: 0x06004B0C RID: 19212 RVA: 0x0003F381 File Offset: 0x0003D581
		public byte[] CustomButtonBasicModeCursor { get; set; }

		// Token: 0x170015EC RID: 5612
		// (get) Token: 0x06004B0D RID: 19213 RVA: 0x0003F392 File Offset: 0x0003D592
		// (set) Token: 0x06004B0E RID: 19214 RVA: 0x0003F39E File Offset: 0x0003D59E
		public byte[] CustomButtonAlternateModeCursor { get; set; }

		// Token: 0x170015ED RID: 5613
		// (get) Token: 0x06004B0F RID: 19215 RVA: 0x0003F3AF File Offset: 0x0003D5AF
		public ModelEditorCursorState CursorState
		{
			get
			{
				return this.state;
			}
		}

		// Token: 0x06004B10 RID: 19216 RVA: 0x0014A804 File Offset: 0x00148A04
		public void RestoreMouseCameraControllerCursor()
		{
			this.state.CustomButtonBasicModeEnabled = (this.state.CustomButtonAlternateModeEnabled = false);
			this.MyRestoreMouseCameraControllerCursor();
		}

		// Token: 0x06004B11 RID: 19217 RVA: 0x0003F3BB File Offset: 0x0003D5BB
		public void SetMouseCameraControllerCursorMoveHorizontally()
		{
			if (this.CustomButtonBasicModeCursor != null)
			{
				this.MySetMouseCameraControllerCursor(this.CustomButtonBasicModeCursor);
				this.state.CustomButtonBasicModeEnabled = true;
				this.state.CustomButtonAlternateModeEnabled = false;
			}
		}

		// Token: 0x06004B12 RID: 19218 RVA: 0x0003F3F5 File Offset: 0x0003D5F5
		public void SetMouseCameraControllerCursorMoveVertically()
		{
			if (this.CustomButtonAlternateModeCursor != null)
			{
				this.MySetMouseCameraControllerCursor(this.CustomButtonAlternateModeCursor);
				this.state.CustomButtonAlternateModeEnabled = true;
				this.state.CustomButtonBasicModeEnabled = false;
			}
		}

		// Token: 0x06004B13 RID: 19219 RVA: 0x0003F42F File Offset: 0x0003D62F
		public void ResetToDefaultViewCubePosition()
		{
			this.ViewCube.NavigateToDefaultPosition();
		}

		// Token: 0x06004B14 RID: 19220 RVA: 0x0014A840 File Offset: 0x00148A40
		private void MySetupViewControls()
		{
			FloatingControlsPanel viewControlsPanel = this.ViewControlsPanel;
			IEnumerable<IPanelItem> enumerable = this.builtInTools;
			if (7 != 0)
			{
				viewControlsPanel.BuiltInTools = enumerable;
			}
			this.ViewCubeHostControl.ViewCubeTools = this.viewCubeTools;
			this.previousControlCursor = System.Windows.Input.Cursors.Arrow;
			this.MouseCameraController.RotationCursor = null;
			ZoomPanel zoomPanel = new ZoomPanel();
			this.MySetupViewCubePanel();
			this.MySetUpNavigationPanel();
			this.MySetup3DControlsPanel();
			this.MySetupZoomPanel(zoomPanel);
			this.MySetup2DControlsPanel(zoomPanel);
			this.MySetupVisibilityPanel();
			this.MySetupQuickOptionsPanel();
			ModelEditorViewControlsHelper.SetupAdditionalTools(this);
			ModelEditorViewControlsHelper.SetupSelectedPositionProperty(this);
			ModelEditorViewControlsHelper.SetupTitleProperty(this);
			this.ViewControlsPanel.ControlsVisibilityChanged += this.ViewControlsPanel_ControlsVisibilityChanged;
			this.MouseCameraController.CameraMoveStarted += this.MouseCameraController_CameraMoveStarted;
			this.MouseCameraController.CameraMoveEnded += this.MouseCameraController_CameraMoveEnded;
			this.MouseCameraController.CameraRotateStarted += this.MouseCameraController_CameraRotateStarted;
			this.MouseCameraController.CameraRotateEnded += this.MouseCameraController_CameraRotateEnded;
			base.MouseRightButtonUp += new MouseButtonEventHandler(this.MyMouseRightButtonUp);
			this.CurrentTranslateViewCondition = MouseAndKeyboardCondition.MiddleMouseButtonPressed;
			this.CurrentRotateViewCondition = (MouseAndKeyboardCondition.MiddleMouseButtonPressed | MouseAndKeyboardCondition.ShiftKey);
		}

		// Token: 0x06004B15 RID: 19221 RVA: 0x0003F448 File Offset: 0x0003D648
		private void ViewControlsPanel_ControlsVisibilityChanged(object sender, RoutedEventArgs e)
		{
			this.PanelControls2DVisibility = this.ViewControlsPanel.IsControls2DCollapsed;
			this.PanelControls3DVisibility = this.ViewControlsPanel.IsControls3DCollapsed;
		}

		// Token: 0x06004B16 RID: 19222 RVA: 0x0014A980 File Offset: 0x00148B80
		private void MySetup2DControlsPanel(ZoomPanel zoomPanel)
		{
			this.PanelItemControls2D = ModelEditorViewControlsHelper.CreateAndSetup2DControlsPanelItem(this, new EventHandler(this.ActionsPanel_ResetButtonClicked), new RoutedEventHandler(this.ResetToModel_Click), new RoutedEventHandler(this.ActionsPanel_PanButtonClicked), new RoutedEventHandler(this.ActionsPanel_ZoomToSelectedWindowButtonClicked), new RoutedEventHandler(zoomPanel.PlusButton_Click), new RoutedEventHandler(zoomPanel.MinusButton_Click));
			this.PanelControls2D = (PanelControls2D)this.PanelItemControls2D.Content;
			this.PanCommandButton = this.PanelControls2D.PanButton;
			this.ZoomToWindowButton = this.PanelControls2D.ZoomToWindowButton;
			this.TranslateButton = this.PanelControls2D.PanButton;
			this.ZoomToWindowTool = new ZoomToWindowTool(this);
			this.ZoomToWindowTool.DeactivationRequested += this.ZoomToWindowTool_DeactivationRequested;
			this.builtInTools.Add(this.PanelItemControls2D);
		}

		// Token: 0x06004B17 RID: 19223 RVA: 0x0003F478 File Offset: 0x0003D678
		private void ZoomToWindowTool_DeactivationRequested(object sender, EventArgs e)
		{
			this.MyDeactivateZoomToWindowMode(true);
		}

		// Token: 0x06004B18 RID: 19224 RVA: 0x0003F489 File Offset: 0x0003D689
		private void MySetup3DControlsPanel()
		{
			ModelEditorPartialClass.Setup3DControlsPanel(this.ViewCubeHostControl, this, new RoutedEventHandler(this.ActionsPanel_ShowHideViewCubeButtonClicked), new RoutedEventHandler(this.ActionsPanelRotate3DButtonClicked), this.builtInTools);
		}

		// Token: 0x06004B19 RID: 19225 RVA: 0x0003F42F File Offset: 0x0003D62F
		private void ActionsPanel_ResetButtonClicked(object sender, EventArgs e)
		{
			this.ViewCube.NavigateToDefaultPosition();
		}

		// Token: 0x06004B1A RID: 19226 RVA: 0x0003F4C2 File Offset: 0x0003D6C2
		private void MySetUpNavigationPanel()
		{
			this.NavigationPanelItem = ModelEditorViewControlsHelper.CreateNavigationPanelItem(this);
			this.NavigationPanel = (NavigationPanel)this.NavigationPanelItem.Content;
		}

		// Token: 0x06004B1B RID: 19227 RVA: 0x0003F4F2 File Offset: 0x0003D6F2
		private void MySetupVisibilityPanel()
		{
			this.VisibilityPanelItem = ModelEditorViewControlsHelper.CreateAndSetupVisibilityPanel(this);
			this.VisibilityItemsControl = (CheckBoxSeriesControl)this.VisibilityPanelItem.Content;
		}

		// Token: 0x06004B1C RID: 19228 RVA: 0x0014AA7C File Offset: 0x00148C7C
		private void MySetupViewCubePanel()
		{
			this.ViewCubePanelItem = ModelEditorViewControlsHelper.CreateAndSetupViewCubePanel(this);
			this.ViewCube = (NewViewCubeControl)this.ViewCubePanelItem.Content;
			this.viewCubeTools.Add(this.ViewCubePanelItem);
		}

		// Token: 0x06004B1D RID: 19229 RVA: 0x0003F522 File Offset: 0x0003D722
		private void MySetupZoomPanel(ZoomPanel zoomPanel)
		{
			this.ZoomPanelItem = ModelEditorViewControlsHelper.CreateAndSetupZoomPanel(this, new EventHandler(this.ZoomPanel_LargeCameraDistanceChange), zoomPanel);
			this.ZoomPanel = (ZoomPanel)this.ZoomPanelItem.Content;
		}

		// Token: 0x06004B1E RID: 19230 RVA: 0x0014AAC8 File Offset: 0x00148CC8
		private void MySetupQuickOptionsPanel()
		{
			this.QuickOptionsPanelItem = ModelEditorViewControlsHelper.CreateAndSetupQuickOptionsPanel(this);
			this.QuickOptionsPanel = (UserControl)this.QuickOptionsPanelItem.Content;
			this.builtInTools.Add(this.QuickOptionsPanelItem);
		}

		// Token: 0x06004B1F RID: 19231 RVA: 0x0003F55F File Offset: 0x0003D75F
		private void ZoomPanel_LargeCameraDistanceChange(object sender, EventArgs e)
		{
			this.OnModelScaleChanged(new SelectedValueChangedEventArgs<double>(this.ModelScale));
		}

		// Token: 0x06004B20 RID: 19232 RVA: 0x0003F57E File Offset: 0x0003D77E
		private void ActionsPanel_ShowHideViewCubeButtonClicked(object sender, RoutedEventArgs e)
		{
			ModelEditorPartialClass.ActionsPanel_ShowHideViewCubeButtonClicked(this.ViewCubeHostControl);
		}

		// Token: 0x06004B21 RID: 19233 RVA: 0x0014AB14 File Offset: 0x00148D14
		private void ResetToModel_Click(object sender, RoutedEventArgs e)
		{
			ModelEditorPartialClass.ResetToModel_Click(new Action<AdjustZoomToModelEventArgs>(this.OnAdjustZoomToModelRequested), new Action<StructurePoint.CoreAssets.Infrastructure.Data.Rect3D, bool>(this.FitCameraPositionToRectImpl));
			this.RefreshModelScale();
			this.OnCameraDistanceChanged(new CameraDistanceChangedEventArgs(this.CameraDistance, this.ModelScale));
			this.OnModelScaleChanged(new SelectedValueChangedEventArgs<double>(this.ModelScale));
		}

		// Token: 0x06004B22 RID: 19234 RVA: 0x0003F593 File Offset: 0x0003D793
		private bool MyTurnOffPanAndRotateTools()
		{
			return this.DisableRotate3DMode() || this.DisablePanMode() || this.DisableZoomToWindowMode(false);
		}

		// Token: 0x06004B23 RID: 19235 RVA: 0x0003F5BA File Offset: 0x0003D7BA
		private void MouseCameraController_CameraRotateEnded(object sender, EventArgs e)
		{
			this.MyRestoreMouseCameraControllerCursor();
		}

		// Token: 0x06004B24 RID: 19236 RVA: 0x0003F5CA File Offset: 0x0003D7CA
		private void MouseCameraController_CameraRotateStarted(object sender, EventArgs e)
		{
			this.MySetMouseCameraControllerCursor(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.Rotate3D);
		}

		// Token: 0x06004B25 RID: 19237 RVA: 0x0003F5BA File Offset: 0x0003D7BA
		private void MouseCameraController_CameraMoveEnded(object sender, EventArgs e)
		{
			this.MyRestoreMouseCameraControllerCursor();
		}

		// Token: 0x06004B26 RID: 19238 RVA: 0x0003F5E3 File Offset: 0x0003D7E3
		private void MouseCameraController_CameraMoveStarted(object sender, EventArgs e)
		{
			this.MySetMouseCameraControllerCursor(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.PanCursorMouseDown);
		}

		// Token: 0x06004B27 RID: 19239 RVA: 0x0003F5FC File Offset: 0x0003D7FC
		private void MyRestoreMouseCameraControllerCursor()
		{
			ModelEditorPartialClass.RestoreMouseCameraControllerCursor(this.state, new Action<byte[]>(this.MySetMouseCameraControllerCursor), this, this.previousControlCursor, this.CustomButtonBasicModeCursor, this.CustomButtonAlternateModeCursor);
		}

		// Token: 0x06004B28 RID: 19240 RVA: 0x0003F634 File Offset: 0x0003D834
		private void MySetMouseCameraControllerCursor(byte[] cursorData)
		{
			ModelEditorPartialClass.SetCameraControllerCursor(cursorData, this, this.MouseCameraController);
		}

		// Token: 0x06004B29 RID: 19241 RVA: 0x0003F64F File Offset: 0x0003D84F
		private void MyApplyRotateCursor()
		{
			ModelEditorPartialClass.ApplyRotateCursor(new Action<Cursor>(this.MyApplyControlCursor));
		}

		// Token: 0x06004B2A RID: 19242 RVA: 0x0003F66A File Offset: 0x0003D86A
		private void MyApplyTranslateCursor()
		{
			ModelEditorPartialClass.ApplyTranslateCursor(new Action<Cursor>(this.MyApplyControlCursor));
		}

		// Token: 0x06004B2B RID: 19243 RVA: 0x0003F685 File Offset: 0x0003D885
		private void MyRestoreControlCursor()
		{
			base.Cursor = this.previousControlCursor;
		}

		// Token: 0x06004B2C RID: 19244 RVA: 0x0003F69F File Offset: 0x0003D89F
		private void MyApplyControlCursor(Cursor cursor)
		{
			if (base.Cursor != null)
			{
				this.previousControlCursor = base.Cursor;
			}
			base.Cursor = cursor;
		}

		// Token: 0x06004B2D RID: 19245 RVA: 0x0003F6C8 File Offset: 0x0003D8C8
		private void MyRestoreRotateOrTranslateModeCursor()
		{
			this.MyRestoreMouseCameraControllerCursor();
			this.MyRestoreControlCursor();
		}

		// Token: 0x06004B2E RID: 19246 RVA: 0x0014AB7C File Offset: 0x00148D7C
		private void ActionsPanel_PanButtonClicked(object sender, RoutedEventArgs e)
		{
			ModelEditorPartialClass.ActionsPanel_PanButtonClicked(this.PanCommandButton, new Func<bool, bool>(this.DisableZoomToWindowMode), new Func<bool>(this.DisableRotate3DMode), new Action(this.MyEnablePanMode), new Action(this.MyDisablePanMode));
		}

		// Token: 0x06004B2F RID: 19247 RVA: 0x0014ABD4 File Offset: 0x00148DD4
		public void ActionsPanelRotate3DButtonClicked(object sender, RoutedEventArgs e)
		{
			ModelEditorPartialClass.ActionsPanel_Rotate3DButtonClicked(this.Rotate3DButton, new Func<bool>(this.DisablePanMode), new Func<bool, bool>(this.DisableZoomToWindowMode), new Action(this.MyEnableRotate3DMode), new Action(this.MyDisableRotate3DMode));
		}

		// Token: 0x06004B30 RID: 19248 RVA: 0x0014AC2C File Offset: 0x00148E2C
		private void MyEnablePanMode()
		{
			ModelEditorCursorState modelEditorCursorState = this.state;
			bool paneModeEnabled = true;
			if (!false)
			{
				modelEditorCursorState.PaneModeEnabled = paneModeEnabled;
			}
			ModelEditorPartialClass.EnablePanMode(new Action(this.MyApplyTranslateCursor), this, new Action<MouseAndKeyboardCondition>(this.MyRefreshRotateViewCondition));
			this.SuspendEvents = true;
		}

		// Token: 0x06004B31 RID: 19249 RVA: 0x0003F6E2 File Offset: 0x0003D8E2
		private void MyDisablePanMode()
		{
			ModelEditorPartialClass.DisablePanMode(new Action(this.MyRestoreRotateOrTranslateModeCursor), this, new Action<MouseAndKeyboardCondition>(this.MyRefreshRotateViewCondition));
			this.SuspendEvents = false;
			this.state.PaneModeEnabled = false;
		}

		// Token: 0x06004B32 RID: 19250 RVA: 0x0014AC7C File Offset: 0x00148E7C
		private void MyEnableRotate3DMode()
		{
			ModelEditorCursorState modelEditorCursorState = this.state;
			bool rotateModeEnabled = true;
			if (!false)
			{
				modelEditorCursorState.RotateModeEnabled = rotateModeEnabled;
			}
			ModelEditorPartialClass.EnableRotate3DMode(new Action(this.MyApplyRotateCursor), this, new Action<MouseAndKeyboardCondition>(this.MyRefreshTranslateViewCondition));
			this.SuspendEvents = true;
		}

		// Token: 0x06004B33 RID: 19251 RVA: 0x0003F721 File Offset: 0x0003D921
		private void MyDisableRotate3DMode()
		{
			ModelEditorPartialClass.DisableRotate3DMode(new Action(this.MyRestoreRotateOrTranslateModeCursor), this, new Action<MouseAndKeyboardCondition>(this.MyRefreshTranslateViewCondition));
			this.SuspendEvents = false;
			this.state.RotateModeEnabled = false;
		}

		// Token: 0x06004B34 RID: 19252 RVA: 0x0003F760 File Offset: 0x0003D960
		private void MyRefreshRotateViewCondition(MouseAndKeyboardCondition rotateViewCondition)
		{
			this.MouseCameraController.RotateCameraConditions = ModelEditorEnumsHelper.ConvertToProviderValue(rotateViewCondition);
		}

		// Token: 0x06004B35 RID: 19253 RVA: 0x0003F77F File Offset: 0x0003D97F
		private void MyRefreshTranslateViewCondition(MouseAndKeyboardCondition translateViewCondition)
		{
			this.MouseCameraController.MoveCameraConditions = ModelEditorEnumsHelper.ConvertToProviderValue(translateViewCondition);
		}

		// Token: 0x06004B36 RID: 19254 RVA: 0x0014ACCC File Offset: 0x00148ECC
		private void ActionsPanel_ZoomToSelectedWindowButtonClicked(object sender, RoutedEventArgs e)
		{
			ModelEditorPartialClass.ActionsPanel_ZoomToSelectedWindowButtonClicked(this.ZoomToWindowButton, new Func<bool>(this.DisablePanMode), new Func<bool>(this.DisableRotate3DMode), new Action(this.MyActivateZoomToWindowMode), new Action<bool>(this.MyDeactivateZoomToWindowMode));
		}

		// Token: 0x06004B37 RID: 19255 RVA: 0x0003F79E File Offset: 0x0003D99E
		private void MyActivateZoomToWindowMode()
		{
			this.ZoomToWindowTool.Activate();
			this.state.ZoomToWindowEnabled = true;
			this.SuspendEvents = true;
		}

		// Token: 0x06004B38 RID: 19256 RVA: 0x0014AD24 File Offset: 0x00148F24
		private void MyDeactivateZoomToWindowMode(bool forceDisabling)
		{
			this.ZoomToWindowTool.Deactivate(forceDisabling);
			this.state.ZoomToWindowEnabled = false;
			if (!this.ZoomToWindowTool.IsActive)
			{
				this.SuspendEvents = false;
				this.RefreshModelScale();
				this.OnCameraDistanceChanged(new CameraDistanceChangedEventArgs(this.CameraDistance, this.ModelScale));
				this.OnModelScaleChanged(new SelectedValueChangedEventArgs<double>(this.ModelScale));
			}
		}

		// Token: 0x170015EE RID: 5614
		// (get) Token: 0x06004B39 RID: 19257 RVA: 0x0003F7CA File Offset: 0x0003D9CA
		// (set) Token: 0x06004B3A RID: 19258 RVA: 0x0003F7D6 File Offset: 0x0003D9D6
		public bool RecollectTransparencyModelsOnDrawingResultsChange
		{
			get
			{
				return this.recollectTransparencyModelsOnDrawingResultsChange;
			}
			set
			{
				this.recollectTransparencyModelsOnDrawingResultsChange = value;
			}
		}

		// Token: 0x06004B3B RID: 19259 RVA: 0x0003F7E7 File Offset: 0x0003D9E7
		public void AddToView(IDrawingResult drawingResult)
		{
			#X0d.#V0d(drawingResult, #Phc.#3hc(107474044), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls, #Phc.#3hc(107472863));
			if (this.MyAddToViewImpl(drawingResult))
			{
				this.MyHandleUpdate(drawingResult);
			}
		}

		// Token: 0x06004B3C RID: 19260 RVA: 0x0003F820 File Offset: 0x0003DA20
		public void AddToView(params IDrawingResult[] drawingResults)
		{
			#X0d.#V0d(drawingResults, #Phc.#3hc(107472778), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls, #Phc.#3hc(107472789));
			this.AddToView(drawingResults.ToList<IDrawingResult>());
		}

		// Token: 0x06004B3D RID: 19261 RVA: 0x0003F855 File Offset: 0x0003DA55
		public void RemoveFromView(params IDrawingResult[] drawingResults)
		{
			#X0d.#V0d(drawingResults, #Phc.#3hc(107472778), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls, #Phc.#3hc(107472704));
			this.RemoveFromView(drawingResults.ToList<IDrawingResult>());
		}

		// Token: 0x06004B3E RID: 19262 RVA: 0x0014AD98 File Offset: 0x00148F98
		public void AddToView(IEnumerable<IDrawingResult> drawingResults)
		{
			#X0d.#V0d(drawingResults, #Phc.#3hc(107472778), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls, #Phc.#3hc(107472651));
			foreach (IDrawingResult drawingResult in drawingResults)
			{
				this.MyAddToViewImpl(drawingResult);
			}
			if (this.RecollectTransparencyModelsOnDrawingResultsChange)
			{
				this.TransparencySorter.RecollectTransparentModels();
			}
		}

		// Token: 0x06004B3F RID: 19263 RVA: 0x0014AE1C File Offset: 0x0014901C
		public void RemoveFromView(IEnumerable<IDrawingResult> drawingResults)
		{
			#X0d.#V0d(drawingResults, #Phc.#3hc(107472778), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls, #Phc.#3hc(107472118));
			foreach (IDrawingResult drawingResult in drawingResults)
			{
				this.MyRemoveFromViewImpl(drawingResult);
			}
			if (this.RecollectTransparencyModelsOnDrawingResultsChange)
			{
				this.TransparencySorter.RecollectTransparentModels();
			}
		}

		// Token: 0x06004B40 RID: 19264 RVA: 0x0003F88A File Offset: 0x0003DA8A
		public void RemoveFromView(IDrawingResult drawingResult)
		{
			#X0d.#V0d(drawingResult, #Phc.#3hc(107474044), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls, #Phc.#3hc(107472033));
			if (this.MyRemoveFromViewImpl(drawingResult))
			{
				this.MyHandleUpdate(drawingResult);
			}
		}

		// Token: 0x06004B41 RID: 19265 RVA: 0x0003F8C3 File Offset: 0x0003DAC3
		public bool IsInView(IDrawingResult drawingResult)
		{
			if (drawingResult == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107474044));
			}
			return this.attachedDrawingResults.Contains(drawingResult.GetHashCode());
		}

		// Token: 0x06004B42 RID: 19266 RVA: 0x0003F8F5 File Offset: 0x0003DAF5
		private void MyHandleUpdate(IDrawingResult drawingResult)
		{
			if (this.RecollectTransparencyModelsOnDrawingResultsChange && !(drawingResult is IPointsDrawingResult))
			{
				this.TransparencySorter.RecollectTransparentModels();
			}
		}

		// Token: 0x06004B43 RID: 19267 RVA: 0x0003F91E File Offset: 0x0003DB1E
		private bool MyRemoveFromViewImpl(IDrawingResult drawingResult)
		{
			return ModelEditorPartialClass.RemoveFromViewImpl(drawingResult, this.attachedDrawingResults, this.MainViewport);
		}

		// Token: 0x06004B44 RID: 19268 RVA: 0x0003F93E File Offset: 0x0003DB3E
		private bool MyAddToViewImpl(IDrawingResult drawingResult)
		{
			return ModelEditorPartialClass.AddToViewImpl(drawingResult, this.attachedDrawingResults, this.MainViewport);
		}

		// Token: 0x06004B45 RID: 19269 RVA: 0x0014AEA0 File Offset: 0x001490A0
		public ModelEditorControl()
		{
			this.InitializeComponent();
			this.MySetupViewControls();
			this.MyUpdateVisibleArea(this.EditorWorkspaceSize);
			if (DesignerHelper.IsInRuntime)
			{
				LinesUpdater.Instance.IsEmissiveMaterialUsed = false;
				LinesUpdater.Instance.RegisterViewport3D(this.MainViewport);
				LinesUpdater.Instance.Refresh(true);
				this.FitCameraPositionToRect(this.visibleArea3D);
				ModelEditorCameraHelper.SetupCameraBindings(this);
				this.MyRegisterEvents();
				this.planarRectangleDrawingResult = new PlanarRectangleDrawingResult(false)
				{
					Color = Colors.Transparent
				};
				this.MainViewport.IsHitTestVisible = false;
				this.transparencySorter = new TransparencySorter(this.MainViewport, this.TargetPositionCamera);
				this.transparencySorter.CustomSortingMode = CustomSortingModeType.CustomByCameraDistance;
				this.transparencySorter.StartTransparencySorting();
			}
			base.UseLayoutRounding = false;
			this.UpdateScaleSlider = true;
			this.LogicalMousePosition = new Position();
			this.areMouseMoveEventsEnabled = true;
			this.EditorWorkspaceBoundingBoxData = new BoundingBoxData(default(StructurePoint.CoreAssets.Infrastructure.Data.Size));
			this.MySetupMouseCameraController();
			this.ResetLinesUpdater();
		}

		// Token: 0x1400010A RID: 266
		// (add) Token: 0x06004B46 RID: 19270 RVA: 0x0014AFFC File Offset: 0x001491FC
		// (remove) Token: 0x06004B47 RID: 19271 RVA: 0x0014B040 File Offset: 0x00149240
		public event RoutedEventHandler SuspendEventsChanged;

		// Token: 0x170015EF RID: 5615
		// (get) Token: 0x06004B48 RID: 19272 RVA: 0x0003F95E File Offset: 0x0003DB5E
		public IFloatingControlsPanel ViewControls
		{
			get
			{
				return this.ViewControlsPanel;
			}
		}

		// Token: 0x170015F0 RID: 5616
		// (get) Token: 0x06004B49 RID: 19273 RVA: 0x0003F96A File Offset: 0x0003DB6A
		// (set) Token: 0x06004B4A RID: 19274 RVA: 0x0003F976 File Offset: 0x0003DB76
		public bool UpdateScaleSlider { get; set; }

		// Token: 0x170015F1 RID: 5617
		// (get) Token: 0x06004B4B RID: 19275 RVA: 0x0003F987 File Offset: 0x0003DB87
		// (set) Token: 0x06004B4C RID: 19276 RVA: 0x0003F993 File Offset: 0x0003DB93
		public double UnitReferenceMultiplier { get; set; }

		// Token: 0x170015F2 RID: 5618
		// (get) Token: 0x06004B4D RID: 19277 RVA: 0x0003F9A4 File Offset: 0x0003DBA4
		// (set) Token: 0x06004B4E RID: 19278 RVA: 0x0003F9B0 File Offset: 0x0003DBB0
		public bool SuspendEvents
		{
			get
			{
				return this.suspendEvents;
			}
			set
			{
				if (this.suspendEvents != value)
				{
					this.suspendEvents = value;
					this.OnSuspendEventsChanged();
				}
			}
		}

		// Token: 0x170015F3 RID: 5619
		// (get) Token: 0x06004B4F RID: 19279 RVA: 0x0003F9D4 File Offset: 0x0003DBD4
		// (set) Token: 0x06004B50 RID: 19280 RVA: 0x0003F9E0 File Offset: 0x0003DBE0
		public bool SuspendCameraEvents { get; set; }

		// Token: 0x170015F4 RID: 5620
		// (get) Token: 0x06004B51 RID: 19281 RVA: 0x0003F9F1 File Offset: 0x0003DBF1
		// (set) Token: 0x06004B52 RID: 19282 RVA: 0x0003F9FD File Offset: 0x0003DBFD
		public Position LogicalMousePosition { get; private set; }

		// Token: 0x170015F5 RID: 5621
		// (get) Token: 0x06004B53 RID: 19283 RVA: 0x0003FA0E File Offset: 0x0003DC0E
		// (set) Token: 0x06004B54 RID: 19284 RVA: 0x0003FA1A File Offset: 0x0003DC1A
		public double ModelScale { get; set; }

		// Token: 0x170015F6 RID: 5622
		// (get) Token: 0x06004B55 RID: 19285 RVA: 0x0003FA2B File Offset: 0x0003DC2B
		// (set) Token: 0x06004B56 RID: 19286 RVA: 0x0003FA37 File Offset: 0x0003DC37
		public BoundingBoxData EditorWorkspaceBoundingBoxData { get; private set; }

		// Token: 0x170015F7 RID: 5623
		// (get) Token: 0x06004B57 RID: 19287 RVA: 0x0003FA48 File Offset: 0x0003DC48
		// (set) Token: 0x06004B58 RID: 19288 RVA: 0x0003FA54 File Offset: 0x0003DC54
		public IMultilineDrawingResult AnnotationConnectors { get; set; }

		// Token: 0x170015F8 RID: 5624
		// (get) Token: 0x06004B59 RID: 19289 RVA: 0x0003FA65 File Offset: 0x0003DC65
		// (set) Token: 0x06004B5A RID: 19290 RVA: 0x0003FA71 File Offset: 0x0003DC71
		public IMultilineDrawingResult DarkerAnnotationConnectors { get; set; }

		// Token: 0x170015F9 RID: 5625
		// (get) Token: 0x06004B5B RID: 19291 RVA: 0x0003FA82 File Offset: 0x0003DC82
		public StructurePoint.CoreAssets.Infrastructure.Data.Point3D CameraPosition
		{
			get
			{
				return this.TargetPositionCamera.GetCameraPosition().Convert();
			}
		}

		// Token: 0x170015FA RID: 5626
		// (get) Token: 0x06004B5C RID: 19292 RVA: 0x0014B084 File Offset: 0x00149284
		// (set) Token: 0x06004B5D RID: 19293 RVA: 0x0014B0C8 File Offset: 0x001492C8
		public CameraType CameraType
		{
			get
			{
				BaseCamera.CameraTypes cameraType = this.TargetPositionCamera.CameraType;
				if (cameraType == BaseCamera.CameraTypes.PerspectiveCamera)
				{
					return CameraType.Perspective;
				}
				if (cameraType != BaseCamera.CameraTypes.OrthographicCamera)
				{
					throw new InvalidOperationException(#Phc.#3hc(107403566));
				}
				return CameraType.Orthographic;
			}
			set
			{
				if (value == CameraType.Perspective)
				{
					this.TargetPositionCamera.CameraType = BaseCamera.CameraTypes.PerspectiveCamera;
					ModelEditorCameraHelper.RecalculateCameraReferenceValue(this.TargetPositionCamera, this.ZoomPanel);
					this.ZoomPanel.CameraType = value;
					return;
				}
				if (value != CameraType.Orthographic)
				{
					throw new ArgumentOutOfRangeException(#Phc.#3hc(107386484));
				}
				this.TargetPositionCamera.CameraType = BaseCamera.CameraTypes.OrthographicCamera;
				ModelEditorCameraHelper.RecalculateCameraReferenceValue(this.TargetPositionCamera, this.ZoomPanel);
				this.ZoomPanel.CameraType = value;
			}
		}

		// Token: 0x170015FB RID: 5627
		// (get) Token: 0x06004B5E RID: 19294 RVA: 0x0003FAA0 File Offset: 0x0003DCA0
		// (set) Token: 0x06004B5F RID: 19295 RVA: 0x0003FAB5 File Offset: 0x0003DCB5
		public AxisName CameraMainAxis
		{
			get
			{
				return this.TargetPositionCamera.MainAxis;
			}
			set
			{
				this.TargetPositionCamera.MainAxis = value;
				this.ViewCube.ViewCubeCamera.MainAxis = value;
			}
		}

		// Token: 0x170015FC RID: 5628
		// (get) Token: 0x06004B60 RID: 19296 RVA: 0x0003FAE0 File Offset: 0x0003DCE0
		public ITransparencySorter TransparencySorter
		{
			get
			{
				return this.transparencySorter;
			}
		}

		// Token: 0x170015FD RID: 5629
		// (get) Token: 0x06004B61 RID: 19297 RVA: 0x0003FAEC File Offset: 0x0003DCEC
		private CustomTargetPositionCamera ScaleCalculationCamera
		{
			get
			{
				if (this.scaleCalculationCamera == null)
				{
					this.scaleCalculationCamera = new CustomTargetPositionCamera();
				}
				ModelEditorCameraHelper.CopyScaleRelevantProperties(this.TargetPositionCamera, this.scaleCalculationCamera);
				return this.scaleCalculationCamera;
			}
		}

		// Token: 0x06004B62 RID: 19298 RVA: 0x0014B150 File Offset: 0x00149350
		public void CleanupOnClose()
		{
			LinesUpdater.Instance.Reset(this.MainViewport);
			LinesUpdater.Instance.UnregisterViewport3D(this.MainViewport);
			LinesUpdater.Instance.Refresh(true);
			this.TranslateButton = null;
			this.PanCommandButton = null;
			this.Panel3DCustomButton1 = null;
			this.Rotate3DButton = null;
			this.ZoomToWindowButton = null;
			this.MainViewport.Children.Clear();
			this.MainViewport.SizeChanged -= this.MainViewport_SizeChanged;
			CompositionTarget.Rendering -= this.CompositionTarget_Rendering;
			if (this.ViewControls != null)
			{
				this.ViewControls.CloseMenuItemClicked -= this.ToolsPanel_CloseMenuItemClicked;
			}
			Window window;
			if ((window = this.eventSourceWindow) == null)
			{
				window = (Window.GetWindow(this) ?? this.ParentOfType<Window>());
			}
			Window window2 = window;
			if (window2 != null)
			{
				window2.KeyDown -= this.Window_KeyDown;
				window2.KeyUp -= this.Window_KeyUp;
			}
			this.LayoutRoot.Children.Clear();
		}

		// Token: 0x06004B63 RID: 19299 RVA: 0x0003FB24 File Offset: 0x0003DD24
		public void ResetLinesUpdater()
		{
			LinesUpdater.Instance.Reset(this.MainViewport);
			LinesUpdater.Instance.Refresh(true);
		}

		// Token: 0x06004B64 RID: 19300 RVA: 0x0003FB4E File Offset: 0x0003DD4E
		public double CalculateViewScale()
		{
			return ModelEditorCameraHelper.CalculateViewScale(this.ScaleCalculationCamera, this.ViewportSize.Convert(), this.EditorWorkspaceSize);
		}

		// Token: 0x06004B65 RID: 19301 RVA: 0x0003FB78 File Offset: 0x0003DD78
		public void ExportCurrentViewAsImage(Stream sinkStream)
		{
			VisualToImageExportHelper.ExportToPng(this.MainViewport, sinkStream);
		}

		// Token: 0x06004B66 RID: 19302 RVA: 0x0003FB92 File Offset: 0x0003DD92
		public StructurePoint.CoreAssets.Infrastructure.Data.Point ConvertPoint3DTo2D(StructurePoint.CoreAssets.Infrastructure.Data.Point3D point3D)
		{
			return this.TargetPositionCamera.Point3DTo2D(point3D.Convert()).Convert();
		}

		// Token: 0x06004B67 RID: 19303 RVA: 0x0014B274 File Offset: 0x00149474
		public bool IsInViewport(StructurePoint.CoreAssets.Infrastructure.Data.Point point)
		{
			return point.X >= 0.0 && point.Y >= 0.0 && point.X <= this.MainViewport.ActualWidth && point.Y <= this.MainViewport.ActualHeight;
		}

		// Token: 0x06004B68 RID: 19304 RVA: 0x0014B2E0 File Offset: 0x001494E0
		public bool IsInViewport(StructurePoint.CoreAssets.Infrastructure.Data.Point point, double uniformMargin)
		{
			return point.X >= uniformMargin && point.Y >= uniformMargin && point.X <= this.MainViewport.ActualWidth - uniformMargin && point.Y <= this.MainViewport.ActualHeight - uniformMargin;
		}

		// Token: 0x06004B69 RID: 19305 RVA: 0x0003FBB6 File Offset: 0x0003DDB6
		public bool GetMousePositionOnXYPlane(StructurePoint.CoreAssets.Infrastructure.Data.Point mousePosition, out StructurePoint.CoreAssets.Infrastructure.Data.Point3D intersectionPoint)
		{
			return ModelEditorCameraHelper.GetMousePositionOnXYPlane(mousePosition, this.TargetPositionCamera, out intersectionPoint);
		}

		// Token: 0x06004B6A RID: 19306 RVA: 0x0003FBD1 File Offset: 0x0003DDD1
		public StructurePoint.CoreAssets.Infrastructure.Data.Point GetEditorPosition(MouseEventArgs mouseEventArgs)
		{
			#X0d.#V0d(mouseEventArgs, #Phc.#3hc(107471980), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls, #Phc.#3hc(107471991));
			return mouseEventArgs.GetPosition(this.MainViewport).Convert();
		}

		// Token: 0x06004B6B RID: 19307 RVA: 0x0003FC0B File Offset: 0x0003DE0B
		public bool CreateMouseRay3D(StructurePoint.CoreAssets.Infrastructure.Data.Point point, out StructurePoint.CoreAssets.Infrastructure.Data.Point3D rayOrigin, out #c4d rayDirection)
		{
			return this.TargetPositionCamera.CreateMouseRay3D(point, out rayOrigin, out rayDirection);
		}

		// Token: 0x06004B6C RID: 19308 RVA: 0x0003FC27 File Offset: 0x0003DE27
		public void ResetCamera()
		{
			this.TargetPositionCamera.Reset(this.EditorWorkspaceWithAnnotationsSize.#Kvc());
		}

		// Token: 0x06004B6D RID: 19309 RVA: 0x0003FC4B File Offset: 0x0003DE4B
		public bool IsCameraInDefault2DPosition()
		{
			return this.TargetPositionCamera.IsCameraInDefault2DPosition();
		}

		// Token: 0x06004B6E RID: 19310 RVA: 0x0003FC60 File Offset: 0x0003DE60
		public void FitCameraPositionToRect(StructurePoint.CoreAssets.Infrastructure.Data.Rect3D rect)
		{
			this.fitToRectTemp = new StructurePoint.CoreAssets.Infrastructure.Data.Rect3D?(rect);
			this.enablePerformFitToObjectOperation = true;
		}

		// Token: 0x06004B6F RID: 19311 RVA: 0x0003FC81 File Offset: 0x0003DE81
		public void FitCameraPositionToWorkspace()
		{
			this.fitToRectTemp = new StructurePoint.CoreAssets.Infrastructure.Data.Rect3D?(this.EditorWorkspaceWithAnnotationsSize.Rect3D);
			this.fitToObjectCounter = 0;
			this.enablePerformFitToObjectOperation = true;
		}

		// Token: 0x06004B70 RID: 19312 RVA: 0x0014B340 File Offset: 0x00149540
		public void SetCursor(Cursor cursor, bool forceCursor)
		{
			#X0d.#V0d(cursor, #Phc.#3hc(107471906), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.DesktopControls, #Phc.#3hc(107471929));
			if (!this.state.PaneModeEnabled && !this.state.RotateModeEnabled)
			{
				base.Cursor = cursor;
				base.ForceCursor = forceCursor;
			}
			this.previousControlCursor = cursor;
			this.ZoomToWindowTool.LastUsedCursor = cursor;
		}

		// Token: 0x06004B71 RID: 19313 RVA: 0x0003FCB3 File Offset: 0x0003DEB3
		public Matrix3D? GetVisualToScreenMatrix(IDrawingResult drawingResult)
		{
			return VisualToScreenHelper.GetVisualToScreenMatrix(drawingResult);
		}

		// Token: 0x06004B72 RID: 19314 RVA: 0x0014B3B0 File Offset: 0x001495B0
		public bool DisablePanMode()
		{
			bool? isChecked = this.PanCommandButton.IsChecked;
			if (isChecked == null || !this.PanCommandButton.IsChecked.Value)
			{
				return false;
			}
			this.MyDisablePanMode();
			this.PanCommandButton.IsChecked = new bool?(false);
			return true;
		}

		// Token: 0x06004B73 RID: 19315 RVA: 0x0014B410 File Offset: 0x00149610
		public bool DisableZoomToWindowMode(bool forceDisabling)
		{
			bool? isChecked = this.ZoomToWindowButton.IsChecked;
			if (isChecked == null || !this.ZoomToWindowButton.IsChecked.Value)
			{
				return false;
			}
			this.MyDeactivateZoomToWindowMode(forceDisabling);
			if (!this.ZoomToWindowTool.IsActive)
			{
				this.ZoomToWindowButton.IsChecked = new bool?(false);
			}
			return !this.ZoomToWindowTool.IsActive;
		}

		// Token: 0x06004B74 RID: 19316 RVA: 0x0014B488 File Offset: 0x00149688
		public double CalculateCameraDistanceToCoverAllObjects(StructurePoint.CoreAssets.Infrastructure.Data.Rect3D mainRect)
		{
			return this.cameraPositionSetterFactory.CreateCameraPositionSetter(this.DefaultPositionOfCamera, this.TargetPositionCamera, this.MainViewport, this.ZoomPanel.ScaleSlider, this.ViewCube.ViewCubeCamera, this.ZoomPanel.Equation).CalculateCameraDistanceToCoverAllObjects(mainRect.Convert());
		}

		// Token: 0x06004B75 RID: 19317 RVA: 0x0014B4EC File Offset: 0x001496EC
		public bool IsPointVisibleInCamera(StructurePoint.CoreAssets.Infrastructure.Data.Point3D point3D)
		{
			Matrix3D matrix3D = default(Matrix3D);
			if (this.TargetPositionCamera.GetWorldToViewportMatrix(ref matrix3D, true))
			{
				System.Windows.Media.Media3D.Point3D point3D2 = matrix3D.Transform(new System.Windows.Media.Media3D.Point3D(point3D.X, point3D.Y, point3D.Z));
				return this.IsInViewport(new StructurePoint.CoreAssets.Infrastructure.Data.Point(point3D2.X, point3D2.Y));
			}
			return false;
		}

		// Token: 0x06004B76 RID: 19318 RVA: 0x0003FCC3 File Offset: 0x0003DEC3
		public void ReconfigureSlider()
		{
			ModelEditorCameraHelper.UpdateSlider(this.TargetPositionCamera, this.ZoomPanel, base.RenderSize, base.RenderSize, this.UnitReferenceMultiplier);
		}

		// Token: 0x06004B77 RID: 19319 RVA: 0x0003FCF4 File Offset: 0x0003DEF4
		public void SetCameraZoomParameters()
		{
			ModelEditorParametersStorage.OneHundredPercentDistance = this.CalculateCameraDistanceToCoverAllObjects(this.EditorWorkspaceSize.Rect3D);
		}

		// Token: 0x06004B78 RID: 19320 RVA: 0x0003FD18 File Offset: 0x0003DF18
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#")]
		public bool GetMousePositionOnPerpendicularPlane(StructurePoint.CoreAssets.Infrastructure.Data.Point mousePosition, out StructurePoint.CoreAssets.Infrastructure.Data.Point3D intersectionPoint)
		{
			return ModelEditorCameraHelper.GetMousePositionOnPerpendicularPlane(mousePosition, this.TargetPositionCamera, out intersectionPoint);
		}

		// Token: 0x06004B79 RID: 19321 RVA: 0x0003FD33 File Offset: 0x0003DF33
		[SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#")]
		public bool GetMousePositionOnPerpendicularPlaneOrthographic(StructurePoint.CoreAssets.Infrastructure.Data.Point mousePosition, out StructurePoint.CoreAssets.Infrastructure.Data.Point3D intersectionPoint)
		{
			return ModelEditorCameraHelper.GetMousePositionOnPerpendicularPlaneOrthographic(mousePosition, this.TargetPositionCamera, this.ViewportSize, out intersectionPoint);
		}

		// Token: 0x06004B7A RID: 19322 RVA: 0x0014B55C File Offset: 0x0014975C
		public bool DisableRotate3DMode()
		{
			RadToggleButton rotate3DButton = this.Rotate3DButton;
			bool flag;
			if (rotate3DButton == null)
			{
				flag = true;
			}
			else
			{
				bool? isChecked = rotate3DButton.IsChecked;
				flag = (isChecked == null);
			}
			if (flag || !this.Rotate3DButton.IsChecked.Value)
			{
				return false;
			}
			this.MyDisableRotate3DMode();
			this.Rotate3DButton.IsChecked = new bool?(false);
			return true;
		}

		// Token: 0x06004B7B RID: 19323 RVA: 0x0014B5C4 File Offset: 0x001497C4
		internal void FitCameraPositionToRectImpl(StructurePoint.CoreAssets.Infrastructure.Data.Rect3D rect, bool updateSlider)
		{
			ModelEditorCameraHelper.FitCameraPositionToRectImpl(rect.Convert(), updateSlider, this.TargetPositionCamera, this.cameraPositionSetterFactory, this.DefaultPositionOfCamera, this.MainViewport, this.ZoomPanel, this.ViewCube, this.FitCameraToWorkspaceAnimationDuration, this.OverlayBorder, this.CameraDistance, this.ModelScale, new Action(this.RefreshModelScale), new Action(this.RaiseCameraChanged), new Action<CameraDistanceChangedEventArgs>(this.OnCameraDistanceChanged), new Action<SelectedValueChangedEventArgs<double>>(this.OnModelScaleChanged));
		}

		// Token: 0x06004B7C RID: 19324 RVA: 0x0014B66C File Offset: 0x0014986C
		private void OnSuspendEventsChanged()
		{
			RoutedEventHandler suspendEventsChanged = this.SuspendEventsChanged;
			if (suspendEventsChanged != null)
			{
				suspendEventsChanged(this, new RoutedEventArgs());
			}
		}

		// Token: 0x06004B7D RID: 19325 RVA: 0x0003FD54 File Offset: 0x0003DF54
		private void MainViewport_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			this.SetCameraZoomParameters();
		}

		// Token: 0x06004B7E RID: 19326 RVA: 0x0003FD64 File Offset: 0x0003DF64
		private void ModelEditorControl_Loaded(object sender, RoutedEventArgs e)
		{
			this.eventSourceWindow = Window.GetWindow(this);
			ModelEditorPartialClass.ModelEditorControl_Loaded(sender, e, this, new KeyEventHandler(this.Window_KeyDown), new KeyEventHandler(this.Window_KeyUp));
		}

		// Token: 0x06004B7F RID: 19327 RVA: 0x0014B69C File Offset: 0x0014989C
		private void CompositionTarget_Rendering(object sender, EventArgs e)
		{
			Tuple<int, bool> tuple = ModelEditorPartialClass.CompositionTarget_Rendering(sender, e, this.enablePerformFitToObjectOperation, this.fitToObjectCounter, this.fitToRectTemp, this.TargetPositionCamera, this.cameraPositionSetterFactory, this.DefaultPositionOfCamera, this.MainViewport, this.ZoomPanel, this.ViewCube, this.UpdateScaleSlider, this.FitCameraToWorkspaceAnimationDuration, this.OverlayBorder, this.CameraDistance, this.ModelScale, new Action(this.RefreshModelScale), new Action(this.RaiseCameraChanged), new Action<CameraDistanceChangedEventArgs>(this.OnCameraDistanceChanged), new Action<SelectedValueChangedEventArgs<double>>(this.OnModelScaleChanged));
			this.fitToObjectCounter = tuple.Item1;
			this.enablePerformFitToObjectOperation = tuple.Item2;
		}

		// Token: 0x06004B80 RID: 19328 RVA: 0x0014B770 File Offset: 0x00149970
		private void TargetPositionCamera_PreviewCameraChanged(object sender, PreviewCameraChangedRoutedEventArgs e)
		{
			if (e.Handled)
			{
				return;
			}
			this.isCameraActionZoom = ModelEditorPartialClass.TargetPositionCamera_PreviewCameraChanged(sender, e, this.TargetPositionCamera, this.MainViewport, this.OverlayBorder, out this.oldMousePositionProjection, this.ViewportSize);
		}

		// Token: 0x06004B81 RID: 19329 RVA: 0x0014B7C0 File Offset: 0x001499C0
		private void TargetPositionCamera_CameraChanged(object sender, CameraChangedRoutedEventArgs e)
		{
			ModelEditorPartialClass.CoerceCameraViewAngles(this.TargetPositionCamera);
			if (this.isCameraActionZoom && this.MainViewport != null && Mouse.DirectlyOver == this.OverlayBorder)
			{
				Tuple<bool, bool, StructurePoint.CoreAssets.Infrastructure.Data.Point3D> tuple = ModelEditorPartialClass.TargetPositionCamera_CameraChanged(sender, e, this.TargetPositionCamera, this.MainViewport, this.OverlayBorder, this.isCameraActionZoom, this.oldMousePositionProjection, out this.newMousePostitionProjection, this.ViewportSize);
				if (tuple.Item1)
				{
					this.isCameraActionZoom = tuple.Item2;
					this.newMousePostitionProjection = tuple.Item3;
				}
			}
			if (this.isCameraFeedbackAvailable)
			{
				try
				{
					this.acceptViewCubeCameraChangedEventArgs = false;
					this.ViewCube.ViewCubeCamera.Attitude = this.TargetPositionCamera.Attitude;
					this.ViewCube.ViewCubeCamera.Bank = this.TargetPositionCamera.Bank;
					this.ViewCube.ViewCubeCamera.Heading = this.TargetPositionCamera.Heading;
				}
				finally
				{
					this.acceptViewCubeCameraChangedEventArgs = true;
				}
			}
			this.RefreshModelScale();
			this.RaiseCameraChanged();
		}

		// Token: 0x06004B82 RID: 19330 RVA: 0x0014B8EC File Offset: 0x00149AEC
		public void RefreshModelScale()
		{
			double? num = this.RecalculateModelScale();
			if (num != null)
			{
				this.ModelScale = num.Value;
				this.TargetPositionCamera.OnDistanceScaleChanged(new SelectedValueChangedEventArgs<double>(this.ModelScale));
			}
		}

		// Token: 0x06004B83 RID: 19331 RVA: 0x0003FD9E File Offset: 0x0003DF9E
		public double? RecalculateModelScale()
		{
			return ModelEditorPartialClass.RefreshModelScale(this, this.planarRectangleDrawingResult, this.isWorkspaceInView, this.TargetPositionCamera, new Action<ISphereDrawingResult>(this.AddToView), new Action<ISphereDrawingResult>(this.RemoveFromView));
		}

		// Token: 0x06004B84 RID: 19332 RVA: 0x0014B938 File Offset: 0x00149B38
		private void ViewCube_OnClicked(object sender, ViewCubeClickedEventArgs viewCubeClickedEventArgs)
		{
			if (this.viewCubeClickLock.#YXd())
			{
				this.isCameraFeedbackAvailable = false;
				TimeSpan timeSpan = this.ViewCube.AnimationDuration.TimeSpan.Add(TimeSpan.FromMilliseconds(50.0));
				try
				{
					StructurePoint.CoreAssets.Infrastructure.Data.Rect3D? rect3D = (this.EditorWorkspaceWithAnnotationsSize != null) ? new StructurePoint.CoreAssets.Infrastructure.Data.Rect3D?(this.EditorWorkspaceWithAnnotationsSize.Rect3D) : null;
					StructurePoint.CoreAssets.Infrastructure.Data.Rect3D? rect3D2 = rect3D;
					rect3D = ((rect3D2 != null) ? rect3D2 : this.fitToRectTemp);
					if (rect3D != null)
					{
						StructurePoint.CoreAssets.Infrastructure.Data.Rect3D value = rect3D.Value;
						CameraPositionSetterBase cameraPositionSetterBase = this.cameraPositionSetterFactory.CreateCameraPositionSetter(viewCubeClickedEventArgs.PositionOfViewCubeClicked, this.TargetPositionCamera, this.MainViewport, this.ZoomPanel.ScaleSlider, this.ViewCube.ViewCubeCamera, this.ZoomPanel.Equation);
						this.acceptViewCubeCameraChangedEventArgs = false;
						cameraPositionSetterBase.SetViewCubeCameraPosition(this.ViewCube.AnimationDuration);
						cameraPositionSetterBase.SetMainCameraPosition(value.Convert(), this.ViewCube.AnimationDuration);
					}
				}
				finally
				{
					LayoutHelper.DelayOperation(timeSpan.TotalSeconds, delegate()
					{
						this.viewCubeClickLock.#ZXd();
						this.acceptViewCubeCameraChangedEventArgs = true;
						this.TargetPositionCamera.RecalculateScale();
						this.OnCameraDistanceChanged(new CameraDistanceChangedEventArgs(this.CameraDistance, this.ModelScale));
						this.OnModelScaleChanged(new SelectedValueChangedEventArgs<double>(this.ModelScale));
						this.RaiseCameraChanged();
					});
				}
			}
		}

		// Token: 0x06004B85 RID: 19333 RVA: 0x0003FDDE File Offset: 0x0003DFDE
		private void ViewCube_OnCameraChanged(object sender, CameraChangedRoutedEventArgs e)
		{
			ModelEditorPartialClass.ViewCube_OnCameraChanged(this.acceptViewCubeCameraChangedEventArgs, this.isCameraFeedbackAvailable, this.TargetPositionCamera, this.ViewCube);
		}

		// Token: 0x06004B86 RID: 19334 RVA: 0x0003FE09 File Offset: 0x0003E009
		private void TargetPositionCamera_DistanceOrAttitudeOrHeadingChanged(object sender, EventArgs e)
		{
			this.OnCameraDistanceOrAttitudeOrHeadingChanged(e);
		}

		// Token: 0x06004B87 RID: 19335 RVA: 0x0003FE1E File Offset: 0x0003E01E
		private void UnlockCameraFeedback(object sender, EventArgs e)
		{
			if (!this.isCameraFeedbackAvailable)
			{
				this.isCameraFeedbackAvailable = true;
			}
		}

		// Token: 0x06004B88 RID: 19336 RVA: 0x0003FE37 File Offset: 0x0003E037
		private void TargetPositionCamera_ScaleChanged(object sender, SelectedValueChangedEventArgs<double> e)
		{
			this.OnModelScaleChanged(e);
		}

		// Token: 0x06004B89 RID: 19337 RVA: 0x0003FE4C File Offset: 0x0003E04C
		private void ToolsPanel_CloseMenuItemClicked(object sender, RadRoutedEventArgs e)
		{
			if (this.ViewControlsPanelVisibility == Visibility.Visible)
			{
				this.ViewControlsPanelVisibility = Visibility.Collapsed;
				return;
			}
			this.ViewControlsPanelVisibility = Visibility.Visible;
		}

		// Token: 0x06004B8A RID: 19338 RVA: 0x0014BA8C File Offset: 0x00149C8C
		private void MyRegisterEvents()
		{
			ModelEditorPartialClass.RegisterEvents(this.OverlayBorder, this.TargetPositionCamera, this.ViewCube, this.ViewControlsPanel, this.MainViewport, new MouseEventHandler(this.OverlayBorder_MouseMove), new MouseEventHandler(this.OverlayBorder_MouseLeave), new EventHandler(this.CompositionTarget_Rendering), new BaseCamera.PreviewCameraChangedRoutedEventHandler(this.TargetPositionCamera_PreviewCameraChanged), new BaseCamera.CameraChangedRoutedEventHandler(this.TargetPositionCamera_CameraChanged), new EventHandler(this.TargetPositionCamera_DistanceOrAttitudeOrHeadingChanged), new EventHandler<ViewCubeClickedEventArgs>(this.ViewCube_OnClicked), new BaseCamera.CameraChangedRoutedEventHandler(this.ViewCube_OnCameraChanged), new EventHandler<SelectedValueChangedEventArgs<double>>(this.TargetPositionCamera_ScaleChanged), new RadRoutedEventHandler(this.ToolsPanel_CloseMenuItemClicked), new SizeChangedEventHandler(this.MainViewport_SizeChanged));
			base.Loaded += this.ModelEditorControl_Loaded;
			base.PreviewMouseDown += new MouseButtonEventHandler(this.UnlockCameraFeedback);
			this.acceptViewCubeCameraChangedEventArgs = true;
		}

		// Token: 0x06004B8B RID: 19339 RVA: 0x0003FE71 File Offset: 0x0003E071
		private void MyUpdateVisibleArea(BoundingBoxData size)
		{
			this.visibleArea3D = size.#Hvc();
			this.EditorWorkspaceBoundingBoxData = size;
		}

		// Token: 0x06004B8C RID: 19340 RVA: 0x0014BB8C File Offset: 0x00149D8C
		private void MyUpdateEditorWorkspaceBackgroundColor()
		{
			this.isWorkspaceInView = ModelEditorPartialClass.UpdateWorkspaceBackgroundColor(this.EditorWorkspaceBackgroundColor, this.EditorWorkspaceSize, this.planarRectangleDrawingResult, new Action<IPlanarRectangleDrawingResult>(this.AddToView), new Action<IPlanarRectangleDrawingResult>(this.RemoveFromView));
		}

		// Token: 0x06004B8D RID: 19341 RVA: 0x0003FE92 File Offset: 0x0003E092
		private void MyUpdatePosition(StructurePoint.CoreAssets.Infrastructure.Data.Point3D position)
		{
			ModelEditorPartialClass.UpdatePosition(this.EditorWorkspaceSize, position, this.LogicalMousePosition);
		}

		// Token: 0x06004B8E RID: 19342 RVA: 0x0003FEB2 File Offset: 0x0003E0B2
		private void MySetupMouseCameraController()
		{
			ModelEditorPartialClass.SetupCameraController(this.MouseCameraController);
		}

		// Token: 0x06004B8F RID: 19343 RVA: 0x0003FEC7 File Offset: 0x0003E0C7
		protected void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.ZoomToWindowTool.Dispose();
			}
		}

		// Token: 0x06004B90 RID: 19344 RVA: 0x0003FEE3 File Offset: 0x0003E0E3
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06004B91 RID: 19345 RVA: 0x0014BBDC File Offset: 0x00149DDC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107472356), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06004B92 RID: 19346 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06004B93 RID: 19347 RVA: 0x0014BC20 File Offset: 0x00149E20
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		[SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.LayoutRoot = (Grid)target;
				return;
			case 2:
				this.MainViewportBorder = (Border)target;
				return;
			case 3:
				this.MainViewport = (Viewport3D)target;
				return;
			case 4:
				this.OverlayBorder = (Border)target;
				return;
			case 5:
				this.TargetPositionCamera = (CustomTargetPositionCamera)target;
				return;
			case 6:
				this.MouseCameraController = (CustomMouseCameraController)target;
				return;
			case 7:
				this.ViewCubeHostControl = (NewViewCubeHostControl)target;
				return;
			case 8:
				this.ViewControlsPanel = (FloatingControlsPanel)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x06004B95 RID: 19349 RVA: 0x00008A99 File Offset: 0x00006C99
		void IModelEditorControl.add_Loaded(RoutedEventHandler value)
		{
			base.Loaded += value;
		}

		// Token: 0x06004B96 RID: 19350 RVA: 0x00008AAE File Offset: 0x00006CAE
		void IModelEditorControl.remove_Loaded(RoutedEventHandler value)
		{
			base.Loaded -= value;
		}

		// Token: 0x06004B97 RID: 19351 RVA: 0x0003FEFE File Offset: 0x0003E0FE
		void IModelEditorControl.add_Unloaded(RoutedEventHandler value)
		{
			base.Unloaded += value;
		}

		// Token: 0x06004B98 RID: 19352 RVA: 0x0003FF13 File Offset: 0x0003E113
		void IModelEditorControl.remove_Unloaded(RoutedEventHandler value)
		{
			base.Unloaded -= value;
		}

		// Token: 0x06004B99 RID: 19353 RVA: 0x0003FF28 File Offset: 0x0003E128
		bool IModelEditorControl.get_IsFocused()
		{
			return base.IsFocused;
		}

		// Token: 0x06004B9A RID: 19354 RVA: 0x00008BB1 File Offset: 0x00006DB1
		bool IModelEditorControl.get_IsVisible()
		{
			return base.IsVisible;
		}

		// Token: 0x0400213C RID: 8508
		public static readonly DependencyProperty EditorWorkspaceBackgroundColorProperty = DependencyProperty.Register(#Phc.#3hc(107472311), typeof(Color), typeof(ModelEditorControl), new PropertyMetadata(Colors.Transparent, new PropertyChangedCallback(ModelEditorControl.MyOnEditorWorkspaceBackgroundColorChanged)));

		// Token: 0x0400213D RID: 8509
		public static readonly DependencyProperty ScreenBackgroundColorProperty = DependencyProperty.Register(#Phc.#3hc(107405924), typeof(Color), typeof(ModelEditorControl), new PropertyMetadata(Colors.WhiteSmoke, new PropertyChangedCallback(ModelEditorControl.MyOnScreenBackgroundColorChanged)));

		// Token: 0x0400213E RID: 8510
		public static readonly DependencyProperty EditorWorkspaceSizeProperty = DependencyProperty.Register(#Phc.#3hc(107472238), typeof(BoundingBoxData), typeof(ModelEditorControl), new PropertyMetadata(new BoundingBoxData(new StructurePoint.CoreAssets.Infrastructure.Data.Size(100.0, 100.0)), new PropertyChangedCallback(ModelEditorControl.OnEditorWorkspaceSizePropertyChanged)));

		// Token: 0x0400213F RID: 8511
		public static readonly DependencyProperty EditorWorkspaceWithAnnotationsSizeProperty = DependencyProperty.Register(#Phc.#3hc(107472241), typeof(BoundingBoxData), typeof(ModelEditorControl), new PropertyMetadata(new BoundingBoxData(new StructurePoint.CoreAssets.Infrastructure.Data.Size(100.0, 100.0)), new PropertyChangedCallback(ModelEditorControl.OnEditorWorkspaceWithAnnotationsSizePropertyChanged)));

		// Token: 0x04002140 RID: 8512
		public static readonly DependencyProperty MinCameraDistanceProperty = DependencyProperty.Register(#Phc.#3hc(107472160), typeof(double), typeof(ModelEditorControl), new PropertyMetadata(20.0));

		// Token: 0x04002141 RID: 8513
		public static readonly DependencyProperty MaxCameraDistanceProperty = DependencyProperty.Register(#Phc.#3hc(107472135), typeof(double), typeof(ModelEditorControl), new PropertyMetadata(20000.0));

		// Token: 0x04002142 RID: 8514
		public static readonly DependencyProperty CameraDistanceProperty = DependencyProperty.Register(#Phc.#3hc(107471598), typeof(double), typeof(ModelEditorControl), new PropertyMetadata(164.0, new PropertyChangedCallback(ModelEditorControl.OnCameraDistancePropertyChanged)));

		// Token: 0x04002143 RID: 8515
		public static readonly DependencyProperty MinCameraWidthProperty = DependencyProperty.Register(#Phc.#3hc(107451263), typeof(double), typeof(ModelEditorControl), new PropertyMetadata(20.0));

		// Token: 0x04002144 RID: 8516
		public static readonly DependencyProperty MaxCameraWidthProperty = DependencyProperty.Register(#Phc.#3hc(107451284), typeof(double), typeof(ModelEditorControl), new PropertyMetadata(20000.0));

		// Token: 0x04002145 RID: 8517
		public static readonly DependencyProperty CameraWidthProperty = DependencyProperty.Register(#Phc.#3hc(107471609), typeof(double), typeof(ModelEditorControl), new PropertyMetadata(164.0, new PropertyChangedCallback(ModelEditorControl.OnCameraWidthPropertyChanged)));

		// Token: 0x04002146 RID: 8518
		public static readonly DependencyProperty TranslateViewConditionProperty = DependencyProperty.Register(#Phc.#3hc(107471560), typeof(MouseAndKeyboardCondition), typeof(ModelEditorControl), new PropertyMetadata(MouseAndKeyboardCondition.MiddleMouseButtonPressed, new PropertyChangedCallback(ModelEditorPartialClass.MyOnTranslateViewConditionPropertyChanged)));

		// Token: 0x04002147 RID: 8519
		public static readonly DependencyProperty RotateViewConditionProperty = DependencyProperty.Register(#Phc.#3hc(107471527), typeof(MouseAndKeyboardCondition), typeof(ModelEditorControl), new PropertyMetadata(MouseAndKeyboardCondition.MiddleMouseButtonPressed | MouseAndKeyboardCondition.ShiftKey, new PropertyChangedCallback(ModelEditorPartialClass.MyOnRotateViewConditionChanged)));

		// Token: 0x04002148 RID: 8520
		public static readonly DependencyProperty IsMouseWheelZoomEnabledProperty = DependencyProperty.Register(#Phc.#3hc(107471498), typeof(bool), typeof(ModelEditorControl), new PropertyMetadata(true));

		// Token: 0x04002149 RID: 8521
		public static readonly DependencyProperty CubePanelVisibilityProperty = DependencyProperty.Register(#Phc.#3hc(107471465), typeof(Visibility), typeof(ModelEditorControl), new PropertyMetadata(Visibility.Visible, new PropertyChangedCallback(ModelEditorPartialClass.OnCubePanelVisibilityChanged)));

		// Token: 0x0400214A RID: 8522
		public static readonly DependencyProperty ZoomPanelVisibilityProperty = DependencyProperty.Register(#Phc.#3hc(107471436), typeof(Visibility), typeof(ModelEditorControl), new PropertyMetadata(Visibility.Visible, new PropertyChangedCallback(ModelEditorPartialClass.OnZoomPanelVisibilityChanged)));

		// Token: 0x0400214B RID: 8523
		public static readonly DependencyProperty NavigationPanelVisibilityProperty = DependencyProperty.Register(#Phc.#3hc(107471407), typeof(Visibility), typeof(ModelEditorControl), new PropertyMetadata(Visibility.Visible, new PropertyChangedCallback(ModelEditorPartialClass.MyOnNavigationPanelVisibilityChanged)));

		// Token: 0x0400214C RID: 8524
		public static readonly DependencyProperty PanelControls2DVisibilityProperty = DependencyProperty.Register(#Phc.#3hc(107471370), typeof(Visibility), typeof(ModelEditorControl), new PropertyMetadata(Visibility.Visible, new PropertyChangedCallback(ModelEditorPartialClass.MyOnPanelControls2DVisibilityChanged)));

		// Token: 0x0400214D RID: 8525
		public static readonly DependencyProperty PanelControls3DVisibilityProperty = DependencyProperty.Register(#Phc.#3hc(107471845), typeof(Visibility), typeof(ModelEditorControl), new PropertyMetadata(Visibility.Visible, new PropertyChangedCallback(ModelEditorPartialClass.MyOnPanelControls3DVisibilityChanged)));

		// Token: 0x0400214E RID: 8526
		public static readonly DependencyProperty VisibilityToolBarControlVisibilityProperty = DependencyProperty.Register(#Phc.#3hc(107471808), typeof(Visibility), typeof(ModelEditorControl), new PropertyMetadata(Visibility.Collapsed, new PropertyChangedCallback(ModelEditorPartialClass.OnVisibilityToolbarControlVisibilityChanged)));

		// Token: 0x0400214F RID: 8527
		public static readonly DependencyProperty VisibilityToolBarCheckBoxesProperty = DependencyProperty.Register(#Phc.#3hc(107471759), typeof(IEnumerable<ICheckBoxData>), typeof(ModelEditorControl), new PropertyMetadata(null));

		// Token: 0x04002150 RID: 8528
		public static readonly DependencyProperty QuickOptionsPanelVisibilityProperty = DependencyProperty.Register(#Phc.#3hc(107471722), typeof(Visibility), typeof(ModelEditorControl), new PropertyMetadata(Visibility.Collapsed, new PropertyChangedCallback(ModelEditorPartialClass.OnQuickOptionsPanelVisibilityChanged)));

		// Token: 0x04002151 RID: 8529
		public static readonly DependencyProperty QuickOptionsPanelContentProperty = DependencyProperty.Register(#Phc.#3hc(107471685), typeof(object), typeof(ModelEditorControl), new PropertyMetadata(null));

		// Token: 0x04002152 RID: 8530
		public static readonly DependencyProperty VisibilityToolBarTitleProperty = DependencyProperty.Register(#Phc.#3hc(107471652), typeof(string), typeof(ModelEditorControl), new PropertyMetadata(Strings.StringLayers, new PropertyChangedCallback(ModelEditorPartialClass.MyVisibilityToolBarTitleChanged)));

		// Token: 0x04002153 RID: 8531
		public static readonly DependencyProperty DefaultPositionOfCameraProperty = DependencyProperty.Register(#Phc.#3hc(107471619), typeof(PredefinedPositionsOfCamera), typeof(ModelEditorControl), new FrameworkPropertyMetadata(PredefinedPositionsOfCamera.Front));

		// Token: 0x04002154 RID: 8532
		public static readonly DependencyProperty AxisXLabelProperty = DependencyProperty.Register(#Phc.#3hc(107471074), typeof(string), typeof(ModelEditorControl), new FrameworkPropertyMetadata(#Phc.#3hc(107408964)));

		// Token: 0x04002155 RID: 8533
		public static readonly DependencyProperty AxisYLabelProperty = DependencyProperty.Register(#Phc.#3hc(107471089), typeof(string), typeof(ModelEditorControl), new FrameworkPropertyMetadata(#Phc.#3hc(107408991)));

		// Token: 0x04002156 RID: 8534
		public static readonly DependencyProperty AxisZLabelProperty = DependencyProperty.Register(#Phc.#3hc(107471040), typeof(string), typeof(ModelEditorControl), new FrameworkPropertyMetadata(#Phc.#3hc(107397860)));

		// Token: 0x04002157 RID: 8535
		public static readonly DependencyProperty FitCameraToWorkspaceAnimationDurationProperty = DependencyProperty.Register(#Phc.#3hc(107471023), typeof(TimeSpan), typeof(ModelEditorControl), new FrameworkPropertyMetadata(TimeSpan.FromMilliseconds(300.0)));

		// Token: 0x04002158 RID: 8536
		public static readonly DependencyProperty ViewControlsPanelAdditionalToolsProperty = DependencyProperty.Register(#Phc.#3hc(107471002), typeof(IEnumerable<IPanelItem>), typeof(ModelEditorControl), new PropertyMetadata(null));

		// Token: 0x04002159 RID: 8537
		public static readonly DependencyProperty ViewControlsPanelPositionProperty = DependencyProperty.Register(#Phc.#3hc(107402933), typeof(ToolsPanelPosition), typeof(ModelEditorControl), new PropertyMetadata(ToolsPanelPosition.TopRight, new PropertyChangedCallback(ModelEditorPartialClass.MyViewControlsPanelPositionChanged)));

		// Token: 0x0400215A RID: 8538
		public static readonly DependencyProperty ViewControlsPanelVisibilityProperty = DependencyProperty.Register(#Phc.#3hc(107361522), typeof(Visibility), typeof(ModelEditorControl), new PropertyMetadata(Visibility.Visible, new PropertyChangedCallback(ModelEditorPartialClass.OnViewControlsPanelVisibilityChanged)));

		// Token: 0x0400215B RID: 8539
		public static readonly DependencyProperty ViewControlsPanelCollapsedProperty = DependencyProperty.Register(#Phc.#3hc(107470925), typeof(bool), typeof(ModelEditorControl), new PropertyMetadata(false));

		// Token: 0x0400215C RID: 8540
		public static readonly DependencyProperty ViewControlsPanelTitleProperty = DependencyProperty.Register(#Phc.#3hc(107470888), typeof(string), typeof(ModelEditorControl), new PropertyMetadata(Strings.StringViewControls));

		// Token: 0x0400215D RID: 8541
		public static readonly DependencyProperty AdjustZoomToModelButtonVisibilityProperty = DependencyProperty.Register(#Phc.#3hc(107470855), typeof(Visibility), typeof(ModelEditorControl), new PropertyMetadata(Visibility.Visible));

		// Token: 0x0400215E RID: 8542
		public static readonly DependencyProperty ZoomToWindowButtonVisibilityProperty = DependencyProperty.Register(#Phc.#3hc(107471354), typeof(Visibility), typeof(ModelEditorControl), new PropertyMetadata(Visibility.Visible));

		// Token: 0x0400215F RID: 8543
		public static readonly DependencyProperty Rotate3DButtonVisibilityProperty = DependencyProperty.Register(#Phc.#3hc(107471313), typeof(Visibility), typeof(ModelEditorControl), new PropertyMetadata(Visibility.Visible));

		// Token: 0x04002160 RID: 8544
		public static readonly DependencyProperty ViewControlsResetButtonToolTipProperty = DependencyProperty.Register(#Phc.#3hc(107471280), typeof(string), typeof(ModelEditorControl), new PropertyMetadata(Strings.StringZoomToWorkspace));

		// Token: 0x04002161 RID: 8545
		public static readonly DependencyProperty ViewCubeSizeProperty = DependencyProperty.Register(#Phc.#3hc(107471207), typeof(ViewCubeSize), typeof(ModelEditorControl), new PropertyMetadata(ViewCubeSize.Regular));

		// Token: 0x04002162 RID: 8546
		public static readonly DependencyProperty EditorMinWidthProperty = DependencyProperty.Register(#Phc.#3hc(107471222), typeof(double), typeof(ModelEditorControl), new PropertyMetadata(double.NaN, new PropertyChangedCallback(ModelEditorControl.PropertyChangedCallback)));

		// Token: 0x04002163 RID: 8547
		public static readonly DependencyProperty BindViewCubeVisibilityWithViewControlsVisibilityProperty = DependencyProperty.Register(#Phc.#3hc(107471169), typeof(bool), typeof(ModelEditorControl), new PropertyMetadata(true));

		// Token: 0x04002164 RID: 8548
		public static readonly DependencyProperty ViewControlsTitleBarVisibilityProperty = DependencyProperty.Register(#Phc.#3hc(107471104), typeof(Visibility), typeof(ModelEditorControl), new PropertyMetadata(Visibility.Visible, new PropertyChangedCallback(ModelEditorControl.OnViewControlsTitleBarVisibilityChanged)));

		// Token: 0x04002165 RID: 8549
		private bool handleKeyUp;

		// Token: 0x04002175 RID: 8565
		private readonly ObservableCollection<IPanelItem> builtInTools = new ObservableCollection<IPanelItem>();

		// Token: 0x04002176 RID: 8566
		private readonly ObservableCollection<IPanelItem> viewCubeTools = new ObservableCollection<IPanelItem>();

		// Token: 0x04002177 RID: 8567
		private Cursor previousControlCursor;

		// Token: 0x04002178 RID: 8568
		private readonly ModelEditorCursorState state = new ModelEditorCursorState();

		// Token: 0x04002193 RID: 8595
		private bool recollectTransparencyModelsOnDrawingResultsChange = true;

		// Token: 0x04002194 RID: 8596
		private readonly ICameraPositionSetterFactory cameraPositionSetterFactory = new RotatingCameraPositionSetterFactory(new PredefinedPositionsOfCameraValueProcessor());

		// Token: 0x04002195 RID: 8597
		private readonly PlanarRectangleDrawingResult planarRectangleDrawingResult;

		// Token: 0x04002196 RID: 8598
		private readonly ITransparencySorter transparencySorter;

		// Token: 0x04002197 RID: 8599
		private readonly NonBlockingLock viewCubeClickLock = new NonBlockingLock();

		// Token: 0x04002198 RID: 8600
		private readonly HashSet<int> attachedDrawingResults = new HashSet<int>();

		// Token: 0x04002199 RID: 8601
		private StructurePoint.CoreAssets.Infrastructure.Data.Rect3D visibleArea3D;

		// Token: 0x0400219A RID: 8602
		private bool areMouseMoveEventsEnabled;

		// Token: 0x0400219B RID: 8603
		private int fitToObjectCounter;

		// Token: 0x0400219C RID: 8604
		private bool enablePerformFitToObjectOperation;

		// Token: 0x0400219D RID: 8605
		private StructurePoint.CoreAssets.Infrastructure.Data.Rect3D? fitToRectTemp;

		// Token: 0x0400219E RID: 8606
		private StructurePoint.CoreAssets.Infrastructure.Data.Point3D oldMousePositionProjection;

		// Token: 0x0400219F RID: 8607
		private StructurePoint.CoreAssets.Infrastructure.Data.Point3D newMousePostitionProjection;

		// Token: 0x040021A0 RID: 8608
		private bool isCameraActionZoom;

		// Token: 0x040021A1 RID: 8609
		private bool isCameraFeedbackAvailable = true;

		// Token: 0x040021A2 RID: 8610
		private bool acceptViewCubeCameraChangedEventArgs;

		// Token: 0x040021A3 RID: 8611
		private CustomTargetPositionCamera scaleCalculationCamera;

		// Token: 0x040021A4 RID: 8612
		private bool suspendEvents;

		// Token: 0x040021AE RID: 8622
		private Window eventSourceWindow;

		// Token: 0x040021AF RID: 8623
		private bool isWorkspaceInView;

		// Token: 0x040021B0 RID: 8624
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal Grid LayoutRoot;

		// Token: 0x040021B1 RID: 8625
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal Border MainViewportBorder;

		// Token: 0x040021B2 RID: 8626
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal Viewport3D MainViewport;

		// Token: 0x040021B3 RID: 8627
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal Border OverlayBorder;

		// Token: 0x040021B4 RID: 8628
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal CustomTargetPositionCamera TargetPositionCamera;

		// Token: 0x040021B5 RID: 8629
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal CustomMouseCameraController MouseCameraController;

		// Token: 0x040021B6 RID: 8630
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal NewViewCubeHostControl ViewCubeHostControl;

		// Token: 0x040021B7 RID: 8631
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal FloatingControlsPanel ViewControlsPanel;

		// Token: 0x040021B8 RID: 8632
		private bool _contentLoaded;
	}
}
