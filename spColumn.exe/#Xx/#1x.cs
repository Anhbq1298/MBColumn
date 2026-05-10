using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using #0Kd;
using #6re;
using #eU;
using #ezc;
using #FTd;
using #hId;
using #LQc;
using #qPd;
using #sUd;
using #uLd;
using #v1c;
using StructurePoint.CoreAssets.GUI.Framework;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Application.API;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Presentation;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Logger;
using StructurePoint.CoreAssets.Units;

namespace #Xx
{
	// Token: 0x0200019A RID: 410
	internal sealed class #1x : #tLd, INotifyPropertyChanged, #RBc<#ZKd>, #Wx, #sPd, IViewModel
	{
		// Token: 0x06000D62 RID: 3426 RVA: 0x0009E05C File Offset: 0x0009C25C
		public #1x(#GBc #2x, #ZKd #Ee, ILogger #3x, #yse #iw, #v2c #4x, #tUd #5x, #8Sc #ls, #oW #Yc, #xAc #6x) : base(#2x, #Ee, #3x, #iw, #4x, #5x, #ls, #6x)
		{
			this.#a = #Yc;
			this.#b = #iw;
			this.#c = #ls;
		}

		// Token: 0x1700054F RID: 1359
		// (get) Token: 0x06000D63 RID: 3427 RVA: 0x0001062E File Offset: 0x0000E82E
		// (set) Token: 0x06000D64 RID: 3428 RVA: 0x0001063A File Offset: 0x0000E83A
		protected override string GeneratingBusyMessage { get; set; }

		// Token: 0x06000D65 RID: 3429 RVA: 0x0009E0A4 File Offset: 0x0009C2A4
		protected override void #0x()
		{
			#gId #gId = this.#b.#ey((ReporterUnitsSystem)this.#a.Model.Options.Unit, #NTd.#b);
			#gId.UnitString = ((this.#a.Model.Options.Unit == UnitSystem.SIMetric) ? Strings.StringMillimeters : Strings.StringInches);
			#gId.PageRangeOptionsVisibility = Visibility.Collapsed;
			#gId.DialogService = this.#c;
			base.View.PrintOptionsControl.Initialize(#gId);
			base.View.PrintOptionsControl.Update(new PrintOptionsSetup
			{
				PagesCount = new int?(1)
			});
		}

		// Token: 0x04000502 RID: 1282
		private readonly #oW #a;

		// Token: 0x04000503 RID: 1283
		private readonly #yse #b;

		// Token: 0x04000504 RID: 1284
		private readonly #8Sc #c;

		// Token: 0x04000505 RID: 1285
		[CompilerGenerated]
		private string #d = Strings.StringGeneratingDiagram.#B2d();
	}
}
