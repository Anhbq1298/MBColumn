using System;
using System.Runtime.CompilerServices;
using System.Windows;
using #7hc;
using #eU;
using #oKe;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;
using StructurePoint.Products.Column.Model;

namespace #7Pb
{
	// Token: 0x020006B5 RID: 1717
	internal sealed class #cQb : #gQb
	{
		// Token: 0x0600391A RID: 14618 RVA: 0x00111280 File Offset: 0x0010F480
		internal #cQb(#oW #xn, #nKe #JF) : base(#Phc.#3hc(107351322), Visibility.Visible)
		{
			this.#a = #xn;
			this.#b = #JF;
			base.Values.#pR(new #nQb[]
			{
				#nQb.Separator,
				this.DesignCode,
				#nQb.Separator,
				this.RunAxis,
				#nQb.Separator,
				this.ProblemType,
				#nQb.Separator,
				this.LoadType
			});
			base.#fQb();
		}

		// Token: 0x1700118D RID: 4493
		// (get) Token: 0x0600391B RID: 14619 RVA: 0x000319E3 File Offset: 0x0002FBE3
		public #nQb DesignCode { get; }

		// Token: 0x1700118E RID: 4494
		// (get) Token: 0x0600391C RID: 14620 RVA: 0x000319EF File Offset: 0x0002FBEF
		public #nQb RunAxis { get; }

		// Token: 0x1700118F RID: 4495
		// (get) Token: 0x0600391D RID: 14621 RVA: 0x000319FB File Offset: 0x0002FBFB
		public #nQb ProblemType { get; }

		// Token: 0x17001190 RID: 4496
		// (get) Token: 0x0600391E RID: 14622 RVA: 0x00031A07 File Offset: 0x0002FC07
		public #nQb LoadType { get; }

		// Token: 0x0600391F RID: 14623 RVA: 0x00111334 File Offset: 0x0010F534
		public void #uP()
		{
			ColumnModel columnModel = this.#a.Model;
			this.DesignCode.Value = this.#b.AvailableDesignCodes.#F1d(columnModel.Options.Code);
			this.ProblemType.Value = ((columnModel.Options.ProblemType == StructurePoint.CoreAssets.AppManager.Column.StorageModel.ProblemType.Design) ? Strings.StringDesign : Strings.StringInvestigation);
			this.RunAxis.Value = this.#aQb(columnModel.Options.ConsideredAxis);
			this.LoadType.Value = this.#bQb();
		}

		// Token: 0x06003920 RID: 14624 RVA: 0x001113E4 File Offset: 0x0010F5E4
		private string #aQb(ConsideredAxis #6gb)
		{
			string result;
			if (!this.#b.AvailableConsideredAxes.TryGetValue(#6gb, out result))
			{
				return string.Empty;
			}
			return result;
		}

		// Token: 0x06003921 RID: 14625 RVA: 0x0011141C File Offset: 0x0010F61C
		private string #bQb()
		{
			ColumnModel columnModel = this.#a.Model;
			ProblemType problemType = columnModel.Options.ProblemType;
			LoadType key = (problemType == StructurePoint.CoreAssets.AppManager.Column.StorageModel.ProblemType.Design) ? columnModel.Options.DesignLoad : columnModel.Options.InvestigationLoad;
			string result;
			if (!this.#b.AvailableLoadTypes.TryGetValue(key, out result))
			{
				return string.Empty;
			}
			return result;
		}

		// Token: 0x040017FF RID: 6143
		private readonly #oW #a;

		// Token: 0x04001800 RID: 6144
		private readonly #nKe #b;

		// Token: 0x04001801 RID: 6145
		[CompilerGenerated]
		private readonly #nQb #c = new #nQb();

		// Token: 0x04001802 RID: 6146
		[CompilerGenerated]
		private readonly #nQb #d = new #nQb();

		// Token: 0x04001803 RID: 6147
		[CompilerGenerated]
		private readonly #nQb #e = new #nQb();

		// Token: 0x04001804 RID: 6148
		[CompilerGenerated]
		private readonly #nQb #f = new #nQb();
	}
}
