using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Model.Runtime;

namespace #hZe
{
	// Token: 0x0200131D RID: 4893
	internal sealed class #dAe
	{
		// Token: 0x0600A357 RID: 41815 RVA: 0x0007F9CA File Offset: 0x0007DBCA
		public void #yl()
		{
			this.#a.Clear();
			this.#b.Clear();
		}

		// Token: 0x0600A358 RID: 41816 RVA: 0x0022EA04 File Offset: 0x0022CC04
		public void #7ai(#y0e #Jte, UniCurve[] #UAe, float #Udb)
		{
			#dAe.#Fbc #Fbc = new #dAe.#Fbc(#Jte, #Udb, #UAe);
			this.#a[#Fbc] = #Fbc;
		}

		// Token: 0x0600A359 RID: 41817 RVA: 0x0022EA28 File Offset: 0x0022CC28
		public bool #8ai(#y0e #Jte, float #Udb, out UniCurve[] #OBe)
		{
			#dAe.#Fbc key = new #dAe.#Fbc(#Jte, #Udb);
			#OBe = null;
			#dAe.#Fbc #Fbc;
			if (!this.#a.TryGetValue(key, out #Fbc))
			{
				return false;
			}
			if (#Fbc == null || #Fbc.Value != #Udb)
			{
				return false;
			}
			#OBe = #Fbc.UniCurve;
			return #OBe != null;
		}

		// Token: 0x0600A35A RID: 41818 RVA: 0x0022EA78 File Offset: 0x0022CC78
		public void #9ai(#y0e #Jte, BiCurve #QBe, float #ivb)
		{
			#dAe.#Fbc #Fbc = new #dAe.#Fbc(#Jte, #ivb, #QBe);
			this.#b[#Fbc] = #Fbc;
		}

		// Token: 0x0600A35B RID: 41819 RVA: 0x0022EA9C File Offset: 0x0022CC9C
		public bool #abi(#y0e #Jte, float #ivb, out BiCurve #QBe)
		{
			#dAe.#Fbc key = new #dAe.#Fbc(#Jte, #ivb);
			#QBe = null;
			#dAe.#Fbc #Fbc;
			if (!this.#b.TryGetValue(key, out #Fbc))
			{
				return false;
			}
			if (#Fbc == null || #Fbc.Value != #ivb)
			{
				return false;
			}
			#QBe = #Fbc.BiCurve;
			return #QBe != null;
		}

		// Token: 0x04004793 RID: 18323
		private readonly SortedDictionary<#dAe.#Fbc, #dAe.#Fbc> #a = new SortedDictionary<#dAe.#Fbc, #dAe.#Fbc>();

		// Token: 0x04004794 RID: 18324
		private readonly SortedDictionary<#dAe.#Fbc, #dAe.#Fbc> #b = new SortedDictionary<#dAe.#Fbc, #dAe.#Fbc>();

		// Token: 0x0200131E RID: 4894
		[DebuggerDisplay("{Diagram.Id} - {Value}")]
		private sealed class #Fbc : IComparable<#dAe.#Fbc>
		{
			// Token: 0x0600A35D RID: 41821 RVA: 0x0007FA00 File Offset: 0x0007DC00
			public #Fbc(#y0e #Gfb, float #f)
			{
				this.Diagram = #Gfb;
				this.Value = #f;
			}

			// Token: 0x0600A35E RID: 41822 RVA: 0x0007FA16 File Offset: 0x0007DC16
			public #Fbc(#y0e #Jte, float #f, UniCurve[] #UAe)
			{
				this.Diagram = #Jte;
				this.Value = #f;
				this.UniCurve = #UAe;
			}

			// Token: 0x0600A35F RID: 41823 RVA: 0x0007FA33 File Offset: 0x0007DC33
			public #Fbc(#y0e #Jte, float #f, BiCurve #QBe)
			{
				this.Diagram = #Jte;
				this.Value = #f;
				this.BiCurve = #QBe;
			}

			// Token: 0x17002ECB RID: 11979
			// (get) Token: 0x0600A360 RID: 41824 RVA: 0x0007FA50 File Offset: 0x0007DC50
			public #y0e Diagram { get; }

			// Token: 0x17002ECC RID: 11980
			// (get) Token: 0x0600A361 RID: 41825 RVA: 0x0007FA58 File Offset: 0x0007DC58
			public float Value { get; }

			// Token: 0x17002ECD RID: 11981
			// (get) Token: 0x0600A362 RID: 41826 RVA: 0x0007FA60 File Offset: 0x0007DC60
			public UniCurve[] UniCurve { get; }

			// Token: 0x17002ECE RID: 11982
			// (get) Token: 0x0600A363 RID: 41827 RVA: 0x0007FA68 File Offset: 0x0007DC68
			public BiCurve BiCurve { get; }

			// Token: 0x0600A364 RID: 41828 RVA: 0x0022EAEC File Offset: 0x0022CCEC
			public int #Qhd(#dAe.#Fbc #L0)
			{
				if (this == #L0)
				{
					return 0;
				}
				if (#L0 == null)
				{
					return 1;
				}
				int num = this.Diagram.Id.CompareTo(#L0.Diagram.Id);
				if (num != 0)
				{
					return num;
				}
				return this.Value.CompareTo(#L0.Value);
			}

			// Token: 0x04004795 RID: 18325
			[CompilerGenerated]
			private readonly #y0e #a;

			// Token: 0x04004796 RID: 18326
			[CompilerGenerated]
			private readonly float #b;

			// Token: 0x04004797 RID: 18327
			[CompilerGenerated]
			private readonly UniCurve[] #c;

			// Token: 0x04004798 RID: 18328
			[CompilerGenerated]
			private readonly BiCurve #d;
		}
	}
}
