using System;
using System.Collections.Generic;
using System.Linq;
using #Fmc;
using #NWc;
using #T0c;
using StructurePoint.CoreAssets.GUI.Framework.Model.Entities;
using StructurePoint.CoreAssets.GUI.Framework.Tools.Selection;
using StructurePoint.CoreAssets.Infrastructure.Data;

namespace #hLc
{
	// Token: 0x02000BCA RID: 3018
	internal sealed class #DLc : #OLc, IEntitiesSelector, #ALc
	{
		// Token: 0x0600629F RID: 25247 RVA: 0x000504E8 File Offset: 0x0004E6E8
		public #DLc(#oW #Yc, #V0c #uLc, #Qrc #NDc, #GLc #vLc) : base(#Yc, #uLc, #NDc, #vLc)
		{
		}

		// Token: 0x060062A0 RID: 25248 RVA: 0x0002FF35 File Offset: 0x0002E135
		public override IReadOnlyList<object> #wLc(bool #xLc, Point3D? #Xrb, Point3D #Yrb)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060062A1 RID: 25249 RVA: 0x0005068A File Offset: 0x0004E88A
		public override IReadOnlyList<object> #qLc()
		{
			return base.ProjectContext.MainModel.LinearObjects.ToList<LinearObject>().AsReadOnly();
		}

		// Token: 0x060062A2 RID: 25250 RVA: 0x000506A6 File Offset: 0x0004E8A6
		public override void #uR(IEnumerable<object> #8f)
		{
			#V0c #V0c = base.ModelEditorViewModel;
			IEnumerable<LinearObject> #iEc = #8f.Cast<LinearObject>();
			if (!false)
			{
				#V0c.#i0c(#iEc);
			}
		}

		// Token: 0x060062A3 RID: 25251 RVA: 0x000506C0 File Offset: 0x0004E8C0
		public override void #ljb(object #Rf)
		{
			#V0c #V0c = base.ModelEditorViewModel;
			LinearObject #NNc = (LinearObject)#Rf;
			if (!false)
			{
				#V0c.#f0c(#NNc);
			}
		}

		// Token: 0x060062A4 RID: 25252 RVA: 0x000506DA File Offset: 0x0004E8DA
		public override void #rLc(IEnumerable<object> #8f)
		{
			#V0c #V0c = base.ModelEditorViewModel;
			IEnumerable<LinearObject> #iEc = #8f.Cast<LinearObject>();
			if (!false)
			{
				#V0c.#h0c(#iEc);
			}
		}

		// Token: 0x060062A5 RID: 25253 RVA: 0x000506F4 File Offset: 0x0004E8F4
		public override void #rLc(object #Rf)
		{
			#V0c #V0c = base.ModelEditorViewModel;
			LinearObject #NNc = (LinearObject)#Rf;
			if (!false)
			{
				#V0c.#g0c(#NNc);
			}
		}

		// Token: 0x060062A6 RID: 25254 RVA: 0x0005070E File Offset: 0x0004E90E
		public override bool #sLc(object #Rf)
		{
			return #Rf != null && #Rf is LinearObject;
		}
	}
}
