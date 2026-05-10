using System;
using System.Drawing.Printing;
using #4vc;
using #7hc;
using StructurePoint.CoreAssets.GUI.Reporter.Core.Printing;

namespace #hId
{
	// Token: 0x02000DA1 RID: 3489
	internal sealed class #zId : #Swc<int>, #hwc<int>, IPageSelection
	{
		// Token: 0x06007E40 RID: 32320 RVA: 0x00066CD1 File Offset: 0x00064ED1
		public #zId(int #cj, int #AId) : base(#cj, #AId)
		{
		}

		// Token: 0x06007E41 RID: 32321 RVA: 0x00066CDB File Offset: 0x00064EDB
		public override #hwc<int> #ul(int #Akb, int #Bkb)
		{
			return new #zId(#Akb, #Bkb);
		}

		// Token: 0x06007E42 RID: 32322 RVA: 0x001BC1C0 File Offset: 0x001BA3C0
		public void #iId(PrinterSettings #Pzc)
		{
			if (#Pzc == null)
			{
				throw new ArgumentNullException(#Phc.#3hc(107281057));
			}
			\u000F\u0005.~\u009D\u000E(#Pzc, PrintRange.SomePages);
			\u0087\u0002.~\u0082\u0005(#Pzc, base.Start);
			\u0087\u0002.~\u0083\u0005(#Pzc, base.End);
		}
	}
}
