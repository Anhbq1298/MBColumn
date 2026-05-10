using System;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000942 RID: 2370
	public static class ModelEditorConfiguration
	{
		// Token: 0x17001678 RID: 5752
		// (get) Token: 0x06004D72 RID: 19826 RVA: 0x00040F47 File Offset: 0x0003F147
		// (set) Token: 0x06004D73 RID: 19827 RVA: 0x00040F4E File Offset: 0x0003F14E
		public static double CameraReferenceDistanceMultiplier
		{
			get
			{
				return ModelEditorConfiguration.cameraReferenceDistanceMultiplier;
			}
			set
			{
				ModelEditorConfiguration.cameraReferenceDistanceMultiplier = value;
			}
		}

		// Token: 0x17001679 RID: 5753
		// (get) Token: 0x06004D74 RID: 19828 RVA: 0x00040F5A File Offset: 0x0003F15A
		// (set) Token: 0x06004D75 RID: 19829 RVA: 0x00040F61 File Offset: 0x0003F161
		public static double CameraReferenceWidthMultiplier
		{
			get
			{
				return ModelEditorConfiguration.cameraReferenceWidthMultiplier;
			}
			set
			{
				ModelEditorConfiguration.cameraReferenceWidthMultiplier = value;
			}
		}

		// Token: 0x04002215 RID: 8725
		private static double cameraReferenceDistanceMultiplier = 10.0;

		// Token: 0x04002216 RID: 8726
		private static double cameraReferenceWidthMultiplier = 10.0;

		// Token: 0x04002217 RID: 8727
		internal const double DistanceScaleSliderMinimumFallbackValue = 0.0;

		// Token: 0x04002218 RID: 8728
		internal const double DistanceScaleSliderMaximumFallbackValue = 1.0;

		// Token: 0x04002219 RID: 8729
		internal const double DistanceScaleSliderValueFallbackValue = 0.5;

		// Token: 0x0400221A RID: 8730
		internal const string DistanceScaleSliderValueLabelFormat = "{0} %";

		// Token: 0x0400221B RID: 8731
		internal const double WidthScaleSliderMinimumFallbackValue = 0.0;

		// Token: 0x0400221C RID: 8732
		internal const double WidthScaleSliderMaximumFallbackValue = 1.0;

		// Token: 0x0400221D RID: 8733
		internal const double WidthScaleSliderValueFallbackValue = 0.5;

		// Token: 0x0400221E RID: 8734
		internal const string WidthScaleSliderValueLabelFormat = "P0";

		// Token: 0x0400221F RID: 8735
		internal const double CameraDefaultReferenceDistance = 240.0;

		// Token: 0x04002220 RID: 8736
		internal const double CameraDefaultMaxReferenceDistanceMultiplier = 10000.0;

		// Token: 0x04002221 RID: 8737
		internal const double CameraDefaultMinReferenceDistanceMultiplier = 10.0;

		// Token: 0x04002222 RID: 8738
		internal const MouseAndKeyboardCondition DefaultTranslateViewCondition = MouseAndKeyboardCondition.MiddleMouseButtonPressed;

		// Token: 0x04002223 RID: 8739
		internal const MouseAndKeyboardCondition DefaultRotateViewCondition = MouseAndKeyboardCondition.MiddleMouseButtonPressed | MouseAndKeyboardCondition.ShiftKey;
	}
}
