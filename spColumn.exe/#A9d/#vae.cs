using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using #7hc;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Units;
using StructurePoint.CoreAssets.Units.UnitSets;

namespace #A9d
{
	// Token: 0x02000FAE RID: 4014
	internal sealed class #vae : INotifyPropertyChanged, IUnitSymbol
	{
		// Token: 0x06008BA5 RID: 35749 RVA: 0x001DD454 File Offset: 0x001DB654
		public #vae(string #wy, string #qnb)
		{
			this.#b = #qnb;
			this.#e = #wy;
			this.#c = #Phc.#3hc(107251263).#D2d(new object[]
			{
				this.Symbol
			});
			this.#d = #Phc.#3hc(107246917).#D2d(new object[]
			{
				this.Symbol
			});
		}

		// Token: 0x140001AC RID: 428
		// (add) Token: 0x06008BA6 RID: 35750 RVA: 0x001DD4C0 File Offset: 0x001DB6C0
		// (remove) Token: 0x06008BA7 RID: 35751 RVA: 0x001DD504 File Offset: 0x001DB704
		public event PropertyChangedEventHandler PropertyChanged
		{
			[CompilerGenerated]
			add
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.#a;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.#a, value2, propertyChangedEventHandler2);
				}
				while (propertyChangedEventHandler != propertyChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.#a;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.#a, value2, propertyChangedEventHandler2);
				}
				while (propertyChangedEventHandler != propertyChangedEventHandler2);
			}
		}

		// Token: 0x170028CE RID: 10446
		// (get) Token: 0x06008BA8 RID: 35752 RVA: 0x000719BB File Offset: 0x0006FBBB
		public string Symbol { get; }

		// Token: 0x170028CF RID: 10447
		// (get) Token: 0x06008BA9 RID: 35753 RVA: 0x000719C7 File Offset: 0x0006FBC7
		public string SquareFormattedSymbol { get; }

		// Token: 0x170028D0 RID: 10448
		// (get) Token: 0x06008BAA RID: 35754 RVA: 0x000719D3 File Offset: 0x0006FBD3
		public string RoundFormattedSymbol { get; }

		// Token: 0x170028D1 RID: 10449
		// (get) Token: 0x06008BAB RID: 35755 RVA: 0x000719DF File Offset: 0x0006FBDF
		public string Name { get; }

		// Token: 0x06008BAC RID: 35756 RVA: 0x000719EB File Offset: 0x0006FBEB
		public string #tae(BracketType #uae)
		{
			if (#uae == BracketType.Round)
			{
				return this.RoundFormattedSymbol;
			}
			return this.SquareFormattedSymbol;
		}

		// Token: 0x06008BAD RID: 35757 RVA: 0x00071A09 File Offset: 0x0006FC09
		protected void #Fkb([CallerMemberName] string #em = null)
		{
			PropertyChangedEventHandler propertyChangedEventHandler = this.#a;
			if (propertyChangedEventHandler == null)
			{
				return;
			}
			propertyChangedEventHandler(this, new PropertyChangedEventArgs(#em));
		}

		// Token: 0x040039F3 RID: 14835
		[CompilerGenerated]
		private PropertyChangedEventHandler #a;

		// Token: 0x040039F4 RID: 14836
		[CompilerGenerated]
		private readonly string #b;

		// Token: 0x040039F5 RID: 14837
		[CompilerGenerated]
		private readonly string #c;

		// Token: 0x040039F6 RID: 14838
		[CompilerGenerated]
		private readonly string #d;

		// Token: 0x040039F7 RID: 14839
		[CompilerGenerated]
		private readonly string #e;
	}
}
