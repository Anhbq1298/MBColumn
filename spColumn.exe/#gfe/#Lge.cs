using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #6he;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.DTO;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.Runtime;

namespace #Gfe
{
	// Token: 0x02001084 RID: 4228
	internal sealed class #Lge
	{
		// Token: 0x17002A05 RID: 10757
		// (get) Token: 0x06009065 RID: 36965 RVA: 0x00074A51 File Offset: 0x00072C51
		public List<SectionPolygon> Polygons { get; } = new List<SectionPolygon>();

		// Token: 0x17002A06 RID: 10758
		// (get) Token: 0x06009066 RID: 36966 RVA: 0x00074A59 File Offset: 0x00072C59
		public List<SectionPolygon> ColoredZones { get; } = new List<SectionPolygon>();

		// Token: 0x17002A07 RID: 10759
		// (get) Token: 0x06009067 RID: 36967 RVA: 0x00074A61 File Offset: 0x00072C61
		public List<EvaluatedReinforcementBar> Bars { get; } = new List<EvaluatedReinforcementBar>();

		// Token: 0x17002A08 RID: 10760
		// (get) Token: 0x06009068 RID: 36968 RVA: 0x00074A69 File Offset: 0x00072C69
		public List<LeaderWithText> Texts { get; } = new List<LeaderWithText>();

		// Token: 0x17002A09 RID: 10761
		// (get) Token: 0x06009069 RID: 36969 RVA: 0x00074A71 File Offset: 0x00072C71
		public List<DimensionData> Dimensions { get; } = new List<DimensionData>();

		// Token: 0x17002A0A RID: 10762
		// (get) Token: 0x0600906A RID: 36970 RVA: 0x00074A79 File Offset: 0x00072C79
		public List<#5he> ShapeLabels { get; } = new List<#5he>();

		// Token: 0x17002A0B RID: 10763
		// (get) Token: 0x0600906B RID: 36971 RVA: 0x00074A81 File Offset: 0x00072C81
		public List<TemplateMessage> Errors { get; } = new List<TemplateMessage>();

		// Token: 0x17002A0C RID: 10764
		// (get) Token: 0x0600906C RID: 36972 RVA: 0x00074A89 File Offset: 0x00072C89
		public List<TemplateMessage> DebugMesages { get; } = new List<TemplateMessage>();

		// Token: 0x17002A0D RID: 10765
		// (get) Token: 0x0600906D RID: 36973 RVA: 0x00074A91 File Offset: 0x00072C91
		public List<#Lfe> DimTexts { get; } = new List<#Lfe>();

		// Token: 0x04003CA2 RID: 15522
		[CompilerGenerated]
		private readonly List<SectionPolygon> #a;

		// Token: 0x04003CA3 RID: 15523
		[CompilerGenerated]
		private readonly List<SectionPolygon> #b;

		// Token: 0x04003CA4 RID: 15524
		[CompilerGenerated]
		private readonly List<EvaluatedReinforcementBar> #c;

		// Token: 0x04003CA5 RID: 15525
		[CompilerGenerated]
		private readonly List<LeaderWithText> #d;

		// Token: 0x04003CA6 RID: 15526
		[CompilerGenerated]
		private readonly List<DimensionData> #e;

		// Token: 0x04003CA7 RID: 15527
		[CompilerGenerated]
		private readonly List<#5he> #f;

		// Token: 0x04003CA8 RID: 15528
		[CompilerGenerated]
		private readonly List<TemplateMessage> #g;

		// Token: 0x04003CA9 RID: 15529
		[CompilerGenerated]
		private readonly List<TemplateMessage> #h;

		// Token: 0x04003CAA RID: 15530
		[CompilerGenerated]
		private readonly List<#Lfe> #i;
	}
}
