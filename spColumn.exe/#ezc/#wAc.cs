using System;
using System.Collections.Generic;
using #2ic;
using StructurePoint.CoreAssets.DataExchange.ExternFormat;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;

namespace #ezc
{
	// Token: 0x02000B46 RID: 2886
	internal interface #wAc
	{
		// Token: 0x06005E42 RID: 24130
		IMultilineDrawingResult #Pb(IEnumerable<ILine> #Usb, double #kAc);

		// Token: 0x06005E43 RID: 24131
		IPolygonsDrawingResult #Pb(IEnumerable<#pjc> #lAc, double #kAc);

		// Token: 0x06005E44 RID: 24132
		IPointsDrawingResult #Pb(IEnumerable<IPoint> #BP, double #kAc);

		// Token: 0x06005E45 RID: 24133
		IPolygonsDrawingResult #Pb(IEnumerable<#tjc> #mAc, double #kAc);

		// Token: 0x06005E46 RID: 24134
		IPolygonsDrawingResult #Pb(IEnumerable<#fjc> #nAc, double #kAc);

		// Token: 0x06005E47 RID: 24135
		IEnumerable<IMultilineDrawingResult> #Pb(IEnumerable<#sjc> #oAc, double #kAc);
	}
}
