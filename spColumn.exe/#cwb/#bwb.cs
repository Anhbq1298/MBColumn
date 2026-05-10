using System;
using #3wb;
using #3yb;
using #6yb;
using #7hc;
using #APb;
using #eU;
using #RJb;
using #Uwb;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Viewports.API;

namespace #cwb
{
	// Token: 0x02000494 RID: 1172
	internal sealed class #bwb : #TKb, #zLb, #SPb
	{
		// Token: 0x06002B95 RID: 11157 RVA: 0x000EA1E0 File Offset: 0x000E83E0
		public #bwb(#UPb #dwb, #oW #xn, Lazy<#4yb> #ewb, Lazy<#Wwb> #fwb, #5wb #gwb, #5yb #hwb, #UV #ms) : base(Strings.StringSection, #xn)
		{
			if (#dwb == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107356874));
			}
			this.#a = #dwb;
			this.#b = #ewb;
			this.#c = #fwb;
			this.#d = #gwb;
			this.#e = #hwb;
			#ms.SectionLeftPanelRefreshRequested += this.#awb;
		}

		// Token: 0x17000EB7 RID: 3767
		// (get) Token: 0x06002B96 RID: 11158 RVA: 0x00027546 File Offset: 0x00025746
		public override IView PanelView
		{
			get
			{
				return this.#a.View;
			}
		}

		// Token: 0x17000EB8 RID: 3768
		// (get) Token: 0x06002B97 RID: 11159 RVA: 0x0002755B File Offset: 0x0002575B
		public override IViewModel PanelViewModel
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x17000EB9 RID: 3769
		// (get) Token: 0x06002B98 RID: 11160 RVA: 0x000EA248 File Offset: 0x000E8448
		public override IView ToolBarView
		{
			get
			{
				if (base.Project.Model.Options.SectionType == SectionType.IrregularTemplate)
				{
					if (!this.#c.IsValueCreated)
					{
						#Wwb value = this.#c.Value;
						value.DataContext = this.#d;
					}
					return this.#c.Value;
				}
				if (!this.#b.IsValueCreated)
				{
					#4yb value2 = this.#b.Value;
					value2.DataContext = this.#e;
				}
				return this.#b.Value;
			}
		}

		// Token: 0x17000EBA RID: 3770
		// (get) Token: 0x06002B99 RID: 11161 RVA: 0x00027567 File Offset: 0x00025767
		public override bool IsPanelViewCreated
		{
			get
			{
				return this.#a.IsViewCreated;
			}
		}

		// Token: 0x06002B9A RID: 11162 RVA: 0x0002757C File Offset: 0x0002577C
		public override void #5b(#ALb #Pc)
		{
			base.AreLeftPanelPropertiesAvailable = true;
			base.#5b(#Pc);
			this.#a.#5b();
		}

		// Token: 0x06002B9B RID: 11163 RVA: 0x000275A3 File Offset: 0x000257A3
		public override void #0kb()
		{
			base.#0kb();
			this.#a.#0kb();
		}

		// Token: 0x06002B9C RID: 11164 RVA: 0x000EA2EC File Offset: 0x000E84EC
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

		// Token: 0x06002B9D RID: 11165 RVA: 0x000275C2 File Offset: 0x000257C2
		public void #8vb(#RPb #Ph)
		{
			this.#e.#8vb(#Ph);
		}

		// Token: 0x06002B9E RID: 11166 RVA: 0x000275DC File Offset: 0x000257DC
		public bool #9vb(#RPb #Ph)
		{
			return this.#e.#9vb(#Ph);
		}

		// Token: 0x06002B9F RID: 11167 RVA: 0x000275F6 File Offset: 0x000257F6
		private void #awb(object #Ge, EventArgs #He)
		{
			base.RaisePropertyChanged(#Phc.#3hc(107356837));
		}

		// Token: 0x04001170 RID: 4464
		private readonly #UPb #a;

		// Token: 0x04001171 RID: 4465
		private readonly Lazy<#4yb> #b;

		// Token: 0x04001172 RID: 4466
		private readonly Lazy<#Wwb> #c;

		// Token: 0x04001173 RID: 4467
		private readonly #5wb #d;

		// Token: 0x04001174 RID: 4468
		private readonly #5yb #e;
	}
}
