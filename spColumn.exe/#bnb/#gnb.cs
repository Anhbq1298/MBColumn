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
	// Token: 0x02000449 RID: 1097
	internal sealed class #gnb : #rnb
	{
		// Token: 0x06002839 RID: 10297 RVA: 0x000DAA88 File Offset: 0x000D8C88
		public #gnb(#oW #xn) : base(#xn, string.Format(#Phc.#3hc(107359944), new object[]
		{
			150,
			150,
			150,
			150
		}))
		{
			base.Values.#pR(new #nQb[]
			{
				#nQb.Separator,
				this.MomentX,
				this.MomentY,
				this.XEcc,
				this.YEcc
			});
			base.#fQb();
		}

		// Token: 0x17000D78 RID: 3448
		// (get) Token: 0x0600283A RID: 10298 RVA: 0x00025205 File Offset: 0x00023405
		public #nQb MomentX { get; }

		// Token: 0x17000D79 RID: 3449
		// (get) Token: 0x0600283B RID: 10299 RVA: 0x00025211 File Offset: 0x00023411
		public #nQb MomentY { get; }

		// Token: 0x17000D7A RID: 3450
		// (get) Token: 0x0600283C RID: 10300 RVA: 0x0002521D File Offset: 0x0002341D
		public #nQb XEcc { get; }

		// Token: 0x17000D7B RID: 3451
		// (get) Token: 0x0600283D RID: 10301 RVA: 0x00025229 File Offset: 0x00023429
		public #nQb YEcc { get; }

		// Token: 0x0600283E RID: 10302 RVA: 0x000DAB54 File Offset: 0x000D8D54
		public void #enb(Point #Ng)
		{
			ColumnUnit<MomentUnit> columnUnit = base.Project.Model.Units.Loads.FactoredLoadMux;
			this.MomentX.Value = base.#onb(base.MomentFormatter, Strings.StringMx, new double?(#Ng.X), columnUnit.Symbol);
			this.MomentY.Value = base.#onb(base.MomentFormatter, Strings.StringMy, new double?(#Ng.Y), columnUnit.Symbol);
		}

		// Token: 0x0600283F RID: 10303 RVA: 0x000DABEC File Offset: 0x000D8DEC
		public void #fnb(double #9o, double #7W)
		{
			ColumnUnit<LengthUnit> columnUnit = base.Project.Model.Units.Section.Width;
			this.XEcc.Value = (double.IsNaN(#9o) ? (#Phc.#3hc(107359906) + Strings.StringInfinity.#O2d() + columnUnit.Symbol) : base.#onb(base.EccentricyFormatter, #Phc.#3hc(107359915), new double?(#9o), columnUnit.Symbol));
			this.YEcc.Value = (double.IsNaN(#7W) ? (#Phc.#3hc(107359884) + Strings.StringInfinity.#O2d() + columnUnit.Symbol) : base.#onb(base.EccentricyFormatter, #Phc.#3hc(107359925), new double?(#7W), columnUnit.Symbol));
		}

		// Token: 0x04000FE1 RID: 4065
		[CompilerGenerated]
		private new readonly #nQb #a = new #nQb();

		// Token: 0x04000FE2 RID: 4066
		[CompilerGenerated]
		private readonly #nQb #b = new #nQb();

		// Token: 0x04000FE3 RID: 4067
		[CompilerGenerated]
		private readonly #nQb #c = new #nQb();

		// Token: 0x04000FE4 RID: 4068
		[CompilerGenerated]
		private readonly #nQb #d = new #nQb();
	}
}
