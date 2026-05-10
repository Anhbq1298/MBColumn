using System;
using System.Runtime.CompilerServices;
using #7hc;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Data;

namespace StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Output
{
	// Token: 0x0200134E RID: 4942
	public sealed class FactoredMoment
	{
		// Token: 0x0600A568 RID: 42344 RVA: 0x00230A0C File Offset: 0x0022EC0C
		public FactoredMoment(FactoredMoment.Axis momentAxis, int? load, int? combination, float? mns, NaNullableFloat ms, float? mu, NaNullableFloat mMin, NaNullableFloat mi, NaNullableFloat mc, NaNullableFloat ratio, FactoredMoment.#wif flags, FactoredMoment.#vif momentSide, int? miIndex)
		{
			this.MomentAxis = momentAxis;
			this.Load = load;
			this.Combination = combination;
			this.Mns = mns;
			this.Ms = ms;
			this.Mu = mu;
			this.MMin = mMin;
			this.Mi = mi;
			this.Mc = mc;
			this.Ratio = ratio;
			this.Flags = flags;
			this.MomentSide = momentSide;
			this.MiIndex = miIndex;
		}

		// Token: 0x0600A569 RID: 42345 RVA: 0x00230A84 File Offset: 0x0022EC84
		public FactoredMoment(FactoredMoment.Axis momentAxis, int? load, int? combination, NaNullableFloat ms, NaNullableFloat mi, NaNullableFloat mc, NaNullableFloat ratio, FactoredMoment.#wif flags, FactoredMoment.#vif momentSide, int? miIndex) : this(momentAxis, load, combination, null, ms, null, NaNullableFloat.#FSd(), mi, mc, ratio, flags, momentSide, miIndex)
		{
		}

		// Token: 0x17002FAD RID: 12205
		// (get) Token: 0x0600A56A RID: 42346 RVA: 0x00081012 File Offset: 0x0007F212
		public FactoredMoment.Axis MomentAxis { get; }

		// Token: 0x17002FAE RID: 12206
		// (get) Token: 0x0600A56B RID: 42347 RVA: 0x0008101A File Offset: 0x0007F21A
		public int? Load { get; }

		// Token: 0x17002FAF RID: 12207
		// (get) Token: 0x0600A56C RID: 42348 RVA: 0x00081022 File Offset: 0x0007F222
		public int? Combination { get; }

		// Token: 0x17002FB0 RID: 12208
		// (get) Token: 0x0600A56D RID: 42349 RVA: 0x0008102A File Offset: 0x0007F22A
		public float? Mns { get; }

		// Token: 0x17002FB1 RID: 12209
		// (get) Token: 0x0600A56E RID: 42350 RVA: 0x00081032 File Offset: 0x0007F232
		public NaNullableFloat Ms { get; }

		// Token: 0x17002FB2 RID: 12210
		// (get) Token: 0x0600A56F RID: 42351 RVA: 0x0008103A File Offset: 0x0007F23A
		public float? Mu { get; }

		// Token: 0x17002FB3 RID: 12211
		// (get) Token: 0x0600A570 RID: 42352 RVA: 0x00081042 File Offset: 0x0007F242
		public NaNullableFloat MMin { get; }

		// Token: 0x17002FB4 RID: 12212
		// (get) Token: 0x0600A571 RID: 42353 RVA: 0x0008104A File Offset: 0x0007F24A
		public NaNullableFloat Mi { get; }

		// Token: 0x17002FB5 RID: 12213
		// (get) Token: 0x0600A572 RID: 42354 RVA: 0x00081052 File Offset: 0x0007F252
		public int? MiIndex { get; }

		// Token: 0x17002FB6 RID: 12214
		// (get) Token: 0x0600A573 RID: 42355 RVA: 0x0008105A File Offset: 0x0007F25A
		public NaNullableFloat Mc { get; }

		// Token: 0x17002FB7 RID: 12215
		// (get) Token: 0x0600A574 RID: 42356 RVA: 0x00081062 File Offset: 0x0007F262
		public NaNullableFloat Ratio { get; }

		// Token: 0x17002FB8 RID: 12216
		// (get) Token: 0x0600A575 RID: 42357 RVA: 0x0008106A File Offset: 0x0007F26A
		public FactoredMoment.#vif MomentSide { get; }

		// Token: 0x17002FB9 RID: 12217
		// (get) Token: 0x0600A576 RID: 42358 RVA: 0x00081072 File Offset: 0x0007F272
		public FactoredMoment.#wif Flags { get; }

		// Token: 0x0600A577 RID: 42359 RVA: 0x00230AC0 File Offset: 0x0022ECC0
		public string #q3e()
		{
			string text = string.Empty;
			if (this.Flags.HasFlag(FactoredMoment.#wif.#b))
			{
				text += #Phc.#3hc(107311217);
			}
			if (this.Flags.HasFlag(FactoredMoment.#wif.#c))
			{
				text += #Phc.#3hc(107348386);
			}
			return text.Trim();
		}

		// Token: 0x040048AD RID: 18605
		[CompilerGenerated]
		private readonly FactoredMoment.Axis #a;

		// Token: 0x040048AE RID: 18606
		[CompilerGenerated]
		private readonly int? #b;

		// Token: 0x040048AF RID: 18607
		[CompilerGenerated]
		private readonly int? #c;

		// Token: 0x040048B0 RID: 18608
		[CompilerGenerated]
		private readonly float? #d;

		// Token: 0x040048B1 RID: 18609
		[CompilerGenerated]
		private readonly NaNullableFloat #e;

		// Token: 0x040048B2 RID: 18610
		[CompilerGenerated]
		private readonly float? #f;

		// Token: 0x040048B3 RID: 18611
		[CompilerGenerated]
		private readonly NaNullableFloat #g;

		// Token: 0x040048B4 RID: 18612
		[CompilerGenerated]
		private readonly NaNullableFloat #h;

		// Token: 0x040048B5 RID: 18613
		[CompilerGenerated]
		private readonly int? #i;

		// Token: 0x040048B6 RID: 18614
		[CompilerGenerated]
		private readonly NaNullableFloat #j;

		// Token: 0x040048B7 RID: 18615
		[CompilerGenerated]
		private readonly NaNullableFloat #k;

		// Token: 0x040048B8 RID: 18616
		[CompilerGenerated]
		private readonly FactoredMoment.#vif #l;

		// Token: 0x040048B9 RID: 18617
		[CompilerGenerated]
		private readonly FactoredMoment.#wif #m;

		// Token: 0x0200134F RID: 4943
		public enum Axis
		{
			// Token: 0x040048BB RID: 18619
			X,
			// Token: 0x040048BC RID: 18620
			Y
		}

		// Token: 0x02001350 RID: 4944
		public enum #vif
		{
			// Token: 0x040048BE RID: 18622
			#a,
			// Token: 0x040048BF RID: 18623
			#b
		}

		// Token: 0x02001351 RID: 4945
		[Flags]
		public enum #wif
		{
			// Token: 0x040048C1 RID: 18625
			#a = 0,
			// Token: 0x040048C2 RID: 18626
			#b = 1,
			// Token: 0x040048C3 RID: 18627
			#c = 2
		}
	}
}
