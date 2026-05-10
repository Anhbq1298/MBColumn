using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using #0I;
using #6s;
using #7hc;
using #cc;
using #kB;
using #npe;
using #PI;
using #qJ;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.Core;
using StructurePoint.Products.Column.ViewModels.Slenderness.Helpers;

namespace #0q
{
	// Token: 0x02000129 RID: 297
	internal sealed class #Zq : WindowViewModelBase<SlendernessPanelType, #ec>, INotifyPropertyChanged, IViewModel<IColumnWindow>, #RI<SlendernessPanelType>, #6I<SlendernessPanelType>, IViewModel, #ht
	{
		// Token: 0x060009C5 RID: 2501 RVA: 0x00097D48 File Offset: 0x00095F48
		public #Zq(Lazy<#ec> #Ee, ICoreServices #0c, #gt #1q, #ft #2q, #it #3q, #et #4q, #jB #pl, #zJ #pj, IEditorService #wj) : base(#Ee, #0c, #pl, #pj, #wj)
		{
			this.#a = #2q.#tr(ModelAxis.XAxisPanel, this);
			this.#b = #2q.#tr(ModelAxis.YAxisPanel, this);
			this.#d = #4q.#tr(ModelAxis.XAxisPanel, this);
			this.#e = #4q.#tr(ModelAxis.YAxisPanel, this);
			this.#c = #1q;
			this.#f = #3q;
			this.SlenderColumnsAboveBelowPanel.Form.SlendernessWindow = this;
			base.CheckForChangesOnClosing = true;
			base.AskToSaveChangesBeforeClosingMessage = Strings.StringModifiedSlendernessParametersNotSaved.#z2d().#Tm() + Strings.StringWouldYouLikeToSaveThem.#J2d();
		}

		// Token: 0x17000401 RID: 1025
		// (get) Token: 0x060009C6 RID: 2502 RVA: 0x0000D7AE File Offset: 0x0000B9AE
		public #bt XDesignColumnPanel { get; }

		// Token: 0x17000402 RID: 1026
		// (get) Token: 0x060009C7 RID: 2503 RVA: 0x0000D7BA File Offset: 0x0000B9BA
		public #bt YDesignColumnPanel { get; }

		// Token: 0x17000403 RID: 1027
		// (get) Token: 0x060009C8 RID: 2504 RVA: 0x0000D7C6 File Offset: 0x0000B9C6
		public #gt SlenderColumnsAboveBelowPanel { get; }

		// Token: 0x17000404 RID: 1028
		// (get) Token: 0x060009C9 RID: 2505 RVA: 0x0000D7D2 File Offset: 0x0000B9D2
		public #8s XBeamsPanel { get; }

		// Token: 0x17000405 RID: 1029
		// (get) Token: 0x060009CA RID: 2506 RVA: 0x0000D7DE File Offset: 0x0000B9DE
		public #8s YBeamsPanel { get; }

		// Token: 0x17000406 RID: 1030
		// (get) Token: 0x060009CB RID: 2507 RVA: 0x0000D7EA File Offset: 0x0000B9EA
		public #it SlenderSlendernessFactorsPanel { get; }

		// Token: 0x17000407 RID: 1031
		// (get) Token: 0x060009CC RID: 2508 RVA: 0x0000D7F6 File Offset: 0x0000B9F6
		public EndConditionType EndConditionX
		{
			get
			{
				return this.XDesignColumnPanel.Form.EndCondition;
			}
		}

		// Token: 0x17000408 RID: 1032
		// (get) Token: 0x060009CD RID: 2509 RVA: 0x0000D814 File Offset: 0x0000BA14
		public EndConditionType EndConditionY
		{
			get
			{
				return this.YDesignColumnPanel.Form.EndCondition;
			}
		}

		// Token: 0x17000409 RID: 1033
		// (get) Token: 0x060009CE RID: 2510 RVA: 0x0000D832 File Offset: 0x0000BA32
		public bool IsAboveBelowWithoutBelow
		{
			get
			{
				return this.#Yq();
			}
		}

