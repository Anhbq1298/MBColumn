using System;
using System.ComponentModel;
using #7hc;
using #UYd;
using #Zmb;
using StructurePoint.CoreAssets.GUI.DesktopControls.Basic;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.SharedResources.Icons.Visualization;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Services.API;

namespace #vmb
{
	// Token: 0x02000444 RID: 1092
	internal sealed class #Xmb : #Imb, INotifyPropertyChanged, IEditionToolData, #4mb, #6mb
	{
		// Token: 0x06002823 RID: 10275 RVA: 0x000DA610 File Offset: 0x000D8810
		public #Xmb(#5mb #8kb, ISettingsManager #iw) : base(#8kb, #iw)
		{
			#X0d.#V0d(#8kb, #Phc.#3hc(107360418), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.FailureSurfaceVisualization, #Phc.#3hc(107360701));
			#X0d.#V0d(#iw, #Phc.#3hc(107381742), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.FailureSurfaceVisualization, #Phc.#3hc(107360616));
			base.Header = Strings.StringRestore;
			base.ToolboxName = Strings.StringRestore;
			base.IconImage = base.FailureSurfaceToolContext.ResourcesHelper.ImageFromResourceBitmap(VisualizationIcons.Restore);
			base.ToolTipContent = new RichToolTipContent(#Phc.#3hc(107360595), #Phc.#3hc(107360550), false, false);
		}

		// Token: 0x06002824 RID: 10276 RVA: 0x000DA6B0 File Offset: 0x000D88B0
		public override void #5b()
		{
			using (base.ModelEditorControl.TransparencySorter.BeginBulkUpdate())
			{
				base.#5b();
				base.FailureSurfaceToolContext.CommandsManager.RemoveSurfacesFromVisualizationCommand.Execute();
				base.FailureSurfaceToolContext.CommandsManager.ShowBaseVisualizationCommand.Execute();
				base.ModelEditorControl.TransparencySorter.PerformTransparencySort();
			}
		}

		// Token: 0x06002825 RID: 10277 RVA: 0x000DA738 File Offset: 0x000D8938
		public override void #0kb()
		{
			using (base.ModelEditorControl.TransparencySorter.BeginBulkUpdate())
			{
				base.#0kb();
				base.ModelEditorControl.UnregisterEvents(null);
				if (base.EventManager != null)
				{
					base.EventManager.ClearAllEventSources();
				}
			}
		}
	}
}
