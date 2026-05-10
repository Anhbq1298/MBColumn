using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using #6re;
using #7hc;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.NewCapacityRatio;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Rendering.Tabular.TelerikGrid;
using StructurePoint.Products.Column.FailureSurface.ViewModels.DTO;
using Telerik.Windows.Data;

namespace #Djb
{
	// Token: 0x02000421 RID: 1057
	internal sealed class #Kjb : FilterDescriptor<GridDataRowCore>
	{
		// Token: 0x0600265B RID: 9819 RVA: 0x000D64E8 File Offset: 0x000D46E8
		public #Kjb()
		{
			this.AllLoadPointsAreVisible = false;
			ParameterExpression parameterExpression = Expression.Parameter(typeof(GridDataRowCore), #Phc.#3hc(107361131));
			base.FilteringExpression = Expression.Lambda<Func<GridDataRowCore, bool>>(Expression.Call(Expression.Constant(this, typeof(#Kjb)), methodof(#Kjb.#zjb(GridDataRowCore)), new Expression[]
			{
				parameterExpression
			}), new ParameterExpression[]
			{
				parameterExpression
			});
		}

		// Token: 0x17000CFA RID: 3322
		// (get) Token: 0x0600265C RID: 9820 RVA: 0x0002408C File Offset: 0x0002228C
		public IReadOnlyList<LoadPointDrawingData> VisibleLoadPoints
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x17000CFB RID: 3323
		// (get) Token: 0x0600265D RID: 9821 RVA: 0x00024098 File Offset: 0x00022298
		// (set) Token: 0x0600265E RID: 9822 RVA: 0x000240A4 File Offset: 0x000222A4
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

		// Token: 0x17000CFC RID: 3324
		// (get) Token: 0x0600265F RID: 9823 RVA: 0x000240DF File Offset: 0x000222DF
		// (set) Token: 0x06002660 RID: 9824 RVA: 0x000240EB File Offset: 0x000222EB
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

		// Token: 0x17000CFD RID: 3325
		// (get) Token: 0x06002661 RID: 9825 RVA: 0x00024121 File Offset: 0x00022321
		// (set) Token: 0x06002662 RID: 9826 RVA: 0x0002412D File Offset: 0x0002232D
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

		// Token: 0x17000CFE RID: 3326
		// (get) Token: 0x06002663 RID: 9827 RVA: 0x0002415B File Offset: 0x0002235B
		// (set) Token: 0x06002664 RID: 9828 RVA: 0x00024167 File Offset: 0x00022367
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

		// Token: 0x17000CFF RID: 3327
		// (get) Token: 0x06002665 RID: 9829 RVA: 0x00024195 File Offset: 0x00022395
		// (set) Token: 0x06002666 RID: 9830 RVA: 0x000241A1 File Offset: 0x000223A1
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

		// Token: 0x17000D00 RID: 3328
		// (get) Token: 0x06002667 RID: 9831 RVA: 0x000241CF File Offset: 0x000223CF
		// (set) Token: 0x06002668 RID: 9832 RVA: 0x000241DB File Offset: 0x000223DB
		public ConsideredAxis ConsideredAxis { get; set; }

		// Token: 0x17000D01 RID: 3329
		// (get) Token: 0x06002669 RID: 9833 RVA: 0x000241EC File Offset: 0x000223EC
		// (set) Token: 0x0600266A RID: 9834 RVA: 0x000241F8 File Offset: 0x000223F8
		public bool AllLoadPointsAreVisible { get; private set; }

		// Token: 0x0600266B RID: 9835 RVA: 0x000D656C File Offset: 0x000D476C
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
			this.#g = #mA.CapacityRatioCalculationMethod;
		}

		// Token: 0x0600266C RID: 9836 RVA: 0x00024209 File Offset: 0x00022409
		public bool #Jjb()
		{
			return this.IsCapacityRatioFilterActive || this.IsLocationFilterActive || this.IsVisibilityFilterActive;
		}

		// Token: 0x0600266D RID: 9837 RVA: 0x000D65D4 File Offset: 0x000D47D4
		public void #xjb(IReadOnlyList<LoadPointDrawingData> #yjb)
		{
			this.#a.Clear();
			this.AllLoadPointsAreVisible = (#yjb == null);
			if (#yjb != null)
			{
				this.#a.AddRange(#yjb);
			}
			if (this.IsLocationFilterActive)
			{
				base.OnPropertyChanged(null);
			}
		}

		// Token: 0x0600266E RID: 9838 RVA: 0x000D6620 File Offset: 0x000D4820
		public bool #zjb(GridDataRowCore #uI)
		{
			#Kjb.#p6b #p6b = new #Kjb.#p6b();
			#Kjb.#p6b #p6b2;
			if (!false)
			{
				#p6b2 = #p6b;
			}
			if (#uI == null)
			{
				return false;
			}
			#p6b2.#a = (#uI.Metadata as LoadPointRowMetadata);
			if (#p6b2.#a == null)
			{
				return false;
			}
			bool flag = true;
			if (this.IsLocationFilterActive && !string.IsNullOrWhiteSpace(#p6b2.#a.Location))
			{
				flag = string.Equals(#p6b2.#a.Location.Trim(), this.LocationFilter, StringComparison.OrdinalIgnoreCase);
			}
			bool flag2 = true;
			if (flag && this.IsCapacityRatioFilterActive)
			{
				flag2 = CapacityRatioHelper.#pAe(#p6b2.#a.CapacityRatio, (#x6e)this.#g, this.CapacityRatioFilterValue, false);
			}
			bool flag3 = true;
			if (flag2 && this.IsVisibilityFilterActive && this.ConsideredAxis == ConsideredAxis.Both)
			{
				flag3 = (this.AllLoadPointsAreVisible || this.#a.Any(new Func<LoadPointDrawingData, bool>(#p6b2.#n6b)));
			}
			return flag && flag2 && flag3;
		}

		// Token: 0x04000F35 RID: 3893
		private readonly List<LoadPointDrawingData> #a = new List<LoadPointDrawingData>();

		// Token: 0x04000F36 RID: 3894
		private bool #b;

		// Token: 0x04000F37 RID: 3895
		private string #c;

		// Token: 0x04000F38 RID: 3896
		private bool #d;

		// Token: 0x04000F39 RID: 3897
		private double #e;

		// Token: 0x04000F3A RID: 3898
		private bool #f;

		// Token: 0x04000F3B RID: 3899
		private SectionCapacityMethodType #g;

		// Token: 0x04000F3C RID: 3900
		[CompilerGenerated]
		private ConsideredAxis #h;

		// Token: 0x04000F3D RID: 3901
		[CompilerGenerated]
		private bool #i;

		// Token: 0x02000422 RID: 1058
		[CompilerGenerated]
		private sealed class #p6b
		{
			// Token: 0x06002670 RID: 9840 RVA: 0x000D6718 File Offset: 0x000D4918
			internal bool #n6b(LoadPointDrawingData #Rf)
			{
				int num = #Rf.Index;
				int? num2 = this.#a.Number;
				return num == num2.GetValueOrDefault() & num2 != null;
			}

			// Token: 0x04000F3E RID: 3902
			public LoadPointRowMetadata #a;
		}
	}
}
