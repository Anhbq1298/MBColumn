using System;
using System.Linq;
using #7hc;
using #lH;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.Services.API.Section;
using Telerik.Windows.Controls.Map;

namespace StructurePoint.Products.Column.Editor.Section.Common
{
	// Token: 0x02000623 RID: 1571
	internal sealed class CoverTypeViewModel : #TH
	{
		// Token: 0x0600355B RID: 13659 RVA: 0x0002ED90 File Offset: 0x0002CF90
		public CoverTypeViewModel(IExtendedServices services, IEditorService editorService, IReinforcementBarsService reinforcementBarsService)
		{
			this.services = services;
			this.editorService = editorService;
			this.reinforcementBarsService = reinforcementBarsService;
			this.<AvailableBars>k__BackingField = new CustomObservableCollection<StandardBar>();
		}

		// Token: 0x170010A6 RID: 4262
		// (get) Token: 0x0600355C RID: 13660 RVA: 0x0000A816 File Offset: 0x00008A16
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x170010A7 RID: 4263
		// (get) Token: 0x0600355D RID: 13661 RVA: 0x0002EDB8 File Offset: 0x0002CFB8
		// (set) Token: 0x0600355E RID: 13662 RVA: 0x00107FA0 File Offset: 0x001061A0
		public ClearCoverType ClearCoverType
		{
			get
			{
				return this.clearCoverType;
			}
			set
			{
				bool flag = this.SetProperty<ClearCoverType>(ref this.clearCoverType, value, #Phc.#3hc(107352245));
				if (flag)
				{
					this.OnClearCoverTypeChanged();
				}
			}
		}

		// Token: 0x170010A8 RID: 4264
		// (get) Token: 0x0600355F RID: 13663 RVA: 0x0002EDC4 File Offset: 0x0002CFC4
		// (set) Token: 0x06003560 RID: 13664 RVA: 0x00107FDC File Offset: 0x001061DC
		public StandardBar SmallTie
		{
			get
			{
				return this.smallTie;
			}
			set
			{
				bool flag = this.SetProperty<StandardBar>(ref this.smallTie, value, #Phc.#3hc(107397739));
				if (flag)
				{
					this.OnSmallTieChanged();
				}
			}
		}

		// Token: 0x170010A9 RID: 4265
		// (get) Token: 0x06003561 RID: 13665 RVA: 0x0002EDD0 File Offset: 0x0002CFD0
		// (set) Token: 0x06003562 RID: 13666 RVA: 0x00108018 File Offset: 0x00106218
		public StandardBar LargeTie
		{
			get
			{
				return this.largeTie;
			}
			set
			{
				bool flag = this.SetProperty<StandardBar>(ref this.largeTie, value, #Phc.#3hc(107397758));
				if (flag)
				{
					this.OnLargeTieChanged();
				}
			}
		}

		// Token: 0x170010AA RID: 4266
		// (get) Token: 0x06003563 RID: 13667 RVA: 0x0002EDDC File Offset: 0x0002CFDC
		// (set) Token: 0x06003564 RID: 13668 RVA: 0x00108054 File Offset: 0x00106254
		public StandardBar LongitudinalBar
		{
			get
			{
				return this.longitudinalBar;
			}
			set
			{
				bool flag = this.SetProperty<StandardBar>(ref this.longitudinalBar, value, #Phc.#3hc(107397745));
				if (flag)
				{
					this.OnLongitudinalBarChanged();
				}
			}
		}

		// Token: 0x170010AB RID: 4267
		// (get) Token: 0x06003565 RID: 13669 RVA: 0x0002EDE8 File Offset: 0x0002CFE8
		public CustomObservableCollection<StandardBar> AvailableBars { get; }

		// Token: 0x170010AC RID: 4268
		// (get) Token: 0x06003566 RID: 13670 RVA: 0x00108090 File Offset: 0x00106290
		protected ClearCoverType ModelClearCoverType
		{
			get
			{
				if (this.services.Project.Model.Options.ProblemType != ProblemType.Design)
				{
					return this.services.Project.Model.Options.InvestigationClearCover;
				}
				return this.services.Project.Model.Options.DesignClearCover;
			}
		}

		// Token: 0x06003567 RID: 13671 RVA: 0x001080FC File Offset: 0x001062FC
		public void InitializeData()
		{
			ColumnModel columnModel = this.services.Project.Model;
			this.AvailableBars.#NBc();
			this.AvailableBars.RemoveAll();
			this.AvailableBars.#pR(this.services.Project.Model.Bars);
			this.AvailableBars.#OBc();
			this.ClearCoverType = this.ModelClearCoverType;
			this.SmallTie = this.AvailableBars.ElementAtOrDefault(columnModel.Ties.SmallTie);
			this.LargeTie = this.AvailableBars.ElementAtOrDefault(columnModel.Ties.LargeTie);
			this.LongitudinalBar = this.AvailableBars.ElementAtOrDefault(columnModel.Ties.LongitudinalBar);
		}

		// Token: 0x06003568 RID: 13672 RVA: 0x001081DC File Offset: 0x001063DC
		private void OnClearCoverTypeChanged()
		{
			ColumnModel model = this.services.Project.Model;
			if (this.ModelClearCoverType == this.ClearCoverType)
			{
				return;
			}
			this.editorService.#0Pb(delegate()
			{
				if (model.Options.ProblemType == ProblemType.Design)
				{
					model.Options.DesignClearCover = this.ClearCoverType;
				}
				else
				{
					model.Options.InvestigationClearCover = this.ClearCoverType;
				}
				this.reinforcementBarsService.#bR();
			});
			this.RequestRedraw();
		}

		// Token: 0x06003569 RID: 13673 RVA: 0x0010824C File Offset: 0x0010644C
		private void OnSmallTieChanged()
		{
			if (this.SmallTie == null)
			{
				return;
			}
			ColumnModel model = this.services.Project.Model;
			if (model.Bars.ElementAtOrDefault(model.Ties.SmallTie) == this.SmallTie)
			{
				return;
			}
			this.editorService.#0Pb(delegate()
			{
				model.Ties.SmallTie = this.GetBarIndex(this.SmallTie);
				this.reinforcementBarsService.#bR();
			});
			this.RequestRedraw();
		}

		// Token: 0x0600356A RID: 13674 RVA: 0x001082F0 File Offset: 0x001064F0
		private void OnLargeTieChanged()
		{
			if (this.LargeTie == null)
			{
				return;
			}
			ColumnModel model = this.services.Project.Model;
			if (model.Bars.ElementAtOrDefault(model.Ties.LargeTie) == this.LargeTie)
			{
				return;
			}
			this.editorService.#0Pb(delegate()
			{
				model.Ties.LargeTie = this.GetBarIndex(this.LargeTie);
				this.reinforcementBarsService.#bR();
			});
			this.RequestRedraw();
		}

		// Token: 0x0600356B RID: 13675 RVA: 0x00108394 File Offset: 0x00106594
		private void OnLongitudinalBarChanged()
		{
			if (this.LongitudinalBar == null)
			{
				return;
			}
			ColumnModel model = this.services.Project.Model;
			if (model.Bars.ElementAtOrDefault(model.Ties.LongitudinalBar) == this.LongitudinalBar)
			{
				return;
			}
			this.editorService.#0Pb(delegate()
			{
				model.Ties.LongitudinalBar = this.GetBarIndex(this.LongitudinalBar);
				this.reinforcementBarsService.#bR();
			});
			this.RequestRedraw();
		}

