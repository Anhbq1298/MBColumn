using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;

namespace #Vob
{
	// Token: 0x02000455 RID: 1109
	internal sealed class #apb
	{
		// Token: 0x060028C5 RID: 10437 RVA: 0x0002579D File Offset: 0x0002399D
		public #apb()
		{
			this.#b = new List<IMultiPolyLineDrawingResult>();
		}

		// Token: 0x17000DB3 RID: 3507
		// (get) Token: 0x060028C6 RID: 10438 RVA: 0x000257B0 File Offset: 0x000239B0
		// (set) Token: 0x060028C7 RID: 10439 RVA: 0x000257BC File Offset: 0x000239BC
		public IMeshDrawingResult FailureSurface { get; set; }

		// Token: 0x17000DB4 RID: 3508
		// (get) Token: 0x060028C8 RID: 10440 RVA: 0x000257CD File Offset: 0x000239CD
		public List<IMultiPolyLineDrawingResult> Wireframe { get; }

		// Token: 0x17000DB5 RID: 3509
		// (get) Token: 0x060028C9 RID: 10441 RVA: 0x000257D9 File Offset: 0x000239D9
		public bool IsNotEmpty
		{
			get
			{
				return this.FailureSurface != null;
			}
		}

		// Token: 0x060028CA RID: 10442 RVA: 0x000DC6B4 File Offset: 0x000DA8B4
		public void #7ob(IModelEditorControl #Smb)
		{
			if (#Smb == null)
			{
				return;
			}
			using (IBulkUpdateScope bulkUpdateScope = #Smb.TransparencySorter.BeginBulkUpdate())
			{
				bulkUpdateScope.RefreshOnCompletion = false;
				if (this.FailureSurface != null && this.Wireframe.Any<IMultiPolyLineDrawingResult>())
				{
					bulkUpdateScope.RefreshOnCompletion = true;
					#Smb.AddToView(this.FailureSurface);
				}
				foreach (IMultiPolyLineDrawingResult drawingResult in this.Wireframe)
				{
					bulkUpdateScope.RefreshOnCompletion = true;
					#Smb.AddToView(drawingResult);
				}
			}
		}

		// Token: 0x060028CB RID: 10443 RVA: 0x000DC784 File Offset: 0x000DA984
		public void #8ob(IModelEditorControl #Smb)
		{
			if (#Smb == null)
			{
				return;
			}
			using (IBulkUpdateScope bulkUpdateScope = #Smb.TransparencySorter.BeginBulkUpdate())
			{
				bulkUpdateScope.RefreshOnCompletion = false;
				if (this.FailureSurface != null)
				{
					bulkUpdateScope.RefreshOnCompletion = true;
					#Smb.RemoveFromView(this.FailureSurface);
				}
				foreach (IMultiPolyLineDrawingResult drawingResult in this.Wireframe)
				{
					bulkUpdateScope.RefreshOnCompletion = true;
					#Smb.RemoveFromView(drawingResult);
				}
			}
		}

		// Token: 0x060028CC RID: 10444 RVA: 0x000257EC File Offset: 0x000239EC
		public void #9ob()
		{
			this.FailureSurface = null;
			this.Wireframe.Clear();
		}

		// Token: 0x04001031 RID: 4145
		[CompilerGenerated]
		private IMeshDrawingResult #a;

		// Token: 0x04001032 RID: 4146
		[CompilerGenerated]
		private readonly List<IMultiPolyLineDrawingResult> #b;
	}
}
