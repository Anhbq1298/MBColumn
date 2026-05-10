using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Ab3d.Utilities;
using Ab3d.Visuals;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.API
{
	// Token: 0x02000952 RID: 2386
	internal interface IViewCubeVisualsHelper
	{
		// Token: 0x170016A3 RID: 5795
		// (get) Token: 0x06004DD7 RID: 19927
		MultiMaterialBoxVisual3D ViewCube { get; }

		// Token: 0x170016A4 RID: 5796
		// (get) Token: 0x06004DD8 RID: 19928
		// (set) Token: 0x06004DD9 RID: 19929
		List<VisualEventSource3D> EventSourceCollection { get; set; }

		// Token: 0x170016A5 RID: 5797
		// (get) Token: 0x06004DDA RID: 19930
		Size ViewCubeSize { get; }

		// Token: 0x170016A6 RID: 5798
		// (get) Token: 0x06004DDB RID: 19931
		double CameraDistance { get; }

		// Token: 0x170016A7 RID: 5799
		// (get) Token: 0x06004DDC RID: 19932
		Material TransparentMaterial { get; }

		// Token: 0x170016A8 RID: 5800
		// (get) Token: 0x06004DDD RID: 19933
		Material SemiTransparentMaterial { get; }

		// Token: 0x170016A9 RID: 5801
		// (get) Token: 0x06004DDE RID: 19934
		ImageSource CounterClockwiseNormalButtonImageSource { get; }

		// Token: 0x170016AA RID: 5802
		// (get) Token: 0x06004DDF RID: 19935
		ImageSource CounterClockwiseSelectedButtonImageSource { get; }

		// Token: 0x170016AB RID: 5803
		// (get) Token: 0x06004DE0 RID: 19936
		ImageSource ClockwiseNormalButtonImageSource { get; }

		// Token: 0x170016AC RID: 5804
		// (get) Token: 0x06004DE1 RID: 19937
		ImageSource ClockwiseSelectedButtonImageSource { get; }

		// Token: 0x170016AD RID: 5805
		// (get) Token: 0x06004DE2 RID: 19938
		ImageSource UpNormalButtonImageSource { get; }

		// Token: 0x170016AE RID: 5806
		// (get) Token: 0x06004DE3 RID: 19939
		ImageSource UpSelectedButtonImageSource { get; }

		// Token: 0x170016AF RID: 5807
		// (get) Token: 0x06004DE4 RID: 19940
		ImageSource RightNormalButtonImageSource { get; }

		// Token: 0x170016B0 RID: 5808
		// (get) Token: 0x06004DE5 RID: 19941
		ImageSource RightSelectedButtonImageSource { get; }

		// Token: 0x170016B1 RID: 5809
		// (get) Token: 0x06004DE6 RID: 19942
		ImageSource DownNormalButtonImageSource { get; }

		// Token: 0x170016B2 RID: 5810
		// (get) Token: 0x06004DE7 RID: 19943
		ImageSource DownSelectedButtonImageSource { get; }

		// Token: 0x170016B3 RID: 5811
		// (get) Token: 0x06004DE8 RID: 19944
		ImageSource LeftNormalButtonImageSource { get; }

		// Token: 0x170016B4 RID: 5812
		// (get) Token: 0x06004DE9 RID: 19945
		ImageSource LeftSelectedButtonImageSource { get; }

		// Token: 0x06004DEA RID: 19946
		IEnumerable<PlaneVisual3D> CreateFrontTopEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004DEB RID: 19947
		IEnumerable<PlaneVisual3D> CreateBackTopEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004DEC RID: 19948
		IEnumerable<PlaneVisual3D> CreateBackBottomEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004DED RID: 19949
		IEnumerable<PlaneVisual3D> CreateFrontBottomEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004DEE RID: 19950
		IEnumerable<PlaneVisual3D> CreateFrontLeftEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004DEF RID: 19951
		IEnumerable<PlaneVisual3D> CreateBackLeftEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004DF0 RID: 19952
		IEnumerable<PlaneVisual3D> CreateBackRightEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004DF1 RID: 19953
		IEnumerable<PlaneVisual3D> CreateFrontRightEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004DF2 RID: 19954
		IEnumerable<PlaneVisual3D> CreateTopLeftEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004DF3 RID: 19955
		IEnumerable<PlaneVisual3D> CreateTopRightEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004DF4 RID: 19956
		IEnumerable<PlaneVisual3D> CreateBottomRightEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004DF5 RID: 19957
		IEnumerable<PlaneVisual3D> CreateBottomLeftEdge(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004DF6 RID: 19958
		IEnumerable<PlaneVisual3D> CreateFrontTopLeftVertex(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004DF7 RID: 19959
		IEnumerable<PlaneVisual3D> CreateBackTopLeftVertex(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004DF8 RID: 19960
		IEnumerable<PlaneVisual3D> CreateBackTopRightVertex(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004DF9 RID: 19961
		IEnumerable<PlaneVisual3D> CreateFrontTopRightVertex(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004DFA RID: 19962
		IEnumerable<PlaneVisual3D> CreateFrontBottomLeftVertex(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004DFB RID: 19963
		IEnumerable<PlaneVisual3D> CreateBackBottomLeftVertex(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004DFC RID: 19964
		IEnumerable<PlaneVisual3D> CreateBackBottomRightVertex(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004DFD RID: 19965
		IEnumerable<PlaneVisual3D> CreateFrontBottomRightVertex(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004DFE RID: 19966
		PlaneVisual3D CreateFrontPlane(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004DFF RID: 19967
		PlaneVisual3D CreateTopPlane(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004E00 RID: 19968
		PlaneVisual3D CreateBackPlane(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004E01 RID: 19969
		PlaneVisual3D CreateBottomPlane(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004E02 RID: 19970
		PlaneVisual3D CreateLeftPlane(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004E03 RID: 19971
		PlaneVisual3D CreateRightPlane(MouseEventHandlers mouseEventHandlers, EventManager3D eventManager);

		// Token: 0x06004E04 RID: 19972
		void CreateViewCubeBox();

		// Token: 0x06004E05 RID: 19973
		void CreateAxisArrows(NewViewCubeControl viewCube);

		// Token: 0x06004E06 RID: 19974
		void CreateAxisLabels(NewViewCubeControl viewCube);

		// Token: 0x06004E07 RID: 19975
		void ArrangeButtonsOnCanvas(NewViewCubeControl viewCube);

		// Token: 0x06004E08 RID: 19976
		void SetupBindings(NewViewCubeControl viewCube);
	}
}
