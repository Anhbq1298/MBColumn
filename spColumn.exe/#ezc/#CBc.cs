using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.GUI.Framework;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Logger;

namespace #ezc
{
	// Token: 0x020001A0 RID: 416
	internal abstract class #CBc<#fx> : NotifyPropertyChangedObjectBase, INotifyPropertyChanged, #RBc<!0>, IViewModel where #fx : #QBc
	{
		// Token: 0x06000D93 RID: 3475 RVA: 0x0009F02C File Offset: 0x0009D22C
		protected #CBc(#GBc #2x, #fx #Ee, ILogger #3x)
		{
			#X0d.#V0d(#2x, #Phc.#3hc(107417812), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107417702));
			this.DependencyResolver = #2x;
			this.View = #Ee;
			this.Logger = #3x;
			this.ApplicationInfoProvider = #2x.#vy<#xAc>();
		}

		// Token: 0x06000D94 RID: 3476 RVA: 0x000107AD File Offset: 0x0000E9AD
		protected #CBc(#fx #Ee)
		{
			this.View = #Ee;
		}

		// Token: 0x17000559 RID: 1369
		// (get) Token: 0x06000D95 RID: 3477 RVA: 0x000107BC File Offset: 0x0000E9BC
		// (set) Token: 0x06000D96 RID: 3478 RVA: 0x000107C4 File Offset: 0x0000E9C4
		public #xAc ApplicationInfoProvider { get; private set; }

		// Token: 0x1700055A RID: 1370
		// (get) Token: 0x06000D97 RID: 3479 RVA: 0x000107CD File Offset: 0x0000E9CD
		// (set) Token: 0x06000D98 RID: 3480 RVA: 0x000107D5 File Offset: 0x0000E9D5
		private protected #GBc DependencyResolver { protected get; private set; }

		// Token: 0x1700055B RID: 1371
		// (get) Token: 0x06000D99 RID: 3481 RVA: 0x000107DE File Offset: 0x0000E9DE
		// (set) Token: 0x06000D9A RID: 3482 RVA: 0x000107E6 File Offset: 0x0000E9E6
		public ILogger Logger { get; private set; }

		// Token: 0x1700055C RID: 1372
		// (get) Token: 0x06000D9B RID: 3483 RVA: 0x000107EF File Offset: 0x0000E9EF
		// (set) Token: 0x06000D9C RID: 3484 RVA: 0x000107F7 File Offset: 0x0000E9F7
		public #fx View { get; private set; }

		// Token: 0x1700055D RID: 1373
		// (get) Token: 0x06000D9D RID: 3485 RVA: 0x0009F07C File Offset: 0x0009D27C
		public virtual string ViewTitle
		{
			get
			{
				#fx #fx = this.View;
				#fx #fx2;
				if (7 != 0)
				{
					#fx2 = #fx;
				}
				return #fx2.Title;
			}
		}

		// Token: 0x04000522 RID: 1314
		[CompilerGenerated]
		private #xAc #a;

		// Token: 0x04000523 RID: 1315
		[CompilerGenerated]
		private #GBc #b;

		// Token: 0x04000524 RID: 1316
		[CompilerGenerated]
		private ILogger #c;

		// Token: 0x04000525 RID: 1317
		[CompilerGenerated]
		private #fx #d;
	}
}
