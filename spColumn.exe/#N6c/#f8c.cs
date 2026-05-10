using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using #7hc;

namespace #N6c
{
	// Token: 0x02000CFE RID: 3326
	[DebuggerDisplay("Count: {Count}")]
	internal sealed class #f8c<#Fu> : IEnumerable, IEnumerable<!0>, IReadOnlyCollection<!0>, ISet<!0>, ICollection<!0>, #Z7c<!0>, #37c<!0>, #47c<!0>
	{
		// Token: 0x06006C9A RID: 27802 RVA: 0x00055158 File Offset: 0x00053358
		public #f8c() : this(EqualityComparer<!0>.Default)
		{
		}

		// Token: 0x06006C9B RID: 27803 RVA: 0x00055165 File Offset: 0x00053365
		public #f8c(IEqualityComparer<#Fu> #AC)
		{
			this.#a = new Dictionary<!0, LinkedListNode<!0>>(#AC);
			this.#b = new LinkedList<!0>();
		}

		// Token: 0x06006C9C RID: 27804 RVA: 0x00055184 File Offset: 0x00053384
		public #f8c(IEnumerable<#Fu> #Du) : this(#Du, EqualityComparer<!0>.Default)
		{
		}

		// Token: 0x06006C9D RID: 27805 RVA: 0x001A3894 File Offset: 0x001A1A94
		public #f8c(IEnumerable<#Fu> #Du, IEqualityComparer<#Fu> #AC) : this(#AC)
		{
			foreach (#Fu item in #Du)
			{
				this.Add(item);
			}
		}

		// Token: 0x17001DAA RID: 7594
		// (get) Token: 0x06006C9E RID: 27806 RVA: 0x00055192 File Offset: 0x00053392
		public int Count
		{
			get
			{
				return this.#a.Count;
			}
		}

		// Token: 0x17001DAB RID: 7595
		// (get) Token: 0x06006C9F RID: 27807 RVA: 0x0005519F File Offset: 0x0005339F
		public bool IsReadOnly
		{
			get
			{
				return this.#a.IsReadOnly;
			}
		}

		// Token: 0x17001DAC RID: 7596
		public #Fu this[int #4jb]
		{
			get
			{
				return this.#b.ElementAt(#4jb);
			}
		}

		// Token: 0x06006CA1 RID: 27809 RVA: 0x000551BA File Offset: 0x000533BA
		public void #yl()
		{
			LinkedList<!0> linkedList = this.#b;
			if (7 != 0)
			{
				linkedList.Clear();
			}
			ICollection<KeyValuePair<!0, LinkedListNode<!0>>> collection = this.#a;
			if (!false)
			{
				collection.Clear();
			}
		}

		// Token: 0x06006CA2 RID: 27810 RVA: 0x001A38E4 File Offset: 0x001A1AE4
		public void #pR(IEnumerable<#Fu> #8f)
		{
			if (!false)
			{
				if (#8f == null)
				{
					throw new ArgumentNullException(#Phc.#3hc(107264273));
				}
				IEnumerator<#Fu> enumerator = #8f.GetEnumerator();
				IEnumerator<#Fu> enumerator2;
				if (!false)
				{
					enumerator2 = enumerator;
				}
				try
				{
					for (;;)
					{
						bool flag = enumerator2.MoveNext();
						if (!false)
						{
							if (!flag)
							{
								break;
							}
							#Fu #Fu = enumerator2.Current;
							#Fu item;
							if (!false)
							{
								item = #Fu;
							}
							if (!true)
							{
								break;
							}
							this.Add(item);
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
			}
		}

		// Token: 0x06006CA3 RID: 27811 RVA: 0x001A3958 File Offset: 0x001A1B58
		public bool #27c(#Fu #x3c, #Fu #y3c)
		{
			LinkedListNode<#Fu> linkedListNode;
			bool result;
			bool flag = result = this.#a.TryGetValue(#x3c, out linkedListNode);
			if (!false)
			{
				bool flag2;
				if (flag)
				{
					LinkedListNode<!0> linkedListNode2 = linkedListNode;
					if (3 != 0)
					{
						linkedListNode2.Value = #y3c;
					}
					flag2 = this.#a.Remove(#x3c);
					if (!false)
					{
						IDictionary<!0, LinkedListNode<!0>> dictionary = this.#a;
						LinkedListNode<!0> value = linkedListNode;
						if (!false)
						{
							dictionary[#y3c] = value;
						}
						return true;
					}
				}
				else
				{
					flag2 = false;
				}
				bool flag3 = result = flag2;
				if (!flag3)
				{
					return flag3;
				}
			}
			return result;
		}

		// Token: 0x06006CA4 RID: 27812 RVA: 0x001A39B4 File Offset: 0x001A1BB4
		public bool #F7c(#Fu #Rf)
		{
			int num2;
			LinkedListNode<#Fu> linkedListNode;
			if (#Rf == null)
			{
				int num = num2 = 0;
				if (num == 0)
				{
					return num != 0;
				}
			}
			else
			{
				num2 = (this.#a.TryGetValue(#Rf, out linkedListNode) ? 1 : 0);
			}
			if (num2 == 0)
			{
				if (!false)
				{
					return false;
				}
			}
			else
			{
				if (!false)
				{
					this.#a.Remove(#Rf);
				}
				LinkedList<!0> linkedList = this.#b;
				LinkedListNode<!0> node = linkedListNode;
				if (!false)
				{
					linkedList.Remove(node);
				}
			}
			return true;
		}

		// Token: 0x06006CA5 RID: 27813 RVA: 0x000551DE File Offset: 0x000533DE
		public IEnumerator<#Fu> #67c()
		{
			return this.#b.GetEnumerator();
		}

		// Token: 0x06006CA6 RID: 27814 RVA: 0x000551F0 File Offset: 0x000533F0
		public bool Contains(#Fu item)
		{
			return item != null && this.#a.ContainsKey(item);
		}

		// Token: 0x06006CA7 RID: 27815 RVA: 0x00055208 File Offset: 0x00053408
		public void #77c(#Fu[] #87c, int #97c)
		{
			LinkedList<!0> linkedList = this.#b;
			if (!false)
			{
				linkedList.CopyTo(#87c, #97c);
			}
		}

		// Token: 0x06006CA8 RID: 27816 RVA: 0x001A3A08 File Offset: 0x001A1C08
		public bool Add(#Fu item)
		{
			if (item != null)
			{
				while (!false && !this.#a.ContainsKey(item))
				{
					LinkedListNode<#Fu> linkedListNode2;
					if (!false)
					{
						LinkedListNode<#Fu> linkedListNode = this.#b.AddLast(item);
						if (!false)
						{
							linkedListNode2 = linkedListNode;
						}
					}
					IDictionary<!0, LinkedListNode<!0>> dictionary = this.#a;
					LinkedListNode<!0> value = linkedListNode2;
					if (!false)
					{
						dictionary.Add(item, value);
					}
					if (-1 != 0)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06006CA9 RID: 27817 RVA: 0x001A3A60 File Offset: 0x001A1C60
		public void #a8c(IEnumerable<#Fu> #L0)
		{
			if (!false)
			{
				if (#L0 == null)
				{
					throw new ArgumentNullException(#Phc.#3hc(107399401));
				}
				IEnumerator<#Fu> enumerator = #L0.GetEnumerator();
				IEnumerator<#Fu> enumerator2;
				if (!false)
				{
					enumerator2 = enumerator;
				}
				try
				{
					for (;;)
					{
						bool flag = enumerator2.MoveNext();
						if (!false)
						{
							if (!flag)
							{
								break;
							}
							#Fu #Fu = enumerator2.Current;
							#Fu item;
							if (!false)
							{
								item = #Fu;
							}
							if (!true)
							{
								break;
							}
							this.Add(item);
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
			}
		}

		// Token: 0x06006CAA RID: 27818 RVA: 0x001A3AD4 File Offset: 0x001A1CD4
		public void #b8c(IEnumerable<#Fu> #L0)
		{
			IEnumerator<#Fu> enumerator = #L0.GetEnumerator();
			IEnumerator<#Fu> enumerator2;
			if (5 != 0)
			{
				enumerator2 = enumerator;
			}
			try
			{
				for (;;)
				{
					bool flag = enumerator2.MoveNext();
					if (4 != 0)
					{
						if (!flag)
						{
							break;
						}
						#Fu #Fu = enumerator2.Current;
						#Fu #Fu2;
						if (4 != 0)
						{
							#Fu2 = #Fu;
						}
						bool flag2 = this.Contains(#Fu2);
						if (-1 != 0)
						{
							if (!flag2)
							{
								this.#F7c(#Fu2);
							}
						}
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
		}

		// Token: 0x06006CAB RID: 27819 RVA: 0x001A3B3C File Offset: 0x001A1D3C
		public void #c8c(IEnumerable<#Fu> #L0)
		{
			if (-1 != 0)
			{
				IEnumerator<#Fu> enumerator = #L0.GetEnumerator();
				IEnumerator<#Fu> enumerator2;
				if (6 != 0)
				{
					enumerator2 = enumerator;
				}
				try
				{
					for (;;)
					{
						if (!enumerator2.MoveNext())
						{
							if (!false && !false)
							{
								break;
							}
						}
						else
						{
							#Fu #Fu = enumerator2.Current;
							#Fu #Rf;
							if (6 != 0)
							{
								#Rf = #Fu;
							}
							this.#F7c(#Rf);
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
			}
		}

		// Token: 0x06006CAC RID: 27820 RVA: 0x001A3B9C File Offset: 0x001A1D9C
		public void #d8c(IEnumerable<#Fu> #L0)
		{
			if (3 != 0 && #L0 != null && 2 != 0)
			{
				IEnumerator<#Fu> enumerator = #L0.GetEnumerator();
				IEnumerator<#Fu> enumerator2;
				if (!false)
				{
					enumerator2 = enumerator;
				}
				try
				{
					do
					{
						if (!enumerator2.MoveNext())
						{
							goto IL_55;
						}
						#Fu #Fu = enumerator2.Current;
						#Fu #Fu2;
						if (!false)
						{
							#Fu2 = #Fu;
						}
						if (false)
						{
							goto IL_55;
						}
						if (this.Contains(#Fu2))
						{
							this.#F7c(#Fu2);
						}
						else
						{
							this.Add(#Fu2);
						}
						continue;
						IL_55:;
					}
					while (false);
				}
				finally
				{
					if (enumerator2 != null)
					{
						enumerator2.Dispose();
					}
				}
				return;
			}
			throw new ArgumentNullException(#Phc.#3hc(107399401));
		}

		// Token: 0x06006CAD RID: 27821 RVA: 0x0005521F File Offset: 0x0005341F
		public bool IsSubsetOf(IEnumerable<#Fu> other)
		{
			int num;
			if (!true || false || other == null)
			{
				num = 107399401;
			}
			else
			{
				bool result = (num = (new HashSet<!0>(other).IsSupersetOf(this) ? 1 : 0)) != 0;
				if (!false)
				{
					return result;
				}
			}
			throw new ArgumentNullException(#Phc.#3hc(num));
		}

		// Token: 0x06006CAE RID: 27822 RVA: 0x00055249 File Offset: 0x00053449
		public bool IsSupersetOf(IEnumerable<#Fu> other)
		{
			if ((8 == 0 || 5 == 0 || other != null) && 2 != 0)
			{
				return other.All(new Func<!0, bool>(this.Contains));
			}
			throw new ArgumentNullException(#Phc.#3hc(107399401));
		}

		// Token: 0x06006CAF RID: 27823 RVA: 0x0005527A File Offset: 0x0005347A
		public bool IsProperSupersetOf(IEnumerable<#Fu> other)
		{
			int num;
			if (!true || false || other == null)
			{
				num = 107399401;
			}
			else
			{
				bool result = (num = (new HashSet<!0>(other).IsProperSubsetOf(this) ? 1 : 0)) != 0;
				if (!false)
				{
					return result;
				}
			}
			throw new ArgumentNullException(#Phc.#3hc(num));
		}

		// Token: 0x06006CB0 RID: 27824 RVA: 0x000552A4 File Offset: 0x000534A4
		public bool IsProperSubsetOf(IEnumerable<#Fu> other)
		{
			int num;
			if (!true || false || other == null)
			{
				num = 107399401;
			}
			else
			{
				bool result = (num = (new HashSet<!0>(other).IsProperSupersetOf(this) ? 1 : 0)) != 0;
				if (!false)
				{
					return result;
				}
			}
			throw new ArgumentNullException(#Phc.#3hc(num));
		}

		// Token: 0x06006CB1 RID: 27825 RVA: 0x000552CE File Offset: 0x000534CE
		public bool Overlaps(IEnumerable<#Fu> other)
		{
			while (other == null)
			{
				if (!false)
				{
					throw new ArgumentNullException(#Phc.#3hc(107399401));
				}
			}
			do
			{
				bool flag = this.Count != 0;
				while (flag)
				{
					bool result = flag = other.Any(new Func<!0, bool>(this.Contains));
					if (!false)
					{
						return result;
					}
				}
			}
			while (false);
			return false;
		}

		// Token: 0x06006CB2 RID: 27826 RVA: 0x00055309 File Offset: 0x00053509
		public bool SetEquals(IEnumerable<#Fu> other)
		{
			int num;
			if (!true || false || other == null)
			{
				num = 107399401;
			}
			else
			{
				bool result = (num = (new HashSet<!0>(other).SetEquals(this) ? 1 : 0)) != 0;
				if (!false)
				{
					return result;
				}
			}
			throw new ArgumentNullException(#Phc.#3hc(num));
		}

		// Token: 0x06006CB3 RID: 27827 RVA: 0x00055333 File Offset: 0x00053533
		void ICollection<!0>.#e8c(#Fu #Rf)
		{
			this.Add(#Rf);
		}

		// Token: 0x06006CB4 RID: 27828 RVA: 0x0005533D File Offset: 0x0005353D
		IEnumerator IEnumerable.#NXb()
		{
			return this.#67c();
		}

		// Token: 0x04002C2D RID: 11309
		private readonly IDictionary<#Fu, LinkedListNode<#Fu>> #a;

		// Token: 0x04002C2E RID: 11310
		private readonly LinkedList<#Fu> #b;
	}
}
