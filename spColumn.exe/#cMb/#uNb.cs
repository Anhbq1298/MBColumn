using System;
using System.Drawing;
using System.Windows.Input;
using devDept.Eyeshot;
using devDept.Geometry;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;

namespace #cMb
{
	// Token: 0x020004DB RID: 1243
	internal interface #uNb
	{
		// Token: 0x17000F57 RID: 3927
		// (get) Token: 0x06002DD8 RID: 11736
		IView ParametersView { get; }

		// Token: 0x06002DD9 RID: 11737
		void #1kb();

		// Token: 0x06002DDA RID: 11738
		void HandleMouseUp(MouseButtonEventArgs args, Point screenPosition, Point3D planePosition);

		// Token: 0x06002DDB RID: 11739
		void HandleMouseDown(MouseButtonEventArgs args, Point screenPosition, Point3D planePosition);

		// Token: 0x06002DDC RID: 11740
		void HandleMouseMove(MouseEventArgs args, Point screenPosition, Point3D planePosition);

		// Token: 0x06002DDD RID: 11741
		void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, Point screenPosition, Point3D planePosition);

		// Token: 0x06002DDE RID: 11742
		void HandleKeyDown(KeyEventArgs args);

		// Token: 0x06002DDF RID: 11743
		void HandleKeyUp(KeyEventArgs args);

		// Token: 0x06002DE0 RID: 11744
		void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args);

		// Token: 0x06002DE1 RID: 11745
		void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args);

		// Token: 0x06002DE2 RID: 11746
		void HandleDynamicInputCoordinateValidation(DynamicInputValueValidationEventArgs args);

		// Token: 0x06002DE3 RID: 11747
		void HandleDynamicInputCoordinateSnapRequested(DynamicInputCoordinateSnapEventArgs args);
	}
}
