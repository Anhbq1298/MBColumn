using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace #Zjb
{
	// Token: 0x0200042A RID: 1066
	internal sealed class #Gkb : INotifyPropertyChanged
	{
		// Token: 0x060026D5 RID: 9941 RVA: 0x0002477A File Offset: 0x0002297A
		public #Gkb(string #sH, string #Hkb)
		{
			this.Title = #sH;
			this.Description = #Hkb;
		}

		// Token: 0x140000AB RID: 171
		// (add) Token: 0x060026D6 RID: 9942 RVA: 0x000D6E00 File Offset: 0x000D5000
		// (remove) Token: 0x060026D7 RID: 9943 RVA: 0x000D6E44 File Offset: 0x000D5044
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

		// Token: 0x17000D25 RID: 3365
		// (get) Token: 0x060026D8 RID: 9944 RVA: 0x00024790 File Offset: 0x00022990
		// (set) Token: 0x060026D9 RID: 9945 RVA: 0x0002479C File Offset: 0x0002299C
		public string Title { get; set; }

		// Token: 0x17000D26 RID: 3366
		// (get) Token: 0x060026DA RID: 9946 RVA: 0x000247AD File Offset: 0x000229AD
		// (set) Token: 0x060026DB RID: 9947 RVA: 0x000247B9 File Offset: 0x000229B9
		public string Description { get; set; }

		// Token: 0x060026DC RID: 9948 RVA: 0x000D6E88 File Offset: 0x000D5088
		protected void #Fkb([CallerMemberName] string #em = null)
		{
			PropertyChangedEventHandler propertyChangedEventHandler = this.#a;
			if (propertyChangedEventHandler != null)
			{
				propertyChangedEventHandler(this, new PropertyChangedEventArgs(#em));
			}
		}

		// Token: 0x04000F64 RID: 3940
		[CompilerGenerated]
		private PropertyChangedEventHandler #a;

		// Token: 0x04000F65 RID: 3941
		[CompilerGenerated]
		private string #b;

		// Token: 0x04000F66 RID: 3942
		[CompilerGenerated]
		private string #c;
	}
}
