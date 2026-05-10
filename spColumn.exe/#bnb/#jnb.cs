using System;
using System.Runtime.CompilerServices;
using #7hc;
using #7Pb;
using #eU;
using StructurePoint.CoreAssets.Infrastructure.Data;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.Model.Entities.Units;

namespace #bnb
{
	// Token: 0x0200044A RID: 1098
	internal sealed class #jnb : #rnb
	{
		// Token: 0x06002840 RID: 10304 RVA: 0x000DACE0 File Offset: 0x000D8EE0
		public #jnb(#oW #xn) : base(#xn, string.Format(#Phc.#3hc(107359969), 150, 150, 150))
		{
			base.Values.#pR(new #nQb[]
			{
				#nQb.Separator,
				this.Force,
				this.Moment,
				this.Ecc
			});
			base.#fQb();
		}

		// Token: 0x17000D7C RID: 3452
		// (get) Token: 0x06002841 RID: 10305 RVA: 0x00025235 File Offset: 0x00023435
		public #nQb Force { get; }

		// Token: 0x17000D7D RID: 3453
		// (get) Token: 0x06002842 RID: 10306 RVA: 0x00025241 File Offset: 0x00023441
		public #nQb Moment { get; }

		// Token: 0x17000D7E RID: 3454
		// (get) Token: 0x06002843 RID: 10307 RVA: 0x0002524D File Offset: 0x0002344D
		public #nQb Ecc { get; }

		// Token: 0x06002844 RID: 10308 RVA: 0x000DAD7C File Offset: 0x000D8F7C
		public void #fnb(double #f)
		{
			ColumnUnit<LengthUnit> columnUnit = base.Project.Model.Units.Section.Width;
			this.Ecc.Value = (double.IsNaN(#f) ? (#Phc.#3hc(107359898) + Strings.StringInfinity.#O2d() + columnUnit.Symbol) : base.#onb(base.EccentricyFormatter, #Phc.#3hc(107359903), new double?(#f), columnUnit.Symbol));
		}

		// Token: 0x06002845 RID: 10309 RVA: 0x000DAE0C File Offset: 0x000D900C
		public void #enb(Point #Ng)
		{
			ColumnUnit<MomentUnit> columnUnit = base.Project.Model.Units.Loads.FactoredLoadMux;
			this.Moment.Value = base.#onb(base.MomentFormatter, #Phc.#3hc(107359889), new double?(#Ng.X), columnUnit.Symbol);
			ColumnUnit<ForceUnit> columnUnit2 = base.Project.Model.Units.Loads.AxialLoadFinal;
			this.Force.Value = base.#onb(base.ForceFormatter, #Phc.#3hc(107359852), new double?(#Ng.Y), columnUnit2.Symbol);
		}

		// Token: 0x04000FE5 RID: 4069
		[CompilerGenerated]
		private new readonly #nQb #a = new #nQb();

		// Token: 0x04000FE6 RID: 4070
		[CompilerGenerated]
		private readonly #nQb #b = new #nQb();

		// Token: 0x04000FE7 RID: 4071
		[CompilerGenerated]
		private readonly #nQb #c = new #nQb();
	}
}
