using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using devDept.Eyeshot;
using devDept.Geometry;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Tools;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.Editor.Core.Tools
{
	// Token: 0x02000501 RID: 1281
	internal abstract class BaseToolWithChildren : BaseToolWithCustomCursor
	{
		// Token: 0x06002EBB RID: 11963 RVA: 0x00029E14 File Offset: 0x00028014
		protected BaseToolWithChildren(IExtendedServices services) : base(services)
		{
		}

		// Token: 0x17000F6D RID: 3949
		// (get) Token: 0x06002EBC RID: 11964 RVA: 0x00029E28 File Offset: 0x00028028
		protected List<IChildColumnEditorTool> ChildTools { get; }

		// Token: 0x06002EBD RID: 11965 RVA: 0x000F2168 File Offset: 0x000F0368
		protected virtual bool #eMb(DynamicInputCoordinateEventArgs #Lg)
		{
			IChildColumnEditorTool childColumnEditorTool = this.#rMb();
			if (childColumnEditorTool != null)
			{
				childColumnEditorTool.HandleDynamicInputCoordinateChange(#Lg);
			}
			return childColumnEditorTool != null;
		}

		// Token: 0x06002EBE RID: 11966 RVA: 0x000F2198 File Offset: 0x000F0398
		protected bool #fMb()
		{
			IChildColumnEditorTool childColumnEditorTool = this.#rMb();
			if (childColumnEditorTool != null)
			{
				childColumnEditorTool.#1kb();
				return true;
			}
			return false;
		}

		// Token: 0x06002EBF RID: 11967 RVA: 0x000F21C4 File Offset: 0x000F03C4
		protected bool #gMb(devDept.Eyeshot.Environment.DrawSceneParams #Gfb, Point #hMb, Point3D #jzb)
		{
			IChildColumnEditorTool childColumnEditorTool = this.#rMb();
			IChildColumnEditorTool childColumnEditorTool2;
			if (!false)
			{
				childColumnEditorTool2 = childColumnEditorTool;
			}
			if (childColumnEditorTool2 != null)
			{
				childColumnEditorTool2.HandleDrawOverlay(#Gfb, #hMb, #jzb);
				return true;
			}
			return false;
		}

		// Token: 0x06002EC0 RID: 11968 RVA: 0x000F21F8 File Offset: 0x000F03F8
		protected bool #iMb(MouseButtonEventArgs #Lg, Point #hMb, Point3D #jzb)
		{
			IChildColumnEditorTool childColumnEditorTool = this.#rMb();
			IChildColumnEditorTool childColumnEditorTool2;
			if (!false)
			{
				childColumnEditorTool2 = childColumnEditorTool;
			}
			if (childColumnEditorTool2 != null)
			{
				childColumnEditorTool2.HandleMouseDown(#Lg, #hMb, #jzb);
				return true;
			}
			return false;
		}

		// Token: 0x06002EC1 RID: 11969 RVA: 0x000F222C File Offset: 0x000F042C
		protected bool #jMb(DynamicInputValueValidationEventArgs #Lg)
		{
			IChildColumnEditorTool childColumnEditorTool = this.#rMb();
			if (childColumnEditorTool != null)
			{
				childColumnEditorTool.HandleDynamicInputCoordinateValidation(#Lg);
				return true;
			}
			return false;
		}

		// Token: 0x06002EC2 RID: 11970 RVA: 0x000F225C File Offset: 0x000F045C
		protected bool #kMb(MouseEventArgs #Lg, Point #hMb, Point3D #jzb)
		{
			IChildColumnEditorTool childColumnEditorTool = this.#rMb();
			IChildColumnEditorTool childColumnEditorTool2;
			if (!false)
			{
				childColumnEditorTool2 = childColumnEditorTool;
			}
			if (childColumnEditorTool2 != null)
			{
				childColumnEditorTool2.HandleMouseMove(#Lg, #hMb, #jzb);
				return true;
			}
			return false;
		}

		// Token: 0x06002EC3 RID: 11971 RVA: 0x000F2290 File Offset: 0x000F0490
		protected bool #lMb(MouseButtonEventArgs #Lg, Point #hMb, Point3D #jzb)
		{
			IChildColumnEditorTool childColumnEditorTool = this.#rMb();
			IChildColumnEditorTool childColumnEditorTool2;
			if (!false)
			{
				childColumnEditorTool2 = childColumnEditorTool;
			}
			if (childColumnEditorTool2 != null)
			{
				childColumnEditorTool2.HandleMouseUp(#Lg, #hMb, #jzb);
				return true;
			}
			return false;
		}

		// Token: 0x06002EC4 RID: 11972 RVA: 0x000F22C4 File Offset: 0x000F04C4
		protected bool #mMb(DynamicInputCoordinateEventArgs #Lg)
		{
			IChildColumnEditorTool childColumnEditorTool = this.#rMb();
			if (childColumnEditorTool != null)
			{
				childColumnEditorTool.HandleDynamicInputCoordinateCommited(#Lg);
				return true;
			}
			return false;
		}

		// Token: 0x06002EC5 RID: 11973 RVA: 0x000F22F4 File Offset: 0x000F04F4
		protected bool #nMb(KeyEventArgs #Lg)
		{
			IChildColumnEditorTool childColumnEditorTool = this.#rMb();
			if (childColumnEditorTool != null)
			{
				childColumnEditorTool.HandleKeyUp(#Lg);
				return true;
			}
			return false;
		}

		// Token: 0x06002EC6 RID: 11974 RVA: 0x000F2324 File Offset: 0x000F0524
		protected bool #nWh(DynamicInputCoordinateSnapEventArgs #He)
		{
			IChildColumnEditorTool childColumnEditorTool = this.#rMb();
			if (childColumnEditorTool != null)
			{
				childColumnEditorTool.HandleDynamicInputCoordinateSnapRequested(#He);
				return true;
			}
			return false;
		}

		// Token: 0x06002EC7 RID: 11975 RVA: 0x000F2354 File Offset: 0x000F0554
		protected bool #pMb()
		{
			IChildColumnEditorTool childColumnEditorTool = this.#rMb();
			IChildColumnEditorTool childColumnEditorTool2;
			if (!false)
			{
				childColumnEditorTool2 = childColumnEditorTool;
			}
			if (childColumnEditorTool2 != null)
			{
				base.Editor.DeactivateTool((EyeshotEditorTool)childColumnEditorTool2);
				return true;
			}
			return false;
		}

		// Token: 0x06002EC8 RID: 11976 RVA: 0x000F2390 File Offset: 0x000F0590
		protected bool #qMb(KeyEventArgs #Lg)
		{
			IChildColumnEditorTool childColumnEditorTool = this.#rMb();
			if (childColumnEditorTool != null)
			{
				childColumnEditorTool.HandleKeyDown(#Lg);
				return true;
			}
			return false;
		}

		// Token: 0x06002EC9 RID: 11977 RVA: 0x00029E34 File Offset: 0x00028034
		protected IChildColumnEditorTool #rMb()
		{
			return this.ChildTools.FirstOrDefault(new Func<IChildColumnEditorTool, bool>(BaseToolWithChildren.<>c.<>9.#ncc));
		}

		// Token: 0x040012C6 RID: 4806
		[CompilerGenerated]
		private readonly List<IChildColumnEditorTool> #a = new List<IChildColumnEditorTool>();
	}
}
