using System;
using System.Runtime.CompilerServices;
using #Gke;
using StructurePoint.CoreAssets.AppManager.Column.StorageModel.Entities;

namespace #z5e
{
	// Token: 0x02001368 RID: 4968
	internal sealed class #K2
	{
		// Token: 0x0600A6CE RID: 42702 RVA: 0x00081C78 File Offset: 0x0007FE78
		internal #K2(#Jle #L0)
		{
			this.#mg(#L0);
		}

		// Token: 0x0600A6CF RID: 42703 RVA: 0x00081C87 File Offset: 0x0007FE87
		internal #K2(MaterialProperties #L0)
		{
			this.#mg(#L0);
		}

		// Token: 0x17003055 RID: 12373
		// (get) Token: 0x0600A6D0 RID: 42704 RVA: 0x00081C96 File Offset: 0x0007FE96
		// (set) Token: 0x0600A6D1 RID: 42705 RVA: 0x00081C9E File Offset: 0x0007FE9E
		public bool IsConcreteStandard { get; private set; }

		// Token: 0x17003056 RID: 12374
		// (get) Token: 0x0600A6D2 RID: 42706 RVA: 0x00081CA7 File Offset: 0x0007FEA7
		// (set) Token: 0x0600A6D3 RID: 42707 RVA: 0x00081CAF File Offset: 0x0007FEAF
		public bool IsSteelStandard { get; private set; }

		// Token: 0x17003057 RID: 12375
		// (get) Token: 0x0600A6D4 RID: 42708 RVA: 0x00081CB8 File Offset: 0x0007FEB8
		// (set) Token: 0x0600A6D5 RID: 42709 RVA: 0x00081CC0 File Offset: 0x0007FEC0
		public float Eyt { get; private set; }

		// Token: 0x17003058 RID: 12376
		// (get) Token: 0x0600A6D6 RID: 42710 RVA: 0x00081CC9 File Offset: 0x0007FEC9
		// (set) Token: 0x0600A6D7 RID: 42711 RVA: 0x00081CD1 File Offset: 0x0007FED1
		public float Fcp { get; private set; }

		// Token: 0x17003059 RID: 12377
		// (get) Token: 0x0600A6D8 RID: 42712 RVA: 0x00081CDA File Offset: 0x0007FEDA
		// (set) Token: 0x0600A6D9 RID: 42713 RVA: 0x00081CE2 File Offset: 0x0007FEE2
		public float Ec { get; private set; }

		// Token: 0x1700305A RID: 12378
		// (get) Token: 0x0600A6DA RID: 42714 RVA: 0x00081CEB File Offset: 0x0007FEEB
		// (set) Token: 0x0600A6DB RID: 42715 RVA: 0x00081CF3 File Offset: 0x0007FEF3
		public float Fc { get; private set; }

		// Token: 0x1700305B RID: 12379
		// (get) Token: 0x0600A6DC RID: 42716 RVA: 0x00081CFC File Offset: 0x0007FEFC
		// (set) Token: 0x0600A6DD RID: 42717 RVA: 0x00081D04 File Offset: 0x0007FF04
		public float Beta1 { get; private set; }

		// Token: 0x1700305C RID: 12380
		// (get) Token: 0x0600A6DE RID: 42718 RVA: 0x00081D0D File Offset: 0x0007FF0D
		// (set) Token: 0x0600A6DF RID: 42719 RVA: 0x00081D15 File Offset: 0x0007FF15
		public float Eps { get; private set; }

		// Token: 0x1700305D RID: 12381
		// (get) Token: 0x0600A6E0 RID: 42720 RVA: 0x00081D1E File Offset: 0x0007FF1E
		// (set) Token: 0x0600A6E1 RID: 42721 RVA: 0x00081D26 File Offset: 0x0007FF26
		public float Fy { get; private set; }

		// Token: 0x1700305E RID: 12382
		// (get) Token: 0x0600A6E2 RID: 42722 RVA: 0x00081D2F File Offset: 0x0007FF2F
		// (set) Token: 0x0600A6E3 RID: 42723 RVA: 0x00081D37 File Offset: 0x0007FF37
		public float Es { get; private set; }

		// Token: 0x0600A6E4 RID: 42724 RVA: 0x00081D40 File Offset: 0x0007FF40
		public float #H2()
		{
			return this.Fy / this.Es / this.Eps;
		}

		// Token: 0x0600A6E5 RID: 42725 RVA: 0x00081D56 File Offset: 0x0007FF56
		public float #I2()
		{
			return this.Eyt / this.Eps;
		}

		// Token: 0x0600A6E6 RID: 42726 RVA: 0x002321D8 File Offset: 0x002303D8
		private void #mg(#Jle #L0)
		{
			this.Fcp = #L0.#a;
			this.Ec = #L0.#b;
			this.Fc = #L0.#c;
			this.Beta1 = #L0.#d;
			this.Eps = #L0.#e;
			this.Fy = #L0.#f;
			this.Es = #L0.#g;
			this.IsConcreteStandard = (#L0.#i > 0);
			this.IsSteelStandard = (#L0.#j > 0);
			this.Eyt = #L0.#k;
		}

		// Token: 0x0600A6E7 RID: 42727 RVA: 0x00232264 File Offset: 0x00230464
		private void #mg(MaterialProperties #L0)
		{
			this.Fcp = #L0.Fcp;
			this.Ec = #L0.Ec;
			this.Fc = #L0.Fc;
			this.Beta1 = #L0.Beta1;
			this.Eps = #L0.Eps;
			this.Fy = #L0.Fy;
			this.Es = #L0.Es;
			this.IsConcreteStandard = #L0.IsConcreteStandard;
			this.IsSteelStandard = #L0.IsSteelStandard;
			this.Eyt = #L0.Eyt;
		}

		// Token: 0x0400497D RID: 18813
		[CompilerGenerated]
		private bool #a;

		// Token: 0x0400497E RID: 18814
		[CompilerGenerated]
		private bool #b;

		// Token: 0x0400497F RID: 18815
		[CompilerGenerated]
		private float #c;

		// Token: 0x04004980 RID: 18816
		[CompilerGenerated]
		private float #d;

		// Token: 0x04004981 RID: 18817
		[CompilerGenerated]
		private float #e;

		// Token: 0x04004982 RID: 18818
		[CompilerGenerated]
		private float #f;

		// Token: 0x04004983 RID: 18819
		[CompilerGenerated]
		private float #g;

		// Token: 0x04004984 RID: 18820
		[CompilerGenerated]
		private float #h;

		// Token: 0x04004985 RID: 18821
		[CompilerGenerated]
		private float #i;

		// Token: 0x04004986 RID: 18822
		[CompilerGenerated]
		private float #j;
	}
}
