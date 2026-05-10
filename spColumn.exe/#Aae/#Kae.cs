using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace #Aae
{
	// Token: 0x02000FB1 RID: 4017
	internal class #Kae : INotifyPropertyChanged
	{
		// Token: 0x140001AE RID: 430
		// (add) Token: 0x06008BC3 RID: 35779 RVA: 0x001DD77C File Offset: 0x001DB97C
		// (remove) Token: 0x06008BC4 RID: 35780 RVA: 0x001DD7C0 File Offset: 0x001DB9C0
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

		// Token: 0x06008BC5 RID: 35781 RVA: 0x00071B8F File Offset: 0x0006FD8F
		protected virtual void #Fkb([CallerMemberName] string #em = null)
		{
			PropertyChangedEventHandler propertyChangedEventHandler = this.#a;
			if (propertyChangedEventHandler == null)
			{
				return;
			}
			propertyChangedEventHandler(this, new PropertyChangedEventArgs(#em));
		}

		// Token: 0x04003A04 RID: 14852
		[CompilerGenerated]
		private PropertyChangedEventHandler #a;
	}
}
