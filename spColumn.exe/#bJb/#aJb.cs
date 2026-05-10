using System;
using #7hc;
using #APb;
using #eU;
using #RJb;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Viewports.API;

namespace #bJb
{
	// Token: 0x02000628 RID: 1576
	internal sealed class #aJb : #TKb, #zLb, #KPb
	{
		// Token: 0x06003577 RID: 13687 RVA: 0x0002EE4C File Offset: 0x0002D04C
		public #aJb(#MPb #cJb, #oW #Yc, #VPb #Bxb) : base(Strings.StringProject, #Yc)
		{
			if (#cJb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107352192));
			}
			this.#a = #cJb;
			this.#b = #Bxb;
		}

		// Token: 0x170010AD RID: 4269
		// (get) Token: 0x06003578 RID: 13688 RVA: 0x0002EE7C File Offset: 0x0002D07C
		public override IView PanelView
		{
			get
			{
				return this.#a.View;
			}
		}

		// Token: 0x170010AE RID: 4270
		// (get) Token: 0x06003579 RID: 13689 RVA: 0x0002EE91 File Offset: 0x0002D091
		public override IViewModel PanelViewModel
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x170010AF RID: 4271
		// (get) Token: 0x0600357A RID: 13690 RVA: 0x0002EE9D File Offset: 0x0002D09D
		public override bool IsPanelViewCreated
		{
			get
			{
				return this.#a.IsViewCreated;
			}
		}

		// Token: 0x0600357B RID: 13691 RVA: 0x0002EEB2 File Offset: 0x0002D0B2
		public override void #5b(#ALb #Pc)
		{
			base.#5b(#Pc);
			this.#b.#5b();
			this.#a.#5b();
		}

		// Token: 0x0600357C RID: 13692 RVA: 0x0002EEDD File Offset: 0x0002D0DD
		public override void #0kb()
		{
			base.#0kb();
			this.#b.#0kb();
			this.#a.#0kb();
		}

		// Token: 0x0600357D RID: 13693 RVA: 0x000EA2EC File Offset: 0x000E84EC
		public override string #7vb(IViewport #fe)
		{
			SectionType sectionType = base.Project.Model.Options.SectionType;
			if (sectionType == SectionType.Irregular)
			{
				return Strings.StringSection.#O2d().#G2d(true) + Strings.StringIrregular;
			}
			if (sectionType == SectionType.Rectangle || sectionType == SectionType.Circle)
			{
				return Strings.StringSection.#O2d().#G2d(true) + Strings.StringRegular;
			}
			if (sectionType == SectionType.IrregularTemplate)
			{
				return Strings.StringSection.#O2d().#G2d(true) + Strings.StringTemplate;
			}
			return Strings.StringSection;
		}

		// Token: 0x04001623 RID: 5667
		private readonly #MPb #a;

		// Token: 0x04001624 RID: 5668
		private readonly #VPb #b;
	}
}
