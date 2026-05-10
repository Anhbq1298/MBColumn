using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using #7hc;

namespace StructurePoint.CoreAssets.Infrastructure.Extensions
{
	// Token: 0x02000EE9 RID: 3817
	public static class LinqToObjectsExtensionMethods
	{
		// Token: 0x06008737 RID: 34615 RVA: 0x0006DEF1 File Offset: 0x0006C0F1
		private static IEnumerable<HierarchyNode<#sR>> #P1d<#sR, #10>(IEnumerable<#sR> #Q1d, #sR #R1d, Func<#sR, #10> #S1d, Func<#sR, #10> #T1d, object #U1d, int #V1d, int #5Q) where #sR : class
		{
			LinqToObjectsExtensionMethods<!!0, !!1>.#F4d #F4d = new LinqToObjectsExtensionMethods<!!0, !!1>.#F4d(-2);
			#F4d.#m = #Q1d;
			#F4d.#k = #R1d;
			#F4d.#e = #S1d;
			#F4d.#i = #T1d;
			#F4d.#g = #U1d;
			#F4d.#q = #V1d;
			#F4d.#o = #5Q;
			return #F4d;
		}

		// Token: 0x06008738 RID: 34616 RVA: 0x001CFF54 File Offset: 0x001CE154
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		public static IEnumerable<HierarchyNode<#sR>> #W1d<#sR, #10>(this IEnumerable<#sR> #Q1d, Func<#sR, #10> #S1d, Func<#sR, #10> #T1d) where #sR : class
		{
			return LinqToObjectsExtensionMethods.#P1d<#sR, #10>(#Q1d, default(!!0), #S1d, #T1d, null, 0, 0);
		}

		// Token: 0x06008739 RID: 34617 RVA: 0x001CFF78 File Offset: 0x001CE178
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		public static IEnumerable<HierarchyNode<#sR>> #W1d<#sR, #10>(this IEnumerable<#sR> #Q1d, Func<#sR, #10> #S1d, Func<#sR, #10> #T1d, object #U1d) where #sR : class
		{
			return LinqToObjectsExtensionMethods.#P1d<#sR, #10>(#Q1d, default(!!0), #S1d, #T1d, #U1d, 0, 0);
		}

		// Token: 0x0600873A RID: 34618 RVA: 0x001CFF9C File Offset: 0x001CE19C
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		public static IEnumerable<HierarchyNode<#sR>> #W1d<#sR, #10>(this IEnumerable<#sR> #Q1d, Func<#sR, #10> #S1d, Func<#sR, #10> #T1d, object #U1d, int #V1d) where #sR : class
		{
			return LinqToObjectsExtensionMethods.#P1d<#sR, #10>(#Q1d, default(!!0), #S1d, #T1d, #U1d, #V1d, 0);
		}

		// Token: 0x0600873B RID: 34619 RVA: 0x0006DF2E File Offset: 0x0006C12E
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		public static IEnumerable<HierarchyNode<#sR>> #X1d<#sR>(this IEnumerable<HierarchyNode<#sR>> #Y1d) where #sR : class
		{
			while (#Y1d == null)
			{
				if (!false)
				{
					throw new ArgumentNullException(#Phc.#3hc(107225589));
				}
			}
			return #Y1d.#X1d(new Func<HierarchyNode<!!0>, IEnumerable<HierarchyNode<!!0>>>(LinqToObjectsExtensionMethods.<>c__4<!!0>.<>9.#G4d));
		}

		// Token: 0x0600873C RID: 34620 RVA: 0x001CFFC0 File Offset: 0x001CE1C0
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		public static IEnumerable<#Fu> #X1d<#Fu>(this IEnumerable<#Fu> #8f, Func<#Fu, IEnumerable<#Fu>> #Z1d)
		{
			LinqToObjectsExtensionMethods<#Fu>.#I4d #I4d = new LinqToObjectsExtensionMethods<!!0>.#I4d();
			LinqToObjectsExtensionMethods<#Fu>.#I4d #I4d2;
			if (5 != 0)
			{
				#I4d2 = #I4d;
			}
			#I4d2.#a = #Z1d;
			while (#8f != null)
			{
				if (#I4d2.#a == null)
				{
					throw new ArgumentNullException(#Phc.#3hc(107225544));
				}
				List<#Fu> list = #8f.ToList<#Fu>();
				List<#Fu> list2;
				if (!false)
				{
					list2 = list;
				}
				if (8 != 0)
				{
					return list2.SelectMany(new Func<!!0, IEnumerable<!!0>>(#I4d2.#H4d)).Concat(list2);
				}
			}
			throw new ArgumentNullException(#Phc.#3hc(107264273));
		}

		// Token: 0x02000EEB RID: 3819
		[CompilerGenerated]
		private sealed class #C4d<#sR, #10> where #sR : class
		{
			// Token: 0x06008741 RID: 34625 RVA: 0x001D0034 File Offset: 0x001CE234
			internal bool #z4d(#sR #Ttb)
			{
				#10 #2;
				do
				{
					#10 # = this.#a(#Ttb);
					if (2 != 0)
					{
						#2 = #;
					}
				}
				while (false);
				return #2.Equals(this.#b);
			}

			// Token: 0x06008742 RID: 34626 RVA: 0x001D006C File Offset: 0x001CE26C
			internal bool #A4d(#sR #Ttb)
			{
				return object.Equals(this.#c(#Ttb), default(!1));
			}

			// Token: 0x06008743 RID: 34627 RVA: 0x0006DF7F File Offset: 0x0006C17F
			internal bool #B4d(#sR #Ttb)
			{
				return object.Equals(this.#c(#Ttb), this.#a(this.#d));
			}

			// Token: 0x040037DC RID: 14300
			public Func<#sR, #10> #a;

			// Token: 0x040037DD RID: 14301
			public object #b;

			// Token: 0x040037DE RID: 14302
			public Func<#sR, #10> #c;

			// Token: 0x040037DF RID: 14303
			public #sR #d;
		}

		// Token: 0x02000EEC RID: 3820
		[CompilerGenerated]
		private sealed class #I4d<#Fu>
		{
			// Token: 0x06008745 RID: 34629 RVA: 0x0006DFAD File Offset: 0x0006C1AD
			internal IEnumerable<#Fu> #H4d(#Fu #uYb)
			{
				return this.#a(#uYb).#X1d(this.#a);
			}

			// Token: 0x040037E0 RID: 14304
			public Func<#Fu, IEnumerable<#Fu>> #a;
		}
	}
}
