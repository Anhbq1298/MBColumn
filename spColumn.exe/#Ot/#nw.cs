using System;
using #0I;
using #3Qb;
using #7hc;
using #Lx;
using #pc;
using StructurePoint.Products.Column.Model;
using StructurePoint.Products.Column.Services.API;
using StructurePoint.Products.Column.ViewModels.API.Core;

namespace #Ot
{
	// Token: 0x02000189 RID: 393
	internal sealed class #nw : #ex<#wc>, #5I, IPanel, IChangesInfo, #Tx
	{
		// Token: 0x06000CE0 RID: 3296 RVA: 0x0000FFDA File Offset: 0x0000E1DA
		public #nw(Lazy<#wc> #Ee, ICoreServices #0c) : base(#Ee, #0c)
		{
		}

		// Token: 0x17000526 RID: 1318
		// (get) Token: 0x06000CE1 RID: 3297 RVA: 0x0000FFE4 File Offset: 0x0000E1E4
		// (set) Token: 0x06000CE2 RID: 3298 RVA: 0x0000FFF0 File Offset: 0x0000E1F0
		public bool GenerateTextResults
		{
			get
			{
				return this.#a;
			}
			set
			{
				this.SetProperty<bool>(ref this.#a, value, #Phc.#3hc(107410048));
			}
		}

		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x06000CE3 RID: 3299 RVA: 0x00010016 File Offset: 0x0000E216
		// (set) Token: 0x06000CE4 RID: 3300 RVA: 0x00010022 File Offset: 0x0000E222
		public bool HighlightCriticalPoints
		{
			get
			{
				return this.#b;
			}
			set
			{
				this.SetProperty<bool>(ref this.#b, value, #Phc.#3hc(107410019));
			}
		}

		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x06000CE5 RID: 3301 RVA: 0x00010048 File Offset: 0x0000E248
		// (set) Token: 0x06000CE6 RID: 3302 RVA: 0x00010054 File Offset: 0x0000E254
		public bool ReorderSolidsAndOpeningLabelsBeforeSolve
		{
			get
			{
				return this.#c;
			}
			set
			{
				this.SetProperty<bool>(ref this.#c, value, #Phc.#3hc(107409986));
			}
		}

		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x06000CE7 RID: 3303 RVA: 0x0001007A File Offset: 0x0000E27A
		public override bool HasErrors
		{
			get
			{
				return base.HasErrors;
			}
		}

		// Token: 0x06000CE8 RID: 3304 RVA: 0x0009CF2C File Offset: 0x0009B12C
		public bool GetHasChanges()
		{
			#2Qb #2Qb = base.Services.Settings.#XN();
			return this.GenerateTextResults != #2Qb.AutomaticallyGenerateTextResultsFile || this.HighlightCriticalPoints != #2Qb.HighlightCriticalLoadPoints || this.ReorderSolidsAndOpeningLabelsBeforeSolve != #2Qb.ReorderSolidAndOpeningLabelsBeforeSolve;
		}

		// Token: 0x06000CE9 RID: 3305 RVA: 0x0009CF88 File Offset: 0x0009B188
		public override void UpdateFromModel(ColumnModel model)
		{
			#2Qb #2Qb = base.Services.Settings.#XN();
			this.GenerateTextResults = #2Qb.AutomaticallyGenerateTextResultsFile;
			this.HighlightCriticalPoints = #2Qb.HighlightCriticalLoadPoints;
			this.ReorderSolidsAndOpeningLabelsBeforeSolve = #2Qb.ReorderSolidAndOpeningLabelsBeforeSolve;
		}

		// Token: 0x06000CEA RID: 3306 RVA: 0x0009CFD8 File Offset: 0x0009B1D8
		public override void UpdateModel(ColumnModel model)
		{
			#2Qb #ng = new #2Qb
			{
				AutomaticallyGenerateTextResultsFile = this.GenerateTextResults,
				HighlightCriticalLoadPoints = this.HighlightCriticalPoints,
				ReorderSolidAndOpeningLabelsBeforeSolve = this.ReorderSolidsAndOpeningLabelsBeforeSolve
			};
			base.Services.Settings.#YN(#ng);
		}

		// Token: 0x06000CEB RID: 3307 RVA: 0x0009D02C File Offset: 0x0009B22C
		public override void #qt()
		{
			#2Qb #2Qb = #2Qb.Default;
			this.GenerateTextResults = #2Qb.AutomaticallyGenerateTextResultsFile;
			this.HighlightCriticalPoints = #2Qb.HighlightCriticalLoadPoints;
			this.ReorderSolidsAndOpeningLabelsBeforeSolve = #2Qb.ReorderSolidAndOpeningLabelsBeforeSolve;
		}

		// Token: 0x06000CEC RID: 3308 RVA: 0x0000A950 File Offset: 0x00008B50
		void #5I.#Lr()
		{
			base.ClearErrors();
		}

		// Token: 0x06000CED RID: 3309 RVA: 0x0000A960 File Offset: 0x00008B60
		void #5I.#Or(string #em)
		{
			base.RemoveError(#em);
		}

		// Token: 0x040004C4 RID: 1220
		private bool #a;

		// Token: 0x040004C5 RID: 1221
		private bool #b;

		// Token: 0x040004C6 RID: 1222
		private bool #c;
	}
}
