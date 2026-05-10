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
	// Token: 0x02000BCF RID: 3023
	internal sealed class #TLc : #OLc, IEntitiesSelector, #CLc
	{
		// Token: 0x060062C1 RID: 25281 RVA: 0x000504E8 File Offset: 0x0004E6E8
		public #TLc(#oW #Yc, #V0c #uLc, #Qrc #NDc, #GLc #vLc) : base(#Yc, #uLc, #NDc, #vLc)
		{
		}

		// Token: 0x060062C2 RID: 25282 RVA: 0x00181550 File Offset: 0x0017F750
		public override IReadOnlyList<object> #wLc(bool #xLc, Point3D? #Xrb, Point3D #Yrb)
		{
			#TLc.#v0b #v0b2;
			List<object> list2;
			if (!false)
			{
				#TLc.#v0b #v0b = new #TLc.#v0b();
				if (!false)
				{
					#v0b2 = #v0b;
				}
				List<object> list = new List<object>();
				if (!false)
				{
					list2 = list;
				}
				#v0b2.#a = base.#LLc(#xLc, #Xrb, #Yrb);
			}
			if (#v0b2.#a != null)
			{
				List<object> list3 = list2;
				IEnumerable<object> collection = base.ProjectContext.MainModel.Shapes.Where(new Func<ShapeDataModel, bool>(#v0b2.#w9c));
				if (!false)
				{
					list3.AddRange(collection);
				}
			}
			else
			{
				#TLc.#A9c #A9c = new #TLc.#A9c();
				#TLc.#A9c #A9c2;
				if (2 != 0)
				{
					#A9c2 = #A9c;
				}
				#A9c2.#a = PointsConverter.#vsc(#Yrb);
				if (!false)
				{
					List<object> list4 = list2;
					IEnumerable<object> collection2 = base.ProjectContext.MainModel.Shapes.Where(new Func<ShapeDataModel, bool>(#A9c2.#x9c));
					if (8 != 0)
					{
						list4.AddRange(collection2);
					}
				}
			}
			return list2;
		}

		// Token: 0x060062C3 RID: 25283 RVA: 0x000508C0 File Offset: 0x0004EAC0
		public override IReadOnlyList<object> #qLc()
		{
			return base.ProjectContext.MainModel.Shapes.ToList<ShapeDataModel>().AsReadOnly();
		}

		// Token: 0x060062C4 RID: 25284 RVA: 0x0005051D File Offset: 0x0004E71D
		public override void #uR(IEnumerable<object> #8f)
		{
			#V0c #V0c = base.ModelEditorViewModel;
			IEnumerable<ShapeDataModel> #rP = #8f.Cast<ShapeDataModel>();
			if (!false)
			{
				#V0c.#0Zc(#rP);
			}
		}

		// Token: 0x060062C5 RID: 25285 RVA: 0x00050537 File Offset: 0x0004E737
		public override void #ljb(object #Rf)
		{
			#V0c #V0c = base.ModelEditorViewModel;
			ShapeDataModel #XDc = (ShapeDataModel)#Rf;
			if (!false)
			{
				#V0c.#1Zc(#XDc);
			}
		}

		// Token: 0x060062C6 RID: 25286 RVA: 0x00050551 File Offset: 0x0004E751
		public override void #rLc(IEnumerable<object> #8f)
		{
			#V0c #V0c = base.ModelEditorViewModel;
			IEnumerable<ShapeDataModel> #6Y = #8f.Cast<ShapeDataModel>();
			if (!false)
			{
				#V0c.#4Zc(#6Y);
			}
		}

		// Token: 0x060062C7 RID: 25287 RVA: 0x0005056B File Offset: 0x0004E76B
		public override void #rLc(object #Rf)
		{
			#V0c #V0c = base.ModelEditorViewModel;
			ShapeDataModel #XDc = (ShapeDataModel)#Rf;
			if (!false)
			{
				#V0c.#5Zc(#XDc);
			}
		}

		// Token: 0x060062C8 RID: 25288 RVA: 0x00050585 File Offset: 0x0004E785
		public override bool #sLc(object #Rf)
		{
			return #Rf != null && #Rf is ShapeDataModel;
		}

		// Token: 0x02000BD0 RID: 3024
		[CompilerGenerated]
		private sealed class #v0b
		{
			// Token: 0x060062CA RID: 25290 RVA: 0x000508DC File Offset: 0x0004EADC
			internal bool #w9c(ShapeDataModel #Rf)
			{
				return GeometryHelper.#WHb(#Rf, this.#a);
			}

			// Token: 0x0400288D RID: 10381
			public PolygonData #a;
		}

		// Token: 0x02000BD1 RID: 3025
		[CompilerGenerated]
		private sealed class #A9c
		{
			// Token: 0x060062CC RID: 25292 RVA: 0x000508EA File Offset: 0x0004EAEA
			internal bool #x9c(ShapeDataModel #Rf)
			{
				return GeometryHelper.#WHb(#Rf, this.#a);
			}

			// Token: 0x0400288E RID: 10382
			public Point #a;
		}
	}
}
