using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #ede;
using #NDb;
using #npe;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.Products.Column.Core.API;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Model.Entities;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.Core;
using Telerik.Windows.Controls.Map;

namespace StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Reinforcement
{
	// Token: 0x02000572 RID: 1394
	internal sealed class EditIrregularReinforcementBarsViewModel : ViewModelWithRowsBase<IrregularBar, #MDb>, INotifyPropertyChanged, IViewModel, IViewModel<#MDb>, #UDb
	{
		// Token: 0x06003188 RID: 12680 RVA: 0x0002BE51 File Offset: 0x0002A051
		public EditIrregularReinforcementBarsViewModel(Lazy<#MDb> view, IExtendedServices services, IEditorService editorService) : base(view, services)
		{
			this.#a = services;
			this.#b = editorService;
			base.CanRemoveLastRemainingRow = true;
			this.#a.MessageBus.UnitSystemChanged += this.#EO;
		}

		// Token: 0x17000FE1 RID: 4065
		// (get) Token: 0x06003189 RID: 12681 RVA: 0x0002BE8C File Offset: 0x0002A08C
		public override bool HasErrors
		{
			get
			{
				return base.Items.Any(new Func<IrregularBar, bool>(EditIrregularReinforcementBarsViewModel.<>c.<>9.#E9b));
			}
		}

		// Token: 0x0600318A RID: 12682 RVA: 0x000FC760 File Offset: 0x000FA960
		public void #twb()
		{
			ColumnModel columnModel = this.#a.Project.Model;
			List<IrregularBar> list = columnModel.ReinforcementBars.Select(new Func<ReinforcementBar, IrregularBar>(this.#YDb)).ToList<IrregularBar>();
			list.ForEach(new Action<IrregularBar>(EditIrregularReinforcementBarsViewModel.<>c.<>9.#LVi));
			base.Items.#NBc();
			base.Items.RemoveAll();
			base.Items.#pR(list);
			base.Items.#OBc();
			IrregularBar irregularBar = list.FirstOrDefault(new Func<IrregularBar, bool>(EditIrregularReinforcementBarsViewModel.<>c.<>9.#MVi));
			this.SelectedItem = (irregularBar ?? base.Items.FirstOrDefault<IrregularBar>());
			this.#9Ti(irregularBar);
			this.#vh();
		}

		// Token: 0x0600318B RID: 12683 RVA: 0x0002BEC4 File Offset: 0x0002A0C4
		protected override void #uh(#MDb #Ee)
		{
			base.#uh(#Ee);
			this.#cD(#Ee);
		}

		// Token: 0x0600318C RID: 12684 RVA: 0x000FC854 File Offset: 0x000FAA54
		protected override bool #dD(object #Sb)
		{
			#gee #gee = #6de.#ul(base.Project.Model.#BY());
			return base.Items.Count < #gee.Core.MaximalBarsCount;
		}

		// Token: 0x0600318D RID: 12685 RVA: 0x000FC89C File Offset: 0x000FAA9C
		protected override void #4B(object #uI)
		{
			base.#4B(#uI);
			IrregularBar irregularBar = #uI as IrregularBar;
			if (irregularBar != null)
			{
				float area = 0.5f;
				float x = 0f;
				float y = 0f;
				float z = 0f;
				if (this.SelectedItem != null)
				{
					area = this.SelectedItem.Area;
					x = this.SelectedItem.X;
					y = this.SelectedItem.Y;
					z = this.SelectedItem.Z;
				}
				irregularBar.Area = area;
				irregularBar.X = x;
				irregularBar.Y = y;
				irregularBar.Z = z;
				irregularBar.CommitCallback = new Action<IrregularBar>(this.#VDb);
				this.#XDb();
				this.#vh();
			}
		}

		// Token: 0x0600318E RID: 12686 RVA: 0x0002BEE0 File Offset: 0x0002A0E0
		protected override void #lG(object #mG)
		{
			base.#lG(#mG);
			this.#XDb();
			this.#vh();
		}

		// Token: 0x0600318F RID: 12687 RVA: 0x0002BF01 File Offset: 0x0002A101
		private void #EO(object #Ge, EventArgs #He)
		{
			if (base.View.IsVisible)
			{
				this.#twb();
			}
		}

		// Token: 0x06003190 RID: 12688 RVA: 0x000FC968 File Offset: 0x000FAB68
		private void #9Ti(IrregularBar #aUi)
		{
			this.#5Xi(#aUi, 1, new string[]
			{
				#Phc.#3hc(107397869),
				#Phc.#3hc(107408964),
				#Phc.#3hc(107408991)
			});
		}

		// Token: 0x06003191 RID: 12689 RVA: 0x0002BF22 File Offset: 0x0002A122
		private void #zxb()
		{
			this.#a.Renderer.#9f(false, false);
		}

		// Token: 0x06003192 RID: 12690 RVA: 0x0002BF42 File Offset: 0x0002A142
		private void #VDb(IrregularBar #WDb)
		{
			this.#XDb();
		}

		// Token: 0x06003193 RID: 12691 RVA: 0x000FC9B8 File Offset: 0x000FABB8
		private void #XDb()
		{
			EditIrregularReinforcementBarsViewModel.#61b #61b = new EditIrregularReinforcementBarsViewModel.#61b();
			#61b.#a = this;
			if (this.HasErrors)
			{
				return;
			}
			#61b.#b = base.Items.Select(new Func<IrregularBar, ReinforcementBar>(EditIrregularReinforcementBarsViewModel.<>c.<>9.#NVi)).ToList<ReinforcementBar>();
			for (int i = 0; i < base.Items.Count; i++)
			{
				base.Items[i].OriginalBar = #61b.#b[i];
			}
			this.#b.#0Pb(new Action(#61b.#G9b));
			this.#zxb();
			this.#a.MessageBus.#HV();
		}

		// Token: 0x06003194 RID: 12692 RVA: 0x0002BF52 File Offset: 0x0002A152
		[CompilerGenerated]
		private IrregularBar #YDb(ReinforcementBar #rG)
		{
			return new IrregularBar(#rG, new Action<IrregularBar>(this.#VDb));
		}

		// Token: 0x04001420 RID: 5152
		private readonly IExtendedServices #a;

		// Token: 0x04001421 RID: 5153
		private readonly IEditorService #b;

		// Token: 0x02000574 RID: 1396
		[CompilerGenerated]
		private sealed class #61b
		{
			// Token: 0x0600319C RID: 12700 RVA: 0x000FCA90 File Offset: 0x000FAC90
			internal void #G9b()
			{
				if (this.#a.IsValid)
				{
					this.#a.Project.Model.#HY(#ope.#d);
				}
				this.#a.#a.Project.Model.ReinforcementBars.Clear();
				this.#a.#a.Project.Model.ReinforcementBars.AddRange(this.#b);
			}

			// Token: 0x04001427 RID: 5159
			public EditIrregularReinforcementBarsViewModel #a;

			// Token: 0x04001428 RID: 5160
			public List<ReinforcementBar> #b;
		}
	}
}
