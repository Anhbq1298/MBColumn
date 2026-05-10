using System;
using #7hc;

namespace StructurePoint.CoreAssets.AppManager.Column.Core
{
	// Token: 0x02001398 RID: 5016
	public sealed class ColumnGlobalInfo
	{
		// Token: 0x17003099 RID: 12441
		// (get) Token: 0x0600A84F RID: 43087 RVA: 0x000827B9 File Offset: 0x000809B9
		public static string CopyrightYear { get; } = #Phc.#3hc(107309608);

		// Token: 0x1700309A RID: 12442
		// (get) Token: 0x0600A850 RID: 43088 RVA: 0x000827C0 File Offset: 0x000809C0
		public static string Copyright { get; } = #Phc.#3hc(107309631) + ColumnGlobalInfo.CopyrightYear + #Phc.#3hc(107309574);

		// Token: 0x1700309B RID: 12443
		// (get) Token: 0x0600A851 RID: 43089 RVA: 0x000827C7 File Offset: 0x000809C7
		public static string ShortName { get; } = #Phc.#3hc(107405338);

		// Token: 0x1700309C RID: 12444
		// (get) Token: 0x0600A852 RID: 43090 RVA: 0x000827CE File Offset: 0x000809CE
		public static string DefaultMessageBoxTitle { get; } = #Phc.#3hc(107405338);

		// Token: 0x1700309D RID: 12445
		// (get) Token: 0x0600A853 RID: 43091 RVA: 0x000827D5 File Offset: 0x000809D5
		public static string Version { get; } = #Phc.#3hc(107310053);

		// Token: 0x1700309E RID: 12446
		// (get) Token: 0x0600A854 RID: 43092 RVA: 0x000827DC File Offset: 0x000809DC
		public static string LongName
		{
			get
			{
				return #Phc.#3hc(107309634) + ColumnGlobalInfo.Version + #Phc.#3hc(107309649);
			}
		}

		// Token: 0x1700309F RID: 12447
		// (get) Token: 0x0600A855 RID: 43093 RVA: 0x000827FC File Offset: 0x000809FC
		public static string ProductFamily { get; } = #Phc.#3hc(107405338);

		// Token: 0x170030A0 RID: 12448
		// (get) Token: 0x0600A856 RID: 43094 RVA: 0x00082803 File Offset: 0x00080A03
		public static string LicensedVersion { get; } = #Phc.#3hc(107310076);
	}
}
