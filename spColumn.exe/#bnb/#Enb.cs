using System;
using System.Runtime.CompilerServices;
using #7hc;
using #7Pb;
using #eU;
using devDept.Geometry;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Units;
using StructurePoint.Products.Column.Model.Entities.Units;

namespace #bnb
{
	// Token: 0x0200044D RID: 1101
	internal sealed class #Enb : #rnb
	{
		// Token: 0x06002853 RID: 10323 RVA: 0x000DB030 File Offset: 0x000D9230
		public #Enb(#oW #xn) : base(#xn, string.Format(#Phc.#3hc(107359865), 150, 150))
		{
			base.Values.#pR(new #nQb[]
			{
				#nQb.Separator,
				this.CordinateX,
				this.CordinateY
			});
			base.#fQb();
		}

		// Token: 0x17000D86 RID: 3462
		// (get) Token: 0x06002854 RID: 10324 RVA: 0x0002531F File Offset: 0x0002351F
		public #nQb CordinateX { get; }

		// Token: 0x17000D87 RID: 3463
		// (get) Token: 0x06002855 RID: 10325 RVA: 0x0002532B File Offset: 0x0002352B
		public #nQb CordinateY { get; }

		// Token: 0x06002856 RID: 10326 RVA: 0x00025337 File Offset: 0x00023537
		public void #Dnb()
		{
			this.#uP(this.#a);
		}

		// Token: 0x06002857 RID: 10327 RVA: 0x000DB0B0 File Offset: 0x000D92B0
		public void #uP(double #9o, double #7W)
		{
			this.#a = new Point3D(#9o, #7W);
			ColumnUnit<LengthUnit> columnUnit = base.Project.Model.Units.Section.Width;
			this.CordinateX.Value = base.#onb(base.DimensionFormatter, #Phc.#3hc(107408964), new double?(#9o), columnUnit.Symbol);
			this.CordinateY.Value = base.#onb(base.DimensionFormatter, #Phc.#3hc(107408991), new double?(#7W), columnUnit.Symbol);
		}

		// Token: 0x06002858 RID: 10328 RVA: 0x000DB160 File Offset: 0x000D9360
		public void #uP(Point2D #Ng)
		{
			if (#Ng == null || !base.Project.Model.DraftingSettings.StatusBarSettings.ShowCoordinates)
			{
				this.#yl();
				return;
			}
			this.#uP(#Ng.X, #Ng.Y);
		}

		// Token: 0x06002859 RID: 10329 RVA: 0x00025351 File Offset: 0x00023551
		private new void #yl()
		{
			this.#a = null;
			this.CordinateX.Value = string.Empty;
			this.CordinateY.Value = string.Empty;
		}

		// Token: 0x04000FF0 RID: 4080
		private new Point3D #a;

		// Token: 0x04000FF1 RID: 4081
		[CompilerGenerated]
		private readonly #nQb #b = new #nQb();

		// Token: 0x04000FF2 RID: 4082
		[CompilerGenerated]
		private readonly #nQb #c = new #nQb();
	}
}
