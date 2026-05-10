using System;
using System.Linq;
using #cMb;
using #ede;
using #tFb;
using devDept.Geometry;
using StructurePoint.CoreAssets.AppManager.Column.Helpers;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.Products.Column.Editor.Section.Common;
using StructurePoint.Products.Column.Services.API;

namespace #NDb
{
	// Token: 0x0200058B RID: 1419
	internal sealed class #qEb : #hEb, #uNb, #DFb
	{
		// Token: 0x06003223 RID: 12835 RVA: 0x0002C692 File Offset: 0x0002A892
		public #qEb(IExtendedServices #0c, #zFb #Pc, #nFb #9Db) : base(#0c, #Pc, #9Db)
		{
		}

		// Token: 0x06003224 RID: 12836 RVA: 0x000FF1F8 File Offset: 0x000FD3F8
		protected override void #7Db(Point3D #Ng)
		{
			base.BarPositions.Clear();
			base.LastPoint = #Ng;
			double? num = base.Parameters.#3Eb();
			if (num != null)
			{
				base.Radius = new double?(CircleHelper.#wmc(num.Value));
			}
			if (num == null || !(base.StartPoint != null) || !(#Ng != null) || !base.#Dzb(base.StartPoint, #Ng))
			{
				if (num != null && #Ng != null)
				{
					base.BarPositions.Add(#Ng);
				}
				return;
			}
			BarPlacementType barPlacementType = base.Parameters.BarPlacementType;
			if (barPlacementType == BarPlacementType.Numbers)
			{
				base.BarPositions.AddRange(ReinforcementPatternHelper.#FLe(base.StartPoint, #Ng, base.Parameters.NumberOfBarsX, base.Parameters.NumberOfBarsY).Take(#dde.Instance.BarsAtOnce));
				return;
			}
			if (barPlacementType != BarPlacementType.Spacing)
			{
				return;
			}
			base.BarPositions.AddRange(ReinforcementPatternHelper.#ELe(base.StartPoint, #Ng, base.Parameters.BarSpacingX, base.Parameters.BarSpacingY).Take(#dde.Instance.BarsAtOnce));
		}
	}
}
