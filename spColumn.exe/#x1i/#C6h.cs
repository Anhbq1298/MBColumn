using System;
using #7hc;
using #w1i;

namespace #x1i
{
	// Token: 0x02000E62 RID: 3682
	internal sealed class #C6h : Exception
	{
		// Token: 0x060083D7 RID: 33751 RVA: 0x0006B7E8 File Offset: 0x000699E8
		private void #A6h(#z6h #Zfc)
		{
			this.Data.Add(#C6h.#a, #Zfc);
		}

		// Token: 0x17002799 RID: 10137
		// (get) Token: 0x060083D8 RID: 33752 RVA: 0x0006B800 File Offset: 0x00069A00
		public #z6h ErrorCode
		{
			get
			{
				return (#z6h)this.Data[#C6h.#a];
			}
		}

		// Token: 0x060083D9 RID: 33753 RVA: 0x0006B817 File Offset: 0x00069A17
		internal static string #B6h(string #5, #z6h #Zfc)
		{
			return #5.Trim() + #Phc.#3hc(107399922) + string.Format(#Ab.SpImporterException_ErrorCodePostfix, (int)#Zfc);
		}

		// Token: 0x060083DA RID: 33754 RVA: 0x0006B83E File Offset: 0x00069A3E
		public #C6h(#z6h #Zfc) : base(#C6h.#B6h(#Phc.#3hc(107381628), #Zfc))
		{
			this.#A6h(#Zfc);
		}

		// Token: 0x060083DB RID: 33755 RVA: 0x0006B85D File Offset: 0x00069A5D
		public #C6h(string #5, #z6h #Zfc) : base(#C6h.#B6h(#5, #Zfc))
		{
			this.#A6h(#Zfc);
		}

		// Token: 0x060083DC RID: 33756 RVA: 0x0006B873 File Offset: 0x00069A73
		public #C6h(string #5, #z6h #Zfc, Exception #Uic) : base(#C6h.#B6h(#5, #Zfc), #Uic)
		{
			this.#A6h(#Zfc);
		}

		// Token: 0x04003658 RID: 13912
		private static readonly string #a = #Phc.#3hc(107269245);
	}
}
