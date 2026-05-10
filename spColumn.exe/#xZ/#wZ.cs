using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;
using #EZ;
using SimpleInjector;
using StructurePoint.CoreAssets.Infrastructure.Extensions;
using StructurePoint.CoreAssets.Localizer;

namespace #xZ
{
	// Token: 0x02000389 RID: 905
	internal static class #wZ
	{
		// Token: 0x17000A43 RID: 2627
		// (get) Token: 0x06001D5A RID: 7514 RVA: 0x0001C20D File Offset: 0x0001A40D
		// (set) Token: 0x06001D5B RID: 7515 RVA: 0x0001C214 File Offset: 0x0001A414
		internal static Container Container { get; set; }

		// Token: 0x06001D5C RID: 7516 RVA: 0x0001C220 File Offset: 0x0001A420
		public static #HZ #uZ(Type #C)
		{
			return #wZ.#vZ(#C);
		}

		// Token: 0x06001D5D RID: 7517 RVA: 0x000C1334 File Offset: 0x000BF534
		public static #HZ #vZ(Type #C)
		{
			if (#C == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107383497));
			}
			#HZ #HZ;
			if (#wZ.#a.TryGetValue(#C, out #HZ) && #HZ != null)
			{
				return #HZ;
			}
			List<#zZ> list = #C.GetCustomAttributes(true).OfType<#zZ>().ToList<#zZ>();
			if (list.Count == 1)
			{
				#zZ #zZ = list.First<#zZ>();
				#HZ = (#HZ)#wZ.Container.GetInstance(#zZ.ValidatorType);
				#wZ.#a[#C] = #HZ;
			}
			if (#HZ == null)
			{
				throw new InvalidOperationException(Strings.StringValidatorNotFound.#z2d());
			}
			return #HZ;
		}

		// Token: 0x04000BBB RID: 3003
		private static readonly ConcurrentDictionary<Type, #HZ> #a = new ConcurrentDictionary<Type, #HZ>();

		// Token: 0x04000BBC RID: 3004
		[CompilerGenerated]
		private static Container #b;
	}
}
