using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using #IDc;
using #Zmb;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.Products.Column.Services.API;

namespace #vmb
{
	// Token: 0x02000433 RID: 1075
	internal class #Imb : #3Ec, INotifyPropertyChanged, IEditionToolData, #4mb
	{
		// Token: 0x06002724 RID: 10020 RVA: 0x000D831C File Offset: 0x000D651C
		public #Imb(#5mb #8kb, ISettingsManager #iw) : base(#8kb.ModelEditorControl)
		{
			this.#d = #8kb;
			base.IsEnabled = true;
			this.#f = #8kb.ModelEditorControl;
			#8kb.FailureSurfaceContext.FailureSurfaceLoaded += this.#ulb;
			#8kb.FailureSurfaceContext.FailureSurfaceVisibilityChanged += this.#Fmb;
			#8kb.FailureSurfaceContext.ViewportCleaned += this.#tlb;
			#8kb.FailureSurfaceContext.ViewportPopulated += this.#slb;
		}

		// Token: 0x17000D2A RID: 3370
		// (get) Token: 0x06002725 RID: 10021 RVA: 0x00024AB7 File Offset: 0x00022CB7
		// (set) Token: 0x06002726 RID: 10022 RVA: 0x00024AC3 File Offset: 0x00022CC3
		public string ToolboxName { get; protected set; }

		// Token: 0x17000D2B RID: 3371
		// (get) Token: 0x06002727 RID: 10023 RVA: 0x00024AD4 File Offset: 0x00022CD4
		public #5mb FailureSurfaceToolContext { get; }

		// Token: 0x17000D2C RID: 3372
		// (get) Token: 0x06002728 RID: 10024 RVA: 0x00024AE0 File Offset: 0x00022CE0
		// (set) Token: 0x06002729 RID: 10025 RVA: 0x00024AEC File Offset: 0x00022CEC
		protected IEventManager EventManager { get; set; }

		// Token: 0x17000D2D RID: 3373
		// (get) Token: 0x0600272A RID: 10026 RVA: 0x00024AFD File Offset: 0x00022CFD
		protected IModelEditorControl ModelEditorControl { get; }

		// Token: 0x0600272B RID: 10027 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void #tfb()
		{
		}

		// Token: 0x0600272C RID: 10028 RVA: 0x00009E6A File Offset: 0x0000806A
		public virtual void #1kb()
		{
		}

		// Token: 0x0600272D RID: 10029 RVA: 0x00024B09 File Offset: 0x00022D09
		protected void #Cmb(ref IEventSource #Dmb)
		{
			if (#Dmb != null)
			{
				this.EventManager.RemoveEventSource(#Dmb);
				#Dmb = null;
			}
		}

		// Token: 0x0600272E RID: 10030 RVA: 0x00024B2B File Offset: 0x00022D2B
		protected override void #2kb(KeyEventArgs #HA)
		{
			if (#HA != null && #HA.Key == Key.Escape)
			{
				this.#1kb();
				return;
			}
			base.#2kb(#HA);
		}

		// Token: 0x0600272F RID: 10031 RVA: 0x00009E6A File Offset: 0x0000806A
		protected override void #Emb(EventArgs #HA)
		{
		}

		// Token: 0x06002730 RID: 10032 RVA: 0x000D83AC File Offset: 0x000D65AC
		protected void #tO(MouseEventArgs3D #He)
		{
			if (this.ModelEditorControl.SuspendEvents || #He == null || #He.HitMousePosition == null)
			{
				return;
			}
			this.#Gmb(#He.HitMousePosition.Value);
		}

		// Token: 0x06002731 RID: 10033 RVA: 0x00009E6A File Offset: 0x0000806A
		private void #tlb(object #Ge, EventArgs #He)
		{
		}

		// Token: 0x06002732 RID: 10034 RVA: 0x00024B54 File Offset: 0x00022D54
		private void #slb(object #Ge, EventArgs #He)
		{
			this.ModelEditorControl.TransparencySorter.Refresh();
		}

		// Token: 0x06002733 RID: 10035 RVA: 0x00009E6A File Offset: 0x0000806A
		private void #Fmb(object #Ge, EventArgs #He)
		{
		}

		// Token: 0x06002734 RID: 10036 RVA: 0x000D83FC File Offset: 0x000D65FC
		private void #ulb(object #Ge, EventArgs #He)
		{
			if (this.EventManager == null)
			{
				this.EventManager = this.FailureSurfaceToolContext.FailureSurfaceContext.FailureSurface.EventManagerFactory.CreateEventManager(this.FailureSurfaceToolContext.ModelEditorControl);
			}
			this.EventManager.ClearAllEventSources();
			this.EventManager.RegisterExcludedVisual3D(this.FailureSurfaceToolContext.FailureSurfaceContext.TransparentBox);
		}

		// Token: 0x06002735 RID: 10037 RVA: 0x000D8470 File Offset: 0x000D6670
		private void #Gmb(Point3D #Hmb)
		{
			Point3D #9mb = this.FailureSurfaceToolContext.FailureSurfaceViewModel.FailureSurface.#vob(#Hmb);
			this.FailureSurfaceToolContext.GuiController.EditorStatusBar.Diagram3D.#8mb(#9mb);
		}

		// Token: 0x04000F88 RID: 3976
		private IEventSource #a;

		// Token: 0x04000F89 RID: 3977
		private IEventSource #b;

		// Token: 0x04000F8A RID: 3978
		[CompilerGenerated]
		private string #c;

		// Token: 0x04000F8B RID: 3979
		[CompilerGenerated]
		private readonly #5mb #d;

		// Token: 0x04000F8C RID: 3980
		[CompilerGenerated]
		private IEventManager #e;

		// Token: 0x04000F8D RID: 3981
		[CompilerGenerated]
		private readonly IModelEditorControl #f;
	}
}
