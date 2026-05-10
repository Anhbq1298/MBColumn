using System;
using System.Collections.Generic;
using System.Windows.Media;
using #7hc;

namespace StructurePoint.CoreAssets.Column.Core.Templates.Rendering
{
	// Token: 0x02000864 RID: 2148
	public sealed class TemplateRenderOptions
	{
		// Token: 0x17001409 RID: 5129
		// (get) Token: 0x06004447 RID: 17479 RVA: 0x00039094 File Offset: 0x00037294
		// (set) Token: 0x06004448 RID: 17480 RVA: 0x0003909C File Offset: 0x0003729C
		public Color BarsColor { get; set; }

		// Token: 0x1700140A RID: 5130
		// (get) Token: 0x06004449 RID: 17481 RVA: 0x000390A5 File Offset: 0x000372A5
		// (set) Token: 0x0600444A RID: 17482 RVA: 0x000390AD File Offset: 0x000372AD
		public Color BarPointColor { get; set; }

		// Token: 0x1700140B RID: 5131
		// (get) Token: 0x0600444B RID: 17483 RVA: 0x000390B6 File Offset: 0x000372B6
		// (set) Token: 0x0600444C RID: 17484 RVA: 0x000390BE File Offset: 0x000372BE
		public Color SolidsColor { get; set; }

		// Token: 0x1700140C RID: 5132
		// (get) Token: 0x0600444D RID: 17485 RVA: 0x000390C7 File Offset: 0x000372C7
		// (set) Token: 0x0600444E RID: 17486 RVA: 0x000390CF File Offset: 0x000372CF
		public Color OpeningsColor { get; set; }

		// Token: 0x1700140D RID: 5133
		// (get) Token: 0x0600444F RID: 17487 RVA: 0x000390D8 File Offset: 0x000372D8
		// (set) Token: 0x06004450 RID: 17488 RVA: 0x000390E0 File Offset: 0x000372E0
		public string FontName { get; set; } = #Phc.#3hc(107399885);

		// Token: 0x1700140E RID: 5134
		// (get) Token: 0x06004451 RID: 17489 RVA: 0x000390E9 File Offset: 0x000372E9
		// (set) Token: 0x06004452 RID: 17490 RVA: 0x000390F1 File Offset: 0x000372F1
		public float FontSize { get; set; } = 10f;

		// Token: 0x1700140F RID: 5135
		// (get) Token: 0x06004453 RID: 17491 RVA: 0x000390FA File Offset: 0x000372FA
		// (set) Token: 0x06004454 RID: 17492 RVA: 0x00039102 File Offset: 0x00037302
		public Color FontColor { get; set; }

		// Token: 0x17001410 RID: 5136
		// (get) Token: 0x06004455 RID: 17493 RVA: 0x0003910B File Offset: 0x0003730B
		public List<ZoneInfo> ZoneInfos { get; } = new List<ZoneInfo>();

		// Token: 0x17001411 RID: 5137
		// (get) Token: 0x06004456 RID: 17494 RVA: 0x0013B0D8 File Offset: 0x001392D8
		public static TemplateRenderOptions Default
		{
			get
			{
				return new TemplateRenderOptions
				{
					SolidsColor = Color.FromArgb(131, Colors.DarkGray.R, Colors.DarkGray.G, Colors.DarkGray.B),
					OpeningsColor = Color.FromArgb(131, Colors.LightCyan.R, Colors.LightCyan.G, Colors.LightCyan.B),
					BarPointColor = Colors.Black,
					BarsColor = Colors.Black,
					FontColor = Colors.Black,
					ShowAnnotations = true
				};
			}
		}

		// Token: 0x17001412 RID: 5138
		// (get) Token: 0x06004457 RID: 17495 RVA: 0x00039113 File Offset: 0x00037313
		// (set) Token: 0x06004458 RID: 17496 RVA: 0x0003911B File Offset: 0x0003731B
		public bool ShowColoredZones { get; set; }

		// Token: 0x17001413 RID: 5139
		// (get) Token: 0x06004459 RID: 17497 RVA: 0x00039124 File Offset: 0x00037324
		// (set) Token: 0x0600445A RID: 17498 RVA: 0x0003912C File Offset: 0x0003732C
		public bool ShowParameters { get; set; }

		// Token: 0x17001414 RID: 5140
		// (get) Token: 0x0600445B RID: 17499 RVA: 0x00039135 File Offset: 0x00037335
		// (set) Token: 0x0600445C RID: 17500 RVA: 0x0003913D File Offset: 0x0003733D
		public bool ShowAnnotations { get; set; }
	}
}
