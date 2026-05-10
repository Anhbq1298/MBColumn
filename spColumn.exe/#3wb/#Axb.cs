using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using #7hc;
using #aHb;
using #eU;
using #lH;
using #Pxb;
using #Swb;
using #Uwb;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.AppManager.Column.Templates.Storage;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;
using Telerik.Windows.Controls;

namespace #3wb
{
	// Token: 0x020004BB RID: 1211
	internal sealed class #Axb : #HH<#Twb>, INotifyPropertyChanged, IViewModel, IViewModel<#Twb>, #5wb
	{
		// Token: 0x06002C5C RID: 11356 RVA: 0x000EBF54 File Offset: 0x000EA154
		public #Axb(Lazy<#Twb> #Ee, ICoreServices #0c, #2wb #UP, IEditorService #wj, #7wb #Xk, #fIb #Nwb, #Oxb #Bxb, #Rwb #Zk) : base(#Ee, #0c)
		{
			this.#a = #wj;
			this.#b = #Xk;
			this.#c = #Zk;
			this.#e = #UP;
			this.#f = #Nwb;
			this.#g = #Bxb;
			this.#h = new DelegateCommand(new Action<object>(this.#xxb), new Predicate<object>(this.#yxb));
			base.Services.MessageBus.TemplateLoaded += this.#wxb;
			base.Services.MessageBus.DefinitionChangesCommitted += this.#owb;
			base.Services.MessageBus.ProjectLoaded += this.#Gh;
		}

		// Token: 0x17000EE3 RID: 3811
		// (get) Token: 0x06002C5D RID: 11357 RVA: 0x00027E5A File Offset: 0x0002605A
		public #2wb TemplateService { get; }

		// Token: 0x17000EE4 RID: 3812
		// (get) Token: 0x06002C5E RID: 11358 RVA: 0x00027E66 File Offset: 0x00026066
		public #fIb Properties { get; }

		// Token: 0x17000EE5 RID: 3813
		// (get) Token: 0x06002C5F RID: 11359 RVA: 0x00027E72 File Offset: 0x00026072
		public #Oxb Toolbar { get; }

		// Token: 0x17000EE6 RID: 3814
		// (get) Token: 0x06002C60 RID: 11360 RVA: 0x00027E7E File Offset: 0x0002607E
		public DelegateCommand NewPatternCommand { get; }

