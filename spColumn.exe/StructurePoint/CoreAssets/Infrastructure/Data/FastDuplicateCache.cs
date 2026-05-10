using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;

namespace StructurePoint.CoreAssets.Infrastructure.Data
{
	// Token: 0x02000EF8 RID: 3832
	public sealed class FastDuplicateCache<TKey, TValue>
	{
		// Token: 0x060087DD RID: 34781 RVA: 0x0006E6DD File Offset: 0x0006C8DD
		public FastDuplicateCache(IComparer<TKey> comparer)
		{
			if (comparer == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107225498));
			}
			this.#a = comparer;
		}

		// Token: 0x17002844 RID: 10308
		// (get) Token: 0x060087DE RID: 34782 RVA: 0x0006E70B File Offset: 0x0006C90B
		public IEnumerable<TValue> Values
		{
			get
			{
				return this.#b.Values.SelectMany(new Func<FastDuplicateCache<!0, !1>.KeyValues, IEnumerable<!1>>(FastDuplicateCache<!0, !1>.<>c.<>9.#R4d));
			}
		}

		// Token: 0x17002845 RID: 10309
		// (get) Token: 0x060087DF RID: 34783 RVA: 0x0006E73C File Offset: 0x0006C93C
		public IEnumerable<TKey> Keys
		{
			get
			{
				return this.#b.Values.SelectMany(new Func<FastDuplicateCache<!0, !1>.KeyValues, IEnumerable<!0>>(FastDuplicateCache<!0, !1>.<>c.<>9.#U4d));
			}
		}

		// Token: 0x060087E0 RID: 34784 RVA: 0x0006E76D File Offset: 0x0006C96D
		public bool #x3d()
		{
			return this.#y3d().ToList<KeyValuePair<TKey, FastDuplicateCache<TKey, TValue>.KeyValues>>().Any<KeyValuePair<TKey, FastDuplicateCache<TKey, TValue>.KeyValues>>();
		}

		// Token: 0x060087E1 RID: 34785 RVA: 0x0006E77F File Offset: 0x0006C97F
		private IEnumerable<KeyValuePair<TKey, FastDuplicateCache<TKey, TValue>.KeyValues>> #y3d()
		{
			return this.#b.Where(new Func<KeyValuePair<!0, FastDuplicateCache<!0, !1>.KeyValues>, bool>(FastDuplicateCache<!0, !1>.<>c.<>9.#W4d));
		}

		// Token: 0x060087E2 RID: 34786 RVA: 0x001D1934 File Offset: 0x001CFB34
		public void #z3d(TKey #6cc, TValue #f)
		{
			FastDuplicateCache<TKey, TValue>.KeyValues keyValues;
			if (!this.#b.TryGetValue(#6cc, out keyValues))
			{
				FastDuplicateCache<TKey, TValue>.KeyValues keyValues2 = new FastDuplicateCache<!0, !1>.KeyValues(this.#a);
				if (-1 != 0)
				{
					keyValues = keyValues2;
				}
				Dictionary<!0, FastDuplicateCache<!0, !1>.KeyValues> dictionary = this.#b;
				FastDuplicateCache<!0, !1>.KeyValues value = keyValues;
				if (!false)
				{
					dictionary[#6cc] = value;
				}
			}
			FastDuplicateCache<!0, !1>.KeyValues keyValues3 = keyValues;
			if (5 != 0)
			{
				keyValues3.#z3d(#6cc, #f);
			}
		}

		// Token: 0x060087E3 RID: 34787 RVA: 0x001D1988 File Offset: 0x001CFB88
		public bool #7tc(TKey #6cc)
		{
			FastDuplicateCache<TKey, TValue>.KeyValues keyValues;
			if (!false)
			{
				int num = this.#b.TryGetValue(#6cc, out keyValues) ? 1 : 0;
				while (num == 0 && 3 != 0)
				{
					int num2 = num = 0;
					if (num2 == 0)
					{
						return num2 != 0;
					}
				}
			}
			return keyValues.#7tc(#6cc);
		}

		// Token: 0x060087E4 RID: 34788 RVA: 0x001D19B8 File Offset: 0x001CFBB8
		public bool #A3d(TKey #6cc, out TValue #f)
		{
			FastDuplicateCache<TKey, TValue>.KeyValues keyValues;
			do
			{
				#f = default(!1);
				if (!this.#b.TryGetValue(#6cc, out keyValues))
				{
					goto IL_23;
				}
			}
			while (false);
			int result = keyValues.#Q4d(#6cc, out #f) ? 1 : 0;
			return result != 0;
			IL_23:
			int num = result = 0;
			if (num != 0)
			{
				return result != 0;
			}
			result = num;
			if (num == 0)
			{
				return num != 0;
			}
			return result != 0;
		}

		// Token: 0x060087E5 RID: 34789 RVA: 0x001D19F0 File Offset: 0x001CFBF0
		public TValue #F1d(TKey #6cc)
		{
			TValue result;
			if (4 != 0)
			{
				FastDuplicateCache<TKey, TValue>.KeyValues keyValues;
				if (this.#b.TryGetValue(#6cc, out keyValues))
				{
					if (!false)
					{
						return keyValues.#3hc(#6cc);
					}
				}
				else if (6 != 0)
				{
					result = default(!1);
				}
			}
			return result;
		}

		// Token: 0x060087E6 RID: 34790 RVA: 0x001D1A28 File Offset: 0x001CFC28
		public bool #F7c(TKey #6cc)
		{
			bool flag = false;
			bool result;
			if (7 != 0)
			{
				result = flag;
			}
			FastDuplicateCache<TKey, TValue>.KeyValues keyValues;
			if (this.#b.TryGetValue(#6cc, out keyValues))
			{
				bool flag2 = keyValues.#F7c(#6cc);
				if (!false)
				{
					result = flag2;
				}
				if (keyValues.#P4d())
				{
					this.#b.Remove(#6cc);
				}
			}
			return result;
		}

		// Token: 0x060087E7 RID: 34791 RVA: 0x0006E7AB File Offset: 0x0006C9AB
		public void #yl()
		{
			Dictionary<!0, FastDuplicateCache<!0, !1>.KeyValues> dictionary = this.#b;
			if (!false)
			{
				dictionary.Clear();
			}
		}

		// Token: 0x04003807 RID: 14343
		private readonly IComparer<TKey> #a;

		// Token: 0x04003808 RID: 14344
		private readonly Dictionary<TKey, FastDuplicateCache<TKey, TValue>.KeyValues> #b = new Dictionary<!0, FastDuplicateCache<!0, !1>.KeyValues>();

		// Token: 0x02000EF9 RID: 3833
		private sealed class KeyValue
		{
			// Token: 0x17002846 RID: 10310
			// (get) Token: 0x060087E8 RID: 34792 RVA: 0x0006E7BE File Offset: 0x0006C9BE
			// (set) Token: 0x060087E9 RID: 34793 RVA: 0x0006E7C6 File Offset: 0x0006C9C6
			public TKey Key { get; set; }

			// Token: 0x17002847 RID: 10311
			// (get) Token: 0x060087EA RID: 34794 RVA: 0x0006E7CF File Offset: 0x0006C9CF
			// (set) Token: 0x060087EB RID: 34795 RVA: 0x0006E7D7 File Offset: 0x0006C9D7
			public TValue Value { get; set; }

			// Token: 0x04003809 RID: 14345
			[CompilerGenerated]
			private TKey #a;

			// Token: 0x0400380A RID: 14346
			[CompilerGenerated]
			private TValue #b;
		}

		// Token: 0x02000EFA RID: 3834
		private sealed class KeyValues
		{
			// Token: 0x060087ED RID: 34797 RVA: 0x0006E7E0 File Offset: 0x0006C9E0
			public KeyValues(IComparer<TKey> comparer)
			{
				if (comparer == null)
				{
					throw new ArgumentNullException(#Phc.#3hc(107225498));
				}
				this.#a = comparer;
			}

			// Token: 0x17002848 RID: 10312
			// (get) Token: 0x060087EE RID: 34798 RVA: 0x0006E80E File Offset: 0x0006CA0E
			public List<FastDuplicateCache<TKey, TValue>.KeyValue> Values { get; } = new List<FastDuplicateCache<!0, !1>.KeyValue>();

			// Token: 0x060087EF RID: 34799 RVA: 0x0006E816 File Offset: 0x0006CA16
			public bool #P4d()
			{
				return this.Values.Count == 0;
			}

			// Token: 0x060087F0 RID: 34800 RVA: 0x001D1A74 File Offset: 0x001CFC74
			public bool #Q4d(TKey #6cc, out TValue #f)
			{
				if (!false)
				{
					FastDuplicateCache<TKey, TValue>.KeyValues.#ITb #ITb = new FastDuplicateCache<!0, !1>.KeyValues.#ITb();
					FastDuplicateCache<TKey, TValue>.KeyValues.#ITb #ITb2;
					if (6 != 0)
					{
						#ITb2 = #ITb;
					}
					#ITb2.#a = this;
					FastDuplicateCache<TKey, TValue>.KeyValue keyValue2;
					if (8 != 0)
					{
						#ITb2.#b = #6cc;
						#f = default(!1);
						FastDuplicateCache<TKey, TValue>.KeyValue keyValue = this.Values.FirstOrDefault(new Func<FastDuplicateCache<!0, !1>.KeyValue, bool>(#ITb2.#X4d));
						if (6 != 0)
						{
							keyValue2 = keyValue;
						}
					}
					while (keyValue2 != null)
					{
						if (!false)
						{
							#f = keyValue2.Value;
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x060087F1 RID: 34801 RVA: 0x001D1ADC File Offset: 0x001CFCDC
			public TValue #3hc(TKey #6cc)
			{
				FastDuplicateCache<TKey, TValue>.KeyValues.#92b #92b = new FastDuplicateCache<!0, !1>.KeyValues.#92b();
				FastDuplicateCache<TKey, TValue>.KeyValues.#92b #92b2;
				if (4 != 0)
				{
					#92b2 = #92b;
				}
				#92b2.#a = this;
				#92b2.#b = #6cc;
				FastDuplicateCache<TKey, TValue>.KeyValue keyValue = this.Values.FirstOrDefault(new Func<FastDuplicateCache<!0, !1>.KeyValue, bool>(#92b2.#Y4d));
				FastDuplicateCache<TKey, TValue>.KeyValue keyValue2;
				if (!false)
				{
					keyValue2 = keyValue;
				}
				if (keyValue2 == null)
				{
					return default(!1);
				}
				return keyValue2.Value;
			}

			// Token: 0x060087F2 RID: 34802 RVA: 0x001D1B34 File Offset: 0x001CFD34
			public bool #7tc(TKey #6cc)
			{
				FastDuplicateCache<TKey, TValue>.KeyValues.#W9b #W9b2;
				do
				{
					FastDuplicateCache<TKey, TValue>.KeyValues.#W9b #W9b = new FastDuplicateCache<!0, !1>.KeyValues.#W9b();
					if (!false)
					{
						#W9b2 = #W9b;
					}
					#W9b2.#a = this;
					#W9b2.#b = #6cc;
				}
				while (false);
				return this.Values.Any(new Func<FastDuplicateCache<!0, !1>.KeyValue, bool>(#W9b2.#Z4d));
			}

			// Token: 0x060087F3 RID: 34803 RVA: 0x001D1B78 File Offset: 0x001CFD78
			public void #z3d(TKey #6cc, TValue #f)
			{
				FastDuplicateCache<TKey, TValue>.KeyValues.#s0b #s0b = new FastDuplicateCache<!0, !1>.KeyValues.#s0b();
				FastDuplicateCache<TKey, TValue>.KeyValues.#s0b #s0b2;
				if (8 != 0)
				{
					#s0b2 = #s0b;
				}
				do
				{
					#s0b2.#a = this;
				}
				while (7 == 0);
				#s0b2.#b = #6cc;
				FastDuplicateCache<TKey, TValue>.KeyValue keyValue = this.Values.FirstOrDefault(new Func<FastDuplicateCache<!0, !1>.KeyValue, bool>(#s0b2.#04d));
				FastDuplicateCache<TKey, TValue>.KeyValue keyValue2;
				if (4 != 0)
				{
					keyValue2 = keyValue;
				}
				if (keyValue2 == null)
				{
					FastDuplicateCache<TKey, TValue>.KeyValue keyValue3 = new FastDuplicateCache<!0, !1>.KeyValue();
					if (8 != 0)
					{
						keyValue2 = keyValue3;
					}
					List<FastDuplicateCache<!0, !1>.KeyValue> list = this.Values;
					FastDuplicateCache<!0, !1>.KeyValue item = keyValue2;
					if (2 != 0)
					{
						list.Add(item);
					}
				}
				do
				{
					FastDuplicateCache<!0, !1>.KeyValue keyValue4 = keyValue2;
					!0 #f2 = #s0b2.#b;
					if (!false)
					{
						keyValue4.Key = #f2;
					}
					FastDuplicateCache<!0, !1>.KeyValue keyValue5 = keyValue2;
					if (5 != 0)
					{
						keyValue5.Value = #f;
					}
				}
				while (!true);
			}

			// Token: 0x060087F4 RID: 34804 RVA: 0x001D1C08 File Offset: 0x001CFE08
			public bool #F7c(TKey #6cc)
			{
				int num2;
				int num4;
				int num6;
				if (2 != 0)
				{
					int num = num2 = this.Values.Count;
					int num3 = num4 = 1;
					if (num3 == 0)
					{
						goto IL_53;
					}
					int num5 = num - num3;
					if (-1 != 0)
					{
						num6 = num5;
					}
					if (!false)
					{
						goto IL_58;
					}
					goto IL_58;
				}
				IL_1C:
				FastDuplicateCache<TKey, TValue>.KeyValue keyValue = this.Values[num6];
				FastDuplicateCache<TKey, TValue>.KeyValue keyValue2;
				if (!false)
				{
					keyValue2 = keyValue;
				}
				int result;
				if (this.#a.Compare(keyValue2.Key, #6cc) == 0)
				{
					List<FastDuplicateCache<!0, !1>.KeyValue> list = this.Values;
					int index = num6;
					if (true)
					{
						list.RemoveAt(index);
					}
					result = 1;
				}
				else
				{
					num2 = (result = num6);
					if (5 != 0)
					{
						num4 = 1;
						goto IL_53;
					}
				}
				return result != 0;
				IL_53:
				int num7 = num2 - num4;
				if (!false)
				{
					num6 = num7;
				}
				IL_58:
				if (num6 < 0)
				{
					return false;
				}
				goto IL_1C;
			}

			// Token: 0x0400380B RID: 14347
			private readonly IComparer<TKey> #a;

			// Token: 0x0400380C RID: 14348
			[CompilerGenerated]
			private readonly List<FastDuplicateCache<TKey, TValue>.KeyValue> #b;

			// Token: 0x02000EFB RID: 3835
			[CompilerGenerated]
			private sealed class #ITb
			{
				// Token: 0x060087F6 RID: 34806 RVA: 0x0006E826 File Offset: 0x0006CA26
				internal bool #X4d(FastDuplicateCache<#M5c, #d3c>.KeyValue #Rf)
				{
					return this.#a.#a.Compare(#Rf.Key, this.#b) == 0;
				}

				// Token: 0x0400380D RID: 14349
				public FastDuplicateCache<#M5c, #d3c>.KeyValues #a;

				// Token: 0x0400380E RID: 14350
				public #M5c #b;
			}

			// Token: 0x02000EFC RID: 3836
			[CompilerGenerated]
			private sealed class #92b
			{
				// Token: 0x060087F8 RID: 34808 RVA: 0x0006E847 File Offset: 0x0006CA47
				internal bool #Y4d(FastDuplicateCache<#M5c, #d3c>.KeyValue #Rf)
				{
					return this.#a.#a.Compare(#Rf.Key, this.#b) == 0;
				}

				// Token: 0x0400380F RID: 14351
				public FastDuplicateCache<#M5c, #d3c>.KeyValues #a;

				// Token: 0x04003810 RID: 14352
				public #M5c #b;
			}

			// Token: 0x02000EFD RID: 3837
			[CompilerGenerated]
			private sealed class #W9b
			{
				// Token: 0x060087FA RID: 34810 RVA: 0x0006E868 File Offset: 0x0006CA68
				internal bool #Z4d(FastDuplicateCache<#M5c, #d3c>.KeyValue #Rf)
				{
					return this.#a.#a.Compare(#Rf.Key, this.#b) == 0;
				}

				// Token: 0x04003811 RID: 14353
				public FastDuplicateCache<#M5c, #d3c>.KeyValues #a;

				// Token: 0x04003812 RID: 14354
				public #M5c #b;
			}

			// Token: 0x02000EFE RID: 3838
			[CompilerGenerated]
			private sealed class #s0b
			{
				// Token: 0x060087FC RID: 34812 RVA: 0x0006E889 File Offset: 0x0006CA89
				internal bool #04d(FastDuplicateCache<#M5c, #d3c>.KeyValue #Rf)
				{
					return this.#a.#a.Compare(#Rf.Key, this.#b) == 0;
				}

				// Token: 0x04003813 RID: 14355
				public FastDuplicateCache<#M5c, #d3c>.KeyValues #a;

				// Token: 0x04003814 RID: 14356
				public #M5c #b;
			}
		}
	}
}
