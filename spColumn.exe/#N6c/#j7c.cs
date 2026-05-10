using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #o1d;
using StructurePoint.CoreAssets.GUI.Framework.Collections;

namespace #N6c
{
	// Token: 0x02000CF8 RID: 3320
	internal sealed class #j7c<#Fu> : CustomObservableCollection<!0>
	{
		// Token: 0x06006C7A RID: 27770 RVA: 0x001A357C File Offset: 0x001A177C
		public #j7c(#k8c<#Fu> #Du, Func<#Fu, bool> #c7c)
		{
			if (#Du == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107420761));
			}
			this.#a = #Du;
			if (#c7c == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107264312));
			}
			this.#b = #c7c;
			this.#a.CollectionChanged += this.#XCc;
		}

		// Token: 0x06006C7B RID: 27771 RVA: 0x00054FE1 File Offset: 0x000531E1
		public #j7c(#k8c<#Fu> #Du, Func<#Fu, bool> #c7c, params string[] #k7c) : this(#Du, #c7c)
		{
			if (#k7c != null)
			{
				this.#c.#pR(#k7c);
			}
		}

		// Token: 0x06006C7C RID: 27772 RVA: 0x00054FFA File Offset: 0x000531FA
		public void #d7c()
		{
			INotifyCollectionChanged notifyCollectionChanged = this.#a;
			NotifyCollectionChangedEventHandler value = new NotifyCollectionChangedEventHandler(this.#XCc);
			if (7 != 0)
			{
				notifyCollectionChanged.CollectionChanged -= value;
			}
		}

		// Token: 0x06006C7D RID: 27773 RVA: 0x0005501A File Offset: 0x0005321A
		public void #cg()
		{
			if (6 != 0)
			{
				this.#56c();
			}
		}

		// Token: 0x06006C7E RID: 27774 RVA: 0x001A35E8 File Offset: 0x001A17E8
		public void #e7c(#k8c<#Fu> #f7c)
		{
			if (#f7c == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107264271));
			}
			if (#f7c == this.#a)
			{
				if (!false)
				{
					return;
				}
				goto IL_49;
			}
			else
			{
				INotifyCollectionChanged notifyCollectionChanged = this.#a;
				NotifyCollectionChangedEventHandler value = new NotifyCollectionChangedEventHandler(this.#XCc);
				if (8 != 0)
				{
					notifyCollectionChanged.CollectionChanged -= value;
				}
			}
			IL_37:
			NotifyCollectionChangedEventHandler value2 = new NotifyCollectionChangedEventHandler(this.#XCc);
			if (!false)
			{
				#f7c.CollectionChanged -= value2;
			}
			IL_49:
			if (!false)
			{
				NotifyCollectionChangedEventHandler value3 = new NotifyCollectionChangedEventHandler(this.#XCc);
				if (!false)
				{
					#f7c.CollectionChanged += value3;
				}
				if (false)
				{
					goto IL_37;
				}
				this.#a = #f7c;
				if (true)
				{
					this.#cg();
				}
			}
		}

		// Token: 0x06006C7F RID: 27775 RVA: 0x001A3680 File Offset: 0x001A1880
		private void #XCc(object #Ge, NotifyCollectionChangedEventArgs #He)
		{
			while (!base.IsNotificationSuspended)
			{
				Action<INotifyPropertyChanged> #nd = new Action<INotifyPropertyChanged>(this.#h7c);
				if (!false)
				{
					this.#16c(#nd);
				}
				if (!false)
				{
					this.#56c();
				}
				if (3 != 0)
				{
					Action<INotifyPropertyChanged> #nd2 = new Action<INotifyPropertyChanged>(this.#i7c);
					if (!false)
					{
						this.#16c(#nd2);
					}
					if (7 != 0)
					{
						return;
					}
				}
			}
		}

		// Token: 0x06006C80 RID: 27776 RVA: 0x00055028 File Offset: 0x00053228
		private void #g7c(object #Ge, PropertyChangedEventArgs #He)
		{
			bool flag = base.IsNotificationSuspended;
			while (!flag)
			{
				bool flag2 = flag = this.#c.Contains(#He.PropertyName);
				if (!false && !false)
				{
					if (!flag2)
					{
						break;
					}
					if (2 != 0)
					{
						this.#56c();
					}
					return;
				}
			}
			if (-1 != 0)
			{
				return;
			}
		}

		// Token: 0x06006C81 RID: 27777 RVA: 0x001A36DC File Offset: 0x001A18DC
		private void #16c(Action<INotifyPropertyChanged> #nd)
		{
			IEnumerator<#Fu> enumerator = base.GetEnumerator();
			IEnumerator<#Fu> enumerator2;
			if (8 != 0)
			{
				enumerator2 = enumerator;
				goto IL_0A;
			}
			try
			{
				for (;;)
				{
					IL_0A:
					while (enumerator2.MoveNext())
					{
						if (7 != 0)
						{
							INotifyPropertyChanged notifyPropertyChanged = enumerator2.Current as INotifyPropertyChanged;
							INotifyPropertyChanged notifyPropertyChanged2;
							if (!false)
							{
								notifyPropertyChanged2 = notifyPropertyChanged;
							}
							if (notifyPropertyChanged2 != null)
							{
								if (false)
								{
									break;
								}
								INotifyPropertyChanged obj = notifyPropertyChanged2;
								if (!false)
								{
									#nd(obj);
								}
							}
						}
					}
					break;
				}
			}
			finally
			{
				if (enumerator2 != null && -1 != 0)
				{
					enumerator2.Dispose();
				}
			}
		}

		// Token: 0x06006C82 RID: 27778 RVA: 0x001A3750 File Offset: 0x001A1950
		private void #56c()
		{
			while (4 != 0)
			{
				if (!false)
				{
					this.#NBc();
				}
				if (!false)
				{
					base.Clear();
				}
				IEnumerable<!0> #8f = this.#a.Where(this.#b);
				if (!false)
				{
					base.#pR(#8f);
				}
				if (!false)
				{
					if (false)
					{
						break;
					}
					this.#OBc();
					break;
				}
			}
		}

		// Token: 0x06006C83 RID: 27779 RVA: 0x0005505B File Offset: 0x0005325B
		[CompilerGenerated]
		private void #h7c(INotifyPropertyChanged #M9b)
		{
			PropertyChangedEventHandler value = new PropertyChangedEventHandler(this.#g7c);
			if (!false)
			{
				#M9b.PropertyChanged -= value;
			}
		}

		// Token: 0x06006C84 RID: 27780 RVA: 0x00055076 File Offset: 0x00053276
		[CompilerGenerated]
		private void #i7c(INotifyPropertyChanged #M9b)
		{
			PropertyChangedEventHandler value = new PropertyChangedEventHandler(this.#g7c);
			if (!false)
			{
				#M9b.PropertyChanged += value;
			}
		}

		// Token: 0x04002C25 RID: 11301
		private #k8c<#Fu> #a;

		// Token: 0x04002C26 RID: 11302
		private readonly Func<#Fu, bool> #b;

		// Token: 0x04002C27 RID: 11303
		private readonly HashSet<string> #c = new HashSet<string>();
	}
}
