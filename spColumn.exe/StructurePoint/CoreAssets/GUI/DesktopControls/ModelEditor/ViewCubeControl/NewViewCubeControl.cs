using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using #7hc;
using Ab3d.Cameras;
using Ab3d.Common.EventManager3D;
using Ab3d.Controls;
using Ab3d.Utilities;
using Ab3d.Visuals;
using HelixToolkit.Wpf;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.API;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl
{
	// Token: 0x02000953 RID: 2387
	public sealed class NewViewCubeControl : UserControl, IComponentConnector, INotifyPropertyChanged
	{
		// Token: 0x06004E09 RID: 19977 RVA: 0x001525B8 File Offset: 0x001507B8
		private ViewCubeVisualElement FindCubeElement(object plane)
		{
			return this.cubeElements.Find((ViewCubeVisualElement item) => item.Planes.Contains(plane));
		}

		// Token: 0x06004E0A RID: 19978 RVA: 0x001525F8 File Offset: 0x001507F8
		private void CubeElement_MouseClick(object sender, MouseButton3DEventArgs e)
		{
			ViewCubeVisualElement viewCubeVisualElement = this.FindCubeElement(e.HitObject);
			if (viewCubeVisualElement != null)
			{
				this.OnViewCubeClicked(new ViewCubeClickedEventArgs(viewCubeVisualElement.CameraPosition, e.MouseData.ChangedButton));
			}
		}

		// Token: 0x06004E0B RID: 19979 RVA: 0x00152640 File Offset: 0x00150840
		private void CubeElement_MouseEnter(object sender, Mouse3DEventArgs e)
		{
			ViewCubeVisualElement viewCubeVisualElement = this.FindCubeElement(e.HitObject);
			if (viewCubeVisualElement != null)
			{
				foreach (PlaneVisual3D planeVisual3D in viewCubeVisualElement.Planes)
				{
					planeVisual3D.Material = this.viewCube.SemiTransparentMaterial;
				}
			}
		}

		// Token: 0x06004E0C RID: 19980 RVA: 0x001526B4 File Offset: 0x001508B4
		private void CubeElement_MouseLeave(object sender, Mouse3DEventArgs e)
		{
			ViewCubeVisualElement viewCubeVisualElement = this.FindCubeElement(e.HitObject);
			if (viewCubeVisualElement != null)
			{
				foreach (PlaneVisual3D planeVisual3D in viewCubeVisualElement.Planes)
				{
					planeVisual3D.Material = this.viewCube.TransparentMaterial;
				}
			}
		}

		// Token: 0x06004E0D RID: 19981 RVA: 0x00152728 File Offset: 0x00150928
		private void CreateCubeElement(CubeElementType type, PredefinedPositionsOfCamera cameraPosition, Func<MouseEventHandlers, EventManager3D, PlaneVisual3D> factory)
		{
			MouseEventHandlers arg = new MouseEventHandlers(new Mouse3DEventHandler(this.CubeElement_MouseEnter), new Mouse3DEventHandler(this.CubeElement_MouseLeave), new MouseButton3DEventHandler(this.CubeElement_MouseClick));
			PlaneVisual3D plane = factory(arg, this.eventManager);
			ViewCubeVisualElement viewCubeVisualElement = new ViewCubeVisualElement(type, cameraPosition, plane);
			this.cubeElements.Add(viewCubeVisualElement);
			this.MyAddToViewport(viewCubeVisualElement.Planes);
		}

		// Token: 0x06004E0E RID: 19982 RVA: 0x0015279C File Offset: 0x0015099C
		private void CreateCubeElement(CubeElementType type, PredefinedPositionsOfCamera cameraPosition, Func<MouseEventHandlers, EventManager3D, IEnumerable<PlaneVisual3D>> factory)
		{
			MouseEventHandlers arg = new MouseEventHandlers(new Mouse3DEventHandler(this.CubeElement_MouseEnter), new Mouse3DEventHandler(this.CubeElement_MouseLeave), new MouseButton3DEventHandler(this.CubeElement_MouseClick));
			IEnumerable<PlaneVisual3D> planes = factory(arg, this.eventManager);
			ViewCubeVisualElement viewCubeVisualElement = new ViewCubeVisualElement(type, cameraPosition, planes);
			this.cubeElements.Add(viewCubeVisualElement);
			this.MyAddToViewport(viewCubeVisualElement.Planes);
		}

		// Token: 0x06004E0F RID: 19983 RVA: 0x00152810 File Offset: 0x00150A10
		private void MyInitializeCubeElements()
		{
			this.cubeElements.Clear();
			this.CreateCubeElement(CubeElementType.Edge, PredefinedPositionsOfCamera.TopFront, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateFrontTopEdge(handlers, d));
			this.CreateCubeElement(CubeElementType.Edge, PredefinedPositionsOfCamera.TopBack, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateBackTopEdge(handlers, d));
			this.CreateCubeElement(CubeElementType.Edge, PredefinedPositionsOfCamera.BottomBack, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateBackBottomEdge(handlers, d));
			this.CreateCubeElement(CubeElementType.Edge, PredefinedPositionsOfCamera.BottomFront, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateFrontBottomEdge(handlers, d));
			this.CreateCubeElement(CubeElementType.Edge, PredefinedPositionsOfCamera.FrontLeft, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateFrontLeftEdge(handlers, d));
			this.CreateCubeElement(CubeElementType.Edge, PredefinedPositionsOfCamera.BackLeft, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateBackLeftEdge(handlers, d));
			this.CreateCubeElement(CubeElementType.Edge, PredefinedPositionsOfCamera.BackRight, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateBackRightEdge(handlers, d));
			this.CreateCubeElement(CubeElementType.Edge, PredefinedPositionsOfCamera.FrontRight, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateFrontRightEdge(handlers, d));
			this.CreateCubeElement(CubeElementType.Edge, PredefinedPositionsOfCamera.TopLeft, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateTopLeftEdge(handlers, d));
			this.CreateCubeElement(CubeElementType.Edge, PredefinedPositionsOfCamera.TopRight, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateTopRightEdge(handlers, d));
			this.CreateCubeElement(CubeElementType.Edge, PredefinedPositionsOfCamera.BottomRight, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateBottomRightEdge(handlers, d));
			this.CreateCubeElement(CubeElementType.Edge, PredefinedPositionsOfCamera.BottomLeft, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateBottomLeftEdge(handlers, d));
			this.CreateCubeElement(CubeElementType.Face, PredefinedPositionsOfCamera.Front, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateFrontPlane(handlers, d));
			this.CreateCubeElement(CubeElementType.Face, PredefinedPositionsOfCamera.Top, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateTopPlane(handlers, d));
			this.CreateCubeElement(CubeElementType.Face, PredefinedPositionsOfCamera.Back, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateBackPlane(handlers, d));
			this.CreateCubeElement(CubeElementType.Face, PredefinedPositionsOfCamera.Bottom, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateBottomPlane(handlers, d));
			this.CreateCubeElement(CubeElementType.Face, PredefinedPositionsOfCamera.Left, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateLeftPlane(handlers, d));
			this.CreateCubeElement(CubeElementType.Face, PredefinedPositionsOfCamera.Right, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateRightPlane(handlers, d));
			this.CreateCubeElement(CubeElementType.Vertex, PredefinedPositionsOfCamera.TopFrontLeft, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateFrontTopLeftVertex(handlers, d));
			this.CreateCubeElement(CubeElementType.Vertex, PredefinedPositionsOfCamera.TopBackLeft, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateBackTopLeftVertex(handlers, d));
			this.CreateCubeElement(CubeElementType.Vertex, PredefinedPositionsOfCamera.TopBackRight, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateBackTopRightVertex(handlers, d));
			this.CreateCubeElement(CubeElementType.Vertex, PredefinedPositionsOfCamera.TopFrontRight, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateFrontTopRightVertex(handlers, d));
			this.CreateCubeElement(CubeElementType.Vertex, PredefinedPositionsOfCamera.BottomFrontLeft, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateFrontBottomLeftVertex(handlers, d));
			this.CreateCubeElement(CubeElementType.Vertex, PredefinedPositionsOfCamera.BottomBackLeft, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateBackBottomLeftVertex(handlers, d));
			this.CreateCubeElement(CubeElementType.Vertex, PredefinedPositionsOfCamera.BottomBackRight, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateBackBottomRightVertex(handlers, d));
			this.CreateCubeElement(CubeElementType.Vertex, PredefinedPositionsOfCamera.BottomFrontRight, (MouseEventHandlers handlers, EventManager3D d) => this.viewCube.CreateFrontBottomRightVertex(handlers, d));
		}

		// Token: 0x06004E10 RID: 19984 RVA: 0x00152A60 File Offset: 0x00150C60
		private void MyAddToViewport(IEnumerable<PlaneVisual3D> planes)
		{
			foreach (PlaneVisual3D value in planes)
			{
				this.ViewCubeViewport.Children.Add(value);
			}
		}

		// Token: 0x06004E11 RID: 19985 RVA: 0x00152AC0 File Offset: 0x00150CC0
		public NewViewCubeControl()
		{
			this.InitializeComponent();
			this.AxisZLabelVisual = new BillboardTextVisual3D();
			this.AxisYLabelVisual = new BillboardTextVisual3D();
			this.AxisXArrow = new Ab3d.Visuals.ArrowVisual3D();
			this.AxisYArrow = new Ab3d.Visuals.ArrowVisual3D();
			this.AxisXLabelVisual = new BillboardTextVisual3D();
			this.AxisZArrow = new Ab3d.Visuals.ArrowVisual3D();
			this.MouseCameraController.RotationInertiaRatio = 0.0;
			this.eventManager = new EventManager3D(this.ViewCubeViewport);
			this.MyInitializeViewCube(this.CubeSize);
			CompositionTarget.Rendering += this.CompositionTarget_Rendering;
			this.ViewCubeCamera.CameraChanged += new BaseCamera.CameraChangedRoutedEventHandler(this.ViewCubeCamera_CameraChanged);
			using (MemoryStream memoryStream = new MemoryStream())
			{
				memoryStream.Write(StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.Rotate3D, 0, StructurePoint.CoreAssets.GUI.SharedResources.CustomCursors.Cursors.Rotate3D.Length);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				this.MouseCameraController.RotationCursor = new Cursor(memoryStream);
			}
		}

		// Token: 0x1400012A RID: 298
		// (add) Token: 0x06004E12 RID: 19986 RVA: 0x00152BD0 File Offset: 0x00150DD0
		// (remove) Token: 0x06004E13 RID: 19987 RVA: 0x00152C14 File Offset: 0x00150E14
		internal event EventHandler<ViewCubeClickedEventArgs> ViewCubeOnClicked;

		// Token: 0x170016B5 RID: 5813
		// (get) Token: 0x06004E14 RID: 19988 RVA: 0x0004150B File Offset: 0x0003F70B
		// (set) Token: 0x06004E15 RID: 19989 RVA: 0x00041517 File Offset: 0x0003F717
		public Rect3D FitToRectTemp { get; private set; }

		// Token: 0x170016B6 RID: 5814
		// (get) Token: 0x06004E16 RID: 19990 RVA: 0x00041528 File Offset: 0x0003F728
		// (set) Token: 0x06004E17 RID: 19991 RVA: 0x00041534 File Offset: 0x0003F734
		public Duration AnimationDuration { get; set; }

		// Token: 0x170016B7 RID: 5815
		// (get) Token: 0x06004E18 RID: 19992 RVA: 0x00041545 File Offset: 0x0003F745
		// (set) Token: 0x06004E19 RID: 19993 RVA: 0x0004155F File Offset: 0x0003F75F
		public PredefinedPositionsOfCamera DefaultPositionOfCamera
		{
			get
			{
				return (PredefinedPositionsOfCamera)base.GetValue(NewViewCubeControl.DefaultPositionOfCameraProperty);
			}
			set
			{
				base.SetValue(NewViewCubeControl.DefaultPositionOfCameraProperty, value);
			}
		}

		// Token: 0x170016B8 RID: 5816
		// (get) Token: 0x06004E1A RID: 19994 RVA: 0x0004157E File Offset: 0x0003F77E
		// (set) Token: 0x06004E1B RID: 19995 RVA: 0x00041598 File Offset: 0x0003F798
		public string AxisXLabel
		{
			get
			{
				return (string)base.GetValue(NewViewCubeControl.AxisXLabelProperty);
			}
			set
			{
				base.SetValue(NewViewCubeControl.AxisXLabelProperty, value);
			}
		}

		// Token: 0x170016B9 RID: 5817
		// (get) Token: 0x06004E1C RID: 19996 RVA: 0x000415B2 File Offset: 0x0003F7B2
		// (set) Token: 0x06004E1D RID: 19997 RVA: 0x000415CC File Offset: 0x0003F7CC
		public string AxisYLabel
		{
			get
			{
				return (string)base.GetValue(NewViewCubeControl.AxisYLabelProperty);
			}
			set
			{
				base.SetValue(NewViewCubeControl.AxisYLabelProperty, value);
			}
		}

		// Token: 0x170016BA RID: 5818
		// (get) Token: 0x06004E1E RID: 19998 RVA: 0x000415E6 File Offset: 0x0003F7E6
		// (set) Token: 0x06004E1F RID: 19999 RVA: 0x00041600 File Offset: 0x0003F800
		public string AxisZLabel
		{
			get
			{
				return (string)base.GetValue(NewViewCubeControl.AxisZLabelProperty);
			}
			set
			{
				base.SetValue(NewViewCubeControl.AxisZLabelProperty, value);
			}
		}

		// Token: 0x170016BB RID: 5819
		// (get) Token: 0x06004E20 RID: 20000 RVA: 0x0004161A File Offset: 0x0003F81A
		// (set) Token: 0x06004E21 RID: 20001 RVA: 0x00041634 File Offset: 0x0003F834
		public ViewCubeSize CubeSize
		{
			get
			{
				return (ViewCubeSize)base.GetValue(NewViewCubeControl.CubeSizeProperty);
			}
			set
			{
				base.SetValue(NewViewCubeControl.CubeSizeProperty, value);
			}
		}

		// Token: 0x170016BC RID: 5820
		// (get) Token: 0x06004E22 RID: 20002 RVA: 0x00041653 File Offset: 0x0003F853
		public ImageSource CounterClockwiseNormalButtonImageSource
		{
			get
			{
				return this.viewCube.CounterClockwiseNormalButtonImageSource;
			}
		}

		// Token: 0x170016BD RID: 5821
		// (get) Token: 0x06004E23 RID: 20003 RVA: 0x00041668 File Offset: 0x0003F868
		public ImageSource CounterClockwiseSelectedButtonImageSource
		{
			get
			{
				return this.viewCube.CounterClockwiseSelectedButtonImageSource;
			}
		}

		// Token: 0x170016BE RID: 5822
		// (get) Token: 0x06004E24 RID: 20004 RVA: 0x0004167D File Offset: 0x0003F87D
		public ImageSource ClockwiseNormalButtonImageSource
		{
			get
			{
				return this.viewCube.ClockwiseNormalButtonImageSource;
			}
		}

		// Token: 0x170016BF RID: 5823
		// (get) Token: 0x06004E25 RID: 20005 RVA: 0x00041692 File Offset: 0x0003F892
		public ImageSource ClockwiseSelectedButtonImageSource
		{
			get
			{
				return this.viewCube.ClockwiseSelectedButtonImageSource;
			}
		}

		// Token: 0x170016C0 RID: 5824
		// (get) Token: 0x06004E26 RID: 20006 RVA: 0x000416A7 File Offset: 0x0003F8A7
		public ImageSource UpNormalButtonImageSource
		{
			get
			{
				return this.viewCube.UpNormalButtonImageSource;
			}
		}

		// Token: 0x170016C1 RID: 5825
		// (get) Token: 0x06004E27 RID: 20007 RVA: 0x000416BC File Offset: 0x0003F8BC
		public ImageSource UpSelectedButtonImageSource
		{
			get
			{
				return this.viewCube.UpSelectedButtonImageSource;
			}
		}

		// Token: 0x170016C2 RID: 5826
		// (get) Token: 0x06004E28 RID: 20008 RVA: 0x000416D1 File Offset: 0x0003F8D1
		public ImageSource RightNormalButtonImageSource
		{
			get
			{
				return this.viewCube.RightNormalButtonImageSource;
			}
		}

		// Token: 0x170016C3 RID: 5827
		// (get) Token: 0x06004E29 RID: 20009 RVA: 0x000416E6 File Offset: 0x0003F8E6
		public ImageSource RightSelectedButtonImageSource
		{
			get
			{
				return this.viewCube.RightSelectedButtonImageSource;
			}
		}

		// Token: 0x170016C4 RID: 5828
		// (get) Token: 0x06004E2A RID: 20010 RVA: 0x000416FB File Offset: 0x0003F8FB
		public ImageSource DownNormalButtonImageSource
		{
			get
			{
				return this.viewCube.DownNormalButtonImageSource;
			}
		}

		// Token: 0x170016C5 RID: 5829
		// (get) Token: 0x06004E2B RID: 20011 RVA: 0x00041710 File Offset: 0x0003F910
		public ImageSource DownSelectedButtonImageSource
		{
			get
			{
				return this.viewCube.DownSelectedButtonImageSource;
			}
		}

		// Token: 0x170016C6 RID: 5830
		// (get) Token: 0x06004E2C RID: 20012 RVA: 0x00041725 File Offset: 0x0003F925
		public ImageSource LeftNormalButtonImageSource
		{
			get
			{
				return this.viewCube.LeftNormalButtonImageSource;
			}
		}

		// Token: 0x170016C7 RID: 5831
		// (get) Token: 0x06004E2D RID: 20013 RVA: 0x0004173A File Offset: 0x0003F93A
		public ImageSource LeftSelectedButtonImageSource
		{
			get
			{
				return this.viewCube.LeftSelectedButtonImageSource;
			}
		}

		// Token: 0x170016C8 RID: 5832
		// (get) Token: 0x06004E2E RID: 20014 RVA: 0x0004174F File Offset: 0x0003F94F
		// (set) Token: 0x06004E2F RID: 20015 RVA: 0x0004175B File Offset: 0x0003F95B
		internal Ab3d.Visuals.ArrowVisual3D AxisXArrow { get; private set; }

		// Token: 0x170016C9 RID: 5833
		// (get) Token: 0x06004E30 RID: 20016 RVA: 0x0004176C File Offset: 0x0003F96C
		// (set) Token: 0x06004E31 RID: 20017 RVA: 0x00041778 File Offset: 0x0003F978
		internal Ab3d.Visuals.ArrowVisual3D AxisYArrow { get; private set; }

		// Token: 0x170016CA RID: 5834
		// (get) Token: 0x06004E32 RID: 20018 RVA: 0x00041789 File Offset: 0x0003F989
		// (set) Token: 0x06004E33 RID: 20019 RVA: 0x00041795 File Offset: 0x0003F995
		internal Ab3d.Visuals.ArrowVisual3D AxisZArrow { get; private set; }

		// Token: 0x170016CB RID: 5835
		// (get) Token: 0x06004E34 RID: 20020 RVA: 0x000417A6 File Offset: 0x0003F9A6
		// (set) Token: 0x06004E35 RID: 20021 RVA: 0x000417B2 File Offset: 0x0003F9B2
		internal BillboardTextVisual3D AxisXLabelVisual { get; private set; }

		// Token: 0x170016CC RID: 5836
		// (get) Token: 0x06004E36 RID: 20022 RVA: 0x000417C3 File Offset: 0x0003F9C3
		// (set) Token: 0x06004E37 RID: 20023 RVA: 0x000417CF File Offset: 0x0003F9CF
		internal BillboardTextVisual3D AxisYLabelVisual { get; private set; }

		// Token: 0x170016CD RID: 5837
		// (get) Token: 0x06004E38 RID: 20024 RVA: 0x000417E0 File Offset: 0x0003F9E0
		// (set) Token: 0x06004E39 RID: 20025 RVA: 0x000417EC File Offset: 0x0003F9EC
		internal BillboardTextVisual3D AxisZLabelVisual { get; private set; }

		// Token: 0x06004E3A RID: 20026 RVA: 0x00152C58 File Offset: 0x00150E58
		public void NavigateToDefaultPosition()
		{
			ViewCubeClickedEventArgs viewCubeClickedEventArgs = new ViewCubeClickedEventArgs(this.DefaultPositionOfCamera, MouseButton.Left);
			this.OnViewCubeClicked(viewCubeClickedEventArgs);
		}

		// Token: 0x06004E3B RID: 20027 RVA: 0x00152C88 File Offset: 0x00150E88
		private void OnViewCubeClicked(ViewCubeClickedEventArgs viewCubeClickedEventArgs)
		{
			EventHandler<ViewCubeClickedEventArgs> viewCubeOnClicked = this.ViewCubeOnClicked;
			if (viewCubeOnClicked != null && viewCubeClickedEventArgs.MouseButton == MouseButton.Left)
			{
				viewCubeOnClicked(this, viewCubeClickedEventArgs);
			}
		}

		// Token: 0x06004E3C RID: 20028 RVA: 0x000417FD File Offset: 0x0003F9FD
		private static void MyCubeSizeChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
		{
			((NewViewCubeControl)dependencyObject).MyInitializeViewCube((ViewCubeSize)eventArgs.NewValue);
		}

		// Token: 0x06004E3D RID: 20029 RVA: 0x00152CBC File Offset: 0x00150EBC
		private void CompositionTarget_Rendering(object sender, EventArgs e)
		{
			if (!this.isInitialized)
			{
				this.MyPrepareCameraForCalculations();
				this.ViewCubeCamera.Distance = this.viewCube.CameraDistance;
				this.isInitialized = true;
				CompositionTarget.Rendering -= this.CompositionTarget_Rendering;
			}
		}

		// Token: 0x06004E3E RID: 20030 RVA: 0x00152D14 File Offset: 0x00150F14
		private void CounterClockwiseButton_Click(object sender, RoutedEventArgs e)
		{
			double num = (this.ViewCubeCamera.Bank + 90.0) % 360.0;
			double to;
			if (!false)
			{
				to = num;
			}
			this.AnimateProperty(SphericalCamera.BankProperty, this.ViewCubeCamera.Bank, to);
		}

		// Token: 0x06004E3F RID: 20031 RVA: 0x00152D68 File Offset: 0x00150F68
		private void ClockwiseButton_Click(object sender, RoutedEventArgs e)
		{
			double num = (this.ViewCubeCamera.Bank - 90.0) % 360.0;
			double to;
			if (!false)
			{
				to = num;
			}
			this.AnimateProperty(SphericalCamera.BankProperty, this.ViewCubeCamera.Bank, to);
		}

		// Token: 0x06004E40 RID: 20032 RVA: 0x00152DBC File Offset: 0x00150FBC
		private void AnimateProperty(DependencyProperty property, double from, double to)
		{
			DoubleAnimation anumation = new DoubleAnimation(from, to, this.AnimationDuration)
			{
				FillBehavior = FillBehavior.Stop
			};
			EventHandler handler = null;
			handler = delegate(object o, EventArgs eventArgs)
			{
				this.ViewCubeCamera.ApplyAnimationClock(property, null);
				anumation.Completed -= handler;
				this.ViewCubeCamera.SetCurrentValue(property, to);
			};
			anumation.Completed += handler;
			this.ViewCubeCamera.BeginAnimation(property, anumation);
		}

		// Token: 0x06004E41 RID: 20033 RVA: 0x00152E60 File Offset: 0x00151060
		private void LeftButton_Click(object sender, RoutedEventArgs e)
		{
			double num = (this.ViewCubeCamera.Heading + 90.0) % 360.0;
			double to;
			if (!false)
			{
				to = num;
			}
			this.AnimateProperty(SphericalCamera.HeadingProperty, this.ViewCubeCamera.Heading, to);
		}

		// Token: 0x06004E42 RID: 20034 RVA: 0x00152EB4 File Offset: 0x001510B4
		private void RightButton_Click(object sender, RoutedEventArgs e)
		{
			double num = (this.ViewCubeCamera.Heading - 90.0) % 360.0;
			double to;
			if (!false)
			{
				to = num;
			}
			this.AnimateProperty(SphericalCamera.HeadingProperty, this.ViewCubeCamera.Heading, to);
		}

		// Token: 0x06004E43 RID: 20035 RVA: 0x00152F08 File Offset: 0x00151108
		private void UpButton_Click(object sender, RoutedEventArgs e)
		{
			double num = (this.ViewCubeCamera.Attitude - 90.0) % 360.0;
			double to;
			if (!false)
			{
				to = num;
			}
			this.AnimateProperty(SphericalCamera.AttitudeProperty, this.ViewCubeCamera.Attitude, to);
		}

		// Token: 0x06004E44 RID: 20036 RVA: 0x00152F5C File Offset: 0x0015115C
		private void DownButton_Click(object sender, RoutedEventArgs e)
		{
			double num = (this.ViewCubeCamera.Attitude + 90.0) % 360.0;
			double to;
			if (!false)
			{
				to = num;
			}
			this.AnimateProperty(SphericalCamera.AttitudeProperty, this.ViewCubeCamera.Attitude, to);
		}

		// Token: 0x06004E45 RID: 20037 RVA: 0x00041822 File Offset: 0x0003FA22
		private void ViewCubeCamera_CameraChanged(object sender, RoutedEventArgs e)
		{
			this.FixAngles();
			this.ShowHideButtons();
		}

		// Token: 0x06004E46 RID: 20038 RVA: 0x00152FB0 File Offset: 0x001511B0
		private void FixAngles()
		{
			if (this.ViewCubeCamera.Attitude > 180.0)
			{
				this.ViewCubeCamera.Attitude -= 360.0;
			}
			else if (this.ViewCubeCamera.Attitude <= -180.0)
			{
				this.ViewCubeCamera.Attitude += 360.0;
			}
			if (this.ViewCubeCamera.Bank > 180.0)
			{
				this.ViewCubeCamera.Bank -= 360.0;
			}
			else if (this.ViewCubeCamera.Bank <= -180.0)
			{
				this.ViewCubeCamera.Bank += 360.0;
			}
			if (this.ViewCubeCamera.Heading > 180.0)
			{
				this.ViewCubeCamera.Heading -= 360.0;
				return;
			}
			if (this.ViewCubeCamera.Heading <= -180.0)
			{
				this.ViewCubeCamera.Heading += 360.0;
			}
		}

		// Token: 0x06004E47 RID: 20039 RVA: 0x0004183C File Offset: 0x0003FA3C
		private void ShowHideButton(Button button, bool show)
		{
			button.IsEnabled = show;
			button.Visibility = (show ? Visibility.Visible : Visibility.Hidden);
		}

		// Token: 0x06004E48 RID: 20040 RVA: 0x00153108 File Offset: 0x00151308
		private void ShowHideButtons()
		{
			bool show;
			bool flag = (show = (NewViewCubeControl.MyIsKnownAngle(this.ViewCubeCamera.Attitude) && NewViewCubeControl.MyIsKnownAngle(this.ViewCubeCamera.Bank) && NewViewCubeControl.MyIsKnownAngle(this.ViewCubeCamera.Heading))) && this.ViewCubeCamera.Bank == 0.0;
			bool show2 = flag && (this.ViewCubeCamera.Attitude == 0.0 || this.ViewCubeCamera.Attitude == 180.0);
			this.ShowHideButton(this.CounterClockwiseButton, show);
			this.ShowHideButton(this.ClockwiseButton, show);
			this.ShowHideButton(this.UpButton, flag);
			this.ShowHideButton(this.DownButton, flag);
			this.ShowHideButton(this.LeftButton, show2);
			this.ShowHideButton(this.RightButton, show2);
		}

		// Token: 0x06004E49 RID: 20041 RVA: 0x0015320C File Offset: 0x0015140C
		private static bool MyIsKnownAngle(double cameraAngle)
		{
			return Math.Abs(cameraAngle) == 0.0 || Math.Abs(cameraAngle) == 90.0 || Math.Abs(cameraAngle) == 180.0 || Math.Abs(cameraAngle) == 270.0;
		}

		// Token: 0x06004E4A RID: 20042 RVA: 0x0015326C File Offset: 0x0015146C
		private void MyUpdateVisibleArea(Size size)
		{
			Point3D location = new Point3D(-size.Width / 2.0, -size.Height / 2.0, 0.0);
			Size3D size2 = new Size3D(size.Width, size.Height, 0.0);
			this.visibleArea3D = new Rect3D(location, size2);
		}

		// Token: 0x06004E4B RID: 20043 RVA: 0x001532E4 File Offset: 0x001514E4
		private void MyPrepareCameraForCalculations()
		{
			this.ViewCubeCamera.BeginInit();
			this.ViewCubeCamera.Attitude = 0.0;
			this.ViewCubeCamera.Bank = 0.0;
			this.ViewCubeCamera.Heading = 0.0;
			this.ViewCubeCamera.Distance = 50.0;
			this.ViewCubeCamera.Offset = new Vector3D(0.0, 0.0, 0.0);
			this.ViewCubeCamera.TargetPosition = new Point3D(0.0, 0.0, 0.0);
			this.ViewCubeCamera.EndInit();
			this.ViewCubeCamera.Refresh();
		}

		// Token: 0x06004E4C RID: 20044 RVA: 0x001533D8 File Offset: 0x001515D8
		private void MyInitializeViewCube(ViewCubeSize size)
		{
			if (this.viewCube != null)
			{
				foreach (VisualEventSource3D eventSource in this.viewCube.EventSourceCollection)
				{
					this.eventManager.RemoveEventSource3D(eventSource);
				}
				this.viewCube.EventSourceCollection.Clear();
			}
			this.ViewCubeViewport.Children.Clear();
			if (size == ViewCubeSize.Regular)
			{
				this.viewCube = new ViewCubeVisualsHelperRegular();
			}
			else
			{
				this.viewCube = new ViewCubeVisualsHelperSmall();
			}
			this.ViewCubeViewport.Children.Add(new ModelVisual3D
			{
				Content = new AmbientLight()
			});
			this.ViewCubeViewport.Children.Add(this.viewCube.ViewCube);
			this.viewCube.CreateAxisArrows(this);
			this.viewCube.CreateAxisLabels(this);
			this.MyInitializeAxisArrows();
			this.MyInitializeAxisLabels();
			this.MyInitializeCubeElements();
			this.viewCube.ArrangeButtonsOnCanvas(this);
			this.MyUpdateVisibleArea(this.viewCube.ViewCubeSize);
			this.FitToRectTemp = this.visibleArea3D;
			this.AnimationDuration = TimeSpan.FromMilliseconds(250.0);
			this.viewCube.SetupBindings(this);
			this.OnPropertyChanged(null);
		}

		// Token: 0x06004E4D RID: 20045 RVA: 0x00153550 File Offset: 0x00151750
		private void MyInitializeAxisArrows()
		{
			this.ViewCubeViewport.Children.Add(this.AxisXArrow);
			this.ViewCubeViewport.Children.Add(this.AxisYArrow);
			this.ViewCubeViewport.Children.Add(this.AxisZArrow);
		}

		// Token: 0x06004E4E RID: 20046 RVA: 0x001535AC File Offset: 0x001517AC
		private void MyInitializeAxisLabels()
		{
			this.ViewCubeViewport.Children.Add(this.AxisXLabelVisual);
			this.ViewCubeViewport.Children.Add(this.AxisYLabelVisual);
			this.ViewCubeViewport.Children.Add(this.AxisZLabelVisual);
		}

		// Token: 0x1400012B RID: 299
		// (add) Token: 0x06004E4F RID: 20047 RVA: 0x00153608 File Offset: 0x00151808
		// (remove) Token: 0x06004E50 RID: 20048 RVA: 0x0015364C File Offset: 0x0015184C
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x06004E51 RID: 20049 RVA: 0x00153690 File Offset: 0x00151890
		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
			if (propertyChanged != null)
			{
				propertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		// Token: 0x06004E52 RID: 20050 RVA: 0x001536C0 File Offset: 0x001518C0
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri(#Phc.#3hc(107468688), UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06004E53 RID: 20051 RVA: 0x00008739 File Offset: 0x00006939
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal Delegate _CreateDelegate(Type delegateType, string handler)
		{
			return Delegate.CreateDelegate(delegateType, this, handler);
		}

		// Token: 0x06004E54 RID: 20052 RVA: 0x00153704 File Offset: 0x00151904
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
				this.ViewCubeRoot = (Grid)target;
				return;
			case 2:
				this.ViewCubeViewport = (Viewport3D)target;
				return;
			case 3:
				this.ButtonsCanvas = (Canvas)target;
				return;
			case 4:
				this.CounterClockwiseButton = (Button)target;
				this.CounterClockwiseButton.Click += this.CounterClockwiseButton_Click;
				return;
			case 5:
				this.ClockwiseButton = (Button)target;
				this.ClockwiseButton.Click += this.ClockwiseButton_Click;
				return;
			case 6:
				this.UpButton = (Button)target;
				this.UpButton.Click += this.UpButton_Click;
				return;
			case 7:
				this.RightButton = (Button)target;
				this.RightButton.Click += this.RightButton_Click;
				return;
			case 8:
				this.DownButton = (Button)target;
				this.DownButton.Click += this.DownButton_Click;
				return;
			case 9:
				this.LeftButton = (Button)target;
				this.LeftButton.Click += this.LeftButton_Click;
				return;
			case 10:
				this.ViewCubeCamera = (CustomTargetPositionCamera)target;
				return;
			case 11:
				this.MouseCameraController = (MouseCameraController)target;
				return;
			default:
				this._contentLoaded = true;
				return;
			}
		}

		// Token: 0x04002271 RID: 8817
		private readonly List<ViewCubeVisualElement> cubeElements = new List<ViewCubeVisualElement>();

		// Token: 0x04002272 RID: 8818
		public static readonly DependencyProperty DefaultPositionOfCameraProperty = DependencyProperty.Register(#Phc.#3hc(107471619), typeof(PredefinedPositionsOfCamera), typeof(NewViewCubeControl), new FrameworkPropertyMetadata(PredefinedPositionsOfCamera.Front));

		// Token: 0x04002273 RID: 8819
		public static readonly DependencyProperty AxisXLabelProperty = DependencyProperty.Register(#Phc.#3hc(107471074), typeof(string), typeof(NewViewCubeControl), new FrameworkPropertyMetadata(#Phc.#3hc(107408964)));

		// Token: 0x04002274 RID: 8820
		public static readonly DependencyProperty AxisYLabelProperty = DependencyProperty.Register(#Phc.#3hc(107471089), typeof(string), typeof(NewViewCubeControl), new FrameworkPropertyMetadata(#Phc.#3hc(107408991)));

		// Token: 0x04002275 RID: 8821
		public static readonly DependencyProperty AxisZLabelProperty = DependencyProperty.Register(#Phc.#3hc(107471040), typeof(string), typeof(NewViewCubeControl), new FrameworkPropertyMetadata(#Phc.#3hc(107397860)));

		// Token: 0x04002276 RID: 8822
		public static readonly DependencyProperty CubeSizeProperty = DependencyProperty.Register(#Phc.#3hc(107468559), typeof(ViewCubeSize), typeof(NewViewCubeControl), new FrameworkPropertyMetadata(ViewCubeSize.Regular, new PropertyChangedCallback(NewViewCubeControl.MyCubeSizeChanged)));

		// Token: 0x04002277 RID: 8823
		private readonly EventManager3D eventManager;

		// Token: 0x04002278 RID: 8824
		private IViewCubeVisualsHelper viewCube;

		// Token: 0x04002279 RID: 8825
		private Rect3D visibleArea3D;

		// Token: 0x0400227A RID: 8826
		private bool isInitialized;

		// Token: 0x04002285 RID: 8837
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal Grid ViewCubeRoot;

		// Token: 0x04002286 RID: 8838
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal Viewport3D ViewCubeViewport;

		// Token: 0x04002287 RID: 8839
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal Canvas ButtonsCanvas;

		// Token: 0x04002288 RID: 8840
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal Button CounterClockwiseButton;

		// Token: 0x04002289 RID: 8841
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal Button ClockwiseButton;

		// Token: 0x0400228A RID: 8842
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal Button UpButton;

		// Token: 0x0400228B RID: 8843
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal Button RightButton;

		// Token: 0x0400228C RID: 8844
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal Button DownButton;

		// Token: 0x0400228D RID: 8845
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal Button LeftButton;

		// Token: 0x0400228E RID: 8846
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal CustomTargetPositionCamera ViewCubeCamera;

		// Token: 0x0400228F RID: 8847
		[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
		internal MouseCameraController MouseCameraController;

		// Token: 0x04002290 RID: 8848
		private bool _contentLoaded;
	}
}
