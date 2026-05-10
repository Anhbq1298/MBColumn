using System;
using System.Runtime.CompilerServices;
using #eU;
using #tFb;
using StructurePoint.CoreAssets.GUI.DesktopControls.Data;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.Model.Entities.Units;

namespace StructurePoint.Products.Column.Editor.Section.Irregular.Tools.Reinforcement
{
	// Token: 0x02000592 RID: 1426
	internal sealed class BarsParametersContext : NotifyPropertyChangedObjectBase, #JFb
	{
		// Token: 0x06003239 RID: 12857 RVA: 0x0002C80C File Offset: 0x0002AA0C
		public BarsParametersContext(#oW project)
		{
			this.#a = project;
		}

		// Token: 0x17000FF3 RID: 4083
		// (get) Token: 0x0600323A RID: 12858 RVA: 0x0002C81B File Offset: 0x0002AA1B
		// (set) Token: 0x0600323B RID: 12859 RVA: 0x0002C827 File Offset: 0x0002AA27
		public double Cover { get; set; }

		// Token: 0x17000FF4 RID: 4084
		// (get) Token: 0x0600323C RID: 12860 RVA: 0x0002C838 File Offset: 0x0002AA38
		// (set) Token: 0x0600323D RID: 12861 RVA: 0x0002C844 File Offset: 0x0002AA44
		public #fU CoverType { get; set; }

		// Token: 0x17000FF5 RID: 4085
		// (get) Token: 0x0600323E RID: 12862 RVA: 0x0002C855 File Offset: 0x0002AA55
		// (set) Token: 0x0600323F RID: 12863 RVA: 0x0002C861 File Offset: 0x0002AA61
		public UnitSystem ActiveUnitSystem { get; set; }

		// Token: 0x06003240 RID: 12864 RVA: 0x000FF66C File Offset: 0x000FD86C
		public void #gFb(UnitSystem #hFb)
		{
			if (#hFb != this.ActiveUnitSystem)
			{
				UnitValueGroups #3r = (#hFb == UnitSystem.SIMetric) ? this.#a.Model.EnglishUnits : this.#a.Model.MetricUnits;
				UnitValueGroups #4r = (#hFb == UnitSystem.SIMetric) ? this.#a.Model.MetricUnits : this.#a.Model.EnglishUnits;
				this.Cover = this.#Pb<LengthUnit>(#3r, #4r, new Func<UnitValueGroups, ColumnUnit<LengthUnit>>(BarsParametersContext.<>c.<>9.#P9b), this.Cover);
				this.ActiveUnitSystem = #hFb;
			}
		}

		// Token: 0x06003241 RID: 12865 RVA: 0x000F7118 File Offset: 0x000F5318
		protected double #Pb<#06>(UnitValueGroups #3r, UnitValueGroups #4r, Func<UnitValueGroups, ColumnUnit<#06>> #Z6, double #c4) where #06 : struct, IComparable
		{
			ColumnUnit<#06> columnUnit = #Z6(#3r);
			ColumnUnit<#06> #b = #Z6(#4r);
			return columnUnit.#a4(#b, #c4);
		}

		// Token: 0x06003242 RID: 12866 RVA: 0x000FF72C File Offset: 0x000FD92C
		public void #eb(bool #nz)
		{
			if (!this.#b || #nz)
			{
				this.#b = true;
				this.ActiveUnitSystem = this.#a.Model.Options.Unit;
				this.Cover = ((this.ActiveUnitSystem == UnitSystem.SIMetric) ? 40.0 : 1.5);
			}
		}

		// Token: 0x04001469 RID: 5225
		private readonly #oW #a;

		// Token: 0x0400146A RID: 5226
		private bool #b;

		// Token: 0x0400146B RID: 5227
		[CompilerGenerated]
		private double #c;

		// Token: 0x0400146C RID: 5228
		[CompilerGenerated]
		private #fU #d;

		// Token: 0x0400146D RID: 5229
		[CompilerGenerated]
		private UnitSystem #e;
	}
}
