using System;
using System.ComponentModel;
using #0I;
using #lH;
using #npe;
using #Zb;
using StructurePoint.CoreAssets.Column.Core.Core.App;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;

namespace #WB
{
	// Token: 0x020001E0 RID: 480
	internal sealed class #9Th : #HH<#cSh>, INotifyPropertyChanged, IViewModel<#cSh>, #5I, IViewModel, #8Th
	{
		// Token: 0x060010A3 RID: 4259 RVA: 0x00012CB1 File Offset: 0x00010EB1
		public #9Th(Lazy<#cSh> #Ee, ICoreServices #0c) : base(#Ee, #0c)
		{
		}

		// Token: 0x1700063D RID: 1597
		// (get) Token: 0x060010A4 RID: 4260 RVA: 0x00012CBB File Offset: 0x00010EBB
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x060010A5 RID: 4261 RVA: 0x00012CCB File Offset: 0x00010ECB
		public override void UpdateModel(ColumnModel model)
		{
			base.UpdateModel(model);
			model.#HY(#ope.#e);
		}

		// Token: 0x060010A6 RID: 4262 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.#Lr()
		{
			base.ClearErrors();
		}

		// Token: 0x060010A7 RID: 4263 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.#Or(string #em)
		{
			base.RemoveError(#em);
		}
	}
}
