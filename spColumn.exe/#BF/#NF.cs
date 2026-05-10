using System;
using System.Collections.Generic;
using #0I;
using #5Z;
using #7hc;
using #Bc;
using #WG;
using #WI;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.Core;

namespace #BF
{
	// Token: 0x02000257 RID: 599
	internal sealed class #NF : ViewModelWithRowsBase<#TF, #Cc>, #VI, #5I, #ZI, #ZG
	{
		// Token: 0x060013E1 RID: 5089 RVA: 0x00015370 File Offset: 0x00013570
		public #NF(Lazy<#Cc> #Ee, ICoreServices #0c) : base(#Ee, #0c)
		{
		}

		// Token: 0x17000723 RID: 1827
		// (get) Token: 0x060013E2 RID: 5090 RVA: 0x0001537A File Offset: 0x0001357A
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x060013E3 RID: 5091 RVA: 0x0001538A File Offset: 0x0001358A
		public void #2B()
		{
			this.#vh();
			base.RaisePropertyChanged(#Phc.#3hc(107408668));
		}

		// Token: 0x060013E4 RID: 5092 RVA: 0x000153AE File Offset: 0x000135AE
		public void #3B()
		{
			this.#tI();
			base.View.ClearIsCurrent();
		}

		// Token: 0x060013E5 RID: 5093 RVA: 0x000AF270 File Offset: 0x000AD470
		public override void UpdateFromModel(ColumnModel model)
		{
			IEnumerable<#TF> #8f = this.#KF(model.SustainedLoadFactors);
			base.Items.Clear();
			base.Items.#pR(#8f);
		}

		// Token: 0x060013E6 RID: 5094 RVA: 0x000153CD File Offset: 0x000135CD
		public override void UpdateModel(ColumnModel model)
		{
			this.#MF(base.Items, model.SustainedLoadFactors);
		}

		// Token: 0x17000724 RID: 1828
		// (get) Token: 0x060013E7 RID: 5095 RVA: 0x000153ED File Offset: 0x000135ED
		public bool IsSustainedLoadColumnActive
		{
			get
			{
				return base.Project.Model.Options.ConsiderSlenderness;
			}
		}

		// Token: 0x060013E8 RID: 5096 RVA: 0x000AF2B0 File Offset: 0x000AD4B0
		private IEnumerable<#TF> #KF(#Y3 #LF)
		{
			return new List<#TF>
			{
				new #TF
				{
					Case = #Phc.#3hc(107408119),
					Type = Strings.StringDead,
					SustainedFactor = new #v0(#LF.Dead)
				},
				new #TF
				{
					Case = #Phc.#3hc(107408114),
					Type = Strings.StringLive,
					SustainedFactor = new #v0(#LF.Live)
				},
				new #TF
				{
					Case = #Phc.#3hc(107408077),
					Type = Strings.StringWind,
					SustainedFactor = new #v0(#LF.Wind)
				},
				new #TF
				{
					Case = #Phc.#3hc(107395517),
					Type = Strings.StringEq,
					SustainedFactor = new #v0(#LF.Earthquake)
				},
				new #TF
				{
					Case = #Phc.#3hc(107386851),
					Type = Strings.StringSnow,
					SustainedFactor = new #v0(#LF.Snow)
				}
			};
		}

		// Token: 0x060013E9 RID: 5097 RVA: 0x000AF3F4 File Offset: 0x000AD5F4
		private void #MF(IList<#TF> #Qb, #Y3 #LF)
		{
			if (#Qb.Count != 5)
			{
				return;
			}
			#LF.Dead = #Qb[0].SustainedFactor.Value;
			#LF.Live = #Qb[1].SustainedFactor.Value;
			#LF.Wind = #Qb[2].SustainedFactor.Value;
			#LF.Earthquake = #Qb[3].SustainedFactor.Value;
			#LF.Snow = #Qb[4].SustainedFactor.Value;
		}

		// Token: 0x060013EA RID: 5098 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.#Lr()
		{
			base.ClearErrors();
		}

		// Token: 0x060013EB RID: 5099 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.#Or(string #em)
		{
			base.RemoveError(#em);
		}

		// Token: 0x04000823 RID: 2083
		private const int #a = 5;
	}
}
