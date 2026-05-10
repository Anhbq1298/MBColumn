using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using #7hc;
using #UYd;
using StructurePoint.CoreAssets.Infrastructure.Exceptions;

namespace #ezc
{
	// Token: 0x02000B34 RID: 2868
	internal static class #mzc
	{
		// Token: 0x06005DD1 RID: 24017 RVA: 0x0017616C File Offset: 0x0017436C
		public static bool #kzc(Assembly #lzc)
		{
			bool result;
			AssemblyName[] array;
			int i;
			do
			{
				string #R0d = #Phc.#3hc(107420270);
				Component #x6c = Component.GUIFramework;
				string #Qic = #Phc.#3hc(107420257);
				if (!false)
				{
					#X0d.#V0d(#lzc, #R0d, #x6c, #Qic);
				}
				bool flag = true;
				if (!false)
				{
					result = flag;
				}
				AssemblyName[] referencedAssemblies = #lzc.GetReferencedAssemblies();
				if (!false)
				{
					array = referencedAssemblies;
				}
				int num = 0;
				if (!false)
				{
					i = num;
				}
			}
			while (2 == 0);
			while (i < array.Length)
			{
				#mzc.#GTb #GTb2;
				if (!false)
				{
					#mzc.#GTb #GTb = new #mzc.#GTb();
					if (!false)
					{
						#GTb2 = #GTb;
					}
					#GTb2.#a = array[i];
				}
				if (AppDomain.CurrentDomain.GetAssemblies().All(new Func<Assembly, bool>(#GTb2.#m8c)))
				{
					try
					{
						do
						{
							#mzc.#kzc(AppDomain.CurrentDomain.Load(#GTb2.#a));
						}
						while (7 == 0);
					}
					catch (Exception)
					{
						do
						{
							result = false;
						}
						while (false);
					}
				}
				int num2 = i + 1;
				if (7 != 0)
				{
					i = num2;
				}
			}
			return result;
		}

		// Token: 0x02000B35 RID: 2869
		[CompilerGenerated]
		private sealed class #GTb
		{
			// Token: 0x06005DD3 RID: 24019 RVA: 0x0004E314 File Offset: 0x0004C514
			internal bool #m8c(Assembly #Rf)
			{
				return #Rf.FullName != this.#a.FullName;
			}

			// Token: 0x040026F7 RID: 9975
			public AssemblyName #a;
		}
	}
}
