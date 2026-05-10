using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #Fmc;
using #NWc;
using #T0c;
using StructurePoint.CoreAssets.Geometry.Data;
using StructurePoint.CoreAssets.Geometry.Helpers;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.GUI.Framework.Tools.Selection;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #hLc
{
	// Token: 0x02000BC3 RID: 3011
	internal sealed class #yLc : #OLc, IEntitiesSelector, #zLc
	{
		// Token: 0x06006292 RID: 25234 RVA: 0x000504E8 File Offset: 0x0004E6E8
		public #yLc(#oW #Yc, #V0c #uLc, #Qrc #NDc, #GLc #vLc) : base(#Yc, #uLc, #NDc, #vLc)
		{
		}

		// Token: 0x06006293 RID: 25235 RVA: 0x00181098 File Offset: 0x0017F298
		public override IReadOnlyList<object> #wLc(bool #xLc, Point3D? #Xrb, Point3D #Yrb)
		{
			#yLc.#v0b #v0b = new #yLc.#v0b();
			#yLc.#v0b #v0b2;
			if (7 != 0)
			{
				#v0b2 = #v0b;
			}
			#v0b2.#a = this;
			List<object> list2;
			do
			{
				List<object> list = new List<object>();
				if (-1 != 0)
				{
					list2 = list;
				}
				if (2 == 0)
				{
					goto IL_31;
				}
			}
			while (false);
			if (#Xrb != null)
			{
				#v0b2.#b = base.#LLc(#xLc, #Xrb, #Yrb);
				if (#v0b2.#b == null)
				{
					return list2;
				}
				if (!false)
				{
					list2.AddRange(base.ProjectContext.MainModel.GridLines.Where(new Func<GridLineDefinitionModel, bool>(#v0b2.#w9c)));
					return list2;
				}
				goto IL_C6;
			}
			IL_31:
			#yLc.#A9c #A9c = new #yLc.#A9c();
			#yLc.#A9c #A9c2;
			if (7 != 0)
			{
				#A9c2 = #A9c;
			}
			#A9c2.#b = #v0b2;
			GridLineDefinitionModel gridLineDefinitionModel2;
			IEnumerable<GridLineDefinitionModel> enumerable2;
			do
			{
				#A9c2.#a = PointsConverter.#vsc(#Yrb);
				GridLineDefinitionModel gridLineDefinitionModel = null;
				if (!false)
				{
					gridLineDefinitionModel2 = gridLineDefinitionModel;
				}
				IEnumerable<GridLineDefinitionModel> enumerable = base.ProjectContext.MainModel.GridLines.Where(new Func<GridLineDefinitionModel, bool>(#A9c2.#x9c));
				if (4 != 0)
				{
					enumerable2 = enumerable;
				}
				if (enumerable2 == null || enumerable2.Count<GridLineDefinitionModel>() != 1)
				{
					goto IL_A1;
				}
			}
			while (5 == 0);
			GridLineDefinitionModel gridLineDefinitionModel3 = enumerable2.First<GridLineDefinitionModel>();
			if (!false)
			{
				gridLineDefinitionModel2 = gridLineDefinitionModel3;
			}
			goto IL_C3;
			IL_A1:
			if (enumerable2 != null && enumerable2.Count<GridLineDefinitionModel>() > 1)
			{
				gridLineDefinitionModel2 = enumerable2.Aggregate(new Func<GridLineDefinitionModel, GridLineDefinitionModel, GridLineDefinitionModel>(#A9c2.#y9c));
			}
			IL_C3:
			if (gridLineDefinitionModel2 == null)
			{
				return list2;
			}
			IL_C6:
			list2.Add(gridLineDefinitionModel2);
			return list2;
		}

		// Token: 0x06006294 RID: 25236 RVA: 0x000505FB File Offset: 0x0004E7FB
		public override IReadOnlyList<object> #qLc()
		{
			return base.ProjectContext.MainModel.GridLines.ToList<GridLineDefinitionModel>();
		}

		// Token: 0x06006295 RID: 25237 RVA: 0x00050612 File Offset: 0x0004E812
		public override void #uR(IEnumerable<object> #8f)
		{
			#V0c #V0c = base.ModelEditorViewModel;
			IEnumerable<GridLineDefinitionModel> #ooc = #8f.Cast<GridLineDefinitionModel>();
			if (!false)
			{
				#V0c.#KZc(#ooc);
			}
		}

		// Token: 0x06006296 RID: 25238 RVA: 0x0005062C File Offset: 0x0004E82C
		public override void #ljb(object #Rf)
		{
			#V0c #V0c = base.ModelEditorViewModel;
			GridLineDefinitionModel #bsc = (GridLineDefinitionModel)#Rf;
			if (!false)
			{
				#V0c.#IZc(#bsc);
			}
		}

		// Token: 0x06006297 RID: 25239 RVA: 0x00050646 File Offset: 0x0004E846
		public override void #rLc(IEnumerable<object> #8f)
		{
			#V0c #V0c = base.ModelEditorViewModel;
			IEnumerable<GridLineDefinitionModel> #ooc = #8f.Cast<GridLineDefinitionModel>();
			if (!false)
			{
				#V0c.#LZc(#ooc);
			}
		}

		// Token: 0x06006298 RID: 25240 RVA: 0x00050660 File Offset: 0x0004E860
		public override void #rLc(object #Rf)
		{
			#V0c #V0c = base.ModelEditorViewModel;
			GridLineDefinitionModel #bsc = (GridLineDefinitionModel)#Rf;
			if (!false)
			{
				#V0c.#JZc(#bsc);
			}
		}

		// Token: 0x06006299 RID: 25241 RVA: 0x0005067A File Offset: 0x0004E87A
		public override bool #sLc(object #Rf)
		{
			return #Rf != null && #Rf is GridLineDefinitionModel;
		}

		// Token: 0x02000BC4 RID: 3012
		[CompilerGenerated]
		private sealed class #v0b
		{
			// Token: 0x0600629B RID: 25243 RVA: 0x001811E0 File Offset: 0x0017F3E0
			internal bool #w9c(GridLineDefinitionModel #qoc)
			{
				while (2 != 0)
				{
					bool result;
					bool flag = result = this.#b.#Lnc(#qoc.GridLineData.LineSegment.StartPoint);
					if (!false)
					{
						if (!flag)
						{
							break;
						}
						if (4 == 0)
						{
							continue;
						}
						result = this.#b.#Lnc(#qoc.GridLineData.LineSegment.EndPoint);
					}
					return result;
				}
				return false;
			}

			// Token: 0x04002880 RID: 10368
			public #yLc #a;

			// Token: 0x04002881 RID: 10369
			public PolygonData #b;
		}

		// Token: 0x02000BC5 RID: 3013
		[CompilerGenerated]
		private sealed class #A9c
		{
			// Token: 0x0600629D RID: 25245 RVA: 0x00181230 File Offset: 0x0017F430
			internal bool #x9c(GridLineDefinitionModel #Rf)
			{
				double? num = #jsc.#lcb(#Rf.GridLineData.LineSegment, this.#a);
				double? num2;
				if (6 != 0)
				{
					num2 = num;
				}
				double num3 = this.#b.#a.SnappingProvider.MaxDistance;
				double num4;
				if (2 != 0)
				{
					num4 = num3;
				}
				bool flag = num2.GetValueOrDefault() < num4;
				bool result;
				do
				{
					result = (flag &= (num2 != null));
				}
				while (false || false);
				return result;
			}

			// Token: 0x0600629E RID: 25246 RVA: 0x00181290 File Offset: 0x0017F490
			internal GridLineDefinitionModel #y9c(GridLineDefinitionModel #Yxc, GridLineDefinitionModel #z9c)
			{
				double? num = #jsc.#lcb(#Yxc.GridLineData.LineSegment, this.#a);
				double? num2;
				if (!false)
				{
					num2 = num;
				}
				do
				{
					double? num3 = #jsc.#lcb(#z9c.GridLineData.LineSegment, this.#a);
					double? num4;
					if (!false)
					{
						num4 = num3;
					}
					if (!false && (num2.GetValueOrDefault() < num4.GetValueOrDefault() & (num2 != null & num4 != null)) && 3 != 0)
					{
						return #Yxc;
					}
				}
				while (false);
				return #z9c;
			}

			// Token: 0x04002882 RID: 10370
			public Point #a;

			// Token: 0x04002883 RID: 10371
			public #yLc.#v0b #b;
		}
	}
}