		// Token: 0x0600356C RID: 13676 RVA: 0x0002EDF4 File Offset: 0x0002CFF4
		private void RequestRedraw()
		{
			this.services.Renderer.#9f(false, false);
		}

		// Token: 0x0600356D RID: 13677 RVA: 0x0002EE14 File Offset: 0x0002D014
		private int GetBarIndex(StandardBar bar)
		{
			return this.AvailableBars.#C7c(bar);
		}

		// Token: 0x04001612 RID: 5650
		private ClearCoverType clearCoverType;

		// Token: 0x04001613 RID: 5651
		private StandardBar smallTie;

		// Token: 0x04001614 RID: 5652
		private StandardBar largeTie;

		// Token: 0x04001615 RID: 5653
		private StandardBar longitudinalBar;

		// Token: 0x04001616 RID: 5654
		private readonly IExtendedServices services;

		// Token: 0x04001617 RID: 5655
		private readonly IEditorService editorService;

		// Token: 0x04001618 RID: 5656
		private readonly IReinforcementBarsService reinforcementBarsService;

		// Token: 0x04001619 RID: 5657
		public static CustomObservableCollection<ClearCoverType> AvailableClearCoverTypes = new CustomObservableCollection<ClearCoverType>
		{
			ClearCoverType.ToLongitudinalBar,
			ClearCoverType.ToTranverseBar
		};
	}
}
