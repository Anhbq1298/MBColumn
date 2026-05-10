using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #Fmc;
using #NWc;
using #T0c;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.GUI.Framework.Tools.Selection;

namespace #hLc
{
	// Token: 0x02000BC1 RID: 3009
	internal abstract class #tLc : #OLc, IEntitiesSelector, #pLc
	{
		// Token: 0x06006272 RID: 25202 RVA: 0x000504E8 File Offset: 0x0004E6E8
		protected #tLc(#oW #Yc, #V0c #uLc, #Qrc #NDc, #GLc #vLc) : base(#Yc, #uLc, #NDc, #vLc)
		{
		}

		// Token: 0x17001BEB RID: 7147
		// (get) Token: 0x06006273 RID: 25203 RVA: 0x000504F5 File Offset: 0x0004E6F5
		// (set) Token: 0x06006274 RID: 25204 RVA: 0x000504FD File Offset: 0x0004E6FD
		public bool SelectOnlyExistingShapes { get; set; }

		// Token: 0x06006275 RID: 25205 RVA: 0x00050506 File Offset: 0x0004E706
		public override IReadOnlyList<object> #qLc()
		{
			return base.ProjectContext.MainModel.Shapes.ToList<ShapeDataModel>();
		}

		// Token: 0x06006276 RID: 25206 RVA: 0x0005051D File Offset: 0x0004E71D
		public override void #uR(IEnumerable<object> #8f)
		{
			#V0c #V0c = base.ModelEditorViewModel;
			IEnumerable<ShapeDataModel> #rP = #8f.Cast<ShapeDataModel>();
			if (!false)
			{
				#V0c.#0Zc(#rP);
			}
		}

		// Token: 0x06006277 RID: 25207 RVA: 0x00050537 File Offset: 0x0004E737
		public override void #ljb(object #Rf)
		{
			#V0c #V0c = base.ModelEditorViewModel;
			ShapeDataModel #XDc = (ShapeDataModel)#Rf;
			if (!false)
			{
				#V0c.#1Zc(#XDc);
			}
		}

		// Token: 0x06006278 RID: 25208 RVA: 0x00050551 File Offset: 0x0004E751
		public override void #rLc(IEnumerable<object> #8f)
		{
			#V0c #V0c = base.ModelEditorViewModel;
			IEnumerable<ShapeDataModel> #6Y = #8f.Cast<ShapeDataModel>();
			if (!false)
			{
				#V0c.#4Zc(#6Y);
			}
		}

		// Token: 0x06006279 RID: 25209 RVA: 0x0005056B File Offset: 0x0004E76B
		public override void #rLc(object #Rf)
		{
			#V0c #V0c = base.ModelEditorViewModel;
			ShapeDataModel #XDc = (ShapeDataModel)#Rf;
			if (!false)
			{
				#V0c.#5Zc(#XDc);
			}
		}

		// Token: 0x0600627A RID: 25210 RVA: 0x00050585 File Offset: 0x0004E785
		public override bool #sLc(object #Rf)
		{
			return #Rf != null && #Rf is ShapeDataModel;
		}

		// Token: 0x04002879 RID: 10361
		[CompilerGenerated]
		private bool #a;
	}
}
