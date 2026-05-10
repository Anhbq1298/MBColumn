using System;
using System.Collections.Generic;
using System.Linq;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Engine.DTO;
using StructurePoint.CoreAssets.Column.Core.Templates.Rendering;
using StructurePoint.Products.Column.Services.Rendering;

namespace #hR
{
	// Token: 0x020002E3 RID: 739
	internal sealed class #jR : BaseCoreRenderer
	{
		// Token: 0x0600197E RID: 6526 RVA: 0x00019748 File Offset: 0x00017948
		public #jR(#tS #iR) : base(#iR)
		{
		}

		// Token: 0x0600197F RID: 6527 RVA: 0x000B84B8 File Offset: 0x000B66B8
		public override void #fR()
		{
			base.#fR();
			if (!this.#a.Any<TemplatesCoreRenderer>())
			{
				this.#a.Add(new TemplateDimensionsCoreRenderer
				{
					Editor = base.Editor
				});
				this.#a.Add(new TemplateDimTextsCoreRenderer
				{
					Editor = base.Editor
				});
				this.#a.Add(new TemplateLeadersRenderer
				{
					Editor = base.Editor
				});
				this.#a.Add(new TemplateShapeLabelsCoreRenderer
				{
					Editor = base.Editor
				});
				this.#a.Add(new CentroidCoreRenderer
				{
					Editor = base.Editor
				});
			}
			foreach (TemplatesCoreRenderer templatesCoreRenderer in this.#a)
			{
				templatesCoreRenderer.DrawForeground();
			}
		}

		// Token: 0x06001980 RID: 6528 RVA: 0x000B85CC File Offset: 0x000B67CC
		public void #uP(TemplateExecutionResult #PE)
		{
			TemplatesRendererContext context = (#PE != null) ? TemplatesRendererContext.Create(#PE) : null;
			foreach (TemplatesCoreRenderer templatesCoreRenderer in this.#a)
			{
				templatesCoreRenderer.Result = #PE;
				templatesCoreRenderer.Context = context;
			}
		}

		// Token: 0x06001981 RID: 6529 RVA: 0x000B8640 File Offset: 0x000B6840
		public void #uP(TemplateRenderOptions #mA)
		{
			if (#mA == null)
			{
				return;
			}
			foreach (TemplatesCoreRenderer templatesCoreRenderer in this.#a)
			{
				templatesCoreRenderer.RenderOptions = #mA;
			}
		}

		// Token: 0x040009BE RID: 2494
		private readonly List<TemplatesCoreRenderer> #a = new List<TemplatesCoreRenderer>();
	}
}
