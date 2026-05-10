using System;
using System.Windows;
using #7hc;
using Ab3d.Controls;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor
{
	// Token: 0x02000945 RID: 2373
	internal static class ModelEditorEnumsHelper
	{
		// Token: 0x06004D81 RID: 19841 RVA: 0x0000EFC3 File Offset: 0x0000D1C3
		public static MouseCameraController.MouseAndKeyboardConditions ConvertToProviderValue(MouseAndKeyboardCondition mouseAndKeyboardCondition)
		{
			return (MouseCameraController.MouseAndKeyboardConditions)mouseAndKeyboardCondition;
		}

		// Token: 0x06004D82 RID: 19842 RVA: 0x0014ED34 File Offset: 0x0014CF34
		public static void ApplyAlignments(FrameworkElement frameworkElement, FrameworkElement viewCube, ToolsPanelPosition position)
		{
			switch (position)
			{
			case ToolsPanelPosition.TopLeft:
				frameworkElement.HorizontalAlignment = (viewCube.HorizontalAlignment = HorizontalAlignment.Left);
				frameworkElement.VerticalAlignment = VerticalAlignment.Top;
				viewCube.VerticalAlignment = VerticalAlignment.Bottom;
				return;
			case ToolsPanelPosition.TopRight:
				frameworkElement.HorizontalAlignment = (viewCube.HorizontalAlignment = HorizontalAlignment.Right);
				frameworkElement.VerticalAlignment = VerticalAlignment.Top;
				viewCube.VerticalAlignment = VerticalAlignment.Bottom;
				return;
			case ToolsPanelPosition.BottomLeft:
				frameworkElement.HorizontalAlignment = (viewCube.HorizontalAlignment = HorizontalAlignment.Left);
				frameworkElement.VerticalAlignment = VerticalAlignment.Bottom;
				viewCube.VerticalAlignment = VerticalAlignment.Top;
				return;
			case ToolsPanelPosition.BottomRight:
				frameworkElement.HorizontalAlignment = (viewCube.HorizontalAlignment = HorizontalAlignment.Right);
				frameworkElement.VerticalAlignment = VerticalAlignment.Bottom;
				viewCube.VerticalAlignment = VerticalAlignment.Top;
				return;
			default:
				throw new ArgumentOutOfRangeException(#Phc.#3hc(107478158));
			}
		}
	}
}