		// Token: 0x1700040A RID: 1034
		// (get) Token: 0x060009CF RID: 2511 RVA: 0x0000D842 File Offset: 0x0000BA42
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x00097DEC File Offset: 0x00095FEC
		public override IEnumerable<PanelItem> #Lq()
		{
			PanelItem panelItem = new PanelItem(Strings.StringColumns);
			panelItem.Children.Add(new PanelItem(SlendernessPanelType.DesignColumnXAxis, Strings.StringDesignColumnXAxis, this.XDesignColumnPanel, new Func<bool>(this.#Pq)));
			panelItem.Children.Add(new PanelItem(SlendernessPanelType.DesignColumnYAxis, Strings.StringDesignColumnYAxis, this.YDesignColumnPanel, new Func<bool>(this.#Qq)));
			panelItem.Children.Add(new PanelItem(SlendernessPanelType.ColumnsAboveAndBelow, Strings.StringColumnsAboveBelow, this.SlenderColumnsAboveBelowPanel, new Func<bool>(this.#Rq)));
			PanelItem panelItem2 = new PanelItem(Strings.StringBeams);
			panelItem2.Children.Add(new PanelItem(SlendernessPanelType.BeamsXAxis, Strings.StringXBeams, this.XBeamsPanel, new Func<bool>(this.#Nq)));
			panelItem2.Children.Add(new PanelItem(SlendernessPanelType.BeamsYAxis, Strings.StringYBeams, this.YBeamsPanel, new Func<bool>(this.#Oq)));
			PanelItem panelItem3 = new PanelItem(Strings.StringProperties);
			panelItem3.Children.Add(new PanelItem(SlendernessPanelType.Factors, Strings.StringSlendernessFactors, this.SlenderSlendernessFactorsPanel, true));
			return new List<PanelItem>
			{
				panelItem,
				panelItem2,
				panelItem3
			};
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x00097F5C File Offset: 0x0009615C
		public override void #Mq()
		{
			if (base.ShowLock.#YXd())
			{
				try
				{
					SlendernessPanelType #kx = (base.ActiveItem != null) ? ((SlendernessPanelType)base.ActiveItem.PanelIdentifier) : SlendernessPanelType.DesignColumnXAxis;
					this.#Mq(#kx);
				}
				finally
				{
					base.ShowLock.#ZXd();
				}
			}
		}

		// Token: 0x060009D2 RID: 2514 RVA: 0x00097FC4 File Offset: 0x000961C4
		public bool #Nq()
		{
			Kmode kmode = this.XDesignColumnPanel.Form.Kmode;
			bool flag = kmode == Kmode.Compute;
			bool flag2 = #Bpe.#xpe(this.EndConditionX);
			return flag && this.#Pq() && !flag2;
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x00098010 File Offset: 0x00096210
		public bool #Oq()
		{
			Kmode kmode = this.YDesignColumnPanel.Form.Kmode;
			bool flag = kmode == Kmode.Compute;
			bool flag2 = #Bpe.#xpe(this.EndConditionY);
			return flag && this.#Qq() && !flag2;
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x0009805C File Offset: 0x0009625C
		public bool #Pq()
		{
			ConsideredAxis consideredAxis = base.Services.Project.Model.Options.ConsideredAxis;
			return consideredAxis == ConsideredAxis.X || consideredAxis == ConsideredAxis.Both;
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x0009809C File Offset: 0x0009629C
		public bool #Qq()
		{
			ConsideredAxis consideredAxis = base.Services.Project.Model.Options.ConsideredAxis;
			return consideredAxis == ConsideredAxis.Y || consideredAxis == ConsideredAxis.Both;
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x000980DC File Offset: 0x000962DC
		public bool #Rq()
		{
			Kmode kmode = this.XDesignColumnPanel.Form.Kmode;
			Kmode kmode2 = this.YDesignColumnPanel.Form.Kmode;
			bool flag = kmode == Kmode.Compute;
			bool flag2 = kmode2 == Kmode.Compute;
			if (flag && this.#Pq() && flag2 && this.#Qq())
			{
				bool flag3 = #Bpe.#rai(this.EndConditionX) && #Bpe.#rai(this.EndConditionY);
				return !flag3;
			}
			if (flag && this.#Pq())
			{
				bool flag4 = #Bpe.#rai(this.EndConditionX);
				return !flag4;
			}
			if (flag2 && this.#Qq())
			{
				bool flag5 = #Bpe.#rai(this.EndConditionY);
				return !flag5;
			}
			return false;
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x0000D852 File Offset: 0x0000BA52
		public bool #Sq()
		{
			return this.EndConditionX == this.EndConditionY;
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x0000D86E File Offset: 0x0000BA6E
		protected override void #Tq(PanelItem #Uq, PanelItem #Vq)
		{
			base.#Tq(#Uq, #Vq);
			this.#Wq();
		}

		// Token: 0x060009D9 RID: 2521 RVA: 0x000981AC File Offset: 0x000963AC
		private void #Wq()
		{
			this.XBeamsPanel.Form.#vh();
			this.YBeamsPanel.Form.#vh();
			this.XDesignColumnPanel.Form.CopyValuesToMirrorAxis.InvalidateCanExecute();
			this.YDesignColumnPanel.Form.CopyValuesToMirrorAxis.InvalidateCanExecute();
			base.RaisePropertyChanged(#Phc.#3hc(107413325));
			base.RaisePropertyChanged(#Phc.#3hc(107413336));
			base.RaisePropertyChanged(#Phc.#3hc(107413283));
		}

		// Token: 0x060009DA RID: 2522 RVA: 0x00098248 File Offset: 0x00096448
		private bool #Yq()
		{
			bool flag = false;
			switch (base.Services.Project.Model.Options.ConsideredAxis)
			{
			case ConsideredAxis.X:
				flag = #Bpe.#qai(this.EndConditionX);
				break;
			case ConsideredAxis.Y:
				flag = #Bpe.#qai(this.EndConditionY);
				break;
			case ConsideredAxis.Both:
				flag = (#Bpe.#qai(this.EndConditionX) || #Bpe.#qai(this.EndConditionY));
				break;
			}
			return !flag;
		}

		// Token: 0x0400037A RID: 890
		[CompilerGenerated]
		private readonly #bt #a;

		// Token: 0x0400037B RID: 891
		[CompilerGenerated]
		private readonly #bt #b;

		// Token: 0x0400037C RID: 892
		[CompilerGenerated]
		private readonly #gt #c;

		// Token: 0x0400037D RID: 893
		[CompilerGenerated]
		private readonly #8s #d;

		// Token: 0x0400037E RID: 894
		[CompilerGenerated]
		private readonly #8s #e;

		// Token: 0x0400037F RID: 895
		[CompilerGenerated]
		private readonly #it #f;
	}
}
