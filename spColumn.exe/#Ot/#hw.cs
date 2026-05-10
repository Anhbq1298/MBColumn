using System;
using #0I;
using #7hc;
using #Lx;
using #pc;
using #wQb;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;

namespace #Ot
{
	// Token: 0x02000187 RID: 391
	internal sealed class #hw : #ex<#vc>, #5I, IPanel, IChangesInfo, #Rx
	{
		// Token: 0x06000CD4 RID: 3284 RVA: 0x0000FEC5 File Offset: 0x0000E0C5
		public #hw(Lazy<#vc> #Ee, ICoreServices #0c, ISettingsManager #iw) : base(#Ee, #0c)
		{
			this.#a = #iw;
		}

		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x06000CD5 RID: 3285 RVA: 0x0000FED6 File Offset: 0x0000E0D6
		// (set) Token: 0x06000CD6 RID: 3286 RVA: 0x0000FEE2 File Offset: 0x0000E0E2
		public bool ShowCoordinateSystemSign
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<bool>(ref this.#b, value, #Phc.#3hc(107410134));
			}
		}

		// Token: 0x17000524 RID: 1316
		// (get) Token: 0x06000CD7 RID: 3287 RVA: 0x0000FF08 File Offset: 0x0000E108
		// (set) Token: 0x06000CD8 RID: 3288 RVA: 0x0000FF14 File Offset: 0x0000E114
		public bool ObjectCentroid
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.SetProperty<bool>(ref this.#c, value, #Phc.#3hc(107410101));
			}
		}

		// Token: 0x17000525 RID: 1317
		// (get) Token: 0x06000CD9 RID: 3289 RVA: 0x0000FF3A File Offset: 0x0000E13A
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06000CDA RID: 3290 RVA: 0x0009CEE8 File Offset: 0x0009B0E8
		public bool GetHasChanges()
		{
			ISettingsManager settingsManager = this.#a;
			return this.ShowCoordinateSystemSign != settingsManager.ShowCoordinateSystemSign || this.ObjectCentroid != settingsManager.ObjectCentroid;
		}

		// Token: 0x06000CDB RID: 3291 RVA: 0x0000FF4A File Offset: 0x0000E14A
		public override void UpdateFromModel(ColumnModel model)
		{
			this.#b = this.#a.ShowCoordinateSystemSign;
			this.#c = this.#a.ObjectCentroid;
			this.RefreshAllProperties();
		}

		// Token: 0x06000CDC RID: 3292 RVA: 0x0000FF80 File Offset: 0x0000E180
		public override void UpdateModel(ColumnModel model)
		{
			this.#a.ShowCoordinateSystemSign = this.#b;
			this.#a.ObjectCentroid = this.#c;
		}

		// Token: 0x06000CDD RID: 3293 RVA: 0x0000FFB0 File Offset: 0x0000E1B0
		public override void #qt()
		{
			this.#b = #VQb.#W;
			this.#c = #VQb.#X;
			this.RefreshAllProperties();
		}

		// Token: 0x06000CDE RID: 3294 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.#Lr()
		{
			base.ClearErrors();
		}

		// Token: 0x06000CDF RID: 3295 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.#Or(string #em)
		{
			base.RemoveError(#em);
		}

		// Token: 0x040004C1 RID: 1217
		private readonly ISettingsManager #a;

		// Token: 0x040004C2 RID: 1218
		private bool #b;

		// Token: 0x040004C3 RID: 1219
		private bool #c;
	}
}
