using System;
using System.Collections.Generic;
using #y6e;
using StructurePoint.CoreAssets.AppManager.Column.Engineer.Communication;

namespace #gMe
{
	// Token: 0x020012BE RID: 4798
	internal sealed class #TQe
	{
		// Token: 0x0600A0B6 RID: 41142 RVA: 0x0007E254 File Offset: 0x0007C454
		public static IEnumerable<Message> #un(#L6e #SQe)
		{
			#L6e[] array = new #L6e[]
			{
				#L6e.#f,
				#L6e.#e,
				#L6e.#h,
				#L6e.#b,
				#L6e.#c,
				#L6e.#d,
				#L6e.#g,
				#L6e.#i
			};
			#M6e[] array2 = new #M6e[]
			{
				#M6e.#z,
				#M6e.#A,
				#M6e.#m,
				#M6e.#n,
				#M6e.#o,
				#M6e.#p,
				#M6e.#h,
				#M6e.#l
			};
			int num;
			for (int i = 0; i < array.Length; i = num + 1)
			{
				if (#SQe.HasFlag(array[i]))
				{
					yield return Message.#S6e(array2[i], Array.Empty<object>());
				}
				num = i;
			}
			yield break;
		}
	}
}
