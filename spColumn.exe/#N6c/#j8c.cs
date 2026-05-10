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
	// Token: 0x02000D00 RID: 3328
	internal sealed class #j8c<#76c, #86c> : CustomObservableCollection<!1>
	{
		// Token: 0x06006CBA RID: 27834 RVA: 0x001A3C24 File Offset: 0x001A1E24
		[SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public #j8c(IEnumerable<#76c> #Ic, INotifyCollectionChanged #96c, Func<#76c, #86c> #a7c, bool #b7c)
		{
			#X0d.#V0d(#Ic, #Phc.#3hc(107457469), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107263596));
			#X0d.#V0d(#a7c, #Phc.#3hc(107264464), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107263575));
			#X0d.#V0d(#96c, #Phc.#3hc(107264366), StructurePoint.CoreAssets.Infrastructure.Exceptions.Component.GUIFramework, #Phc.#3hc(107263490));
			this.#d = new Dictionary<!0, !1>();
			this.#a = #Ic;
			this.#b = #a7c;
			this.#c = #b7c;
			#96c.CollectionChanged += this.#W6c;
			this.#Y6c();
		}

		// Token: 0x06006CBB RID: 27835 RVA: 0x001A3CC4 File Offset: 0x001A1EC4
		private void #W6c(object #Ge, NotifyCollectionChangedEventArgs #He)
		{
			NotifyCollectionChangedAction action = #He.Action;
			NotifyCollectionChangedAction notifyCollectionChangedAction;
			if (!false)
			{
				notifyCollectionChangedAction = action;
			}
			int count;
			int num;
			int num2;
			int num4;
			switch (notifyCollectionChangedAction)
			{
			case NotifyCollectionChangedAction.Add:
				if (#He.NewItems != null && #He.NewItems.Count == 1)
				{
					#76c #76c = (!0)((object)#He.NewItems[0]);
					#76c #76c2;
					if (7 != 0)
					{
						#76c2 = #76c;
					}
					if (!this.#d.ContainsKey(#76c2))
					{
						#86c #86c = this.#lpc(#76c2);
						#86c #86c2;
						if (3 != 0)
						{
							#86c2 = #86c;
						}
						!1 item = #86c2;
						if (3 != 0)
						{
							base.Add(item);
						}
					}
					return;
				}
				goto IL_192;
			case NotifyCollectionChangedAction.Remove:
				if (#He.OldItems == null)
				{
					goto IL_192;
				}
				num = (count = #He.OldItems.Count);
				if (3 != 0)
				{
					num2 = 1;
					goto IL_F5;
				}
				goto IL_14B;
			case NotifyCollectionChangedAction.Replace:
				if (#He.NewItems != null && #He.NewItems.Count == 1)
				{
					goto IL_138;
				}
				goto IL_192;
			case NotifyCollectionChangedAction.Move:
			{
				if (#He.NewItems == null)
				{
					goto IL_192;
				}
				int num3 = num4 = #He.NewItems.Count;
				if (false)
				{
					goto IL_154;
				}
				if (num3 != 1 || #He.OldItems == null)
				{
					goto IL_192;
				}
				int num5 = count = #He.OldItems.Count;
				int num6 = num2 = 1;
				if (num6 == 0)
				{
					goto IL_F5;
				}
				if (num5 != num6)
				{
					goto IL_192;
				}
				int oldStartingIndex = #He.OldStartingIndex;
				int newStartingIndex = #He.NewStartingIndex;
				if (!false)
				{
					this.#V6c(oldStartingIndex, newStartingIndex);
				}
				break;
			}
			default:
				goto IL_192;
			}
			return;
			IL_F5:
			if (count != num2)
			{
				goto IL_192;
			}
			if (false)
			{
				return;
			}
			if (true)
			{
				!1 #Rf = base[#He.OldStartingIndex];
				if (!false)
				{
					this.#X6c(#Rf);
				}
				base.RemoveAt(#He.OldStartingIndex);
				return;
			}
			IL_138:
			if (#He.OldItems == null)
			{
				goto IL_192;
			}
			num = #He.OldItems.Count;
			IL_14B:
			if (num != 1)
			{
				goto IL_192;
			}
			num4 = #He.OldStartingIndex;
			IL_154:
			if (num4 == #He.NewStartingIndex)
			{
				this.#X6c(base[#He.OldStartingIndex]);
				base[#He.OldStartingIndex] = this.#lpc((!0)((object)#He.NewItems[0]));
				return;
			}
			IL_192:
			this.#Y6c();
		}

		// Token: 0x06006CBC RID: 27836 RVA: 0x001A3E9C File Offset: 0x001A209C
		private #86c #lpc(#76c #Rf)
		{
			#86c #86c;
			if (4 != 0)
			{
				if (!this.#d.TryGetValue(#Rf, out #86c))
				{
					goto IL_13;
				}
				return #86c;
			}
			IL_2B:
			while (!false)
			{
				INotifyPropertyChanged notifyPropertyChanged2;
				if (!false)
				{
					INotifyPropertyChanged notifyPropertyChanged = #Rf as INotifyPropertyChanged;
					if (!false)
					{
						notifyPropertyChanged2 = notifyPropertyChanged;
					}
					if (notifyPropertyChanged2 == null)
					{
						goto IL_58;
					}
				}
				if (!false)
				{
					INotifyPropertyChanged notifyPropertyChanged3 = notifyPropertyChanged2;
					PropertyChangedEventHandler value = new PropertyChangedEventHandler(this.#06c);
					if (7 == 0)
					{
						goto IL_58;
					}
					notifyPropertyChanged3.PropertyChanged += value;
					goto IL_58;
				}
			}
			IL_13:
			#86c #86c2 = this.#b(#Rf);
			if (!false)
			{
				#86c = #86c2;
			}
			if (this.#c)
			{
				goto IL_2B;
			}
			IL_58:
			IDictionary<!0, !1> dictionary = this.#d;
			!1 value2 = #86c;
			if (4 != 0)
			{
				dictionary[#Rf] = value2;
			}
			return #86c;
		}

		// Token: 0x06006CBD RID: 27837 RVA: 0x001A3F24 File Offset: 0x001A2124
		private void #X6c(#86c #Rf)
		{
			#j8c<#76c, #86c>.#92b #92b = new #j8c<!0, !1>.#92b();
			#j8c<#76c, #86c>.#92b #92b2;
			if (4 != 0)
			{
				#92b2 = #92b;
			}
			#92b2.#a = #Rf;
			IDisposable disposable = #92b2.#a as IDisposable;
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
			KeyValuePair<#76c, #86c> keyValuePair = this.#d.First(new Func<KeyValuePair<!0, !1>, bool>(#92b2.#Acd));
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
			this.#d.Remove(keyValuePair2.Key);
		}

		// Token: 0x06006CBE RID: 27838 RVA: 0x001A3FD4 File Offset: 0x001A21D4
		private void #Y6c()
		{
			if (8 != 0)
			{
				this.#NBc();
			}
			if (4 != 0)
			{
				this.#Z6c();
			}
			IEnumerator<#76c> enumerator = this.#a.GetEnumerator();
			IEnumerator<#76c> enumerator2;
			if (8 != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				while (enumerator2.MoveNext())
				{
					#76c #76c = enumerator2.Current;
					#76c #Rf;
					if (2 != 0)
					{
						#Rf = #76c;
					}
					#86c #86c = this.#lpc(#Rf);
					#86c #86c2;
					if (!false)
					{
						#86c2 = #86c;
					}
					!1 item = #86c2;
					if (5 != 0)
					{
						base.Add(item);
					}
				}
			}
			finally
			{
				if (enumerator2 != null)
				{
					enumerator2.Dispose();
				}
			}
			do
			{
				if (!false)
				{
					this.#OBc();
				}
			}
			while (!true);
		}

		// Token: 0x06006CBF RID: 27839 RVA: 0x001A4078 File Offset: 0x001A2278
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
				ICollection<KeyValuePair<!0, !1>> collection = this.#d;
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

		// Token: 0x06006CC0 RID: 27840 RVA: 0x001A4124 File Offset: 0x001A2324
		private void #06c(object #Ge, PropertyChangedEventArgs #He)
		{
			if (!(#Ge is !0))
			{
				return;
			}
			#76c #76c = (!0)((object)#Ge);
			#76c #76c2;
			if (6 != 0)
			{
				#76c2 = #76c;
			}
			#86c #86c;
			if (this.#d.TryGetValue(#76c2, out #86c))
			{
				int num = base.#C7c(#86c);
				int num2;
				if (!false)
				{
					num2 = num;
				}
				if (num2 < 0)
				{
					return;
				}
				#86c #86c3;
				if (!false)
				{
					int index = num2;
					if (8 != 0)
					{
						base.RemoveAt(index);
					}
					#86c #86c2 = this.#b(#76c2);
					if (6 != 0)
					{
						#86c3 = #86c2;
					}
				}
				int index2 = num2;
				!1 item = #86c3;
				if (!false)
				{
					base.Insert(index2, item);
				}
				IDictionary<!0, !1> dictionary = this.#d;
				!0 key = #76c2;
				!1 value = #86c3;
				if (!false)
				{
					dictionary[key] = value;
				}
			}
		}

		// Token: 0x04002C2F RID: 11311
		private readonly IEnumerable<#76c> #a;

		// Token: 0x04002C30 RID: 11312
		private readonly Func<#76c, #86c> #b;

		// Token: 0x04002C31 RID: 11313
		private readonly bool #c;

		// Token: 0x04002C32 RID: 11314
		private readonly IDictionary<#76c, #86c> #d;

		// Token: 0x02000D01 RID: 3329
		[CompilerGenerated]
		private sealed class #92b
		{
			// Token: 0x06006CC2 RID: 27842 RVA: 0x00055373 File Offset: 0x00053573
			internal bool #Acd(KeyValuePair<#76c, #86c> #Bcd)
			{
				return #Bcd.Value == this.#a;
			}

			// Token: 0x04002C33 RID: 11315
			public #86c #a;
		}
	}
}
