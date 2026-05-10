using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #A9d;
using #u9d;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Units.Formatters;

namespace StructurePoint.CoreAssets.Units.UnitSets
{
	// Token: 0x02000F9C RID: 3996
	[SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
	public sealed class DefinitionAttribute
	{
		// Token: 0x06008B5E RID: 35678 RVA: 0x000715E7 File Offset: 0x0006F7E7
		private DefinitionAttribute()
		{
		}

		// Token: 0x06008B5F RID: 35679 RVA: 0x001DC304 File Offset: 0x001DA504
		public DefinitionAttribute(#H9d unitSet, IUnit defaultUnit)
		{
			#X0d.#V0d(unitSet, #Phc.#3hc(107249270), Component.AppManager, #Phc.#3hc(107249225));
			#X0d.#V0d(defaultUnit, #Phc.#3hc(107249204), Component.AppManager, #Phc.#3hc(107249179));
			this.UnitSet = unitSet;
			this.DefaultUnit = defaultUnit;
		}

		// Token: 0x06008B60 RID: 35680 RVA: 0x001DC368 File Offset: 0x001DA568
		public #IWc #IH(IUnit #6jb, IUnitValueFormatter #70c, double #f)
		{
			#X0d.#V0d(#6jb, #Phc.#3hc(107249606), Component.Units, #Phc.#3hc(107249621));
			#x9d #x9d = this.#b.#F1d(#6jb.UnitSymbol);
			if (#x9d == null)
			{
				return #IWc.Success;
			}
			return #x9d.#IH(#70c, #f, #6jb.UnitSymbol.SquareFormattedSymbol);
		}

		// Token: 0x06008B61 RID: 35681 RVA: 0x001DC3CC File Offset: 0x001DA5CC
		public double? #M9d(IUnit #6jb)
		{
			#X0d.#V0d(#6jb, #Phc.#3hc(107249606), Component.Units, #Phc.#3hc(107249536));
			#x9d #x9d = this.#b.#F1d(#6jb.UnitSymbol);
			if (#x9d == null)
			{
				return null;
			}
			#t9d #t9d = #x9d as #t9d;
			if (#t9d == null)
			{
				return null;
			}
			return #t9d.MinValue;
		}

		// Token: 0x06008B62 RID: 35682 RVA: 0x001DC43C File Offset: 0x001DA63C
		public DefinitionAttribute #N9d(IUnitSymbol #80c, double? #S0d, double? #T0d)
		{
			DefinitionAttribute.#ITb #ITb = new DefinitionAttribute.#ITb();
			DefinitionAttribute.#ITb #ITb2;
			if (!false)
			{
				#ITb2 = #ITb;
			}
			#ITb2.#a = #80c;
			#X0d.#V0d(#ITb2.#a, #Phc.#3hc(107249483), Component.Units, #Phc.#3hc(107249494));
			if (this.UnitSet.Units.Count(new Func<IUnit, bool>(#ITb2.#hbe)) != 1)
			{
				throw new InvalidOperationException();
			}
			this.#b.Add(#ITb2.#a, new #t9d(#S0d, #T0d)
			{
				TrimTrailingZeroes = true
			});
			return this;
		}

		// Token: 0x06008B63 RID: 35683 RVA: 0x001DC4DC File Offset: 0x001DA6DC
		public void #O9d(double? #S0d, double? #T0d)
		{
			this.#N9d(this.UnitSet.Units.Select(new Func<IUnit, IUnitSymbol>(DefinitionAttribute.<>c.<>9.#ibe)), #S0d, #T0d);
		}

		// Token: 0x06008B64 RID: 35684 RVA: 0x001DC530 File Offset: 0x001DA730
		public DefinitionAttribute #N9d(IEnumerable<IUnitSymbol> #P9d, double? #S0d, double? #T0d)
		{
			#X0d.#V0d(#P9d, #Phc.#3hc(107249409), Component.Units, #Phc.#3hc(107248876));
			foreach (IUnitSymbol #80c in #P9d)
			{
				this.#N9d(#80c, #S0d, #T0d);
			}
			return this;
		}

		// Token: 0x06008B65 RID: 35685 RVA: 0x001DC5A4 File Offset: 0x001DA7A4
		public DefinitionAttribute #N9d(IUnitSymbol #Q9d, IUnitSymbol #R9d, double? #S0d, double? #T0d)
		{
			#X0d.#V0d(#Q9d, #Phc.#3hc(107248855), Component.Units, #Phc.#3hc(107248826));
			#X0d.#V0d(#R9d, #Phc.#3hc(107248741), Component.Units, #Phc.#3hc(107248712));
			return this.#N9d(new IUnitSymbol[]
			{
				#Q9d,
				#R9d
			}, #S0d, #T0d);
		}

		// Token: 0x06008B66 RID: 35686 RVA: 0x001DC60C File Offset: 0x001DA80C
		public void #S9d(string #pJd, int #8W)
		{
			IUnit unit = this.UnitSet.#G9d(#pJd);
			unit.UnitValueFormatter.Precision = #8W;
			this.DefaultUnit = unit;
		}

		// Token: 0x170028C9 RID: 10441
		// (get) Token: 0x06008B67 RID: 35687 RVA: 0x000715FA File Offset: 0x0006F7FA
		public static DefinitionAttribute Empty
		{
			get
			{
				return DefinitionAttribute.#a;
			}
		}

		// Token: 0x170028CA RID: 10442
		// (get) Token: 0x06008B68 RID: 35688 RVA: 0x00071601 File Offset: 0x0006F801
		public bool IsEmpty
		{
			get
			{
				return DefinitionAttribute.#a == this;
			}
		}

		// Token: 0x170028CB RID: 10443
		// (get) Token: 0x06008B69 RID: 35689 RVA: 0x0007160F File Offset: 0x0006F80F
		// (set) Token: 0x06008B6A RID: 35690 RVA: 0x0007161B File Offset: 0x0006F81B
		public IUnit DefaultUnit { get; private set; }

		// Token: 0x170028CC RID: 10444
		// (get) Token: 0x06008B6B RID: 35691 RVA: 0x0007162C File Offset: 0x0006F82C
		// (set) Token: 0x06008B6C RID: 35692 RVA: 0x00071638 File Offset: 0x0006F838
		public #H9d UnitSet { get; private set; }

		// Token: 0x170028CD RID: 10445
		// (get) Token: 0x06008B6D RID: 35693 RVA: 0x00071649 File Offset: 0x0006F849
		public Enum UnitCode
		{
			get
			{
				return this.DefaultUnit.UnitCode;
			}
		}

		// Token: 0x040039A3 RID: 14755
		private static readonly DefinitionAttribute #a = new DefinitionAttribute();

		// Token: 0x040039A4 RID: 14756
		private readonly Dictionary<IUnitSymbol, #x9d> #b = new Dictionary<IUnitSymbol, #x9d>();

		// Token: 0x040039A5 RID: 14757
		[CompilerGenerated]
		private IUnit #c;

		// Token: 0x040039A6 RID: 14758
		[CompilerGenerated]
		private #H9d #d;

		// Token: 0x02000F9E RID: 3998
		[CompilerGenerated]
		private sealed class #ITb
		{
			// Token: 0x06008B73 RID: 35699 RVA: 0x00071692 File Offset: 0x0006F892
			internal bool #hbe(IUnit #Rf)
			{
				return #Rf.UnitSymbol == this.#a;
			}

			// Token: 0x040039A9 RID: 14761
			public IUnitSymbol #a;
		}
	}
}
