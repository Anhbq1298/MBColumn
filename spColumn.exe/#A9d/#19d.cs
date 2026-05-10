using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #N7d;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Units;
using StructurePoint.CoreAssets.Units.UnitSets;

namespace #A9d
{
	// Token: 0x02000F95 RID: 3989
	internal class #19d<#06> : #X9d, #H9d where #06 : struct, IComparable
	{
		// Token: 0x06008B3E RID: 35646 RVA: 0x001DC09C File Offset: 0x001DA29C
		public #19d(UnitSystem #Qg, params IUnit[] #jUd)
		{
			this.#a = new List<IUnit>();
			this.#b = new UnitConverter<!0>();
			this.UnitType = typeof(!0);
			this.UnitSystem = #Qg;
			if (#jUd != null)
			{
				this.#a.AddRange(#jUd);
			}
		}

		// Token: 0x170028BB RID: 10427
		// (get) Token: 0x06008B3F RID: 35647 RVA: 0x0007150B File Offset: 0x0006F70B
		// (set) Token: 0x06008B40 RID: 35648 RVA: 0x00071517 File Offset: 0x0006F717
		public Type UnitType { get; private set; }

		// Token: 0x170028BC RID: 10428
		// (get) Token: 0x06008B41 RID: 35649 RVA: 0x00071528 File Offset: 0x0006F728
		// (set) Token: 0x06008B42 RID: 35650 RVA: 0x00071534 File Offset: 0x0006F734
		public UnitSystem UnitSystem { get; private set; }

		// Token: 0x170028BD RID: 10429
		// (get) Token: 0x06008B43 RID: 35651 RVA: 0x00071545 File Offset: 0x0006F745
		public IEnumerable<IUnit> Units
		{
			get
			{
				return this.#a;
			}
		}

		// Token: 0x06008B44 RID: 35652 RVA: 0x001DC0EC File Offset: 0x001DA2EC
		public void #E9d(params IUnit[] #F9d)
		{
			if (#F9d != null)
			{
				foreach (IUnit #6jb in #F9d)
				{
					this.#D9d(#6jb);
				}
			}
		}

		// Token: 0x06008B45 RID: 35653 RVA: 0x001DC124 File Offset: 0x001DA324
		public IUnit #G9d(string #pJd)
		{
			#19d<#06>.#61b #61b = new #19d<!0>.#61b();
			#61b.#a = #pJd;
			return this.Units.First(new Func<IUnit, bool>(#61b.#jbe));
		}

		// Token: 0x06008B46 RID: 35654 RVA: 0x001DC164 File Offset: 0x001DA364
		public IUnit #G9d(Enum #Y7d)
		{
			#19d<#06>.#8Ub #8Ub = new #19d<!0>.#8Ub();
			#8Ub.#b = this;
			#8Ub.#c = #Y7d;
			#X0d.#V0d(#8Ub.#c, #Phc.#3hc(107217941), Component.Units, #Phc.#3hc(107248691));
			#8Ub.#a = #8Ub.#c.GetType();
			return this.Units.First(new Func<IUnit, bool>(#8Ub.#jbe));
		}

		// Token: 0x06008B47 RID: 35655 RVA: 0x001DC1DC File Offset: 0x001DA3DC
		public double #Pb(IUnit #J7d, IUnit #b4, double #f)
		{
			#X0d.#V0d(#J7d, #Phc.#3hc(107218871), Component.Units, #Phc.#3hc(107249150));
			#X0d.#V0d(#b4, #Phc.#3hc(107249065), Component.Units, #Phc.#3hc(107249056));
			if (!this.#09d(#J7d))
			{
				throw new InvalidCastException();
			}
			if (!this.#09d(#b4))
			{
				throw new InvalidCastException();
			}
			if (#J7d != #b4)
			{
				return this.#b.#Pb((!0)((object)#J7d.UnitCode), (!0)((object)#b4.UnitCode), #f);
			}
			return #f;
		}

		// Token: 0x06008B48 RID: 35656 RVA: 0x001DC284 File Offset: 0x001DA484
		public #H9d #D9d(IUnit #6jb)
		{
			#X0d.#V0d(#6jb, #Phc.#3hc(107249606), Component.Units, #Phc.#3hc(107249003));
			if (!this.#09d(#6jb))
			{
				string str = #6jb.UnitSymbol.Name;
				string str2 = #Phc.#3hc(107399922);
				Type type = this.UnitType;
				throw new InvalidCastException(str + str2 + ((type != null) ? type.ToString() : null));
			}
			this.#a.Add(#6jb);
			return this;
		}

		// Token: 0x06008B49 RID: 35657 RVA: 0x00071551 File Offset: 0x0006F751
		private bool #09d(IUnit #6jb)
		{
			return #6jb.UnitType != null && #6jb.UnitType == this.UnitType;
		}

		// Token: 0x0400399B RID: 14747
		private readonly List<IUnit> #a;

		// Token: 0x0400399C RID: 14748
		private readonly #L8d<#06> #b;

		// Token: 0x0400399D RID: 14749
		[CompilerGenerated]
		private Type #c;

		// Token: 0x0400399E RID: 14750
		[CompilerGenerated]
		private UnitSystem #d;

		// Token: 0x02000F96 RID: 3990
		[CompilerGenerated]
		private sealed class #61b
		{
			// Token: 0x06008B4B RID: 35659 RVA: 0x00071580 File Offset: 0x0006F780
			internal bool #jbe(IUnit #Rf)
			{
				return string.Equals(#Rf.UnitSymbol.Name, this.#a);
			}

			// Token: 0x0400399F RID: 14751
			public string #a;
		}

		// Token: 0x02000F97 RID: 3991
		[CompilerGenerated]
		private sealed class #8Ub
		{
			// Token: 0x06008B4D RID: 35661 RVA: 0x000715A4 File Offset: 0x0006F7A4
			internal bool #jbe(IUnit #Rf)
			{
				return this.#a == this.#b.UnitType && #Rf.UnitCode.Equals(this.#c);
			}

			// Token: 0x040039A0 RID: 14752
			public Type #a;

			// Token: 0x040039A1 RID: 14753
			public #19d<#06> #b;

			// Token: 0x040039A2 RID: 14754
			public Enum #c;
		}
	}
}
