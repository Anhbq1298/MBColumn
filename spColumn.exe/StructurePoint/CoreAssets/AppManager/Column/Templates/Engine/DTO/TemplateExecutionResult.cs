using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using #6he;
using #Gfe;
using FluentValidation.Results;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.DTO
{
	// Token: 0x0200109F RID: 4255
	public sealed class TemplateExecutionResult
	{
		// Token: 0x17002A3E RID: 10814
		// (get) Token: 0x0600913C RID: 37180 RVA: 0x000750D5 File Offset: 0x000732D5
		public List<SectionPolygon> Polygons { get; } = new List<SectionPolygon>();

		// Token: 0x17002A3F RID: 10815
		// (get) Token: 0x0600913D RID: 37181 RVA: 0x000750DD File Offset: 0x000732DD
		public List<SectionPolygon> ColoredZones { get; } = new List<SectionPolygon>();

		// Token: 0x17002A40 RID: 10816
		// (get) Token: 0x0600913E RID: 37182 RVA: 0x000750E5 File Offset: 0x000732E5
		public List<TemplateReinforcementBar> Bars { get; } = new List<TemplateReinforcementBar>();

		// Token: 0x17002A41 RID: 10817
		// (get) Token: 0x0600913F RID: 37183 RVA: 0x000750ED File Offset: 0x000732ED
		public List<LeaderWithText> Texts { get; } = new List<LeaderWithText>();

		// Token: 0x17002A42 RID: 10818
		// (get) Token: 0x06009140 RID: 37184 RVA: 0x000750F5 File Offset: 0x000732F5
		public List<TemplateMessage> Errors { get; } = new List<TemplateMessage>();

		// Token: 0x17002A43 RID: 10819
		// (get) Token: 0x06009141 RID: 37185 RVA: 0x000750FD File Offset: 0x000732FD
		public List<TemplateMessage> DebugMesages { get; } = new List<TemplateMessage>();

		// Token: 0x17002A44 RID: 10820
		// (get) Token: 0x06009142 RID: 37186 RVA: 0x00075105 File Offset: 0x00073305
		public List<DimensionData> Dimensions { get; } = new List<DimensionData>();

		// Token: 0x17002A45 RID: 10821
		// (get) Token: 0x06009143 RID: 37187 RVA: 0x0007510D File Offset: 0x0007330D
		public List<#5he> ShapeLabels { get; } = new List<#5he>();

		// Token: 0x17002A46 RID: 10822
		// (get) Token: 0x06009144 RID: 37188 RVA: 0x00075115 File Offset: 0x00073315
		public List<ValidationFailure> ResultValidationFailures { get; } = new List<ValidationFailure>();

		// Token: 0x17002A47 RID: 10823
		// (get) Token: 0x06009145 RID: 37189 RVA: 0x0007511D File Offset: 0x0007331D
		public List<TemplateParameterName> ParameterNames { get; } = new List<TemplateParameterName>();

		// Token: 0x17002A48 RID: 10824
		// (get) Token: 0x06009146 RID: 37190 RVA: 0x00075125 File Offset: 0x00073325
		public List<#Lfe> DimTexts { get; } = new List<#Lfe>();

		// Token: 0x04003D0C RID: 15628
		[CompilerGenerated]
		private readonly List<SectionPolygon> #a;

		// Token: 0x04003D0D RID: 15629
		[CompilerGenerated]
		private readonly List<SectionPolygon> #b;

		// Token: 0x04003D0E RID: 15630
		[CompilerGenerated]
		private readonly List<TemplateReinforcementBar> #c;

		// Token: 0x04003D0F RID: 15631
		[CompilerGenerated]
		private readonly List<LeaderWithText> #d;

		// Token: 0x04003D10 RID: 15632
		[CompilerGenerated]
		private readonly List<TemplateMessage> #e;

		// Token: 0x04003D11 RID: 15633
		[CompilerGenerated]
		private readonly List<TemplateMessage> #f;

		// Token: 0x04003D12 RID: 15634
		[CompilerGenerated]
		private readonly List<DimensionData> #g;

		// Token: 0x04003D13 RID: 15635
		[CompilerGenerated]
		private readonly List<#5he> #h;

		// Token: 0x04003D14 RID: 15636
		[CompilerGenerated]
		private readonly List<ValidationFailure> #i;

		// Token: 0x04003D15 RID: 15637
		[CompilerGenerated]
		private readonly List<TemplateParameterName> #j;

		// Token: 0x04003D16 RID: 15638
		[CompilerGenerated]
		private readonly List<#Lfe> #k;
	}
}
