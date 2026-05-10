using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace StructurePoint.CoreAssets.GUI.DesktopControls.ModelEditor.Drawing
{
	// Token: 0x02000981 RID: 2433
	public static class ListHelper
	{
		// Token: 0x06004F5C RID: 20316 RVA: 0x0015BA10 File Offset: 0x00159C10
		public static bool EnsureCapacity<T>(this IList<T> list, int additionalCapacity)
		{
			#X0d.#V0d(list, #Phc.#3hc(107467337), Component.DesktopControls, #Phc.#3hc(107467328));
			List<T> list2 = list as List<!!0>;
			return list2 != null && list2.EnsureCapacity(additionalCapacity);
		}

		// Token: 0x06004F5D RID: 20317 RVA: 0x0015BA58 File Offset: 0x00159C58
		public static bool EnsureTotalCapacity<T>(this IList<T> list, int capacity)
		{
			List<T> list2 = list as List<!!0>;
			return list2 != null && list2.EnsureTotalCapacity(capacity);
		}

		// Token: 0x06004F5E RID: 20318 RVA: 0x00042168 File Offset: 0x00040368
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public static bool EnsureTotalCapacity<T>(this List<T> list, int capacity)
		{
			#X0d.#V0d(list, #Phc.#3hc(107467337), Component.DesktopControls, #Phc.#3hc(107467275));
			list.Capacity = Math.Max(list.Capacity, capacity);
			return true;
		}

		// Token: 0x06004F5F RID: 20319 RVA: 0x0015BA84 File Offset: 0x00159C84
		[SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
		public static bool EnsureCapacity<T>(this List<T> list, int additionalCapacity)
		{
			#X0d.#V0d(list, #Phc.#3hc(107467337), Component.DesktopControls, #Phc.#3hc(107467766));
			if (list.Capacity - list.Count <= additionalCapacity)
			{
				list.Capacity += additionalCapacity + 1;
			}
			return true;
		}
	}
}
