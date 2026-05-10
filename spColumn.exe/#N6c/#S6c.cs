using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using StructurePoint.CoreAssets.GUI.Framework.Collections;

namespace #N6c
{
	// Token: 0x02000CF1 RID: 3313
	internal sealed class #S6c<#Fu> : CustomObservableCollection<!0>
	{
		// Token: 0x06006C2B RID: 27691 RVA: 0x00054E3A File Offset: 0x0005303A
		public #S6c(#k8c<#Fu> #T6c, #k8c<#Fu> #U6c)
		{
			this.#a = #T6c;
			this.#b = #U6c;
			this.#Q6c();
			this.#R6c();
		}

		// Token: 0x06006C2C RID: 27692 RVA: 0x001A1D18 File Offset: 0x0019FF18
		private void #P6c(object #Ge, NotifyCollectionChangedEventArgs #HA)
		{
			NotifyCollectionChangedAction action = #HA.Action;
			NotifyCollectionChangedAction notifyCollectionChangedAction;
			if (4 != 0)
			{
				notifyCollectionChangedAction = action;
			}
			for (;;)
			{
				switch (notifyCollectionChangedAction)
				{
				case NotifyCollectionChangedAction.Add:
					goto IL_25;
				case NotifyCollectionChangedAction.Remove:
				{
					if (false)
					{
						goto IL_25;
					}
					if (7 == 0)
					{
						goto IL_56;
					}
					IEnumerable<!0> #8f = #HA.OldItems.Cast<#Fu>();
					Action<!0> #E7c = null;
					bool #A3h = false;
					if (3 != 0)
					{
						base.#F7c(#8f, #E7c, #A3h);
					}
					if (!false)
					{
						return;
					}
					continue;
				}
				case NotifyCollectionChangedAction.Replace:
				case NotifyCollectionChangedAction.Move:
					return;
				case NotifyCollectionChangedAction.Reset:
					goto IL_56;
				}
				break;
			}
			return;
			IL_25:
			IEnumerable<!0> #8f2 = #HA.NewItems.Cast<#Fu>();
			if (!false)
			{
				base.#pR(#8f2);
			}
			return;
			IL_56:
			if (!false)
			{
				base.Clear();
			}
			if (!false)
			{
				this.#Q6c();
			}
		}

		// Token: 0x06006C2D RID: 27693 RVA: 0x001A1DA4 File Offset: 0x0019FFA4
		private void #Q6c()
		{
			if (2 != 0)
			{
				#07c #07c = new #07c(this);
				#07c #07c2;
				if (true)
				{
					#07c2 = #07c;
				}
				try
				{
					while (4 != 0)
					{
						IEnumerable<!0> #8f = this.#a;
						if (2 != 0)
						{
							base.#pR(#8f);
						}
						if (!false)
						{
							IEnumerable<!0> #8f2 = this.#b;
							if (2 == 0)
							{
								break;
							}
							base.#pR(#8f2);
							break;
						}
					}
				}
				finally
				{
					if (#07c2 != null)
					{
						((IDisposable)#07c2).Dispose();
					}
				}
			}
		}

		// Token: 0x06006C2E RID: 27694 RVA: 0x001A1E0C File Offset: 0x001A000C
		private void #R6c()
		{
			if (8 != 0 && 5 != 0)
			{
				INotifyCollectionChanged notifyCollectionChanged = this.#a;
				NotifyCollectionChangedEventHandler value = new NotifyCollectionChangedEventHandler(this.#P6c);
				if (-1 != 0)
				{
					notifyCollectionChanged.CollectionChanged += value;
				}
				if (2 != 0)
				{
					INotifyCollectionChanged notifyCollectionChanged2 = this.#b;
					NotifyCollectionChangedEventHandler value2 = new NotifyCollectionChangedEventHandler(this.#P6c);
					if (2 != 0)
					{
						notifyCollectionChanged2.CollectionChanged += value2;
					}
				}
			}
		}

		// Token: 0x04002C16 RID: 11286
		private readonly #k8c<#Fu> #a;

		// Token: 0x04002C17 RID: 11287
		private readonly #k8c<#Fu> #b;
	}
}
