using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;

namespace StructurePoint.CoreAssets.GUI.Framework.Core
{
	// Token: 0x02000CD6 RID: 3286
	public static class CollectionsComparer
	{
		// Token: 0x06006BBE RID: 27582 RVA: 0x001A06F4 File Offset: 0x0019E8F4
		public static bool #J5c<#M5c, #d3c>(IDictionary<#M5c, #d3c> #dX, IDictionary<#M5c, #d3c> #K5c, IEqualityComparer<#d3c> #L5c)
		{
			while (#dX != #K5c)
			{
				if (#dX != null)
				{
					if (false)
					{
						continue;
					}
					if (#K5c != null)
					{
						if (#dX.Count != #K5c.Count)
						{
							return false;
						}
						IEqualityComparer<#d3c> equalityComparer;
						if ((equalityComparer = #L5c) == null)
						{
							equalityComparer = EqualityComparer<!!1>.Default;
						}
						if (-1 != 0)
						{
							#L5c = equalityComparer;
						}
						for (;;)
						{
							IEnumerator<KeyValuePair<#M5c, #d3c>> enumerator = #dX.GetEnumerator();
							IEnumerator<KeyValuePair<#M5c, #d3c>> enumerator2;
							if (4 != 0)
							{
								enumerator2 = enumerator;
							}
							try
							{
								while (enumerator2.MoveNext())
								{
									KeyValuePair<#M5c, #d3c> keyValuePair = enumerator2.Current;
									KeyValuePair<#M5c, #d3c> keyValuePair2;
									if (!false)
									{
										keyValuePair2 = keyValuePair;
									}
									#d3c y;
									if (!#K5c.TryGetValue(keyValuePair2.Key, out y))
									{
										bool flag = false;
										if (2 != 0)
										{
											bool result = flag;
										}
										goto IL_9C;
									}
									int num;
									bool flag2 = (num = (#L5c.Equals(keyValuePair2.Value, y) ? 1 : 0)) != 0;
									if (5 != 0)
									{
										if (!flag2)
										{
											continue;
										}
										if (false)
										{
											break;
										}
										num = 0;
									}
									if (6 != 0)
									{
										bool result = num != 0;
									}
									goto IL_9C;
								}
							}
							finally
							{
								if (enumerator2 != null)
								{
									enumerator2.Dispose();
								}
							}
							break;
							IL_9C:
							if (!false)
							{
								bool result;
								return result;
							}
						}
						return true;
					}
				}
				return false;
			}
			return true;
		}

		// Token: 0x06006BBF RID: 27583 RVA: 0x001A07C4 File Offset: 0x0019E9C4
		public static bool #N5c<#Fu>(IList<#Fu> #dX, IList<#Fu> #K5c)
		{
			if (#dX == #K5c)
			{
				return true;
			}
			if (#dX != null)
			{
				while (#K5c != null)
				{
					while (#dX.Count != #K5c.Count)
					{
						if (!false)
						{
							return false;
						}
					}
					if (!false)
					{
						Dictionary<#Fu, int> dictionary = new Dictionary<!!0, int>();
						Dictionary<#Fu, int> dictionary2;
						if (8 != 0)
						{
							dictionary2 = dictionary;
						}
						IEnumerator<#Fu> enumerator = #dX.GetEnumerator();
						IEnumerator<#Fu> enumerator2;
						if (!false)
						{
							enumerator2 = enumerator;
						}
						try
						{
							while (enumerator2.MoveNext() || 5 == 0)
							{
								#Fu #Fu = enumerator2.Current;
								#Fu #Fu2;
								if (-1 != 0)
								{
									#Fu2 = #Fu;
								}
								if (dictionary2.ContainsKey(#Fu2) && !false)
								{
									Dictionary<#Fu, int> dictionary3 = dictionary2;
									#Fu #Fu3 = #Fu2;
									int num = dictionary3[#Fu3];
									int num2;
									if (8 != 0)
									{
										num2 = num;
									}
									!!0 key = #Fu3;
									int value = num2 + 1;
									if (!false)
									{
										dictionary3[key] = value;
									}
								}
								else
								{
									Dictionary<!!0, int> dictionary4 = dictionary2;
									!!0 key2 = #Fu2;
									int value2 = 1;
									if (3 != 0)
									{
										dictionary4.Add(key2, value2);
									}
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
						enumerator2 = #K5c.GetEnumerator();
						try
						{
							while (enumerator2.MoveNext())
							{
								#Fu #Fu4 = enumerator2.Current;
								if (!dictionary2.ContainsKey(#Fu4))
								{
									return false;
								}
								Dictionary<#Fu, int> dictionary5 = dictionary2;
								#Fu #Fu3 = #Fu4;
								int num2 = dictionary5[#Fu3];
								dictionary5[#Fu3] = num2 - 1;
							}
						}
						finally
						{
							if (enumerator2 == null)
							{
								goto IL_F1;
							}
							IL_EB:
							enumerator2.Dispose();
							IL_F1:
							if (5 == 0)
							{
								goto IL_EB;
							}
						}
						return dictionary2.Values.All(new Func<int, bool>(CollectionsComparer.<>c__1<!!0>.<>9.#hcd));
					}
				}
			}
			return false;
		}

		// Token: 0x06006BC0 RID: 27584 RVA: 0x001A091C File Offset: 0x0019EB1C
		public static bool #N5c<#Fu>(IReadOnlyList<#Fu> #dX, IReadOnlyList<#Fu> #K5c)
		{
			if (#dX == #K5c)
			{
				return true;
			}
			if (#dX != null)
			{
				while (#K5c != null)
				{
					while (#dX.Count != #K5c.Count)
					{
						if (!false)
						{
							return false;
						}
					}
					if (!false)
					{
						Dictionary<#Fu, int> dictionary = new Dictionary<!!0, int>();
						Dictionary<#Fu, int> dictionary2;
						if (8 != 0)
						{
							dictionary2 = dictionary;
						}
						IEnumerator<#Fu> enumerator = #dX.GetEnumerator();
						IEnumerator<#Fu> enumerator2;
						if (!false)
						{
							enumerator2 = enumerator;
						}
						try
						{
							while (enumerator2.MoveNext() || 5 == 0)
							{
								#Fu #Fu = enumerator2.Current;
								#Fu #Fu2;
								if (-1 != 0)
								{
									#Fu2 = #Fu;
								}
								if (dictionary2.ContainsKey(#Fu2) && !false)
								{
									Dictionary<#Fu, int> dictionary3 = dictionary2;
									#Fu #Fu3 = #Fu2;
									int num = dictionary3[#Fu3];
									int num2;
									if (8 != 0)
									{
										num2 = num;
									}
									!!0 key = #Fu3;
									int value = num2 + 1;
									if (!false)
									{
										dictionary3[key] = value;
									}
								}
								else
								{
									Dictionary<!!0, int> dictionary4 = dictionary2;
									!!0 key2 = #Fu2;
									int value2 = 1;
									if (3 != 0)
									{
										dictionary4.Add(key2, value2);
									}
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
						enumerator2 = #K5c.GetEnumerator();
						try
						{
							while (enumerator2.MoveNext())
							{
								#Fu #Fu4 = enumerator2.Current;
								if (!dictionary2.ContainsKey(#Fu4))
								{
									return false;
								}
								Dictionary<#Fu, int> dictionary5 = dictionary2;
								#Fu #Fu3 = #Fu4;
								int num2 = dictionary5[#Fu3];
								dictionary5[#Fu3] = num2 - 1;
							}
						}
						finally
						{
							if (enumerator2 == null)
							{
								goto IL_F1;
							}
							IL_EB:
							enumerator2.Dispose();
							IL_F1:
							if (5 == 0)
							{
								goto IL_EB;
							}
						}
						return dictionary2.Values.All(new Func<int, bool>(CollectionsComparer.<>c__2<!!0>.<>9.#icd));
					}
				}
			}
			return false;
		}

		// Token: 0x06006BC1 RID: 27585 RVA: 0x001A0A74 File Offset: 0x0019EC74
		public static bool #z3h<#Fu>(IList<#Fu> #O5c, IList<#Fu> #P5c, Func<#Fu, #Fu, bool> #Q5c)
		{
			int num5;
			if (!false && #O5c != null)
			{
				int num2;
				if (#P5c != null)
				{
					bool result;
					if (#Q5c == null)
					{
						int num = num2 = 107266010;
						if (num == 0)
						{
							goto IL_1E;
						}
						result = (num != 0);
						if (num != 0)
						{
							throw new ArgumentNullException(#Phc.#3hc(num));
						}
					}
					else
					{
						if (#O5c.Count != #P5c.Count)
						{
							return false;
						}
						int num3 = 0;
						int i;
						if (5 != 0)
						{
							i = num3;
						}
						while (i < #O5c.Count)
						{
							if (!#Q5c(#O5c[i], #P5c[i]))
							{
								return false;
							}
							int num4 = num5 = i + 1;
							if (false)
							{
								goto IL_0B;
							}
							if (3 != 0)
							{
								i = num4;
							}
						}
						result = true;
					}
					return result;
				}
				num2 = 107265987;
				IL_1E:
				throw new ArgumentNullException(#Phc.#3hc(num2));
			}
			num5 = 107265996;
			IL_0B:
			throw new ArgumentNullException(#Phc.#3hc(num5));
		}

		// Token: 0x06006BC2 RID: 27586 RVA: 0x001A0B10 File Offset: 0x0019ED10
		public static bool #uC<#Fu>(IList<#Fu> #O5c, IList<#Fu> #P5c, Func<#Fu, #Fu, bool> #Q5c)
		{
			if (!false)
			{
				CollectionsComparer<#Fu>.#lcd #lcd = new CollectionsComparer<!!0>.#lcd();
				CollectionsComparer<#Fu>.#lcd #lcd2;
				if (!false)
				{
					#lcd2 = #lcd;
				}
				#lcd2.#a = #Q5c;
				while (#O5c != null)
				{
					if (#P5c == null)
					{
						if (5 != 0)
						{
							throw new ArgumentNullException(#Phc.#3hc(107265987));
						}
					}
					else
					{
						if (#lcd2.#a == null)
						{
							throw new ArgumentNullException(#Phc.#3hc(107266010));
						}
						if (#O5c.Count != #P5c.Count)
						{
							return false;
						}
						IEnumerator<#Fu> enumerator = #O5c.GetEnumerator();
						IEnumerator<#Fu> enumerator2;
						if (!false)
						{
							enumerator2 = enumerator;
						}
						try
						{
							while (false || enumerator2.MoveNext())
							{
								CollectionsComparer<#Fu>.#mcd #mcd = new CollectionsComparer<!!0>.#mcd();
								CollectionsComparer<#Fu>.#mcd #mcd2;
								if (true)
								{
									#mcd2 = #mcd;
								}
								#mcd2.#b = #lcd2;
								if (-1 == 0)
								{
									break;
								}
								#mcd2.#a = enumerator2.Current;
								if (!#P5c.Any(new Func<!!0, bool>(#mcd2.#w2b)))
								{
									bool flag = false;
									bool result;
									if (true)
									{
										result = flag;
									}
									return result;
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
						return true;
					}
				}
			}
			throw new ArgumentNullException(#Phc.#3hc(107265996));
		}

		// Token: 0x06006BC3 RID: 27587 RVA: 0x001A0C08 File Offset: 0x0019EE08
		public static bool #uC<#Fu>(IReadOnlyList<#Fu> #O5c, IReadOnlyList<#Fu> #P5c, Func<#Fu, #Fu, bool> #Q5c)
		{
			if (!false)
			{
				CollectionsComparer<#Fu>.#I4d #I4d = new CollectionsComparer<!!0>.#I4d();
				CollectionsComparer<#Fu>.#I4d #I4d2;
				if (!false)
				{
					#I4d2 = #I4d;
				}
				#I4d2.#a = #Q5c;
				while (#O5c != null)
				{
					if (#P5c == null)
					{
						if (5 != 0)
						{
							throw new ArgumentNullException(#Phc.#3hc(107265987));
						}
					}
					else
					{
						if (#I4d2.#a == null)
						{
							throw new ArgumentNullException(#Phc.#3hc(107266010));
						}
						if (#O5c.Count != #P5c.Count)
						{
							return false;
						}
						IEnumerator<#Fu> enumerator = #O5c.GetEnumerator();
						IEnumerator<#Fu> enumerator2;
						if (!false)
						{
							enumerator2 = enumerator;
						}
						try
						{
							while (false || enumerator2.MoveNext())
							{
								CollectionsComparer<#Fu>.#G3h #G3h = new CollectionsComparer<!!0>.#G3h();
								CollectionsComparer<#Fu>.#G3h #G3h2;
								if (true)
								{
									#G3h2 = #G3h;
								}
								#G3h2.#b = #I4d2;
								if (-1 == 0)
								{
									break;
								}
								#G3h2.#a = enumerator2.Current;
								if (!#P5c.Any(new Func<!!0, bool>(#G3h2.#w2b)))
								{
									bool flag = false;
									bool result;
									if (true)
									{
										result = flag;
									}
									return result;
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
						return true;
					}
				}
			}
			throw new ArgumentNullException(#Phc.#3hc(107265996));
		}

		// Token: 0x02000CD9 RID: 3289
		[CompilerGenerated]
		private sealed class #lcd<#Fu>
		{
			// Token: 0x04002BE2 RID: 11234
			public Func<#Fu, #Fu, bool> #a;
		}

		// Token: 0x02000CDA RID: 3290
		[CompilerGenerated]
		private sealed class #mcd<#Fu>
		{
			// Token: 0x06006BCC RID: 27596 RVA: 0x00054A52 File Offset: 0x00052C52
			internal bool #w2b(#Fu #z9c)
			{
				return this.#b.#a(this.#a, #z9c);
			}

			// Token: 0x04002BE3 RID: 11235
			public #Fu #a;

			// Token: 0x04002BE4 RID: 11236
			public CollectionsComparer<#Fu>.#lcd #b;
		}

		// Token: 0x02000CDB RID: 3291
		[CompilerGenerated]
		private sealed class #I4d<#Fu>
		{
			// Token: 0x04002BE5 RID: 11237
			public Func<#Fu, #Fu, bool> #a;
		}

		// Token: 0x02000CDC RID: 3292
		[CompilerGenerated]
		private sealed class #G3h<#Fu>
		{
			// Token: 0x06006BCF RID: 27599 RVA: 0x00054A6B File Offset: 0x00052C6B
			internal bool #w2b(#Fu #z9c)
			{
				return this.#b.#a(this.#a, #z9c);
			}

			// Token: 0x04002BE6 RID: 11238
			public #Fu #a;

			// Token: 0x04002BE7 RID: 11239
			public CollectionsComparer<#Fu>.#I4d #b;
		}
	}
}
