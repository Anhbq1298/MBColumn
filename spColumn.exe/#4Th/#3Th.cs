using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using #0I;
using #hc;
using #IW;
using #kB;
using #qJ;
using #TI;
using #WB;
using #wD;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.Core;

namespace #4Th
{
	// Token: 0x020001D9 RID: 473
	internal sealed class #3Th : WindowViewModelBase<#FD, #kc>, INotifyPropertyChanged, IViewModel<IColumnWindow>, #UI<#FD>, #6I<#FD>, IViewModel, #CD
	{
		// Token: 0x0600108F RID: 4239 RVA: 0x000A6F60 File Offset: 0x000A5160
		public #3Th(Lazy<#kc> #Ee, ICoreServices #0c, #AD #ltf, #xD #mtf, #DD #ntf, #KW #Cj, #6Th #5Th, #jB #pl, #zJ #pj, IEditorService #wj) : base(#Ee, #0c, #pl, #pj, #wj)
		{
			this.#a = #ltf;
			this.#b = #mtf;
			this.#c = #ntf;
			this.#d = #Cj;
			this.#e = #5Th;
			base.CheckForChangesOnClosing = true;
			base.AskToSaveChangesBeforeClosingMessage = Strings.StringModifiedLoadSNotSaved.#z2d().#Tm() + Strings.StringWouldYouLikeToSaveThem.#J2d();
		}

		// Token: 0x17000634 RID: 1588
		// (get) Token: 0x06001090 RID: 4240 RVA: 0x00012B61 File Offset: 0x00010D61
		public bool IsAxialLoadsEnabled
		{
			get
			{
				return this.#d.#1T(LoadType.Axial);
			}
		}

		// Token: 0x17000635 RID: 1589
		// (get) Token: 0x06001091 RID: 4241 RVA: 0x00012B77 File Offset: 0x00010D77
		public bool IsControlPointsEnabled
		{
			get
			{
				return this.#d.#1T(LoadType.NoLoads);
			}
		}

		// Token: 0x17000636 RID: 1590
		// (get) Token: 0x06001092 RID: 4242 RVA: 0x00012B8D File Offset: 0x00010D8D
		public bool IsFactoredLoadsEnabled
		{
			get
			{
				return this.#d.#1T(LoadType.Factored);
			}
		}

		// Token: 0x17000637 RID: 1591
		// (get) Token: 0x06001093 RID: 4243 RVA: 0x00012BA3 File Offset: 0x00010DA3
		// (set) Token: 0x06001094 RID: 4244 RVA: 0x00012BAF File Offset: 0x00010DAF
		protected LoadType LoadType { get; set; }

		// Token: 0x17000638 RID: 1592
		// (get) Token: 0x06001095 RID: 4245 RVA: 0x00012BC0 File Offset: 0x00010DC0
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06001096 RID: 4246 RVA: 0x000A6FD0 File Offset: 0x000A51D0
		public override IEnumerable<PanelItem> #Lq()
		{
			this.LoadType = this.#d.CurrentLoadType;
			PanelItem panelItem = new PanelItem(Strings.StringLoads);
			panelItem.Children.Add(new PanelItem(#FD.#b, Strings.StringFactoredLoads, this.#a, this.IsFactoredLoadsEnabled));
			panelItem.Children.Add(new PanelItem(#FD.#d, Strings.StringServiceLoads, this.#c, true));
			PanelItem panelItem2 = new PanelItem(Strings.StringModesNoLoads);
			panelItem2.Children.Add(new PanelItem(#FD.#c, Strings.StringAxialLoadPoints, this.#b, this.IsAxialLoadsEnabled));
			panelItem2.Children.Add(new PanelItem(#FD.#f, Strings.StringControlPoints, this.#e, this.IsControlPointsEnabled));
			return new List<PanelItem>
			{
				panelItem,
				panelItem2
			};
		}

		// Token: 0x06001097 RID: 4247 RVA: 0x000A70CC File Offset: 0x000A52CC
		public override void #Mq()
		{
			if (base.ShowLock.#YXd())
			{
				try
				{
					LoadType loadType = this.#d.CurrentLoadType;
					LoadType #GB = (loadType != LoadType.Undefined) ? loadType : this.#d.#2T();
					#FD #kx = this.#FB(#GB);
					this.#Mq(#kx);
				}
				finally
				{
					base.ShowLock.#ZXd();
				}
			}
		}

		// Token: 0x06001098 RID: 4248 RVA: 0x000A7140 File Offset: 0x000A5340
		protected override void #Tq(PanelItem #Uq, PanelItem #Vq)
		{
			base.#Tq(#Uq, #Vq);
			if (#Vq == null)
			{
				return;
			}
			#FD #FD = (#FD)#Vq.PanelIdentifier;
			this.LoadType = this.#DB(#FD);
			if (#FD == #FD.#e)
			{
				return;
			}
			base.#aI();
		}

		// Token: 0x06001099 RID: 4249 RVA: 0x00012BD0 File Offset: 0x00010DD0
		protected override void #BB()
		{
			base.#BB();
			if (this.HasErrors)
			{
				return;
			}
			this.#d.#3T(this.LoadType);
		}

		// Token: 0x0600109A RID: 4250 RVA: 0x00012BFE File Offset: 0x00010DFE
		protected override bool #2Th()
		{
			return this.LoadType != base.Project.Model.Options.ActiveLoad;
		}

		// Token: 0x0600109B RID: 4251 RVA: 0x000A718C File Offset: 0x000A538C
		protected override void #CB()
		{
			PanelItem panelItem = base.ActiveItem;
			if (((panelItem != null) ? panelItem.Panel : null) == null)
			{
				return;
			}
			if (base.ActiveItem.Panel.HasAnyErrors && base.ActiveItem.PanelIdentifier.Equals(#FD.#d))
			{
				string panelName = base.ActiveItem.PanelName;
				base.#8H(panelName);
			}
		}

		// Token: 0x0600109C RID: 4252 RVA: 0x00012C2C File Offset: 0x00010E2C
		private LoadType #DB(#FD #EB)
		{
			switch (#EB)
			{
			case #FD.#b:
				return LoadType.Factored;
			case #FD.#c:
				return LoadType.Axial;
			case #FD.#d:
				return LoadType.Service;
			case #FD.#f:
				return LoadType.NoLoads;
			}
			return LoadType.Undefined;
		}

		// Token: 0x0600109D RID: 4253 RVA: 0x00012C59 File Offset: 0x00010E59
		private #FD #FB(LoadType #GB)
		{
			switch (#GB)
			{
			case LoadType.Factored:
				return #FD.#b;
			case LoadType.Service:
				return #FD.#d;
			case LoadType.Axial:
				return #FD.#c;
			case LoadType.NoLoads:
				return #FD.#f;
			}
			return #FD.#a;
		}

		// Token: 0x0400068B RID: 1675
		private readonly #AD #a;

		// Token: 0x0400068C RID: 1676
		private readonly #xD #b;

		// Token: 0x0400068D RID: 1677
		private readonly #DD #c;

		// Token: 0x0400068E RID: 1678
		private readonly #KW #d;

		// Token: 0x0400068F RID: 1679
		private readonly #6Th #e;

		// Token: 0x04000690 RID: 1680
		[CompilerGenerated]
		private LoadType #f;
	}
}
