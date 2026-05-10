using System;
using System.Windows.Media;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.Data
{
	// Token: 0x02000A28 RID: 2600
	public sealed class LineFormat
	{
		// Token: 0x06005618 RID: 22040 RVA: 0x00047503 File Offset: 0x00045703
		public LineFormat(Color color, double thickness)
		{
			#X0d.#U0d(thickness, #Phc.#3hc(107429623), Component.DesktopControls, #Phc.#3hc(107429578));
			this.Color = color;
			this.Thickness = thickness;
		}

		// Token: 0x170018C9 RID: 6345
		// (get) Token: 0x06005619 RID: 22041 RVA: 0x00047534 File Offset: 0x00045734
		// (set) Token: 0x0600561A RID: 22042 RVA: 0x00047540 File Offset: 0x00045740
		public Color Color { get; private set; }

		// Token: 0x170018CA RID: 6346
		// (get) Token: 0x0600561B RID: 22043 RVA: 0x00047551 File Offset: 0x00045751
		// (set) Token: 0x0600561C RID: 22044 RVA: 0x0004755D File Offset: 0x0004575D
		public double Thickness { get; private set; }
	}
}
