using System;
using System.Collections.Generic;
using System.Windows.Controls;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.API;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl.CameraPositionSetters;
using StructurePoint.CoreAssets.GUI.DesktopControls.Utils;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using Telerik.Windows.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.ViewCubeControl
{
	// Token: 0x0200095C RID: 2396
	internal sealed class RotatingCameraPositionSetterFactory : ICameraPositionSetterFactory
	{
		// Token: 0x06004EDD RID: 20189 RVA: 0x00041FB4 File Offset: 0x000401B4
		internal RotatingCameraPositionSetterFactory(IPredefinedPositionsOfCameraValuesProcessor valueProcessor)
		{
			this.valueProcessor = valueProcessor;
			this.predefinedPositionsOfCameraDictionary = this.MyCreatePredefinedPositionsOfCameraDictionary();
		}

		// Token: 0x06004EDE RID: 20190 RVA: 0x00156C78 File Offset: 0x00154E78
		CameraPositionSetterBase ICameraPositionSetterFactory.CreateCameraPositionSetter(PredefinedPositionsOfCamera predefinedPositionOfCamera, CustomTargetPositionCamera mainTargetPositionCamera, Viewport3D mainViewport, RadSlider mainScaleSlider, CustomTargetPositionCamera viewCubeTargetPositionCamera, LinearEquation equationForSlider)
		{
			#X0d.#V0d(mainTargetPositionCamera, #Phc.#3hc(107468188), Component.DesktopControls, #Phc.#3hc(107468155));
			#X0d.#V0d(mainViewport, #Phc.#3hc(107449128), Component.DesktopControls, #Phc.#3hc(107468070));
			#X0d.#V0d(mainScaleSlider, #Phc.#3hc(107468049), Component.DesktopControls, #Phc.#3hc(107467516));
			#X0d.#V0d(viewCubeTargetPositionCamera, #Phc.#3hc(107467431), Component.DesktopControls, #Phc.#3hc(107467422));
			if (this.predefinedPositionsOfCameraDictionary.ContainsKey(predefinedPositionOfCamera))
			{
				return this.predefinedPositionsOfCameraDictionary[predefinedPositionOfCamera](mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
			}
			return this.predefinedPositionsOfCameraDictionary[PredefinedPositionsOfCamera.Front](mainTargetPositionCamera, mainViewport, mainScaleSlider, viewCubeTargetPositionCamera, equationForSlider);
		}

		// Token: 0x06004EDF RID: 20191 RVA: 0x00156D54 File Offset: 0x00154F54
		private Dictionary<PredefinedPositionsOfCamera, Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>> MyCreatePredefinedPositionsOfCameraDictionary()
		{
			return new Dictionary<PredefinedPositionsOfCamera, Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>>
			{
				{
					PredefinedPositionsOfCamera.BottomBackLeft,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetBottomFrontLeftCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.BottomBackRight,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetFrontBackRightCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.TopBackRight,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetBottomBackRightCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.TopBackLeft,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetBottomBackLeftCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.BottomFrontLeft,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetTopFrontLeftCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.BottomFrontRight,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetTopFrontRightCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.TopFrontRight,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetTopBackRightCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.TopFrontLeft,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetTopBackLeftCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.BottomBack,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetBottomFrontCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.TopBack,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetBottomBackCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.TopFront,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetBackFrontCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.BottomFront,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetTopFrontCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.BackLeft,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetBottomLeftCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.BackRight,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetBottomRightCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.FrontRight,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetTopRightCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.FrontLeft,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetTopLeftCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.BottomLeft,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetFrontLeftCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.BottomRight,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetFrontRightCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.TopRight,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetBackRightCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.TopLeft,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetBackLeftCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.Bottom,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetFrontCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.Top,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetBackCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.Back,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetBottomCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.Front,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetTopCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.Left,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetLeftCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.Right,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetRightCameraPositionSetter)
				},
				{
					PredefinedPositionsOfCamera.Default,
					new Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>(this.valueProcessor.GetDefaultCameraPositionSetter)
				}
			};
		}

		// Token: 0x040022A0 RID: 8864
		private readonly IPredefinedPositionsOfCameraValuesProcessor valueProcessor;

		// Token: 0x040022A1 RID: 8865
		private readonly Dictionary<PredefinedPositionsOfCamera, Func<CustomTargetPositionCamera, Viewport3D, RadSlider, CustomTargetPositionCamera, LinearEquation, CameraPositionSetterBase>> predefinedPositionsOfCameraDictionary;
	}
}
