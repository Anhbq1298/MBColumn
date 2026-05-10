using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;
using StructurePoint.CoreAssets.Units.Formatters;
using StructurePoint.CoreAssets.Units.UnitSets;

namespace #A9d
{
	// Token: 0x02000FAF RID: 4015
	internal sealed class #wae : INotifyPropertyChanged, IUnit
	{
		// Token: 0x06008BAE RID: 35758 RVA: 0x001DD548 File Offset: 0x001DB748
		public #wae(Enum #Y7d, IUnitValueFormatter #70c)
		{
			#X0d.#V0d(#70c, #Phc.#3hc(107431438), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.Units, #Phc.#3hc(107246940));
			#X0d.#V0d(#Y7d, #Phc.#3hc(107217941), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.Units, #Phc.#3hc(107246855));
			this.#b = #Y7d;
			this.#c = #Y7d.GetType();
			this.#d = UnitSymbolProvider.#29d(#Y7d);
			this.#e = #70c;
		}

		// Token: 0x140001AD RID: 429
		// (add) Token: 0x06008BAF RID: 35759 RVA: 0x001DD5BC File Offset: 0x001DB7BC
		// (remove) Token: 0x06008BB0 RID: 35760 RVA: 0x001DD600 File Offset: 0x001DB800
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

		// Token: 0x170028D2 RID: 10450
		// (get) Token: 0x06008BB1 RID: 35761 RVA: 0x00071A2E File Offset: 0x0006FC2E
		public Enum UnitCode { get; }

		// Token: 0x170028D3 RID: 10451
		// (get) Token: 0x06008BB2 RID: 35762 RVA: 0x00071A3A File Offset: 0x0006FC3A
		public Type UnitType { get; }

		// Token: 0x170028D4 RID: 10452
		// (get) Token: 0x06008BB3 RID: 35763 RVA: 0x00071A46 File Offset: 0x0006FC46
		public IUnitSymbol UnitSymbol { get; }

		// Token: 0x170028D5 RID: 10453
		// (get) Token: 0x06008BB4 RID: 35764 RVA: 0x00071A52 File Offset: 0x0006FC52
		public IUnitValueFormatter UnitValueFormatter { get; }

		// Token: 0x06008BB5 RID: 35765 RVA: 0x00071A5E File Offset: 0x0006FC5E
		protected void #Fkb([CallerMemberName] string #em = null)
		{
			PropertyChangedEventHandler propertyChangedEventHandler = this.#a;
			if (propertyChangedEventHandler == null)
			{
				return;
			}
			propertyChangedEventHandler(this, new PropertyChangedEventArgs(#em));
		}

		// Token: 0x040039F8 RID: 14840
		[CompilerGenerated]
		private PropertyChangedEventHandler #a;

		// Token: 0x040039F9 RID: 14841
		[CompilerGenerated]
		private readonly Enum #b;

		// Token: 0x040039FA RID: 14842
		[CompilerGenerated]
		private readonly Type #c;

		// Token: 0x040039FB RID: 14843
		[CompilerGenerated]
		private readonly IUnitSymbol #d;

		// Token: 0x040039FC RID: 14844
		[CompilerGenerated]
		private readonly IUnitValueFormatter #e;
	}
}
