using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using #7hc;
using #ezc;
using #N6c;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace StructurePoint.CoreAssets.GUI.Framework.Collections
{
	// Token: 0x02000CF2 RID: 3314
	[Serializable]
	public class CustomObservableCollection<T> : Collection<!0>, INotifyPropertyChanged, INotifyPropertyChanging, IEnumerable, IEnumerable<!0>, ICollection, INotifyCollectionChanged, #k8c<!0>, IReadOnlyList<!0>, IReadOnlyCollection<!0>, #PBc, #h8c, #i8c
	{
		// Token: 0x06006C2F RID: 27695 RVA: 0x00054E5C File Offset: 0x0005305C
		public CustomObservableCollection()
		{
			this.IsNotificationSuspended = false;
		}

		// Token: 0x06006C30 RID: 27696 RVA: 0x001A1E60 File Offset: 0x001A0060
		public CustomObservableCollection(IEnumerable<T> items) : this()
		{
			foreach (T item in items)
			{
				base.Add(item);
			}
		}

		// Token: 0x06006C31 RID: 27697 RVA: 0x00054E6B File Offset: 0x0005306B
		public CustomObservableCollection(bool disposeRemovedItems)
		{
			this.DisposeRemovedItems = disposeRemovedItems;
		}

		// Token: 0x06006C32 RID: 27698 RVA: 0x00054E7A File Offset: 0x0005307A
		public CustomObservableCollection(IList<T> list, bool disposeRemovedItems) : base(list)
		{
			this.DisposeRemovedItems = disposeRemovedItems;
		}

		// Token: 0x06006C33 RID: 27699 RVA: 0x001A1EB0 File Offset: 0x001A00B0
		public CustomObservableCollection(IEnumerable<T> items, bool disposeRemovedItems)
		{
			this.DisposeRemovedItems = disposeRemovedItems;
			foreach (T item in items)
			{
				base.Add(item);
			}
		}

		// Token: 0x1400019C RID: 412
		// (add) Token: 0x06006C34 RID: 27700 RVA: 0x001A1F08 File Offset: 0x001A0108
		// (remove) Token: 0x06006C35 RID: 27701 RVA: 0x001A1F60 File Offset: 0x001A0160
		public event NotifyCollectionChangedEventHandler CollectionChanging
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler2;
					if (!false)
					{
						NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler = this.#a;
						if (!false)
						{
							notifyCollectionChangedEventHandler2 = notifyCollectionChangedEventHandler;
						}
					}
					NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler4;
					do
					{
						if (7 != 0)
						{
							NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler3 = notifyCollectionChangedEventHandler2;
							if (3 != 0)
							{
								notifyCollectionChangedEventHandler4 = notifyCollectionChangedEventHandler3;
							}
							NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler5 = (NotifyCollectionChangedEventHandler)Delegate.Combine(notifyCollectionChangedEventHandler4, value);
							NotifyCollectionChangedEventHandler value2;
							if (-1 != 0)
							{
								value2 = notifyCollectionChangedEventHandler5;
							}
							NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler6 = Interlocked.CompareExchange<NotifyCollectionChangedEventHandler>(ref this.#a, value2, notifyCollectionChangedEventHandler4);
							if (6 != 0)
							{
								notifyCollectionChangedEventHandler2 = notifyCollectionChangedEventHandler6;
							}
						}
					}
					while (notifyCollectionChangedEventHandler2 != notifyCollectionChangedEventHandler4);
				}
			}
			[CompilerGenerated]
			remove
			{
				if (!false)
				{
					NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler2;
					if (!false)
					{
						NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler = this.#a;
						if (!false)
						{
							notifyCollectionChangedEventHandler2 = notifyCollectionChangedEventHandler;
						}
					}
					NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler4;
					do
					{
						if (7 != 0)
						{
							NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler3 = notifyCollectionChangedEventHandler2;
							if (3 != 0)
							{
								notifyCollectionChangedEventHandler4 = notifyCollectionChangedEventHandler3;
							}
							NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler5 = (NotifyCollectionChangedEventHandler)Delegate.Remove(notifyCollectionChangedEventHandler4, value);
							NotifyCollectionChangedEventHandler value2;
							if (-1 != 0)
							{
								value2 = notifyCollectionChangedEventHandler5;
							}
							NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler6 = Interlocked.CompareExchange<NotifyCollectionChangedEventHandler>(ref this.#a, value2, notifyCollectionChangedEventHandler4);
							if (6 != 0)
							{
								notifyCollectionChangedEventHandler2 = notifyCollectionChangedEventHandler6;
							}
						}
					}
					while (notifyCollectionChangedEventHandler2 != notifyCollectionChangedEventHandler4);
				}
			}
		}

		// Token: 0x1400019D RID: 413
		// (add) Token: 0x06006C36 RID: 27702 RVA: 0x001A1FB8 File Offset: 0x001A01B8
		// (remove) Token: 0x06006C37 RID: 27703 RVA: 0x001A2010 File Offset: 0x001A0210
		public event NotifyCollectionChangedEventHandler CollectionChanged
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler2;
					if (!false)
					{
						NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler = this.#b;
						if (!false)
						{
							notifyCollectionChangedEventHandler2 = notifyCollectionChangedEventHandler;
						}
					}
					NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler4;
					do
					{
						if (7 != 0)
						{
							NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler3 = notifyCollectionChangedEventHandler2;
							if (3 != 0)
							{
								notifyCollectionChangedEventHandler4 = notifyCollectionChangedEventHandler3;
							}
							NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler5 = (NotifyCollectionChangedEventHandler)Delegate.Combine(notifyCollectionChangedEventHandler4, value);
							NotifyCollectionChangedEventHandler value2;
							if (-1 != 0)
							{
								value2 = notifyCollectionChangedEventHandler5;
							}
							NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler6 = Interlocked.CompareExchange<NotifyCollectionChangedEventHandler>(ref this.#b, value2, notifyCollectionChangedEventHandler4);
							if (6 != 0)
							{
								notifyCollectionChangedEventHandler2 = notifyCollectionChangedEventHandler6;
							}
						}
					}
					while (notifyCollectionChangedEventHandler2 != notifyCollectionChangedEventHandler4);
				}
			}
			[CompilerGenerated]
			remove
			{
				if (!false)
				{
					NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler2;
					if (!false)
					{
						NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler = this.#b;
						if (!false)
						{
							notifyCollectionChangedEventHandler2 = notifyCollectionChangedEventHandler;
						}
					}
					NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler4;
					do
					{
						if (7 != 0)
						{
							NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler3 = notifyCollectionChangedEventHandler2;
							if (3 != 0)
							{
								notifyCollectionChangedEventHandler4 = notifyCollectionChangedEventHandler3;
							}
							NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler5 = (NotifyCollectionChangedEventHandler)Delegate.Remove(notifyCollectionChangedEventHandler4, value);
							NotifyCollectionChangedEventHandler value2;
							if (-1 != 0)
							{
								value2 = notifyCollectionChangedEventHandler5;
							}
							NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler6 = Interlocked.CompareExchange<NotifyCollectionChangedEventHandler>(ref this.#b, value2, notifyCollectionChangedEventHandler4);
							if (6 != 0)
							{
								notifyCollectionChangedEventHandler2 = notifyCollectionChangedEventHandler6;
							}
						}
					}
					while (notifyCollectionChangedEventHandler2 != notifyCollectionChangedEventHandler4);
				}
			}
		}

		// Token: 0x1400019E RID: 414
		// (add) Token: 0x06006C38 RID: 27704 RVA: 0x001A2068 File Offset: 0x001A0268
		// (remove) Token: 0x06006C39 RID: 27705 RVA: 0x001A20C0 File Offset: 0x001A02C0
		public event EventHandler<#O6c> ItemChanged
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					EventHandler<#O6c> eventHandler2;
					if (!false)
					{
						EventHandler<#O6c> eventHandler = this.#c;
						if (!false)
						{
							eventHandler2 = eventHandler;
						}
					}
					EventHandler<#O6c> eventHandler4;
					do
					{
						if (7 != 0)
						{
							EventHandler<#O6c> eventHandler3 = eventHandler2;
							if (3 != 0)
							{
								eventHandler4 = eventHandler3;
							}
							EventHandler<#O6c> eventHandler5 = (EventHandler<#O6c>)Delegate.Combine(eventHandler4, value);
							EventHandler<#O6c> value2;
							if (-1 != 0)
							{
								value2 = eventHandler5;
							}
							EventHandler<#O6c> eventHandler6 = Interlocked.CompareExchange<EventHandler<#O6c>>(ref this.#c, value2, eventHandler4);
							if (6 != 0)
							{
								eventHandler2 = eventHandler6;
							}
						}
					}
					while (eventHandler2 != eventHandler4);
				}
			}
			[CompilerGenerated]
			remove
			{
				if (!false)
				{
					EventHandler<#O6c> eventHandler2;
					if (!false)
					{
						EventHandler<#O6c> eventHandler = this.#c;
						if (!false)
						{
							eventHandler2 = eventHandler;
						}
					}
					EventHandler<#O6c> eventHandler4;
					do
					{
						if (7 != 0)
						{
							EventHandler<#O6c> eventHandler3 = eventHandler2;
							if (3 != 0)
							{
								eventHandler4 = eventHandler3;
							}
							EventHandler<#O6c> eventHandler5 = (EventHandler<#O6c>)Delegate.Remove(eventHandler4, value);
							EventHandler<#O6c> value2;
							if (-1 != 0)
							{
								value2 = eventHandler5;
							}
							EventHandler<#O6c> eventHandler6 = Interlocked.CompareExchange<EventHandler<#O6c>>(ref this.#c, value2, eventHandler4);
							if (6 != 0)
							{
								eventHandler2 = eventHandler6;
							}
						}
					}
					while (eventHandler2 != eventHandler4);
				}
			}
		}

		// Token: 0x1400019F RID: 415
		// (add) Token: 0x06006C3A RID: 27706 RVA: 0x001A2118 File Offset: 0x001A0318
		// (remove) Token: 0x06006C3B RID: 27707 RVA: 0x001A2170 File Offset: 0x001A0370
		public event PropertyChangedEventHandler PropertyChanged
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					PropertyChangedEventHandler propertyChangedEventHandler2;
					if (!false)
					{
						PropertyChangedEventHandler propertyChangedEventHandler = this.#d;
						if (!false)
						{
							propertyChangedEventHandler2 = propertyChangedEventHandler;
						}
					}
					PropertyChangedEventHandler propertyChangedEventHandler4;
					do
					{
						if (7 != 0)
						{
							PropertyChangedEventHandler propertyChangedEventHandler3 = propertyChangedEventHandler2;
							if (3 != 0)
							{
								propertyChangedEventHandler4 = propertyChangedEventHandler3;
							}
							PropertyChangedEventHandler propertyChangedEventHandler5 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler4, value);
							PropertyChangedEventHandler value2;
							if (-1 != 0)
							{
								value2 = propertyChangedEventHandler5;
							}
							PropertyChangedEventHandler propertyChangedEventHandler6 = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.#d, value2, propertyChangedEventHandler4);
							if (6 != 0)
							{
								propertyChangedEventHandler2 = propertyChangedEventHandler6;
							}
						}
					}
					while (propertyChangedEventHandler2 != propertyChangedEventHandler4);
				}
			}
			[CompilerGenerated]
			remove
			{
				if (!false)
				{
					PropertyChangedEventHandler propertyChangedEventHandler2;
					if (!false)
					{
						PropertyChangedEventHandler propertyChangedEventHandler = this.#d;
						if (!false)
						{
							propertyChangedEventHandler2 = propertyChangedEventHandler;
						}
					}
					PropertyChangedEventHandler propertyChangedEventHandler4;
					do
					{
						if (7 != 0)
						{
							PropertyChangedEventHandler propertyChangedEventHandler3 = propertyChangedEventHandler2;
							if (3 != 0)
							{
								propertyChangedEventHandler4 = propertyChangedEventHandler3;
							}
							PropertyChangedEventHandler propertyChangedEventHandler5 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler4, value);
							PropertyChangedEventHandler value2;
							if (-1 != 0)
							{
								value2 = propertyChangedEventHandler5;
							}
							PropertyChangedEventHandler propertyChangedEventHandler6 = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.#d, value2, propertyChangedEventHandler4);
							if (6 != 0)
							{
								propertyChangedEventHandler2 = propertyChangedEventHandler6;
							}
						}
					}
					while (propertyChangedEventHandler2 != propertyChangedEventHandler4);
				}
			}
		}

		// Token: 0x140001A0 RID: 416
		// (add) Token: 0x06006C3C RID: 27708 RVA: 0x001A21C8 File Offset: 0x001A03C8
		// (remove) Token: 0x06006C3D RID: 27709 RVA: 0x001A2220 File Offset: 0x001A0420
		public event PropertyChangingEventHandler PropertyChanging
		{
			[CompilerGenerated]
			add
			{
				if (!false)
				{
					PropertyChangingEventHandler propertyChangingEventHandler2;
					if (!false)
					{
						PropertyChangingEventHandler propertyChangingEventHandler = this.#e;
						if (!false)
						{
							propertyChangingEventHandler2 = propertyChangingEventHandler;
						}
					}
					PropertyChangingEventHandler propertyChangingEventHandler4;
					do
					{
						if (7 != 0)
						{
							PropertyChangingEventHandler propertyChangingEventHandler3 = propertyChangingEventHandler2;
							if (3 != 0)
							{
								propertyChangingEventHandler4 = propertyChangingEventHandler3;
							}
							PropertyChangingEventHandler propertyChangingEventHandler5 = (PropertyChangingEventHandler)Delegate.Combine(propertyChangingEventHandler4, value);
							PropertyChangingEventHandler value2;
							if (-1 != 0)
							{
								value2 = propertyChangingEventHandler5;
							}
							PropertyChangingEventHandler propertyChangingEventHandler6 = Interlocked.CompareExchange<PropertyChangingEventHandler>(ref this.#e, value2, propertyChangingEventHandler4);
							if (6 != 0)
							{
								propertyChangingEventHandler2 = propertyChangingEventHandler6;
							}
						}
					}
					while (propertyChangingEventHandler2 != propertyChangingEventHandler4);
				}
			}
			[CompilerGenerated]
			remove
			{
				if (!false)
				{
					PropertyChangingEventHandler propertyChangingEventHandler2;
					if (!false)
					{
						PropertyChangingEventHandler propertyChangingEventHandler = this.#e;
						if (!false)
						{
							propertyChangingEventHandler2 = propertyChangingEventHandler;
						}
					}
					PropertyChangingEventHandler propertyChangingEventHandler4;
					do
					{
						if (7 != 0)
						{
							PropertyChangingEventHandler propertyChangingEventHandler3 = propertyChangingEventHandler2;
							if (3 != 0)
							{
								propertyChangingEventHandler4 = propertyChangingEventHandler3;
							}
							PropertyChangingEventHandler propertyChangingEventHandler5 = (PropertyChangingEventHandler)Delegate.Remove(propertyChangingEventHandler4, value);
							PropertyChangingEventHandler value2;
							if (-1 != 0)
							{
								value2 = propertyChangingEventHandler5;
							}
							PropertyChangingEventHandler propertyChangingEventHandler6 = Interlocked.CompareExchange<PropertyChangingEventHandler>(ref this.#e, value2, propertyChangingEventHandler4);
							if (6 != 0)
							{
								propertyChangingEventHandler2 = propertyChangingEventHandler6;
							}
						}
					}
					while (propertyChangingEventHandler2 != propertyChangingEventHandler4);
				}
			}
		}

		// Token: 0x17001DA2 RID: 7586
		// (get) Token: 0x06006C3E RID: 27710 RVA: 0x00054E8A File Offset: 0x0005308A
		// (set) Token: 0x06006C3F RID: 27711 RVA: 0x00054E92 File Offset: 0x00053092
		public bool IsNotificationSuspended { get; private set; }

		// Token: 0x17001DA3 RID: 7587
		// (get) Token: 0x06006C40 RID: 27712 RVA: 0x00054E9B File Offset: 0x0005309B
		// (set) Token: 0x06006C41 RID: 27713 RVA: 0x00054EA3 File Offset: 0x000530A3
		public bool DisposeRemovedItems { get; set; }

		// Token: 0x17001DA4 RID: 7588
		// (get) Token: 0x06006C42 RID: 27714 RVA: 0x00054EAC File Offset: 0x000530AC
		int #k8c<!0>.Count
		{
			get
			{
				return base.Count;
			}
		}

		// Token: 0x06006C43 RID: 27715 RVA: 0x001A2278 File Offset: 0x001A0478
		public void #w7c()
		{
			NotifyCollectionChangedAction #nd = NotifyCollectionChangedAction.Reset;
			!0 #Rf = default(!0);
			int? #4jb = null;
			if (!false)
			{
				this.#L7c(#nd, #Rf, #4jb);
			}
		}

		// Token: 0x06006C44 RID: 27716 RVA: 0x00054EB4 File Offset: 0x000530B4
		public void #DE(Comparison<T> #41d)
		{
			IList<T> items = base.Items;
			if (7 != 0)
			{
				items.#DE(#41d);
			}
			if (!false)
			{
				this.#w7c();
			}
		}

		// Token: 0x06006C45 RID: 27717 RVA: 0x001A22A8 File Offset: 0x001A04A8
		public bool #x7c(int #y7c)
		{
			if (8 != 0 && 5 != 0)
			{
				List<T> list = base.Items as List<!0>;
				List<T> list2;
				if (-1 != 0)
				{
					list2 = list;
				}
				if (list2 != null)
				{
					if (2 != 0)
					{
						List<!0> list3 = list2;
						if (2 != 0)
						{
							list3.Capacity = #y7c;
						}
					}
					return true;
				}
			}
			return false;
		}

		// Token: 0x06006C46 RID: 27718 RVA: 0x001A22E4 File Offset: 0x001A04E4
		public void #z7c(bool #A7c = false)
		{
			List<T> list2;
			for (;;)
			{
				if (false)
				{
					goto IL_15;
				}
				if (-1 != 0)
				{
					List<T> list = base.Items as List<!0>;
					if (false)
					{
						goto IL_15;
					}
					list2 = list;
					goto IL_15;
				}
				IL_18:
				if (6 != 0)
				{
					break;
				}
				continue;
				IL_15:
				if (list2 != null)
				{
					goto IL_18;
				}
				goto IL_63;
			}
			List<!0> list3 = list2;
			if (3 != 0)
			{
				list3.Clear();
			}
			List<!0> list4 = list2;
			int capacity = 1;
			if (!false)
			{
				list4.Capacity = capacity;
			}
			bool flag = this.IsNotificationSuspended;
			int num = 0;
			bool flag2;
			do
			{
				flag2 = (flag = ((flag ? 1 : 0) == num));
				num = (#A7c ? 1 : 0);
			}
			while (6 == 0);
			if (flag2 && #A7c)
			{
				NotifyCollectionChangedAction #nd = NotifyCollectionChangedAction.Reset;
				!0 #Rf = default(!0);
				int? #4jb = null;
				if (-1 != 0)
				{
					this.#L7c(#nd, #Rf, #4jb);
				}
				string #em = #Phc.#3hc(107264282);
				if (3 != 0)
				{
					this.#Fkb(#em);
				}
			}
			return;
			IL_63:
			if (2 != 0)
			{
				base.Clear();
			}
		}

		// Token: 0x06006C47 RID: 27719 RVA: 0x001A2380 File Offset: 0x001A0580
		public int #B7c(Func<T, bool> #Q5c)
		{
			IL_00:
			int num4;
			while (#Q5c != null)
			{
				int num = 0;
				int num2;
				if (5 != 0)
				{
					num2 = num;
				}
				for (;;)
				{
					int num3 = num4 = num2;
					if (false)
					{
						break;
					}
					if (num3 >= base.Count)
					{
						return -1;
					}
					if (false)
					{
						goto IL_00;
					}
					if (#Q5c(base.Items[num2]))
					{
						goto Block_2;
					}
					int num5 = num2 + 1;
					if (!false)
					{
						num2 = num5;
					}
				}
				IL_08:
				throw new ArgumentNullException(#Phc.#3hc(num4));
				Block_2:
				if (!false)
				{
					return num2;
				}
				return -1;
			}
			num4 = 107266010;
			goto IL_08;
		}

		// Token: 0x06006C48 RID: 27720 RVA: 0x00054ED5 File Offset: 0x000530D5
		public int #C7c(object #Rf)
		{
			return base.IndexOf((!0)((object)#Rf));
		}

		// Token: 0x06006C49 RID: 27721 RVA: 0x001A23E0 File Offset: 0x001A05E0
		public void #D7c(Func<T, bool> #Q5c, Action<T> #E7c = null)
		{
			while (#Q5c != null)
			{
				List<T> list = this.Where(#Q5c).ToList<T>();
				List<T> list2;
				if (!false)
				{
					list2 = list;
				}
				if (3 != 0)
				{
					IEnumerable<!0> #8f = list2;
					bool #A3h = false;
					if (!false)
					{
						this.#F7c(#8f, #E7c, #A3h);
					}
					if (7 != 0)
					{
						return;
					}
				}
			}
			throw new ArgumentNullException(#Phc.#3hc(107266010));
		}

		// Token: 0x06006C4A RID: 27722 RVA: 0x001A242C File Offset: 0x001A062C
		public void #F7c(IEnumerable<T> #8f, Action<T> #E7c = null, bool #A3h = false)
		{
			if (#8f == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107264273));
			}
			try
			{
				if (#A3h)
				{
					this.#NBc();
				}
				foreach (T t in #8f)
				{
					T t2;
					if (2 != 0)
					{
						t2 = t;
					}
					if (#E7c != null)
					{
						!0 obj = t2;
						if (!false)
						{
							#E7c(obj);
						}
					}
					base.Remove(t2);
				}
			}
			finally
			{
				if (#A3h)
				{
					this.#OBc();
				}
			}
		}

		// Token: 0x06006C4B RID: 27723 RVA: 0x00054EE3 File Offset: 0x000530E3
		public void #B3h(int #1f)
		{
			if (!false && base.Count >= #1f)
			{
				int #1f2 = base.Count - #1f;
				if (!false)
				{
					this.#C3h(#1f2);
				}
				if (!false)
				{
					return;
				}
			}
		}

		// Token: 0x06006C4C RID: 27724 RVA: 0x001A24C0 File Offset: 0x001A06C0
		public void #C3h(int #1f)
		{
			while (#1f < base.Count)
			{
				if (-1 != 0)
				{
					this.#NBc();
				}
				if (2 != 0)
				{
					List<T> list = base.Items.Skip(#1f).ToList<T>();
					List<T> list2;
					if (!false)
					{
						list2 = list;
					}
					do
					{
						if (!false)
						{
							base.Clear();
						}
						IList<T> items = base.Items;
						ICollection<T>[] #8f = new ICollection<!0>[]
						{
							list2
						};
						if (!false)
						{
							items.#pR(#8f);
						}
						if (5 != 0 && 4 != 0)
						{
							this.#OBc();
						}
					}
					while (false);
					return;
				}
			}
			if (!false)
			{
				base.Clear();
			}
		}

		// Token: 0x06006C4D RID: 27725 RVA: 0x001A2544 File Offset: 0x001A0744
		public void #G7c(IEnumerable<T> #8f)
		{
			List<T> list2;
			int startingIndex;
			if (#8f == null)
			{
				if (4 != 0)
				{
					throw new ArgumentNullException(#Phc.#3hc(107264273));
				}
				goto IL_59;
			}
			else
			{
				List<T> list = base.Items as List<!0>;
				if (!false)
				{
					list2 = list;
				}
				if (list2 == null)
				{
					goto IL_6B;
				}
				int count = base.Count;
				if (!false)
				{
					startingIndex = count;
				}
				List<!0> list3 = list2;
				if (!false)
				{
					list3.AddRange(#8f);
				}
			}
			IL_39:
			string #em = #Phc.#3hc(107264282);
			if (!false)
			{
				this.#Fkb(#em);
			}
			string #em2 = #Phc.#3hc(107263720);
			if (6 != 0)
			{
				this.#Fkb(#em2);
			}
			IL_59:
			if (false)
			{
				goto IL_6B;
			}
			NotifyCollectionChangedEventArgs #Lg = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, list2, startingIndex);
			if (!false)
			{
				this.#O7c(#Lg);
			}
			return;
			IL_6B:
			if (false)
			{
				return;
			}
			if (!false)
			{
				this.#pR(#8f);
				return;
			}
			goto IL_39;
		}

		// Token: 0x06006C4E RID: 27726 RVA: 0x001A25EC File Offset: 0x001A07EC
		public void #pR(IEnumerable<T> #8f)
		{
			while (#8f != null)
			{
				IEnumerator<T> enumerator = #8f.GetEnumerator();
				IEnumerator<T> enumerator2;
				if (3 != 0)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (enumerator2.MoveNext())
					{
						T t = enumerator2.Current;
						T t2;
						if (2 != 0)
						{
							t2 = t;
						}
						!0 item = t2;
						if (3 != 0)
						{
							base.Add(item);
						}
					}
				}
				finally
				{
					do
					{
						if (enumerator2 != null)
						{
							if (4 == 0)
							{
								continue;
							}
							enumerator2.Dispose();
						}
					}
					while (2 == 0);
				}
				if (!false)
				{
					return;
				}
			}
			throw new ArgumentNullException(#Phc.#3hc(107264273));
		}

		// Token: 0x06006C4F RID: 27727 RVA: 0x001A2664 File Offset: 0x001A0864
		public void #pR(IEnumerable<T> #8f, bool #A3h)
		{
			try
			{
				if (#A3h)
				{
					this.#NBc();
				}
				using (IEnumerator<T> enumerator = #8f.GetEnumerator())
				{
					while (enumerator.MoveNext() && 8 != 0)
					{
						T t = enumerator.Current;
						T t2;
						if (!false)
						{
							t2 = t;
						}
						!0 item = t2;
						if (true)
						{
							base.Add(item);
						}
					}
				}
			}
			finally
			{
				while (#A3h)
				{
					if (!false)
					{
						this.#OBc();
						break;
					}
				}
			}
		}

		// Token: 0x06006C50 RID: 27728 RVA: 0x001A26E0 File Offset: 0x001A08E0
		public void #H7c(int #4jb, IEnumerable<T> #8f)
		{
			if (#8f == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107264273));
			}
			IEnumerator<T> enumerator = #8f.GetEnumerator();
			IEnumerator<T> enumerator2;
			if (!false)
			{
				enumerator2 = enumerator;
				goto IL_1D;
			}
			try
			{
				for (;;)
				{
					IL_1D:
					for (;;)
					{
						if (!enumerator2.MoveNext())
						{
							if (6 != 0)
							{
								goto Block_5;
							}
						}
						else
						{
							T t = enumerator2.Current;
							T t2;
							if (!false)
							{
								t2 = t;
							}
							if (!false)
							{
								int num = #4jb;
								int num2 = num + 1;
								if (!false)
								{
									#4jb = num2;
								}
								!0 item = t2;
								if (7 != 0)
								{
									base.Insert(num, item);
								}
							}
						}
					}
				}
				Block_5:;
			}
			finally
			{
				if (enumerator2 == null)
				{
					goto IL_60;
				}
				IL_5A:
				enumerator2.Dispose();
				IL_60:
				if (3 == 0)
				{
					goto IL_5A;
				}
			}
		}

		// Token: 0x06006C51 RID: 27729 RVA: 0x001A2764 File Offset: 0x001A0964
		public virtual void #V6c(int #4jb, T #Rf)
		{
			if (4 != 0)
			{
				int num = this.#C7c(#Rf);
				int num2;
				int num3;
				do
				{
					if (!false)
					{
						num2 = num;
					}
					if (7 == 0)
					{
						return;
					}
					num3 = (num = num2);
				}
				while (false);
				if (num3 != #4jb)
				{
					int #I7c = num2;
					if (false)
					{
						return;
					}
					this.#V6c(#I7c, #4jb);
					return;
				}
				return;
			}
		}

		// Token: 0x06006C52 RID: 27730 RVA: 0x001A27A4 File Offset: 0x001A09A4
		public virtual void #V6c(int #I7c, int #J7c)
		{
			T t = base[#I7c];
			T t2;
			if (true)
			{
				t2 = t;
			}
			NotifyCollectionChangedEventArgs #Lg = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move, t2, #J7c, #I7c);
			if (6 != 0)
			{
				this.#N7c(#Lg);
			}
			bool flag = this.IsNotificationSuspended;
			bool #f;
			if (!false)
			{
				#f = flag;
				goto IL_32;
			}
			try
			{
				for (;;)
				{
					IL_32:
					bool #f2 = true;
					if (6 != 0)
					{
						this.IsNotificationSuspended = #f2;
					}
					do
					{
						if (8 != 0)
						{
							base.RemoveItem(#I7c);
						}
						if (2 == 0)
						{
							goto IL_32;
						}
					}
					while (false);
					if (5 != 0)
					{
						!0 item = t2;
						if (!false)
						{
							base.InsertItem(#J7c, item);
						}
						this.IsNotificationSuspended = false;
						if (!false)
						{
							break;
						}
					}
				}
			}
			finally
			{
				this.IsNotificationSuspended = #f;
			}
			this.#O7c(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move, t2, #J7c, #I7c));
		}

		// Token: 0x06006C53 RID: 27731 RVA: 0x001A2868 File Offset: 0x001A0A68
		public virtual void #NBc()
		{
			for (;;)
			{
				bool #f = true;
				if (!false)
				{
					this.IsNotificationSuspended = #f;
				}
				for (;;)
				{
					IEnumerator<INotifyPropertyChanged> enumerator = base.Items.OfType<INotifyPropertyChanged>().GetEnumerator();
					IEnumerator<INotifyPropertyChanged> enumerator2;
					if (3 != 0)
					{
						enumerator2 = enumerator;
					}
					try
					{
						while (enumerator2.MoveNext())
						{
							INotifyPropertyChanged notifyPropertyChanged = enumerator2.Current;
							PropertyChangedEventHandler value = new PropertyChangedEventHandler(this.#Q7c);
							if (!false)
							{
								notifyPropertyChanged.PropertyChanged -= value;
							}
						}
					}
					finally
					{
						if (false || enumerator2 != null)
						{
							enumerator2.Dispose();
						}
					}
					if (false)
					{
						break;
					}
					if (!false)
					{
						return;
					}
				}
			}
		}

		// Token: 0x06006C54 RID: 27732 RVA: 0x00054F0A File Offset: 0x0005310A
		public virtual void #K7c()
		{
			bool #f = false;
			if (!false)
			{
				this.IsNotificationSuspended = #f;
			}
		}

		// Token: 0x06006C55 RID: 27733 RVA: 0x001A28E8 File Offset: 0x001A0AE8
		public virtual void #OBc()
		{
			if (!false)
			{
				if (!false)
				{
					bool #f = false;
					if (!false)
					{
						this.IsNotificationSuspended = #f;
					}
				}
				if (7 != 0)
				{
					NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler = this.#b;
					if (notifyCollectionChangedEventHandler != null)
					{
						NotifyCollectionChangedEventArgs e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
						if (3 != 0)
						{
							notifyCollectionChangedEventHandler(this, e);
						}
					}
					string #em = #Phc.#3hc(107264282);
					if (-1 != 0)
					{
						this.#Fkb(#em);
					}
				}
				if (6 != 0)
				{
					this.#FIc();
				}
			}
		}

		// Token: 0x06006C56 RID: 27734 RVA: 0x001A2950 File Offset: 0x001A0B50
		protected void #L7c(NotifyCollectionChangedAction #nd, T #Rf, int? #4jb)
		{
			if (!true)
			{
				goto IL_31;
			}
			NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs;
			if (#4jb != null)
			{
				notifyCollectionChangedEventArgs = new NotifyCollectionChangedEventArgs(#nd, #Rf, #4jb.Value);
				goto IL_2D;
			}
			IL_0C:
			notifyCollectionChangedEventArgs = new NotifyCollectionChangedEventArgs(#nd, #Rf);
			IL_2D:
			NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs2;
			if (!false)
			{
				notifyCollectionChangedEventArgs2 = notifyCollectionChangedEventArgs;
			}
			IL_31:
			NotifyCollectionChangedEventArgs #Lg = notifyCollectionChangedEventArgs2;
			if (!false)
			{
				this.#O7c(#Lg);
			}
			if (!false)
			{
				return;
			}
			goto IL_0C;
		}

		// Token: 0x06006C57 RID: 27735 RVA: 0x001A29A4 File Offset: 0x001A0BA4
		protected void #L7c(NotifyCollectionChangedAction #nd, T #Rf, T #x3c, int? #4jb)
		{
			NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs2;
			while (#4jb != null)
			{
				NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs;
				if (#nd != NotifyCollectionChangedAction.Replace)
				{
					if (false)
					{
						continue;
					}
					notifyCollectionChangedEventArgs = new NotifyCollectionChangedEventArgs(#nd, #Rf, #4jb.Value);
				}
				else
				{
					notifyCollectionChangedEventArgs = new NotifyCollectionChangedEventArgs(#nd, #Rf, #x3c, #4jb.Value);
				}
				if (7 != 0)
				{
					notifyCollectionChangedEventArgs2 = notifyCollectionChangedEventArgs;
				}
				IL_54:
				NotifyCollectionChangedEventArgs #Lg = notifyCollectionChangedEventArgs2;
				if (3 != 0)
				{
					this.#O7c(#Lg);
				}
				return;
			}
			NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs3 = new NotifyCollectionChangedEventArgs(#nd, #Rf);
			if (5 == 0)
			{
				goto IL_54;
			}
			notifyCollectionChangedEventArgs2 = notifyCollectionChangedEventArgs3;
			goto IL_54;
		}

		// Token: 0x06006C58 RID: 27736 RVA: 0x001A2A1C File Offset: 0x001A0C1C
		protected void #M7c(NotifyCollectionChangedAction #nd, T #Rf, int? #4jb)
		{
			if (!true)
			{
				goto IL_31;
			}
			NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs;
			if (#4jb != null)
			{
				notifyCollectionChangedEventArgs = new NotifyCollectionChangedEventArgs(#nd, #Rf, #4jb.Value);
				goto IL_2D;
			}
			IL_0C:
			notifyCollectionChangedEventArgs = new NotifyCollectionChangedEventArgs(#nd, #Rf);
			IL_2D:
			NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs2;
			if (!false)
			{
				notifyCollectionChangedEventArgs2 = notifyCollectionChangedEventArgs;
			}
			IL_31:
			NotifyCollectionChangedEventArgs #Lg = notifyCollectionChangedEventArgs2;
			if (!false)
			{
				this.#N7c(#Lg);
			}
			if (!false)
			{
				return;
			}
			goto IL_0C;
		}

		// Token: 0x06006C59 RID: 27737 RVA: 0x001A2A70 File Offset: 0x001A0C70
		protected void #M7c(NotifyCollectionChangedAction #nd, T #Rf, T #x3c, int? #4jb)
		{
			NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs2;
			while (#4jb != null)
			{
				NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs;
				if (#nd != NotifyCollectionChangedAction.Replace)
				{
					if (false)
					{
						continue;
					}
					notifyCollectionChangedEventArgs = new NotifyCollectionChangedEventArgs(#nd, #Rf, #4jb.Value);
				}
				else
				{
					notifyCollectionChangedEventArgs = new NotifyCollectionChangedEventArgs(#nd, #Rf, #x3c, #4jb.Value);
				}
				if (7 != 0)
				{
					notifyCollectionChangedEventArgs2 = notifyCollectionChangedEventArgs;
				}
				IL_54:
				NotifyCollectionChangedEventArgs #Lg = notifyCollectionChangedEventArgs2;
				if (3 != 0)
				{
					this.#N7c(#Lg);
				}
				return;
			}
			NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs3 = new NotifyCollectionChangedEventArgs(#nd, #Rf);
			if (5 == 0)
			{
				goto IL_54;
			}
			notifyCollectionChangedEventArgs2 = notifyCollectionChangedEventArgs3;
			goto IL_54;
		}

		// Token: 0x06006C5A RID: 27738 RVA: 0x001A2AE8 File Offset: 0x001A0CE8
		protected virtual void #N7c(NotifyCollectionChangedEventArgs #Lg)
		{
			if (!true)
			{
				goto IL_20;
			}
			if (!this.IsNotificationSuspended)
			{
				NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler = this.#a;
				if (notifyCollectionChangedEventHandler == null)
				{
					goto IL_20;
				}
				if (false)
				{
					goto IL_20;
				}
				notifyCollectionChangedEventHandler(this, #Lg);
				goto IL_20;
			}
			return;
			IL_20:
			if (false)
			{
				return;
			}
			PropertyChangingEventArgs #He = new PropertyChangingEventArgs(#Phc.#3hc(107264282));
			if (6 != 0)
			{
				this.#TXc(#He);
			}
			if (!false)
			{
				return;
			}
		}

		// Token: 0x06006C5B RID: 27739 RVA: 0x001A2B40 File Offset: 0x001A0D40
		protected virtual void #O7c(NotifyCollectionChangedEventArgs #Lg)
		{
			while (!false && !this.IsNotificationSuspended)
			{
				if (4 != 0)
				{
					if (!false)
					{
						this.#FIc();
					}
					NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler = this.#b;
					if (notifyCollectionChangedEventHandler != null)
					{
						if (3 != 0)
						{
							notifyCollectionChangedEventHandler(this, #Lg);
						}
					}
					IL_2B:
					string #em = #Phc.#3hc(107264282);
					if (-1 != 0)
					{
						this.#Fkb(#em);
					}
					return;
				}
			}
			if (7 != 0)
			{
				return;
			}
			goto IL_2B;
		}

		// Token: 0x06006C5C RID: 27740 RVA: 0x00054F1A File Offset: 0x0005311A
		protected virtual void #P7c(#O6c #He)
		{
			EventHandler<#O6c> eventHandler = this.#c;
			if (eventHandler == null)
			{
				return;
			}
			if (!false)
			{
				eventHandler(this, #He);
			}
		}

		// Token: 0x06006C5D RID: 27741 RVA: 0x001A2BA0 File Offset: 0x001A0DA0
		protected override void ClearItems()
		{
			NotifyCollectionChangedAction #nd = NotifyCollectionChangedAction.Reset;
			!0 #Rf = default(!0);
			int? #4jb = null;
			if (6 != 0)
			{
				this.#M7c(#nd, #Rf, #4jb);
			}
			do
			{
				if (2 != 0)
				{
					base.ClearItems();
				}
				NotifyCollectionChangedAction #nd2 = NotifyCollectionChangedAction.Reset;
				!0 #Rf2 = default(!0);
				int? #4jb2 = null;
				if (5 != 0)
				{
					this.#L7c(#nd2, #Rf2, #4jb2);
				}
			}
			while (false || false);
		}

		// Token: 0x06006C5E RID: 27742 RVA: 0x001A2C04 File Offset: 0x001A0E04
		protected override void InsertItem(int index, T item)
		{
			do
			{
				NotifyCollectionChangedAction #nd = NotifyCollectionChangedAction.Add;
				int? #4jb = null;
				if (8 != 0)
				{
					this.#M7c(#nd, item, #4jb);
				}
			}
			while (7 == 0);
			if (!false)
			{
				if (!false)
				{
					base.InsertItem(index, item);
				}
				NotifyCollectionChangedAction #nd2 = NotifyCollectionChangedAction.Add;
				int? #4jb2 = null;
				if (6 != 0)
				{
					this.#L7c(#nd2, item, #4jb2);
				}
			}
		}

		// Token: 0x06006C5F RID: 27743 RVA: 0x001A2C5C File Offset: 0x001A0E5C
		protected override void SetItem(int index, T item)
		{
			if (!false)
			{
				T t = base.Items[index];
				T t2;
				if (6 != 0)
				{
					t2 = t;
				}
				if (8 != 0)
				{
					!0 #Rf = t2;
					if (6 != 0)
					{
						this.#R7c(#Rf);
					}
					NotifyCollectionChangedAction #nd = NotifyCollectionChangedAction.Replace;
					!0 #x3c = t2;
					int? #4jb = new int?(index);
					if (4 != 0)
					{
						this.#M7c(#nd, item, #x3c, #4jb);
					}
				}
				do
				{
					if (!false)
					{
						base.SetItem(index, item);
					}
				}
				while (false);
				NotifyCollectionChangedAction #nd2 = NotifyCollectionChangedAction.Replace;
				!0 #x3c2 = t2;
				int? #4jb2 = new int?(index);
				if (8 != 0)
				{
					this.#L7c(#nd2, item, #x3c2, #4jb2);
				}
			}
		}

		// Token: 0x06006C60 RID: 27744 RVA: 0x001A2CD8 File Offset: 0x001A0ED8
		protected override void RemoveItem(int index)
		{
			if (!false)
			{
				T t2;
				if (!false)
				{
					T t = base[index];
					if (!false)
					{
						t2 = t;
					}
				}
				NotifyCollectionChangedAction #nd = NotifyCollectionChangedAction.Remove;
				!0 #Rf = t2;
				int? #4jb = new int?(index);
				if (3 != 0)
				{
					this.#M7c(#nd, #Rf, #4jb);
				}
				do
				{
					if (-1 != 0)
					{
						base.RemoveItem(index);
					}
				}
				while (2 == 0);
				NotifyCollectionChangedAction #nd2 = NotifyCollectionChangedAction.Remove;
				!0 #Rf2 = t2;
				int? #4jb2 = new int?(index);
				if (6 != 0)
				{
					this.#L7c(#nd2, #Rf2, #4jb2);
				}
			}
		}

		// Token: 0x06006C61 RID: 27745 RVA: 0x00054F36 File Offset: 0x00053136
		protected virtual void #Fkb([CallerMemberName] string #em = null)
		{
			do
			{
				if (!false)
				{
					PropertyChangedEventHandler propertyChangedEventHandler = this.#d;
					if (propertyChangedEventHandler != null)
					{
						PropertyChangedEventArgs e = new PropertyChangedEventArgs(#em);
						if (!false)
						{
							propertyChangedEventHandler(this, e);
						}
						if (!false)
						{
							return;
						}
						continue;
					}
				}
			}
			while (false);
		}

		// Token: 0x06006C62 RID: 27746 RVA: 0x00054F60 File Offset: 0x00053160
		protected virtual void #TXc(PropertyChangingEventArgs #He)
		{
			PropertyChangingEventHandler propertyChangingEventHandler = this.#e;
			if (propertyChangingEventHandler == null)
			{
				return;
			}
			if (!false)
			{
				propertyChangingEventHandler(this, #He);
			}
		}

		// Token: 0x06006C63 RID: 27747 RVA: 0x00054F7C File Offset: 0x0005317C
		private void #Q7c(object #Ge, PropertyChangedEventArgs #He)
		{
			#O6c #He2 = new #O6c(#Ge, #He.PropertyName);
			if (7 != 0)
			{
				this.#P7c(#He2);
			}
		}

		// Token: 0x06006C64 RID: 27748 RVA: 0x001A2D38 File Offset: 0x001A0F38
		private void #R7c(T #Rf)
		{
			for (;;)
			{
				if (!this.DisposeRemovedItems)
				{
					goto IL_22;
				}
				IL_08:
				IDisposable disposable = #Rf as IDisposable;
				IDisposable disposable2;
				if (!false)
				{
					disposable2 = disposable;
				}
				if (false)
				{
					continue;
				}
				if (disposable2 != null)
				{
					IDisposable disposable3 = disposable2;
					if (4 != 0)
					{
						disposable3.Dispose();
					}
				}
				IL_22:
				if (!false)
				{
					break;
				}
				goto IL_08;
			}
		}

		// Token: 0x06006C65 RID: 27749 RVA: 0x001A2D74 File Offset: 0x001A0F74
		private void #FIc()
		{
			if (!false)
			{
				IEnumerator<INotifyPropertyChanged> enumerator = base.Items.OfType<INotifyPropertyChanged>().GetEnumerator();
				IEnumerator<INotifyPropertyChanged> enumerator2;
				if (6 != 0)
				{
					enumerator2 = enumerator;
					goto IL_17;
				}
				try
				{
					for (;;)
					{
						IL_17:
						if (8 != 0)
						{
						}
						while (!false)
						{
							if (!enumerator2.MoveNext())
							{
								goto Block_5;
							}
							INotifyPropertyChanged notifyPropertyChanged = enumerator2.Current;
							PropertyChangedEventHandler value = new PropertyChangedEventHandler(this.#Q7c);
							if (6 != 0)
							{
								notifyPropertyChanged.PropertyChanged -= value;
							}
							PropertyChangedEventHandler value2 = new PropertyChangedEventHandler(this.#Q7c);
							if (4 != 0)
							{
								notifyPropertyChanged.PropertyChanged += value2;
							}
						}
					}
					Block_5:;
				}
				finally
				{
					if (enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
			}
		}

		// Token: 0x04002C18 RID: 11288
		[CompilerGenerated]
		[NonSerialized]
		private NotifyCollectionChangedEventHandler #a;

		// Token: 0x04002C19 RID: 11289
		[CompilerGenerated]
		[NonSerialized]
		private NotifyCollectionChangedEventHandler #b;

		// Token: 0x04002C1A RID: 11290
		[CompilerGenerated]
		[NonSerialized]
		private EventHandler<#O6c> #c;

		// Token: 0x04002C1B RID: 11291
		[CompilerGenerated]
		[NonSerialized]
		private PropertyChangedEventHandler #d;

		// Token: 0x04002C1C RID: 11292
		[CompilerGenerated]
		[NonSerialized]
		private PropertyChangingEventHandler #e;
	}
}
