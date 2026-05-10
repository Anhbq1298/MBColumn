using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.GUI.Framework.Collections;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #N6c
{
	// Token: 0x02000CF6 RID: 3318
	internal sealed class #66c<#76c, #86c> : CustomObservableCollection<!1>
	{
		// Token: 0x06006C6C RID: 27756 RVA: 0x001A2E00 File Offset: 0x001A1000
		[SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public #66c(IEnumerable<#76c> #Ic, INotifyCollectionChanged #96c, Func<#76c, #86c> #a7c, bool #b7c, Func<#76c, bool> #c7c)
		{
			#X0d.#V0d(#Ic, #Phc.#3hc(107457469), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107264485));
			#X0d.#V0d(#a7c, #Phc.#3hc(107264464), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107264419));
			#X0d.#V0d(#96c, #Phc.#3hc(107264366), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107264333));
			this.#e = new Dictionary<!0, !1>();
			this.#a = #Ic;
			this.#b = #a7c;
			this.#d = #b7c;
			this.#c = #c7c;
			#96c.CollectionChanged += this.#W6c;
			this.#Y6c();
		}

		// Token: 0x06006C6D RID: 27757 RVA: 0x00054F97 File Offset: 0x00053197
		public void #V6c(object #y3c)
		{
			if (this.#e.ContainsKey((!0)((object)#y3c)) && 4 != 0)
			{
				this.#Y6c();
			}
		}

		// Token: 0x06006C6E RID: 27758 RVA: 0x001A2EA8 File Offset: 0x001A10A8
		private void #W6c(object #Ge, NotifyCollectionChangedEventArgs #He)
		{
			int num;
			bool flag = (num = (base.IsNotificationSuspended ? 1 : 0)) != 0;
			if (5 != 0)
			{
				if (flag)
				{
					return;
				}
				NotifyCollectionChangedAction action = #He.Action;
				NotifyCollectionChangedAction notifyCollectionChangedAction;
				if (!false)
				{
					notifyCollectionChangedAction = action;
				}
				switch (notifyCollectionChangedAction)
				{
				case NotifyCollectionChangedAction.Add:
					if (#He.NewItems != null && #He.NewItems.Count == 1)
					{
						#76c #76c = (!0)((object)#He.NewItems[0]);
						#76c #76c2;
						if (!false)
						{
							#76c2 = #76c;
						}
						!0 #36c = #76c2;
						if (!false)
						{
							this.#26c(#36c);
						}
						if (!this.#e.ContainsKey(#76c2) && this.#56c(#76c2))
						{
							#86c #86c = this.#lpc(#76c2);
							#86c #86c2;
							if (5 != 0)
							{
								#86c2 = #86c;
							}
							!1 item = #86c2;
							if (!false)
							{
								base.Add(item);
							}
							NotifyCollectionChangedAction #nd = NotifyCollectionChangedAction.Add;
							!1 #Rf = #86c2;
							int? #4jb = new int?(base.#C7c(#86c2));
							if (6 != 0)
							{
								base.#L7c(#nd, #Rf, #4jb);
							}
						}
						return;
					}
					goto IL_215;
				case NotifyCollectionChangedAction.Remove:
					if (#He.OldItems != null && #He.OldItems.Count == 1 && this.#e.ContainsKey((!0)((object)#He.OldItems[0])))
					{
						#76c #76c3 = (!0)((object)#He.OldItems[0]);
						this.#46c(#76c3);
						#86c #86c3 = this.#e[#76c3];
						int num2 = base.#C7c(#86c3);
						base.RemoveAt(num2);
						this.#e.Remove(#76c3);
						base.#L7c(NotifyCollectionChangedAction.Remove, #86c3, new int?(num2));
						return;
					}
					goto IL_215;
				case NotifyCollectionChangedAction.Replace:
					if (#He.NewItems != null && #He.NewItems.Count == 1 && #He.OldItems != null && #He.OldItems.Count == 1 && #He.OldStartingIndex == #He.NewStartingIndex)
					{
						this.#X6c(base[#He.OldStartingIndex]);
						base[#He.OldStartingIndex] = this.#lpc((!0)((object)#He.NewItems[0]));
						return;
					}
					goto IL_215;
				case NotifyCollectionChangedAction.Move:
					if (#He.NewItems == null || #He.NewItems.Count != 1 || #He.OldItems == null)
					{
						goto IL_215;
					}
					num = #He.OldItems.Count;
					break;
				default:
					goto IL_215;
				}
			}
			if (num == 1)
			{
				this.#V6c(#He.NewItems[0]);
				return;
			}
			IL_215:
			this.#Y6c();
		}

		// Token: 0x06006C6F RID: 27759 RVA: 0x001A3104 File Offset: 0x001A1304
		private #86c #lpc(#76c #Rf)
		{
			#86c #86c;
			if (this.#e.TryGetValue(#Rf, out #86c))
			{
				goto IL_31;
			}
			IL_10:
			if (!false)
			{
				#86c #86c2 = this.#b(#Rf);
				if (true)
				{
					#86c = #86c2;
				}
			}
			IDictionary<!0, !1> dictionary = this.#e;
			!1 value = #86c;
			if (true)
			{
				dictionary[#Rf] = value;
			}
			IL_31:
			if (-1 != 0)
			{
				return #86c;
			}
			goto IL_10;
		}

		// Token: 0x06006C70 RID: 27760 RVA: 0x001A3150 File Offset: 0x001A1350
		private void #X6c(#86c #Rf)
		{
			#66c<#76c, #86c>.#s0b #s0b = new #66c<!0, !1>.#s0b();
			#66c<#76c, #86c>.#s0b #s0b2;
			if (4 != 0)
			{
				#s0b2 = #s0b;
			}
			#s0b2.#a = #Rf;
			IDisposable disposable = #s0b2.#a as IDisposable;
			IDisposable disposable2;
			if (!false)
			{
				disposable2 = disposable;
			}
			if (disposable2 != null)
			{
				IDisposable disposable3 = disposable2;
				if (!false)
				{
					disposable3.Dispose();
				}
			}
			KeyValuePair<#76c, #86c> keyValuePair = this.#e.First(new Func<KeyValuePair<!0, !1>, bool>(#s0b2.#Acd));
			KeyValuePair<#76c, #86c> keyValuePair2;
			if (!false)
			{
				keyValuePair2 = keyValuePair;
			}
			INotifyPropertyChanged notifyPropertyChanged = keyValuePair2.Key as INotifyPropertyChanged;
			INotifyPropertyChanged notifyPropertyChanged2;
			if (2 != 0)
			{
				notifyPropertyChanged2 = notifyPropertyChanged;
			}
			if (notifyPropertyChanged2 != null)
			{
				INotifyPropertyChanged notifyPropertyChanged3 = notifyPropertyChanged2;
				PropertyChangedEventHandler value = new PropertyChangedEventHandler(this.#06c);
				if (!false)
				{
					notifyPropertyChanged3.PropertyChanged -= value;
				}
			}
			this.#e.Remove(keyValuePair2.Key);
		}

		// Token: 0x06006C71 RID: 27761 RVA: 0x001A3200 File Offset: 0x001A1400
		private void #Y6c()
		{
			if (2 != 0)
			{
				this.#NBc();
			}
			if (8 != 0)
			{
				this.#Z6c();
			}
			do
			{
				IEnumerator<#76c> enumerator = this.#a.GetEnumerator();
				IEnumerator<#76c> enumerator2;
				if (!false)
				{
					enumerator2 = enumerator;
					goto IL_22;
				}
				try
				{
					for (;;)
					{
						IL_22:
						for (;;)
						{
							bool flag2;
							bool flag = flag2 = enumerator2.MoveNext();
							#76c #76c2;
							if (6 != 0)
							{
								if (!flag)
								{
									goto Block_7;
								}
								#76c #76c = enumerator2.Current;
								if (6 != 0)
								{
									#76c2 = #76c;
								}
								if (false)
								{
									goto IL_4C;
								}
								!0 #36c = #76c2;
								if (4 != 0)
								{
									this.#26c(#36c);
								}
								flag2 = this.#56c(#76c2);
							}
							if (!flag2)
							{
								break;
							}
							#86c #86c = this.#lpc(#76c2);
							#86c item;
							if (!false)
							{
								item = #86c;
							}
							IL_4C:
							base.Add(item);
						}
					}
					Block_7:;
				}
				finally
				{
					if (enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
			}
			while (2 == 0);
			this.#OBc();
		}

		// Token: 0x06006C72 RID: 27762 RVA: 0x001A32C0 File Offset: 0x001A14C0
		private void #Z6c()
		{
			do
			{
				IEnumerator<#76c> enumerator = this.#a.GetEnumerator();
				IEnumerator<#76c> enumerator2;
				if (6 != 0)
				{
					enumerator2 = enumerator;
					goto IL_12;
				}
				try
				{
					for (;;)
					{
						IL_12:
						if (4 != 0)
						{
							goto IL_43;
						}
						goto IL_2B;
						IL_4B:
						if (!false)
						{
							break;
						}
						continue;
						IL_2B:
						if (6 == 0)
						{
							goto IL_4B;
						}
						INotifyPropertyChanged notifyPropertyChanged;
						if (notifyPropertyChanged != null)
						{
							INotifyPropertyChanged notifyPropertyChanged2 = notifyPropertyChanged;
							PropertyChangedEventHandler value = new PropertyChangedEventHandler(this.#06c);
							if (!false)
							{
								notifyPropertyChanged2.PropertyChanged -= value;
							}
						}
						IL_43:
						if (!enumerator2.MoveNext())
						{
							goto IL_4B;
						}
						INotifyPropertyChanged notifyPropertyChanged3 = enumerator2.Current as INotifyPropertyChanged;
						if (!true)
						{
							goto IL_2B;
						}
						notifyPropertyChanged = notifyPropertyChanged3;
						goto IL_2B;
					}
				}
				finally
				{
					if (enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
				ICollection<KeyValuePair<!0, !1>> collection = this.#e;
				if (4 != 0)
				{
					collection.Clear();
				}
			}
			while (4 == 0);
			if (7 != 0)
			{
				base.Clear();
			}
		}

		// Token: 0x06006C73 RID: 27763 RVA: 0x001A336C File Offset: 0x001A156C
		private void #06c(object #Ge, PropertyChangedEventArgs #He)
		{
			if (!(#Ge is !0))
			{
				return;
			}
			#76c #76c = (!0)((object)#Ge);
			#76c #76c2;
			if (5 != 0)
			{
				#76c2 = #76c;
			}
			#86c #86c;
			int num2;
			bool flag2;
			if (this.#e.TryGetValue(#76c2, out #86c))
			{
				int num = base.#C7c(#86c);
				if (!false)
				{
					num2 = num;
				}
				if (-1 != 0)
				{
					if (num2 < 0)
					{
						return;
					}
					int index = num2;
					if (8 != 0)
					{
						base.RemoveAt(index);
					}
					bool flag = flag2 = this.#56c(#76c2);
					if (false)
					{
						goto IL_97;
					}
					if (flag)
					{
						goto IL_57;
					}
				}
				this.#e.Remove(#76c2);
				return;
			}
			flag2 = this.#56c(#76c2);
			goto IL_97;
			IL_57:
			#86c #86c2 = this.#b(#76c2);
			#86c #86c3;
			if (!false)
			{
				#86c3 = #86c2;
			}
			int index2 = num2;
			!1 item = #86c3;
			if (8 != 0)
			{
				base.Insert(index2, item);
			}
			IDictionary<!0, !1> dictionary = this.#e;
			!0 key = #76c2;
			!1 value = #86c3;
			if (!false)
			{
				dictionary[key] = value;
			}
			return;
			IL_97:
			if (flag2)
			{
				if (8 == 0)
				{
					goto IL_57;
				}
				bool flag3 = this.#e.ContainsKey(#76c2);
				if (false)
				{
					return;
				}
				if (!flag3 && this.#56c(#76c2))
				{
					#86c item2 = this.#lpc(#76c2);
					base.Add(item2);
				}
			}
		}

		// Token: 0x06006C74 RID: 27764 RVA: 0x001A3470 File Offset: 0x001A1670
		private void #16c(Action<INotifyPropertyChanged> #nd)
		{
			IEnumerator<#86c> enumerator = base.GetEnumerator();
			IEnumerator<#86c> enumerator2;
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

		// Token: 0x06006C75 RID: 27765 RVA: 0x001A34E4 File Offset: 0x001A16E4
		private void #26c(#76c #36c)
		{
			if (!this.#d)
			{
				goto IL_32;
			}
			IL_08:
			INotifyPropertyChanged notifyPropertyChanged2;
			if (8 != 0)
			{
				INotifyPropertyChanged notifyPropertyChanged = #36c as INotifyPropertyChanged;
				if (2 != 0)
				{
					notifyPropertyChanged2 = notifyPropertyChanged;
				}
			}
			if (notifyPropertyChanged2 != null && 7 != 0)
			{
				INotifyPropertyChanged notifyPropertyChanged3 = notifyPropertyChanged2;
				PropertyChangedEventHandler value = new PropertyChangedEventHandler(this.#06c);
				if (true)
				{
					notifyPropertyChanged3.PropertyChanged += value;
				}
			}
			IL_32:
			if (!false)
			{
				return;
			}
			goto IL_08;
		}

		// Token: 0x06006C76 RID: 27766 RVA: 0x001A3530 File Offset: 0x001A1730
		private void #46c(#76c #36c)
		{
			if (!this.#d)
			{
				goto IL_32;
			}
			IL_08:
			INotifyPropertyChanged notifyPropertyChanged2;
			if (8 != 0)
			{
				INotifyPropertyChanged notifyPropertyChanged = #36c as INotifyPropertyChanged;
				if (2 != 0)
				{
					notifyPropertyChanged2 = notifyPropertyChanged;
				}
			}
			if (notifyPropertyChanged2 != null && 7 != 0)
			{
				INotifyPropertyChanged notifyPropertyChanged3 = notifyPropertyChanged2;
				PropertyChangedEventHandler value = new PropertyChangedEventHandler(this.#06c);
				if (true)
				{
					notifyPropertyChanged3.PropertyChanged -= value;
				}
			}
			IL_32:
			if (!false)
			{
				return;
			}
			goto IL_08;
		}

		// Token: 0x06006C77 RID: 27767 RVA: 0x00054FB8 File Offset: 0x000531B8
		private bool #56c(#76c #36c)
		{
			return this.#c(#36c);
		}

		// Token: 0x04002C1F RID: 11295
		private readonly IEnumerable<#76c> #a;

		// Token: 0x04002C20 RID: 11296
		private readonly Func<#76c, #86c> #b;

		// Token: 0x04002C21 RID: 11297
		private readonly Func<#76c, bool> #c;

		// Token: 0x04002C22 RID: 11298
		private readonly bool #d;

		// Token: 0x04002C23 RID: 11299
		private readonly IDictionary<#76c, #86c> #e;

		// Token: 0x02000CF7 RID: 3319
		[CompilerGenerated]
		private sealed class #s0b
		{
			// Token: 0x06006C79 RID: 27769 RVA: 0x00054FC6 File Offset: 0x000531C6
			internal bool #Acd(KeyValuePair<#76c, #86c> #Bcd)
			{
				return #Bcd.Value == this.#a;
			}

			// Token: 0x04002C24 RID: 11300
			public #86c #a;
		}
	}
}
