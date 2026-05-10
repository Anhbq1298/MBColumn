using System;
using System.Runtime.CompilerServices;
using #wje;

namespace StructurePoint.CoreAssets.AppManager.Column.Storage.Legacy
{
	// Token: 0x020010B5 RID: 4277
	internal sealed class DefaultColFormatReaderConfiguration : #cke
	{
		// Token: 0x060091ED RID: 37357 RVA: 0x00075654 File Offset: 0x00073854
		public DefaultColFormatReaderConfiguration()
		{
			this.GetLateralLoadsCompatibilityMode = new Func<LateralLoadsCompatibilityMode>(DefaultColFormatReaderConfiguration.<>c.<>9.#22b);
		}

		// Token: 0x17002A5D RID: 10845
		// (get) Token: 0x060091EE RID: 37358 RVA: 0x00075681 File Offset: 0x00073881
		// (set) Token: 0x060091EF RID: 37359 RVA: 0x00075689 File Offset: 0x00073889
		public Func<LateralLoadsCompatibilityMode> GetLateralLoadsCompatibilityMode { get; set; }

		// Token: 0x04003D63 RID: 15715
		[CompilerGenerated]
		private Func<LateralLoadsCompatibilityMode> #a;
	}
}