		// Token: 0x17000EE7 RID: 3815
		// (get) Token: 0x06002C61 RID: 11361 RVA: 0x00027E8A File Offset: 0x0002608A
		// (set) Token: 0x06002C62 RID: 11362 RVA: 0x00027E96 File Offset: 0x00026096
		public int SelectedTabIndex
		{
			get
			{
				return this.#d;
			}
			set
			{
				this.SetProperty<int>(ref this.#d, value, #Phc.#3hc(107356321));
			}
		}

		// Token: 0x17000EE8 RID: 3816
		// (get) Token: 0x06002C63 RID: 11363 RVA: 0x00027EBC File Offset: 0x000260BC
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06002C64 RID: 11364 RVA: 0x00027ECC File Offset: 0x000260CC
		public void #twb()
		{
			this.Properties.#dIb();
		}

		// Token: 0x06002C65 RID: 11365 RVA: 0x00027EE5 File Offset: 0x000260E5
		public void #0kb()
		{
			this.Properties.#0kb();
		}

		// Token: 0x06002C66 RID: 11366 RVA: 0x000EC010 File Offset: 0x000EA210
		public bool #5b()
		{
			#Axb.#ETb #ETb = new #Axb.#ETb();
			#ETb.#b = this;
			#ETb.#a = base.Project.Model;
			if (#ETb.#a.Options.SectionType != SectionType.IrregularTemplate)
			{
				this.#a.#0Pb(new Func<bool>(#ETb.#77b));
				if (#ETb.#a.TemplateData.TemplateDefinition == null)
				{
					return false;
				}
				ColumnModelHelper.#VW(base.Project);
				base.Services.SnappingCache.#uP(base.Project);
			}
			base.Project.#2O();
			this.#twb();
			this.Properties.#5b();
			this.#zxb();
			return true;
		}

		// Token: 0x06002C67 RID: 11367 RVA: 0x00027EFE File Offset: 0x000260FE
		private void #Gh(object #Ge, #cW #He)
		{
			if (!#He.IsInternalChange)
			{
				this.SelectedTabIndex = 0;
			}
		}

		// Token: 0x06002C68 RID: 11368 RVA: 0x00027F1B File Offset: 0x0002611B
		private void #owb(object #Ge, EventArgs #He)
		{
			if (base.View.IsVisible && base.Project.Model.Options.SectionType == SectionType.IrregularTemplate)
			{
				this.TemplateService.#0wb(true);
			}
		}

		// Token: 0x06002C69 RID: 11369 RVA: 0x00027F5A File Offset: 0x0002615A
		private void #wxb(object #Ge, EventArgs #He)
		{
			this.SelectedTabIndex = 0;
		}

		// Token: 0x06002C6A RID: 11370 RVA: 0x000EC0DC File Offset: 0x000EA2DC
		private void #xxb(object #Sb)
		{
			#Axb.#KTb #KTb = new #Axb.#KTb();
			#KTb.#a = this;
			bool flag = this.#b.#6wb(out #KTb.#b);
			if (flag)
			{
				this.#a.#0Pb(new Action(#KTb.#87b));
			}
		}

		// Token: 0x06002C6B RID: 11371 RVA: 0x00003375 File Offset: 0x00001575
		private bool #yxb(object #Sb)
		{
			return true;
		}

		// Token: 0x06002C6C RID: 11372 RVA: 0x00027F6B File Offset: 0x0002616B
		private void #zxb()
		{
			this.TemplateService.#0wb(true);
			this.Properties.#dIb();
		}

		// Token: 0x040011CB RID: 4555
		private readonly IEditorService #a;

		// Token: 0x040011CC RID: 4556
		private readonly #7wb #b;

		// Token: 0x040011CD RID: 4557
		private readonly #Rwb #c;

		// Token: 0x040011CE RID: 4558
		private int #d;

		// Token: 0x040011CF RID: 4559
		[CompilerGenerated]
		private readonly #2wb #e;

		// Token: 0x040011D0 RID: 4560
		[CompilerGenerated]
		private readonly #fIb #f;

		// Token: 0x040011D1 RID: 4561
		[CompilerGenerated]
		private readonly #Oxb #g;

		// Token: 0x040011D2 RID: 4562
		[CompilerGenerated]
		private readonly DelegateCommand #h;

		// Token: 0x020004BC RID: 1212
		[CompilerGenerated]
		private sealed class #ETb
		{
			// Token: 0x06002C6E RID: 11374 RVA: 0x000EC130 File Offset: 0x000EA330
			internal bool #77b()
			{
				SectionType #KY = this.#a.Options.SectionType;
				bool #LY = this.#a.#IY();
				this.#a.#JY(SectionType.IrregularTemplate, #LY);
				if (this.#a.TemplateData.TemplateDefinition == null)
				{
					SectionTemplateDefinition #Pwb;
					bool flag = this.#b.#b.#6wb(out #Pwb);
					if (flag)
					{
						this.#b.#c.#Owb(#Pwb);
					}
				}
				if (this.#a.TemplateData.TemplateDefinition == null)
				{
					this.#a.#JY(#KY, true);
					return false;
				}
				this.#a.Options.SectionType = SectionType.IrregularTemplate;
				this.#a.Options.InvestigationReinforcement = ReinforcementType.Irregular;
				return true;
			}

			// Token: 0x040011D3 RID: 4563
			public ColumnModel #a;

			// Token: 0x040011D4 RID: 4564
			public #Axb #b;
		}

		// Token: 0x020004BD RID: 1213
		[CompilerGenerated]
		private sealed class #KTb
		{
			// Token: 0x06002C70 RID: 11376 RVA: 0x00027F90 File Offset: 0x00026190
			internal void #87b()
			{
				this.#a.#c.#Owb(this.#b);
				this.#a.Toolbar.#5b();
				this.#a.#zxb();
			}

			// Token: 0x040011D5 RID: 4565
			public #Axb #a;

			// Token: 0x040011D6 RID: 4566
			public SectionTemplateDefinition #b;
		}
	}
}
