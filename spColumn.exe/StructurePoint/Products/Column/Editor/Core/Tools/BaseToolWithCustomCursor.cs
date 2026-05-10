using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using #cMb;
using devDept.Geometry;
using StructurePoint.CoreAssets.GUI.DesktopControls.Editor.Core;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.Products.Column.Services.API;

namespace StructurePoint.Products.Column.Editor.Core.Tools
{
	// Token: 0x020004D7 RID: 1239
	internal abstract class BaseToolWithCustomCursor : #tNb
	{
		// Token: 0x06002D68 RID: 11624 RVA: 0x00028AFF File Offset: 0x00026CFF
		protected BaseToolWithCustomCursor(IExtendedServices services) : base(services)
		{
		}

		// Token: 0x17000F42 RID: 3906
		// (get) Token: 0x06002D69 RID: 11625 RVA: 0x00028B08 File Offset: 0x00026D08
		// (set) Token: 0x06002D6A RID: 11626 RVA: 0x00028B14 File Offset: 0x00026D14
		protected bool HasBeenOverViewControls { get; set; }

		// Token: 0x17000F43 RID: 3907
		// (get) Token: 0x06002D6B RID: 11627 RVA: 0x00028B25 File Offset: 0x00026D25
		// (set) Token: 0x06002D6C RID: 11628 RVA: 0x00028B31 File Offset: 0x00026D31
		protected bool IsActive { get; set; }

		// Token: 0x06002D6D RID: 11629 RVA: 0x000EE4CC File Offset: 0x000EC6CC
		protected override void #uMb()
		{
			try
			{
				this.#vMb(Cursors.Arrow);
			}
			catch (Exception exception)
			{
				base.Services.Logger.Log(LoggingLevel.Warning, new Func<string>(BaseToolWithCustomCursor.<>c.<>9.#occ), exception);
			}
		}

		// Token: 0x06002D6E RID: 11630 RVA: 0x000EE538 File Offset: 0x000EC738
		protected void #vMb(Cursor #wMb)
		{
			try
			{
				base.Editor.SetCursor(#wMb);
				base.Editor.InvalidateCursor();
			}
			catch (Exception exception)
			{
				base.Services.Logger.Log(LoggingLevel.Warning, new Func<string>(BaseToolWithCustomCursor.<>c.<>9.#pcc), exception);
			}
		}

		// Token: 0x06002D6F RID: 11631 RVA: 0x000EE5B0 File Offset: 0x000EC7B0
		protected void #vMb(byte[] #wMb)
		{
			try
			{
				base.Editor.SetCursor(#wMb);
				base.Editor.InvalidateCursor();
			}
			catch (Exception exception)
			{
				base.Services.Logger.Log(LoggingLevel.Warning, new Func<string>(BaseToolWithCustomCursor.<>c.<>9.#qcc), exception);
			}
		}

		// Token: 0x06002D70 RID: 11632 RVA: 0x00009E6A File Offset: 0x0000806A
		protected override void #Zzb()
		{
		}

		// Token: 0x06002D71 RID: 11633 RVA: 0x00028B42 File Offset: 0x00026D42
		protected void #oWh()
		{
			if (!base.Services.ToolsContext.ToolsBlockedByErrorsInLeftPanel)
			{
				this.#Zzb();
			}
			base.#qWh();
		}

		// Token: 0x06002D72 RID: 11634 RVA: 0x000EE628 File Offset: 0x000EC828
		public override void OnActivated()
		{
			base.OnActivated();
			this.IsActive = true;
			this.#oWh();
			base.Editor.ActionModeChanged -= this.#xMb;
			base.Editor.ActionModeChanged += this.#xMb;
		}

		// Token: 0x06002D73 RID: 11635 RVA: 0x00028B6E File Offset: 0x00026D6E
		public override void HandleMouseUp(MouseButtonEventArgs args, Point screenPosition, Point3D planePosition)
		{
			base.HandleMouseUp(args, screenPosition, planePosition);
			if (this.IsActive)
			{
				this.#oWh();
			}
		}

		// Token: 0x06002D74 RID: 11636 RVA: 0x00028B93 File Offset: 0x00026D93
		public override void OnDeactivated()
		{
			if (!false)
			{
				base.OnDeactivated();
			}
			this.IsActive = false;
			this.#uMb();
			base.Editor.ActionModeChanged -= this.#xMb;
		}

		// Token: 0x06002D75 RID: 11637 RVA: 0x000EE684 File Offset: 0x000EC884
		public override void HandleMouseMove(MouseEventArgs args, Point screenPosition, Point3D planePosition)
		{
			if (this.IsActive && base.Editor.IsMouseWithinVisualObjects())
			{
				this.HasBeenOverViewControls = true;
			}
			else if (this.IsActive && this.HasBeenOverViewControls)
			{
				this.#oWh();
				this.HasBeenOverViewControls = false;
			}
			base.HandleMouseMove(args, screenPosition, planePosition);
		}

		// Token: 0x06002D76 RID: 11638 RVA: 0x00028BCD File Offset: 0x00026DCD
		public override void HandleChangedState()
		{
			base.HandleChangedState();
			if (this.IsActive)
			{
				this.#oWh();
			}
		}

		// Token: 0x06002D77 RID: 11639 RVA: 0x00028BEF File Offset: 0x00026DEF
		private void #xMb(object #Ge, ActionModeChangedEventArgs #He)
		{
			if (this.IsActive)
			{
				this.#oWh();
			}
		}

		// Token: 0x04001252 RID: 4690
		[CompilerGenerated]
		private bool #a;

		// Token: 0x04001253 RID: 4691
		[CompilerGenerated]
		private bool #b;
	}
}
