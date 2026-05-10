using System;
using System.Drawing;
using System.Windows.Input;
using devDept.Eyeshot;
using devDept.Geometry;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Tools
{
	// Token: 0x020004DA RID: 1242
	public abstract class EyeshotEditorTool : NotifyPropertyChangedObjectBase
	{
		// Token: 0x06002DC9 RID: 11721 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void OnActivated()
		{
		}

		// Token: 0x06002DCA RID: 11722 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void OnDeactivated()
		{
		}

		// Token: 0x06002DCB RID: 11723 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void HandleKeyDown(KeyEventArgs args)
		{
		}

		// Token: 0x06002DCC RID: 11724 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void HandleKeyUp(KeyEventArgs args)
		{
		}

		// Token: 0x06002DCD RID: 11725 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void HandleMouseUp(MouseButtonEventArgs args, Point screenPosition, Point3D planePosition)
		{
		}

		// Token: 0x06002DCE RID: 11726 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void HandleMouseDown(MouseButtonEventArgs args, Point screenPosition, Point3D planePosition)
		{
		}

		// Token: 0x06002DCF RID: 11727 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void HandleMouseMove(MouseEventArgs args, Point screenPosition, Point3D planePosition)
		{
		}

		// Token: 0x06002DD0 RID: 11728 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void HandleBeginMouseMove(MouseEventArgs args, Point screenPosition, Point3D planePosition)
		{
		}

		// Token: 0x06002DD1 RID: 11729 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void HandleDrawOverlay(devDept.Eyeshot.Environment.DrawSceneParams data, Point screenPosition, Point3D planePosition)
		{
		}

		// Token: 0x06002DD2 RID: 11730 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void HandleDynamicInputCoordinateChange(DynamicInputCoordinateEventArgs args)
		{
		}

		// Token: 0x06002DD3 RID: 11731 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void HandleDynamicInputCoordinateCommited(DynamicInputCoordinateEventArgs args)
		{
		}

		// Token: 0x06002DD4 RID: 11732 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void HandleDynamicInputCoordinateValidation(DynamicInputValueValidationEventArgs args)
		{
		}

		// Token: 0x06002DD5 RID: 11733 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void HandleDynamicInputCoordinateSnapRequested(DynamicInputCoordinateSnapEventArgs args)
		{
		}

		// Token: 0x06002DD6 RID: 11734 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void HandleChangedState()
		{
		}
	}
}
