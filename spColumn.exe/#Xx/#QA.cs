using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #6re;
using #eU;
using #kB;
using #qJ;
using #wqe;
using #Wse;
using StructurePoint.CoreAssets.AppManager.Column.Core;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Documents;
using StructurePoint.CoreAssets.AppManager.Column.Reporting.Model;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Services.API;

namespace #Xx
{
	// Token: 0x020001D1 RID: 465
	internal sealed class #QA : #lB
	{
		// Token: 0x0600104B RID: 4171 RVA: 0x000A6444 File Offset: 0x000A4644
		public #QA(#rW #Hj, #oW #Yc, #qW #rj, ISettingsManager #ng, #yse #tA, #9V #RA)
		{
			this.#a = #Hj;
			this.#b = #Yc;
			this.#c = #rj;
			this.#d = #ng;
			this.#e = #tA;
			this.#f = #RA;
		}

		// Token: 0x17000629 RID: 1577
		// (get) Token: 0x0600104C RID: 4172 RVA: 0x000128DE File Offset: 0x00010ADE
		public IList<ReporterImage> Screenshots { get; }

		// Token: 0x1700062A RID: 1578
		// (get) Token: 0x0600104D RID: 4173 RVA: 0x000128EA File Offset: 0x00010AEA
		public List<SolverMessage> SolverMessages { get; }

		// Token: 0x0600104E RID: 4174 RVA: 0x000128F6 File Offset: 0x00010AF6
		public #lte #LA(ColumnStorageModel #Od, bool #MA)
		{
			return this.#PA(false, #Od, #MA);
		}

		// Token: 0x0600104F RID: 4175 RVA: 0x000A649C File Offset: 0x000A469C
		public #lte #LA(bool #NA, bool #MA = true)
		{
			ColumnStorageModel #Od = this.#f.#Pb(this.#b.Model);
			return this.#PA(#NA, #Od, #MA);
		}

		// Token: 0x06001050 RID: 4176 RVA: 0x000A64D8 File Offset: 0x000A46D8
		public GeneralInformation #OA()
		{
			#dQ #dQ = this.#a.ApplicationData;
			return new GeneralInformation
			{
				LicenseeName = #dQ.LicensedTo,
				LockingCode = #dQ.LockingCode,
				ProductAndVersion = ColumnGlobalInfo.LongName + this.#Fj(),
				LicenseId = #dQ.LicenseId,
				FileName = (string.IsNullOrWhiteSpace(this.#b.LoadedFilePath) ? Strings.StringUntitled : this.#b.LoadedFilePath),
				IsTrial = #dQ.IsTrial
			};
		}

		// Token: 0x06001051 RID: 4177 RVA: 0x000A6584 File Offset: 0x000A4784
		public #lte #1Th(ColumnStorageModel #Od, bool #MA)
		{
			#Uqe #Uqe = new #Uqe(this.#e, this.#OA());
			#Hqe #Pc = new #Hqe(#Od, this.#c.DesignEngine, this.#a.DocumentOptions)
			{
				CreateDiagrams = #MA,
				UserImages = this.Screenshots.ToList<ReporterImage>()
			};
			#lte #lte = #Uqe.#ul(#Pc);
			this.#d.CurrentColorSettings.#oRb(#lte.ColorSettings);
			#lte.SolverMessages.AddRange(this.SolverMessages);
			ColumnDocumentContentOptionsHelper columnDocumentContentOptionsHelper = new ColumnDocumentContentOptionsHelper(this.#a.DocumentOptions, #lte);
			columnDocumentContentOptionsHelper.#iwe();
			return #lte;
		}

		// Token: 0x06001052 RID: 4178 RVA: 0x0001290D File Offset: 0x00010B0D
		public #lte #1Th(bool #MA)
		{
			return this.#1Th(this.#b.Model.#CY(), #MA);
		}

		// Token: 0x06001053 RID: 4179 RVA: 0x000A6640 File Offset: 0x000A4840
		private #lte #PA(bool #NA, ColumnStorageModel #Od, bool #MA)
		{
			#lte result = this.#1Th(#Od, #MA);
			this.#a.Model = result;
			this.#a.ResultsParameters.UpdateOnly = #NA;
			this.#a.ReporterParameters.UpdateOnly = #NA;
			return result;
		}

		// Token: 0x06001054 RID: 4180 RVA: 0x0000A36A File Offset: 0x0000856A
		private string #Fj()
		{
			return string.Empty;
		}

		// Token: 0x04000660 RID: 1632
		private readonly #rW #a;

		// Token: 0x04000661 RID: 1633
		private readonly #oW #b;

		// Token: 0x04000662 RID: 1634
		private readonly #qW #c;

		// Token: 0x04000663 RID: 1635
		private readonly ISettingsManager #d;

		// Token: 0x04000664 RID: 1636
		private readonly #yse #e;

		// Token: 0x04000665 RID: 1637
		private readonly #9V #f;

		// Token: 0x04000666 RID: 1638
		[CompilerGenerated]
		private readonly IList<ReporterImage> #g = new List<ReporterImage>();

		// Token: 0x04000667 RID: 1639
		[CompilerGenerated]
		private readonly List<SolverMessage> #h = new List<SolverMessage>();
	}
}
