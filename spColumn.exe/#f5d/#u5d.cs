using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using #7hc;
using #pXd;
using StructurePoint.CoreAssets.Infrastructure.Extensions;

namespace #f5d
{
	// Token: 0x02000F26 RID: 3878
	internal sealed class #u5d : #TXd
	{
		// Token: 0x060089A7 RID: 35239 RVA: 0x001D65F4 File Offset: 0x001D47F4
		[MethodImpl(MethodImplOptions.NoInlining)]
		public string #QXd(int #RXd)
		{
			MethodBase method = new StackTrace().GetFrame(#RXd).GetMethod();
			return #Phc.#3hc(107222631).#D2d(new object[]
			{
				method.Name,
				method.MethodHandle.GetFunctionPointer()
			});
		}

		// Token: 0x060089A8 RID: 35240 RVA: 0x00070188 File Offset: 0x0006E388
		public string #SXd()
		{
			return new StackTrace().ToString();
		}
	}
}
