using System;
using System.ComponentModel;
using System.Linq;
using #7hc;
using #cPc;
using #DPc;
using #ezc;
using #IDc;
using #JPc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor;
using StructurePoint.CoreAssets.GUI.Framework;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #4Nc
{
	// Token: 0x02000BE1 RID: 3041
	internal sealed class #3Nc : #RHc, INotifyPropertyChanged, IEditionToolData, IGroupingEditionToolData, #8Hc, #ZIc, #5Nc
	{
		// Token: 0x0600632E RID: 25390 RVA: 0x001834A4 File Offset: 0x001816A4
		public #3Nc(#GBc #2x)
		{
			#X0d.#V0d(#2x, #Phc.#3hc(107417812), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107413887));
			base.AddTool(#2x.#vy<#dPc>());
			base.AddTool(#2x.#vy<#LPc>());
			base.AddTool(#2x.#vy<#FPc>());
			base.SelectedEditionToolData = base.ChildTools.First<IEditionToolData>();
			base.HelpId = HelpIdentifiers.ToolCircleGrouping;
		}
	}
}
