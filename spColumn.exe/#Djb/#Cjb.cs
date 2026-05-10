using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #6re;
using #7hc;
using #9Ue;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.NewCapacityRatio;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;
using StructurePoint.Products.Column.FailureSurface.ViewModels.DTO;
using StructurePoint.Products.Column.FailureSurface.ViewModels.Filtering;
using Telerik.Windows.Data;

namespace #Djb
{
	// Token: 0x0200041D RID: 1053
	internal sealed class #Cjb : FilterDescriptor<NavigationComboItem>
	{
		// Token: 0x0600263F RID: 9791 RVA: 0x000D608C File Offset: 0x000D428C
		public #Cjb()
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(NavigationComboItem), #Phc.#3hc(107361131));
			base.FilteringExpression = Expression.Lambda<Func<NavigationComboItem, bool>>(Expression.Call(Expression.Constant(this, typeof(#Cjb)), methodof(#Cjb.#zjb(NavigationComboItem)), new Expression[]
			{
				parameterExpression
			}), new ParameterExpression[]
			{
				parameterExpression
			});
		}

		// Token: 0x17000CEE RID: 3310
		// (get) Token: 0x06002640 RID: 9792 RVA: 0x00023EBF File Offset: 0x000220BF
		// (set) Token: 0x06002641 RID: 9793 RVA: 0x00023ECB File Offset: 0x000220CB
		public string LocationFilter
		{
			get
			{
				return this.#c;
			}
			set
			{
				if (this.#c != value)
				{
					this.#c = value;
					if (this.IsLocationFilterActive)
					{
						base.OnPropertyChanged(#Phc.#3hc(107405552));
					}
				}
			}
		}

		// Token: 0x17000CEF RID: 3311
		// (get) Token: 0x06002642 RID: 9794 RVA: 0x00023F06 File Offset: 0x00022106
		// (set) Token: 0x06002643 RID: 9795 RVA: 0x00023F12 File Offset: 0x00022112
		public double CapacityRatioFilterValue
		{
			get
			{
				return this.#e;
			}
			set
			{
				if (this.#e != value)
				{
					this.#e = value;
					if (this.IsCapacityRatioFilterActive)
					{
						base.OnPropertyChanged(#Phc.#3hc(107406134));
					}
				}
			}
		}

		// Token: 0x17000CF0 RID: 3312
		// (get) Token: 0x06002644 RID: 9796 RVA: 0x00023F48 File Offset: 0x00022148
		// (set) Token: 0x06002645 RID: 9797 RVA: 0x00023F54 File Offset: 0x00022154
		public bool IsCapacityRatioFilterActive
		{
			get
			{
				return this.#d;
			}
			set
			{
				if (this.#d != value)
				{
					this.#d = value;
					base.OnPropertyChanged(#Phc.#3hc(107406101));
				}
			}
		}

		// Token: 0x17000CF1 RID: 3313
		// (get) Token: 0x06002646 RID: 9798 RVA: 0x00023F82 File Offset: 0x00022182
		// (set) Token: 0x06002647 RID: 9799 RVA: 0x00023F8E File Offset: 0x0002218E
		public bool IsLocationFilterActive
		{
			get
			{
				return this.#b;
			}
			set
			{
				if (this.#b != value)
				{
					this.#b = value;
					base.OnPropertyChanged(#Phc.#3hc(107405531));
				}
			}
		}

		// Token: 0x17000CF2 RID: 3314
		// (get) Token: 0x06002648 RID: 9800 RVA: 0x00023FBC File Offset: 0x000221BC
		// (set) Token: 0x06002649 RID: 9801 RVA: 0x00023FC8 File Offset: 0x000221C8
		public bool IsVisibilityFilterActive
		{
			get
			{
				return this.#f;
			}
			set
			{
				if (this.#f != value)
				{
					this.#f = value;
					base.OnPropertyChanged(#Phc.#3hc(107405371));
				}
			}
		}

		// Token: 0x17000CF3 RID: 3315
		// (get) Token: 0x0600264A RID: 9802 RVA: 0x00023FF6 File Offset: 0x000221F6
		// (set) Token: 0x0600264B RID: 9803 RVA: 0x00024002 File Offset: 0x00022202
		public ConsideredAxis ConsideredAxis { get; set; }

		// Token: 0x0600264C RID: 9804 RVA: 0x000D6108 File Offset: 0x000D4308
		public void #wjb(#Gse #mA)
		{
			if (#mA == null)
			{
				return;
			}
			this.CapacityRatioFilterValue = #mA.CapacityRatioFilterValue;
			this.IsCapacityRatioFilterActive = #mA.IsCapacityRatioFilterActive;
			this.LocationFilter = #mA.LocationFilter;
			this.IsVisibilityFilterActive = #mA.IsVisibilityFilterActive;
			this.IsLocationFilterActive = #mA.IsLocationFilterActive;
			this.#h = #mA.CapacityRatioCalculationMethod;
		}

		// Token: 0x0600264D RID: 9805 RVA: 0x000D6170 File Offset: 0x000D4370
		public void #xjb(IReadOnlyList<LoadPointDrawingData> #yjb)
		{
			this.#a.Clear();
			this.#g = (#yjb == null);
			if (#yjb != null)
			{
				this.#a.AddRange(#yjb);
			}
			if (this.IsLocationFilterActive)
			{
				base.OnPropertyChanged(null);
			}
		}

		// Token: 0x0600264E RID: 9806 RVA: 0x000D61BC File Offset: 0x000D43BC
		public bool #zjb(NavigationComboItem #Ajb)
		{
			if (#Ajb == null)
			{
				return false;
			}
			foreach (NavigationComboItem navigationComboItem in #Ajb.OtherItems)
			{
				#Cjb.#o6b #o6b = new #Cjb.#o6b();
				#o6b.#b = this;
				GridDataRowCore gridDataRowCore = navigationComboItem.Data;
				object obj = (gridDataRowCore != null) ? gridDataRowCore.Metadata : null;
				#o6b.#a = (obj as LoadPointRowMetadata);
				if (#o6b.#a == null)
				{
					return false;
				}
				bool flag = true;
				if (this.IsLocationFilterActive && !string.IsNullOrWhiteSpace(#o6b.#a.Location))
				{
					flag = string.Equals(#o6b.#a.Location.Trim(), this.LocationFilter, StringComparison.OrdinalIgnoreCase);
				}
				bool flag2 = true;
				if (flag && this.IsCapacityRatioFilterActive)
				{
					flag2 = CapacityRatioHelper.#pAe(#o6b.#a.CapacityRatio, (#x6e)this.#h, this.CapacityRatioFilterValue, false);
				}
				bool flag3 = true;
				if (flag2 && this.IsVisibilityFilterActive && this.ConsideredAxis == ConsideredAxis.Both)
				{
					flag3 = (this.#g || this.#a.Any(new Func<LoadPointDrawingData, bool>(#o6b.#n6b)));
				}
				if (flag && flag2 && flag3)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600264F RID: 9807 RVA: 0x000D6334 File Offset: 0x000D4534
		private bool #Bjb(LoadPointDrawingData #ycb, LoadPointRowMetadata #3ab)
		{
			bool flag = #Emc.#Bjb(new double?((double)#ycb.AxialLoad), #3ab.AxialLoad);
			bool flag2 = true;
			if (this.ConsideredAxis == ConsideredAxis.X || this.ConsideredAxis == ConsideredAxis.Both)
			{
				flag2 = #Emc.#Bjb(new double?((double)#ycb.MomentX), #3ab.MomentX);
			}
			bool flag3 = true;
			if (this.ConsideredAxis == ConsideredAxis.Y || this.ConsideredAxis == ConsideredAxis.Both)
			{
				flag3 = #Emc.#Bjb(new double?((double)#ycb.MomentY), #3ab.MomentY);
			}
			return flag && flag2 && flag3;
		}

		// Token: 0x04000F24 RID: 3876
		private readonly List<LoadPointDrawingData> #a = new List<LoadPointDrawingData>();

		// Token: 0x04000F25 RID: 3877
		private bool #b;

		// Token: 0x04000F26 RID: 3878
		private string #c;

		// Token: 0x04000F27 RID: 3879
		private bool #d;

		// Token: 0x04000F28 RID: 3880
		private double #e;

		// Token: 0x04000F29 RID: 3881
		private bool #f;

		// Token: 0x04000F2A RID: 3882
		private bool #g;

		// Token: 0x04000F2B RID: 3883
		private SectionCapacityMethodType #h;

		// Token: 0x04000F2C RID: 3884
		[CompilerGenerated]
		private ConsideredAxis #i;

		// Token: 0x0200041E RID: 1054
		[CompilerGenerated]
		private sealed class #o6b
		{
			// Token: 0x06002651 RID: 9809 RVA: 0x00024013 File Offset: 0x00022213
			internal bool #n6b(LoadPointDrawingData #Rf)
			{
				return this.#b.#Bjb(#Rf, this.#a);
			}

			// Token: 0x04000F2D RID: 3885
			public LoadPointRowMetadata #a;

			// Token: 0x04000F2E RID: 3886
			public #Cjb #b;
		}
	}
}
