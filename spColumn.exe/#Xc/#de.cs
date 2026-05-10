using System;
using System.Runtime.CompilerServices;
using System.Threading;
using #hg;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.Products.Column.Viewports.API;

namespace #Xc
{
	// Token: 0x020000AE RID: 174
	internal abstract class #de : NotifyPropertyChangedObjectBase, IViewport
	{
		// Token: 0x060005A1 RID: 1441 RVA: 0x0000A26D File Offset: 0x0000846D
		protected #de()
		{
			this.#d = Interlocked.Increment(ref #ge.#a);
		}

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x060005A2 RID: 1442
		public abstract object View { get; }

		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x060005A3 RID: 1443 RVA: 0x0000A290 File Offset: 0x00008490
		// (set) Token: 0x060005A4 RID: 1444 RVA: 0x0000A29C File Offset: 0x0000849C
		public bool IsActive { get; set; }

		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x060005A5 RID: 1445 RVA: 0x0000A2AD File Offset: 0x000084AD
		// (set) Token: 0x060005A6 RID: 1446 RVA: 0x0000A2B9 File Offset: 0x000084B9
		public #Ke Host { get; set; }

		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x060005A7 RID: 1447 RVA: 0x0000A2CA File Offset: 0x000084CA
		public #og ScopeSettings { get; }

		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x060005A8 RID: 1448 RVA: 0x0000A2D6 File Offset: 0x000084D6
		public int AutoIdentifier { get; }

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x060005A9 RID: 1449 RVA: 0x0000A2E2 File Offset: 0x000084E2
		// (set) Token: 0x060005AA RID: 1450 RVA: 0x0000A2EE File Offset: 0x000084EE
		public bool MarkedForClosing { get; set; }

		// Token: 0x060005AB RID: 1451 RVA: 0x0000A2FF File Offset: 0x000084FF
		public virtual void #Ud()
		{
			#Ke #Ke = this.Host;
			if (#Ke == null)
			{
				return;
			}
			#Ke.#1();
		}

		// Token: 0x04000132 RID: 306
		[CompilerGenerated]
		private bool #a;

		// Token: 0x04000133 RID: 307
		[CompilerGenerated]
		private #Ke #b;

		// Token: 0x04000134 RID: 308
		[CompilerGenerated]
		private readonly #og #c = new #og();

		// Token: 0x04000135 RID: 309
		[CompilerGenerated]
		private readonly int #d;

		// Token: 0x04000136 RID: 310
		[CompilerGenerated]
		private bool #e;
	}
}
